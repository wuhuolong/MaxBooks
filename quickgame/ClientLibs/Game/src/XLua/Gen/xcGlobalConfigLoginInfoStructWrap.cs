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


namespace XLua.CSObjectWrap
{
    using XUtils = XLua.XUtils;
    public class xcGlobalConfigLoginInfoStructWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.GlobalConfig.LoginInfoStruct), L, translator, 0, 0, 11, 11);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerInfo", _g_get_ServerInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AccName", _g_get_AccName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Ticket", _g_get_Ticket);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Status", _g_get_Status);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Level", _g_get_Level);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RId", _g_get_RId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Job", _g_get_Job);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ProviderPassport", _g_get_ProviderPassport);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CreateRoleTime", _g_get_CreateRoleTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RollServer", _g_get_RollServer);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerInfo", _s_set_ServerInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AccName", _s_set_AccName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Ticket", _s_set_Ticket);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Status", _s_set_Status);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Level", _s_set_Level);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RId", _s_set_RId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Job", _s_set_Job);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ProviderPassport", _s_set_ProviderPassport);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CreateRoleTime", _s_set_CreateRoleTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RollServer", _s_set_RollServer);
            
			XUtils.EndObjectRegister(typeof(xc.GlobalConfig.LoginInfoStruct), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.GlobalConfig.LoginInfoStruct), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.GlobalConfig.LoginInfoStruct));
			
			
			XUtils.EndClassRegister(typeof(xc.GlobalConfig.LoginInfoStruct), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.GlobalConfig.LoginInfoStruct __cl_gen_ret = new xc.GlobalConfig.LoginInfoStruct();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.GlobalConfig.LoginInfoStruct constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ServerInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AccName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.AccName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Ticket(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Ticket);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Status(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Status);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Level);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Job(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Job);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ProviderPassport(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ProviderPassport);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CreateRoleTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.CreateRoleTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RollServer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.RollServer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerInfo = (xc.ServerInfo)translator.GetObject(L, 2, typeof(xc.ServerInfo));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AccName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AccName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Ticket(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Ticket = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Status(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Status = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Level(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Level = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RId = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Job(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Job = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ProviderPassport(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ProviderPassport = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CreateRoleTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CreateRoleTime = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RollServer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.GlobalConfig.LoginInfoStruct __cl_gen_to_be_invoked = (xc.GlobalConfig.LoginInfoStruct)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RollServer = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
