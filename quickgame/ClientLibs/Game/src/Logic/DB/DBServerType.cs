/*******************************************************************/
//   Desc : 渠道标识
//   Author : raorui
//   Date   : 2016.1.23
/*******************************************************************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    public class ServerTypeInfo
    {
        public string platform; // 平台名字
        public int test_id;     // 测试服务器标识
        public int official_id; // 正式服务器标识
        public int audit_id; // 审核服务器标识
    }
    
    public class DBServerType : DBSqliteTableResource
    {
        private Dictionary<string, ServerTypeInfo> mServerTypeInfos = new Dictionary<string, ServerTypeInfo> ();
        
        public DBServerType(string name, string path)
            : base(name, path)
        {

        }
        
        public override void Unload()
        {
            base.Unload();
        }

        public int GetServerType(string platform, string run_env)
        {
            ServerTypeInfo info = null;
            if(mServerTypeInfos.TryGetValue(platform, out info))
            {
                if(run_env == "test_id")
                {
                    return info.test_id;
                }
                else if(run_env == "official_id")
                {
                    return info.official_id;
                }
                else if (run_env == "audit_id")
                {
                    return info.audit_id;
                }
                else
                {
                    GameDebug.Log("GetServerType error: " + platform + " " + run_env);
                    return 0;
                }
            }
            else
            {
                GameDebug.Log("GetServerType error: " + platform + " " + run_env);
                return 0;
            }
        }
        
        protected override void ParseData(SqliteDataReader reader)
        {
            base.ParseData (reader);

            if (reader == null || !reader.HasRows)
            {
                return;
            }
            
            mServerTypeInfos.Clear ();

            while (reader.Read())
            {
                ServerTypeInfo info = new ServerTypeInfo();
                info.platform = GetReaderString(reader, "platform");
                info.test_id = DBTextResource.ParseI_s(GetReaderString(reader, "test_id"),0);
                info.official_id = DBTextResource.ParseI_s(GetReaderString(reader, "official_id"),0);
                info.audit_id = DBTextResource.ParseI_s(GetReaderString(reader, "audit_id"),0);
                
                mServerTypeInfos[info.platform] = info;
            }
        }
    }
}
