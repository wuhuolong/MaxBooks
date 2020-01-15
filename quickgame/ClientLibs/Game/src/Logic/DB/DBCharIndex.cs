//----------------------------------------------------------------
// File： DBCharIndex.cs
// Desc: 描述某一表格的某一列是中文字符的配置表
// Author: raorui
// Date: 2018.12.4
//----------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBCharIndex : DBSqliteTableResource
    {
        //缓存数据
        Dictionary<string, List<string>> mCharIndexMap = new Dictionary<string, List<string>>();

        static DBCharIndex mInstance;
        public static DBCharIndex Instance
        {
            get
            {
                return mInstance;
            }
        }

        public DBCharIndex(string strName, string strPath)
            : base(strName, strPath)
        {
            mInstance = this;
        }

        public override void Unload()
        {
            base.Unload();
            mCharIndexMap.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
                return;

            mCharIndexMap.Clear();

            // 如果本地语言是中文，则直接返回
            if (Const.Language == LanguageType.SIMPLE_CHINESE)
                return;

            while (reader.Read())
            {
                var table_name = GetReaderString(reader, "table_name");
                var column_name = GetReaderString(reader, "column_name");

                List<string> columnList = null;
                if (mCharIndexMap.TryGetValue(table_name, out columnList))
                {
                    columnList.Add(column_name);
                    continue;
                }

                columnList = new List<string>();
                columnList.Add(column_name);
                mCharIndexMap[table_name] = columnList;
            }
        }

        /// <summary>
        /// 指定表格的列是否包含中文
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public bool HasChineseChars(string tableName, string columnName)
        {
            // 如果本地语言是中文，则返回false
            if (Const.Language == LanguageType.SIMPLE_CHINESE)
                return false;

            List<string> columnList = null;
            if(mCharIndexMap.TryGetValue(tableName, out columnList))
            {
                return columnList.Contains(columnName);
            }

            return false;
        }
    }
}
