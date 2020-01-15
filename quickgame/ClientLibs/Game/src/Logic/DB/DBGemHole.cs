/*----------------------------------------------------------------
// 文件名： DBGemHole.cs
// 文件功能描述： 宝石孔表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
	public class DBGemHole : DBSqliteTableResource
    {
        public class GemHoleInfo
        {
            public string CsvId;        // CSV id
            public byte Pos;            // 位置
            public byte HoleId;         // 孔位
            public uint LvStepLimit;    // 解锁条件-装备等阶
            public uint VipLimit;       // 解锁条件-VIP等级
            public List<uint> GemList;  // 可镶嵌宝石列表
        }

        private Dictionary<string, GemHoleInfo> mGemHoleInfos = new Dictionary<string, GemHoleInfo>();

        /// <summary>
        /// 装备的宝石孔数量
        /// </summary>
        private uint mGemHoleNum = 0;

		public DBGemHole(string strName, string strPath)
			: base(strName, strPath)
		{
		}

		public GemHoleInfo GetGemHoleInfo(byte pos, byte holeId)
		{
            GemHoleInfo value;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(pos);
            sb.Append("_");
            sb.Append(holeId);
            mGemHoleInfos.TryGetValue(sb.ToString(), out value);
			return value;
		}

        /// <summary>
        /// 获取装备的宝石孔数量
        /// </summary>
        /// <returns></returns>
        public uint GetGemHoleNum()
        {
            if (mGemHoleNum == 0)
            {
                foreach (GemHoleInfo info in mGemHoleInfos.Values)
                {
                    if (mGemHoleNum < info.HoleId)
                    {
                        mGemHoleNum = info.HoleId;
                    }
                }
            }

            return mGemHoleNum;
        }

		protected override void ParseData(SqliteDataReader reader)
        {
            mGemHoleInfos.Clear();
            GemHoleInfo gemHoleInfo = null;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        gemHoleInfo = new GemHoleInfo();
                        gemHoleInfo.Pos = DBTextResource.ParseBT_s(GetReaderString(reader, "pos"), 0);
                        gemHoleInfo.HoleId = DBTextResource.ParseBT_s(GetReaderString(reader, "hole_id"), 0);
                        gemHoleInfo.CsvId = string.Format("{0}_{1}", gemHoleInfo.Pos, gemHoleInfo.HoleId);
                        gemHoleInfo.LvStepLimit = DBTextResource.ParseUI_s(GetReaderString(reader, "lv_step_limit"), 0);
                        gemHoleInfo.VipLimit = DBTextResource.ParseUI_s(GetReaderString(reader, "vip_limit"), 0);
                        gemHoleInfo.GemList = DBTextResource.ParseArrayUint(GetReaderString(reader, "gem_list"), ",");

#if UNITY_EDITOR
                        if (mGemHoleInfos.ContainsKey(gemHoleInfo.CsvId))
                        {
                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, gemHoleInfo.CsvId));
                            continue;
                        }
#endif
                        mGemHoleInfos.Add(gemHoleInfo.CsvId, gemHoleInfo);
                    }
                }
			}
		}
	}
}
