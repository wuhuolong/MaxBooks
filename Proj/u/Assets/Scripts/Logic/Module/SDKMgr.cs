using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SDKMgr : CSSingleton<SDKMgr>
{
    private SdkInterface m_interface;
    protected override void Init()
    {
#if UNITY_IOS &&!UNITY_EDITOR
        Debug.Log("Sdk init iosSdkInterface");
        m_interface = new iosSdkInterface();
#elif UNITY_ANDROID &&!UNITY_EDITOR
        Debug.Log("Sdk init androidInterface");
        m_interface = new androidInterface();
#else
        Debug.Log("Sdk init pcSdkInterface");
        m_interface = new pcSdkInterface();
#endif
        UCallback.GetInstance();
    }

    public void Test()
    {
        m_interface.Test();
    }
    public bool isRewardVideoReady()
    {
        return m_interface.isRewardVideoReady();
    }
    public void showRewardVideo(Action onReward, Action onFail, Action onClose)
    {
        UCallback.GetInstance().onReward = onReward;
        UCallback.GetInstance().onFail = onFail;
        m_interface.showRewardVideo();
    }
    public void SendSdkMsg(string json)
    {
        m_interface.sendMsg(json);
    }
}
public enum SDKMsgType
{
    OnRewardedVideoBack = 1,
}
