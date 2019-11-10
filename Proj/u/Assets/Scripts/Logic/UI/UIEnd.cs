using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnd : UIPage
{
    private uint levelID;
    private uint nextLevelID;
    private LevelData data;

    //private static string numAllStar = "numAllStar";
    static string isUnlock = "isUnlock";
    //static string numStar = "numStar";
    //static string tmpNumStar = "tmpNumStar";
    static string isCompleted = "isCompleted";

    static string curLevel = "curLevel";

    public Text menuText;
    //public Text starsText;
    public GameObject returnTips;
    public Text[] texts;
    public Image screenShot;

    //public GameObject[] starEffects;
    //public GameObject allStar;
    //private bool[] starEffectsCheck = { false, false, false }; 

    X.Res.ValueConfig_ARRAY value;
    //public Text[] starRatingTexts;

    //public Image[] starsImg;

    private bool buttonCheck;
    private bool canClick;

    public RectTransform[] shadows;
    public CanvasGroup black;
    private bool isShadow = false;
    private bool toList = false;
    private bool toLevel = false;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 10.0f;
    private static string shadowType = "shadowType";
    private int type;

    private void OnEnable()
    {
        black.alpha = 0.0f;
        buttonCheck = true;
        canClick = false;
        levelID = LevelMgr.GetInstance().CurLevelID;
        data = LevelMgr.GetInstance().GetLevelConfig(levelID);
        value = LevelMgr.GetInstance().GetValueConfig();
        //ShadowInit();
        OnShow();
    }

    public void OnShow()
    {
        if (gameObject.name == "UIEnd(Clone)")
        {  
            LoadOriginImg();
            SetToNextLevel();

            //保存
            XPlayerPrefs.Save();
        }
    }
    protected override void InitComp()
    {
        
    }
    protected override void InitData()
    {
        OnLevelEnd();
        returnTips.SetActive(false);
        toList = false;
        toLevel = false;
    }

    private void FixedUpdate()
    {
        if (isShadow)
        {
            if (shadows[type].localScale != shadowMin)
            {
                shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeed);

                if (Mathf.Abs(shadows[type].localScale.x - shadowMin.x) <= 0.1f)
                {
                    shadows[type].localScale = Vector3.zero;
                    //进入下一关
                    isShadow = false;
                    black.alpha = 1.0f;
                    //從結算界面退出：
                    //1 如果是Normal模式，回到關卡選擇
                    //2 如果是每日挑戰模式，回到每日挑戰界面并且設置好選擇的日期
                    if(toLevel)
                    {
                        UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
                        return;
                    }
                    if(toList)
                    {
                        BaseLevel levelmode = LevelMgr.GetInstance().CurLevelMode;
                        levelmode.OnClickQuit_UIEnd();
                        return;
                    }
                }
            }
        }
        #region xx
        //if(starEffectsCheck[0])
        //{
        //    if(starEffects[0].transform.position.x != allStar.transform.position.x)
        //    {
        //        starEffects[0].transform.position = Vector3.Lerp(starEffects[0].transform.position, allStar.transform.position, Time.deltaTime);
        //        if(Mathf.Abs(starEffects[0].transform.position.x-allStar.transform.position.x)<=0.1f)
        //        {
        //            starEffectsCheck[0] = false;
        //            starEffects[0].SetActive(false);
        //            int numStar = XPlayerPrefs.GetInt(numAllStar);
        //            XPlayerPrefs.SetInt(numAllStar, numStar + 1);
        //            Debug.Log("add star1");
        //            starsText.text = XPlayerPrefs.GetInt(numAllStar).ToString();
        //        }
        //    }
        //}

        //if (starEffectsCheck[1])
        //{
        //    if (starEffects[1].transform.position.x != allStar.transform.position.x)
        //    {
        //        starEffects[1].transform.position = Vector3.Lerp(starEffects[0].transform.position, allStar.transform.position, Time.deltaTime);
        //        if (Mathf.Abs(starEffects[1].transform.position.x - allStar.transform.position.x) <= 0.1f)
        //        {
        //            starEffectsCheck[1] = false;
        //            starEffects[1].SetActive(false);
        //            int numStar = XPlayerPrefs.GetInt(numAllStar);
        //            XPlayerPrefs.SetInt(numAllStar, numStar + 1);
        //            Debug.Log("add star2");
        //            starsText.text = XPlayerPrefs.GetInt(numAllStar).ToString();
        //        }
        //    }
        //}

        //if (starEffectsCheck[2])
        //{
        //    if (starEffects[2].transform.position.x != allStar.transform.position.x)
        //    {
        //        starEffects[2].transform.position = Vector3.Lerp(starEffects[0].transform.position, allStar.transform.position, Time.deltaTime * 5.0f);
        //        if (Mathf.Abs(starEffects[0].transform.position.x - allStar.transform.position.x) <= 0.1f)
        //        {
        //            starEffectsCheck[2] = false;
        //            starEffects[2].SetActive(false);
        //            int numStar = XPlayerPrefs.GetInt(numAllStar);
        //            XPlayerPrefs.SetInt(numAllStar, numStar + 1);
        //            Debug.Log("add star3");
        //            starsText.text = XPlayerPrefs.GetInt(numAllStar).ToString();
        //        }
        //    }
        //}
        #endregion
    }

    private void ShadowInit()
    {
        //随机加载阴影图
        type = Random.Range(0, 3);
        //type = 1;
        XPlayerPrefs.SetInt(shadowType, type);
        for (int i = 0; i < shadows.Length; i++)
        {
            shadows[i].localScale = Vector3.zero;
        }
        if (type != -1)
            shadows[type].localScale = shadowMax;
        isShadow = false;
    }
    private void ClickReturnLevelList()
    {
        
    }
    private void ClickRestart()
    {
        //重新开始
        UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
    }
    private void SetToNextLevel()
    {
        //设置本关卡已完成
        XPlayerPrefs.SetInt(levelID + isCompleted, 1);
        //Debug.Log(XPlayerPrefs.GetInt(levelID + isCompleted));

        //下一关
        if (LevelMgr.GetInstance().GetNextLevelIDByID(levelID) == 0)
        {
            //Debug.Log("没有下一关了");
            return;
        }
        nextLevelID = LevelMgr.GetInstance().GetNextLevelIDByID(levelID);
        XPlayerPrefs.SetInt(curLevel, (int)nextLevelID);
        XPlayerPrefs.SetInt(nextLevelID + isUnlock, -1);
        LevelMgr.GetInstance().CurLevelID = nextLevelID;
    }
    public void ClickNextLevel()
    {
        if(canClick)
        {
            if(buttonCheck)
            {
                buttonCheck = false;
                if (LevelMgr.GetInstance().GetNextLevelIDByID(levelID) == 0)
                {
                    returnTips.SetActive(true);
                    return;
                }
                //heimu-test
                //Debug.Log("next");
                //isShadow = true;
                //toLevel = true;
                UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
            }
        }
    }
    public void ClickCloseReturnTips()
    {
        returnTips.SetActive(false);
    }
    public void ClickReturnList()
    {
        buttonCheck = false;
        isShadow = true;
        toList = true;
        toLevel = false;
    }
    private void LoadOriginImg()
    {
        //加载原图
        Image img = gameObject.transform.Find("GameObject").transform.Find("Image").GetComponent<Image>();
        int pitcureId = LevelMgr.GetInstance().GetLevelConfig(levelID).Config.LevelPicture;
        string altasname = AltasMgr.GetInstance().GetConfigByID((uint)pitcureId).AltasName2;
        Debug.Log(altasname);
        UIAtlas ats = UIAtlasUtil.GetAtlas(altasname);
        ats.Sp = img;
        ats.SetSprite("p_" + data.Config.LevelPicture.ToString());

        //加载关卡名字
        //menuText.text = LevelMgr.GetInstance().GetIndexByID(levelID);
    }
    private void LoadNumOfStars()
    {
        //加载星星数量
        //starsText.text = XPlayerPrefs.GetInt(numAllStar).ToString();
    }

    private void setStar()
    {
        //string id = LevelMgr.GetInstance().GetCurLevelID().ToString();
        ////string nextID = LevelMgr.GetInstance().GetNextLevelID().ToString();

        ////获取某次游玩达成的当前关卡星星
        //int tmpPreStar = XPlayerPrefs.GetInt(id + tmpNumStar);//tmpPreStar格式是三位数的int，比如101，分别表示三颗星的有无

        ////设置之前获取的当前关卡星星
        //int preStar = XPlayerPrefs.GetInt(id + numStar);
        //if (UnpackStarNum(tmpPreStar) >= UnpackStarNum(preStar))
        //{
        //    XPlayerPrefs.SetInt(id + numStar, tmpPreStar);
        //}
        //int curStar = XPlayerPrefs.GetInt(id + numStar);

        ////设置总星星数量
        //int curNum = XPlayerPrefs.GetInt(numAllStar);
        //XPlayerPrefs.SetInt(numAllStar, curNum + UnpackStarNum(curStar) - UnpackStarNum(preStar));


    }

    private int UnpackStarNum(int starNum)
    {
        int result = 0;
        result += starNum / 100;
        result += (starNum % 100) / 10;
        result += (starNum % 10);

        return result;
    }

    private void LoadStarTips()
    {
        ////加载评星提示
        //if (data.Config.Rating1 == 0)
        //{
        //    starRatingTexts[0].text = "完成关卡！";
        //}
        //string id = LevelMgr.GetInstance().GetCurLevelID().ToString();
        //int curStar = XPlayerPrefs.GetInt(id + numStar);
        //switch (UnpackStarNum(curStar))
        //{
        //    case 1:
        //        LoadStarImg(1);
        //        LoadRating(data.Config.Rating2, 0);
        //        LoadRating(data.Config.Rating3, 1);
        //        break;
        //    case 2:
        //        LoadStarImg(2);
        //        if (curStar % 10 == 0)
        //        {
        //            LoadRating(data.Config.Rating2, 0);
        //            LoadRating(data.Config.Rating3, 1);
        //        }
        //        else
        //        {
        //            LoadRating(data.Config.Rating3, 0);
        //            LoadRating(data.Config.Rating2, 1);
        //        }
        //        break;
        //    case 3:
        //        LoadStarImg(3);
        //        LoadRating(data.Config.Rating2, 0);
        //        LoadRating(data.Config.Rating3, 1);
        //        break;
        //}

        //
    }

    private void LoadStarImg(int num)
    {
        //UIAtlas ats = ResMgr.GetAtlas("star");
        //for (int i = 0; i < 3; i++)
        //{
        //    ats.Sp = starsImg[i];
        //    if (i < num)
        //    {
        //        ats.SetSprite("xingxing");
        //    }
        //    else
        //    {
        //        ats.SetSprite("xingxinghui");
        //    }
        //}
    }

    private void LoadRating(Google.Protobuf.Collections.RepeatedField<int> rating, int index)
    {
        //switch (rating[0])
        //{
        //    case 1:

        //        string time = rating[1].ToString();
        //        string text = string.Format(value.Items[1].RatingName, time);
        //        starRatingTexts[index + 1].text = text;
        //        break;
        //    case 2:
        //        starRatingTexts[index + 1].text = value.Items[2].RatingName;
        //        break;
        //}
    }

    private void starEffectFly(int index)
    {

        //string id = LevelMgr.GetInstance().GetCurLevelID().ToString();
        //int curStar = XPlayerPrefs.GetInt(id + numStar);
        //if(index<=UnpackStarNum(curStar))
        //{
        //    starEffects[index - 1].SetActive(true);
        //    starEffectsCheck[index - 1] = true;
        //}
    }
    //private static string Evaluation_Tag = "Evaluation_";
    public void OnLevelEnd()
    {
        BaseLevel levelmode = LevelMgr.GetInstance().CurLevelMode;
        levelmode.OnExit();
    }
    public void ClickScreenShot()
    {
        Debug.Log("screenshot");
        ImgUtil.TakePhoto(screenShot,this.transform.parent.GetComponent<RectTransform>());
    }

    public void ShowAD()
    {
        AdMgr.GetInstance().InterstitialTrigger();
    }

    public void CanClickNext()
    {
        Debug.Log("animation end");
        canClick = true;
    }

    public void ClickQuit()
    {
        if(canClick)
        {
            if (buttonCheck)
            {
                buttonCheck = false;
                BaseLevel levelmode = LevelMgr.GetInstance().CurLevelMode;
                levelmode.OnClickQuit_UIEnd();
                //返回关卡列表
                //toList = true;
                //isShadow = true;
            }
        }
    }
}