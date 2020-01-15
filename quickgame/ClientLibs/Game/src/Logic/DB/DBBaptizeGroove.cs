
/*----------------------------------------------------------------
// 文件名： DBBaptizeGroove.cs
// 文件功能描述： 洗练槽配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBBaptizeGroove : DBSqliteTableResource
    {
        public class DBBaptizeGrooveInfo
        {
            public uint Id;                     // 槽位
            public Dictionary<uint, uint> Cost; // 开启消耗
            public uint AttrAddition;           // 属性加成
            public uint BaseRank;               // 洗练槽基础评分
        }
        
        public Dictionary<uint, DBBaptizeGrooveInfo> mInfos = new Dictionary<uint, DBBaptizeGrooveInfo>();

        public DBBaptizeGroove(string strName, string strPath)
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
            DBBaptizeGrooveInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBBaptizeGrooveInfo();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Cost = DBTextResource.ParseDictionaryUintUint(GetReaderString(reader, "cost"));
                        info.AttrAddition = DBTextResource.ParseUI_s(GetReaderString(reader, "attr_addition"), 0);
                        info.BaseRank = DBTextResource.ParseUI_s(GetReaderString(reader, "base_rank"), 0);

                        mInfos[info.Id] = info;
                    }
                }
            }
        }

        /// <summary>
        /// 获取一个洗练槽信息
        /// </summary>
        /// <param name="posId"></param>
        /// <returns></returns>
        public DBBaptizeGrooveInfo GetOneInfo(uint id)
        {
            DBBaptizeGrooveInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            return null;
        }


        /// <summary>
        /// 所有洗练槽信息
        /// </summary>
        public Dictionary<uint, DBBaptizeGrooveInfo> AllInfos
        {
            get
            {
                return mInfos;
            }
        }
    }
}
