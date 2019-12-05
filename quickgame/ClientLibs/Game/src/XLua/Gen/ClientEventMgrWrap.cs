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
    public class ClientEventMgrWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(ClientEventMgr), L, translator, 0, 5, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SubscribeClientEvent", _m_SubscribeClientEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnsubscribeClientEvent", _m_UnsubscribeClientEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FireEvent", _m_FireEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PostEvent", _m_PostEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateMsgPump", _m_UpdateMsgPump);
			
			
			
			
			XUtils.EndObjectRegister(typeof(ClientEventMgr), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(ClientEventMgr), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(ClientEventMgr));
			
			
			XUtils.EndClassRegister(typeof(ClientEventMgr), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					ClientEventMgr __cl_gen_ret = new ClientEventMgr();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ClientEventMgr constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SubscribeClientEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ClientEventMgr __cl_gen_to_be_invoked = (ClientEventMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int eventID = LuaAPI.xlua_tointeger(L, 2);
                    ClientEventMgr.ClientEventFunc func = translator.GetDelegate<ClientEventMgr.ClientEventFunc>(L, 3);
                    
                    __cl_gen_to_be_invoked.SubscribeClientEvent( eventID, func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnsubscribeClientEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ClientEventMgr __cl_gen_to_be_invoked = (ClientEventMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int eventID = LuaAPI.xlua_tointeger(L, 2);
                    ClientEventMgr.ClientEventFunc func = translator.GetDelegate<ClientEventMgr.ClientEventFunc>(L, 3);
                    
                    __cl_gen_to_be_invoked.UnsubscribeClientEvent( eventID, func );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FireEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ClientEventMgr __cl_gen_to_be_invoked = (ClientEventMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int eventID = LuaAPI.xlua_tointeger(L, 2);
                    CEventBaseArgs arg = (CEventBaseArgs)translator.GetObject(L, 3, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.FireEvent( eventID, arg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PostEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ClientEventMgr __cl_gen_to_be_invoked = (ClientEventMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int eventID = LuaAPI.xlua_tointeger(L, 2);
                    CEventBaseArgs arg = (CEventBaseArgs)translator.GetObject(L, 3, typeof(CEventBaseArgs));
                    
                    __cl_gen_to_be_invoked.PostEvent( eventID, arg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateMsgPump(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ClientEventMgr __cl_gen_to_be_invoked = (ClientEventMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateMsgPump(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
