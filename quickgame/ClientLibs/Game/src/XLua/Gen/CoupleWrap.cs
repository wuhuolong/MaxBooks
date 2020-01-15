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
    public class CoupleWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Couple), L, translator, 0, 0, 4, 4);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ParameterA", _g_get_ParameterA);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ParameterB", _g_get_ParameterB);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RawA", _g_get_RawA);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RawB", _g_get_RawB);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ParameterA", _s_set_ParameterA);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ParameterB", _s_set_ParameterB);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RawA", _s_set_RawA);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RawB", _s_set_RawB);
            
			XUtils.EndObjectRegister(typeof(Couple), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Couple), L, __CreateInstance, 3, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Make", _m_Make_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "ParseCoupleMapFromDB", _m_ParseCoupleMapFromDB_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Couple));
			
			
			XUtils.EndClassRegister(typeof(Couple), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Couple __cl_gen_ret = new Couple();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Couple constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Make_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    
                        Couple __cl_gen_ret = Couple.Make( raw );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string rawA = LuaAPI.lua_tostring(L, 1);
                    string rawB = LuaAPI.lua_tostring(L, 2);
                    
                        Couple __cl_gen_ret = Couple.Make( rawA, rawB );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Couple.Make!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseCoupleMapFromDB_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.Dictionary<uint, Couple>>(L, 2)) 
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    System.Collections.Generic.Dictionary<uint, Couple> result = (System.Collections.Generic.Dictionary<uint, Couple>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint, Couple>));
                    
                    Couple.ParseCoupleMapFromDB( raw, ref result );
                    translator.Push(L, result);
                        
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Collections.Generic.List<Couple>>(L, 2)) 
                {
                    string raw = LuaAPI.lua_tostring(L, 1);
                    System.Collections.Generic.List<Couple> result = (System.Collections.Generic.List<Couple>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Couple>));
                    
                    Couple.ParseCoupleMapFromDB( raw, ref result );
                    translator.Push(L, result);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Couple.ParseCoupleMapFromDB!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ParameterA(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ParameterA);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ParameterB(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.ParameterB);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RawA(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RawA);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RawB(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.RawB);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ParameterA(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ParameterA = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ParameterB(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ParameterB = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RawA(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RawA = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RawB(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Couple __cl_gen_to_be_invoked = (Couple)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RawB = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
