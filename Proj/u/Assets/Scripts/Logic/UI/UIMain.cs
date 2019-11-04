using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : UIPage
{
    bool languageCheck = true;

    public CanvasGroup black;
    public CanvasGroup flash;
    public GameObject setting;
    public Text[] texts;

    private float alphaSpeed = 8.2f;
    private bool isFlashOver = false;
    private bool flashCheck = false;

    private float alphaZero = 0.0f;
    private float alphaOne = 1.0f;

    private uint levelID;

    private bool buttonCheck;

    public RectTransform[] shadows;
    private bool isShadow = false;
    private bool isShadowFromList = false;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 10.0f;
    private float shadowSpeedFromList = 3.5f;
    private string shadowType = "shadowType";
    private string curLevel = "curLevel";
    private string isUnlock = "isUnlock";
    private int type;

    protected override void InitComp()
    {
        this.Log("InitComp");
    }

    protected override void InitData()
    {
        this.Log("InitData");
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        
        if(XPlayerPrefs.GetInt(curLevel)==0)
        {
            LevelMgr.GetInstance().SetFirstLevel();
        }
        levelID = (uint)XPlayerPrefs.GetInt(curLevel);
        LevelMgr.GetInstance().SetCurLevelID(levelID);
        XPlayerPrefs.SetInt(levelID + isUnlock, -1);
        //XPlayerPrefs.Save();

        buttonCheck = true;
        type = XPlayerPrefs.GetInt(shadowType);
        if(isFlashOver==true && type!=-1)
        {
            black.alpha = 1.0f;
            StartCoroutine(ShadowInit2());
        }
        //ShadowInit();
    }

    private void FixedUpdate()
    {
        //闪屏
        if(isFlashOver==false)
        {
            if (flashCheck == false)
            {
                if (black.alpha != alphaZero)
                {
                    black.alpha = Mathf.Lerp(black.alpha, alphaZero, alphaSpeed * Time.deltaTime);
                    if (Mathf.Abs(alphaZero - black.alpha) <= 0.01f)
                    {
                        black.alpha = alphaZero;
                        Invoke("flashChange", 2.0f);
                    }
                }
            }
            else
            {
                if (black.alpha != alphaOne)
                {
                    black.alpha = Mathf.Lerp(black.alpha, alphaOne, alphaSpeed * Time.deltaTime);
                    if (Mathf.Abs(alphaOne - black.alpha) <= 0.01f)
                    {
                        black.alpha = alphaOne;
                        closeBlack();
                        closeFlash();
                        isFlashOver = true;
                    }
                }
            }
        }

        //转场动画
        if (isShadow)
        {
            if(type!=-1)
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
                        UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
                    }
                }
            }
            
        }

        if(isShadowFromList)
        {
            if(type!=-1)
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
        if(type!=-1)
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
        if(type!=-1)
            shadows[type].localScale = shadowMin;
        yield return new WaitForSeconds(0.02f * waittime);
        isShadowFromList = true;
    }

    private void RandomType()
    {
        type = Random.Range(0, 3);
        XPlayerPrefs.SetInt(shadowType, type);
    }

    public void Click()
    {
        if(buttonCheck)
        {
            buttonCheck = false;
            RandomType();
            ShadowInit();
            isShadow = true;
        }
    }

    private void flashChange()
    {
        flashCheck = true;
    }

    private void closeBlack()
    {
        black.alpha = alphaZero;
        black.blocksRaycasts = false;
    }

    private void closeFlash()
    {
        flash.alpha = alphaZero;
        flash.blocksRaycasts = false;
    }

    public void CallGM()
    {
        UIMgr.ShowWindows(UIPageEnum.GM_Page);
    }

    public void ClickOpenSetting()
    {
        setting.SetActive(true);
        Refresh();
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
        languageCheck = !languageCheck;
        GameConfig.Language = languageCheck ? LangType.cn : LangType.en;
        Refresh();
    }

    private void Refresh()
    {
        LanguageMgr.GetInstance().GetLangStrByID(texts[0], 3);
        LanguageMgr.GetInstance().GetLangStrByID(texts[1],4);
        LanguageMgr.GetInstance().GetLangStrByID(texts[2],5);
        LanguageMgr.GetInstance().GetLangStrByID(texts[3],6);
        LanguageMgr.GetInstance().GetLangStrByID(texts[4],7);
    }
}