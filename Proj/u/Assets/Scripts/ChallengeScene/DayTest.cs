using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using X.Res;

public class DayTest : MonoBehaviour, IPointerClickHandler
{
    //子对象:
    public Image dayBGSelect;
    public Image dayBGFinish;
    public Text dayText;
    public Image lockImage;


    //数据:
    private DateTime dateTime;
    public DateTime DateTime { get; set; }
    private int dateTimeInt;
    private bool isChallenged = false;//是否已通过
    public bool IsChallenged { get; set; }
    public bool isLocked = false;//是否上锁
    public bool isEmpty = false;//是否是空


    static string challengeStr = "IsChallenged";


    public void InitDay(DateTime dateTime)
    {
        isLocked = false;
        isEmpty = false;

        this.dateTime = dateTime;
        this.dateTimeInt = TimeUtil.getIntByDateTime(dateTime);
        //TODO:首先获取配置表，如果今天没有配置任何信息，就不显示任何
        SignInConfig signInConfig = SignInMgr.GetInstance().GetConfigByID((uint)dateTimeInt);
        if (signInConfig == null)
        {
            InitInvisible();
            return;
        }


        //TODO:和今天对比，如果是今天，就显示为蓝色字体；如果是今天之后，就先上锁；如果是今天之前，就判断完成状态
        DateTime todayDateTime = DateTime.Today;
        bool todayOrPast = false;
        if (dateTime == todayDateTime)
        {
            dayBGSelect.color = Color.clear;
            dayBGFinish.color = Color.clear;
            dayText.text = dateTime.Day.ToString();
            dayText.color = Color.cyan;
            lockImage.color = Color.clear;

            todayOrPast = true;
        }
        else if (dateTime > todayDateTime)
        {
            dayBGSelect.color = Color.clear;
            dayBGFinish.color = Color.clear;
            dayText.text = "";
            lockImage.color = Color.white;
            isLocked = true;
        }
        else
        {
            dayBGSelect.color = Color.clear;
            dayBGFinish.color = Color.clear;
            dayText.text = dateTime.Day.ToString();
            dayText.color = Color.black;
            lockImage.color = Color.clear;

            todayOrPast = true;
        }

        //如果是今天或者今天之前才要读取当天的完成状态
        if (todayOrPast)
        {
            //TODO：读取当天的完成状态 via 存档/如果存档中记录的是一系列二进制数，那么读取存档应该放在上层，获取当天的状态后，传入一个bool即可
            // int isChallengedInt = XPlayerPrefs.GetInt(TimeUtil.getIntByDateTime(dateTime) + challengeStr);

            //!just for test
            GameConfig.Init();

            Debug.Log(dateTime.ToShortDateString() + " " + dateTimeInt.ToString());
            Debug.Log(GameConfig.SignInDay);

            Debug.Log(dateTimeInt - GameConfig.SignInDay);

            isChallenged = SignInMgr.GetInstance().IsSign(dateTimeInt - GameConfig.SignInDay);

            if (isChallenged)
            {
                dayBGFinish.color = Color.white;
                dayText.color = Color.white;
            }

            //TODO：判断当前日期是否被选中
            bool isSelected = XPlayerPrefs.GetInt(ChallengeController.selectedDateTimeStr) == dateTimeInt ? true : false;
            if (isSelected)
            {
                dayBGSelect.color = Color.white;
                //还要通知一下ChallengeController
                LogicEvent.Broadcast(LogicEvent.CALENDAR_SELECTED, dateTime, this);
            }

        }
    }

    public void InitInvisible()
    {
        isLocked = false;
        isEmpty = false;
        dayBGSelect.color = Color.clear;
        dayBGFinish.color = Color.clear;
        dayText.text = "";
        lockImage.color = Color.clear;
        isEmpty = true;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (isEmpty || isLocked)
        {
            return;
        }
        Debug.Log("点击了" + dateTime.ToShortDateString());
        LogicEvent.Broadcast(LogicEvent.CALENDAR_SELECTED, dateTime, this);
    }
}
