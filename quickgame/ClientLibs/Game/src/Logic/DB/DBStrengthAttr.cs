/*----------------------------------------------------------------
// 文件名： DBStrengthAttr.cs
// 文件功能描述： 强化属性表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text.RegularExpressions;

namespace xc
{
	public class DBStrengthAttr : DBSqliteTableResource
    {
		private Dictionary<string, ActorAttribute> mStrengthAttrs = new Dictionary<string, ActorAttribute>();

		public DBStrengthAttr(string strName, string strPath)
			: base(strName, strPath)
		{
		}

        public static ActorAttribute GetStrengthAttr(uint lv, uint equipPos)
        {
            return DBManager.Instance.GetDB<DBStrengthAttr>().StrengthAttr(lv, equipPos);
        }

        public ActorAttribute StrengthAttr(uint lv, uint equipPos)
		{
            string key = string.Format("{0}_{1}", lv, equipPos);
            ActorAttribute attr = null;
            if (mStrengthAttrs.TryGetValue(key, out attr) == true)
            {
                return attr;
            }

            attr = new ActorAttribute();

            List<string> dbs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_strength_attr", "csv_id", key, "base_attr");
            if (dbs.Count == 0)
            {
                mStrengthAttrs.Add(key, attr);
                return attr;
            }

            string raw = dbs[0];
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                    attr.Add(attrId, attrValue);
                }
            }

            mStrengthAttrs.Add(key, attr);
            return attr;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mStrengthAttrs.Clear();
            //if (reader != null)
            //{
            //    if (reader.HasRows == true)
            //    {
            //        while (reader.Read())
            //        {
            //            ActorAttribute attr = new ActorAttribute();

            //            uint lv = DBTextResource.ParseUI(GetReaderString(reader, "lv"));
            //            uint equipPos = DBTextResource.ParseUI(GetReaderString(reader, "pos"));

            //            string raw = GetReaderString(reader, "base_attr");
            //            raw = raw.Replace(" ", "");
            //            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            //            foreach (Match _match in matchs)
            //            {
            //                if (_match.Success)
            //                {
            //                    uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
            //                    uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
            //                    attr.Add(attrId, attrValue);
            //                }
            //            }

            //            string key = string.Format("{0}_{1}", lv, equipPos);
            //            mStrengthAttrs.Add(key, attr);
            //        }
            //    }
            //}
        }
	}
}
