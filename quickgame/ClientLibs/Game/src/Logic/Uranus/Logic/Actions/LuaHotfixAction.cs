using System;

namespace Uranus.Runtime
{
    public class LuaHotfixAction : IAction
    {
        public string ClassName;
        public string Args;

        protected int mId;

        protected override void OnInit()
        {
            var lua_mgr = LuaScriptMgr.Instance;
            if (lua_mgr != null)
                mId = lua_mgr.UranusHotfixInit(false, ClassName, Args);
        }

        public override void OnDestroy()
        {
            var lua_mgr = LuaScriptMgr.Instance;
            if (lua_mgr != null)
                lua_mgr.UranusHotfixFunc(mId, "OnDestroy");
        }
        public override NodeStatus Execute()
        {
            var lua_mgr = LuaScriptMgr.Instance;
            if (lua_mgr != null)
            {
                int result = lua_mgr.UranusHotfixFunc(mId, "Execute");
                return (NodeStatus)result;
            }
            return NodeStatus.FAIL;
        }
    }
}
