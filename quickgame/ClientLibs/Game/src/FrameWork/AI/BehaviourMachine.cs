using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class BehaviourMachine
{
    public enum State
    {
        EMPTY,
        WALK,
        RUN,
        STAND,
        ATTACK,
        CHASETARGET,
        PATROL,
        FOLLOW,
        ESCAPE
    }

    private BehaviourAI mAI;
    private SimpleFSMachine<State> mMachine = new SimpleFSMachine<State>();

    private BehaviourStandFiniteState mStandState;
    private BehaviourWalkFiniteState mWalkState;
    private BehaviourAttackFiniteState mAttackState;
    private BehaviourRunFiniteState mRunState;
    private BehaviourChaseTargetFiniteState mChaseTargetState;
    private BehaviourPatrolFiniteState mPatrolState;
    private BehaviourFollowFiniteState mFollowState;
    private BehaviourEscapeFiniteState mEscapeState;
    private BehaviourEmptyFiniteState mEmptyState;

    public BehaviourMachine(BehaviourAI ai)
    {
        mAI = ai;

        mStandState = new BehaviourStandFiniteState(ai.RunningProperty);
        mWalkState = new BehaviourWalkFiniteState(ai.RunningProperty);
        mAttackState = new BehaviourAttackFiniteState(ai.RunningProperty);
        mRunState = new BehaviourRunFiniteState(ai.RunningProperty);
        mChaseTargetState = new BehaviourChaseTargetFiniteState(ai.RunningProperty);
        mPatrolState = new BehaviourPatrolFiniteState(ai.RunningProperty);
        mFollowState = new BehaviourFollowFiniteState(ai.RunningProperty);
        mEmptyState = new BehaviourEmptyFiniteState(ai.RunningProperty);
        mEscapeState = new BehaviourEscapeFiniteState(ai.RunningProperty);

        mMachine.AddState(State.WALK, mWalkState);
        mMachine.AddState(State.RUN, mRunState);
        mMachine.AddState(State.STAND, mStandState);
        mMachine.AddState(State.ATTACK, mAttackState);
        mMachine.AddState(State.CHASETARGET, mChaseTargetState);
        mMachine.AddState(State.PATROL, mPatrolState);
        mMachine.AddState(State.FOLLOW, mFollowState);
        mMachine.AddState(State.EMPTY, mEmptyState);
        mMachine.AddState(State.ESCAPE, mEscapeState);
    }

    public void Update()
    {
        mMachine.Update();
    }

    public void SwitchToState(State type)
    {
        if (mMachine.GetCurrentStateId() == type)
        {
            return;
        }

        mMachine.SwitchToState(type);
    }

    public T GetCurrentState<T>() where T:SimpleFiniteState<State>
    {
        return (T)CurrentState;
    }

    public T GetState<T>(State type) where T : SimpleFiniteState<State>
    {
        return (T)mMachine.GetState(type);
    }

    public bool IsStanding
    {
        get
        {
            if(CurrentStateType == State.STAND)
            {
                return true;
            }

            return false;
        }
    }

    public bool IsWalking
    {
        get
        {
            if (CurrentStateType == State.WALK)
            {
                return true;
            }

            return false;
        }
    }

    public bool IsRunning
    {
        get
        {
            if (CurrentStateType == State.RUN)
            {
                return true;
            }

            return false;
        }
    }

    public bool IsAttacking
    {
        get
        {
            if (CurrentStateType == State.ATTACK)
            {
                return true;
            }

            return false;
        }
    }

    public State CurrentStateType
    {
        get
        {
            return mMachine.GetCurrentStateId();
        }
    }

    public SimpleFiniteState<State> CurrentState
    {
        get
        {
            return mMachine.GetCurrentState();
        }
    }

    public SimpleFSMachine<State> FSMachine
    {
        get
        {
            return mMachine;
        }
    }
}