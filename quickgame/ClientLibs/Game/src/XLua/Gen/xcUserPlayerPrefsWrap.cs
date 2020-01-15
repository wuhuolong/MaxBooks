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
    public class xcUserPlayerPrefsWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.UserPlayerPrefs), L, translator, 0, 9, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetFloat", _m_GetFloat);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInt", _m_GetInt);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetString", _m_GetString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetFloat", _m_SetFloat);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetInt", _m_SetInt);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetString", _m_SetString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Save", _m_Save);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Contain", _m_Contain);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.UserPlayerPrefs), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.UserPlayerPrefs), L, __CreateInstance, 2, 1, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetInstance", _m_GetInstance_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.UserPlayerPrefs));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.UserPlayerPrefs), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.UserPlayerPrefs __cl_gen_ret = new xc.UserPlayerPrefs();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.UserPlayerPrefs constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstance_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        xc.UserPlayerPrefs __cl_gen_ret = xc.UserPlayerPrefs.GetInstance(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string filename = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Init( filename );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFloat(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    float default_val = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.GetFloat( key, default_val );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    int default_val = LuaAPI.xlua_tointeger(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetInt( key, default_val );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    string default_val = LuaAPI.lua_tostring(L, 3);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.GetString( key, default_val );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFloat(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    float val = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.SetFloat( key, val );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    float val = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.SetInt( key, val );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    string val = LuaAPI.lua_tostring(L, 3);
                    
                    __cl_gen_to_be_invoked.SetString( key, val );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Save(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Save(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Contain(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.UserPlayerPrefs __cl_gen_to_be_invoked = (xc.UserPlayerPrefs)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string key = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Contain( key );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.UserPlayerPrefs.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
