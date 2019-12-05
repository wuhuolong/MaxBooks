using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XLua;
using xc;
namespace xc.ui.ugui
{
    public class UILuaBaseWindow: UIBaseWindow
    {
        public static bool IsLuaScriptExist(string wnd_name)
        {
            if (LuaScriptMgr.Instance == null)
                return false;
            string lua_script = "";
            string path = UIHelper.GetLuaWindowPath(wnd_name);
            if (path.CompareTo(string.Empty) == 0)
                lua_script = string.Format("newUI.{0}", wnd_name);
            else
                lua_script = string.Format("newUI.{0}.{1}", path, wnd_name);
            return LuaScriptMgr.Instance.IsLuaScriptExist(lua_script);
        }

        private string mLuaScript;
        private LuaTable mLuaTable;

        public UILuaBaseWindow(string wnd_name, string lua_script)
             : base()
        {
            var prefab_name = wnd_name;
            mWndName = prefab_name;
            mPrefabName = mWndName;
            IsLoadDone = false;
            base.LoadDB();
            mLuaScript = lua_script;
            mLuaTable = LuaScriptMgr.Instance.Require(lua_script) as LuaTable;
            if (!CallLuaFunc<UIBaseWindow>("ctor", (UIBaseWindow)this))
            {
                GameDebug.LogError(string.Format("({0}) Must Define ctor Function!", lua_script));
            }
        }

        //~UILuaBaseWindow()
        //{
        //    //CallLuaFunc("dtor");
        //}

        protected bool CallLuaFunc<T>(string func_name, T param)
        {
            // LuaEnv是否为空
            if (LuaScriptMgr.Instance.Lua == null)
            {
                return false;
            }

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

        protected bool CallLuaFunc(string func_name)
        {
            // LuaEnv是否为空
            if (LuaScriptMgr.Instance.Lua == null)
            {
                return false;
            }

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

        /*内部调用 Start*/
        protected override void InitUI()
        {
            base.InitUI();
            CallLuaFunc("InitUI");
        }

        protected override void ResetUI()
        {
            base.ResetUI();
            CallLuaFunc("ResetUI");
        }

        protected override void UnInitUI()
        {
            base.UnInitUI();

            CallLuaFunc("UnInitUI");

            /*if (mLuaTable != null)
            {
                mLuaTable.Dispose();
                mLuaTable = null;
            }
            LuaScriptMgr.Instance.RemoveRequire(mLuaScript);*/
        }

        protected override void HideUI()
        {
            base.HideUI();
            CallLuaFunc("HideUI");
        }

        /*内部调用 End*/

        /*外部调用 Start*/
        public override void Show()
        {
            base.Show();
            //CallLuaFunc("Show");
        }

        public override void Close()
        {
            base.Close();
            CallLuaFunc("Close");
        }

        public override void Destroy()
        {
            base.Destroy();
            CallLuaFunc("Destroy");
        }
        /*外部调用 End*/

    }
}
