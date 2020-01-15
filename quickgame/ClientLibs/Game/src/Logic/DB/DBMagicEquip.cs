using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMagicEquip : DBSqliteTableResource
    {
        public class DBMagicEquipItem
        {
            public uint Gid; 
            public uint PosId;  // 部位id
            public uint StrengthMax;  // 最大强化等级
            public uint Star; // 星级 
            public uint SwallowExpValue; // 被吞噬所化经验值
            public string DefaultAppendDesc; // 装备额外描述
            public uint AppendAttrNum; // 附加属性条数

            public List<DBTextResource.DBAttrItem> BaseAttrs; // 基础属性
        }

        public Dictionary<uint, DBMagicEquipItem> data; 

        public DBMagicEquip(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBMagicEquipItem>();
        }

        public static DBMagicEquip Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBMagicEquip>();
            }
        }

        public DBMagicEquipItem GetData(uint gid)
        {
            DBMagicEquipItem ad = null;
            if (!data.TryGetValue(gid, out ad))
                ad = GetItemInfo(gid);

            return ad;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        private DBMagicEquipItem GetItemInfo(uint gid)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "gid", gid);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                data[gid] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                data[gid] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            DBMagicEquipItem ad = new DBMagicEquipItem();
            ad.Gid = gid;
            ad.PosId = DBTextResource.ParseUI(GetReaderString(reader, "pos_id"));
            ad.StrengthMax = DBTextResource.ParseUI(GetReaderString(reader, "max_lv"));
            ad.Star = DBTextResource.ParseUI(GetReaderString(reader, "star"));
            ad.SwallowExpValue = DBTextResource.ParseUI(GetReaderString(reader, "exp"));
            ad.DefaultAppendDesc = GetReaderString(reader, "default_append_desc");

            ad.BaseAttrs = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "base_attrs"));

            uint num = 0;

            string appendAttrStr = GetReaderString(reader, "spec_attrs");
            appendAttrStr = appendAttrStr.Replace(" ", "");
            var matchs = Regex.Matches(appendAttrStr, @"\{(\d+),(\d+)\}");

            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    num = num + DBTextResource.ParseUI(_match.Groups[2].Value);
                }
            }

            ad.AppendAttrNum = num;

            data.Add(ad.Gid, ad);

            reader.Close();
            reader.Dispose();
            return ad;
        }

        public override void Unload()
        {
            data.Clear();
        }
    }
}