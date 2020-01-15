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
    public class UnityEngineGameObjectWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(UnityEngine.GameObject), L, translator, 0, 10, 6, 2);

            XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IsDestroyed", _m_IsDestroyed);
            XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetComponent", _m_GetComponent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetComponentInChildren", _m_GetComponentInChildren);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetComponentInParent", _m_GetComponentInParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetComponents", _m_GetComponents);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetComponentsInChildren", _m_GetComponentsInChildren);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetComponentsInParent", _m_GetComponentsInParent);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "SetActive", _m_SetActive);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CompareTag", _m_CompareTag);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddComponent", _m_AddComponent);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "transform", _g_get_transform);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "layer", _g_get_layer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "activeSelf", _g_get_activeSelf);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "activeInHierarchy", _g_get_activeInHierarchy);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "tag", _g_get_tag);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "gameObject", _g_get_gameObject);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "layer", _s_set_layer);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "tag", _s_set_tag);
            
			XUtils.EndObjectRegister(typeof(UnityEngine.GameObject), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(UnityEngine.GameObject), L, __CreateInstance, 5, 0, 0);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindGameObjectWithTag", _m_FindGameObjectWithTag_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindWithTag", _m_FindWithTag_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "FindGameObjectsWithTag", _m_FindGameObjectsWithTag_xlua_st_);
            XUtils.RegisterFunc(L, XUtils.CLS_IDX, "Find", _m_Find_xlua_st_);
            
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(UnityEngine.GameObject));
			
			
			XUtils.EndClassRegister(typeof(UnityEngine.GameObject), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string name = LuaAPI.lua_tostring(L, 2);
					
					UnityEngine.GameObject __cl_gen_ret = new UnityEngine.GameObject(name);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UnityEngine.GameObject __cl_gen_ret = new UnityEngine.GameObject();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) >= 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || translator.Assignable<System.Type>(L, 3)))
				{
					string name = LuaAPI.lua_tostring(L, 2);
					System.Type[] components = translator.GetParams<System.Type>(L, 3);
					
					UnityEngine.GameObject __cl_gen_ret = new UnityEngine.GameObject(name, components);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GameObject constructor!");
            
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDestroyed(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);

            try
            {

                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                bool isDestroyed = __cl_gen_to_be_invoked == null;
                LuaAPI.lua_pushboolean(L, isDestroyed);

                return 1;
            }
            catch (System.Exception __gen_e)
            {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
        }

        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        UnityEngine.Component __cl_gen_ret = __cl_gen_to_be_invoked.GetComponent( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string type = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Component __cl_gen_ret = __cl_gen_to_be_invoked.GetComponent( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponent!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponentInChildren(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        UnityEngine.Component __cl_gen_ret = __cl_gen_to_be_invoked.GetComponentInChildren( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    bool includeInactive = LuaAPI.lua_toboolean(L, 3);
                    
                        UnityEngine.Component __cl_gen_ret = __cl_gen_to_be_invoked.GetComponentInChildren( type, includeInactive );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponentInChildren!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponentInParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        UnityEngine.Component __cl_gen_ret = __cl_gen_to_be_invoked.GetComponentInParent( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponents(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        UnityEngine.Component[] __cl_gen_ret = __cl_gen_to_be_invoked.GetComponents( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Component>>(L, 3)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    System.Collections.Generic.List<UnityEngine.Component> results = (System.Collections.Generic.List<UnityEngine.Component>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Component>));
                    
                    __cl_gen_to_be_invoked.GetComponents( type, results );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponents!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponentsInChildren(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        UnityEngine.Component[] __cl_gen_ret = __cl_gen_to_be_invoked.GetComponentsInChildren( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    bool includeInactive = LuaAPI.lua_toboolean(L, 3);
                    
                        UnityEngine.Component[] __cl_gen_ret = __cl_gen_to_be_invoked.GetComponentsInChildren( type, includeInactive );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponentsInChildren!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetComponentsInParent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Type>(L, 2)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        UnityEngine.Component[] __cl_gen_ret = __cl_gen_to_be_invoked.GetComponentsInParent( type );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<System.Type>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    System.Type type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    bool includeInactive = LuaAPI.lua_toboolean(L, 3);
                    
                        UnityEngine.Component[] __cl_gen_ret = __cl_gen_to_be_invoked.GetComponentsInParent( type, includeInactive );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.GameObject.GetComponentsInParent!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActive(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool value = LuaAPI.lua_toboolean(L, 2);
                    
                    if(__cl_gen_to_be_invoked.activeSelf != value)
                    __cl_gen_to_be_invoked.SetActive( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTag(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string tag = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.CompareTag( tag );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindGameObjectWithTag_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string tag = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.GameObject __cl_gen_ret = UnityEngine.GameObject.FindGameObjectWithTag( tag );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindWithTag_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string tag = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.GameObject __cl_gen_ret = UnityEngine.GameObject.FindWithTag( tag );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindGameObjectsWithTag_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string tag = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.GameObject[] __cl_gen_ret = UnityEngine.GameObject.FindGameObjectsWithTag( tag );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddComponent(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Type componentType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        UnityEngine.Component __cl_gen_ret = __cl_gen_to_be_invoked.AddComponent( componentType );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Find_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    string name = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.GameObject __cl_gen_ret = UnityEngine.GameObject.Find( name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transform(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.transform);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.layer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_activeSelf(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.activeSelf);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_activeInHierarchy(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.activeInHierarchy);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, __cl_gen_to_be_invoked.tag);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gameObject(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.gameObject);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_layer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.layer = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tag(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                UnityEngine.GameObject __cl_gen_to_be_invoked = (UnityEngine.GameObject)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.tag = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
