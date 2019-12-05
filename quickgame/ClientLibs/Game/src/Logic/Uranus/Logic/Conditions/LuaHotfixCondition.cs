using System;

namespace Uranus.Runtime
{
    public class LuaHotfixCondition : ICondition
    {
        public string ClassName;
        public string Args;

        protected int mId;

        protected override void OnInit()
        {
            var lua_mgr = LuaScriptMgr.Instance;
            if (lua_mgr != null)
                mId = lua_mgr.UranusHotfixInit(true, ClassName, Args);
        }

        public override void OnDestroy()
        {
            var lua_mgr = LuaScriptMgr.Instance;
            if (lua_mgr != null)
                lua_mgr.UranusHotfixFunc(mId, "OnDestroy");
        }

        protected override bool Check()
        {
            var lua_mgr = LuaScriptMgr.Instance;
            if (lua_mgr != null)
            {
                int result = lua_mgr.UranusHotfixFunc(mId, "Check");
                return result == 1;
            }
            return false;
        }
    }
}
