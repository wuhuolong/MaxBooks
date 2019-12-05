//-----------------------------------------------
// QuadTreeSceneManager.cs
// 四叉树的管理类
// @raorui comments
// 2017.6.11
//-----------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SGameEngine;
using xc;

public class QuadTreeSceneManager : MonoBehaviour
{
    /// <summary>
    /// 记录加入缓存的节点信息
    /// </summary>
    public class CubeTime
    {
        public QuadTreeSpaceCube mCube;
        public float mTime;// 加入缓存的时间

        public CubeTime(QuadTreeSpaceCube cube, float time)
        {
            mCube = cube;
            mTime = time;
        }
    }

    /// <summary>
    /// 可缓存节点的最大数量
    /// </summary>
    public int MAX_CACHE_NUM = 5;

    /// <summary>
    /// 超过固定时间，销毁节点的资源
    /// </summary>
    public int DIE_TIME = 10;
    public static QuadTreeSceneManager Instance;

    /// <summary>
    /// 当前缓存的所有节点
    /// </summary>
    public List<CubeTime> cachedCube = new List<CubeTime>();//old -> new

    /// <summary>
    /// 需要删除的节点资源
    /// </summary>
    List<CubeTime> cubeNeedDelete = new List<CubeTime>();

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("QuadTreeSceneManager inited many times!");
            Destroy(this);
            return;
        }
        Instance = this;

        if (QualitySetting.IsVeryLowIPhone())
        {
            MAX_CACHE_NUM = 5;
            DIE_TIME = 5;
        }
        else
        {
            MAX_CACHE_NUM = 10;
            DIE_TIME = 10;
        }

        InvokeRepeating("ReleaseTooOld", DIE_TIME, DIE_TIME);
    }

    /// <summary>
    /// 从缓存中获取节点
    /// </summary>
    /// <param name="cube"></param>
    /// <returns></returns>
    public bool TryHitCache(QuadTreeSpaceCube cube)
    {
        CubeTime hitCube = null;
        for (int i = 0; i < cachedCube.Count; ++i)
        {
            var cache_info = cachedCube[i];
            if (cache_info == null)
                continue;

            if(cache_info.mCube == cube)
            {
                hitCube = cache_info;
                break;
            }
        }

        if (hitCube != null)
        {
            // 将节点移动到队列结尾，并设置新的访问时间
            cachedCube.Remove(hitCube);
            cachedCube.Add(hitCube);
            hitCube.mTime = Time.unscaledTime;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 将场景节点加入到缓存中
    /// </summary>
    /// <param name="cube"></param>
    public void AddToCache(QuadTreeSpaceCube cube)
    {
        cachedCube.Add(new CubeTime(cube, Time.unscaledTime));
        cubeNeedDelete.Clear();

        int exceed = cachedCube.Count - MAX_CACHE_NUM;// 超出了可用缓存的数量
        if (exceed > 0)
        {
            for (int i = 0; i < cachedCube.Count; i++)
            {
                if (!cachedCube[i].mCube.IsShow)// 如果缓存中的节点没有显示，则将其添加到需要删除的列表中
                {
                    cubeNeedDelete.Add(cachedCube[i]);
                    if (cubeNeedDelete.Count >= exceed)// 如果需要删除的节点释放后在最大缓存范围内
                    {
                        break;
                    }
                }
            }
        }

        if (cubeNeedDelete.Count > 0)
        {
            for (int j = 0; j < cubeNeedDelete.Count; j++)// 释放需要删除节点的资源
            {
                QuadTreeSpaceCube c = cubeNeedDelete[j].mCube;
                if (c.Release())
                {
                    cachedCube.Remove(cubeNeedDelete[j]);
                }
            }
        }
    }

    /// <summary>
    /// 释放超过一定时候都还没有显示的节点
    /// </summary>
    void ReleaseTooOld()
    {
        cubeNeedDelete.Clear();
        for (int i = 0; i < cachedCube.Count; i++)
        {
            if (!cachedCube[i].mCube.IsShow)
            {
                if (Time.unscaledTime - cachedCube[i].mTime > DIE_TIME)
                {
                    cubeNeedDelete.Add(cachedCube[i]);
                }
            }
        }

        if (cubeNeedDelete.Count > 0)
        {
            for (int j = 0; j < cubeNeedDelete.Count; j++)
            {
                QuadTreeSpaceCube c = cubeNeedDelete[j].mCube;
                if (c.Release())
                {
                    cachedCube.Remove(cubeNeedDelete[j]);
                }
            }
        }
    }

    /// <summary>
    /// 是否已经开始监测动态加载是否完成
    /// </summary>
    bool mIsListen = false;

    /// <summary>
    /// 动态加载正在等待的列表
    /// </summary>
    List<QuadTreeSpaceCube> mListenerList = new List<QuadTreeSpaceCube>();

    /// <summary>
    /// 开始监测的时间
    /// </summary>
    float mListenerTime = 0;

    /// <summary>
    /// 开始动态加载场景的时间
    /// </summary>
    float mStartTime = 0;

    /// <summary>
    /// 最大的动态加载数量
    /// </summary>
    uint mMaxListenerNum = 0;

    /// <summary>
    /// 四叉树场景物件开始加载时的百分比，0.4到0.6随机一个数
    /// </summary>
    public float StartLoadPercentage = 0.5f;

    /// <summary>
    /// 开启场景动态加载的监测
    /// </summary>
    public void StartLoadListener()
    {
        if (mIsListen)
            return;

        mListenerList.Clear();
        mListenerTime = Time.unscaledTime;
        mIsListen = true;

        mStartTime = Time.realtimeSinceStartup;

        mMaxListenerNum = 0;
    }

    /// <summary>
    /// 场景的动态加载是否完成
    /// </summary>
    public bool LoadFinish
    {
        get
        {
            // 非动态场景立即完成
            //if (SceneHelp.Instance.MapInfo != null && SceneHelp.Instance.MapInfo.IsDynamic == false)
            //    return true;

            if (!mIsListen)
                return false;

            bool is_finish = false;
            float delta_time = Time.unscaledTime - mListenerTime;
            if ((delta_time > 2.0f && mListenerList.Count <= 0) || delta_time > 10.0f)
                is_finish = true;
            
            if(is_finish)
            {
                mListenerList.Clear();
                mIsListen = false;
                mListenerTime = 0;

                // 恢复加载的线程优先级
                float cost_time = Time.realtimeSinceStartup - mStartTime;
                Debug.Log("load scene part cost: " + cost_time);
                // 恢复帧率限制
                Application.targetFrameRate = Const.G_FPS;

                xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar(1.0f);
            }
            else
            {
                if (delta_time > 2.0f)
                {
                    int restListenerNum = (int)mMaxListenerNum - mListenerList.Count + 2;
                    xc.ui.ugui.UIManager.GetInstance().UpdateLoadingBar((1f - StartLoadPercentage) + StartLoadPercentage * ((float)restListenerNum / (float)mMaxListenerNum));
                }
            }

            return is_finish;
        }
    }

    /// <summary>
    /// 添加对QuadTreeSpaceCube的监听
    /// </summary>
    /// <param name="cube"></param>
    public void AddListener(QuadTreeSpaceCube cube)
    {
        if (!mIsListen)
            return;

        if (!mListenerList.Contains(cube))
        {
            mListenerList.Add(cube);

            mMaxListenerNum++;
        }
    }

    /// <summary>
    /// 移除对QuadTreeSpaceCube的监听
    /// </summary>
    /// <param name="cube"></param>
    public void RemoveListener(QuadTreeSpaceCube cube)
    {
        if(!mIsListen)
            return;

        if (mListenerList.Contains(cube))
            mListenerList.Remove(cube);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Application.lowMemory += OnLowMemory;
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Application.lowMemory -= OnLowMemory;
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
    }

    /// <summary>
    /// 场景加载后的回调
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene != null)
        {
            string info = string.Format("sceneload: {0}, graphics: {1}", scene.name, GlobalSettings.GetInstance().GraphicLevel);
            //Debug.Log(info);
            BuglyAgent.PrintLog(LogSeverity.LogInfo, info);
        }
    }

    /// <summary>
    /// 开启切换场景
    /// </summary>
    /// <param name="data"></param>
    void OnStartSwitchScene(CEventBaseArgs data)
    {
        mListenerList.Clear();
        mIsListen = false;
        mListenerTime = 0;
    }

    int mLowMemoryCount = 0;

    /// <summary>
    /// 应用内存不足时候的回调
    /// </summary>
    void OnLowMemory()
    {
        if (mLowMemoryCount >= 60)
            return;

        BuglyAgent.PrintLog(LogSeverity.LogInfo, "low memory");
        mLowMemoryCount++;
    }
}