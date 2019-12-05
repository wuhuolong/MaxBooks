/*----------------------------------------------------------------
// 文件名： DBEngrave.cs
// 文件功能描述： 铭刻表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBEngrave : DBSqliteTableResource
    {
        public class EngraveInfo
        {
            public uint Id;                 // 铭刻id(物品表GID)
            public uint Type;               // 类型
            public ushort Lv;               // 等级
            public uint NextEngraveId;      // 下一等级铭刻id 
            public List<List<uint>> Attrs;  // 属性列表格式
        }

        private Dictionary<uint, EngraveInfo> mEngravenfos = new Dictionary<uint, EngraveInfo>();

        public DBEngrave(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public EngraveInfo GetEngraveInfoByGid(uint gid)
        {
            EngraveInfo value;
            mEngravenfos.TryGetValue(gid, out value);

            return value;
        }

        /// <summary>
        /// 根据铭刻类型返回信息列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<EngraveInfo> GetEngraveInfosByType(uint type)
        {
            List<EngraveInfo> ret = new List<EngraveInfo>();
            ret.Clear();

            foreach (EngraveInfo gemInfo in mEngravenfos.Values)
            {
                if (gemInfo.Type == type)
                {
                    ret.Add(gemInfo);
                }
            }

            return ret;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mEngravenfos.Clear();
            EngraveInfo gemInfo = null;

            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        gemInfo = new EngraveInfo();
                        gemInfo.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        gemInfo.Type = DBTextResource.ParseBT_s(GetReaderString(reader, "type"), 0);
                        gemInfo.Lv = DBTextResource.ParseUS_s(GetReaderString(reader, "lv"), 0);
                        gemInfo.NextEngraveId = DBTextResource.ParseUI_s(GetReaderString(reader, "next_engrave_id"), 0);
                        gemInfo.Attrs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "attr"));

                        mEngravenfos.Add(gemInfo.Id, gemInfo);
                    }
                }
            }
        }
    }
}
