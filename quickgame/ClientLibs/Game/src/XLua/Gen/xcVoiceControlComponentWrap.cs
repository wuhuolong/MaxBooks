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
    public class xcVoiceControlComponentWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.VoiceControlComponent), L, translator, 0, 8, 6, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Start", _m_Start);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnDisable", _m_OnDisable);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerDown", _m_OnPointerDown);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerUp", _m_OnPointerUp);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerEnter", _m_OnPointerEnter);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnPointerExit", _m_OnPointerExit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnApplicationPause", _m_OnApplicationPause);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Tag", _g_get_Tag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "DelayTime", _g_get_DelayTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RecordMaxTime", _g_get_RecordMaxTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "RecordMinTime", _g_get_RecordMinTime);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Intevel", _g_get_Intevel);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnClickFunc", _g_get_OnClickFunc);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Tag", _s_set_Tag);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "DelayTime", _s_set_DelayTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RecordMaxTime", _s_set_RecordMaxTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "RecordMinTime", _s_set_RecordMinTime);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Intevel", _s_set_Intevel);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnClickFunc", _s_set_OnClickFunc);
            
			XUtils.EndObjectRegister(typeof(xc.VoiceControlComponent), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.VoiceControlComponent), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.VoiceControlComponent));
			
			
			XUtils.EndClassRegister(typeof(xc.VoiceControlComponent), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.VoiceControlComponent __cl_gen_ret = new xc.VoiceControlComponent();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.VoiceControlComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Start(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDisable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.OnDisable(  );
                    
                    
                    
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
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_OnPointerEnter(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.EventSystems.PointerEventData eventData = (UnityEngine.EventSystems.PointerEventData)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.PointerEventData));
                    
                    __cl_gen_to_be_invoked.OnPointerEnter( eventData );
                    
                    
                    
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
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_OnApplicationPause(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool pauseStatus = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.OnApplicationPause( pauseStatus );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.Tag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DelayTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.DelayTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RecordMaxTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.RecordMaxTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RecordMinTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.RecordMinTime);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Intevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.Intevel);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnClickFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnClickFunc);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Tag = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DelayTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DelayTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RecordMaxTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RecordMaxTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RecordMinTime(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.RecordMinTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Intevel(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Intevel = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnClickFunc(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.VoiceControlComponent __cl_gen_to_be_invoked = (xc.VoiceControlComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnClickFunc = translator.GetDelegate<xc.VoiceControlComponent.OnClickDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
