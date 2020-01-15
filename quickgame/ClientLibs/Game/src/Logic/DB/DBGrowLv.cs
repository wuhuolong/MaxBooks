

/*----------------------------------------------------------------
// 文件名： DBGrowLv.cs
// 文件功能描述： 成长等级表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGrowLv : DBSqliteTableResource
    {
        public class DBGrowLvItem
        {
            public uint GrowType;         // 成长类型
            public uint Lv;         //等级
            public uint Exp;         //经验
            public List<DBTextResource.DBGoodsItem> Cost;   //消耗物品
            public uint GetExp;     //每次消耗获得经验值
            public List<DBTextResource.DBAttrItem> AttrArray; //属性
        }

        Dictionary<uint, DBGrowLvItem> mInfos = new Dictionary<uint,DBGrowLvItem>();

        public DBGrowLv(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();

        }

        DBGrowLvItem ReadData(uint grow_type, uint level)
        {
            uint uid = grow_type + level * 100;
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"", mTableName, "type", grow_type, "lv", level);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
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

            DBGrowLvItem info = new DBGrowLvItem();
            info.GrowType = DBTextResource.ParseUI_s(GetReaderString(reader, "type"), 0);
            info.Lv = DBTextResource.ParseUI_s(GetReaderString(reader, "lv"), 0);
            info.Exp = DBTextResource.ParseUI_s(GetReaderString(reader, "exp"), 0);
            info.Cost = DBTextResource.ParseDBGoodsItem(GetReaderString(reader, "cost"));
            info.GetExp = DBTextResource.ParseUI_s(GetReaderString(reader, "get_exp"), 0);
            info.AttrArray = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attr")); //属性加成
            mInfos[uid] = info;

            reader.Close();
            reader.Dispose();

            return info;
        }

        public DBGrowLvItem GetOneItem(uint grow_type, uint level)
        {
            uint uid = grow_type + level * 100;
            DBGrowLvItem info = null;
            if (!mInfos.TryGetValue(uid, out info))
                info = ReadData(grow_type, level);
           
            return info;
        }
    }
}
