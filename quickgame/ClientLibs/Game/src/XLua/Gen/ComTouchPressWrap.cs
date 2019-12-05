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
    public class ComTouchPressWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(ComTouchPress), L, translator, 0, 4, 8, 8);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Init", _m_Init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerDown", _m_OnPointerDown);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerUp", _m_OnPointerUp);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "onPressCallBack", _e_onPressCallBack);
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "SupportPressDown", _g_get_SupportPressDown);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "CallBack", _g_get_CallBack);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ParmasObj", _g_get_ParmasObj);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isSupportAddSpeed", _g_get_isSupportAddSpeed);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AddSpeedTotal", _g_get_AddSpeedTotal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AddSpeedDetal", _g_get_AddSpeedDetal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PressDownTotal", _g_get_PressDownTotal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "PressDownDetal", _g_get_PressDownDetal);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "SupportPressDown", _s_set_SupportPressDown);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "CallBack", _s_set_CallBack);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ParmasObj", _s_set_ParmasObj);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isSupportAddSpeed", _s_set_isSupportAddSpeed);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AddSpeedTotal", _s_set_AddSpeedTotal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "AddSpeedDetal", _s_set_AddSpeedDetal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PressDownTotal", _s_set_PressDownTotal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "PressDownDetal", _s_set_PressDownDetal);
            
			XUtils.EndObjectRegister(typeof(ComTouchPress), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(ComTouchPress), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(ComTouchPress));
			
			
			XUtils.EndClassRegister(typeof(ComTouchPress), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					ComTouchPress __cl_gen_ret = new ComTouchPress();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ComTouchPress constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<ComTouchPress.OnPress>(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    ComTouchPress.OnPress callBack = translator.GetDelegate<ComTouchPress.OnPress>(L, 2);
                    object obj = translator.GetObject(L, 3, typeof(object));
                    
                    __cl_gen_to_be_invoked.Init( callBack, obj );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<ComTouchPress.OnPress>(L, 2)) 
                {
                    ComTouchPress.OnPress callBack = translator.GetDelegate<ComTouchPress.OnPress>(L, 2);
                    
                    __cl_gen_to_be_invoked.Init( callBack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to ComTouchPress.Init!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPointerDown(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
            
            
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
        static int _g_get_SupportPressDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.SupportPressDown);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CallBack(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.CallBack);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ParmasObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                translator.PushAny(L, __cl_gen_to_be_invoked.ParmasObj);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isSupportAddSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isSupportAddSpeed);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AddSpeedTotal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.AddSpeedTotal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AddSpeedDetal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.AddSpeedDetal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PressDownTotal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.PressDownTotal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PressDownDetal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.PressDownDetal);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SupportPressDown(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.SupportPressDown = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CallBack(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.CallBack = translator.GetDelegate<ComTouchPress.OnPress>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ParmasObj(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ParmasObj = translator.GetObject(L, 2, typeof(object));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isSupportAddSpeed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isSupportAddSpeed = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AddSpeedTotal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AddSpeedTotal = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AddSpeedDetal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.AddSpeedDetal = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PressDownTotal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PressDownTotal = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PressDownDetal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.PressDownDetal = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_onPressCallBack(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			int __gen_param_count = LuaAPI.lua_gettop(L);
			ComTouchPress __cl_gen_to_be_invoked = (ComTouchPress)translator.FastGetCSObj(L, 1);
            try {
                ComTouchPress.OnPress __gen_delegate = translator.GetDelegate<ComTouchPress.OnPress>(L, 3);
                if (__gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#3 need ComTouchPress.OnPress!");
                }
				
				if (__gen_param_count == 3)
				{
					System.IntPtr strlen;

					System.IntPtr str = LuaAPI.lua_tolstring(L, 2, out strlen);

					if (str != System.IntPtr.Zero && strlen.ToInt32() == 1)
					{
						byte op = System.Runtime.InteropServices.Marshal.ReadByte(str);
					
						
						if (op == (byte)'+') {
							__cl_gen_to_be_invoked.onPressCallBack += __gen_delegate;
							return 0;
						} 
						
						
						if (op == (byte)'-') {
							__cl_gen_to_be_invoked.onPressCallBack -= __gen_delegate;
							return 0;
						} 
						
					}
				}
			} catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
			LuaAPI.luaL_error(L, "invalid arguments to ComTouchPress.onPressCallBack!");
            return 0;
        }
        
		
		
    }
}
