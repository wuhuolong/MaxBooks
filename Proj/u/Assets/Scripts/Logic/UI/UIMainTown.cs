using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainTown : UIPage
{
    protected override void InitComp()
    {
        this.Log("InitComp");
    }

    protected override void InitData()
    {
        this.Log("InitData");
    }

    public void ClickTips()
    {
        UIMgr.ShowTips(UIPageEnum.SimTips_Tips);
    }

    public void ClickWinds()
    {
        UIMgr.ShowWindows(UIPageEnum.SimPleWindows_Wind);
    }
}
