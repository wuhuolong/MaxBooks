using System.Collections;
using System;
using LitJson;
using UnityEngine;
using X.Res;

public class AdMgr:MonoSingleton<AdMgr>
{
    FuncParamConfig config = FuncMgr.GetInstance().GetConfigByID(2);
    public int playTimes = 0;
    public int startUpCount = -1;
    public int tmpCount;
    public int index;

    public bool isPaying = false;

    public bool isRewardVideoReady()
    {
        return SDKMgr.GetInstance().isRewardVideoReady();
    }
    public static readonly string Pay2RemoveAD_Tag = "Pay2RemoveAD";

    public bool isPaid()
    {
        return XPlayerPrefs.GetInt(AdMgr.Pay2RemoveAD_Tag) == 1;
    }

    public void showRewardVideo(Action onReward,Action onFail,Action onClose)
    {
        if (isPaid())
        {
            onReward();
            return;
        }
        SDKMgr.GetInstance().showRewardVideo(onReward, onFail, onClose);
    }

    public void InterstitialTrigger(Action onReward=null, Action onFail=null, Action onClose=null)
    {
        if (isPaid())
        {
            if (onReward != null)
            {
                onReward();
            }
            return;
        }
        tmpCount = XPlayerPrefs.GetInt("StartUpCount");
        //int startUpCount = XPlayerPrefs.GetInt("StartUpCount");
        if (startUpCount!= tmpCount)
        {
            startUpCount = tmpCount;
            Debug.Log("StartUpCount" + startUpCount);
            if(startUpCount>config.Params1[config.Params1.Count-1])
            {
                index = config.Params1.Count - 1;
            }
            else
            {
                index = config.Params1.IndexOf(startUpCount);
            }
            Debug.Log("first"+ index);
            playTimes = config.Params2[index];
        }
        if (playTimes == 0)
        {
            playTimes = config.Params3[index];
        }
        playTimes--;
        Debug.Log("playTimes"+playTimes);
        if(playTimes==0)
        {
            //TODO:播放广告
			SDKMgr.GetInstance().showIntersitialAD(onReward, onFail, onClose);

#if UNITY_EDITOR
            Debug.Log("激励广告");
#endif
        }
    }

    public void Pay4RemoveAD()
    {
        if (isPaying)
        {
            //todo 此处应该有tips
            return;
        }
        isPaying = true;
        SDKMgr.GetInstance().pay4RemoveAd();
    }
}
