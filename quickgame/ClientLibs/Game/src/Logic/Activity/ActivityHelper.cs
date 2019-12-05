//-----------------------------------
// File: ActivityHelper.cs
// Desc: 活动的辅助类，用于从lua中获取数据
// Author: raorui
// Date: 2018.5.23
//-----------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class ActivityHelper
    {
        /// <summary>
        /// 获取指定id的日常活动对象，并调用对象中的函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="func_name"></param>
        /// <returns></returns>
        public static T GetActivityInfo<T>(uint id, string func_name)
        {
            T ret = default(T);
            if (LuaScriptMgr.Instance != null)
            {
                object[] param = { id, func_name };
                System.Type[] returnType = { typeof(T) };
                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "ActivityHelper_GetActivityInfo", param, returnType);
                if (objs != null && objs.Length > 0)
                {
                    ret = (T)(objs[0]);
                }
            }
            return ret;
        }

        /// <summary>
        /// 指定系统id对应的活动是否已经开启(包括限时活动和运营活动)
        /// </summary>
        /// <param name="sys_id"></param>
        /// <returns></returns>
        public static bool IsActivityOpen(uint sys_id, bool showTips = false)
        {
            bool is_open = false;
            if (LuaScriptMgr.Instance != null)
            {
                object[] param = { sys_id, showTips };
                System.Type[] return_type = { typeof(bool) };
                object[] ret_objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "ActivityManager_IsActivityOpen", param, return_type);
                if (ret_objs != null && ret_objs.Length > 0)
                {
                    is_open = (bool)(ret_objs[0]);
                }
            }
            return is_open;
        }
    }
}
