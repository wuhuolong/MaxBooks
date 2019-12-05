
//---------------------------------------
// File:    DBTrialBossDifficulty.cs
// Desc:    试炼BOSS难度
// Author:  xusong
// Date:    2017.11.1
//---------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using Mono.Data.Sqlite;
namespace xc
{
    public class DBTrialBossDifficulty : DBSqliteTableResource
    {
        public class DBTrialBossDifficultyItem
        {
            public uint DifficultyId; //难度ID
            public string Name;       //名字
            public uint Color;      //颜色
        }
        private Dictionary<uint, DBTrialBossDifficultyItem> mInfos = new Dictionary<uint, DBTrialBossDifficultyItem>();

        public DBTrialBossDifficulty(string strName, string strPath)
            : base(strName, strPath)
        {

        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
        }
        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public DBTrialBossDifficultyItem GetItem(uint diff_id)
        {
            DBTrialBossDifficultyItem item;

            if (mInfos.TryGetValue(diff_id, out item))
                return item;

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", diff_id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[diff_id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[diff_id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            var tmp_info = new DBTrialBossDifficultyItem();
            tmp_info.DifficultyId = DBTextResource.ParseUI(GetReaderString(reader, "id"));
            tmp_info.Name = GetReaderString(reader, "name");
            tmp_info.Color = DBTextResource.ParseUI(GetReaderString(reader, "color"));

            if (mInfos.ContainsKey(tmp_info.DifficultyId) == false)
            {
                mInfos.Add(tmp_info.DifficultyId, tmp_info);
            }
            else
                GameDebug.LogError("DBTrialBossDifficulty contain the same info; DifficultyId = " + tmp_info.DifficultyId);

            reader.Close();
            reader.Dispose();

            return tmp_info;
        }
    }
}