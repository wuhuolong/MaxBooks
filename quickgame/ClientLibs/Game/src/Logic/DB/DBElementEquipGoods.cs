using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBElementEquipGoods : DBSqliteTableResource
    {
        private static string TableName = "data_element_ep";

        public class DBElementEquipGoodsItem
        {
            public uint Gid;    
            public uint Pos;  // 部位id
            public uint LvStep; // 阶数
            public uint Star; // 星级
            public uint StrenthenLimit; // 强化等级上限
            public uint Exp; // 被吞噬所化经验值
            public ActorAttribute BasicAttrs;   //基础属性
            public uint LegendAttrId;  //附加属性id
        }

        public Dictionary<uint, DBElementEquipGoodsItem> data;

        public DBElementEquipGoods(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBElementEquipGoodsItem>();
        }

        public static DBElementEquipGoods Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBElementEquipGoods>();
            }
        }

        public DBElementEquipGoodsItem GetData(uint gid)
        {
            DBElementEquipGoodsItem oneData = null;
            if (data.TryGetValue(gid, out oneData))
                return oneData;

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", TableName, "gid", gid.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, TableName, query_str);
            if (table_reader == null)
            {
                data[gid] = null;
                return null;
            }

            if (!table_reader.HasRows)
            {
                data[gid] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                data[gid] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            oneData = new DBElementEquipGoodsItem();
            oneData.Gid = DBTextResource.ParseUI(GetReaderString(table_reader, "gid"));
            oneData.Pos = DBTextResource.ParseUI(GetReaderString(table_reader, "type"));
            oneData.LvStep = DBTextResource.ParseUI(GetReaderString(table_reader, "lv_step"));
            oneData.Star = DBTextResource.ParseUI(GetReaderString(table_reader, "star"));
            oneData.StrenthenLimit = DBTextResource.ParseUI(GetReaderString(table_reader, "strength_limit"));
            oneData.Exp = DBTextResource.ParseUI(GetReaderString(table_reader, "exp"));
            List<List<uint>> basicAttrs = DBTextResource.ParseArrayUintUint(GetReaderString(table_reader, "attrs"));
            oneData.BasicAttrs = new ActorAttribute();
            for (var i = 0; i < basicAttrs.Count; i++)
            {
                oneData.BasicAttrs.Add(basicAttrs[i][0], basicAttrs[i][1]);
            }
            List<List<uint>> legendAttrs = DBTextResource.ParseArrayUintUint(GetReaderString(table_reader, "legend_attrs"));
            if (legendAttrs.Count > 0 && legendAttrs[0].Count > 0)
            {
                oneData.LegendAttrId = legendAttrs[0][0];
            }
            else
            {
                oneData.LegendAttrId = 0;
            }

            data[gid] = oneData;

            table_reader.Close();
            table_reader.Dispose();

            return oneData;
        }

        //protected override void ParseData(SqliteDataReader reader)
        //{
        //    if (reader == null || !reader.HasRows)
        //    {
        //        return;
        //    }

        //    while (reader.Read())
        //    {
        //        DBElementEquipGoodsItem ad = new DBElementEquipGoodsItem();
        //        ad.Gid = DBTextResource.ParseUI(GetReaderString(reader, "gid"));
        //        ad.Pos = DBTextResource.ParseUI(GetReaderString(reader, "type"));
        //        ad.LvStep = DBTextResource.ParseUI(GetReaderString(reader, "lv_step"));
        //        ad.Star = DBTextResource.ParseUI(GetReaderString(reader, "star"));
        //        ad.StrenthenLimit = DBTextResource.ParseUI(GetReaderString(reader, "strength_limit"));
        //        ad.Exp = DBTextResource.ParseUI(GetReaderString(reader, "exp"));
        //        List<List<uint>> basicAttrs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "attrs"));
        //        ad.BasicAttrs = new ActorAttribute();
        //        for (var i = 0; i < basicAttrs.Count; i++)
        //        {
        //            ad.BasicAttrs.Add(basicAttrs[i][0], basicAttrs[i][1]);
        //        }
        //        data.Add(ad.Gid, ad);
        //    }
        //}

        public override void Unload()
        {
            base.Unload();
            data.Clear();
        }
    }
}
