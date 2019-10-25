using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using X.Res;
public enum Level_UnlockType
{
    None = 0,
    AD,
    Subscription,
}
public class LevelData
{
    public LevelMapArray Map;
    public LevelConfig Config;
}

public class LevelMgr : CSSingleton<LevelMgr>
{
    private LevelConfig_ARRAY m_config;
    private ThemeConfig_ARRAY m_themeConfig;
    private LevelMapData m_data;
    private ValueConfig_ARRAY m_value;

    private uint curLevelID;
    private uint nextLevelID;

    private string curThemeID;
    private string nextThemeID;

    public LevelMgr()
    {
        InitData();
    }
    private void InitData()
    {
        m_config = ResBinReader.Read<LevelConfig_ARRAY>("LevelConfig");
        SortConfig();
        m_themeConfig = ResBinReader.Read<ThemeConfig_ARRAY>("ThemeConfig");
        m_value = ResBinReader.Read<ValueConfig_ARRAY>("ValueConfig");
        m_data = LevelLoader.Load();
        if (m_data == null)
        {
            this.Log("m_data == null");
        }
    }

    /// <summary>
    /// m_config排序
    /// </summary>
    private void SortConfig()
    {
        //第一遍排序按照关卡id
        for(int i=0;i<m_config.Items.Count;i++)
        {
            for(int j=0;j<m_config.Items.Count-i-1;j++)
            {
                if(m_config.Items[j].LevelId>m_config.Items[j+1].LevelId)
                {
                    LevelConfig temp = m_config.Items[j];
                    m_config.Items[j] = m_config.Items[j + 1];
                    m_config.Items[j + 1] = temp;
                }
            }
        }
        //第二遍排序按照主题id
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            for (int j = 0; j < m_config.Items.Count - i - 1; j++)
            {
                if (string.Compare(m_config.Items[j].LevelTheme,m_config.Items[j+1].LevelTheme)==1)
                {
                    LevelConfig temp = m_config.Items[j];
                    m_config.Items[j] = m_config.Items[j + 1];
                    m_config.Items[j + 1] = temp;
                }
            }
        }
    }

    private LevelMapArray GetMapArrayData(uint id)
    {
        return m_data.GetConfigByID(id);
    }

    private LevelConfig GetLevelConfigData(uint id)
    {
        LevelConfig item;
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            item = m_config.Items[i];
            if (item.LevelId == id)
            {
                return item;
            }
        }
        return null;
    }

    public ToolMapArray GetToolMapArray()
    {
        return m_data.Tools;
    }

    public ValueConfig_ARRAY GetValueConfig()
    {
        return m_value;
    }

    public void DoLoadLevelListLen(System.Action<LevelConfig> ac)
    {
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            ac(m_config.Items[i]);
        }
    }

    public void DoLoadLevelListContent(System.Action<LevelConfig, LevelConfig, int, int> ac)
    {
        for (int i = 0; i < m_config.Items.Count; i++)
        {
            if(i+1 == m_config.Items.Count)
                ac(m_config.Items[i], m_config.Items[i], i, m_config.Items.Count);
            else
                ac(m_config.Items[i], m_config.Items[i + 1], i, m_config.Items.Count);
        }
    }
    public LevelData GetLevelConfig(uint id)
    {
        LevelData data = new LevelData();
        data.Config = GetLevelConfigData(id);
        data.Map = GetMapArrayData(id);
        if (data.Config == null)
        {
            this.Log("data.Config == null)");
        }
        if (data.Map == null)
        {
            this.Log("data.Map == null");
        }
        return data;
    }
    public ThemeConfig GetThemeConfig(string id)
    {
        ThemeConfig config = new ThemeConfig();
        for (int i = 0; i < m_themeConfig.Items.Count; i++)
        {
            if (m_themeConfig.Items[i].ThemeId == id)
            {
                config = m_themeConfig.Items[i];
            }
        }
        return config;
    }

    public LevelConfig_ARRAY GetLevelConfigArray()
    {
        return m_config;
    }
    public ThemeConfig_ARRAY GetThemeConfigArray()
    {
        return m_themeConfig;
    }

    public uint GetCurLevelID()
    {
        return curLevelID;
    }
    public void SetCurLevelID(uint id)
    {
        curLevelID = id;
    }
    public uint GetNextLevelID()
    {
        return nextLevelID;
    }
    public void SetNextLevelID(uint id)
    {
        nextLevelID = id;
    }
    public string GetCurThemeID()
    {
        return curThemeID;
    }
    public void SetCurThemeID(string id)
    {
        curThemeID = id;
    }
    public string GetNextThemeID()
    {
        return nextThemeID;
    }
    public void SetNextThemeID(string id)
    {
        nextThemeID = id;
    }
}
