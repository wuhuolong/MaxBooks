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
    public class SystemCollectionsGenericList_1_xcDBGrowSkinDBGrowSkinItem_Wrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>), L, translator, 0, 29, 2, 1);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Add", _m_Add);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AddRange", _m_AddRange);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "AsReadOnly", _m_AsReadOnly);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "BinarySearch", _m_BinarySearch);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Clear", _m_Clear);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Contains", _m_Contains);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "CopyTo", _m_CopyTo);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Exists", _m_Exists);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Find", _m_Find);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindAll", _m_FindAll);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindIndex", _m_FindIndex);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindLast", _m_FindLast);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "FindLastIndex", _m_FindLastIndex);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ForEach", _m_ForEach);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetEnumerator", _m_GetEnumerator);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "GetRange", _m_GetRange);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "IndexOf", _m_IndexOf);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Insert", _m_Insert);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "InsertRange", _m_InsertRange);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LastIndexOf", _m_LastIndexOf);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Remove", _m_Remove);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveAll", _m_RemoveAll);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveAt", _m_RemoveAt);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveRange", _m_RemoveRange);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Reverse", _m_Reverse);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Sort", _m_Sort);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "ToArray", _m_ToArray);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TrimExcess", _m_TrimExcess);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "TrueForAll", _m_TrueForAll);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Capacity", _g_get_Capacity);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "Count", _g_get_Count);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "Capacity", _s_set_Capacity);
            
			XUtils.EndObjectRegister(typeof(System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>), L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>), L, __CreateInstance, 1, 0, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>));
			
			
			XUtils.EndClassRegister(typeof(System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_ret = new System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2))
				{
					System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem> collection = (System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem>));
					
					System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_ret = new System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>(collection);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					int capacity = LuaAPI.xlua_tointeger(L, 2);
					
					System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_ret = new System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>(capacity);
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				
				if (translator.Assignable<System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
					int index = LuaAPI.xlua_tointeger(L, 2);
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
				
				if (translator.Assignable<System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 3))
				{
					
					System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
					int key = LuaAPI.xlua_tointeger(L, 2);
					__cl_gen_to_be_invoked[key] = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 3, typeof(xc.DBGrowSkin.DBGrowSkinItem));
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
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    
                    __cl_gen_to_be_invoked.Add( item );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddRange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem> collection = (System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem>));
                    
                    __cl_gen_to_be_invoked.AddRange( collection );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AsReadOnly(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.ObjectModel.ReadOnlyCollection<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_ret = __cl_gen_to_be_invoked.AsReadOnly(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BinarySearch(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.BinarySearch( item );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)&& translator.Assignable<System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>>(L, 3)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem> comparer = (System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>)translator.GetObject(L, 3, typeof(System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.BinarySearch( item, comparer );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 4)&& translator.Assignable<System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>>(L, 5)) 
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    int count = LuaAPI.xlua_tointeger(L, 3);
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 4, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem> comparer = (System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>)translator.GetObject(L, 5, typeof(System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.BinarySearch( index, count, item, comparer );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.BinarySearch!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
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
        static int _m_Contains(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Contains( item );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyTo(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem[]>(L, 2)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem[] array = (xc.DBGrowSkin.DBGrowSkinItem[])translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem[]));
                    
                    __cl_gen_to_be_invoked.CopyTo( array );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem[]>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem[] array = (xc.DBGrowSkin.DBGrowSkinItem[])translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem[]));
                    int arrayIndex = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.CopyTo( array, arrayIndex );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    xc.DBGrowSkin.DBGrowSkinItem[] array = (xc.DBGrowSkin.DBGrowSkinItem[])translator.GetObject(L, 3, typeof(xc.DBGrowSkin.DBGrowSkinItem[]));
                    int arrayIndex = LuaAPI.xlua_tointeger(L, 4);
                    int count = LuaAPI.xlua_tointeger(L, 5);
                    
                    __cl_gen_to_be_invoked.CopyTo( index, array, arrayIndex, count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.CopyTo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exists(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Exists( match );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Find(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        xc.DBGrowSkin.DBGrowSkinItem __cl_gen_ret = __cl_gen_to_be_invoked.Find( match );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindAll(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_ret = __cl_gen_to_be_invoked.FindAll( match );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindIndex(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2)) 
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.FindIndex( match );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 3)) 
                {
                    int startIndex = LuaAPI.xlua_tointeger(L, 2);
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.FindIndex( startIndex, match );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 4)) 
                {
                    int startIndex = LuaAPI.xlua_tointeger(L, 2);
                    int count = LuaAPI.xlua_tointeger(L, 3);
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 4);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.FindIndex( startIndex, count, match );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.FindIndex!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindLast(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        xc.DBGrowSkin.DBGrowSkinItem __cl_gen_ret = __cl_gen_to_be_invoked.FindLast( match );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindLastIndex(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2)) 
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.FindLastIndex( match );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 3)) 
                {
                    int startIndex = LuaAPI.xlua_tointeger(L, 2);
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.FindLastIndex( startIndex, match );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 4)) 
                {
                    int startIndex = LuaAPI.xlua_tointeger(L, 2);
                    int count = LuaAPI.xlua_tointeger(L, 3);
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 4);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.FindLastIndex( startIndex, count, match );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.FindLastIndex!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForEach(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Action<xc.DBGrowSkin.DBGrowSkinItem> action = translator.GetDelegate<System.Action<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                    __cl_gen_to_be_invoked.ForEach( action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEnumerator(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.Enumerator __cl_gen_ret = __cl_gen_to_be_invoked.GetEnumerator(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    int count = LuaAPI.xlua_tointeger(L, 3);
                    
                        System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_ret = __cl_gen_to_be_invoked.GetRange( index, count );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IndexOf(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.IndexOf( item );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    int index = LuaAPI.xlua_tointeger(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.IndexOf( item, index );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    int index = LuaAPI.xlua_tointeger(L, 3);
                    int count = LuaAPI.xlua_tointeger(L, 4);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.IndexOf( item, index, count );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.IndexOf!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Insert(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 3, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    
                    __cl_gen_to_be_invoked.Insert( index, item );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InsertRange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem> collection = (System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem>)translator.GetObject(L, 3, typeof(System.Collections.Generic.IEnumerable<xc.DBGrowSkin.DBGrowSkinItem>));
                    
                    __cl_gen_to_be_invoked.InsertRange( index, collection );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LastIndexOf(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.LastIndexOf( item );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    int index = LuaAPI.xlua_tointeger(L, 3);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.LastIndexOf( item, index );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<xc.DBGrowSkin.DBGrowSkinItem>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    int index = LuaAPI.xlua_tointeger(L, 3);
                    int count = LuaAPI.xlua_tointeger(L, 4);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.LastIndexOf( item, index, count );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.LastIndexOf!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.DBGrowSkin.DBGrowSkinItem item = (xc.DBGrowSkin.DBGrowSkinItem)translator.GetObject(L, 2, typeof(xc.DBGrowSkin.DBGrowSkinItem));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.Remove( item );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAll(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.RemoveAll( match );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveAt( index );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveRange(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    int count = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.RemoveRange( index, count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reverse(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.Reverse(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    int count = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.Reverse( index, count );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.Reverse!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sort(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.Sort(  );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2)) 
                {
                    System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem> comparer = (System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>)translator.GetObject(L, 2, typeof(System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>));
                    
                    __cl_gen_to_be_invoked.Sort( comparer );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<System.Comparison<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2)) 
                {
                    System.Comparison<xc.DBGrowSkin.DBGrowSkinItem> comparison = translator.GetDelegate<System.Comparison<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                    __cl_gen_to_be_invoked.Sort( comparison );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>>(L, 4)) 
                {
                    int index = LuaAPI.xlua_tointeger(L, 2);
                    int count = LuaAPI.xlua_tointeger(L, 3);
                    System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem> comparer = (System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>)translator.GetObject(L, 4, typeof(System.Collections.Generic.IComparer<xc.DBGrowSkin.DBGrowSkinItem>));
                    
                    __cl_gen_to_be_invoked.Sort( index, count, comparer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>.Sort!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToArray(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        xc.DBGrowSkin.DBGrowSkinItem[] __cl_gen_ret = __cl_gen_to_be_invoked.ToArray(  );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TrimExcess(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.TrimExcess(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TrueForAll(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    System.Predicate<xc.DBGrowSkin.DBGrowSkinItem> match = translator.GetDelegate<System.Predicate<xc.DBGrowSkin.DBGrowSkinItem>>(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.TrueForAll( match );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Capacity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Capacity);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Count(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.Count);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Capacity(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem> __cl_gen_to_be_invoked = (System.Collections.Generic.List<xc.DBGrowSkin.DBGrowSkinItem>)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.Capacity = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
