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
    public class GrayServerManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(GrayServerManager), L, translator, 0, 5, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetLoginServer", _m_GetLoginServer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RecordLoginServer", _m_RecordLoginServer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsSupportGrayServer", _m_IsSupportGrayServer);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetUpdateURL", _m_SetUpdateURL);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CheckUpdate", _m_CheckUpdate);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "UpdateInfo", _g_get_UpdateInfo);
            
			
			XUtils.EndObjectRegister(typeof(GrayServerManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(GrayServerManager), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(GrayServerManager));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(GrayServerManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					GrayServerManager __cl_gen_ret = new GrayServerManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to GrayServerManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLoginServer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            GrayServerManager __cl_gen_to_be_invoked = (GrayServerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetLoginServer(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecordLoginServer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            GrayServerManager __cl_gen_to_be_invoked = (GrayServerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int serverId = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RecordLoginServer( serverId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSupportGrayServer(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            GrayServerManager __cl_gen_to_be_invoked = (GrayServerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsSupportGrayServer(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUpdateURL(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            GrayServerManager __cl_gen_to_be_invoked = (GrayServerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetUpdateURL( url );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckUpdate(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            GrayServerManager __cl_gen_to_be_invoked = (GrayServerManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int serverID = LuaAPI.xlua_tointeger(L, 2);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.CheckUpdate( serverID );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
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
			    translator.Push(L, GrayServerManager.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UpdateInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                GrayServerManager __cl_gen_to_be_invoked = (GrayServerManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.UpdateInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
