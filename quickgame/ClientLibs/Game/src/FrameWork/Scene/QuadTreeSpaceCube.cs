//-----------------------------------------------
// QuadTreeSpaceCube.cs
// 四叉树的空间节点，用来控制节点资源的加载\卸载
// @raorui comments
// 2017.6.11
//-----------------------------------------------
using UnityEngine;
using System.Collections;
using SGameEngine;

public class QuadTreeSpaceCube : MonoBehaviour
{
    public string scenePartPath; //场景节点资源的路径
    bool isShow = false;// 节点是否可见
    bool isLoading = false;// 节点的资源是否正在加载过程中
    private QuadtreeScenePart scenePart;// 节点资源上的组件
    Transform mCacheTrans;

#if UNITY_EDITOR
    private MeshRenderer meshRenderer;
#endif

    void Awake()
    {
        mCacheTrans = transform;
#if UNITY_EDITOR
        meshRenderer = GetComponent<MeshRenderer>();
#endif
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        //UpdateSceneInEditor();
#endif
        if (isLoading)// 如果正在加载资源，则直接返回
        {
            return;
        }

        if (mStartDelay)
        {
            if(Time.realtimeSinceStartup - mStartTime > mDelayTime)
            {
                isShow = true;
                StopDelay();
            }
        }

        // 如果节点可见
        if (isShow)
        {
            if (scenePart == null || !scenePart.gameObject.activeSelf)// 当前加载的资源为空或者放入了缓存中，则进行加载
                StartCoroutine(Load());
        }
        else if (!isShow)// 如果节点不可见
        {
            if (scenePart != null && scenePart.gameObject.activeSelf)// 如果已经加载了资源并且没有被放入缓存，则进行卸载
                UnLoad();
        }
    }

#if UNITY_EDITOR
    //editor we use frustum caculation (for the scene view problem)
    /*void UpdateSceneInEditor()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        isShow = GeometryUtility.TestPlanesAABB(planes, meshRenderer.bounds);
    }*/

#endif

    void OnBecameVisible()
    {
        var camera_main = Camera.main;
        if(camera_main == null)
        {
            isShow = true;
            StopDelay();
        }
        else
        {
            // 距离太远的需要延迟1.5s才设置显示属性
            var distance = Vector3.Distance(camera_main.transform.position, mCacheTrans.position);
            if (distance > 150.0f)
            {
                GameDebug.Log(string.Format("OnBecameVisible delay show, gameobject: {0} camera pos:{1}", gameObject.name ,camera_main.transform.position));

                StartDelayShow();
            }
            else
            {
                isShow = true;
                StopDelay();
            }
        }
    }
    
    void OnBecameInvisible()
    { 
        isShow = false;
        StopDelay();
    }

   /// <summary>
   /// 加载节点的资源，有可能直接从缓存中加载
   /// </summary>
   /// <returns></returns>
    IEnumerator Load()
    {
        QuadTreeSceneManager.Instance.AddListener(this);
        isLoading = true;

        if (QuadTreeSceneManager.Instance.TryHitCache(this))
        {
            scenePart.gameObject.SetActive(true);
        }
        else
        {
            PrefabResource pr = new PrefabResource();
            yield return StartCoroutine(ResourceLoader.Instance.load_prefab(scenePartPath, pr));

            pr.obj_.transform.position = Vector3.zero;
            scenePart = pr.obj_.GetComponent<QuadtreeScenePart>();
            QuadTreeSceneManager.Instance.AddToCache(this);
        }

        QuadTreeSceneManager.Instance.RemoveListener(this);
        isLoading = false;
    }

    bool mStartDelay = false;
    float mStartTime = 0;
    float mDelayTime = 1.5f;

    void StartDelayShow()
    {
        mStartDelay = true;
        mStartTime = Time.realtimeSinceStartup;
    }

    void StopDelay()
    {
        mStartDelay = false;
    }

    /// <summary>
    /// 卸载场景资源，先将其放入缓存中（在加载的时候已经放入）
    /// </summary>
    void UnLoad()
    {
        if (isLoading)
        {
            return;
        }
        scenePart.gameObject.SetActive(false);
    }

    /// <summary>
    /// 当前的资源节点是否可见
    /// </summary>
    /// <returns></returns>
    public bool IsShow
    {
        get { return isShow; }
    }

    /// <summary>
    /// 释放节点的资源
    /// </summary>
    /// <returns></returns>
    public bool Release()
    {
        if (isLoading)
        {
            return false;
        }

        if (scenePart == null)
        {
            return true;
        }

        Destroy(scenePart.gameObject);
        scenePart = null;
        return true;
    }
}
