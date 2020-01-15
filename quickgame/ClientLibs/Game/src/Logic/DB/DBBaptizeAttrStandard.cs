
/*----------------------------------------------------------------
// 文件名： DBBaptizeAttrStandard.cs
// 文件功能描述： 洗练属性标准值配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBBaptizeAttrStandard : DBSqliteTableResource
    {
        public class DBBaptizeAttrStandardInfo
        {
            public uint LvStep;                                 // 等阶
            public ActorAttribute BaseAttrs;                    // 属性
        }
        
        private Dictionary<uint, DBBaptizeAttrStandardInfo> mInfos = new Dictionary<uint, DBBaptizeAttrStandardInfo>();

        public DBBaptizeAttrStandard(string strName, string strPath)
            : base(strName, strPath)
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
        }

        DBBaptizeAttrStandardInfo GetItemInfo(uint id)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "lv_step", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[id] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            DBBaptizeAttrStandardInfo info = new DBBaptizeAttrStandardInfo();

            info.LvStep = id;

            info.BaseAttrs = new ActorAttribute();
            string raw = GetReaderString(reader, "base_attr");
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint attrVal = DBTextResource.ParseUI(_match.Groups[2].Value);

                    info.BaseAttrs.Add(attrId, attrVal);
                }
            }

            mInfos[info.LvStep] = info;

            reader.Close();
            reader.Dispose();
            return info;
        }

        /// <summary>
        /// 获取一个洗练属性标准值配置信息
        /// </summary>
        /// <param name="posId"></param>
        /// <returns></returns>
        public DBBaptizeAttrStandardInfo GetOneInfo(uint id)
        {
            DBBaptizeAttrStandardInfo info = null;
            if (!mInfos.TryGetValue(id, out info))
            {
                info = GetItemInfo(id);
            }

            return info;
        }
    }
}
