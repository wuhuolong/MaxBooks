/*----------------------------------------------------------------
// 文件名： DBMarketFilter.cs
// 文件功能描述： 市场筛选总表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMarketFilter : DBSqliteTableResource
    {
        public class DBMarketFilterItem
        {
            //public uint Id;
            public uint Key1;
            public uint Key2;
            public string Name;
            public uint SortId;
            public bool IsShowQualityAndStar;
            public bool IsShowQuality;
            public bool IsShowStep;
            public bool IsShowPassword;
            public bool IsShowScore;
            public uint SysId;
        }
        public class OneDBMarketFilter
        {
            public uint Key1;
            public uint SortId = 0;
            public DBMarketFilterItem Key2_zeroItem; //key2为0的数据
            public List<DBMarketFilterItem> OneDBMarketFilterArray;
        }
        public List<OneDBMarketFilter> mSortInfos = new List<OneDBMarketFilter>();
        private Dictionary<uint, DBMarketFilterItem> mInfos = new Dictionary<uint, DBMarketFilterItem>();   //所有的宠物表的排序后的列表
        public DBMarketFilter(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mSortInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mSortInfos.Clear();

            DBMarketFilterItem info;
            Dictionary<uint, OneDBMarketFilter> tmp_sortMap = new Dictionary<uint, OneDBMarketFilter>();
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBMarketFilterItem();

                        info.Key1 = DBTextResource.ParseUI_s(GetReaderString(reader, "key1"), 0);
                        info.Key2 = DBTextResource.ParseUI_s(GetReaderString(reader, "key2"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.SortId = DBTextResource.ParseUI_s(GetReaderString(reader, "sort_id"), 0);
                        info.IsShowQualityAndStar = DBTextResource.ParseUI_s(GetReaderString(reader, "is_show_quality_star"), 0) == 1;
                        info.IsShowQuality = DBTextResource.ParseUI_s(GetReaderString(reader, "is_show_quality"), 0) == 1;
                        info.IsShowStep = DBTextResource.ParseUI_s(GetReaderString(reader, "is_show_step"), 0) == 1;
                        info.IsShowPassword = DBTextResource.ParseUI_s(GetReaderString(reader, "is_show_password"), 0) == 1;
                        info.IsShowScore = DBTextResource.ParseUI_s(GetReaderString(reader, "is_show_score"), 0) == 1;
                        info.SysId = DBTextResource.ParseUI_s(GetReaderString(reader, "sys_id"), 0);
                        if (tmp_sortMap.ContainsKey(info.Key1) == false)
                        {
                            OneDBMarketFilter one_db_filter = new OneDBMarketFilter();
                            one_db_filter.Key1 = info.Key1;
                            one_db_filter.SortId = 0;
                            one_db_filter.Key2_zeroItem = null;
                            one_db_filter.OneDBMarketFilterArray = new List<DBMarketFilterItem>();
                            tmp_sortMap[one_db_filter.Key1] = one_db_filter;
                        }
                        if (info.Key2 == 0)
                        {
                            tmp_sortMap[info.Key1].Key2_zeroItem = info;
                            tmp_sortMap[info.Key1].SortId = info.SortId;
                        }
                        tmp_sortMap[info.Key1].OneDBMarketFilterArray.Add(info);
                        uint info_key = GetKey(info.Key1, info.Key2);
                        mInfos[info_key] = info;
                    }
                }
            }
            foreach (var item in tmp_sortMap)
                mSortInfos.Add(item.Value);
            mSortInfos.Sort((a, b) =>
            {
                if (a.SortId < b.SortId)
                    return -1;
                else if (a.SortId > b.SortId)
                    return 1;
                return 0;
            });
            for (int index = 0; index < mSortInfos.Count; ++index)
            {
                OneDBMarketFilter one_filter = mSortInfos[index];
                one_filter.OneDBMarketFilterArray.Sort((a, b) =>
                {
                    if (a.Key2 < b.Key2)
                        return -1;
                    else if (a.Key2 > b.Key2)
                        return 1;
                    return 0;
                });

                if(one_filter.Key2_zeroItem != null)
                {
                    for(int sort_index = 0; sort_index < one_filter.OneDBMarketFilterArray.Count; ++sort_index)
                    {
                        if (one_filter.OneDBMarketFilterArray[sort_index].Key2 != 0)
                        {
                            one_filter.OneDBMarketFilterArray[sort_index].IsShowQuality = one_filter.Key2_zeroItem.IsShowQuality;
                            one_filter.OneDBMarketFilterArray[sort_index].IsShowQualityAndStar = one_filter.Key2_zeroItem.IsShowQualityAndStar;
                            one_filter.OneDBMarketFilterArray[sort_index].IsShowScore = one_filter.Key2_zeroItem.IsShowScore;
                            one_filter.OneDBMarketFilterArray[sort_index].IsShowStep = one_filter.Key2_zeroItem.IsShowStep;
                            one_filter.OneDBMarketFilterArray[sort_index].IsShowPassword = one_filter.Key2_zeroItem.IsShowPassword;
                        }
                    }
                }
            }
        }

        public uint GetKey(uint key1, uint key2)
        {
            return key1 * 1000 + key2;
        }
        public DBMarketFilterItem GetOneInfo(uint key1, uint key2)
        {
            uint info_key = GetKey(key1, key2);
            DBMarketFilterItem info;
            if (mInfos.TryGetValue(info_key, out info))
            {
                return info;
            }
            return null;
        }
    }
}