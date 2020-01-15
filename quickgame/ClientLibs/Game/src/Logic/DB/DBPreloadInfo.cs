/*******************************************************************/
//   Desc : 预加载资源表
//   Author : raorui
//   Date   : 2018.4.14
/*******************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    public class PreloadInfo
    {
        public string asset_path; // 资源路径
    }

    public class DBPreloadInfo : DBSqliteTableResource
    {
        private List<PreloadInfo> mPreloadInfos = new List<PreloadInfo>();

        static DBPreloadInfo mInstance;
        public static DBPreloadInfo Instance
        {
            get
            {
                return mInstance;
            }
        }

        public List<PreloadInfo> PreloadInfos
        {
            get
            {
                return mPreloadInfos;
            }
        }

        public DBPreloadInfo(string name, string path)
            : base(name, path)
        {
            mInstance = this;
        }
        
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

            mPreloadInfos.Clear();
            while (reader.Read())
            {
                PreloadInfo data = new PreloadInfo();
                data.asset_path = GetReaderString(reader, "asset_path");
                mPreloadInfos.Add(data);
            }
        }
    }
}