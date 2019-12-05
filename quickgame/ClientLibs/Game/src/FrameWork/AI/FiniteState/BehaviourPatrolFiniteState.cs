using UnityEngine;
using Utils;
using System.Collections.Generic;

public class BehaviourPatrolFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;

    // 预先设置好的中心坐标
    public Vector3 PresetCenterPos = Vector3.zero;
    public Vector3 CenterPos = Vector3.zero;
    private float mMotionRadius;

    private Vector3 mLastPos;
    private float mSamePosTime;

    public BehaviourPatrolFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.PATROL)
    {
        mRunningProperty = data;
    }

    public override void Enter()
    {
        base.Enter();

        Monster monster = mRunningProperty.SelfActor as Monster;

        if(monster != null)
        {
            if (AIHelper.RoughlyEqual(PresetCenterPos, Vector3.zero) == false)
            {
                CenterPos = PresetCenterPos;
            }
            else
            {
                CenterPos = monster.CenterSpawnPos;
            }

            mMotionRadius = monster.MotionRadius;

            return;
        }

        if (AIHelper.RoughlyEqual(PresetCenterPos, Vector3.zero) == false)
        {
            CenterPos = PresetCenterPos;
        }
        else
        {
            CenterPos = mRunningProperty.SelfActorPos;
        }

        mMotionRadius = mRunningProperty.MotionRadius;
    }

    public override void Exit()
    {
        mRunningProperty.SelfActor.Stop();
        PresetCenterPos = Vector3.zero;
        CenterPos = Vector3.zero;

        base.Exit();
    }

    public override void Update()
    {
        if (mRunningProperty.SelfActor.IsAttacking())
        {
            return;
        }

        Vector3 nowPos = mRunningProperty.SelfActorPos;

        if (AIHelper.RoughlyEqual(nowPos, mLastPos))
        {
            mSamePosTime += Time.deltaTime;

            if (mSamePosTime >= 0.1f)
            {
                mRunningProperty.SelfActor.Stop();
                mSamePosTime = 0.0f;
            }
        }
        else
        {
            mSamePosTime = 0.0f;
        }

        mLastPos = nowPos;

        if (mRunningProperty.SelfActor.IsWalking())
        {
            return;
        }

        Vector3 targetPos = CenterPos;

        // 找最近的可以寻路的触发器
        Vector3 nearestNeedNavigateColliderPosition = AIHelper.GetNearestNeedNavigateColliderPosition(mRunningProperty);
        if (AIHelper.RoughlyEqual(nearestNeedNavigateColliderPosition, Vector3.zero) == true)
        {
            float angle = UnityEngine.Random.Range(0, 360);
            float radius = UnityEngine.Random.Range(0.0f, mMotionRadius);

            targetPos.x = targetPos.x + radius * Mathf.Cos(angle);
            targetPos.z = targetPos.z + radius * Mathf.Sin(angle);
        }
        else
        {
            targetPos = nearestNeedNavigateColliderPosition;
        }

        Vector3 trueTargetPos = InstanceHelper.ClampInWalkableRange(targetPos);

        if (AIHelper.RoughlyEqual(mLastPos, trueTargetPos) == false)
        {
            mRunningProperty.AI.PathWalker.WalkTo(trueTargetPos);
        }

        base.Update();
    }
}