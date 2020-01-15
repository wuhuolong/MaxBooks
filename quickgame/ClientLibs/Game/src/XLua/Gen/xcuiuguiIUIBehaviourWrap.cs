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
    public class xcuiuguiIUIBehaviourWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.IUIBehaviour), L, translator, 0, 4, 4, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InitBehaviour", _m_InitBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UpdateBehaviour", _m_UpdateBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "DestroyBehaviour", _m_DestroyBehaviour);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "EnableBehaviour", _m_EnableBehaviour);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Window", _g_get_Window);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isInit", _g_get_isInit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "IsEnable", _g_get_IsEnable);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OldEnable", _g_get_OldEnable);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Window", _s_set_Window);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isInit", _s_set_isInit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "IsEnable", _s_set_IsEnable);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OldEnable", _s_set_OldEnable);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.IUIBehaviour), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.IUIBehaviour), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.IUIBehaviour));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.IUIBehaviour), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "xc.ui.ugui.IUIBehaviour does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitBehaviour(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool isEnable = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.EnableBehaviour( isEnable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Window(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Window);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isInit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isInit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsEnable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.IsEnable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OldEnable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.OldEnable);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Window(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Window = (xc.ui.ugui.UIBaseWindow)translator.GetObject(L, 2, typeof(xc.ui.ugui.UIBaseWindow));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isInit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isInit = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsEnable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.IsEnable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OldEnable(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.IUIBehaviour __cl_gen_to_be_invoked = (xc.ui.ugui.IUIBehaviour)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OldEnable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
