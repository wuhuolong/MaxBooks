using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;

public class BinProcess : PreProcess
{
    public BinProcess()
    {
        num = 3;
    }
    public override void Process()
    {
        System.Action ac1 = () => { ResBinReader.Read<LevelConfig_ARRAY>("LevelConfig");Progress++; };
        System.Action ac2 = () => { ResBinReader.Read<ThemeConfig_ARRAY>("ThemeConfig"); Progress++; };
        System.Action ac3 = () => { ResBinReader.Read<ValueConfig_ARRAY>("ValueConfig"); Progress++; };
        Loom.QueueOnMainThread(ac1);
        Loom.QueueOnMainThread(ac2);
        Loom.QueueOnMainThread(ac3);
    }
}

public class AtlasProcess : PreProcess
{
    public override void Process()
    {

    }
}

public class AbProcess : PreProcess
{
    public AbProcess()
    {
        num = 3;
    }
    public override void Process()
    {
        //UI部分
        UIMgr.LoadUIAsync((int)UIPageEnum.LevelList_Page,()=> { Callback(); });
        UIMgr.LoadUIAsync((int)UIPageEnum.Main_Page, () => { Callback(); });
        UIMgr.LoadUIAsync((int)UIPageEnum.Play_Page, () => { Callback(); });
    }
}


