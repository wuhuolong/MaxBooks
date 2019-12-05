using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBTitleEffect : DBSqliteTableResource
    {
        public class DBTitleEffectItem
        {
            public uint Id; 
            public string Name; 
            public Vector2 Arg;
            public Vector2 FrameSize;
            public uint PatchId;
        }

        Dictionary<uint, DBTitleEffectItem> Data = new Dictionary<uint, DBTitleEffectItem>();

        public DBTitleEffect(string strName, string strPath) : base(strName, strPath)
        {

        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public DBTitleEffectItem GetData(uint id)
        {
            DBTitleEffectItem ad = null;
            if (Data.TryGetValue(id, out ad))
                return ad;

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                Data[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                Data[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            var ret = new DBTitleEffectItem();
            ret.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
            ret.Name = GetReaderString(reader, "name");
            ret.Arg = DBTextResource.ParseVector2(GetReaderString(reader, "arg"));
            ret.FrameSize = DBTextResource.ParseVector2(GetReaderString(reader, "frame_size"));
            ret.PatchId = DBTextResource.ParseUI(GetReaderString(reader, "patch_id"));

            Data.Add(ret.Id, ret);

            reader.Close();
            reader.Dispose();

            return ret;
        }

        public override void Unload()
        {
            Data.Clear();
        }
    }
}