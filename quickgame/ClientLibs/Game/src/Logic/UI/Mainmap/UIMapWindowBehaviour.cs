//------------------------------------------
// File: UIMapWindowBehaviour.cs
// Desc: 区域地图界面上的组件
// Authro: raorui 重构
// Date: 2017.11.15
//------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using xc.protocol;
using xc.ui;
using System.Collections;
using System.Collections.Generic;
using Net;
using Utils;
namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIMapWindowBehaviour : IUIBehaviour
    {
        const float m_MapPointDistance = 23.0f;
        const float m_MapPointRemoveDistance = 20.0f;

        /// <summary>
        /// 当前地图对应的场景id(可以通过外部传入)
        /// </summary>
        uint m_CurSceneId;

        /// <summary>
        /// 怪物挂机点标识的UI物体
        /// </summary>
        GameObject m_MonsterPoint;

        /// <summary>
        /// 传送点标识的UI物体
        /// </summary>
        GameObject m_TranspotPoint;
        
        /// <summary>
        /// npc标识的UI物体
        /// </summary>
        GameObject m_NpcPoint;

        /// <summary>
        /// 队员标识的UI物体
        /// </summary>
        GameObject m_TeamPoint;

        /// <summary>
        /// 本地玩家标识的UI物体
        /// </summary>
        GameObject m_LocalPlayerPoint;

        /// <summary>
        /// 显示挂机点怪物相关信息的UI物体
        /// </summary>
        GameObject m_MonsterInfo;

        /// <summary>
        /// 前往挂机的按钮
        /// </summary>
        Button m_GotoBtn;

        RectTransform mPathPointRectTemplate;

        /// <summary>
        /// 网络消息应答，用来判断发送MSG_TEAM_MEMBER_POS后，服务端是否有消息返回
        /// </summary>
        bool m_bNetAnswer = false;

        GameObject mEndPathGo;
        RawImage mMiniMapRawImage;

        /// <summary>
        /// 本地玩家在地图上的二维坐标位置
        /// </summary>
        Vector2 m_PlayerPos = Vector2.zero;

        /// <summary>
        /// 本地玩家UI物体的localposition
        /// </summary>
        Vector3 m_PlayerLocalPos = Vector3.zero;

        Vector3 LocalPlayerEulerAngles = Vector3.zero;
        GameObject MonsterLineObj;
        EventTriggerListener MonsterTipsTrigger;
        
        ScrollRect mMapScroll;
        Dictionary<int,GameObject> mMonsterListPointObjs = new Dictionary<int, GameObject>();
        List<GameObject> mTranspotListPointObjs = new List<GameObject>();
        List<GameObject> mTeamListPointObjs = new List<GameObject>();

        Dictionary<uint, GameObject> mNpcListPointObjs = new Dictionary<uint, GameObject>();

        /// <summary>
        /// 加载的地图图片资源
        /// </summary>
        private SGameEngine.AssetResource m_AssetRes;
        float uiScalex = 0;
        float uiScaley = 0;
        float minX = 0;
        float minY = 0;
        float m_MonsterTipsOffsetY = 22;

        /// <summary>
        /// 地图上的寻路点(2维坐标)
        /// </summary>
        List<Vector2> m_PathPoints = new List<Vector2>();

        /// <summary>
        /// 地图上的寻路点(ui组件)
        /// </summary>
        List<RectTransform> m_PathPointTrans = new List<RectTransform>();

        Utils.Timer mUpdateTeamPosCd;
        MiniMapPointInfo mCurrentMonsterInfo;
        bool isStartPath = false;

        Dictionary<int, MiniMapPointInfo> WorldBossList = new Dictionary<int, MiniMapPointInfo>();
        public override void InitBehaviour()
        {
            m_LocalPlayerPoint = Window.FindChild("LocalPlayerPoint");
            m_MonsterPoint = Window.FindChild("MonsterPoint");
            m_TranspotPoint = Window.FindChild("TranspotPoint");
            m_NpcPoint = Window.FindChild("NpcPoint");
            m_TeamPoint = Window.FindChild("TeamPlayerPoint");

            mMiniMapRawImage = Window.FindChild<RawImage>("MapTexture");
            MonsterLineObj = Window.FindChild("MonsterLine");
            mEndPathGo = Window.FindChild("EndPathPoint");
            mMiniMapRawImage.enabled = false;
            mMapScroll = Window.FindChild<ScrollRect>("MapScrollView");
            m_MonsterInfo = Window.FindChild("MonsterInfo");
            mPathPointRectTemplate = Window.FindChild<RectTransform>("PathPoint");
            m_GotoBtn = Window.FindChild<Button>("GotoBtn");
            m_GotoBtn.onClick.AddListener(OnClickGotoMonster);
             mCurrentMonsterInfo = null;
            MonsterTipsTrigger = EventTriggerListener.GetListener(Window.FindChild("MonsterTips"));
            MonsterTipsTrigger.onPointerDown += LostMonsterTips;
            MonsterTipsTrigger.gameObject.SetActive(false);
            mPathPointRectTemplate.gameObject.SetActive(false);
            mEndPathGo.SetActive(false);
            UIResourceManager.Instance.InitPool(m_MonsterPoint, 5);
            UIResourceManager.Instance.InitPool(m_TranspotPoint, 3);
            UIResourceManager.Instance.InitPool(m_NpcPoint, 3);
            UIResourceManager.Instance.InitPool(m_TeamPoint, 2);
            UIResourceManager.Instance.InitPool(mPathPointRectTemplate.gameObject, 5);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.TASK_CHANGED, UpdateNpcState);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, UpdateRequsetTeam);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO, MonsterSelectChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTOR_PATH_POINTS_CHANGED, OnWalkPathChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_MINI_MAP_COM_POS, ClickMiniMapPos);
            ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL, UpdateWorldBossState);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_MEMBER_POS, UpdateTeam);
            base.InitBehaviour();
        }

        /// <summary>
        /// 创建挂机点怪物和特殊怪物(世界boss)位置的UI物体
        /// </summary>
        public void CreateMonsterPoint()
        {
            var monster_infos = MiniMapHelp.GetInstanceAllNormalMonster(m_CurSceneId);
            WorldBossList.Clear();
            for (int i = 0; i < monster_infos.Count; i++)
            {
                var info = monster_infos[i];
                var rect = GetItem(m_MonsterPoint);
                Vector3 vect = new Vector3((info.Position.x - minX) / uiScalex, (info.Position.z - minY) / uiScaley, 0);
                rect.localPosition = vect;
                Text nameText = UIHelper.FindChild(rect.gameObject, "NameText").GetComponent<Text>();
                var monster1 = UIHelper.FindChild(rect.gameObject, "MonsterType1");
                var monster2 = UIHelper.FindChild(rect.gameObject, "MonsterType2");
                var monster3 = UIHelper.FindChild(rect.gameObject, "MonsterType3");
                var bossDead = UIHelper.FindChild(rect.gameObject, "BossDead");
                Button moneterBtn = rect.GetComponent<Button>();
                moneterBtn.onClick.RemoveAllListeners();
                moneterBtn.onClick.AddListener(() => { OnClickMonsterPoint(info); });
                monster1.SetActive(false);
                monster2.SetActive(false);
                monster3.SetActive(false);
                bossDead.SetActive(false);

                string blackLv = ActorHelper.GetColorLvDiff(info.ActorId, 1);
                switch (info.PointType)
                {
                    case MiniMapPointType.Monster:
                    case MiniMapPointType.EliteMonster:
                        monster2.SetActive(true);
                        nameText.text = info.BlackName;
                        break;

                    case MiniMapPointType.Boss:
                        monster3.SetActive(true);
                        WorldBossList.Add(info.Id, info);
                        nameText.text = string.Format("{0}\n{1}", info.BlackName, blackLv);
                        break;
                }

                mMonsterListPointObjs.Add(info.Id, rect.gameObject);
            }
        }

        /// <summary>
        /// 点击怪物挂机点的按钮
        /// </summary>
        /// <param name="info"></param>
        public void OnClickMonsterPoint(MiniMapPointInfo info)
        {
            MonsterTipsTrigger.gameObject.SetActive(true);
            MonsterTipsTrigger.transform.SetAsLastSibling();
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO, new CEventEventParamArgs("MiniMap",info));
            SetMonsterTipsInfo(info);
        }

        public void LostMonsterTips(GameObject go)
        {
            MonsterTipsTrigger.gameObject.SetActive(false);
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO, new CEventEventParamArgs("MiniMap", null));
        }

        /// <summary>
        /// 当本地玩家的寻路路径改变
        /// </summary>
        /// <param name="evt"></param>
        public void OnWalkPathChange(CEventBaseArgs evt)
        {
            if (IsEnable == false)
                return;

            // 重新创建寻路点
            CreatePathPoint();
        }

        public void UpdateWorldBossState(CEventBaseArgs evt)
        {
            if (IsEnable == false)
                return;
            foreach (var kv in WorldBossList)
            {
                var pkg = xc.instance_behaviour.BossBehaviour.GetPkgBossInfo((uint)kv.Key);
                if (pkg != null)
                {
                    bool isDead = pkg.state == 0 ? true : false;
                    GameObject go;
                    if(mMonsterListPointObjs.TryGetValue(kv.Key , out go))
                    {
                        var bossDead = UIHelper.FindChild(go, "BossDead");
                        bossDead.SetActive(isDead);
                    }
                }
            }
        }

        /// <summary>
        /// 点击地图上的某一位置
        /// </summary>
        /// <param name="evt"></param>
        public void ClickMiniMapPos(CEventBaseArgs evt)
        {
            if (IsEnable == false)
                return;

            Vector2 pos = (Vector2)evt.arg;
            Vector2 _pos = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(mMiniMapRawImage.rectTransform, pos, xc.ui.ugui.UIMainCtrl.MainCam, out pos))
            {
                
                isStartPath = true;
                Vector3 finalVect = new Vector3();
                finalVect.x = pos.x * uiScalex + minX;
                finalVect.z = pos.y * uiScaley + minY;
                TargetPathManager.Instance.GoToConstPosition(m_CurSceneId, SceneHelp.Instance.CurLine, finalVect, null, () => {
                    isStartPath = false;
                });
                CreatePathPoint();
            }
        }

        /// <summary>
        /// 清除掉寻路坐标点和对应的ui物体
        /// </summary>
        public void ClearPathPoint()
        {
            m_PathPoints.Clear();
            if (m_PathPointTrans.Count > 0)
            {
                for (int i = 0; i < m_PathPointTrans.Count; i++)
                {
                    UIResourceManager.Instance.ReturnObjectToPool(m_PathPointTrans[i].gameObject);
                }
                m_PathPointTrans.Clear();
            }
        }

        BetterList<Vector3> m_PathPos = new BetterList<Vector3>();

        /// <summary>
        /// 创建寻路点
        /// </summary>
        public void CreatePathPoint()
        {
            var local_player = Game.Instance.GetLocalPlayer();
            if (local_player == null)
                return;

            ClearPathPoint();

            var scene_path_points = local_player.DestList;// 获取玩家当前的寻路路径
            if (scene_path_points == null || scene_path_points.size <= 0)
                return;

            m_PathPos.Clear();
            m_PathPos.Add(local_player.transform.position);
            for (int i = 0; i < scene_path_points.size; ++i)
            {
                m_PathPos.Add(scene_path_points[i]);
            }

            int pre_node_index = 0;// 记录上一次与当前路径点差距太小而没有计算插值的路径点索引
            for (int i = 0; i < m_PathPos.size; i++)
            {
                if (i == 0)
                    continue;

                Vector2 now_point = new Vector2((m_PathPos[i].x - minX) / uiScalex, (m_PathPos[i].z - minY) / uiScaley);
                
                // 获取上一个路径点的位置，如果与当前路径点差距太大，需要补齐，如果太小，则不添加到列表中
                Vector2 pre_point = Vector2.zero;
                if(pre_node_index != 0)
                    pre_point = new Vector2((m_PathPos[pre_node_index].x - minX) / uiScalex, (m_PathPos[pre_node_index].z - minY) / uiScaley);
                else
                {
                    pre_node_index = i - 1;
                    pre_point = new Vector2((m_PathPos[pre_node_index].x - minX) / uiScalex, (m_PathPos[pre_node_index].z - minY) / uiScaley);
                }

                float length = Vector2.Distance(now_point, pre_point);
                if(length > m_MapPointDistance)
                {
                    pre_node_index = 0;
                    int inter_count = Mathf.FloorToInt(length / m_MapPointDistance);// 需要插值增加的路径点数量
                    for (int j = 0; j <= inter_count; j++)
                    {
                        Vector2 middle_point = pre_point + (now_point - pre_point) * (j / (float)inter_count);
                        m_PathPoints.Add(middle_point);
                    }
                }
            }

            for (int i = 0; i < m_PathPoints.Count; i++)
            {
                Vector2 now = m_PathPoints[i];
                var item = GetItem(mPathPointRectTemplate.gameObject);
                item.localPosition = now;
                m_PathPointTrans.Add(item);
                if (i == m_PathPoints.Count - 1)
                {
                    mEndPathGo.SetActive(true);
                    mEndPathGo.transform.localPosition = now;
                }
            }

            mEndPathGo.transform.SetAsLastSibling();
            m_LocalPlayerPoint.transform.SetAsLastSibling();
            MonsterTipsTrigger.transform.SetAsLastSibling();
        }

        public void UpdatePathPoint()
        {
            for (int i = 0; i < m_PathPointTrans.Count; i++)
            {
                UIResourceManager.Instance.ReturnObjectToPool(m_PathPointTrans[i].gameObject);
            }
            mEndPathGo.transform.SetAsLastSibling();
            m_LocalPlayerPoint.transform.SetAsLastSibling();
            MonsterTipsTrigger.transform.SetAsLastSibling();
        }


        /// <summary>
        /// 响应最佳刷怪点的按钮的点击消息
        /// </summary>
        /// <param name="evt"></param>
        public void MonsterSelectChange(CEventBaseArgs evt)
        {
            if (IsEnable == false)
                return;

            if (evt is CEventEventParamArgs)
            {
                CEventEventParamArgs moreEvt = evt as CEventEventParamArgs;
                string str = moreEvt.mMoreParam[0] as string;
                MiniMapPointInfo info = moreEvt.mMoreParam[1] as MiniMapPointInfo;
                if(str.CompareTo("MiniMap") != 0)// 不是Minimap的时候，显示怪物挂机的提示框
                {
                    MonsterTipsTrigger.gameObject.SetActive(true);
                    MonsterTipsTrigger.transform.SetAsLastSibling();
                    SetMonsterTipsInfo(info);
                }
            }
        }

        /// <summary>
        /// 设置怪物挂架的tips
        /// </summary>
        /// <param name="info"></param>
        public void SetMonsterTipsInfo(MiniMapPointInfo info)
        {
            mCurrentMonsterInfo = info;
            string key = string.Format("{0}_{1}", info.Tag, m_CurSceneId);

            // F副本.xlsx -- 刷怪点信息
            var data_actor_tag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_actor_tag", "csv_id", key);


            //服务端不建议改表格式
            //List<Dictionary<string, string>> data_actor_tag = null;
            //string key = string.Empty;
            //SDKConfig sdk_config = SDKHelper.GetSDKConfig();
            //if (sdk_config != null && SDKHelper.IsCopyBag() && AuditManager.Instance.Open)
            //{
            //    key = string.Format("{0}_{1}{2}", info.Tag, m_CurSceneId, sdk_config.SDKNamePrefix);
            //    data_actor_tag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_actor_tag", "csv_id", key);
            //}

            ////当对应的马甲包没配置对应的数据时，就直接用正式数据
            //if (data_actor_tag == null || data_actor_tag.Count == 0)
            //{
            //    key = string.Format("{0}_{1}", info.Tag, m_CurSceneId);// 唯一id由{tag_id}_{map_id}组成
            //    data_actor_tag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_actor_tag", "csv_id", key);
            //}






            string titlestr = string.Empty;
            string contentstr = string.Empty;

            if (info.PointType != MiniMapPointType.Boss) // 普通怪物
            {
                if (data_actor_tag.Count > 0)
                {
                    var table = data_actor_tag[0];
                    uint level = DBTextResource.ParseUI(table["min_level"]);

                    string levelDesc = string.Empty;
                    uint peakLevel = 0;
                    bool isPeak = TransferHelper.IsPeak(level, out peakLevel);
                    if (isPeak)
                    {
                        var fmt = DBConstText.GetText("UI_PLAYER_PEAK_LEVEL_FORMAT"); // 巅峰{0}级
                        levelDesc = string.Format(fmt, peakLevel);
                    }
                    else
                    {
                        var fmt = DBConstText.GetText("UI_PLAYER_LEVEL_FORMAT"); // {0}级
                        levelDesc = string.Format(fmt, peakLevel);
                    }

                    uint def = DBTextResource.ParseUI(table["min_def"]);
                    string _def = string.Empty;
                    if (LocalPlayerManager.Instance.Level < level)
                        levelDesc = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_108"), GameConst.COLOR_DARK_RED, levelDesc);
                    else
                        levelDesc = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_108"), GameConst.COLOR_DARK_GREEN, levelDesc);

                    var Def = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_DEF].Value;
                    if (Def < def)
                        _def = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_109"), GameConst.COLOR_DARK_RED, def);
                    else
                        _def = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_109"), GameConst.COLOR_DARK_GREEN, def);

                    titlestr = levelDesc + _def;

                    StringBuilder award_desc = new StringBuilder(150);
                    award_desc.AppendFormat(xc.TextHelper.GetTranslateText(table["tips1_format"]), table["tips1"]);
                    award_desc.Append('\n');
                    award_desc.AppendFormat(xc.TextHelper.GetTranslateText(table["tips2_format"]), table["tips2"]);
                    award_desc.Append('\n');
                    award_desc.AppendFormat(xc.TextHelper.GetTranslateText(table["tips3_format"]), table["tips3"]);

                    contentstr = award_desc.ToString();
                }
                else
                {
                    titlestr = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_110"));
                    contentstr = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_111")); ;
                }
            }
            else
            {
                if (GlobalConst.IsBanshuVersion)
                    titlestr = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_112"), GameConst.COLOR_DARK_RED, info.BlackName, info.Level);
                else
                    titlestr = string.Format("{0}{1} Lv{2}</color>", GameConst.COLOR_DARK_RED, info.BlackName, info.Level);

                uint actorId = (uint)info.ActorId;

                bool isSouthLandBoss = ActorHelper.IsSouthLandBoss(actorId); // 南天圣地boss
                bool isElementAreaBoss = ActorHelper.IsElementAreaBoss(actorId); // 元素禁地boss
                if ( isSouthLandBoss || isElementAreaBoss)
                {
                    // 浊气值
                    uint evilValue = 0;

                    if (isSouthLandBoss)
                    {
                        var evilItem = DBManager.Instance.GetDB<DBEvilValue>().GetData(actorId);
                        if (null != evilItem)
                            evilValue = evilItem.Value;
                    }
                    else
                    {
                        var evilItem = DBManager.Instance.GetDB<DBElementAreaEvilValue>().GetData(actorId);
                        if (null != evilItem)
                            evilValue = evilItem.Value;
                    }

                    string strEvilValue = DBConstText.GetText("SOUTH_LAND_EVIL_VALUE"); // 浊气值：
                    titlestr = string.Format("{0}\n{1}{2}{3}</color>", titlestr, strEvilValue, GameConst.COLOR_DARK_YELLOW, evilValue);
                }

                if (data_actor_tag.Count > 0)
                {
                    var table = data_actor_tag[0];
                    StringBuilder award_desc = new StringBuilder(150);
                    award_desc.AppendFormat(xc.TextHelper.GetTranslateText(table["tips1_format"]), table["tips1"]);
                    award_desc.Append('\n');
                    award_desc.AppendFormat(xc.TextHelper.GetTranslateText(table["tips2_format"]), table["tips2"]);
                    award_desc.Append('\n');
                    award_desc.AppendFormat(xc.TextHelper.GetTranslateText(table["tips3_format"]), table["tips3"]);

                    contentstr = award_desc.ToString();
                }
            }

            Text title = UIHelper.FindChild(m_MonsterInfo, "TitleText").GetComponent<Text>();
            Text content = UIHelper.FindChild(m_MonsterInfo, "Content").GetComponent<Text>();
            title.text = titlestr;
            content.text = contentstr;
            GameObject monster_point;
            if (mMonsterListPointObjs.TryGetValue(mCurrentMonsterInfo.Id, out monster_point))
            {
                m_MonsterInfo.transform.localPosition = GetTipsPos(monster_point);
                float y = mMapScroll.viewport.rect.height / 2 - monster_point.transform.localPosition.y;
                float x = mMapScroll.viewport.rect.width / 2 - monster_point.transform.localPosition.x;
                mMiniMapRawImage.rectTransform.anchoredPosition = new Vector2(x, y);
            }
        }

        /// <summary>
        /// 计算怪物tips的位置(优先下方)
        /// </summary>
        /// <param name="monster_point"></param>
        /// <returns></returns>
        public Vector3 GetTipsPos(GameObject monster_point)
        {
            Vector3 vec = Vector3.zero;
            var info_rect = m_MonsterInfo.GetComponent<RectTransform>().rect;
            var line_rect = MonsterLineObj.GetComponent<RectTransform>().rect;
            float info_width = info_rect.width; // 信息界面的宽度
            float info_height = info_rect.height;// 信息界面的高度
            float line_point_width = line_rect.width;
            float match_x = 0; // x的最优坐标点
            float match_y = 0; // y的最优坐标点
            bool overstep_x = false; // x方向超出了

            // 先计算x方向的最优坐标
            if (monster_point.transform.localPosition.x + info_width / 2 > mMiniMapRawImage.rectTransform.rect.width) // 右边超出
            {
                overstep_x = true;

                match_x = mMiniMapRawImage.rectTransform.rect.width - info_width / 2;

                MonsterLineObj.transform.localEulerAngles = new Vector3(0, 0, 180);
                float lineOffset = info_width / 2 + line_point_width / 2;
                MonsterLineObj.transform.localPosition = new Vector3(lineOffset, 0, 0);
            }
            else if (monster_point.transform.localPosition.x < info_width / 2) // 左边超出
            {
                overstep_x = true;

                match_x = info_width / 2;

                MonsterLineObj.transform.localEulerAngles = Vector3.zero;
                float lineOffset = info_width / 2 + line_point_width / 2;
                MonsterLineObj.transform.localPosition = new Vector3(-lineOffset, 0, 0);
            }
            else
            {
                match_x = monster_point.transform.localPosition.x;
            }

            // 计算y方向的最优坐标
            if (monster_point.transform.localPosition.y < (info_height + m_MonsterTipsOffsetY)) // 下方超出
            {
                match_y = monster_point.transform.localPosition.y + info_height / 2 + m_MonsterTipsOffsetY; // 将其放到上面

                if (!overstep_x)
                {
                    float lineOffset = info_height / 2 + line_point_width / 2;
                    MonsterLineObj.transform.localPosition = new Vector3(0, -lineOffset, 0);
                    MonsterLineObj.transform.localEulerAngles = new Vector3(0, 0, 90);
                }
            }
            else
            {
                match_y = monster_point.transform.localPosition.y - info_height / 2 - m_MonsterTipsOffsetY;

                if (!overstep_x)
                {
                    float lineOffset = info_height / 2 + line_point_width / 2;
                    MonsterLineObj.transform.localPosition = new Vector3(0, lineOffset, 0);
                    MonsterLineObj.transform.localEulerAngles = new Vector3(0, 0, -90);
                }
            }

            vec.x = match_x;
            vec.y = match_y;
            return vec;
        }

        /// <summary>
        /// 点击前往挂机点的按钮
        /// </summary>
        public void OnClickGotoMonster()
        {
            // 本地玩家是否处于护送状态
            if (SceneHelp.CheckLocalPlayerEscortTaskState() == false)
            {
                return;
            }

            if (mCurrentMonsterInfo == null)
                return;

            // 记录当弹出退出提示的时候是否要继续自动战斗
            if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
            {
                SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
            }

            // 首先取消自动挂机
            InstanceManager.Instance.IsAutoFighting = false;

            // 世界boss默认刷新到1分线
            if (ActorHelper.IsWorldBoss(mCurrentMonsterInfo.ActorId) 
                && !SceneHelp.Instance.IsInFirstWorldBossInstance) 
            {
                if (SceneHelp.CheckCanSwitch(mCurrentMonsterInfo.MapId, true) == true)
                {
                    TargetPathManager.Instance.GoToConstPosition(mCurrentMonsterInfo.MapId, 1, mCurrentMonsterInfo.Position, null, () => { InstanceManager.Instance.SetOnHook(true); });
                }
            }
            else
            {
                // 从服务器那里获取挂机位置
                uint hangId = DBHang.Instance.GetHangIdByInstanceIdAndTagId(mCurrentMonsterInfo.MapId, (uint)mCurrentMonsterInfo.Id);
                uint tagIndex = DBHang.Instance.GetTagIndexByInstanceIdAndTagId(mCurrentMonsterInfo.MapId, (uint)mCurrentMonsterInfo.Id);
                if (hangId > 0)
                {
                    var data = new C2SMapGetHangPos();
                    data.data_id = hangId;
                    data.nth_pos = tagIndex;
                    NetClient.GetBaseClient().SendData<C2SMapGetHangPos>(NetMsg.MSG_MAP_GET_HANG_POS, data);
                }
                // 如果配置表没有数据则客户端直接跳转
                else
                {
                    if (SceneHelp.CheckCanSwitch(mCurrentMonsterInfo.MapId, true) == true)
                    {
                        TargetPathManager.Instance.GoToConstPosition(mCurrentMonsterInfo.MapId, SceneHelp.Instance.CurLine, mCurrentMonsterInfo.Position, null, () => { InstanceManager.Instance.SetOnHook(true); });
                    }
                }
            }

            UIManager.Instance.CloseSysWindow("UIMapWindow");
        }

        public void CreateTranspotPoint()
        {
            var list = MiniMapHelp.GetInstanceAllTrasnspot(m_CurSceneId);
            for (int i = 0; i < list.Count; i++)
            {
                var info = list[i];
                var rect = GetItem(m_TranspotPoint);
                Vector3 vect = new Vector3((info.Position.x- minX) / uiScalex, (info.Position.z - minY) / uiScaley, 0);
                rect.localPosition = vect;
                Button btn = rect.GetComponent<Button>();
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => { OnClickTranspotPoint(info); });
                mTranspotListPointObjs.Add(rect.gameObject);
            }
        }

        /// <summary>
        /// 点击传送点
        /// </summary>
        /// <param name="info"></param>
        public void OnClickTranspotPoint(MiniMapPointInfo info)
        {
            TargetPathManager.Instance.GoToConstPosition(m_CurSceneId, SceneHelp.Instance.CurLine, info.Position, null, () =>
            {
                isStartPath = false;
            });
        }

        public void UpdateTeam(ushort protocol, byte[] data)
        {
            if (IsEnable == false)
                return;
            if (protocol == NetMsg.MSG_TEAM_MEMBER_POS)
            {
                m_bNetAnswer = true;

                var msg = S2CPackBase.DeserializePack<S2CTeamMemberPos>(data);
                if (mTeamListPointObjs.Count != msg.list.Count)
                {
                    for (int i = 0; i < mTeamListPointObjs.Count; i++)
                    {
                        UIResourceManager.Instance.ReturnObjectToPool(mTeamListPointObjs[i]);
                    }
                    mTeamListPointObjs.Clear();
                    for (int i = 0; i < msg.list.Count; i++)
                    {
                        uint uuid = msg.list[i].uuid;
                        PkgTeamMember member = TeamManager.Instance.GetMember(uuid);
                        if (member.dungeon_id.Equals(m_CurSceneId))
                        {
                            var rect = GetItem(m_TeamPoint);
                            mTeamListPointObjs.Add(rect.gameObject);
                        }
                    }
                }
                for (int i = 0; i < mTeamListPointObjs.Count; i++)
                {
                    if (msg.list.Count > i)
                    {
                        var pos = msg.list[i];
                        mTeamListPointObjs[i].transform.localPosition = new Vector3((pos.pos.px * GlobalConst.UnitScale- minX) / uiScalex, (pos.pos.py * GlobalConst.UnitScale - minY) / uiScalex);
                    }
                }
            }
        }


        public void CreateNpcPoint()
        {
            var List = MiniMapHelp.GetInstanceAllNpc(m_CurSceneId);
            for (int i = 0; i < List.Count; i++)
            {
                var info = List[i];
                uint state = NpcHelper.GetNpcTaskState((uint)info.Id, m_CurSceneId);//npcId
                if (IsDisplayNpcByTaskState(state))
                {
                    var rect = GetItem(m_NpcPoint);
                    UpdateOneNpc(state, rect.gameObject);
                    Vector3 vect = new Vector3((info.Position.x- minX) / uiScalex, (info.Position.z- minY) / uiScaley, 0);
                    rect.localPosition = vect;
                    Text nameText = UIHelper.FindChild(rect.gameObject, "NameText").GetComponent<Text>();
                    nameText.text = info.BlackName;
                    Button btn = rect.GetComponent<Button>();
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(()=> { OnClickNpcPoint(info); });
                    mNpcListPointObjs.Add((uint)info.Id, rect.gameObject);
                }
            }
        }

        public void OnClickNpcPoint(MiniMapPointInfo info)
        {
            TargetPathManager.Instance.GoToNpcPos(info.MapId, (uint)info.Id , null);
            UIManager.Instance.CloseSysWindow("UIMapWindow");
        }

        /// <summary>
        /// 家泳那边没有单个更新
        /// </summary>
        public void UpdateNpcState(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;
            foreach (var kv in mNpcListPointObjs)
            {
                uint state = NpcHelper.GetNpcTaskState(kv.Key);//npcId
                UpdateOneNpc(state, kv.Value);
            }
        }

        public void UpdateOneNpc(uint state , GameObject go)
        {
            var state1 = UIHelper.FindChild(go, "NpcState1");
            var state2 = UIHelper.FindChild(go, "NpcState2");
            var state3 = UIHelper.FindChild(go, "NpcState3");

            state1.SetActive(false);
            state2.SetActive(false);
            state3.SetActive(false);
            switch (state)
            {
                case GameConst.QUEST_STATE_DOING:
                    {
                        state1.SetActive(true);
                        break;
                    }
                case GameConst.QUEST_STATE_DONE:
                    {
                        state2.SetActive(true);
                        break;
                    }
                case GameConst.QUEST_STATE_ACCEPT:
                    {
                        state3.SetActive(true);
                        break;
                    }
            }
        }

        public bool IsDisplayNpcByTaskState( uint state )
        {
            bool ret = false;
            switch (state)
            {
                case GameConst.QUEST_STATE_DOING:   //任务状态-进行中
                    {
                        ret = true;
                        break;
                    }
                case GameConst.QUEST_STATE_DONE:    //任务状态-完成且未提交
                    {
                        ret = true;
                        break;
                    }
                case GameConst.QUEST_STATE_ACCEPT:  //任务状态-可接
                    {
                        ret = true;
                        break;
                    }
            }

            return ret;
        }

        public RectTransform GetItem(GameObject template)
        {
            GameObject go = UIResourceManager.Instance.GetObjectFromPool(template);
            if (go == null)
                return null;
            RectTransform nextItem = go.GetComponent<RectTransform>();
            nextItem.transform.SetParent(template.transform.parent, false);
            nextItem.gameObject.SetActive(true);
            return nextItem;
        }

        public override void UpdateBehaviour()
        {
            base.UpdateBehaviour();
            var localPlayer = Game.Instance.GetLocalPlayer();
            bool isInCurScene = SceneHelp.Instance.CurSceneID.Equals(m_CurSceneId);
            if (localPlayer != null&& localPlayer.transform != null&& m_LocalPlayerPoint != null && isInCurScene)
            {
                LocalPlayerEulerAngles.z = 360- localPlayer.transform.localEulerAngles.y;
                m_LocalPlayerPoint.transform.localEulerAngles = LocalPlayerEulerAngles;
                m_PlayerPos.x = (localPlayer.transform.localPosition.x- minX )/ uiScalex;
                m_PlayerPos.y = (localPlayer.transform.localPosition.z- minY) / uiScaley;
                m_PlayerLocalPos = m_PlayerPos;
                m_LocalPlayerPoint.transform.localPosition = m_PlayerLocalPos;

                if (TargetPathManager.Instance.IsNavigating == false && mEndPathGo.activeSelf == true)
                {
                    ClearPathPoint();
                    if (mEndPathGo != null)
                        mEndPathGo.SetActive(false);
                }
                else if(TargetPathManager.Instance.IsNavigating)
                {
                    if (m_PathPoints.Count > 0 && m_PathPointTrans.Count > 0)
                    {
                        // 检查前5个点，因为UpdateBehaviour在打开界面后才更新，此时可能角色已经走了一段路
                        for (int i =0; i < m_PathPoints.Count && i < 5; ++i)
                        {
                            Vector2 current_point = m_PathPoints[i];
                            if (Vector2.Distance(current_point, m_PlayerPos) <= m_MapPointRemoveDistance)
                            {
                                for(int j = i; j >=0; --j)
                                {
                                    m_PathPoints.RemoveAt(0);
                                    RectTransform rect = m_PathPointTrans[0];
                                    UIResourceManager.Instance.ReturnObjectToPool(rect.gameObject);
                                    m_PathPointTrans.RemoveAt(0);
                                }
                                break;
                            }
                        }
                        
                    }
                }

            }
        }

        public void DestroyPathPoint()
        {
            m_PathPoints.Clear();
            UIResourceManager.Instance.DestroyPool(mPathPointRectTemplate.gameObject);
        }


        public override void DestroyBehaviour()
        {
            m_bNetAnswer = false;
            m_PathPos.Release();
            m_GotoBtn.onClick.RemoveAllListeners();

            if (m_AssetRes != null)
            {
                m_AssetRes.destroy();
                m_AssetRes = null;
            }

            DestroyPathPoint();
            DestroyPoint();
            MonsterTipsTrigger.onPointerDown -= LostMonsterTips;
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TEAM_MEMBER_POS, UpdateTeam);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.TASK_CHANGED, UpdateNpcState);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, UpdateRequsetTeam);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.NEW_MINIMAP_SELECT_MONSTER_MINIMAPINFO, MonsterSelectChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_MINI_MAP_COM_POS, ClickMiniMapPos);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ACTOR_PATH_POINTS_CHANGED, OnWalkPathChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)xc.ClientEvent.CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL, UpdateWorldBossState);
            m_PathPoints.Clear();
            base.DestroyBehaviour();
        }

        /// <summary>
        /// 监听队伍发送改变就请求队伍位置
        /// </summary>
        /// <param name="args"></param>
        public void UpdateRequsetTeam(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;
            if (mUpdateTeamPosCd != null)
                return;
            if (TeamManager.Instance.HaveTeam)
            {
                mUpdateTeamPosCd = new Utils.Timer(2000, true, 3000,
                    (dt) =>
                    {
                        if (!m_bNetAnswer)
                            ClearTeamPoint();

                        m_bNetAnswer = false;
                        var data = new C2STeamMemberPos();
                        NetClient.GetBaseClient().SendData<C2STeamMemberPos>(NetMsg.MSG_TEAM_MEMBER_POS, data);
                    });

            }
        }

        public void ClearTeamPoint()
        {
            if (mTeamListPointObjs.Count > 0)
            {
                for (int i = 0; i < mTeamListPointObjs.Count; i++)
                {
                    UIResourceManager.Instance.ReturnObjectToPool(mTeamListPointObjs[i]);
                }
                mTeamListPointObjs.Clear();
            }
        }

        public void ClearPoint()
        {
            mCurrentMonsterInfo = null;
            if (mUpdateTeamPosCd != null)
            {
                mUpdateTeamPosCd.Destroy();
                mUpdateTeamPosCd = null;
            }

            ClearTeamPoint();

            if (mMonsterListPointObjs.Count > 0)
            {
                foreach (var kv in mMonsterListPointObjs)
                {
                    UIResourceManager.Instance.ReturnObjectToPool(kv.Value);
                }
                mMonsterListPointObjs.Clear();
            }
            if (mTranspotListPointObjs.Count > 0)
            {
                for (int i = 0; i < mTranspotListPointObjs.Count; i++)
                {
                    UIResourceManager.Instance.ReturnObjectToPool(mTranspotListPointObjs[i]);
                }
                mTranspotListPointObjs.Clear();
            }

            if (mNpcListPointObjs.Count > 0)
            {
                foreach (var kv in mNpcListPointObjs)
                {
                    UIResourceManager.Instance.ReturnObjectToPool(kv.Value);
                }
                mNpcListPointObjs.Clear();
            }
        }

        public void DestroyPoint()
        {
            mCurrentMonsterInfo = null;
            if (mUpdateTeamPosCd != null)
            {
                mUpdateTeamPosCd.Destroy();
                mUpdateTeamPosCd = null;
            }
            
            UIResourceManager.Instance.DestroyPool(m_TranspotPoint);
            UIResourceManager.Instance.DestroyPool(m_TeamPoint);
            UIResourceManager.Instance.DestroyPool(m_MonsterPoint);
            UIResourceManager.Instance.DestroyPool(m_NpcPoint);
        }

        public void LocalCenter()
        {
            var localPlayer = Game.Instance.GetLocalPlayer();
            bool isInCurScene = SceneHelp.Instance.CurSceneID.Equals(m_CurSceneId);
            if (localPlayer != null && localPlayer.transform != null && m_LocalPlayerPoint != null && isInCurScene)
            {
                m_PlayerPos.x = (localPlayer.transform.localPosition.x- minX) / uiScalex;
                m_PlayerPos.y = (localPlayer.transform.localPosition.z - minY) / uiScaley;
                m_PlayerLocalPos = m_PlayerPos;
                m_LocalPlayerPoint.transform.localPosition = m_PlayerLocalPos;
                float y = mMapScroll.viewport.rect.height / 2 - m_LocalPlayerPoint.transform.localPosition.y;
                float x = mMapScroll.viewport.rect.width / 2 - m_LocalPlayerPoint.transform.localPosition.x;
                mMiniMapRawImage.rectTransform.anchoredPosition = new Vector2(x, y);
            }
        }

        public void LoadMiniMapTexture(string minimapName)
        {
            if (mMiniMapRawImage.texture == null || mMiniMapRawImage.texture.name.CompareTo(minimapName.ToString()) != 0)
                ui.ugui.UIManager.Instance.MainCtrl.StartCoroutine(ShowAsync(minimapName));
            else if (mMiniMapRawImage.texture.name.CompareTo(minimapName.ToString()) == 0)
            {
                mMiniMapRawImage.enabled = true;
            }
        }

        public IEnumerator ShowAsync(string minimapName)
        {
            if(m_AssetRes != null)
            {
                m_AssetRes.destroy();
                m_AssetRes = null;
            }

            m_AssetRes = new SGameEngine.AssetResource();
            if (mMiniMapRawImage == null)
            {
                yield break;
            }

            if (mMiniMapRawImage.texture != null)
            {
                if (mMiniMapRawImage.texture.name.CompareTo(minimapName.ToString()) == 0)
                {
                    yield break;
                }
            }

            yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_asset("Assets/Res/UI/Textures/MiniMap/"+ minimapName+".png", typeof(Texture), m_AssetRes));
            if (m_AssetRes == null || m_AssetRes.asset_ == null)
            {
                if (null != mMiniMapRawImage)
                    mMiniMapRawImage.enabled = false;

                yield break;
            }

            if (null != mMiniMapRawImage)
            {
                mMiniMapRawImage.texture = m_AssetRes.asset_ as Texture;
                mMiniMapRawImage.enabled = true;
                //mMiniMapRawImage.rectTransform.sizeDelta = new Vector2(1920, 1920);
            }
        }

        public override void EnableBehaviour(bool isEnable)
        {
            base.EnableBehaviour(isEnable);

            m_bNetAnswer = false;
            m_CurSceneId = SceneHelp.Instance.CurSceneID;

            if (isEnable)// 显示
            {
                uint pos_tag = 0; // 指定的挂机点位置Tag
                if (Window != null && Window.ShowParam != null)
                {
                    if (Window.ShowParam.Length >= 1)
                    {
                        if ((bool)Window.ShowParam[0] == true) // 标识需要通过离线挂机表来寻找合适的场景和挂机点
                        {
                            var hang_info = DBHang.Instance.GetSuitableHangInfo();
                            if (hang_info != null)
                            {
                                m_CurSceneId = hang_info.Dungeon;
                                pos_tag = hang_info.GetRandomTag().Id;
                            }
                        }
                    }
                }

                DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(m_CurSceneId);
                if (instanceInfo != null)
                {
                    minX = instanceInfo.mMinPos.x;
                    minY = instanceInfo.mMinPos.y;
                    uiScalex = instanceInfo.mMiniMapWidth / mMiniMapRawImage.rectTransform.rect.width;
                    uiScaley = instanceInfo.mMiniMapHeight / mMiniMapRawImage.rectTransform.rect.height;
                    LoadMiniMapTexture(instanceInfo.mMiniMapName);
                }


                LocalCenter();
                ClearPoint();
                CreateMonsterPoint();
                CreateTranspotPoint();
                CreateNpcPoint();

                if (TargetPathManager.Instance.IsNavigating)
                    CreatePathPoint();

                UpdateRequsetTeam(null);
                UpdateWorldBossState(null);

                bool isInCurScene = SceneHelp.Instance.CurSceneID.Equals(m_CurSceneId);
                m_LocalPlayerPoint.SetActive(isInCurScene);
                m_LocalPlayerPoint.transform.SetAsLastSibling();
                MonsterTipsTrigger.transform.SetAsLastSibling();

                // 寻找指定的挂机点
                var monster_infos = MiniMapHelp.GetInstanceAllNormalMonster(m_CurSceneId);
                for (int i = 0; i < monster_infos.Count; i++)
                {
                    var info = monster_infos[i];
                    if (info == null)
                        continue;

                    if(info.Id == pos_tag)
                    {
                        OnClickMonsterPoint(info);
                        break;
                    }
                }
            }
            else// 隐藏
            {
                ClearPathPoint();
                ClearPoint();
                MonsterTipsTrigger.gameObject.SetActive(false);
            }
        }
    }
}
