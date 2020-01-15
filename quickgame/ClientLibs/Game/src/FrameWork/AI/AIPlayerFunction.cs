using System;
using System.Collections.Generic;
using UnityEngine;
using xc;
using BehaviourTree;
using xc.Dungeon;

[wxb.Hotfix]
public class AIPlayerFunction : AIBaseFunction
{
    /// <summary>
    /// 走到副本的尽头
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionWalkToInstanceEndPosition()
    {
        if(RunningProperty.SelfActor.IsWalking())
        {
            return BehaviourReturnCode.Success;
        }

        Vector3 endPosition = InstanceHelper.GetAutoRunnerTargetLocation();

        if (Vector3.Equals(endPosition, Vector3.zero))
        {
            return BehaviourReturnCode.Success;
        }

        if (AIHelper.RoughlyEqual(endPosition, RunningProperty.SelfActorPos))
        {
            RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            return BehaviourReturnCode.Success;
        }

        endPosition.y = RoleHelp.GetHeightInScene(RunningProperty.SelfActor.ActorId, endPosition.x, endPosition.z);

        //endPosition = InstanceHelper.ClampInWalkableRange(endPosition);

        RunningProperty.AI.PathWalker.WalkTo(endPosition);

        //         uint instanceType = InstanceManager.Instance.InstanceType;
        // 
        //         if (instanceType == GameConst.WAR_TYPE_WILD || instanceType == GameConst.WAR_TYPE_HOLE || instanceType == GameConst.WAR_SUBTYPE_WILD_PUB || instanceType == GameConst.WAR_TYPE_MULTI)
        //         {
        //             RunningProperty.AI.PathWalker.WalkTo(endPosition);
        //         }
        //         else
        //         {
        //             RunningProperty.SelfActor.MoveCtrl.TryWalkTo(endPosition);
        //         }

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.WALK);

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionSetAvailableSkill()
    {
        //List<Skill> skills = new List<Skill>();
        //skills.Clear();

        //Dictionary<uint, Skill> fitSkills = SkillManager.Instance.FitSkills;
        //foreach (Skill skill in fitSkills.Values)
        //{
        //    if (skill != null && skill.IsNextActionInCD() == false && RunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(skill, 0) == true)
        //    {
        //        skills.Add(skill);
        //    }
        //}

        //if (skills.Count <= 0)
        //{
        //    return BehaviourReturnCode.Failure;
        //}

        //int rand = UnityEngine.Random.Range(0, skills.Count);

        //RunningProperty.TargetSkill = skills[rand];

        if (RunningProperty.TargetSkillId > 0)
        {
            return BehaviourReturnCode.Success;
        }

        uint skillId = SkillManager.Instance.GetAvailableSkill();
        if (skillId == 0)
        {
            return BehaviourReturnCode.Failure;
        }

        //GameDebug.LogError("ActionSetAvailableSkill: " + skill.SkillID);
        //RunningProperty.TargetSkill = skill;
        RunningProperty.TargetSkillId = skillId;
        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 打开宝箱或者解救NPC
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionOpenChest()
    {
        RunningProperty.AI.PathWalker.Reset();

        if(RunningProperty.SelfActor.IsAttacking() /*|| RunningProperty.SelfActor.IsWalking() || RunningProperty.SelfActor.IsRunning()*/)
        {
            return BehaviourReturnCode.Success;
        }

        return BehaviourReturnCode.Failure;
    }

    /// <summary>
    /// 玩家喝药
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionUseHpDrug()
    {
        //GameDebug.LogError("ActionUseHpDrug");

        InstanceHelper.UseDrugInInstance();

//        xc.ui.UIInstanceWindow wnd = xc.ui.UIManager.GetInstance().GetWindow("UIInstanceWindow") as xc.ui.UIInstanceWindow;
//        if (wnd != null)
//        {
//            wnd.IsUseDrugButtonEnabled = false;
//        }

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionWalkToClosestMine()
    {
        if(RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.RUN)
        {
            return BehaviourReturnCode.Success;
        }

        //MineInstanceManager.MineInfo closetMine = MineInstanceManager.Instance.GetClosestMine();

        //if(closetMine != null)
        //{
        //    RunningProperty.AI.PathWalker.RunTo(closetMine.Position);
        //}

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.RUN);

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionSetTargetDrop()
    {
        if (RunningProperty.SelfActor == null)
        {
            return BehaviourReturnCode.Success;
        }

        if (HookSettingManager.Instance.AutoPickDrop == false)
        {
            RunningProperty.TargetDropId = 0;
            return BehaviourReturnCode.Success;
        }

        if (RunningProperty.TargetDropId > 0)
        {
            return BehaviourReturnCode.Success;
        }

        bool isFull = ItemManager.Instance.BagIsFull(1);
        if (InstanceDropManager.Instance.Drops != null)
        {
            float minDistance = float.MaxValue;
            Vector3 selfPos = RunningProperty.SelfActor.transform.position;
            DropComponent nearestDrop = null;
            foreach (DropComponent drop in InstanceDropManager.Instance.Drops)
            {
                if (drop != null && drop.DropInfo != null && HookSettingManager.Instance.CheckIsInAutoPickDropGoodsSettingInfo(drop.DropInfo.gid) == true)
                {
                    if ((drop.DropInfo.type == GameConst.GIVE_TYPE_GOODS || drop.DropInfo.type == GameConst.GIVE_TYPE_EQUIP) && isFull == true)
                    {

                    }
                    else
                    {
                        if (drop.CanPick == true && drop.IsInCD == false && drop.IsBossChip == false)
                        {
                            selfPos.y = 0;
                            Vector3 dropPos = drop.transform.position;
                            dropPos.y = 0;
                            float distance = Vector3.Distance(selfPos, dropPos);
                            if (distance <= RunningProperty.MotionRadius && distance < minDistance)
                            {
                                minDistance = distance;
                                nearestDrop = drop;
                            }
                        }
                    }
                }
            }

            if (nearestDrop != null)
            {
                RunningProperty.TargetDropId = nearestDrop.Id;
                return BehaviourReturnCode.Success;
            }
        }

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionWalkToTargetDrop()
    {
        if (RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.WALK)
        {
            return BehaviourReturnCode.Failure;
        }

        DropComponent drop = InstanceDropManager.Instance.GetDrop(RunningProperty.TargetDropId);
        if (drop == null)
        {
            RunningProperty.TargetDropId = 0;
            return BehaviourReturnCode.Success;
        }
        Vector3 dropPos = drop.transform.position;

        if (AIHelper.RoughlyEqual(dropPos, RunningProperty.SelfActorPos))
        {
            RunningProperty.TargetDropId = 0;
            RunningProperty.AI.PathWalker.IsWalkingToDropPos = false;
            RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            return BehaviourReturnCode.Success;
        }

        RunningProperty.TargetActor = null;

        RunningProperty.AI.PathWalker.WalkTo(dropPos);
        RunningProperty.AI.PathWalker.IsWalkingToDropPos = true;
        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.WALK);

        return BehaviourReturnCode.Failure;
    }

    public BehaviourReturnCode ActionSetTargetCollection()
    {
        if (RunningProperty.SelfActor == null)
        {
            return BehaviourReturnCode.Success;
        }

        // 副本是否配置自动采集
        if (DBInstanceTypeControl.Instance.AutoCollect(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType) == false)
        {
            RunningProperty.TargetCollectionId = 0;
            return BehaviourReturnCode.Success;
        }

        if (CollectionObjectManager.Instance.Enable == false)
        {
            RunningProperty.TargetCollectionId = 0;
            return BehaviourReturnCode.Success;
        }

        if (RunningProperty.TargetCollectionId > 0)
        {
            return BehaviourReturnCode.Success;
        }

        CollectionObject targetCollection = AIHelper.GetNearstAutoCollectableCollectionObject(RunningProperty);
        if (targetCollection != null)
        {
            RunningProperty.TargetCollectionId = targetCollection.Id;
            return BehaviourReturnCode.Success;
        }

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionWalkToTargetCollection()
    {
        if (RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.WALK)
        {
            return BehaviourReturnCode.Failure;
        }

        CollectionObject collectionObject = CollectionObjectManager.Instance.GetCollectionObject(RunningProperty.TargetCollectionId);
        if (collectionObject == null || collectionObject.BindGameObject == null || collectionObject.BindGameObject.transform == null)
        {
            RunningProperty.TargetCollectionId = 0;
            return BehaviourReturnCode.Success;
        }
        CollectionObjectBehaviour collectionObjectBehaviour = collectionObject.BindGameObject.GetComponent<CollectionObjectBehaviour>();
        if (collectionObjectBehaviour == null)
        {
            RunningProperty.TargetCollectionId = 0;
            return BehaviourReturnCode.Success;
        }

        Vector3 pos = collectionObject.BindGameObject.transform.position;

        if (AIHelper.RoughlyEqual(pos, RunningProperty.SelfActorPos) || collectionObjectBehaviour.IsTouching == true)
        {
            RunningProperty.TargetCollectionId = 0;
            RunningProperty.AI.PathWalker.IsWalkingToCollectionPos = false;
            RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);

            // 已经在采集物范围内，马上开始采集
            collectionObjectBehaviour.StartInteract();
            return BehaviourReturnCode.Success;
        }

        RunningProperty.TargetActor = null;

        RunningProperty.AI.PathWalker.WalkTo(pos);
        RunningProperty.AI.PathWalker.IsWalkingToCollectionPos = true;
        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.WALK);

        // 设置IsClickedTouch为true，走到采集物范围内就可以开始采集了
        collectionObjectBehaviour.IsClickedTouch = true;

        return BehaviourReturnCode.Failure;
    }

    /// <summary>
    /// 是否正在打开宝箱或者解救NPC
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsOpeningChest()
    {
        return false;
    }

    /// <summary>
    /// 是否需要打开宝箱
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsNeedOpenChest()
    {
        return false;
    }

    public bool ConditionIsHaveCaveInWild()
    {
        //if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD)
        //{
        //    CommonLuaInstanceState wildState = Game.GetInstance().GetFSM().GetCurState() as CommonLuaInstanceState;

        //    if (wildState != null)
        //    {
        //        if(wildState.AllCaves.Count > 0)
        //        {
        //            return true;
        //        }
        //    }
        //}

        return false;
    }

    /// <summary>
    /// 是否看见矿
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsSeeMine()
    {
        //MineInstanceManager.MineInfo mine = MineInstanceManager.Instance.GetClosestMine();

        //if(mine == null)
        //{
        //    return false;
        //}

        //if((mine.Position - RunningProperty.SelfActorPos).sqrMagnitude <= RunningProperty.ViewRange * RunningProperty.ViewRange)
        //{
        //    return true;
        //}

        return false;
    }

    /// <summary>
    /// 身上的矿是否是满的
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsMineFull()
    {
        //return MineInstanceManager.Instance.MineIsFull;
        return false;
    }

    /// <summary>
    /// 是否可以挖最近距离的矿
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsCanDigClosestMine()
    {
        //MineInstanceManager.MineInfo mine = MineInstanceManager.Instance.GetClosestMine();

        //if (mine == null)
        //{
        //    return false;
        //}

        //if(mine.Component == null)
        //{
        //    return false;
        //}

        //bool result = mine.Component.IsLocalPlayerCloseEnough;

        //if(result)
        //{
        //    int sdd = 2;
        //}

        //return result;

        return false;
    }

    /// <summary>
    /// 最近矿的距离是否比怪物近
    /// </summary>
    /// <returns></returns>
    public bool ConditionClosetMineIsNearThanMonster()
    {
        //MineInstanceManager.MineInfo mine = MineInstanceManager.Instance.GetClosestMine();

        //if (mine == null)
        //{
        //    return false;
        //}

        //if(RunningProperty.TargetActor == null)
        //{
        //    return true;
        //}

        //if(RunningProperty.GetToTargetDistanceSquare() < (RunningProperty.SelfActorPos - mine.Position).sqrMagnitude)
        //{
        //    return false;
        //}

        //return true;

        return false;
    }

    public override bool ConditionIsNeedFollowPlayer()
    {
        Actor followActor = RunningProperty.FollowActor;

        Vector3 targetPos = Vector3.zero;

        if (followActor == null && AIHelper.RoughlyEqual(RunningProperty.FollowBackupPosition, Vector3.zero))
        {
            return false;
        }

        if (followActor == RunningProperty.SelfActor)
        {
            return false;
        }

        if (followActor != null)
        {
            RunningProperty.FollowBackupPosition = Vector3.zero;
            targetPos = followActor.transform.position;
        }
        else
        {
            targetPos = RunningProperty.FollowBackupPosition;
        }

        float followRadius = 1.5f;

        if(Vector3.Distance(targetPos, RunningProperty.SelfActorPos) <= (followRadius * 2.0f))
        {
            return false;
        }

        return true;
    }

    public override bool ConditionHaveTargetDrop()
    {
        if (RunningProperty.TargetDropId == 0)
        {
            return false;
        }

        return true;
    }

    public override bool ConditionHaveTargetCollection()
    {
        if (RunningProperty.TargetCollectionId == 0)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 自身是否在采集状态
    /// </summary>
    /// <returns></returns>
    public override bool ConditionSelfActorIsInteraction()
    {
        if (RunningProperty.SelfActor == null || RunningProperty.SelfActor.ActorMachine == null)
        {
            return false;
        }

        return RunningProperty.SelfActor.ActorMachine.IsInInteraction;
    }
}
