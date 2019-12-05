
/*----------------------------------------------------------------
// 文件名： DBMarketQualityFilter.cs
// 文件功能描述： 市场品质筛选表
//----------------------------------------------------------------*/
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMarketQualityFilter : DBSqliteTableResource
    {
        public class DBMarketQualityFilterItem
        {
            public uint Id;
            public string Name;
            public uint ColorType;
        }
        public List<DBMarketQualityFilterItem> mSortInfos = new List<DBMarketQualityFilterItem>();
        
        public DBMarketQualityFilter(string strName, string strPath)
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

            DBMarketQualityFilterItem info;
            
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBMarketQualityFilterItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.ColorType = DBTextResource.ParseUI_s(GetReaderString(reader, "color_type"), 0);

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


