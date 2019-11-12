using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;

public class BinProcess : PreProcess
{
    public BinProcess()
    {
        num = 6;
    }
    public override void Process()
    {
        System.Action ac1 = () => { ResBinReader.Read<LevelConfig_ARRAY>("LevelConfig");Progress++; };
        System.Action ac2 = () => { ResBinReader.Read<ThemeConfig_ARRAY>("ThemeConfig"); Progress++; };
        System.Action ac3 = () => { ResBinReader.Read<ValueConfig_ARRAY>("ValueConfig"); Progress++; };
        System.Action ac4 = () => { ResBinReader.Read<LanguageConfig_ARRAY>("LanguageConfig"); Progress++; };
        System.Action ac5 = () => { ResBinReader.Read<FuncParamConfig_ARRAY>("FuncParamConfig"); Progress++; };
        System.Action ac6 = () => { ResBinReader.Read<SignInConfig_ARRAY>("SignInConfig"); Progress++; };
        Loom.QueueOnMainThread(ac1);
        Loom.QueueOnMainThread(ac2);
        Loom.QueueOnMainThread(ac3);
        Loom.QueueOnMainThread(ac4);
        Loom.QueueOnMainThread(ac5);
        Loom.QueueOnMainThread(ac6);
    }
}

public class AtlasProcess : PreProcess
{
    public AtlasProcess()
    {
        num = 1;
    }
    public override void Process()
    {
        UIAtlasUtil.GetAtlasAsync("level_s", (o)=> { Callback(); });
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
        UIMgr.GetInstance().LoadUIAsync((int)UIPageEnum.LevelList_Page,()=> { Callback(); });
        UIMgr.GetInstance().LoadUIAsync((int)UIPageEnum.Main_Page, () => { Callback(); });
        UIMgr.GetInstance().LoadUIAsync((int)UIPageEnum.Play_Page, () => { Callback(); });

        //shader
        AbMgr.GetInstance().AsyncLoad("shaders",null);
    }
}


