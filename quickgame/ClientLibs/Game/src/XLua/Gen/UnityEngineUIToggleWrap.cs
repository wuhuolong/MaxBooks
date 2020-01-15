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
    public class UnityEngineUIToggleWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.Toggle), L, translator, 0, 5, 5, 5);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Rebuild", _m_Rebuild);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LayoutComplete", _m_LayoutComplete);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GraphicUpdateComplete", _m_GraphicUpdateComplete);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerClick", _m_OnPointerClick);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnSubmit", _m_OnSubmit);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "group", _g_get_group);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isOn", _g_get_isOn);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "toggleTransition", _g_get_toggleTransition);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "graphic", _g_get_graphic);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onValueChanged", _g_get_onValueChanged);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "group", _s_set_group);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isOn", _s_set_isOn);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "toggleTransition", _s_set_toggleTransition);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "graphic", _s_set_graphic);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onValueChanged", _s_set_onValueChanged);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.Toggle), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.Toggle), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.Toggle));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.Toggle), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.Toggle does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rebuild(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.UI.CanvasUpdate executing;translator.Get(L, 2, out executing);
                    
                    __cl_gen_to_be_invoked.Rebuild( executing );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LayoutComplete(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.LayoutComplete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GraphicUpdateComplete(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.GraphicUpdateComplete(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerClick(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnPointerClick( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnSubmit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.BaseEventData eventData = (UnityEngine.EventSystems.BaseEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.BaseEventData));
                    
                    __cl_gen_to_be_invoked.OnSubmit( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_group(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.group);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isOn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isOn);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toggleTransition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineUIToggleToggleTransition(L, __cl_gen_to_be_invoked.toggleTransition);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.graphic);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onValueChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onValueChanged);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_group(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.group = (UnityEngine.UI.ToggleGroup)translator.GetObject(L, 2, typeof(UnityEngine.UI.ToggleGroup));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isOn(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isOn = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toggleTransition(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                UnityEngine.UI.Toggle.ToggleTransition __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.toggleTransition = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphic(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.graphic = (UnityEngine.UI.Graphic)translator.GetObject(L, 2, typeof(UnityEngine.UI.Graphic));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onValueChanged(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.Toggle __cl_gen_to_be_invoked = (UnityEngine.UI.Toggle)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onValueChanged = (UnityEngine.UI.Toggle.ToggleEvent)translator.GetObject(L, 2, typeof(UnityEngine.UI.Toggle.ToggleEvent));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
