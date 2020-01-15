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
    public class xcuiuguiTweenCircleAnchoredPositionWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.TweenCircleAnchoredPosition), L, translator, 0, 2, 6, 5);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetStartToCurrentValue", _m_SetStartToCurrentValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetEndToCurrentValue", _m_SetEndToCurrentValue);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cachedRectTransform", _g_get_cachedRectTransform);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "centerPos", _g_get_centerPos);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "radius", _g_get_radius);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "fromDegree", _g_get_fromDegree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "toDegree", _g_get_toDegree);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "value", _g_get_value);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "centerPos", _s_set_centerPos);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "radius", _s_set_radius);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "fromDegree", _s_set_fromDegree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "toDegree", _s_set_toDegree);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "value", _s_set_value);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.TweenCircleAnchoredPosition), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.TweenCircleAnchoredPosition), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Begin", _m_Begin_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.TweenCircleAnchoredPosition));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.TweenCircleAnchoredPosition), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_ret = new xc.ui.ugui.TweenCircleAnchoredPosition();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.TweenCircleAnchoredPosition constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Begin_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector2 centerPos;translator.Get(L, 3, out centerPos);
                    float radius = (float)LuaAPI.lua_tonumber(L, 4);
                    float fromDegree = (float)LuaAPI.lua_tonumber(L, 5);
                    float toDegree = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_ret = xc.ui.ugui.TweenCircleAnchoredPosition.Begin( go, duration, centerPos, radius, fromDegree, toDegree );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetStartToCurrentValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetStartToCurrentValue(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEndToCurrentValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetEndToCurrentValue(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cachedRectTransform(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.cachedRectTransform);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_centerPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.centerPos);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_radius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.radius);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fromDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.fromDegree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.toDegree);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.value);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_centerPos(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.centerPos = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_radius(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.radius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fromDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.fromDegree = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toDegree(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.toDegree = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenCircleAnchoredPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenCircleAnchoredPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.value = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
