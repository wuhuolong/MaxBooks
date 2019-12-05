using SGameEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace xc.ui.ugui
{
    public class UICacheManager
    {
        public const string UIGOODSITEM = "Assets/Res/UI/Widget/Dynamic/UINewGoodsItem.prefab";
        private const string UIREDPOINT = "Assets/Res/UI/Widget/Dynamic/RedPoint.prefab";
        private const string PreviewTextureBackground = "Assets/Res/UI/Widget/Dynamic/ActorPreviewTexturePrefab.prefab";

        private const string UILOCKICON = "Assets/Res/UI/Widget/Dynamic/LockButton.prefab";
        private const string UINEWMARKER = "Assets/Res/UI/Widget/Dynamic/NewMarker.prefab";

        public class TemplateCache
        {
            private List<GameObject> list = new List<GameObject>();

            public string templateName;

            public float releaseTime = 0;

            public float releaseTimeCount = 0f;

            public GameObject template;
            private RectTransform templateRect;

            public GameObject root;
            private int maxNum;
            public void Clear()
            {
                list.Clear();
                template = null;
                releaseTime = 0f;
                releaseTimeCount = 0f;
                templateName = "";

                if (root != null)
                {
                    root.name = "CachedRoot";
                }
            }

            public void ReleaseAll()
            {
                if (list.Count == 0)
                {
                    return;
                }

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    GameObject.Destroy(list[i]);
                }

                list.Clear();

            }

            public void AddGameObjects(int count)
            {
                for (int i = 0; i < count; i ++)
                {
                    GameObject obj = GameObject.Instantiate<GameObject>(template);
                    this.FreeTemplateInstance(obj);
                }
            }

            /// <summary>
            /// 获取模版物体实例
            /// </summary>
            /// <param name="parent"></param>
            /// <returns></returns>
            public GameObject GetTemplateInstance(Transform parent)
            {
                // 池中没有的时候需要实例化
                if (list.Count == 0)
                {
                    GameObject game_object = null;
                    if(parent != null)
                        game_object = GameObject.Instantiate<GameObject>(template, parent);
                    else
                        game_object = GameObject.Instantiate<GameObject>(template);

                    CommonTool.SetActive(game_object, true);

                    return game_object;
                }
                // 从内存池中获取
                else
                {
                    var gameobj = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    gameobj.transform.SetParent(parent, false);

                    CommonTool.SetActive(gameobj,true);

                    return gameobj;
                }
            }

            public void FreeTemplateInstance(GameObject obj)
            {

                if (obj == null)
                {
                    return;
                }

                if (list.Count > maxNum)
                {
                    GameObject.Destroy(obj);
                    return;
                }

                this.list.Add(obj);
                obj.transform.SetParent(root.transform, false);

                ///设置回template的size
                var slotRect = obj.GetComponent<RectTransform>();

                slotRect.sizeDelta = templateRect.sizeDelta;
                slotRect.pivot = templateRect.pivot;
                slotRect.localPosition = templateRect.localPosition;
                slotRect.localRotation = templateRect.localRotation;
                slotRect.localScale = templateRect.localScale;
                slotRect.localEulerAngles = templateRect.localEulerAngles;
                slotRect.anchorMin = templateRect.anchorMin;
                slotRect.anchorMin = templateRect.anchorMax;
                slotRect.anchoredPosition = templateRect.anchoredPosition;
                slotRect.anchoredPosition3D = templateRect.anchoredPosition3D;
                slotRect.sizeDelta = templateRect.sizeDelta;

                var animator = obj.transform.GetComponent<Animator>();
                if (animator != null) animator.enabled = false;


            }


            public void Init(GameObject gameobj, string name, float time, GameObject cacheRoot, int maxCachedNum = 50)
            {
                this.template = gameobj;

                templateRect = this.template.GetComponent<RectTransform>();

                this.templateName = name;
                this.releaseTime = time;
                this.releaseTimeCount = 0f;
                this.maxNum = maxCachedNum;

                if (root == null)
                {
                    root = new GameObject(templateName);
                    root.SetActive(false);
                    root.transform.SetParent(cacheRoot.transform, false);
                }

                root.name = templateName;
            }
        }

        private GameObject root;

        private List<TemplateCache> cachePool;

        private Dictionary<string, TemplateCache> templateDic;

        private TemplateCache cachedItems;

        private GameObject mRedPointObj;
        private Vector2 mRedPointObjSize = new Vector2(18, 19.2f);


        private GameObject mLockIconObj;
        

        private GameObject mNewMarkerObj;

        GameObject m_previewTextureBackground;
        public UICacheManager(string name = "UITemplateRoot")
        {
            cachePool = new List<TemplateCache>();
            templateDic = new Dictionary<string, TemplateCache>();

            if (root == null)
            {
                root = new GameObject(name);
                GameObject.DontDestroyOnLoad(root);
            }

        }

        public void Reset()
        {

            if (root == null)
            {
                root = new GameObject("UITemplateRoot");
                GameObject.DontDestroyOnLoad(root);
            }

            this.ReleaseAllTemplate();
        }

        public IEnumerator InitCachedItems()
        {
            PrefabResource res = new PrefabResource();
            yield return ResourceLoader.Instance.load_prefab(UIGOODSITEM, res, true);

            GameObject obj = res.obj_;
            obj.name = obj.name.Replace("(Clone)", "");

            UIItemNewSlot.Bind(obj);

            obj.SetActive(false);
            cachedItems = new TemplateCache();
            cachedItems.Init(obj, "UINewGoodsItem", 0, this.root, 50);

            obj.transform.SetParent(cachedItems.root.transform, false);

            obj.transform.localPosition = new Vector3();
            obj.transform.localScale = Vector3.one;
            obj.transform.localRotation = new Quaternion();

            cachedItems.AddGameObjects(30);

        }

        /// <summary>
        /// 获取物品模版的实例
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="newInstance"></param>
        /// <returns></returns>
        public GameObject GetItemGameObj(Transform parent, bool newInstance = false)
        {
            if (cachedItems == null)
            {
                return null;
            }

            if (newInstance)
            {
                var template = cachedItems.template;

                var game_object = GameObject.Instantiate<GameObject>(template, parent);
                CommonTool.SetActive(game_object,true);
                return game_object;
            }

            return cachedItems.GetTemplateInstance(parent);
        }

        public void FreeItemGameObj(GameObject obj)
        {
            if (cachedItems == null)
            {
                return;
            }

            UIItemNewSlot.Bind(obj).Dispose();

            cachedItems.FreeTemplateInstance(obj);
        }

        public void Dispose()
        {
            ClearItemCaches();
            this.ReleaseAllTemplate();

            List<string> keys = new List<string>(templateDic.Keys);

            foreach (var key in keys)
            {
                this.RemoveTemplate(key);
            }

            GameObject.Destroy(root);

            root = null;
        }

        public void ClearItemCaches()
        {
            if (cachedItems != null)
            {
                cachedItems.Clear();
            }
        }

        /// <summary>
        /// 添加模板类,50秒回收一次
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gameobj"></param>
        /// <param name="releaseTime"></param>
        public void AddTemplate(string name, GameObject gameobj, float releaseTime = 10f)
        {
            if (IsTemplateExist(name))
            {
                GameDebug.LogError("ui cache template already exist:" + name);
                return;
            }

            if (gameobj == null)
            {
                GameDebug.LogError("ui cache gameobj is nil :" + gameobj);
                return;
            }

            //add
            TemplateCache cache = this.GetTemplateCache();
            cache.Init(gameobj, name, releaseTime, root);


            templateDic.Add(name, cache);

        }


        /// <summary>
        /// 获取某一模板对象的实例
        /// </summary>
        /// <param name="name"></param>
        public GameObject GetTemplate(string name, Transform parent = null, bool isActive = true)
        {
            if (!IsTemplateExist(name))
            {
                GameDebug.LogError("template not exist :" + name);
                return null;
            }

            TemplateCache cache = this.templateDic[name];
            if(parent == null)
            {
                if (cache.template != null)
                {
                    var cache_parent = cache.template.transform.parent;
                    if(cache_parent != null)
                        parent = cache.template.transform.parent;
                }
            }

            GameObject obj = cache.GetTemplateInstance(parent);

            CommonTool.SetActive(obj, isActive);

            return obj;
        }


        /// <summary>
        /// 放回到缓存池
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gameobj"></param>
        public void FreeTemplate(string name, GameObject gameobj)
        {
            if (!IsTemplateExist(name))
            {
                GameDebug.LogError("template not exist:" + name);
                return;
            }

            TemplateCache cache = this.templateDic[name];

            cache.FreeTemplateInstance(gameobj);
        }


        /// <summary>
        /// 释放所有模板生成对象
        /// </summary>
        public void ReleaseAllTemplate()
        {
            foreach (var templateName in templateDic.Keys)
            {
                this.ReleaseTemplate(templateName);
            }
        }


        /// <summary>
        /// 释放特定模板对象
        /// </summary>
        /// <param name="name"></param>
        public void ReleaseTemplate(string name)
        {
            if (!IsTemplateExist(name))
            {
                return;
            }

            TemplateCache cache = templateDic[name];

            cache.ReleaseAll();
        }

        /// <summary>
        /// 模板是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsTemplateExist(string name)
        {
            return this.templateDic.ContainsKey(name);
        }

        /// <summary>
        /// 移除并释放所有模板
        /// </summary>
        /// <param name="name"></param>
        public void RemoveTemplate(string name)
        {
            if (!IsTemplateExist(name))
            {
                return;
            }

            ReleaseTemplate(name);

            TemplateCache cache = templateDic[name];

            templateDic.Remove(name);

            this.FreeTemplateCache(cache);
        }

        /// <summary>
        /// 更新，释放模板
        /// </summary>
        public void Update()
        {
            foreach (var templateName in templateDic.Keys)
            {
                TemplateCache cache = templateDic[templateName];

                cache.releaseTimeCount += Time.deltaTime;

                if (cache.releaseTimeCount > cache.releaseTime)
                {
                    cache.ReleaseAll();
                    cache.releaseTimeCount = 0f;
                }
            }
        }


        private TemplateCache GetTemplateCache()
        {
            if (cachePool.Count == 0)
            {
                return new TemplateCache();
            }
            else
            {
                var info = cachePool[cachePool.Count - 1];
                cachePool.RemoveAt(cachePool.Count - 1);
                return info;
            }
        }

        private void FreeTemplateCache(TemplateCache cache)
        {
            cache.Clear();
            cachePool.Add(cache);
        }

        public IEnumerator InitRedPointGameObject()
        {
            PrefabResource res = new PrefabResource();
            yield return ResourceLoader.Instance.load_prefab(UIREDPOINT, res, true);

            GameObject obj = res.obj_;
            obj.name = obj.name.Replace("(Clone)", "");
            obj.SetActive(false);
            obj.transform.SetParent(root.transform, false);
            obj.transform.localPosition = new Vector3();
            obj.transform.localScale = Vector3.one;
            obj.transform.localRotation = new Quaternion();
            mRedPointObj = obj;
            RectTransform redPoint_rectTransform = mRedPointObj.GetComponent<RectTransform>();
            if (redPoint_rectTransform != null)
                mRedPointObjSize = redPoint_rectTransform.sizeDelta;
        }

        public GameObject GetRedPointGameObj()
        {
            if (mRedPointObj == null)
            {
                return null;
            }
            return GameObject.Instantiate<GameObject>(mRedPointObj);
        }



        //--------------------------------------------锁
        public IEnumerator InitLockIconGameObject()
        {
            PrefabResource res = new PrefabResource();
            yield return ResourceLoader.Instance.load_prefab(UILOCKICON, res, true);

            GameObject obj = res.obj_;
            obj.name = obj.name.Replace("(Clone)", "");
            obj.SetActive(false);
            obj.transform.SetParent(root.transform, false);
            obj.transform.localPosition = new Vector3();
            obj.transform.localScale = Vector3.one;
            obj.transform.localRotation = new Quaternion();
            mLockIconObj = obj;
        }

        public IEnumerator InitNewMarkerGameObject()
        {
            PrefabResource res = new PrefabResource();
            yield return ResourceLoader.Instance.load_prefab(UINEWMARKER, res, true);

            GameObject obj = res.obj_;
            obj.name = obj.name.Replace("(Clone)", "");
            obj.SetActive(false);
            obj.transform.SetParent(root.transform, false);
            obj.transform.localPosition = new Vector3();
            obj.transform.localScale = Vector3.one;
            obj.transform.localRotation = new Quaternion();
            mNewMarkerObj = obj;
        }

        public GameObject GetLockIconGameObj()
        {
            if (mLockIconObj == null)
            {
                return null;
            }
            return GameObject.Instantiate<GameObject>(mLockIconObj);
        }


        public GameObject GetNewMarkerGameObj()
        {
            if (mNewMarkerObj == null)
                return null;
            return GameObject.Instantiate<GameObject>(mNewMarkerObj);
        }





        public Vector2 RedPointSize
        {
            get { return mRedPointObjSize; }
        }

        public IEnumerator InitPreviewBackgroundMat()
        {
            PrefabResource res = new PrefabResource();
            yield return ResourceLoader.Instance.load_prefab(PreviewTextureBackground, res, true);
            
            GameObject obj = res.obj_;

            if (obj == null)
            {
                Debug.LogError(string.Format("the res {0} does not exist", PreviewTextureBackground));
                yield break;
            }
            obj.name = obj.name.Replace("(Clone)", "");
            obj.SetActive(false);
            obj.transform.SetParent(root.transform, false);
           
            m_previewTextureBackground = obj;
        }

        public GameObject GetPreivewBackGround()
        {
            if (m_previewTextureBackground == null)
            {
                return null;
            }
            return GameObject.Instantiate(m_previewTextureBackground) as GameObject;
        }

        
    }
}
