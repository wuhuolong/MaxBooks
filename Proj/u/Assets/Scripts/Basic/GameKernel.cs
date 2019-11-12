using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKernel : MonoSingleton<GameKernel>
{
    float m_last_timestamp = 0;
    static int Time_Interval = 30;
    public static string StartUpCount_Tag = "StartUpCount";


    private List<PreProcess> processList;
    private int index = 0;

    public void Init()
    {
        Debuger.Init();
        Debuger.EnableLog = GameConfig.IsDebug;
        LanguageMgr.GetInstance().SetUp();
        int count = XPlayerPrefs.GetInt(StartUpCount_Tag) + 1;
        XPlayerPrefs.SetInt(StartUpCount_Tag, count);
        Application.targetFrameRate = 60;
        //UIMgr.ShowPage(UIPageEnum.Main_Page);
        processList = new List<PreProcess>() {
            new BinProcess(),
            new AtlasProcess(),
            new AbProcess()
        };
        StartCoroutine(Preprocess());
    }

    IEnumerator Preprocess()
    {
        processList[index].Process();
        while (index == processList.Count)
        {
            if (processList[index].Progress == processList[index].num)
            {
                if (index >= processList.Count - 1)
                {
                    break;
                }
                index++;
                processList[index].Process();
            }
            yield return null;
        }

        yield return StartCoroutine(NextStep());
    }

    IEnumerator NextStep()
    {
        yield return StartCoroutine(AbMgr.GetInstance().Init());
        //UIMgr.ShowTips(UIPageEnum.Effect_Tips);
        UIMgr.GetInstance().ShowPage(UIPageEnum.Main_Page);
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
