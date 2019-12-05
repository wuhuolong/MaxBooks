
/*----------------------------------------------------------------
// 文件名： DBMarketStepFilter.cs
// 文件功能描述： 市场阶数筛选表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMarketStepFilter : DBSqliteTableResource
    {
        public class DBMarketStepFilterItem
        {
            public uint Id;
            public string Name;
            public uint Step;
        }
        public List<DBMarketStepFilterItem> mSortInfos = new List<DBMarketStepFilterItem>();

        public DBMarketStepFilter(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mSortInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            //mInfos.Clear();
            mSortInfos.Clear();

            DBMarketStepFilterItem info;

            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBMarketStepFilterItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.Step = DBTextResource.ParseUI_s(GetReaderString(reader, "step"), 0);
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


