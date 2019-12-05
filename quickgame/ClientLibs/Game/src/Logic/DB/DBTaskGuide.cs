/*----------------------------------------------------------------
// 文件名： DBTaskGuide.cs
// 文件功能描述： 任务指引表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
	public class DBTaskGuide : DBSqliteTableResource
    {
        public class TaskGuideInfo
        {
            public uint Id;
            public uint TaskId;
            public uint State;
            public uint Type;
            public string Param;
        }

        private Dictionary<uint, TaskGuideInfo> mTaskGuideInfos = new Dictionary<uint, TaskGuideInfo>();

		public DBTaskGuide(string strName, string strPath)
			: base(strName, strPath)
		{
		}

		public TaskGuideInfo GetTaskGuideInfo(uint taskId, uint taskState, uint taskGuideType = 0)
		{
            foreach (TaskGuideInfo taskGuideInfo in mTaskGuideInfos.Values)
            {
                if (taskGuideInfo.TaskId == taskId && taskGuideInfo.State == taskState && (taskGuideType == 0 || taskGuideInfo.Type == taskGuideType))
                {
                    return taskGuideInfo;
                }
            }

            return null;
		}

        /// <summary>
        /// 获取任务栏上的任务指引数据，类型分别为1,2,3
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskState"></param>
        /// <returns></returns>
        public TaskGuideInfo GetTaskBarGuideInfo(uint taskId, uint taskState)
        {
            foreach (TaskGuideInfo taskGuideInfo in mTaskGuideInfos.Values)
            {
                if (taskGuideInfo.TaskId == taskId && taskGuideInfo.State == taskState)
                {
                    if (taskGuideInfo.Type == 1 || taskGuideInfo.Type == 2 || taskGuideInfo.Type == 3)
                    {
                        return taskGuideInfo;
                    }
                }
            }

            return null;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mTaskGuideInfos.Clear();
            TaskGuideInfo taskGuideInfo = null;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        taskGuideInfo = new TaskGuideInfo();

                        taskGuideInfo.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        taskGuideInfo.TaskId = DBTextResource.ParseUI_s(GetReaderString(reader, "task_id"), 0);
                        taskGuideInfo.State = DBTextResource.ParseUI_s(GetReaderString(reader, "state"), 0);
                        taskGuideInfo.Type = DBTextResource.ParseUI_s(GetReaderString(reader, "type"), 0);
                        taskGuideInfo.Param = GetReaderString(reader, "param");

#if UNITY_EDITOR
                        if (mTaskGuideInfos.ContainsKey(taskGuideInfo.Id))
                        {
                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, taskGuideInfo.Id));
                            continue;
                        }
#endif
                        mTaskGuideInfos.Add(taskGuideInfo.Id, taskGuideInfo);
                    }
                }
			}
		}
	}
}
