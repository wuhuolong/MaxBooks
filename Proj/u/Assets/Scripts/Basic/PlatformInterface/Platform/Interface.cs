using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChanelType
{
    iOS,
    Android,
    PC,
}
public abstract class SdkInterface
{
    public abstract bool isRewardVideoReady();
    public abstract void showRewardVideo();
}
