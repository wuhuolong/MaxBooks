//************************************
//  BundleObject.cs
//  the bundle object is the encapsulation of assetbundle, it maintains the ref count of bundles. AssetObject refs BundleObject
//  Created by leon @INCEPTION .
//  Last modify 14-12-19 : refactor
//************************************

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;
using System;
using System.Reflection;
using SGameFirstPass;
using xc;

namespace SGameEngine
{
    //the bundle object is the encapsulation of assetbundle, it maintains the ref count of bundles. AssetObject refs BundleObject
    public class BundleObject
    {
        private string path_; //the path of the main asset in this bundle
        private AssetBundle bundle_; //bundle
        private int ref_count_ = 0;
        private bool destroyed_ = false;

        public bool get_is_destroyed_
        {
            get {
                return destroyed_;
            }
        }

        //private MonoBehaviour fbx_info_;// the fbx info if this bundle contains fbx

        public BundleObject(string _path, AssetBundle _bundle)
        {
            path_ = _path;
            bundle_ = _bundle;
        }

        public string get_asset_path_
        {
            get
            {
                return path_;
            }
        }

        public AssetBundle get_asset_bundle_
        {
            get
            {
                return bundle_;
            }
        }

        public void add_ref()
        {
            ++ref_count_;
        }

        public void decrease_ref()
        {
            --ref_count_;
        }
        public int get_ref_count_
        {
            get
            {
                return ref_count_;
            }
        }

        //************************************
        // Method:   destroy this bundle
        //Return void 
        //Paramater bool _all : if true: all the resource from this bundle will be released, if false, the using reource will be kept.
        //************************************
        public void destroy(bool _all = true)
        {
            if (destroyed_)
            {
                Debug.LogError(string.Format("bundle {0} already destroyed", path_));
                return;
            }
            destroyed_ = true;
            bundle_.Unload(_all);
        }


    }

    public class BundleObjectCache
    {
        public static readonly string FIRST_INIT_BUNDLE = "Assets/Res/DefaultRes.prefab"; //the first asset bundle,contains trhe built-in assets, all cs .


        /////////////////////////////////////////private properties/////////////////////////////////////////
        private Dictionary<string, AssetBundleInfoItem> bundle_info_ = new Dictionary<string, AssetBundleInfoItem>(); // the bundle info read form the bundle file
		public string[] bundle_info_asset_path_list_;
        private Dictionary<string, BundleObject> bundles_cache_ = new Dictionary<string, BundleObject>(); //all cached bundles
        private Dictionary<string, List<List<string>>> asset_sorted_depends_cache_ = new Dictionary<string, List<List<string>>>();//cache the sorted dependencies of a asset
        private List<string> cslight_files_ = new List<string>(); //all cslight files
        private bool is_first_resource_loaded_ = false; //bundle信息是否已加载完毕
	

        public AssetBundleInfoItem get_asset_bundle_info(string _path)
        {
            if (bundle_info_.ContainsKey(_path))
            {
                return bundle_info_[_path];
            }
            return null;
        }

        /// <summary>
        /// 设置path和guid与bundle的映射
        /// </summary>
        public void set_asset_bundle_info(string _path, AssetBundleInfoItem _info)
        {
            bundle_info_.Add(_path, _info);
        }

        public bool is_in_cache(string _path)
        {
            if(bundles_cache_.ContainsKey(_path))
            {
                return true;
            }
            return false;
        }

        public int get_bundles_count()
        {
            return bundles_cache_.Count;
        }

        public Dictionary<string, BundleObject> get_bundles_cache()
        {
            return bundles_cache_;
        }

        /// <summary>
        /// 是否所有的资源都在Cache中
        /// </summary>
        public bool is_all_in_cache(List<string> _asset_list)
        {
            foreach (string path in _asset_list)
            {
                if (!is_in_cache(path))
                {
                    return false;
                }
            }
            return true;
        }

        public bool is_first_resource_loaded()
        {
            return is_first_resource_loaded_;
        }

        public BundleObject get_bundle_object_from_cache(string _path)
        {
            if (bundles_cache_.ContainsKey(_path))
            {
                return bundles_cache_[_path];
            }
            return null;
        }

        public void put_bundle_object_to_cache(string _path, BundleObject _bundle_object)
        {
            bundles_cache_.Add(_path, _bundle_object);
        }

        public void remove_bundle_object_from_cache(string _path)
        {
            if (bundles_cache_.ContainsKey(_path))
            {
                bundles_cache_.Remove(_path);
            }
        }

        public UnityEngine.Object load_main_asset(AssetBundle _bundle, Type _type, string _name_in_bundle)
        {
            //UnityEngine.Object bundle_obj = _bundle.mainAsset;

            //if(bundle_obj == null)
            UnityEngine.Object bundle_obj = _bundle.LoadAsset(_name_in_bundle, _type);
            return bundle_obj;
        }

        public void init()
        {
#if UNITY_EDITOR
            if (!ResourceLoader.EnableBundleInEditor)
            {
                is_first_resource_loaded_ = true;
            }
            else
#endif
            {
                ResourceLoader.Instance.StartCoroutine(init_coroutine());
            }
        }

        public string get_bundle_url(string _path, ref bool from_install_package, ref uint file_offset)
        {
            from_install_package = false;
            file_offset = 0;
            AssetBundleInfoItem bundle_info = get_asset_bundle_info(_path);
            if (bundle_info == null)
            {
                return null;
            }

            // 提审状态开启的时候，资源从bin文件中加载
            if(AuditManager.Instance.Open)
            {
                from_install_package = true;
                var asset_path_id = bundle_info.assetpath;
                AssetBundleOffsetInfoItem bin_offset_info = null;
                if(bin_info_dic != null && bin_info_dic.TryGetValue(asset_path_id, out bin_offset_info))
                {
                    file_offset = bin_offset_info.offset;
                    var bin_file_name = bin_offset_info.binid + ".bin";
                    var bin_file_path = String.Format("{0}/{1}", get_bundle_dir(from_install_package), bin_file_name);
                    bin_file_path = ResNameMapping.Instance.GetMappingPath(bin_file_path, Const.BUNDLE_FOLDER_NAME, bin_file_name);
                    return bin_file_path;
                }
                else
                {
                    Debug.LogError("get offset_info error:" + _path);
                    return null;
                }
            }
            else
            {
                from_install_package = bundle_info.is_from_install_package_;
                return String.Format("{0}/{1}.unity3d", get_bundle_dir(from_install_package), bundle_info.bundleName);
            }
        }

        /// <summary>
        /// 获取asset的所有依赖项，返回的结果按照依赖顺序进行排序
        /// </summary>
        public List<List<string>> get_asset_all_dependence(string _asset_path)
        {
            List<List<string>> sorted_list = null;

            if (asset_sorted_depends_cache_.ContainsKey(_asset_path))
            {
                sorted_list = asset_sorted_depends_cache_[_asset_path];
            }
            else
            {
                sorted_list = new List<List<string>>();
                HashSet<string> unique_set = new HashSet<string>();
                get_asset_all_dependence_recursively(_asset_path, sorted_list, unique_set);
                asset_sorted_depends_cache_.Add(_asset_path, sorted_list);
            }
            return sorted_list;
        }

        /// <summary>
        /// 获取所有引用计数为0的BundleObject
        /// </summary>
		public List<string> get_bundles_for_gc()
		{
            List<string> cache = SGameEngine.Pool<string>.List.New();
            // notice: 之后需要立即调用 SGameEngine.Pool<string>.List.Free(bundles_set);
            foreach (KeyValuePair<string, BundleObject> kvp in bundles_cache_)
			{
				if(kvp.Value.get_ref_count_ > 0)
				{
                    //Debug.LogError("assetbundle ref:" + kvp.Value.get_asset_path_);
					continue;
				}
				cache.Add(kvp.Key);
			}
			return cache;
		}

		private string get_bundle_dir(bool _is_from_pacakge)
		{
			if(_is_from_pacakge)
			{
                return Const.BUNDLE_FILE_FOLDER_PACKAGE;
			}
			else
			{
				return Const.BUNDLE_FILE_FOLDER_DISK;
			}
		}

        private void get_asset_all_dependence_recursively(string _asset_path, List<List<string>> _sorted_list, HashSet<string> _unique_set)
        {
            AssetBundleInfoItem bundle_item_info = get_asset_bundle_info(_asset_path);
            List<int> dependencies = bundle_item_info.dependencyAssetPath;

			if (dependencies.Count <= 0)
            {
                return;
            }

            List<string> current_list = new List<string>();

			foreach (int path_index in dependencies)
            {
				string path = bundle_info_asset_path_list_[path_index];
				get_asset_all_dependence_recursively(path, _sorted_list, _unique_set);

                if (!_unique_set.Contains(path) && path != BundleObjectCache.FIRST_INIT_BUNDLE)
                {
                    current_list.Add(path);
                    _unique_set.Add(path);
                }
            }

            if (current_list.Count > 0)
            {
                _sorted_list.Add(current_list);
            }
        }

        /// <summary>
        /// 加载bundle信息和DefaultRes
        /// </summary>
        private IEnumerator init_coroutine()
        {
            float start_time = Time.unscaledTime;
            yield return ResourceLoader.Instance.StartCoroutine(load_bundle_info());
            Debug.Log(string.Format("[BundleObjectCache](init_coroutine)load bundle info use time: {0}", Time.unscaledTime - start_time));

            // 提审状态开启的时候，需要加载dl_bin_info.data文件
            if(AuditManager.Instance.Open)
            {
                start_time = Time.unscaledTime;
                yield return ResourceLoader.Instance.StartCoroutine(load_bin_info());
                Debug.Log(string.Format("[BundleObjectCache](init_coroutine)load bin_info use time: {0}", Time.unscaledTime - start_time));
            }

            start_time = Time.unscaledTime;
            yield return ResourceLoader.Instance.StartCoroutine(load_first_bundle());
            Debug.Log(string.Format("[BundleObjectCache](init_coroutine)load first bundle use time: {0}", Time.unscaledTime - start_time));

            is_first_resource_loaded_ = true;
        }

        /// <summary>
        /// 加载bundle信息
        /// </summary>
        private IEnumerator load_bundle_info()
        {
            AssetBundleInfoRuntime raw_bundle_info = ResourceLoader.Instance.ServerBundleInfo;
			AssetBundle bundle = null;
            // 加载bundle_info的逻辑
			if(raw_bundle_info == null)
			{
				string bundle_url = String.Format("{0}/{1}.unity3d", get_bundle_dir(true), 0);

#if UNITY_IPHONE
                // ios streamingasset目录下的文件也可以通过LoadFromFileAsync来读取
                bundle_url = CommonTool.WipeFileSprit(bundle_url);
                var requeset = AssetBundle.LoadFromFileAsync(bundle_url);
                yield return requeset;
                bundle = requeset.assetBundle;
#else
                WWW www = new WWW(bundle_url);
				yield return www;
				
				bundle = www.assetBundle;
				www.Dispose();
#endif
                raw_bundle_info = load_main_asset(bundle, typeof(UnityEngine.Object), BundleNameDef.MAIN) as AssetBundleInfoRuntime;
			}

            string[] raw_assetpath_list = raw_bundle_info.assetpathList;
			bundle_info_asset_path_list_ = new string[raw_assetpath_list.Length];
			Array.Copy(raw_assetpath_list, bundle_info_asset_path_list_, raw_assetpath_list.Length);

            List<AssetBundleInfoItem> lst_bundle_info = raw_bundle_info.info;
            foreach (AssetBundleInfoItem item in lst_bundle_info)
            {
                set_asset_bundle_info( bundle_info_asset_path_list_[item.assetpath] , item);
            }

            // 删除原始资源信息的列表
			UnityEngine.Object.DestroyImmediate(raw_bundle_info as UnityEngine.Object, true);
			if(bundle != null)
			{
				bundle.Unload(true);
			}
        }

        /// <summary>
        /// 加载DefaultRes
        /// </summary>
        private IEnumerator load_first_bundle()
        {
            // 使用LoadFromFileAsync进行加载(ios包内外均可使用，android必须拷贝到包外)
            bool is_from_package = false;
            uint file_offset = 0;
            string bundle_url = get_bundle_url(FIRST_INIT_BUNDLE, ref is_from_package, ref file_offset);
            bundle_url = CommonTool.WipeFileSprit(bundle_url);

            AssetBundle bundle = null;
            if (AuditManager.Instance.Open)
            {
                var request = AssetBundle.LoadFromFileAsync(bundle_url, 0, file_offset);
                yield return request;

                bundle = request.assetBundle;
            }
            else
            {
                var request = AssetBundle.LoadFromFileAsync(bundle_url);
                yield return request;

                bundle = request.assetBundle;
            }
           
            BundleObject bundle_object = new BundleObject(FIRST_INIT_BUNDLE, bundle);
            bundle_object.add_ref();
            put_bundle_object_to_cache(FIRST_INIT_BUNDLE, bundle_object);

#if UNITY_IPHONE
            // 在ios提审/内存小于1G时，不进行Shader的预加载
            if(AuditManager.Instance.Open || SystemInfo.systemMemorySize <= 1024)
            {
                yield break;
            }
#endif

            // 加载ShaderVariantCollection
            var load_request = bundle.LoadAllAssetsAsync(typeof(UnityEngine.ShaderVariantCollection));
            yield return load_request;

            var load_asset = load_request.asset;
            if (load_asset != null)
            {
                Debug.Log("load shadervariantvollection succ.");

                // warmup
                var shader_varient = load_asset as UnityEngine.ShaderVariantCollection;
                if (!shader_varient.isWarmedUp)
                    shader_varient.WarmUp();

                // Shader变体存为静态变量
                var variant_info = MainGame.GetGlobalMono().gameObject.AddComponent<ShaderVariantInfo>();
                if (variant_info != null)
                    variant_info.ShaderVariantUsed = shader_varient;
            }
            else
                Debug.Log("load shadervariantvollection failed !!!");
        }

        static Dictionary<int, AssetBundleOffsetInfoItem> bin_info_dic = null;

        /// <summary>
        /// 加载dl_bin_info.data文件(ios提审时候使用)
        /// </summary>
        /// <returns></returns>
        private IEnumerator load_bin_info()
        {
            var bundle_dir = get_bundle_dir(true);
            bundle_dir = CommonTool.WipeFileSprit(bundle_dir);

            string bundle_url = String.Format("{0}/{1}", bundle_dir, "dl_bin_info.data");
            bundle_url = ResNameMapping.Instance.GetMappingPath(bundle_url, Const.BUNDLE_FOLDER_NAME, "dl_bin_info.data");
            var bundle = AssetBundle.LoadFromFile(bundle_url);
            var bin_info = bundle.LoadAsset<AssetBundleBinInfo>(Const.BUNDLE_MAIN);
            bin_info_dic = bin_info.to_dictionary();

            yield return null;
        }

#if UNITY_EDITOR
		public void dump_loaded_bundles()
		{
			foreach(KeyValuePair<string, BundleObject> kvp in bundles_cache_)	
			{
				Debug.Log(kvp.Key);
			}
		}
#endif

    }
}

