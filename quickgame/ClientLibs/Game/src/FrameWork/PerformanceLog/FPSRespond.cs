//------------------------------------------------------------------------------
// FileName: FPSRespond.cs
// Desc: 针对FPS的数据进行性能和参数上的调整
// Author: Raorui
// Date: 2016.5.23
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using xc;


public class FPSRespond : DebugFPS
{
    public override void Awake()
    {
        base.Awake();

        //fpsRT = new Rect(Screen.width - 100, 30, 80, 20);

        DrawFPS = false;
    }

    void OnFPSUpdate()
    {
        float factor = CullManager.Instance.Factor;
        if(mFPS < 22)
        {
            float newFactor = Math.Max(factor * 0.8f, 0.1f);
            if(newFactor != factor)
            {
                CullManager.Instance.Factor = newFactor;
                CullManager.Instance.SetDirty();
            }

        }
        else if(mFPS >= 28)
        {
            float newFactor = Math.Min(factor * 1.2f, 1.0f);
            if(newFactor != factor)
            {
                CullManager.Instance.Factor = newFactor;
                CullManager.Instance.SetDirty();
            }
        }
    }

    public override void Update() 
    {
        float now = Time.time;

        if(Game.GetInstance().IsSwitchingScene || !SceneHelp.Instance.IsPlayingInstance )
        {
            CullManager.Instance.Factor = 1.0f;
            mFPS = 0;
            mFrameCount = 0;
            mLastTime = now;

            return;
        }

        mFrameCount++;
        if (now >= mLastTime + FPSUpdateWaitTime)
        {
            float fps = mFrameCount / (now - mLastTime);
            mFPS = (int)fps;
            mFrameCount = 0;
            mLastTime = now;

            OnFPSUpdate();
        }
    }
}