using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public UIType UIType = UIType.None;
    public bool IsNeedMask = true;
    public bool IsClickBgClose = false;
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
