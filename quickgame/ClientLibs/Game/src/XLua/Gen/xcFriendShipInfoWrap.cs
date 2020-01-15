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
    public class xcFriendShipInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.FriendShipInfo), L, translator, 0, 0, 7, 7);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BuffDes", _g_get_BuffDes);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Min", _g_get_Min);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Max", _g_get_Max);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ShipSprName", _g_get_ShipSprName);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Display", _g_get_Display);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isHave", _g_get_isHave);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BuffDes", _s_set_BuffDes);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Min", _s_set_Min);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Max", _s_set_Max);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ShipSprName", _s_set_ShipSprName);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Display", _s_set_Display);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isHave", _s_set_isHave);
            
			XUtils.EndObjectRegister(typeof(xc.FriendShipInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.FriendShipInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.FriendShipInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.FriendShipInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.FriendShipInfo __cl_gen_ret = new xc.FriendShipInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.FriendShipInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BuffDes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.BuffDes);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Min(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Min);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Max(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Max);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ShipSprName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.ShipSprName);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Display(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Display);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isHave(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isHave);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BuffDes(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BuffDes = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Min(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Min = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Max(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Max = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ShipSprName(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ShipSprName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Display(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Display = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isHave(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.FriendShipInfo __cl_gen_to_be_invoked = (xc.FriendShipInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isHave = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
