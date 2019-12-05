using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc;

public class BehaviourNpcAI : BehaviourAI
{
    private string mNpcAiFile;
    private AINpcFunction mNpcFunction;

    public BehaviourNpcAI(NpcPlayer npcPlayer, string aiFile)
        : base(npcPlayer)
    {
        mNpcAiFile = aiFile;
    }

    protected override string GetBehaivorTreeFile()
    {
        return mNpcAiFile;
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

    protected override void InitAIFunction()
    {
        mNpcFunction = new AINpcFunction();
        mFunction = mNpcFunction;
    }

    public override Actor GetDefaultTargetActor()
    {
        Actor targetActor = null;

        float shortest = float.MaxValue;
        float viewRange = mRunningProperty.ViewRange * mRunningProperty.ViewRange;

        NpcPlayer npc = mRunningProperty.SelfActor as NpcPlayer;

        if(npc == null)
        {
            return null;
        }

        if (npc.NpcData.Relationship == Neptune.Relationship.FRIENDLY)
        {
            Dictionary<UnitID, Actor> monsters = ActorManager.Instance.MonsterSet;

            // 计算出最短距离

            foreach (var item in monsters)
            {
                if (item.Value.IsDead() || (item.Value.gameObject.activeSelf == false))
                {
                    continue;
                }

                if (item.Value.IsActorInvisiable)
                {
                    continue;
                }

                float distanceSquare = AIHelper.DistanceSquare(mRunningProperty.SelfActorPos, item.Value.transform.position);
                if (distanceSquare < shortest)
                {
                    shortest = distanceSquare;
                    targetActor = item.Value;
                }
            }

            if (shortest > viewRange)
            {
                targetActor = null;
            }

            return targetActor;
        }
        else if(npc.NpcData.Relationship == Neptune.Relationship.NEUTRAL)
        {
            return null;
        }
        else if(npc.NpcData.Relationship == Neptune.Relationship.HOSTILE)
        {
            foreach (var item in ActorManager.Instance.PlayerSet)
            {
                if (item.Value.IsDead() || (item.Value.gameObject.activeSelf == false))
                {
                    continue;
                }

                if (item.Value.IsActorInvisiable)
                {
                    continue;
                }

                float distanceSquare = AIHelper.DistanceSquare(mRunningProperty.SelfActorPos, item.Value.transform.position);
                if (distanceSquare < shortest)
                {
                    shortest = distanceSquare;
                    targetActor = item.Value;
                }
            }

            if (shortest > viewRange)
            {
                targetActor = null;
            }

            return targetActor;
        }

        return base.GetDefaultTargetActor();
    }

    protected override bool RunConditionImplement(string condition, object[] parameters)
    {
        if(condition == "ConditionIsSeeLocalPlayer")
        {
            return mNpcFunction.ConditionIsSeeLocalPlayer();
        }

        return base.RunConditionImplement(condition, parameters);
    }
}