
/*----------------------------------------------------------------
// 文件名： DBGuildWareColorFilter.cs
// 文件功能描述： 帮派仓库品质筛选表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuildWareColorFilter : DBSqliteTableResource
    {
        public class DBGuildWareColorFilterItem
        {
            public uint Id;
            public string Desc;
            public uint MinColor;
            public uint MaxColor;
            public bool IsDefault;  //是否是默认选中
            public string CaptionText;  //下拉框中的内容
        }
        public List<DBGuildWareColorFilterItem> mSortInfos = new List<DBGuildWareColorFilterItem>();
        public DBGuildWareColorFilter(string strName, string strPath)
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

            mSortInfos.Clear();

            DBGuildWareColorFilterItem info;

            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBGuildWareColorFilterItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Desc = GetReaderString(reader, "desc");
                        info.MinColor = DBTextResource.ParseUI_s(GetReaderString(reader, "min_color"), 0);
                        info.MaxColor = DBTextResource.ParseUI_s(GetReaderString(reader, "max_color"), 0);
                        info.IsDefault = DBTextResource.ParseUI_s(GetReaderString(reader, "is_default"), 0) == 1;
                        info.CaptionText = GetReaderString(reader, "caption_text");
                        if(info.CaptionText == "")
                        {
                            info.CaptionText = info.Desc;
                        }
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