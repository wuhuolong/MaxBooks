using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using X.Res;

public class UILevelList : UIPage
{
    string menuPath = "Prefabs/UI/Menu.Prefab";
    string levelBtnPath = "Prefabs/UI/UILevelBtn.Prefab";

    string isUnlock = "isUnlock";
    //string numStar = "numStar";
    //string numAllStar = "numAllStar";
    //string curLevel = "curLevel";
    string isCompleted = "isCompleted";
    public RectTransform LevelContent;
    //public Text starsText;
    public Scrollbar scrollbar;
    private float scrollValue;
    //private float len;

    private bool isFirst;

    private bool buttonCheck;

    public Text topText;

    //转场动画用-hzy
    public CanvasGroup black;
    public RectTransform[] shadows;
    private Vector3 shadowMax = new Vector3(120.0f, 120.0f, 120.0f);
    private Vector3 shadowMin = Vector3.one;
    private float shadowSpeed = 3.3f;
    private float shadowSpeedToMain = 10.0f;
    public bool isShadow = false;
    public bool isShadowToLevel = false;
    public bool isShadowToMain = false;
    private string shadowType = "shadowType";
    private int type;

    GameObject menu;
    GameObject levelBtn;

    float offsetY = 480.0f;
    float offsetX = 320.0f;
    float offsetMenu = 260.0f;

    float rectWidth;

    float curHeight = 0.0f;

    private float totalLen = 100.0f;

    string curTheme = "";
    int themeCnt = 0;
    int levelCnt = 0;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        buttonCheck = true;
        //black.alpha = 1.0f;
        themeCnt = 0;
        isShadow = false;
        //StartCoroutine(ShadowInit());

        rectWidth = LevelContent.rect.width;

        if(!isFirst)
        {
            RefreshLevelList();
        }
        isFirst = false;

    }
    private void FixedUpdate()
    {
        if (isShadow)
        {
            scrollbar.value = scrollValue;
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
        if(isShadowToLevel)
        {
            if (shadows[type].localScale != shadowMin)
            {
                shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeedToMain);

                if (Mathf.Abs(shadows[type].localScale.x - shadowMin.x) <= 0.1f)
                {
                    shadows[type].localScale = Vector3.zero;
                    //进入主界面
                    isShadowToLevel = false;
                    black.alpha = 1.0f;
                    UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
                }
            }
        }
        if (isShadowToMain)
        {
            if (shadows[type].localScale != shadowMin)
            {
                shadows[type].localScale = Vector3.Lerp(shadows[type].localScale, shadowMin, Time.deltaTime * shadowSpeedToMain);

                if (Mathf.Abs(shadows[type].localScale.x - shadowMin.x) <= 0.1f)
                {
                    shadows[type].localScale = Vector3.zero;
                    //进入主界面
                    isShadowToMain = false;
                    black.alpha = 1.0f;
                    UIMgr.ShowPage(UIPageEnum.Main_Page);
                }
            }
        }
    }

    protected override void InitComp()
    {
        isFirst = true;
        if (gameObject.name == "UILevelList(Clone)")
        {
            for (int i = 0; i < LevelContent.childCount; i++)
            {
                Destroy(LevelContent.GetChild(i).gameObject);
            }
            totalLen = 100.0f;
            curHeight = 0.0f;
            LoadLevelList();
        }
    }
    protected override void InitData()
    {

    }

    private void SetTopText()
    {
        int AllNum = LevelMgr.GetInstance().GetNumOfLevel();
        int CompleteNum = LevelMgr.GetInstance().GetNumOfComplete();
        topText.text = CompleteNum.ToString() + "/" + AllNum.ToString();
    }

    private void SetScrollValue()
    {
        uint curLevelID = LevelMgr.GetInstance().GetNewLevel().LevelId;
        if(curLevelID == 0)
        {
            scrollValue = 1.0f;
        }
        else
        {
            List<int> index = LevelMgr.GetInstance().GetLevelIndex(curLevelID);
            float curLen = 0.0f;
            if(index.Count==1 && index[0]<=9)
            {
                scrollValue = 1.0f;
                return;
            }
            curLen += index.Count * offsetMenu;
            for(int i =0;i<index.Count;i++)
            {
                curLen += Mathf.CeilToInt(index[i] / 3.0f) * offsetY;
            }
            scrollValue = 1 - curLen / totalLen;
            //len = curLen;
        }
    }

    IEnumerator ShadowInit()
    {
        type = XPlayerPrefs.GetInt(shadowType);
        int waittime = (type == -1) ? 0 : 1;
        yield return new WaitForSeconds(0.2f*waittime);
        black.alpha = 0.0f;
        if(type!=-1)
            shadows[type].localScale = shadowMin;
        yield return new WaitForSeconds(0.02f*waittime);
        if(type!=-1)
            isShadow = true;
    }

    private void ShadowInit2()
    {
        shadows[type].localScale = Vector3.zero;
        isShadow = false;
        for (int i = 0; i < shadows.Length; i++)
        {
            shadows[i].localScale = Vector3.zero;
        }
        if (type != -1)
            shadows[type].localScale = shadowMax;
    }

    private void RandomType()
    {
        type = Random.Range(0, 3);
        XPlayerPrefs.SetInt(shadowType, type);
    }

    public void EnterLevel()
    {
        if(buttonCheck)
        {
            buttonCheck = false;
            //返回
            //heimu-test
            //isShadowToLevel = true;
            //RandomType();
            //ShadowInit2();
            UIMgr.ShowPage_Play(UIPageEnum.Play_Page);
        }
    }

    public void ReturnToMain()
    {
        if (buttonCheck)
        {
            buttonCheck = false;
            //返回
            //heimu-test
            //isShadowToMain = true;
            //RandomType();
            //ShadowInit2();
            UIMgr.ShowPage(UIPageEnum.Main_Page);
        }
    }

    private void RefreshLevelList()
    {
        SetScrollValue();
        SetTopText();
        int levelCnt = 0;
        int themeCnt = 0;
        for(int i=0;i<LevelContent.gameObject.transform.childCount;i++)
        {
            if(LevelContent.gameObject.transform.GetChild(i).name == "menu(Clone)")
            {
                themeCnt++;
                levelCnt = 0;
            }
            if(LevelContent.gameObject.transform.GetChild(i).name=="UILevelBtn(Clone)")
            {
                
                UILevelBtn uibtn = LevelContent.gameObject.transform.GetChild(i).GetComponent<UILevelBtn>();
                if (levelCnt == 1)
                {
                    uibtn.line.SetActive(true);
                }
                LevelConfig config = LevelMgr.GetInstance().GetLevelConfig(uibtn.levelID).Config;
                LoadLevelBtn(uibtn, config.LevelId, config.LevelPicture.ToString(), levelCnt, themeCnt);
            }
        }
    }

    private void LoadLevelList()
    {
        //LoadNumOfStars();
        LevelMgr.GetInstance().DoLoadLevelListLen(LoadLevelListLen);
        LevelContent.sizeDelta = new Vector2(rectWidth, totalLen);
        SetScrollValue();
        SetTopText();

        curTheme = "";
        levelCnt = 0;
        LevelMgr.GetInstance().DoLoadLevelListContent(LoadLevelListContent);
    }

    private void LoadLevelListLen(LevelConfig config)
    {
        //新的主题
        if (curTheme != config.LevelTheme)
        {
            curTheme = config.LevelTheme;
            totalLen += offsetMenu;
            levelCnt = 0;
        }
        int cnt = levelCnt % 3;
        if (cnt == 0)
        {
            totalLen += offsetY;
        }
        levelCnt++;
    }

    private void LoadLevelListContent(LevelConfig config,LevelConfig nextConfig,int i,int count)
    {
        
        ////设置星星数量
        //if(!XPlayerPrefs.HasKey(config.LevelId.ToString()+numStar))
        //{
        //    XPlayerPrefs.SetInt(config.LevelId.ToString() + numStar, 0);
        //}
        
        //新的主题
        if (curTheme != config.LevelTheme)
        {
            curTheme = config.LevelTheme;
            curHeight += offsetMenu;
            menu = ResMgr.LoadGameObject(menuPath);
            menu.transform.SetParent(LevelContent.transform);
            menu.transform.localPosition = Vector3.zero - new Vector3(0, curHeight, 0);
            menu.transform.localScale = LevelContent.localScale;
            LoadMenu(menu, config.LevelTheme);
            themeCnt++;
            levelCnt = 0;
        }
        int cnt = levelCnt % 3;
        if (cnt == 0)
        {
            curHeight += offsetY;
        }
        levelBtn = ResMgr.LoadGameObject(levelBtnPath);
        levelBtn.transform.SetParent(LevelContent.transform);
        levelBtn.transform.localPosition = Vector3.zero - new Vector3((cnt - 1) * offsetX * -1, curHeight, 0);
        levelBtn.transform.localScale = LevelContent.localScale;
        
        UILevelBtn UIBtn = levelBtn.GetComponent<UILevelBtn>();
        if (cnt == 1)
        {
            UIBtn.line.SetActive(true);
        }
        LoadLevelBtn(UIBtn, config.LevelId, config.LevelPicture.ToString(), levelCnt,themeCnt);
        UIBtn.setLevelID(config.LevelId);
        UIBtn.setThemeID(config.LevelTheme);
        //if (count > i + 1)
        //{
        //    UIBtn.setNextLevelID(config.LevelId+1);
        //    if (config.LevelTheme != nextConfig.LevelTheme)
        //        UIBtn.setNextThemeID(nextConfig.LevelTheme);
        //    else
        //        UIBtn.setNextThemeID(config.LevelTheme);
        //}
        //else
        //{
        //    UIBtn.setNextLevelID(0);
        //    UIBtn.setNextThemeID("null");
        //}
        levelCnt++;
    }

    private void LoadNumOfStars()
    {

        //if(!XPlayerPrefs.HasKey(numAllStar))
        //{
        //    XPlayerPrefs.SetInt(numAllStar, 0);
        //}
        //starsText.text = XPlayerPrefs.GetInt(numAllStar).ToString();
    }

    /// <summary>
    /// 加载主题
    /// </summary>
    private void LoadMenu(GameObject menu,string n)
    {
        //加载主题名字
        Text name = menu.GetComponentInChildren<Text>();
        //name.text = LevelMgr.GetInstance().GetThemeConfig(n).ThemeName;
        uint id = LevelMgr.GetInstance().GetThemeConfig(n).ThemeName;
        LanguageMgr.GetInstance().GetLangStrByID(name,id);
    }

    private int UnpackStarNum(int starNum)
    {
        int result = 0;
        result += starNum / 100;
        result += (starNum % 100) / 10;
        result += (starNum % 10);

        return result;
    } 

    private void LoadLevelBtn(UILevelBtn uiLevelBtn, uint id,string picture,int levelCnt,int themeCnt)
    {
        //加载关卡名字，缩略图;
        //uiLevelBtn.levelText.text = themeCnt.ToString() + "-" + (levelCnt + 1).ToString();
        //string picname = "level_s";//string.Format("s_{0}", picture);
        string altasname = AltasMgr.GetInstance().GetConfigByID(id).AltasName;
        UIAtlas ats = UIAtlasUtil.GetAtlas(altasname);
        UIAtlas ats2 = UIAtlasUtil.GetAtlas("uncomplete");
        ats.Sp = uiLevelBtn.levelImg;
        ats2.Sp = uiLevelBtn.levelImg;

        if(ats!=null)
        {
            if (XPlayerPrefs.GetInt(id.ToString()+isCompleted)==1)
            {
                ats.SetSprite("s_" + picture);//ats.SetSprite("p_"+picture);
                ats.Sp.rectTransform.localScale = Vector3.one;
                uiLevelBtn.star.SetActive(true);
                uiLevelBtn._new.SetActive(false);
                //uiLevelBtn.levelText.text = LevelMgr.GetInstance().GetLevelConfig(id).Config.LevelName;
                //uiLevelBtn.levelText.text = themeCnt.ToString() + "-" + (levelCnt + 1).ToString();
            }
            else if(XPlayerPrefs.GetInt(id.ToString()+isUnlock)==-1)
            {
                Debug.Log("isunlock");
                ats2.SetSprite("unknown");
                ats.Sp.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                uiLevelBtn._new.SetActive(true);
                uiLevelBtn.star.SetActive(false);
                //uiLevelBtn.levelText.text = (levelCnt+1).ToString();
                //uiLevelBtn.levelText.text = "? ? ?";
            }
            else
            {
                uiLevelBtn.star.SetActive(false);
                uiLevelBtn._new.SetActive(false);
                uiLevelBtn.SetGray();
                Debug.Log("islock");
                //未解锁
                ats2.SetSprite("lock");
                ats.Sp.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
        }

        #region starandlock
        ////加载星星
        //if (UnpackStarNum(XPlayerPrefs.GetInt(id.ToString() + numStar)) >= 1)
        //{
        //    int stars = UnpackStarNum(XPlayerPrefs.GetInt(id.ToString() + numStar));
        //    Debug.Log(stars);
        //    for (int i = 0; i < 3; i++)
        //    {
        //        UIAtlas starAts = ResMgr.GetAtlas("levelStar");
        //        starAts.Sp = uiLevelBtn.stars[i];

        //        if (i < stars)
        //        {
        //            starAts.SetSprite("guanqiaxuanzexing1");
        //        }
        //        else
        //        {
        //            starAts.SetSprite("guanqiaxuanzexing2");
        //        }
        //    }
        //}
        //else
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        uiLevelBtn.stars[i].color = new Color(255, 255, 255, 0);
        //    }
        //}


        ////设置解锁状态;
        //UIAtlas unlockAts = ResMgr.GetAtlas("unlock");
        //unlockAts.Sp = uiLevelBtn.unlockBtn;
        //switch (LevelMgr.GetInstance().GetLevelConfig(id).Config.LevelUnlock)
        //{
        //    case 0:
        //        XPlayerPrefs.SetInt(id.ToString() + isUnlock, -1);
        //        Destroy(uiLevelBtn.unlockBtn.gameObject);
        //        break;
        //    case 1:
        //        if(XPlayerPrefs.GetInt(id.ToString()+isUnlock)==-1)
        //        {
        //            Destroy(uiLevelBtn.unlockBtn.gameObject);
        //            break;
        //        }
        //        XPlayerPrefs.SetInt(id.ToString() + isUnlock, 1);
        //        unlockAts.SetSprite("guanggao");
        //        break;
        //    case 2:
        //        if (XPlayerPrefs.GetInt(id.ToString() + isUnlock) == -1)
        //        {
        //            Destroy(uiLevelBtn.unlockBtn.gameObject);
        //            break;
        //        }
        //        XPlayerPrefs.SetInt(id.ToString() + isUnlock, 2);
        //        unlockAts.SetSprite("zuanshi");
        //        break;
        //}
        #endregion
    }
}
