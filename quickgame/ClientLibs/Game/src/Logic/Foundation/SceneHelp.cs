//------------------------------------------------------------------------------
// Desc   :  场景切换的辅助类
// Author :  Raorui
// Date   :  2015.8.11
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using UnityEngine.SceneManagement;
using xc.protocol;
using xc.ui;
using Net;

namespace xc
{
    [wxb.Hotfix]
    public class SceneHelp:Singleton<SceneHelp>
    {
        public static string loadedLevelName
        {
            get
            {
                return SceneManager.GetActiveScene().name;
            }
        }

        /// <summary>
        /// 加载完毕后是否自动隐藏loading界面
        /// </summary>
        public bool AutoHideLoadingUI
        {
            get
            {
                return mAutoHideLoadingUI;
            }
        }

        /// <summary>
        /// 当前场景的Level名字
        /// </summary>
        public string CurSceneName
        {
            get
            {
                return mCurSceneName;
            }
        }

        /// <summary>
        /// 当前场景的资源路径
        /// </summary>
        public string CurSceneResPath
        {
            get
            {
                return mCurSceneResPath;
            }
        }

        /// <summary>
        /// 是否正在切换场景
        /// </summary>
        private bool m_SwitchingScene;

        /// <summary>
        /// 加载完毕后是否自动隐藏loading界面
        /// </summary>
        private bool mAutoHideLoadingUI;

        /// <summary>
        /// 当前场景的Level名字
        /// </summary>
        private string mCurSceneName;

        /// <summary>
        /// 当前场景的资源路径
        /// </summary>
        private string mCurSceneResPath;

        /// <summary>
        /// 当前场景的信息(对应地图表中的信息)
        /// </summary>
        private DBMap.MapInfo mCurMapInfo;

        public DBMap.MapInfo MapInfo
        {
            get
            {
                return mCurMapInfo;
            }
        }

        /// <summary>
        /// 是否要加载场景
        /// </summary>
        public bool WillSwitchScene { get; set; }

        public Dictionary<uint , uint> mLineInfos = new Dictionary<uint , uint>();//换线信息
        public uint mChangeLineCDTime = 0;//上一个换线cd
        public float mDelyLineCdTime = 0;
        private Utils.Timer mLineCDTimer;


        /// <summary>
        /// 当前场景的分线
        /// </summary>
        public uint CurLine = 0;

        uint mCurSceneID;

        /// <summary>
        /// 跳场景后是否激活自动战斗
        /// </summary>
        public bool IsAutoFightingAfterSwitchInstance { get; set; }

        /// <summary>
        /// 副本弹出退出提示的时候是否要继续自动战斗
        /// 【【C提测】离开副本的提示不要打断挂机】
        /// https://www.tapd.cn/20249401/prong/stories/view/1120249401001009408
        /// </summary>
        bool mIsAutoFightingWhenShowExitTips;
        public bool IsAutoFightingWhenShowExitTips
        {
            get
            {
                return mIsAutoFightingWhenShowExitTips;
            }
            set
            {
                mIsAutoFightingWhenShowExitTips = value;
            }
        }

        /// <summary>
        /// 当前副本或者主城在表格中的id
        /// </summary>
        public uint CurSceneID
        {
            get
            {
                return mCurSceneID;
            }

            set
            {
                mCurSceneID = value;
            }
        }

        uint mPreSceneID;
        /// <summary>
        /// 上一个副本或者主城在表格中的id
        /// </summary>
        public uint PreSceneID
        {
            get
            {
                return mPreSceneID;
            }

            set
            {
                mPreSceneID = value;
            }
        }

        /// <summary>
        /// 当前副本是否可以隐藏其他玩家
        /// </summary>
        public bool CanHidePlayer
        {
            get
            {
                return DBInstanceTypeControl.Instance.CannotHidePlayer(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType) == false;
            }
        }

        /// <summary>
        /// 当前副本是否优先筛选玩家作为目标
        /// </summary>
        public bool PrecedentPlayer
        {
            get
            {
                return DBInstanceTypeControl.Instance.PrecedentPlayer(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 当前副本似是否对pk的等级进行限制
        /// </summary>
        public bool PKLevelLimit
        {
            get
            {
                return DBInstanceTypeControl.Instance.PKLevelLimit(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 是否屏蔽点击其他玩家后弹出的详情界面
        /// </summary>
        public bool IgnoreClickPlayer
        {
            get
            {
                return DBInstanceTypeControl.Instance.IgnoreClickPlayer(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 是否强制显示玩家血条
        /// </summary>
        public bool ForceShowHpBar
        {
            get
            {
                return DBInstanceTypeControl.Instance.ForceShowHpBar(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 是否禁止使用道具
        /// </summary>
        public bool ForbidUseGoods(uint goodsId)
        {
            uint goodsType = GoodsHelper.GetGoodsType(goodsId);
            uint goodsSubType = GoodsHelper.GetGoodsSubType(goodsId);
            return DBInstanceTypeControl.Instance.ForbidUseGoods(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType, goodsType, goodsSubType);
        }

        public bool ForbidChangePkMode
        {
            get
            {
                return DBInstanceTypeControl.Instance.ForbiChangePkMode(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 是否显示弹幕开关
        /// </summary>
        public bool ShowDanmakuSwitch
        {
            get
            {
                return DBInstanceTypeControl.Instance.ShowDanmakuSwitch(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 指定的聊天频道是否显示弹幕
        /// </summary>
        /// <param name="chatChannel"></param>
        /// <returns></returns>
        public bool ShowDanmakuInChatChannel(uint chatChannel)
        {
            return DBInstanceTypeControl.Instance.ShowDanmaku(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType, chatChannel);
        }

        /// <summary>
        /// 是否禁止打开世界地图界面
        /// </summary>
        public bool ForbidOpenWorldMap
        {
            get
            {
                return DBInstanceTypeControl.Instance.ForbidOpenWorldMap(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 是否场景中禁止组队
        /// </summary>
        public bool ForbidTeam
        {
            get
            {
                return DBInstanceTypeControl.Instance.ForbidTeam(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 是否为武神塔
        /// </summary>
        public bool IsKungfuInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_SECRET_AREA) 
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在帮派BOSS
        /// </summary>
        public bool IsInGuildBossInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_GUILD_BOSS)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在破碎死域
        /// </summary>
        public bool IsInDeadSpaceInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_DEAD_SPACE)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在试炼BOSS
        /// </summary>
        public bool IsInTrialBossInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_TRIAL_BOSS)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在巅峰BOSS
        /// </summary>
        public bool IsInPeakBossInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_PEAK_BOSS)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// 是否在秘境守护副本
        /// </summary>
        public bool IsInSecretDefendInstance
        {
            get
            {
                return InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON 
                    && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_SECRET_DEFEND;
            }
        }
        
        /// <summary>
        /// 是否在南天圣地
        /// </summary>
        public bool IsInSouthLandInstance
        {
            get
            {
                return InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD
                    && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_SOUTH_LAND;
            }
        }

        /// <summary>
        /// 是否在元素禁地
        /// </summary>
        public bool IsInElementAreaInstance
        {
            get
            {
                return InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD
                    && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_ELEMENT_AREA;
            }
        }

        /// <summary>
        /// 是否在BOSS之家
        /// </summary>
        public bool IsInBossHomeInstance
        {
            get
            {
                return InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD
                    && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_BOSS;
            }
        }
        /// <summary>
        /// 是否在契约副本
        /// </summary>
        public bool IsInDeedInheritInstance
        {
            get
            {
                return InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON
                    && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_CONTRACT_INHERIT;
            }
        }

        /// <summary>
        ///  是否在 首个世界BOSS单人副本
        /// </summary>
        public bool IsInFirstWorldBossInstance
        {
            get
            {
                return InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON
                    && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_WORLD_BOSS_FIRST;
            }
        }

        /// <summary>
        /// 是否在仙灵山谷
        /// </summary>
        public bool IsInFairyValleyInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_FAIRY_VALLEY)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在剑域盛会
        /// </summary>
        public bool IsInWorshipMeetingInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_WORSHIP_MEETING)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在抓boss副本
        /// </summary>
        public bool IsInCatchBossInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_CATCH_BOSS)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在世界BOSS引导副本
        /// </summary>
        public bool IsInWorldBossExperienceInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_WORLD_BOSS_EXPERIENCE)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在世界BOSS首次副本
        /// </summary>
        public bool IsInWorldBossFirstInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_WORLD_BOSS_FIRST)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在个人BOSS副本
        /// </summary>
        public bool IsInPersonalBossInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_PERSON_BOSS)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在帮派联赛副本
        /// </summary>
        public bool IsInGuildLeagueInstance(uint instanceId = 0)
        {
            if (instanceId == 0)
            {
                instanceId = CurSceneID;
            }

            DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
            if (instanceInfo != null)
            {
                if (instanceInfo.mWarType == GameConst.WAR_TYPE_DUNGEON && instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_GUILD_LEAGUE)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否在跨服帮战副本
        /// </summary>
        public bool IsInSpanGuildWarInstance(uint instanceId = 0)
        {
            if (instanceId == 0)
            {
                instanceId = CurSceneID;
            }

            DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
            if (instanceInfo != null)
            {
                if (instanceInfo.mWarType == GameConst.WAR_TYPE_DUNGEON && instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_SPAN_GUILD_WAR)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否是情缘副本
        /// </summary>
        public bool IsInLoveInstance
        {
            get
            {
                DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
                if (instanceInfo != null)
                {
                    if (instanceInfo.mWarType == GameConst.WAR_TYPE_DUNGEON && instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_LOVE)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 是否在婚宴副本
        /// </summary>
        public bool IsInWeddingInstance
        {
            get
            {
                DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
                if (instanceInfo != null)
                {
                    if (instanceInfo.mWarType == GameConst.WAR_TYPE_DUNGEON && instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_WEDDING)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsInInstance
        {
            get
            {
                uint type = InstanceManager.Instance.InstanceType;
                if (type == GameConst.WAR_TYPE_DUNGEON)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在野外中
        /// </summary>
        public bool IsInWildInstance(uint instanceId = 0)
        {
            if (instanceId == 0)
            {
                instanceId = CurSceneID;
            }

            if (instanceId == CurSceneID)
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD)
                    return true;
            }
            else
            {
                DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
                if (instanceInfo != null)
                {
                    if (instanceInfo.mWarType == GameConst.WAR_TYPE_WILD)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 是否在普通野外
        /// </summary>
        public bool IsInNormalWild(uint instanceId = 0)
        {
            if (instanceId == 0)
            {
                instanceId = CurSceneID;
            }

            if (instanceId == CurSceneID)
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_WILD)
                    return true;
            }
            else
            {
                DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
                if (instanceInfo != null)
                {
                    if (instanceInfo.mWarType == GameConst.WAR_TYPE_WILD && instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_WILD)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 是否在副本或者野外中
        /// </summary>
        public bool IsPlayingInstance
        {
            get
            {
                return IsInInstance || IsInWildInstance();
            }
        }

        /// <summary>
        /// 是否在帮派领地
        /// </summary>
        public bool IsInGuildManor
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_GUILD_MANOR)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 是否在 魔王降临 副本
        /// </summary>
        public bool IsInDevilComeInstance
        {
            get
            {
                if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_DUNGEON 
                    && InstanceManager.Instance.InstanceSubType == GameConst.WAR_SUBTYPE_LORD_COME)
                    return true;

                return false;
            }
        }
        
        /// <summary>
        /// 场景是否使用aoi广播的
        /// </summary>
        /// <returns></returns>
        public bool IsInstanceUseAoi()
        {
            var cur_state = Game.GetInstance().GetFSM().GetCurState();
            if (cur_state != null && cur_state is CommonLuaInstanceState)
                return true;

            return false;
        }

        /// <summary>
        /// 是否显示PK模式
        /// </summary>
        public bool UsePKMode
        {
            get
            {
                return DBInstanceTypeControl.Instance.UsePKMode(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 当前副本类型下, 攻击同一阵容玩家是否不飘字（“不可攻击友方"） 
        /// </summary>
        public bool NoShowAtkCampTips 
        {
            get
            {
                return DBInstanceTypeControl.Instance.NoShowAtkCampTips(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            }
        }

        /// <summary>
        /// 当前场景是否可以骑坐骑
        /// </summary>
        public bool CanRide
        {
            get
            {
                DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
                if (instanceInfo != null)
                {
                    return !instanceInfo.mCanNotRide;
                }

                return false;
            }
        }

        /// <summary>
        /// 当前场景是否可以显示退出按钮
        /// </summary>
        public bool IsShowDungeonUI_inMainMap
        {
            get
            {
                if (IsInInstance)
                    return true;
                if (IsCanExitBtnInWild)
                    return true;
                return false;
            }
        }

        public bool IsCanExitBtnInWild
        {
            get
            {
                if (InstanceManager.Instance == null)
                    return false;
                uint type = InstanceManager.Instance.InstanceType;
                if (type != GameConst.WAR_TYPE_WILD)
                    return false;
                if (DBInstanceTypeControl.Instance.GetCanExit(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType))
                    return true;
                return false;
           }
        }

        const float autoSwitchDetailTime = 0.5f * 60.0f;
        int switchCount = 0;

        public void ProcessLineCD(uint time)
        {
            SceneHelp.Instance.mChangeLineCDTime = time;
            mDelyLineCdTime = 0;
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHANGE_LINE_CD_TIME, new CEventBaseArgs());
            uint cd = 0;
            cd = GameConstHelper.GetUint("GAME_LINE_CHANGE_CD");
            if(SceneHelp.Instance.mChangeLineCDTime + cd > Game.GetInstance().ServerTime)
            {
                mDelyLineCdTime = SceneHelp.Instance.mChangeLineCDTime + cd  - Game.GetInstance().ServerTime ;
                mLineCDTimer = new Utils.Timer((int)mDelyLineCdTime * 1000, false, 1000,
                                         (dt) =>
                                         {
                    if (dt <= 0f)
                    {
                        mDelyLineCdTime = 0;
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHANGE_LINE_CD_TIME, new CEventBaseArgs());
                        if (mLineCDTimer != null)
                        {
                            mLineCDTimer.Destroy();
                            mLineCDTimer = null;
                        }
                    }
                    else
                    {
                        mDelyLineCdTime = Mathf.Ceil(dt / 1000f);
                    }
                });
            }
        }

        /// <summary>
        /// 处理服务端发送过来的分线信息
        /// </summary>
        /// <param name="msg"></param>
        public void ProcessLineInfo(S2CMapLineState msg)
        {
            mLineInfos.Clear();
            uint minLine = GameConstHelper.GetUint("GAME_LINE_MIN");
            for(int i = 1 ; i <= minLine ; i ++)
            {
                mLineInfos.Add((uint)i , 0);
            }

            // 设置每条分线上的人数
            foreach(var info in msg.hcounts)
            {
                uint count = 0;
                if(mLineInfos.TryGetValue(info.line , out count))
                {
                    mLineInfos[info.line] = info.count;
                }
                else
                {
                    mLineInfos.Add(info.line , info.count);
                }
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LINE_INFO, new CEventBaseArgs(msg.dungeon_id));
        }

        /// <summary>
        /// 在进入副本之前检测副本是否下载完成
        /// 没下载的话会弹出提示框提示下载
        /// </summary>
        /// <param name="instance_id"></param>
        /// <returns></returns>
        public static bool PreCheckInstanceIsDownloaded(uint instance_id)
        {
            var instanceInfo = DBInstance.Instance.GetInstanceInfo(instance_id);
            if (instanceInfo == null) {
                return false;
            }

            string asset_path;
            if (TryGetSceneResByInstanceInfo(instanceInfo, out asset_path)) {
                int patch_id;
                if (!xpatch.XPatchManager.Instance.IsAssetDownloaded(asset_path, out patch_id)) {
                    //需要下载最新资源才能体验当前内容
                    var content = DBConstText.GetText("DOWNLOAD_PATCH_TIPS");

                    UIWidgetHelp.Instance.ShowNoticeDlg(ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, content,
                        (param) => { ui.ugui.UIManager.Instance.ShowSysWindow("UIPatchWindow", patch_id); }, null);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 在服务器要求场景切换时，检测副本是否下载完成
        /// 没下载的话，会在下一次进入任意场景时提示下载
        /// </summary>
        /// <param name="instance_id"></param>
        /// <returns></returns>
        public static bool PostCheckInstanceIsDownloaded(uint instance_id)
        {
            var instanceInfo = DBInstance.Instance.GetInstanceInfo(instance_id);
            if (instanceInfo == null) {
                return false;
            }

            string asset_path;
            if (TryGetSceneResByInstanceInfo(instanceInfo, out asset_path)) {
                int patch_id;
                if (!xpatch.XPatchManager.Instance.IsAssetDownloaded(asset_path, out patch_id)) {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SCENE_NOT_DOWNLOAD, new CEventBaseArgs(patch_id));
                    return false;
                }
            }

            // 找不到对应的asset_path也算是成功
            return true;
        }

        /// <summary>
        /// 根据InstanceInfo，查询其需要的场景资源
        /// 成功返回true
        /// </summary>
        /// <param name="instanceInfo"></param>
        /// <param name="asset_path"></param>
        /// <returns></returns>
        protected static bool TryGetSceneResByInstanceInfo(DBInstance.InstanceInfo instanceInfo, out string asset_path)
        {
            asset_path = string.Empty;
            if (instanceInfo.mStages == null || instanceInfo.mStages.Count <= 0) {
                return false;
            }

            var stage_id = instanceInfo.mStages[0];
            var map_ids = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_stage_map", "id", stage_id, "map");
            if (map_ids == null || map_ids.Count <= 0) {
                return false;
            }

            var map_id = Convert.ToUInt32(map_ids[0]);

            var db = DBManager.GetInstance().GetDB<DBMap>();
            if (db == null) {
                return false;
            }

            var map_info = db.GetMapInfo(map_id);
            if (map_info == null) {
                return false;
            }


            asset_path = map_info.SceneResPath;
            GameDebug.LogYellow(asset_path);

            return true;
        }

        static void JumpToSceneImpl(uint id, uint line = 0, uint transferPosId = 0, bool checkAttr = true)
        {
            if (LuaScriptMgr.Instance != null)
            {
                // 记录当弹出退出提示的时候是否要继续自动战斗
                if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
                {
                    SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
                }

                object[] param = { id, line, transferPosId, checkAttr };
                LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "InstanceHelper_JumpToScene", param);
            }
        }

        static void JumpToSceneWrap(uint id, uint line = 0, uint transferPosId = 0, bool checkAttr = true)
        {
            JumpToSceneImpl(id, line, transferPosId, checkAttr);
        }

        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="id"></param>
        public static void JumpToScene(uint id, uint line = 0, uint transferPosId = 0, bool checkAttr = true)
        {
            JumpToSceneWrap(id, line, transferPosId, checkAttr);
        }

        private static bool m_isReEnterScene = false;
        public static bool IsReEnterScene
        {
            get { return m_isReEnterScene; }
        }

        private static string mLogFmt = "TestinLog-Event>>>> ID GameQuality, Key GameQuality, Value {0}";

        /// <summary>
        /// 重新进入当前的场景(切换画质的时候使用)
        /// </summary>
        public static void ReenterScene()
        {
            // TestinExternalLog
            var logContent = string.Format(mLogFmt, 3 - QualitySetting.GraphicLevel);
            DBOSManager.getOSBridge().log2OSCmd("TestinExternalLog", logContent);

            // 如果当前场景名字和需要再次进入的场景名字不一样，才进行跳场景的操作
            var cur_scene_name = SceneHelp.Instance.CurSceneName;
            var db_map = DBManager.Instance.GetDB<DBMap>();
            if (db_map == null)
                return;

            var map_info = SceneHelp.Instance.MapInfo;
            if (map_info == null)
            {
                GameDebug.LogError("MapInfo is null");
                return;
            }
            m_isReEnterScene = true;
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SETTING_QUALITY_CHANGED, null);

            var scen_name = map_info.SceneLevelName;
            if (scen_name != cur_scene_name)
            {
                if (CheckCanSwitch(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType, false))
                {
                    JumpToScene(SceneHelp.Instance.CurSceneID);
                }
                else
                    GameDebug.Log("can not renter scene");
            }
            
            m_isReEnterScene = false;
        }

        /// <summary>
        /// 当前是否可以切换画质
        /// </summary>
        /// <returns></returns>
        public static bool CheckCanSwitch()
        {
            return CheckCanSwitch(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType, false);
        }

        /// <summary>
        /// 跳转到上一个场景
        /// </summary>
        public static void JumpToPreScene()
        {
            JumpToSceneWrap(SceneHelp.Instance.PreSceneID);
        }

        /// <summary>
        /// 飞鞋
        /// </summary>
        public static bool TravelBootsJump(Vector3 pos, uint instanceId = 0, bool isFree = false, uint line = 1, bool isAutoFighting = false)
        {
            if (instanceId == 0)
            {
                instanceId = SceneHelp.Instance.CurSceneID;
            }

            if (PKModeManagerEx.Instance.TryToOtherDungeonScene() == false)
                return false;

            DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
            if (instanceInfo == null)
            {
                GameDebug.LogError("Travel boots ump to scene " + instanceId + " error, can not find instance info!!!");
                return false;
            }

            // 本地玩家处于护送状态不能用飞鞋
            if (CheckLocalPlayerEscortTaskState() == false)
            {
                return false;
            }

            // 检查道具
            if (isFree == false)
            {
                if (VipHelper.GetIsFlyFree() == false)
                {
                    uint need_goods = GameConstHelper.GetUint("GAME_ITEM_TRAVEL_BOOTS");
                    if (need_goods > 0)
                    {
                        var num = ItemManager.Instance.GetGoodsNumForBagByTypeId(need_goods);
                        if (num <= 0)
                        {
                            UINotice.Instance.ShowMessage(DBConstText.GetText("ITME_NUM_NOTENOUGH"));
                            return false;
                        }
                    }
                }
            }

            bool isInstance = false;
            if (instanceInfo.mWarType == GameConst.WAR_TYPE_DUNGEON)
            {
                isInstance = true;
            }

            // 检查是否达到等级
            uint needLv = InstanceHelper.GetInstanceNeedRoleLevel(instanceId);
            if (LocalPlayerManager.Instance.LocalActorAttribute.Level < needLv)
            {
                // 巅峰等级
                uint peakLv = 0;
                bool isPeak = TransferHelper.IsPeak(needLv, out peakLv);
                string levelStr = "";
                if (isPeak)
                {
                    levelStr = string.Format(DBConstText.GetText("UI_PLAYER_PEAK_LEVEL_FORMAT_2"), peakLv); // 巅峰{0}
                }
                else
                {
                    levelStr = peakLv.ToString(); // {0}
                }
                if (isInstance == true)
                {
                    UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("INSTANCE_IS_NOT_UNLOCK_NEED_LEVEL"), levelStr));
                }
                else
                {
                    UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("WILD_INSTANCE_IS_NOT_UNLOCK_NEED_LEVEL"), levelStr));
                }
                return false;
            }

            // 检查是否通关某主线任务
            uint needTaskId = instanceInfo.mNeedTaskId;
            if (needTaskId > 0)
            {
                if (TaskHelper.MainTaskIsPassed(needTaskId) == false)
                {
                    TaskDefine needTaskDefine = TaskDefine.MakeDefine(needTaskId);
                    if (needTaskDefine != null)
                    {
                        // 巅峰等级
                        uint peakLv = 0;
                        bool isPeak = TransferHelper.IsPeak((uint)needTaskDefine.RequestLevelMin, out peakLv);
                        string levelStr = "";
                        if (isPeak)
                        {
                            levelStr = string.Format(DBConstText.GetText("UI_PLAYER_PEAK_LEVEL_FORMAT_2"), peakLv); // 巅峰{0}
                        }
                        else
                        {
                            levelStr = peakLv.ToString(); // {0}
                        }
                        if (isInstance == true)
                        {
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("INSTANCE_IS_NOT_UNLOCK_NEED_TASK"), levelStr, needTaskDefine.Name, instanceInfo.mName));
                        }
                        else
                        {
                            UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("WILD_INSTANCE_IS_NOT_UNLOCK_NEED_TASK"), levelStr, needTaskDefine.Name, instanceInfo.mName));
                        }
                    }
                    return false;
                }
            }

            // 判断是否可到达
            if (instanceId == SceneHelp.Instance.CurSceneID)
            {
                if (InstanceHelper.CanWalkTo(pos) == false)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("MAP_POS_CAN_NOT_REACH"));
                    return false;
                }
            }

            // 跳往不同的场景需要加个转圈，防止同时多次跳转
            if (instanceId != SceneHelp.Instance.CurSceneID)
            {
                ui.ugui.UIManager.GetInstance().ShowWaitScreen(true);
            }

            C2STravelBootsJump data = new C2STravelBootsJump();
            data.dungeon_id = instanceId;
            data.line = line;
            PkgNwarPos pkgNwarPos = new PkgNwarPos();
            pkgNwarPos.px = (int)(pos.x / GlobalConst.UnitScale);
            pkgNwarPos.py = (int)(pos.z / GlobalConst.UnitScale);
            data.pos = pkgNwarPos;
            if (isFree == true)
            {
                data.is_free = 1;
            }
            else
            {
                data.is_free = 0;
            }

            NetClient.BaseClient.SendData<C2STravelBootsJump>(NetMsg.MSG_TRAVEL_BOOTS_JUMP, data);

            SceneHelp.Instance.IsAutoFightingAfterSwitchInstance = isAutoFighting;

            InstanceManager.Instance.IsAutoFighting = false;

            return true;
        }

        /// <summary>
        /// 获取指定副本的第一个关卡id
        /// </summary>
        public static uint GetFirstStageId(uint instanceId)
        {
            DBInstance dbInstance = DBManager.Instance.GetDB<DBInstance>();
            if (dbInstance != null)
            {
                DBInstance.InstanceInfo instanceInfo = dbInstance.GetInstanceInfo(instanceId);
                if (instanceInfo != null)
                {
                    return instanceInfo.mStages[0];
                }
            }

            return 0;
        }

        public static uint GetFirstMapIdByInstanceId(uint instanceId)
        {
            uint mapId = 0;
            uint stageId = GetFirstStageId(instanceId);
            List<string> retStrs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_stage_map", "id", stageId.ToString(), "map");
            if (retStrs.Count > 0)
            {
                uint.TryParse(retStrs[0], out mapId);
            }

            return mapId;
        }

        /// <summary>
        /// 从关卡id获取mapid
        /// </summary>
        /// <param name="stage_id"></param>
        /// <returns></returns>
        public static uint GetMapIdByStageId(uint stage_id)
        {
            uint mapId = 0;
            List<string> retStrs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_stage_map", "id", stage_id.ToString(), "map");
            if (retStrs.Count > 0)
            {
                uint.TryParse(retStrs[0], out mapId);
            }

            return mapId;
        }

        /// <summary>
        /// 是否正在切换场景
        /// </summary>
        public bool IsSwitchingScene
        {
            get { return m_SwitchingScene; }
            set { m_SwitchingScene = value; }
        }

        /// <summary>
        /// 加载QuadTreeScene的状态枚举
        /// </summary>
        public enum LoadQuadTreeSceneState
        {
            NoStartLoading = 1, // 还没开始加载
            Loading,            // 加载中
            LoadFinished,       // 加载完毕
        }
        private LoadQuadTreeSceneState mIsLoadingQuadTreeScene = LoadQuadTreeSceneState.NoStartLoading;
        public LoadQuadTreeSceneState IsLoadingQuadTreeScene
        {
            get { return mIsLoadingQuadTreeScene; }
            set { mIsLoadingQuadTreeScene = value; }
        }

        /// <summary>
        /// 通过map_id来进行场景切换
        /// </summary>
        public void SwitchScene(uint map_id, bool auto_hide_loadingUI, bool willSwitchScene)
        {
            DBMap db_map = DBManager.GetInstance().GetDB<DBMap>();
            if (db_map == null)
            {
                GameDebug.LogError("No scene with map id " + map_id);
                return;
            }

            DBMap.MapInfo map_info = db_map.GetMapInfo(map_id);
            if (map_info == null)
            {
                GameDebug.LogError("No scene with map id " + map_id);
                return;
            }

            mCurMapInfo = map_info;

            SwitchScene(map_info, auto_hide_loadingUI, willSwitchScene);
        }

        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="map_info">地图信息</param>
        /// <param name="auto_hide_loadingUI">是否在加载完成后自动隐藏loading界面</param>
        /// <param name="willSwitchScene">是否需要切换场景</param>
        public void SwitchScene(DBMap.MapInfo map_info, bool auto_hide_loadingUI, bool willSwitchScene)
        {
            mCurSceneName = map_info.SceneLevelName;
            mCurSceneResPath = map_info.SceneResPath;
            bool clearUI = true;

            if (willSwitchScene == false)
            {
                clearUI = false;
                // 是否需要切换UI
                if (SceneHelp.Instance.CurSceneID != SceneHelp.Instance.PreSceneID)
                {
                    UIVisibleControlComponent.UpdateVisibleState();

                    //ui.ugui.UIManager.GetInstance().ClearUI();
                    //xc.ClientEventManager<ClientEventType.ugui.UICoreEvent>.Instance.FireEvent(ClientEventType.ugui.UICoreEvent.LEVEL_CHANGE, null);
                    ui.ugui.UIManager.GetInstance().CloseWindowsWhenSwitchPlaneInstance();

                    // 这里要fire这个事件，不然主界面右上角出不来
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_SWITCH_ANIMATION, new CEventBaseArgs(true));
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_START_SWITCH_PLANE_INSTANCE,null);
                }
            }
            else
            {
                ui.ugui.UIManager.GetInstance().ClearUI();
                xc.ClientEventManager<ClientEventType.ugui.UICoreEvent>.Instance.FireEvent(ClientEventType.ugui.UICoreEvent.LEVEL_CHANGE, null);

                m_SwitchingScene = true;
                ui.ugui.UIManager.GetInstance().ShowLoadingBK(true);
                mAutoHideLoadingUI = auto_hide_loadingUI;

                /*ui.UIWidgetHelp.GetInstance().HideNoticeDlg()*/
                UIWidgetHelp.BlockOtherNoticeDlg = false;
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_START_SWITCHSCENE, null);

                // 展示一个资源加载界面
                // MapLoading 场景中的SceneLoader组件会按照Game中的全局数据来加载场景
                Game.GetInstance().SetLoadAsyncOp(null);
                SceneManager.LoadScene("MapLoading");

                SceneHelp.Instance.IsLoadingQuadTreeScene = SceneHelp.LoadQuadTreeSceneState.NoStartLoading;
            }
            AudioManager.GetInstance().TransferOut();
            Dungeon.CollectionObjectManager.Instance.Enable = true;//重置采集

            // 销毁场景数据
            DestroyScene(clearUI);
        }

        /// <summary>
        /// 切换进入游戏前的场景
        /// </summary>
        public void SwitchPreposeScene(string name, bool auto_hide_loading_ui)
        {
            var map_info = new DBMap.MapInfo();
            map_info.SceneRes = name;
            SwitchScene(map_info, auto_hide_loading_ui, true);
        }

        /// <summary>
        /// 销毁场景数据
        /// </summary>
        void DestroyScene(bool clearUI = true)
        {
            DialogManager.Instance.Reset();

            // 保存客户端需要保存的玩家信息
            LocalPlayerManager.Instance.OnDestroyScene();

            // 销毁所有场景不需要的数据  
            if (ActorManager.Instance != null)
            {
                ActorManager.Instance.OnDestroyScene();
            }

            InterObjectManager.Instance.DestroyAllAndBoss();

            Game.Instance.SetLocalPlayer(null);

            CullManager.GetInstance().Reset();

            if (ObjCachePoolMgr.Instance != null)
            {
                ObjCachePoolMgr.Instance.OnDestroyScene(clearUI);
            }

            ObjInstHelp.GetInstance().ClearInstedObject();
        }

        /// <summary>
        /// 通过查副本切换控制表来检查能否切换
        /// </summary>
        /// <param name="warType"></param>
        /// <param name="warSubType"></param>
        /// <returns></returns>
        public static bool CheckCanSwitch(uint warType, uint warSubType, bool show_notice = true)
        {
            uint curWarType = InstanceManager.Instance.InstanceType;
            uint curWarSubType = InstanceManager.Instance.InstanceSubType;

            // 游戏初始副本类型的值都是0，这时候可以跳转到任何副本
            if (curWarType == 0 && curWarSubType == 0)
            {
                return true;
            }

            List<string> datas = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "instance_switch_control", "id", curWarType + "_" + curWarSubType, "type_" + warType + "_" + warSubType);
            if (datas != null && datas.Count > 0)
            {
                uint val = 0;
                uint.TryParse(datas[0], out val);
                if (val > 0)
                {
                    return true;
                }
            }
            else
            {
                GameDebug.LogError("Check can switch instance error, can not find config in excel, current war type: " + curWarType + ", current war sub type: " + curWarSubType + ", target war type: " + warType + ", target war sub type: " + warSubType);
                return false;
            }

            bool isInstance = false;
            if (warType == GameConst.WAR_TYPE_DUNGEON)
            {
                isInstance = true;
            }

            if (isInstance == true)
            {
                if(show_notice)
                    UINotice.Instance.ShowMessage(DBConstText.GetText("INSTANCE_CAN_NOT_SWITCH_INSTANCE"));
            }
            else
            {
                if (show_notice)
                    UINotice.Instance.ShowMessage(DBConstText.GetText("INSTANCE_CAN_NOT_SWITCH_WILD_INSTANCE"));
            }

            GameDebug.Log("Can not switch instance, current war type: " + curWarType + ", current war sub type: " + curWarSubType + ", target war type: " + warType + ", target war sub type: " + warSubType);

            return false;
        }

        public static bool CheckCanSwitch(uint instanceId, bool show_notice = true)
        {
            DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
            if (instanceInfo != null)
            {
                return CheckCanSwitch(instanceInfo.mWarType, instanceInfo.mWarSubType, show_notice);
            }

            return false;
        }

        /// <summary>
        /// 判断本地玩家的护送任务状态
        /// </summary>
        /// <param name="showTips"></param>
        /// <returns></returns>
        public static bool CheckLocalPlayerEscortTaskState(bool showTips = true)
        {
            if (TaskHelper.LocalPlayerIsInEscortTaskState() == true)
            {
                if (showTips == true)
                {
                    UINotice.Instance.ShowMessage(DBErrorCode.GetErrorString((uint)ErrorCode.ERR_TASK_ESCORT_DOING));
                }
                return false;
            }

            return true;
        }
    }
}

