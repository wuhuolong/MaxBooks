//------------------------------------------
// File : DBMoney.cs
// Desc: 货币表数据读取的辅助类
// Author: raorui
// Date: 2018.8.29
//------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMoney : DBSqliteTableResource
    {
        static DBMoney mInstance;
        public static DBMoney Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new DBMoney(GlobalConfig.DBFile, "data_money");

                return mInstance;
            }
        }

        public class MoneyInfo
        {
            public bool show_get = false;
        }

        Dictionary<uint, MoneyInfo> mMoneyInfo = new Dictionary<uint, MoneyInfo>();

        public DBMoney(string strName, string strPath) : base(strName, strPath)
        {

        }

        public override void Load() // 不进行预加载
        {

        }

        public MoneyInfo GetMoneyInfo(uint gid)
        {
            MoneyInfo info = null;
            if (mMoneyInfo.TryGetValue(gid, out info))
                return info;

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "gid", gid);
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (table_reader == null)
            {
                return null;
            }

            if (!table_reader.HasRows)
            {
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            info = new MoneyInfo();
            info.show_get = GetReaderString(table_reader, "show_get") == "1";

            mMoneyInfo[gid] = info;
            

            table_reader.Close();
            table_reader.Dispose();

            return info;
        }
    }
}