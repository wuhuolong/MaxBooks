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
    public class xcuiuguiTweenPositionWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.TweenPosition), L, translator, 0, 2, 5, 4);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetStartToCurrentValue", _m_SetStartToCurrentValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetEndToCurrentValue", _m_SetEndToCurrentValue);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cachedTransform", _g_get_cachedTransform);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "value", _g_get_value);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "from", _g_get_from);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "to", _g_get_to);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "worldSpace", _g_get_worldSpace);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "value", _s_set_value);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "from", _s_set_from);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "to", _s_set_to);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "worldSpace", _s_set_worldSpace);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.TweenPosition), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.TweenPosition), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Begin", _m_Begin_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.TweenPosition));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.TweenPosition), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.TweenPosition __cl_gen_ret = new xc.ui.ugui.TweenPosition();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.TweenPosition constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Begin_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.GameObject go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector3 pos;translator.Get(L, 3, out pos);
                    
                        xc.ui.ugui.TweenPosition __cl_gen_ret = xc.ui.ugui.TweenPosition.Begin( go, duration, pos );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.GameObject go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float duration = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector3 pos;translator.Get(L, 3, out pos);
                    bool worldSpace = LuaAPI.lua_toboolean(L, 4);
                    
                        xc.ui.ugui.TweenPosition __cl_gen_ret = xc.ui.ugui.TweenPosition.Begin( go, duration, pos, worldSpace );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.TweenPosition.Begin!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetStartToCurrentValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
            
            
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
        static int _g_get_cachedTransform(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.cachedTransform);
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
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.value);
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
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.from);
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
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, __cl_gen_to_be_invoked.to);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_worldSpace(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.worldSpace);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_value(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.value = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_from(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.from = __cl_gen_value;
            
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
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.to = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_worldSpace(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.TweenPosition __cl_gen_to_be_invoked = (xc.ui.ugui.TweenPosition)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.worldSpace = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
