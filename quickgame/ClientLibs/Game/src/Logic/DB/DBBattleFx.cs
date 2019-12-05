//------------------------------------------------------------------------------
// FileName ： DBBattleFx.cs
// Desc   ： 提供战斗受击后的特效等的配置
// Author : raorui
// Date : 2016.10.10
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

public class DBBattleFx : DBSqliteTableResource
{
    public class BattleFxInfo
    {
        public float HitDelayTime; // 打击帧
        public bool IsFlying = true; // 是否具备死亡击飞效果
        public float FlyingAngle = 60.0f; // 浮空角度
        public float FlyingXSpeed = 15.0f; // 击飞水平方向速度速度
        public float FlyingXFric = 15.0f; // 击飞水平方向摩擦力系数
        public AnimationEffect.ResInitData BeattackEffectData = null;// 命中目标的特效
    }

    Dictionary<uint, BattleFxInfo> mBattleFxInfos = new Dictionary<uint, BattleFxInfo>();
    static DBBattleFx mInstance = null;
    
    public DBBattleFx(string strName, string strPath) : 
        base(strName, strPath)
    {
        mInstance = this;
    }
    
    public static DBBattleFx Instance
    {
        get
        {
            return mInstance;
        }
    }

    public override void Load()
    {
        IsLoaded = true;
    }

    public override void Unload()
    {
        mBattleFxInfos.Clear();
    }
    
    public BattleFxInfo GetBattleFxInfo(uint uiKey)
    {
        BattleFxInfo info;
        if (mBattleFxInfos.TryGetValue(uiKey, out info))
        {
            return info;
        }

        string query_str = string.Format("SELECT * FROM {0} WHERE {1}=\"{2}\"", mTableName, "id", uiKey);
        var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
        if (reader == null)
        {
            mBattleFxInfos[uiKey] = null;
            return null;
        }

        if (!reader.HasRows || !reader.Read())
        {
            mBattleFxInfos[uiKey] = null;
            reader.Close();
            reader.Dispose();
            return null;
        }

        info = new BattleFxInfo();

        uint id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
        info.HitDelayTime = DBTextResource.ParseUS(GetReaderString(reader, "hit_time")) * GlobalConst.MilliToSecond;
        info.IsFlying = DBTextResource.ParseUS(GetReaderString(reader, "is_flying")) == 1;
        info.FlyingAngle = DBTextResource.ParseF(GetReaderString(reader, "flying_angle"));
        info.FlyingXSpeed = DBTextResource.ParseF(GetReaderString(reader, "flying_xspeed"));
        info.FlyingXFric = DBTextResource.ParseF(GetReaderString(reader, "flying_xfric"));

        string under_attack_effect = GetReaderString(reader, "under_attack_effect");
        string under_attack_sound = GetReaderString(reader, "under_attack_sound");
        if (under_attack_sound != string.Empty)
            under_attack_sound = string.Format("{{0}.mp3", under_attack_sound);

        if (!string.IsNullOrEmpty(under_attack_effect) || !string.IsNullOrEmpty(under_attack_sound))
        {
            info.BeattackEffectData = new AnimationEffect.ResInitData();
            info.BeattackEffectData.BindNode = GetReaderString(reader, "bind_node"); //"Bip001Pelvis";
            info.BeattackEffectData.Effect = under_attack_effect;
            info.BeattackEffectData.Audio = under_attack_sound;
            info.BeattackEffectData.EndTime = (float)DBTextResource.ParseF_s(GetReaderString(reader, "under_attack_effect_lifetime"), 0) * 0.001f;
            info.BeattackEffectData.FollowTarget = DBTextResource.ParseUS_s(GetReaderString(reader, "follow_target"), 1) == 1;
            info.BeattackEffectData.AutoScale = DBTextResource.ParseUS_s(GetReaderString(reader, "auto_scale"), 0) == 1;
        }

        mBattleFxInfos.Add(id, info);

        reader.Close();
        reader.Dispose();

        return info;
    }       
}

