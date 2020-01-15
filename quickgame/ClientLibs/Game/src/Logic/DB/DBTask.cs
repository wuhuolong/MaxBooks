/*----------------------------------------------------------------
// 文件名： DBTask.cs
// 文件功能描述： 任务表，只缓存主线和护送任务
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
	public class DBTask : DBSqliteTableResource
    {
		private Dictionary<uint, TaskDefine> mTasksData = new Dictionary<uint, TaskDefine>();
        private Dictionary<ushort, Dictionary<uint, TaskDefine>> mTasksDataByType = new Dictionary<ushort, Dictionary<uint, TaskDefine>>();


        public DBTask(string strName, string strPath)
			: base(strName, strPath)
		{
		}

		public TaskDefine GetTaskDefine(uint taskId)
		{
            TaskDefine retTaskDefine = null;
            if (mTasksData.TryGetValue(taskId, out retTaskDefine) == true)
            {
                return retTaskDefine;
            }

            //foreach (Dictionary<uint, TaskDefine> taskDefines in mTasksDataByType.Values)
            //{
            //    foreach (TaskDefine taskDefine in taskDefines.Values)
            //    {
            //        if (taskDefine.Id == taskId)
            //        {
            //            return taskDefine;
            //        }
            //    }
            //}

            string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", taskId.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, queryStr);
            if (table_reader == null)
            {
                return null;
            }
            if (!table_reader.HasRows)
            {
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }
            if (!table_reader.Read())
            {
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            TaskDefine ret = null;
            try
            {
            	ret = ReadReader(table_reader);
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("Read task db error, id:" + taskId + ", msg:" + ex.Message);
            }

            table_reader.Close();
            table_reader.Dispose();

            return ret;
        }

        public Dictionary<uint, TaskDefine> GetTaskDefineListByType(ushort taskType)
        {
            Dictionary<uint, TaskDefine> ret = null;
            mTasksDataByType.TryGetValue(taskType, out ret);
            return ret;
        }

        TaskDefine ReadReader(SqliteDataReader reader)
        {
            ushort taskType = DBTextResource.ParseUS_s(GetReaderString(reader, "type"), 0);
            TaskDefine define = new TaskDefine();

            define.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
            define.DescriptionBytes = GetReaderBytes(reader, "description");
            define.NameBytes = GetReaderBytes(reader, "name");
            define.Type = taskType;
            define.SubType = DBTextResource.ParseUI_s(GetReaderString(reader, "sub_type"), 0);
            define.RequestLevelMin = DBTextResource.ParseI_s(GetReaderString(reader, "lv_min"), 0);
            define.PreviousId = DBTextResource.ParseUI_s(GetReaderString(reader, "pre_id"), 0);
            define.NextId = DBTextResource.ParseUI_s(GetReaderString(reader, "next_id"), 0);
            define.NextId = DBTextResource.ParseUI_s(GetReaderString(reader, "next_id"), 0);

            string serverStepRawsString = GetReaderString(reader, "goals");
            string clientStepRawsString = GetReaderString(reader, "steps");
            string navigationPointsRawsString = GetReaderString(reader, "navigation_points");
            define.Steps = TaskDefine.TaskStep.CreateStepsByRawString(serverStepRawsString, clientStepRawsString, navigationPointsRawsString);
            if (define.Steps == null || define.Steps.Count == 0)
            {
                GameDebug.LogError("Parse task " + define.Id + " error, step is empty!!!");
            }

            define.RewardIds = DBTextResource.ParseArrayUint(GetReaderString(reader, "reward_ids"), ",");
            define.GetSkills = DBTextResource.ParseArrayUint(GetReaderString(reader, "get_skills"), ",");
            define.IsShowGetSkillProgress = DBTextResource.ParseI_s(GetReaderString(reader, "is_show_get_skill_progress"), 0) == 0 ? false : true;
            define.ReceiveDialogId = DBTextResource.ParseUI_s(GetReaderString(reader, "receive_dialog_id"), 0);
            define.SubmitDialogId = DBTextResource.ParseUI_s(GetReaderString(reader, "submit_dialog_id"), 0);
            define.ReceiveNpc = NpcScenePosition.Make(GetReaderString(reader, "receive_npc"));
            define.SubmitNpc = NpcScenePosition.Make(GetReaderString(reader, "submit_npc"));
            define.AutoRunType = (TaskDefine.EAutoRunType)DBTextResource.ParseBT_s(GetReaderString(reader, "auto_run"), 0);
            define.ShowPriority = DBManager.Instance.GetDB<DBTaskPriority>().GetTaskPriority((int)taskType);
            define.ShowPriority2 = DBManager.Instance.GetDB<DBTaskPriority>().GetTaskPriority2((int)taskType);

            string raw = GetReaderString(reader, "is_temporary_on_top");
            if (string.IsNullOrEmpty(raw) == true || raw == "0")
            {
                define.IsTemporaryOnTop = false;
            }
            else
            {
                define.IsTemporaryOnTop = true;
            }

            string npcsRawString = GetReaderString(reader, "create_npcs_when_received");
            define.CreateNpcsWhenReceived = TaskDefine.MakeNpcScenePositions(npcsRawString);
            npcsRawString = GetReaderString(reader, "delete_npcs_when_received");
            define.DeleteNpcsWhenReceived = TaskDefine.MakeNpcScenePositions(npcsRawString);
            npcsRawString = GetReaderString(reader, "create_npcs_when_done");
            define.CreateNpcsWhenDone = TaskDefine.MakeNpcScenePositions(npcsRawString);
            npcsRawString = GetReaderString(reader, "delete_npcs_when_done");
            define.DeleteNpcsWhenDone = TaskDefine.MakeNpcScenePositions(npcsRawString);

            define.FollowNpcs = TaskDefine.MakeNpcScenePositions(GetReaderString(reader, "follow_npcs"));
            define.CanUseBoots = (DBTextResource.ParseI_s(GetReaderString(reader, "can_use_boots"), 0) > 0);
            define.ReceivedTimelineId = DBTextResource.ParseUI_s(GetReaderString(reader, "received_timeline_id"), 0);
            define.SubmitedTimelineId = DBTextResource.ParseUI_s(GetReaderString(reader, "submited_timeline_id"), 0);

            raw = GetReaderString(reader, "cost");
            if (string.IsNullOrEmpty(raw) == false)
            {
                define.Costs = DBTextResource.ParseArrayStringString(raw);
            }

            raw = GetReaderString(reader, "show_reward_goods_id");
            List<List<uint>> showRewardGoodsIdConfigs = DBTextResource.ParseArrayUintUint(raw);
            define.ShowRewardGoodsIds = new Dictionary<uint, uint>();
            define.ShowRewardGoodsIds.Clear();
            define.ShowRewardGoodsNums = new Dictionary<uint, uint>();
            define.ShowRewardGoodsNums.Clear();
            define.ShowRewardGoodsIsBinds = new Dictionary<uint, byte>();
            define.ShowRewardGoodsIsBinds.Clear();
            uint index = 1;
            foreach (List<uint> showRewardGoodsIdConfig in showRewardGoodsIdConfigs)
            {
                define.ShowRewardGoodsIds[index] = showRewardGoodsIdConfig[0];
                define.ShowRewardGoodsNums[index] = showRewardGoodsIdConfig[1];
                define.ShowRewardGoodsIsBinds[index] = (byte)showRewardGoodsIdConfig[2];
                ++index;
            }

            mTasksData.Add(define.Id, define);
            if (mTasksDataByType.ContainsKey(define.Type) == true)
            {
                mTasksDataByType[define.Type].Add(define.Id, define);
            }
            else
            {
                Dictionary<uint, TaskDefine> taskDefines = new Dictionary<uint, TaskDefine>();
                taskDefines.Clear();
                taskDefines.Add(define.Id, define);

                mTasksDataByType.Add(define.Type, taskDefines);
            }

            return define;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mTasksData.Clear();
            mTasksDataByType.Clear();
            // 任务不做预加载了
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        ushort taskType = DBTextResource.ParseUS_s(GetReaderString(reader, "type"), 0);
                        if (taskType == GameConst.QUEST_MAIN || taskType == GameConst.QUEST_ESCORT)
                        {
                            try
                            {
                                ReadReader(reader);
                            }
                            catch (System.Exception ex)
                            {
                                GameDebug.LogError("Read task db error, msg:" + ex.Message);
                            }
                        }
                    }
                }
            }
        }
	}
}
