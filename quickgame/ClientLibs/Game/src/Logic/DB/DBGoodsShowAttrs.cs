//------------------------------------------
// File : DBGoodsShowAttrs.cs
// Desc: 物品使用后增加的属性（前端显示用）
// Author: lijiayong
// Date: 2018.10.26
//------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text.RegularExpressions;

namespace xc
{
    public class DBGoodsShowAttrs : DBSqliteTableResource
    {
        public static DBGoodsShowAttrs Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBGoodsShowAttrs>();
            }
        }

        Dictionary<uint, ActorAttribute> mGoodsShowAttrsInfos = new Dictionary<uint, ActorAttribute>();

        public DBGoodsShowAttrs(string strName, string strPath) : base(strName, strPath)
        {

        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public ActorAttribute GetGoodsShowAttr(uint gid)
        {
            ActorAttribute attr = null;
            if (mGoodsShowAttrsInfos.TryGetValue(gid, out attr))
                return attr;

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "gid", gid.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (table_reader == null)
            {
                mGoodsShowAttrsInfos[gid] = null;
                return null;
            }

            if(!table_reader.HasRows)
            {
                mGoodsShowAttrsInfos[gid] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                mGoodsShowAttrsInfos[gid] = null;
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            attr = new ActorAttribute();
            string attrsStr = GetReaderString(table_reader, "attrs");
            attrsStr = attrsStr.Replace(" ", "");
            var matchs = Regex.Matches(attrsStr, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                    attr.Add(attrId, attrValue);
                }
            }

            mGoodsShowAttrsInfos[gid] = attr;

            table_reader.Close();
            table_reader.Dispose();

            return attr;
        }
    }
}