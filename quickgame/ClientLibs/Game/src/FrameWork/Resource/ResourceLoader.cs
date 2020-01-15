//************************************
//  ResourceLoader.cs
//  The resouce loader, all reources should be loaded using this interface
//  Created by leon @INCEPTION .
//  Last modify 14-12-24 : add pool
//************************************

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
#if UNITY_EDITOR
using System.Reflection;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using SGameEngine;
using SGameFirstPass;
using xc;

namespace SGameEngine
{
    public class ResourceLoader : MonoBehaviour
    {
        /////////////////////////////////////////public properties/////////////////////////////////////////
        public static ResourceLoader Instance;
        public AssetBundleInfoRuntime ServerBundleInfo { get; set; } //包含所有bundle信息
        public int BundleVersion; // 当前获取到的bundle的版本号

        public delegate void on_load_scene(); //the callback after load a scene
        public AsyncOperation sceneLoadAsyncOp;
        #if UNITY_EDITOR
        private HashSet<string> allResCfged = new HashSet<string>();
        #endif

        /// <summary>
        /// 是否在编辑器下开启assetbundel资源的加载
        /// </summary>
        public static bool EnableBundleInEditor = false;

        /// <summary>
        /// 是否已经对全局的assetbundle进行了缓存
        /// </summary>
        Dictionary<string, bool> mGlobalCache = new Dictionary<string, bool>();

        /////////////////////////////////////////public interfaces/////////////////////////////////////////
        /// 
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                Debug.LogError("resource loader is inited twice!");
                return;
            }

            Instance = this;

            #if UNITY_EDITOR
            // 获取需要打包的资源信息
            Assembly editorAssembly = Assembly.Load("Assembly-CSharp-Editor");
            Type cfg = editorAssembly.GetType ("SGameBundleMaker.BundleResourceCfg");
            MethodInfo methodInf = cfg.GetMethod ("collect", BindingFlags.Static | BindingFlags.Public);
            methodInf.Invoke(null,new System.Object[]{allResCfged});

            //foreach (System.Object o in allResCfged)
            //    Debug.Log(o.ToString());
            #endif

        }

        //init this module, this module should only be init once before any resouce loaded
        public void init()
        {
            if (is_inited_)
            {
                return;
            }
            is_inited_ = true;

            bundleobj_cache_.init();

            //对于内存低于1G的机器，gc的时间减少为20s
            if (SystemInfo.systemMemorySize <= 1024)
                GC_INTERVAL = 20;
            else
                GC_INTERVAL = 60;

            //reg gc update
            InvokeRepeating("gc",GC_INTERVAL,GC_INTERVAL);
            //check the died locks
            InvokeRepeating("check_dead_lock_coroutine", 1f, 1f);
        }

        /// <summary>
        /// <para>加载prefab并进行实例化，实例化后的GameObject会添加到dic_gameobj_asset_中</para>
        /// <para>调用gc时如果GameObject实例已经销毁，则会自动减少对应AssetObject的引用计数</para>
        /// <para>创建后返回的GameObject最好不要再进行Clone，因为GameObject被销毁后，Clone的实例资源也可能丢失</para>
        /// </summary>
		public IEnumerator load_prefab(string _asset_path, PrefabResource _result, bool _dont_destroy_on_load = false, bool _cache_global_bundle = false, Transform parent = null)
        {
            if (Const.Language != LanguageType.SIMPLE_CHINESE)
                LocalizeManager.Instance.LocalizePath(ref _asset_path);

            if (is_destroyed_)
            {
                yield break;
            }
            string lower_case = _asset_path.ToLower();
            if (!lower_case.EndsWith(CACHE_STR_PREFAB))
            {
                Debug.LogError(string.Format("{0} is not a prefab!", lower_case));
                yield break;
            }

            //1. lock the asset
            //do nothing

            //2. load asset and instantiate prefab
            AssetResource ar = new AssetResource();
            yield return StartCoroutine(load_asset(_asset_path, type_game_object_, ar));
            if (ar.asset_ != null)
            {
                /*if(_asset_path.Contains("/Res/UI/") && !_asset_path.Contains("/Res/UI/Atlas/") && _asset_path.EndsWith(".prefab"))
				{
					yield return StartCoroutine(load_atlas(ar));
				}*/

				_result.obj_ = instantiate_prefab_from_asset_object(ar, parent);
				if(_dont_destroy_on_load)
				{
					GameObject.DontDestroyOnLoad(_result.obj_);
				}
                //adjust the gameobject postion to not be seen directly
                (_result.obj_ as GameObject).transform.position = new Vector3(-100, -1000, -100);
            }
            //3.已经在instantiate_prefab_from_asset_object进行了实例化，可以释放AssetResource对AssetObject的引用
            if(!_cache_global_bundle)
            {
                ar.destroy();
            }
            else
            {
                if (mGlobalCache.ContainsKey(_asset_path))
                {
                    ar.destroy();
                }
                else
                {
                    mGlobalCache[_asset_path] = true;
                }
            }

            //4.unlock asset
            //do nothing
        }

        /// <summary>
        /// 加载一系列bundle，可能因为其他协程正在加载某一bundle而该加载失败
        /// </summary>
        private IEnumerator try_load_bundle_list_coroutine(List<string> _asset_list, List<BundleObject> _bundles, List<string> _fail_list, bool is_ui_asset)
        {
            HashSet<string> lock_set = new HashSet<string>();
            Queue<string> task_queue = new Queue<string>();

            // 按顺序加载bundle
            foreach (string path in _asset_list)
            {
                if(!bundleobj_cache_.is_in_cache(path))
                {
                    if (bundle_lock_.is_locked(path))
                    {
                        _fail_list.Add(path);
                    }
                    else
                    {
                        bundle_lock_.try_lock(path);
                        lock_set.Add(path);
                        IEnumerator task = load_bundle_from_disk_coroutine(path, _bundles, is_ui_asset);
                        task_queue.Enqueue(path);
                        StartCoroutine(task);
                    }
                }
                else
                {
                    load_bundle_from_cache(path, _bundles);
                }
            }

            // 等待加载全部完成
            while (task_queue.Count > 0)
            {
                string task = task_queue.Peek();
                if(bundleobj_cache_.is_in_cache(task))
                {
                    task_queue.Dequeue();
                }
                else
                {
                    yield return new WaitForEndOfFrame();
                }
            }

            // bundle解锁
            foreach (string path in _asset_list)
            {
                if (lock_set.Contains(path))
                {
                    bundle_lock_.unlock(path);
                }
            }
        }

        /// <summary>
        /// 加载路径下的资源文件，完成后调用指定的回调函数(用于加载prefab等序列化的资源)
        /// 注意: 创建后返回的GameObject最好不要再进行Clone，因为GameObject被销毁后，Clone的实例资源也可能丢失
        /// </summary>
        /// <param name="assetPath"></param>
        /// <param name="poolType"></param>
        /// <param name="poolKey"></param>
        /// <param name="callBack"></param>
        public void LoadPrefabAsync(string asset_path, System.Action<GameObject> call_back)
        {
            StartCoroutine(LoadPrefabImpl(asset_path, call_back));        
        }

        IEnumerator LoadPrefabImpl(string asset_path, System.Action<GameObject> call_back)
        {
            PrefabResource prefab_res = new PrefabResource();
            yield return StartCoroutine(load_prefab(asset_path, prefab_res));
            if (call_back != null)
                call_back(prefab_res.obj_);
        }

        /// <summary>
        /// 异步加载的唯一ID
        /// </summary>
        uint mAsyncId = 0;

        /// <summary>
        /// 获取当前异步加载的唯一ID
        /// </summary>
        public uint AsyncID
        {
            get
            {
                return mAsyncId;
            }
        }

        /// <summary>
        /// 加载路径下的资源文件，完成后调用指定的回调函数(用于加载图片等非序列化的资源)
        /// </summary>
        /// <param name="assetPath"></param>
        /// <param name="call_back"></param>
        public void LoadAssetAsync(string asset_path, System.Action<AssetResource> call_back)
        {
            StartCoroutine(LoadAssetImpl(asset_path, call_back));

            // 异步加载的ID递增(NextID)
            mAsyncId = (mAsyncId+1) % uint.MaxValue;
        }

        private IEnumerator LoadAssetImpl(string asset_path, System.Action<AssetResource> call_back)
        {
            AssetResource ar = new AssetResource();
            yield return StartCoroutine(load_asset(asset_path, typeof(UnityEngine.Object), ar, false, false, string.Empty));
            if (call_back != null)
                call_back(ar);
        }

        /// <summary>
        /// <para>加载UnityEngine.Object资源，资源不再使用后要调用AssetResource.Destroy()来销毁</para>
        /// <para>_asset_path:资源路径,eg: "Assets/Res/DefaultRes.prefab"</para>
        /// <para>_type:加载资源的类型</para>
        /// <para>_result:协程结束后返回加载资源的结果</para>
        /// <para>_lock_asset:为避免其他协程加载资源，是否进行锁定操作</para>
        /// <para>_scene_asset:是否是场景资源</para>
        /// <para>_scene_name:场景资源的名字</para>
        /// </summary>
        public IEnumerator load_asset(string _asset_path, Type _type, AssetResource _result, bool _lock_asset = true, bool _scene_asset = false, string _scene_name = "")
        {
            if (is_destroyed_)
            {
                yield break;
            }

            bool is_ui_asset = _asset_path.Contains("Assets/Res/UI");

            if (Const.Language != LanguageType.SIMPLE_CHINESE)
                LocalizeManager.Instance.LocalizePath(ref _asset_path);

#if UNITY_EDITOR
            // 在编辑器下检查资源是否添加到打包配置中(因为lightmap的bug,.unity3d场景暂时不进行资源检查)
            if(!CheckAssetCfged(_asset_path))
            {
                Debug.LogError(string.Format("asset {0} is not configured for bundle, load failed!", _asset_path));
                yield break;
            }
#endif

            if (_result.get_obj() != null)
            {
                Debug.LogError("resused an old assetresoure! you should create a new!");
                yield break;
            }
            //1. 等待first res加载完毕，其中包含bundleinfo
            while(!bundleobj_cache_.is_first_resource_loaded())
            {
                yield return new WaitForEndOfFrame();
            }
            loading_ = true;

            // 检查资源对应的分包是否已经下载完毕
            int patch_id;
            if (!xpatch.XPatchManager.Instance.IsAssetDownloaded(_asset_path, out patch_id))
            {
                Debug.Log(string.Format("asset {0} is not download for bundle!", _asset_path));
                yield break;
            }

            //2. 锁定资源，避免加载同一份asset
            IEnumerator	ielock = null;
            if (_lock_asset )
            {
				if(!asset_lock_.try_lock(_asset_path))
				{
					ielock = asset_lock_.try_lock_croutine(_asset_path);
					coroutine_locked_assets_.Add(ielock, _asset_path);
					yield return StartCoroutine(ielock);
				}
            }

            //3. 检查Cache中是否已经有对应的bundle，否则需要进行加载
            AssetObject found_obj = assetobj_cache_.get_from_cache(_asset_path);
            if (found_obj != null)
            {
                _result.set_obj(found_obj);
                if (_scene_asset)
                {
                    //load level
                    sceneLoadAsyncOp = SceneManager.LoadSceneAsync(_scene_name);
                    yield return sceneLoadAsyncOp;
                }
            }
            else
            {
#if UNITY_EDITOR
                if (!EnableBundleInEditor)
                {
                    //editor enviroment
                    yield return StartCoroutine(load_asset_from_assetdatabase(_asset_path, _type, _result, _lock_asset, _scene_asset, _scene_name));
                }
                else
#endif
                {
                    //bundle enviroment
                    //4.从bundleinfo中获取asset的依赖项
                    AssetBundleInfoItem bundle_info = bundleobj_cache_.get_asset_bundle_info(_asset_path);
                    if (bundle_info == null)
                    {
                        Debug.LogError("Dynamic bundle not find!Editor path is " + _asset_path);
                        goto EXIT_LOAD_ASSET;
                    }
                    UnityEngine.Object loaded_asset = null;
                    List<BundleObject> all_bundles = new List<BundleObject>();

                    List<List<string>> sort_depends_list = bundleobj_cache_.get_asset_all_dependence(_asset_path);
                    foreach (List<string> sub_list in sort_depends_list)
                    {
                        // 先判断是否在Cache中
                        if (bundleobj_cache_.is_all_in_cache(sub_list))
                        {
                            foreach (string path in sub_list)
                            {
                                load_bundle_from_cache(path, all_bundles);
                            }
                        }
                        else
                        {
                            List<string> fail_list = new List<string>();
                            yield return StartCoroutine(try_load_bundle_list_coroutine(sub_list, all_bundles, fail_list,is_ui_asset));

                            //被其他协程锁定的bundle等待解锁后再进行加载
                            foreach (string depend_bundle_path in fail_list)
                            {
                                //lock
                                if (!bundle_lock_.try_lock(depend_bundle_path))
                                {
                                    yield return StartCoroutine(bundle_lock_.try_lock_croutine(depend_bundle_path));
                                }
                                //load bundle and add ref
                                if (!load_bundle_from_cache(depend_bundle_path, all_bundles))
                                {
                                    yield return StartCoroutine(load_bundle_from_disk_coroutine(depend_bundle_path, all_bundles,is_ui_asset));
                                }
                                //unlock
                                bundle_lock_.unlock(depend_bundle_path);
                            }
                        }
                    }

                    //5.锁定asset并进行加载
                    if (!bundle_lock_.try_lock(_asset_path))
                    {
                        yield return StartCoroutine(bundle_lock_.try_lock_croutine(_asset_path));
                    }
                    //load bundle and add ref
                    if (!load_bundle_from_cache(_asset_path, all_bundles))
                    {
                        yield return StartCoroutine(load_bundle_from_disk_coroutine(_asset_path, all_bundles,is_ui_asset));
                    }
                    //unlock
                    bundle_lock_.unlock(_asset_path);

                    if (all_bundles.Count < 1)
                    {
                        goto EXIT_LOAD_ASSET;
                    }

                    //6.从bundle中加载mainasset
                    // 在调用Bundle.Load()之前，需要将缓存所有的依赖bundle
                    if (!_scene_asset)
                    {
                        BundleObject root = all_bundles[all_bundles.Count - 1];
                        // 获取在bundle中的资源名字
                        /*string asset_name = root.get_asset_path_;
                        int last_path_idx = asset_name.LastIndexOf('/');
                        if(last_path_idx != -1)
                            asset_name = asset_name.Substring(last_path_idx + 1);
                        last_path_idx = asset_name.LastIndexOf('.');
                        if (last_path_idx != -1)
                            asset_name = asset_name.Substring(0, last_path_idx);*/

                        //loaded_asset = bundleobj_cache_.load_main_asset(root.get_asset_bundle_, _type, BundleNameDef.MAIN);
                        var loadReq = root.get_asset_bundle_.LoadAssetAsync(BundleNameDef.MAIN, _type);
                        yield return loadReq;

                        loaded_asset = loadReq.asset;

                        if (loaded_asset == null)
                        {
                            Debug.LogError(string.Format("asset counld not be loaded {0} ,check xls or your project", _asset_path));
                            // 加载失败后要将依赖的bundle的引用计数减少
                            foreach (BundleObject bo in all_bundles)
                            {
                                bo.decrease_ref();// 因为load bundle的时候增加了引用计数，所以此处需要减少
                            }
                            goto EXIT_LOAD_ASSET;
                        }
                    }
                    // 场景资源在缓存bundle之后就可以使用
                    else
                    {
                        sceneLoadAsyncOp = SceneManager.LoadSceneAsync(_scene_name);
                        yield return sceneLoadAsyncOp;
                    }

                    //7. 创建assetobject并添加到Cache中
                    AssetObject ao = _scene_asset ? new SceneAssetObject(_asset_path) : new AssetObject(_asset_path, loaded_asset);
                    foreach (BundleObject bo in all_bundles)
                    {
                        AssetBundleInfoItem bundle_item_depend = bundleobj_cache_.get_asset_bundle_info(bo.get_asset_path_);
                        bool shared = bundle_item_depend.shared;
                        // 当assetbundle不被多个资源引用时，可以立即将assetbundle的文件镜像卸载，并从Cache中清除
                        // Atlas经过特殊处理，虽然被多个资源引用，但是也会立即卸载

                        /// FIXME
                        /// 在2017版本中，此时unload assetbundle会报错
                        /*if(!shared)
                        {
                            bo.destroy(false);
                            bundleobj_cache_.remove_bundle_object_from_cache(bo.get_asset_path_);
                        }
                        else*/
                        {
                            ao.add_depend_bundle(bo);
                        }
                        bo.decrease_ref();//decrease the ref added by load bundle
                    }
                    all_bundles.Clear();
                    assetobj_cache_.put_to_cache(_asset_path, ao);
                    _result.set_obj(ao);
                }
            }
            //9.unlock asset
            EXIT_LOAD_ASSET:
            //unlock
            if (_lock_asset)
            {
                if (ielock != null)
                {
                    coroutine_locked_assets_.Remove(ielock);
                }
                asset_lock_.unlock(_asset_path);
            }

            loading_ = false;
        }

		//************************************
		// Method:   try load a general asset (any type inherited from UnityEngine.Object)
		//Notice :    this will quickly load an asset if it already in cache, but it may fail
		//************************************
		public bool try_load_asset_immediately(string _asset_path, Type _type, AssetResource _result, bool _lock_asset = true)
		{
			if (is_destroyed_)
			{
				return false;
			}
			if (_result.get_obj() != null)
			{
				Debug.LogError("resused an old assetresoure! you should create a new!");
				return false;
			}
			if(!bundleobj_cache_.is_first_resource_loaded())
			{
				return false;
			}

			if (_lock_asset )
			{
				if(asset_lock_.is_locked(_asset_path))
				{
					return false;
				}
			}

			AssetObject found_obj = assetobj_cache_.get_from_cache(_asset_path);
			if (found_obj != null)
			{
				_result.set_obj(found_obj);
			}
			else
			{  
				return false;
			}

			return true;
		}
		
		//************************************
		// Method:   try load an asset from cache
		// you shoul preload the asset in advance, the returned object maybe released if the preload time is not long enough
		//Return Object 
		//Paramater string _assets_path: the asset path. eg. "Assets/Art/a.mat"
		//************************************
		public UnityEngine.Object try_load_cached_asset(string _asset_path)
		{

			AssetObject found_obj = assetobj_cache_.get_from_cache(_asset_path);
			if (found_obj != null)
			{
				return found_obj.get_obj_;
			}
			else
			{
				return null;
			} 
		}
		
		//************************************
		// Method:  preload an asset, and keep in the cache for some seconds, sothat you can load it quickly without loading from bundle next time
		//Return IEnumerator : when the iemurrator ends, the asset loaded 
		//Paramater string _asset_path: the asset path. eg. "Assets/Art/a.mat"
		//Paramater int _life_time: the time(in seconds) this asset keep in cache, it will be asured during this time, the asset will not destroyed from cache. a negitive (< 0 ) value implies infinite.
		//************************************
		public IEnumerator preload(string _asset_path, int _life_time = 30)
		{
			if (is_destroyed_)
			{
				yield break;
			}
			AssetResource ar = new AssetResource();
			yield return StartCoroutine(load_asset(_asset_path, typeof(UnityEngine.Object), ar));
			if (_life_time > 0)
			{
				yield return new WaitForSeconds(_life_time);
				ar.destroy();
			}
			// <0 = forever !
		}

        /// <summary>
        /// <para>加载场景资源</para>
        /// <para>_asset_path:场景资源路径，eg:"Assets/Res/Map/Scenes/start.unity"</para>
        /// <para>is_dynamic:是否是动态加载的场景</para>
        /// </summary>
        // <para>int _life_time: the time(in seconds) this asset keep in cache, it will be asured during this time, the asset will not destroyed from cache. a negitive (< 0 ) value implies infinite.</para>
        public IEnumerator load_scene(string scene_asset_path, string scene_level_name, on_load_scene _before_load_scene)
        {
            if (is_destroyed_)
            {
                yield break;
            }

            // 设置加载的线程优先级
            float start_time = Time.realtimeSinceStartup;
            // 取消帧率限制
            Application.targetFrameRate = Const.MAX_FPS;

            sceneLoadAsyncOp = null;
            //clear_prefab_pool_caches(_scene_id);
            current_scene_asset_.destroy();

            // unload bundle
            while (is_gcing_ == true)
            {
                yield return null;
            }
            yield return StartCoroutine(gc_coroutine());
            // unload some wild asset
            //AsyncOperation asynco = Resources.UnloadUnusedAssets();
            //yield return asynco;

            if (_before_load_scene != null)
            {
                _before_load_scene();
            }

            //为了优化登录，将额外资源的预加载放在加载场景前进行
            yield return StartCoroutine(MainGame.PreloadExtra());

            // 从bundle加载场景，并LoadLevel
            yield return StartCoroutine(load_asset(scene_asset_path, typeof(UnityEngine.Object), current_scene_asset_, true, true, scene_level_name));

            // system gc
            //System.GC.Collect();

            // 恢复加载的线程优先级
            float cost_time = Time.realtimeSinceStartup - start_time;
            Debug.Log(string.Format("load scene {0} cost: {1}",scene_level_name,cost_time));
            // 恢复帧率
            //Application.targetFrameRate = Const.G_FPS;
        }

        /// <summary>
        /// 将_asset中的Object实例化成GameObject
        /// 实例化后并增加AssetResource的引用计数
        /// </summary>
		public GameObject instantiate_prefab_from_asset_object(AssetResource _asset, Transform parent = null)
		{
			AssetObject ao = _asset.get_obj();
            GameObject go = null;
            if(parent != null)
                go = GameObject.Instantiate(ao.get_obj_, parent) as GameObject;
            else
                go = GameObject.Instantiate(ao.get_obj_) as GameObject;

            ao.add_ref();
            dic_gameobj_asset_.Add(new xc.Tuple<GameObject, AssetObject>(go, ao));
			return go;
		}

        //for statics
        public int get_bundle_num()
        {
            return bundleobj_cache_.get_bundles_count();
        }

        public int get_asset_num()
        {
            return assetobj_cache_.get_asset_count();
        }

        /// <summary>
        /// 销毁Object
        /// </summary>
        public static void safe_unload_res(UnityEngine.Object _obj)
        {
            if (_obj == null)
            {
                return;
            }
            if (!(_obj is GameObject))
            {
#if UNITY_EDITOR
                if (!EnableBundleInEditor)
                {
                    if (!(_obj is ScriptableObject))
                    {
                        Resources.UnloadAsset(_obj);
                    }
                }
                else
#endif
                {
                    GameObject.DestroyImmediate(_obj, true);
                }
            }
            else
            {
#if UNITY_EDITOR
                if (!EnableBundleInEditor)
                {
                    // for a Gameobject, no need to clear the uninstantiate mem ,cause :
                    // 1. it alloc little extra mem unlike the instantiate ones, 
                    // 2. the assetbundle`s unload and unusedasset ()will destroy  it
                }
                else
#endif
                {
                    GameObject.DestroyImmediate(_obj, true);
                }
            }
        }

        #region editor only function
        [XLua.BlackList]
        public AssetObjectCache GetEditorAssetCache()
        {
            return assetobj_cache_;
        }
        [XLua.BlackList]
        public BundleObjectCache GetEditorBundleObjectCache()
        {
            return bundleobj_cache_;
        }
        [XLua.BlackList]
        public List<xc.Tuple<GameObject, AssetObject>> GetEditorDicGameobjAsset()
        {
            return dic_gameobj_asset_;
        }
        #endregion

        ////////////////////////////////////////private members /////////////////////////////////////////
        private static Type type_game_object_ = typeof(GameObject); //cache this type
        private static bool is_inited_ = false;
		private static bool is_gcing_ = false; //in gc status
		private static bool loading_ = false; //in loading a asset
		private static bool is_destroyed_ = false;
		

		private static AssetObjectCache assetobj_cache_ = new AssetObjectCache();
		private static BundleObjectCache bundleobj_cache_ = new BundleObjectCache(); 

		private static AssetResource current_scene_asset_ = new AssetResource(); //current scene asset

        private static List<xc.Tuple<GameObject, AssetObject>> dic_gameobj_asset_ = new List<xc.Tuple<GameObject, AssetObject>>(); //the gameobjec-asset dic, to ensure the asset release after the gameobj destoyed

		private static Mutex asset_lock_ = new Mutex();
		private static Mutex bundle_lock_ = new Mutex();
		private static Dictionary<IEnumerator, String> coroutine_locked_assets_ = new Dictionary<IEnumerator, string>(); //the coroutines that locling the assets

        //cached strings
		private static readonly string CACHE_STR_PREFAB = ".prefab";
		private static readonly string CACHE_STR_CS = ".cs";
        public static readonly string CACHE_STR_SCENE_ROOT = "scene_root";

		private static int GC_INTERVAL = 60;

        ////////////////////////////////////////mono inherited/////////////////////////////////////////
        protected void OnDestroy()
        {
            is_destroyed_ = true;
        }


        ////////////////////////////////////////private interfaces/////////////////////////////////////////
        //GC
        [XLua.BlackList]
        public void gc()
        {
            StartCoroutine(gc_coroutine());
        }

        private IEnumerator gc_coroutine()
        {
            float start_time = Time.unscaledTime;

            if(!bundleobj_cache_.is_first_resource_loaded() || is_gcing_)
            {
                yield break;
            }

            is_gcing_ = true;

            // GameObject被销毁时，要减少对应AssetObject的引用
            foreach (xc.Tuple<GameObject, AssetObject> item in dic_gameobj_asset_)
            {
                if (item.get_item1_ == null)
                {
                    item.get_item2_.decrence_ref();
                }
            }
            dic_gameobj_asset_.RemoveAll(item => item.get_item1_ == null);

            // 销毁场景相关引用计数已为0的AssetObject
            List<string> assets = assetobj_cache_.get_cache_asset_for_gc_names(true);
            foreach (string path in assets)
            {
				if(!asset_lock_.try_lock(path))
				{
					yield return StartCoroutine(asset_lock_.try_lock_croutine(path));
				}
                assetobj_cache_.try_clean_noused_asset(path);
                asset_lock_.unlock(path);
            }

            // 销毁其他引用计数已为0的AssetObject
            assets = assetobj_cache_.get_cache_asset_for_gc_names(false);
            foreach (string path in assets)
            {
				if(!asset_lock_.try_lock(path))
				{
					yield return StartCoroutine(asset_lock_.try_lock_croutine(path));
				}
                assetobj_cache_.try_clean_noused_asset(path);
                asset_lock_.unlock(path);
            }

			ResourceUtilEx.Instance.gc(0);

            // ResourceUtilEx调用gc后需要再次检查引用计数已为0的AssetObject
			assets = assetobj_cache_.get_cache_asset_for_gc_names(false);
			foreach (string path in assets)
			{
				if(!asset_lock_.try_lock(path))
				{
					yield return StartCoroutine(asset_lock_.try_lock_croutine(path));
				}
				assetobj_cache_.try_clean_noused_asset(path);
				asset_lock_.unlock(path);
			}
			
			// 卸载引用计数为0的assetbundle
			List<string> destroyed = new List<string>();
			List<string> bundles_set = bundleobj_cache_.get_bundles_for_gc();
            foreach (string path in bundles_set)
            {
                if(!bundleobj_cache_.is_in_cache(path))
                {
                    continue;
                }
				if(!bundle_lock_.try_lock(path))
				{
					yield return StartCoroutine(bundle_lock_.try_lock_croutine(path));
				}
                BundleObject bundle_object = bundleobj_cache_.get_bundle_object_from_cache(path);
                if (bundle_object.get_ref_count_ < 1)
                {
                    bundle_object.destroy();
                    bundleobj_cache_.remove_bundle_object_from_cache(path);
                }
                bundle_lock_.unlock(path);
            }

            SGameEngine.Pool<string>.List.Free(bundles_set);

#if UNITY_IPHONE
            // 1G内存的iphone设备开启gc
            if(SystemInfo.systemMemorySize <= 1024)
                System.GC.Collect(0);
#endif
            float mark_time = Time.unscaledTime;

            is_gcing_ = false;

            GameDebug.Log(string.Format("[ResourceLoader](gc_process)use time: {0}, mark time: {1}", Time.unscaledTime - start_time, Time.unscaledTime - mark_time));
        }

        //load asset in editor mode,directly from the assetdatabase
#if UNITY_EDITOR
        private IEnumerator load_asset_from_assetdatabase(string _asset_path, Type _type, AssetResource _result, bool _lock_asset = true, bool _scene_asset = false, string _scene_name = "")
        {
            yield return null;//force wait one frame to simulate the async logic
            UnityEngine.Object loaded_asset = null;
            if (_scene_asset)
            {
                // Temp Test Quad Tree Scene
//                 if(_scene_name == "X4_zhucheng_001")
//                 {
//                     _scene_name = "daditu_001";
//                 }

                //Test End

                //load level
                sceneLoadAsyncOp = SceneManager.LoadSceneAsync(_scene_name);
                yield return sceneLoadAsyncOp;
            }
            else
            {
                //loaded_asset = Resources.Load(_asset_path, _type);
                loaded_asset = EditorResourceLoader.LoadAssetAtPath(_asset_path, _type);
                if (loaded_asset == null)
                {
                    Debug.LogError(string.Format("asset counld not be loaded {0},check xls or your project", _asset_path));
                    yield break;
                }
            }
            //create the assetobject
            AssetObject ao = _scene_asset ? new SceneAssetObject(_asset_path) : new AssetObject(_asset_path, loaded_asset);
            assetobj_cache_.put_to_cache(_asset_path, ao);
            _result.set_obj(ao);

        }
#endif

		/// <summary>
        /// 从cache中加载bundle
        /// </summary>
		private bool load_bundle_from_cache(string _bundle_path, List<BundleObject> _all_bundles)
		{
            if(bundleobj_cache_.is_in_cache(_bundle_path))
			{
                BundleObject bundle_object = bundleobj_cache_.get_bundle_object_from_cache(_bundle_path);
				if (!_all_bundles.Contains(bundle_object))
				{
					_all_bundles.Add(bundle_object);
                    bundle_object.add_ref();//增加引用，防止在加载过程中被gc销毁
					//bundle_object.load_fbx_inf();//set the mesh info if this is a fbx info
				}
				return true;
			}
			return false;
		}

        /// <summary>
        /// 取掉字符串中的file://
        /// </summary>
        /// <param name="bundle_url"></param>
        /// <returns></returns>
        public string wipe_file_sprit(string bundle_url)
        {
            string url_no_sprit = "";
            if (bundle_url.IndexOf("file://") == 0)
            {
                url_no_sprit = bundle_url.Substring("file://".Length);
            }
            else
                url_no_sprit = bundle_url;

            return url_no_sprit;
        }

        /// <summary>
        /// 是否存在指定路径下的资源文件
        /// </summary>
        /// <param name="asset_path"></param>
        /// _asset_path:资源路径,eg: "Assets/Res/DefaultRes.prefab"
        /// <returns></returns>
        public bool is_exist_asset(string asset_path)
        {
            if (Const.Language != LanguageType.SIMPLE_CHINESE)
                LocalizeManager.Instance.LocalizePath(ref asset_path);
#if UNITY_EDITOR
            // 在编辑器下检查资源是否添加到打包配置中
            if (!CheckAssetCfged(asset_path))
            {
                return false;
            }
            else
                return true;
#else
            var bundle_info = bundleobj_cache_.get_asset_bundle_info(asset_path);
            if (bundle_info == null)
            {
                return false;
            }
            else
            {
                int patch_id = 0;
                if (!xpatch.XPatchManager.Instance.IsAssetDownloaded(asset_path, out patch_id))
                    return false;
                else
                    return true;
            }
                
#endif
        }

        /// <summary>
        /// 从磁盘上加载bundle文件
        /// </summary>
        private IEnumerator load_bundle_from_disk_coroutine(string _bundle_path, List<BundleObject> _all_bundles, bool is_ui_asset)
        {
            // 获取实际的文件路径
            bool from_install_package = false;
            uint file_offset = 0;
            string bundle_url = bundleobj_cache_.get_bundle_url(_bundle_path, ref from_install_package, ref file_offset);
            if (bundle_url == null)
            {
                Debug.LogError( string.Format("[ResourceLoader](load_bundle_from_disk_coroutine)bundle url null. bundle path: {0}", _bundle_path) );
                yield break;
            }

            AssetBundle bundle = null;
            if (from_install_package == false)// 在包外通过LoadFromFileAsync来加载会更快
            {
                bundle_url = CommonTool.WipeFileSprit(bundle_url);

                if (!is_ui_asset)
                {
                    if(AuditManager.Instance.Open) // 提审状态开启的时候，资源需要从bin文件读取
                    {
                        var requeset = AssetBundle.LoadFromFileAsync(bundle_url, 0, file_offset);
                        yield return requeset;
                        bundle = requeset.assetBundle;
                    }
                    else
                    {
                        var requeset = AssetBundle.LoadFromFileAsync(bundle_url);
                        yield return requeset;
                        bundle = requeset.assetBundle;
                    }
                }
                else
                {
                    if(AuditManager.Instance.Open) // 提审状态开启的时候，资源需要从bin文件读取
                    {
                        bundle = AssetBundle.LoadFromFile(bundle_url, 0, file_offset);
                    }
                    else
                        bundle = AssetBundle.LoadFromFile(bundle_url);
                }
            }
            else // 在包内时，因为程序修改了x.data的路径，所以必须通过www来进行加载*/
            {
#if UNITY_IPHONE
                if(AuditManager.Instance.Open) // 提审状态开启的时候，资源需要从bin文件读取
                {
                    // ios streamingasset目录下的文件也可以通过LoadFromFileAsync来读取
                    bundle_url = CommonTool.WipeFileSprit(bundle_url);
                    var requeset = AssetBundle.LoadFromFileAsync(bundle_url, 0, file_offset);
                    yield return requeset;
                    bundle = requeset.assetBundle;
                }
                else
                {
                    // ios streamingasset目录下的文件也可以通过LoadFromFileAsync来读取
                    bundle_url = CommonTool.WipeFileSprit(bundle_url);
                    var requeset = AssetBundle.LoadFromFileAsync(bundle_url);
                    yield return requeset;
                    bundle = requeset.assetBundle;
                }
                
#else
                // 通过www来加载bundle
                WWW www = new WWW(bundle_url);
                yield return www;
                while (!www.isDone)
                {
                    Debug.LogError(string.Format("[ResourceLoader](load_bundle_from_disk_coroutine) this is harmless, bundle ids not donw after yield: {0}", _bundle_path));
                    yield return new WaitForEndOfFrame();
                }
                // 加载完毕后获取assetbundle
                bundle = www.assetBundle;
                www.Dispose();
#endif
            }

            if (bundle == null)
			{
                string msg = string.Format("[ResourceLoader](load_bundle_from_disk_coroutine)load bundle from www failed, unity3d file is in valid, bundle path is {0} device is {1}", _bundle_path, SystemInfo.deviceModel);
                Debug.LogError(msg);
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ResLoadFail, msg, false);
                // Post The File Msg To DownloadRepairer Manager
                //ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_BUNDLE_RES_LOAD_FAILED, new CEventBaseArgs(_bundle_path));
                var patch_mgr = xpatch.XPatchManager.Instance;
                if (patch_mgr.IsAutoFix)
                    patch_mgr.DownloadBundle(_bundle_path);

                BuglyAgent.ReportException(new IOException(), msg);

                yield break;
			}

            // 加载的bundle使用BundleObject进行包装并放入到Cache中
            BundleObject bundle_object = new BundleObject(_bundle_path, bundle);
			if (_bundle_path.EndsWith(CACHE_STR_CS))
            {
                bundle_object.add_ref();
            }
            bundleobj_cache_.put_bundle_object_to_cache(_bundle_path, bundle_object);
       		_all_bundles.Add(bundle_object);
			bundle_object.add_ref();//增加引用，防止在加载过程中被gc销毁
			//bundle_object.load_fbx_inf();//set the mesh info if this is a fbx info
        }

        //some tray lock may die if the mono which start the coroutine destroyed, so we should check the dead trylocl croutines to release the locks
        private void check_dead_lock_coroutine()
        {
            List<IEnumerator> delete_lst = new List<IEnumerator>();
            foreach (KeyValuePair<IEnumerator, string> kvp in coroutine_locked_assets_)
            {
                if (!kvp.Key.MoveNext())
                {
					asset_lock_.unlock(kvp.Value);
                    delete_lst.Add(kvp.Key);
                }
            }
            foreach (IEnumerator ie in delete_lst)
            {
                coroutine_locked_assets_.Remove(ie);
            }
            delete_lst.Clear();
        }

        public delegate void OnRemoteFileDownload(string url, string error, byte[] fileData);
        public void download_remotefile(string url, OnRemoteFileDownload fileDownloaded)
        {
            StartCoroutine(_download_remotefile_impl(url, fileDownloaded));
        }

        IEnumerator _download_remotefile_impl(string url, OnRemoteFileDownload fileDownloaded)
        {
            WWW download = new WWW(url);
            yield return download;

            if (string.IsNullOrEmpty(download.error)==false)
            {
                if (fileDownloaded != null)
                    fileDownloaded(url, download.error, null);
            }
            else
            {
                if (fileDownloaded != null)
                    fileDownloaded(url, null, download.bytes);
            }
        }
#if UNITY_EDITOR
        protected void Update()
        {
            /*if (Input.GetKeyUp(KeyCode.D))
            {
                bundleobj_cache_.dump_loaded_bundles();
            }*/
        }
        
        /// <summary>
        /// 检查加载的文件是否在资源配置
        /// </summary>
        private bool CheckAssetCfged(string path)
        {
            if (path.Contains("/UI/Atlas/"))
            {
                return true;
            }
            return allResCfged.Contains(path);
        }
#endif


        public UnityEngine.Object Resources_Load(string filePath)
        {
            return Resources.Load(filePath);
        }

        public void Resources_UnloadAsset(UnityEngine.Object res)
        {
            Resources.UnloadAsset(res);
        }



    }
}
