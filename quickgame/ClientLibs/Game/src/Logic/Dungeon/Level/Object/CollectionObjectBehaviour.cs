using UnityEngine;
using System.Collections.Generic;
using Uranus.Runtime;
using Net;
using xc.protocol;

namespace xc.Dungeon
{
    [wxb.Hotfix]
    public class CollectionObjectBehaviour : MonoBehaviour
    {
        bool mIsDestroy = false;

        bool mIsTouching = false;
        public bool IsTouching { get { return mIsTouching; } }

        bool mIsCollecting = false;
        public bool IsCollecting { get { return mIsCollecting; } }
        bool mIsClickedTouch = false;
        public bool IsClickedTouch { set { mIsClickedTouch = value; } }

        uint mId = 0;
        uint mCollectTime = 3;

        uint mExcelId = 0;
        string mHeadName = string.Empty; 
        /// <summary>
        /// 交互半径的平方
        /// </summary>
        float mSqrRadius = 9f;
        public float SqrRadius { get { return mSqrRadius; } }

        bool mDisappearAfterCollected = false;
        bool mCanBeInterrupt = false;

        string mClass;
        public string Class { get { return mClass; } }

        string mLayerName;

        enum ECollectMode
        {
            Click = 1,
            Touch = 2,
            InteractButton = 3,
        }
        ECollectMode mCollectMode = ECollectMode.Click;

        /// <summary>
        /// 交互按钮文本
        /// </summary>
        string mInteractButtonText = string.Empty;

        /// <summary>
        /// 交互按钮图片
        /// </summary>
        string mInteractButtonPic = string.Empty;

        void Awake()
        {
        }

        void Start()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CLICKINTEROBJECTLAYER, OnClicked);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.INTERACT_BUTTON_CLICK_CALLBACK, OnInteractButtonClickCallback);

            var localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                //localPlayer.SubscribeActorEvent(Actor.ActorEvent.EXITIDLE, OnLocalPlayerBeInterrupted);
                localPlayer.SubscribeActorEvent(Actor.ActorEvent.BEATTACK, OnLocalPlayerBeInterrupted);
                localPlayer.SubscribeActorEvent(Actor.ActorEvent.DEAD, OnLocalPlayerBeInterrupted);
            }

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BAR_READ_FINISH, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BAR_READ_FAIL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BAR_DISAPPEAR, HandleServerData);

            mIsDestroy = false;
        }

        void OnDestroy()
        {
            if (mCollectMode == ECollectMode.Click)
                CollectionObjectManager.Instance.HideCollectionBar(mId);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CLICKINTEROBJECTLAYER, OnClicked);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.INTERACT_BUTTON_CLICK_CALLBACK, OnInteractButtonClickCallback);

            var localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                //localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.EXITIDLE, OnLocalPlayerBeInterrupted);
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.BEATTACK, OnLocalPlayerBeInterrupted);
                localPlayer.UnsubscribeActorEvent(Actor.ActorEvent.DEAD, OnLocalPlayerBeInterrupted);
            }

            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_BAR_READ_FINISH, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_BAR_READ_FAIL, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_BAR_DISAPPEAR, HandleServerData);

            mIsDestroy = true;
        }

        void Update()
        {
            if (!CollectionObjectManager.Instance.Enable)
            {
                return;
            }
            if (mIsTouching == true)
            {
                if (IsLocalPlayerCloseEnoughToExit == false)
                {
                    OnTouchExit();
                }
            }
            else
            {
                if (IsLocalPlayerCloseEnoughToEnter == true)
                {
                    OnTouchEnter();
                }
            }
        }

        public void Init(uint id, uint excelId)
        {
            mId = id;
            mExcelId = excelId;
            List<Dictionary<string, string>> dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_collection", "id", excelId.ToString());
            if (dbs != null && dbs.Count > 0)
            {
                uint.TryParse(dbs[0]["collect_time"], out mCollectTime);
                float radius = 0f;
                float.TryParse(dbs[0]["radius"], out radius);
                radius = radius * GlobalConst.UnitScale;
                mSqrRadius = radius * radius;
                if (dbs[0]["disappear_after_collected"] == "1")
                {
                    mDisappearAfterCollected = true;
                }
                else
                {
                    mDisappearAfterCollected = false;
                }
                if (dbs[0]["can_be_interrupt"] == "1")
                {
                    mCanBeInterrupt = true;
                }
                else
                {
                    mCanBeInterrupt = false;
                }
                mClass = dbs[0]["class"];
                uint collectModeUint = 0;
                uint.TryParse(dbs[0]["collect_mode"], out collectModeUint);
                mCollectMode = (ECollectMode)collectModeUint;

                mInteractButtonText = dbs[0]["interact_button_text"];
                mInteractButtonPic = dbs[0]["interact_pic"];
                mLayerName = dbs[0]["layer_name"];
                mHeadName = dbs[0]["head_name"];
            }
            else
            {
                GameDebug.LogError("Init collection object error, can not find db info by id " + excelId);
            }
        }

        bool IsLocalPlayerCloseEnoughToEnter
        {
            get
            {
                var player = Game.GetInstance().GetLocalPlayer();
                if (player == null)
                    return false;

                return (player.transform.position - transform.position).sqrMagnitude < mSqrRadius;
            }
        }

        bool IsLocalPlayerCloseEnoughToExit
        {
            get
            {
                var player = Game.GetInstance().GetLocalPlayer();
                if (player == null)
                    return false;

                return (player.transform.position - transform.position).sqrMagnitude < mSqrRadius;
            }
        }

        public void OnTouchEnter()
        {
            mIsTouching = true;

            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            bool startRet = TryToStart();
            //if (startRet == true && localPlayer != null && localPlayer.IsAttacking() == false && mIsCollecting)// 在释放技能时不能停止
            //{
            //    localPlayer.Stop();
            //    localPlayer.MoveCtrl.TryWalkAlongStop();

            //    localPlayer.BeginInteraction("action_1");
            //}
        }

        public void OnTouchExit()
        {

            mIsTouching = false;
            mIsClickedTouch = false;

            if (mCollectMode == ECollectMode.InteractButton)
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_INTERACT_BUTTON, new CEventEventParamArgs(false, "", mInteractButtonPic, mId));
            }
            else if (mCollectMode == ECollectMode.Click)
            {
                //隐藏操作按钮
                CollectionObjectManager.Instance.HideCollectionBar(mId);
            }
        }
        public void StartInteract(bool isShowPauseAutoFightingTips = false)
        {
            // 帮派篝火要判断背包是否已满
            if (mClass == "guild_league_fire")
            {
                if (ItemManager.Instance.BagIsFull(1) == true)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("BAG_IS_FULL"));
                    return;
                }
            }

            // 跨服boss大宝箱
            if (mClass == "span_boss_big_box" || mClass == "span_boss_little_box")
            {
                if (CheckCanGetServerBossBox(true) == false)
                {
                    return;
                }
            }


            Actor localPlayer = Game.GetInstance().GetLocalPlayer();

            if (localPlayer == null)
            {
                return;
            }
            if (mCollectMode == ECollectMode.Click)
                CollectionObjectManager.Instance.HideCollectionBar(mId);
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_INTERACT_BUTTON, new CEventEventParamArgs(false, "", mInteractButtonPic, mId));

            if (mCollectTime > 0)
            {
                localPlayer.Stop();
                localPlayer.MoveCtrl.TryWalkAlongStop();
                TargetPathManager.Instance.TaskNavigationActive(false);
                InstanceManager.Instance.PauseAutoFighting(isShowPauseAutoFightingTips);
                localPlayer.BeginInteraction("action_1");
                //localPlayer.AttackCtrl.Attack(1414);

                InterruptCollect(false);
                CommonSliderHelper.Start((int)mCollectTime, "", mInteractButtonPic, SendInterruptCollect, SendFinishCollect, false);
                mIsCollecting = true;

                SendStartInteract();
            }
            else
            {
                SendFinishCollect();
            }
        }

        public void InterruptCollect(bool executeCallback)
        {
            if (mIsCollecting == true)
            {
                CommonSliderHelper.Interrupt(executeCallback);
                mIsCollecting = false;

                Actor localPlayer = Game.GetInstance().GetLocalPlayer();
                if (localPlayer != null)
                {
                    localPlayer.Stop();
                    localPlayer.MoveCtrl.TryWalkAlongStop();
                }
            }
        }

        public void SendStartInteract()
        {
            C2SNwarBarReadStart msg = new C2SNwarBarReadStart();
            msg.bar_id = mId;
            NetClient.CrossClient.SendData<C2SNwarBarReadStart>(NetMsg.MSG_NWAR_BAR_READ_START, msg);
        }

        public void SendInterruptCollect()
        {
            C2SNwarBarReadAbort msg = new C2SNwarBarReadAbort();
            msg.bar_id = mId;
            NetClient.CrossClient.SendData<C2SNwarBarReadAbort>(NetMsg.MSG_NWAR_BAR_READ_ABORT, msg);

            mIsCollecting = false;
        }

        public void SendFinishCollect()
        {
            C2SNwarBarReadFinish msg = new C2SNwarBarReadFinish();
            msg.bar_id = mId;
            NetClient.CrossClient.SendData<C2SNwarBarReadFinish>(NetMsg.MSG_NWAR_BAR_READ_FINISH, msg);

            mIsCollecting = false;

            if (mDisappearAfterCollected == true)
            {
                CollectionObjectManager.Instance.RemoveCollectionObject((int)mId);

                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_COLLECTION_OBJECTS_COUNT_CHANGED, null);
            }

            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                localPlayer.Stop();
                localPlayer.MoveCtrl.TryWalkAlongStop();
            }
        }

        public void OnClicked(CEventBaseArgs args)
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer == null || localPlayer.IsDead() == true)
            {
                return;
            }

            if (args == null || args.arg == null)
            {
                return;
            }

            GameObject clickedObject = args.arg as GameObject;
            // 实际点击的是该组件的孩子
            if (clickedObject == null || clickedObject.transform == null || clickedObject.transform.parent == null || clickedObject.transform.parent.gameObject == null || clickedObject.transform.parent.gameObject != this.gameObject)
            {
                return;
            }

            // 帮派篝火要判断是否还有烤肉次数和背包是否已满
            if (mClass == "guild_league_fire")
            {
                if (GuildBonfireCheckCanMeat(true) == false)
                {
                    return;
                }

                if (ItemManager.Instance.BagIsFull(1) == true)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("BAG_IS_FULL"));
                    return;
                }
            }

            // 跨服boss大宝箱
            if (mClass == "span_boss_big_box" || mClass == "span_boss_little_box")
            {
                if (CheckCanGetServerBossBox(true) == false)
                {
                    return;
                }
            }

            mIsClickedTouch = true;

            if (!IsLocalPlayerCloseEnoughToEnter)
            {
                bool result = false;
                Vector3 pos = transform.position;
                pos = InstanceHelper.ClampInWalkableRange(pos, pos, out result);
                localPlayer.MoveCtrl.TryWalkToAlong(pos);
            }
            else
            {
                OnTouchEnter();
            }
        }

        public void OnInteractButtonClickCallback(CEventBaseArgs args)
        {
            if (args == null || args.arg == null)
            {
                return;
            }

            uint id = uint.Parse(args.arg.ToString());
            if (id == mId)
            {
                StartInteract();
            }
        }

        public void OnLocalPlayerBeInterrupted(CEventBaseArgs evt)
        {
            if (mCanBeInterrupt == true)
            {
                // 玩家离开idle状态，则中断读条
                InterruptCollect(false);
            }
        }

        public bool TryToStart()
        {
            // 帮派篝火要判断是否还有烤肉次数
            if (mClass == "guild_league_fire")
            {
                if (GuildBonfireCheckCanMeat(false) == false)
                {
                    return false;
                }
            }

            if (mIsTouching == false)
            {
                return false;
            }
            if (mIsCollecting == true)
            {
                return false;
            }
            if (mCollectMode == ECollectMode.Click)
            {
                if (mIsClickedTouch == true)
                {
                    StartInteract();
                }
            }
            else if (mCollectMode == ECollectMode.Touch)
            {
                StartInteract();
            }
            else if (mCollectMode == ECollectMode.InteractButton)
            {
                if (mIsClickedTouch == false)
                {
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.SHOW_INTERACT_BUTTON, new CEventEventParamArgs(true, mInteractButtonText, mInteractButtonPic, mId));
                }
                else
                {
                    StartInteract();
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_NWAR_BAR_READ_FINISH:
                    {
                        S2CNwarBarReadFinish pack = S2CPackBase.DeserializePack<S2CNwarBarReadFinish>(data);

                        if (pack.bar_id == mId)
                        {
                            InterruptCollect(false);
                        }

                        break;
                    }
                case NetMsg.MSG_NWAR_BAR_READ_FAIL:
                    {
                        S2CNwarBarReadFail pack = S2CPackBase.DeserializePack<S2CNwarBarReadFail>(data);

                        if (pack.bar_id == mId)
                        {
                            InterruptCollect(false);
                        }

                        break;
                    }
                case NetMsg.MSG_NWAR_BAR_DISAPPEAR:
                    {
                        S2CNwarBarDisappear pack = S2CPackBase.DeserializePack<S2CNwarBarDisappear>(data);

                        HandleBarDisappear(pack.bar_id);

                        break;
                    }
                default:
                    break;
            }
        }

        public void HandleBarDisappear(uint barId)
        {
            if (barId == mId)
            {
                if (mIsCollecting == true)
                {
                    if (mClass == "guild_league_stone")
                    {
                        UINotice.Instance.ShowMessage(DBConstText.GetText("GUILD_LEAGUE_MINE_IS_COLLECTED"));
                    }

                    if (mClass == "span_boss_big_box" || mClass == "span_boss_little_box")
                    {
                        UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("SERVER_BOSS_COLLECT_FAIL"), mHeadName));
                    }
                }

                InterruptCollect(false);
            }
        }

        public void OnResLoaded()
        {
            string layerName = mLayerName;
            if (string.IsNullOrEmpty(layerName) == true)
            {
                layerName = "InterObject";
            }
            int parentLayer = LayerMask.NameToLayer("InterObject");
            int layer = LayerMask.NameToLayer(layerName);
            Transform trans = this.transform;
            for (int i = 0; i < trans.childCount; ++i)
            {
                Transform child = trans.GetChild(i);
                child.gameObject.layer = parentLayer;
                UGUITools.SetChildLayer(child, layer);
            }

            Collider collider = gameObject.GetComponentInChildren<Collider>();
            if (collider != null)
            {
                collider.isTrigger = true;
            }
        }

        /// <summary>
        /// 判断帮派篝火能否烤肉
        /// </summary>
        public bool GuildBonfireCheckCanMeat(bool showTips)
        {
            uint num = 0;
            object[] param = { };
            System.Type[] returnType = { typeof(uint) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "GuildBonfireDataManager_GetMeatNum", param, returnType);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    num = (uint)objs[0];
                }
            }

            uint maxNum = GameConstHelper.GetUint("GAME_GUILD_FIRE_MAX_MEAT_NUM");

            bool ret = false;
            if (num < maxNum)
            {
                ret = true;
            }
            else
            {
                if (showTips == true)
                {
                    UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("GUILD_FIRE_GET_MEAT_REACH_MAX"), maxNum));
                }
            }
            return ret;
        }

        public bool CheckCanGetServerBossBox(bool showTips)
        {
            bool ret = true;
            if (LuaScriptMgr.Instance != null)
            {
                object[] param = { mExcelId, showTips };
                System.Type[] return_type = { typeof(bool) };
                object[] ret_objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "ServerBossManager_CheckCanGetBox", param, return_type);
                if (ret_objs != null && ret_objs.Length > 0)
                {
                    ret = (bool)(ret_objs[0]);
                }
            }
            return ret;
        }
    }
}
