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
    public class DBOSManagerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(DBOSManager), L, translator, 0, 4, 2, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "getBridge", _m_getBridge);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "getSpeechManager", _m_getSpeechManager);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitBuglySDK", _m_InitBuglySDK);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetUserId", _m_SetUserId);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Res1Version", _g_get_Res1Version);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Res2Version", _g_get_Res2Version);
            
			
			XUtils.EndObjectRegister(typeof(DBOSManager), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(DBOSManager), L, __CreateInstance, 7, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "getDBOSManager", _m_getDBOSManager_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "getOSBridge", _m_getOSBridge_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "uploadRecordFile", _m_uploadRecordFile_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "downLoadRecordFile", _m_downLoadRecordFile_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "writeCSDmpToFile", _m_writeCSDmpToFile_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "writeLuaDmpToFile", _m_writeLuaDmpToFile_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(DBOSManager));
			
			
			XUtils.EndClassRegister(typeof(DBOSManager), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DBOSManager __cl_gen_ret = new DBOSManager();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DBOSManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getDBOSManager_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        DBOSManager __cl_gen_ret = DBOSManager.getDBOSManager(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getBridge(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DBOSManager __cl_gen_to_be_invoked = (DBOSManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        IBridge __cl_gen_ret = __cl_gen_to_be_invoked.getBridge(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getSpeechManager(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DBOSManager __cl_gen_to_be_invoked = (DBOSManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        ISpeechManager __cl_gen_ret = __cl_gen_to_be_invoked.getSpeechManager(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getOSBridge_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        IBridge __cl_gen_ret = DBOSManager.getOSBridge(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_uploadRecordFile_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string filePath = LuaAPI.lua_tostring(L, 1);
                    
                        int __cl_gen_ret = DBOSManager.uploadRecordFile( filePath );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_downLoadRecordFile_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string filePath = LuaAPI.lua_tostring(L, 1);
                    
                        int __cl_gen_ret = DBOSManager.downLoadRecordFile( filePath );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_writeCSDmpToFile_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    DBOSManager.writeCSDmpToFile( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_writeLuaDmpToFile_xlua_st_(RealStatePtr L)
        {
            
            
            
            try {
                
                {
                    string text = LuaAPI.lua_tostring(L, 1);
                    
                    DBOSManager.writeLuaDmpToFile( text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitBuglySDK(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DBOSManager __cl_gen_to_be_invoked = (DBOSManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitBuglySDK(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUserId(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            DBOSManager __cl_gen_to_be_invoked = (DBOSManager)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string user_id = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.SetUserId( user_id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Res1Version(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBOSManager __cl_gen_to_be_invoked = (DBOSManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Res1Version);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Res2Version(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                DBOSManager __cl_gen_to_be_invoked = (DBOSManager)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.Res2Version);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
