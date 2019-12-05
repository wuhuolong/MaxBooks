using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

using Mono.Data.Sqlite;

namespace xc
{
    public class DBSqliteTableResource : DBManager.DBBase
    {
        /// <summary>
        /// 缓存列名与index的对应
        /// </summary>
        Dictionary<string, int> mColumnIndexMap = new Dictionary<string, int>();

		protected string mFileName;
        protected string mTableName;

        public string FileName { get { return mFileName; } }
        public string TableName { get { return mTableName; } }


        public DBSqliteTableResource(string fileName, string tableName)
		{
            mFileName = fileName;
            mTableName = tableName;
		}
		
		public override void Load()
        {
            SqliteDataReader reader = DBManager.Instance.ExecuteSqliteQueryToReader(mFileName, mTableName, "SELECT * FROM " + mTableName);
            ParseData(reader);

            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }

            IsLoaded = true;
        }

        protected virtual void ParseData(SqliteDataReader reader)
        {

        }

        /// <summary>
        /// 获取指定列的index
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetColumnIndex(SqliteDataReader reader, string name)
        {
            if (reader == null || string.IsNullOrEmpty(name))
                return -1;

            int index = -1;
            if(!mColumnIndexMap.TryGetValue(name, out index))
            {
                index = reader.GetOrdinal(name);
                mColumnIndexMap[name] = index;
            }

            return index;
        }

        /// <summary>
        /// 获取指定列的字符串数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetReaderString(SqliteDataReader reader, string name)
        {
            string result = string.Empty;

            if(reader == null)
                return result;

            int index = GetColumnIndex(reader,name);
            if(index != -1)
            {
                result = reader.GetString(index);
                if(mTableName != DBManager.CharIndexTable)
                {
                    // 翻译文本
                    var hasChinese = DBCharIndex.Instance.HasChineseChars(mTableName, name);
                    if (hasChinese)
                        result = xc.DBTranslate.Instance.GetTranslateText(mTableName, result);
                }
            }
            else
                GameDebug.LogError(string.Format("DBSqliteTableResource.GetReaderString can not get ordinal: {0}", name));

            return result;
        }

        /// <summary>
        /// 读取指定列中字符串的二进制数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public byte[] GetReaderBytes(SqliteDataReader reader, string name)
        {
            if (reader == null)
                return null;

            byte[] result = null;
            int index = GetColumnIndex(reader, name);
            if (index != -1)
            {
                result = reader.GetStringBytes(index);
            }
            else
                GameDebug.LogError(string.Format("DBSqliteTableResource.GetReaderString can not get ordinal: {0}", name));

            return result;
        }

        /// <summary>
        /// 获取指定列的整形数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public uint GetReaderUint(SqliteDataReader reader, string name)
        {
            uint result = 0;

            if (reader == null)
                return result;

            int index = GetColumnIndex(reader, name);
            if (index != -1)
            {
                result = (uint)reader.GetInt32(index);
            }
            else
            {
                GameDebug.LogError(string.Format("DBSqliteTableResource.GetReaderUint can not get ordinal: {0}", name));
            }

            return result;
        }

        /// <summary>
        /// 获取指定列的浮点数据
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public float GetReaderFloat(SqliteDataReader reader, string name)
        {
            float result = 0f;

            if (reader == null)
            {
                return result;
            }

            int index = GetColumnIndex(reader, name);
            if (index != -1)
            {
                result = reader.GetFloat(index);
            }
            else
            {
                GameDebug.LogError(string.Format("GetReaderFloat read field: {0} error", name));
            }

            return result;
        }
    }
}
