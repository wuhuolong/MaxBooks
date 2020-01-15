using UnityEngine;
using xc;

public class AIRunningProperty
{
    private ActorMono mTargetActor;
    
    public Vector3 TargetActorPos;
    public float TargetActorColliderRadius;

    public uint TargetMonsterId { get; set; }

    private ActorMono mSelfActor;

    public Vector3 SelfActorPos;

    public Vector3 OriginalSelfActorPos;

    /// <summary>
    /// 要使用的目标技能
    /// </summary>
    public Skill TargetSkill
    {
        get
        {
            if (mSelfActor != null)
            {
                Actor actor = mSelfActor.BindActor;
                if (actor != null)
                {
                    //GameDebug.LogError("TargetSkill: " + mTargetSkillId);
                    Skill skill = actor.GetSelfSkill(mTargetSkillId);
                    if (skill != null)
                    {
                        return skill;
                    }
                    else
                    {
                        //GameDebug.LogError("Can not get target skill info by id " + mTargetSkillId);
                    }
                }
            }

            return null;
        }
    }

    public uint TargetSkillId
    {
        get
        {
            return mTargetSkillId;
        }
        set
        {
            mTargetSkillId = value;
            //if (mTargetSkillId == 0)
            //{
            //    GameDebug.LogError("TargetSkillId: " + mTargetSkillId);
            //}
        }
    }

    private uint mTargetSkillId;

    public float ViewRange;

    public string AIFile = "Empty file";

    public BehaviourAI AI;
    /// <summary>
    /// 当前需要Follow的Actor
    /// </summary>
    private ActorMono mFollowActor;

    /// <summary>
    /// 当前备选Follow的坐标,当FollowActor被销毁之后会跟随这个地方
    /// </summary>
    public Vector3 FollowBackupPosition = Vector3.zero;

    /// <summary>
    /// 跟随的队长是否进行了攻击动作
    /// </summary>
    public bool FollowActorIsAttacked = false;

    /// <summary>
    /// 当前的目标是否是反击的
    /// </summary>
    public bool TargetActorIsCounterattack = false;

    /// <summary>
    /// 当前是否在只触发一种技能模式
    /// </summary>
    public bool IsInFireOneSkillMode = false;

    /// <summary>
    /// 上一次攻击的技能ID
    /// </summary>
    public uint LastUseSkillId = 0;
    /// <summary>
    /// 上一次攻击的目标
    /// </summary>
    public ActorMono LastTargetActor = null;

    /// <summary>
    /// 活动半径，超过这个半径会先回到原点
    /// </summary>
    public float MotionRadius = GameConstHelper.GetFloat("GAME_AUTO_FIGHT_MOTION_RADIUS");

    /// <summary>
    /// 目标掉落的id
    /// </summary>
    public ulong TargetDropId { get; set; }

    /// <summary>
    /// 是否攻击父亲的目标，用于魔仆或者召唤物的ai，作用于ConditionParentActorIsAttackingOrBeAttacking和ActionPetSetTarget
    /// </summary>
    public bool IsAttackParentTarget = true;

    /// <summary>
    /// 目标采集物的id
    /// </summary>
    public int TargetCollectionId { get; set; }

    public void RefreshState()
    {
        if(SelfActor != null)
        {
            SelfActorPos = SelfActor.transform.position;
        }

        if(TargetActor != null)
        {
            TargetActorPos = TargetActor.transform.position;
        }
        else
        {
            TargetActorColliderRadius = -1.0f;
        }

        if(FollowActorIsAttacked == false)
        {
            if(mFollowActor != null && mFollowActor.BindActor != null)
            {
                FollowActorIsAttacked = mFollowActor.BindActor.IsAttacking();
            }
        }
    }

    public void Reset()
    {
        FollowActorIsAttacked = false;
        TargetActorIsCounterattack = false;
        mFollowActor = null;
        FollowBackupPosition = Vector3.zero;
        //TargetSkill = null;
        TargetSkillId = 0;
        TargetActor = null;
        TargetMonsterId = 0;
        TargetDropId = 0;
        TargetCollectionId = 0;
        OriginalSelfActorPos = SelfActor.transform.position;
    }

    /// <summary>
    /// 得到距离目标对象距离的平方
    /// </summary>
    /// <returns></returns>
    public float GetToTargetDistanceSquare()
    {
        return (TargetActorPos.x - SelfActorPos.x) * (TargetActorPos.x - SelfActorPos.x) + (TargetActorPos.y - SelfActorPos.y) * (TargetActorPos.y - SelfActorPos.y) + (TargetActorPos.z - SelfActorPos.z) * (TargetActorPos.z - SelfActorPos.z);
    }

    public float GetToTargetColliderDistance()
    {
        float distance = Mathf.Sqrt(GetToTargetDistanceSquare());

        return distance - TargetActorColliderRadius;
    }

    public float ToTargetDistanceSquare
    {
        get
        {
            return GetToTargetDistanceSquare();
        }
    }

    public float ToTargetDistance
    {
        get
        {
            return Mathf.Sqrt(GetToTargetDistanceSquare());
        }
    }

    public float TargetActorColliderRadiusSquare
    {
        get
        {
            if(TargetActorColliderRadius >= 0.0f)
            {
                return TargetActorColliderRadius * TargetActorColliderRadius;
            }

            return 0.0f;
        }
    }

    public Actor TargetActor
    {
        get
        {
            if(mTargetActor == null)
            {
                return null;
            }

            return mTargetActor.BindActor;
        }
        set
        {
            if(value == null)
            {
                TargetActorColliderRadius = -1.0f;
                mTargetActor = null;

                return;
            }

            if((mTargetActor == null || mTargetActor.BindActor != value) && value != null)
            {
                mTargetActor = value.GetActorMono();

                TargetActorColliderRadius = -1.0f;
            }
        }
    }

    public Actor SelfActor
    {
        get
        {
            if(mSelfActor == null)
            {
                return null;
            }

            return mSelfActor.BindActor;
        }
        set
        {
            if(value == null)
            {
                mSelfActor = null;
                return;
            }

            mSelfActor = value.GetActorMono();
        }
    }

    public Actor FollowActor
    {
        get
        {
            if (mFollowActor == null)
            {
                return null;
            }

            return mFollowActor.BindActor;
        }
        set
        {
            if (value == null)
            {
                mFollowActor = null;
                return;
            }

            mFollowActor = value.GetActorMono();
        }
    }
}