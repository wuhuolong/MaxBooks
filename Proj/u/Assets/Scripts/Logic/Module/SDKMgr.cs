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

    public void showIntersitialAD(Action onReward, Action onFail, Action onClose)
    {
        UCallback.GetInstance().onReward = onReward;
        UCallback.GetInstance().onFail = onFail;
        m_interface.showInterstitialAd();
    }

    public void SendSdkMsg(string json)
    {
        m_interface.sendMsg(json);
    }
    public void Track(SDKMsgType type,params object[] args)
    {
        JsonData data = new JsonData();
        data["Type"] = (int)type;
        int levelid;
        switch (type)
        {
            //case SDKMsgType.OnRewardAdShowOver://
            //    break;
            //case SDKMsgType.OnRewardAdShow://TODO
            //    break;
            case SDKMsgType.OnLevelEnter:
                levelid = (int)args[0];
                data["LevelID"] = levelid;
                break;
            case SDKMsgType.OnLevelClear:
                levelid = (int)args[0];
                data["LevelID"] = levelid;
                break;
            case SDKMsgType.OnClickADPuzzle:
                break;
            //case SDKMsgType.OnUnlockAdPuzzle:
            //    break;
            case SDKMsgType.OnPay2RemoveAd:
                break;
            //case SDKMsgType.OnPay2RemoveAdSucc:
            //    break;
            case SDKMsgType.OnScreenshots:
                break;
            case SDKMsgType.OnCallEvaluation:
                break;
            default:
                break;
        }
        SendSdkMsg(data.ToJson());
    }
    public LangType GetSystemLang()
    {
        string temp = m_interface.GetCurLang();
        LangType type;
        if (Enum.TryParse<LangType>(temp,out type))
        {
            return type;
        }
        return LangType.zh_Hans;
    }
}

public enum SDKMsgType
{
    //*****start track*****
    /// <summary>
    /// 结算广告展示
    /// </summary>
    OnRewardAdShow = 1,
    /// <summary>
    /// 结算广告展示成功
    /// </summary>
    OnRewardAdShowOver = 2,
    /// <summary>
    /// 关卡进入
    /// </summary>
    OnLevelEnter = 3,
    /// <summary>
    /// 关卡通过
    /// </summary>
    OnLevelClear = 4,
    /// <summary>
    /// 广告方块广告展示
    /// </summary>
    OnClickADPuzzle = 5,
    /// <summary>
    /// 广告方块解锁成功
    /// </summary>
    OnUnlockAdPuzzle = 6,
    /// <summary>
    /// 去广告功能触发
    /// </summary>
    OnPay2RemoveAd = 7,
    /// <summary>
    /// 去广告付费成功
    /// </summary>
    OnPay2RemoveAdSucc = 8,
    /// <summary>
    /// 结算截图使用次数
    /// </summary>
    OnScreenshots = 9,
    /// <summary>
    /// 调起商店评价
    /// </summary>
    OnCallEvaluation = 10,
    //*****end track*****
}
