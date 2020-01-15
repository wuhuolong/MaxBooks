using System;
using System.Collections.Generic;
using UnityEngine;
using xc;
using BehaviourTree;

[wxb.Hotfix]
public class AIBaseFunction
{
    public AIRunningProperty RunningProperty;

    /// <summary>
    /// 直接返回指定的返回值
    /// </summary>
    /// <param name="returnCode"></param>
    /// <returns></returns>
    public BehaviourReturnCode ActionReturnCode(int returnCode)
    {
        return (BehaviourReturnCode)returnCode;
    }

    /// <summary>
    /// 追踪玩家
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionChaseTarget()
    {
        if(RunningProperty.TargetActor == null)
        {
            return BehaviourReturnCode.Success;
        }

        if (RunningProperty.SelfActor.IsAttacking())
        {
            if (RunningProperty.SelfActor.IsInSkillActionEndingStage())
            {
                return BehaviourReturnCode.Success;
            }
        }

        // 主角挂机是否是定点挂机
        if (RunningProperty.SelfActor is LocalPlayer)
        {
            if (HookSettingManager.Instance.RangeType == EHookRangeType.FixedPos)
            {
                return BehaviourReturnCode.Success;
            }
        }

        //RunningProperty.AI.SetRandomSkill();

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.CHASETARGET);
        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 巡逻
    /// </summary>
    /// <param name="currentIsCenterPos">当前坐标是否是巡逻中心点坐标</param>
    /// <returns></returns>
    public BehaviourReturnCode ActionPatrol(bool currentIsCenterPos)
    {
        if (RunningProperty.SelfActor is LocalPlayer)
        {
            // 定点挂机
            if (HookSettingManager.Instance.RangeType == EHookRangeType.FixedPos)
            {
                return BehaviourReturnCode.Success;
            }
            // 副本类型控制表配置是否要巡逻
            else if (DBInstanceTypeControl.Instance.DoNotPatrol(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType) == true)
            {
                return BehaviourReturnCode.Success;
            }
        }

        BehaviourPatrolFiniteState patrolState = RunningProperty.AI.Machine.GetState<BehaviourPatrolFiniteState>(BehaviourMachine.State.PATROL);

        if (currentIsCenterPos)
        {
            patrolState.PresetCenterPos = RunningProperty.SelfActorPos;
        }

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.PATROL);

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 跟随玩家
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionFollowPlayer()
    {
        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.FOLLOW);
        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionTestRun()
    {
        // 追逐算法
        Vector3 toEvader = RunningProperty.TargetActorPos - RunningProperty.SelfActorPos;

        float time = toEvader.magnitude / (RunningProperty.TargetActor.MoveSpeed + RunningProperty.SelfActor.MoveSpeed);
        Vector3 targetPos = RunningProperty.SelfActorPos + RunningProperty.TargetActor.MoveDir * time;

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.RUN);

        BehaviourRunFiniteState state = RunningProperty.AI.Machine.GetCurrentState<BehaviourRunFiniteState>();
        state.LastTargetPos = targetPos;

        //RunningProperty.SelfActor.MoveCtrl.TryRunTo(targetPos);
        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionFireEvent(int eventId)
    {
        //Destiny.DestinyManager.Instance.Fire(eventId, RunningProperty.SelfActor.gameObject);

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionSetAILevelHpBeacons(float beacon1, float beacon2, int beaconType)
    {
        RunningProperty.AI.SetAILevelHpBeacons(beacon1, beacon2, beaconType);

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 站立
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionStand()
    {
        if(RunningProperty.SelfActor.IsAttacking())
        {
            return BehaviourReturnCode.Success;
        }

        RunningProperty.AI.PathWalker.Reset();
        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.STAND);

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionAttack()
    {
        //if (RunningProperty.SelfActor.IsAttacking())
        //{
        //    if (RunningProperty.TargetSkill != null && RunningProperty.TargetSkill.IsCanCacheNext() == false)
        //    {
        //        return BehaviourReturnCode.Failure;
        //    }
        //}

        RunningProperty.AI.PathWalker.Reset();
        //RunningProperty.AI.SetRandomSkill();

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.ATTACK);
        //RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionTryAttack()
    {
        RunningProperty.AI.PathWalker.Reset();
        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.ATTACK);
        //RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 什么也不做
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionDoNothing()
    {
        if(RunningProperty.AI.Machine.CurrentStateType != BehaviourMachine.State.EMPTY)
        {
            RunningProperty.AI.PathWalker.Reset();
            //GameDebug.LogError("RunningProperty.SelfActor.Stand()");
            //RunningProperty.SelfActor.Stand();
        }

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 自杀行为
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSuicide()
    {
        RunningProperty.SelfActor.BeattackedCtrl.KillSelf();

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 把仇恨值最高的角色设置为目标角色
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetMostHateActorToTarget()
    {
        RunningProperty.TargetActor = RunningProperty.AI.Ambient.GetMostHateActor();

        if(RunningProperty.TargetActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        RunningProperty.RefreshState();

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置最近的玩家是打击目标
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetPlayerToTarget()
    {
        RunningProperty.TargetActor = AIHelper.GetNearestActor(RunningProperty, ActorManager.Instance.PlayerSet);

        if (RunningProperty.TargetActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        RunningProperty.TargetActorIsCounterattack = false;
        RunningProperty.RefreshState();

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置最近的怪物是打击目标
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetMonsterToTarget()
    {
        RunningProperty.TargetActor = AIHelper.GetNearestActor(RunningProperty, ActorManager.Instance.MonsterSet);

        if (RunningProperty.TargetActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        RunningProperty.TargetActorIsCounterattack = false;
        RunningProperty.RefreshState();

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionCleanCanNotAttackTarget()
    {
        if (RunningProperty.TargetActor != null)
        {
            if (RunningProperty.TargetActor.IsPlayer() && (RunningProperty.SelfActor is LocalPlayer || RunningProperty.SelfActor.ParentActor is LocalPlayer))
            {
                var show_tips = false;
                if (PKModeManagerEx.Instance.IsLocalPlayerCanAttackActor(RunningProperty.TargetActor, ref show_tips) == false)
                {
                    RunningProperty.TargetActor = null;
                }
            }
        }

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置最近的目标
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetPlayerOrMonsterToTarget()
    {
        if (RunningProperty.TargetActor != null)
        {
            if (HookSettingManager.Instance.RangeType == EHookRangeType.FixedPos && RunningProperty.GetToTargetDistanceSquare() > (MaxAttackDistance * MaxAttackDistance))
            {
                RunningProperty.TargetActor = null;
            }
            else if (RunningProperty.TargetActor.IsDead() == false)
            {
                return BehaviourReturnCode.Success;
            }
        }

        var player = AIHelper.GetNearestActor(RunningProperty, ActorManager.Instance.PlayerSet);

        if (SceneHelp.Instance.PrecedentPlayer)// 优先选择玩家
        {
            if (player != null)
            {
                RunningProperty.TargetActor = player;
                RunningProperty.TargetActorIsCounterattack = false;

                return BehaviourReturnCode.Success;
            }
        }

        float motionRadius = RunningProperty.MotionRadius;
        // 定点挂机
        if (RunningProperty.SelfActor is LocalPlayer && HookSettingManager.Instance.RangeType == EHookRangeType.FixedPos)
        {
            motionRadius = 1f;
        }

        Dictionary<UnitID, Actor> monsters = null;
        if (RunningProperty.TargetMonsterId == 0)
        {
            monsters = AIHelper.GetMonsterListByRange(RunningProperty.OriginalSelfActorPos, motionRadius + MaxAttackDistance);
        }
        else
        {
            monsters = AIHelper.GetMonsterListByActorIdAndRange(RunningProperty.TargetMonsterId, RunningProperty.OriginalSelfActorPos, motionRadius + MaxAttackDistance);
        }

        Actor monster = null;

        // 先看看怪物列表里面是否有boss，有的话只在boss里面选
        Actor boss = AIHelper.GetBossActor(monsters);
        if (boss != null)
        {
            monster = boss;
        }
        else
        {
            monster = AIHelper.GetNearestActor(RunningProperty, monsters);
        }

        if(player == null)
        {
            RunningProperty.TargetActor = monster;
        }
        else if(monster == null)
        {
            RunningProperty.TargetActor = player;
        }
        else
        {
            if(Vector3.Distance(RunningProperty.SelfActorPos, player.transform.position) <= Vector3.Distance(RunningProperty.SelfActorPos, monster.transform.position))
            {
                RunningProperty.TargetActor = player;
            }
            else
            {
                RunningProperty.TargetActor = monster;
            }
        }

        if (RunningProperty.TargetActor != null && Vector3.Distance(RunningProperty.SelfActorPos, RunningProperty.TargetActor.transform.position) <= AttackCtrl.MaxTargetRange)
        {
            RunningProperty.SelfActor.AttackCtrl.CurSelectActor = RunningProperty.TargetActor.GetActorMono();
        }

        RunningProperty.RefreshState();

        if (RunningProperty.TargetActor == null)
        {
            return BehaviourReturnCode.Success;
        }

        if (RunningProperty.GetToTargetDistanceSquare() > ((motionRadius + MaxAttackDistance) * (motionRadius + MaxAttackDistance)))
        {
            RunningProperty.TargetActor = null;
            return BehaviourReturnCode.Success;
        }

        if (HookSettingManager.Instance.RangeType == EHookRangeType.FixedPos && RunningProperty.GetToTargetDistanceSquare() > (MaxAttackDistance * MaxAttackDistance))
        {
            RunningProperty.TargetActor = null;
            return BehaviourReturnCode.Success;
        }

        if (RunningProperty.TargetActor.IsDead() == true)
        {
            RunningProperty.TargetActor = null;
            return BehaviourReturnCode.Success;
        }

        RunningProperty.TargetActorIsCounterattack = false;

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置需要反击的玩家
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetNeedCounterattackPlayerToTarget()
    {
        LocalPlayer localPlayer = RunningProperty.SelfActor as LocalPlayer;

        if(localPlayer == null)
        {
            if(RunningProperty.SelfActor.ParentActor is LocalPlayer)
            {
                localPlayer = RunningProperty.SelfActor.ParentActor as LocalPlayer;
            }
        }

        if(localPlayer == null)
        {
            return BehaviourReturnCode.Success;
        }

        if(RunningProperty.TargetActorIsCounterattack && RunningProperty.TargetActor != null)
        {
            return BehaviourReturnCode.Success;
        }

        //RunningProperty.TargetActor = null;
        RunningProperty.RefreshState();

        return BehaviourReturnCode.Failure;
    }

    /// <summary>
    /// 设置默认目标角色
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetDefaultActorToTarget()
    {
        RunningProperty.TargetActor = RunningProperty.AI.GetDefaultTargetActor();

        if (RunningProperty.TargetActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        RunningProperty.RefreshState();

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 选定技能攻击
    /// </summary>
    /// <param name="skillId"></param>
    /// <returns></returns>
    public BehaviourReturnCode ActionSelectSkillAttack(int skillId)
    {
        //RunningProperty.TargetSkill = RunningProperty.SelfActor.GetSelfSkill((uint)skillId);
        RunningProperty.TargetSkillId = (uint)skillId;

        if (RunningProperty.TargetSkill == null)
        {
            Debug.LogError(string.Format("AIBaseFunction::ActionSelectSkillAttack failed,{0} can not get skill:{1}", RunningProperty.SelfActor.TypeIdx, skillId));
            return BehaviourReturnCode.Failure;
        }

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.ATTACK);
        //RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置上一次使用的攻击技能/目标到现在的状态
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetLastSkillAndTargetToCurrent()
    {
        if(RunningProperty.LastTargetActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        Actor lastActor = RunningProperty.LastTargetActor.BindActor;

        if(lastActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        if(lastActor.IsDead())
        {
            return BehaviourReturnCode.Failure;
        }

        if(RunningProperty.LastUseSkillId <= 0)
        {
            return BehaviourReturnCode.Failure;
        }

        //Skill skill = RunningProperty.SelfActor.GetSelfSkill(RunningProperty.LastUseSkillId);

        //if(skill == null)
        //{
        //    return BehaviourReturnCode.Failure;
        //}

//         if (RunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(skill, 0) == false)
//         {
//             // 不能攻击且没技能用的情况下才算失败
//             if(RunningProperty.SelfActor.IsAttacking() == false)
//             {
//                 return BehaviourReturnCode.Failure;
//             }
//         }

        RunningProperty.TargetActor = RunningProperty.LastTargetActor.BindActor;
        RunningProperty.TargetSkillId = RunningProperty.LastUseSkillId;

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionWalkToOriginalPos()
    {
        if (RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.WALK)
        {
            return BehaviourReturnCode.Failure;
        }

        if (AIHelper.RoughlyEqual(RunningProperty.OriginalSelfActorPos, RunningProperty.SelfActorPos))
        {
            RunningProperty.AI.PathWalker.IsWalkingToOriginalPos = false;
            RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            return BehaviourReturnCode.Success;
        }

        RunningProperty.TargetActor = null;

        RunningProperty.AI.PathWalker.WalkTo(RunningProperty.OriginalSelfActorPos);
        RunningProperty.AI.PathWalker.IsWalkingToOriginalPos = true;
        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.WALK);

        return BehaviourReturnCode.Failure;
    }

    /// <summary>
    /// 瞬移到parent周围的随机位置
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionTeleportToParentActorRangeRandomPosition(float nearRadius, float farRadius)
    {
        if (RunningProperty.SelfActor.ParentActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        Vector3 pos = AIHelper.GetActorRangeRandomPosition(RunningProperty.SelfActor.ParentActor, nearRadius, farRadius);

        if (AIHelper.RoughlyEqual(pos, RunningProperty.SelfActorPos))
        {
            RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            return BehaviourReturnCode.Success;
        }

        RunningProperty.TargetActor = null;

        RunningProperty.SelfActor.SetPosition(pos);
        RunningProperty.AI.PathWalker.WalkTo(pos);

        if (RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.STAND)
        {
            RunningProperty.AI.Machine.CurrentState.StatingDuration = 0.0f;
        }

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 移动到父亲目标指定范围内的随机位置
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionWalkToParentActorRangeRandomPosition(float nearRadius, float farRadius)
    {
        if (RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.WALK)
        {
            return BehaviourReturnCode.Failure;
        }

        if (RunningProperty.SelfActor.ParentActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        Vector3 pos = AIHelper.GetActorRangeRandomPosition(RunningProperty.SelfActor.ParentActor, nearRadius, farRadius);

        if (AIHelper.RoughlyEqual(pos, RunningProperty.SelfActorPos))
        {
            RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            return BehaviourReturnCode.Success;
        }

        RunningProperty.TargetActor = null;

        RunningProperty.AI.PathWalker.WalkTo(pos);
        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.WALK);

        return BehaviourReturnCode.Failure;
    }

    /// <summary>
    /// 是否远离要跟随的玩家
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsFarAwayFollowActor()
    {
        if(ConditionIsHaveFollowInfo() == false)
        {
            return false;
        }

        Vector3 followPos = Vector3.zero;
        if(RunningProperty.FollowActor != null)
        {
            followPos = RunningProperty.FollowActor.transform.position;
        }
        else
        {
            followPos = RunningProperty.FollowBackupPosition;
        }

        if(Vector3.Equals(followPos, Vector3.zero))
        {
            return false;
        }

        if (AIHelper.DistanceSquare(RunningProperty.SelfActorPos, followPos) >= (150.0f))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 是否在混乱状态
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsInChaosState()
    {
        if(RunningProperty.SelfActor.HasBattleState(BattleStatusType.BATTLE_STATUS_TYPE_CHAOS))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 是否有跟随的信息
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsHaveFollowInfo()
    {
        Actor followActor = RunningProperty.FollowActor;

        if (followActor != null)
        {
            return true;
        }

        if (!AIHelper.RoughlyEqual(RunningProperty.FollowBackupPosition, Vector3.zero))
        {
            return true;
        }

        return false;
    }

    public bool ConditionTargetIsInAttackRange()
    {
        if(RunningProperty.TargetActor == null)
        {
            return false;
        }

        float distanceSquare = RunningProperty.GetToTargetDistanceSquare();
        if (distanceSquare <= (MaxAttackDistance * MaxAttackDistance) || (RunningProperty.GetToTargetColliderDistance()) <= MaxAttackDistance)
        {
            if (distanceSquare >= (MinAttackDistance * MinAttackDistance))
            {
                BehaviourChaseTargetFiniteState chaseState = RunningProperty.AI.Machine.CurrentState as BehaviourChaseTargetFiniteState;

                if(chaseState == null)
                {
                    return true;
                }

                if(chaseState.IsChasing == false)
                {
                    return true;
                }

                if (distanceSquare <= (chaseState.Radius * chaseState.Radius))
                {
                    return true;
                }
            }
        }

        if (RunningProperty.TargetSkill != null)
        {
            if (RunningProperty.TargetSkill.GetAction(0).ActionData.SkillInfo.Target == "self")
            {
                return true;
            }
        }

        return false;
    }

    public bool ConditionIsSeeTarget()
    {
        if (RunningProperty == null)
        {
            return false;
        }

        if (RunningProperty.TargetActor == null)
        {
            return false;
        }

        return true;
    }

    public bool ConditionIsInMotionRange()
    {
        if (RunningProperty == null)
        {
            return true;
        }

        if (RunningProperty.SelfActor == null)
        {
            return true;
        }

        // 定点挂机
        if (RunningProperty.SelfActor is LocalPlayer && HookSettingManager.Instance.RangeType == EHookRangeType.FixedPos)
        {
            if (Vector3.Distance(RunningProperty.SelfActor.transform.position, RunningProperty.OriginalSelfActorPos) > 1f)
            {
                return false;
            }
        }

        if (RunningProperty.MotionRadius < 0f)
        {
            return true;
        }

        if (Vector3.Distance(RunningProperty.SelfActor.transform.position, RunningProperty.OriginalSelfActorPos) > RunningProperty.MotionRadius)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 追逐的时间是否超过这个长度
    /// </summary>
    /// <param name="overTime"></param>
    /// <returns></returns>
    public bool ConditionIsChasingOverrideTime(float overTime)
    {
        if(RunningProperty.AI.Machine.CurrentState.Id != BehaviourMachine.State.CHASETARGET)
        {
            return false;
        }

        BehaviourChaseTargetFiniteState chaseState = RunningProperty.AI.Machine.CurrentState as BehaviourChaseTargetFiniteState;

        if(chaseState == null)
        {
            return false;
        }

        if(chaseState.StatingDuration >= overTime)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 站立的时间是否超过这个长度
    /// </summary>
    /// <param name="overTime"></param>
    /// <returns></returns>
    public bool ConditionIsStandingOverrideTime(float overTime)
    {
        if (RunningProperty.AI.Machine.CurrentState.Id != BehaviourMachine.State.STAND)
        {
            return false;
        }

        BehaviourStandFiniteState standState = RunningProperty.AI.Machine.CurrentState as BehaviourStandFiniteState;

        if (standState == null)
        {
            return false;
        }

        if (standState.StatingDuration >= overTime)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 是否在野外
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsInWildScene()
    {
        return SceneHelp.Instance.IsInWildInstance();
    }

    public virtual bool ConditionIsNeedPatrol()
    {
        return false;  
    }

    public virtual bool ConditionIsNeedFollowPlayer()
    {
        return false;
    }

    public virtual bool ConditionHaveTargetDrop()
    {
        return false;
    }

    public virtual bool ConditionHaveTargetCollection()
    {
        return false;
    }

    public virtual bool ConditionSelfActorIsInteraction()
    {
        return false;
    }

    /// <summary>
    /// 是否在安全区
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsInSafaArea()
    {
        if(RunningProperty.SelfActor == null)
        {
            return false;
        }

        return RunningProperty.SelfActor.IsInSafeArea;
    }

    /// <summary>
    /// 当前玩家是否在操控
    /// </summary>
    /// <returns></returns>
    public bool ConditionPlayerIsControlling()
    {
        if(GameInput.GetInstance().IsInput)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 跟随的玩家是否攻击了
    /// </summary>
    /// <returns></returns>
    public bool ConditionFollowActorIsAttacked()
    {
        if(ConditionIsHaveFollowInfo())
        {
            return RunningProperty.FollowActorIsAttacked;
        }

        return false;
    }

    /// <summary>
    /// 当前是否空闲
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsIdle()
    {
        bool result = RunningProperty.SelfActor.IsIdle();

        return result;
    }

    /// <summary>
    /// 选取的技能当前是否可以攻击
    /// </summary>
    /// <returns></returns>
    public bool ConditionSelectSkillInCanFire()
    {
        if(RunningProperty.TargetSkill == null)
        {
            return false;
        }

        bool result = RunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(RunningProperty.TargetSkill, 0);
        return result;
    }

    /// <summary>
    /// 当前是否在走路
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsWalking()
    {
        if (RunningProperty.SelfActor == null)
        {
            return false;
        }

        bool result = RunningProperty.SelfActor.IsWalking();

        return result;
    }

    /// <summary>
    /// 当前是否在攻击
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsAttacking()
    {
        if (RunningProperty.SelfActor == null)
        {
            return false;
        }

        bool result = RunningProperty.SelfActor.IsAttacking();

        return result;
    }

    /// <summary>
    /// 当前是否在攻击或受击
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsAttackingOrBeAttacking()
    {
        if (RunningProperty.SelfActor == null)
        {
            return false;
        }

        return RunningProperty.SelfActor.IsAttacking() || RunningProperty.SelfActor.IsBeAttacking();
    }

    /// <summary>
    /// 当前技能是否处于后摇阶段之前
    /// </summary>
    /// <returns></returns>
    public bool ConditionTargetSkillIsInBeforeSkillActionEndingStage()
    {
        Skill targetSkill = RunningProperty.TargetSkill;
        if (targetSkill == null)
        {
            return false;
        }

        bool ret = targetSkill.IsInBeforeSkillActionEndingStage();

        //if (targetSkill.IsMultiAction() == true)
        //{
        //    BehaviourAttackFiniteState attackState = RunningProperty.AI.Machine.GetState<BehaviourAttackFiniteState>(BehaviourMachine.State.ATTACK);
        //    if (attackState != null)
        //    {
        //        GameDebug.LogError("ConditionTargetSkillIsInBeforeSkillActionEndingStage CurrentComboAttackCount: " + attackState.CurrentComboAttackCount + ", " + targetSkill.GetSkillActionCount());
        //        if (attackState.CurrentComboAttackCount >= (targetSkill.GetSkillActionCount() - 1))
        //        {
        //            return ret;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        return ret;
    }

    public bool ConditionIsWalkingToOriginalPos()
    {
        return RunningProperty.AI.PathWalker.IsWalkingToOriginalPos == true;
    }

    public bool ConditionIsWalkingToDropPos()
    {
        return RunningProperty.AI.PathWalker.IsWalkingToDropPos == true;
    }

    public bool ConditionIsWalkingToCollectionPos()
    {
        return RunningProperty.AI.PathWalker.IsWalkingToCollectionPos == true;
    }

    /// <summary>
    /// 是否远离父亲一定的距离
    /// </summary>
    /// <param name="distanceSquare"></param>
    /// <returns></returns>
    public bool ConditionIsFarAwayParentActor(float distanceSquare)
    {
        Vector3 parentPos = Vector3.zero;
        if (RunningProperty.SelfActor != null && RunningProperty.SelfActor.ParentActor != null && RunningProperty.SelfActor.ParentActor.transform != null)
        {
            parentPos = RunningProperty.SelfActor.ParentActor.transform.position;
        }

        if (Vector3.Equals(parentPos, Vector3.zero))
        {
            return false;
        }

        if (AIHelper.DistanceSquare(RunningProperty.SelfActor.transform.position, parentPos) >= distanceSquare)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 与父亲的距离是否少于一定的距离
    /// </summary>
    /// <param name="distanceSquare"></param>
    /// <returns></returns>
    public bool ConditionIsNearParentActor(float distanceSquare)
    {
        Vector3 parentPos = Vector3.zero;
        if (RunningProperty.SelfActor != null && RunningProperty.SelfActor.ParentActor != null && RunningProperty.SelfActor.ParentActor.transform != null)
        {
            parentPos = RunningProperty.SelfActor.ParentActor.transform.position;
        }

        if (Vector3.Equals(parentPos, Vector3.zero))
        {
            return false;
        }

        if (AIHelper.DistanceSquare(RunningProperty.SelfActor.transform.position, parentPos) <= distanceSquare)
        {
            return true;
        }

        return false;
    }

    public float MinAttackDistance
    {
        get
        {
            //return 0.0f;

            //RunningProperty.AI.SetRandomSkill();

            if(RunningProperty.TargetSkill == null)
            {
                return 1.0f;
            }

            Vector2 range = RunningProperty.TargetSkill.GetAttackRange(0);

            if(range.x < 0.2f)
            {
                return 0.2f;
            }

            return range.x;
        }
    }

    public float MaxAttackDistance
    {
        get
        {
            if (RunningProperty.TargetSkill == null)
            {
                return 0.0f;
            }

            Vector2 range = RunningProperty.TargetSkill.GetAttackRange(0);

            // AttackCtrl里面可选目标的最大距离，需要取两者的最小值
            return Mathf.Min(range.y, AttackCtrl.MaxTargetRange);
        }
    }

    /// <summary>
    /// 最小的追击距离 MinChaseDistance <= 追击时的目标距离 <= MaxAttackDistance
    /// </summary>
    public float MinChaseDistance
    {
        get
        {
            //RunningProperty.AI.SetRandomSkill();

            float maxDistance = MaxAttackDistance * GameConstHelper.GetFloat("GAME_AI_CHASE_DISTANCE_RATIO");

            return maxDistance;
        }
    }
}
