/*----------------------------------------------------------------
// 文件名： InstanceManager.cs
// 文件功能描述： 副本管理类
//----------------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using xc.ui;
using Net;
using xc.protocol;

namespace xc
{
    /// <summary>
    /// 破碎死域(安格玛)积分
    /// </summary>
    [wxb.Hotfix]
    public class DungeonDeadSpaceScore
    {
        public DungeonDeadSpaceScore(uint lv, uint score, ulong exp)
        {
            this.lv = lv;
            this.score = score;
            this.exp = exp;
        }

        public uint lv;     // 阶段
        public uint score;  // 积分
        public ulong exp;   // 经验
    }

    /// <summary>
    /// 仙灵山谷信息
    /// </summary>
    public class DungeonFairyValleyInfo
    {
        public uint common;     // 击杀小怪数量
        public uint elite;      // 击杀精英数量
        public uint boss;       // 击杀boss数量
        public ulong exp;       // 个人获取经验数
        public uint current;    // 当前波数
    }

    public class InstanceManager : xc.Singleton<InstanceManager>
	{
        DBInstance.InstanceInfo mInstanceInfo;
        DBMap.MapInfo mMapInfo;

        // 章节和副本通关奖励
        public enum ERewardState : byte
        {
            RS_UnGot = 0,       // 未领取
            RS_Got = 1,         // 已领取
            RS_UnFinished = 2,  // 未达成
        }
        public enum InstaneOpenState
        {
            NotOpen =0,
            Open,
        }

        public Dictionary<uint, InstaneOpenState> InstanceOpenState = new Dictionary<uint, InstaneOpenState>();

        /// <summary>
        /// 副本通关时间
        /// </summary>
        public uint InstanceCostTime { get; set; }

        /// <summary>
        /// 复活疲劳层数
        /// </summary>
        public uint ReviveLayer { get; set; }

        /// <summary>
        /// 当前是否在自动战斗
        /// </summary>
        bool mIsAutoFighting = false;
        float mAutoFightTime = 0f;
        /// <summary>
        /// 自动战斗期间的经验
        /// </summary>
        ulong mAutoFightingGotExp = 0;
        /// <summary>
        /// 上一次自动战斗期间的经验
        /// </summary>
        ulong mLastAutoFightingGotExp = 0;
        /// <summary>
        /// 是否显示挂机经验效率
        /// </summary>
        bool mIsShowAutoFightingGotExp = true;
        public bool IsShowAutoFightingGotExp
        {
            set
            {
                mIsShowAutoFightingGotExp = value;

                if (mIsShowAutoFightingGotExp == false)
                {
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_AUTO_BATTLE_GET_EXP, new CEventObjectArgs(false, 0));
                }
            }
        }

        /// <summary>
        /// 是否在挂机
        /// </summary>
        public bool IsOnHook { get; set; }

        private bool mIsBreakingAutoFight = false;
        private float mAutoFightBreakingTime = 0.0f;
        private float mAutoBreakRecoverTime = GameConstHelper.GetFloat("GAME_AUTO_FIGHT_BREAK_RECOVER_TIME");

        private bool m_isInCastingReadyStage = false;
        private float m_maxCastingReadyInterval = 0;    //最大的吟唱时间
        public bool IsInCastingReadyStage
        {
            get { return m_isInCastingReadyStage; }
        }
        public float InCastingReadyStageMaxInterval
        {
            get { return m_maxCastingReadyInterval; }
        }

        public uint KunfuGodId = 0;//武神塔已通关id
        public List<uint> KunfuGodShowRunesTipsCache = new List<uint>();

        /// <summary>
        /// 秒一片副本杀怪数
        /// </summary>
        public uint KillPieceNum { get; set; }

        /// <summary>
        /// 考眼力积分
        /// </summary>
        public uint DogHeadScore { get; set; }

        /// <summary>
        /// 破碎死域积分
        /// </summary>
        public DungeonDeadSpaceScore DeadSpaceScore { get; set; }

        /// <summary>
        /// 仙灵山谷信息
        /// </summary>
        public DungeonFairyValleyInfo FairyValleyInfo { get; set; }

        /// <summary>
        /// 仙灵山谷经验记录
        /// </summary>
        public ulong FairyValleyExpRecord { get; set; }

        /// <summary>
        /// 仙灵山谷鼓舞次数
        /// </summary>
        public uint FairyValleyInspireNum1 { get; set; }
        public uint FairyValleyInspireNum2 { get; set; }

        /// <summary>
        /// 设定玩家是否处于吟唱阶段
        /// </summary>
        /// <param name="var_isInCastingReadyStage"></param>
        /// <param name="max_castingReady_interval"></param>
        public void SetInCastingReadyStage(bool var_isInCastingReadyStage, float max_castingReady_interval)
        {
            if (m_isInCastingReadyStage == var_isInCastingReadyStage)
                return;
            m_isInCastingReadyStage = var_isInCastingReadyStage;
            m_maxCastingReadyInterval = max_castingReady_interval;
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHANGE_LOCALPLAYER_CASTINGREADY_STATGE, null);
        }

        /// <summary>
        /// 副本投票信息
        /// </summary>
        public class InstancePollInfo
        {
            /// <summary>
            /// 副本id
            /// </summary>
            public uint InstanceId { get; set; }

            /// <summary>
            /// 投票id
            /// </summary>
            public uint PollId { get; set; }

            public Dictionary<uint, uint> VoteList { get; set; }

            public InstancePollInfo()
            {
                InstanceId = 0;
                PollId = 0;
                VoteList = new Dictionary<uint, uint>();
                VoteList.Clear();
            }

            public void ChangeVote(uint uuid, uint vote)
            {
                if (VoteList.ContainsKey(uuid) == true)
                {
                    VoteList[uuid] = vote;
                }
                else
                {
                    VoteList.Add(uuid, vote);
                }
            }
        }
        public InstancePollInfo PollInfo { get; set; }

        /// <summary>
        /// 投票开始时间
        /// </summary>
        public uint PollStartTime { get; set; }

        /// <summary>
        /// 副本阶段
        /// </summary>
        public uint InstancePhase { get; set; }

        /// <summary>
        /// 副本阶段开始时间戳
        /// </summary>
        public uint InstancePhaseStartTime { get; set; }

        /// <summary>
        /// 副本阶段内进展
        /// </summary>
        public uint InstancePhaseProgress { get; set; }

        /// <summary>
        /// 副本评分
        /// </summary>
        public uint InstanceMark { get; set; }

        public InstanceManager()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnRockSkillSuccess);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerClickedCollision);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PLAYERDEAD, OnPlayerDead);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_LOCALPLAYER_EXP_ADDED, OnLocalPlayerExpAdded);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SWITCHINSTANCE, OnSwitchInstance);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_MAINMAP_OPEN, OnMainMapLoad);
            //ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGRAM_OPENNEW, OnCheckInstanceOpen);//有八卦牌更新
        }

        public void Reset(bool isBreakLine)
        {
            KunfuGodId = 0;
            ReviveLayer = 0;
            InstanceCostTime = 0;
            PollInfo = null;
            PollStartTime = 0;
            KillPieceNum = 0;
            DogHeadScore = 0;
            IsOnHook = false;

            DeadSpaceScore = null;
            //FairyValleyInfo = null;
            //FairyValleyExpRecord = 0;
            //FairyValleyInspireNum = 0;

            KunfuGodShowRunesTipsCache.Clear();
            InstanceOpenState.Clear();
        }

        public void ResetInstanceData()
        {
            InstancePhase = 1;
            InstancePhaseStartTime = Game.GetInstance().ServerTime;
            InstancePhaseProgress = 0;
            InstanceMark = 1;
            KillPieceNum = 0;
            DogHeadScore = 0;
        }

        public void RegisterAllMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_PHASE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_PHASE_PROGRESS, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_MARK, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_SECRET_AREA_INFO, HandleServerData);//武神塔
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_KILL_PIECE_NUM, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_DOG_HEAD_SCORE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_DEAD_SPACE_SCORE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_DEAD_SPACE_SCORE_ADD, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_FAIRY_VALLEY_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_FAIRY_VALLEY_CURRENT_EXP, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_FAIRY_VALLEY_EXP, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_FAIRY_VALLEY_INSPIRE, HandleServerData);
        }

        public void Update()
        {
            if (InstanceHelper.InstanceIsInPlay() == false)
            {
                return;
            }

            Actor localPlayer = Game.GetInstance().GetLocalPlayer();

            if (localPlayer == null)
            {
                return;
            }

            if(Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                mAutoFightBreakingTime = 0.0f;
                //mAutoBreakRecoverTime = GameConstHelper.GetFloat("GAME_AUTO_FIGHT_BREAK_RECOVER_TIME");
            }

            if (IsAutoFighting)
            {
                if(localPlayer.GetAIEnable() == false && GameInput.Instance.GetEnableInput())
                {
                    mIsBreakingAutoFight = true;

                    if (localPlayer.IsWalking() == false && localPlayer.IsAttacking() == false)
                    {
                        mAutoFightBreakingTime += Time.deltaTime;
                    }

                    // 玩家交互中不允许恢复自动战斗
                    if (mAutoFightBreakingTime > mAutoBreakRecoverTime && localPlayer.ActorMachine.IsInInteraction == false)
                    {
                        localPlayer.ActiveAI(true);
                        GameInput.Instance.EnableInput(false);

                        mIsBreakingAutoFight = false;

                        var playerAI = localPlayer.GetAI() as BehaviourAI;
                        if (playerAI != null)
                        {
                            playerAI.RunningProperty.OriginalSelfActorPos = localPlayer.transform.position;
                        }

                        // 暂时屏蔽掉
                        //UINotice.Instance.ShowMessage(DBConstText.GetText("AUTO_FIGHT_ENTER"));
                    }
                }
            }

            mAutoFightTime += Time.deltaTime;
            if (mAutoFightTime > 30f)
            {
                mAutoFightTime = 0f;

                // 获得经验大于0才显示经验效率
                if (mAutoFightingGotExp > 0)
                {
                    if (mLastAutoFightingGotExp > 0)
                    {
                        mAutoFightingGotExp = (mLastAutoFightingGotExp + mAutoFightingGotExp) / 2;
                    }
                    mLastAutoFightingGotExp = mAutoFightingGotExp;

                    if (mIsShowAutoFightingGotExp == true)
                    {
                        if (DBInstanceTypeControl.Instance.IsShowAutoFightingGotExp(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType) == true)
                        {
                            // 因为这里是显示每分钟的经验，所以才乘以2
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_AUTO_BATTLE_GET_EXP, new CEventObjectArgs(true, 2 * mAutoFightingGotExp));
                        }
                    }
                }
                else
                {
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_AUTO_BATTLE_GET_EXP, new CEventObjectArgs(false, 0));
                }

                mAutoFightingGotExp = 0;
            }
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_DUNGEON_PHASE:
                    {
                        S2CDungeonPhase msg = S2CPackBase.DeserializePack<S2CDungeonPhase>(data);

                        InstancePhase = msg.phase;
                        InstancePhaseProgress = 0;
                        InstancePhaseStartTime = (uint)(0.001 * (double)(msg.time));

                        //GameDebug.LogError("<<< MSG_DUNGEON_PHASE: " + InstancePhase + ", " + msg.time);

                        // 校正服务器时间
                        //Game.GetInstance().ServerTime = InstancePhaseStartTime;
                        //GameDebug.LogError("Server time: " + Game.GetInstance().ServerTime);


                        // 帮派boss的第一阶段不显示阶段目标
                        if (SceneHelp.Instance.IsInGuildBossInstance == true && InstancePhase == 1)
                        {

                        }
                        else
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_PHASE_CHANGED, null);
                        }

                        break;
                    }
                case NetMsg.MSG_DUNGEON_PHASE_PROGRESS:
                    {
                        S2CDungeonPhaseProgress msg = S2CPackBase.DeserializePack<S2CDungeonPhaseProgress>(data);

                        InstancePhaseProgress = msg.count;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_PHASE_PROGRESS_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_DUNGEON_MARK:
                    {
                        S2CDungeonMark msg = S2CPackBase.DeserializePack<S2CDungeonMark>(data);

                        InstanceMark = msg.mark;

                        //GameDebug.LogError("<<< MSG_DUNGEON_MARK: " + InstanceMark);

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_MARK_CHANGED, null);

                        break;
                    }
               case NetMsg.MSG_DUNGEON_SECRET_AREA_INFO:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonSecretAreaInfo>(data);

                        if (KunfuGodId != 0)
                        {
                            bool isNeed = InstanceHelper.IsNeedShowRuneTips(msg.id);
                            if (isNeed)
                            {
                                //ui.ugui.UIManager.Instance.ShowWindow("UIRunesTipsWindow", "Normal", msg.id);

                                // 先不打开突破奖励界面，放在缓存里面，等下次打开武神塔界面的时候再打开
                                KunfuGodShowRunesTipsCache.Add(msg.id);
                            }
                        }
                        KunfuGodId = msg.id;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_KUNGFUGOD_CHANGED, null);
                        break;
                    }
                case NetMsg.MSG_DUNGEON_KILL_PIECE_NUM:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonKillPieceNum>(data);

                        KillPieceNum = msg.count;
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_PHASE_PROGRESS_CHANGED, null);
                        break;
                    }
                case NetMsg.MSG_DUNGEON_DOG_HEAD_SCORE:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonDogHeadScore>(data);

                        DogHeadScore = msg.score;
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_PHASE_PROGRESS_CHANGED, null);
                        break;
                    }
                case NetMsg.MSG_DUNGEON_DEAD_SPACE_SCORE:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonDeadSpaceScore>(data);

                        uint oldLv = 0;
                        uint oldScore = 0;
                        ulong oldExp = 0;
                        if (DeadSpaceScore != null)
                        {
                            oldLv = DeadSpaceScore.lv;
                            oldScore = DeadSpaceScore.score;
                            oldExp = DeadSpaceScore.exp;
                        }

                        DeadSpaceScore = new DungeonDeadSpaceScore(msg.lv, msg.score, msg.exp);

                        if (oldLv == 0 || oldLv != DeadSpaceScore.lv)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_DEAD_SPACE_LV_CHANGED, null);
                        }
                        if (oldScore == 0 || oldScore != DeadSpaceScore.score)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_DEAD_SPACE_SCORE_CHANGED, null);
                        }
                        if (oldExp == 0 || oldExp != DeadSpaceScore.exp)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_DEAD_SPACE_EXP_CHANGED, null);
                        }
                        break;
                    }
                case NetMsg.MSG_DUNGEON_DEAD_SPACE_SCORE_ADD:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonDeadSpaceScoreAdd>(data);

                        string text = "";
                        if (msg.reason == 1)
                        {
                            text = string.Format(DBConstText.GetText("DEAD_SPACE_INSTANCE_KILL_PLAYER_ADD_SCORE"), msg.score);
                        }
                        else if (msg.reason == 2)
                        {
                            text = string.Format(DBConstText.GetText("DEAD_SPACE_INSTANCE_KILL_MONSTER_ADD_SCORE"), msg.score);
                        }
                        UINotice.Instance.ShowMessage(text);
                        break;
                    }
                case NetMsg.MSG_DUNGEON_FAIRY_VALLEY_INFO:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonFairyValleyInfo>(data);

                        if (FairyValleyInfo == null)
                        {
                            FairyValleyInfo = new DungeonFairyValleyInfo();
                        }
                        FairyValleyInfo.common = msg.common;
                        FairyValleyInfo.elite = msg.elite;
                        FairyValleyInfo.boss = msg.boss;
                        FairyValleyInfo.current = msg.current;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_FAIRY_VALLEY_INFO_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_DUNGEON_FAIRY_VALLEY_CURRENT_EXP:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonFairyValleyCurrentExp>(data);

                        if (FairyValleyInfo == null)
                        {
                            FairyValleyInfo = new DungeonFairyValleyInfo();
                        }
                        FairyValleyInfo.exp = msg.exp;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_FAIRY_VALLEY_INFO_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_DUNGEON_FAIRY_VALLEY_EXP:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonFairyValleyExp>(data);

                        FairyValleyExpRecord = msg.exp;

                        break;
                    }
                case NetMsg.MSG_DUNGEON_FAIRY_VALLEY_INSPIRE:
                    {
                        var msg = S2CPackBase.DeserializePack<S2CDungeonFairyValleyInspire>(data);

                        FairyValleyInspireNum1 = msg.cnum;
                        FairyValleyInspireNum2 = msg.dnum;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTANCE_FAIRY_VALLEY_INSPIRE_NUM_CHANGED, null);

                        break;
                    }
                default:
                    break;
            }
        }
        
        private void OnPlayerControlled(CEventBaseArgs args)
        {
            PauseAutoFighting();
        }

        private void OnPlayerClickedCollision(CEventBaseArgs args)
        {
            OnPlayerControlled(null);
        }

        /// <summary>
        /// 暂停自动战斗
        /// </summary>
        public void PauseAutoFighting(bool isShowTips = false)
        {
            if (InstanceHelper.InstanceIsInPlay() == false)
            {
                return;
            }

            Actor localPlayer = Game.GetInstance().GetLocalPlayer();

            if (localPlayer == null)
            {
                return;
            }

            if (IsAutoFighting && localPlayer.GetAIEnable() == true)
            {
                localPlayer.ActiveAI(false);
                localPlayer.AttackCtrl.ClearCacheSkill();
                GameInput.Instance.EnableInput(true);
                mAutoFightBreakingTime = 0.0f;
                mAutoBreakRecoverTime = GameConstHelper.GetFloat("GAME_AUTO_FIGHT_BREAK_RECOVER_TIME");

                if (isShowTips == true)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("AUTO_FIGHT_PAUSE"));
                }
            }
        }

        private void OnPlayerDead(CEventBaseArgs args)
        {
            UnitID uid = (UnitID)args.arg;
            if (uid != null && Game.GetInstance().LocalPlayerID.Equals(uid) == true)
            {
                
            }
        }

        private void OnMainMapLoad(CEventBaseArgs args)
        {
            InstanceOpenState.Clear();
            List<Dictionary<string, string>> data_world = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_world");
            for (int i = 0; i < data_world.Count; i++)
            {
                Dictionary<string, string> data = data_world[i];
                uint mapId = DBTextResource.ParseUI_s(data["map_id"], 0);
                var instanceInfo = DBInstance.Instance.GetInstanceInfo(mapId);
                if (instanceInfo != null)
                {
                    InstaneOpenState state = InstaneOpenState.NotOpen;
                    bool isOpen = MiniMapHelp.isMapOpen(mapId);
                    if (isOpen)
                        state = InstaneOpenState.Open;
                    InstanceOpenState.Add(mapId, state);
                }
           }
        }

        private void OnLocalPlayerExpAdded(CEventBaseArgs args)
        {
            // 野外才计算挂机经验效率
            //if (SceneHelp.Instance.IsInWildInstance() == true)
            {
                CEventObjectArgs objectArgs = (CEventObjectArgs)args;
                ulong expAdded = (ulong)objectArgs.Value[0];
                uint reason = (uint)objectArgs.Value[1];
                if (reason == GameConst.EXP_REASON_KILL_MON)
                {
                    mAutoFightingGotExp += expAdded;
                }
            }
        }

        void OnRockSkillSuccess(CEventBaseArgs data)
        {
            //OnPlayerControlled(data);
        }

        private void OnSwitchInstance(CEventBaseArgs evt)
        {
            // 已经进入副本了就不需要显示了
            if (PollInfo != null && PollInfo.InstanceId != SceneHelp.Instance.CurSceneID)
            {
                xc.ui.ugui.UIManager.Instance.ShowWindow("UITeamInstancePrepareWindow", PollInfo.InstanceId);
            }

            mIsShowAutoFightingGotExp = true;

            // 角色切换场景后，清除原有的经验效率
            mLastAutoFightingGotExp = 0;
        }

        public DBInstance.InstanceInfo InstanceInfo
        {
            get
            {
                return mInstanceInfo;
            }
            set {
                bool is_need_updateScene = false;
                if (mInstanceInfo == null)
                    is_need_updateScene = true;
                mInstanceInfo = value;
                if (is_need_updateScene)
                {
                    PKModeManagerEx.instance.IsInSafeArea = false;
                    PKModeManagerEx.instance.IsInPKArea = false;
                }
                PKModeManagerEx.instance.UpdateAttack();
            }
        }

        public DBMap.MapInfo MapInfo
        {
            get
            {
                return mMapInfo;
            }
            set { mMapInfo = value; }
        }

        public uint InstanceType
        {
            get
            {
                if (mInstanceInfo != null)
                {
                    return mInstanceInfo.mWarType;
                }
                return 0;
            }
        }


        public uint InstanceSubType
        {
            get
            {
                if (mInstanceInfo != null)
                {
                    return mInstanceInfo.mWarSubType;
                }
                return 0;
            }
        }

        public bool IsPlayerVSPlayerType
        {
            get
            {
                //if(InstanceType == GameConst.WAR_TYPE_QIECUO || InstanceType == GameConst.WAR_TYPE_PVP || InstanceType == GameConst.WAR_TYPE_GVG)
                //{
                //    return true;
                //}

                return false;
            }
        }

        /// <summary>
        /// 自动战斗设置
        /// </summary>
        public bool IsAutoFighting
        {
            get
            {
                return mIsAutoFighting;
            }
            set
            {
                if (InstanceHelper.IsJumpingOut())
                {
                    return;
                }
                if (mIsAutoFighting == value)
                {
                    return;
                }

                //GameDebug.LogError("Set IsAutoFighting: " + value.ToString());

                mAutoFightBreakingTime = 0.0f;
                mAutoBreakRecoverTime = GameConstHelper.GetFloat("GAME_AUTO_FIGHT_BREAK_RECOVER_TIME");

                bool lastState = mIsAutoFighting;

                mIsAutoFighting = value;
                mAutoFightTime = 0f;

                LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;

                if (mIsAutoFighting == false)
                {
                    if (localPlayer != null)
                    {
                        localPlayer.ActiveAI(false);

                        if (localPlayer.IsWalking())
                        {
                            localPlayer.MoveCtrl.TryWalkAlongStop();
                        }

                        localPlayer.AttackCtrl.ClearCacheSkill();
                    }

                    if (!mIsBreakingAutoFight)
                    {
                        //GameInput.Instance.EnableInput(true);
                    }

                    mAutoFightingGotExp = 0;
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_AUTO_BATTLE_GET_EXP, new CEventObjectArgs(false, 0));

                    IsOnHook = false;
                }
                else
                {
                    if (localPlayer != null)
                    {
                        localPlayer.ActiveAI(true);
                    }

                    mIsBreakingAutoFight = false;
                    //GameInput.Instance.EnableInput(false);

                    // 暂时屏蔽掉
                    //UINotice.Instance.ShowMessage(DBConstText.GetText("AUTO_FIGHT_ENTER"));

                    mAutoFightingGotExp = 0;
                }

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.UPDATE_AUTO_BATTLE_UI, null);
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_AUTO_FIGHT_STATE_CHANGED, null);

                TargetPathManager.Instance.TaskNavigationActive(false);

                // 挂机状态发给服务端
                if (lastState != mIsAutoFighting)
                {
                    C2SNwarClientAuto msg = new C2SNwarClientAuto();
                    msg.state = (uint)((mIsAutoFighting == true) ? 1 : 0);
                    Net.NetClient.GetCrossClient().SendData<C2SNwarClientAuto>(NetMsg.MSG_NWAR_CLIENT_AUTO, msg);
                }
            }
        }

        /// <summary>
        /// 设置挂机
        /// </summary>
        public void SetOnHook(bool isOnHook)
        {
            IsOnHook = isOnHook;
            if (isOnHook == true)
            {
                InstanceManager.Instance.IsAutoFighting = true;
            }
            else
            {
                InstanceManager.Instance.IsAutoFighting = false;
            }
        }

        /// <summary>
        /// 设置自动战斗的怪物目标
        /// </summary>
        public void SetAutoFightingTargetMonsterId(uint targetMonsterId)
        {
            LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;

            if (localPlayer == null)
            {
                return;
            }

            var playerAI = localPlayer.GetAI() as BehaviourAI;

            if (playerAI == null)
            {
                return;
            }

            playerAI.RunningProperty.TargetMonsterId = targetMonsterId;
        }

        /// <summary>
        /// 在副本外面设置自动战斗状态
        /// </summary>
        /// <param name="isAutoFighting">If set to <c>true</c> is auto fighting.</param>
        public void SetIsAutoFightingOutsideInstance(bool isAutoFighting)
        {
            mIsAutoFighting = isAutoFighting;
            mAutoFightTime = 0f;
            mAutoFightingGotExp = 0;
        }

        /// <summary>
        /// 初始化投票信息
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="pollId"></param>
        public void InitPollInfo(uint instanceId, uint pollId)
        {
            PollInfo = new InstancePollInfo();
            PollInfo.InstanceId = instanceId;
            PollInfo.PollId = pollId;
            PollStartTime = Game.Instance.ServerTime;
        }

        public uint GetVote(uint uuid)
        {
            if (PollInfo != null)
            {
                if (PollInfo.VoteList.ContainsKey(uuid) == true)
                {
                    return PollInfo.VoteList[uuid];
                }
            }

            return 0;
        }
	}
}
