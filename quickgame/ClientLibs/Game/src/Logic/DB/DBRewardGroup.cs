
/*----------------------------------------------------------------
// 文件名： DBRewardGroup.cs
// 文件功能描述： 奖励组
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBRewardGroup : DBSqliteTableResource
    {
        public class DBRewardGroupInfo
        {
            public uint Id;                    // id
            public uint RewardId;       //消耗的物品ID
            private bool m_isInitRewardType = false;
            private bool m_isExpReward = false;
            private bool m_isCoinReward = false;
            public long ExpOrCoinRewardNum = 0;  //经验值或者货币值
            public bool IsLvEffect = false; //是否受等级影响
            public bool IsExpReward
            {
                get
                {
                    InitRewardType();
                    return m_isExpReward;
                }
            }
            public bool IsCoinReward
            {
                get
                {
                    InitRewardType();
                    return m_isCoinReward;
                }
            }

            void InitRewardType()
            {
                if (m_isInitRewardType == true)
                    return;

                m_isInitRewardType = true;
                DBReward db_reward = DBManager.Instance.GetDB<DBReward>();
                List<DBReward.RewardInfo> info_array = db_reward.GetRewardItemList(RewardId);
                if (info_array != null)
                {
                    for (int index = 0; index < info_array.Count; ++index)
                    {
                        uint goods_id = info_array[index].mGID;
                        if (goods_id == GameConst.GOODS_ID_EXP)//经验
                        {
                            m_isExpReward = true;
                        }
                        else if (goods_id == GameConst.MONEY_COIN_BIND)
                        {
                            m_isCoinReward = true;
                        }
                        if (m_isExpReward || m_isCoinReward)
                        {
                            ExpOrCoinRewardNum = info_array[index].mNum;
                            if (info_array[index].mEffectByLevel == 1)
                                IsLvEffect = true;
                            else
                                IsLvEffect = false;
                            break;
                        }
                    }
                }
            }

            public long GetExpOrCoinNum(uint player_lv)
            {
                if (m_isExpReward == false && m_isCoinReward == false)
                    return 0;
                if (IsLvEffect == false)
                    return ExpOrCoinRewardNum;
                DBLvEfficiency db_lv_eff = DBManager.Instance.GetDB<DBLvEfficiency>();
                DBLvEfficiency.DBLvEfficiencyInfo lv_info = db_lv_eff.GetOneDBLvEfficiencyInfo(player_lv);
                if (lv_info != null)
                {
                    if(m_isExpReward)
                        return (long)System.Math.Ceiling(ExpOrCoinRewardNum * lv_info.Exp);
                    else if(m_isCoinReward)
                        return (long)System.Math.Ceiling(ExpOrCoinRewardNum * lv_info.Coin);
                }
                return 0;
            }
        }
        Dictionary<uint, DBRewardGroupInfo> mInfos = new Dictionary<uint, DBRewardGroupInfo>();

        public DBRewardGroup(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();

        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            //DBRewardGroupInfo info;
            //if (reader != null)
            //{
            //    if (reader.HasRows == true)
            //    {
            //        while (reader.Read())
            //        {
            //            info = new DBRewardGroupInfo();

            //            info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            //            if(info.Id > 0)
            //            {
            //                info.RewardId = GetReaderUint(reader, "reward_id");
            //                if(mInfos.ContainsKey(info.Id) == false)
            //                    mInfos.Add(info.Id, info);
            //            }
            //        }
            //    }
            //}
            
        }

        public DBRewardGroupInfo GetOneDBRewardGroupInfo(uint id)
        {
            DBRewardGroupInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            
            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (table_reader == null)
            {
                mInfos[id] = null;
                return null;
            }

            if (!table_reader.HasRows)
            {
                mInfos[id] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                mInfos[id] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            info = new DBRewardGroupInfo();
            info.Id = DBTextResource.ParseUI_s(GetReaderString(table_reader, "id"), 0);
            if (info.Id > 0)
            {
                info.RewardId = GetReaderUint(table_reader, "reward_id");
                if (mInfos.ContainsKey(info.Id) == false)
                {
                    mInfos.Add(info.Id, info);

                    table_reader.Close();
                    table_reader.Dispose();

                    return info;
                }
            }

            table_reader.Close();
            table_reader.Dispose();

            return null;
        }
    }
}
