using UnityEngine;
using Utils;

public class BehaviourEmptyFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;

    public BehaviourEmptyFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.EMPTY)
    {
        mRunningProperty = data;
    }
    public override void Update()
    {
        base.Update();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
}