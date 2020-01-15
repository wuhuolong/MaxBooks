/*----------------------------------------------------------------
// 文件名： DBDeadSpaceLv.cs
// 作者：Kevin
// 文件功能描述： 破碎死域配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBDeadSpaceLv : DBSqliteTableResource
    {
        public static DBDeadSpaceLv Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBDeadSpaceLv>();
            }
        }

        public class DeadSpaceLvInfo : IComparable
        {
            public uint Id;
            public uint Score;
            public List<uint> mRewards;
            public string Name;
            public uint Grid;

            public int CompareTo(object targetObj)
            {
                int result = 1;
                DeadSpaceLvInfo targetInfo = targetObj as DeadSpaceLvInfo;

                if (targetInfo.Id < this.Id)
                {
                    result = 1;
                }
                else if (targetInfo.Id == this.Id)
                {
                    result = 0;
                }
                else
                {
                    result = -1;
                }

                return result;
            }
        }

        private Dictionary<uint, DeadSpaceLvInfo> mDeadSpaceLvInfos = new Dictionary<uint, DeadSpaceLvInfo>();
        private DeadSpaceLvInfo mMaxScoreDeadSpaceLvInfo;

        public DBDeadSpaceLv(string strName, string strPath)
            : base(strName,strPath)
        {
            
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (mDeadSpaceLvInfos != null)
            {
                mDeadSpaceLvInfos.Clear();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        DeadSpaceLvInfo info = new DeadSpaceLvInfo();

                        info.Id = DBTextResource.ParseUI(GetReaderString(reader, "id"));
                        info.Score = DBTextResource.ParseUI(GetReaderString(reader, "score"));
                        info.mRewards = DBTextResource.ParseArrayUint(GetReaderString(reader, "reward"), ",");
                        info.Name = GetReaderString(reader, "name");
                        info.Grid = DBTextResource.ParseUI(GetReaderString(reader, "grid"));

                        mDeadSpaceLvInfos.Add(info.Id, info);
                    }
                }
            }

            mMaxScoreDeadSpaceLvInfo = null;
        }

        public override void Unload()
        {
            base.Unload();
            mDeadSpaceLvInfos.Clear();
        }

        public DeadSpaceLvInfo GetDeadSpaceLvInfo(uint id)
        {
            DeadSpaceLvInfo info = null;
            mDeadSpaceLvInfos.TryGetValue(id, out info);

            return info;
        }

        /// <summary>
        /// 获取最大积分的信息
        /// </summary>
        public DeadSpaceLvInfo GetMaxScoreDeadSpaceLvInfo()
        {
            if (mMaxScoreDeadSpaceLvInfo == null)
            {
                uint maxScore = 0;
                foreach (DeadSpaceLvInfo deadSpaceLvInfo in mDeadSpaceLvInfos.Values)
                {
                    if (maxScore < deadSpaceLvInfo.Score)
                    {
                        maxScore = deadSpaceLvInfo.Score;
                        mMaxScoreDeadSpaceLvInfo = deadSpaceLvInfo;
                    }
                }
            }

            return mMaxScoreDeadSpaceLvInfo;
        }
    }
}
