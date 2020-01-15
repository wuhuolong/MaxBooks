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
    public class xcDBEngraveEngraveInfoWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.DBEngrave.EngraveInfo), L, translator, 0, 0, 5, 5);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Id", _g_get_Id);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Type", _g_get_Type);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Lv", _g_get_Lv);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NextEngraveId", _g_get_NextEngraveId);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Attrs", _g_get_Attrs);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Id", _s_set_Id);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Type", _s_set_Type);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Lv", _s_set_Lv);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "NextEngraveId", _s_set_NextEngraveId);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Attrs", _s_set_Attrs);
            
			XUtils.EndObjectRegister(typeof(xc.DBEngrave.EngraveInfo), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.DBEngrave.EngraveInfo), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.DBEngrave.EngraveInfo));
			
			
			XUtils.EndClassRegister(typeof(xc.DBEngrave.EngraveInfo), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.DBEngrave.EngraveInfo __cl_gen_ret = new xc.DBEngrave.EngraveInfo();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.DBEngrave.EngraveInfo constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Id);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Type);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Lv);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NextEngraveId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.NextEngraveId);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Attrs);
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
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Id = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Type(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Type = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Lv(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Lv = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NextEngraveId(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.NextEngraveId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Attrs(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.DBEngrave.EngraveInfo __cl_gen_to_be_invoked = (xc.DBEngrave.EngraveInfo)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Attrs = (System.Collections.Generic.List<System.Collections.Generic.List<uint>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<System.Collections.Generic.List<uint>>));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
