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
    public class xcMachineWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.Machine), L, translator, 0, 7, 2, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Destroy", _m_Destroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reset", _m_Reset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetCurState", _m_SetCurState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetCurState", _m_GetCurState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "React", _m_React);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CanReact", _m_CanReact);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "StateList", _g_get_StateList);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "bIsDebug", _g_get_bIsDebug);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "bIsDebug", _s_set_bIsDebug);
            
			XUtils.EndObjectRegister(typeof(xc.Machine), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.Machine), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.Machine));
			
			
			XUtils.EndClassRegister(typeof(xc.Machine), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.Machine __cl_gen_ret = new xc.Machine();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.Machine constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Destroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.Machine.State s = (xc.Machine.State)translator.GetObject(L, 2, typeof(xc.Machine.State));
                    
                    __cl_gen_to_be_invoked.SetCurState( s );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.Machine.State __cl_gen_ret = __cl_gen_to_be_invoked.GetCurState(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_React(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint fsmEvent = LuaAPI.xlua_touint(L, 2);
                    object[] param = translator.GetParams<object>(L, 3);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.React( fsmEvent, param );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanReact(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint fsmEvent = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CanReact( fsmEvent );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StateList(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.StateList);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bIsDebug(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.bIsDebug);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bIsDebug(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.Machine __cl_gen_to_be_invoked = (xc.Machine)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.bIsDebug = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
