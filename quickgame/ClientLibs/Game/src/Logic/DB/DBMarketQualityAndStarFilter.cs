
/*----------------------------------------------------------------
// 文件名： DBMarketQualityAndStarFilter.cs
// 文件功能描述： 市场品质星级筛选表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMarketQualityAndStarFilter : DBSqliteTableResource
    {
        public class DBMarketQualityAndStarFilterItem
        {
            public uint Id;
            public string Name;
            public uint ColorType;
            public uint StarLv;
        }
        public List<DBMarketQualityAndStarFilterItem> mSortInfos = new List<DBMarketQualityAndStarFilterItem>();
        
        public DBMarketQualityAndStarFilter(string strName, string strPath)
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

            DBMarketQualityAndStarFilterItem info;
            
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBMarketQualityAndStarFilterItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.ColorType = DBTextResource.ParseUI_s(GetReaderString(reader, "color_type"), 0);
                        info.StarLv = DBTextResource.ParseUI_s(GetReaderString(reader, "star_lv"), 0);

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


