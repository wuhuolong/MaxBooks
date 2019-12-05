//------------------------------------------
// File : DBSoulLv.cs
// Desc:  武魂等级表
// Author: raorui
// Date: 2019.2.22
//------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSoulLv : DBSqliteTableResource
    {
        private static string TableName = "data_soul_lv";

        static DBSoulLv mInstance;
        public static DBSoulLv Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new DBSoulLv(GlobalConfig.DBFile, TableName);

                return mInstance;
            }
        }

        public class SoulLvInfo
        {
            public uint cream; // 升级需要精髓
            public Dictionary<uint, uint> attr = new Dictionary<uint, uint>(); // 属性
        }

        Dictionary<string, SoulLvInfo> mInfos = new Dictionary<string, SoulLvInfo>();

        public DBSoulLv(string strName, string strPath) : base(strName, strPath)
        {

        }

        public SoulLvInfo GetData(string csvId)
        {
            SoulLvInfo info = null;
            if (mInfos.TryGetValue(csvId, out info))
                return info;

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "csv_id", csvId);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[csvId] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[csvId] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new SoulLvInfo();
            info.cream = DBTextResource.ParseUI(GetReaderString(reader, "cream"));
            var attr = GetReaderString(reader, "attr");
            attr = attr.Replace(" ", "");
            var matchs = Regex.Matches(attr, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                    info.attr[attrId] = attrValue;
                }
            }

            mInfos[csvId] = info;

            reader.Close();
            reader.Dispose();
            return info;
        }
    }
}
