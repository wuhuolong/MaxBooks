using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    public class DBFlyWord : DBSqliteTableResource
    {
        private static string TableName = "data_fly_word";

        private Dictionary<uint, string> mInfosDic = new Dictionary<uint, string>();

        public DBFlyWord(string strName, string strPath)
           : base(strName, strPath)
        {
        }

        public override void Load() // 不进行预加载
        {

        }

        public override void Unload()
        {
            base.Unload();

            mInfosDic.Clear();

        }


        public string GetFlyWordKey(uint id)
        {
            string key = null;
            if (!mInfosDic.TryGetValue(id, out key))
            {
                string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" ", TableName, "id", id.ToString());
                var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, TableName, query_str);
                if (table_reader == null)
                {
                    mInfosDic[id] = null;
                    return null;
                }

                if (!table_reader.HasRows)
                {
                    mInfosDic[id] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                if (!table_reader.Read())
                {
                    mInfosDic[id] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                mInfosDic.Add(id, GetReaderString(table_reader, "name"));
                table_reader.Close();
                table_reader.Dispose();
            }
            return key;
        }

        public static string GetFlyWordById(uint id)
        {
            var db = DBManager.Instance.GetDB<DBFlyWord>();
            string key = db.GetFlyWordKey(id);
            if (key != null)
            {
                return DBConstText.GetText(key);
            }
            return "";
        }
    }
}
