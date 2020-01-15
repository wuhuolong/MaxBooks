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
    public class NetNetClientIListenerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Net.NetClient.IListener), L, translator, 0, 3, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnNetConnect", _m_OnNetConnect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnNetDisconnect", _m_OnNetDisconnect);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnNetDataReply", _m_OnNetDataReply);
			
			
			
			
			XUtils.EndObjectRegister(typeof(Net.NetClient.IListener), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Net.NetClient.IListener), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Net.NetClient.IListener));
			
			
			XUtils.EndClassRegister(typeof(Net.NetClient.IListener), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Net.NetClient.IListener does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnNetConnect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient.IListener __cl_gen_to_be_invoked = (Net.NetClient.IListener)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.NetType netType;translator.Get(L, 2, out netType);
                    
                    __cl_gen_to_be_invoked.OnNetConnect( netType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnNetDisconnect(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient.IListener __cl_gen_to_be_invoked = (Net.NetClient.IListener)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.NetType netType;translator.Get(L, 2, out netType);
                    int e = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.OnNetDisconnect( netType, e );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnNetDataReply(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient.IListener __cl_gen_to_be_invoked = (Net.NetClient.IListener)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    Net.NetType netType;translator.Get(L, 2, out netType);
                    ushort protocol = (ushort)LuaAPI.xlua_tointeger(L, 3);
                    byte[] data = LuaAPI.lua_tobytes(L, 4);
                    
                    __cl_gen_to_be_invoked.OnNetDataReply( netType, protocol, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
