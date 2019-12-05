using UnityEngine;
using Utils;

public class BehaviourRunFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    public string LastRunAction;
    public Vector3 LastTargetPos;
    public bool IsFlocking = false;

    private AIRunningProperty mRunningProperty;
    private Vector3 mLastPos;
    private float mSamePosTime;

    public BehaviourRunFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.RUN)
    {
        mRunningProperty = data;
        mLastPos = mRunningProperty.SelfActorPos;
    }

    public override void Update()
    {
        base.Update();

        Vector3 nowPos = mRunningProperty.SelfActorPos;

        if(nowPos.Equals(mLastPos))
        {
            mSamePosTime += Time.deltaTime;

            if(mSamePosTime >= 0.5f)
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
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        //mRunningProperty.SelfActor.Stop();
        IsFlocking = false;
        LastRunAction = string.Empty;

        base.Exit();
    }
}