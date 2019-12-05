
/*----------------------------------------------------------------
// 文件名： DBBaptizeCost.cs
// 文件功能描述： 洗练消耗配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBBaptizeCost : DBSqliteTableResource
    {
        public class DBBaptizeCostInfo
        {
            public uint Num;                                    // 锁定槽数
            public uint CostDiamond;                            // 消耗钻石
            public List<KeyValuePair<uint, uint>> CostGoods;    // 消耗道具
        }
        
        public Dictionary<uint, DBBaptizeCostInfo> mInfos = new Dictionary<uint, DBBaptizeCostInfo>();

        public DBBaptizeCost(string strName, string strPath)
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
        /// 获取一个洗练属性标准值配置信息
        /// </summary>
        /// <param name="posId"></param>
        /// <returns></returns>
        public DBBaptizeCostInfo GetOneInfo(uint id)
        {
            DBBaptizeCostInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "num", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new DBBaptizeCostInfo();

            info.Num = DBTextResource.ParseUI_s(GetReaderString(reader, "num"), 0);
            info.CostDiamond = DBTextResource.ParseUI_s(GetReaderString(reader, "cost_diamond"), 0);

            string raw = GetReaderString(reader, "cost_goods");
            info.CostGoods = new List<KeyValuePair<uint, uint>>();
            info.CostGoods.Clear();
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint goodsId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint num = DBTextResource.ParseUI(_match.Groups[2].Value);
                    KeyValuePair<uint, uint> goods = new KeyValuePair<uint, uint>(goodsId, num);

                    info.CostGoods.Add(goods);
                }
            }

            mInfos[info.Num] = info;

            reader.Close();
            reader.Dispose();
            return info;
        }
    }
}
