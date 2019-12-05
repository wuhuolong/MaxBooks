#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;
using System;
using Mono.Data.Sqlite;
using System.Data;

namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcLuaUtilityWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);

            XUtils.BeginObjectRegister(typeof(xc.LuaUtility), L, translator, 0, 1, 0, 0);
            XUtils.EndObjectRegister(typeof(xc.LuaUtility), L, translator, null, null, null, null, null);

            XUtils.BeginClassRegister(typeof(xc.LuaUtility), L, __CreateInstance, 1, 0, 0);
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.LuaUtility));
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseArrayUintUint", ParseArrayUintUint);
            XUtils.EndClassRegister(typeof(xc.LuaUtility), L, translator); 
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try
            {
                if (LuaAPI.lua_gettop(L) == 1)
                {

                    xc.LuaUtility __cl_gen_ret = new xc.LuaUtility();
                    translator.Push(L, __cl_gen_ret);
                    return 1;
                }

            }
            catch (System.Exception __gen_e)
            {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return LuaAPI.luaL_error(L, "invalid arguments to xc.LuaUtility constructor!");
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int ParseArrayUintUint(RealStatePtr L)
        {
            try
            {
                string str = LuaAPI.lua_tostring(L, 1);
                LuaAPI.lua_newtable(L);

                var list = xc.DBTextResource.ParseArrayUintUint(str);
                int index = 1;
                for (int i =0; i < list.Count; ++i)
                {
                    LuaAPI.lua_newtable(L);

                    var list2 = list[i];
                    int index2 = 1;
                    for (int j = 0; j < list2.Count; ++j)
                    {
                        LuaAPI.lua_pushnumber(L, Convert.ToDouble(list2[j]));
                        LuaAPI.xlua_rawseti(L, -2, index2);
                        index2++;
                    }

                    LuaAPI.xlua_rawseti(L, -2, index);
                    index++;
                }
            }
            catch (System.Exception e)
            {
                return LuaAPI.luaL_error(L, "c# exception:" + e);
            }
            return 1;
        }
    }
}
