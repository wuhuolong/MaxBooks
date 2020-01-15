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
    public class NetNetClientMutiPacketHelpWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(Net.NetClient.MutiPacketHelp), L, translator, 0, 3, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Push", _m_Push);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Send", _m_Send);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			
			
			
			
			XUtils.EndObjectRegister(typeof(Net.NetClient.MutiPacketHelp), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(Net.NetClient.MutiPacketHelp), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(Net.NetClient.MutiPacketHelp));
			
			
			XUtils.EndClassRegister(typeof(Net.NetClient.MutiPacketHelp), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Net.NetClient>(L, 2))
				{
					Net.NetClient p = (Net.NetClient)translator.GetObject(L, 2, typeof(Net.NetClient));
					
					Net.NetClient.MutiPacketHelp __cl_gen_ret = new Net.NetClient.MutiPacketHelp(p);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Net.NetClient.MutiPacketHelp constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Push(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient.MutiPacketHelp __cl_gen_to_be_invoked = (Net.NetClient.MutiPacketHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    byte[] data = LuaAPI.lua_tobytes(L, 2);
                    
                    __cl_gen_to_be_invoked.Push( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Send(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient.MutiPacketHelp __cl_gen_to_be_invoked = (Net.NetClient.MutiPacketHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Send(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Net.NetClient.MutiPacketHelp __cl_gen_to_be_invoked = (Net.NetClient.MutiPacketHelp)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
