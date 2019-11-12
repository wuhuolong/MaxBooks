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
    public Image dayBGSelectFinish;//選擇+完成
    public Image dayBGSelectUnFinish;//選擇+未完成
    public Image dayBGUnSelectFinish;//未選擇+完成
    public Image lockImage;//上鎖
    public Text dayText;

    //数据:
    private DateTime dateTime;
    private int dateTimeInt;
    // private bool isChallenged = false;//是否已通过
    public bool isChallenged { get; set; }
    public bool isLocked = false;//是否上锁
    public bool isEmpty = false;//是否是空


    // static string challengeStr = "IsChallenged";
    // static Color todayColor = new Color(232, 88, 57);
    // static Color lockColor = new Color(169, 161, 153);
    // static Color normalColor = new Color(118, 109, 100);
    static Color todayColor = new Color(232f / 255f, 88f / 255f, 57f / 255f);
    static Color normalColor = new Color(118f / 255f, 109f / 255f, 100f / 255f);
    static Color lockColor = new Color(169f / 255f, 161f / 255f, 153f / 255f);
    static Color emptyColor = new Color(191f / 255f, 191f / 255f, 181f / 255f);


    public void InitDay(DateTime dateTime)
    {
        isLocked = false;
        isEmpty = false;

        this.dateTime = dateTime;
        this.dateTimeInt = TimeUtil.getIntByDateTime(dateTime);
        //TODO:首先获取配置表，如果今天没有配置任何信息，就不显示任何
        SignInConfig signInConfig = SignInMgr.GetInstance().GetConfigByID((uint)dateTimeInt);
        if (signInConfig == null || LevelMgr.GetInstance().GetLevelConfig(signInConfig.LevelId).Config == null)
        {
            // InitInvisible();
            dayBGSelectFinish.color = Color.clear;
            dayBGSelectUnFinish.color = Color.clear;
            dayBGUnSelectFinish.color = Color.clear;
            lockImage.color = Color.clear;
            dayText.text = dateTime.Day.ToString();
            dayText.color = emptyColor;
            isEmpty = true;

            return;
        }


        //TODO:和今天对比，如果是今天，字體显示为todaycolor；如果是今天之后，就先上锁，字體顯示爲lockcolor；如果是今天之前，就顯示爲normalcolor
        DateTime todayDateTime = DateTime.Today;

        dayBGSelectFinish.color = Color.clear;
        dayBGSelectUnFinish.color = Color.clear;
        dayBGUnSelectFinish.color = Color.clear;
        dayText.text = dateTime.Day.ToString();


        bool todayOrPast = false;
        if (dateTime == todayDateTime)
        {
            dayText.color = todayColor;
            lockImage.color = Color.clear;
            todayOrPast = true;
        }
        else if (dateTime > todayDateTime)
        {
            dayText.color = lockColor;
            lockImage.color = Color.white;
            isLocked = true;
        }
        else
        {
            dayText.color = normalColor;
            lockImage.color = Color.clear;
            todayOrPast = true;
        }

        //如果是今天或者今天之前才要读取当天的完成状态
        if (todayOrPast)
        {
            //TODO：读取当天的完成状态 via 存档/如果存档中记录的是一系列二进制数，那么读取存档应该放在上层，获取当天的状态后，传入一个bool即可
            // int isChallengedInt = XPlayerPrefs.GetInt(TimeUtil.getIntByDateTime(dateTime) + challengeStr);

            //!just for test
            

            // Debug.Log(dateTime.ToShortDateString() + " " + dateTimeInt.ToString());
            // Debug.Log(GameConfig.SignInDay);

            // Debug.Log(dateTimeInt - GameConfig.SignInDay);

            isChallenged = SignInMgr.GetInstance().IsSign(dateTimeInt - GameConfig.SignInDay);

            //FINISH：判断当前日期是否被选中

            bool isSelected = XPlayerPrefs.GetInt(ChallengeController.selectedDateTimeStr) == dateTimeInt ? true : false;

            if (isChallenged && isSelected)
            {
                //如果當前日期是選中+完成
                dayBGSelectFinish.color = Color.white;
                dayText.color = Color.white;
                //还要通知一下ChallengeController
                LogicEvent.Broadcast(LogicEvent.CALENDAR_SELECTED, dateTime, this.gameObject);
            }
            else if (!isChallenged && isSelected)
            {
                //如果當前日期是選中+未完成

                dayBGSelectUnFinish.color = Color.white;
                // Debug.Log("select unfinish:" + dateTime.ToShortDateString());
                // Debug.Log("select unfinish color?:" + dayBGSelectUnFinish.color.ToString());

                // Debug.Log("select finish color?:" + dayBGSelectFinish.color.ToString());
                LogicEvent.Broadcast(LogicEvent.CALENDAR_SELECTED, dateTime, this.gameObject);

            }
            else if (isChallenged && !isSelected)
            {
                //如果當前日期是未選中+完成
                dayBGUnSelectFinish.color = Color.white;
                dayText.color = Color.white;
            }
        }
    }

    public void InitInvisible()
    {
        isLocked = false;
        isEmpty = false;
        dayBGSelectFinish.color = Color.clear;
        dayBGSelectUnFinish.color = Color.clear;
        dayBGUnSelectFinish.color = Color.clear;
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
        LogicEvent.Broadcast(LogicEvent.CALENDAR_SELECTED, dateTime, this.gameObject);
    }
}
