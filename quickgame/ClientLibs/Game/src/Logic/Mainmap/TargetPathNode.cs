using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using xc.ui;

namespace xc
{
    public class TargetPathNode
    {
        public uint SceneId;
        public uint LineId;
        public uint TargetNpcId;
        public uint TargetTriggerId;
        public uint TargetMonsterId;
        public uint TargetTagId;
        /// <summary>
        /// 目标是固定坐标点
        /// </summary>
        public Vector3 TargetConstPos;
        /// <summary>
        /// 想要进入的地图ID
        /// </summary>
        public uint WantEnterMapId
        {
            get
            {
                return mWantEnterMapId;
            }
            set
            {
                mWantEnterMapId = value;

                if(mWantEnterMapId == 0)
                {
                    int setBreakpointHere = 0;
                }
            }
        }

        private uint mWantEnterMapId = 0;

        public bool Reached = false;
        public Task RelateTask;
        public System.Action FinishedCallback = null;

        /// <summary>
        /// 是否需要工作
        /// </summary>
        public bool NeedWork = true;

        public bool IsRunning = false;

        public void NotifyLastPathNodeReached()
        {
            Reached = true;

            Actor localPlayer = Game.GetInstance().GetLocalPlayer();

            if (RelateTask != null && RelateTask.CurrentStep != null)
            {
                uint tagId = RelateTask.CurrentStep.NavigationTagId;

                Task task = TaskManager.Instance.GetTask(RelateTask.Define.Id);

                if (RelateTask.CurrentGoal == GameConst.GOAL_KILL_MON || RelateTask.CurrentGoal == GameConst.GOAL_KILL_GROUP_MON || RelateTask.CurrentGoal == GameConst.GOAL_KILL_COLLECT)
                {
                    uint monsterId = RelateTask.CurrentStep.MonsterId;

                    if (TargetMonsterId == monsterId || RelateTask.CurrentGoal == GameConst.GOAL_KILL_GROUP_MON)
                    {
                        if (RelateTask.CurrentStep != null && RelateTask.CurrentStep.InstanceId == SceneHelp.Instance.CurSceneID)
                        {
                            if (task != null && task.State == GameConst.QUEST_STATE_DOING)
                            {
                                if (InstanceManager.Instance.IsAutoFighting == false)
                                {
                                    InstanceManager.Instance.IsAutoFighting = true;
                                    InstanceManager.Instance.SetAutoFightingTargetMonsterId(TargetMonsterId);
                                }
                            }

                            TargetPathManager.Instance.NotifyMetMonster(monsterId);
                        }
                    }
                    else if (TargetTagId == tagId)
                    {
                        if (RelateTask.CurrentStep != null && RelateTask.CurrentStep.InstanceId == SceneHelp.Instance.CurSceneID)
                        {
                            if (task != null && task.State == GameConst.QUEST_STATE_DOING)
                            {
                                InstanceManager.Instance.IsAutoFighting = true;
                            }

                            TargetPathManager.Instance.NotifyMetTag(tagId);
                        }
                    }
                }
                else if (RelateTask.CurrentGoal == GameConst.GOAL_COLLECT_GOODS)
                {
                    if (TargetTagId == tagId)
                    {
                        if (RelateTask.CurrentStep != null)
                        {
                            if (task != null && task.State == GameConst.QUEST_STATE_DOING)
                            {
                                InstanceManager.Instance.IsAutoFighting = true;
                            }

                            TargetPathManager.Instance.NotifyMetTag(tagId);
                        }
                    }
                }
                else if (RelateTask.CurrentGoal == GameConst.GOAL_WAR_WIN || RelateTask.CurrentGoal == GameConst.GOAL_WAR_ENTER || RelateTask.CurrentGoal == GameConst.GOAL_WAR_GRADE)
                {
                    if (TargetTagId == tagId)
                    {
                        if (RelateTask.CurrentStep != null && RelateTask.CurrentStep.InstanceId == SceneHelp.Instance.CurSceneID)
                        {
                            // 进行中的任务才能进入副本
                            if (task != null)
                            {
                                if (RelateTask.State != task.State)
                                {
                                    GameDebug.LogError("Error!!! RelateTask's state is not the same!!!");
                                }
                                if (task.State == GameConst.QUEST_STATE_DOING)
                                {
                                    SceneHelp.JumpToScene(RelateTask.CurrentStep.InstanceId2);
                                }
                            }
                            TargetPathManager.Instance.NotifyMetTag(tagId);
                        }
                    }
                }
            }
            else if (TargetMonsterId > 0)
            {
                if (InstanceManager.Instance.IsAutoFighting == false)
                {
                    InstanceManager.Instance.IsAutoFighting = true;
                    InstanceManager.Instance.SetAutoFightingTargetMonsterId(TargetMonsterId);
                }
            }

            if (FinishedCallback != null)
            {
                FinishedCallback();
            }

            IsRunning = false;
        }

        public bool WalkToTarget()
        {
            if(Reached)
            {
                return true;
            }

            if(!NeedWork)
            {
                return true;
            }

            Actor player = Game.GetInstance().GetLocalPlayer();

            // 此时资源还未加载完成
            if (player == null || player.IsResLoaded == false)
            {
                return false;
            }

            if(Game.GetInstance().GetLoadAsyncOp() != null && Game.GetInstance().GetLoadAsyncOp().isDone == false)
            {
                return false;
            }

            if (GameInput.Instance.GetEnableInput() == false)
            {
                return false;
            }

            Vector3 targetPos = Vector3.zero;

            if (TargetNpcId != 0)
            {
                if(NpcManager.GetNpcPos(TargetNpcId, ref targetPos))
                {
                    IsRunning = true;
                    TargetPathManager.Instance.LocalPlayerWalkToDestination(targetPos, RelateTask);
                    return true;
                }
            }
            else if (TargetTriggerId != 0)
            {
                //TriggerCollider trigger = TriggerManager.Instance.GetTrigger((int)TargetTriggerId);

                //if (trigger != null)
                //{
                //    targetPos = trigger.transform.position;
                //    TargetPathManager.Instance.LocalPlayerWalkToDestination(targetPos);
                //    return true;
                //}
            }
            else if (WantEnterMapId != 0)
            {
                //foreach (var triggerItem in TriggerManager.Instance.Triggers)
                //{
                //    if (triggerItem.Value.TriggerInfo.NeedNavigation == false)
                //    {
                //        continue;
                //    }

                //    if (triggerItem.Value.TriggerInfo.Info == Spartan.TriggerInfo.InfoType.PORTAL && triggerItem.Value.TriggerInfo.PortalTargetMapID == WantEnterMapId)
                //    {
                //        targetPos = triggerItem.Value.transform.position;
                //        TargetPathManager.Instance.LocalPlayerWalkToDestination(targetPos);

                //        TargetTriggerId = (uint)triggerItem.Value.TriggerInfo.Id;

                //        return true;
                //    }
                //}
            }
            else if(TargetMonsterId != 0)
            {
                Vector3 monsterPosition = xc.Dungeon.LevelObjectHelper.GetNearestMonsterPositionByActorId(TargetMonsterId);

                if (monsterPosition.Equals(Vector3.zero) == false)
                {
                    targetPos = monsterPosition;
                    targetPos = InstanceHelper.ClampInWalkableRange(targetPos);

                    IsRunning = true;
                    TargetPathManager.Instance.LocalPlayerWalkToDestination(targetPos, RelateTask);

                    return true;
                }
            }
            else if (TargetTagId != 0)
            {
                Neptune.Tag tagInfo = Neptune.DataManager.Instance.Data.GetNode<Neptune.Tag>((int)TargetTagId);
                if (tagInfo != null)
                {
                    Vector3 tagPosition = tagInfo.Position;
                    float radius = tagInfo.SphereRadius;
                    if (tagPosition.Equals(Vector3.zero) == false)
                    {
                        targetPos = tagPosition;
                        targetPos.x = tagPosition.x + UnityEngine.Random.Range(-radius, radius);
                        targetPos.z = Mathf.Sqrt(radius * radius - (targetPos.x - tagPosition.x) * (targetPos.x - tagPosition.x)) + tagPosition.z;

                        targetPos = InstanceHelper.ClampInWalkableRange(targetPos);

                        IsRunning = true;
                        TargetPathManager.Instance.LocalPlayerWalkToDestination(targetPos, RelateTask);

                        return true;
                    }
                }
            }
            else if(Vector3.zero.Equals(TargetConstPos) == false)
            {
                if (IsReachConstTargetPos())
                {
                    TargetPathManager.Instance.NotifyLastPathNodeReached();
                    return true;
                }

                IsRunning = true;
                TargetPathManager.Instance.LocalPlayerWalkToDestination(TargetConstPos, RelateTask);

                return true;
            }

            return false;
        }

        private bool IsReachConstTargetPos()
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();

            if(localPlayer == null)
            {
                return false;
            }

            float deltaDistance = localPlayer.MoveSpeed * Time.deltaTime;

            Vector3 selfPos = localPlayer.transform.position;
            Vector3 targetPos = TargetConstPos;

            selfPos.y = 0.0f;
            targetPos.y = 0.0f;

            Vector3 direction = targetPos - selfPos;
            direction = direction.normalized;

            targetPos = targetPos - selfPos;
            float compareDistance = targetPos.magnitude;

            if (compareDistance <= deltaDistance)
            {
                return true;
            }

            return false;
        }
    }
}
