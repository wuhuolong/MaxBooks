/*******************************************************************/
//   File : DBServerIdMaping.cs
//   Desc : 服务器ID与区号映射
//   Author : raorui
//   Date   : 2016.10.17
/*******************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    /// <summary>
    /// 服务器映射信息
    /// </summary>
    public class ServerMapInfo
    {
        public uint ServerId; // 服务器ID
        public uint ServerZoneId; // 服务器区号ID
    }
    
    public class DBServerIdMaping : DBSqliteTableResource
    {
        private Dictionary<uint, ServerMapInfo> mServerMapInfos = new Dictionary<uint, ServerMapInfo>();
        
        public static DBServerIdMaping mInstace;
        public static DBServerIdMaping Instace
        {
            get{
                return mInstace;
            }
        }
        
        public DBServerIdMaping(string name, string path)
            : base(name, path)
        {
            mInstace = this;
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
            
            mServerMapInfos.Clear();           
            while (reader.Read())
            {
                ServerMapInfo info = new ServerMapInfo();
                info.ServerId = DBTextResource.ParseUI_s(GetReaderString(reader, "svr_id"),0);
                info.ServerZoneId = DBTextResource.ParseUI_s(GetReaderString(reader, "svr_no"),0);
                
                mServerMapInfos[info.ServerId] = info;
            }
        }

        /// <summary>
        /// 从服务器Id获取服务器区号
        /// </summary>
        /// <returns>The server map info.</returns>
        /// <param name="svr_id">Svr_id.</param>
        public uint GetServerZoneId(uint svr_id)
        {
            ServerMapInfo info = null;
            if(mServerMapInfos.TryGetValue(svr_id, out info))
            {
                return info.ServerZoneId;
            }
            else
                return svr_id;
        }

    }
}
