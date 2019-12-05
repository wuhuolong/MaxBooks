using System.Collections.Generic;

public struct NpcScenePosition
{
    public uint SceneId;
    public uint NpcId;

    public static NpcScenePosition Make(string raw)
    {
        List<uint> ids = new List<uint>();
        Utils.DataFormatHelper.DBRawStringReplaceBraceToIds(raw, ids);

        NpcScenePosition result = new NpcScenePosition();

        for (int i = 0; i < ids.Count; i++)
        {
            if(i == 0)
            {
                result.SceneId = ids[i];
            }
            else
            {
                result.NpcId = ids[i];
            }
        }

        return result;
    }

    public static NpcScenePosition Make(List<string> strings)
    {
        NpcScenePosition result = new NpcScenePosition();

        uint val = 0;
        if (strings.Count > 0)
        {
            uint.TryParse(strings[0], out val);
            result.SceneId = val;
        }
        if (strings.Count > 1)
        {
            uint.TryParse(strings[1], out val);
            result.NpcId = val;
        }

        return result;
    }
}