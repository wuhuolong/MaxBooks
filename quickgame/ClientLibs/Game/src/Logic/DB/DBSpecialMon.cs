//------------------------------------
// File: DBSpecialMon.cs
// Desc: 特殊刷怪表,标识了在场景的某一位置刷出了一些特殊的怪物（世界boss等）
// raorui 重构
// 2017.11.15
//------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    [wxb.Hotfix]
    public class DBSpecialMon : DBSqliteTableResource
    {
        public class DBSpecialMonItem
        {
            public uint Id; //对应特殊怪物表中的id
            public uint ActorId;    //角色ID
            public string SpecialType;    //特殊怪类型
            public uint DungeonId;  //副本ID
            public string Tag;//tag
            public string TagGroup;//tagGroup
            public uint SysId;  // 关联的系统id
        }

        /// <summary>
        /// 存储id与特殊怪物信息的对应关系
        /// </summary>
        private Dictionary<uint, DBSpecialMonItem> m_AllData = new Dictionary<uint, DBSpecialMonItem>();

        /// <summary>
        /// 存储了某一副本内包含的特殊怪物信息
        /// </summary>
        public Dictionary<uint, List<DBSpecialMonItem> > m_DungeonData = new Dictionary<uint, List<DBSpecialMonItem>>();

        public DBSpecialMon(string strName, string strPath) : base(strName, strPath)
        {

        }

        /// <summary>
        /// 通过id来获取特殊怪物的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DBSpecialMonItem GetData(uint id)
        {
            DBSpecialMonItem ad = null;
            m_AllData.TryGetValue(id, out ad);
            return ad;
        }

        public uint GetSpecialMonLevel(uint id)
        {
            DBSpecialMonItem data = GetData(id);
            if (data != null)
            {
                return ActorHelper.GetActorLevel(data.ActorId);
            }

            return 0;
        }

        /// <summary>
        /// 获取副本中的所有特殊怪物
        /// </summary>
        /// <param name="dungeon_id"></param>
        /// <returns></returns>
        public List<DBSpecialMonItem> GetDungeonData(uint dungeon_id)
        {
            List<DBSpecialMonItem> ad = null;
            m_DungeonData.TryGetValue(dungeon_id, out ad);
            return ad;
        }

        /// <summary>
        /// 获取副本中指定类型的所有怪物
        /// </summary>
        /// <param name="dungeon_id"></param>
        /// <param name="specialType"></param>
        /// <returns></returns>
        public List<DBSpecialMonItem> GetDungeonData(uint dungeon_id, string special_type)
        {
            List<DBSpecialMonItem> ad = null;
            m_DungeonData.TryGetValue(dungeon_id, out ad);

            List<DBSpecialMonItem> ret = new List<DBSpecialMonItem>();
            ret.Clear();
            if (ad != null)
            {
                foreach (DBSpecialMonItem item in ad)
                {
                    if (item.SpecialType == special_type)
                    {
                        ret.Add(item);
                    }
                }
            }

            return ret;
        }

        public DBSpecialMonItem GetNearestSpecialMonItem(uint dungeon_id, string special_type, float range)
        {
            List<DBSpecialMonItem> ad = null;
            m_DungeonData.TryGetValue(dungeon_id, out ad);

            DBSpecialMonItem nearestMonItem = null;
            if (ad != null)
            {
                Actor localPlayer = Game.Instance.GetLocalPlayer();
                float sqrRange = range * range;
                if (localPlayer != null)
                {
                    Vector3 localPlayerPos = localPlayer.Trans.position;
                    float minDistance = float.MaxValue;
                    foreach (DBSpecialMonItem item in ad)
                    {
                        if (item != null && item.SpecialType == special_type)
                        {
                            Vector3 pos = xc.Dungeon.LevelObjectHelper.GetTagPosition(item.TagGroup);
                            float distance = (localPlayerPos - pos).sqrMagnitude;
                            if (distance < sqrRange && distance < minDistance)
                            {
                                minDistance = distance;
                                nearestMonItem = item;
                            }
                        }
                    }
                }
            }

            return nearestMonItem;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBSpecialMonItem ad = new DBSpecialMonItem();
                ad.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
                ad.DungeonId = DBTextResource.ParseUI(GetReaderString(reader, "dungeon"));
                ad.ActorId = DBTextResource.ParseUI(GetReaderString(reader, "actor"));
                ad.SpecialType = GetReaderString(reader, "type");
                string pos = GetReaderString(reader, "pos");
                pos = pos.Replace(" ", "");
                pos = pos.Substring(1, pos.Length - 2);
                string[] _tmp_split = pos.Split(',');
                if (_tmp_split.Length >= 2)
                {
                    ad.Tag = _tmp_split[0];
                    ad.TagGroup = _tmp_split[1];
                }
                ad.SysId = DBTextResource.ParseUI(GetReaderString(reader, "sys_id"));

                m_AllData.Add(ad.Id, ad);
                if (m_DungeonData.ContainsKey(ad.DungeonId) == false)
                    m_DungeonData.Add(ad.DungeonId, new List<DBSpecialMonItem>());
                m_DungeonData[ad.DungeonId].Add(ad);
            }
        }

        public override void Unload()
        {
            m_AllData.Clear();
            m_DungeonData.Clear();
        }
    }
}


