/*----------------------------------------------------------------
// 文件名： DBConstText.cs
// 文件功能描述： 游戏文本表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
	public class DBConstText : DBSqliteTableResource
    {
        /// <summary>
        /// 保存文本ID与文本的对应关系
        /// </summary>
		private Dictionary<string, string> mTextData = new Dictionary<string, string>();

#if UNITY_EDITOR
        private Dictionary<string, bool> mTextCheck = new Dictionary<string, bool>();
#endif

        public DBConstText(string strName, string strPath) : base(strName, strPath)
		{
		}

        /// <summary>
        /// 获取指定文本ID对应的字符串
        /// </summary>
        /// <param name="textId"></param>
        /// <returns></returns>
        public static string GetText(string textId)
        {
            return DBManager.Instance.GetDB<DBConstText>().Text(textId);
        }

        /// <summary>
        /// 根据文本表里面的id前缀随机获取文本表的内容
        /// 比如文本表里面有"XXX_1","XXX_2","XXX_3"这三行内容，传入"XXX_"则获取这三个文本的其中随机一个
        /// </summary>
        public static string GetRandomText(string textIdPrefix, uint random_count = 1)
        {
            var random_index = UnityEngine.Random.Range((int)0, (int)random_count) + 1;
            string random_text = GetText(textIdPrefix + random_index);
            return random_text;
        }

		public string Text(string textId)
		{
			string value;
			if(mTextData.TryGetValue(textId, out value))
			    return value;

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", textId);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mTextData[textId] = "";
                return "";
            }

            if (!reader.HasRows || !reader.Read())
            {
                mTextData[textId] = "";
                reader.Close();
                reader.Dispose();
                GameDebug.LogError("Error!!! Can not find const text by key:" + textId);
                return "";
            }

            var text = GetReaderString(reader, "text");

            mTextData[textId] = text;

            reader.Close();
            reader.Dispose();

            return text;
        }

		protected override void ParseData(SqliteDataReader reader)
        {
#if UNITY_EDITOR
            mTextCheck.Clear();
            if (reader != null || !reader.HasRows)
                return;

            while (reader.Read())
            {
                string key = GetReaderString(reader, "id");
                if (mTextCheck.ContainsKey(key) == false)
                {
                    mTextCheck.Add(key, true);
                }
                else
                {
                    GameDebug.LogError("Parse const text error, key " + key + " already exists!!!");
                }
            }
#endif
        }
	}
}
