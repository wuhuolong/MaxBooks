using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc;

public class BehaviourMonsterAI : BehaviourAI
{
    protected AIMonsterFunction mMonsterFunction;

    public int CurrentEscapeCount = 0;
    public float EscapeHpRationBeacon = 0.2f;

    public BehaviourMonsterAI(Monster monster)
        : base(monster)
    {

    }
    protected override float GetActorViewRange()
    {
        if (mRunningProperty.SelfActor == null)
        {
            return 50.0f;
        }

        //return mRunningProperty.SelfActor.ActorAttribute.EyesightRange;
        return 50f;
    }

    protected override string GetBehaivorTreeFile()
    {
        Monster monster = mRunningProperty.SelfActor as Monster;

        if(monster == null)
        {
            return string.Empty;
        }

        if (monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_PLAYER)
        {
            return monster.ActorAttribute.SummonBehaviourTree;
        }
        else if (monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_ROBOT)
        {
            return monster.ActorAttribute.SummonBehaviourTree;
        }

        if (monster is Pet)
        {
            return monster.ActorAttribute.SummonBehaviourTree;
        }

        return monster.ActorAttribute.BehaviourTree;
    }

    protected override void InitAIFunction()
    {
        mMonsterFunction = new AIMonsterFunction();
        mFunction = mMonsterFunction;
    }

    public override Dictionary<UnitID, Actor> GetPartners()
    {
        Monster monster = mRunningProperty.SelfActor as Monster;

        if (monster != null)
        {
            if (monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_MONSTER || monster is Pet)
            {
                return ActorManager.Instance.CalledMonsterSet;
            }
        }

        return ActorManager.Instance.MonsterSet;
    }

    public override Actor GetDefaultTargetActor()
    {
        Monster monster = mRunningProperty.SelfActor as Monster;

        if (monster == null)
        {
            return null;
        }

        //if (monster is Pet)
        //{
        //    if (!SceneHelp.Instance.IsInSingleInstance())
        //    {
        //        return null;
        //    }
        //}

        Actor targetActor = null;
        float shortest = float.MaxValue;
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();

        // 有没有强制目标
        //Spartan.MonsterGroupInfo monsterGroupInfo = monster.SpartanMonsterGroupInfo;

        //if(monsterGroupInfo != null)
        //{
        //    targetActor = NpcManager.Instance.GetNpcByNpcId((uint)monsterGroupInfo.TargetNpcId);

        //    if(targetActor != null && !targetActor.IsActorInvisiable)
        //    {
        //        return targetActor;
        //    }
        //}

        float viewRange = mRunningProperty.ViewRange * mRunningProperty.ViewRange;

        if (InstanceManager.Instance.IsPlayerVSPlayerType)
        {
            if (mRunningProperty.SelfActor.ParentActor == null)
            {
                return null;
            }

            foreach (var item in ActorManager.Instance.PlayerSet)
            {
                Actor oppositeActor = null;

                if (item.Value.UID != mRunningProperty.SelfActor.ParentActor.UID)
                {
                    oppositeActor = item.Value;
                    float distanceSquare = AIHelper.DistanceSquare(mRunningProperty.SelfActorPos, item.Value.transform.position);
                    shortest = distanceSquare;

                    foreach (var son in oppositeActor.SonActors)
                    {
                        if(son == null || son.IsDead() || son.IsActorInvisiable)
                        {
                            continue;
                        }

                        distanceSquare = AIHelper.DistanceSquare(mRunningProperty.SelfActorPos, son.transform.position);

                        if (distanceSquare < shortest)
                        {
                            shortest = distanceSquare;
                            oppositeActor = son;
                        }
                    }

                    return oppositeActor;
                }
            }
        }
        //else if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_ARENA)
        //{
        //    if (mRunningProperty.SelfActor.ParentActor == null)
        //    {
        //        return null;
        //    }
            
        //    foreach (var item in ActorManager.Instance.ActorSet)
        //    {
        //        if(item.Value.IsActorInvisiable)
        //        {
        //            continue;
        //        }

        //        if (item.Value.UID != mRunningProperty.SelfActor.ParentActor.UID)
        //        {
        //            return item.Value;
        //        }
        //    }
        //}

        // 是玩家队友
        if(localPlayer != null && monster.Camp == localPlayer.Camp)
        {
            Dictionary<UnitID, Actor> monsters = ActorManager.Instance.MonsterSet;

            // 计算出最短距离
            foreach (var item in monsters)
            {
                if(item.Value == null)
                {
                    continue;
                }

                if(item.Value.IsDead() || (item.Value.gameObject.activeSelf == false))
                {
                    continue;
                }

                if(item.Value == mRunningProperty.SelfActor.ParentActor || item.Value.IsActorInvisiable)
                {
                    continue;
                }

                if (item.Value == mRunningProperty.SelfActor)
                {
                    continue;
                }

                if(item.Value.Camp == monster.Camp)
                {
                    continue;
                }

                if(mRunningProperty.SelfActor.ParentActor != null)
                {
                    if(item.Value.ParentActor == mRunningProperty.SelfActor.ParentActor)
                    {
                        continue;
                    }
                }

                float distanceSquare = AIHelper.DistanceSquare(mRunningProperty.SelfActorPos, item.Value.transform.position);
                if (distanceSquare < shortest)
                {
                    shortest = distanceSquare;
                    targetActor = item.Value;
                }
            }

            if (InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD)
            {
                if (localPlayer != null && localPlayer.WildState == Actor.EWildState.Kill)
                {
                    Dictionary<UnitID, Actor> players = ActorManager.Instance.PlayerSet;

                    // Linq
                    //monsters = monsters.Concat(players).ToDictionary(k => k.Key, v => v.Value);

                    // 计算出最短距离
                    foreach (var item in players)
                    {
                        if (item.Value == null)
                        {
                            continue;
                        }

                        if (item.Value.IsDead() || (item.Value.gameObject.activeSelf == false))
                        {
                            continue;
                        }

                        if (item.Value == mRunningProperty.SelfActor.ParentActor || item.Value.IsActorInvisiable)
                        {
                            continue;
                        }

                        if(mRunningProperty.SelfActor.ParentActor != null)
                        {
                            if(!mRunningProperty.SelfActor.ParentActor.CheckCanAttackOtherPlayer(item.Value))
                            {
                                continue;
                            }
                        }

                        float distanceSquare = AIHelper.DistanceSquare(mRunningProperty.SelfActorPos, item.Value.transform.position);
                        if (distanceSquare < shortest)
                        {
                            shortest = distanceSquare;
                            targetActor = item.Value;
                        }
                    }
                }

                if (shortest > viewRange)
                {
                    targetActor = null;
                }
            }

            return targetActor;
        }
        
        // 先检测当前目标有没有脱离视野范围
        if(mRunningProperty.TargetActor != null && !mRunningProperty.TargetActor.IsActorInvisiable)
        {
            float distance = AIHelper.DistanceSquare(mRunningProperty.TargetActor.transform.position, mRunningProperty.SelfActorPos);

            if(distance <= viewRange && !mRunningProperty.TargetActor.IsActorInvisiable)
            {
                return mRunningProperty.TargetActor;
            }
        }

        targetActor = Game.GetInstance().GetLocalPlayer();

        if(targetActor != null)
        {
            shortest = AIHelper.DistanceSquare(targetActor.transform.position, mRunningProperty.SelfActorPos);
        }
        else
        {
            shortest = float.MaxValue;
        }

        // 检测召唤出来的怪物
        Dictionary<UnitID, Actor> summonMonsters = ActorManager.Instance.SummonMonsterSet;

        foreach (var item in summonMonsters)
        {
            Monster monster2 = item.Value as Monster;

            if(monster2 == null)
            {
                continue;
            }

            if(monster2.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_MONSTER)
            {
                continue;
            }

            if(monster2.IsActorInvisiable)
            {
                continue;
            }

            float distance = AIHelper.DistanceSquare(item.Value.transform.position, mRunningProperty.SelfActorPos);

            if (distance > viewRange || distance > shortest)
            {
                continue;
            }

            shortest = distance;
            targetActor = item.Value;
        }

        // 检测场景内的NPC
        var allNpc = NpcManager.Instance.AllNpc;

        foreach (var item in allNpc)
        {
            NpcPlayer npc = item.Value.BindActor as NpcPlayer;
            if(npc.NpcData.Relationship != Neptune.Relationship.FRIENDLY)
            {
                continue;
            }

            float distance = AIHelper.DistanceSquare(npc.transform.position, mRunningProperty.SelfActorPos);

            if (distance > viewRange || distance > shortest)
            {
                continue;
            }

            if (npc.IsActorInvisiable)
            {
                continue;
            }

            shortest = distance;
            targetActor = npc;
        }

        if (shortest > viewRange)
        {
            targetActor = null;
        }

        return targetActor;
    }

    protected override BehaviourTree.BehaviourReturnCode RunActionImplement(string action, object[] parameters)
    {
        if (action == "ActionTeleportToPlayer")
        {
            return mMonsterFunction.ActionTeleportToPlayer();
        }
        else if(action == "ActionSetPresetNpcActorToTarget")
        {
            return mMonsterFunction.ActionSetPresetNpcActorToTarget();
        }
        else if(action == "ActionEscape")
        {
            int buffId = 0;

            if(parameters.Length >= 1)
            {
                buffId = (int)parameters[0];
            }

            return mMonsterFunction.ActionEscape((uint)buffId);
        }
        else if (action == "ActionSummonMonsterSetTarget")
        {
            return mMonsterFunction.ActionSummonMonsterSetTarget();
        }
        else if (action == "ActionSummonMonsterNotFollowSetTarget")
        {
            return mMonsterFunction.ActionSummonMonsterNotFollowSetTarget();
        }
        else if (action == "ActionPetSetTarget")
        {
            return mMonsterFunction.ActionPetSetTarget();
        }
        else if (action == "ActionSummonMonsterSetAvailableSkill")
        {
            return mMonsterFunction.ActionSummonMonsterSetAvailableSkill();
        }
        else if (action == "ActionPetSetAvailableSkill")
        {
            return mMonsterFunction.ActionPetSetAvailableSkill();
        }

        return base.RunActionImplement(action, parameters);
    }

    protected override bool RunConditionImplement(string condition, object[] parameters)
    {
        if (condition == "ConditionIsNeedTeleportToPlayer")
        {
            float time = 4.0f;
            if(parameters.Length >= 1)
            {
                time = (float)parameters[0];
            }

            return mMonsterFunction.ConditionIsNeedTeleportToPlayer(time);
        }
        else if (condition == "ConditionIsAwayMotionArea")
        {
            return mMonsterFunction.ConditionIsAwayMotionArea();
        }
        else if(condition == "ConditionIsNeedEscapeWithHpBeacon")
        {
            float ratio = 0.2f;

            if (parameters.Length >= 1)
            {
                ratio = (float)parameters[0];
            }

            EscapeHpRationBeacon = ratio;
            return mMonsterFunction.ConditionIsNeedEscapeWithHpBeacon(ratio);
        }
        else if(condition == "ConditionIsEscaping")
        {
            return mMonsterFunction.ConditionIsEscaping();
        }
        else if (condition == "ConditionParentActorIsAttackingOrBeAttacking")
        {
            return mMonsterFunction.ConditionParentActorIsAttackingOrBeAttacking();
        }

        return base.RunConditionImplement(condition, parameters);
    }
}