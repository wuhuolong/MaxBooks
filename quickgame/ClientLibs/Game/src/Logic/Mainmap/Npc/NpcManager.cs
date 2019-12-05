//------------------------------------------------------------------------------
// Desc   :  Npc管理类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using xc.ui;

namespace xc
{
    [wxb.Hotfix]
    public class NpcManager : xc.Singleton<NpcManager>
    {
        private const uint mStartId = 0;// ClientModelStartId预留300给NPC和膜拜雕像使用，0-99给普通NPC

        private const uint mEscortNpcStartID = 100;// 100-199给护送NPC
        private const uint mEscortNpcIDCount = 100;
        private uint mEscortNpcIndex = 0;

        private Dictionary<uint, ActorMono> mNpcs = new Dictionary<uint, ActorMono>();
        private Dictionary<uint, ActorMono> mEscortNpcs = new Dictionary<uint, ActorMono>();    // 护送NPC
        private List<uint> mCreatings = new List<uint>();    //记录创建中的NPC id

        SafeCoroutine.Coroutine mRefreshTaskNpcCoroutine = null;

        /// <summary>
        /// 正在寻路的npc的id
        /// </summary>
        uint mNavigatingNpcId;
        public uint NavigatingNpcId
        {
            get
            {
                return mNavigatingNpcId;
            }
            set
            {
                mNavigatingNpcId = value;
            }
        }

        /// <summary>
        /// 正在使用飞鞋跳转的npc的id
        /// </summary>
        public uint TravelBootsJumpNpcId;


        public void AddNpc(NpcPlayer npc)
        {
            if(npc == null)
            {
                return;
            }

            mCreatings.Remove(npc.UID.obj_idx);

            if (npc.IsEscortNPC == false)
            {
                mNpcs[npc.UID.obj_idx] = npc.GetActorMono();
            }
            else
            {
                mEscortNpcs[npc.UID.obj_idx] = npc.GetActorMono();
            }
        }

        public void RemoveNpc(NpcPlayer npc)
        {
            if(npc == null)
            {
                return;
            }
            
            if (mNpcs.ContainsKey(npc.UID.obj_idx))
            {
                mNpcs.Remove(npc.UID.obj_idx);
            }
            if (mEscortNpcs.ContainsKey(npc.UID.obj_idx))
            {
                mEscortNpcs.Remove(npc.UID.obj_idx);
            }
        }

        public void DestroyNpc(NpcPlayer npc)
        {
            if (npc != null)
            {
                RemoveNpc(npc);
                ActorManager.Instance.DestroyActor(npc.UID);
            }
        }
        
        public NpcManager()
        {
            // 注册客户端消息
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CLICKNPC, OnNpcClicked);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.TASK_CHANGED, OnTaskChanged);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.TASK_NEW_ACCEPTED, OnTaskNewAccepted);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.TASK_CAN_SUBMIT, OnTaskCanSubmit);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_FINISH_LOAD_LEVEL, OnFinishLoadLevel);
        }
        
        ~NpcManager ()
        {
            // 取消注册客户端消息
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CLICKNPC, OnNpcClicked);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.TASK_CHANGED, OnTaskChanged);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.TASK_NEW_ACCEPTED, OnTaskNewAccepted);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.TASK_CAN_SUBMIT, OnTaskCanSubmit);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_FINISH_LOAD_LEVEL, OnFinishLoadLevel);
        }
    
        //--------------------------------------------------------
        //  内部调用
        //--------------------------------------------------------
        private void BuildNpcCache()
        {
            Dictionary<int, Neptune.BaseGenericNode> npcs = Neptune.DataManager.Instance.Data.GetData<Neptune.NPC>().Data;
            foreach (Neptune.NPC npc in npcs.Values)
            {
                if (npc.SpawnDirectly == true && TaskHelper.ShouldDeleteNpcInCurMainTask(npc.Id) == false)
                {
                    CreateNPC(npc);
                    mDoNotGuideNpcIds.Add(npc.Id);
                }
            }
        }

        /// <summary>
        /// 不执行指引的npc
        /// </summary>
        List<int> mDoNotGuideNpcIds = new List<int>();
        public bool NpcCanGuide(int npcId)
        {
            if (mDoNotGuideNpcIds.Contains(npcId) == true)
            {
                return false;
            }

            return true;
        }

        public void RemoveNpcInDoNotGuideList(int npcId)
        {
            if (mDoNotGuideNpcIds.Contains(npcId) == true)
            {
                mDoNotGuideNpcIds.Remove(npcId);
            }
        }

        /// <summary>
        /// 重新创建当前交互物体对应的NPC
        /// </summary>
        private void RefreshCurrentInteractNpcs()
        {
            List<int> npcIds = TaskManager.Instance.GetNpcIdsByCurrentInteractGoal();
            foreach (int npcId in npcIds)
            {
                if (TaskHelper.ShouldDeleteNpcInCurMainTask(npcId) == false)
                {
                    DestroyNpc(GetNpcByNpcId((uint)npcId));
                    CreateNPC(npcId);
                    mDoNotGuideNpcIds.Add(npcId);
                }
            }
        }

        private void RefreshCurrentInteractNpcs(uint taskId)
        {
            List<int> npcIds = TaskManager.Instance.GetNpcIdsByCurrentInteractGoal(taskId);
            Task task = TaskManager.Instance.GetTask(taskId);
            foreach (int npcId in npcIds)
            {
                if (TaskHelper.ShouldDeleteNpcInCurMainTask(npcId) == false)
                {
                    if (GetNpcByNpcId((uint)npcId) == null)
                    {
                        CreateNPC(npcId);

                        if (task != null && task.Define.Type == GameConst.QUEST_SG && TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true)
                        {
                            mDoNotGuideNpcIds.Add(npcId);
                        }
                        if (task != null && task.Define.Type == GameConst.QUEST_GUILD && TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true)
                        {
                            mDoNotGuideNpcIds.Add(npcId);
                        }
                    }
                }
            }
        }

        void CreateAllNewAcceptedAndDoneTaskNpcs()
        {
            foreach (Task task in TaskManager.Instance.GetTasksByType(GameConst.QUEST_MAIN))
            {
                CreateAcceptedTaskNpcs(task.Define.Id, true);
                CreateDoneTaskNpcs(task.Define.Id, true);
            }
        }

        void CreateAcceptedTaskNpcs(uint taskId, bool doNotGuide = false)
        {
            Task task = TaskManager.Instance.GetTaskByTypeAndId(GameConst.QUEST_MAIN, taskId);
            uint instanceId = SceneHelp.Instance.CurSceneID;
            if (task != null && task.Define.CreateNpcsWhenReceived != null)
            {
                foreach (NpcScenePosition npcScenePosition in task.Define.CreateNpcsWhenReceived)
                {
                    if (npcScenePosition.SceneId == instanceId)
                    {
                        int npcId = (int)npcScenePosition.NpcId;
                        if (TaskHelper.ShouldDeleteNpcInCurMainTask(npcId) == false)
                        {
                            CreateNPC(npcId);

                            if (doNotGuide == true || (task.Define.Type == GameConst.QUEST_SG && TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true)
                                || (task.Define.Type == GameConst.QUEST_GUILD && TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true))
                            {
                                mDoNotGuideNpcIds.Add(npcId);
                            }
                        }
                    }
                }
            }
            List<uint> preMainTasksId = TaskHelper.GetPreMainTasksId(taskId);
            foreach (uint preMainTaskId in preMainTasksId)
            {
                List<NpcScenePosition> createNpcsWhenReceived = TaskDefine.GetCreateNpcsWhenReceived(preMainTaskId);
                if (createNpcsWhenReceived != null)
                {
                    foreach (NpcScenePosition npcScenePosition in createNpcsWhenReceived)
                    {
                        if (npcScenePosition.SceneId == instanceId)
                        {
                            int npcId = (int)npcScenePosition.NpcId;
                            if (TaskHelper.ShouldDeleteNpcInCurMainTask(npcId) == false)
                            {
                                CreateNPC(npcId);

                                if (doNotGuide == true || (task.Define.Type == GameConst.QUEST_SG && TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true)
                                    || (task.Define.Type == GameConst.QUEST_GUILD && TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true))
                                {
                                    mDoNotGuideNpcIds.Add(npcId);
                                }
                            }
                        }
                    }
                }
            }
        }

        void DeleteAcceptedTaskNpcs(uint taskId)
        {
            Task task = TaskManager.Instance.GetTaskByTypeAndId(GameConst.QUEST_MAIN, taskId);
            uint instanceId = SceneHelp.Instance.CurSceneID;
            if (task != null && task.Define.DeleteNpcsWhenReceived != null)
            {
                foreach (NpcScenePosition npcScenePosition in task.Define.DeleteNpcsWhenReceived)
                {
                    if (npcScenePosition.SceneId == instanceId)
                    {
                        DestroyNpc(GetNpcByNpcId(npcScenePosition.NpcId));
                    }
                }
            }
            List<uint> preMainTasksId = TaskHelper.GetPreMainTasksId(taskId);
            foreach (uint preMainTaskId in preMainTasksId)
            {
                List<NpcScenePosition> deleteNpcsWhenReceived = TaskDefine.GetDeleteNpcsWhenReceived(preMainTaskId);
                if (deleteNpcsWhenReceived != null)
                {
                    foreach (NpcScenePosition npcScenePosition in deleteNpcsWhenReceived)
                    {
                        if (npcScenePosition.SceneId == instanceId)
                        {
                            DestroyNpc(GetNpcByNpcId(npcScenePosition.NpcId));
                        }
                    }
                }
            }
        }

        void CreateDoneTaskNpcs(uint taskId, bool doNotGuide = false)
        {
            Task task = TaskManager.Instance.GetTaskByTypeAndId(GameConst.QUEST_MAIN, taskId);
            uint instanceId = SceneHelp.Instance.CurSceneID;
            if (task != null && task.Define.CreateNpcsWhenDone != null && task.State == GameConst.QUEST_STATE_DONE)
            {
                foreach (NpcScenePosition npcScenePosition in task.Define.CreateNpcsWhenDone)
                {
                    if (npcScenePosition.SceneId == instanceId)
                    {
                        int npcId = (int)npcScenePosition.NpcId;
                        if (TaskHelper.ShouldDeleteNpcInCurMainTask(npcId) == false)
                        {
                            CreateNPC(npcId);

                            if (doNotGuide == true || (task.Define.Type == GameConst.QUEST_SG && TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true)
                                || (task.Define.Type == GameConst.QUEST_GUILD && TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true))
                            {
                                mDoNotGuideNpcIds.Add(npcId);
                            }
                        }
                    }
                }
            }
            List<uint> preMainTasksId = TaskHelper.GetPreMainTasksId(taskId);
            foreach (uint preMainTaskId in preMainTasksId)
            {
                List<NpcScenePosition> createNpcsWhenDone = TaskDefine.GetCreateNpcsWhenDone(preMainTaskId);
                if (createNpcsWhenDone != null)
                {
                    foreach (NpcScenePosition npcScenePosition in createNpcsWhenDone)
                    {
                        if (npcScenePosition.SceneId == instanceId)
                        {
                            int npcId = (int)npcScenePosition.NpcId;
                            if (TaskHelper.ShouldDeleteNpcInCurMainTask(npcId) == false)
                            {
                                CreateNPC(npcId);

                                if (doNotGuide == true || (task.Define.Type == GameConst.QUEST_SG && TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true)
                                     || (task.Define.Type == GameConst.QUEST_GUILD && TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true))
                                {
                                    mDoNotGuideNpcIds.Add(npcId);
                                }
                            }
                        }
                    }
                }
            }
        }

        void DeleteDoneTaskNpcs(uint taskId)
        {
            Task task = TaskManager.Instance.GetTaskByTypeAndId(GameConst.QUEST_MAIN, taskId);
            uint instanceId = SceneHelp.Instance.CurSceneID;
            if (task != null && task.Define.DeleteNpcsWhenDone != null)
            {
                foreach (NpcScenePosition npcScenePosition in task.Define.DeleteNpcsWhenDone)
                {
                    if (npcScenePosition.SceneId == instanceId)
                    {
                        DestroyNpc(GetNpcByNpcId(npcScenePosition.NpcId));
                    }
                }
            }
            List<uint> preMainTasksId = TaskHelper.GetPreMainTasksId(taskId);
            foreach (uint preMainTaskId in preMainTasksId)
            {
                List<NpcScenePosition> deleteNpcsWhenDone = TaskDefine.GetDeleteNpcsWhenDone(preMainTaskId);
                if (deleteNpcsWhenDone != null)
                {
                    foreach (NpcScenePosition npcScenePosition in deleteNpcsWhenDone)
                    {
                        if (npcScenePosition.SceneId == instanceId)
                        {
                            DestroyNpc(GetNpcByNpcId(npcScenePosition.NpcId));
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------
        //  客户端消息
        //--------------------------------------------------------  
        private void OnNpcClicked(CEventBaseArgs args)
        {
            if(args == null || args.arg == null)
            {
                return;
            }

            if (UIInputEvent.TouchedUI() == true)
            {
                return;
            }

            GameObject npcObject = args.arg as GameObject;

            if(npcObject == null)
            {
                return;
            }

            var mono = ActorHelper.GetActorMono(npcObject.gameObject);

            if(mono == null)
            {
                return;
            }

            NpcPlayer targetNpc = mono.BindActor as NpcPlayer;
            
            if (targetNpc == null)
            {
                return;
            }

            // 点击npc后已经取消任务的导航了，所以要把导航任务清空
            TaskManager.Instance.NavigatingTask = null;

            //MissionManager.Instance.NotifyMetNpc((uint)targetNpc.NpcData.Id);
            targetNpc.OnClicked();
        }

        private void OnTaskChanged(CEventBaseArgs args)
        {
            foreach (var mono in mNpcs.Values)
            {
                var npcPlayer = (mono.BindActor as NpcPlayer);

                if (npcPlayer == null)
                {
                    continue;
                }

                npcPlayer.OnTaskChanged();
            }
        }

        private void OnTaskNewAccepted(CEventBaseArgs args)
        {
            object arg = args.arg;
            uint taskId = 0;
            if (arg != null)
            {
                taskId = (uint)arg;
            }
            RefreshCurrentInteractNpcs(taskId);
            CreateAcceptedTaskNpcs(taskId);
            DeleteAcceptedTaskNpcs(taskId);

            TaskHelper.CheckTaskAndActiveNpcFollowAI(taskId, true);
        }

        private void OnTaskCanSubmit(CEventBaseArgs args)
        {
            object arg = args.arg;
            List<Task> doneTasks = arg as List<Task>;
            if (doneTasks != null && doneTasks.Count > 0)
            {
                foreach (Task task in doneTasks)
                {
                    CreateDoneTaskNpcs(task.Define.Id);
                    DeleteDoneTaskNpcs(task.Define.Id);

                    TaskHelper.CheckTaskAndActiveNpcFollowAI(task.Define.Id, false);
                }
            }
        }

        private void OnFinishLoadLevel(CEventBaseArgs args)
        {
            if (NpcManager.Instance.TravelBootsJumpNpcId == 0)
            {
                NavigatingNpcId = 0;
            }
            NpcManager.Instance.TravelBootsJumpNpcId = 0;
        }
        //--------------------------------------------------------
        //  网络消息
        //--------------------------------------------------------


        //--------------------------------------------------------
        //  外部调用
        //--------------------------------------------------------
        public void Reset()
        {
            mNpcs.Clear();
            mEscortNpcs.Clear();
            mCreatings.Clear();

            if (mRefreshTaskNpcCoroutine != null)
            {
                mRefreshTaskNpcCoroutine.Stop();
                mRefreshTaskNpcCoroutine = null;
            }
        }

        public void CreateAllNpcs()
        {
            mEscortNpcIndex = 0;

            mNpcs.Clear();
            mEscortNpcs.Clear();
            mCreatings.Clear();

            mDoNotGuideNpcIds.Clear();

            BuildNpcCache();

            // 等到收到首次任务信息之后才刷新任务npc
            if (mRefreshTaskNpcCoroutine != null)
            {
                mRefreshTaskNpcCoroutine.Stop();
                mRefreshTaskNpcCoroutine = null;
            }
            mRefreshTaskNpcCoroutine = SafeCoroutine.CoroutineManager.StartCoroutine(RefreshTaskNpc());
        }

        IEnumerator RefreshTaskNpc()
        {
            yield return new SafeCoroutine.WaitForCondition(CanRefreshTaskNpc);

            RefreshCurrentInteractNpcs();
            CreateAllNewAcceptedAndDoneTaskNpcs();
        }

        bool CanRefreshTaskNpc()
        {
            return TaskNet.HaveReceivedTaskInfo;
        }

        /// <summary>
        /// 获取可用的npc唯一id
        /// </summary>
        uint GetAvailableUUId(Neptune.NPC npcInfo, NpcDefine npcDefine)
        {
            // 普通NPC直接用唯一id加上start id
            uint uuid = (uint)npcInfo.Id + mStartId;

            // 护送NPC逐步递增并取余
            if (npcDefine.Function == NpcDefine.EFunction.ESCORT)
            {
                uuid = mEscortNpcStartID + mEscortNpcIndex % mEscortNpcIDCount;
                ++mEscortNpcIndex;
            }

            return uuid;
        }

        public UnitID CreateNPC(Neptune.NPC npcInfo, Actor parent = null)
        {
            if (npcInfo == null)
            {
                GameDebug.LogError("Error in create npc, npc info is null!!!");
                return null;
            }

            Vector3 bornPos = npcInfo.Position;

            NpcDefine npcDefine = NpcHelper.MakeNpcDefine((uint)npcInfo.ExcelId);

            if (npcDefine == null)
            {
                GameDebug.LogError("Error in create npc, npc define is null!!!");
                return null;
            }

            // 护送任务NPC可以创建多个
            if (GetNpcByNpcId((uint)npcInfo.Id) != null && npcDefine.Function != NpcDefine.EFunction.ESCORT)
            {
                return null;
            }

            uint uuid = GetAvailableUUId(npcInfo, npcDefine);

            DBActor dbActor = DBManager.GetInstance().GetDB<DBActor>();
            DBActor.ActorData actorData = dbActor.GetData((uint)npcDefine.ActorId);

            bornPos = RoleHelp.GetPositionInScene((uint)npcDefine.ActorId, npcInfo.Position.x, npcInfo.Position.z);
            if (npcInfo.Id >= 300)
            {
                GameDebug.LogError("npcInfo.Id is too large! " + npcInfo.Id);
            }
            xc.UnitCacheInfo initData = new xc.UnitCacheInfo(EUnitType.UNITTYPE_NPC, uuid);
            initData.ClientNpc = npcInfo;
            initData.ClientNpcDefine = NpcHelper.MakeNpcDefine((uint)(npcInfo.ExcelId));
            initData.CacheType = xc.UnitCacheInfo.EType.ET_Create;
            initData.PosBorn = bornPos;
            initData.ParentActor = parent;

            // 如果有父角色，则出生在父角色附近的一个随机位置
            if (parent != null)
            {
                Vector3 pos = AIHelper.GetActorRangeRandomPosition(parent, 1f, 2f);
                bool result = false;
                initData.PosBorn = InstanceHelper.ClampInWalkableRange(pos, pos, out result);
            }

            mCreatings.Add(initData.UnitID.obj_idx);

            ActorManager.Instance.PushUnitCacheData(initData);

            return initData.UnitID;
        }

        public UnitID CreateNPC(int npcId, Actor parent = null)
        {
            Neptune.NPC info = Neptune.DataManager.Instance.Data.GetNode<Neptune.NPC>(npcId);
            return CreateNPC(info, parent);
        }

        public NpcPlayer GetNpcByNpcId(uint npcId)
        {
            foreach (var mono in mNpcs.Values)
            {
                var npcPlayer = (mono.BindActor as NpcPlayer);

                if (npcPlayer == null)
                {
                    continue;
                }

                if (npcPlayer.NpcData.Id == npcId)
                {
                    return npcPlayer;
                }
            }

            return null;
        }

        public NpcPlayer GetNpcByNpcExcelId(uint npcExcelId)
        {
            foreach (var mono in mNpcs.Values)
            {
                var npcPlayer = (mono.BindActor as NpcPlayer);

                if (npcPlayer == null)
                {
                    continue;
                }

                if (npcPlayer.NpcData.ExcelId == npcExcelId)
                {
                    return npcPlayer;
                }
            }

            return null;
        }

        public static bool GetNpcPos(uint npcId, ref Vector3 result)
        {
            NpcPlayer npc = NpcManager.Instance.GetNpcByNpcId(npcId);

            if(npc != null)
            {
                result = npc.transform.position;
                return true;
            }

            Neptune.NPC npcInfo = Neptune.DataManager.Instance.Data.GetNode<Neptune.NPC>((int)npcId);

            if (npcInfo != null)
            {
                result = npcInfo.Position;
                return true;
            }

            return false;
        }

        public Dictionary<uint, ActorMono> AllNpc
        {
            get
            {
                return mNpcs;
            }
        }

        public NpcPlayer GetClosestNpc(Neptune.Relationship npcType)
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null && localPlayer.transform != null)
            {
                Vector3 localPlayerPos = localPlayer.transform.position;
                float minDistance = float.MaxValue;
                NpcPlayer closestNpc = null;
                foreach (var mono in mNpcs.Values)
                {
                    var npc = (mono.BindActor as NpcPlayer);

                    if (npc == null)
                    {
                        continue;
                    }

                    if (npc.NpcData.Relationship == npcType)
                    {
                        float distance = (localPlayerPos - npc.transform.position).sqrMagnitude;
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            closestNpc = npc;
                        }
                    }
                }
                return closestNpc;
            }

            return null;
        }
    }
}