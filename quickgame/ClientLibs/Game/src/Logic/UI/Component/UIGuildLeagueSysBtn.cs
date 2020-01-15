//------------------------------------------------------------------------------
// Desc   :  帮派联赛系统按钮组件，跟普通的系统按钮不一样的是这里有倒计时
// Author :  ljy
// Date   :  2018.3.23
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using xc.ui.ugui;
using xc;

public class UIGuildLeagueSysBtn : MonoBehaviour
{
    List<uint> mActivityIds;

    Utils.Timer mTimer = null;

    void Awake()
    {
        mActivityIds = new List<uint>();
        mActivityIds.Clear();
        mActivityIds.Add(GameConst.SYS_OPEN_LEAGUE_READY);
        mActivityIds.Add(GameConst.SYS_OPEN_LEAGUE_QUALIFY);
        mActivityIds.Add(GameConst.SYS_OPEN_LEAGUE);
    }

    void Start()
    {
    }

    void OnDestroy()
    {
        if (mTimer != null)
        {
            mTimer.Destroy();
            mTimer = null;
        }

        ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_GUILD_LEAGUE_INFO_CHANGED, OnGuildLeagueInfoChanged);
        ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_ACTIVITY_STATE_CHANGED, OnActivityStateChanged);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_SHOW, OnShowRedPoint);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, OnDisappearRedPoint);
        ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, OnSysOpen);

    }

    public void Init()
    {
        ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_GUILD_LEAGUE_INFO_CHANGED, OnGuildLeagueInfoChanged);
        ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_ACTIVITY_STATE_CHANGED, OnActivityStateChanged);
        ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_SHOW, OnShowRedPoint);
        ClientEventMgr.Instance.SubscribeClientEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, OnDisappearRedPoint);
        ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, OnSysOpen);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (mTimer != null)
        {
            mTimer.Destroy();
            mTimer = null;
        }

        if (mActivityIds == null)
        {
            return;
        }
        Transform timerTextTrans = this.transform.Find("SysBtn").Find("TimerText");
        if (timerTextTrans == null)
        {
            GameDebug.LogError("UIGuildLeagueSysBtn UpdateTimerText error!!! Can not find TimerText!!!");
            return;
        }

        UISysConfigBtn btn = this.gameObject.GetComponent<UISysConfigBtn>();


        //当预告开启的时候  预备和资格的  icon不允许显示
        if (ActivityHelper.IsActivityOpen(GameConst.SYS_OPEN_LEAGUE_PRE_SHOW))
        {
            btn.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
            return;
        }


        // 系统是否开放
        bool sysIsOpen = false;
        foreach (uint activityId in mActivityIds)
        {
            if (SysConfigManager.Instance.CheckSysHasOpenIgnoreActivity(activityId))
            {
                sysIsOpen = true;
                break;
            }
        }

        if (sysIsOpen == false)
        {
            btn.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
            return;
        }

        bool todayIsOpen = false;
        foreach (uint activityId in mActivityIds)
        {
            if (ActivityHelper.GetActivityInfo<bool>(activityId, "TodayIsOpen") == true)
            {
                todayIsOpen = true;
                break;
            }
        }
        if (todayIsOpen == false)
        {
            //this.gameObject.SetActive(false);
            btn.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
        }
        else
        {
            DateTime curDateTime = Game.Instance.GetServerDateTime();
            uint serverTime = Game.Instance.ServerTime;

            List<uint> startShowBtnTimeStr = GameConstHelper.GetUintList("GAME_GUILD_LEAGUE_START_SHOW_BTN_TIME");  // 开始显示系统按钮时间(5点)
            List<uint> confirmTimeStr = GameConstHelper.GetUintList("GAME_GUILD_LEAGUE_CONFIRM_TIME");  // 确认对战表时间(19点)
            List<uint> openTimeStr = GameConstHelper.GetUintList("GAME_GUILD_LEAGUE_OPEN_TIME");    // 活动开启时间(21点)
            List<uint> closeTimeStr = GameConstHelper.GetUintList("GAME_GUILD_LEAGUE_CLOSE_TIME");  // 活动关闭时间(22点)

            uint startShowBtnTimeHour = startShowBtnTimeStr[0];
            uint startShowBtnTimeMinute = startShowBtnTimeStr[1];
            uint confirmTimeHour = confirmTimeStr[0];
            uint confirmTimeMinute = confirmTimeStr[1];
            uint openTimeHour = openTimeStr[0];
            uint openTimeMinute = openTimeStr[1];
            uint closeTimeHour = closeTimeStr[0];
            uint closeTimeMinute = closeTimeStr[1];

            long startShowBtnTimestamp = DateHelper.GetTimestamp(new DateTime(curDateTime.Year, curDateTime.Month, curDateTime.Day, (int)startShowBtnTimeHour, (int)startShowBtnTimeMinute, 0));
            long confirmTimestamp = DateHelper.GetTimestamp(new DateTime(curDateTime.Year, curDateTime.Month, curDateTime.Day, (int)confirmTimeHour, (int)confirmTimeMinute, 0));
            long openTimestamp = DateHelper.GetTimestamp(new DateTime(curDateTime.Year, curDateTime.Month, curDateTime.Day, (int)openTimeHour, (int)openTimeMinute, 0));
            long roundTwoOpenTimestamp = openTimestamp + GameConstHelper.GetUint("GAME_GUILD_LEAGUE_ROUND_TWO_AFTER") * 60;
            long closeTimestamp = DateHelper.GetTimestamp(new DateTime(curDateTime.Year, curDateTime.Month, curDateTime.Day, (int)closeTimeHour, (int)closeTimeMinute, 0));

            long endTimestamp = 0;

            if (serverTime < startShowBtnTimestamp) // 5点前
            {
                //this.gameObject.SetActive(false);
                btn.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
            }
            else if (serverTime < confirmTimestamp) // 确认参赛资格前
            {
                //this.gameObject.SetActive(true);
                btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
                endTimestamp = openTimestamp;
            }
            else if (serverTime < openTimestamp)    // 第一轮比赛开启前
            {
                if (GuildLeagueManager.Instance.CanJoinLeague() == true)    // 有参赛资格
                {
                    //this.gameObject.SetActive(true);
                    btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
                    endTimestamp = openTimestamp;
                }
                else // 没有参赛资格
                {
                    //this.gameObject.SetActive(true);
                    btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
                }
            }
            else if (serverTime < roundTwoOpenTimestamp)    // 第二轮比赛开启前
            {
                if (GuildLeagueManager.Instance.RoundOneIsOver() == false)  // 第一轮还没结束
                {
                    //this.gameObject.SetActive(true);
                    btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
                }
                else  // 第一轮已经结束
                {
                    //this.gameObject.SetActive(true);
                    btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
                    endTimestamp = roundTwoOpenTimestamp;
                }
            }
            else if (serverTime < closeTimestamp)   // 22点前
            {
                //this.gameObject.SetActive(true);
                btn.SetSysBtnState(UISysConfigBtn.SysState.Open);
            }
            else // 22点后
            {
                //this.gameObject.SetActive(false);
                btn.SetSysBtnState(UISysConfigBtn.SysState.NotOpen);
            }

            Text timerText = this.transform.Find("SysBtn").Find("TimerText").GetComponent<Text>();
            if (endTimestamp > 0)
            {
                timerText.gameObject.SetActive(true);
                if (endTimestamp > serverTime)
                {
                    long timeOffset = endTimestamp - serverTime;
                    timerText.text = Utils.Timer.GetFMTTime2(1000f * timeOffset);
                    mTimer = new Utils.Timer(timeOffset * 1000, false, 1000,
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

                                UpdateUI();
                            }
                        });
                }
                else
                {
                    GameDebug.LogError("Init UIGuildLeagueSysBtn error, end timestamp is early then cur time!!!");
                }
            }
            else
            {
                timerText.gameObject.SetActive(false);
            }
        }

        ShowEffect(RedPointDataMgr.Instance.GetRedPointVisible(70));
    }

    void Show(bool isShow)
    {

    }

    void OnGuildLeagueInfoChanged(CEventBaseArgs args)
    {
        UpdateUI();
    }

    void OnSysOpen(CEventBaseArgs args)
    {
        UpdateUI();
    }

    void OnActivityStateChanged(CEventBaseArgs args)
    {
        uint activityId = uint.Parse(args.arg.ToString());
        foreach (uint tempActivityId in mActivityIds)
        {
            if (activityId == tempActivityId)
            {
                UpdateUI();
                break;
            }
        }
    }

    void OnShowRedPoint(CEventBaseArgs args)
    {
        if (args == null || args.arg == null)
            return;
        string str = (string)(args.arg);
        uint redPointId = 0;
        if (uint.TryParse(str, out redPointId) == false)
            return;

        if (redPointId == 70)
        {
            ShowEffect(true);
        }
    }

    void OnDisappearRedPoint(CEventBaseArgs args)
    {
        if (args == null || args.arg == null)
            return;
        string str = (string)(args.arg);
        uint redPointId = 0;
        if (uint.TryParse(str, out redPointId) == false)
            return;

        if (redPointId == 70)
        {
            ShowEffect(false);
        }
    }

    void ShowEffect(bool isShow)
    {
        Transform sysBtnTrans = this.transform.Find("SysBtn");
        if (sysBtnTrans != null)
        {
            Transform effectTrans = sysBtnTrans.Find("Effect_ui_txyg");
            if (effectTrans != null)
            {
                effectTrans.gameObject.SetActive(isShow);
            }
        }
    }
}
