using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelBtn : UIWindows
{
    private string themeID;
    private uint levelID;

    //public UILevelList levelList;

    private bool buttonCheck;

    public Text levelText;
    //public Image[] stars;
    public Image levelImg;
    public Image unlockBtn;

    string isUnlock = "isUnlock";
    string curLevel = "curLevel";

    protected override void InitComp()
    {

    }

    protected override void InitData()
    {
        buttonCheck = true;
    }

    public void setLevelID(uint id)
    {
        levelID = id;
    }
    public void setThemeID(string id)
    {
        themeID = id;
    }

    private void setState()
    {
        XPlayerPrefs.SetInt(curLevel, (int)levelID);
        LevelMgr.GetInstance().SetCurLevelID(levelID);
        //LevelMgr.GetInstance().SetCurThemeID(themeID);
    }

    public void ClickEnterLevel()
    {
        if (XPlayerPrefs.GetInt(levelID.ToString() + isUnlock) == -1)
        {
            if (buttonCheck)
            {
                buttonCheck = false;
                setState();
                gameObject.transform.GetComponentInParent<UILevelList>().EnterLevel();
                XPlayerPrefs.SetInt(curLevel, (int)levelID);
                XPlayerPrefs.Save();
            }
        }
        else
        {
            Debug.Log("未解锁");
        }
    }

    public void ClickUnlock()
    {
        Debug.Log("解锁");
        XPlayerPrefs.SetInt(levelID.ToString() + isUnlock, -1);
        XPlayerPrefs.Save();
        Destroy(transform.Find("unlockBtn").gameObject);
    }
}
