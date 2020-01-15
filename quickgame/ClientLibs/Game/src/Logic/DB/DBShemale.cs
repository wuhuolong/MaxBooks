/*----------------------------------------------------------------
// 文件名： DBShemale.cs
// 文件功能描述： 机器人配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBShemale : DBSqliteTableResource
    {
        public static DBShemale Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBShemale>();
            }
        }

        public class ShemaleInfo
        {
            public uint Id;             // id
            public uint Rid;            // 职业
            public List<uint> Shows;    // 外观列表
		}
		Dictionary<uint, ShemaleInfo> mShemaleInfos = new Dictionary<uint, ShemaleInfo>();

        public DBShemale(string strName, string strPath)
            : base(strName, strPath)
		{
        }

		/// <summary>
		/// 获取某个机器人的信息
		/// </summary>
		/// <returns>The instance info.</returns>
		/// <param name="id">Identifier.</param>
		public ShemaleInfo GetShemaleInfo(uint id)
		{
            ShemaleInfo info = null;
            if (mShemaleInfos.TryGetValue(id, out info))
            {
                return info;
            }

            string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, queryStr);
            if (table_reader == null)
            {
                mShemaleInfos.Add(id, null);
                return null;
            }

            if (!table_reader.HasRows)
            {
                mShemaleInfos.Add(id, null);
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                mShemaleInfos.Add(id, null);
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            info = new ShemaleInfo();

            info.Id = GetReaderUint(table_reader, "id");
            info.Rid = DBTextResource.ParseUI_s(GetReaderString(table_reader, "rid"), 0);
            info.Shows = DBTextResource.ParseArrayUint(GetReaderString(table_reader, "show"), ",");

#if UNITY_EDITOR
            if (mShemaleInfos.ContainsKey(info.Id))
            {
                GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.Id));
                return info;
            }
#endif
            mShemaleInfos.Add(info.Id, info);

            table_reader.Close();
            table_reader.Dispose();

            return info;
        }

        public override void Unload()
        {
            base.Unload();
            mShemaleInfos.Clear();
        }

        public override void Load()
        {
            IsLoaded = true;
        }
	}
}
