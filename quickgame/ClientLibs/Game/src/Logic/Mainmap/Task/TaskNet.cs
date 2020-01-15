//------------------------------------------------------------------------------
// Desc   :  任务网络类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class TaskNet : xc.Singleton<TaskNet>
    {
        public void RegisterMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_DELETE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_VALUE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_SG_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_REWARD_SG, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_GUILD_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_REWARD_GUILD, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_TRANSFER_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_TASK_REWARD_TRANSFER, HandleServerData);
        }

        /// <summary>
        /// 接受任务
        /// </summary>
        public void AcceptTask(uint id)
        {
            C2STaskAccept data = new C2STaskAccept();
            data.id = id;

            NetClient.BaseClient.SendData<C2STaskAccept>(NetMsg.MSG_TASK_ACCEPT, data);
        }

        /// <summary>
        /// 提交任务
        /// </summary>
        public void SubmitTask(uint id)
        {
            C2STaskSubmit data = new C2STaskSubmit();
            data.id = id;

            NetClient.BaseClient.SendData<C2STaskSubmit>(NetMsg.MSG_TASK_SUBMIT, data);
        }

        /// <summary>
        /// 触发完成任务目标
        /// </summary>
        public void DoTaskGoal(string goal, int arg)
        {
            C2STaskCgoal data = new C2STaskCgoal();
            data.type = System.Text.Encoding.UTF8.GetBytes(goal);
            //if (arg > 0)
            {
                //data.args = new List<int>();
                data.args.Clear();
                data.args.Add(arg);
            }

            NetClient.BaseClient.SendData<C2STaskCgoal>(NetMsg.MSG_TASK_CGOAL, data);
        }

        public void DoTaskGoal(string goal)
        {
            DoTaskGoal(goal, 0);
        }

        /// <summary>
        /// 接取赏金任务
        /// </summary>
        public void AcceptBountyTask()
        {
            C2STaskAcceptSg data = new C2STaskAcceptSg();

            NetClient.BaseClient.SendData<C2STaskAcceptSg>(NetMsg.MSG_TASK_ACCEPT_SG, data);
        }

        /// <summary>
        /// 领取赏金任务奖励
        /// </summary>
        public void ReceiveBountyTaskReward()
        {
            C2STaskRewardSg data = new C2STaskRewardSg();

            NetClient.BaseClient.SendData<C2STaskRewardSg>(NetMsg.MSG_TASK_REWARD_SG, data);
        }

        /// <summary>
        /// 立即完成赏金任务
        /// </summary>
        public void FinishBounty()
        {
            C2STaskFinishSg data = new C2STaskFinishSg();

            NetClient.BaseClient.SendData<C2STaskFinishSg>(NetMsg.MSG_TASK_FINISH_SG, data);
        }

        /// <summary>
        /// 接取帮派任务
        /// </summary>
        public void AcceptGuildTask()
        {
            C2STaskAcceptGuild data = new C2STaskAcceptGuild();

            NetClient.BaseClient.SendData<C2STaskAcceptGuild>(NetMsg.MSG_TASK_ACCEPT_GUILD, data);
        }

        /// <summary>
        /// 领取帮派任务奖励
        /// </summary>
        public void ReceiveGuildTaskReward()
        {
            C2STaskRewardGuild data = new C2STaskRewardGuild();

            NetClient.BaseClient.SendData<C2STaskRewardGuild>(NetMsg.MSG_TASK_REWARD_GUILD, data);
        }

        /// <summary>
        /// 立即完成帮派任务
        /// </summary>
        public void FinishGuild()
        {
            C2STaskFinishGuild data = new C2STaskFinishGuild();

            NetClient.BaseClient.SendData<C2STaskFinishGuild>(NetMsg.MSG_TASK_FINISH_GUILD, data);
        }

        /// <summary>
        /// 接取转职任务
        /// </summary>
        public void AcceptTransferTask()
        {
            C2STaskAcceptTransfer data = new C2STaskAcceptTransfer();

            NetClient.BaseClient.SendData<C2STaskAcceptTransfer>(NetMsg.MSG_TASK_ACCEPT_TRANSFER, data);
        }

        /// <summary>
        /// 领取转职任务奖励
        /// </summary>
        public void ReceiveTransferTaskReward()
        {
            C2STaskRewardTransfer data = new C2STaskRewardTransfer();

            NetClient.BaseClient.SendData<C2STaskRewardTransfer>(NetMsg.MSG_TASK_REWARD_TRANSFER, data);
        }

        /// <summary>
        /// 立即完成转职任务
        /// </summary>
        public void FinishTransfer()
        {
            C2STaskFinishTransfer data = new C2STaskFinishTransfer();

            NetClient.BaseClient.SendData<C2STaskFinishTransfer>(NetMsg.MSG_TASK_FINISH_TRANSFER, data);
        }

        static SafeCoroutine.Coroutine mTaskChangedCoroutine = null;
        static float mTaskChangedCoroutineDelayTime = -1f;
        public static bool IsFirstReceiveTaskInfo = true;
        public static bool IsFirstReceiveBountyTaskInfo = true;
        public static bool IsFirstReceiveGuildTaskInfo = true;

        public static bool HaveReceivedTaskInfo = false;

        public static void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_TASK_INFO:
                    {
                        S2CTaskInfo pack = S2CPackBase.DeserializePack<S2CTaskInfo>(data);

                        // 首先所有任务的置顶取消
                        foreach (Task task in TaskManager.Instance.AllTasks)
                        {
                            task.IsOnTop = false;
                        }

                        IsFirstReceiveTaskInfo = !Game.Instance.AllSystemInited;

                        List<Task> newTasks = new List<Task>();
                        newTasks.Clear();
                        List<Task> finishedTasks = new List<Task>();
                        finishedTasks.Clear();
                        List<Task> newAcceptTasks = new List<Task>();
                        newAcceptTasks.Clear();
                        List<Task> doneTasks = new List<Task>();
                        doneTasks.Clear();
                        List<Task> tasksToGuide = new List<Task>();
                        tasksToGuide.Clear();
                        bool isTitleTaskChanged = false;    // 头衔任务是否改变
                        bool isEscortTaskChanged = false;   // 护送任务是否改变
                        foreach (PkgTaskInfo taskInfo in pack.tasks)
                        {
                            bool isNewTask = false;
                            if (TaskManager.Instance.HasTask(taskInfo.id))
                            {
                                TaskManager.Instance.DeleteTask(taskInfo.id);
                            }
                            else
                            {
                                isNewTask = true;
                            }
                            
                            var dbTask = TaskDefine.MakeDefine(taskInfo.id);
                            if (dbTask == null)
                            {
                                GameDebug.LogError("Error!!! Can not find task data in db by id " + taskInfo.id);
                                continue;
                            }

                            Task task = new Task(dbTask);

                            uint index = 1;
                            foreach (var step in dbTask.Steps)
                            {
                                Task.StepProgress stepProgress = new Task.StepProgress();
                                stepProgress.StepId = index;
                                if (taskInfo.value.Count > 0)
                                {
                                    stepProgress.CurrentValue = taskInfo.value[0];
                                }
                                else
                                {
                                    stepProgress.CurrentValue = 0;
                                }

                                task.StepProgresss.Add(stepProgress);

                                ++index;
                            }

                            task.StepProgresss.Sort();
                            task.State = taskInfo.state;
                            task.StartTime = taskInfo.start_time;
                            if (taskInfo.step > 0)
                            {
                                task.CurrentStepIndex = taskInfo.step - 1;
                            }
                            else
                            {
                                task.CurrentStepIndex = 0;
                            }

                            // 提高任务显示优先级
                            if (IsFirstReceiveTaskInfo == false)
                            {
                                // 头衔任务不受动态排序规则影响
                                if (task.Define.Type != GameConst.QUEST_TITLE)
                                {
                                    Task.IncreaseCurDynamicShowPriority();
                                    task.DynamicShowPriority = Task.CurDynamicShowPriority;
                                }
                            }

                            TaskManager.Instance.AddTask(task);

                            if (task.State == GameConst.QUEST_STATE_DONE)
                            {
                                Task.StepProgress stepProgress = task.CurrentStepProgress;
                                TaskDefine.TaskStep curStep = task.CurrentStep;
                                if (stepProgress != null && curStep != null)
                                {
                                    stepProgress.CurrentValue = curStep.ExpectResult;
                                }
                            }

                            // 是否是新接取的任务
                            if (IsFirstReceiveTaskInfo == false && task.State == GameConst.QUEST_STATE_DOING)
                            {
                                if (task.CurrentStepProgress != null && task.CurrentStepProgress.CurrentValue == 0)
                                {
                                    newAcceptTasks.Add(task);
                                }
                            }

                            // 是否自动执行，进入游戏首次收到这个消息不执行副本状态下不执行，新任务不执行，不是在追踪状态的任务不执行
                            if (IsFirstReceiveTaskInfo == false && SceneHelp.Instance.IsInNormalWild() == true && task.Define.AutoRunType != TaskDefine.EAutoRunType.None)
                            {
                                // 不可接或者失效的任务不可自动执行
                                if (taskInfo.state != GameConst.QUEST_STATE_UNACCEPT && taskInfo.state != GameConst.QUEST_STATE_INVALID)
                                {
                                    if ((task.Define.AutoRunType == TaskDefine.EAutoRunType.AutoRun && InstanceManager.Instance.IsOnHook == false) || task.Define.AutoRunType == TaskDefine.EAutoRunType.ForceAutoRun)
                                    {
                                        // 如果当前正在导航的任务的自动执行是ForceAutoRun2，则其他任务的自动执行不会打断它
                                        Task navigatingTask = TaskManager.Instance.NavigatingTask;
                                        if (navigatingTask == null || navigatingTask.Define.AutoRunType != TaskDefine.EAutoRunType.ForceAutoRun2)
                                        {
                                            if (taskInfo.state == GameConst.QUEST_STATE_DOING || taskInfo.state == GameConst.QUEST_STATE_DONE)
                                            {
                                                tasksToGuide.Add(task);
                                            }
                                        }
                                    }
                                    else if (task.Define.AutoRunType == TaskDefine.EAutoRunType.ForceAutoRun2)
                                    {
                                        tasksToGuide.Add(task);
                                    }
                                }
                            }

                            if (IsFirstReceiveTaskInfo == false)
                            {
                                if (taskInfo.state == GameConst.QUEST_STATE_FIN)
                                {
                                    finishedTasks.Add(task);
                                }
                            }

                            if (IsFirstReceiveTaskInfo == false)
                            {
                                if (taskInfo.state == GameConst.QUEST_STATE_DONE)
                                {
                                    doneTasks.Add(task);
                                }
                            }

                            // 任务进度飘字
                            if (isNewTask == false && taskInfo.state == GameConst.QUEST_STATE_DONE)
                            {
                                TaskHelper.ShowTaskProgressTips(task);
                            }

                            if (IsFirstReceiveTaskInfo == false && isNewTask == true)
                            {
                                newTasks.Add(task);
                            }

                            if (task.Define.Type == GameConst.QUEST_TITLE)
                            {
                                isTitleTaskChanged = true;
                            }
                            if (task.Define.Type == GameConst.QUEST_ESCORT)
                            {
                                isEscortTaskChanged = true;
                            }
                        }

                        //TaskManager.Instance.SortTaskList();

                        //ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_CHANGED, null);
                        StartTaskChangedCoroutine();

                        if (isTitleTaskChanged == true)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.TITLE_TASK_CHANGED, null);
                        }
                        if (isEscortTaskChanged == true)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.ESCORT_TASK_CHANGED, null);
                        }

                        if (finishedTasks.Count > 0)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_FINISHED, new CEventBaseArgs(finishedTasks[0].Define.Id));

                            if (finishedTasks[0].Define.SubmitedTimelineId > 0)
                            {
                                // 是否是婚宴剧情动画
                                if (finishedTasks[0].Define.SubmitedTimelineId == GameConstHelper.GetUint("GAME_WEDDING_DRAMA_TIMELINE_ID_1"))
                                {
                                    TimelineManager.Instance.PlayWeddingChapelTimeline();
                                }
                                else
                                {
                                    TimelineManager.Instance.Play(finishedTasks[0].Define.SubmitedTimelineId);
                                }
                            }
                        }

                        if (newAcceptTasks.Count > 0)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_NEW_ACCEPTED, new CEventBaseArgs(newAcceptTasks[0].Define.Id));

                            if (newAcceptTasks[0].Define.ReceivedTimelineId > 0)
                            {
                                // 是否是婚宴剧情动画
                                if (newAcceptTasks[0].Define.ReceivedTimelineId == GameConstHelper.GetUint("GAME_WEDDING_DRAMA_TIMELINE_ID_1"))
                                {
                                    TimelineManager.Instance.PlayWeddingChapelTimeline();
                                }
                                else
                                {
                                    TimelineManager.Instance.Play(newAcceptTasks[0].Define.ReceivedTimelineId);
                                }
                            }

                            // 如果在副本里面接受了AutoRun的赏金任务或者帮派任务，则Post一个TASK_GUIDE的event，等退出副本再次导航这个任务
                            if (SceneHelp.Instance.IsInInstance == true)
                            {
                                if ((newAcceptTasks[0].Define.AutoRunType == TaskDefine.EAutoRunType.AutoRun && InstanceManager.Instance.IsOnHook == false) || newAcceptTasks[0].Define.AutoRunType == TaskDefine.EAutoRunType.ForceAutoRun || newAcceptTasks[0].Define.AutoRunType == TaskDefine.EAutoRunType.ForceAutoRun2)
                                {
                                    BountyTaskInfo bountyTaskInfo = TaskManager.Instance.BountyTaskInfo;
                                    GuildTaskInfo guildTaskInfo = TaskManager.Instance.GuildTaskInfo;

                                    // bountyTaskInfo.id == 0即首次接取赏金任务时不自动执行
                                    if (newAcceptTasks[0].Define.Type == GameConst.QUEST_SG && !(bountyTaskInfo != null && bountyTaskInfo.id == 0))
                                    {
                                        ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.TASK_GUIDE, new CEventBaseArgs(newAcceptTasks[0].Define.Id));
                                    }
                                    // guildTaskInfo.id == 0即首次接取帮派任务时不自动执行
                                    else if (newAcceptTasks[0].Define.Type == GameConst.QUEST_GUILD && !(guildTaskInfo != null && guildTaskInfo.id == 0))
                                    {
                                        ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.TASK_GUIDE, new CEventBaseArgs(newAcceptTasks[0].Define.Id));
                                    }
                                }
                            }
                        }

                        if (doneTasks.Count > 0)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_CAN_SUBMIT, new CEventBaseArgs(doneTasks));
                        }

                        if (SceneHelp.Instance.IsInNormalWild() == true)
                        {
                            if (tasksToGuide.Count > 0)
                            {
                                BountyTaskInfo bountyTaskInfo = TaskManager.Instance.BountyTaskInfo;
                                GuildTaskInfo guildTaskInfo = TaskManager.Instance.GuildTaskInfo;

                                // DoNotAutoRunBountyTaskNextTime为true不自动执行，bountyTaskInfo.id == 0即首次接取赏金任务时不自动执行
                                if (tasksToGuide[0].Define.Type == GameConst.QUEST_SG && (TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true || (bountyTaskInfo != null && bountyTaskInfo.id == 0)))
                                {
                                    TaskManager.Instance.DoNotAutoRunBountyTaskNextTime = false;
                                }
                                // DoNotAutoRunGuildTaskNextTime为true不自动执行，guildTaskInfo.id == 0即首次接取帮派任务时不自动执行
                                else if (tasksToGuide[0].Define.Type == GameConst.QUEST_GUILD && (TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true || (guildTaskInfo != null && guildTaskInfo.id == 0)))
                                {
                                    TaskManager.Instance.DoNotAutoRunGuildTaskNextTime = false;
                                }
                                else
                                {
                                    // 正在主线任务导航的时候，则不能自动执行其他类型的任务
                                    if ((TaskManager.Instance.IsNavigatingMainTask == false && TaskHelper.MainTaskIsInGuideCoroutine == false) || tasksToGuide[0].Define.Type == GameConst.QUEST_MAIN)
                                    {
                                        if (tasksToGuide[0].State != GameConst.QUEST_STATE_UNACCEPT && tasksToGuide[0].State != GameConst.QUEST_STATE_FIN && tasksToGuide[0].State != GameConst.QUEST_STATE_INVALID)
                                        {
                                            if ((TaskManager.Instance.NavigatingTaskType == GameConst.QUEST_NONE || TaskManager.Instance.NavigatingTaskType == tasksToGuide[0].Define.Type) &&
                                                (TaskHelper.TaskTypeInGuideCoroutine == GameConst.QUEST_NONE || TaskHelper.TaskTypeInGuideCoroutine == tasksToGuide[0].Define.Type))
                                            {
                                                // 如果需要自动寻路的任务是第三级别的自动执行，则需要先停止其他的任务寻路
                                                if (tasksToGuide[0].Define.AutoRunType == TaskDefine.EAutoRunType.ForceAutoRun2)
                                                {
                                                    TargetPathManager.Instance.StopPlayerAndReset();
                                                }
                                                TaskHelper.TaskGuide(tasksToGuide[0]);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (newTasks.Count > 0)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_ADDED, new CEventBaseArgs(newTasks[0].Define.Id));
                        }

                        TaskNet.HaveReceivedTaskInfo = true;

                        break;
                    }
                case NetMsg.MSG_TASK_DELETE:
                    {
                        S2CTaskDelete pack = S2CPackBase.DeserializePack<S2CTaskDelete>(data);

                        Task navigatingTask = TaskManager.Instance.NavigatingTask;
                        if (navigatingTask != null && navigatingTask.Define.Id == pack.id)
                        {
                            TaskManager.Instance.NavigatingTask = null;
                            TargetPathManager.Instance.StopPlayerAndReset(false);
                        }

                        TaskManager.Instance.DeleteTask(pack.id);

                        //ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_CHANGED, null);
                        StartTaskChangedCoroutine();

                        break;
                    }
                case NetMsg.MSG_TASK_VALUE:
                    {
                        S2CTaskValue pack = S2CPackBase.DeserializePack<S2CTaskValue>(data);

                        // 其它所有任务的置顶取消
                        foreach (Task tempTask in TaskManager.Instance.AllTasks)
                        {
                            if (tempTask.Define.Id != pack.id)
                            {
                                tempTask.IsOnTop = false;
                            }
                        }

                        bool isDone = false;
                        uint value = 0;
                        if (pack.value.Count > 0)
                        {
                            isDone = TaskManager.Instance.ChangeTaskCurStepValue(pack.id, pack.value[0]);
                            value = pack.value[0];
                        }
                        else
                        {
                            isDone = TaskManager.Instance.ChangeTaskCurStepValue(pack.id, 0);
                        }

                        Task task = TaskManager.Instance.GetTask(pack.id);

                        // 提高任务显示优先级，头衔任务不受动态排序规则影响
                        if (task != null && task.Define.Type != GameConst.QUEST_TITLE)
                        {
                            Task.IncreaseCurDynamicShowPriority();
                            task.DynamicShowPriority = Task.CurDynamicShowPriority;
                        }

                        //TaskManager.Instance.SortTaskList();

                        if (SceneHelp.Instance.IsInNormalWild() == true)
                        {
                            if ((isDone == true || InstanceManager.Instance.IsAutoFighting == false) && task != null && task.Define.AutoRunType != TaskDefine.EAutoRunType.None)
                            {
                                if ((task.Define.AutoRunType == TaskDefine.EAutoRunType.AutoRun && InstanceManager.Instance.IsOnHook == false) || task.Define.AutoRunType == TaskDefine.EAutoRunType.ForceAutoRun || task.Define.AutoRunType == TaskDefine.EAutoRunType.ForceAutoRun2)
                                {
                                    // 正在主线任务导航的时候，则不能自动执行其他类型的任务
                                    if ((TaskManager.Instance.IsNavigatingMainTask == false && TaskHelper.MainTaskIsInGuideCoroutine == false) || task.Define.Type == GameConst.QUEST_MAIN)
                                    {
                                        // 进度大于0才自动执行
                                        if (value > 0)
                                        {
                                            if ((TaskManager.Instance.NavigatingTaskType == GameConst.QUEST_NONE || TaskManager.Instance.NavigatingTaskType == task.Define.Type) &&
                                                (TaskHelper.TaskTypeInGuideCoroutine == GameConst.QUEST_NONE || TaskHelper.TaskTypeInGuideCoroutine == task.Define.Type))
                                            {
                                                TaskHelper.TaskGuide(task);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_PROGRESS_CHANGED, new CEventBaseArgs(pack.id));

                        break;
                    }
                case NetMsg.MSG_TASK_SG_INFO:
                    {
                        S2CTaskSgInfo pack = S2CPackBase.DeserializePack<S2CTaskSgInfo>(data);

                        TaskManager.Instance.BountyTaskInfo = new BountyTaskInfo(pack.id, pack.num, pack.is_reward);
                        if (TaskManager.Instance.BountyTaskInfo.id > 0 || TaskManager.Instance.BountyTaskInfo.is_reward == 0)
                        {
                            TaskManager.Instance.BountyTaskCoinReward = 0;
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.BOUNTY_TASK_CHANGED, null);

                        if (IsFirstReceiveBountyTaskInfo == false)
                        {
                            if (TaskManager.Instance.BountyTaskInfo.num >= TaskHelper.GetBountyTaskMaxTimes() && TaskManager.Instance.BountyTaskInfo.is_reward == 0)
                            {
                                if (SceneHelp.Instance.IsInWildInstance() == true)
                                {
                                    xc.ui.ugui.UIManager.Instance.ShowSysWindow("UITaskWindow", xc.GameConst.QUEST_SG, null);
                                }
                                else
                                {
                                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.OPEN_TASK_WINDOW, new CEventBaseArgs(xc.GameConst.QUEST_SG));
                                }
                            }
                        }

                        IsFirstReceiveBountyTaskInfo = false;

                        xc.ui.ugui.UIManager.Instance.ShowWaitScreen(false);

                        break;
                    }
                case NetMsg.MSG_TASK_REWARD_SG:
                    {
                        S2CTaskRewardSg pack = S2CPackBase.DeserializePack<S2CTaskRewardSg>(data);

                        TaskManager.Instance.BountyTaskCoinReward = pack.coin;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.BOUNTY_TASK_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_TASK_GUILD_INFO:
                    {
                        S2CTaskGuildInfo pack = S2CPackBase.DeserializePack<S2CTaskGuildInfo>(data);

                        TaskManager.Instance.GuildTaskInfo = new GuildTaskInfo(pack.id, pack.num, pack.reward_state);
                        //if (TaskManager.Instance.GuildTaskInfo.id > 0 || TaskManager.Instance.GuildTaskInfo.reward_state == 1)
                        //{
                        //    TaskManager.Instance.GuildTaskCtbReward = 0;
                        //}

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.GUILD_TASK_CHANGED, null);

                        if (IsFirstReceiveGuildTaskInfo == false && TaskManager.Instance.GuildTaskInfo.reward_state == 1)
                        {
                            if (TaskManager.Instance.GuildTaskInfo.num >= GameConstHelper.GetInt("GAME_QUEST_GUILD_PRE_NUM"))
                            {
                                if (SceneHelp.Instance.IsInWildInstance() == true)
                                {
                                    xc.ui.ugui.UIManager.Instance.ShowSysWindow("UITaskWindow", xc.GameConst.QUEST_GUILD, null);
                                }
                                else
                                {
                                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.OPEN_TASK_WINDOW, new CEventBaseArgs(xc.GameConst.QUEST_GUILD));
                                }
                            }
                        }

                        IsFirstReceiveGuildTaskInfo = false;

                        xc.ui.ugui.UIManager.Instance.ShowWaitScreen(false);

                        break;
                    }
                case NetMsg.MSG_TASK_REWARD_GUILD:
                    {
                        S2CTaskRewardGuild pack = S2CPackBase.DeserializePack<S2CTaskRewardGuild>(data);

                        TaskManager.Instance.GuildTaskCtbReward = pack.ctb;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.GUILD_TASK_CHANGED, null);

                        //UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("BAG_GET_GUILD_CTB"), pack.ctb));

                        break;
                    }
                case NetMsg.MSG_TASK_TRANSFER_INFO:
                    {
                        S2CTaskTransferInfo pack = S2CPackBase.DeserializePack<S2CTaskTransferInfo>(data);

                        TaskManager.Instance.TransferTaskInfo = pack;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.TRANSFER_TASK_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_TASK_REWARD_TRANSFER:
                    {
                        //暂时没有用到
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// 任务更新事件协程，避免短时间内多次刷新任务，造成卡顿
        /// </summary>
        static void StartTaskChangedCoroutine()
        {
            if (mTaskChangedCoroutine != null)
            {
                mTaskChangedCoroutine.Stop();
                mTaskChangedCoroutine = null;
            }

            if (mTaskChangedCoroutineDelayTime < 0f)
            {
                mTaskChangedCoroutineDelayTime = GameConstHelper.GetFloat("GAME_TASK_CHANGED_EVENT_DELAY");
            }

            // 如果配置成0，则立刻刷新
            if (mTaskChangedCoroutineDelayTime == 0f)
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_CHANGED, null);
            }
            else
            {
                mTaskChangedCoroutine = SafeCoroutine.CoroutineManager.StartCoroutine(TaskChangedCoroutine());
            }
        }

        static IEnumerator TaskChangedCoroutine()
        {
            yield return new SafeCoroutine.SafeWaitForSeconds(mTaskChangedCoroutineDelayTime);

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_CHANGED, null);

            mTaskChangedCoroutine = null;
        }
    }
}
