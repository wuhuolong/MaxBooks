using UnityEngine;
using Utils;

public class BehaviourEscapeFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;
    private Vector3 mTargetPos;
    private const uint mEscapeRadius = 20;

    private Vector3 mLastPos;
    private float mSamePosTime;

    public uint EnterBuffId = 0;

    public BehaviourEscapeFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.ESCAPE)
    {
        mRunningProperty = data;
    }
    public override void Update()
    {
        base.Update();

        //如果逃跑了五秒钟
        if(StatingDuration >= 8.0f)
        {
            mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
            return;
        }

        // 如果逃跑卡住在某个位置
        Vector3 nowPos = mRunningProperty.SelfActorPos;

        if (AIHelper.RoughlyEqual(nowPos, mLastPos))
        {
            mSamePosTime += Time.deltaTime;

            if (mSamePosTime >= 0.1f)
            {
                float angle = UnityEngine.Random.Range(0.0f, 360.0f);

                Vector3 newPos = mTargetPos;
                newPos.x = mTargetPos.x + mEscapeRadius * Mathf.Cos(angle);
                newPos.z = mTargetPos.z + mEscapeRadius * Mathf.Sin(angle);

                bool clampResult = false;
                newPos = InstanceHelper.ClampInWalkableRange(newPos, mTargetPos, out clampResult);

                if(clampResult)
                {
                    mTargetPos = newPos;

                    mRunningProperty.AI.PathWalker.RunTo(mTargetPos);
                    //mRunningProperty.SelfActor.MoveCtrl.TryRunTo(mTargetPos);
                }

                mSamePosTime = 0.0f;
            }
        }
        else
        {
            mSamePosTime = 0.0f;
        }

        mLastPos = nowPos;

        // 逃跑完成
        if (AIHelper.RoughlyEqual(mRunningProperty.SelfActorPos, mTargetPos))
        {
            mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
        }
    }

    public override void Enter()
    {
        Vector3 currentPos = mRunningProperty.SelfActorPos;

        float angle = UnityEngine.Random.Range(0.0f, 360.0f);
        mTargetPos.x = currentPos.x + mEscapeRadius * Mathf.Cos(angle);
        mTargetPos.z = currentPos.z + mEscapeRadius * Mathf.Sin(angle);

        mTargetPos = InstanceHelper.ClampInWalkableRange(mTargetPos, currentPos);

        mRunningProperty.AI.PathWalker.RunTo(mTargetPos);
        //mRunningProperty.SelfActor.MoveCtrl.TryRunTo(mTargetPos);

        if(EnterBuffId > 0)
        {
            //mRunningProperty.SelfActor.BuffCtrl.AddCustomBuff(EnterBuffId);
        }

        base.Enter();
    }

    public override void Exit()
    {
        if(EnterBuffId > 0)
        {
            mRunningProperty.SelfActor.BuffCtrl.DelBuff(EnterBuffId);
        }

        base.Exit();
    }
}
