
/*----------------------------------------------------------------
// 文件名： DBFightEfffectLayout.cs
// 文件功能描述： 战斗飘字的布局
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBFightEfffectLayout : DBSqliteTableResource
    {
        public class DBFightEfffectLayoutItem
        {
            public string FightTypeStr;
            public int Level;
        }
        Dictionary<string, DBFightEfffectLayoutItem> mInfos = new Dictionary<string, DBFightEfffectLayoutItem>();

        public DBFightEfffectLayout(string strName, string strPath)
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

            DBFightEfffectLayoutItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBFightEfffectLayoutItem();
                        info.FightTypeStr = GetReaderString(reader, "type");
                        info.Level = DBTextResource.ParseI_s(GetReaderString(reader, "level"), 0);
                        
                        if (info.FightTypeStr != null && mInfos.ContainsKey(info.FightTypeStr) == false)
                            mInfos[info.FightTypeStr] = info;
                    }
                }
            }
        }

        public DBFightEfffectLayoutItem GetOneItem(string fight_type_str)
        {
            DBFightEfffectLayoutItem item;
            if (mInfos.TryGetValue(fight_type_str, out item) == false)
            {
                return null;
            }
            return item;
        }
    }
}
