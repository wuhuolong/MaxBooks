using XLua;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace xc
{
    namespace instance_behaviour
    {
        public class LuaBehaviour : Behaviour
        {
            public LuaTable LuaT { get; private set; }
            protected string LuaScriptFileName { get; set; }
            protected Dictionary<string, LuaFunction> LuaMethods { get; set; }

            public LuaBehaviour(string lua_script)
            {
                LuaScriptFileName = lua_script;
                LuaT = LuaScriptMgr.Instance.Require(lua_script) as LuaTable;
                if (!CallLuaFunc<Behaviour>("ctor", (Behaviour)this))
                {
                    GameDebug.LogError(string.Format("({0}) Must Define ctor Function!", lua_script));
                    return;
                }

                LuaMethods = new Dictionary<string, LuaFunction>();
                LuaMethods["InitState"] = LuaT.Get<LuaFunction>("InitState");
                LuaMethods["Update"] = LuaT.Get<LuaFunction>("Update");
                LuaMethods["Enter"] = LuaT.Get<LuaFunction>("Enter");
                LuaMethods["Exit"] = LuaT.Get<LuaFunction>("Exit");
                LuaMethods["LoadedUI"] = LuaT.Get<LuaFunction>("LoadedUI");
                LuaMethods["OnWarReady"] = LuaT.Get<LuaFunction>("OnWarReady");
                LuaMethods["StateEnter_LoadRes"] = LuaT.Get<LuaFunction>("StateEnter_LoadRes");
                LuaMethods["StateUpdate_LoadRes"] = LuaT.Get<LuaFunction>("StateUpdate_LoadRes");
                LuaMethods["StateExit_LoadRes"] = LuaT.Get<LuaFunction>("StateExit_LoadRes");
                LuaMethods["StateEnter_InPlay"] = LuaT.Get<LuaFunction>("StateEnter_InPlay");
                LuaMethods["StateUpdate_InPlay"] = LuaT.Get<LuaFunction>("StateUpdate_InPlay");
                LuaMethods["StateExit_InPlay"] = LuaT.Get<LuaFunction>("StateExit_InPlay");
                LuaMethods["StateEnter_InPause"] = LuaT.Get<LuaFunction>("StateEnter_InPause");
                LuaMethods["StateExit_InPause"] = LuaT.Get<LuaFunction>("StateExit_InPause");
                LuaMethods["StateEnter_Complete"] = LuaT.Get<LuaFunction>("StateEnter_Complete");
            }

            protected bool CallLuaFunc<T>(string func_name, T param)
            {
                if (LuaT != null)
                {
                    Action<T> action = LuaT.Get<Action<T>>(func_name);
                    if (action != null)
                    {
                        action(param);

                        return true;
                    }
                }
                return false;
            }

            protected bool CallLuaFunc(string func_name, params object[] args)
            {
                if (LuaMethods != null)
                {
                    LuaFunction method;
                    if (LuaMethods.TryGetValue(func_name, out method))
                    {
                        if (method != null)
                        {
                            method.Call(args);

                            return true;
                        }
                        else
                        {
                            //GameDebug.LogWarning("Can not find method " + func_name + " with file " + LuaScriptFileName);
                        }
                    }
                }

                return false;
            }

            protected bool CallLuaFunc(string func_name)
            {
                if (LuaMethods != null)
                {
                    LuaFunction method;
                    if (LuaMethods.TryGetValue(func_name, out method))
                    {
                        if (method != null)
                        {
                            method.Call(null, null);
                            return true;
                        }
                        else
                        {
                            //GameDebug.LogWarning("Can not find method " + func_name + " with file " + LuaScriptFileName);
                        }
                    }
                }

                return false;
            }


            public override void InitState() {
                CallLuaFunc("InitState");
            }

            private const string UPDATE_STR = "Update";
            private const string STATEUPDATE_INPLAY_STR = "StateUpdate_InPlay";
            public override void Update() { } //CallLuaFunc(UPDATE_STR);
            public override void Enter(params object[] param) { CallLuaFunc("Enter"); }
            public override void Exit() { CallLuaFunc("Exit"); }
            public override void LoadedUI() { CallLuaFunc("LoadedUI"); }
            public override void OnWarReady() { CallLuaFunc("OnWarReady"); }
            public override void StateEnter_LoadRes() { CallLuaFunc("StateEnter_LoadRes"); }
            public override void StateUpdate_LoadRes() { CallLuaFunc("StateUpdate_LoadRes"); }
            public override void StateExit_LoadRes() { CallLuaFunc("StateExit_LoadRes"); }
            public override void StateEnter_InPlay() { CallLuaFunc("StateEnter_InPlay"); }
            public override void StateUpdate_InPlay() { CallLuaFunc(STATEUPDATE_INPLAY_STR); }
            public override void StateExit_InPlay() { CallLuaFunc("StateExit_InPlay"); }
            public override void StateEnter_InPause() { CallLuaFunc("StateEnter_InPause"); }
            public override void StateExit_InPause() { CallLuaFunc("StateExit_InPause"); }
            public override void StateEnter_Complete() { CallLuaFunc("StateEnter_Complete"); }
        }
    }

    public class CommonLuaInstanceState : CommonInstanceState
    {
        protected LuaTable LuaT { get; set; }
        private LuaTable BaseLuaT;
        private const string BASE_LUA = "Instance.CommonLuaInstanceState";
        public readonly string LuaScript;
        public new string Name { get { return LuaScript; } }

        instance_behaviour.BossBehaviour m_BossBehaviour;
        public CommonLuaInstanceState(string lua_script, uint id, xc.Machine machine)
            : base(id, machine, false)
        {
            this.LuaScript = lua_script;
            this.Prepare();
            this.Init();
        }

        public CommonLuaInstanceState(string lua_script, uint id, xc.Machine machine, xc.Machine.State owner)
            : base(id, machine, owner, false)
        {
            this.LuaScript = lua_script;
            this.Prepare();
            this.Init();
        }

        //@hzb
        protected virtual void Prepare()
        {
            if (LuaScriptMgr.Instance == null)
            {
                return;
            }

            BaseLuaT = LuaScriptMgr.Instance.Require(BASE_LUA) as LuaTable;

            LuaT = LuaScriptMgr.Instance.Require(LuaScript) as LuaTable;
            if (!CallLuaFunc("ctor", (CommonLuaInstanceState)this))
            {
                GameDebug.LogError(string.Format("({0}) Must Define ctor Function!", LuaScript));
            }

            CallLuaFunc("SetInstance", this);
        }

        public override instance_behaviour.Behaviour AddComponent(string component_name)
        {
            instance_behaviour.Behaviour com = null;
            var lua_script = string.Format("Instance.Behaviour.{0}", component_name);
            if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(lua_script))
            {
                com = new instance_behaviour.LuaBehaviour(lua_script);
            }
            else
            {
                var t = System.Type.GetType("xc.instance_behaviour." + component_name);
                if (t != null && t.IsSubclassOf(typeof(instance_behaviour.Behaviour)))
                {
                    com = System.Activator.CreateInstance(t) as instance_behaviour.Behaviour;
                }
            }

            if (com != null)
            {
                com.Instance = this;
                Behaviours[component_name] = com;
                //GameDebug.Log("add component:" + component_name);
            }

            return com;
        }

        protected bool CallLuaFunc<T>(string func_name, T param)
        {
            bool result = false;

            if (BaseLuaT != null)
            {
                Action<T> action = BaseLuaT.Get<Action<T>>(func_name);
                if (action != null)
                {
                    action(param);
                    result = true;
                }
            }
            if (LuaT != null)
            {
                Action<T> action = LuaT.Get<Action<T>>(func_name);
                if (action != null)
                {
                    action(param);
                    result = true;
                }
            }
            return result;
        }

        protected bool CallLuaFunc(string func_name)
        {
            bool result = false;

            if (BaseLuaT != null)
            {
                Action action = BaseLuaT.Get<Action>(func_name);
                if (action != null)
                {
                    action();
                    result = true;
                }
            }
            if (LuaT != null)
            {
                Action action = LuaT.Get<Action>(func_name);
                if (action != null)
                {
                    action();
                    result = true;
                }
            }
            return result;
        }

        protected override void InitBehaviours()
        {
            base.InitBehaviours();

            m_BossBehaviour = AddComponent<instance_behaviour.BossBehaviour>();
            AddComponent<instance_behaviour.DropBehaviour>();
            AddComponent<instance_behaviour.AoiBehaviour>();
            AddComponent<instance_behaviour.PickBossChipBehaviour>();
            AddComponent<instance_behaviour.HostileAttackBehaviour>();
            CallLuaFunc("InitBehaviours");
        }

        protected override void Init()
        {
            base.Init();
            CallLuaFunc("Init");
        }

        protected override void Destroy()
        {
            base.Destroy();
            CallLuaFunc("Destroy");
        }

        private const string UPDATE_STR = "Update";
        public override void Update()
        {
            base.Update();
            //CallLuaFunc(UPDATE_STR);
        }

        public override void Enter(params object[] param)
        {
            base.Enter(param);
            CallLuaFunc("Enter");
        }

        public override void Exit()
        {
            base.Exit();
            CallLuaFunc("Exit");
        }

        protected override void StateEnter_Loadlevel(xc.Machine.State s)
        {
            base.StateEnter_Loadlevel(s);
            CallLuaFunc("StateEnter_Loadlevel");
        }

        protected override void LoadedUI()
        {
            base.LoadedUI();
            CallLuaFunc("LoadedUI");
        }

        protected override void StateExit_Loadlevel(xc.Machine.State s)
        {
            base.StateExit_Loadlevel(s);
            CallLuaFunc("StateExit_Loadlevel");
        }

        protected override bool WaitPlayeInfo()
        {
            if (m_PlayerAttributes == null)
            {
                GameDebug.Log("PlayerAttributes is null");
                return false;
            }

            if (m_PlayerAttributes.Count == 0)
                return false;

            return true;
        }

        protected override void StateExit_LoadRes(xc.Machine.State s)
        {
            base.StateExit_LoadRes(s);
            CallLuaFunc("StateExit_LoadRes");
        }

        protected override void OnWarReady()
        {
            base.OnWarReady();
            CallLuaFunc("OnWarReady");
        }

        protected override void OnPlayerInfo(Net.S2CNwarInitInfo pack)
        {
            if (!CallLuaFunc("OnPlayerInfo", pack))
                base.OnPlayerInfo(pack);
        }

        public override void StateEnter_InPlay(xc.Machine.State s)
        {
            base.StateEnter_InPlay(s);
            CallLuaFunc("StateEnter_InPlay");
        }

        private const string UPDATE_INPLAY = "StateUpdate_InPlay";

        protected override void StateUpdate_InPlay(xc.Machine.State s)
        {
            base.StateUpdate_InPlay(s);
            //CallLuaFunc(UPDATE_INPLAY);
        }

        protected override void StateExit_InPlay(xc.Machine.State s)
        {
            base.StateExit_InPlay(s);
            CallLuaFunc("StateExit_InPlay");
        }

        protected override void StateEnter_InPause(xc.Machine.State s)
        {
            base.StateEnter_InPause(s);
            CallLuaFunc("StateEnter_InPause");
        }

        protected override void StateUpdate_InPause(xc.Machine.State s)
        {
            base.StateUpdate_InPause(s);
            CallLuaFunc("StateUpdate_InPause");
        }

        protected override void StateExit_InPause(xc.Machine.State s)
        {
            base.StateExit_InPause(s);
            CallLuaFunc("StateExit_InPause");
        }

        protected override void StateEnter_Complete(xc.Machine.State s)
        {
            base.StateEnter_Complete(s);
            CallLuaFunc("StateEnter_Complete");
        }

        protected override void StateUpdate_Complete(xc.Machine.State s)
        {
            base.StateUpdate_Complete(s);
            CallLuaFunc("StateUpdate_Complete");
        }

        protected override void StateExit_Complete(xc.Machine.State s)
        {
            base.StateExit_Complete(s);
            CallLuaFunc("StateExit_Complete");
        }

        public instance_behaviour.BossBehaviour DataBossBehaviour
        {
            get { return m_BossBehaviour; }
        }
    }
}
