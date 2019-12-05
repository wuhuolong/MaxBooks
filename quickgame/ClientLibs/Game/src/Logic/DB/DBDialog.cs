/*----------------------------------------------------------------
// 文件名： DBDialog.cs
// 文件功能描述： 对话配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBDialog : DBSqliteTableResource
    {
        public enum EDialogType : byte
        {
            IST_DialogBox = 1,  // 对话框
            IST_Bubble,         // 冒泡
        }

		public class DialogInfo
		{
			public uint mId;                                // id
            public EDialogType mType;                       // 对话类型
			public List<uint> mDialogs = new List<uint>();	// 对话剧本
            public uint mAutoRunTime;                       // 自动执行的时间，单位秒，0为不自动执行（只对对话框类型有效）
        }
        Dictionary<uint, DialogInfo> mDialogInfos = new Dictionary<uint, DialogInfo>();

        public DBDialog(string strName, string strPath)
            : base(strName, strPath)
        {
		}

        /// <summary>
        /// 获取相应的对话
        /// </summary>
        /// <returns>The dialog.</returns>
        /// <param name="dialogId">Dialog identifier.</param>
        public DialogInfo GetDialog(uint dialogId)
        {
            DialogInfo info = null;
            if (!mDialogInfos.TryGetValue(dialogId, out info))
                info = GetItemInfo(dialogId);

            return info;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mDialogInfos.Clear();
        }

        DialogInfo GetItemInfo(uint id)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mDialogInfos[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mDialogInfos[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            DialogInfo info = new DialogInfo();

            info.mId = id;
            info.mType = (EDialogType)System.Enum.Parse(typeof(EDialogType), GetReaderString(reader, "type"));
            info.mDialogs = DBTextResource.ParseArrayUint(GetReaderString(reader, "dialogs"), ",");
            info.mAutoRunTime = DBTextResource.ParseUI_s(GetReaderString(reader, "auto_tun_time"), 0);
            mDialogInfos.Add(info.mId, info);

            reader.Close();
            reader.Dispose();
            return info;
        }
    }
}
