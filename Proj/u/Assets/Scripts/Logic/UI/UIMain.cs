using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : UIPage
{
    public RectTransform top;
    public GameObject music;
    public GameObject bgm;
    public GameObject cnY;
    public GameObject cnG;
    public GameObject enY;
    public GameObject enG;

    private bool isMusicOn;
    private bool isBgmOn;
    private LangType lang;

    public CanvasGroup black;
    //public CanvasGroup flash;
    public GameObject setting;
    public Text[] texts;

    public Text timeLeftText;

    //private float alphaSpeed = 8.2f;
    //private bool isFlashOver = false;
    //private bool flashCheck = false;

    //private float alphaZero = 0.0f;
    //private float alphaOne = 1.0f;

    private uint levelID;

    private bool buttonCheck;

    public Dropdown languageList;
    public RectTransform[] shadows;
    private bool isShadow = false;
    private bool isShadowFromList = false;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 10.0f;
    private float shadowSpeedFromList = 3.5f;
    private string shadowType = "shadowType";
    private string isUnlock = "isUnlock";
    private int type;

    protected override void InitComp()
    {
        this.Log("InitComp");
    }

    protected override void InitData()
    {
        this.Log("InitData");
        isBgmOn = true;
        isMusicOn = true;

        if (Mathf.Abs(((float)Screen.height / (float)Screen.width) - 2.16f) < 0.1f)//判断是否是刘海屏iphone
        {
            top.anchoredPosition = new Vector2(0, -100);
        }


    }

    bool updateFlag = true;


    private void OnEnable()
    {
        levelID = LevelMgr.GetInstance().GetNewLevel().LevelId;
        Debug.Log("levelID" + levelID);
        LevelMgr.GetInstance().CurLevelID = levelID;
        XPlayerPrefs.SetInt(levelID + isUnlock, -1);
        //XPlayerPrefs.Save();

        buttonCheck = true;
        type = XPlayerPrefs.GetInt(shadowType);

        updateFlag = false;
        StartCoroutine(TimeLeftUpdate(DateTime.Today.AddDays(1)));

        //if(isFlashOver==true && type!=-1)
        //{
        //    black.alpha = 1.0f;
        //    StartCoroutine(ShadowInit2());
        //}
        //ShadowInit();
    }

    private IEnumerator TimeLeftUpdate(DateTime endTime)
    {
        yield return new WaitForFixedUpdate();


        TimeSpan timeSpan;
        timeSpan = endTime - DateTime.Now;


        if (timeSpan.TotalSeconds < 0)
        {
            timeLeftText.text = "00:00:00";

            yield break;
        }
        else
        {
            updateFlag = true;
            timeLeftText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        while (updateFlag)
        {
            timeSpan = endTime - DateTime.Now;
            if (timeSpan.TotalSeconds < 0)
            {
                updateFlag = false;
            }
            timeLeftText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            yield return null;
        }
    }

    public override IEnumerator DoTween(bool isleft, int uiid, Action<int> onend)
    {
        if (UIMgr.GetInstance().isFirstShow)
        {
            UIMgr.GetInstance().isFirstShow = false;
            if (onend != null)
            {
                onend(uiid);
            }
            AfterTween();
            yield break;
        }

        if (!IsAnim)
        {
            if (onend != null)
            {
                onend(uiid);
            }
            AfterTween();
            yield break;
        }
        float now = 0f;
        float progress = 0f;
        //RectTransform rt = ub.GetComponent<RectTransform>();
        Vector3 target = Vector3.zero;//rt.position;
        UIRoot root = UIMgr.GetInstance().uiRoot;
        Vector3 v3 = isleft ? root.LeftPoint : root.RightPoint;
        transform.position = v3;
        Vector3 v33 = v3;
        while (AnimatTime > now)
        {
            progress = now / AnimatTime;
            float newx = Mathf.Lerp(v3.x, 0, progress);
            v33.x = newx;
            //rt.position = v33;
            transform.position = v33;
            //Debug.Log(GetType().ToString() + "DoTweenOnPop ==>" + v33);
            now += Time.deltaTime;
            yield return null;
        }
        v33.x = 0;
        transform.position = v33;
        if (onend != null)
        {
            onend(uiid);
        }
        AfterTween();
    }

    private void FixedUpdate()
    {
        ////闪屏
        //if(isFlashOver==false)
        //{
        //    if (flashCheck == false)
        //    {
        //        if (black.alpha != alphaZero)
        //        {
        //            black.alpha = Mathf.Lerp(black.alpha, alphaZero, alphaSpeed * Time.deltaTime);
        //            if (Mathf.Abs(alphaZero - black.alpha) <= 0.01f)
        //            {
        //                black.alpha = alphaZero;
        //                Invoke("flashChange", 2.0f);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (black.alpha != alphaOne)
        //        {
        //            black.alpha = Mathf.Lerp(black.alpha, alphaOne, alphaSpeed * Time.deltaTime);
        //            if (Mathf.Abs(alphaOne - black.alpha) <= 0.01f)
        //            {
        //                black.alpha = alphaOne;
        //                closeBlack();
        //                closeFlash();
        //                isFlashOver = true;
        //            }
        //        }
        //    }
        //}

        //转场动画
        if (isShadow)
        {
            if (type != -1)
            {
                if (shadows[type].localScale != shadowMin)
                {
                    shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeed);

                    if (Mathf.Abs(shadows[type].localScale.x - shadowMin.x) <= 0.1f)
                    {
                        shadows[type].localScale = Vector3.zero;
                        isShadow = false;
                        //进入游戏主界面
                        black.alpha = 1.0f;
                        //UIMgr.ShowPage(UIPageEnum.LevelList_Page);
                        UIMgr.GetInstance().ShowPage_Play(UIPageEnum.Play_Page);
                    }
                }
            }

        }

        if (isShadowFromList)
        {
            if (type != -1)
            {
                if (shadows[type].localScale != shadowMax)
                {
                    shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMax, Time.deltaTime * shadowSpeedFromList);
                    if (Mathf.Abs(shadows[type].localScale.x - shadowMax.x) <= 10.0f)
                    {
                        shadows[type].localScale = Vector3.zero;
                        XPlayerPrefs.SetInt(shadowType, -1);
                        isShadowFromList = false;
                    }
                }
            }
        }
    }

    private void ShadowInit()
    {
        if (type != -1)
        {
            isShadowFromList = false;
            for (int i = 0; i < shadows.Length; i++)
            {
                shadows[i].localScale = Vector3.zero;
            }
            shadows[type].localScale = shadowMax;
            isShadow = false;
        }
    }

    IEnumerator ShadowInit2()
    {
        type = XPlayerPrefs.GetInt(shadowType);
        int waittime = (type == -1) ? 0 : 1;
        black.alpha = 1.0f;
        yield return new WaitForSeconds(0.2f * waittime);
        black.alpha = 0.0f;
        if (type != -1)
            shadows[type].localScale = shadowMin;
        yield return new WaitForSeconds(0.02f * waittime);
        isShadowFromList = true;
    }

    private void RandomType()
    {
        type = UnityEngine.Random.Range(0, 3);
        XPlayerPrefs.SetInt(shadowType, type);
    }

    public void Click()
    {
        if (buttonCheck)
        {
            buttonCheck = false;
            LevelMgr.GetInstance().CurPlayMode = GamePlayModule.Normal;
            Debug.Log(LevelMgr.GetInstance().CurPlayMode);
            UIMgr.GetInstance().ShowPage_Play(UIPageEnum.Play_Page);
        }
    }

    private void flashChange()
    {
        //flashCheck = true;
    }

    private void closeBlack()
    {
        //black.alpha = alphaZero;
        black.blocksRaycasts = false;
    }

    private void closeFlash()
    {
        //flash.alpha = alphaZero;
        //flash.blocksRaycasts = false;
    }

    public void CallGM()
    {
        UIMgr.GetInstance().ShowWindows(UIPageEnum.GM_Page);
    }

    public void ClickOpenSetting()
    {
        setting.SetActive(true);
        switch (GameConfig.Language)
        {
            case LangType.zh_Hans:
                LanguageMgr.GetInstance().SwitchLanguage(LangType.zh_Hans);
                cnY.SetActive(false);
                cnG.SetActive(true);
                enY.SetActive(true);
                enG.SetActive(false);
                break;
            case LangType.zh_Hant:
                LanguageMgr.GetInstance().SwitchLanguage(LangType.zh_Hant);
                break;
            case LangType.en:
                LanguageMgr.GetInstance().SwitchLanguage(LangType.en);
                cnY.SetActive(true);
                cnG.SetActive(false);
                enY.SetActive(false);
                enG.SetActive(true);
                break;
        }
    }

    public void ClickCloseSetting()
    {

        setting.SetActive(false);
    }

    public void ClickSettingSave()
    {
        XPlayerPrefs.Save();
        setting.SetActive(false);
    }

    public void ClickChangeLanguage()
    {
        if (languageList.options[languageList.value].text == "简体中文")
        {
            LanguageMgr.GetInstance().SwitchLanguage(LangType.zh_Hans);
            //GameConfig.Language = LangType.zh_Hans;
        }
        else if (languageList.options[languageList.value].text == "繁體中文")
        {
            LanguageMgr.GetInstance().SwitchLanguage(LangType.zh_Hant);
        }
        else if (languageList.options[languageList.value].text == "English")
        {
            LanguageMgr.GetInstance().SwitchLanguage(LangType.en);
            //GameConfig.Language = LangType.en;
        }
        //GameConfig.Language = languageCheck ? LangType.zh_Hans : LangType.en;//多个语言下呢？要用toggle
        //Refresh();//languagemgr的逻辑已经改了，要调用LanguageMgr.SwitchLanguage
    }

    public void ShowAD()
    {
        AdMgr.GetInstance().Pay4RemoveAD();
    }

    public void ClickRanking()
    {
        UIMgr.GetInstance().ShowWindows(UIPageEnum.Calendar_Page);
        LevelMgr.GetInstance().CurPlayMode = GamePlayModule.SignIn;
    }

    public void ClickBgm()
    {
        isBgmOn = !isBgmOn;
        bgm.SetActive(isBgmOn);
    }

    public void ClickMusic()
    {
        isMusicOn = !isMusicOn;
        music.SetActive(isMusicOn);
    }

    public void ClikcCn()
    {
        LanguageMgr.GetInstance().SwitchLanguage(LangType.zh_Hans);
        cnY.SetActive(false);
        cnG.SetActive(true);
        enY.SetActive(true);
        enG.SetActive(false);
    }

    public void ClickEn()
    {
        LanguageMgr.GetInstance().SwitchLanguage(LangType.en);
        cnY.SetActive(true);
        cnG.SetActive(false);
        enY.SetActive(false);
        enG.SetActive(true);
    }
}