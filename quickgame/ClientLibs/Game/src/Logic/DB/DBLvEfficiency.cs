
/*----------------------------------------------------------------
// 文件名： DBLvEfficiency.cs
// 文件功能描述： 圣痕
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBLvEfficiency : DBSqliteTableResource
    {
        public class DBLvEfficiencyInfo
        {
            public uint Lv;                    // Lv
            public float Exp;
            public float Coin;
            
        }
        Dictionary<uint, DBLvEfficiencyInfo> mInfos = new Dictionary<uint, DBLvEfficiencyInfo>();

        public DBLvEfficiency(string strName, string strPath)
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
            
            
            DBLvEfficiencyInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBLvEfficiencyInfo();

                        info.Lv = DBTextResource.ParseUI_s(GetReaderString(reader, "Lv"), 0);
                        info.Exp = GetReaderFloat(reader, "exp");
                        info.Coin = GetReaderFloat(reader, "coin");
                        if (mInfos.ContainsKey(info.Lv) == false)
                        {
                            mInfos.Add(info.Lv, info);
                        }
                        else
                            GameDebug.LogError("DBLvEfficiency has the same lv data " + info.Lv);
                    }
                }
            }
        }

        public DBLvEfficiencyInfo GetOneDBLvEfficiencyInfo(uint id)
        {
            DBLvEfficiencyInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            return null;
        }
    }
}
