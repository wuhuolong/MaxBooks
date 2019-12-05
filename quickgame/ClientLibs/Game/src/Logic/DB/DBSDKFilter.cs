/*******************************************************************/
//   Desc : 渠道开启特定系统的处理
//   Author : raorui
//   Date   : 2016.1.22
/*******************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    public class SDKFilterInfo
    {
        public string sdk_name;
        public bool disable_share;
    }
    
    public class DBSDKFilter : DBSqliteTableResource
    {
        private Dictionary<string, SDKFilterInfo> mSDKFilterInfos;
        
        public static DBSDKFilter mInstace;
        public static DBSDKFilter Instace
        {
            get{
                return mInstace;
            }
        }
        
        public DBSDKFilter(string name, string path)
            : base(name, path)
        {
            mInstace = this;
        }
        
        public override void Unload()
        {
            base.Unload();
        }

        public bool DisableShareSys(string sdk_name)
        {
            SDKFilterInfo info;
            if(mSDKFilterInfos.TryGetValue(sdk_name.ToLower(), out info))
            {
                return info.disable_share;
            }

            return false;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }
            
            mSDKFilterInfos = new Dictionary<string, SDKFilterInfo>();
            
            while (reader.Read())
            {
                SDKFilterInfo info = new SDKFilterInfo();
                info.sdk_name = GetReaderString(reader, "sdk_name");
                info.disable_share = DBTextResource.ParseUI_s(GetReaderString(reader, "disable_share"),0) == 1;
               
                mSDKFilterInfos[info.sdk_name] = info;
            }
        }
    }
}
