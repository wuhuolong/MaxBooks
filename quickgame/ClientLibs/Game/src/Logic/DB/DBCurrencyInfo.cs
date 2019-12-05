
/*----------------------------------------------------------------
// 文件名： DBCurrencyInfo.cs
// 文件功能描述： 宠物进阶表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBCurrencyInfo : DBSqliteTableResource
    {

        public class DBCurrencyInfoItem
        {
            public int Id;
            public string CurrencyIcon;
        }

        public Dictionary<int, DBCurrencyInfoItem> mInfos = new Dictionary<int, DBCurrencyInfoItem>();
        public DBCurrencyInfo(string strName, string strPath)
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


            DBCurrencyInfoItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBCurrencyInfoItem();

                        info.Id = DBTextResource.ParseI_s(GetReaderString(reader, "id"), 0);
                        info.CurrencyIcon = GetReaderString(reader, "currency_icon");
                        mInfos[info.Id] = info;
                    }
                }
            }
        }

        public DBCurrencyInfoItem GetOneInfo(int money_type)
        {
            DBCurrencyInfoItem info;
            if (mInfos.TryGetValue(money_type, out info))
            {
                return info;
            }
            return null;
        }
    }
}

