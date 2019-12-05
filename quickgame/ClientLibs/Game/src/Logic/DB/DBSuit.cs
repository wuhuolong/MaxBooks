
/*----------------------------------------------------------------
// 文件名： DBSuit.cs
// 文件功能描述： 套装信息配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSuit : DBSqliteTableResource
    {
        public class DBSuitInfo
        {
            /// <summary>
            /// 锻造要求信息
            /// </summary>
            public class NeedInfo
            {
                public uint ColorNeed;      // 锻造颜色要求
                public uint StarNeed;       // 锻造星级要求
            }

            public uint Id;             // 套装id
            public uint Lv;             // 等级
            public string Name;         // 名字
            public string PreviewName;  // 预览名字
            public uint SuitId;         // 客户端展示套装外观id
            public uint ColorNeed;      // 锻造颜色要求
            public uint StarNeed;       // 锻造星级要求
            public List<NeedInfo> NeedInfos;    // 锻造要求
            public Dictionary<uint, List<KeyValuePair<uint, uint>>> CostGoodsIdList;    // 锻造消耗
            public Dictionary<uint, List<GoodsItem>> CostGoodsList; // 锻造消耗GoodsItem

            /// <summary>
            /// 根据部位返回锻造消耗
            /// </summary>
            /// <param name="pos"></param>
            /// <returns></returns>
            public List<GoodsItem> GetCostGoods(uint pos)
            {
                if (CostGoodsList.ContainsKey(pos) == true)
                {
                    return CostGoodsList[pos];
                }
                else if(CostGoodsIdList.ContainsKey(pos) == true)
                {
                    List<KeyValuePair<uint, uint>> costGoodsIds = CostGoodsIdList[pos];
                    List<GoodsItem> goodsList = new List<GoodsItem>();
                    goodsList.Clear();
                    foreach (KeyValuePair<uint, uint> costGoodsId in costGoodsIds)
                    {
                        uint goodsId = costGoodsId.Key;
                        uint num = costGoodsId.Value;
                        GoodsItem goods = new GoodsItem(goodsId);
                        goods.num = num;
                        goodsList.Add(goods);
                    }

                    CostGoodsList.Add(pos, goodsList);
                    return goodsList;
                }

                return null;
            }
        }
        
        public Dictionary<string, DBSuitInfo> mInfos = new Dictionary<string, DBSuitInfo>();

        public DBSuit(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
        }

        /// <summary>
        /// 获取一个套装信息
        /// </summary>
        /// <returns></returns>
        public DBSuitInfo GetOneInfo(uint id, uint lv)
        {
            //foreach (DBSuitInfo info in mInfos)
            //{
            //    if (info.Id == id && info.Lv == lv)
            //    {
            //        return info;
            //    }
            //}
            //return null;

            string csvId = id + "_" + lv;
            DBSuitInfo info = null;
            if (mInfos.TryGetValue(csvId, out info))
            {
                return info;
            }

            string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "csv_id", csvId);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, queryStr);
            if (reader == null)
            {
                mInfos.Add(csvId, null);
                return null;
            }

            if (!reader.HasRows)
            {
                mInfos.Add(csvId, null);
                reader.Close();
                reader.Dispose();
                return null;
            }

            if (!reader.Read())
            {
                mInfos.Add(csvId, null);
                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new DBSuitInfo();

            info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            info.Lv = DBTextResource.ParseUI_s(GetReaderString(reader, "lv"), 0);
            info.Name = GetReaderString(reader, "name");
            info.PreviewName = GetReaderString(reader, "preview_name");
            info.SuitId = DBTextResource.ParseUI_s(GetReaderString(reader, "suit_id"), 0);
            info.ColorNeed = DBTextResource.ParseUI_s(GetReaderString(reader, "color_need"), 0);
            info.StarNeed = DBTextResource.ParseUI_s(GetReaderString(reader, "star_need"), 0);

            info.NeedInfos = new List<DBSuitInfo.NeedInfo>();
            info.NeedInfos.Clear();
            List<List<uint>> needConfigs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "need"));
            foreach (List<uint> needConfig in needConfigs)
            {
                if (needConfig.Count >= 2)
                {
                    DBSuitInfo.NeedInfo needInfo = new DBSuitInfo.NeedInfo();
                    needInfo.ColorNeed = needConfig[0];
                    needInfo.StarNeed = needConfig[1];

                    info.NeedInfos.Add(needInfo);
                }
            }

            info.CostGoodsIdList = new Dictionary<uint, List<KeyValuePair<uint, uint>>>();
            info.CostGoodsIdList.Clear();
            info.CostGoodsList = new Dictionary<uint, List<GoodsItem>>();
            info.CostGoodsList.Clear();
            // 锻造消耗的部位配置从3到10
            for (uint i = 3; i <= 10; ++i)
            {
                List<KeyValuePair<uint, uint>> costGoodsIds = new List<KeyValuePair<uint, uint>>();
                costGoodsIds.Clear();
                string raw = GetReaderString(reader, "pos_" + i + "_cost");
                raw = raw.Replace(" ", "");
                var matchs = TextHelper.ParseBraceContent(raw, true);
                foreach (var _match in matchs)
                {
                    uint goodsId = DBTextResource.ParseUI(_match[0]);
                    uint num = DBTextResource.ParseUI(_match[1]);
                    KeyValuePair<uint, uint> goodsIdPair = new KeyValuePair<uint, uint>(goodsId, num);
                    costGoodsIds.Add(goodsIdPair);
                }
                SGameEngine.Pool<List<string>>.List.Free(matchs);

                info.CostGoodsIdList.Add(i, costGoodsIds);
            }

#if UNITY_EDITOR
            if (mInfos.ContainsKey(csvId))
            {
                GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, csvId));

                reader.Close();
                reader.Dispose();
                return info;
            }
#endif
            mInfos.Add(csvId, info);

            reader.Close();
            reader.Dispose();

            return info;
        }

        /// <summary>
        /// 是否满足品质和星级条件
        /// </summary>
        /// <param name="color"></param>
        /// <param name="star"></param>
        /// <param name="needInfos"></param>
        /// <returns></returns>
        public static bool MeetColorAndStarCondition(uint color, uint star, List<DBSuit.DBSuitInfo.NeedInfo> needInfos)
        {
            if (needInfos == null || needInfos.Count == 0)
            {
                return true;
            }

            bool meetColorAndStar = false;
            foreach (DBSuit.DBSuitInfo.NeedInfo needInfo in needInfos)
            {
                if (color >= needInfo.ColorNeed && star >= needInfo.StarNeed)
                {
                    meetColorAndStar = true;
                    break;
                }
            }
            return meetColorAndStar;
        }
    }
}
