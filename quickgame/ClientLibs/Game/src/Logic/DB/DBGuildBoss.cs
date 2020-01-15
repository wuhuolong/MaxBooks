
/*----------------------------------------------------------------
// 文件名： DBGuildBoss.cs
// 文件功能描述： 帮派BOSS
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuildBoss : DBSqliteTableResource
    {
        public class DBGuildBossRewardItem
        {
            public uint GoodsId;
            public string RewardType;
            public string RewardDesc1;
            public string RewardDesc2;
        }
        public class DBGuildBossItem
        {
            public uint BossType;
            public uint Star;
            public string TypeName;
            public string Name;
            public uint DungeonId;
            public uint OpenCond;   //开启的世界等级
            public uint OpenCost;   //开启需要的帮派资金
            public uint BossRewardId;//帮派boss奖励显示data_guild_boss_gift 表的id
            //public List<DBGuildBossRewardItem> RewardItemArray;
        }
        
        public class DBGuildBossStatisticItem
        {
            public uint BossType;
            public uint MaxStar;    //最大的星级
            public string TypeName; //名字
            public List<DBGuildBossItem> BossItemSortArray;

            /// <summary>
            /// 返回最大可以开放的等级
            /// </summary>
            /// <param name="world_level"></param>
            /// <returns></returns>
            public uint CanOpenMaxStar(uint world_level)
            {
                if (BossItemSortArray == null)
                    return 0;
                for(int index = BossItemSortArray.Count - 1; index >= 0; --index)
                {
                    if(BossItemSortArray[index].OpenCond <= world_level)
                    {
                        return BossItemSortArray[index].Star;
                    }
                }
                return 0;
            }
        }
        Dictionary<uint, Dictionary<uint, DBGuildBossItem>> mInfos = new Dictionary<uint, Dictionary<uint, DBGuildBossItem>>();
        public List<DBGuildBossStatisticItem> mSortStatisticArray = new List<DBGuildBossStatisticItem>();
        public DBGuildBoss(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mSortStatisticArray.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mSortStatisticArray.Clear();
            DBGuildBossItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBGuildBossItem();
                        info.BossType = DBTextResource.ParseUI_s(GetReaderString(reader, "type"), 0); //类型ID
                        info.Star = DBTextResource.ParseUI_s(GetReaderString(reader, "star"), 0); //星级
                        info.TypeName = GetReaderString(reader, "type_name"); //类型名字
                        info.Name = GetReaderString(reader, "name"); //名字
                        info.DungeonId = DBTextResource.ParseUI_s(GetReaderString(reader, "dgn_id"), 0); //副本ID
                        info.OpenCond = DBTextResource.ParseUI_s(GetReaderString(reader, "open_cond"), 0); //开启条件（世界等级）
                        info.OpenCost = DBTextResource.ParseUI_s(GetReaderString(reader, "open_cost"), 0); //开启需要的帮派资金
                        info.BossRewardId = DBTextResource.ParseUI_s(GetReaderString(reader, "reward_id"), 0); //帮派boss奖励显示data_guild_boss_gift 表的id
                        //info.RewardItemArray = new List<DBGuildBossRewardItem>();
                        //for(int index = 1; index <= 5; ++index)
                        //{
                        //    string tmp_reward_col_name = string.Format("reward_{0}", index);
                        //    string tmp_reward_str = GetReaderString(reader, tmp_reward_col_name);
                        //    if(tmp_reward_str != null && tmp_reward_str.Length > 0)
                        //    {
                        //        List<string> parse_array = DBTextResource.ParseArrayString(tmp_reward_str, ",", false);
                        //        if(parse_array != null && parse_array.Count >= 4)
                        //        {
                        //            uint goods_id = 0;
                        //            if(uint.TryParse(parse_array[0], out goods_id))
                        //            {
                        //                DBGuildBossRewardItem tmp_item = new DBGuildBossRewardItem();
                        //                tmp_item.GoodsId = goods_id;
                        //                tmp_item.RewardType = parse_array[1];
                        //                tmp_item.RewardDesc1 = parse_array[2];
                        //                tmp_item.RewardDesc2 = parse_array[3];
                        //                info.RewardItemArray.Add(tmp_item);
                        //            }
                        //        }
                        //    }
                        //}

                        if (mInfos.ContainsKey(info.BossType) == false)
                            mInfos.Add(info.BossType, new Dictionary<uint, DBGuildBossItem>());
                        if (mInfos[info.BossType].ContainsKey(info.Star) == false)
                        {
                            mInfos[info.BossType].Add(info.Star, info);
                        }
                        else
                        {
                            GameDebug.LogError(string.Format("has repeat id {0}-{1}", info.BossType, info.Star));
                        }

                        DBGuildBossStatisticItem find_item = mSortStatisticArray.Find((a) =>
                        {
                            return a.BossType == info.BossType;
                        });
                        if (find_item == null)
                        {
                            find_item = new DBGuildBossStatisticItem();
                            find_item.BossType = info.BossType;
                            find_item.MaxStar = info.Star;
                            find_item.TypeName = info.TypeName;
                            find_item.BossItemSortArray = new List<DBGuildBossItem>();
                            find_item.BossItemSortArray.Add(info);
                            mSortStatisticArray.Add(find_item);
                        }
                        else
                        {
                            if (find_item.MaxStar < info.Star)
                                find_item.MaxStar = info.Star;
                            find_item.BossItemSortArray.Add(info);
                        }
                    }
                }
            }

            mSortStatisticArray.Sort((a, b) =>
            {
                if (a.BossType < b.BossType)
                    return -1;
                else if (a.BossType > b.BossType)
                    return 1;
                return 0;
            });
            for (int index = 0; index < mSortStatisticArray.Count; ++index)
            {
                mSortStatisticArray[index].BossItemSortArray.Sort((a, b) =>
                {
                    if (a.Star < b.Star)
                        return -1;
                    else if (a.Star > b.Star)
                        return 1;
                    return 0;
                });
            }
        }

        public DBGuildBossItem GetOneItem(uint boss_type, uint boss_level)
        {
            Dictionary<uint, DBGuildBossItem> info_array;
            if (mInfos.TryGetValue(boss_type, out info_array) == false)
            {
                return null;
            }
            DBGuildBossItem info;
            if (info_array.TryGetValue(boss_level, out info) == false)
            {
                return null;
            }
            return info;
        }

        public DBGuildBossStatisticItem GetOneStatisticItem(uint boss_type)
        {
            DBGuildBossStatisticItem find_item = mSortStatisticArray.Find((a) =>
            {
                return a.BossType == boss_type;
            });
            return find_item;
        }
    }
}
