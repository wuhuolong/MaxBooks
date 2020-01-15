//------------------------------------------------------------------------------
// Desc   :  新手引导完成组件
// Author :  XiongWei
// Date   :  2018.7.13
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using xc.ui.ugui;
using xc;

public class UIFinishGuideBtn : MonoBehaviour
{
    public uint GuideId = 0;
    public uint StepId = 0;
    Button mButton;

    void Awake()
    {
    }

    void Start()
    {
        if (GuideId == 0 || StepId == 0)
        {
            return;
        }
        mButton = GetComponent<Button>();
        if (mButton == null)
        {
            mButton = gameObject.AddComponent<Button>();
        }
        if (mButton != null)
        {
            mButton.onClick.AddListener(OnClickButton);
        }
    }

    void OnClickButton()
    {
        GuideManager.Instance.FinishGuideStep(GuideId, StepId);
    }

    void OnDestroy()
    {
        if (mButton != null)
        {
            mButton.onClick.RemoveListener(OnClickButton);
            mButton = null;
        }
    }
}
