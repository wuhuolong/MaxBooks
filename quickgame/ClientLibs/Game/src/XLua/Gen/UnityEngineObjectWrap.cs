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
    public class UnityEngineObjectWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.Object), L, translator, 1, 4, 2, 2);
			XUtils.RegisterFunc(L, XUtils.OBJ_META_IDX, "__eq", __EqMeta);
            
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToString", _m_ToString);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetInstanceID", _m_GetInstanceID);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Equals", _m_Equals);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "name", _g_get_name);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "hideFlags", _g_get_hideFlags);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "name", _s_set_name);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "hideFlags", _s_set_hideFlags);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.Object), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.Object), L, __CreateInstance, 8, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Destroy", _m_Destroy_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DestroyImmediate", _m_DestroyImmediate_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindObjectsOfType", _m_FindObjectsOfType_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DontDestroyOnLoad", _m_DontDestroyOnLoad_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "DestroyObject", _m_DestroyObject_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Instantiate", _m_Instantiate_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindObjectOfType", _m_FindObjectOfType_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.Object));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.Object), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.Object __cl_gen_ret = new UnityEngine.Object();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Object constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			try {
				if (translator.Assignable<UnityEngine.Object>(L, 1) && translator.Assignable<UnityEngine.Object>(L, 2))
				{
					UnityEngine.Object leftside = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
					UnityEngine.Object rightside = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need UnityEngine.Object!");
            
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Object>(L, 1)) 
                {
                    UnityEngine.Object obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    UnityEngine.Object.Destroy( obj );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Object obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    float t = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    UnityEngine.Object.Destroy( obj, t );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Object.Destroy!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyImmediate_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Object>(L, 1)) 
                {
                    UnityEngine.Object obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    UnityEngine.Object.DestroyImmediate( obj );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Object obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    bool allowDestroyingAssets = LuaAPI.lua_toboolean(L, 2);
                    
                    UnityEngine.Object.DestroyImmediate( obj, allowDestroyingAssets );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Object.DestroyImmediate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindObjectsOfType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        UnityEngine.Object[] __cl_gen_ret = UnityEngine.Object.FindObjectsOfType( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DontDestroyOnLoad_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Object target = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    UnityEngine.Object.DontDestroyOnLoad( target );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyObject_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Object>(L, 1)) 
                {
                    UnityEngine.Object obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    UnityEngine.Object.DestroyObject( obj );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Object obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    float t = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    UnityEngine.Object.DestroyObject( obj, t );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Object.DestroyObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInstanceID(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetInstanceID(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object other = translator.GetObject(L, 2, typeof(object));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Equals( other );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Instantiate_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Object>(L, 1)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Object>(L, 1)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Transform>(L, 2)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Transform>(L, 2)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Transform>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    bool instantiateInWorldSpace = LuaAPI.lua_toboolean(L, 3);
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, parent, instantiateInWorldSpace );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Transform>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    bool worldPositionStays = LuaAPI.lua_toboolean(L, 3);
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, parent, worldPositionStays );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Quaternion>(L, 3)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Vector3 position;translator.Get(L, 2, out position);
                    UnityEngine.Quaternion rotation;translator.Get(L, 3, out rotation);
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, position, rotation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Quaternion>(L, 3)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Vector3 position;translator.Get(L, 2, out position);
                    UnityEngine.Quaternion rotation;translator.Get(L, 3, out rotation);
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, position, rotation );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Quaternion>(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Vector3 position;translator.Get(L, 2, out position);
                    UnityEngine.Quaternion rotation;translator.Get(L, 3, out rotation);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, position, rotation, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.Object>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Quaternion>(L, 3)&& translator.Assignable<UnityEngine.Transform>(L, 4)) 
                {
                    UnityEngine.Object original = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    UnityEngine.Vector3 position;translator.Get(L, 2, out position);
                    UnityEngine.Quaternion rotation;translator.Get(L, 3, out rotation);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 4, typeof(UnityEngine.Transform));
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.Instantiate( original, position, rotation, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Object.Instantiate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindObjectOfType_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    System.Type type = (System.Type)translator.GetObject(L, 1, typeof(System.Type));
                    
                        UnityEngine.Object __cl_gen_ret = UnityEngine.Object.FindObjectOfType( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.name);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hideFlags(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.hideFlags);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hideFlags(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.Object __cl_gen_to_be_invoked = (UnityEngine.Object)translator.FastGetCSObj(L, 1);
                UnityEngine.HideFlags __cl_gen_value;translator.Get(L, 2, out __cl_gen_value);
				__cl_gen_to_be_invoked.hideFlags = __cl_gen_value;
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
