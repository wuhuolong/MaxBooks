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
    public class UnityEngineUIVerticalLayoutGroupWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.VerticalLayoutGroup), L, translator, 0, 4, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CalculateLayoutInputHorizontal", _m_CalculateLayoutInputHorizontal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CalculateLayoutInputVertical", _m_CalculateLayoutInputVertical);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayoutHorizontal", _m_SetLayoutHorizontal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayoutVertical", _m_SetLayoutVertical);
			
			
			
			
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.VerticalLayoutGroup), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.VerticalLayoutGroup), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.VerticalLayoutGroup));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.VerticalLayoutGroup), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.VerticalLayoutGroup does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputHorizontal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.VerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.VerticalLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CalculateLayoutInputHorizontal(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputVertical(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.VerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.VerticalLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.CalculateLayoutInputVertical(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayoutHorizontal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.VerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.VerticalLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            UnityEngine.UI.VerticalLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.VerticalLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.SetLayoutVertical(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
