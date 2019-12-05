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
    public class xcuiuguiTweenScrollNormalizedPositionWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.TweenScrollNormalizedPosition), L, translator, 0, 2, 5, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetStartToCurrentValue", _m_SetStartToCurrentValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetEndToCurrentValue", _m_SetEndToCurrentValue);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cachedScrollRect", _g_get_cachedScrollRect);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "from", _g_get_from);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "to", _g_get_to);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "isHorizontal", _g_get_isHorizontal);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "value", _g_get_value);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "from", _s_set_from);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "to", _s_set_to);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "isHorizontal", _s_set_isHorizontal);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "value", _s_set_value);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.TweenScrollNormalizedPosition), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.TweenScrollNormalizedPosition), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Begin", _m_Begin_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.TweenScrollNormalizedPosition));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.TweenScrollNormalizedPosition), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_ret = new xc.ui.ugui.TweenScrollNormalizedPosition();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.TweenScrollNormalizedPosition constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Begin_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float duration = (float)LuaAPI.lua_tonumber(L, 2);
                    float position = (float)LuaAPI.lua_tonumber(L, 3);
                    bool isHorizontal = LuaAPI.lua_toboolean(L, 4);
                    
                        xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_ret = xc.ui.ugui.TweenScrollNormalizedPosition.Begin( go, duration, position, isHorizontal );
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
            
            
            xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
            
            
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
        static int _g_get_cachedScrollRect(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.cachedScrollRect);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_from(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.from);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_to(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.to);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isHorizontal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.isHorizontal);
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
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.value);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_from(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.from = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_to(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.to = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isHorizontal(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.isHorizontal = LuaAPI.lua_toboolean(L, 2);
            
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
			
                xc.ui.ugui.TweenScrollNormalizedPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenScrollNormalizedPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.value = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
