using UnityEngine;
using Utils;
using System.Collections.Generic;
using xc;

public class BehaviourFollowFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;
    private float mFollowRadius;
    private float mPartnerIndex;

    private float mInterval = 1.0f;
    private float mCurrentInterval = -1.0f;

    public BehaviourFollowFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.FOLLOW)
    {
        mRunningProperty = data;
    }

    public override void Update()
    {
        base.Update();

        if (mRunningProperty == null || mRunningProperty.SelfActor == null)
        {
            return;
        }

        Actor followActor = mRunningProperty.FollowActor;
        
        Vector3 targetPos = Vector3.zero;

        if (followActor == null && AIHelper.RoughlyEqual(mRunningProperty.FollowBackupPosition, Vector3.zero))
        {
            return;
        }

        if (followActor == mRunningProperty.SelfActor)
        {
            return;
        }

        if (followActor != null)
        {
            mRunningProperty.FollowBackupPosition = Vector3.zero;
            targetPos = followActor.transform.position;
        }
        else
        {
            targetPos = mRunningProperty.FollowBackupPosition;
        }

        float angle = 60.0f;
        targetPos.x = targetPos.x + mFollowRadius * Mathf.Cos(angle * mPartnerIndex);
        targetPos.z = targetPos.z + mFollowRadius * Mathf.Sin(angle * mPartnerIndex);

        //targetPos = InstanceHelper.ClampInWalkableRange(targetPos);

        if (AIHelper.RoughlyEqual(targetPos, mRunningProperty.SelfActorPos))
        {
            return;
        }
        /*
        else
        {
            // 对于当前闲置但是却还没达到目标的情况，需要立即追踪
            if (mRunningProperty.AI.PathWalker.IsCloseToTarget && targetPos != mRunningProperty.AI.PathWalker.CurrentTargetPos)
            {
                //mCurrentInterval = mCurrentInterval * 2.0f;
                if (mCurrentInterval < mInterval)
                {
                    float newInterval = mInterval * 0.9f;

                    if (mCurrentInterval < newInterval)
                    {
                        mCurrentInterval = newInterval;
                    }
                }
            }

            if (mRunningProperty.AI.PathWalker.IsWorking == false)
            {
                if (mCurrentInterval < mInterval)
                {
                    float newInterval = mInterval * 0.9f;

                    if (mCurrentInterval < newInterval)
                    {
                        mCurrentInterval = newInterval;
                    }
                }

            }
        }*/

        if (mCurrentInterval >= 0.0f && mCurrentInterval < mInterval)
        {
            mCurrentInterval += Time.deltaTime;
            return;
        }

        mCurrentInterval = 0.0f;

        targetPos = InstanceHelper.ClampInWalkableRange(targetPos);

        //         if(mRunningProperty.SelfActor is Pet)
        //         {
        //             mRunningProperty.SelfActor.MoveCtrl.TryRunTo(targetPos);
        // 
        //             return;
        //         }

        mRunningProperty.AI.PathWalker.RunTo(targetPos);
    }

    public override void Enter()
    {
        base.Enter();

        mCurrentInterval = -1.0f;
        mInterval = UnityEngine.Random.Range(0.5f, 0.6f);

        mPartnerIndex = UnityEngine.Random.Range(0, 100);

        //       Dictionary<UnitID, Actor> partners = mRunningProperty.AI.GetPartners();
        //mPartnerIndex = 0;

//         foreach (var itr in partners)
//         {
//             XC.AI ai = itr.Value.GetAI();
//             BehaviourAI behaviourAI = ai as BehaviourAI;
// 
//             if (behaviourAI == null)
//             {
//                 continue;
//             }
// 
//             if (behaviourAI.AIFunction.ConditionIsSeeTarget() == false)
//             {
//                 continue;
//             }
// 
//             if (itr.Value == mRunningProperty.SelfActor)
//             {
//                 break;
//             }
// 
//             ++mPartnerIndex;
//         }

        mFollowRadius = 1.5f;
    }

    public override void Exit()
    {
        base.Exit();

        if(mRunningProperty != null && mRunningProperty.SelfActor != null)
        {
            mRunningProperty.AI.PathWalker.Stop();
        }
    }

    public float Radius
    {
        get
        {
            return mFollowRadius;
        }
    }

    public bool IsFollowing
    {
        get
        {
            return mRunningProperty.SelfActor.IsWalking();
        }
    }
}