using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using X.Res;

public class ChallengeController : MonoBehaviour
{
    private GameObject m_selectedDayObject;
    private DateTime m_selectedDateTime;

    private uint m_selectedLevelID;

    public static string selectedDateTimeStr = "SelectedDateTime";

    public CalendarPanelTest calendarPanel;

    public Image mapIcon;
    public Text levelNumText;
    public Text levelNameText;
    public Image timeLeftImg;
    public Text timeLeftText;
    public Button tryButton;
    public Text tryButtonText;
    public Transform AdImgTrans;

    private static Color normalTryButtonTextColor = new Color(191f / 255f, 100f / 255f, 33f / 255f);

    bool initFlag = false;

    private void OnEnable()
    {
        LogicEvent.RegEvent(LogicEvent.CALENDAR_SELECTED, OnSelected);
        if (initFlag)
        {
            calendarPanel.InitAllCalendars();
        }
    }

    private void OnDisable()
    {
        LogicEvent.UnRegEvent(LogicEvent.CALENDAR_SELECTED, OnSelected);
    }

    private void Start()
    {
        InitUI();

        //TODO:修改选择，上方界面的显示和下方界面的显示 
        // 从主界面-每日挑战 默认选择最新一关
        // 每日结算界面-每日挑战 默认选当前关
        //重置选择：
        XPlayerPrefs.SetInt(selectedDateTimeStr, 0);

        calendarPanel.InitPanelSize();
        calendarPanel.InitAllCalendars();

        initFlag = true;
    }

    public void InitUI()
    {
        //TODO:多语言修改，通过配置读取title，星期的显示




    }

    #region logic
    private void OnSelected(params object[] values)
    {
        DateTime newSelectedDateTime = (DateTime)values[0];
        GameObject newSelectedDayObject = values[1] as GameObject;
        SetSelectedDay(newSelectedDateTime, newSelectedDayObject);
        ModiMapAndInfo();
    }
    #endregion

    private void SetSelectedDay(DateTime newSelectedDateTime, GameObject newSelectedDayObject)
    {
        //修改选择的日期以及显示
        m_selectedDateTime = newSelectedDateTime;
        DayTest m_selectedDay;

        if (m_selectedDayObject != null && m_selectedDayObject.GetComponent<DayTest>() != null)
        {
            m_selectedDay = m_selectedDayObject.GetComponent<DayTest>();
            // Debug.Log("oldSelectedDay isChallenged" + m_selectedDay.isChallenged);
            if (m_selectedDay.isChallenged)
            {
                m_selectedDay.dayBGSelectFinish.color = Color.clear;
                m_selectedDay.dayBGUnSelectFinish.color = Color.white;
            }
            else
            {
                m_selectedDay.dayBGSelectUnFinish.color = Color.clear;
            }
        }
        m_selectedDayObject = newSelectedDayObject;
        m_selectedDay = m_selectedDayObject.GetComponent<DayTest>();
        // Debug.Log("newSelectedDay isChallenged" + m_selectedDay.isChallenged);

        if (m_selectedDay.isChallenged)
        {
            m_selectedDay.dayBGSelectFinish.color = Color.white;
            m_selectedDay.dayBGUnSelectFinish.color = Color.clear;
        }
        else
        {
            m_selectedDay.dayBGSelectUnFinish.color = Color.white;
            m_selectedDay.dayBGUnSelectFinish.color = Color.clear;
        }
        XPlayerPrefs.SetInt(selectedDateTimeStr, TimeUtil.getIntByDateTime(m_selectedDateTime));
    }

    private void ModiMapAndInfo()
    {
        updateFlag = false;
        //修改图片和信息的显示
        //获得表
        int dayId = TimeUtil.getIntByDateTime(m_selectedDateTime);
        SignInConfig signInConfig = SignInMgr.GetInstance().GetConfigByID((uint)dayId);
        m_selectedLevelID = signInConfig.LevelId;
        LevelData levelData = LevelMgr.GetInstance().GetLevelConfig(m_selectedLevelID);
        LevelConfig levelConfig = levelData.Config;

        if (levelConfig == null)
        {
            Debug.LogError("获取不到关卡 " + m_selectedLevelID + " 的Config");
            return;
        }

        //TODO:修改mapIcon的图标，需要通过读表获取对应的图集
        AltasConfig altasConfig = AltasMgr.GetInstance().GetConfigByID(m_selectedLevelID);
        string altasname = altasConfig.AltasName2;
        UIAtlas ats = UIAtlasUtil.GetAtlas(altasname);
        if (ats != null)
        {
            ats.Sp = mapIcon;
            if (SignInMgr.GetInstance().IsSign(dayId - GameConfig.SignInDay))
            {
                ats.SetSprite("p_" + levelConfig.LevelPicture.ToString());
            }
            else
            {
                ats.SetSprite("s_" + levelConfig.LevelPicture.ToString());
            }

        }

        //TODO:修改info，包括了编号、名字、剩余时间和按钮的状态、文字等
        levelNumText.text = "#" + (SignInMgr.GetInstance().GetIndexByID((uint)dayId) + 1).ToString();
        LanguageMgr.GetInstance().GetLangStrByID(levelNameText, signInConfig.DailylevelName);

        StartCoroutine(TimeLeftUpdate(m_selectedDateTime.AddDays(1)));

        ModiTryButton();

    }

    private void ModiTryButton()
    {
        if (!TimeUtil.isNetworkOn())
        {
            UIGray.SetUIGray(tryButton.GetComponent<Image>());
            UIGray.SetUIGray(AdImgTrans.GetComponent<Image>());

            tryButton.interactable = false;
            tryButtonText.color = Color.grey;
            UIMgr.GetInstance().ShowSimpleTips(306);
            return;
        }
        else
        {
            UIGray.Recovery(tryButton.GetComponent<Image>());
            UIGray.Recovery(AdImgTrans.GetComponent<Image>());

            tryButtonText.color = normalTryButtonTextColor;
            tryButton.interactable = true;
        }

        if (m_selectedDateTime != DateTime.Today && !m_selectedDayObject.GetComponent<DayTest>().isChallenged)
        {
            //还需要读取多语言配置
            LanguageMgr.GetInstance().GetLangStrByID(tryButtonText, 304);//"挑战关卡"
            RectUtils.SetLeft(tryButtonText.GetComponent<RectTransform>(), 95);
            AdImgTrans.gameObject.SetActive(true);
        }
        else if (m_selectedDateTime == DateTime.Today)
        {
            LanguageMgr.GetInstance().GetLangStrByID(tryButtonText, 304);//"挑战关卡"
            RectUtils.SetLeft(tryButtonText.GetComponent<RectTransform>(), 10);
            AdImgTrans.gameObject.SetActive(false);
        }
        else
        {
            LanguageMgr.GetInstance().GetLangStrByID(tryButtonText, 305);//"再次挑战"

            RectUtils.SetLeft(tryButtonText.GetComponent<RectTransform>(), 10);
            AdImgTrans.gameObject.SetActive(false);
        }
    }

    bool updateFlag = false;
    private IEnumerator TimeLeftUpdate(DateTime endTime)
    {
        yield return new WaitForFixedUpdate();


        TimeSpan timeSpan;
        timeSpan = endTime - DateTime.Now;

        if (timeSpan.TotalSeconds < 0)
        {
            updateFlag = false;
            //如果是负数，说明选中的已经是昨天或者更早的日期，这种情况下将剩余时间隐藏
            timeLeftImg.enabled = false;
            timeLeftText.text = "";
            yield break;
        }
        else
        {
            updateFlag = true;
            timeLeftImg.enabled = true;
            timeLeftText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        while (updateFlag)
        {
            timeSpan = endTime - DateTime.Now;
            timeLeftText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            yield return null;
        }
    }

    public void CheckChallenge()
    {

#if UNITY_IOS && !UNITY_EDITOR
        if (m_selectedDateTime != DateTime.Today && !m_selectedDayObject.GetComponent<DayTest>().isChallenged)
        {
            //未挑战通过的关卡，播放广告
            AdMgr.GetInstance().showRewardVideo(() =>
            {
                StartChallenge();
            }, null, null);
        }
        else
        {
            StartChallenge();
        }
#elif UNITY_EDITOR
        Debug.Log("播放广告");
        StartChallenge();
#endif


    }

    private void StartChallenge()
    {
        if (LevelMgr.GetInstance().GetLevelConfig(m_selectedLevelID).Config == null)
        {
            Debug.Log("当前关卡id无效");
            return;
        }
        else
        {
            LevelMgr.GetInstance().GotoLevel(m_selectedLevelID);
        }
    }

    public void QuitToMain()
    {
        UIMgr.GetInstance().ShowPage(UIPageEnum.Main_Page);
    }
}
