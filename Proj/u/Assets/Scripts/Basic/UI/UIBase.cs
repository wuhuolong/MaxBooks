using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{

    protected static readonly float AnimatTime = 0.3f;

    public UIType UIType = UIType.None;
    public bool IsNeedMask = true;
    public bool IsClickBgClose = false;
    public bool IsAnim = true;

    //public object[] argc;
    private void Awake()
    {
        this.InitComp();
    }

    private void Start()
    {
        this.InitData();
    }
    protected void Log(string msg)
    {
        //Debug.Log(msg);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    //用来初始化UI组件
    protected abstract void InitComp();
    //暂时放Start获取数据，如果需要网络请求，就把这个放别的地方先请求，再调用showUI
    protected abstract void InitData();
    protected virtual void AfterTween() { }
    public virtual IEnumerator DoTween(bool isleft,int uiid, Action<int> onend)
    {
        if (!IsAnim)
        {
            if (onend != null)
            {
                onend(uiid);
            }
            AfterTween();
            yield break;
        }
        Debug.Log("virtual ==> DoTween -- "+GetType().ToString());
        float now = 0f;
        float progress = 0f;
        //RectTransform rt = ub.GetComponent<RectTransform>();
        Vector3 target = Vector3.zero;//rt.position;
        UIRoot root = UIMgr.GetInstance().uiRoot;
        Vector3 v3 = isleft ? root.LeftPoint : root.RightPoint;
        transform.position = v3;
        Vector3 v33 = v3;
        while (AnimatTime > now)
        {
            progress = now / AnimatTime;
            float newx = Mathf.Lerp(v3.x, 0, progress);
            v33.x = newx;
            //rt.position = v33;
            transform.position = v33;
            now += Time.deltaTime;
            yield return null;
        }
        v33.x = 0;
        transform.position = v33;
        if (onend != null)
        {
            onend(uiid);
        }
        AfterTween();
    }
}
public abstract class UIWindows : UIBase
{

}
public abstract class UITips : UIBase
{
    public object[] argv;
    public abstract void OnShowTips();
}
public abstract class UIPage : UIBase
{

}
