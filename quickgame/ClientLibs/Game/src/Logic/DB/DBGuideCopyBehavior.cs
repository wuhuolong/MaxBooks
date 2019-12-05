/// <summary>
/// 引导可拷贝组件名字
/// </summary>

using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuideCopyBehavior : DBSqliteTableResource
    {
        public List<string> mData = new List<string>();

        public DBGuideCopyBehavior(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            mData.Clear();

            while (reader.Read())
            {
                var name = GetReaderString(reader, "behavior_name");
                mData.Add(name);
            }
        }

        public bool ContainType(string type_name)
        {
            return mData.Contains(type_name);
        }
    }
}

