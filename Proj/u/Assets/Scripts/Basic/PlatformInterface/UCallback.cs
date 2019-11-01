using LitJson;
using System;

public class UCallback : MonoSingleton<UCallback>
{
    //播放激励广告的回调
    public Action onReward;
    public Action onFail;

    public void SdkInterfaceCallback(string json)
    {
        JsonData data = JsonMapper.ToObject(json);
        SDKMsgType type = (SDKMsgType)(int)data["Type"];
        this.Log("SdkInterfaceCallback ==> "+json);
        switch (type)
        {
            case SDKMsgType.OnRewardAdShowOver:
                OnRewardedVideoBack(data);
                break;
            default:
                this.LogError("sdk call back type error");
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
