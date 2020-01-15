
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBHonor : DBSqliteTableResource
    {
        public class DBHonorItem
        {
            public uint Id; //头衔表id字段
            public string Name; // 头衔名
            public long NeedPower;
            public string Icon; // 头衔图标
            public List<DBTextResource.DBGoodsItem> NeedGoods;
            public List<DBTextResource.DBAttrItem> AddAttr;
            public uint Quality; //品质
        }

        private Dictionary<uint, DBHonorItem> data = new Dictionary<uint, DBHonorItem>();

        public DBHonor(string strName, string strPath) : base(strName, strPath)
        {

        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public DBHonorItem GetData(uint id)
        {
            DBHonorItem ad = null;
            if (data.TryGetValue(id, out ad))
                return ad;

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
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

            var ret = new DBHonorItem();
            ret.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
            ret.Name = GetReaderString(reader, "name");
            ret.Icon = GetReaderString(reader, "icon");
            ret.NeedPower = DBTextResource.ParseL(GetReaderString(reader, "need_pw"));
            ret.NeedGoods = DBTextResource.ParseDBGoodsItem(GetReaderString(reader, "need_goods"));
            ret.AddAttr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attr"));
            ret.Quality = DBTextResource.ParseUI_s(GetReaderString(reader, "qual"), 0);
            data.Add(ret.Id, ret);

            reader.Close();
            reader.Dispose();

            return ret;
        }

        public override void Unload()
        {
            data.Clear();
        }

        public string GetHonorIcon()
        {
            return GetHonorIcon(LocalPlayerManager.Instance.LocalActorAttribute.Honor);
        }

        public string GetHonorIcon(uint honorId)
        {
            var item = GetData(honorId);
            if (null == item || item.Icon.Length <= 0)
                return null;

            return item.Icon;
        }
    }
}


