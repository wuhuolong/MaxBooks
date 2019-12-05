//----------------------------------------------------------------
// File： DBTranslate.cs
// Desc: 中文翻译对照表
// Author: raorui
// Date: 2018.12.4
//----------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text.RegularExpressions;

namespace xc
{
    [wxb.Hotfix]
    public class DBTranslate : DBSqliteTableResource
    {
        //语言类型对应的翻译表列名
        Dictionary<LanguageType, string> mLangDataColumn = new Dictionary<LanguageType, string>()
        {
            {LanguageType.KOREAN,"korean" },
            {LanguageType.ASIAN_ENGLISH,"english" },
            {LanguageType.VIETNAMESE, "vietnamese" },
            {LanguageType.THAI, "thai" },
        };
            //缓存数据
        Dictionary<string, string> mTranslate = new Dictionary<string, string>();

        public System.Text.StringBuilder TranslateErrorRecord
        {
            get
            {
                return m_TranslateErrorRecord;
            }
        }
        protected System.Text.StringBuilder m_TranslateErrorRecord = new System.Text.StringBuilder();

        static DBTranslate mInstance;
        public static DBTranslate Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new DBTranslate(GlobalConfig.DBFile, "data_translate");
                return mInstance;
            }
        }

        public DBTranslate(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        /// <summary>
        /// 正则配置
        /// </summary>
        protected const string PATTERN_CHINESE = @"[\u4e00-\u9fa5]";

        public string GetTranslateTextByLanguage(string tableName, string text, LanguageType lang)
        {
            
//#if UNITY_EDITOR
//            if (!Regex.IsMatch(text, PATTERN_CHINESE))
//                return text;
//#endif

            string translateText = "";
            if (mTranslate.TryGetValue(text, out translateText))
                return translateText;

            string trim_text = text.Trim();
            string search_text = Regex.Replace(trim_text, @"\s", "");
            string query_str;
            if (search_text == text)
                query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", "data_translate", "text", text);
            else
                query_str = string.Format("SELECT * FROM {0} WHERE REPLACE(REPLACE(REPLACE(REPLACE({0}.{1}, CHAR(13), ''), CHAR(10), ''), CHAR(9), ''), ' ', '')=\"{2}\"", "data_translate", "text", search_text);
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str, (int)DBManager.CommandTag.TAG_2);
            if (table_reader == null)
            {
                mTranslate[text] = text;
#if UNITY_EDITOR
                string log = string.Format("[GetTranslateText] table:{0} text:{1} null", tableName, text);
                GameDebug.LogError(log);

                m_TranslateErrorRecord.AppendLine(string.Format("{0}   {1}", tableName, text));
#endif

                return text;
            }

            if (!table_reader.HasRows || !table_reader.Read())
            {
                mTranslate[text] = text;
#if UNITY_EDITOR
                string log = string.Format("[GetTranslateText] table:{0} text:{1} 没有翻译文本", tableName, text);
                GameDebug.Log(log);

                m_TranslateErrorRecord.AppendLine(log);
#endif

                table_reader.Close();
                table_reader.Dispose();

                return text;
            }
            //根据当前的语言，选择对应的列
            string columnName = mLangDataColumn[lang];
            int index = table_reader.GetOrdinal(columnName);
            if (trim_text == text)
            {
                translateText = index != -1 ? table_reader.GetString(index) : text;
            }
            else
            {
                translateText = index != -1 ? text.Replace(trim_text, table_reader.GetString(index)) : text;
            }

            mTranslate[text] = translateText;

            table_reader.Close();
            table_reader.Dispose();

            return translateText;
        }
        /// <summary>
        /// 获取翻译后的文本
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string GetTranslateText(string tableName, string text)
        {
            // 如果本地语言是中文，则返回原始文本
            if (Const.Language == LanguageType.SIMPLE_CHINESE)
                return text;
            return GetTranslateTextByLanguage(tableName, text, Const.Language);
        }
    }
}
