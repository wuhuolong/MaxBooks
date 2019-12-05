/*----------------------------------------------------------------
// 文件名： DBMonster.cs
// 文件功能描述： 怪物组表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBMonster : DBSqliteTableResource
    {
        public class MonsterInfo
        {
			public uint Id;
            public uint Times;
            public uint Num;
            public uint ActorId;
        }
        Dictionary<uint, MonsterInfo> mMonsterInfos = new Dictionary<uint, MonsterInfo>();

        public DBMonster(string strName, string strPath)
            : base(strName, strPath)
		{
		}

        public MonsterInfo GetMonsterInfo(uint id)
        {
            if (mMonsterInfos.ContainsKey(id) == true)
            {
                return mMonsterInfos[id];
            }

            return null;
        }

        public override void Unload()
        {
            base.Unload();
            mMonsterInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mMonsterInfos.Clear();
            MonsterInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new MonsterInfo();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Times = DBTextResource.ParseUI_s(GetReaderString(reader, "times"), 0);
                        info.Num = DBTextResource.ParseUI_s(GetReaderString(reader, "num"), 0);
                        info.ActorId = DBTextResource.ParseUI_s(GetReaderString(reader, "actor"), 0);

//#if UNITY_EDITOR
                        if (mMonsterInfos.ContainsKey(info.Id))
                        {
                            GameDebug.LogWarning(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.Id));
                            continue;
                        }
//#endif
                        mMonsterInfos.Add(info.Id, info);
                    }
                }
			}
		}
	}
}
