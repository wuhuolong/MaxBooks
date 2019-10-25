using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnd : UIPage
{
    private uint levelID;
    private LevelData data;

    private string numAllStar = "numAllStar";
    string isUnlock = "isUnlock";
    string numStar = "numStar";

    public Text menuText;
    public Text starsText;

    X.Res.ValueConfig_ARRAY value;
    public Text[] starRatingTexts;

    public RectTransform[] shadows;
    private bool isShadow = false;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 10.0f;
    private string shadowType = "shadowType";
    private int type;

    private void OnEnable()
    {
        levelID = LevelMgr.GetInstance().GetCurLevelID();
        data = LevelMgr.GetInstance().GetLevelConfig(levelID);
        value = LevelMgr.GetInstance().GetValueConfig();
        ShadowInit();
        OnShow();
    }
    public void OnShow()
    {
        if(gameObject.name=="UIEnd(Clone)")
        {
            Debug.Log("show end page");
            setStar();
            CompleteAnim();
            StarFlyInAnim();
            LoadOriginImg();
            LoadNumOfStars();
            LoadStarTips();
        }
    }
    protected override void InitComp()
    {

    }
    protected override void InitData()
    {

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
                    shadows[type].localScale = shadowMin;
                    //进入关卡列表界面
                    isShadow = false;
                    UIMgr.ShowPage(UIPageEnum.LevelList_Page);
                }
            }
        }
    }

    private void ShadowInit()
    {
        //随机加载阴影图
        type = Random.Range(0, 3);
        //type = 1;
        XPlayerPrefs.SetInt(shadowType, type);
        //Debug.Log("pre" + shadowType + type);
        for (int i = 0; i < shadows.Length; i++)
        {
            shadows[i].localScale = Vector3.zero;
        }
        if (type != -1)
            shadows[type].localScale = shadowMax;
        isShadow = false;
    }
    public void ClickReturnLevelList()
    {
        //返回关卡列表
        isShadow = true;
    }
    public void ClickRestart()
    {
        //重新开始
        UIMgr.ShowPage(UIPageEnum.Tips_Page);
    }
    public void ClickNextLevel()
    {
        //下一关
        if(LevelMgr.GetInstance().GetNextLevelID()==0)
        {
            Debug.Log("没有下一关了");
            return;
        }
        while(XPlayerPrefs.GetInt((levelID+1).ToString()+isUnlock)==1)
        {
            levelID++;
            if(!XPlayerPrefs.HasKey((levelID+1).ToString()+isUnlock))
            {
                Debug.Log("没有未解锁的关卡了");
                return;
            }
        }
        LevelMgr.GetInstance().SetCurLevelID(levelID+1);
        LevelMgr.GetInstance().SetCurThemeID(LevelMgr.GetInstance().GetLevelConfig(levelID+1).Config.LevelTheme);
        UIMgr.ShowPage(UIPageEnum.Tips_Page);
    }
    private void CompleteAnim()
    {
        Debug.Log("complete animation is played");
    }
    private void StarFlyInAnim()
    {
        Debug.Log("star fly in animation is played");
    }
    private void LoadOriginImg()
    {
        //加载原图
        Image img = gameObject.transform.Find("GameObject").transform.Find("Image").GetComponent<Image>();
        UIAtlas ats = ResMgr.GetAtlas(data.Config.LevelPicture.ToString());
        ats.Sp = img;
        ats.SetSprite("p_"+data.Config.LevelPicture.ToString());

        //加载关卡名字
        menuText.text = data.Config.LevelName;
    }
    private void LoadNumOfStars()
    {
        //加载星星数量
        starsText.text = XPlayerPrefs.GetInt(numAllStar).ToString();
    }

    private void setStar()
    {
        string id = LevelMgr.GetInstance().GetCurLevelID().ToString();
        string nextID = LevelMgr.GetInstance().GetNextLevelID().ToString();
        //设置当前关卡星星
        int preStar = XPlayerPrefs.GetInt(id + numStar);
        XPlayerPrefs.SetInt(id + numStar, 3);


        //设置总星星数量
        int curNum = XPlayerPrefs.GetInt(numAllStar);
        XPlayerPrefs.SetInt(numAllStar, curNum + 3 - preStar);

        //保存
        XPlayerPrefs.Save();
    }

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
