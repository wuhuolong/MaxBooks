using UnityEngine;
using Utils;

public class BehaviourAttackFiniteState : SimpleFiniteState<BehaviourMachine.State>
{
    private AIRunningProperty mRunningProperty;

    private const float mNormalAttackInterval = 0.1f;
    private const int mMaxComboAttackCount = 4;

    private int mCurrentComboAttackCount = 0;
    private float mCurrentDeltaTime = 0.0f;

    private float mCurrentMovingDeltaTime = 0.0f;
    private const float mMovingInterval = 1.0f;

    private uint mTargetSkillId = 0;

    public BehaviourAttackFiniteState(AIRunningProperty data)
        : base(BehaviourMachine.State.ATTACK)
    {
        mRunningProperty = data;
    }

    public override void Update()
    {
        base.Update();

        bool attackResult = true;

        if (mTargetSkillId != mRunningProperty.TargetSkillId)
        {
            attackResult = mRunningProperty.AI.DoAttack();
            mTargetSkillId = mRunningProperty.TargetSkillId;
        }

        if (TargetSkill != null && TargetSkill.IsMultiAction())
        {
            mCurrentDeltaTime += Time.deltaTime;

            xc.SkillAction skillAction = TargetSkill.CurAction;
            if ((TargetSkill != null && TargetSkill.IsCanCacheNext() == true))
            {
                mCurrentDeltaTime = 0.0f;

                //GameDebug.LogError("Update: " + TargetSkill.SkillID);
                attackResult = mRunningProperty.AI.DoAttack();

                ++mCurrentComboAttackCount;
            }

            if (TargetSkill != null)
            {
                if (mCurrentComboAttackCount >= TargetSkill.GetSkillActionCount())
                {
                    if (mRunningProperty.SelfActor.IsAttacking() == false && mRunningProperty.SelfActor.IsWalking() == false)
                    {
                        mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
                    }
                    if (TargetSkill != null && TargetSkill.IsCanCacheNext() == true)
                    {
                        mRunningProperty.TargetSkillId = 0;
                        mTargetSkillId = 0;
                        //mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
                    }

                    mCurrentComboAttackCount = 0;
                }
            }
        }

        if (mRunningProperty.SelfActor.IsAttacking() == false && mRunningProperty.SelfActor.IsWalking() == false)
        {
            mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
        }
        if (TargetSkill != null && TargetSkill.IsInBeforeSkillActionEndingStage() == false)
        {
            mRunningProperty.TargetSkillId = 0;
            mTargetSkillId = 0;
            //mRunningProperty.AI.Machine.SwitchToState(BehaviourMachine.State.EMPTY);
        }

        if (attackResult == false)
        {
        }

        //GameDebug.LogError("Update: " + mRunningProperty.TargetSkillId);
    }

    public override void Enter()
    {
        base.Enter();

        mCurrentComboAttackCount = 0;
        mCurrentDeltaTime = 0.0f;
        mCurrentMovingDeltaTime = 0.0f;

        if (mRunningProperty.TargetSkill == null)
        {
            return;
        }

        if (mRunningProperty.TargetActor == null)
        {
            return;
        }

        // 因为服务端的怪物的信息过来可能会延迟，导致找寻敌人的时候这个判断成立，攻击的时候却不成立了,表现就是AI呆住不动，于是在这里不判断了

//         if (mRunningProperty.TargetActor.IsDead())
//         {
//             return;
//         }

        if (mRunningProperty.SelfActor.IsAttacking())
        {
            return;
        }

        mTargetSkillId = mRunningProperty.TargetSkillId;

        bool result = mRunningProperty.AI.DoAttack();

        if (result)
        {
            if(mRunningProperty.TargetSkill.IsMultiAction())
            {
                ++mCurrentComboAttackCount;
            }
        }

        //GameDebug.LogError("Enter: " + mRunningProperty.TargetSkillId);
    }

    public override void Exit()
    {
        base.Exit();
        //mRunningProperty.TargetSkill = null; 
        mRunningProperty.TargetSkillId = 0;
        mCurrentComboAttackCount = 0;
        mCurrentDeltaTime = 0.0f;
        mCurrentMovingDeltaTime = 0.0f;

        //GameDebug.LogError("Exit: " + mRunningProperty.TargetSkillId);
    }

    xc.Skill TargetSkill
    {
        get
        {
            if (mRunningProperty.SelfActor != null)
            {
                return mRunningProperty.SelfActor.GetSelfSkill(mTargetSkillId);
            }

            return null;
        }
    }

    public int CurrentComboAttackCount
    {
        get
        {
            return mCurrentComboAttackCount;
        }
    }
}