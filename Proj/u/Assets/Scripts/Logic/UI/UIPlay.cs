using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlay : UIPage
{
    //暂停界面读取评星提示用-hzy
    uint levelID;
    LevelData data;
    X.Res.ValueConfig_ARRAY value;
    public Text[] starRatingTexts;
    public GameObject pausePage;

    //转场动画用-hzy
    public CanvasGroup black;
    public RectTransform[] shadows;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 3.3f;
    private float shadowSpeedToList = 10.0f;
    private bool isShadow = false;
    private bool isShadowToList = false;
    private bool isShadowSelf = false;
    private string shadowType = "shadowType";
    private int type;


    private Animator animator;


    //需要清空的一些父对象的Transform：
    public Transform playFieldTrans;
    public Transform puzzleBarTrans;
    public Transform puzzleMoveTrans;
    public Transform whiteLightTrans;

    //Canvas：
    public Canvas BGCanvas;
    public Canvas MainUICanvas;

    public GeneralPanelUI generalPanelUI;
    public PuzzleBar puzzleBar;
    public LevelTimer levelTimer;
    public OperationHistoryRecorder operationHistoryRecorder;
    public PanelTransformationController panelTransformationController;
    public MiniMapController miniMapController;

    public UIUseRecTips m_isUseRecPanel;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        UIEvent.RegEvent(UIEvent.UI_LEVELSTART, LevelStart);
        //UIEvent.RegEvent(UIEvent.UI_LEVEL_USEREC, LevelUseRec);

        //暂停界面读取评星提示用-hzy
        levelID = LevelMgr.GetInstance().GetCurLevelID();
        operationHistoryRecorder.SetLevelId(levelID);
        data = LevelMgr.GetInstance().GetLevelConfig(levelID);
        value = LevelMgr.GetInstance().GetValueConfig();

        black.alpha = 1.0f;
        isShadow = false;
        levelTimer.SetTime(0);
        StartCoroutine(ShadowInit());
        UIEvent.Broadcast(UIEvent.UI_LEVELSTART);
    }

    private void FixedUpdate()
    {
        if (isShadow)
        {
            if (shadows[type].localScale != shadowMax)
            {
                shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMax, Time.deltaTime * shadowSpeed);
                if (Mathf.Abs(shadows[type].localScale.x - shadowMax.x) <= 10.0f)
                {
                    shadows[type].localScale = Vector3.zero;
                    XPlayerPrefs.SetInt(shadowType, -1);
                    isShadow = false;
                }
            }
        }
        if(isShadowToList)
        {
            if (type != -1)
            {
                if (shadows[type].localScale != shadowMin)
                {
                    shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeedToList);

                    if (Mathf.Abs(shadows[type].localScale.x - shadowMin.x) <= 0.1f)
                    {
                        shadows[type].localScale = Vector3.zero;
                        isShadowToList = false;
                        //进入关卡列表界面
                        UIMgr.ShowPage(UIPageEnum.LevelList_Page);
                    }
                }
            }
        }
        if(isShadowSelf)
        {
            if (type != -1)
            {
                if (shadows[type].localScale != shadowMin)
                {
                    shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeedToList);

                    if (Mathf.Abs(shadows[type].localScale.x - shadowMin.x) <= 0.1f)
                    {
                        shadows[type].localScale = Vector3.zero;
                        isShadowSelf = false;
                        //Resume();
                        uint curLevelID = LevelMgr.GetInstance().GetCurLevelID();
                        XPlayerPrefs.DelRec(curLevelID);
                        pausePage.SetActive(false);
                        CloseUIPlay();
                        UIMgr.ShowPage(UIPageEnum.Tips_Page);
                        UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
                    }
                }
            }
        }
    }

    IEnumerator ShadowInit()
    {
        type = XPlayerPrefs.GetInt(shadowType);
        int waittime = (type == -1) ? 0 : 1;
        //Debug.Log("after" + shadowType + type);
        Debug.Log("play" + waittime);
        yield return new WaitForSeconds(0.2f * waittime);
        black.alpha = 0.0f;
        if (type != -1)
            shadows[type].localScale = shadowMin;
        yield return new WaitForSeconds(0.02f * waittime);
        if (type != -1)
            isShadow = true;
    }

    private void ShadowInit2()
    {
        if (type != -1)
        {
            isShadowToList = false;
            for (int i = 0; i < shadows.Length; i++)
            {
                shadows[i].localScale = Vector3.zero;
            }
            shadows[type].localScale = shadowMax;
            isShadow = false;
        }
    }

    private void RandomType()
    {
        type = UnityEngine.Random.Range(0, 3);
        XPlayerPrefs.SetInt(shadowType, type);
    }

    private void OnDisable()
    {
        UIEvent.UnRegEvent(UIEvent.UI_LEVELSTART, LevelStart);
        //UIEvent.UnRegEvent(UIEvent.UI_LEVEL_USEREC, LevelUseRec);
    }

    protected override void InitComp()
    {
        // LevelStart();
    }

    protected override void InitData()
    {
        BGCanvas.worldCamera = Camera.main;
        MainUICanvas.worldCamera = Camera.main;
    }

    public void LevelStart(params object[] argv)
    {
        animator.enabled = true;
        animator.Play("UIPlay_Origin_Anim", 0, 0);
        StartCoroutine(WaitOriginAnimEnd());

    }

    IEnumerator WaitOriginAnimEnd()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("DoNothing"))
        {
            yield return null;
        }
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("UIPlay_Origin_Anim") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
        Debug.Log("animator set false");

        animator.enabled = false;
        RecCheck();
    }

    public void GenMap(bool isReGen =false)
    {
        generalPanelUI.InitComp(isReGen);
        generalPanelUI.InitGeneralPanelUI();
        puzzleBar.InitPuzzleBar();
        panelTransformationController.InitPTController();
        miniMapController.InitMiniMap();
    }

    private void RecCheck()
    {
        var rec = XPlayerPrefs.GetRec(levelID);
        if (rec != null)
        {
            Debug.Log("RecCheck == true");
            Action ac_ok = () => {
                operationHistoryRecorder.SetLevelId(levelID, true);
                GenMap(true);
                levelTimer.SetTime(rec.TimeCount);
                StartCoroutine(levelTimer.RestartTimer());
            };
            Action ac_cancel = () => {
                levelTimer.SetTime(0);
                StartCoroutine(levelTimer.RestartTimer());
                GenMap();
                XPlayerPrefs.DelRec(levelID);
            };
            m_isUseRecPanel.Show(ac_cancel, ac_ok);
        }
        else
        {
            GenMap();
            StartCoroutine(levelTimer.RestartTimer());
        }
    }


    public void LevelOverStep1()
    {
        StartCoroutine(panelTransformationController.ReturnToOrigin(0.2f, LevelOverStep2));
    }

    public void LevelOverStep2()
    {
        animator.enabled = true;
        for (int i = 0; i < whiteLightTrans.childCount; ++i)
        {
            Transform whiteLightGridTrans = whiteLightTrans.GetChild(i);
        }
        animator.Play("UIPlay_Anim", 0, 0);

        StartCoroutine(ShowEndPage());
    }

    public void LevelReturn()
    {
        Debug.Log("return");
        Resume();
        RandomType();
        ShadowInit2();
        isShadowToList = true;
        //UIMgr.ShowPage(UIPageEnum.LevelList_Page);

        SaveOperation();
        CloseUIPlay();
    }

    public void LevelRestart()
    {
        isShadowSelf = true;
        RandomType();
        Resume();
        shadows[type].localScale = shadowMax;
        Debug.Log("restart"+isShadowSelf);
        Debug.Log("restart"+type);
        
    }

    public void LevelRestartCorou()
    {
        Debug.Log("restart");
        Resume();
        uint curLevelID = LevelMgr.GetInstance().GetCurLevelID();
        XPlayerPrefs.DelRec(curLevelID);
        pausePage.SetActive(false);
        CloseUIPlay();
        UIMgr.ShowPage(UIPageEnum.Tips_Page);
        UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
    }

    IEnumerator ShowEndPage()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("DoNothing"))
        {
            yield return null;
        }
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("UIPlay_Origin_Anim"))
        {
            yield return null;
        }
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("UIPlay_Anim"))
        {
            yield return null;
        }
        animator.enabled = false;

        UIMgr.ShowPage(UIPageEnum.End_Page);

        CloseUIPlay();
    }



    void CloseUIPlay()
    {
        levelTimer.SetTime(0);
        operationHistoryRecorder.Clear();


        for (int i = 0; i < playFieldTrans.childCount; ++i)
        {
            Transform childTrans = playFieldTrans.GetChild(i);
            for (int j = 0; j < childTrans.childCount; ++j)
            {
                Destroy(childTrans.GetChild(j).gameObject);
            }
        }

        for (int i = 0; i < puzzleBarTrans.childCount; ++i)
        {
            Destroy(puzzleBarTrans.GetChild(i).gameObject);
        }

        for (int i = 0; i < puzzleMoveTrans.childCount; ++i)
        {
            Destroy(puzzleMoveTrans.GetChild(i).gameObject);
        }

        for (int i = 0; i < whiteLightTrans.childCount; ++i)
        {
            Destroy(whiteLightTrans.GetChild(i).gameObject);
        }

    }

    private void SaveOperation()
    {
        Recorder rec = operationHistoryRecorder.Recoder;
        rec.LevelId = levelID;
        rec.layout = generalPanelUI.generalPanelData.Playout;
        rec.TimeCount = levelTimer.Time;
        //todo 保存广告格子的个数
        XPlayerPrefs.SetRec(rec);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        LoadStarTips();
        SaveOperation();
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    //暂停界面读取评星提示用-hzy
    private void LoadStarTips()
    {
        Debug.Log("loadstartips");
        //加载评星提示
        if (data.Config.Rating1 == 0)
        {
            starRatingTexts[0].text = "完成关卡！";
        }
        LoadRating(data.Config.Rating2, 0);
        LoadRating(data.Config.Rating3, 1);
    }

    private void LoadRating(Google.Protobuf.Collections.RepeatedField<int> rating, int index)
    {
        switch (rating[0])
        {
            case 1:

                string time = rating[1].ToString();
                string text = string.Format(value.Items[1].RatingName, time);
                starRatingTexts[index + 1].text = text;
                break;
            case 2:
                starRatingTexts[index + 1].text = value.Items[2].RatingName;
                break;
        }
    }

}
