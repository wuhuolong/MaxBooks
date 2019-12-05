/*----------------------------------------------------------------
// 文件名： DBGem.cs
// 文件功能描述： 宝石表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
	public class DBGem : DBSqliteTableResource
    {
        public class GemInfo
        {
            public uint Id;                 // 宝石id
            public byte Type;               // 宝石类型
            public ushort Lv;               // 宝石等级
            public uint NextGemId;          // 可升级成宝石id
            public List<List<uint>> Attrs;  // 属性列表格式
            public string TypeName;         // type_name
        }

        private Dictionary<uint, GemInfo> mGemInfos = new Dictionary<uint, GemInfo>();

		public DBGem(string strName, string strPath)
			: base(strName, strPath)
		{
		}

		public GemInfo GetGemInfo(uint id)
		{
            GemInfo value;
            mGemInfos.TryGetValue(id, out value);
			return value;
		}

        /// <summary>
        /// 根据宝石类型返回宝石信息的列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<GemInfo> GetGemInfosByType(byte type)
        {
            List<GemInfo> gemInfos = new List<GemInfo>();
            gemInfos.Clear();

            foreach (GemInfo gemInfo in mGemInfos.Values)
            {
                if (gemInfo.Type == type)
                {
                    gemInfos.Add(gemInfo);
                }
            }

            return gemInfos;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mGemInfos.Clear();
            GemInfo gemInfo = null;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        gemInfo = new GemInfo();
                        gemInfo.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        gemInfo.Type = DBTextResource.ParseBT_s(GetReaderString(reader, "type"), 0);
                        gemInfo.Lv = DBTextResource.ParseUS_s(GetReaderString(reader, "lv"), 0);
                        gemInfo.NextGemId = DBTextResource.ParseUI_s(GetReaderString(reader, "next_gem_id"), 0);
                        gemInfo.Attrs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "attr"));
                        gemInfo.TypeName = GetReaderString(reader, "type_name");

#if UNITY_EDITOR
                        if (mGemInfos.ContainsKey(gemInfo.Id))
                        {
                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, gemInfo.Id));
                            continue;
                        }
#endif
                        mGemInfos.Add(gemInfo.Id, gemInfo);
                    }
                }
			}
		}
	}
}
