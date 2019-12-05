
/*----------------------------------------------------------------
// 文件名： DBShiftStateControl.cs
// 文件功能描述： 变身状态控制表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBShiftStateControl : DBSqliteTableResource
    {
        public class ShiftStateInfo
        {
            public uint state;
            public uint target_type;
        }
        public Dictionary<uint, ShiftStateInfo> mInfos = new Dictionary<uint, ShiftStateInfo>();

        public DBShiftStateControl(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        static DBShiftStateControl mInstance;
        public static DBShiftStateControl Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new DBShiftStateControl(GlobalConfig.DBFile, "shift_state_control");

                return mInstance;
            }
        }

        public ShiftStateInfo GetInfo(uint state)
        {
            ShiftStateInfo info;
            if (mInfos.TryGetValue(state, out info))
            {
                return info;
            }

            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "shift_state", state);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mInfos[state] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[state] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new ShiftStateInfo();

            info.state = DBTextResource.ParseUI_s(GetReaderString(reader, "shift_state"), 0);
            info.target_type = DBTextResource.ParseUI_s(GetReaderString(reader, "target_type"), 0);

            mInfos[info.state] = info;

            reader.Close();
            reader.Dispose();
            return info;
        }
    }
}
