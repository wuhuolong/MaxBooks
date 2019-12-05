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
    public class UnityEngineUIGridLayoutGroupWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup), L, translator, 0, 4, 6, 6);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CalculateLayoutInputHorizontal", _m_CalculateLayoutInputHorizontal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CalculateLayoutInputVertical", _m_CalculateLayoutInputVertical);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayoutHorizontal", _m_SetLayoutHorizontal);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetLayoutVertical", _m_SetLayoutVertical);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "startCorner", _g_get_startCorner);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "startAxis", _g_get_startAxis);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "cellSize", _g_get_cellSize);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "spacing", _g_get_spacing);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "constraint", _g_get_constraint);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "constraintCount", _g_get_constraintCount);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "startCorner", _s_set_startCorner);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "startAxis", _s_set_startAxis);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "cellSize", _s_set_cellSize);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "spacing", _s_set_spacing);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "constraint", _s_set_constraint);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "constraintCount", _s_set_constraintCount);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.UI.GridLayoutGroup), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.UI.GridLayoutGroup), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.UI.GridLayoutGroup));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.UI.GridLayoutGroup), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.UI.GridLayoutGroup does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateLayoutInputHorizontal(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
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
            
            
            UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
            
            
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
        static int _g_get_startCorner(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineUIGridLayoutGroupCorner(L, __cl_gen_to_be_invoked.startCorner);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startAxis(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineUIGridLayoutGroupAxis(L, __cl_gen_to_be_invoked.startAxis);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cellSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.cellSize);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, __cl_gen_to_be_invoked.spacing);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constraint(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineUIGridLayoutGroupConstraint(L, __cl_gen_to_be_invoked.constraint);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constraintCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.constraintCount);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startCorner(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                UnityEngine.UI.GridLayoutGroup.Corner __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.startCorner = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startAxis(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                UnityEngine.UI.GridLayoutGroup.Axis __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.startAxis = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cellSize(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.cellSize = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spacing(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.spacing = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constraint(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                UnityEngine.UI.GridLayoutGroup.Constraint __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.constraint = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constraintCount(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.UI.GridLayoutGroup __cl_gen_to_be_invoked = (UnityEngine.UI.GridLayoutGroup)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.constraintCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
