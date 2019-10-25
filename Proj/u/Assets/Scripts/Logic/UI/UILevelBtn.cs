using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelBtn : UIWindows
{
    private string themeID;
    private string nextThemeID;
    private uint levelID;
    private uint nextLevelID;//0表示不存在

    public Text levelText;
    public Image[] stars;
    public Image levelImg;
    public Image unlockBtn;

    string isUnlock = "isUnlock";

    protected override void InitComp()
    {

    }

    protected override void InitData()
    {

    }

    public void setLevelID(uint id)
    {
        levelID = id;
    }
    public void setThemeID(string id)
    {
        themeID = id;
    }
    public void setNextLevelID(uint id)
    {
        nextLevelID = id;
    }
    public void setNextThemeID(string id)
    {
        nextThemeID = id;
    }

    private void setState()
    {
        LevelMgr.GetInstance().SetCurLevelID(levelID);
        LevelMgr.GetInstance().SetCurThemeID(themeID);
        LevelMgr.GetInstance().SetNextLevelID(nextLevelID);
        LevelMgr.GetInstance().SetNextThemeID(nextThemeID);
    }

    public void ClickEnterLevel()
    {
        if(XPlayerPrefs.GetInt(levelID.ToString()+ isUnlock)==0)
        {
            setState();
            UIMgr.ShowPage(UIPageEnum.Tips_Page);
        }
        else
        {
            Debug.Log("未解锁");
        }
    }

    public void ClickUnlock()
    {
        Debug.Log("解锁");
        XPlayerPrefs.SetInt(levelID.ToString() + isUnlock, 0);
        Destroy(transform.Find("unlockBtn").gameObject);
    }
}
