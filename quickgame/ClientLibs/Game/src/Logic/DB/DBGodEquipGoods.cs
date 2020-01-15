using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGodEquipGoods : DBSqliteTableResource
    {
        private static string VoiceTableName = "data_voice";


        public class DBGodEquipGoodsItem
        {
            public uint Gid;
            public uint Pos;  // 部位id
            public uint LvStep; // 阶数
            public uint SwallowExpValue; // 被吞噬所化经验值
            public uint GrooveNum;//槽数
            public Dictionary<uint, uint> BasicAttrs; // 基础属性
        }

        public Dictionary<uint, DBGodEquipGoodsItem> data;

        public DBGodEquipGoods(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBGodEquipGoodsItem>();
        }

        public static DBGodEquipGoods Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBGodEquipGoods>();
            }
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;

        }

        public DBGodEquipGoodsItem GetData(uint id)
        {
            DBGodEquipGoodsItem ad = null;
            if(!data.TryGetValue(id, out ad))
            {
                string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" ", mTableName, "gid", id.ToString());
                var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(mFileName, VoiceTableName, query_str);
                if (table_reader == null)
                {
                    data[id] = null;
                    return null;
                }

                if (!table_reader.HasRows)
                {
                    data[id] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                if (!table_reader.Read())
                {
                    data[id] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                ad = new DBGodEquipGoodsItem();
                ad.Gid = DBTextResource.ParseUI(GetReaderString(table_reader, "gid"));
                ad.Pos = DBTextResource.ParseUI(GetReaderString(table_reader, "pos_id"));
                ad.LvStep = DBTextResource.ParseUI(GetReaderString(table_reader, "lv_step"));
                ad.SwallowExpValue = DBTextResource.ParseUI(GetReaderString(table_reader, "value"));
                ad.GrooveNum = DBTextResource.ParseUI(GetReaderString(table_reader, "groove_num"));
                ad.BasicAttrs = DBTextResource.ParseDictionaryUintUint(GetReaderString(table_reader, "attrs"));
                data.Add(ad.Gid, ad);

                table_reader.Close();
                table_reader.Dispose();
            }

            return ad;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            //if (reader == null || !reader.HasRows)
            //{
            //    return;
            //}

            //while (reader.Read())
            //{
            //    DBGodEquipGoodsItem ad = new DBGodEquipGoodsItem();
            //    ad.Gid = DBTextResource.ParseUI(GetReaderString(reader, "gid"));
            //    ad.Pos = DBTextResource.ParseUI(GetReaderString(reader, "pos_id"));
            //    ad.LvStep = DBTextResource.ParseUI(GetReaderString(reader, "lv_step"));
            //    ad.SwallowExpValue = DBTextResource.ParseUI(GetReaderString(reader, "value"));
            //    ad.GrooveNum = DBTextResource.ParseUI(GetReaderString(reader, "groove_num"));
            //    ad.BasicAttrs = DBTextResource.ParseDictionaryUintUint(GetReaderString(reader, "attrs"));
            //    data.Add(ad.Gid, ad);
            //}
        }


        public override void Unload()
        {
            data.Clear();
        }
    }
}
