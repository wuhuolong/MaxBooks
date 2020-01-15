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
    public class SystemCollectionsGenericDictionary_2_SystemUInt32xcGoodsLightWeaponSoul_Wrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>), L, translator, 0, 9, 4, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Add", _m_Add);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ContainsKey", _m_ContainsKey);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ContainsValue", _m_ContainsValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetObjectData", _m_GetObjectData);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnDeserialization", _m_OnDeserialization);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Remove", _m_Remove);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TryGetValue", _m_TryGetValue);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEnumerator", _m_GetEnumerator);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Count", _g_get_Count);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Comparer", _g_get_Comparer);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Keys", _g_get_Keys);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Values", _g_get_Values);
            
			
			XUtils.EndObjectRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>), L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>));
			
			
			XUtils.EndClassRegister(typeof(System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_ret = new System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Collections.Generic.IEqualityComparer<uint>>(L, 2))
				{
					System.Collections.Generic.IEqualityComparer<uint> comparer = (System.Collections.Generic.IEqualityComparer<uint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.IEqualityComparer<uint>));
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_ret = new System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>(comparer);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul>>(L, 2))
				{
					System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul> dictionary = (System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul>)translator.GetObject(L, 2, typeof(System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul>));
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_ret = new System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>(dictionary);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					int capacity = LuaAPI.xlua_tointeger(L, 2);
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_ret = new System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>(capacity);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && translator.Assignable<System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul>>(L, 2) && translator.Assignable<System.Collections.Generic.IEqualityComparer<uint>>(L, 3))
				{
					System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul> dictionary = (System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul>)translator.GetObject(L, 2, typeof(System.Collections.Generic.IDictionary<uint, xc.GoodsLightWeaponSoul>));
					System.Collections.Generic.IEqualityComparer<uint> comparer = (System.Collections.Generic.IEqualityComparer<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.IEqualityComparer<uint>));
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_ret = new System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>(dictionary, comparer);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<System.Collections.Generic.IEqualityComparer<uint>>(L, 3))
				{
					int capacity = LuaAPI.xlua_tointeger(L, 2);
					System.Collections.Generic.IEqualityComparer<uint> comparer = (System.Collections.Generic.IEqualityComparer<uint>)translator.GetObject(L, 3, typeof(System.Collections.Generic.IEqualityComparer<uint>));
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_ret = new System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>(capacity, comparer);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				
				if (translator.Assignable<System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
					uint index = LuaAPI.xlua_touint(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					translator.Push(L, __cl_gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if (translator.Assignable<System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<xc.GoodsLightWeaponSoul>(L, 3))
				{
					
					System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
					uint key = LuaAPI.xlua_touint(L, 2);
					__cl_gen_to_be_invoked[key] = (xc.GoodsLightWeaponSoul)translator.GetObject(L, 3, typeof(xc.GoodsLightWeaponSoul));
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Add(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint key = LuaAPI.xlua_touint(L, 2);
                    xc.GoodsLightWeaponSoul value = (xc.GoodsLightWeaponSoul)translator.GetObject(L, 3, typeof(xc.GoodsLightWeaponSoul));
                    
                    __cl_gen_to_be_invoked.Add( key, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_ContainsKey(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint key = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ContainsKey( key );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContainsValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.GoodsLightWeaponSoul value = (xc.GoodsLightWeaponSoul)translator.GetObject(L, 2, typeof(xc.GoodsLightWeaponSoul));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ContainsValue( value );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObjectData(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Runtime.Serialization.SerializationInfo info = (System.Runtime.Serialization.SerializationInfo)translator.GetObject(L, 2, typeof(System.Runtime.Serialization.SerializationInfo));
                    System.Runtime.Serialization.StreamingContext context;translator.Get(L, 3, out context);
                    
                    __cl_gen_to_be_invoked.GetObjectData( info, context );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDeserialization(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object sender = translator.GetObject(L, 2, typeof(object));
                    
                    __cl_gen_to_be_invoked.OnDeserialization( sender );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint key = LuaAPI.xlua_touint(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Remove( key );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetValue(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint key = LuaAPI.xlua_touint(L, 2);
                    xc.GoodsLightWeaponSoul value;
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TryGetValue( key, out value );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    translator.Push(L, value);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEnumerator(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>.Enumerator __cl_gen_ret = __cl_gen_to_be_invoked.GetEnumerator(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Comparer(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Comparer);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Keys(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Keys);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Values(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul> __cl_gen_to_be_invoked = (System.Collections.Generic.Dictionary<uint, xc.GoodsLightWeaponSoul>)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.Values);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
