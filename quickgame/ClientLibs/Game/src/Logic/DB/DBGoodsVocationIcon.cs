/*----------------------------------------------------------------
// 文件名： DBGoodsVocationIcon.cs
// 文件功能描述： 物品图标特效表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGoodsVocationIcon : DBSqliteTableResource
    {

        public class DBGoodsVocationIconItem
        {
            public uint Id;
            private Dictionary<uint, uint> Icons = new Dictionary<uint, uint>();

            public void Add(uint vocation, uint iconId)
            {
                if(Icons.ContainsKey(vocation) == false)
                {
                    Icons.Add(vocation, iconId);
                }
            }

            public uint GetIconId(uint vocation)
            {
                if(Icons.ContainsKey(vocation))
                {
                    return Icons[vocation];
                }
                return 0;
            }
        }

        public Dictionary<uint, DBGoodsVocationIconItem> mInfos = new Dictionary<uint, DBGoodsVocationIconItem>(); 
        public DBGoodsVocationIcon(string strName, string strPath)
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
            DBGoodsVocationIconItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBGoodsVocationIconItem();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Add(1,DBTextResource.ParseUI_s(GetReaderString(reader, "icon1"), 0));
                        info.Add(2,DBTextResource.ParseUI_s(GetReaderString(reader, "icon2"), 0));
                        info.Add(3,DBTextResource.ParseUI_s(GetReaderString(reader, "icon3"), 0));

                        if (mInfos.ContainsKey(info.Id) == false)
                        {
                            mInfos.Add(info.Id, info);
                        }
                    }
                }
            }
        }

        public DBGoodsVocationIconItem GetOneInfo(uint icon_id)
        {
            DBGoodsVocationIconItem info;
            if (mInfos.TryGetValue(icon_id, out info))
            {
                return info;
            }
            return null;
        }
    }
}
