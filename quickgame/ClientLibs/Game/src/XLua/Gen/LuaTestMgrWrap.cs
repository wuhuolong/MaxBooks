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
    public class LuaTestMgrWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(LuaTestMgr), L, translator, 0, 3, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RunTestScript", _m_RunTestScript);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Testu64", _m_Testu64);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TestPbc", _m_TestPbc);
			
			
			
			
			XUtils.EndObjectRegister(typeof(LuaTestMgr), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(LuaTestMgr), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(LuaTestMgr));
			
			
			XUtils.EndClassRegister(typeof(LuaTestMgr), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					LuaTestMgr __cl_gen_ret = new LuaTestMgr();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LuaTestMgr constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunTestScript(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LuaTestMgr __cl_gen_to_be_invoked = (LuaTestMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.RunTestScript(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Testu64(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LuaTestMgr __cl_gen_to_be_invoked = (LuaTestMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong a = LuaAPI.lua_touint64(L, 2);
                    ulong b = LuaAPI.lua_touint64(L, 3);
                    
                    __cl_gen_to_be_invoked.Testu64( a, b );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TestPbc(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            LuaTestMgr __cl_gen_to_be_invoked = (LuaTestMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    byte[] data = LuaAPI.lua_tobytes(L, 2);
                    
                    __cl_gen_to_be_invoked.TestPbc( data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
