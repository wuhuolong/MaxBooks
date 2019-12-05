/// <summary>
/// 默认换装表
/// </summary>
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBAvatarDefault: DBSqliteTableResource
    {   
        public class Data
        {
            public uint bodyId;
            public uint weaponId;
            public string default_res; // 默认换装资源的路径
        }
        
        public Dictionary<Actor.EVocationType, Data> mData = new Dictionary<Actor.EVocationType, Data>();
        
        public DBAvatarDefault(string strName, string strPath)
            :base(strName, strPath)
        {
        }
        
        protected override void ParseData(SqliteDataReader reader)
        {
            if(reader == null || !reader.HasRows)
            {
                return;
            }

            mData.Clear();
            
            while (reader.Read())
            {
                Data data = new Data();
                data.bodyId = DBTextResource.ParseUI(GetReaderString(reader, "body"));
                data.weaponId = DBTextResource.ParseUI(GetReaderString(reader, "weapon"));
                data.default_res = GetReaderString(reader, "default_res");
                mData.Add((Actor.EVocationType)DBTextResource.ParseUI(GetReaderString(reader, "vocation")), data);
            }
        }
        
        
    }
}

