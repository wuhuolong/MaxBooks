//------------------------------------------
// File : DBEquipBase.cs
// Desc:  装备基础属性表的配置
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
    public class DBEquipBase : DBSqliteTableResource
    {
        private static string TableName = "data_ep_base_attr";

        static DBEquipBase mInstance;
        public static DBEquipBase Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new DBEquipBase(GlobalConfig.DBFile, TableName);

                return mInstance;
            }
        }

        Dictionary<uint, Dictionary<uint, uint>> mBaseAttrInfos = new Dictionary<uint, Dictionary<uint, uint>>();

        public DBEquipBase(string strName, string strPath) : base(strName, strPath)
        {

        }

        public Dictionary<uint, uint> GetAttrInfo(uint gid)
        {
            Dictionary<uint, uint> info = null;
            if (mBaseAttrInfos.TryGetValue(gid, out info))
                return info;

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "gid", gid);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mBaseAttrInfos[gid] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mBaseAttrInfos[gid] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new Dictionary<uint, uint>();
            var attr = GetReaderString(reader, "base_attr");
            attr = attr.Replace(" ", "");
            var matchs = Regex.Matches(attr, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                    info[attrId] = attrValue;
                }
            }

            mBaseAttrInfos[gid] = info;

            reader.Close();
            reader.Dispose();
            return info;
        }
    }
}
