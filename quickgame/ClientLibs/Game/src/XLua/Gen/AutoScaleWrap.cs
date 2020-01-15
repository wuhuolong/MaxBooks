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
    public class AutoScaleWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(AutoScale), L, translator, 0, 0, 2, 2);
			
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "m_ScaleMode", _g_get_m_ScaleMode);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "OnAutoSize", _g_get_OnAutoSize);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "m_ScaleMode", _s_set_m_ScaleMode);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "OnAutoSize", _s_set_OnAutoSize);
            
			XUtils.EndObjectRegister(typeof(AutoScale), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(AutoScale), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(AutoScale));
			
			
			XUtils.EndClassRegister(typeof(AutoScale), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					AutoScale __cl_gen_ret = new AutoScale();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to AutoScale constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_ScaleMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AutoScale __cl_gen_to_be_invoked = (AutoScale)translator.FastGetCSObj(L, 1);
                translator.PushAutoScaleScaleMode(L, __cl_gen_to_be_invoked.m_ScaleMode);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnAutoSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AutoScale __cl_gen_to_be_invoked = (AutoScale)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.OnAutoSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_ScaleMode(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AutoScale __cl_gen_to_be_invoked = (AutoScale)translator.FastGetCSObj(L, 1);
                AutoScale.ScaleMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.m_ScaleMode = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnAutoSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                AutoScale __cl_gen_to_be_invoked = (AutoScale)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.OnAutoSize = translator.GetDelegate<AutoScale.AutoSizeDelegate>(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
