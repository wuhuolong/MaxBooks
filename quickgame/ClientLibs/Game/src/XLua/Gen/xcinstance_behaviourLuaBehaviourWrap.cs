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
    public class xcinstance_behaviourLuaBehaviourWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.instance_behaviour.LuaBehaviour), L, translator, 0, 15, 1, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitState", _m_InitState);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Update", _m_Update);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Enter", _m_Enter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Exit", _m_Exit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadedUI", _m_LoadedUI);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnWarReady", _m_OnWarReady);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateEnter_LoadRes", _m_StateEnter_LoadRes);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateUpdate_LoadRes", _m_StateUpdate_LoadRes);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateExit_LoadRes", _m_StateExit_LoadRes);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateEnter_InPlay", _m_StateEnter_InPlay);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateUpdate_InPlay", _m_StateUpdate_InPlay);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateExit_InPlay", _m_StateExit_InPlay);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateEnter_InPause", _m_StateEnter_InPause);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateExit_InPause", _m_StateExit_InPause);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StateEnter_Complete", _m_StateEnter_Complete);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "LuaT", _g_get_LuaT);
            
			
			XUtils.EndObjectRegister(typeof(xc.instance_behaviour.LuaBehaviour), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.instance_behaviour.LuaBehaviour), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.instance_behaviour.LuaBehaviour));
			
			
			XUtils.EndClassRegister(typeof(xc.instance_behaviour.LuaBehaviour), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string lua_script = LuaAPI.lua_tostring(L, 2);
					
					xc.instance_behaviour.LuaBehaviour __cl_gen_ret = new xc.instance_behaviour.LuaBehaviour(lua_script);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.instance_behaviour.LuaBehaviour constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitState(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitState(  );
                    
                    
                    
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
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Enter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object[] param = translator.GetParams<object>(L, 2);
                    
                    __cl_gen_to_be_invoked.Enter( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Exit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadedUI(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LoadedUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnWarReady(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnWarReady(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateEnter_LoadRes(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateEnter_LoadRes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateUpdate_LoadRes(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateUpdate_LoadRes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateExit_LoadRes(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateExit_LoadRes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateEnter_InPlay(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateEnter_InPlay(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateUpdate_InPlay(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateUpdate_InPlay(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateExit_InPlay(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateExit_InPlay(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateEnter_InPause(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateEnter_InPause(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateExit_InPause(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateExit_InPause(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StateEnter_Complete(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StateEnter_Complete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaT(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.instance_behaviour.LuaBehaviour __cl_gen_to_be_invoked = (xc.instance_behaviour.LuaBehaviour)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LuaT);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
