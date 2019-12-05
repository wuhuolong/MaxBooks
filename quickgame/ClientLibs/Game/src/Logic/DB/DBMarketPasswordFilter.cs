
/*----------------------------------------------------------------
// 文件名： DBMarketPasswordFilter.cs
// 文件功能描述： 市场品质筛选表
//----------------------------------------------------------------*/
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMarketPasswordFilter : DBSqliteTableResource
    {
        public class DBMarketPasswordFilterItem
        {
            public uint Id;
            public string Name;
            public int Password;
        }
        public List<DBMarketPasswordFilterItem> mSortInfos = new List<DBMarketPasswordFilterItem>();

        public DBMarketPasswordFilter(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            //mInfos.Clear();
            mSortInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            //mInfos.Clear();
            mSortInfos.Clear();

            DBMarketPasswordFilterItem info;

            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBMarketPasswordFilterItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.Password = DBTextResource.ParseI_s(GetReaderString(reader, "password"), 0);

                        mSortInfos.Add(info);
                    }
                }
            }

            mSortInfos.Sort((a, b) =>
            {
                if (a.Id < b.Id)
                    return -1;
                else if (a.Id > b.Id)
                    return 1;
                return 0;
            });
        }

    }
}


