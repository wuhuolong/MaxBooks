//------------------------------------------------------------------------------
// FileName ： DBBulletTrace.cs
// Desc   ： 追踪目标的子弹表
// Author : raorui
// Date : 2016.8.31
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

public class DBBulletTrace : DBSqliteTableResource
{
    public enum BulletTypes
    {
        BT_NONE = 0,// 无
        BT_DIRECTION = 1, //直接飞行
        BT_BIND = 2,// 绑定在角色身上
        BT_IMMEDIATE = 3, // 立即定位到目标位置
        BT_LINK = 4, // 连接技能释放者和目标物体（暂时用于拉扯技能）
    }

    public class BulletInfo
    {
        public uint ID; // 子弹ID
        public BulletTypes BulletType; // 子弹的类型
        public float  OffsetX;   // 前后的偏移数值
        public float  OffsetY;   // 高度的偏移数值
        public float  FlySpeed;  // 飞行速度
        public float  FlyMaxTime;   // 最大飞行时间
        public string AttackEffect = string.Empty; // 子弹对应的特效文件
        public string AttackSound = string.Empty;  // 绑定在子弹上的声音
        //public AnimationEffect.ResInitData BeattackEffectData = null;// 命中目标的特效
    }
    
    Dictionary<uint, BulletInfo> mBulletInfos = new Dictionary<uint, BulletInfo>();
    static DBBulletTrace SInstance = null;
    
    public DBBulletTrace(string strName, string strPath) : 
        base(strName, strPath)
    {
        SInstance = this;
    }
    
    public static DBBulletTrace GetInstance()
    {
        return SInstance;
    }

    protected override void ParseData(SqliteDataReader reader)
    {
        if(reader == null || !reader.HasRows)
        {
            return;
        }

        BulletInfo kInfo;
        while(reader.Read())
        {
            kInfo = new BulletInfo();   
            kInfo.ID = DBTextResource.ParseUI(GetReaderString(reader,"type_idx"));
            kInfo.BulletType = (BulletTypes)DBTextResource.ParseUI_s(GetReaderString(reader,"bullet_type"),0);
            kInfo.FlySpeed = (float)DBTextResource.ParseI(GetReaderString(reader,"speed")) * 0.01f;
            kInfo.FlyMaxTime = (float)DBTextResource.ParseI(GetReaderString(reader,"max_time")) * 0.001f;
            kInfo.OffsetX = DBTextResource.ParseI(GetReaderString(reader,"offset_x")) * 0.01f;
            kInfo.OffsetY = DBTextResource.ParseI(GetReaderString(reader,"offset_y")) * 0.01f;

            string effect_file = GetReaderString(reader,"effect_file");
            if (!string.IsNullOrEmpty(effect_file))
                kInfo.AttackEffect = effect_file + ".prefab";
            string sound_file = GetReaderString(reader,"sound_file").Trim();
            if (!string.IsNullOrEmpty(sound_file))
                kInfo.AttackSound = sound_file + ".mp3";
            
            /*string under_attack_effect = GetReaderString(reader,"under_attack_effect");
            if (under_attack_effect != string.Empty)
                under_attack_effect = under_attack_effect + ".prefab";
            string under_attack_sound = GetReaderString(reader,"under_attack_sound");
            if (under_attack_sound != string.Empty)
                under_attack_sound = string.Format("{{0}.mp3", under_attack_sound);
      
            if (!string.IsNullOrEmpty(under_attack_effect) || !string.IsNullOrEmpty(under_attack_sound))
            {
                kInfo.BeattackEffectData = new AnimationEffect.ResInitData();
                kInfo.BeattackEffectData.Prefab = under_attack_effect;
                kInfo.BeattackEffectData.Audio = under_attack_sound;
                kInfo.BeattackEffectData.EndTime = (float)DBTextResource.ParseF_s(GetReaderString(reader,"under_attack_lifetime"), 0) * 0.001f;
                kInfo.BeattackEffectData.InWorld = true;
            }*/

            mBulletInfos.Add(kInfo.ID, kInfo);
        }   
    }
    
    public override void Unload()
    {
        mBulletInfos.Clear();
    }
    
    public BulletInfo GetBulletInfo(uint uiKey)
    {
        BulletInfo kResult;
        if (mBulletInfos.TryGetValue(uiKey, out kResult))
        {
            return kResult;
        }
        return null;
    }       
}

