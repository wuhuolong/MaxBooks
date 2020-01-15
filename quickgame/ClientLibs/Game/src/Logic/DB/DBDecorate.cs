using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    [wxb.Hotfix]
    public class DBDecorate : DBSqliteTableResource
    {
        public class DBDecorateItem
        {
            public uint Gid; 
            public uint Pos;  // 部位id
            public uint StrengthMax;  // 最大强化等级
            public uint LvStep; // 阶数
            public uint SwallowExpValue; // 被吞噬所化经验值
            public string DefaultExtraDesc;// 额外属性描述
            public uint DefaultStar; // 默认星级

            public string Attrs; // 基础属性
            public List<List<uint>> LegendAttrs; //传奇属性
        }

        public class LegendAttrDescItem
        {
            public string Name;
            public string ValueStr;
        }

        Dictionary<uint, DBDecorateItem> data; 

        public DBDecorate(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBDecorateItem>();
        }

        public static DBDecorate Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBDecorate>();
            }
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public DBDecorateItem GetData(uint gid)
        {
            DBDecorateItem ad = null;
            if (data.TryGetValue(gid, out ad))
                return ad;

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

            var ret = new DBDecorateItem();
            ret.Gid = DBTextResource.ParseUI(GetReaderString(reader, "gid"));
            ret.Pos = DBTextResource.ParseUI(GetReaderString(reader, "pos_id"));
            ret.StrengthMax = DBTextResource.ParseUI(GetReaderString(reader, "max_lv"));
            ret.LvStep = DBTextResource.ParseUI(GetReaderString(reader, "lv_step"));
            ret.SwallowExpValue = DBTextResource.ParseUI(GetReaderString(reader, "value"));
            ret.Attrs = GetReaderString(reader, "attrs");
            ret.LegendAttrs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "legend_attrs"));
            ret.DefaultExtraDesc = GetReaderString(reader, "default_extra_desc");
            ret.DefaultStar = DBTextResource.ParseUI(GetReaderString(reader, "default_star"));

            data.Add(ret.Gid, ret);

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