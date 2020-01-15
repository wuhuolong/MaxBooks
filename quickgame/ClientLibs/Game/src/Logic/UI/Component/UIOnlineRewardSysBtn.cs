//------------------------------------------------------------------------------
// Desc   :  在线奖励系统按钮组件，有倒计时和抖动动画
// Author :  XiongWei
// Date   :  2018.3.23
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using xc.ui.ugui;
using xc;

public class UIOnlineRewardSysBtn : MonoBehaviour
{
    Utils.Timer mTimer = null;
    Transform timerTextTrans;
    Animation mAnimation = null;
    GameObject effect;

    void Awake()
    {
    }

    void Start()
    {
        timerTextTrans = this.transform.Find("SysBtn").Find("TimerText");
        if (timerTextTrans == null)
        {
            GameDebug.LogError("UIOnlineRewardSysBtn SetTimer error!!! Can not find TimerText!!!");
            return;
        }
        effect = this.transform.Find("SysBtn").Find("EF_UI_zhujiemianlingqu").gameObject;
        if (effect == null)
        {
            GameDebug.LogError("UIOnlineRewardSysBtn Can not find EF_UI_zhujiemianlingqu!!!");
        }

        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ONLINE_REWARD_INFO_CHANGED, OnOnlineRewardInfoChanged);
        SetTimer();
    }

    void OnDestroy()
    {
        DestroyTimer();
        StopShake();
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ONLINE_REWARD_INFO_CHANGED, OnOnlineRewardInfoChanged);
    }
    
    void DestroyTimer()
    {
        if (mTimer != null)
        {
            mTimer.Destroy();
            mTimer = null;
        }
    }

    void SetTimer()
    {
        DestroyTimer();

        uint endTime = 0;
        object[] param = { };
        System.Type[] returnType = { typeof(uint) };
        object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "OnlineRewardManager_GetEndTime", param, returnType);
        if (objs != null && objs.Length > 0)
        {
            if (objs[0] != null)
            {
                endTime = (uint)objs[0];
            }
        }

        uint countTime;
        if (endTime <= Game.Instance.ServerTime)
        {
            countTime = 0;
        }
        else
        {
            countTime = endTime - Game.Instance.ServerTime;
        }
        Text timerText = timerTextTrans.GetComponent<Text>();
        if (countTime > 0)
        {
            StopShake();
            timerText.gameObject.SetActive(true);
            timerText.text = Utils.Timer.GetFMTTime2(1000f * countTime);
            mTimer = new Utils.Timer(countTime * 1000, false, 1000,
                (remainTime) =>
                {
                    if (remainTime > 0)
                    {
                        timerText.text = Utils.Timer.GetFMTTime2(remainTime);
                    }
                    else
                    {
                        timerText.text = "";
                        timerText.gameObject.SetActive(false);
                        DestroyTimer();
                        StartShake();
                    }
                });
        }
        else
        {
            timerText.gameObject.SetActive(false);
            StartShake();
        }
    }

    void OnOnlineRewardInfoChanged(CEventBaseArgs args)
    {
        SetTimer();
    }

    void StartShake()
    {
        if (mAnimation == null)
        {
            mAnimation = GetComponent<Animation>();
        }
        mAnimation.Play("UIMainmapWindow_TRSysBtnObj_dou");
        if (effect == null)
        {
            effect = this.transform.Find("SysBtn").Find("EF_UI_zhujiemianlingqu").gameObject;
        }
        effect.SetActive(true);
    }

    void StopShake()
    {
        if (mAnimation != null)
        {
            mAnimation.Stop();
            this.transform.Find("SysBtn").Find("SysIcon").GetComponent<RectTransform>().rotation = Quaternion.identity;
            mAnimation = null;
        }
        if (effect != null)
        {
            effect.SetActive(false);
            effect = null;
        }
    }
}
