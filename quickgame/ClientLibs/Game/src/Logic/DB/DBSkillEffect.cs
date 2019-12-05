//------------------------------------------------------------------------------
// File ： DBSkillEffect.cs
// Desc ： 技能效果表
// Author : raorui
// Date : 2016.9.20
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

public class DBSkillEffect : DBSqliteTableResource
{
    public enum SkillEffectType : byte
    {
        ET_NONE,
        ET_STATUS, // 改变角色状态的效果
        ET_OTHERS
    }

    public class SkillEffectInfo
    {
        public class SkillEffectInfoPotentialParam
        {
            public uint trigram_rune_id;
            public uint value;
        }
        public uint id;// id
        public string type; //效果类型
        public string attr; // 效果的属性，对于改变角色状态的效果，attr对应具体的状态类型
        public float p1; //参数1
        public float p2; //参数2
        public SkillEffectInfoPotentialParam p2_potentialParam;
        //public float p3; //参数3
    }
    
    Dictionary<uint, SkillEffectInfo> mSkillEffectMap = new Dictionary<uint, SkillEffectInfo>();
    static DBSkillEffect mInstance;
    
    public static DBSkillEffect GetInstance()
    {
        return mInstance;
    }
    
    public DBSkillEffect(string strName, string strPath):
        base(strName, strPath)
    {
        mInstance = this;
    }
    
    public SkillEffectInfo GetSkillEffectInfo(uint id)
    {
        SkillEffectInfo info;
        if (mSkillEffectMap.TryGetValue(id, out info))
        {
            return info;
        }

        string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id.ToString());
        var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
        if (table_reader == null)
        {
            mSkillEffectMap[id] = null;
            return null;
        }

        if (!table_reader.HasRows)
        {
            mSkillEffectMap[id] = null;
            table_reader.Close();
            table_reader.Dispose();
            return null;
        }

        if (!table_reader.Read())
        {
            mSkillEffectMap[id] = null;
            table_reader.Close();
            table_reader.Dispose();
            return null;
        }

        info = new SkillEffectInfo();
        info.id = DBTextResource.ParseUI(GetReaderString(table_reader, "id"));
        info.type = GetReaderString(table_reader, "type");
        info.attr = GetReaderString(table_reader, "attr");
        float.TryParse(GetReaderString(table_reader, "p1"), out info.p1);
        string p2_str = GetReaderString(table_reader, "p2");
        float p = 0;
        bool can_parse = float.TryParse(p2_str, out p);
        if (can_parse == false)
        {
            //尝试用潜力格式读取
            List<uint> p2_array = DBTextResource.ParseArrayUint(p2_str, ",");
            if (p2_array != null && p2_array.Count >= 2)
            {
                info.p2_potentialParam = new SkillEffectInfo.SkillEffectInfoPotentialParam();
                info.p2_potentialParam.trigram_rune_id = p2_array[0];
                info.p2_potentialParam.value = p2_array[1];
            }
        }
        else
        {
            info.p2 = p;
        }

        mSkillEffectMap[info.id] = info;

        table_reader.Close();
        table_reader.Dispose();

        return info;
    }

    public override void Unload()
    {
        mSkillEffectMap.Clear();
    }

    public override void Load()
    {
        IsLoaded = true;
    }
}