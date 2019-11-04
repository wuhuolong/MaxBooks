using System.Runtime.InteropServices;
using LitJson;

public enum ChanelType
{
    iOS,
    Android,
    PC,
}
public abstract class SdkInterface
{
    public abstract void Test();
    public abstract bool isRewardVideoReady();
    public abstract void showRewardVideo();
    public abstract void sendMsg(string json);
}
public class androidInterface : SdkInterface
{
    public override bool isRewardVideoReady()
    {
        this.Log("isRewardVideoReady");
        return false;
    }

    public override void sendMsg(string json)
    {
        this.Log("sendMsg ==> "+json);
    }



    public override void showRewardVideo()
    {
        this.Log("showRewardVideo");
    }

    public override void Test()
    {
        this.Log("Test");
    }
}

public class pcSdkInterface : SdkInterface
{
    public override bool isRewardVideoReady()
    {
        this.Log("isRewardVideoReady");
        return false;
    }

    public override void sendMsg(string json)
    {
        this.Log("sendMsg ==> " + json);
    }

    public override void showRewardVideo()
    {
        JsonData data = new JsonData();
        data["Type"] = 1;
        data["Ret"] = 1;
        string json = data.ToJson();
        UCallback.GetInstance().SendMessage("SdkInterfaceCallback", json);
    }

    public override void Test()
    {
        this.Log("Test");
    }
}
public class iosSdkInterface : SdkInterface
{
    [DllImport("__Internal")]
    private static extern void test();
    [DllImport("__Internal")]
    private static extern bool _isRewardVideoReady();
    [DllImport("__Internal")]
    private static extern void _showRewardVideo();
    [DllImport("__Internal")]
    private static extern void _SendMsg(string json);

    public override bool isRewardVideoReady()
    {
        return _isRewardVideoReady();
    }

    public override void showRewardVideo()
    {
        _showRewardVideo();
    }

    public override void sendMsg(string json)
    {
        _SendMsg(json);
    }

    public override void Test()
    {
        test();
    }

}