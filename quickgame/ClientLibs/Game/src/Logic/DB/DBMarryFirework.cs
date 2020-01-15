//----------------------------------------------------------------
// File: DBMarryFirework.cs
// Desc: 烟火特效配置表
// Author: raorui
// Date: 2018.11.22
//----------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMarryFirework : DBSqliteTableResource
    {
        static string mFirewordTableName = "data_marry_firework";

        public class FireworkInfo
        {
            public uint ID; // 对应的物品ID
            public string AssetPath; // 特效的资源路径
            public string AudioPath; // 音效的资源路径
            public float Time;// 特效播放的时间
        }

        public Dictionary<uint, FireworkInfo> mInfos = new Dictionary<uint, FireworkInfo>();

        static DBMarryFirework mInstance;
        public static DBMarryFirework Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new DBMarryFirework(GlobalConfig.DBFile, mFirewordTableName);

                return mInstance;
            }
        }

        public DBMarryFirework(string strName, string strPath) : base(strName, strPath)
        {
            
        }

        /// <summary>
        /// 根据物品ID来获取烟火特效的配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FireworkInfo GetInfo(uint id)
        {
            FireworkInfo info = null;
            if(mInfos.TryGetValue(id, out info))
                return info;

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mFirewordTableName, "id", id.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mFirewordTableName, query_str);
            if (table_reader == null)
            {
                mInfos[id] = null;
                return null;
            }

            if (!table_reader.HasRows || !table_reader.Read())
            {
                mInfos[id] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            info = new FireworkInfo();
            info.ID = DBTextResource.ParseUI_s(GetReaderString(table_reader, "id"), 0);
            info.AssetPath = GetReaderString(table_reader, "asset_path");
            info.AudioPath = GetReaderString(table_reader, "audio_path");
            info.Time = DBTextResource.ParseF_s(GetReaderString(table_reader, "time"),1.0f);

            table_reader.Close();
            table_reader.Dispose();
            mInfos[info.ID] = info;

            return info;
        }
    }
}
