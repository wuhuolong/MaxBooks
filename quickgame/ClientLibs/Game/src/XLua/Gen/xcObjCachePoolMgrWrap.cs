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
    public class xcObjCachePoolMgrWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(xc.ObjCachePoolMgr), L, translator, 0, 7, 0, 0);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RecycleCSharpObject", _m_RecycleCSharpObject);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadPrefabAsync", _m_LoadPrefabAsync);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadPrefab", _m_LoadPrefab);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RecyclePrefab", _m_RecyclePrefab);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadFromCache", _m_LoadFromCache);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "OnDestroyScene", _m_OnDestroyScene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "RemoveFromCachePool", _m_RemoveFromCachePool);
			
			
			
			
			XUtils.EndObjectRegister(typeof(xc.ObjCachePoolMgr), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(xc.ObjCachePoolMgr), L, __CreateInstance, 1, 1, 0);
			
			
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(xc.ObjCachePoolMgr));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			XUtils.EndClassRegister(typeof(xc.ObjCachePoolMgr), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					xc.ObjCachePoolMgr __cl_gen_ret = new xc.ObjCachePoolMgr();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ObjCachePoolMgr constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecycleCSharpObject(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ObjCachePoolMgr __cl_gen_to_be_invoked = (xc.ObjCachePoolMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    object obj = translator.GetObject(L, 2, typeof(object));
                    xc.ObjCachePoolType poolType;translator.Get(L, 3, out poolType);
                    string poolKey = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.RecycleCSharpObject( obj, poolType, poolKey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefabAsync(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ObjCachePoolMgr __cl_gen_to_be_invoked = (xc.ObjCachePoolMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string assetPath = LuaAPI.lua_tostring(L, 2);
                    xc.ObjCachePoolType poolType;translator.Get(L, 3, out poolType);
                    string poolKey = LuaAPI.lua_tostring(L, 4);
                    System.Action<object> callBack = translator.GetDelegate<System.Action<object>>(L, 5);
                    
                    __cl_gen_to_be_invoked.LoadPrefabAsync( assetPath, poolType, poolKey, callBack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefab(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ObjCachePoolMgr __cl_gen_to_be_invoked = (xc.ObjCachePoolMgr)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ObjCachePoolType>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<object>>(L, 5)) 
                {
                    string assetPath = LuaAPI.lua_tostring(L, 2);
                    xc.ObjCachePoolType poolType;translator.Get(L, 3, out poolType);
                    string poolKey = LuaAPI.lua_tostring(L, 4);
                    System.Action<object> callBack = translator.GetDelegate<System.Action<object>>(L, 5);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.LoadPrefab( assetPath, poolType, poolKey, callBack );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ObjCachePoolType>(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& translator.Assignable<xc.ObjectWrapper>(L, 5)) 
                {
                    string assetPath = LuaAPI.lua_tostring(L, 2);
                    xc.ObjCachePoolType poolType;translator.Get(L, 3, out poolType);
                    string poolKey = LuaAPI.lua_tostring(L, 4);
                    xc.ObjectWrapper prefab = (xc.ObjectWrapper)translator.GetObject(L, 5, typeof(xc.ObjectWrapper));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.LoadPrefab( assetPath, poolType, poolKey, prefab );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ObjCachePoolMgr.LoadPrefab!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecyclePrefab(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ObjCachePoolMgr __cl_gen_to_be_invoked = (xc.ObjCachePoolMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    xc.ObjCachePoolType poolType;translator.Get(L, 3, out poolType);
                    string poolKey = LuaAPI.lua_tostring(L, 4);
                    
                    __cl_gen_to_be_invoked.RecyclePrefab( obj, poolType, poolKey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadFromCache(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ObjCachePoolMgr __cl_gen_to_be_invoked = (xc.ObjCachePoolMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ObjCachePoolType poolType;translator.Get(L, 2, out poolType);
                    string poolKey = LuaAPI.lua_tostring(L, 3);
                    
                        object __cl_gen_ret = __cl_gen_to_be_invoked.LoadFromCache( poolType, poolKey );
                        translator.PushAny(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroyScene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ObjCachePoolMgr __cl_gen_to_be_invoked = (xc.ObjCachePoolMgr)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool clearUI = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.OnDestroyScene( clearUI );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1) 
                {
                    
                    __cl_gen_to_be_invoked.OnDestroyScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to xc.ObjCachePoolMgr.OnDestroyScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveFromCachePool(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            xc.ObjCachePoolMgr __cl_gen_to_be_invoked = (xc.ObjCachePoolMgr)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    xc.ObjCachePoolType poolType;translator.Get(L, 2, out poolType);
                    string poolKey = LuaAPI.lua_tostring(L, 3);
                    object obj = translator.GetObject(L, 4, typeof(object));
                    
                    __cl_gen_to_be_invoked.RemoveFromCachePool( poolType, poolKey, obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, xc.ObjCachePoolMgr.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
