//-------------------------------------------
// File ： CustomDataMgr.cs
// Desc ： 自定义数据管理类 (数据保存在服务器)
// Author : caoxingcai 
// Date : 2018.01.24
//-------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Utils;
using Net;
using xc.protocol;

namespace xc
{
    public enum CustomDataType
    {
        WorldMapLock = 0,               // 世界地图解锁
        TargetSysLock = 1,              // 目标系统大目标解锁
        WorldBossExpEnter = 2,          // 世界BOSS体验副本进入
        IsOpenSysMount = 3,             // 是否开放过坐骑系统
        IsFirstGetElfin = 4,            // 是否首次获得小精灵
        GodEquipPosUnlock = 5,          // 解锁神兵部位提示（破境之道副本结算界面）
    }

    public class CustomDataMgr : xc.Singleton<CustomDataMgr>
    {
        Dictionary<uint, List<int>> m_data = new Dictionary<uint, List<int>>();

        public void RegisterMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_CLIENT_DATA, OnMsgPlayerClientData);
        } 

        public void Reset()
        {
            m_data.Clear();
        }

        void OnMsgPlayerClientData(ushort protocol, byte[] data)
        {
            S2CPlayerClientData msg = S2CPackBase.DeserializePack<S2CPlayerClientData>(data);
            m_data.Clear();

            foreach(var kv in msg.settings)
            {
                m_data.Add(kv.type, kv.vals);
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CUSTOM_DATA_UPDATE, null);
        }

        public void AddCustomData(CustomDataType dataType, List<int> data, bool bPutServer = false)
        {
            uint type = (uint)dataType;
            m_data[type] = data;

            if (bPutServer)
                PutCustomoData(dataType);
        }

        public void AddCustomData(CustomDataType dataType, int value, bool bPutServer = false)
        {
            uint type = (uint)dataType;
            if (!m_data.ContainsKey(type))
            {
                m_data[type] = new List<int>();
            }

            if (m_data[type].Contains(value))
                return;

            m_data[type].Add(value);

            if (bPutServer)
                PutCustomoData(dataType);
        }

        public void RemoveCustomData(CustomDataType dataType, int value, bool bPutServer = false)
        {
            uint type = (uint)dataType;
            if (!m_data.ContainsKey(type))
                return;

            if (m_data[type].Contains(value))
            {
                m_data[type].Remove(value);

                if (bPutServer)
                    PutCustomoData(dataType);
            }
        }

        public List<int> GetCustomData(CustomDataType type)
        {
            List<int> ret = null;
            if (!m_data.TryGetValue((uint)type, out ret))
            {
                ret = new List<int>();
            }

            //WorldMapLock， 出生地图默认已经解锁 
            if(type == CustomDataType.WorldMapLock && 0 == ret.Count)
            {
                uint id = GameConstHelper.GetUint("GAME_DEFAULT_UNLOCK_DUNGEON");
                ret.Add((int)id);
            }

            return ret;
        }

        public bool IsExistCustomData(CustomDataType type, int value)
        {
            List<int> ret = GetCustomData(type);
            if (ret != null && ret.Contains(value))
                return true;
            return false;
        }

        /// <summary>
        /// 上传客户端自定义数据至服务器 
        /// </summary>
        public void PutCustomoData(CustomDataType dataType)
        {
            uint type = (uint)dataType;
            C2SPlayerClientData pack = new C2SPlayerClientData();

            foreach (var kv in m_data)
            {
                if (kv.Key.Equals(type))
                {
                    var pkg = new PkgPlayerClientData();
                    pkg.type = kv.Key;
                    pkg.vals.Clear();

                    foreach (var e in kv.Value)
                        pkg.vals.Add(e);

                    pack.setting = pkg;
                    break;
                }
            }

            if (null == pack.setting)
                return;

            NetClient.GetBaseClient().SendData<C2SPlayerClientData>(NetMsg.MSG_PLAYER_CLIENT_DATA, pack);
        }
    }
}
