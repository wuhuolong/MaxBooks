using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKernel : MonoSingleton<GameKernel>
{
    float m_last_timestamp = 0;
    static int Time_Interval = 30;
    public static string StartUpCount_Tag = "StartUpCount";
    
    public void Init()
    {
        GameConfig.Init();
        Debuger.Init();
        Debuger.EnableLog = GameConfig.IsDebug;
        LanguageMgr.GetInstance().SetUp();
    }

    public void OnStart()
    {
        //
        int count = XPlayerPrefs.GetInt(StartUpCount_Tag) + 1;
        XPlayerPrefs.SetInt(StartUpCount_Tag, count);
        Application.targetFrameRate = 60;
        //UIMgr.ShowPage(UIPageEnum.Main_Page);
        StartCoroutine(Preprocess());
    }

    IEnumerator Preprocess()
    {
        yield return StartCoroutine(NextStep());
    }

    IEnumerator NextStep()
    {
        yield return StartCoroutine(AbMgr.GetInstance().Init());
        UIMgr.Init();
        //UIMgr.ShowTips(UIPageEnum.Effect_Tips);
        UIMgr.ShowPage(UIPageEnum.Load_Page);
    }

    private void OnApplicationQuit()
    {
        XPlayerPrefs.Save();
        Debuger.DeInit();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            m_last_timestamp = Time.time;
        }
        else
        {
            if (Time.time - m_last_timestamp >= Time_Interval)
            {
                int count = XPlayerPrefs.GetInt(StartUpCount_Tag) + 1;
                XPlayerPrefs.SetInt(StartUpCount_Tag, count);
            }
        }
    }
}
