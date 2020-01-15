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
    public class xcuiuguiSliderExWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ui.ugui.SliderEx), L, translator, 0, 2, 3, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetValue", _m_SetValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "duration", _g_get_duration);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onOneFinished", _g_get_onOneFinished);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "onFinished", _g_get_onFinished);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "duration", _s_set_duration);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onOneFinished", _s_set_onOneFinished);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "onFinished", _s_set_onFinished);
            
			XUtils.EndObjectRegister(typeof(xc.ui.ugui.SliderEx), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ui.ugui.SliderEx), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ui.ugui.SliderEx));
			
			
			XUtils.EndClassRegister(typeof(xc.ui.ugui.SliderEx), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ui.ugui.SliderEx __cl_gen_ret = new xc.ui.ugui.SliderEx();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.SliderEx constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float v = (float)LuaAPI.lua_tonumber(L, 2);
                    float time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.SetValue( v, time );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float v = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.SetValue( v );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ui.ugui.SliderEx.SetValue!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_duration(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, __cl_gen_to_be_invoked.duration);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onOneFinished(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onOneFinished);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onFinished(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.onFinished);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_duration(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.duration = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onOneFinished(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onOneFinished = translator.GetDelegate<xc.ui.ugui.SliderEx.OnOneFinished>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onFinished(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                xc.ui.ugui.SliderEx __cl_gen_to_be_invoked = (xc.ui.ugui.SliderEx)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.onFinished = translator.GetDelegate<xc.ui.ugui.SliderEx.OnFinished>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
