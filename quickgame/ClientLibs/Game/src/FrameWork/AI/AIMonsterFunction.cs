using System;
using System.Collections.Generic;
using UnityEngine;
using xc;
using BehaviourTree;

public class AIMonsterFunction : AIBaseFunction
{
    public BehaviourReturnCode ActionTeleportToPlayer()
    {
        float angle = 60.0f;

        Actor followActor = RunningProperty.SelfActor.ParentActor;

        if (followActor == null)
        {
            return BehaviourReturnCode.Success;
        }

        Vector3 targetPos = followActor.transform.position;

        float radius = UnityEngine.Random.Range(1.0f, 3.0f);
        int index = UnityEngine.Random.Range(1, 11);

        targetPos.x = targetPos.x + radius * Mathf.Cos(angle * index);
        targetPos.z = targetPos.z + radius * Mathf.Sin(angle * index);

        RunningProperty.SelfActor.transform.position = targetPos;

        if (RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.STAND)
        {
            RunningProperty.AI.Machine.CurrentState.StatingDuration = 0.0f;
        }

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 逃跑，顺便可以放个Buff
    /// </summary>
    /// <param name="skillId"></param>
    /// <returns></returns>
    public BehaviourReturnCode ActionEscape(uint buffId)
    {
        BehaviourEscapeFiniteState escapeState = RunningProperty.AI.Machine.GetState<BehaviourEscapeFiniteState>(BehaviourMachine.State.ESCAPE);

        if(escapeState != null)
        {
            escapeState.EnterBuffId = buffId;
        }

        RunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.ESCAPE);

        float ratio = (float)((double)(RunningProperty.SelfActor.FullLife - RunningProperty.SelfActor.CurLife) / (double)RunningProperty.SelfActor.FullLife);
        BehaviourMonsterAI monsterAI = RunningProperty.AI as BehaviourMonsterAI;

        if(monsterAI.EscapeHpRationBeacon <= 0.0f)
        {
            monsterAI.CurrentEscapeCount = int.MaxValue;
        }
        else
        {
            monsterAI.CurrentEscapeCount = (int)(ratio / monsterAI.EscapeHpRationBeacon);
        }

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置预设NPC目标是目标角色
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSetPresetNpcActorToTarget()
    {
        Monster monster = RunningProperty.SelfActor as Monster;

        if (monster == null)
        {
            return BehaviourReturnCode.Failure;
        }

        //Spartan.MonsterGroupInfo monsterGroupInfo = monster.SpartanMonsterGroupInfo;

        //if (monsterGroupInfo != null)
        //{
        //    Actor targetActor = NpcManager.Instance.GetNpcByNpcId((uint)monsterGroupInfo.TargetNpcId);

        //    if (targetActor != null && !targetActor.IsActorInvisiable)
        //    {
        //        RunningProperty.TargetActor = targetActor;

        //        if(RunningProperty.TargetActor == null)
        //        {
        //            return BehaviourReturnCode.Failure;
        //        }
        //    }
        //}

        RunningProperty.RefreshState();

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置召唤怪的攻击目标
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSummonMonsterSetTarget()
    {
        if (RunningProperty.TargetActor != null)
        {
            return BehaviourReturnCode.Success;
        }

        Actor parentActor = RunningProperty.SelfActor.ParentActor;
        if (parentActor == null || parentActor.AttackCtrl == null || parentActor.BeattackedCtrl == null)
        {
            return BehaviourReturnCode.Failure;
        }

        // 父亲的目标
        uint lastTargetId = parentActor.AttackCtrl.LastTargetId;
        Actor target = ActorManager.Instance.GetActor(lastTargetId);
        if (target != null)
        {
            RunningProperty.TargetActor = target;

            return BehaviourReturnCode.Success;
        }

        // 攻击父亲的目标
        uint attackerId = parentActor.BeattackedCtrl.LastAttackerId;
        Actor attacker = ActorManager.Instance.GetActor(attackerId);
        if (attacker != null)
        {
            RunningProperty.TargetActor = attacker;

            return BehaviourReturnCode.Success;
        }

        // 离父亲最近的目标
        RunningProperty.TargetActor = AIHelper.GetParentNearestSummonMonsterTargetActor(RunningProperty);

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置不跟随的召唤怪的攻击目标
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionSummonMonsterNotFollowSetTarget()
    {
        if (RunningProperty.TargetActor != null)
        {
            return BehaviourReturnCode.Success;
        }

        Actor parentActor = RunningProperty.SelfActor.ParentActor;
        if (parentActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        // 最近的目标
        RunningProperty.TargetActor = AIHelper.GetSelfNearestSummonMonsterTargetActor(RunningProperty);

        return BehaviourReturnCode.Success;
    }

    /// <summary>
    /// 设置魔仆的攻击目标
    /// </summary>
    /// <returns></returns>
    public BehaviourReturnCode ActionPetSetTarget()
    {
        if (RunningProperty.TargetActor != null)
        {
            RunningProperty.SelfActor.AttackCtrl.CurSelectActor = RunningProperty.TargetActor.GetActorMono();

            return BehaviourReturnCode.Success;
        }

        // 是否使用父亲的目标
        if (RunningProperty.IsAttackParentTarget == false)
        {
            var player = AIHelper.GetNearestActor(RunningProperty, ActorManager.Instance.PlayerSet);
            if (player == null)
            {
                var monster = AIHelper.GetNearestActor(RunningProperty, ActorManager.Instance.MonsterSet);
                RunningProperty.TargetActor = monster;
            }
            else
            {
                RunningProperty.TargetActor = player;
            }
        }
        else
        {
            Actor parentActor = RunningProperty.SelfActor.ParentActor;
            if (parentActor == null || parentActor.AttackCtrl == null)
            {
                return BehaviourReturnCode.Failure;
            }

            // 父亲的目标
            if (parentActor.AttackCtrl.LastTargetId > 0)
            {
                Actor actor = ActorManager.Instance.GetActor(parentActor.AttackCtrl.LastTargetId);
                if (actor != null)
                {
                    RunningProperty.TargetActor = actor;
                }
            }
        }

        if (RunningProperty.TargetActor != null)
        {
            RunningProperty.SelfActor.AttackCtrl.CurSelectActor = RunningProperty.TargetActor.GetActorMono();
        }

        RunningProperty.RefreshState();

        if (RunningProperty.TargetActor == null)
        {
            return BehaviourReturnCode.Failure;
        }

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionSummonMonsterSetAvailableSkill()
    {
        if (RunningProperty.TargetSkillId > 0)
        {
            return BehaviourReturnCode.Success;
        }

        List<Skill> skillList = RunningProperty.SelfActor.GetSkillList();
        List<uint> skillIds = new List<uint>();
        skillIds.Clear();
        foreach (Skill skill in skillList)
        {
            if (skill != null && skill.IsNextActionInCD() == false && RunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(skill, 0) == true)
            {
                skillIds.Add(skill.SkillID);
            }
        }
        DBSkillSelection dbSkillSelection = DBManager.GetInstance().GetDB<DBSkillSelection>();
        uint skillId = dbSkillSelection.SelectSkill(RunningProperty.SelfActor, skillIds);

        if (skillId == 0)
        {
            return BehaviourReturnCode.Failure;
        }

        RunningProperty.TargetSkillId = skillId;

        return BehaviourReturnCode.Success;
    }

    public BehaviourReturnCode ActionPetSetAvailableSkill()
    {
        if (RunningProperty.TargetSkillId > 0)
        {
            return BehaviourReturnCode.Success;
        }

        List<Skill> skillList = RunningProperty.SelfActor.GetSkillList();
        List<uint> skillIds = new List<uint>();
        skillIds.Clear();
        foreach (Skill skill in skillList)
        {
            if (skill != null && skill.IsNextActionInCD() == false && RunningProperty.SelfActor.AttackCtrl.IsSkillCanCast(skill, 0) == true)
            {
                skillIds.Add(skill.SkillID);
            }
        }
        DBSkillSelection dbSkillSelection = DBManager.GetInstance().GetDB<DBSkillSelection>();
        uint skillId = dbSkillSelection.SelectSkill(RunningProperty.SelfActor, skillIds);

        if (skillId == 0)
        {
            return BehaviourReturnCode.Failure;
        }

        RunningProperty.TargetSkillId = skillId;

        return BehaviourReturnCode.Success;
    }

    public bool ConditionIsNeedTeleportToPlayer(float time)
    {
        Monster monster = RunningProperty.SelfActor as Monster;

        if(InstanceManager.Instance.IsPlayerVSPlayerType)
        {
            return false;
        }

        if(monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_PLAYER || monster is Pet)
        {
            if(ConditionIsAwayMotionArea() == false)
            {
                return false;
            }

            if(RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.STAND)
            {
                if (RunningProperty.AI.Machine.CurrentState.StatingDuration >= time)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public override bool ConditionIsNeedPatrol()
    {
        if (RunningProperty.TargetActor == null)
        {
            return true;
        }

        Monster monster = RunningProperty.SelfActor as Monster;

        if (monster == null)
        {
            return false;
        }

        if(RunningProperty.AI.Machine.CurrentStateType == BehaviourMachine.State.ESCAPE)
        {
            return false;
        }

        if(monster.Camp == LocalPlayer.NowCamp)
        {
            return false;
        }

        if (ConditionTargetIsInAttackRange())
        {
            return false;
        }

        if (AIHelper.DistanceSquare(monster.CenterSpawnPos, RunningProperty.SelfActorPos) >= (monster.MaxChaseDistance * monster.MaxChaseDistance))
        {
            return true;
        }

        //目标对象是否超出最大追击距离
        if (AIHelper.DistanceSquare(monster.CenterSpawnPos, RunningProperty.TargetActorPos) >= (monster.MaxChaseDistance * monster.MaxChaseDistance))
        {
            return true;
        }

        return false;
    }

    public override bool ConditionIsNeedFollowPlayer()
    {
        Monster monster = RunningProperty.SelfActor as Monster;

        if (monster == null)
        {
            return false;
        }

        if (monster.Camp == LocalPlayer.NowCamp)
        {
            if(AIHelper.DistanceSquare(monster.CenterSpawnPos, RunningProperty.SelfActorPos) >= (monster.MotionRadius * monster.MotionRadius))
            {
                return true;
            }

            if(RunningProperty.TargetActor == null)
            {
                return true;
            }

            return false;
        }

        return base.ConditionIsNeedFollowPlayer();
    }

    /// <summary>
    /// 是否离开运动范围
    /// </summary>
    /// <returns></returns>
    public bool ConditionIsAwayMotionArea()
    {
        Monster monster = RunningProperty.SelfActor as Monster;

        if (monster == null)
        {
            return false;
        }

        if (InstanceManager.Instance.IsPlayerVSPlayerType)
        {
            return false;
        }

        if (AIHelper.DistanceSquare(monster.CenterSpawnPos, RunningProperty.SelfActorPos) >= (monster.MotionRadius * monster.MotionRadius))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 根据血量，判断是否到了需要逃跑的时候
    /// </summary>
    /// <param name="hpRatio"></param>
    /// <returns></returns>
    public bool ConditionIsNeedEscapeWithHpBeacon(float hpRatio)
    {
        float ratio = (float)((double)(RunningProperty.SelfActor.FullLife - RunningProperty.SelfActor.CurLife) / (double)RunningProperty.SelfActor.FullLife);

        int times = (int)(ratio / hpRatio);
        BehaviourMonsterAI monsterAI = RunningProperty.AI as BehaviourMonsterAI;

        if(monsterAI == null)
        {
            return false;
        }

        if(times > monsterAI.CurrentEscapeCount)
        {
            return true;
        }

        return false;
    }

    public bool ConditionIsEscaping()
    {
        if(RunningProperty.AI.Machine.CurrentStateType != BehaviourMachine.State.ESCAPE)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 父亲actor当前是否在攻击或受击
    /// </summary>
    /// <returns></returns>
    public bool ConditionParentActorIsAttackingOrBeAttacking()
    {
        if (RunningProperty.SelfActor == null || RunningProperty.SelfActor.ParentActor == null)
        {
            return false;
        }

        // 是否使用父亲的目标
        if (RunningProperty.IsAttackParentTarget == false)
        {
            return true;
        }
        else
        {
            return RunningProperty.SelfActor.ParentActor.IsAttacking() || RunningProperty.SelfActor.ParentActor.IsBeAttacking();
        }
    }
}

