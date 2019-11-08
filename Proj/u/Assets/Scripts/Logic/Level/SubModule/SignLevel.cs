using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignLevel : BaseLevel
{
    public override void OnEnter(params object[] argv)
    {
        Text txt = (Text)argv[0];
        uint curlevelid = LevelMgr.GetInstance().CurLevelID;
        txt.text = "# " + curlevelid;//modify at 20191108 wuhuolong
    }

    public override void OnExit(params object[] argv)
    {

    }

    public override void OnClickQuit_UIEnd(params object[] argv)
    {
        UIMgr.ShowPage(UIPageEnum.Calendar_Page);        
    }
}
