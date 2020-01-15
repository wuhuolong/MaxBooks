
/*----------------------------------------------------------------
// 文件名： DBGuildLv.cs
// 文件功能描述： 宠物表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuildLv : DBSqliteTableResource
    {
        public class DBGuildLvItem
        {
            public uint Id;         // 当前等级
            public uint exp;        //下一级的经验
            public uint num;        //成员数
        }
        Dictionary<uint, DBGuildLvItem> mInfos = new Dictionary<uint, DBGuildLvItem>();

        public DBGuildLv(string strName, string strPath)
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

        public DBGuildLvItem GetOneItem(uint level)
        {
            if (mInfos.ContainsKey(level) == true)
            {
                return mInfos[level];
            }

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "lv", level);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[level] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[level] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            DBGuildLvItem info = new DBGuildLvItem();
            info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "lv"), 0);
            info.exp = DBTextResource.ParseUI_s(GetReaderString(reader, "exp"), 0);
            info.num = DBTextResource.ParseUI_s(GetReaderString(reader, "num"), 0);
            mInfos.Add(info.Id, info);

            reader.Close();
            reader.Dispose();
            return info;
        }
    }
}
