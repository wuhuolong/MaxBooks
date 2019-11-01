using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

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
    public void Track(SDKMsgType type,params object[] args)
    {
        JsonData data = new JsonData();
        switch (type)
        {
            case SDKMsgType.OnRewardAdShowOver:
                break;
            case SDKMsgType.OnRewardAdShow:
                break;
            case SDKMsgType.OnLevelEnter:
                break;
            case SDKMsgType.OnLevelClear:
                int levelid = (int)args[0];
                data["LevelID"] = levelid;
                data["Type"] = (int)SDKMsgType.OnLevelClear;
                SendSdkMsg(data.ToJson());
                break;
            case SDKMsgType.OnClickADPuzzle:
                break;
            case SDKMsgType.OnUnlockAdPuzzle:
                break;
            case SDKMsgType.OnPay2RemoveAd:
                break;
            case SDKMsgType.OnPay2RemoveAdSucc:
                break;
            case SDKMsgType.OnScreenshots:
                break;
            default:
                break;
        }
    }
}

public enum SDKMsgType
{
    //*****start track*****
    /// <summary>
    /// 结算广告展示成功
    /// </summary>
    OnRewardAdShowOver = 1,
    /// <summary>
    /// 结算广告展示
    /// </summary>
    OnRewardAdShow,
    /// <summary>
    /// 关卡进入
    /// </summary>
    OnLevelEnter,
    /// <summary>
    /// 关卡通过
    /// </summary>
    OnLevelClear,
    /// <summary>
    /// 广告方块广告展示
    /// </summary>
    OnClickADPuzzle,
    /// <summary>
    /// 广告方块解锁成功
    /// </summary>
    OnUnlockAdPuzzle,
    /// <summary>
    /// 去广告功能触发
    /// </summary>
    OnPay2RemoveAd,
    /// <summary>
    /// 去广告付费成功
    /// </summary>
    OnPay2RemoveAdSucc,
    /// <summary>
    /// 结算截图使用次数
    /// </summary>
    OnScreenshots,
    //*****end track*****
}
