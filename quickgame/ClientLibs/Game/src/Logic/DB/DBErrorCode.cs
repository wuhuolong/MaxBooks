/*----------------------------------------------------------------
// 文件名： DBErrorCode.cs
// 文件功能描述： 系统错误表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBErrorCode : DBSqliteTableResource
    {
        public class ErrorInfo
		{
			public uint mId;                        // id
            public string mName;                    // 名字
            public string mDesc;                    // 描述
		}
        Dictionary<uint, ErrorInfo> mErrorInfos = new Dictionary<uint, ErrorInfo>();

        public DBErrorCode(string strName, string strPath)
            : base(strName, strPath)
		{
		}

        /// <summary>
        /// 获取错误信息详情
        /// </summary>
        /// <returns>The error info.</returns>
        /// <param name="id">Identifier.</param>
        public ErrorInfo GetErrorInfo(uint id)
        {
            ErrorInfo info = null;
            if (!mErrorInfos.TryGetValue(id, out info))
                info = GetItemInfo(id);
            
            return info;
        }

        public static string GetErrorString(uint id)
        {
            var db = DBManager.Instance.GetDB<DBErrorCode>();
            var info = db.GetErrorInfo(id);
            if (info != null)
                return info.mDesc;

            return string.Empty;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            base.Unload();
            mErrorInfos.Clear();
        }

        ErrorInfo GetItemInfo(uint id)
		{
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mErrorInfos[id] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mErrorInfos[id] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }


            ErrorInfo info = new ErrorInfo();
            info.mId = id;
            info.mName = GetReaderString(reader, "name");
            info.mDesc = GetReaderString(reader, "desc");

            mErrorInfos.Add(info.mId, info);

            reader.Close();
            reader.Dispose();
            return info;
        }
	}
}
