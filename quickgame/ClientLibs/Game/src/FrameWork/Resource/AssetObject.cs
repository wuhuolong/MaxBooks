//************************************
//  AssetObject.cs
//  the asset object is the encapsulation of an unity asset, it mantains the ref count of an asset, AssetResource refs AssetObject
//  Created by leon @INCEPTION .
//  Last modify 14-12-19 : refactor
//************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace SGameEngine
{
    //  the asset object is the encapsulation of an unity asset, it mantains the ref count of an asset, AssetResource refs AssetObject
    public class AssetObject
    {
		//public static readonly string STR_METHOD_ON_RES_UNLOAD = "OnResourceUnload";
        protected bool destroyed_ = false;
        protected List<BundleObject> dependence_bundles_ = new List<BundleObject>();

        private string path_; //assetpath
        private UnityEngine.Object obj_;//asset
        private int ref_count_ = 0;

        public AssetObject(string _path, UnityEngine.Object _obj)
        {
            path_ = _path;
            obj_ = _obj;
        }

        public string get_asset_path_
        {
            get
            {
                return path_;
            }
        }

        public List<BundleObject> get_dependence_bundles_
        {
            get {
                return dependence_bundles_;
            }
        }


        public int get_ref_count_
        {
            get
            {
                return ref_count_;
            }
        }

        public UnityEngine.Object get_obj_
        {
            get
            {
                return obj_;
            }
        }

        public void add_ref()
        {
            ++ref_count_;
        }

        public void decrence_ref()
        {
            --ref_count_;
        }

        public void add_depend_bundle(BundleObject _bundle_object)
        {
            _bundle_object.add_ref();
            dependence_bundles_.Add(_bundle_object);
        }

        public virtual void destroy()
        {
            destroyed_ = true;
            foreach (BundleObject bo in dependence_bundles_)
            {
                bo.decrease_ref();
            }

			//MethodInfo method_res_unload = obj_.GetType().GetMethod(STR_METHOD_ON_RES_UNLOAD, BindingFlags.Public|BindingFlags.Instance);
			//if(method_res_unload != null)
			//{
			//	method_res_unload.Invoke(obj_, null) ;
			//}
			ResourceLoader.safe_unload_res(obj_);
        }

        public bool is_destroyed_
        {
            get
            {
                return destroyed_;
            }
        }
    }

    public class SceneAssetObject : AssetObject
    {
        public SceneAssetObject(string path)
            : base(path, null)
        {

        }

        public override void destroy()
        {
            destroyed_ = true;
            foreach (BundleObject bo in dependence_bundles_)
            {
                bo.decrease_ref();
            }
        }
    }

    public class AssetObjectCache
    {
        private Dictionary<string, AssetObject> assetobj_cache_ = new Dictionary<string, AssetObject>();

        public void put_to_cache(string _path, AssetObject _asset_obj)
        {
            if (!assetobj_cache_.ContainsKey(_path))
            {
                assetobj_cache_.Add(_path, _asset_obj);
            }
        }

        public AssetObject get_from_cache(string _path)
        {
            if (assetobj_cache_.ContainsKey(_path))
            {
                return assetobj_cache_[_path];
            }
            return null;
        }

        public int get_asset_count()
        {
            return assetobj_cache_.Count;
        }

        public Dictionary<string, AssetObject> get_cache()
        {
            return assetobj_cache_;
        }

        /// <summary>
        /// 从Cache中获取所有引用计数为0的AssetObject
        /// _check_scene表示是否获取的是SceneObject
        /// </summary>
        public List<string> get_cache_asset_for_gc_names(bool _check_scene)
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, AssetObject> kvp in assetobj_cache_)
            {
				if(kvp.Value.get_ref_count_ > 0)
				{
					continue;
				}
				if (_check_scene && ! (kvp.Value is SceneAssetObject))
                {
					continue;
                }
                list.Add(kvp.Key);
            }
            return list;
        }

        public void try_clean_noused_asset(string _asset_path)
        {
            if (assetobj_cache_.ContainsKey(_asset_path))
            {
                AssetObject asset_obj = assetobj_cache_[_asset_path];
                if (asset_obj.get_ref_count_ < 1)
                {
                    asset_obj.destroy();
                    assetobj_cache_.Remove(_asset_path);
                }
            }
        }
    }
}
