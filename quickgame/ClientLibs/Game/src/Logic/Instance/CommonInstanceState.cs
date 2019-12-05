using Net;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc.protocol;
using xc.ui;
using xc.ui.ugui;

namespace xc
{
    namespace instance_behaviour
    {
        public abstract class Behaviour
        {
            public CommonInstanceState Instance { get; set; }

            public T AddComponent<T>() where T : instance_behaviour.Behaviour { return Instance.AddComponent<T>(); }
            public instance_behaviour.Behaviour AddComponent(string component_name) { return Instance.AddComponent(component_name); }
            public T GetComponent<T>() where T : instance_behaviour.Behaviour { return Instance.GetComponent<T>(); }
            public Behaviour GetComponent(string name) { return Instance.GetComponent(name); }

            public virtual void InitState() { }
            public virtual void Update() { }
            public virtual void Enter(params object[] param) { }
            public virtual void Exit() { }
            public virtual void LoadedUI() { }
            public virtual void OnWarReady() { }
            public virtual void StateEnter_LoadRes() { }
            public virtual void StateUpdate_LoadRes() { }
            public virtual void StateExit_LoadRes() { }
            public virtual void StateEnter_InPlay() { }
            public virtual void StateUpdate_InPlay() { }
            public virtual void StateExit_InPlay() { }
            public virtual void StateEnter_InPause() { }
            public virtual void StateExit_InPause() { }
            public virtual void StateEnter_Complete() { }
        }
    }

    [Flags]
    public enum InstanceFlag
    {
        None = 0x0,
        IsInstance = 0x1, // 是否在副本内
        CanRide = 0x2, // 是否可以上下坐骑
        CanSwitchTarget = 0x4, // 是否可以切换优先攻击目标
        TotemRestrain = 0x8, // 
        EnterHiLvBoss = 0x10, // 是否可以进入巅峰boss
        EnterResGain = 0x20, // 是否可以通过资源获取界面跳转
        CanChangeSkill = 0x40, // 是否可以通过资源获取界面跳转
    }

    [Flags]
    public enum InstanceActorNameFlag
    {
        None = 0x0,
        Society = 0x1, // 显示公会名
        Totem = 0x2, // 显示图腾
        SvrId = 0x4, // 显示服务器id
    }

    public class CEventActionArgs : CEventBaseArgs
    {
        public CEventActionArgs(System.Action action) : base(action) { }
    }

    //[LuaExport(LuaExportOption.SELECTED)]
    public abstract class CommonInstanceState : xc.Machine.State
    {
        protected Dictionary<string, instance_behaviour.Behaviour> Behaviours = new Dictionary<string, instance_behaviour.Behaviour>();
        protected xc.Machine.State mInitChildState;  // 默认子状态
        protected bool mLoadResInited = false; // 在LoadRes状态更新中，设置了玩家信息后，mLoadResInited设置为true
        protected Dictionary<uint, xc.Machine.State> mStates = new Dictionary<uint, xc.Machine.State>();

        /// <summary>
        /// 玩家的属性(只发送本地玩家或者竞技场其他玩家的信息)
        /// </summary>
        protected Dictionary<UnitID, ActorAttributeData> m_PlayerAttributes;

        /// <summary>
        /// 副本的标记flag
        /// </summary>
        public InstanceFlag Flag { get; protected set; }

        public InstanceActorNameFlag NameFlag { get; protected set; }

        /// <summary>
        /// 本地玩家的出生点信息
        /// </summary>
        public uint LocalPlayerInitPos { get; protected set; }

        public CommonInstanceState(uint id, xc.Machine machine, bool withInit=true)
            : base(id, machine)
        {
            if(withInit)
                Init();
        }

        public CommonInstanceState(uint id, xc.Machine machine, xc.Machine.State owner, bool withInit = true)
            : base(id, machine, owner)
        {
            if (withInit)
                Init();
        }

        ~CommonInstanceState()
        {
            this.Destroy();
        }

        #region Componet

        public T AddComponent<T>() where T : instance_behaviour.Behaviour
        {
            return AddComponent(UtilType.GetTypeName(typeof(T))) as T;
        }

        //[LuaExport]
        public virtual instance_behaviour.Behaviour AddComponent(string component_name)
        {
            instance_behaviour.Behaviour com = null;
            var t = System.Type.GetType("xc.instance_behaviour." + component_name);
            if (t != null && t.IsSubclassOf(typeof(instance_behaviour.Behaviour)))
            {
                com = System.Activator.CreateInstance(t) as instance_behaviour.Behaviour;
            }
            else
            {
                var lua_script = string.Format("Instance.Behaviour.{0}", component_name);
                if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(lua_script))
                {
                    com = new instance_behaviour.LuaBehaviour(lua_script);
                }
            }

            if (com != null)
            {
                com.Instance = this;
                Behaviours[component_name] = com;
            }

            return com;
        }

        public T GetComponent<T>() where T : instance_behaviour.Behaviour
        {
            return GetComponent(UtilType.GetTypeName(typeof(T))) as T;
        }

        //[LuaExport]
        public instance_behaviour.Behaviour GetComponent(string name)
        {
            instance_behaviour.Behaviour ret;
            if (Behaviours.TryGetValue(name, out ret))
                return ret;

            return null;
        }

        #endregion

        #region actor name

        public virtual string LocalPlayerSocietyName(LocalPlayer actor)
        {
            return string.Empty;
        }

        public virtual string LocalPlayerName(LocalPlayer actor)
        {
            return string.Format("<color=#0AE800>{0}</color>", actor.UserName);
        }

        public virtual string LocalPlayerWholeName(LocalPlayer actor)
        {
            var name = string.Empty;
            if (FlagOperate.HasFlag((int)NameFlag, (int)InstanceActorNameFlag.Society))
            {
                name += LocalPlayerSocietyName(actor);
            }

            if (FlagOperate.HasFlag((int)NameFlag, (int)InstanceActorNameFlag.SvrId))
            {
                name += PlayerSvrName(actor);
            }

            // name += LocalPlayerName(actor);

            name = actor.UserName;

            if (FlagOperate.HasFlag((int)NameFlag, (int)InstanceActorNameFlag.Totem))
            {
               // name += LocalPlayerTotemName(actor);
            }

            uint nameColor = PKModeManagerEx.Instance.LocalPlayerNameColor;
            ActorHelper.GetPKColorName(nameColor, ref name, true);

            return name;
        }

        public virtual string PlayerSvrName(Actor actor)
        {
            return string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_39"), actor.SvrId);
        }

        public virtual string PlayerName(Actor actor)
        {
            if (!IsFriend(actor)) //敌人
                return string.Format("<color=#ff880a>{0}</color>", actor.UserName);
            else //队友
                return string.Format("<color=#00ff00>{0}</color>", actor.UserName);
        }

        public virtual string PlayerWholeName(Actor actor)
        {
            var name = string.Empty;
            if (FlagOperate.HasFlag((int)NameFlag, (int)InstanceActorNameFlag.SvrId))
            {
                name += PlayerSvrName(actor);
            }

           // name += PlayerName(actor);

            if (FlagOperate.HasFlag((int)NameFlag, (int)InstanceActorNameFlag.Totem))
            {
                //name += PlayerTotemName(actor);
            }

            string replaceName = DBInstanceTypeControl.Instance.GetReplaceOtherPlayerName(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            if (replaceName == null || replaceName == "")
            {
                name = actor.UserName;
                ActorHelper.GetPKColorName(actor.NameColor, ref name, false);
            }
            else
            {
                name = replaceName;
                name = string.Format("{0}", name);
            }
            

            return name;
        }

        public virtual string NpcWholeName(NpcPlayer actor)
        {
            string funcName = "";
            if (actor.Define != null)
            {
                funcName = actor.Define.ConstTitle;
            }
            string name = string.Empty;
            if (!string.IsNullOrEmpty(funcName))
            {
                name = string.Format("<color=#68e0fa>{0}</color>\n<color=#fbbd65>{1}</color>", funcName, actor.Name);
            }
            else
            {
                name = string.Format("<color=#fbbd65>{0}</color>", actor.Name);
            }

            // 护送NPC的名字要加上"XXX的"
            if (actor.Define != null && actor.IsEscortNPC == true)
            {
                if (actor.ParentActor != null)
                {
                    name = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_40"), actor.ParentActor.UserName, name);
                }
            }

            return name;
        }

        public virtual string MonsterWholeName(Monster actor)
        {
            string name = actor.Name;
            //string colorText = actor.GetMonsterColorStr();
            string colorText = "f5f97a";

            name = "<color=#" + colorText + ">" + name + string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_41"), actor.Level) + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_42");

            return name;
        }

        public virtual string ActorNameText(Actor actor)
        {
            if (actor is LocalPlayer)// 本地玩家
            {
                return LocalPlayerWholeName(actor as LocalPlayer);
            }
            else if (actor is NpcPlayer) // NPC
            {
                return NpcWholeName(actor as NpcPlayer);
            }
            else if (actor is Monster)
            {
                return MonsterWholeName(actor as Monster);
            }
            else
            {
                return PlayerWholeName(actor);
            }
        }

        public virtual bool IsMonsterFriend(LocalPlayer local, Monster actor)
        {
            //my summon monster
            var monster = actor as Monster;
            if (monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_PLAYER && monster.ParentActor != null)
            {
                if (monster.ParentActor == local || monster.ParentActor.Camp == local.Camp)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual bool IsRemotePlayerFriend(LocalPlayer local, RemotePlayer actor)
        {
            return false;
        }

        public virtual bool IsFriend(Actor actor)
        {
            var local = Game.Instance.GetLocalPlayer() as LocalPlayer;
            if (local == null)
                return false;

            if (actor == local)
            {
                //self
                return true;
            }
            else if (actor is Monster)
            {
                return IsMonsterFriend(local, actor as Monster);
            }
            else if (actor is RemotePlayer)
            {
                return IsRemotePlayerFriend(local, actor as RemotePlayer);
            }

            return false;
        }

        #endregion

        protected virtual void InitBehaviours()
        {
        }

        public xc.Machine.State CreateState(uint id)
        {
            var state = new xc.Machine.State(id, mMachine, this);
            mStates[id] = state;

            return state;
        }

        public xc.Machine.State GetState(uint id)
        {
            xc.Machine.State ret;
            if (mStates.TryGetValue(id, out ret))
                return ret;

            return null;
        }

        protected virtual void Init()
        {
            InitBehaviours();

            // 创建子状态
            var stateLoadLevel = CreateState((uint)GameState.GS_LOADING_LEVEL);
            var stateLoadRes = CreateState((uint)GameState.GS_LOADING_RES);
            var stateInPlay = CreateState((uint)GameState.GS_IN_PLAY);
            var stateInPause = CreateState((uint)GameState.GS_IN_PAUSE);
            var stateComplete = CreateState((uint)GameState.GS_INSTANCE_COMPLETED);

            stateLoadLevel.SetEnterFunction(StateEnter_Loadlevel);
            stateLoadLevel.SetUpdateFunction(StateUpdate_Loadlevel);
            stateLoadLevel.SetExitFunction(StateExit_Loadlevel);

            stateLoadRes.SetEnterFunction(StateEnter_LoadRes);
            stateLoadRes.SetUpdateFunction(StateUpdate_LoadRes);
            stateLoadRes.SetExitFunction(StateExit_LoadRes);

            stateInPlay.SetEnterFunction(StateEnter_InPlay);
            stateInPlay.SetUpdateFunction(StateUpdate_InPlay);
            stateInPlay.SetExitFunction(StateExit_InPlay);

            stateInPause.SetEnterFunction(StateEnter_InPause);
            stateInPause.SetUpdateFunction(StateUpdate_InPause);
            stateInPause.SetExitFunction(StateExit_InPause);

            stateComplete.SetEnterFunction(StateEnter_Complete);
            stateComplete.SetUpdateFunction(StateUpdate_Complete);
            stateComplete.SetExitFunction(StateExit_Complete);

            // 状态图 -- begin
            stateLoadLevel.AddTransition((uint)GameEvent.GE_LEVEL_LOADED, stateLoadRes);

            stateLoadRes.AddTransition((uint)GameEvent.GE_INSTANCE_START, stateInPlay);
            stateLoadRes.AddTransition((uint)GameEvent.GE_DISCONNECT, stateLoadLevel);

            stateInPlay.AddTransition((uint)GameEvent.GE_INSTANCE_PAUSE, stateInPause);
            stateInPlay.AddTransition((uint)GameEvent.GE_INSTANCE_COMPLETED, stateComplete);
            stateInPlay.AddTransition((uint)GameEvent.GE_DISCONNECT, stateLoadLevel);

            stateInPause.AddTransition((uint)GameEvent.GE_DISCONNECT, stateLoadLevel);
            stateInPause.AddTransition((uint)GameEvent.GE_INSTANCE_RESUME, stateInPlay);

            stateComplete.AddTransition((uint)GameEvent.GE_INSTANCE_PAUSE, stateInPause);
            stateComplete.AddTransition((uint)GameEvent.GE_DISCONNECT, stateLoadLevel);
            stateComplete.AddTransition((uint)GameEvent.GE_INSTANCE_RESUME, stateInPlay);
            // 状态图 -- end

            foreach (var behaviour in Behaviours)
                behaviour.Value.InitState();

            // 设置默认子状态
            mInitChildState = stateLoadLevel;
            this.SetChild(mInitChildState);
        }

        protected virtual void Destroy()
        {

        }

        public override void Update()
        {
            base.Update();

            // 处理AOI的缓存信息
            if (Game.Instance.CameraControl != null)
                ActorManager.Instance.UpdateUnitCache(false);

            using (var iter = Behaviours.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    iter.Current.Value.Update();
                }
            }

            //foreach (var behaviour in Behaviours)
            //    behaviour.Value.Update();

            ActorModelCullManager.GetInstance().Update();
        }

        public override void Enter(params object[] param)
        {
            if (mInitChildState != null)
                this.SetChild(mInitChildState);
            else
                GameDebug.LogError("LuaInstanceState's Child State is null.");

            m_PlayerAttributes = new Dictionary<UnitID, ActorAttributeData>();

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_INIT_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_ALL_READY, HandleServerData);

            //ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_STATUS_TRANSFER_AUTO_ENDED, OnPlayerTransferAutoEnded);

            // 重设Input的引用计数
            GameInput.Instance.ResetInputRef();
            UnityEngine.EventSystems.EventSystem eventSys = xc.ui.ugui.UIManager.Instance.MainCtrl.EventSystemCom;
            if (eventSys != null)
            {
                eventSys.enabled = GameInput.Instance.GetEnableInput();
            }

            // 等map load之后才能移动
            GameInput.Instance.EnableInput(false);

            uint instanceID = SceneHelp.Instance.CurSceneID;

            // 配置表信息
            var dbInstance = DBManager.GetInstance().GetDB<DBInstance>();
            var dbMap = DBManager.GetInstance().GetDB<DBMap>();

            InstanceManager.GetInstance().InstanceInfo = dbInstance.GetInstanceInfo(instanceID);
            InstanceManager.GetInstance().MapInfo = dbMap.GetMapInfo(SceneHelp.GetFirstMapIdByInstanceId(instanceID));

            foreach (var behaviour in Behaviours)
                behaviour.Value.Enter(param);

            ActorModelCullManager.GetInstance().Reset();

            InstanceManager.Instance.ResetInstanceData();

            base.Enter(param);
        }

        public override void Exit()
        {
            base.Exit();

            ActorModelCullManager.GetInstance().Reset();

            foreach (var behaviour in Behaviours)
                behaviour.Value.Exit();

            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_INIT_INFO, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_ALL_READY, HandleServerData);

            //ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_STATUS_TRANSFER_AUTO_ENDED, OnPlayerTransferAutoEnded);

            InstanceManager.GetInstance().InstanceInfo = null; 
            InstanceManager.GetInstance().MapInfo = null;

            Actor player = Game.GetInstance().GetLocalPlayer();
            if (player == null)
                return;

            player.gameObject.transform.parent = null;
            //player.enabled = true;
        }

        bool mLevelLoaded = false;
        bool mUIStartLoaded = false;
        protected virtual void StateEnter_Loadlevel(xc.Machine.State s)
        {
            GameDebug.Log("CommonInstanceState StateEnter_Loadlevel");

            mUIStartLoaded = false;
            mLevelLoaded = false;
        }

        protected virtual void StateUpdate_Loadlevel(xc.Machine.State s)
        {
            //GameDebug.Log("LuaInstanceState StateUpdate_Loadlevel");

            // Navmesh文件是否加载完毕
            if (xc.Dungeon.LevelManager.Instance.IsLoadingNavmeshFile == true)
            {
                return;
            }

            if (SceneHelp.Instance.WillSwitchScene == true && Game.GetInstance().GetLoadAsyncOp() == null)
                return;

            if (SceneHelp.Instance.WillSwitchScene == false || (Game.GetInstance().GetLoadAsyncOp() != null && Game.GetInstance().GetLoadAsyncOp().isDone))
            {
                if (!mLevelLoaded)
                {
                    mLevelLoaded = true;
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_FINISH_LOAD_LEVEL, null);
                }

                var mainmap_window = UIManager.Instance.GetWindow("UIMainmapWindow");

                if (mUIStartLoaded == false)
                {
                    if (mainmap_window == null)
                    {
                        UIManager.Instance.ShowSysWindow("UIMainmapWindow");
                    }
                    xc.ui.ugui.UIManager.Instance.ShowWindow("UICommonTipsWindow");
                    mUIStartLoaded = true;
                }

                if (mainmap_window != null)
                {
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_FINISH_SWITCHSCENE, null);

                    LoadedUI();
                    mMachine.React((uint)xc.GameEvent.GE_LEVEL_LOADED);
                }
            }
        }

        protected virtual void LoadedUI()
        {
            using (var enumerator = Behaviours.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var cur = enumerator.Current;
                    cur.Value.LoadedUI();
                }
            }
        }

        protected virtual void StateExit_Loadlevel(xc.Machine.State s)
        {

        }

        protected virtual void StateEnter_LoadRes(xc.Machine.State s)
        {
            mLoadResInited = false;

            //GameInput.Instance.EnableInput(false);

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SWITCHINSTANCE, null);

            foreach (var behaviour in Behaviours)
                behaviour.Value.StateEnter_LoadRes();
        }

        protected abstract bool WaitPlayeInfo();

        protected virtual void StateUpdate_LoadRes(xc.Machine.State s)
        {
            if (!WaitPlayeInfo())
                return;

            foreach (var behaviour in Behaviours)
                behaviour.Value.StateUpdate_LoadRes();

            if (mLoadResInited)
                return;

            mLoadResInited = true;
        }

        protected virtual void StateExit_LoadRes(xc.Machine.State s)
        {
            //GameInput.Instance.EnableInput(true);

            foreach (var behaviour in Behaviours)
                behaviour.Value.StateExit_LoadRes();
        }

        protected virtual void OnWarReady()
        {
            foreach (var behaviour in Behaviours)
                behaviour.Value.OnWarReady();

            //GameInput.Instance.EnableInput(true);

            mMachine.React((uint)xc.GameEvent.GE_INSTANCE_START);
        }

        protected virtual ActorAttributeData CreateActorAttrData(S2CNwarInitInfo pkg)
        {
            var player_attr = new ActorAttributeData();
            player_attr.UnitId.type = (byte)EUnitType.UNITTYPE_PLAYER;
            player_attr.UnitId.obj_idx = pkg.brief.uuid;

            if (pkg.brief.uuid == Game.GetInstance().LocalPlayerID.obj_idx)
            {
                player_attr.Name = Game.GetInstance().LocalPlayerName;
                PKModeManagerEx.Instance.LocalPlayerNameColor = pkg.brief.name_color;
            }
            else
                player_attr.Name = System.Text.Encoding.UTF8.GetString(pkg.brief.name);

            player_attr.Camp = pkg.side;
            //player_attr.MapPos = new Vector2(pkg.init_pos.px, pkg.init_pos.py);

            // 记录下本地玩家的出生点信息
            if (pkg.brief.uuid == Game.Instance.LocalPlayerID.obj_idx)
                LocalPlayerInitPos = 0;
            return player_attr;
        }

        protected virtual UnitCacheInfo CreateUnitCacheData(S2CNwarInitInfo player_info)
        {
            var born_pos = RoleHelp.GetPositionInScene(ActorHelper.RoleIdToTypeId(player_info.brief.rid), player_info.init_pos.px * GlobalConst.UnitScale, player_info.init_pos.py * GlobalConst.UnitScale);
            var init_data = ActorHelper.CreateUnitCacheInfo(player_info.brief, born_pos);

            // 读取出生点朝向
            List<Neptune.Tag> tags = Neptune.DataHelper.GetTagListByType(Neptune.DataManager.Instance.Data, "born_pos");
            if (tags.Count > 0)
            {
                init_data.Rotation = tags[0].Rotation;
            }
            if (LocalPlayerManager.Instance.BornRotation.Equals(Quaternion.identity) == false)
            {
                init_data.Rotation = LocalPlayerManager.Instance.BornRotation;
                LocalPlayerManager.Instance.BornRotation = Quaternion.identity;
            }

            return init_data;
        }

        protected virtual void OnPlayerInfo(S2CNwarInitInfo pack)
        {
            //GameDebug.LogPack(pack);
            var player_attr = CreateActorAttrData(pack);
            m_PlayerAttributes[player_attr.UnitId] = player_attr;

            ActorManager.Instance.PushUnitCacheData(CreateUnitCacheData(pack));
        }

        public virtual void StateEnter_InPlay(xc.Machine.State s)
        {
            foreach (var behaviour in Behaviours)
                behaviour.Value.StateEnter_InPlay();
        }

        protected virtual void StateUpdate_InPlay(xc.Machine.State s)
        {
            using (var iter = Behaviours.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    iter.Current.Value.StateUpdate_InPlay();
                }
            }

                //foreach (var behaviour in Behaviours)
                //    behaviour.Value.StateUpdate_InPlay();

            // 野外才处理post event消息
            if (SceneHelp.Instance.IsInWildInstance() == true)
            {
                ClientEventMgr.GetInstance().UpdateMsgPump();
            }

            HookSettingManager.Instance.Update();
        }

        protected virtual void StateExit_InPlay(xc.Machine.State s)
        {
            foreach (var behaviour in Behaviours)
                behaviour.Value.StateExit_InPlay();
        }

        protected virtual void StateEnter_InPause(xc.Machine.State s)
        {
            foreach (var behaviour in Behaviours)
                behaviour.Value.StateEnter_InPause();
        }

        protected virtual void StateUpdate_InPause(xc.Machine.State s)
        {
        }

        protected virtual void StateExit_InPause(xc.Machine.State s)
        {
            foreach (var behaviour in Behaviours)
                behaviour.Value.StateExit_InPause();
        }

        protected virtual void StateEnter_Complete(xc.Machine.State s)
        {
            GameInput.Instance.EnableInput(false);

            foreach (var behaviour in Behaviours)
                behaviour.Value.StateEnter_Complete();
        }

        protected virtual void StateUpdate_Complete(xc.Machine.State s)
        {

        }

        protected virtual void StateExit_Complete(xc.Machine.State s)
        {

        }

        protected virtual void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_NWAR_INIT_INFO:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarInitInfo>(data);
                        OnPlayerInfo(pack);

                        //GameDebug.LogError(">>>MSG_NWAR_INIT_INFO pos: " + pack.init_pos.px + ", " + pack.init_pos.py);

                        GameDebug.Log(">>>MSG_NWAR_INIT_INFO");
                    }
                    return;
                case NetMsg.MSG_NWAR_ALL_READY: // 副本开始
                    {
                        xc.LocalPlayerManager.Instance.m_canShowBuffTips = true; //不允许显示buff提示
                        xc.LocalPlayerManager.Instance.m_isFirstLoadingScene = false;

                        // 服务端可能会发两次ready过来，第一次是副本准备倒计时结束，第二次是本地的资源加载好，只有在本地资源加载好才是真正的ready
                        if (IsInState(GameState.GS_LOADING_RES) == true)
                        {
                            OnWarReady();

                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_INSTANCE_START, null);
                        }

                        GameDebug.Log(">>>MSG_NWAR_ALL_READY");
                    }
                    return;
            }
        }

        public virtual void ReactInstanceEvent(uint game_event)
        {
            mMachine.React(game_event);
        }

        public void CompleteInstance()
        {
            mMachine.React((uint)GameEvent.GE_INSTANCE_COMPLETED);
        }

        public void PauseInstance()
        {
            mMachine.React((uint)GameEvent.GE_INSTANCE_PAUSE);
        }

        public void ResumeInstance()
        {
            mMachine.React((uint)GameEvent.GE_INSTANCE_RESUME);
        }

        /// <summary>
        /// 当前是否在指定的副本状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool IsInState(uint state)
        {
            xc.Machine.State curState = mMachine.GetCurState();
            if (curState != null)
            {
                xc.Machine.State childState = curState.GetChild();
                if (childState != null)
                {
                    return childState.GetID() == state;
                }
            }

            return false;
        }
    }
}
