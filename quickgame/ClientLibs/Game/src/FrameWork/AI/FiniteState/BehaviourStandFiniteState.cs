using UnityEngine;
using Utils;

public class BehaviourStandFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;

    public BehaviourStandFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.STAND)
    {
        mRunningProperty = data;
    }
    public override void Update()
    {
        base.Update();
    }

    public override void Enter()
    {
        if(mRunningProperty.SelfActor.IsIdle() == false)
        {
            mRunningProperty.SelfActor.Stand();
        }
        
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}