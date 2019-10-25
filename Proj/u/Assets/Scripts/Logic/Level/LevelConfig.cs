using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class LevelMapArray
{
    public enum CellType
    {
        Invisible,
        Block,
        Normal,
    }
    public int MapHeight;//地图高度//可以不用保存
    public int MapWidth;//地图宽度
    public uint Id;//关卡id
    public uint ConfigID;//对应的关卡ID
    public int[] MapArray;//地图网格
    public void FitArray(int owidth, int oheight)
    {
        MapArray = MatrixUtil.MatrixTrans(owidth, oheight, MapWidth, MapHeight, MapArray);
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("ID==>" + Id + "\n");
        sb.Append("width==>" + MapWidth + "height==>" + MapHeight + "\n");
        for (int i = 1; i <= MapArray.Length; i++)
        {
            if (i % MapWidth == 0)
            {
                sb.Append(MapArray[i - 1] + "\n");
            }
            else
            {
                sb.Append(MapArray[i - 1] + ",");
            }
        }
        return sb.ToString();
    }
}

[Serializable]
public class ToolMapArray
{
    public Dictionary<string, int[]> FillTypeMap;//填充格子类型
    public Dictionary<string, int> WidthMap;//填充格子类型
    public int Length
    {
        get
        {
            return FillTypeMap.Count;
        }
    }
    public string[] FillTypeArray
    {
        get
        {
            if (m_FillTypeArray == null || isDirty)
            {
                m_FillTypeArray = new string[Length];
                int i = 0;
                foreach (var item in FillTypeMap)
                {
                    m_FillTypeArray[i] = item.Key;
                    i++;
                }
            }
            return m_FillTypeArray;
        }
    }
    [NonSerialized]
    private string[] m_FillTypeArray;
    [NonSerialized]
    private bool isDirty = false;
    public void SetTypeLength(int len)
    {
        isDirty = true;
        if (len > Length)
        {
            for (int i = Length; i < len; i++)
            {
                FillTypeMap.Add(i.ToString(), new int[9]);
                WidthMap.Add(i.ToString(), 3);
            }
        }
        else
        {
            for (int i = len; i < Length; i++)
            {
                FillTypeMap.Remove(i.ToString());
                WidthMap.Remove(i.ToString());
            }
        }
    }
    public void FitArray(int owidth, int oheight, int fwidth, int fheight, string index)
    {
        FillTypeMap[index] = MatrixUtil.MatrixTrans(owidth, oheight, fwidth, fheight, FillTypeMap[index]);
    }
}

[Serializable]
public class LevelMapData
{
    public string Name;
    public List<LevelMapArray> Configs;
    public ToolMapArray Tools;
    public LevelMapArray GetConfigByID(uint id)
    {
        foreach (var item in Configs)
        {
            if (item.ConfigID == id)
            {
                return item;
            }
        }
        return null;
    }
    public LevelMapArray GetConfigByMapID(uint id)
    {
        foreach (var item in Configs)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }
    public void DeleteConfig(LevelMapArray config)
    {
        if (Configs.Contains(config))
        {
            Configs.Remove(config);
        }
        else
        {
            UnityEngine.Debug.Log("试图删除一个不存在的关卡配置表");
        }
    }
    public void DeleteConfig(List<LevelMapArray> config)
    {
        for (int i = 0; i < config.Count; i++)
        {
            DeleteConfig(config[i]);
        }
    }
    public void DeleteConfig(int id)
    {
        foreach (var item in Configs)
        {
            if (item.Id == id)
            {
                Configs.Remove(item);
                return;
            }
        }
    }
    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("Name==>" + Name + "\n");

        for (int i = 1; i <= Configs.Count; i++)
        {
            sb.Append(Configs[i - 1].ToString() + "\n");
        }
        return sb.ToString();
    }
}
