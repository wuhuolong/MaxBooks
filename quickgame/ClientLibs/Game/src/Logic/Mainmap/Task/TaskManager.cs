//------------------------------------------------------------------------------
// Desc   :  任务管理类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    /// <summary>
    /// 赏金任务信息
    /// </summary>
    [wxb.Hotfix]
    public class BountyTaskInfo
    {
        public BountyTaskInfo(int id, int num, int is_reward)
        {
            this.id = id;
            this.num = num;
            this.is_reward = is_reward;
        }

        public int id;         // 任务id
        public int num;        // 已完成环数
        public int is_reward;  // 0、未领取总奖励，1、已领取
    }

    /// <summary>
    /// 帮派任务信息
    /// </summary>
    [wxb.Hotfix]
    public class GuildTaskInfo
    {
        public GuildTaskInfo(int id, int num, int reward_state)
        {
            this.id = id;
            this.num = num;
            this.reward_state = reward_state;
        }

        public int id;             // 任务id
        public int num;            // 已完成环数
        public int reward_state;   // 领取奖励状态：0、不可领取，1、可领取
    }

    [wxb.Hotfix]
    public class TaskManager : xc.Singleton<TaskManager>
    {
        private Dictionary<ushort, List<Task>> mTasksDict = new Dictionary<ushort, List<Task>>();

        /// <summary>
        /// 导航（自动寻路）中的任务
        /// </summary>
        private Task mNavigatingTask = null;
        public Task NavigatingTask
        {
            get
            {
                return mNavigatingTask;
            }
            set
            {
                Task oldNavigatingTask = mNavigatingTask;
                mNavigatingTask = value;

                bool navigatingMainTaskChanged = false;
                bool navigatingBountyTaskChanged = false;
                bool navigatingGuildTaskChanged = false;
                if (oldNavigatingTask == null)
                {
                    if (mNavigatingTask != null && mNavigatingTask.Define.Type == GameConst.QUEST_MAIN)
                    {
                        navigatingMainTaskChanged = true;
                    }
                    if (mNavigatingTask != null && mNavigatingTask.Define.Type == GameConst.QUEST_SG)
                    {
                        navigatingBountyTaskChanged = true;
                    }
                    if (mNavigatingTask != null && mNavigatingTask.Define.Type == GameConst.QUEST_GUILD)
                    {
                        navigatingGuildTaskChanged = true;
                    }
                }
                else
                {
                    if (mNavigatingTask == null)
                    {
                        if (oldNavigatingTask.Define.Type == GameConst.QUEST_MAIN)
                        {
                            navigatingMainTaskChanged = true;
                        }
                        if (oldNavigatingTask.Define.Type == GameConst.QUEST_SG)
                        {
                            navigatingBountyTaskChanged = true;
                        }
                        if (oldNavigatingTask.Define.Type == GameConst.QUEST_GUILD)
                        {
                            navigatingGuildTaskChanged = true;
                        }
                    }
                    else
                    {
                        if ((oldNavigatingTask.Define.Type == GameConst.QUEST_MAIN || mNavigatingTask.Define.Type == GameConst.QUEST_MAIN) &&
                            oldNavigatingTask.Define.Id != mNavigatingTask.Define.Id)
                        {
                            navigatingMainTaskChanged = true;
                        }
                        if ((oldNavigatingTask.Define.Type == GameConst.QUEST_SG || mNavigatingTask.Define.Type == GameConst.QUEST_SG) &&
                            oldNavigatingTask.Define.Id != mNavigatingTask.Define.Id)
                        {
                            navigatingBountyTaskChanged = true;
                        }
                        if ((oldNavigatingTask.Define.Type == GameConst.QUEST_GUILD || mNavigatingTask.Define.Type == GameConst.QUEST_GUILD) &&
                            oldNavigatingTask.Define.Id != mNavigatingTask.Define.Id)
                        {
                            navigatingGuildTaskChanged = true;
                        }
                    }
                }

                if (navigatingMainTaskChanged == true)
                {
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.NAVIGATING_MAIN_TASK_CHANGED, null);
                }
                if (navigatingBountyTaskChanged == true)
                {
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.NAVIGATING_BOUNTY_TASK_CHANGED, null);
                }
                if (navigatingGuildTaskChanged == true)
                {
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.NAVIGATING_GUILD_TASK_CHANGED, null);
                }
            }
        }

        public ushort NavigatingTaskType
        {
            get
            {
                if (mNavigatingTask != null)
                {
                    return mNavigatingTask.Define.Type;
                }
                return GameConst.QUEST_NONE;
            }
        }

        /// <summary>
        /// 是否在导航（自动寻路）主线任务
        /// </summary>
        public bool IsNavigatingMainTask
        {
            get
            {
                if (NavigatingTask != null && NavigatingTask.Define.Type == GameConst.QUEST_MAIN)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 任务栏中选中的任务ID
        /// </summary>
        public uint SelectedTaskId { get; set; }

        /// <summary>
        /// 赏金任务信息
        /// </summary>
        public BountyTaskInfo BountyTaskInfo { get; set; }

        /// <summary>
        /// 是否在导航（自动寻路）去接取赏金任务
        /// </summary>
        private bool mIsNavigatingAcceptBountyTask = false;
        public bool IsNavigatingAcceptBountyTask
        {
            get
            {
                return mIsNavigatingAcceptBountyTask;
            }
            set
            {
                mIsNavigatingAcceptBountyTask = value;
            }
        }

        /// <summary>
        /// 是否在导航（自动寻路）赏金任务
        /// </summary>
        public bool IsNavigatingBountyTask
        {
            get
            {
                if (NavigatingTask != null && NavigatingTask.Define.Type == GameConst.QUEST_SG)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 是否无需确认直接花钱完成赏金任务
        /// </summary>
        public bool FinishBountyTaskNoConfirm { get; set; }

        /// <summary>
        /// 赏金任务金币奖励
        /// </summary>
        public uint BountyTaskCoinReward { get; set; }

        /// <summary>
        /// 下一次赏金任务更新是否不自动执行任务
        /// </summary>
        public bool DoNotAutoRunBountyTaskNextTime { get; set; }

        /// <summary>
        /// 帮派任务信息
        /// </summary>
        public GuildTaskInfo GuildTaskInfo { get; set; }

        /// <summary>
        /// 是否在导航（自动寻路）去接取帮派任务
        /// </summary>
        private bool mIsNavigatingAcceptGuildTask = false;
        public bool IsNavigatingAcceptGuildTask
        {
            get
            {
                return mIsNavigatingAcceptGuildTask;
            }
            set
            {
                mIsNavigatingAcceptGuildTask = value;
            }
        }

        /// <summary>
        /// 是否在导航（自动寻路）帮派任务
        /// </summary>
        public bool IsNavigatingGuildTask
        {
            get
            {
                if (NavigatingTask != null && NavigatingTask.Define.Type == GameConst.QUEST_GUILD)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 是否无需确认直接花钱完成帮派任务
        /// </summary>
        public bool FinishGuildTaskNoConfirm { get; set; }

        /// <summary>
        /// 帮派任务帮派贡献奖励
        /// </summary>
        public uint GuildTaskCtbReward { get; set; }

        /// <summary>
        /// 下一次帮派任务更新是否不自动执行任务
        /// </summary>
        public bool DoNotAutoRunGuildTaskNextTime { get; set; }

        /// <summary>
        /// 转职任务信息
        /// </summary>
        public Net.S2CTaskTransferInfo TransferTaskInfo { get; set; }

        /// <summary>
        /// 是否在导航（自动寻路）去接取护送任务
        /// </summary>
        private bool mIsNavigatingAcceptEscortTask = false;
        public bool IsNavigatingAcceptEscortTask
        {
            get
            {
                return mIsNavigatingAcceptEscortTask;
            }
            set
            {
                mIsNavigatingAcceptEscortTask = value;
            }
        }

        public void RegisterAllMessage()
        {
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerControlled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerControlled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }

        public void AddTask(Task task)
        {
            if (task == null)
            {
                return;
            }

            if (mTasksDict.ContainsKey(task.Define.Type) == false)
            {
                mTasksDict[task.Define.Type] = new List<Task>();
                mTasksDict[task.Define.Type].Clear();
            }

            if (mTasksDict[task.Define.Type].Contains(task))
            {
                return;
            }

            mTasksDict[task.Define.Type].Add(task);
        }

        /// <summary>
        /// 根据任务类型和id获取指定的任务
        /// </summary>
        /// <param name="taskType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task GetTaskByTypeAndId(ushort taskType, uint id)
        {
            if (mTasksDict.ContainsKey(taskType) == true && mTasksDict[taskType] != null)
            {
                foreach (var item in mTasksDict[taskType])
                {
                    if (item.Define.Id == id)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

        public Task GetTask(uint id)
        {
            foreach (List<Task> tasks in mTasksDict.Values)
            {
                foreach (var item in tasks)
                {
                    if (item.Define.Id == id)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public bool HasTask(uint id)
        {
            return !(GetTask(id) == null);
        }

        public bool IsMainTaskFinished(uint id)
        {
            if (mTasksDict.ContainsKey(GameConst.QUEST_MAIN) == true && mTasksDict[GameConst.QUEST_MAIN] != null)
            {
                foreach (var item in mTasksDict[GameConst.QUEST_MAIN])
                {
                    if (item.Define.Id > id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void DeleteTask(uint id)
        {
            foreach (List<Task> tasks in mTasksDict.Values)
            {
                foreach (var item in tasks)
                {
                    if (item.Define.Id == id)
                    {
                        tasks.Remove(item);
                        return;
                    }
                }
            }
        }

        public void ClearAllTasks()
        {
            foreach (List<Task> tasks in mTasksDict.Values)
            {
                tasks.Clear();
            }
            mTasksDict.Clear();
        }

        /// <summary>
        /// 更新指定任务的当前进度值
        /// </summary>
        public bool ChangeTaskCurStepValue(uint id, uint value)
        {
            Task task = GetTask(id);
            if (task != null)
            {
                bool isDone = false;

                Task.StepProgress stepProgress = task.CurrentStepProgress;
                if (stepProgress != null)
                {
                    stepProgress.CurrentValue = value;

                    TaskDefine.TaskStep step = task.CurrentStep;
                    if (step != null)
                    {
                        if (stepProgress.CurrentValue == step.ExpectResult)
                        {
                            isDone = true;
                        }
                    }
                }

                TaskHelper.ShowTaskProgressTips(task);

                return isDone;
            }

            return false;
        }

        public void Reset()
        {
            ClearAllTasks();
            SelectedTaskId = 0;
            BountyTaskInfo = null;
            IsNavigatingAcceptBountyTask = false;
            FinishBountyTaskNoConfirm = false;
            BountyTaskCoinReward = 0;
            DoNotAutoRunBountyTaskNextTime = false;
            DoNotAutoRunGuildTaskNextTime = false;
            IsNavigatingAcceptGuildTask = false;
            IsNavigatingAcceptEscortTask = false;
            FinishGuildTaskNoConfirm = false;
            GuildTaskCtbReward = 0;

            TaskNet.IsFirstReceiveTaskInfo = true;
            TaskNet.IsFirstReceiveBountyTaskInfo = true;
            TaskNet.IsFirstReceiveGuildTaskInfo = true;

            TaskNet.HaveReceivedTaskInfo = false;

            TaskDefine.ClearCache();
        }

        public List<Task> GetNpcRelateCurrentStepTasks(uint npcId, uint sceneId = 0)
        {
            List<Task> retTasks = new List<Task>();
            retTasks.Clear();

            if (0 == sceneId)
                sceneId = SceneHelp.Instance.CurSceneID;

            System.Action<Task> MetNpc = (Task taskItem) =>
            {
                if (taskItem == null)
                {
                    return;
                }

                if (taskItem.State == GameConst.QUEST_STATE_ACCEPT || taskItem.State == GameConst.QUEST_STATE_FAIL)
                {
                    if (taskItem.Define.ReceiveNpc.SceneId == sceneId && taskItem.Define.ReceiveNpc.NpcId == npcId)
                    {
                        retTasks.Add(taskItem);
                        return;
                    }
                }

                if (taskItem.State == GameConst.QUEST_STATE_DONE || taskItem.State == GameConst.QUEST_STATE_DOING)
                {
                    if (taskItem.Define.SubmitNpc.SceneId == sceneId && taskItem.Define.SubmitNpc.NpcId == npcId)
                    {
                        retTasks.Add(taskItem);
                        return;
                    }
                }
            };

            foreach (List<Task> tasks in mTasksDict.Values)
            {
                foreach (Task task in tasks)
                {
                    MetNpc(task);
                }
            }

            return retTasks;
        }

        public void Update()
        {
            foreach (List<Task> tasks in mTasksDict.Values)
            {
                foreach (var item in tasks)
                {
                    item.Update();
                }
            }
        }

        public List<Task> VisibleMainTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                if (mTasksDict.ContainsKey(GameConst.QUEST_MAIN) == true && mTasksDict[GameConst.QUEST_MAIN] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_MAIN])
                    {
                        if (item.State != GameConst.QUEST_STATE_FIN && item.State != GameConst.QUEST_STATE_INVALID)
                        {
                            tasks.Add(item);
                        }
                    }
                }

                return tasks;
            }
        }

        /// <summary>
        /// 已经接取的任务
        /// </summary>
        public List<Task> AcceptedBranchTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                foreach (var item in VisibleBranchTasks)
                {
                    if (item.State != GameConst.QUEST_STATE_ACCEPT && item.State != GameConst.QUEST_STATE_FAIL)
                    {
                        tasks.Add(item);
                    }
                }

                return tasks;
            }
        }

        /// <summary>
        /// 还没接取的任务
        /// </summary>
        public List<Task> UnAcceptedBranchTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                foreach (var item in VisibleBranchTasks)
                {
                    if (item.State == GameConst.QUEST_STATE_ACCEPT || item.State == GameConst.QUEST_STATE_FAIL)
                    {
                        tasks.Add(item);
                    }
                }

                return tasks;
            }
        }

        public List<Task> VisibleBranchTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                if (mTasksDict.ContainsKey(GameConst.QUEST_BRANCH) == true && mTasksDict[GameConst.QUEST_BRANCH] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_BRANCH])
                    {
                        if (item.State != GameConst.QUEST_STATE_FIN && item.State != GameConst.QUEST_STATE_INVALID)
                        {
                            tasks.Add(item);
                        }
                    }
                }

                return tasks;
            }
        }

        public List<Task> VisibleBountyTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                if (mTasksDict.ContainsKey(GameConst.QUEST_SG) == true && mTasksDict[GameConst.QUEST_SG] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_SG])
                    {
                        if (item.State != GameConst.QUEST_STATE_FIN && item.State != GameConst.QUEST_STATE_INVALID)
                        {
                            tasks.Add(item);
                        }
                    }
                }

                return tasks;
            }
        }

        public List<Task> VisibleGuildTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                if (mTasksDict.ContainsKey(GameConst.QUEST_GUILD) == true && mTasksDict[GameConst.QUEST_GUILD] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_GUILD])
                    {
                        if (item.State != GameConst.QUEST_STATE_FIN && item.State != GameConst.QUEST_STATE_INVALID)
                        {
                            tasks.Add(item);
                        }
                    }
                }

                return tasks;
            }
        }

        /// <summary>
        /// 返回一个正在进行中的护送任务
        /// </summary>
        public Task DoingEscortTask
        {
            get
            {
                if (mTasksDict.ContainsKey(GameConst.QUEST_ESCORT) == true && mTasksDict[GameConst.QUEST_ESCORT] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_ESCORT])
                    {
                        if (item.State == GameConst.QUEST_STATE_DOING)
                        {
                            return item;
                        }
                    }
                }

                return null;
            }
        }

        public List<Task> VisibleTransferTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                if (mTasksDict.ContainsKey(GameConst.QUEST_TRANSFER) == true && mTasksDict[GameConst.QUEST_TRANSFER] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_TRANSFER])
                    {
                        if (item.Define.SubType != 54 && item.Define.SubType != 56 && item.State != GameConst.QUEST_STATE_FIN && item.State != GameConst.QUEST_STATE_INVALID)
                        {
                            tasks.Add(item);
                        }
                    }
                }

                return tasks;
            }
        }

        /// <summary>
        /// 任务栏上可见的头衔任务，只显示进行中和已完成的任务
        /// </summary>
        public List<Task> VisibleTitleTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                if (mTasksDict.ContainsKey(GameConst.QUEST_TITLE) == true && mTasksDict[GameConst.QUEST_TITLE] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_TITLE])
                    {
                        if (item.State == GameConst.QUEST_STATE_DOING || item.State == GameConst.QUEST_STATE_DONE)
                        {
                            tasks.Add(item);
                        }
                    }
                }

                return tasks;
            }
        }

        public List<Task> VisibleEscortTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();

                if (mTasksDict.ContainsKey(GameConst.QUEST_ESCORT) == true && mTasksDict[GameConst.QUEST_ESCORT] != null)
                {
                    foreach (var item in mTasksDict[GameConst.QUEST_ESCORT])
                    {
                        if (item.State != GameConst.QUEST_STATE_FIN && item.State != GameConst.QUEST_STATE_INVALID)
                        {
                            tasks.Add(item);
                        }
                    }
                }

                return tasks;
            }
        }

        /// <summary>
        /// 任务栏上可见的任务
        /// </summary>
        public List<Task> VisibleOnBarTasks
        {
            get
            {
                List<Task> tasks = new List<Task>();
                tasks.Clear();

                tasks.AddRange(VisibleMainTasks);
                tasks.AddRange(AcceptedBranchTasks);
                tasks.AddRange(VisibleBountyTasks);
                tasks.AddRange(VisibleGuildTasks);
                tasks.AddRange(VisibleTransferTasks);
                tasks.AddRange(VisibleTitleTasks);
                tasks.AddRange(VisibleEscortTasks);

                tasks.Sort();

                return tasks;
            }
        }

        /// <summary>
        /// 根据任务状态获取任务列表
        /// </summary>
        public List<Task> GetTasksByState(uint taskState)
        {
            List<Task> retTasks = new List<Task>();
            retTasks.Clear();

            foreach (List<Task> tasks in mTasksDict.Values)
            {
                foreach (var item in tasks)
                {
                    if (item.State == taskState)
                    {
                        retTasks.Add(item);
                    }
                }
            }

            return retTasks;
        }

        public List<Task> AllTasks
        {
            get
            {
                List<Task> allTasks = new List<Task>();
                allTasks.Clear();

                foreach (List<Task> tasks in mTasksDict.Values)
                {
                    allTasks.AddRange(tasks);
                }

                return allTasks;
            }
        }

        /// <summary>
        /// 根据任务类型获取任务列表
        /// </summary>
        /// <param name="taskType"></param>
        /// <returns></returns>
        public List<Task> GetTasksByType(ushort taskType)
        {
            if (mTasksDict.ContainsKey(taskType) == true)
            {
                return mTasksDict[taskType];
            }
            List<Task> tasks = new List<Task>();
            tasks.Clear();
            return tasks;
        }

        /// <summary>
        /// 获取指定任务类型和状态的任务数量
        /// </summary>
        /// <param name="taskType"></param>
        /// <param name="taskState"></param>
        /// <returns></returns>
        public uint GetTaskNumByTypeAndState(ushort type, uint state)
        {
            uint num = 0;
            foreach (Task task in AllTasks)
            {
                if (task.Define.Type == type && task.State == state)
                {
                    ++num;
                }
            }

            return num;
        }

        /// <summary>
        /// 获取指定任务状态的任务数量
        /// </summary>
        /// <param name="taskType"></param>
        /// <param name="taskState"></param>
        /// <returns></returns>
        public uint GetTaskNumByState(uint state)
        {
            uint num = 0;
            foreach (Task task in AllTasks)
            {
                if (task.State == state)
                {
                    ++num;
                }
            }

            return num;
        }

        /// <summary>
        /// 获取任务栏比指定任务排序优先级要高的任务数量
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public uint GetVisibleOnBarHigherPriority2TasksNum(uint taskId)
        {
            uint num = 0;
            TaskDefine taskDefine = TaskDefine.MakeDefine(taskId);
            if (taskDefine != null)
            {
                foreach (Task task in VisibleOnBarTasks)
                {
                    // 非主线和支线且不可接的任务不显示
                    if (task.Define.Type != GameConst.QUEST_MAIN && task.Define.Type != GameConst.QUEST_BRANCH && task.State == GameConst.QUEST_STATE_UNACCEPT)
                    {
                        continue;
                    }
                    // 没有帮派则不显示帮派任务
                    if (task.Define.Type == GameConst.QUEST_GUILD && xc.LocalPlayerManager.Instance.GuildID == 0)
                    {
                        continue;
                    }
                    // 排除已完成的任务
                    if (task.State == GameConst.QUEST_STATE_DONE)
                    {
                        continue;
                    }
                    if (task.Define.ShowPriority2 < taskDefine.ShowPriority2)
                    {
                        ++num;
                    }
                }
            }

            return num;
        }

        /// <summary>
        /// 是否有指定目标的任务
        /// </summary>
        /// <param name="goal"></param>
        /// <returns></returns>
        public bool HaveTasksByGoal(string goal)
        {
            foreach (Task task in AllTasks)
            {
                if (task.CurrentGoal == goal)
                {
                    return true;
                }
            }

            return false;
        }

        public void SortTaskList()
        {
            foreach (List<Task> tasks in mTasksDict.Values)
            {
                tasks.Sort();
            }
        }

        /// <summary>
        /// 获取当前采集目标任务的npc id列表
        /// </summary>
        public List<int> GetNpcIdsByCurrentInteractGoal()
        {
            List<int> npcIds = new List<int>();
            npcIds.Clear();

            Dictionary<int, Neptune.BaseGenericNode> npcDatas = Neptune.DataManager.Instance.Data.GetData<Neptune.NPC>().Data;
            uint curInstanceId = SceneHelp.Instance.CurSceneID;
            List<Task> doingTasks = GetTasksByState(GameConst.QUEST_STATE_DOING);
            foreach (Task task in doingTasks)
            {
                if (task.State == GameConst.QUEST_STATE_DOING)
                {
                    TaskDefine.TaskStep step = task.CurrentStep;
                    if (step != null && step.Goal == GameConst.GOAL_INTERACT && step.InstanceId == curInstanceId)
                    {
                        foreach (KeyValuePair<int, Neptune.BaseGenericNode> kv in npcDatas)
                        {
                            if (kv.Value is Neptune.NPC)
                            {
                                if ((kv.Value as Neptune.NPC).ExcelId == step.NpcId)
                                {
                                    npcIds.Add(kv.Key);
                                }
                            }
                        }
                    }
                }
            }

            return npcIds;
        }

        /// <summary>
        /// 获取指定采集目标任务的npc id列表
        /// </summary>
        public List<int> GetNpcIdsByCurrentInteractGoal(uint taskId)
        {
            List<int> npcIds = new List<int>();
            npcIds.Clear();

            Task task = GetTask(taskId);
            if (task != null)
            {
                if (task.State == GameConst.QUEST_STATE_DOING)
                {
                    uint curInstanceId = SceneHelp.Instance.CurSceneID;

                    TaskDefine.TaskStep step = task.CurrentStep;
                    if (step != null && step.Goal == GameConst.GOAL_INTERACT && step.InstanceId == curInstanceId)
                    {
                        Dictionary<int, Neptune.BaseGenericNode> npcDatas = Neptune.DataManager.Instance.Data.GetData<Neptune.NPC>().Data;
                        foreach (KeyValuePair<int, Neptune.BaseGenericNode> kv in npcDatas)
                        {
                            if (kv.Value is Neptune.NPC)
                            {
                                if ((kv.Value as Neptune.NPC).ExcelId == step.NpcId)
                                {
                                    npcIds.Add(kv.Key);
                                }
                            }
                        }
                    }
                }
            }

            return npcIds;
        }

        void OnPlayerControlled(CEventBaseArgs args)
        {
            SelectedTaskId = 0;
            NavigatingTask = null;
            IsNavigatingAcceptBountyTask = false;
            IsNavigatingAcceptGuildTask = false;
            IsNavigatingAcceptEscortTask = false;
        }

        void OnStartSwitchScene(CEventBaseArgs args)
        {
            TaskHelper.StopTaskGuideCoroutine();
        }
    }
}
