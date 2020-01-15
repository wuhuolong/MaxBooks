using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using xc;
using xc.ui;
using Utils;
using Net;
using xc.protocol;
namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIWorldMapWindowBehaviour : IUIBehaviour
    {
        Dictionary<int, GameObject> mMapGoDic = new Dictionary<int, GameObject>();

        /// <summary>
        /// 玩家当前所在的地图id
        /// </summary>
        int m_MapId = -1;
        uint m_playerTransferLv = 0;

        uint LocalPlayerLevel = 0;
        uint MaintaskId = 0;
        RectTransform mLocalPlayerPoint;
        GameObject mNotEnterTips;
        EventTriggerListener mNotEnterTipsTrigger;
        GameObject mTeamPointTemplate;
        Utils.Timer mUpdateTeamPosCd;
        List<GameObject> mTeamListPointObjs = new List<GameObject>();
        GameObject mOpenRoot;
        RawImage MapTexture;
        ScrollRect mMapScroll;
        GameObject mEffectUnLock; // 解锁特效

        uint m_lastUnlockMapId = 0; // 解锁地图中最后一个地图id

        private SafeCoroutine.Coroutine mPlayOpenSysRoutine = null;

        Color m_grayColor = new Color(63.0f / 255.0f, 106.0f / 255.0f, 148.0f / 255.0f, 1.0f);
        Color m_normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        public override void InitBehaviour()
        {
            mMapScroll = Window.FindChild("ScrollView").GetComponent<ScrollRect>();
            mNotEnterTips = Window.FindChild("NotEnterTips");
            mTeamPointTemplate = Window.FindChild("TeamPoint");
            mOpenRoot = Window.FindChild("OpenRoot");
            MapTexture = Window.FindChild("MapTexture").GetComponent<RawImage>();
            mOpenRoot.SetActive(false);
            mTeamPointTemplate.SetActive(false);
            mNotEnterTipsTrigger = EventTriggerListener.GetListener(Window.FindChild("NotEnterRoot"));
            mNotEnterTipsTrigger.onPointerDown += LostNotEnterTips;
            mLocalPlayerPoint = Window.FindChild("LocalPlayer").GetComponent<RectTransform>();

            // 解锁特效
            mEffectUnLock = Window.FindChild("EF_ui_WorldMap_lock");
            mEffectUnLock.SetActive(false);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, TeamChange);
            
            UIResourceManager.Instance.InitPool(mTeamPointTemplate, 2);
            InitAllMapPoint();
            mLocalPlayerPoint.transform.SetAsLastSibling();
            base.InitBehaviour();
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

        /// <summary>
        /// 监听队伍发送改变就请求队伍位置
        /// </summary>
        /// <param name="args"></param>
        public void TeamChange(CEventBaseArgs args)
        {
            if (IsEnable == false)
                return;
            for (int i = 0; i < mTeamListPointObjs.Count; i++)
            {
                UIResourceManager.Instance.ReturnObjectToPool(mTeamListPointObjs[i]);
            }
            if (TeamManager.Instance.TeamMembers != null)
            {
                foreach (var item in TeamManager.Instance.TeamMembers)
                {
                    if (item.dungeon_id != m_MapId 
                        && item.brief.uuid != LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx
                        && xc.SpanServerManager.Instance.IsInSameServer(item.brief.uuid))
                    {
                        GameObject go;
                        if (mMapGoDic.TryGetValue((int)item.dungeon_id, out go))
                        {
                            var rect = GetItem(mTeamPointTemplate);
                            var refObjPos = GetMapPointRefObjPos(go);

                            rect.localPosition = new Vector3(refObjPos.x + 60, refObjPos.y + 15, 0);
                            mTeamListPointObjs.Add(rect.gameObject);
                        }
                    }
                }
            }
        }

        public override void UpdateBehaviour()
        {
            base.UpdateBehaviour();
            UpdatePlayerPos();
            SetMapIconState();
        }

        /// <summary>
        /// 设置当前玩家所在地图的标记
        /// </summary>
        public void UpdatePlayerPos()
        {
            int cur_scene_id = (int)SceneHelp.Instance.CurSceneID;
            uint transferLv = (uint)xc.TransferHelper.GetTransferLevel();
            if (m_MapId != cur_scene_id || m_playerTransferLv != transferLv)
            {
                m_MapId = cur_scene_id;
                m_playerTransferLv = transferLv;

                GameObject map_point;
                if (mMapGoDic.TryGetValue(cur_scene_id, out map_point))
                {
                    var refObjPos = GetMapPointRefObjPos(map_point);
                    mLocalPlayerPoint.gameObject.SetActive(true);
                    mLocalPlayerPoint.transform.localPosition = new Vector3(refObjPos.x + 60, refObjPos.y - 45, 0);

                    var head_icon = RoleHelp.GetPlayerIconName(Game.Instance.LocalPlayerVocation, transferLv, false);
                    mLocalPlayerPoint.Find("HeadIcon").GetComponent<Image>().sprite = Window.LoadSprite(head_icon);

                    float y = mMapScroll.viewport.rect.height / 2 - map_point.transform.localPosition.y;
                    float x = mMapScroll.viewport.rect.width / 2 - map_point.transform.localPosition.x;
                    MapTexture.rectTransform.anchoredPosition = new Vector2(x, y);
                }
                else
                {
                    mLocalPlayerPoint.gameObject.SetActive(false);
                }
            }
        }

        public void LostNotEnterTips(GameObject go)
        {
            mNotEnterTipsTrigger.gameObject.SetActive(false);
            mNotEnterTips.SetActive(false);
        }

        public void UpdateState(Task mainTask)
        {
            LocalPlayerLevel = LocalPlayerManager.Instance.Level;

            if (mainTask != null && mainTask.Define != null)
                MaintaskId = mainTask.Define.Id;

            foreach (var kv in mMapGoDic)
            {
                DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo((uint)kv.Key);

                if (instanceInfo != null)
                {
                    // 设置区域名字
                    Text name_text = UIHelper.FindChild(kv.Value, "NameText").GetComponent<Text>();
                    string inst_name = instanceInfo.mName;
                    StringBuilder align_name = new StringBuilder(inst_name.Length*2);
                    foreach(var c in inst_name)
                    {
                        align_name.Append(c);
                        align_name.Append('\n');
                    }

                    name_text.text = align_name.ToString();

                    bool isOpen = MiniMapHelp.isMapOpen((uint)kv.Key);

                    // 背景图片
                    var bgImage = kv.Value.GetComponent<Image>();

                    // 设置开启等级信息
                    uint need_level = InstanceHelper.GetInstanceNeedRoleLevel((uint)kv.Key);
                    Text level_text = UIHelper.FindChild(kv.Value, "LevelText").GetComponent<Text>();

                    string peakLvDesc = GetPeakLvDesc(need_level);
                    if (!isOpen)
                    {
                        peakLvDesc = "<color=#ff0000>" + peakLvDesc + "</color>";

                        SetMapPointImgState(bgImage, true);
                    }
                    else
                    {
                        SetMapPointImgState(bgImage, false);
                    }

                    level_text.text = peakLvDesc;

                    // 设置当前是否可开启的标记
                    GameObject lock_object = UIHelper.FindChild(kv.Value, "Lock");
                    lock_object.SetActive(!isOpen);                    

                    // 根据pk区域设置不同的图标
                    var stateNode = UIHelper.FindChild(kv.Value, "State");
                    GameObject free_pk_area = UIHelper.FindChild(kv.Value, "FreePkArea");
                    GameObject no_safe_area = UIHelper.FindChild(kv.Value, "NoSafeArea");

                    stateNode.SetActive(isOpen);

                    int pk_type = instanceInfo.mPKType;
                    switch (pk_type)
                    {
                        case GameConst.SCENE_PK_COMMON:
                            {
                                no_safe_area.SetActive(true);
                                free_pk_area.SetActive(false);
                                //pkStr = "<color=#ffeb07>非安全区域</color>";
                                break;
                            }
                        case GameConst.SCENE_PK_DANGER:
                            {
                                free_pk_area.SetActive(true);
                                no_safe_area.SetActive(false);
                                //pkStr = "<color=#ff0000>PK区域</color>";
                                break;
                            }
                        default:
                            {
                                free_pk_area.SetActive(false);
                                no_safe_area.SetActive(false);
                                //pkStr = "安全区域";
                                break;
                            }
                    }
                }
            }
        }

        public void SetMapIconState(bool forceUpdate = false)
        {
            Task mainTask = null;
            List<Task> mainTasks = TaskManager.Instance.GetTasksByType(GameConst.QUEST_MAIN);
            if (mainTasks.Count > 0)
            {
                mainTask = mainTasks[0];
            }

            if (forceUpdate)
            {
                UpdateState(mainTask);
            }
            else
            {
                if (LocalPlayerLevel != LocalPlayerManager.Instance.Level || (mainTask != null && MaintaskId != mainTask.Define.Id))
                {
                    UpdateState(mainTask);
                }
            }
        }

        public override void DestroyBehaviour()
        {
            if (mUpdateTeamPosCd != null)
            {
                mUpdateTeamPosCd.Destroy();
                mUpdateTeamPosCd = null;
            }
            if (mPlayOpenSysRoutine != null)
            {
                mPlayOpenSysRoutine.Stop();
                mPlayOpenSysRoutine = null;
            }
            mNotEnterTipsTrigger.onPointerDown -= LostNotEnterTips;
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, TeamChange);
            base.DestroyBehaviour();
        }

        public void InitAllMapPoint()
        {
            List<Dictionary<string, string>> data_world = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_world");
            for (int i = 0; i < data_world.Count; i++)
            {
                Dictionary<string, string> data = data_world[i];
                int mapId = DBTextResource.ParseI(data["map_id"]);
                string mapPointName = data["map_point_name"];
                var go = Window.FindChild(mapPointName);
                if (go != null)
                {
                    var instanceInfo = DBInstance.Instance.GetInstanceInfo((uint)mapId);
                    Button btn = go.transform.Find("BgImage").GetComponent<Button>();
                    if (instanceInfo != null)
                    {
                        btn.onClick.RemoveAllListeners();
                        btn.onClick.AddListener(() => { OnClickMap((uint)mapId); });

                        mMapGoDic.Add(mapId, go);
                    }
                    else
                    {
                        var bgImage = go.GetComponent<Image>();
                        SetMapPointImgState(bgImage, true);

                        btn.gameObject.SetActive(false);

                        var lockObj = go.transform.Find("Lock");
                        lockObj.gameObject.SetActive(false);
                    }
                }
            }

            SetMapIconState(true);
        }

        public void OnClickMap(uint mapId)
        {
            uint needLevel = InstanceHelper.GetInstanceNeedRoleLevel((uint)mapId);
            var instance = DBInstance.Instance.GetInstanceInfo(mapId);

            string peakLvDesc = GetPeakLvDesc(needLevel);
            var preStrFmt = DBConstText.GetText("GAME_MAP_OPEN_TIPS"); // 达到{0}
            string descontent = string.Format(preStrFmt, peakLvDesc);

            uint isCanEnterCount = 0;
            if (needLevel > LocalPlayerManager.Instance.Level)
            {
                isCanEnterCount++;
                descontent = string.Format("<color=#ff0000>{0}</color>", descontent);
            }

            var needTaskId = instance.mNeedTaskId;

            if (instance != null && needTaskId != 0)
            {
                int requestLevelMin = TaskDefine.GetTaskRequestLevelMin(needTaskId);

                string taskFmt = DBConstText.GetText("GAME_MAP_FINISH_TASK_TIPS"); //完成{0}任务开启
                string requestPeakLvDesc = GetPeakLvDesc((uint)requestLevelMin);
                string taskDesc = string.Format(taskFmt, requestPeakLvDesc);

                if (TaskHelper.MainTaskIsPassed(needTaskId) == false)
                {
                    taskDesc = string.Format("<color=#ff0000>{0}</color>", taskDesc);

                    isCanEnterCount++;
                }

                descontent += string.Format("\n{0}", taskDesc);
            }

            if (isCanEnterCount == 0)
            {
                if (mapId == SceneHelp.Instance.CurSceneID)
                {
                    if (instance != null)
                    {
                        UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("ENTER_SAME_SCENE_TIPS"), instance.mName));
                    }
                    else
                    {
                        UINotice.Instance.ShowMessage(DBConstText.GetText("INSTANCE_CAN_NOT_SWITCH_WILD_INSTANCE"));
                    }
                }
                else
                {
                    SceneHelp.JumpToScene(mapId);
                    UIManager.Instance.CloseSysWindow("UIWorldMapWindow");
                }
            }
            else
            {
                var refObjPos = GetMapPointRefObjPos(mMapGoDic[(int)mapId]);
                mNotEnterTips.transform.localPosition = new Vector3(refObjPos.x, refObjPos.y - 190, 0);
                mNotEnterTips.SetActive(true);

                mNotEnterTipsTrigger.gameObject.SetActive(true);
                mNotEnterTipsTrigger.transform.SetAsLastSibling();
                Text content = UIHelper.FindChild(mNotEnterTips, "Content").GetComponent<Text>();

                content.text = descontent;
            }
        }

        public string GetPeakLvDesc(uint lv)
        {
            string ret = string.Empty;

            var fmt = "{0}";
            uint peakLv = 0;
            bool isPeak = TransferHelper.IsPeak(lv, out peakLv);
            if (isPeak)
                fmt = DBConstText.GetText("UI_PLAYER_PEAK_LEVEL_FORMAT"); // 巅峰{0}级

            else
                fmt = DBConstText.GetText("UI_PLAYER_LEVEL_FORMAT"); // {0}级

            return string.Format(fmt, peakLv);
        }

        public void OnGotoNewMap()
        {
            OnClickMap(m_lastUnlockMapId);

            m_lastUnlockMapId = 0;
        }

        /// <summary>
        /// 获取参考坐标（相对于MapTexture计算的本地坐标）
        /// </summary>
        /// <param name="mapPoint"></param>
        /// <returns></returns>

        public Vector3 GetMapPointRefObjPos(GameObject mapPoint)
        {
            if (mapPoint == null)
                return Vector3.zero;

            var refObj = mapPoint.transform.Find("BgImage");
            if (refObj == null)
                return Vector3.zero;

            var refPos = refObj.transform.position;

            return MapTexture.transform.InverseTransformPoint(refPos);
        }

        public void SetMapPointImgState(Image img, bool isGray)
        {
            if (null == img)
                return;

            if (isGray)
                img.color = m_grayColor;

            else
                img.color = m_normalColor;

        }

        public override void EnableBehaviour(bool isEnable)
        {
            m_lastUnlockMapId = 0;

            mOpenRoot.SetActive(false);
            mEffectUnLock.SetActive(false);

            base.EnableBehaviour(isEnable);
            if (isEnable)
            {
                if (mUpdateTeamPosCd != null)
                {
                    mUpdateTeamPosCd.Destroy();
                    mUpdateTeamPosCd = null;
                }

                mNotEnterTipsTrigger.gameObject.SetActive(false);
                mNotEnterTips.SetActive(false);

                UpdatePlayerPos();
                TeamChange(null);
                //SetMapIconState(true);
                if (mPlayOpenSysRoutine != null)
                {
                    mPlayOpenSysRoutine.Stop();
                    mPlayOpenSysRoutine = null;
                }

                //CheckOpenInstance();
            }
            else
            {
                if (mPlayOpenSysRoutine != null)
                {
                    mPlayOpenSysRoutine.Stop();
                    mPlayOpenSysRoutine = null;
                }
                
            }
        }

        public void GoToScene(int sceneId)
        {
            if (!mMapGoDic.ContainsKey(sceneId))
            {
                return;
            }

            GameObject go = mMapGoDic[sceneId];
            float y = mMapScroll.viewport.rect.height / 2 - go.transform.localPosition.y;
            float x = mMapScroll.viewport.rect.width / 2 - go.transform.localPosition.x;
            MapTexture.rectTransform.anchoredPosition = new Vector2(x, y);
        }
    }
}
