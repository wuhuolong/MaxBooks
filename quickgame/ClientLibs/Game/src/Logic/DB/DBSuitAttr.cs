
/*----------------------------------------------------------------
// 文件名： DBSuitAttr.cs
// 文件功能描述： 套装属性配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSuitAttr : DBSqliteTableResource
    {
        public class DBSuitAttrInfo
        {
            public string CsvId;                // csv id
            public uint Id;                     // 套装id
            public uint Lv;                     // 等级
            public byte Num;                    // 套装数量
            public uint EffectId;               // 特效id
            public ActorAttribute BasicAttrs;   // 属性
        }
        
        Dictionary<uint, List<DBSuitAttrInfo>> mInfos = new Dictionary<uint, List<DBSuitAttrInfo>>();

        public DBSuitAttr(string strName, string strPath)
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

        uint MakeUID(uint id, uint lv)
        {
            return id * 100 + lv;
        }

        List<DBSuitAttrInfo> GetItemInfo(uint id, uint lv)
        {
            uint uid = MakeUID(id, lv);
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"", mTableName, "id", id, "lv", lv);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[uid] = null;
                return null;
            }

            if (!reader.HasRows)
            {
                mInfos[uid] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            List<DBSuitAttrInfo> attrInfos = null;

            while (reader.Read())
            {
                DBSuitAttrInfo info = new DBSuitAttrInfo();
                info.Id = id;
                info.Lv = lv;
                info.Num = DBTextResource.ParseBT_s(GetReaderString(reader, "num"), 0);
                info.EffectId = DBTextResource.ParseUI_s(GetReaderString(reader, "effect_id"), 0);

                string raw = GetReaderString(reader, "base_attr");
                raw = raw.Replace(" ", "");
                var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
                info.BasicAttrs = new ActorAttribute();
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        var attrVal = DBTextResource.ParseUI(_match.Groups[2].Value);
                        info.BasicAttrs.Add(attrId, attrVal);
                    }
                }

                if (attrInfos == null)
                    attrInfos = new List<DBSuitAttrInfo>();

                attrInfos.Add(info);
            }

            mInfos[uid] = attrInfos;
            reader.Close();
            reader.Dispose();
            return attrInfos;
        }

        public List<DBSuitAttrInfo> GetAttrInfos(uint suitid,uint suitlv)
        {
            uint uid = MakeUID(suitid, suitlv);
            List<DBSuitAttrInfo> infos = null;
            if (!mInfos.TryGetValue(uid, out infos))
                infos = GetItemInfo(suitid, suitlv);

            return infos;
        }
    }
}
