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
    public class xcDBMallTypeDBMallTypeItemWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBMallType.DBMallTypeItem), L, translator, 0, 0, 4, 4);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Name", _g_get_Name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "TapBkg", _g_get_TapBkg);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BottomDesc", _g_get_BottomDesc);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Name", _s_set_Name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "TapBkg", _s_set_TapBkg);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BottomDesc", _s_set_BottomDesc);
            
			XUtils.EndObjectRegister(typeof(xc.DBMallType.DBMallTypeItem), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBMallType.DBMallTypeItem), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBMallType.DBMallTypeItem));
			
			
			XUtils.EndClassRegister(typeof(xc.DBMallType.DBMallTypeItem), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBMallType.DBMallTypeItem __cl_gen_ret = new xc.DBMallType.DBMallTypeItem();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBMallType.DBMallTypeItem constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
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
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TapBkg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.TapBkg);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BottomDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.BottomDesc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
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
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TapBkg(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.TapBkg = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BottomDesc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBMallType.DBMallTypeItem __cl_gen_to_be_invoked = (xc.DBMallType.DBMallTypeItem)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BottomDesc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
