
/*----------------------------------------------------------------
// 文件名： DBGoodsName.cs
// 文件功能描述： 物品名字搜索表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    public class DBGoodsName : DBSqliteTableResource
    {
        private Dictionary<string, List<uint>> mInfos = new Dictionary<string, List<uint>>();
        public DBGoodsName(string strName, string strPath) : base(strName, strPath)
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

        /// <summary>
        /// 获取指定搜索名字对应的物品ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<uint> GetGidArray(string name)
        {
            List<uint> info = null;
            if (mInfos.TryGetValue(name, out info))
            {
                return info;
            }
            else
            {
                string query_str = string.Format("SELECT {0}.{1} FROM {0} WHERE {0}.{2}=\"{3}\"", "goods_name_index", "gid", "name", name);
                var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.GoodsNameDBFile, "goods_name_index", query_str);
                if (table_reader == null)
                {
                    mInfos[name] = null;
                    return null;
                }

                if (!table_reader.HasRows)
                {
                    mInfos[name] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                if (!table_reader.Read())
                {
                    mInfos[name] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                var gid = GetReaderString(table_reader, "gid");
                info = DBTextResource.ParseArrayUint(gid, ",", false);
                mInfos[name] = info;

                table_reader.Close();
                table_reader.Dispose();

                return info;
            }
        }
    }
}
