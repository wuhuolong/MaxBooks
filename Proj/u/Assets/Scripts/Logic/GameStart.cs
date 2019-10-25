using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    UIBase m_uiroot;

    private void Awake()
    {
        Debuger.Init();
        Debuger.EnableLog = true;
    }
    void Start()
    {
        this.Log("GameLogicStart");
        GameConfig.Init();
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
        this.Log("ShowPage ==> Main_Page");
        UIMgr.Init();
        //UIMgr.ShowTips(UIPageEnum.Effect_Tips);
        UIMgr.ShowPage(UIPageEnum.Main_Page);
    }

    private void OnApplicationQuit()
    {
        XPlayerPrefs.Save();
        Debuger.DeInit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            XPlayerPrefs.Save();
        }
    }
}
