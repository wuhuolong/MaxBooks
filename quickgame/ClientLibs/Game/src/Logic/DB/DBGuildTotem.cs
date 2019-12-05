/*----------------------------------------------------------------
// 文件名： DBGuildTotem.cs
// 文件功能描述： 帮派图腾表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuildTotem : DBSqliteTableResource
    {
        public class DBGuildTotemItem
        {
            public uint Lv;             // 等级
            public ulong Exp;           // 经验
            public List<uint> Buffs;    // buff
            public List<string> Descs;              // 当前级增加的数值描述
            public List<string> NextOffsetDescs;    // 下一级增加的数值描述
        }
        Dictionary<uint, DBGuildTotemItem> mInfos = new Dictionary<uint, DBGuildTotemItem>();

        public DBGuildTotem(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
        }

        public DBGuildTotemItem GetOneItem(uint lv)
        {
            DBGuildTotemItem info;
            if (mInfos.TryGetValue(lv, out info))
            {
                return info;
            }

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "lv", lv);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[lv] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[lv] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new DBGuildTotemItem();

            info.Lv = DBTextResource.ParseUI_s(GetReaderString(reader, "lv"), 0);
            info.Exp = DBTextResource.ParseUL_s(GetReaderString(reader, "exp"), 0);
            info.Buffs = DBTextResource.ParseArrayUint(GetReaderString(reader, "buffs"), ",");
            info.Descs = DBTextResource.ParseArrayString(GetReaderString(reader, "descs"));
            info.NextOffsetDescs = DBTextResource.ParseArrayString(GetReaderString(reader, "next_offset_descs"));

            mInfos.Add(info.Lv, info);

            reader.Close();
            reader.Dispose();
            return info;
        }

        public DBGuildTotemItem GetNextItem(uint lv)
        {
            return GetOneItem(lv + 1);
        }
    }
}
