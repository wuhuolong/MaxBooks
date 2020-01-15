using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class VipHelper
    {
        /// <summary>
        /// 获取生效VIP等级
        /// </summary>
        /// <returns></returns>
        public static uint GetVipValidLevel()
        {
            object[] param = { };
            System.Type[] return_type = { typeof(uint) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "VipManager_GetValidLevel", param, return_type);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    uint a = (uint)objs[0];
                    return a;
                }
            }

            return 0;
        }

        /// <summary>
        /// 是否自动执行帮派任务
        /// </summary>
        /// <returns></returns>
        public static bool GetIsAutoRunGuildTask()
        {
            object[] param = { };
            System.Type[] return_type = { typeof(bool) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "VipManager_GetIsAutoRunGuildTask", param, return_type);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    bool a = (bool)objs[0];
                    return a;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否免费使用小飞鞋
        /// </summary>
        /// <returns></returns>
        public static bool GetIsFlyFree()
        {
            object[] param = { };
            System.Type[] return_type = { typeof(bool) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "VipManager_GetIsFlyFree", param, return_type);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    bool a = (bool)objs[0];
                    return a;
                }
            }

            return false;
        }

        public static string GetVipIconName( uint vipLv )
        {
            return "Chatting@Vip_" + vipLv;
        }
    }
}
