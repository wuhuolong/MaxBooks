

/*----------------------------------------------------------------
// 文件名： DBStigmaLv.cs
// 文件功能描述： 圣痕进阶表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBStigmaLv : DBSqliteTableResource
    {
        public class DBStigmaLvItem
        {
            public uint Id;
            public uint Lv;
            public uint Exp;
            public List<DBTextResource.DBAttrItem> Attr;    //属性加成
            public uint attr_percent;
        }

        /// <summary>
        /// 保存所有的圣痕属性
        /// </summary>
        public Dictionary<uint, DBStigmaLvItem> mInfos = new Dictionary<uint, DBStigmaLvItem>();

        /// <summary>
        /// 保存id与最大等级的对应关系
        /// </summary>
        public Dictionary<uint, uint> mMaxLevelInfos = new Dictionary<uint, uint>();

        public DBStigmaLv(string strName, string strPath): base(strName, strPath)
        {
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mMaxLevelInfos.Clear();
        }

        /// <summary>
        /// 根据id和level获取圣痕属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public DBStigmaLvItem GetOneInfo(uint id, uint level)
        {
            uint uid = id * 1000 + level;
            DBStigmaLvItem info;
            if (mInfos.TryGetValue(uid, out info))
            {
                return info;
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"", mTableName, "id", id, "lv", level);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mInfos[uid] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[uid] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new DBStigmaLvItem();
            info.Id = id;
            info.Lv = level;
            info.Exp = GetReaderUint(reader, "exp");
            info.Attr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attr"));
            info.attr_percent = DBTextResource.ParseUI_s(GetReaderString(reader, "attr_percent"), 0);
            mInfos[uid] = info;

            reader.Close();
            reader.Dispose();

            return info;
        }

        /// <summary>
        /// 获取某一圣痕的最大等级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public uint GetMaxLevel(uint id)
        {
            uint max_lv = 0;
            if (mMaxLevelInfos.TryGetValue(id, out max_lv))
            {
                return max_lv;
            }

            string query_str = string.Format("SELECT {0}.{3} FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id, "lv");
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mMaxLevelInfos[id] = 0;
                return 0;
            }

            if (!reader.HasRows)
            {
                mMaxLevelInfos[id] = 0;
                reader.Close();
                reader.Dispose();
                return 0;
            }

            while(reader.Read())
            {
                var lv = GetReaderUint(reader, "lv");
                if (lv > max_lv)
                    max_lv = lv;
            }

            mMaxLevelInfos[id] = max_lv;

            reader.Close();
            reader.Dispose();

            return max_lv;
        }
    }
}
