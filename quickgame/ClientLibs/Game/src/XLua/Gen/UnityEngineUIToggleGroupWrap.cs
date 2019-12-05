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
    public class UnityEngineUIToggleGroupWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.ToggleGroup), L, translator, 0, 6, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "NotifyToggleOn", _m_NotifyToggleOn);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "UnregisterToggle", _m_UnregisterToggle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RegisterToggle", _m_RegisterToggle);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AnyTogglesOn", _m_AnyTogglesOn);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ActiveToggles", _m_ActiveToggles);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetAllTogglesOff", _m_SetAllTogglesOff);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "allowSwitchOff", _g_get_allowSwitchOff);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "allowSwitchOff", _s_set_allowSwitchOff);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.ToggleGroup), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.ToggleGroup), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.ToggleGroup));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.ToggleGroup), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.ToggleGroup does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NotifyToggleOn(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.UI.Toggle toggle = (UnityEngine.UI.Toggle)translator.GetObject(L, 2, typeof(UnityEngine.UI.Toggle));
                    
                    __cl_gen_to_be_invoked.NotifyToggleOn( toggle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnregisterToggle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.UI.Toggle toggle = (UnityEngine.UI.Toggle)translator.GetObject(L, 2, typeof(UnityEngine.UI.Toggle));
                    
                    __cl_gen_to_be_invoked.UnregisterToggle( toggle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterToggle(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.UI.Toggle toggle = (UnityEngine.UI.Toggle)translator.GetObject(L, 2, typeof(UnityEngine.UI.Toggle));
                    
                    __cl_gen_to_be_invoked.RegisterToggle( toggle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AnyTogglesOn(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.AnyTogglesOn(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ActiveToggles(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.IEnumerable<UnityEngine.UI.Toggle> __cl_gen_ret = __cl_gen_to_be_invoked.ActiveToggles(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAllTogglesOff(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetAllTogglesOff(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_allowSwitchOff(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.allowSwitchOff);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_allowSwitchOff(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.ToggleGroup __cl_gen_to_be_invoked = (UnityEngine.UI.ToggleGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.allowSwitchOff = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
