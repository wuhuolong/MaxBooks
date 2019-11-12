using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalLevel : BaseLevel
{
    public override void OnEnter(params object[] argv)
    {
        Text txt = (Text)argv[0];
        uint curlevelid = LevelMgr.GetInstance().CurLevelID;
        txt.text = "LEVEL " + LevelMgr.GetInstance().GetIndexByID(curlevelid);//modify at 20191108 wuhuolong
    }

    public override void OnExit(params object[] argv)
    {
        GameObject nextLevelButton=argv[0] as GameObject;
        nextLevelButton.SetActive(true);
        X.Res.FuncParamConfig config = FuncMgr.GetInstance().GetConfigByID(1);
        if (config != null)
        {
            uint curlevelid = LevelMgr.GetInstance().CurLevelID;
            //int showcount = XPlayerPrefs.GetInt(Evaluation_Tag);
            for (int i = 0; i < config.Params1.Count; i++)
            {
                if (config.Params1[i] == curlevelid /*&& config.Params2[i] > showcount*/)
                {
                    SDKMgr.GetInstance().Track(SDKMsgType.OnCallEvaluation);
                    //showcount++;
                    //XPlayerPrefs.SetInt(Evaluation_Tag, showcount);
                    return;
                }
            }
        }
    }

    public override void OnClickQuit(params object[] argv)
    {
        UIMgr.GetInstance().ShowPage(UIPageEnum.LevelList_Page);
    }
}
