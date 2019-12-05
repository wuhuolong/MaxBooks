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
    public class UnityEngineUIContentSizeFitterWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.ContentSizeFitter), L, translator, 0, 2, 2, 2);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayoutHorizontal", _m_SetLayoutHorizontal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayoutVertical", _m_SetLayoutVertical);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "horizontalFit", _g_get_horizontalFit);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "verticalFit", _g_get_verticalFit);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "horizontalFit", _s_set_horizontalFit);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "verticalFit", _s_set_verticalFit);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.ContentSizeFitter), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.ContentSizeFitter), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.ContentSizeFitter));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.ContentSizeFitter), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.ContentSizeFitter does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayoutHorizontal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ContentSizeFitter __cl_gen_to_be_invoked = (UnityEngine.UI.ContentSizeFitter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetLayoutHorizontal(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayoutVertical(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.ContentSizeFitter __cl_gen_to_be_invoked = (UnityEngine.UI.ContentSizeFitter)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetLayoutVertical(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_horizontalFit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.ContentSizeFitter __cl_gen_to_be_invoked = (UnityEngine.UI.ContentSizeFitter)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineUIContentSizeFitterFitMode(L, __cl_gen_to_be_invoked.horizontalFit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_verticalFit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.ContentSizeFitter __cl_gen_to_be_invoked = (UnityEngine.UI.ContentSizeFitter)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineUIContentSizeFitterFitMode(L, __cl_gen_to_be_invoked.verticalFit);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_horizontalFit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.ContentSizeFitter __cl_gen_to_be_invoked = (UnityEngine.UI.ContentSizeFitter)translator.FastGetCSObj(L, 1);
                UnityEngine.UI.ContentSizeFitter.FitMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.horizontalFit = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_verticalFit(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.ContentSizeFitter __cl_gen_to_be_invoked = (UnityEngine.UI.ContentSizeFitter)translator.FastGetCSObj(L, 1);
                UnityEngine.UI.ContentSizeFitter.FitMode __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.verticalFit = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
