//------------------------------------------------------------------------------
// FileName: FPSNotice.cs
// Desc: FPS低于某项参数的时候进行提示
// Author: Raorui
// Date: 2018.8.24
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using xc;

public class FPSNotice : DebugFPS
{
    /// <summary>
    /// fps低于该数值则进行提示
    /// </summary>
    static int mFpsMinLimit = 15;

    /// <summary>
    /// 进行提示的间隔时间(秒)
    /// </summary>
    static int mFpsNoticeIntervalTime = 600;

    /// <summary>
    /// 上次提示的时间
    /// </summary>
    float mLastNoticeTime = -1;
    ulong mLogCount = 1;

    private string mLogFmt = "TestinLog-Event>>>> ID FPS, Key FPS{0}, Value {1}";

    public override void Awake()
    {
        base.Awake();

        DrawFPS = false;

        var const_float_val = GameConstHelper.GetFloat("FPS_WAIT_TIME"); // fps检测的间隔时间
        if (const_float_val != 0)
            FPSUpdateWaitTime = const_float_val;

        var const_int_val = GameConstHelper.GetInt("FPS_MIN_LIMIT");
        if (const_int_val != 0)
            mFpsMinLimit = const_int_val;

        const_int_val = GameConstHelper.GetInt("FPS_NOTICE_INTERVALTIME");
        if (const_int_val != 0)
            mFpsNoticeIntervalTime = const_int_val;
    }

    void OnFPSUpdate()
    {
        if (mFPS < mFpsMinLimit)
        {
            float now = Time.time;
            if (mLastNoticeTime != -1)
            {
                if (now - mLastNoticeTime < mFpsNoticeIntervalTime)
                    return;
            }

            mLastNoticeTime = now;
            ClientEventMgr.Instance.PostEvent((int)ClientEvent.CE_SETTING_LOW_FPS, null);
            //UINotice.Instance.ShowMessage("检测到您当前游戏运行不太流畅，建议前往设置调整");
        }
    }

    public override void Update()
    {
        float now = Time.time;

        if (Game.GetInstance().IsSwitchingScene || !SceneHelp.Instance.IsPlayingInstance)
        {
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

            // TestinExternalLog
            var logContent = string.Format(mLogFmt, mLogCount, mFPS);
            DBOSManager.getOSBridge().log2OSCmd("TestinExternalLog", logContent);

            mLogCount += 1;

            OnFPSUpdate();
        }
    }
}