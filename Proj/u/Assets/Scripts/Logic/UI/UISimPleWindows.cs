using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISimPleWindows : UIWindows
{
    protected override void InitComp()
    {

    }
    protected override void InitData()
    {

    }
    public void ClickTips()
    {
        UIMgr.ShowTips(UIPageEnum.SimTips_Tips);
    }
}
