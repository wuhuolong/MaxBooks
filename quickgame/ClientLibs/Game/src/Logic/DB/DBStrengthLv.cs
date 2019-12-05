/*----------------------------------------------------------------
// 文件名： DBStrengthLv.cs
// 作者：Kevin
// 文件功能描述： 装备强化等级配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBStrengthLv : DBSqliteTableResource
    {
        public static DBStrengthLv Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBStrengthLv>();
            }
        }

        public class StrengthLvInfo
        {
            public uint Lv;
            public uint Degree;
            public List<KeyValuePair<uint, ulong>> Costs;
            public List<KeyValuePair<uint, ulong>> ShowRedPointGoodsNums;
        }

        private Dictionary<uint, StrengthLvInfo> mStrengthLvInfos = new Dictionary<uint, StrengthLvInfo>();

        public DBStrengthLv(string strName, string strPath) : base(strName,strPath)
        {
            
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mStrengthLvInfos.Clear();
        }

        public StrengthLvInfo GetStrengthLvInfo(uint lv)
        {
            StrengthLvInfo info;
            if (mStrengthLvInfos.TryGetValue(lv, out info))
            {
                return info;
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {1}=\"{2}\"", mTableName, "lv", lv);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mStrengthLvInfos[lv] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mStrengthLvInfos[lv] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new StrengthLvInfo();

            info.Lv = DBTextResource.ParseUI(GetReaderString(reader, "lv"));
            info.Degree = DBTextResource.ParseUI(GetReaderString(reader, "degree"));
            info.Costs = DBTextResource.ParseKeyUlongValuePairList(GetReaderString(reader, "cost"));
            info.ShowRedPointGoodsNums = DBTextResource.ParseKeyUlongValuePairList(GetReaderString(reader, "show_red_point_goods_num"));

            mStrengthLvInfos.Add(info.Lv, info);

            reader.Close();
            reader.Dispose();

            return info;
        }
    }
}
