using UnityEngine;
using System.Collections;
using xc;
using XLua;
using System;

namespace xc.ui.ugui
{
	//************************************
	// lua 的behaviour 目的方便在lua 下实现各种组件
	//************************************
	public class UILuaBehaviour : IUIBehaviour
	{
        string mLuaScript;
        LuaTable mLuaTable;

        public UILuaBehaviour(UIBaseWindow win, string lua_script)
		{
			Window = win;

            mLuaScript = lua_script;
            mLuaTable = LuaScriptMgr.Instance.Require(lua_script) as LuaTable;
            if (!CallLuaFunc<IUIBehaviour>("ctor", (IUIBehaviour)this))
            {
                GameDebug.LogError(string.Format("({0}) Must Define ctor Function!", lua_script));
            }
        }

        ~UILuaBehaviour()
        {
            
        }

        public override void InitBehaviour()
		{
            CallLuaFunc("InitBehaviour");
            base.InitBehaviour();
        }
		public override void DestroyBehaviour()
		{
            CallLuaFunc("DestroyBehaviour");
            base.DestroyBehaviour();

            /*if (mLuaTable != null)
            {
                mLuaTable.Dispose();
                mLuaTable = null;
            }
            LuaScriptMgr.Instance.RemoveRequire(mLuaScript);*/
        }

        public void ResetBehaviour(params object[] param)
        {
            CallLuaFunc("ResetBehaviour", param);
        }

        public override void EnableBehaviour(bool isEnable)
        {
            base.EnableBehaviour(isEnable);
            CallLuaFunc("EnableBehaviour", isEnable);
        }

        bool CallLuaFunc<T>(string func_name, T param)
        {
            if (mLuaTable != null)
            {
                Action<T> action = mLuaTable.Get<Action<T>>(func_name);
                if (action != null)
                {
                    action(param);
                    return true;
                }
            }
            return false;
        }

        public bool CallLuaFunc(string func_name)
        {
            if (mLuaTable != null)
            {
                Action action = mLuaTable.Get<Action>(func_name);
                if (action != null)
                {
                    action();
                    return true;
                }
            }
            return false;
        }
    }
}


