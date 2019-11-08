using LitJson;
using System;

public class UCallback : MonoSingleton<UCallback>
{
    //播放激励广告的回调
    public Action onReward;
    public Action onFail;
    private static string m_Tag = "UCallback";
    private static string m_Func_Tag = "SdkInterfaceCallback";
    public void SdkInterfaceCallback(string json)
    {
        JsonData data = JsonMapper.ToObject(json);
        SDKMsgType type = (SDKMsgType)(int)data["Type"];
        UnityEngine.Debug.Log(m_Tag +"==>"+ json);
        switch (type)
        {
            case SDKMsgType.OnUnlockAdPuzzle:
                OnRewardedVideoBack(data);
                break;
            case SDKMsgType.OnRewardAdShowOver:
                OnRewardedVideoBack(data);
                break;
            default:
                Debuger.LogError(m_Tag, m_Func_Tag, "sdk call back type error");
                break;
        }
    }
    private void OnRewardedVideoBack(JsonData data)
    {
        int retcode = (int)data["Ret"];
        if (retcode == 1)
        {
            if (onReward != null)
            {
                onReward();
            }
        }
        else
        {
            if (onFail != null)
            {
                onFail();
            }
        }
        onReward = null;
        onFail = null;
    }
}
