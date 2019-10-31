using System.Collections;
using System;
using LitJson;
using UnityEngine;

public class AdMgr:MonoSingleton<AdMgr>
{

    public bool isRewardVideoReady()
    {
        return SDKMgr.GetInstance().isRewardVideoReady();
    }

    public void showRewardVideo(Action onReward,Action onFail,Action onClose)
    {
        SDKMgr.GetInstance().showRewardVideo(onReward, onFail, onClose);
    }
}
