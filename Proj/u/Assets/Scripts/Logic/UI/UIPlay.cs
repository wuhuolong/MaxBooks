using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlay : UIPage
{
    public bool debugFlag = false;
    /// <summary>
    /// 新手引导
    /// </summary>
    public GameObject mask;
    public CircleShaderViewer shaderViewer;
    private int needMask;
    private bool inGuiding;


    //暂停界面读取评星提示用-hzy （现在单纯是为了把关卡序号显示在上方 -sjh）（最新版仅仅用于显示拼图面板的原始图片 - sjh）
    uint levelID;
    // LevelData data;
    // X.Res.ValueConfig_ARRAY value;
    // public Text[] starRatingTexts;
    // public GameObject pausePage;

    //转场动画用-hzy
    public CanvasGroup black;
    public RectTransform[] shadows;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 3.3f;
    private float shadowSpeedToList = 10.0f;
    private bool isShadow = false;
    private bool isShadowToList = false;
    //private bool isShadowSelf = false;
    private string shadowType = "shadowType";
    private int type;

    private bool buttonCheck;

    //string tmpNumStar = "tmpNumStar";



    private Animator animator;


    //需要清空的一些父对象的Transform：
    public Transform playFieldTrans;
    public Transform puzzleBarTrans;
    public Transform puzzleBarForFreeLayoutTrans;

    public Transform puzzleMoveTrans;
    public Transform whiteLightTrans;

    //Canvas：
    public Canvas BGCanvas;
    public Canvas MainUICanvas;

    //需要使用的一些组件：
    public GeneralPanelUI generalPanelUI;
    public PuzzleBar puzzleBar;
    // public LevelTimer levelTimer;
    public OperationHistoryRecorder operationHistoryRecorder;
    public DragController dragController;
    public PanelTransformationController panelTransformationController;
    public MiniMapController miniMapController;
    public Text levelText;
    public Image originImg;

    //提示框：
    public UIUseRecTips m_isUseRecPanel;


    private void OnEnable()
    {
        mask.SetActive(false);
        needMask = 0;
        if (LevelMgr.GetInstance().GetIndexByID(LevelMgr.GetInstance().CurLevelID) == "1-1")
        {
            Debug.Log("1-1");
            needMask = 1;
        }
        if (LevelMgr.GetInstance().GetIndexByID(LevelMgr.GetInstance().CurLevelID) == "1-2")
        {
            needMask = 2;
        }

        

        buttonCheck = true;
        animator = GetComponent<Animator>();
        UIEvent.RegEvent(UIEvent.UI_LEVELSTART, LevelStart);
        //UIEvent.RegEvent(UIEvent.UI_LEVEL_USEREC, LevelUseRec);

        //显示关卡拼图面板原图
        levelID = LevelMgr.GetInstance().CurLevelID;
        if (!debugFlag)
            LoadOriginImg();

        operationHistoryRecorder.SetLevelId(levelID);
        // data = LevelMgr.GetInstance().GetLevelConfig(levelID);
        // value = LevelMgr.GetInstance().GetValueConfig();

        //显示关卡序号
        BaseLevel levelmode = LevelMgr.GetInstance().CurLevelMode;
        levelmode.OnEnter(levelText);
        //levelText.text="LEVEL "+LevelMgr.GetInstance().GetIndexByID(levelID);//modify at 20191108 wuhuolong

        // Debug.LogError(LevelMgr.GetInstance().GetIndexByID(levelID));

        //heimu-test
        //black.alpha = 1.0f;
        //isShadow = false;
        //// levelTimer.SetTime(0);
        //StartCoroutine(ShadowInit());
        UIEvent.Broadcast(UIEvent.UI_LEVELSTART);

        //heimu-test
        StartCoroutine(Guiding());
        
    }

    IEnumerator Guiding()
    {
        yield return new WaitForSeconds(1.0f);
        if (needMask == 1)
        {
            Debug.Log("init");
            mask.SetActive(true);
            shaderViewer.Init(1, 0);
        }
        if (needMask == 2)
        {
            var rec = XPlayerPrefs.GetRec(levelID);
            if (rec == null)
            {
                SettlePuzzle newSettlePuzzle = new SettlePuzzle();
                newSettlePuzzle.puzzleID = 0;
                newSettlePuzzle.puzzleRotateState = 1;
                newSettlePuzzle.puzzleGridIndex = 128;
                generalPanelUI.SettlePuzzleFunc(newSettlePuzzle);
                Debug.Log("init");
                mask.SetActive(true);
                shaderViewer.Init(2, 0);
            }
        }
    }

    private void LoadOriginImg()
    {
        //加载原图
        X.Res.LevelConfig levelConfig = LevelMgr.GetInstance().GetLevelConfig(levelID).Config;
        int pitcureId = levelConfig.LevelPicture;
        string altasname = AltasMgr.GetInstance().GetConfigByID((uint)pitcureId).AltasName2;
        Debug.Log(altasname);
        UIAtlas ats = UIAtlasUtil.GetAtlas(altasname);
        ats.Sp = originImg;
        ats.SetSprite("p_" + levelConfig.LevelPicture.ToString());
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
                    if (needMask == 1)
                    {
                        Debug.Log("init");
                        mask.SetActive(true);
                        shaderViewer.Init(1, 0);
                    }
                    if (needMask == 2)
                    {
                        var rec = XPlayerPrefs.GetRec(levelID);
                        if (rec == null)
                        {
                            SettlePuzzle newSettlePuzzle = new SettlePuzzle();
                            newSettlePuzzle.puzzleID = 0;
                            newSettlePuzzle.puzzleRotateState = 0;
                            newSettlePuzzle.puzzleGridIndex = 162;
                            generalPanelUI.SettlePuzzleFunc(newSettlePuzzle);
                            Debug.Log("init");
                            mask.SetActive(true);
                            shaderViewer.Init(2, 0);
                        }
                    }
                }
            }
        }
        if (isShadowToList)
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
                        // pausePage.SetActive(false);
                        black.alpha = 1.0f;
                        UIMgr.ShowPage(UIPageEnum.LevelList_Page);
                    }
                }
            }
        }
        //if (isShadowSelf)
        //{
        //    if (type != -1)
        //    {
        //        if (shadows[type].localScale != shadowMin)
        //        {
        //            shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeedToList);

        //            if (Mathf.Abs(shadows[type].localScale.x - shadowMin.x) <= 0.1f)
        //            {
        //                shadows[type].localScale = Vector3.zero;
        //                isShadowSelf = false;
        //                //Resume();
        //                uint curLevelID = LevelMgr.GetInstance().GetCurLevelID();
        //                XPlayerPrefs.DelRec(curLevelID);
        //                // pausePage.SetActive(false);
        //                CloseUIPlay();
        //                black.alpha = 1.0f;
        //                UIMgr.ShowPage(UIPageEnum.Tips_Page);
        //                UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
        //            }
        //        }
        //    }
        //}
    }

    IEnumerator ShadowInit()
    {
        type = XPlayerPrefs.GetInt(shadowType);
        int waittime = (type == -1) ? 0 : 1;
        //Debug.Log("after" + shadowType + type);
        //Debug.Log("play" + waittime);
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
        puzzleBar.ResetAdPuzzleUse();//重置广告方块
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
        //Debug.Log("animator set false");

        animator.enabled = false;
        RecCheck();
    }

    public void GenMap(bool isReGen = false)
    {
        puzzleBar.InitPuzzleBar();

        generalPanelUI.InitComp(isReGen);
        generalPanelUI.InitGeneralPanelUI();

        StartCoroutine(generalPanelUI.InitPuzzleContainPanel(isReGen));

        panelTransformationController.InitPTController();
        miniMapController.InitMiniMap();
        dragController.GameOverFlag = false;
        SDKMgr.GetInstance().Track(SDKMsgType.OnLevelEnter, (int)levelID);
    }

    private void RecCheck()
    {
        // var rec = XPlayerPrefs.GetRec(levelID);
        // if (rec != null)
        // {
        //     //Debug.Log("RecCheck == true");
        //     Action ac_ok = () =>
        //     {
        //         operationHistoryRecorder.SetLevelId(levelID, true);
        //         GenMap(true);
        //         // levelTimer.SetTime(rec.TimeCount);
        //         // StartCoroutine(levelTimer.RestartTimer());
        //     };
        //     Action ac_cancel = () =>
        //     {
        //         // levelTimer.SetTime(0);
        //         // StartCoroutine(levelTimer.RestartTimer());
        //         GenMap();
        //         XPlayerPrefs.DelRec(levelID);
        //     };
        //     m_isUseRecPanel.Show(ac_cancel, ac_ok);
        // }
        // else
        // {
        //     GenMap();
        //     // StartCoroutine(levelTimer.RestartTimer());
        // }
        GenMap();
    }


    public void LevelOverStep1()
    {
        // CheckRating();//检查评星
        StartCoroutine(panelTransformationController.ReturnToOrigin(0.2f, LevelOverStep2));
        dragController.GameOverFlag = false;
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
        //Debug.Log("return");
        // Resume();

        //heimu-test
        //RandomType();
        //ShadowInit2();
        //isShadowToList = true;
        

        SaveOperation();
        CloseUIPlay();

        UIMgr.ShowPage(UIPageEnum.LevelList_Page);
    }

    private void LevelRestart()
    {
        //if (buttonCheck)
        //{
        //    buttonCheck = false;
        //    isShadowSelf = true;
        //    RandomType();
        //    // Resume();
        //    shadows[type].localScale = shadowMax;
        //    Debug.Log("restart" + isShadowSelf);
        //    Debug.Log("restart" + type);
        //}
    }

    public void LevelRestartCorou()
    {
        if (buttonCheck)
        {
            buttonCheck = false;
            //Debug.Log("restart");
            // Resume();
            uint curLevelID = LevelMgr.GetInstance().CurLevelID;
            XPlayerPrefs.DelRec(curLevelID);
            // pausePage.SetActive(false);
            CloseUIPlay();
            UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
        }
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
        // levelTimer.SetTime(0);
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

        if (puzzleBarForFreeLayoutTrans.childCount > 0)
        {
            puzzleBarForFreeLayoutTrans.GetChild(0).gameObject.SetActive(false);
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
        rec.layout = MatrixUtil.ArrayCopy(generalPanelUI.generalPanelData.Playout);
        // rec.TimeCount = levelTimer.Time;
        if (!rec.isFilled())
        {
            XPlayerPrefs.DelRec(rec.LevelId);
            return;
        }
        //todo 保存广告格子的个数
        XPlayerPrefs.SetRec(rec);
    }

    // public void Pause()
    // {
    //     Time.timeScale = 0;
    //     LoadStarTips();
    //     SaveOperation();
    // }

    // public void Resume()
    // {
    //     Time.timeScale = 1;
    // }

    //暂停界面读取评星提示用-hzy
    // private void LoadStarTips()
    // {
    //     Debug.Log("loadstartips");
    //     //加载评星提示
    //     if (data.Config.Rating1 == 0)
    //     {
    //         starRatingTexts[0].text = "完成关卡！";
    //     }
    //     LoadRating(data.Config.Rating2, 0);
    //     LoadRating(data.Config.Rating3, 1);
    // }

    // private void LoadRating(Google.Protobuf.Collections.RepeatedField<int> rating, int index)
    // {
    //     switch (rating[0])
    //     {
    //         case 1:

    //             string time = rating[1].ToString();
    //             string text = string.Format(value.Items[1].RatingName, time);
    //             starRatingTexts[index + 1].text = text;
    //             break;
    //         case 2:
    //             starRatingTexts[index + 1].text = value.Items[2].RatingName;
    //             break;
    //     }
    // }

    // private void CheckRating()
    // {
    //     int[] starsArr = { 0, 0, 0 };
    //     if (data.Config.Rating1 == 0)
    //     {
    //         starsArr[0] = 1;
    //         CheckRating2And3(starsArr, data.Config.Rating2, 1);
    //         CheckRating2And3(starsArr, data.Config.Rating3, 2);
    //     }
    //     Debug.Log("starsArr" + starsArr);
    //     string id = LevelMgr.GetInstance().GetCurLevelID().ToString();
    //     XPlayerPrefs.SetInt(id + tmpNumStar, starsArr[0] * 100 + starsArr[1] * 10 + starsArr[2]);
    // }

    // private void CheckRating2And3(int[] starsArr, Google.Protobuf.Collections.RepeatedField<int> rating, int index)
    // {
    //     switch (rating[0])
    //     {
    //         case 1:
    //             {
    //                 if (levelTimer.Time < rating[1])
    //                 {
    //                     starsArr[index] = 1;
    //                 }
    //                 break;
    //             }
    //         case 2:
    //             {
    //                 //TODO:需要添加 如果没有使用广告拼图时 的逻辑
    //                 if (puzzleBar.AdPuzzleUseFlag == false)
    //                 {
    //                     starsArr[index] = 1;
    //                 }
    //                 break;
    //             }
    //         default:
    //             break;
    //     }
    // }
}
