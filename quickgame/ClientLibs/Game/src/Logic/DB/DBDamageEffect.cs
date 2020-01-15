//------------------------------------------------------------------------------
// FileName ： DBDamageEffect.cs
// Desc   ： 设置伤害飘字类型的表格
// Author : raorui
// Date : 2016.9.22
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

public class DBDamageEffect : DBSqliteTableResource
{
    public enum EffectTarget
    {
        ET_DEST = 1,// 受击着
        ET_SRC = 2, // 攻击者
    }

    public class DamageEffectInfo
    {
        public uint ID; // 枚举ID
        public EffectTarget Target; //飘字显示的目标
        public bool IsCombineValue; // 是否在分段飘字的时候合并所有的伤害数字
    }
    
    Dictionary<uint, DamageEffectInfo> mDamageEffectInfos = new Dictionary<uint, DamageEffectInfo>();
    static DBDamageEffect mInstance = null;
    
    public DBDamageEffect(string strName, string strPath) : 
        base(strName, strPath)
    {
        mInstance = this;
    }

    public static DBDamageEffect Instance
    {
        get
        {
            return mInstance;
        }
    }

    public static DBDamageEffect GetInstance()
    {
        return mInstance;
    }

    protected override void ParseData(SqliteDataReader reader)
    {
        if(reader == null || !reader.HasRows)
        {
            return;
        }
        
        DamageEffectInfo effectInfo;
        while(reader.Read())
        {
            effectInfo = new DamageEffectInfo();
            effectInfo.ID = DBTextResource.ParseUI(GetReaderString(reader,"type_idx"));
            effectInfo.Target = (EffectTarget)DBTextResource.ParseUI(GetReaderString(reader,"target"));
            effectInfo.IsCombineValue = DBTextResource.ParseUI_s(GetReaderString(reader, "combine_value"), 0) == 1;
            
            mDamageEffectInfos.Add(effectInfo.ID, effectInfo);
        }   
    }
    
    public override void Unload()
    {
        mDamageEffectInfos.Clear();
    }
    
    /// <summary>
    /// 获取指定ID的伤害类型配置
    /// </summary>
    /// <param name="uiKey"></param>
    /// <returns></returns>
    public DamageEffectInfo GetDamageEffectInfo(uint id)
    {
        DamageEffectInfo effectInfo = null;
        mDamageEffectInfos.TryGetValue(id, out effectInfo);

        return effectInfo;
    }

    /// <summary>
    /// 指定ID的伤害类型是否在分段飘字的时候合并伤害数字的显示
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool IsCombineValue(uint id)
    {
        DamageEffectInfo effectInfo = null;
        mDamageEffectInfos.TryGetValue(id, out effectInfo);

        if (effectInfo != null)
            return effectInfo.IsCombineValue;
        else
            return false;
    }

    /// <summary>
    /// 获取所有的伤害类型配置
    /// </summary>
    public Dictionary<uint, DamageEffectInfo> DamagetEffects
    {
        get
        {
            return mDamageEffectInfos;
        }
    }
}

