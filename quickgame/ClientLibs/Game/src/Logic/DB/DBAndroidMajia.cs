using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBAndroidMajia : DBSqliteTableResource
    {
        public class DBAndroidMajiaItem
        {
            public uint AppID;      // sdk app id
            public bool ShowUserCenter; // 显示用户中心
            public bool ShowLogo;  // 显示Logo
            public bool ShowKv;  // 显示kv
            public bool ShowEffect; // 显示特效
        }

        public Dictionary<uint, DBAndroidMajiaItem> data;

        public DBAndroidMajia(string strName, string strPath) : base(strName, strPath)
        {
            data = new Dictionary<uint, DBAndroidMajiaItem>();
        }

        public static DBAndroidMajia Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBAndroidMajia>();
            }
        }

        public DBAndroidMajiaItem GetData(uint app_id)
        {
            DBAndroidMajiaItem ad = null;
            if (!data.TryGetValue(app_id, out ad))
                ad = GetItemInfo(app_id);

            return ad;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        private DBAndroidMajiaItem GetItemInfo(uint app_id)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "app_id", app_id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                data[app_id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                data[app_id] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            DBAndroidMajiaItem ad = new DBAndroidMajiaItem();
            ad.AppID = app_id;
            ad.ShowUserCenter = DBTextResource.ParseUI(GetReaderString(reader, "show_user_center")) == 1;
            ad.ShowLogo = DBTextResource.ParseUI(GetReaderString(reader, "show_logo")) == 1;
            ad.ShowKv = DBTextResource.ParseUI(GetReaderString(reader, "show_kv")) == 1;
            ad.ShowEffect = DBTextResource.ParseUI(GetReaderString(reader, "show_effect")) == 1;
            data.Add(ad.AppID, ad);

            reader.Close();
            reader.Dispose();
            return ad;
        }

        public override void Unload()
        {
            data.Clear();
        }
    }
}
