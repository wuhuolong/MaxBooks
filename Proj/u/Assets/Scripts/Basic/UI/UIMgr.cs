using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//UI类型
//窗口/页面/Tips
public enum UIType
{
    None,
    Windows,
    Page,
    Tips,
}
public class UIMgr : CSSingleton<UIMgr>
{
    private static string m_UIPath = "Prefabs/UI/{0}.Prefab";
    private static string m_root_tag = "UIRoot";
    private static string m_mask_tag = "UIMask";

    private static StringBuilder sb;
    private GameKernel kernel;
    private UIBase[] m_uicache;

    private UIBase m_uiRoot;//UI根节点--canvas
    private UIMask m_bgMask;//背景遮罩

    public UIRoot uiRoot
    {
        get
        {
            return m_uiRoot as UIRoot;
        }
    }
    public bool isFirstShow = true;//用来第一次显示 UI时不做动画的标记

    private Canvas m_canvas;
    /// <summary>
    /// 当前页面
    /// </summary>
    private UIBase m_curPage;
    private Stack<int> m_uistacks;//UI栈，专门保存window和tips，用于返回键依次关闭UI，和深度管理
    private List<int> m_tips_cache;

    private GameObject LoadUI(int uiid)
    {
        string str = UIUtil.GetUITypeName(uiid);
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }
        sb.Clear();
        sb.Append(string.Format(m_UIPath, str));
        return ResMgr.LoadGameObject(sb.ToString());
    }
    public void LoadUIAsync(int uiid, Action<GameObject> callback)
    {
        string str = UIUtil.GetUITypeName(uiid);
        if (string.IsNullOrEmpty(str))
        {
            ResMgr.LogError(Tag, "LoadUIAsync", " uiid not exist ==>" + uiid); return;
        }
        sb.Clear();
        sb.Append(string.Format(m_UIPath, str));
        ResMgr.LoadGobjAsync(sb.ToString(), callback);
    }
    public void LoadUIAsync(int uiid, Action callback)
    {
        string str = UIUtil.GetUITypeName(uiid);
        if (string.IsNullOrEmpty(str))
        {
            ResMgr.LogError(Tag, "LoadUIAsync", "UIMgr uiid not exist ==>" + uiid); return;
        }
        sb.Clear();
        sb.Append(string.Format(m_UIPath, str));
        ResMgr.LoadGobjAsync(sb.ToString(), callback);
    }
    #region 外部接口

    protected override void Init()
    {
        kernel = GameKernel.GetInstance();

        m_uistacks = new Stack<int>();
        m_uicache = new UIBase[(int)UIPageEnum.Max];
        m_tips_cache = new List<int>();
        sb = new StringBuilder(256);

        //生成uiroot
        GameObject temp = ResMgr.LoadGameObject(string.Format(m_UIPath, m_root_tag));
        //Debug.Log(string.Format(m_UIPath, m_root_tag));
        m_uiRoot = temp.GetComponentInChildren<UIBase>();
        m_canvas = m_uiRoot.GetComponent<Canvas>();

        //Debug.Log("init the muiRoot");
        GameObject.DontDestroyOnLoad(temp);
        //生成背景遮罩
        temp = ResMgr.LoadGameObject(string.Format(m_UIPath, m_mask_tag), m_uiRoot.transform);
        m_bgMask = temp.GetComponent<UIMask>();
        m_bgMask.Hide();
    }
    public UIBase GetMuiroot()
    {
        return m_uiRoot;
    }
    #region UI logic   
    public void ShowPage(UIPageEnum uiid)
    {
        //ShowUI((int)uiid);
        ShowUIAsync((int)uiid, LoadWindCallback);
    }
    public void ShowPage_Play(UIPageEnum uiid)
    {
        //ShowUI_Play((int)uiid);
        //ShowUIAsync_Play((int)uiid, LoadWindCallback);
        ShowUIAsync((int)uiid, LoadWindCallback);
    }
    public void ShowSimpleTips(uint msgid)
    {
        ShowTips(UIPageEnum.TipsLabel_Page, msgid);
    }
    public void ShowTips(UIPageEnum uiid, params object[] argv)
    {
        //ShowUI((int)uiid);
        ShowUIAsync_Tips((int)uiid, LoadTipsCallback, argv);
    }
    public void ShowWindows(UIPageEnum uiid)
    {
        //ShowUI((int)uiid);
        ShowUIAsync((int)uiid, LoadWindCallback);
    }
    private void LoadPageCallback(UIBase ub, int uiid)
    {
        if (ub != null)
        {
            if (ub.IsNeedMask)
            {
                if (!m_bgMask.gameObject.activeInHierarchy)
                {
                    m_bgMask.Show();
                }
                m_bgMask.transform.SetSiblingIndex(-2);
            }
            ub.transform.SetAsLastSibling();
            if (null != m_curPage)
            {
                m_curPage.Close();
            }
            m_curPage = ub;
            ResMgr.Log(Tag, "LoadCallback", "load ui succ " + ub.GetType().ToString());
        }
        else
        {
            ResMgr.LogError(Tag, "LoadCallback", "load ui fail");
        }
    }
    private void LoadWindCallback(UIBase ub, int uiid)
    {
        if (ub != null)
        {
            if (ub.IsNeedMask)
            {
                if (!m_bgMask.gameObject.activeInHierarchy)
                {
                    m_bgMask.Show();
                }
                m_bgMask.transform.SetSiblingIndex(-2);
            }
            ub.transform.SetAsLastSibling();
            Push(uiid);
            ResMgr.Log("UIMgr", "LoadCallback", "load ui succ " + ub.GetType().ToString());
        }
        else
        {
            ResMgr.LogError("UIMgr", "LoadCallback", "load ui fail");
        }
    }
    private void LoadTipsCallback(UIBase ub, int uiid)
    {
        if (ub != null)
        {
            if (ub.IsNeedMask)
            {
                if (!m_bgMask.gameObject.activeInHierarchy)
                {
                    m_bgMask.Show();
                }
                m_bgMask.transform.SetSiblingIndex(-2);
            }
            ub.transform.SetAsLastSibling();
            _ins.m_tips_cache.Add(uiid);
            //Push(uiid);
            Debuger.Log("UIMgr", "LoadCallback", "load ui succ " + ub.GetType().ToString());
        }
        else
        {
            Debuger.LogError("UIMgr", "LoadCallback", "load ui fail");
        }
    }
    private UIBase ShowUI(int uiid)
    {
        UIBase ub = _ins.m_uicache[uiid];
        if (ub == null)
        {
            GameObject go = LoadUI(uiid);
            if (m_uiRoot == null)
                Debug.Log("muiRoot is null");
            go.transform.SetParent(m_uiRoot.transform, false);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            ub = go.GetComponent<UIBase>();
            _ins.m_uicache[uiid] = ub;
        }
        else
        {
            ub.gameObject.SetActive(true);
        }
        if (ub.IsNeedMask)
        {
            if (!m_bgMask.gameObject.activeInHierarchy)
            {
                m_bgMask.Show();
            }
            m_bgMask.transform.SetSiblingIndex(-2);
        }
        ub.transform.SetAsLastSibling();
        Push(uiid);
        return ub;
    }

    private void ShowUIAsync(int uiid, Action<UIBase, int> callback = null, params object[] argc)
    {
        //System.Diagnostics.Stopwatch wa = new System.Diagnostics.Stopwatch();
        //wa.Reset();
        //wa.Start();
        ResMgr.Log(Tag, "ShowUIAsync", "==>" + uiid);
        UIBase ub = _ins.m_uicache[uiid];
        if (ub == null)
        {
            Action<GameObject> cb = (go) =>
            {
                if (m_uiRoot == null)
                    Debug.Log("muiRoot is null");
                go.transform.SetParent(m_uiRoot.transform, false);
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = Vector3.one;
                ub = go.GetComponent<UIBase>();
                _ins.m_uicache[uiid] = ub;
                if (callback != null)
                {
                    callback(ub, uiid);
                }
            };

            LoadUIAsync(uiid, cb);

        }
        else
        {
            ub.gameObject.SetActive(true);
            if (ub.IsNeedMask)
            {
                if (!m_bgMask.gameObject.activeInHierarchy)
                {
                    m_bgMask.Show();
                }
                m_bgMask.transform.SetSiblingIndex(-2);
            }
            ub.transform.SetAsLastSibling();
            if (callback != null)
            {
                callback(ub, uiid);
            }
            //Debug.Log("2:"+wa.ElapsedMilliseconds);
        }
    }

    private void ShowUIAsync_Play(int uiid, Action<UIBase, int> callback = null)
    {
        UIBase ub = _ins.m_uicache[uiid];
        if (ub == null)
        {
            Action<GameObject> cb = (go) =>
            {
                if (m_uiRoot == null)
                    Debug.Log("muiRoot is null");
                go.transform.SetParent(m_uiRoot.transform.parent, false);
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = Vector3.one;
                ub = go.GetComponent<UIBase>();
                _ins.m_uicache[uiid] = ub;
                if (callback != null)
                {
                    callback(ub, uiid);
                }
            };
            LoadUIAsync(uiid, cb);

        }
        else
        {
            ub.gameObject.SetActive(true);
            if (ub.IsNeedMask)
            {
                if (!m_bgMask.gameObject.activeInHierarchy)
                {
                    m_bgMask.Show();
                }
                m_bgMask.transform.SetSiblingIndex(-2);
            }
            ub.transform.SetAsLastSibling();
            if (callback != null)
            {
                callback(ub, uiid);
            }
        }

    }

    private void ShowUIAsync_Tips(int uiid, Action<UIBase, int> callback = null, params object[] argv)
    {
        ResMgr.Log(Tag, "ShowUIAsync", "==>" + uiid);
        UITips ub = (UITips)_ins.m_uicache[uiid];
        if (ub == null)
        {
            Action<GameObject> cb = (go) =>
            {
                if (m_uiRoot == null)
                    Debug.Log("muiRoot is null");
                go.transform.SetParent(m_uiRoot.transform, false);
                go.transform.localPosition = Vector3.zero;
                go.transform.localScale = Vector3.one;
                ub = go.GetComponent<UITips>();
                ub.argv = argv;
                ub.OnShowTips();
                _ins.m_uicache[uiid] = ub;
                if (callback != null)
                {
                    callback(ub, uiid);
                }
            };
            LoadUIAsync(uiid, cb);

        }
        else
        {
            ub.argv = argv;
            ub.gameObject.SetActive(true);
            ub.OnShowTips();
            if (ub.IsNeedMask)
            {
                if (!m_bgMask.gameObject.activeInHierarchy)
                {
                    m_bgMask.Show();
                }
                m_bgMask.transform.SetSiblingIndex(-2);
            }
            ub.transform.SetAsLastSibling();
            if (callback != null)
            {
                callback(ub, uiid);
            }
        }
    }

    private UIBase ShowUI_Play(int uiid)
    {
        UIBase ub = _ins.m_uicache[uiid];
        if (ub == null)
        {
            GameObject go = LoadUI(uiid);
            if (m_uiRoot == null)
                Debug.Log("muiRoot is null");
            go.transform.SetParent(m_uiRoot.transform.parent, false);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            ub = go.GetComponent<UIBase>();
            _ins.m_uicache[uiid] = ub;
        }
        else
        {
            ub.gameObject.SetActive(true);
        }
        if (ub.IsNeedMask)
        {
            if (!m_bgMask.gameObject.activeInHierarchy)
            {
                m_bgMask.Show();
            }
            m_bgMask.transform.SetSiblingIndex(-2);
        }
        ub.transform.SetAsLastSibling();
        Push(uiid);
        return ub;
    }

    #endregion

    private void Push(int uiid)
    {
        UIBase ub = _ins.m_uicache[uiid];
        kernel.StartCoroutine(ub.DoTween(false, uiid, DoTweenOnPush));
    }
    private void OnPush()
    {
        int tipsid;
        for (int i = _ins.m_tips_cache.Count - 1; i > -1; i--)
        {
            tipsid = _ins.m_tips_cache[i];
            _ins.m_uicache[tipsid].Close();
            _ins.m_tips_cache.RemoveAt(i);
        }
    }

    public void Pop()
    {
        if (_ins.m_uistacks.Count == 0)
        {
            m_bgMask.Hide();
            return;
        }
        int uiid = _ins.m_uistacks.Pop();
        UIBase ub = _ins.m_uicache[uiid];
        kernel.StartCoroutine(ub.DoTween(false, uiid, DoTweenOnPop));
    }
    #endregion

    #region Tween
    void DoTweenOnPop(int uiid)
    {
        //logic

        UIBase ub = _ins.m_uicache[uiid];
        _ins.m_uicache[uiid].Close();

        uiid = _ins.m_uistacks.Peek();
        ub = _ins.m_uicache[uiid];
        ub.gameObject.SetActive(true);
        if (ub.IsNeedMask)
        {
            m_bgMask.transform.SetSiblingIndex(-2);
        }
        else
        {
            m_bgMask.Hide();
        }
        m_bgMask.IsClickBgClose = ub.IsClickBgClose;
        ub.gameObject.transform.SetAsLastSibling();

    }
    void DoTweenOnPush(int uiid)
    {
        UIBase ub = _ins.m_uicache[uiid];

        if (_ins.m_uistacks.Count > 0)
        {
            int id = _ins.m_uistacks.Peek();
            _ins.m_uicache[id].Close();
        }
        OnPush();
        ub.gameObject.SetActive(true);
        _ins.m_uistacks.Push((int)uiid);
    }
    #endregion
}
