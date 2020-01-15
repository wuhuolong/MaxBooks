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
    public class xcuiuguiUIMainMapAnimationBehaviourWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.UIMainMapAnimationBehaviour), L, translator, 0, 7, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitBehaviour", _m_InitBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateBehaviour", _m_UpdateBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyBehaviour", _m_DestroyBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnableBehaviour", _m_EnableBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SendAnimationEvent", _m_SendAnimationEvent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "PlayAnimation", _m_PlayAnimation);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPlayAnimationEnd", _m_OnPlayAnimationEnd);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.UIMainMapAnimationBehaviour), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.UIMainMapAnimationBehaviour), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.UIMainMapAnimationBehaviour));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.UIMainMapAnimationBehaviour), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_ret = new xc.ui.ugui.UIMainMapAnimationBehaviour();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.UIMainMapAnimationBehaviour constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.UIMainMapAnimationBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.InitBehaviour(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.UIMainMapAnimationBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.UpdateBehaviour(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.UIMainMapAnimationBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.DestroyBehaviour(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnableBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.UIMainMapAnimationBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool is_enable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.EnableBehaviour( is_enable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendAnimationEvent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.UIMainMapAnimationBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string part = LuaAPI.lua_tostring(L, 2);
                    bool is_show = LuaAPI.lua_toboolean(L, 3);
                    
                    __cl_gen_to_be_invoked.SendAnimationEvent( part, is_show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PlayAnimation(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.UIMainMapAnimationBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string part = LuaAPI.lua_tostring(L, 2);
                    uint target_state = LuaAPI.xlua_touint(L, 3);
                    
                    __cl_gen_to_be_invoked.PlayAnimation( part, target_state );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPlayAnimationEnd(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.UIMainMapAnimationBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.UIMainMapAnimationBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string param = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.OnPlayAnimationEnd( param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
