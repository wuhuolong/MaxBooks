//--------------------------------------
// File: DBUICommonSound.cs
// Desc: ui通用声音的播放配置
// Author: Raorui
// Date: 2017.11.28
//--------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBUISoundCommon : DBSqliteTableResource
    {
        /// <summary>
        /// 图片名字与声音资源路径的对应
        /// </summary>
        Dictionary<string, string> m_CommonSoundMap = new Dictionary<string, string>();

        static DBUISoundCommon m_Instance;
        public static DBUISoundCommon Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public DBUISoundCommon(string strName, string strPath) :
            base(strName, strPath)
        {
            m_Instance = this;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            m_CommonSoundMap.Clear();

            while (reader.Read())
            {
                //info = new SoundCommonInfo();
                string sprite_name = GetReaderString(reader, "sprite_name");
                string res_path = GetReaderString(reader, "res_path");

                m_CommonSoundMap[sprite_name] = res_path;
            }
        }

        /// <summary>
        /// 获取指定图片对应的声音名字
        /// </summary>
        /// <param name="sprite_name"></param>
        /// <returns></returns>
        public string GetSoundPath(string sprite_name)
        {
            string res_path = string.Empty;
            m_CommonSoundMap.TryGetValue(sprite_name, out res_path);
            return res_path;
        }
    }
}
