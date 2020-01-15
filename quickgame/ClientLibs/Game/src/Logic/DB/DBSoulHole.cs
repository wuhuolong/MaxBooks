//-----------------------------------
// File: DBSoulHole.cs
// Desc: 武魂鑲嵌孔 配置
// Author: luozhuocheng
// Date: 2018/11/23 17:15:25
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using Utils;




namespace xc
{
    public class DBSoulHole : DBSqliteTableResource
    {
        public class DBSoulHoleItem
        {
            public uint hole_id;
            public uint open_cond;  
            public List<uint> inlay_type;//镶嵌类型组
        }

        public Dictionary<uint, DBSoulHoleItem> data;
        public List<uint> limitedList = new List<uint>();

        public DBSoulHole(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBSoulHoleItem>();
 
        }

        public static DBSoulHole Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBSoulHole>();
            }
        }

        public DBSoulHoleItem GetData(uint hole)
        {
            DBSoulHoleItem ad = null;
            data.TryGetValue(hole, out ad);
            return ad;
        }
 
        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBSoulHoleItem ad = new DBSoulHoleItem();
                ad.hole_id = DBTextResource.ParseUI(GetReaderString(reader, "hole_id"));
                ad.open_cond = DBTextResource.ParseUI(GetReaderString(reader, "open_cond"));
                string str_inlay_type = GetReaderString(reader, "inlay_type");
                if (string.IsNullOrEmpty(str_inlay_type))
                {
                    ad.inlay_type = new List<uint>();
                }
                else
                {
                    ad.inlay_type = DBTextResource.ParseArrayUint(str_inlay_type, ",");
                }
                data.Add(ad.hole_id, ad);

                for (int i = 0; i < ad.inlay_type.Count; i++)
                {
                    limitedList.Add(ad.inlay_type[i]);    
                }
            }
        }

        public override void Unload()
        {
            data.Clear();
        }

        public List<uint> GetLimitedList()
        {
            return limitedList;
        }


    }
}
