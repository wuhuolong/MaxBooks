//------------------------------------------------------------------------------
// File ： DBBattleState.cs
// Desc ： 角色特殊状态（buff效果）
// Author : raorui
// Date : 2016.9.20
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;
using xc;

public class DBBattleState : DBSqliteTableResource
{
    public class StateInfo
    {
        public string state;// 角色状态
        public byte value; // 状态的枚举数值
    }
    
    Dictionary<string, StateInfo> mBattleStateMap;
    static DBBattleState mkInstance;
    
    public static DBBattleState GetInstance()
    {
        return mkInstance;
    }
    
    public DBBattleState(string strName, string strPath):
        base(strName, strPath)
    {
        mkInstance = this;
    }
    
    public StateInfo GetBattleStateInfo(string state)
    {
        StateInfo kInfo;
        if (mBattleStateMap.TryGetValue(state, out kInfo))
        {
            return kInfo;
        }
        
        return null;
    }
    
    
    public override void Unload()
    {
        mBattleStateMap.Clear();
    }
    
    protected override void ParseData(SqliteDataReader reader)
    {
        if(reader == null || !reader.HasRows)
        {
            return;
        }
        
        mBattleStateMap = new Dictionary<string, StateInfo>();
        StateInfo kInfo;
        while (reader.Read())
        {
            kInfo = new StateInfo();
            kInfo.state = GetReaderString(reader, "state");
            kInfo.value = DBTextResource.ParseBT(GetReaderString(reader, "value"));
            mBattleStateMap.Add(kInfo.state, kInfo);
        }
    }           
}