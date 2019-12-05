/*----------------------------------------------------------------
// 文件名： DBInstancePhase.cs
// 文件功能描述： 副本阶段表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBInstancePhase : DBSqliteTableResource
    {
        public class InstancePhaseInfo
        {
            public string CsvId;
			public uint Id;
            public uint Phase;
            public string Mark1;
            public string Mark2;
            public string Mark3;
            public string Mark4;
            public string Mark5;
            public string Desc;
            public string Tips;
            public string TargetStr;
            private uint mTargetNum = 0;  // 目标数量，根据配置自己算出来
            public uint TargetNum
            {
                get
                {
                    if (mTargetNum == 0)
                    {
                        mTargetNum = CalcTargetNum(Id, TargetStr);
                    }
                    return mTargetNum;
                }
            }

            uint CalcTargetNum(uint instanceId, string targetStr)
            {
                uint targetNum = 0;
                Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(instanceId));
                if (levelData == null)
                {
                    return targetNum;
                }
                if (targetStr == "kill_all")
                {
                    Dictionary<int, Neptune.BaseGenericNode> monsters = levelData.GetData<Neptune.MonsterBase>().Data;
                    foreach (var monsterBase in monsters.Values)
                    {
                        if (monsterBase is Neptune.Monster)
                        {
                            ++targetNum;
                        }
                        else if (monsterBase is Neptune.MonsterGroup)
                        {
                            Neptune.MonsterGroup monsterGroup = (Neptune.MonsterGroup)monsterBase;
                            DBMonster dbMonster = DBManager.Instance.GetDB<DBMonster>();
                            DBMonster.MonsterInfo monsterInfo = dbMonster.GetMonsterInfo(monsterGroup.ExcelId);
                            if (monsterInfo != null)
                            {
                                targetNum += monsterInfo.Num;
                            }
                        }
                    }
                }
                else
                {
                    var matchs = System.Text.RegularExpressions.Regex.Matches(targetStr, @"\{kill,(\S+)\}");
                    foreach (System.Text.RegularExpressions.Match match in matchs)
                    {
                        if (match.Success)
                        {
                            List<uint> ids = DBTextResource.ParseArrayUint(match.Groups[1].Value, ",");
                            foreach (uint id in ids)
                            {
                                Dictionary<int, Neptune.BaseGenericNode> monsters = levelData.GetData<Neptune.MonsterBase>().Data;
                                foreach (var monsterBase in monsters.Values)
                                {
                                    if (monsterBase.Id == id)
                                    {
                                        if (monsterBase is Neptune.Monster)
                                        {
                                            ++targetNum;
                                        }
                                        else if (monsterBase is Neptune.MonsterGroup)
                                        {
                                            Neptune.MonsterGroup monsterGroup = (Neptune.MonsterGroup)monsterBase;
                                            DBMonster dbMonster = DBManager.Instance.GetDB<DBMonster>();
                                            DBMonster.MonsterInfo monsterInfo = dbMonster.GetMonsterInfo(monsterGroup.ExcelId);
                                            if (monsterInfo != null)
                                            {
                                                targetNum += monsterInfo.Num;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return targetNum;
            }

            public string GetMarkStr(uint mark)
            {
                if (mark == 1)
                {
                    return Mark1;
                }
                else if (mark == 2)
                {
                    return Mark2;
                }
                else if (mark == 3)
                {
                    return Mark3;
                }
                else if (mark == 4)
                {
                    return Mark4;
                }
                else if (mark == 5)
                {
                    return Mark5;
                }
                else
                {
                    return Mark5;
                }
            }
        }
        Dictionary<string, InstancePhaseInfo> mInstancePhaseInfos = new Dictionary<string, InstancePhaseInfo>();
        Dictionary<uint, uint> mInstancePhaseCount = new Dictionary<uint, uint>(); // 保存每个副本的阶段数

        public DBInstancePhase(string strName, string strPath)
            : base(strName, strPath)
		{
		}

        public override void Unload()
        {
            base.Unload();
            mInstancePhaseInfos.Clear();
            mInstancePhaseCount.Clear();
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        public InstancePhaseInfo GetInstancePhaseInfo(uint instanceId, uint phase)
        {
            string csvId = instanceId + "-" + phase;
            if (mInstancePhaseInfos.ContainsKey(csvId) == true)
            {
                return mInstancePhaseInfos[csvId];
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "csv_id", csvId.ToString());
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mInstancePhaseInfos[csvId] = null;
                return null;
            }

            if (!reader.HasRows)
            {
                mInstancePhaseInfos[csvId] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            if (!reader.Read())
            {
                mInstancePhaseInfos[csvId] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            InstancePhaseInfo info = new InstancePhaseInfo();

            info.CsvId = GetReaderString(reader, "csv_id");
            info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            info.Phase = DBTextResource.ParseUI_s(GetReaderString(reader, "phase"), 0);
            info.Mark1 = GetReaderString(reader, "mark_1");
            info.Mark2 = GetReaderString(reader, "mark_2");
            info.Mark3 = GetReaderString(reader, "mark_3");
            info.Mark4 = GetReaderString(reader, "mark_4");
            info.Mark5 = GetReaderString(reader, "mark_5");
            info.Desc = GetReaderString(reader, "desc");
            info.Tips = GetReaderString(reader, "tips");
            info.TargetStr = GetReaderString(reader, "target");
            mInstancePhaseInfos.Add(info.CsvId, info);

            reader.Close();
            reader.Dispose();

            return info;
        }

        public uint GetInstancePhaseCount(uint instanceId)
        {
            if (mInstancePhaseCount.ContainsKey(instanceId) == true)
            {
                return mInstancePhaseCount[instanceId];
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", instanceId.ToString());
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mInstancePhaseCount[instanceId] = 0;
                return 0;
            }

            if (!reader.HasRows)
            {
                mInstancePhaseCount[instanceId] = 0;
                reader.Close();
                reader.Dispose();
                return 0;
            }

            if (!reader.Read())
            {
                mInstancePhaseCount[instanceId] = 0;
                reader.Close();
                reader.Dispose();
                return 0;
            }

            uint count = 1;
            while (reader.Read())
            {
                ++count;
            }

            mInstancePhaseCount[instanceId] = count;
            reader.Close();
            reader.Dispose();

            return count;
        }

        public bool HavePhases(uint instanceId)
        {
            return GetInstancePhaseCount(instanceId) > 0;
            //foreach (InstancePhaseInfo instancePhaseInfo in mInstancePhaseInfos.Values)
            //{
            //    if (instancePhaseInfo.Id == instanceId)
            //    {
            //        return true;
            //    }
            //}

            //return false;
        }

        public uint PhasesCount(uint instanceId)
        {
            return GetInstancePhaseCount(instanceId);
            //uint count = 0;
            //foreach (InstancePhaseInfo instancePhaseInfo in mInstancePhaseInfos.Values)
            //{
            //    if (instancePhaseInfo.Id == instanceId)
            //    {
            //        count = count + 1;
            //    }
            //}

            //return count;
        }

        public bool IsLastPhase(uint instanceId, uint phase)
        {
            return GetInstancePhaseCount(instanceId) == phase;
            //uint maxPhase = 0;
            //foreach (InstancePhaseInfo instancePhaseInfo in mInstancePhaseInfos.Values)
            //{
            //    if (instancePhaseInfo.Id == instanceId)
            //    {
            //        if (maxPhase < instancePhaseInfo.Phase)
            //        {
            //            maxPhase = instancePhaseInfo.Phase;
            //        }
            //    }
            //}

            //return maxPhase == phase;
        }


        protected override void ParseData(SqliteDataReader reader)
        {
            mInstancePhaseInfos.Clear();
            mInstancePhaseCount.Clear();
//            InstancePhaseInfo info;
//            if (reader != null)
//            {
//                if (reader.HasRows == true)
//                {
//                    while (reader.Read())
//                    {
//                        info = new InstancePhaseInfo();

            //                        info.CsvId = GetReaderString(reader, "csv_id");
            //                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            //                        info.Phase = DBTextResource.ParseUI_s(GetReaderString(reader, "phase"), 0);
            //                        info.Mark1 = GetReaderString(reader, "mark_1");
            //                        info.Mark2 = GetReaderString(reader, "mark_2");
            //                        info.Mark3 = GetReaderString(reader, "mark_3");
            //                        info.Mark4 = GetReaderString(reader, "mark_4");
            //                        info.Mark5 = GetReaderString(reader, "mark_5");
            //                        info.Desc = GetReaderString(reader, "desc");
            //                        info.Tips = GetReaderString(reader, "tips");
            //                        info.TargetStr = GetReaderString(reader, "target");

            //#if UNITY_EDITOR
            //                        if (mInstancePhaseInfos.ContainsKey(info.CsvId))
            //                        {
            //                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.Id));
            //                            continue;
            //                        }
            //#endif
            //                        mInstancePhaseInfos.Add(info.CsvId, info);
            //                    }
            //                }
            //			}
        }
	}
}
