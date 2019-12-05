//#define DEBUG_ROUTER_NODE

using System;
using System.Collections.Generic;
using UnityEngine;
using xc;

public class AIActorPathWalker
{
    public enum WalkType : byte
    {
        WALK,
        RUN
    }

    /// <summary>
    /// 控制的Actor
    /// </summary>
    private WeakReference mTargetActor;
    private WalkType mWalkType = WalkType.WALK;
    private Vector3 mTargetPos = Vector3.zero;

    public bool IsWalkingToOriginalPos { get; set; }

    public bool IsWalkingToDropPos { get; set; }

    public bool IsWalkingToCollectionPos { get; set; }

    public AIActorPathWalker(Actor targetActor)
    {
        mTargetActor = new WeakReference(targetActor.GetActorMono());
        targetActor.SubscribeActorEvent(Actor.ActorEvent.REACH_TARGET, OnWalkEndCallback);

        IsWalkingToOriginalPos = false;
        IsWalkingToDropPos = false;
        IsWalkingToCollectionPos = false;
    }

    public void Update()
    {

    }

    public void Reset()
    {
        mWalkType = WalkType.WALK;
        mTargetPos = Vector3.zero;
        IsWalkingToOriginalPos = false;
        IsWalkingToDropPos = false;
        IsWalkingToCollectionPos = false;
    }

    public void Stop()
    {
        if (TargetActor == null || TargetActor.MoveCtrl == null)
        {
            return;
        }

        TargetActor.MoveCtrl.TryWalkAlongStop();
    }

    int m_WalkId = 0;
    public int WalkId
    {
        set { m_WalkId = value; }
    }

    private void OnWalkEndCallback(CEventBaseArgs data)
    {
        int walk_id = (int)data.arg;
        if (walk_id != m_WalkId)
            return;

        if(TargetPathManager.Instance.PathWalker == this)
        {
            TargetPathManager.Instance.NotifyLastPathNodeReached();
        }
    }

    /// <summary>
    /// 走路到某地-
    /// </summary>
    /// <param name="target"></param>
    public void WalkTo(Vector3 target)
    {
        if(TargetActor != null)
        {
            target.y = RoleHelp.GetHeightInScene(TargetActor.ActorId, target.x, target.z);
            target = InstanceHelper.ClampInWalkableRange(target, 10);

            if (TargetActor.IsAttacking() == true)
            {
                Skill cur_skill = TargetActor.GetCurSkill();
                if (cur_skill != null)
                {
                    cur_skill.End();
                }
            }
            m_WalkId = TargetActor.MoveCtrl.TryWalkToAlong(target);
        }

        mWalkType = WalkType.WALK;
        mTargetPos = target;
    }

    /// <summary>
    /// 跑步到某地
    /// </summary>
    /// <param name="target"></param>
    public void RunTo(Vector3 target)
    {
        target = InstanceHelper.ClampInWalkableRange(target);

        if (TargetActor != null)
        {
            // Hmmm ActorMachine的TryRunToAlong似乎有点问题，部分时候会卡住，暂时屏蔽
            m_WalkId = TargetActor.MoveCtrl.TryWalkToAlong(target);
        }

        mWalkType = WalkType.RUN;
        mTargetPos = target;
    }

    public void Renavigate()
    {
        if (Vector3.Equals(Vector3.zero, mTargetPos))
        {
            return;
        }

        if (TargetActor == null)
        {
            return;
        }

        TargetActor.MoveCtrl.TryWalkAlongStop();

        if (mWalkType == WalkType.WALK)
        {
            WalkTo(mTargetPos);
        }

        if (mWalkType == WalkType.RUN)
        {
            RunTo(mTargetPos);
        }
    }

    public Vector3 CurrentTargetPos
    {
        get
        {
            return mTargetPos;
        }
        set
        {
            mTargetPos = value;
            Renavigate();
        }
    }

    public bool IsWorking
    {
        get
        {
            if(TargetActor == null)
            {
                return false;
            }

            if(TargetActor.IsWalking())
            {
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// 当前是否很靠近目标
    /// </summary>
    public bool IsCloseToTarget
    {
        get
        {
            if(TargetActor == null)
            {
                return false;
            }

            if (Vector3.Distance(Vector3.zero, CurrentTargetPos) < 1.0f)
            {
                return true;
            }

            Vector3 targetActorPos = TargetActor.transform.position;
            targetActorPos.y = 0;
            Vector3 currentTargetPos = CurrentTargetPos;
            currentTargetPos.y = 0;
            if (Vector3.Distance(targetActorPos, currentTargetPos) < 1.0f)
            {
                return true;
            }

            return false;
        }
    }

    public Actor TargetActor
    {
        get
        {
            if (mTargetActor != null && mTargetActor.IsAlive)
            {
                ActorMono actor = (ActorMono)(mTargetActor.Target);
                return actor.BindActor;
            }

            return null;
        }

        set
        {
            if (mTargetActor == null || !mTargetActor.IsAlive)
            {
                mTargetActor = new WeakReference(value.GetActorMono());
            }
            else
            {
                mTargetActor.Target = value.GetActorMono();
            }
            value.UnsubscribeActorEvent(Actor.ActorEvent.REACH_TARGET, OnWalkEndCallback);
            value.SubscribeActorEvent(Actor.ActorEvent.REACH_TARGET, OnWalkEndCallback);
        }
    }
}