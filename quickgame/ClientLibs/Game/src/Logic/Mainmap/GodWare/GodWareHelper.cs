//-----------------------------------
// File: GodWareHelper.cs
// Desc: 神器工具类
// Author: luozhuocheng
// Date: 2018/10/29 17:38:30
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class GodWareHelper
    {
        /// <summary>
        /// 解封动画是否播放完毕
        /// </summary>
        /// <param name="transferLevel"></param>
        /// <returns></returns>
        public static bool GetHasFinishShowGodWare()
        {
            object[] param = {  };
            System.Type[] returnType = { typeof(bool) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "GodWareManager_GetHasFinishShowGodWare", param, returnType);
            if (objs != null && objs.Length > 0 && objs[0] != null)
            {
                return (bool)objs[0];
            }
            return false;
        }

    }
}
