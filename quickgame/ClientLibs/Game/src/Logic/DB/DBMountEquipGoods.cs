//-----------------------------------
// File: DBMountEquipGoods.cs
// Desc: 坐骑装备  配置
// Author: luozhuocheng
// Date: 2018/8/29 17:34:20
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using Utils;

namespace xc
{
    public class DBMountEquipGoods : DBSqliteTableResource
    {
        public class DBMountEquipGoodsItem
        {
            public uint gid;
            public uint ride_limit;  // 穿戴坐骑等级限制
            public uint pos_id;
            public uint lv_step;
            public List<DBTextResource.DBAttrItem> attrs;

        }

        public Dictionary<uint, DBMountEquipGoodsItem> data;
        public List<uint> pos_list;

        public DBMountEquipGoods(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBMountEquipGoodsItem>();
            pos_list = new List<uint>();
        }

        public static DBMountEquipGoods Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBMountEquipGoods>();
            }
        }

        public DBMountEquipGoodsItem GetData(uint id)
        {
            DBMountEquipGoodsItem ad = null;
            data.TryGetValue(id, out ad);
            return ad;
        }
        public List<uint> GetPosList()
        {
            return pos_list;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBMountEquipGoodsItem ad = new DBMountEquipGoodsItem();
                ad.gid = DBTextResource.ParseUI(GetReaderString(reader, "gid"));
                ad.ride_limit = DBTextResource.ParseUI(GetReaderString(reader, "ride_limit"));
                ad.pos_id = DBTextResource.ParseUI(GetReaderString(reader, "pos_id"));
                ad.lv_step = DBTextResource.ParseUI(GetReaderString(reader, "lv_step"));
                ad.attrs = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attrs"));

                data.Add(ad.gid, ad);

                if (pos_list.Contains(ad.pos_id) == false)
                    pos_list.Add(ad.pos_id);

            }
        }

        public override void Unload()
        {
            data.Clear();
        }

    }
}
