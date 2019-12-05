/*----------------------------------------------------------------
// 文件名： DBTaskPriority.cs
// 文件功能描述： 任务显示优先级表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
	public class DBTaskPriority : DBSqliteTableResource
    {
        public class TaskPriorityInfo
        {
            public byte Priority;
            public byte Priority2;
        }

        private Dictionary<int, TaskPriorityInfo> mTaskPrioritys = new Dictionary<int, TaskPriorityInfo>();

		public DBTaskPriority(string strName, string strPath)
			: base(strName, strPath)
		{
		}

		public byte GetTaskPriority(int taskType)
		{
            TaskPriorityInfo taskPriorityInfo = null;
            if (mTaskPrioritys.TryGetValue(taskType, out taskPriorityInfo) == true)
            {
                return taskPriorityInfo.Priority;
            }
			return 0;
		}

        public byte GetTaskPriority2(int taskType)
        {
            TaskPriorityInfo taskPriorityInfo = null;
            if (mTaskPrioritys.TryGetValue(taskType, out taskPriorityInfo) == true)
            {
                return taskPriorityInfo.Priority2;
            }
            return 0;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mTaskPrioritys.Clear();
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        TaskPriorityInfo taskPriorityInfo = new TaskPriorityInfo();

                        int type = DBTextResource.ParseI_s(GetReaderString(reader, "type"), 0);
                        byte priority = DBTextResource.ParseBT_s(GetReaderString(reader, "priority"), 0);
                        byte priority2 = DBTextResource.ParseBT_s(GetReaderString(reader, "priority2"), 0);
                        taskPriorityInfo.Priority = priority;
                        taskPriorityInfo.Priority2 = priority2;

#if UNITY_EDITOR
                        if (mTaskPrioritys.ContainsKey(type))
                        {
                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, type));
                            continue;
                        }
#endif
                        mTaskPrioritys.Add(type, taskPriorityInfo);
                    }
                }
			}
		}
	}
}
