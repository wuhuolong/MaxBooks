/*----------------------------------------------------------------
// 文件名： DBDialogContent.cs
// 文件功能描述： 对话内容配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBDialogContent : DBSqliteTableResource
    {
		public enum EDialogObjectType : byte
		{
			DOT_Player = 1,     // 主角
			DOT_Other = 2,      // 其他
            DOT_NPC = 3,        // NPC
            DOT_Monster = 4,    // 怪物
		}

        public class DialogContentInfo
		{
			public uint mId;                        // id
            public EDialogObjectType mObjectType;   // 说话对象
            public string mName;                    // 名字
            public uint mObjectParam;               // 对象参数
            public string mWords;                   // 对话内容
            public string mVoice;                   // 语音文件
            public uint mLength;                    // 长度（秒）
		}
        Dictionary<uint, DialogContentInfo> mDialogContentInfos = new Dictionary<uint, DialogContentInfo>();

        public DBDialogContent(string strName, string strPath)
            : base(strName, strPath)
		{
		}
        
        /// <summary>
        /// 获取对话剧本信息
        /// </summary>
        /// <returns>The dialog info.</returns>
        /// <param name="id">Identifier.</param>
        public DialogContentInfo GetDialogContentInfo(uint id)
        {
            //DialogContentInfo info = null;
            //if (mDialogContentInfos.TryGetValue(id, out info))
            //{
            //    return info;
            //}

            //return null;

            DialogContentInfo info = null;
            if (mDialogContentInfos.TryGetValue(id, out info))
            {
                return info;
            }

            string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id.ToString());
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, queryStr);
            if (reader == null)
            {
                mDialogContentInfos.Add(id, null);
                return null;
            }

            if (!reader.HasRows)
            {
                mDialogContentInfos.Add(id, null);
                reader.Close();
                reader.Dispose();
                return null;
            }

            if (!reader.Read())
            {
                mDialogContentInfos.Add(id, null);
                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new DialogContentInfo();

            info.mId = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            string objectStr = GetReaderString(reader, "object");
            if (string.IsNullOrEmpty(objectStr) == true)
            {
                GameDebug.LogError("Dialog content " + info.mId + " has a empty object param");
                info.mObjectType = EDialogObjectType.DOT_Player;
            }
            else
            {
                info.mObjectType = (EDialogObjectType)System.Enum.Parse(typeof(EDialogObjectType), objectStr);
            }

            info.mName = GetReaderString(reader, "name");
            info.mObjectParam = DBTextResource.ParseUI_s(GetReaderString(reader, "object_param"), 0);
            info.mWords = GetReaderString(reader, "words");
            info.mVoice = GetReaderString(reader, "voice");
            info.mLength = DBTextResource.ParseUI_s(GetReaderString(reader, "length"), 0);

#if UNITY_EDITOR
            if (mDialogContentInfos.ContainsKey(info.mId))
            {
                GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.mId));

                reader.Close();
                reader.Dispose();
                return info;
            }
#endif
            mDialogContentInfos.Add(info.mId, info);

            reader.Close();
            reader.Dispose();
            return info;
        }

        public override void Unload()
        {
            base.Unload();
            mDialogContentInfos.Clear();
        }

		protected override void ParseData(SqliteDataReader reader)
        {
            mDialogContentInfos.Clear();
//            DialogContentInfo info;
//            if (reader != null)
//            {
//                if (reader.HasRows == true)
//                {
//                    while (reader.Read())
//                    {
//                        info = new DialogContentInfo();

//                        info.mId = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
//                        string objectStr = GetReaderString(reader, "object");
//                        if (string.IsNullOrEmpty(objectStr) == true)
//                        {
//                            GameDebug.LogError("Dialog content " + info.mId + " has a empty object param");
//                            info.mObjectType = EDialogObjectType.DOT_Player;
//                        }
//                        else
//                        {
//                            info.mObjectType = (EDialogObjectType)System.Enum.Parse(typeof(EDialogObjectType), objectStr);
//                        }

//                        info.mName = GetReaderString(reader, "name");
//                        info.mObjectParam = DBTextResource.ParseUI_s(GetReaderString(reader, "object_param"), 0);
//                        info.mWords = GetReaderString(reader, "words");
//                        info.mVoice = GetReaderString(reader, "voice");
//                        info.mLength = DBTextResource.ParseUI_s(GetReaderString(reader, "length"), 0);

//#if UNITY_EDITOR
//                        if (mDialogContentInfos.ContainsKey(info.mId))
//                        {
//                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.mId));
//                            continue;
//                        }
//#endif
//                        mDialogContentInfos.Add(info.mId, info);
//                    }
//                }
//            }
		}

        public static DBDialogContent Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBDialogContent>();
            }
        }
	}
}
