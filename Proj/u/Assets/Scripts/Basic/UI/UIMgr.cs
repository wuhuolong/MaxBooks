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
public class UIMgr
{
    private static string Tag = "UIMgr";

    private static string m_UIPath = "Prefabs/UI/{0}.Prefab";
    private static string m_root_tag = "UIRoot";
    private static string m_mask_tag = "UIMask";
    private static UIMgr _ins = null;
    private static UIMgr _Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new UIMgr();
            }
            return _ins;
        }
        set
        {
            _ins = value;
        }
    }
    private UIMgr()
    {
        m_uistacks = new Stack<int>();
        m_uicache = new UIBase[(int)UIPageEnum.Max];
        m_tips_cache = new List<int>();
        sb = new StringBuilder(256);
    }

    private static StringBuilder sb;

    private UIBase[] m_uicache;

    private static UIBase m_uiRoot;//UI根节点--canvas
    private static UIMask m_bgMask;//背景遮罩
    /// <summary>
    /// 当前页面
    /// </summary>
    private static UIBase m_curPage;
    private Stack<int> m_uistacks;//UI栈，专门保存window和tips，用于返回键依次关闭UI，和深度管理
    private List<int> m_tips_cache;

    private static GameObject LoadUI(int uiid)
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
    public static void LoadUIAsync(int uiid, Action<GameObject> callback)
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
    public static void LoadUIAsync(int uiid, Action callback)
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

    public static void Init()
    {
        //生成uiroot
        GameObject temp = ResMgr.LoadGameObject(string.Format(m_UIPath, m_root_tag));
        //Debug.Log(string.Format(m_UIPath, m_root_tag));
        m_uiRoot = temp.GetComponentInChildren<UIBase>();
        //Debug.Log("init the muiRoot");
        GameObject.DontDestroyOnLoad(temp);
        //生成背景遮罩
        temp = ResMgr.LoadGameObject(string.Format(m_UIPath, m_mask_tag), m_uiRoot.transform);
        m_bgMask = temp.GetComponent<UIMask>();
        m_bgMask.Hide();
    }
    public static UIBase GetMuiroot()
    {
        return m_uiRoot;
    }
    #region UI logic   
    public static void ShowPage(UIPageEnum uiid)
    {
        //ShowUI((int)uiid);
        ShowUIAsync((int)uiid, LoadWindCallback);
    }
    public static void ShowPage_Play(UIPageEnum uiid)
    {
        //ShowUI_Play((int)uiid);
        ShowUIAsync_Play((int)uiid, LoadWindCallback);
    }
    public static void ShowTips(UIPageEnum uiid, params object[] argc)
    {
        //ShowUI((int)uiid);
        ShowUIAsync_Tips((int)uiid, LoadTipsCallback, argc);
    }
    public static void ShowWindows(UIPageEnum uiid)
    {
        //ShowUI((int)uiid);
        ShowUIAsync((int)uiid, LoadWindCallback);
    }
    private static void LoadPageCallback(UIBase ub, int uiid)
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
    private static void LoadWindCallback(UIBase ub, int uiid)
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
    private static void LoadTipsCallback(UIBase ub, int uiid)
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
            _Ins.m_tips_cache.Add(uiid);
            //Push(uiid);
            Debuger.Log("UIMgr", "LoadCallback", "load ui succ " + ub.GetType().ToString());
        }
        else
        {
            Debuger.LogError("UIMgr", "LoadCallback", "load ui fail");
        }
    }
    private static UIBase ShowUI(int uiid)
    {
        UIBase ub = _Ins.m_uicache[uiid];
        if (ub == null)
        {
            GameObject go = LoadUI(uiid);
            if (m_uiRoot == null)
                Debug.Log("muiRoot is null");
            go.transform.SetParent(m_uiRoot.transform, false);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            ub = go.GetComponent<UIBase>();
            _Ins.m_uicache[uiid] = ub;
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

    private static void ShowUIAsync(int uiid, Action<UIBase, int> callback = null, params object[] argc)
    {
        //System.Diagnostics.Stopwatch wa = new System.Diagnostics.Stopwatch();
        //wa.Reset();
        //wa.Start();
        ResMgr.Log(Tag, "ShowUIAsync", "==>" + uiid);
        UIBase ub = _Ins.m_uicache[uiid];
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
                _Ins.m_uicache[uiid] = ub;
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

    private static void ShowUIAsync_Play(int uiid, Action<UIBase, int> callback = null)
    {
        UIBase ub = _Ins.m_uicache[uiid];
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
                _Ins.m_uicache[uiid] = ub;
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

    private static void ShowUIAsync_Tips(int uiid, Action<UIBase, int> callback = null, params object[] argc)
    {
        ResMgr.Log(Tag, "ShowUIAsync", "==>" + uiid);
        UITips ub = (UITips)_Ins.m_uicache[uiid];
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
                ub.argc = argc;
                ub.OnShowTips();
                _Ins.m_uicache[uiid] = ub;
                if (callback != null)
                {
                    callback(ub, uiid);
                }
            };
            LoadUIAsync(uiid, cb);

        }
        else
        {
            ub.argc = argc;
            ub.OnShowTips();
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

    private static UIBase ShowUI_Play(int uiid)
    {
        UIBase ub = _Ins.m_uicache[uiid];
        if (ub == null)
        {
            GameObject go = LoadUI(uiid);
            if (m_uiRoot == null)
                Debug.Log("muiRoot is null");
            go.transform.SetParent(m_uiRoot.transform.parent, false);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            ub = go.GetComponent<UIBase>();
            _Ins.m_uicache[uiid] = ub;
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

    private static bool Push(int uiid)
    {
        if (_Ins.m_uistacks.Count > 0)
        {
            int id = _Ins.m_uistacks.Peek();
            _Ins.m_uicache[id].Close();
        }
        OnPush();
        _Ins.m_uistacks.Push((int)uiid);
        return true;
    }
    private static void OnPush()
    {
        int tipsid;
        for (int i = _ins.m_tips_cache.Count - 1; i > -1; i--)
        {
            tipsid = _ins.m_tips_cache[i];
            _ins.m_uicache[tipsid].Close();
            _ins.m_tips_cache.RemoveAt(i);
        }
    }
    public static void Pop()
    {
        if (_ins.m_uistacks.Count == 0)
        {
            m_bgMask.Hide();
            return;
        }
        int uiid = _ins.m_uistacks.Pop();
        _ins.m_uicache[uiid].Close(); ;
        {
            uiid = _ins.m_uistacks.Peek();
            UIBase ub = _ins.m_uicache[uiid];
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
    }
    #endregion
}
