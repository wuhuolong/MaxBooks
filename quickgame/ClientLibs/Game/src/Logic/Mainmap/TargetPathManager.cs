using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using xc.ui;

namespace xc
{
    [wxb.Hotfix]
    public class TargetPathManager : xc.Singleton<TargetPathManager>
    {
        private LinkedList<TargetPathNode> mTargetPathNodes = new LinkedList<TargetPathNode>();
        private TargetPathNode mRunningTargetPathNode = null;
        private AIActorPathWalker mPathWalker;

        private readonly string mIsFirstNavigatingJumpToScenePrefKey = "IsFirstNavigatingJumpToScene";

        //@hzb 计数器
        private uint mCounter = 0;

        public uint Counter
        {
            get { return mCounter; }
        }

        public Vector3 TargetPos
        {
            get
            {
                if (mTargetPathNodes.Count == 0)
                    return Vector3.zero;
                return mTargetPathNodes.Last.Value.TargetConstPos;
            }
        }

        public LinkedList<TargetPathNode> TargetPathNodes
        {
            get
            {
                return mTargetPathNodes;
            }
        }

        /// <summary>
        /// 标记自动任务寻路状态的变量
        /// </summary>
        byte mTaskNavigationState = 0;

        //--------------------------------------------------------
        //  构造函数
        //--------------------------------------------------------
        public TargetPathManager()
        {
            // 注册客户端消息
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerControled);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnPlayerControled);
            //ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_AUTO_FIGHT_STATE_CHANGED, OnPlayerControled);
            //ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SWITCHSCENE, OnPlayerControled);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }
        
        ~TargetPathManager ()
        {
            // 取消注册客户端消息
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PLAYERCONTROLED, OnPlayerControled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_CLICKCOLLISION, OnPlayerControled);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnPlayerControled);
            //ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_AUTO_FIGHT_STATE_CHANGED, OnPlayerControled);
            //ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SWITCHSCENE, OnPlayerControled);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }
        //--------------------------------------------------------
        //  客户端消息
        //--------------------------------------------------------  
        public void OnPlayerControled(CEventBaseArgs data)
        {
            if (GameInput.Instance.GetEnableInput() == false || UIInputEvent.TouchedUI())
            {
                return;
            }

            NpcManager.Instance.NavigatingNpcId = 0;
            NpcManager.Instance.TravelBootsJumpNpcId = 0;

            mCounter++;
            mTargetPathNodes.Clear();

            RunningTargetPathNode = null;

            if (mPathWalker != null)
            {
                mPathWalker.Reset();
            }

            TaskNavigationActive(false);
            IsNavigating = false;
        }

        public void OnStartSwitchScene(CEventBaseArgs data)
        {
            IsNavigating = false;
        }

        //--------------------------------------------------------
        //  外部调用
        //--------------------------------------------------------
        public void Reset()
        {
            mTaskNavigationState = 0;

            //  mTargetNpcId = 0xffffffff;
            mTargetPathNodes.Clear();

            if(mPathWalker != null)
            {
                mPathWalker.Reset();
            }

            RunningTargetPathNode = null;
        }

        /// <summary>
        /// 停止寻路
        /// </summary>
        public void StopPlayerAndReset(bool setAutoFightingFalse = true, bool isStopLocalPlayer = true)
        {
            TaskHelper.StopTaskGuideCoroutine();
            MainmapManager.Instance.StopLocalPlayerWalkCoroutine();

            LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;
            
            if (localPlayer != null && isStopLocalPlayer == true)
            {
                localPlayer.Stop();
                localPlayer.MoveCtrl.TryWalkAlongStop();
            }
            
            TargetPathManager.Instance.Reset();

            if (setAutoFightingFalse == true)
            {
                InstanceManager.Instance.IsAutoFighting = false;
            }

            TaskNavigationActive(false);
            IsNavigating = false;

            TaskManager.Instance.NavigatingTask = null;
            NpcManager.Instance.NavigatingNpcId = 0;
        }

        public AIActorPathWalker PathWalker
        {
            get
            {
                return mPathWalker;
            }
        }

        /// <summary>
        /// 设置自动任务寻路的状态
        /// </summary>
        /// <param name="active"></param>
        public void TaskNavigationActive(bool active)
        {
            byte activeState = active ? (byte)1 : (byte)2;
            if (activeState == mTaskNavigationState)
                return;

            mTaskNavigationState = activeState;
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_NAVIGATION_ACTIVE, new CEventBaseArgs(active));
        }

        public void LocalPlayerWalkToDestination(Vector3 targetPos, Task relateTask = null)
        {
            Actor player = Game.GetInstance().GetLocalPlayer();

            if (player == null)
            {
                return;
            }

            targetPos.y = RoleHelp.GetHeightInScene(player.ActorId, targetPos.x, targetPos.z);
            targetPos = InstanceHelper.ClampInWalkableRange(targetPos, 10);

            // 判断是否可到达
            XNavMeshPath walkMeshPath = new XNavMeshPath();
            XNavMesh.CalculatePath(player.transform.position, targetPos, xc.Dungeon.LevelManager.GetInstance().AreaExclude, walkMeshPath);
            if (walkMeshPath.status != XNavMeshPathStatus.PathComplete)
            {
                // 如果通过任务导航寻路，且在新手副本的不可到达区域，则直接飞过去，以免因为配置错误而导致卡死
                if (relateTask != null && SceneHelp.Instance.CurSceneID == GameConstHelper.GetUint("GAME_BORN_DUNGEON"))
                {
                    GameDebug.LogWarning(DBConstText.GetText("MAP_POS_CAN_NOT_REACH") + "，该场景是新手场景，直接瞬移过去");
                    player.MoveCtrl.SendFly(targetPos);
                    player.SetPosition(targetPos);
                }
                else
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("MAP_POS_CAN_NOT_REACH"));
                }
                return;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            mPathWalker.WalkTo(targetPos);
            //player.MoveCtrl.TryWalkTo(targetPos);

            /*
            uint instanceType = InstanceManager.Instance.InstanceType;

            if (instanceType == GameConst.WAR_TYPE_WILD || instanceType == GameConst.WAR_TYPE_HOLE || instanceType == GameConst.WAR_SUBTYPE_WILD_PUB || instanceType == GameConst.WAR_TYPE_MULTI)
            {
                if(mPathWalker == null)
                {
                    return;
                }

                mPathWalker.WalkTo(targetPos);
            }
            else
            {
                player.MoveCtrl.TryWalkTo(targetPos);
            }*/

            TaskNavigationActive(true);
            IsNavigating = true;
        }

        public void NotifyLastPathNodeReached()
        {
            //GameDebug.LogError("NotifyLastPathNodeReached. Counter:" + Counter);

            if(RunningTargetPathNode != null)
            {
                RunningTargetPathNode.NotifyLastPathNodeReached();
                RunningTargetPathNode = null;
            }

            ClearAllTargetPathNodes();

            TaskNavigationActive(false);
            IsNavigating = false;
        }

        public void Update()
        {
            uint sceneId = SceneHelp.Instance.CurSceneID;
            uint lineId = SceneHelp.Instance.CurLine;
            Actor player = Game.GetInstance().GetLocalPlayer();

            if(player == null)
            {
                return;
            }

            if(mPathWalker == null)
            {
                mPathWalker = new AIActorPathWalker(player);
            }

            bool needReturn = false;

            // 调整了mRunningTargetPathNode和mPathWalker更新的顺序，先更新mRunningTargetPathNode再更新mPathWalker

            if (RunningTargetPathNode != null)
            {
                // 要导航的点非当前场景的点，移除先
                if (RunningTargetPathNode.SceneId != sceneId || (RunningTargetPathNode.LineId != 0 && RunningTargetPathNode.LineId != lineId))
                {
                    mTargetPathNodes.Remove(RunningTargetPathNode);
                    RunningTargetPathNode = null;
                }
                else
                {
                    bool walkRet = false;
                    if (RunningTargetPathNode.IsRunning == false)
                    {
                        walkRet = RunningTargetPathNode.WalkToTarget();
                    }
                    if (walkRet == true)
                    {
                        needReturn = true;
                    }
                }
            }

            if(mPathWalker != null)
            {
                // 切换场景后，本地玩家重新创建
                if(mPathWalker.TargetActor == null)
                {
                    mPathWalker.TargetActor = player;
                }

                mPathWalker.Update();
            }

            if(needReturn)
            {
                return;
            }

            if (mTargetPathNodes.Count <= 0)
            {
                mPathWalker.Reset();
                return;
            }

            foreach (var item in mTargetPathNodes)
            {
                if (item.SceneId == sceneId && (item.LineId == 0 || item.LineId == lineId))
                {
                    if (RunningTargetPathNode == item)
                    {
                        return;
                    }

                    Vector3 targetPos = Vector3.zero;

                    if (item.TargetNpcId != 0)
                    {
                        //NpcPlayer targetNpc = NpcManager.Instance.GetNpcByNpcId(item.TargetNpcId);
                        //if (targetNpc != null)
                        //{
                        //    targetPos = targetNpc.transform.position;
                        //    NpcManager.Instance.NavigatingNpcId = item.TargetNpcId;

                        //    RunningTargetPathNode = item;
                        //    return;
                        //}
                        if (NpcManager.GetNpcPos(item.TargetNpcId, ref targetPos))
                        {
                            NpcManager.Instance.NavigatingNpcId = item.TargetNpcId;
                            RunningTargetPathNode = item;
                            return;
                        }
                        // 
                        //                         Spartan.NpcInfo npcInfo = Spartan.NpcInfoManager.Instance.GetNpcInfo((int)item.TargetNpcId);
                        // 
                        //                         if (npcInfo != null)
                        //                         {
                        //                             targetPos = npcInfo.Position;
                        // 
                        //                             //LocalPlayerWalkToDestination(targetPos);
                        // 
                        //                             RunningTargetPathNode = item;
                        //                             return;
                        //                         }
                    }
                    else if (item.TargetTriggerId != 0)
                    {
                        //TriggerCollider trigger = TriggerManager.Instance.GetTrigger((int)item.TargetTriggerId);

                        //if (trigger != null)
                        //{
                        //    //targetPos = trigger.transform.position;

                        //    //LocalPlayerWalkToDestination(targetPos);

                        //    RunningTargetPathNode = item;
                        //    return;
                        //}
                    }
                    else if (item.WantEnterMapId != 0)
                    {
                        //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(item.WantEnterMapId);

                        //uint triggerId = 0;

                        //if (targetTrigger == null)
                        //{
                        //    targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);

                        //    if(targetTrigger != null)
                        //    {
                        //        triggerId = (uint)targetTrigger.TriggerInfo.Id;
                        //    }
                        //    else
                        //    {
                        //        triggerId = TriggerManager.Instance.GetShortestPortalTriggerId(item.WantEnterMapId);

                        //        if(triggerId == 0)
                        //        {
                        //            triggerId = TriggerManager.Instance.GetShortestPortalTriggerId(0);
                        //        }
                        //    }
                        //}

                        //RunningTargetPathNode = item;
                        //RunningTargetPathNode.TargetTriggerId = triggerId;

                        //                         foreach (var triggerItem in TriggerManager.Instance.Triggers)
                        //                         {
                        //                             if (triggerItem.Value.TriggerInfo.NeedNavigation == false)
                        //                             {
                        //                                 continue;
                        //                             }
                        // 
                        //                             if (triggerItem.Value.TriggerInfo.Info == Spartan.TriggerInfo.InfoType.PORTAL && triggerItem.Value.TriggerInfo.PortalTargetMapID == item.WantEnterMapId)
                        //                             {
                        //                                // targetPos = triggerItem.Value.transform.position;
                        // 
                        //                                 //LocalPlayerWalkToDestination(targetPos);
                        // 
                        //                                 RunningTargetPathNode = item;
                        //                                 mRunningTargetPathNode.TargetTriggerId = (uint)triggerItem.Value.TriggerInfo.Id;
                        // 
                        //                                 return;
                        //                             }
                        //                         }
                    }
                    else if (item.TargetMonsterId != 0)
                    {
                        List<Vector3> monsterPositions = xc.Dungeon.LevelObjectHelper.GetMonsterPositionsByActorId(item.TargetMonsterId);

                        if (monsterPositions.Count > 0)
                        {
                            // targetPos = groupInfo.Position;
                            //targetPos = InstanceHelper.ClampInWalkableRange(targetPos);

                            //LocalPlayerWalkToDestination(targetPos);

                            RunningTargetPathNode = item;

                            return;
                        }
                    }
                    else if (item.TargetTagId != 0)
                    {
                        Neptune.Tag tagInfo = Neptune.DataManager.Instance.Data.GetNode<Neptune.Tag>((int)item.TargetTagId);
                        if (tagInfo != null)
                        {
                            RunningTargetPathNode = item;

                            return;
                        }
                    }
                    else if (item.TargetConstPos.Equals(Vector3.zero) == false)
                    {
                        RunningTargetPathNode = item;
                    }
                }
            }
        }

        /// <summary>
        /// 当前是否在导航ing
        /// </summary>
        public bool IsNavigating { get; set; }

        public void ClearAllTargetPathNodes()
        {
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;
        }

        public TargetPathNode RunningTargetPathNode
        {
            get
            {
                return mRunningTargetPathNode;
            }
            set
            {
                if(value == null)
                {
                    //GameDebug.LogError("TargetPathManager:RunningTargetPathNode Set RunningTargetPathNode to null!");
                }

                mRunningTargetPathNode = value;
            }
        }

        public TargetPathNode CurrentSceneTargetPathNode
        {
            get
            {
                foreach (var item in mTargetPathNodes)
                {
                    if(item.SceneId == SceneHelp.Instance.CurSceneID && (item.LineId == 0 || item.LineId == SceneHelp.Instance.CurLine))
                    {
                        return item;
                    }
                }

                return null;
            }
        }

        public bool NotifyMetNpc(uint npcId)
        {
            if (RunningTargetPathNode == null)
            {
                return false;
            }

            //因为涉及到跨地图寻路，这种接口里面，不能清空整个寻路节点

            if (RunningTargetPathNode.TargetNpcId == npcId)
            {
                NpcManager.Instance.NavigatingNpcId = 0;

                mTargetPathNodes.Remove(RunningTargetPathNode);
                RunningTargetPathNode = null;

                if(mTargetPathNodes.Count <= 0)
                {
                    NotifyLastPathNodeReached();
                }

                return true;
            }

            return false;
        }

        public void NotifyMetTrigger(uint triggerId)
        {
            if(RunningTargetPathNode == null)
            {
                return;
            }

            if(RunningTargetPathNode.TargetTriggerId == triggerId)
            {
                mTargetPathNodes.Remove(RunningTargetPathNode);
                RunningTargetPathNode = null;

                if (mTargetPathNodes.Count <= 0)
                {
                    NotifyLastPathNodeReached();
                }
            }
        }

        public void NotifyMetMonster(uint monsterId)
        {
            if (RunningTargetPathNode == null)
            {
                return;
            }

            if (RunningTargetPathNode.TargetMonsterId == monsterId)
            {
                mTargetPathNodes.Remove(RunningTargetPathNode);

                RunningTargetPathNode = null;

                if (mTargetPathNodes.Count <= 0)
                {
                    NotifyLastPathNodeReached();
                }
            }
        }

        public void NotifyMetTag(uint tagId)
        {
            if (RunningTargetPathNode == null)
            {
                return;
            }

            if (RunningTargetPathNode.TargetTagId == tagId)
            {
                mTargetPathNodes.Remove(RunningTargetPathNode);

                RunningTargetPathNode = null;

                if (mTargetPathNodes.Count <= 0)
                {
                    NotifyLastPathNodeReached();
                }
            }
        }

        /// <summary>
        ///  移动到固定点
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool GoToConstPosition(Vector3 pos)
        {
            return GoToConstPosition(SceneHelp.Instance.CurSceneID, SceneHelp.Instance.CurLine, pos, null);
        }

        /// <summary>
        /// 移动到固定点
        /// </summary>
        public bool GoToConstPosition(uint mapId, uint line, Vector3 pos)
        {
            return GoToConstPosition(mapId, line, pos, null, null);
        }

        public bool GoToConstPosition(uint mapId, uint line, Vector3 pos, Task relateTask)
        {
            return GoToConstPosition(mapId, line, pos, relateTask, null);
        }

        /// <summary>
        /// 移动到目标点
        /// </summary>
        public bool GoToConstPosition(uint mapId, uint line, Vector3 pos, Task relateTask, System.Action finishedCallback)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return false;
            }
            if (localPlayer.IsDead() == true)
            {
                return false;
            }

            // 记录当弹出退出提示的时候是否要继续自动战斗
            if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
            {
                SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            mCounter++;
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;

            if (mapId == SceneHelp.Instance.CurSceneID 
                && (line == SceneHelp.Instance.CurLine || SceneHelp.Instance.IsInWorldBossFirstInstance))
            {
                TargetPathNode path = new TargetPathNode();
                path.SceneId = SceneHelp.Instance.CurSceneID;
                path.LineId = SceneHelp.Instance.CurLine;
                path.TargetConstPos = pos;
                path.RelateTask = relateTask;
                path.FinishedCallback = finishedCallback;

                mTargetPathNodes.AddLast(path);
            }
            else
            {
                //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(mapId);

                //if (targetTrigger == null)
                //{
                //    targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);

                //    if (targetTrigger == null)
                //    {
                //        return false;
                //    }
                //}

                //TargetPathNode path = new TargetPathNode();
                //path.SceneId = SceneHelp.Instance.CurSceneID;
                //path.TargetTriggerId = (uint)targetTrigger.TriggerInfo.Id;
                //path.WantEnterMapId = mapId;
                //path.RelateTask = relateTask;

                //mTargetPathNodes.AddLast(path);

                TargetPathNode path2 = new TargetPathNode();
                path2.SceneId = mapId;
                path2.LineId = line;
                path2.TargetConstPos = pos;
                path2.RelateTask = relateTask;
                path2.FinishedCallback = finishedCallback;

                mTargetPathNodes.AddLast(path2);

                JumpToScene(false, mapId, line, relateTask);
            }

            TaskManager.Instance.NavigatingTask = null;

            return true;
        }

        /// <summary>
        /// 寻路去副本
        /// </summary>
        public bool GoToInstance(uint entranceMapId, uint instanceId, Task relateTask)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return false;
            }
            if (localPlayer.IsDead() == true)
            {
                return false;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            mCounter++;
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;

            if (entranceMapId == SceneHelp.Instance.CurSceneID)
            {
                //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(instanceId);

                //if (targetTrigger == null)
                //{
                //    targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);

                //    if(targetTrigger == null)
                //    {
                //        return false;
                //    }
                //}

                //TargetPathNode node = new TargetPathNode();
                //node.SceneId = entranceMapId;
                //node.TargetTriggerId = (uint)targetTrigger.TriggerInfo.Id;
                //node.RelateTask = relateTask;

                //mTargetPathNodes.AddLast(node);
            }
            else
            {
                //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);

                //if(targetTrigger == null)
                //{
                //    return false;
                //}

                //TargetPathNode path = new TargetPathNode();
                //path.SceneId = SceneHelp.Instance.CurSceneID;
                //path.TargetTriggerId = (uint)targetTrigger.TriggerInfo.Id;
                //path.WantEnterMapId = entranceMapId;
                //path.RelateTask = relateTask;

                //mTargetPathNodes.AddLast(path);

                TargetPathNode path2 = new TargetPathNode();
                path2.SceneId = entranceMapId;
                path2.LineId = 0;
                path2.WantEnterMapId = instanceId;
                path2.RelateTask = relateTask;

                mTargetPathNodes.AddLast(path2);
            }

            return false;
        }

        /// <summary>
        /// 去某个副本的怪物
        /// </summary>
        /// <param name="mapId">要进入这个副本的大地图的trigger ID</param>
        /// <param name="instanceId">要进入这个副本的ID</param>
        /// <param name="monsterId">要找寻的这个怪物ID</param>
        /// <returns></returns>
        public bool GoToMonsterPos(uint mapId, uint instanceId, uint monsterId, Task relateTask)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return false;
            }
            if (localPlayer.IsDead() == true)
            {
                return false;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            if (instanceId <= 0)
            {
                return GoToMonsterPos(mapId, monsterId, relateTask);
            }

            mCounter++;
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;

            // 如果已经在这个大地图
            if (mapId == SceneHelp.Instance.CurSceneID)
            {
                // 防止策划配错表
                uint realInstanceId = 0;

                //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(instanceId);

                //if(targetTrigger == null)
                //{
                //    targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);
                //}

                //if (targetTrigger != null)
                //{
                //    TargetPathNode node = new TargetPathNode();
                //    node.SceneId = SceneHelp.Instance.CurSceneID;
                //    node.TargetTriggerId = (uint)targetTrigger.TriggerInfo.Id;
                //    node.RelateTask = relateTask;
                //    node.WantEnterMapId = instanceId;

                //    mTargetPathNodes.AddLast(node);
                //}

                realInstanceId = instanceId;

                TargetPathNode node2 = new TargetPathNode();
                node2.SceneId = realInstanceId;
                node2.LineId = 0;
                node2.TargetMonsterId = monsterId;
                node2.RelateTask = relateTask;

                mTargetPathNodes.AddLast(node2);

                // 如果没有找到传送门则直接传过去
                //if (targetTrigger == null)
                {
                    JumpToScene(false, instanceId, 0, relateTask);
                }

                return false;
            }
            // 如果已经在这个副本
            else if(instanceId == SceneHelp.Instance.CurSceneID)
            {
                List<Vector3> monsterPositions = xc.Dungeon.LevelObjectHelper.GetMonsterPositionsByActorId(monsterId);

                if (monsterPositions.Count > 0)
                {
                    TargetPathNode path = new TargetPathNode();
                    path.SceneId = SceneHelp.Instance.CurSceneID;
                    path.LineId = SceneHelp.Instance.CurLine;
                    path.TargetMonsterId = monsterId;
                    path.RelateTask = relateTask;

                    mTargetPathNodes.AddLast(path);

                    return true;
                }
            }
            // 如果什么都不在
            else
            {
                //TriggerCollider shortestTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);

                //if (shortestTrigger != null)
                //{
                //    TargetPathNode path = new TargetPathNode();
                //    path.SceneId = SceneHelp.Instance.CurSceneID;
                //    path.TargetTriggerId = (uint)shortestTrigger.TriggerInfo.Id;
                //    path.WantEnterMapId = mapId;
                //    path.RelateTask = relateTask;

                //    mTargetPathNodes.AddLast(path);

                //    path = new TargetPathNode();
                //    path.SceneId = mapId;
                //    path.WantEnterMapId = instanceId;
                //    path.RelateTask = relateTask;

                //    mTargetPathNodes.AddLast(path);
                //}

                TargetPathNode path2 = new TargetPathNode();
                path2.SceneId = instanceId;
                path2.LineId = 0;
                path2.TargetMonsterId = monsterId;
                path2.RelateTask = relateTask;

                mTargetPathNodes.AddLast(path2);

                // 如果没有找到传送门则直接传过去
                //if (shortestTrigger == null)
                {
                    JumpToScene(false, instanceId, 0, relateTask);
                }
            }

            return false;
        }

        public bool GoToMonsterPos(uint mapId, uint monsterId, Task relateTask)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return false;
            }
            if (localPlayer.IsDead() == true)
            {
                return false;
            }

            mCounter++;
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;

            if (mapId == SceneHelp.Instance.CurSceneID)
            {
                List<Vector3> monsterPositions = xc.Dungeon.LevelObjectHelper.GetMonsterPositionsByActorId(monsterId);

                if (monsterPositions.Count > 0)
                {
                    TargetPathNode path = new TargetPathNode();
                    path.SceneId = SceneHelp.Instance.CurSceneID;
                    path.LineId = SceneHelp.Instance.CurLine;
                    path.TargetMonsterId = monsterId;
                    path.RelateTask = relateTask;

                    mTargetPathNodes.AddLast(path);

                    return true;
                }
                else
                {
                    GameDebug.LogWarning("Can not find monster " + monsterId + "(actor id) in instance " + mapId);
                }
            }
            else
            {
                //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);

                //if (targetTrigger != null)
                //{
                //    TargetPathNode path = new TargetPathNode();
                //    path.SceneId = SceneHelp.Instance.CurSceneID;
                //    path.TargetTriggerId = (uint)targetTrigger.TriggerInfo.Id;
                //    path.WantEnterMapId = mapId;
                //    path.RelateTask = relateTask;

                //    mTargetPathNodes.AddLast(path);
                //}

                TargetPathNode path2 = new TargetPathNode();
                path2.SceneId = mapId;
                path2.LineId = 0;
                path2.TargetMonsterId = monsterId;
                path2.RelateTask = relateTask;

                mTargetPathNodes.AddLast(path2);

                // 如果没有找到传送门则直接传过去
                //if (targetTrigger == null)
                {
                    JumpToScene(false, mapId, 0, relateTask);
                }
            }

            return false;
        }

        public bool GoToMap(uint mapId)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return false;
            }
            if (localPlayer.IsDead() == true)
            {
                return false;
            }

            mCounter++;
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;

            if (mapId == SceneHelp.Instance.CurSceneID)
            {
                return true;
            }

            //@hzb fix
            //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);
            //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(mapId);

            //if (targetTrigger != null)
            //{
            //    TargetPathNode path = new TargetPathNode();
            //    path.SceneId = SceneHelp.Instance.CurSceneID;
            //    path.TargetTriggerId = (uint)targetTrigger.TriggerInfo.Id;
            //    path.WantEnterMapId = mapId;
            //    path.RelateTask = null;

            //    mTargetPathNodes.AddLast(path);
            //}

            // 如果没有找到传送门则直接传过去
            //if (targetTrigger == null)
            {
                JumpToScene(false, mapId, 0, null);
            }

            return false;
        }

        public bool GoToNpcPos(uint mapId, uint npcId, Task relateTask, uint npcExcelId = 0)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return false;
            }
            if (localPlayer.IsDead() == true)
            {
                return false;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            mCounter++;
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;

            if (mapId == SceneHelp.Instance.CurSceneID)
            {
                NpcPlayer targetNpc = null;
                if (relateTask != null && relateTask.CurrentGoal == GameConst.GOAL_INTERACT)
                {
                    targetNpc = NpcManager.Instance.GetNpcByNpcExcelId(npcExcelId);
                }
                if (targetNpc == null)
                {
                    targetNpc = NpcManager.Instance.GetNpcByNpcId(npcId);
                }

                NpcManager.Instance.NavigatingNpcId = npcId;

                if (targetNpc != null)
                {
                    if (targetNpc.IsLocalPlayerCloseEnoughToEnter)
                    {
                        bool touchRet = targetNpc.FireTouchEvent();
                        NpcManager.Instance.NavigatingNpcId = 0;
                        if (touchRet == true)
                        {
                            return true;
                        }
                    }
                }

                TargetPathNode path = new TargetPathNode();
                path.SceneId = SceneHelp.Instance.CurSceneID;
                path.LineId = SceneHelp.Instance.CurLine;
                path.TargetNpcId = npcId;
                path.RelateTask = relateTask;

                mTargetPathNodes.AddLast(path);

                return true;
            }
            else
            {
                //TriggerCollider targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(mapId);

                //if(targetTrigger == null)
                //{
                //    targetTrigger = TriggerManager.Instance.GetShortestPortalTrigger(0);
                //}

                //if (targetTrigger != null)
                //{
                //    TargetPathNode path = new TargetPathNode();
                //    path.SceneId = SceneHelp.Instance.CurSceneID;
                //    path.TargetTriggerId = (uint)targetTrigger.TriggerInfo.Id;
                //    path.WantEnterMapId = mapId;
                //    path.RelateTask = relateTask;

                //    mTargetPathNodes.AddLast(path);
                //}

                TargetPathNode path2 = new TargetPathNode();
                path2.SceneId = mapId;
                path2.LineId = 0;
                path2.TargetNpcId = npcId;
                path2.RelateTask = relateTask;

                mTargetPathNodes.AddLast(path2);

                // 如果没有找到传送门则直接传过去
                //if (targetTrigger == null)
                {
                    JumpToScene(true, mapId, 0, relateTask);
                }

                return true;
            }
        }

        public bool GoToTagPos(uint mapId, uint tagId, Task relateTask, System.Action finishedCallback = null)
        {
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null)
            {
                return false;
            }
            if (localPlayer.IsDead() == true)
            {
                return false;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            mCounter++;
            mTargetPathNodes.Clear();
            RunningTargetPathNode = null;

            if (mapId == SceneHelp.Instance.CurSceneID)
            {
                Neptune.Tag tagInfo = Neptune.DataManager.Instance.Data.GetNode<Neptune.Tag>((int)tagId);

                if (tagInfo != null)
                {
                    TargetPathNode path = new TargetPathNode();
                    path.SceneId = SceneHelp.Instance.CurSceneID;
                    path.LineId = SceneHelp.Instance.CurLine;
                    path.TargetTagId = tagId;
                    path.RelateTask = relateTask;
                    path.FinishedCallback = finishedCallback;

                    mTargetPathNodes.AddLast(path);

                    return true;
                }
            }
            else
            {
                TargetPathNode path2 = new TargetPathNode();
                path2.SceneId = mapId;
                path2.LineId = 0;
                path2.TargetTagId = tagId;
                path2.RelateTask = relateTask;
                path2.FinishedCallback = finishedCallback;

                mTargetPathNodes.AddLast(path2);

                // 如果没有找到传送门则直接传过去
                //if (targetTrigger == null)
                {
                    JumpToScene(true, mapId, 0, relateTask);
                }
            }

            return false;
        }

        /// <summary>
        /// 是否第一次通过寻路来跳场景，如果是则寻路到当前场景的一个传送门
        /// 相关需求：https://www.tapd.cn/20249401/prong/stories/view/1120249401001002752
        /// </summary>
        public bool IsFirstNavigatingJumpToScene
        {
            get
            {
                uint uuid = 0;
                if (LocalPlayerManager.Instance.LocalActorAttribute != null)
                {
                    uuid = LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx;
                }
                return UserPlayerPrefs.Instance.GetInt(mIsFirstNavigatingJumpToScenePrefKey + "_" + uuid, 0) == 0 ? true : false;
            }
        }

        public void SetIsFirstNavigatingJumpToScene(bool isFirst)
        {
            uint value = 0;
            if (isFirst == false)
            {
                value = 1;
            }
            uint uuid = 0;
            if (LocalPlayerManager.Instance.LocalActorAttribute != null)
            {
                uuid = LocalPlayerManager.Instance.LocalActorAttribute.UnitId.obj_idx;
            }
            UserPlayerPrefs.Instance.SetInt(mIsFirstNavigatingJumpToScenePrefKey + "_" + uuid, value);
            UserPlayerPrefs.Instance.Save();
        }

        public void JumpToScene(bool check, uint id, uint line = 0, Task relateTask = null)
        {
            // 在新手村第一次跳场景的时候，去找第一个传送点
            if (check == true && IsFirstNavigatingJumpToScene == true && SceneHelp.Instance.CurSceneID == GameConstHelper.GetUint("GAME_BORN_DUNGEON"))
            {
                Dictionary<int, Neptune.BaseGenericNode> colliders = Neptune.DataManager.Instance.Data.GetData<Neptune.Collider>().Data;
                if (colliders != null)
                {
                    foreach (Neptune.BaseGenericNode collider in colliders.Values)
                    {
                        if (collider.Id == 1)
                        {
                            if (InstanceHelper.CanWalkTo(collider.Position) == true)
                            {
                                LocalPlayerWalkToDestination(collider.Position, relateTask);
                                return;
                            }
                            break;
                        }
                    }
                }
            }

            SceneHelp.JumpToScene(id, line);
        }
    }
}