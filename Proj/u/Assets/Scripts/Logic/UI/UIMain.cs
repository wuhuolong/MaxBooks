using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : UIPage
{
    public CanvasGroup black;
    public CanvasGroup flash;

    private float alphaSpeed = 8.2f;
    private bool isFlashOver = false;
    private bool flashCheck = false;

    private float alphaZero = 0.0f;
    private float alphaOne = 1.0f;

    public RectTransform[] shadows;
    public bool isShadow = false;
    public bool isShadowFromList = false;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 10.0f;
    private float shadowSpeedFromList = 3.5f;
    private string shadowType = "shadowType";
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
        //Debug.Log(Time.time);
        //black.alpha = alphaOne;
    }

    private void OnEnable()
    {
        type = XPlayerPrefs.GetInt(shadowType);
        if(isFlashOver==true && type!=-1)
        {
            Debug.Log("before shadow2");
            black.alpha = 1.0f;
            StartCoroutine(ShadowInit2());
        }
        ShadowInit();
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
                        Debug.Log(Time.time+"over");
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
                        //进入关卡列表界面
                        UIMgr.ShowPage(UIPageEnum.LevelList_Page);
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
        Debug.Log("shadow2");
        type = XPlayerPrefs.GetInt(shadowType);
        int waittime = (type == -1) ? 0 : 1;
        Debug.Log("play" + waittime);
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
        RandomType();
        ShadowInit();
        isShadow = true;
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
}