//------------------------------------------------------------------------------
// File ： DBBuffSev.cs
// Desc ： 技能buff表的读取
// Author : raorui
// Date : 2016.9.20
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

public class DBBuffSev : DBSqliteTableResource
{
    public enum BindPos
    {
        BP_Body  = 0,
        BP_Head  = 1,
        BP_Foot  = 2
    }

    public class DBBuffInfo
    {
        public uint buff_id;      // id
        public string name; // buff名
        public bool is_show_tip; // 是否显示tip
        public ushort max_add_num; // buff的叠加数量
        public List<uint> add_eff;      //持续效果
        public string des;//说明
        public BattleStatusType battle_effect_type = BattleStatusType.BATTLE_STATUS_TYPE_INVALID;// buff的特殊状态类型
        public int[] attr_effect_type;// buff的修改属性效果类型
        public ushort buff_flags;     // flags,对应Buff类中的AuraFlags
        public float delay_time; // buff延迟生效的时间
        public float life_time; // 生命周期(ms)
        public uint shape_shift; //变身buff对应的角色表中的id
        public byte shift_state; // 变身状态标记
        public float period_time = Mathf.Infinity; // 周期执行时间(ms)
        public string icon;                        // icon
        public string effect_file;                 // 特效文件
        public ushort priority;                    // 特效的优先级
        public bool force_show;                    // 特效是否一定显示
        public bool other_hide;                    // buff的目标是其他玩家的时候，是否隐藏隐藏特效
        public BindPos bind_pos;                   // 绑定位置
        public bool follow_target = false;                 // 是否跟随目标移动
        public float scale = 1.0f;        // 特效的缩放
        public bool auto_scale = false;  // 特效是否自动缩放
        public bool hide_countDown = false; //是否隐藏倒计时
        public int max_count = 5; // 单个buff特效的最大显示数量
        public bool HasFlag(Buff.BuffFlags kTargetFlag)
        {
            return (buff_flags & (ushort)kTargetFlag) != 0;
        }
    }
    
    Dictionary<uint, DBBuffInfo> mBuffInfos = new Dictionary<uint, DBBuffInfo>();
    static DBBuffSev mInstance;
    
    public static DBBuffSev GetInstance()
    {
        return mInstance;
    }
    
    public DBBuffSev(string strName, string strPath) : 
        base(strName, strPath)
    {
        mInstance = this;
    }
    
    public DBBuffInfo GetBuffInfo(uint uiID)
    {
        DBBuffInfo info = null;
        if (mBuffInfos.TryGetValue(uiID, out info))
        {
            return info;
        }

        string query_str = string.Format("SELECT * FROM {0} WHERE {1}=\"{2}\"", mTableName, "id", uiID);
        var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
        if (reader == null)
        {
            mBuffInfos[uiID] = null;
            return null;
        }

        if (!reader.HasRows || !reader.Read())
        {
            mBuffInfos[uiID] = null;
            reader.Close();
            reader.Dispose();
            return null;
        }

        var buff_info = new Buff.BuffInfo();
        buff_info.buff_id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
        buff_info.is_show_tip = DBTextResource.ParseUI(GetReaderString(reader, "is_show_tip")) == 1;
        buff_info.max_add_num = DBTextResource.ParseUS(GetReaderString(reader, "max_layer"));
        buff_info.add_eff = DBTextResource.ParseArrayUint(GetReaderString(reader, "add_eff"), ",");
        buff_info.delay_time = DBTextResource.ParseUI_s(GetReaderString(reader, "delay_time"), 0) * 0.001f;
        buff_info.shape_shift = DBTextResource.ParseUI_s(GetReaderString(reader, "transform"), 0);
        buff_info.shift_state = DBTextResource.ParseBT_s(GetReaderString(reader, "shift_state"), 0);
        buff_info.life_time = 3.0f;//buff的时间由服务端发送下来

        buff_info.name = GetReaderString(reader, "name");
        buff_info.icon = GetReaderString(reader, "icon");
        buff_info.effect_file = GetReaderString(reader, "effect_file");
        buff_info.priority = DBTextResource.ParseUS_s(GetReaderString(reader, "priority"), 0);
        buff_info.force_show = DBTextResource.ParseUS_s(GetReaderString(reader, "force_show"), 0) == 1;
        buff_info.other_hide = DBTextResource.ParseUS_s(GetReaderString(reader, "other_hide"), 0) == 1;
        buff_info.bind_pos = (BindPos)DBTextResource.ParseUI(GetReaderString(reader, "bind_pos"));
        buff_info.follow_target = DBTextResource.ParseUI_s(GetReaderString(reader, "follow_target"), 1) == 1;
        buff_info.scale = DBTextResource.ParseF_s(GetReaderString(reader, "scale"), 1.0f);
        buff_info.auto_scale = DBTextResource.ParseUS_s(GetReaderString(reader, "auto_scale"), 0) == 1;
        buff_info.des = GetReaderString(reader, "des");
        buff_info.hide_countDown = DBTextResource.ParseUS_s(GetReaderString(reader, "hide_countDown"), 0) == 1;
        var max_count = GetReaderString(reader, "max_count");
        if(string.IsNullOrEmpty(max_count))
        {
            buff_info.max_count = 5;
        }
        else
            buff_info.max_count = DBTextResource.ParseI_s(max_count, 5);
        string status = GetReaderString(reader, "status");// buff的特殊状态
        BattleStatusType status_type = Buff.GetBattleState(status);
        if (status_type != BattleStatusType.BATTLE_STATUS_TYPE_INVALID)
        {
            buff_info.battle_effect_type = status_type;
            Bind(buff_info, BuffEffect.BattleStateChangeBegin, BuffEffect.BattleStateChangeEnd, null);
        }

        if (buff_info.shape_shift != 0)
        {
            Bind(buff_info, BuffEffect.ShapeShiftBegin, BuffEffect.ShapeShiftEnd, null);
        }

        // 设置周期更新时间
        buff_info.period_time = Mathf.Infinity;

        buff_info.buff_flags |= (ushort)Buff.BuffFlags.AF_RECOVERY_AFTER_DIE;

        mBuffInfos.Add(buff_info.buff_id, buff_info);

        reader.Close();
        reader.Dispose();

        return buff_info;
    }

    public override void Load()
    {
        IsLoaded = true;
    }

    public override void Unload()
    {
        mBuffInfos.Clear();
    }
    
    void Bind(Buff.BuffInfo info, Buff.BuffInfo.FunctionHandle add_handle, Buff.BuffInfo.FunctionHandle finish_handle, Buff.BuffInfo.FunctionHandle period_handle)
    {
        info.mAddHandle += add_handle;
        info.mFinishedHandle += finish_handle;
        info.mPeriodHandle += period_handle;
    }  
}