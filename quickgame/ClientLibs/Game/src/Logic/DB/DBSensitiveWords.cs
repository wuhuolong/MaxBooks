using System;
using UnityEngine;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSensitiveWords
        : DBSqliteTableResource
    {
        public DBSensitiveWords(string strName, string strPath)
        : base(strName, strPath)
        { }

        public override void Unload()
        {
            base.Unload();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                string raw_words = GetReaderString(reader, "text");
                if(string.IsNullOrEmpty(raw_words) == false)
                    SensitiveWordsFilter.Instance.AddSensitiveWord(raw_words);
            }
        }
    }
}
