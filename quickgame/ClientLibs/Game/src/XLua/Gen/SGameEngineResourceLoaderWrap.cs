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
    public class SGameEngineResourceLoaderWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			XUtils.BeginObjectRegister(typeof(SGameEngine.ResourceLoader), L, translator, 0, 17, 4, 3);
			
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "init", _m_init);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "load_prefab", _m_load_prefab);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadPrefabAsync", _m_LoadPrefabAsync);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "LoadAssetAsync", _m_LoadAssetAsync);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "load_asset", _m_load_asset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "try_load_asset_immediately", _m_try_load_asset_immediately);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "try_load_cached_asset", _m_try_load_cached_asset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "preload", _m_preload);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "load_scene", _m_load_scene);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "instantiate_prefab_from_asset_object", _m_instantiate_prefab_from_asset_object);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "get_bundle_num", _m_get_bundle_num);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "get_asset_num", _m_get_asset_num);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "wipe_file_sprit", _m_wipe_file_sprit);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "is_exist_asset", _m_is_exist_asset);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "download_remotefile", _m_download_remotefile);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Resources_Load", _m_Resources_Load);
			XUtils.RegisterFunc(L, XUtils.METHOD_IDX, "Resources_UnloadAsset", _m_Resources_UnloadAsset);
			
			
			XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "ServerBundleInfo", _g_get_ServerBundleInfo);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "AsyncID", _g_get_AsyncID);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "BundleVersion", _g_get_BundleVersion);
            XUtils.RegisterFunc(L, XUtils.GETTER_IDX, "sceneLoadAsyncOp", _g_get_sceneLoadAsyncOp);
            
			XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "ServerBundleInfo", _s_set_ServerBundleInfo);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "BundleVersion", _s_set_BundleVersion);
            XUtils.RegisterFunc(L, XUtils.SETTER_IDX, "sceneLoadAsyncOp", _s_set_sceneLoadAsyncOp);
            
			XUtils.EndObjectRegister(typeof(SGameEngine.ResourceLoader), L, translator, null, null,
			    null, null, null);

		    XUtils.BeginClassRegister(typeof(SGameEngine.ResourceLoader), L, __CreateInstance, 3, 2, 2);
			XUtils.RegisterFunc(L, XUtils.CLS_IDX, "safe_unload_res", _m_safe_unload_res_xlua_st_);
            
			
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "CACHE_STR_SCENE_ROOT", SGameEngine.ResourceLoader.CACHE_STR_SCENE_ROOT);
            
            XUtils.RegisterObject(L, translator, XUtils.CLS_IDX, "UnderlyingSystemType", typeof(SGameEngine.ResourceLoader));
			XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            XUtils.RegisterFunc(L, XUtils.CLS_GETTER_IDX, "EnableBundleInEditor", _g_get_EnableBundleInEditor);
            
			XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "Instance", _s_set_Instance);
            XUtils.RegisterFunc(L, XUtils.CLS_SETTER_IDX, "EnableBundleInEditor", _s_set_EnableBundleInEditor);
            
			XUtils.EndClassRegister(typeof(SGameEngine.ResourceLoader), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					SGameEngine.ResourceLoader __cl_gen_ret = new SGameEngine.ResourceLoader();
					translator.Push(L, __cl_gen_ret);
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to SGameEngine.ResourceLoader constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_init(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_load_prefab(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<SGameEngine.PrefabResource>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& translator.Assignable<UnityEngine.Transform>(L, 6)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    SGameEngine.PrefabResource _result = (SGameEngine.PrefabResource)translator.GetObject(L, 3, typeof(SGameEngine.PrefabResource));
                    bool _dont_destroy_on_load = LuaAPI.lua_toboolean(L, 4);
                    bool _cache_global_bundle = LuaAPI.lua_toboolean(L, 5);
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 6, typeof(UnityEngine.Transform));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_prefab( _asset_path, _result, _dont_destroy_on_load, _cache_global_bundle, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<SGameEngine.PrefabResource>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    SGameEngine.PrefabResource _result = (SGameEngine.PrefabResource)translator.GetObject(L, 3, typeof(SGameEngine.PrefabResource));
                    bool _dont_destroy_on_load = LuaAPI.lua_toboolean(L, 4);
                    bool _cache_global_bundle = LuaAPI.lua_toboolean(L, 5);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_prefab( _asset_path, _result, _dont_destroy_on_load, _cache_global_bundle );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<SGameEngine.PrefabResource>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    SGameEngine.PrefabResource _result = (SGameEngine.PrefabResource)translator.GetObject(L, 3, typeof(SGameEngine.PrefabResource));
                    bool _dont_destroy_on_load = LuaAPI.lua_toboolean(L, 4);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_prefab( _asset_path, _result, _dont_destroy_on_load );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<SGameEngine.PrefabResource>(L, 3)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    SGameEngine.PrefabResource _result = (SGameEngine.PrefabResource)translator.GetObject(L, 3, typeof(SGameEngine.PrefabResource));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_prefab( _asset_path, _result );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to SGameEngine.ResourceLoader.load_prefab!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadPrefabAsync(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Action<UnityEngine.GameObject> call_back = translator.GetDelegate<System.Action<UnityEngine.GameObject>>(L, 3);
                    
                    __cl_gen_to_be_invoked.LoadPrefabAsync( asset_path, call_back );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAssetAsync(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Action<SGameEngine.AssetResource> call_back = translator.GetDelegate<System.Action<SGameEngine.AssetResource>>(L, 3);
                    
                    __cl_gen_to_be_invoked.LoadAssetAsync( asset_path, call_back );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_load_asset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 7&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<SGameEngine.AssetResource>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& (LuaAPI.lua_isnil(L, 7) || LuaAPI.lua_type(L, 7) == LuaTypes.LUA_TSTRING)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Type _type = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    SGameEngine.AssetResource _result = (SGameEngine.AssetResource)translator.GetObject(L, 4, typeof(SGameEngine.AssetResource));
                    bool _lock_asset = LuaAPI.lua_toboolean(L, 5);
                    bool _scene_asset = LuaAPI.lua_toboolean(L, 6);
                    string _scene_name = LuaAPI.lua_tostring(L, 7);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_asset( _asset_path, _type, _result, _lock_asset, _scene_asset, _scene_name );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<SGameEngine.AssetResource>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Type _type = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    SGameEngine.AssetResource _result = (SGameEngine.AssetResource)translator.GetObject(L, 4, typeof(SGameEngine.AssetResource));
                    bool _lock_asset = LuaAPI.lua_toboolean(L, 5);
                    bool _scene_asset = LuaAPI.lua_toboolean(L, 6);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_asset( _asset_path, _type, _result, _lock_asset, _scene_asset );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<SGameEngine.AssetResource>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Type _type = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    SGameEngine.AssetResource _result = (SGameEngine.AssetResource)translator.GetObject(L, 4, typeof(SGameEngine.AssetResource));
                    bool _lock_asset = LuaAPI.lua_toboolean(L, 5);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_asset( _asset_path, _type, _result, _lock_asset );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<SGameEngine.AssetResource>(L, 4)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Type _type = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    SGameEngine.AssetResource _result = (SGameEngine.AssetResource)translator.GetObject(L, 4, typeof(SGameEngine.AssetResource));
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_asset( _asset_path, _type, _result );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to SGameEngine.ResourceLoader.load_asset!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_try_load_asset_immediately(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<SGameEngine.AssetResource>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Type _type = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    SGameEngine.AssetResource _result = (SGameEngine.AssetResource)translator.GetObject(L, 4, typeof(SGameEngine.AssetResource));
                    bool _lock_asset = LuaAPI.lua_toboolean(L, 5);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.try_load_asset_immediately( _asset_path, _type, _result, _lock_asset );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Type>(L, 3)&& translator.Assignable<SGameEngine.AssetResource>(L, 4)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    System.Type _type = (System.Type)translator.GetObject(L, 3, typeof(System.Type));
                    SGameEngine.AssetResource _result = (SGameEngine.AssetResource)translator.GetObject(L, 4, typeof(SGameEngine.AssetResource));
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.try_load_asset_immediately( _asset_path, _type, _result );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to SGameEngine.ResourceLoader.try_load_asset_immediately!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_try_load_cached_asset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Object __cl_gen_ret = __cl_gen_to_be_invoked.try_load_cached_asset( _asset_path );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_preload(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    int _life_time = LuaAPI.xlua_tointeger(L, 3);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.preload( _asset_path, _life_time );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _asset_path = LuaAPI.lua_tostring(L, 2);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.preload( _asset_path );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to SGameEngine.ResourceLoader.preload!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_load_scene(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string scene_asset_path = LuaAPI.lua_tostring(L, 2);
                    string scene_level_name = LuaAPI.lua_tostring(L, 3);
                    SGameEngine.ResourceLoader.on_load_scene _before_load_scene = translator.GetDelegate<SGameEngine.ResourceLoader.on_load_scene>(L, 4);
                    
                        System.Collections.IEnumerator __cl_gen_ret = __cl_gen_to_be_invoked.load_scene( scene_asset_path, scene_level_name, _before_load_scene );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_instantiate_prefab_from_asset_object(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 3&& translator.Assignable<SGameEngine.AssetResource>(L, 2)&& translator.Assignable<UnityEngine.Transform>(L, 3)) 
                {
                    SGameEngine.AssetResource _asset = (SGameEngine.AssetResource)translator.GetObject(L, 2, typeof(SGameEngine.AssetResource));
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 3, typeof(UnityEngine.Transform));
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.instantiate_prefab_from_asset_object( _asset, parent );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<SGameEngine.AssetResource>(L, 2)) 
                {
                    SGameEngine.AssetResource _asset = (SGameEngine.AssetResource)translator.GetObject(L, 2, typeof(SGameEngine.AssetResource));
                    
                        UnityEngine.GameObject __cl_gen_ret = __cl_gen_to_be_invoked.instantiate_prefab_from_asset_object( _asset );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to SGameEngine.ResourceLoader.instantiate_prefab_from_asset_object!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_get_bundle_num(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.get_bundle_num(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_get_asset_num(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.get_asset_num(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_safe_unload_res_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.Object _obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    SGameEngine.ResourceLoader.safe_unload_res( _obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_wipe_file_sprit(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string bundle_url = LuaAPI.lua_tostring(L, 2);
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.wipe_file_sprit( bundle_url );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_is_exist_asset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string asset_path = LuaAPI.lua_tostring(L, 2);
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.is_exist_asset( asset_path );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_download_remotefile(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string url = LuaAPI.lua_tostring(L, 2);
                    SGameEngine.ResourceLoader.OnRemoteFileDownload fileDownloaded = translator.GetDelegate<SGameEngine.ResourceLoader.OnRemoteFileDownload>(L, 3);
                    
                    __cl_gen_to_be_invoked.download_remotefile( url, fileDownloaded );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Resources_Load(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string filePath = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Object __cl_gen_ret = __cl_gen_to_be_invoked.Resources_Load( filePath );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Resources_UnloadAsset(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    UnityEngine.Object res = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    
                    __cl_gen_to_be_invoked.Resources_UnloadAsset( res );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerBundleInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.ServerBundleInfo);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AsyncID(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, __cl_gen_to_be_invoked.AsyncID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    translator.Push(L, SGameEngine.ResourceLoader.Instance);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BundleVersion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, __cl_gen_to_be_invoked.BundleVersion);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sceneLoadAsyncOp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.sceneLoadAsyncOp);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnableBundleInEditor(RealStatePtr L)
        {
            
            try {
			    LuaAPI.lua_pushboolean(L, SGameEngine.ResourceLoader.EnableBundleInEditor);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ServerBundleInfo(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.ServerBundleInfo = (SGameFirstPass.AssetBundleInfoRuntime)translator.GetObject(L, 2, typeof(SGameFirstPass.AssetBundleInfoRuntime));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Instance(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			    SGameEngine.ResourceLoader.Instance = (SGameEngine.ResourceLoader)translator.GetObject(L, 1, typeof(SGameEngine.ResourceLoader));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BundleVersion(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.BundleVersion = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sceneLoadAsyncOp(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                SGameEngine.ResourceLoader __cl_gen_to_be_invoked = (SGameEngine.ResourceLoader)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.sceneLoadAsyncOp = (UnityEngine.AsyncOperation)translator.GetObject(L, 2, typeof(UnityEngine.AsyncOperation));
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EnableBundleInEditor(RealStatePtr L)
        {
            
            try {
			    SGameEngine.ResourceLoader.EnableBundleInEditor = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
