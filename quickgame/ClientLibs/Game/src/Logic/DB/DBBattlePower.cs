//------------------------------------------------------------------------------
// FileName : DBBattlePower.cs
// Desc   : 提供战力计算的表格
// Author : raorui
// Date : 2018.7.17
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

public class DBBattlePower : DBSqliteTableResource
{
    public class BattlePowerInfo
    {
        public KeyValuePair<uint, float> val;    // 战力系数
        public byte show_type; // 显示类型
        public string desc; // 描述
        public string tips_desc; // tips描述
        public string name = ""; // 属性名字
        public float equip_val; // 装备评分系数
        public float equip_strength_val; // 装备强化评分系数
        public float equip_baptize_val; // 装备洗练评分系数
    }

    Dictionary<uint, BattlePowerInfo> mBattlePowerInfos = new Dictionary<uint, BattlePowerInfo>();
    static DBBattlePower mInstance = null;

    public DBBattlePower(string strName, string strPath) :
        base(strName, strPath)
    {
        mInstance = this;
    }

    public static DBBattlePower Instance
    {
        get
        {
            return mInstance;
        }
    }

    public BattlePowerInfo GetItemInfo(uint id)
    {
        string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
        var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query, (int)DBManager.CommandTag.TAG_3);
        if (reader == null)
        {
            mBattlePowerInfos[id] = null;
            return null;
        }

        if (!reader.HasRows || !reader.Read())
        {
            mBattlePowerInfos[id] = null;

            reader.Close();
            reader.Dispose();
            return null;
        }

        BattlePowerInfo info = new BattlePowerInfo();
        int suffix_len = "{0}".Length;

        List<string> valStrList = DBTextResource.ParseArrayString(GetReaderString(reader, "val"));
        if (valStrList.Count >= 2)
        {
            uint key = 0;
            uint.TryParse(valStrList[0], out key);
            float val = 0f;
            float.TryParse(valStrList[1], out val);
            info.val = new KeyValuePair<uint, float>(key, val);
        }

        info.show_type = DBTextResource.ParseBT_s(GetReaderString(reader, "show_type"), 0);
        info.desc = GetReaderString(reader, "desc");
        if (!string.IsNullOrEmpty(info.desc))
        {
            //if(info.desc.Length > suffix_len)
            //    info.name = info.desc.Substring(0, info.desc.Length - suffix_len);
            if (info.desc.Length > suffix_len)
                info.name = info.desc.Replace("{0}", "");
        }

        info.tips_desc = GetReaderString(reader, "tips_desc");
        info.equip_val = GetReaderFloat(reader, "equip_val");
        info.equip_strength_val = GetReaderFloat(reader, "equip_strength_val");
        info.equip_baptize_val = GetReaderFloat(reader, "equip_baptize_val");

        mBattlePowerInfos.Add(id, info);

        reader.Close();
        reader.Dispose();
        return info;
    }

    public override void Load()
    {
        IsLoaded = true;
    }

    public override void Unload()
    {
        mBattlePowerInfos.Clear();
    }

    public BattlePowerInfo GetBattlePowerInfo(uint uiKey)
    {
        BattlePowerInfo info = null;
        if (!mBattlePowerInfos.TryGetValue(uiKey, out info))
            info = GetItemInfo(uiKey);

        return info;
    }

    /// <summary>
    /// 根据属性列表算出战力
    /// </summary>
    /// <returns></returns>
    public static ulong CalBattlePowerByAttrs(ActorAttribute attr)
    {
        if (attr == null)
        {
            return 0;
        }

        float baseValue = 0;
        float additionValue = 0;
        float specialValue = 0;
        float fourValue = 0;
        foreach (KeyValuePair<uint, IActorAttribute> kv in attr)
        {
            uint attrId = kv.Value.Id;
            BattlePowerInfo battlePowerInfo = DBBattlePower.Instance.GetBattlePowerInfo(attrId);
            if (battlePowerInfo != null)
            {
                long attrVal = kv.Value.Value;

                uint battleType = battlePowerInfo.val.Key;
                float battleValue = battlePowerInfo.val.Value;
                switch (battleType)
                {
                    case 1: // 基数
                        {
                            baseValue += attrVal * battleValue;
                        }
                        break;
                    case 2: // 加成
                        {
                            additionValue += attrVal * battleValue;
                        }
                        break;
                    case 3: // 特殊
                        {
                            float specialAttr = (GameConstHelper.GetFloat("GAME_CF_SPEED1") * attrVal) / (GameConstHelper.GetFloat("GAME_CF_SPEED2") + attrVal) - GameConstHelper.GetFloat("GAME_CF_SPEED3");
                            specialValue += specialAttr * battleValue;
                        }
                        break;
                    case 4: // 一比一加战力
                        {
                            fourValue += attrVal * battleValue;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        return (ulong)(baseValue * (10000.0f + additionValue + specialValue) / 10000.0f + fourValue);
    }
}

