using System;
using System.Collections.Generic;
namespace xc
{
    public class ClientAttrHelper 
    {
        public static uint GetID(string key)
        {
            uint result = 0;

            string raw = GetString(key , "id");

            uint.TryParse(raw, out result);

            return result;
        }

        public static uint GetValueType(string key)
        {
            uint result = 0;

            string raw = GetString(key, "val_type");

            uint.TryParse(raw, out result);

            return result;
        }


        public static uint GetValueType(uint id)
        {
            uint result = 0;

            List<string> retStrs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_client_attr", "id", id.ToString(), "val_type");
            if (retStrs.Count == 0)
            {
                GameDebug.LogError("Can not find game const value by id: " + id);
                return 0;
            }
            string raw = retStrs[0];
            uint.TryParse(raw, out result);
            return result;
        }

        public static string GetString(string key , string str)
        {
            List<string> retStrs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_client_attr", "macro", key, str);
            if (retStrs.Count == 0)
            {
                GameDebug.LogError("Can not find game const value by key: " + key);
                return "";
            }
            return retStrs[0];
        }
    }
}


