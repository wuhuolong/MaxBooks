using System;
using System.Collections.Generic;

public enum UIPageEnum
{
    Load_Page,
    Main_Page,
    // BG_Page,
    // PlayField_Page,
    LevelList_Page,
    Tips_Page,

    Effect_Tips,

    Play_Page,
    GM_Page,
    UseRec_Tips,
    // Pause_Page,
    Calendar_Page,
    End_Page,
    TipsLabel_Page,
    Test_Wnd,
    Max,
}
public static class UIUtil
{

    public static Dictionary<int, string> m_DicUI = new Dictionary<int, string>() {
        {(int)UIPageEnum.Load_Page,typeof(UILoad).ToString()},
        {(int)UIPageEnum.Main_Page,typeof(UIMain).ToString()},
        {(int)UIPageEnum.LevelList_Page,typeof(UILevelList).ToString()},
        {(int)UIPageEnum.Effect_Tips,typeof(UIEffect).ToString()},
        {(int)UIPageEnum.Play_Page,typeof(UIPlay).ToString()},
        {(int)UIPageEnum.GM_Page,typeof(UIGM).ToString()},
        {(int)UIPageEnum.Calendar_Page,typeof(UIChallenge).ToString()},
        {(int)UIPageEnum.UseRec_Tips,typeof(UIUseRecTips).ToString()},
        //{(int)UIPageEnum.Test_Wnd,typeof(testImg).ToString()},
        {(int)UIPageEnum.TipsLabel_Page,typeof(UITipsLabel).ToString()},
        // {(int)UIPageEnum.Pause_Page,typeof(UIPause).ToString()},

        {(int)UIPageEnum.End_Page,typeof(UIEnd).ToString()},

    };
    public static string GetUITypeName(int uiid)
    {
        if (m_DicUI.ContainsKey(uiid))
        {
            return m_DicUI[uiid];
        }
        return string.Empty;
    }
}
