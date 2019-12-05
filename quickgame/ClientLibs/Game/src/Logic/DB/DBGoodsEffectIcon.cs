
/*----------------------------------------------------------------
// 文件名： DBGoodsEffectIcon.cs
// 文件功能描述： 物品图标特效表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGoodsEffectIcon : DBSqliteTableResource
    {

        public class DBGoodsEffectIconItem
        {
            public uint Id;
            public string Path;
            public string EffectImagePath {
                get {
                    return string.Format("Assets/Res/Effects/Textures/{0}", Path);
                }
            }  //特效文件路径
        }
     
        public Dictionary<uint, DBGoodsEffectIconItem> mInfos = new Dictionary<uint, DBGoodsEffectIconItem>();   //所有的宠物表的排序后的列表
        public DBGoodsEffectIcon(string strName, string strPath)
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
            DBGoodsEffectIconItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBGoodsEffectIconItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Path = GetReaderString(reader, "path");
                        if (mInfos.ContainsKey(info.Id) == false)
                        {
                            mInfos.Add(info.Id, info);
                        }
                    }
                }
            }
        }

        public DBGoodsEffectIconItem GetOneInfo(uint icon_id)
        {
            DBGoodsEffectIconItem info;
            if (mInfos.TryGetValue(icon_id, out info))
            {
                return info;
            }
            return null;
        }
    }
}
