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
    public class NetNetClientWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Net.NetClient), L, translator, 0, 5, 3, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Start", _m_Start);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Stop", _m_Stop);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendData", _m_SendData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendLuaData", _m_SendLuaData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "NetState", _g_get_NetState);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Encrypt", _g_get_Encrypt);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "mListener", _g_get_mListener);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Encrypt", _s_set_Encrypt);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "mListener", _s_set_mListener);
            
			XUtils.EndObjectRegister(typeof(Net.NetClient), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Net.NetClient), L, __CreateInstance, 3, 4, 1);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetBaseClient", _m_GetBaseClient_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetCrossClient", _m_GetCrossClient_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Net.NetClient));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "CrossToggle", _g_get_CrossToggle);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "BaseClient", _g_get_BaseClient);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "CrossClient", _g_get_CrossClient);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "HasCrossClient", _g_get_HasCrossClient);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "CrossToggle", _s_set_CrossToggle);
            
			XUtils.EndClassRegister(typeof(Net.NetClient), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Net.NetClient does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaseClient_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        Net.NetClient __cl_gen_ret = Net.NetClient.GetBaseClient(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCrossClient_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    
                        Net.NetClient __cl_gen_ret = Net.NetClient.GetCrossClient(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string ip = LuaAPI.lua_tostring(L, 2);
                    int port = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.Start( ip, port );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Stop(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Stop(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    object c2sPack = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.SendData( protocol, c2sPack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendLuaData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                    __cl_gen_to_be_invoked.SendLuaData( protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NetState(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
                translator.PushNetNetClientENetState(L, __cl_gen_to_be_invoked.NetState);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Encrypt(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Encrypt);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CrossToggle(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, Net.NetClient.CrossToggle);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseClient(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, Net.NetClient.BaseClient);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CrossClient(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, Net.NetClient.CrossClient);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HasCrossClient(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, Net.NetClient.HasCrossClient);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mListener(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.mListener);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Encrypt(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Encrypt = (Net.DBEncrypt)translator.GetObject(L, 2, typeof(Net.DBEncrypt));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CrossToggle(RealStatePtr L)
        {
            
            try {
			    Net.NetClient.CrossToggle = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mListener(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Net.NetClient __cl_gen_to_be_invoked = (Net.NetClient)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.mListener = (Net.NetClient.IListener)translator.GetObject(L, 2, typeof(Net.NetClient.IListener));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
