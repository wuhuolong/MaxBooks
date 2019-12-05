
/*----------------------------------------------------------------
// 文件名： DBGuildWareStepFilter.cs
// 文件功能描述： 帮派仓库阶数筛选表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuildWareStepFilter : DBSqliteTableResource
    {
        public class DBGuildWareStepFilterItem
        {
            public uint Id;
            public string Desc;
            public uint MinStep;
            public uint MaxStep;
            public bool IsDefault;  //是否是默认选中
            public string CaptionText;
        }
        public List<DBGuildWareStepFilterItem> mSortInfos = new List<DBGuildWareStepFilterItem>();

        public DBGuildWareStepFilter(string strName, string strPath)
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

            DBGuildWareStepFilterItem info;

            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBGuildWareStepFilterItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Desc = GetReaderString(reader, "desc");
                        info.MinStep = DBTextResource.ParseUI_s(GetReaderString(reader, "min_step"), 0);
                        info.MaxStep = DBTextResource.ParseUI_s(GetReaderString(reader, "max_step"), 0);
                        info.IsDefault = DBTextResource.ParseUI_s(GetReaderString(reader, "is_default"), 0) == 1;
                        info.CaptionText = GetReaderString(reader, "caption_text");
                        if (info.CaptionText == "")
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