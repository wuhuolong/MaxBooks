using UnityEngine;
using Utils;
using System.Collections.Generic;
using xc;

public class BehaviourChaseTargetFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;
    private float mChaseRadius;
    private float mMonsterIndex;

    private float mInterval = 1.0f;
    private float mCurrentInterval = -1.0f;

    private Vector3 mLastPos;
    private float mSamePosTime;

    public BehaviourChaseTargetFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.CHASETARGET)
    {
        mRunningProperty = data;
    }

    public override void Update()
    {
        base.Update();

        if (mRunningProperty.TargetActor == null)
        {
            return;
        }

        Vector3 nowPos = mRunningProperty.SelfActorPos;

        if (AIHelper.RoughlyEqual(nowPos, mLastPos))
        {
            mSamePosTime += Time.deltaTime;

            if (mSamePosTime >= 0.1f)
            {
                mMonsterIndex = UnityEngine.Random.Range(0, 100);
                mSamePosTime = 0.0f;
            }
        }
        else
        {
            mSamePosTime = 0.0f;
        }

        mLastPos = nowPos;

        if (mCurrentInterval >= 0.0f && mCurrentInterval < mInterval /*&& mRunningProperty.AI.PathWalker.IsWorking*/)
        {
            mCurrentInterval += Time.deltaTime;
            return;
        }

        mCurrentInterval = 0.0f;

        Vector3 targetPos = mRunningProperty.TargetActorPos;

        float angle = 60.0f;
        targetPos.x = targetPos.x + mChaseRadius * Mathf.Cos(angle * mMonsterIndex);
        targetPos.z = targetPos.z + mChaseRadius * Mathf.Sin(angle * mMonsterIndex);

        // 奇怪的情况,这里的targetPos 有时候会各种Nan和Infinity
        if(!targetPos.Equals(targetPos))
        {
            targetPos = mRunningProperty.TargetActorPos;
        }

        if(float.IsInfinity(targetPos.x)|| float.IsInfinity(targetPos.z))
        {
            targetPos = mRunningProperty.TargetActorPos;
        }

        //float minDistance = mRunningProperty.AI.AIFunction.MinChaseDistance;
        //mChaseRadius = UnityEngine.Random.Range(minDistance, mRunningProperty.AI.AIFunction.MaxAttackDistance);
        mChaseRadius = mRunningProperty.AI.AIFunction.MaxAttackDistance;

        targetPos = InstanceHelper.ClampInWalkableRange(targetPos);

        if(AIHelper.RoughlyEqual(targetPos, mRunningProperty.SelfActorPos))
        {
            mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            return;
        }

        mRunningProperty.AI.PathWalker.RunTo(targetPos);
    }

    public override void Enter()
    {
        base.Enter();

        mCurrentInterval = -1.0f;
        mInterval = UnityEngine.Random.Range(0.5f, 0.51f);

        Dictionary<UnitID, Actor> partners = mRunningProperty.AI.GetPartners();
        mMonsterIndex = 0;

        foreach (var itr in partners)
        {
            xc.AI ai = itr.Value.GetAI();
            BehaviourAI behaviourAI = ai as BehaviourAI;

            if (behaviourAI == null)
            {
                continue;
            }

            if (behaviourAI.AIFunction.ConditionIsSeeTarget() == false)
            {
                continue;
            }

            if (itr.Value == mRunningProperty.SelfActor)
            {
                break;
            }

            ++mMonsterIndex;
        }

        if (mRunningProperty.TargetActor == null)
        {
            float minDistance = mRunningProperty.AI.AIFunction.MinChaseDistance;

            mChaseRadius = UnityEngine.Random.Range(minDistance, mRunningProperty.AI.AIFunction.MaxAttackDistance);

            return;
        }
        else
        {
            //float minDistance = mRunningProperty.AI.AIFunction.MinChaseDistance + mRunningProperty.TargetActor.MoveImplement.CharacterRadius + mRunningProperty.SelfActor.MoveImplement.CharacterRadius;
            float minDistance = mRunningProperty.AI.AIFunction.MinChaseDistance;

            mChaseRadius = UnityEngine.Random.Range(minDistance, mRunningProperty.AI.AIFunction.MaxAttackDistance);
        }
    }

    public override void Exit()
    {
        base.Exit();
        mRunningProperty.AI.PathWalker.Stop();
    }

    public float Radius
    {
        get
        {
            return mChaseRadius;
        }
    }

    public bool IsChasing
    {
        get
        {
            return mRunningProperty.SelfActor.IsWalking();
        }
    }
}