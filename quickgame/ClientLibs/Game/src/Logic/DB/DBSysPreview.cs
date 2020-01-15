using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSysPreview : DBSqliteTableResource
    {
        public class DBSysPreviewInfo
        {
            public uint SysId;
            public string Notice;
            public string UiNotice;
            public uint RewardId;
            public string SysDesc;
        }

        public Dictionary<uint, DBSysPreviewInfo> Data = new Dictionary<uint, DBSysPreviewInfo>();

        public DBSysPreview(string strName, string strPath) : base(strName, strPath)
        {

        }

        public DBSysPreviewInfo GetData(uint id)
        {
            DBSysPreviewInfo info = null;
            Data.TryGetValue(id, out info);
            return info;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            while (reader.Read())
            {
                DBSysPreviewInfo info = new DBSysPreviewInfo();
                info.SysId = DBTextResource.ParseUI(GetReaderString(reader, "sys_id"));
                info.Notice = GetReaderString(reader, "notice");
                info.UiNotice = GetReaderString(reader, "ui_notice");
                info.RewardId = DBTextResource.ParseUI(GetReaderString(reader, "reward_id"));
                info.SysDesc = GetReaderString(reader, "sys_desc");

                Data.Add(info.SysId, info);
            }
        }

        public override void Unload()
        {
            Data.Clear();
        }
    }
}