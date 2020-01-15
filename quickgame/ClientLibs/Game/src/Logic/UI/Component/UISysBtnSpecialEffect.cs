//------------------------------------------------------------------------------
// Desc   :  系统按钮特殊效果组件
// Author :  XiongWei
// Date   :  2018.10.15
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using xc.ui.ugui;
using xc;

[wxb.Hotfix]
public class UISysBtnSpecialEffect : MonoBehaviour
{
    UISysConfigBtn mSysConfigBtn;
    string mSpecialName = "";

    /// <summary>
    /// 初始化按钮的名字
    /// </summary>
    string GetBtnName()
    {
        if (string.IsNullOrEmpty(mSpecialName))
            mSpecialName = "Special" + gameObject.name;

        return mSpecialName;
    }

    public void Start()
    {
        //送审下 关闭特效
        if(AuditManager.Instance.AuditAndIOS())
            return;


        mSysConfigBtn = GetComponent<UISysConfigBtn>();
        if (mSysConfigBtn == null)
        {
            return;
        }

        AddListener();

        Transform specialRoot = null;
        var window = UIManager.Instance.GetWindow("UIMainmapWindow");
        if(window != null)
        {
            var go = window.FindChild("SpecialBtnPanel");
            specialRoot = go.GetComponent<Transform>();
        }

        //Transform specialRoot = transform.parent.parent.parent.parent.parent.parent.Find("SpecialBtnPanel");
        if(specialRoot != null)
        {
            Transform specialTransform = specialRoot.Find(GetBtnName());
            if (specialTransform != null)
            {
                GameObject specialGmaeObject = GameObject.Instantiate(specialTransform.gameObject);
                specialGmaeObject.name = GetBtnName();
                specialTransform = specialGmaeObject.transform;
                specialTransform.SetParent(transform.Find("SysBtn"), false);
                specialTransform.SetAsFirstSibling();
            }
        }
      
        UpdateState();
    }

    void AddListener()
    {
        ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_SHOW, OnShowRedPoint);
        ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, OnDisappearRedPoint);
    }

    void OnShowRedPoint(CEventBaseArgs event_param)
    {
        if (event_param == null || event_param.arg == null)
            return;
        UpdateState();
    }

    void OnDisappearRedPoint(CEventBaseArgs event_param)
    {
        if (event_param == null || event_param.arg == null)
            return;
        UpdateState();
    }

    void UpdateState()
    {
        Transform specialTransform = transform.Find("SysBtn").Find(GetBtnName());
        if (specialTransform == null)
        {
            return;
        }
        bool isRedPointEnable = RedPointDataMgr.Instance.GetRedPointVisible(mSysConfigBtn.UIMainBtnId);
        CommonTool.SetActive(specialTransform.gameObject, isRedPointEnable);
        mSysConfigBtn.EnableIcon(!isRedPointEnable);
    }

    void OnDestroy()
    {
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_SHOW, OnShowRedPoint);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, OnDisappearRedPoint);
    }
}
