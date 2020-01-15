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
    public class UnityEngineMonoBehaviourWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.MonoBehaviour), L, translator, 0, 7, 1, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Invoke", _m_Invoke);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InvokeRepeating", _m_InvokeRepeating);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CancelInvoke", _m_CancelInvoke);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsInvoking", _m_IsInvoking);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StartCoroutine", _m_StartCoroutine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopCoroutine", _m_StopCoroutine);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "StopAllCoroutines", _m_StopAllCoroutines);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "useGUILayout", _g_get_useGUILayout);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "useGUILayout", _s_set_useGUILayout);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.MonoBehaviour), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.MonoBehaviour), L, __CreateInstance, 2, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "print", _m_print_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.MonoBehaviour));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.MonoBehaviour), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.MonoBehaviour __cl_gen_ret = new UnityEngine.MonoBehaviour();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.MonoBehaviour constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Invoke(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    float time = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    __cl_gen_to_be_invoked.Invoke( methodName, time );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InvokeRepeating(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    float time = (float)LuaAPI.lua_tonumber(L, 3);
                    float repeatRate = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    __cl_gen_to_be_invoked.InvokeRepeating( methodName, time, repeatRate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CancelInvoke(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.CancelInvoke(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.CancelInvoke( methodName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.MonoBehaviour.CancelInvoke!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInvoking(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInvoking(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.IsInvoking( methodName );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.MonoBehaviour.IsInvoking!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartCoroutine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.IEnumerator>(L, 2)) 
                {
                    System.Collections.IEnumerator routine = (System.Collections.IEnumerator)translator.GetObject(L, 2, typeof(System.Collections.IEnumerator));
                    
                        UnityEngine.Coroutine __cl_gen_ret = __cl_gen_to_be_invoked.StartCoroutine( routine );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Coroutine __cl_gen_ret = __cl_gen_to_be_invoked.StartCoroutine( methodName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 3)) 
                {
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    object value = translator.GetObject(L, 3, typeof(object));
                    
                        UnityEngine.Coroutine __cl_gen_ret = __cl_gen_to_be_invoked.StartCoroutine( methodName, value );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.MonoBehaviour.StartCoroutine!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopCoroutine(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string methodName = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.StopCoroutine( methodName );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.IEnumerator>(L, 2)) 
                {
                    System.Collections.IEnumerator routine = (System.Collections.IEnumerator)translator.GetObject(L, 2, typeof(System.Collections.IEnumerator));
                    
                    __cl_gen_to_be_invoked.StopCoroutine( routine );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Coroutine>(L, 2)) 
                {
                    UnityEngine.Coroutine routine = (UnityEngine.Coroutine)translator.GetObject(L, 2, typeof(UnityEngine.Coroutine));
                    
                    __cl_gen_to_be_invoked.StopCoroutine( routine );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.MonoBehaviour.StopCoroutine!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAllCoroutines(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.StopAllCoroutines(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_print_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    object message = translator.GetObject(L, 1, typeof(object));
                    
                    UnityEngine.MonoBehaviour.print( message );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useGUILayout(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.useGUILayout);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useGUILayout(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.MonoBehaviour __cl_gen_to_be_invoked = (UnityEngine.MonoBehaviour)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.useGUILayout = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
