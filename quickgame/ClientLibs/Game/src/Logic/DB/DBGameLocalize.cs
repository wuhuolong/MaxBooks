/*----------------------------------------------------------------
// File： DBGameLocalize.cs
// Author: Raorui
// Desc： 界面中语言本地化表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGameLocalize : DBSqliteTableResource
    {
        private Dictionary<string, string> mTextData = new Dictionary<string, string>();
        
        public DBGameLocalize(string strName, string strPath)
            : base(strName, strPath)
        {
        }
        
        public static string GetText(string textId)
        {
            return DBManager.Instance.GetDB<DBGameLocalize>().Text(textId);
        }
        
        public string Text(string textId)
        {
            string value;
            mTextData.TryGetValue(textId, out value);
            return value;
        }
        
        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            mTextData.Clear();
            while (reader.Read())
            {
                mTextData.Add(GetReaderString(reader, "id"), GetReaderString(reader,"text").Trim('\"'));
            }
        }
        
    }
}
