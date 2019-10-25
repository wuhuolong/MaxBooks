using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;

public class BinProcess : PreProcess
{
    public override void Process()
    {
        ResBinReader.Read<LevelConfig_ARRAY>("LevelConfig");
        ResBinReader.Read<ThemeConfig_ARRAY>("ThemeConfig");
        ResBinReader.Read<ValueConfig_ARRAY>("ValueConfig");
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
    public override void Process()
    {

    }
}
