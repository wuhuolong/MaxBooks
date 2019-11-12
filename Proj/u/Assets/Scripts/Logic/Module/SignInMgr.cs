using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using X.Res;

public class SignInMgr : CSSingleton<SignInMgr>
{
    SignInConfig_ARRAY data;
    List<uint> m_day_list;
    public List<uint> Days
    {
        get
        {
            return m_day_list;
        }
    }

    public uint MaxDay
    {
        get
        {
            if (m_day_list.Count > 0)
                return m_day_list[m_day_list.Count - 1];
            return 0;
        }
    }

    public uint MinDay
    {
        get
        {
            if (m_day_list.Count > 0)
                return m_day_list[0];
            return 0;
        }
    }

    public uint MaxValidDay
    {
        get
        {
            if (m_day_list.Count > 0)
            {
                int todayIndex = GetIndexByID((uint)TimeUtil.getIntByDateTime(DateTime.Today));
                for (int i = todayIndex; i >= 0; --i)
                {
                    uint dayInt = m_day_list[i];
                    SignInConfig signInConfig = GetConfigByID(dayInt);
                    if (signInConfig != null)
                    {
                        uint levelID = signInConfig.LevelId;
                        if (LevelMgr.GetInstance().GetLevelConfig(levelID).Config != null)
                        {
                            return dayInt;
                        }
                    }
                }
            }
            return 0;
        }
    }

    Dictionary<uint, SignInConfig> m_Configs;
    protected override void Init()
    {
        data = ResBinReader.Read<SignInConfig_ARRAY>("SignInConfig");
        m_day_list = new List<uint>();
        m_Configs = new Dictionary<uint, SignInConfig>();
        for (int i = 0; i < data.Items.Count; i++)
        {
            m_day_list.Add(data.Items[i].DayId);
            m_Configs.Add(data.Items[i].DayId, data.Items[i]);
        }
        m_day_list.Sort();
    }

    public SignInConfig GetConfigByID(uint id)
    {
        SignInConfig config;
        if (m_Configs.TryGetValue(id, out config))
        {
            return config;
        }
        return null;
    }

    public bool IsSign(int DayInt)
    {
        int index = DayInt / 8;
        int offset = DayInt % 8;
        return XPlayerPrefs.GetSign(index, offset);
    }

    public void Sign(int DayInt)
    {
        Debug.Log("DayInt:" + DayInt);



        int index = DayInt / 8;
        int offset = DayInt % 8;

        Debug.Log("index:" + index);
        Debug.Log("offset:" + offset);

        XPlayerPrefs.SetSign(index, offset, 1);
    }

    public int GetIndexByID(uint id)
    {
        if (m_day_list.Contains(id))
        {
            return m_day_list.IndexOf(id);
        }
        return -1;
    }
}
