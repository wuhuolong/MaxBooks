//-----------------------------------
// File: DBWeddingRingGoods.cs
// Desc: 
// Author: luozhuocheng
// Date: 2018/11/7 15:32:32
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using Utils;

namespace xc
{
    public class DBWeddingRingGoods : DBSqliteTableResource
    {
        public class DBWeddingRingGoodsItem
        {
            public uint id_info;
            public uint step;
            public uint lv;
            public uint need_exp;
            public List<DBTextResource.DBAttrItem> normal_attrs;
            public List<DBTextResource.DBAttrItem> couple_attrs;
            public uint skill;
            public uint gid;
        }

        public Dictionary<uint, DBWeddingRingGoodsItem> data;
 

        public DBWeddingRingGoods(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBWeddingRingGoodsItem>();
 
        }

        public static DBWeddingRingGoods Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBWeddingRingGoods>();
            }
        }

        public DBWeddingRingGoodsItem GetData(uint id_info)
        {
            DBWeddingRingGoodsItem ad = null;
            if (data.TryGetValue(id_info, out ad))
                return ad;



            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", "data_ring", "id", id_info.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, "data_ring", query_str);
            if (table_reader == null)
            {
                data[id_info] = null;
                return null;
            }

            if (!table_reader.HasRows)
            {
                data[id_info] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                data[id_info] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            ad = new DBWeddingRingGoodsItem();
            ad.id_info = DBTextResource.ParseUI(GetReaderString(table_reader, "id"));
            ad.step = DBTextResource.ParseUI(GetReaderString(table_reader, "step"));
            ad.lv = DBTextResource.ParseUI(GetReaderString(table_reader, "lv"));
            ad.need_exp = DBTextResource.ParseUI(GetReaderString(table_reader, "need_exp"));

            ad.normal_attrs = DBTextResource.ParseDBAttrItems(GetReaderString(table_reader, "normal_attrs"));
            ad.couple_attrs = DBTextResource.ParseDBAttrItems(GetReaderString(table_reader, "couple_attrs"));

            ad.skill = DBTextResource.ParseUI(GetReaderString(table_reader, "skill"));
            ad.gid = DBTextResource.ParseUI(GetReaderString(table_reader, "gid"));

            data.Add(ad.id_info, ad);

            table_reader.Close();
            table_reader.Dispose();

            return ad;
        }

        public override void Load()
        {
            IsLoaded = true;
        }



        protected override void ParseData(SqliteDataReader reader)
        {
  
        }

        public override void Unload()
        {
            data.Clear();
        }

    }
}
