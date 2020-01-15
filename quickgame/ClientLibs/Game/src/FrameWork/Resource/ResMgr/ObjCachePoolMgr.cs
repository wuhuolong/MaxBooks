using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using SGameEngine;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class ObjCachePoolMgr : MonoBehaviour
    {
        private static ObjCachePoolMgr mInstance;
        private Dictionary<ObjCachePoolType, ObjectCachePool> mDicObjPools = new Dictionary<ObjCachePoolType, ObjectCachePool>();//the prefab pool
        private GameObject mPoolRoot; 
        private GameObject mPoolRootActor; 
        private GameObject mPoolRootSmallPrefab;
        private GameObject mPoolRootSFX;
        private GameObject mPoolRootUIPrefab;
        private GameObject mPoolRootDropPrefab;

        public static ObjCachePoolMgr Instance
        {
            get
            {
                return mInstance;
            }
        }

        //public ObjectCachePool(CacheReleaser _releaser, int _max_cache_count, int _cache_limit_count, float _worn_time, GameObject _root_node);

        private void Awake()
        {
            mInstance = this;

            //init gameobj pool root 
            mPoolRoot = new GameObject("PoolRoot");
            mPoolRoot.SetActive(false);
            DontDestroyOnLoad(mPoolRoot);
            Transform root_trans = mPoolRoot.transform;
            mPoolRootActor = new GameObject("PoolActor");
            mPoolRootActor.transform.parent = root_trans;
            mPoolRootSmallPrefab = new GameObject("PoolSmallPrefab");
            //mPoolRootSmallPrefab.SetActive(false);
            mPoolRootSmallPrefab.transform.parent = root_trans;
            mPoolRootSFX = new GameObject("PoolSFX");
            //mPoolRootSFX.SetActive(false);
            mPoolRootSFX.transform.parent = root_trans;
            mPoolRootUIPrefab = new GameObject("PoolUIPrefab");
            //mPoolRootUIPrefab.SetActive(false);
            mPoolRootUIPrefab.transform.parent = root_trans;
            mPoolRootDropPrefab = new GameObject("PoolDropPrefab");
            //mPoolRootDropPrefab.SetActive(false);
            mPoolRootDropPrefab.transform.parent = root_trans;

            CacheReleaser cacheReleaserUnityObj = new CacheReleaser();
            cacheReleaserUnityObj.register_release(new CacheReleaser.ReleaseCacheHandle(CacheReleaseHandlerUnityObj));

            CacheReleaser cacheReleaserGameObject = new CacheReleaser();
            cacheReleaserGameObject.register_release(new CacheReleaser.ReleaseCacheHandle(CacheReleaseHandlerPrefab));

            mDicObjPools.Add(ObjCachePoolType.JSON, new ObjectCachePool(cacheReleaserUnityObj, 16, 32, 10, null));
            mDicObjPools.Add(ObjCachePoolType.AIJSON, new ObjectCachePool(cacheReleaserUnityObj, 16, 32, 120, null));
            mDicObjPools.Add(ObjCachePoolType.AI, new ObjectCachePool(null, 128, 256, 120, null));
            mDicObjPools.Add(ObjCachePoolType.MACHINE, new ObjectCachePool(null, 256, 512, 60, null));
            mDicObjPools.Add(ObjCachePoolType.STATE, new ObjectCachePool(null, 1024, 2048, 60, null));
            mDicObjPools.Add(ObjCachePoolType.SMALL_PREFAB, new ObjectCachePool(cacheReleaserGameObject, 128, 256, 10, mPoolRootSmallPrefab));
            mDicObjPools.Add(ObjCachePoolType.UI_PREFAB, new ObjectCachePool(cacheReleaserGameObject, 50, 100, 60, mPoolRootUIPrefab));
            mDicObjPools.Add(ObjCachePoolType.DROP_PREFAB, new ObjectCachePool(cacheReleaserGameObject, 50, 100, 180, mPoolRootDropPrefab));

            if (QualitySetting.IsVeryLowIPhone())
            {
                mDicObjPools.Add(ObjCachePoolType.ACTOR, new ObjectCachePool(cacheReleaserGameObject, 15, 30, 30, mPoolRootActor));
                mDicObjPools.Add(ObjCachePoolType.SFX, new ObjectCachePool(cacheReleaserGameObject, 25, 50, 30, mPoolRootSFX));
            }
            else
            {
                mDicObjPools.Add(ObjCachePoolType.ACTOR, new ObjectCachePool(cacheReleaserGameObject, 25, 50, 60, mPoolRootActor));
                mDicObjPools.Add(ObjCachePoolType.SFX, new ObjectCachePool(cacheReleaserGameObject, 50, 100, 60, mPoolRootSFX));
            }

            //timers
            InvokeRepeating("UpdateCachePool", 5f, 5f);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }


        void OnDestroy()
        {
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }
        /*private void Update()
        {
            mPoolRoot.name = string.Format("PoolRoot_{0}/{1}", mDicObjPools [ObjCachePoolType.SMALL_PREFAB].get_free_cache_count() , mDicObjPools [ObjCachePoolType.SMALL_PREFAB].get_cache_count());
        }*/

        //load c# object from pool, it not found in pool, return null
        //notice: if you got object by this method, you should call RecycleCSharpObject() after using it.
        public T TryLoadCSharpObject<T>(ObjCachePoolType poolType, string poolKey) where T : class
        {
            if (poolKey == null)
            {
                return null;
            }

            ObjectCachePool dstPool = null;
            if (!mDicObjPools.TryGetValue(poolType, out dstPool))
            {
                Debug.LogError(string.Format("ObjCachePoolMgr::TryLoadCSharpObject pool type {0} is not defined!", poolType));
                return null;
            }

            //try load from pool
            return dstPool.try_hit_cache(poolKey) as T;
        }

        //recycle a c# object to pool
        public void RecycleCSharpObject(object obj, ObjCachePoolType poolType, string poolKey)
        {
            if(obj == null)
            {
                Debug.LogError(string.Format("ObjCachePoolMgr::RecycleCSharpObject recycle  an  null gameobject you may repeat recycle, pool key {0}", poolKey));
                return;
            }
            if (!mDicObjPools.ContainsKey(poolType))
            {
                Debug.LogError(string.Format("ObjCachePoolMgr::RecycleCSharpObject pool type {0} is not defined!", poolType));
                return ;
            }

            ObjectCachePool dstPool = mDicObjPools[poolType];
            dstPool.add_cache(poolKey, obj);
            obj = null;
        }

        //@hzb
        public void LoadPrefabAsync(string assetPath, ObjCachePoolType poolType, string poolKey, System.Action<object> callBack)
        {
            //TODO no update when Game.!mIsInited || Game.mStopped 
            //SafeCoroutine.Coroutine ct = SafeCoroutine.CoroutineManager.StartCoroutine(LoadPrefab(assetPath, poolType, poolKey, ow));
            StartCoroutine(LoadPrefab(assetPath, poolType, poolKey, callBack));
        }

        //@hzb
        public IEnumerator LoadPrefab(string assetPath, ObjCachePoolType poolType, string poolKey, System.Action<object> callBack)
        {
            ObjectWrapper ow = new ObjectWrapper();
            yield return StartCoroutine(LoadPrefab(assetPath, poolType, poolKey, ow));
            if (callBack != null)
               callBack(ow.obj);
        }

        //load a prefab from pool, it not found in pool, return null
        //notice: if you got object by this method, you should call RecyclePrefab() after using it.
        public IEnumerator LoadPrefab(string assetPath, ObjCachePoolType poolType, string poolKey, ObjectWrapper prefab)
        {
            if(poolKey == null)
            {
                poolKey = assetPath;
            }
            if (!mDicObjPools.ContainsKey(poolType))
            {
                Debug.LogError(string.Format("ObjCachePoolMgr::LoadPrefab pool type {0} is not defined!", poolType));
                yield break;
            }
            ObjectCachePool dstPool = mDicObjPools[poolType];
            
            //try load from pool
            GameObject obj = dstPool.try_hit_cache(poolKey) as GameObject;
         
            if (obj == null)
            {
                PrefabResource pr = new PrefabResource();
                yield return StartCoroutine(ResourceLoader.Instance.load_prefab(string.Format("Assets/Res/{0}.prefab", assetPath), pr));
                obj = pr.obj_;
                if (obj == null)
                {
                    yield break;
                }

                PoolGameObject pg = obj.AddComponent<PoolGameObject>();
                pg.poolType = poolType;
                pg.key = poolKey;
            }
            else
            {
                obj.transform.SetParent(null, false);
                obj.SetActive(true);
            }
            obj.transform.position = new Vector3(0, -1000, 0);
            prefab.obj = obj;
        }

        //recycle a prafab to pool
        public void RecyclePrefab(GameObject obj, ObjCachePoolType poolType, string poolKey)
        {
            if (obj == null)
            {
                return ;
            }
            if (obj.GetComponent<PoolGameObject>() == null)
            {
                Debug.LogError(string.Format("you can not recycle an gameobject without pool flag {0}", obj.name));
                Destroy(obj);
                return;
            }
            if (!mDicObjPools.ContainsKey(poolType))
            {
                Debug.LogError(string.Format("ObjCachePoolMgr::RecyclePrefab pool type {0} is not defined!", poolType));
                Destroy(obj);
                return ;
            }
            ObjectCachePool dstPool = mDicObjPools[poolType];
            obj.SetActive(false);
            obj.transform.SetParent(dstPool.get_root_node(), false);
            if (!dstPool.add_cache(poolKey, obj))
            {
                CacheReleaseHandlerPrefab(obj);
            }
        }

        //load a prefab from pool, it not found in pool, return null
        //notice: if you got object by this method, you should call RecyclePrefab() after using it.
        public object LoadFromCache(ObjCachePoolType poolType, string poolKey)
        {
            if (!mDicObjPools.ContainsKey(poolType))
            {
                Debug.LogError(string.Format("ObjCachePoolMgr::LoadPrefab pool type {0} is not defined!", poolType));
                return null;
            }
            ObjectCachePool dstPool = mDicObjPools[poolType];
            
            //try load from pool
            GameObject go =  dstPool.try_hit_cache(poolKey) as GameObject;
            if (go != null)
            {
                go.transform.SetParent(null, false);
                go.transform.position = new Vector3(0, -1000, 0);
            }
            return go;
        }

        //do some release when scene change.
        public void OnDestroyScene(bool clearUI = true)
        {
            //clear pool
            ClearCachePool(ObjCachePoolType.JSON, false);
            ClearCachePool(ObjCachePoolType.ACTOR, true);//when clear the scene, every actor should be released, so we can use true to destroy all in pool
            ClearCachePool(ObjCachePoolType.SMALL_PREFAB, true);
            ClearCachePool(ObjCachePoolType.SFX, true);
            //ClearCachePool(ObjCachePoolType.UI_PREFAB, true);
            ClearCachePool(ObjCachePoolType.UI_PREFAB, clearUI);
            ClearCachePool(ObjCachePoolType.DROP_PREFAB, true);
        }

        public void RemoveFromCachePool(ObjCachePoolType poolType, string poolKey, object obj)
        {
            ObjectCachePool dstPool = mDicObjPools[poolType];
            dstPool.remove_from_cache(poolKey, obj);
        }


        //clear the prefab pool cache
        private void ClearCachePool(ObjCachePoolType type, bool includeRent)
        {
            ObjectCachePool pool = mDicObjPools[type];
            pool.clear_all_cache(includeRent);
        }

        //update the prefab pool
        private void UpdateCachePool()
        {
            foreach (KeyValuePair<ObjCachePoolType, ObjectCachePool> kvp in mDicObjPools)
            {
                kvp.Value.update();
            }
        }

        private void CacheReleaseHandlerUnityObj(object obj)
        {
            UnityEngine.Object unityObj = obj as UnityEngine.Object;
            if (unityObj == null)
            {
                return;
            }
     
            Resources.UnloadAsset(unityObj);

        }


        private void CacheReleaseHandlerPrefab(object obj)
        {
            GameObject go = obj as GameObject;
            if (go == null)
            {
                return;
            }
            go.GetComponent<PoolGameObject>().DeleteByPool = true;
            Destroy(go);
        }


        void OnStartSwitchScene(CEventBaseArgs data)
        {
           // StopCoroutine(GcCoroutine());
 
        }
    }
}

