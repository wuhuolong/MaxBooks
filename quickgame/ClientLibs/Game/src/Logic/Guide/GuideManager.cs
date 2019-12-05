//---------------------------------------
// File:    GuideManager.cs
// Desc:    新手引导的管理器
// Author:  Raorui
// Date:    2017.9.20
//---------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using xc.protocol;
using xc.ui.ugui;
using Net;
using UnityEngine.EventSystems;
using Guide.Condition;

namespace xc
{
    [wxb.Hotfix]
    public class GuideManager : xc.Singleton<GuideManager>
    {
        /// <summary>
        /// 正在进行监听的引导步骤
        /// </summary>
        Dictionary<uint, Guide.Step> m_ListeningStepDict;

        /// <summary>
        /// 通过指令强制开启的引导步骤
        /// </summary>
        Dictionary<uint, Guide.Step> m_ForceStartStepDict;

        /// <summary>
        /// 射线检测时忽略的物体
        /// </summary>
        List<GameObject> m_IgnoreRaycastGameObjects;

        /// <summary>
        /// 更新的定时器
        /// </summary>
        Utils.Timer m_UpdateTimer;

        /// <summary>
        /// m_Dirty为true时，需要重新进行触发条件的监听
        /// </summary>
        bool m_Dirty;

        private DBGuideStep m_DBGuideStep;
        private DBGuide m_DBGuide;

        /// <summary>
        /// 是否有正在播放的指引步骤
        /// </summary>
        bool m_IsPlayingGuideStep;

        /// <summary>
        /// 当前正在播放的指引步骤
        /// </summary>
        Guide.Step m_PlayingGuideStep;

        /// <summary>
        ///  当前正在播放指引的表格数据
        /// </summary>
        GuideData mPlayingGuide;

        /// <summary>
        /// 是否已经开始引导的监听
        /// </summary>
        bool m_ListenerStarted;

        private const int LISTENER_INTERVAL = 100;
        private uint mCurGuidePlayerLevel = 0xffffffff;
        private bool mPause = false;
        public bool IsPause { get { return mPause; } }

        public bool TestGuide { get; set; }

        public Dictionary<uint, Guide.Step> ListeningStepDict { get { return m_ListeningStepDict; } }
        public Dictionary<uint, Guide.Step> ForceStartStepDict { get { return m_ForceStartStepDict; } }
        public List<GameObject> IgnoreRaycastGameObjects { get { return m_IgnoreRaycastGameObjects; } }

        public bool IsPlayingGuideStep
        {
            get
            {
                return (m_PlayingGuideStep != null);
            }
        }

        public Guide.Step PlayingGuideStep
        {
            get { return m_PlayingGuideStep; }
        }

        public bool IsPlayingForcibleStep
        {
            get
            {
                if (m_PlayingGuideStep != null && m_PlayingGuideStep.IsForcible)
                {
                    return true;
                }
                return false;
            }
        }

        public GuideManager()
        {
            TestGuide = false;
            m_ListeningStepDict = new Dictionary<uint, Guide.Step>();
            m_ForceStartStepDict = new Dictionary<uint, Guide.Step>();
            m_IgnoreRaycastGameObjects = new List<GameObject>();

            m_DBGuide = DBManager.GetInstance().GetDB<DBGuide>();
            m_DBGuideStep = DBManager.GetInstance().GetDB<DBGuideStep>();
        }

        // APIs
        public void RegisterAllMessages()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_ACTOR_BASEINFO_UPDATE, UpdatePlayerInfo);
            // 不能在开始切换场景的时候就清除当前指引，因此当前正在运行的指引可能还没有设置完成状态
            //ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnSwitchScene);
            //ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SWITCHINSTANCE, OnSwitchScene);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_FINISH_SWITCHSCENE, OnSwitchSceneFinish);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TIMELINE_START, OnTimelineStart);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TIMELINE_FINISH, OnTimelineFinish);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.TASK_FINISHED, OnTaskCompleted);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.TASK_NEW_ACCEPTED, OnGuideTrigger);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.TASK_CAN_SUBMIT, OnGuideTrigger);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_BAG_ADD, OnGuideTrigger); // 获取物品
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_FURYSKILL_CANUSE, OnGuideTrigger); // 怒气技能可用
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SOUL_UPDATE, OnGuideTrigger);  // 获取武魂
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);  // 网络断线重连
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_MAIN_DISCONNECT, OnNetDisconnect);  // 网络断开
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_CROSS_DISCONNECT, OnNetDisconnect); // 网络断开
            //ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_GUIDEEND, OnGuideTrigger); 

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_GUIDE_INFO, HandleServerData);
        }

        public void Reset()
        {
            m_ListeningStepDict.Clear();
            m_ForceStartStepDict.Clear();

            if (m_UpdateTimer != null)
            {
                m_UpdateTimer.Destroy();
                m_UpdateTimer = null;
            }

            if (m_DBGuide != null)
            {
                m_DBGuide.Reset();
                m_DBGuide = null;
            }

            if (m_DBGuideStep != null)
            {
                m_DBGuideStep.Reset();
                m_DBGuideStep = null;
            }

            m_FinishedBranchTask.Clear();
            m_TimelineStatus.Clear();
            m_Dirty = false;
            m_IsPlayingGuideStep = false;
            m_PlayingGuideStep = null;
            mPlayingGuide = null;
            m_ListenerStarted = false;
        }

        // Utils

        public delegate void WaitGuideFinishDelegate(uint guide_id);

        private WaitGuideFinishDelegate mWaitFinishCB = null;
        private uint mWaitFinishGuideId = 0;

        public void StartGuide(uint guide_id, WaitGuideFinishDelegate finish_cb)
        {
            StartGuide(guide_id, false, finish_cb);
        }

        void StartGuide(uint guide_id, bool once, WaitGuideFinishDelegate finish_cb)
        {
            var guide = m_DBGuide.GetGuideById(guide_id);
            var guide_step = m_DBGuideStep.GetCurrentStep(guide_id);

            if (guide_step != null && guide != null)
            {
                guide_step.IsFinished = false;

                mWaitFinishGuideId = guide_id;
                mWaitFinishCB = finish_cb;

                m_ForceStartStepDict[guide_id] = guide_step;
            }
            else if (finish_cb != null)
            {
                finish_cb(guide_id);
            }
        }

        public bool IsGuideForceStart(uint guide_id)
        {
            return m_ForceStartStepDict.ContainsKey(guide_id);
        }

        /// <summary>
        /// 开始新手引导(编辑器中使用)
        /// </summary>
        /// <param name="guide_id"></param>
        public void ForceReStartGuide(uint guide_id)
        {
            m_DBGuide.ResetGuide(guide_id);
            m_DBGuideStep.ResetAllStepStateByGuideId(guide_id);

            Guide.Step old_step;
            if (m_ListeningStepDict.TryGetValue(guide_id, out old_step))
            {
                m_ListeningStepDict[guide_id] = m_DBGuideStep.GetCurrentStep(guide_id);
            }
            else
            {
                StartGuide(guide_id, true, null);
            }
        }

        /// <summary>
        /// 将所有符合条件的引导放到m_ListeningStepDict字典中
        /// </summary>
        void ResetListener()
        {
            if (m_DBGuide == null)
                m_DBGuide = DBManager.GetInstance().GetDB<DBGuide>();

            if (m_DBGuideStep == null)
                m_DBGuideStep = DBManager.GetInstance().GetDB<DBGuideStep>();

            if(m_DBGuide == null || m_DBGuideStep == null)
                return;

            m_ListeningStepDict.Clear();

            var active_guide = m_DBGuide.GetActiveGuides();
            for (int i = 0; i < active_guide.Count; i++)
            {
                var guide = active_guide[i];
                var guide_step = m_DBGuideStep.GetCurrentStep(guide.Id);
                if (guide_step == null)
                    continue;

                if (m_ListeningStepDict.Count < 3)
                {
                    m_ListeningStepDict[guide.Id] = guide_step;
                }
                else
                {
                    break;
                }
            }

            m_Dirty = false;
        }

        public void ForceCheckGuides()
        {
            m_Dirty = true;
            CheckGuides(0f);
        }

        /// <summary>
        /// 检查是可否有满足条件的引导步骤，有的话则开启
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        bool CheckGuideDict(Dictionary<uint, Guide.Step> dict)
        {
            if (dict.Values.Count <= 0)
                return false;

            using(var enumerator = dict.GetEnumerator())
            {
                while(enumerator.MoveNext())
                {
                    var cur = enumerator.Current;
                    var guide_step = cur.Value;
                    if (guide_step == null)
                        continue;

                    // 如果有正在播的是非强制引导，则同一时间只能播一个非强制引导
                    if (m_PlayingGuideStep != null && (guide_step == m_PlayingGuideStep || !guide_step.IsForcible))
                        continue;

                    // 如果引导步骤的条件满足了，则开启改步骤
                    if (guide_step.CheckGuideCondition())
                    {
                        if (TryToStartGuideStep(guide_step))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 检查新手指引
        /// </summary>
        /// <param name="deltaTime"></param>
        void CheckGuides(float deltaTime)
        {
            // 提审状态开启时，不显示新手引导
            if (mPause || AuditManager.Instance.Open)
                return;

            // 更新当前的指引步骤
            if (m_IsPlayingGuideStep)
            {
                if (!m_PlayingGuideStep.TargetTrigger.Finished && !m_PlayingGuideStep.CheckGuideCondition())
                {
                    ResetGuideStep(m_PlayingGuideStep);
                    UIBaseWindow guidewnd = UIManager.Instance.GetWindow("UIGuideWindow");
                    if (guidewnd != null)
                    {
                        guidewnd.Close();
                    }
                }
                else if (m_PlayingGuideStep.TargetTrigger.IsAchieve())// 当前步骤已经完成
                {
                    FinishGuideStep(m_PlayingGuideStep);
                }
                else if (PlayingGuideStep.IsForcible)// 当前的强制指引未完成，不开启新的指引
                {
                    return;
                }
            }

            if (m_Dirty)
            {
                ResetListener();
            }

            if (!CheckGuideDict(m_ForceStartStepDict))
                CheckGuideDict(m_ListeningStepDict);
        }

        private bool TryToStartGuideStep(Guide.Step guideStep)
        {
            if(guideStep == null || guideStep.TargetTrigger == null)
            {
                return false;
            }

            m_IsPlayingGuideStep = guideStep.TryToStartup();
            if (m_IsPlayingGuideStep)
            {
                m_PlayingGuideStep = guideStep;
                mPlayingGuide = m_DBGuide.GetGuideById(guideStep.GuideId);
                mPlayingGuide.StartPlayerLevel = LocalPlayerManager.Instance.LocalActorAttribute.Level;
                mPlayingGuide.StartTime = Game.Instance.ServerTime;

                // 强制指引才停止寻路
                if (guideStep.IsForcible)
                    TargetPathManager.Instance.StopPlayerAndReset();

                // 暂停副本
                if (guideStep.IsPause)
                {
                    var local_player = Game.Instance.GetLocalPlayer();
                    if (local_player != null)
                        local_player.Stop();

                    C2SDungeonStopAi stop_ai = new C2SDungeonStopAi();
                    NetClient.GetBaseClient().SendData<C2SDungeonStopAi>(NetMsg.MSG_DUNGEON_STOP_AI, stop_ai);

                    InstanceHelper.PauseInstance();
                }

                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GUIDESTART, new CEventBaseArgs(guideStep.GuideId));

                // 为了防止新手配置问题导致引导一直卡住，在第一次播放引导时就标记为已完成
                /*if (guideStep.StepId == 1 && !guideStep.IsForcible)
                {
                    if (!TestGuide)
                    {
                        SendFinishGuide(guideStep.GuideId);
                    }
                }*/
            }
            return m_IsPlayingGuideStep;
        }

        /// <summary>
        /// 与服务端同步指引步骤
        /// </summary>
        /// <param name="guide_id"></param>
        /// <param name="finish_type"> 完成引导的类型 (1: 正常 0: 跳过)</param>
        void SendFinishGuide(uint guide_id, Guide.Step guide_step, uint finish_type)
        {
            var pack = new C2SPlayerGuideMark();
            pack.guide_id = guide_id;
            NetClient.GetBaseClient().SendData<C2SPlayerGuideMark>(NetMsg.MSG_PLAYER_GUIDE_MARK, pack);

            var guide = m_DBGuide.GetGuideById(guide_id);
            if(guide_step != null && guide != null)
            {
                var guide_log = new C2SPlayerGuideLog();
                guide_log.guide_id = guide_id;
                guide_log.sub_id = guide_step.StepId;
                guide_log.start_time = guide.StartTime;
                guide_log.start_lv = guide.StartPlayerLevel;
                guide_log.finish_type = finish_type;
                guide_log.state = 1; // 默认都是成功的
                NetClient.GetBaseClient().SendData<C2SPlayerGuideLog>(NetMsg.MSG_PLAYER_GUIDE_LOG, guide_log);
            }
        }

        public void FinishGuideStep(uint guideId, uint stepId)
        {
            foreach (KeyValuePair<uint, Guide.Step> kvp in m_ListeningStepDict)
            {
                if (kvp.Value.GuideId == guideId && kvp.Value.StepId == stepId)
                {
                    FinishGuideStep(kvp.Value);
                    break;
                }
            }
        }

        /// <summary>
        /// 完成指定的GuideStep
        /// </summary>
        /// <param name="guide_step"></param>
        void FinishGuideStep(Guide.Step guide_step)
        {
            if (guide_step == null)
                return;

            guide_step.IsFinished = true;

            if(guide_step.IsCanFinish)
                SendFinishGuide(guide_step.GuideId, guide_step, 1);

            // 如果是最后一步,则完成指引序列
            if (m_DBGuideStep.IsLastGuidesStep(guide_step))
            {
                uint guide_id = guide_step.GuideId;
                var guide = m_DBGuide.GetGuideById(guide_id);
                if (guide != null)
                {
                    guide.IsFinished = true;

                    // 完成后是否自动战斗
                    if (guide.AutoFightWhenFinish == true)
                    {
                        InstanceManager.Instance.IsAutoFighting = true;
                    }

                    // 完成后是否播放剧情
                    if (guide.TimelineWhenFinish > 0)
                    {
                        TimelineManager.Instance.Play(guide.TimelineWhenFinish);
                    }
                }

                // 可能IsCanFinish都没有设置
                SendFinishGuide(guide_step.GuideId, guide_step, 1);

                m_ListeningStepDict.Remove(guide_id);
                m_ForceStartStepDict.Remove(guide_id);

                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GUIDEEND, new CEventBaseArgs(guide_id));
                m_Dirty = true;
                m_IsPlayingGuideStep = false;
                m_PlayingGuideStep = null;
                mPlayingGuide = null;

                if (mWaitFinishCB != null && mWaitFinishGuideId == guide_id)
                {
                    var cb = mWaitFinishCB;

                    mWaitFinishCB = null;
                    mWaitFinishGuideId = 0;

                    cb(guide_id);
                }
            }
            else// 更新下一步的指引步骤
            {
                m_IsPlayingGuideStep = false;
                m_PlayingGuideStep = null;

                var new_guide_step = m_DBGuideStep.GetCurrentStep(guide_step.GuideId);
                if (new_guide_step != null)
                {
                    uint new_guide_id = new_guide_step.GuideId;
                    Guide.Step old_step;
                    if (m_ForceStartStepDict.TryGetValue(new_guide_id, out old_step))
                    {
                        m_ForceStartStepDict[new_guide_id] = new_guide_step;
                    }
                    else if (m_ListeningStepDict.TryGetValue(new_guide_id, out old_step))
                    {
                        m_ListeningStepDict[new_guide_id] = new_guide_step;
                    }
                }
            }
        }

        /// <summary>
        /// 跳过指定的和剩下的引导步骤
        /// </summary>
        /// <param name="guide_step"></param>
        public void SkipGuideStep(Guide.Step guide_step)
        {
            if (guide_step == null)
                return;

            guide_step.IsFinished = true;

            uint guide_id = guide_step.GuideId;
            var guide = m_DBGuide.GetGuideById(guide_id);
            if (guide != null)
            {
                guide.IsFinished = true;

                // 完成后是否自动战斗
                if (guide.AutoFightWhenFinish == true)
                {
                    InstanceManager.Instance.IsAutoFighting = true;
                }

                // 完成后是否播放剧情
                if (guide.TimelineWhenFinish > 0)
                {
                    TimelineManager.Instance.Play(guide.TimelineWhenFinish);
                }
            }

            SendFinishGuide(guide_step.GuideId, guide_step, 0);

            m_ListeningStepDict.Remove(guide_id);
            m_ForceStartStepDict.Remove(guide_id);

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_GUIDEEND, new CEventBaseArgs(guide_id));

            m_Dirty = true;
            m_IsPlayingGuideStep = false;
            m_PlayingGuideStep = null;
            mPlayingGuide = null;

            if (mWaitFinishCB != null && mWaitFinishGuideId == guide_id)
            {
                var cb = mWaitFinishCB;
                mWaitFinishCB = null;
                mWaitFinishGuideId = 0;
                cb(guide_id);
            }
        }

        /// <summary>
        /// 跳过当前的引导
        /// </summary>
        public void SkipCurrentGuide()
        {
            if (m_IsPlayingGuideStep)
            {
                if (m_PlayingGuideStep != null && m_PlayingGuideStep.TargetTrigger != null)
                    m_PlayingGuideStep.TargetTrigger.NotifyClick();

                SkipGuideStep(m_PlayingGuideStep);
            }
        }

        private void StopGuideStep(Guide.Step guideStep)
        {
            FinishGuideStep(guideStep);

            m_Dirty = true;
            m_IsPlayingGuideStep = false;
            m_PlayingGuideStep = null;
        }

        private void ResetGuideStep(Guide.Step guideStep)
        {
            guideStep.Reset();

            if (guideStep == m_PlayingGuideStep)
            {
                m_Dirty = true;
                m_IsPlayingGuideStep = false;
                m_PlayingGuideStep = null;
            }
        }

        /// <summary>
        /// 玩家等级发生变化时，需要进行触发条件的重新监听
        /// </summary>
        /// <param name="arg"></param>
        void UpdatePlayerInfo(CEventBaseArgs arg)
        {
            if (!m_ListenerStarted || m_IsPlayingGuideStep)
            {
                return;
            }

            if (mCurGuidePlayerLevel != LocalPlayerManager.Instance.LocalActorAttribute.Level)
            {
                mCurGuidePlayerLevel = LocalPlayerManager.Instance.LocalActorAttribute.Level;
                m_Dirty = true;
            }
        }

        /// <summary>
        /// 切换场景完毕
        /// </summary>
        /// <param name="evt"></param>
        private void OnSwitchSceneFinish(CEventBaseArgs evt)
        {
            Debug.Log("OnSwitchSceneFinish");

            // 切换场景时，指引窗口已经被销毁了，因此需要清除掉当前正在运行的指引
            if (m_IsPlayingGuideStep)
            {
                m_IsPlayingGuideStep = false;
                m_PlayingGuideStep = null;
                mPlayingGuide = null;
            }

            m_ForceStartStepDict.Clear();
            m_ListeningStepDict.Clear();
            m_TimelineStatus.Clear();

            m_Dirty = true;
            UIManager.Instance.CloseWindow("UIGuideWindow");
            UIManager.Instance.ShowWindow("UIGuideWindow");

            // 如果新手引导在断线重连等情况下被暂停了，需要恢复
            //if(mPause)
            //  Resume();
        }

        #region 任务条件
        private ushort GetTaskType(uint task_id)
        {
            return TaskDefine.GetTaskType(task_id);
        }

        /// <summary>
        /// 因为任务完成后就被删掉了，所以需要缓存已经完成的任务ID
        /// 主线可以通过任务ID大小来判断
        /// </summary>
        Dictionary<uint, bool> m_FinishedBranchTask = new Dictionary<uint, bool>();

        /// <summary>
        /// 保存进入副本就立即播放的剧情的状态
        /// </summary>
        Dictionary<uint, bool> m_TimelineStatus = new Dictionary<uint, bool>();

        /// <summary>
        /// 任务完成的消息响应
        /// </summary>
        /// <param name="args"></param>
        void OnTaskCompleted(CEventBaseArgs args)
        {
            var taskId = (uint)(args.arg);
            if (TaskDefine.GetTaskType(taskId) != GameConst.QUEST_MAIN)
            {
                m_FinishedBranchTask[taskId] = true;
            }

            // 已经开始监听并且没有正在执行的指引步骤或者正在执行的是弱指引
            if (m_ListenerStarted)
            {
                if(!m_IsPlayingGuideStep || (m_PlayingGuideStep != null && !m_PlayingGuideStep.IsForcible))
                    m_Dirty = true;
            }
        }


        /// <summary>
        /// 响应剧情开始播放的消息
        /// </summary>
        /// <param name="data"></param>
        void OnTimelineStart(CEventBaseArgs data)
        {
            var timeline_id = (uint)(data.arg);
            m_TimelineStatus[timeline_id] = true;
        }

        /// <summary>
        /// 响应剧情播放完毕的消息
        /// </summary>
        /// <param name="data"></param>
        void OnTimelineFinish(CEventBaseArgs data)
        {
            var timeline_id = (uint)(data.arg);
            m_TimelineStatus[timeline_id] = false;

            // 已经开始监听并且没有正在执行的指引步骤或者正在执行的是弱指引
            if (m_ListenerStarted)
            {
                if (!m_IsPlayingGuideStep || (m_PlayingGuideStep != null && !m_PlayingGuideStep.IsForcible))
                    m_Dirty = true;
            }
        }

        /// <summary>
        /// 新手引导的触发条件发生变化
        /// </summary>
        /// <param name="args"></param>
        void OnGuideTrigger(CEventBaseArgs args)
        {
            // 已经开始监听并且没有正在执行的指引步骤或者正在执行的是弱指引
            if (m_ListenerStarted)
            {
                if (!m_IsPlayingGuideStep || (m_PlayingGuideStep != null && !m_PlayingGuideStep.IsForcible))
                    m_Dirty = true;
            }
        }

        /// <summary>
        /// 响应网络断线重连成功的消息
        /// </summary>
        /// <param name="args"></param>
        void OnNetReconnect(CEventBaseArgs args)
        {
            Debug.Log("OnNetReconnect");
            // 如果新手引导在断线重连等情况下被暂停了，需要恢复
            //if (mPause)
            //    Resume();

            //OnSwitchSceneFinish(null);
        }

        /// <summary>
        /// 响应网络连接断开的消息
        /// </summary>
        /// <param name="args"></param>
        void OnNetDisconnect(CEventBaseArgs args)
        {
            Pause();
            Resume();
        }

        /// <summary>
        /// 检查任务是否已经完成
        /// </summary>
        /// <param name="task_id"></param>
        /// <returns></returns>
        public bool IsTaskFinished(uint task_id)
        {
            var task_type = GetTaskType(task_id);
            if (task_type == GameConst.QUEST_MAIN)
                return TaskManager.Instance.IsMainTaskFinished(task_id);
            else
                return m_FinishedBranchTask.ContainsKey(task_id);
        }

        /// <summary>
        /// 剧情是否已经播放过并且播放完毕
        /// </summary>
        /// <param name="timeline_id"></param>
        /// <returns></returns>
        public bool IsTimelineFinish(uint timeline_id)
        {
            bool status = false;
            if (m_TimelineStatus.TryGetValue(timeline_id, out status))
            {
                return status == false;
            }
            else
                return false;

        }
        #endregion

        /// <summary>
        /// 开启引导的监听
        /// </summary>
        void StartupListener()
        {
            if (m_ListenerStarted)
            {
                if (!m_IsPlayingGuideStep)
                {
                    ResetListener();
                }
                return;
            }
            m_ListenerStarted = true;

            ResetListener();

            if (m_UpdateTimer != null)
            {
                m_UpdateTimer.Destroy();
                m_UpdateTimer = null;
            }

            m_UpdateTimer = new Utils.Timer(LISTENER_INTERVAL, true, Mathf.Infinity, CheckGuides);
        }

        public void TryToFinishGuideStep(Guide.Step guideStep)
        {
            if (!guideStep.TargetTrigger.IsAchieve())
            {
                return;
            }
            FinishGuideStep(guideStep);
        }

        public bool TryToStopGuideStep(Guide.Step guideStep)
        {
            StopGuideStep(guideStep);
            return true;
        }

        public void TryToResetGuideStep(Guide.Step guideStep)
        {
            ResetGuideStep(guideStep);
        }

        protected bool mEnableGuide = true;
        protected int mEnableRef = 0;

        public void Pause()
        {
            mEnableRef++;
            if (mEnableRef <= 0)
                mEnableGuide = true;
            else
                mEnableGuide = false;

            mPause = !mEnableGuide;

            if (m_PlayingGuideStep == null)
            {
                return;
            }
            TryToResetGuideStep(m_PlayingGuideStep);

            UIManager.Instance.CloseWindow("UIGuideWindow");
        }

        public void Resume()
        {
            mEnableRef--;
            if (mEnableRef <= 0)
                mEnableGuide = true;
            else
                mEnableGuide = false;

            mPause = !mEnableGuide;

            ForceCheckGuides();
        }

        /// <summary>
        /// 重设引用计数
        /// </summary>
        public void ResetEnableRef()
        {
            mEnableRef = 0;
            mEnableGuide = true;
        }

        /// <summary>
        /// 强制关闭所有引导(GM指令)
        /// </summary>
        public void ForceToSleepGuide()
        {
            var db_guide = DBManager.GetInstance().GetDB<DBGuide>();
            if (db_guide != null)
            {
                var guide_list = db_guide.GuideList;
                if (guide_list != null)
                {
                    foreach (var guide in guide_list)
                    {
                        guide.IsFinished = true;
                        SendFinishGuide(guide.Id, null, 0);
                    }
                }
            }

            //mIsSleep = true;
            //GlobalSettings.GetInstance().SetSleepGuide();

            //if (m_PlayingGuideStep != null)
            //{
            //    FinishGuideStep(m_PlayingGuideStep);
            //}

            //UIManager.GetInstance().DestroyWindow<UIGuideWindow>();
            UIManager.Instance.CloseWindow("UIGuideWindow");
        }

        /// <summary>
        /// 重置所有指引的状态为未完成(调试用)
        /// </summary>
        public void ResetAllSysGuide()
        {
            DBGuide dbGuide = DBManager.GetInstance().GetDB<DBGuide>();
            dbGuide.Reset();

            DBGuideStep db_guide_step = DBManager.GetInstance().GetDB<DBGuideStep>();
            db_guide_step.Reset();
            m_Dirty = true;
        }

        /// <summary>
        /// 根据控件路径获取控件
        /// 
        /// 路径格式为：窗口名:控件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public GameObject GetWidgetByPath(string path)
        {
            var obj_names = path.Split(new char[] { ':' });
            if (obj_names.Length <= 1)
                return null;

            var wnd_name = obj_names[0];
            var widget_path = obj_names[1];

            var wnd = ui.ugui.UIManager.GetInstance().GetWindow(wnd_name);
            if (wnd == null || !wnd.IsShow)
                return null;

            return wnd.FindWidgetByPath(widget_path);
        }

        private PointerEventData pointerData;

        /// <summary>
        /// 判断控件是否可见
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        public bool IsWidgetVisible(GameObject widget)
        {
            if (widget == null)
                return false;

            bool widget_is_visible = false;
            RectTransform rect_trans = widget.GetComponent<RectTransform>();
            if (rect_trans != null)
            {
                Vector3[] world_corner = new Vector3[4];
                rect_trans.GetWorldCorners(world_corner);
                Camera current_cam = UIMainCtrl.MainCam;
                if(current_cam != null)
                {
                    Vector3 center = (world_corner[0] + world_corner[2])*0.5f;
                    var screen_pos = current_cam.WorldToScreenPoint(center);

                    if (pointerData == null)
                    {
                        pointerData = new PointerEventData(EventSystem.current);
                    }

                    bool hasGuideWindow = false;
                    for (int i = m_IgnoreRaycastGameObjects.Count - 1; i >= 0; i --)
                    {
                        if (m_IgnoreRaycastGameObjects[i] == null)
                        {
                            m_IgnoreRaycastGameObjects.Remove(m_IgnoreRaycastGameObjects[i]);
                            continue;
                        }
                        if (m_IgnoreRaycastGameObjects[i].name == "UIGuideWindow")
                        {
                            hasGuideWindow = true;
                            break;
                        }
                    }
                    if (!hasGuideWindow)
                    {
                        UIBaseWindow guidewnd = UIManager.Instance.GetWindow("UIGuideWindow");
                        if (guidewnd != null)
                        {
                            m_IgnoreRaycastGameObjects.Add(guidewnd.mUIObject);
                        }
                    }

                    var hit_obj = UGUIMath.GetRaycastObj(screen_pos, pointerData, m_IgnoreRaycastGameObjects, true);
                    if (hit_obj != null && UGUIMath.ContainWidget(widget, hit_obj))
                        widget_is_visible = true;
                }
            }

            return widget.activeInHierarchy && widget_is_visible;
        }

        /// <summary>
        /// 判断是否满足组件的条件（图片名称，文本内容）
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        public bool MatchComponent(GameObject widget, string path)
        {
            var pathParams = path.Split(new char[] { ':' });
            if (pathParams.Length <= 2) //没有组件条件，当做满足处理
                return true;
            if (pathParams.Length <= 3) //配置格式错误
                return false;

            var componentType = pathParams[2];
            var componentValue = pathParams[3];

            if (componentType == "Image")
            {
                Image image = widget.GetComponent<Image>();
                return image != null && image.sprite.name == componentValue;
            }
            else if (componentType == "Text")
            {
                Text text = widget.GetComponent<Text>();
                return text != null && text.text == DBConstText.GetText(componentValue);
            }
            else if (componentType == "GoodsNameText")
            {
                Text text = widget.GetComponent<Text>();
                uint goodsId;
                if (!uint.TryParse(componentValue, out goodsId))
                {
                    return false;
                }
                return text != null && text.text == GoodsHelper.GetGoodsOriginalNameByTypeId(goodsId);
            }
            if (componentType == "RawImage")
            {
                RawImage rawImage = widget.GetComponent<RawImage>();
                return rawImage != null && rawImage.mainTexture.name == componentValue;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断控件是否当前被触摸到
        /// </summary>
        /// <param name="widget"></param>
        /// <returns></returns>
        public bool IsWidgetTouched(GameObject widget)
        {
            if (widget == null)
                return false;

            bool widget_is_visible = false;
            RectTransform rect_trans = widget.GetComponent<RectTransform>();
            if (rect_trans != null)
            {
                Camera current_cam = UIMainCtrl.MainCam;
                if (current_cam != null)
                {
                    var screen_pos = Input.mousePosition;

                    if (pointerData == null)
                    {
                        pointerData = new PointerEventData(EventSystem.current);
                    }

                    var hit_obj = UGUIMath.GetRaycastObj(screen_pos, pointerData);
                    if (hit_obj != null && UGUIMath.ContainWidget(widget, hit_obj))
                        widget_is_visible = true;
                }
            }

            return widget.activeInHierarchy && widget_is_visible;
        }

        /// <summary>
        /// 判断是否是其父/祖宗节点
        /// </summary>
        /// <param name="parentWidget"></param>
        /// <param name="childWidget"></param>
        /// <returns></returns>
        public bool IsParent(GameObject parentWidget, GameObject childWidget)
        {
            if(parentWidget == null || childWidget == null)
            {
                return false;
            }

            if(childWidget.transform.parent == null)
            {
                return false;
            }

            if(childWidget.transform.parent != parentWidget.transform)
            {
                return IsParent(parentWidget, childWidget.transform.parent.gameObject);
            }

            return true;
        }

        public void ForceFinishAllGuides()
        {
            DBManager.GetInstance().GetDB<DBGuide>().FinishAllSysGuide();
        }

        /// <summary>
        /// 当前步骤是否正在引导点开某一系统按钮
        /// </summary>
        /// <returns></returns>
        public bool IsSysGuideStepPlaying()
        {
            var step = m_PlayingGuideStep;
            if (step == null || step.IsFinished)
                return false;

            if(step.IsForcible)
            {
                foreach(var condition in step.GuideTriggerList)
                {
                    var sys_condition = condition as GuideConditionSysBtnIsShow;
                    if (sys_condition != null)
                    {
                        var sys_config = DBManager.Instance.GetDB<DBSysConfig>().GetConfigById(sys_condition.SysId);
                        if (sys_config != null && (sys_config.Pos == DBSysConfig.ESysBtnPos.SYS_LBBTN_POS || sys_config.Pos == DBSysConfig.ESysBtnPos.SYS_TRBTN_POS))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 当前步骤是否正在播放引导
        /// </summary>
        /// <returns></returns>
        public bool IsGuidePlaying()
        {
            var step = m_PlayingGuideStep;
            if (step == null || step.IsFinished)
                return false;

            return true;
        }

        /// <summary>
        /// 系统开放的动画是否正在播放过程中
        /// </summary>
        /// <returns></returns>
        public bool IsSysOpenPlaying()
        {
            var mainmap_window = UIManager.Instance.GetWindow("UIMainmapWindow");
            if (mainmap_window == null || !mainmap_window.IsShow)
            {
                return false;
            }

            var mainmap_system = mainmap_window.GetBehaviour("UIMainMapSysOpenBehaviour") as UIMainMapSysOpenBehaviour;
            if (mainmap_system == null)
                return false;

            return mainmap_system.IsSysOpenPlaying;
        }

        // Events
        void HandleServerData(ushort protocol, byte[] data)
        {
            if (m_DBGuide == null)
                m_DBGuide = DBManager.GetInstance().GetDB<DBGuide>();

            if(m_DBGuide == null)
                return;

            switch (protocol)
            {
                case NetMsg.MSG_PLAYER_GUIDE_INFO:
                    {
                        var guide_info = S2CPackBase.DeserializePack<S2CPlayerGuideInfo>(data);
                        foreach (uint guide_id in guide_info.guide_ids)
                        {
                            var guide = m_DBGuide.GetGuideById(guide_id);
                            if (guide == null)
                            {
                                continue;
                            }

                            guide.IsFinished = true;
                            GameDebug.Log("Finished guide id : " + guide_id);
                        }

                        StartupListener();
                        break;
                    }
            }
        }

        /// <summary>
        /// 获取所有正在执行的系统新手指引id
        /// </summary>
        /// <returns></returns>
        public List<uint> GetPlayingGuides()
        {
            List<uint> guide_ids = new List<uint>();
            guide_ids.Clear();

            foreach (Guide.Step guide_step in m_ListeningStepDict.Values)
            {
                if (guide_step.CheckGuideCondition() == true)
                {
                    guide_ids.Add(guide_step.GuideId);
                }
            }
            foreach (Guide.Step guide_step in m_ForceStartStepDict.Values)
            {
                if (guide_step.CheckGuideCondition() == true)
                {
                    guide_ids.Add(guide_step.GuideId);
                }
            }

            return guide_ids;
        }

        /// <summary>
        /// 点击屏幕的委托函数
        /// </summary>
        public delegate void OnTouchedDelegate();
        public OnTouchedDelegate OnTouched;

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if(OnTouched != null)
            {
                var invock_list = OnTouched.GetInvocationList();
                if(invock_list != null && invock_list.Length > 0)
                {
                    var touched = ProcessTouches();
                    if(touched)
                    {
                        OnTouched();
                    }
                }
            }
        }

        /// <summary>
        /// 处理触摸屏点击的判断
        /// </summary>
        bool ProcessTouches()
        {
            bool touched = false;

#if UNITY_ANDROID || UNITY_IPHONE
            if (Input.touchCount <= 0)
                return false;

            Touch input = Input.GetTouch(0);
            //bool pressed = (input.phase == TouchPhase.Began);
            bool unpressed = (input.phase == TouchPhase.Canceled) || (input.phase == TouchPhase.Ended);

            if (unpressed)
            {
                touched = true;
            }
#else
            if (Input.GetMouseButtonDown(0))// 响应鼠标左键消息
            {
                touched = true;
            }
#endif
            return touched;
        }



        /// <summary>
        /// 判断引导是否结束
        /// </summary>
        /// <param name="guide_id">引导id</param>
        /// <returns>是否结束</returns>
        public bool IsGuideFinish(uint guide_id)
        {
            return DBManager.GetInstance().GetDB<DBGuide>().IsGuideFinish(guide_id);
        }


    }
}