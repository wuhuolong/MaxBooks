using UnityEngine;
using Utils;
using xc;

public class BehaviourWalkFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;

    private Vector3 mLastPos;
    private float mSamePosTime;

    public BehaviourWalkFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.WALK)
    {
        mRunningProperty = data;
    }

    public override void Update()
    {
        base.Update();

        Vector3 nowPos = mRunningProperty.SelfActorPos;

        if (AIHelper.RoughlyEqual(nowPos, mLastPos))
        {
            mSamePosTime += Time.deltaTime;

            if (mSamePosTime >= 0.1f)
            {
                if (/*(InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_WILD || InstanceManager.Instance.InstanceType == GameConst.WAR_TYPE_HOLE) && */
                    mRunningProperty.SelfActor is LocalPlayer)
                {
                    mRunningProperty.AI.PathWalker.Renavigate();
                }

                    if (mRunningProperty.SelfActor.IsIdle() == false)
                {
//                     mRunningProperty.SelfActor.Stop();
//                     bool test = mRunningProperty.SelfActor.IsIdle();
// 

                }

                //mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            }
        }
        else
        {
            mSamePosTime = 0.0f;
        }

        if (mRunningProperty.AI.PathWalker.IsCloseToTarget)
        {
            mRunningProperty.AI.PathWalker.IsWalkingToOriginalPos = false;
            mRunningProperty.AI.PathWalker.IsWalkingToDropPos = false;
            mRunningProperty.AI.PathWalker.IsWalkingToCollectionPos = false;
            mRunningProperty.TargetDropId = 0;
            mRunningProperty.TargetCollectionId = 0;
            mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
        }

        mLastPos = nowPos;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        //mRunningProperty.SelfActor.Stand();
        base.Exit();
    }
}