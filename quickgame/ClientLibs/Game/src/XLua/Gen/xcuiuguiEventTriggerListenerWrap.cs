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
    public class xcuiuguiEventTriggerListenerWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.EventTriggerListener), L, translator, 0, 8, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerClick", _m_OnPointerClick);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerDown", _m_OnPointerDown);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerUp", _m_OnPointerUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerExit", _m_OnPointerExit);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "onPointerClick", _e_onPointerClick);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "onPointerDown", _e_onPointerDown);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "onPointerUp", _e_onPointerUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "onPointerExit", _e_onPointerExit);
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.EventTriggerListener), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.EventTriggerListener), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "GetListener", _m_GetListener_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.EventTriggerListener));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.EventTriggerListener), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.EventTriggerListener __cl_gen_ret = new xc.ui.ugui.EventTriggerListener();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.EventTriggerListener constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetListener_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject game_object = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        xc.ui.ugui.EventTriggerListener __cl_gen_ret = xc.ui.ugui.EventTriggerListener.GetListener( game_object );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerClick(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_OnPointerDown(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnPointerDown( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerUp(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnPointerUp( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerExit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnPointerExit( eventData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onPointerClick(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
			xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            try {
                xc.ui.ugui.EventTriggerListener.UIDelegate __gen_delegate = translator.GetDelegate<xc.ui.ugui.EventTriggerListener.UIDelegate>(L, 3);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need xc.ui.ugui.EventTriggerListener.UIDelegate!");
                }
				
				if (__gen_param_count == 3)
				{
					System.IntPtr strlen;

					System.IntPtr str = LuaAPI.lua_tolstring(L, 2, out strlen);

					if (str != System.IntPtr.Zero && strlen.ToInt32() == 1)
					{
						byte op = System.Runtime.InteropServices.Marshal.ReadByte(str);
					
						
						if (op == (byte)'+') {
							__cl_gen_to_be_invoked.onPointerClick += __gen_delegate;
							return 0;
						} 
						
						
						if (op == (byte)'-') {
							__cl_gen_to_be_invoked.onPointerClick -= __gen_delegate;
							return 0;
						} 
						
					}
				}
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.EventTriggerListener.onPointerClick!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onPointerDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
			xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            try {
                xc.ui.ugui.EventTriggerListener.UIDelegate __gen_delegate = translator.GetDelegate<xc.ui.ugui.EventTriggerListener.UIDelegate>(L, 3);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need xc.ui.ugui.EventTriggerListener.UIDelegate!");
                }
				
				if (__gen_param_count == 3)
				{
					System.IntPtr strlen;

					System.IntPtr str = LuaAPI.lua_tolstring(L, 2, out strlen);

					if (str != System.IntPtr.Zero && strlen.ToInt32() == 1)
					{
						byte op = System.Runtime.InteropServices.Marshal.ReadByte(str);
					
						
						if (op == (byte)'+') {
							__cl_gen_to_be_invoked.onPointerDown += __gen_delegate;
							return 0;
						} 
						
						
						if (op == (byte)'-') {
							__cl_gen_to_be_invoked.onPointerDown -= __gen_delegate;
							return 0;
						} 
						
					}
				}
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.EventTriggerListener.onPointerDown!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onPointerUp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
			xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            try {
                xc.ui.ugui.EventTriggerListener.UIDelegate __gen_delegate = translator.GetDelegate<xc.ui.ugui.EventTriggerListener.UIDelegate>(L, 3);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need xc.ui.ugui.EventTriggerListener.UIDelegate!");
                }
				
				if (__gen_param_count == 3)
				{
					System.IntPtr strlen;

					System.IntPtr str = LuaAPI.lua_tolstring(L, 2, out strlen);

					if (str != System.IntPtr.Zero && strlen.ToInt32() == 1)
					{
						byte op = System.Runtime.InteropServices.Marshal.ReadByte(str);
					
						
						if (op == (byte)'+') {
							__cl_gen_to_be_invoked.onPointerUp += __gen_delegate;
							return 0;
						} 
						
						
						if (op == (byte)'-') {
							__cl_gen_to_be_invoked.onPointerUp -= __gen_delegate;
							return 0;
						} 
						
					}
				}
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.EventTriggerListener.onPointerUp!");
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onPointerExit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
			xc.ui.ugui.EventTriggerListener __cl_gen_to_be_invoked = (xc.ui.ugui.EventTriggerListener)translator.FastGetCSObj(L, 1);
            try {
                xc.ui.ugui.EventTriggerListener.UIDelegate __gen_delegate = translator.GetDelegate<xc.ui.ugui.EventTriggerListener.UIDelegate>(L, 3);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need xc.ui.ugui.EventTriggerListener.UIDelegate!");
                }
				
				if (__gen_param_count == 3)
				{
					System.IntPtr strlen;

					System.IntPtr str = LuaAPI.lua_tolstring(L, 2, out strlen);

					if (str != System.IntPtr.Zero && strlen.ToInt32() == 1)
					{
						byte op = System.Runtime.InteropServices.Marshal.ReadByte(str);
					
						
						if (op == (byte)'+') {
							__cl_gen_to_be_invoked.onPointerExit += __gen_delegate;
							return 0;
						} 
						
						
						if (op == (byte)'-') {
							__cl_gen_to_be_invoked.onPointerExit -= __gen_delegate;
							return 0;
						} 
						
					}
				}
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.EventTriggerListener.onPointerExit!");
            return 0;
        }
        
		
		
    }
}
