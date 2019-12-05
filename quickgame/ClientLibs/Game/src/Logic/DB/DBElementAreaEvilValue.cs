using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBElementAreaEvilValue : DBSqliteTableResource
    {
        public class DBElementAreaEvilValueItem
        {
            public uint ActorId; //对应角色表中的id
            public uint Value;
        }

        public Dictionary<uint, DBElementAreaEvilValueItem> data = new Dictionary<uint, DBElementAreaEvilValueItem>();

        public DBElementAreaEvilValue(string strName, string strPath) : base(strName, strPath)
        {

        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public DBElementAreaEvilValueItem GetData(uint id)
        {
            DBElementAreaEvilValueItem ad = null;
            if (data.TryGetValue(id, out ad))
                return ad;

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "actor_id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                data[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                data[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            var ret = new DBElementAreaEvilValueItem();
            ret.ActorId = DBTextResource.ParseUI(GetReaderString(reader, "actor_id"));
            ret.Value = DBTextResource.ParseUI(GetReaderString(reader, "evil_value"));
            data.Add(ret.ActorId, ret);

            reader.Close();
            reader.Dispose();

            return ret;
        }

        public override void Unload()
        {
            data.Clear();
        }
    }
}