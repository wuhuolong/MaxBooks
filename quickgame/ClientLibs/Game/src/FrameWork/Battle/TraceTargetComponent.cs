//------------------------------------------------------------------------------
// Desc  :  跟踪目标的组件
// Author:  raorui
// Date  ： 2016.8.31
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using xc;

public class TraceTargetComponent : TraceBaseComponent
{
    Transform cacheTrans;
    Vector3 mTargetStartPos; // 目标物体刚开始的位置
    float mTraceSpeed;// 每秒运动的距离
    Vector3 mTransDir;
    float mTraceDetalTime = 1.0f;
    float mNextTime;
    float mSqrReachRange = 1.0f*1.0f;

    public override void Init(ActorMono src, ActorMono target, DBBulletTrace.BulletInfo bulletInfo, SkillAttackInstance inst)
    {
        base.Init(src, target, bulletInfo, inst);

        if(target == null || target.BindActor == null)
        {
            Debug.LogError("Target is lost");
            DestroySelf();
            return;
        }

        if(bulletInfo == null)
        {
            Debug.LogError("BulletInfo is null");
            DestroySelf();
            return;
        }

        m_BulletInfo = bulletInfo;
        mTarget = target;
        mTargetStartPos = TargetPos;
        mTraceSpeed = bulletInfo.FlySpeed;
        float move_per_frame = mTraceSpeed * 0.0333f;
        mSqrReachRange = move_per_frame*move_per_frame;

        Vector3 dir = mTargetStartPos - cacheTrans.position;
        dir.Normalize();
        mTransDir = dir * mTraceSpeed;
    }

    void Awake()
    {
        cacheTrans = transform;
    }

    /// <summary>
    /// 每帧按照指定的方向移动
    /// </summary>
    void Update()
    {
        if(mTarget != null && mTarget.BindActor != null)
        {
            if(m_BulletInfo.BulletType == DBBulletTrace.BulletTypes.BT_DIRECTION)
            {
                Vector3 vec = TargetPos - cacheTrans.position;
                float curTime = Time.time;
                if(curTime > mNextTime)
                {
                    mTransDir = vec.normalized * mTraceSpeed;
                    cacheTrans.rotation = Quaternion.LookRotation(mTransDir);
                }

                vec.y = 0;
                if(vec.sqrMagnitude <= mSqrReachRange)
                {
                    OnHit();
                }
                else
                    cacheTrans.Translate(mTransDir * Time.deltaTime, Space.World);
            }
            else if(m_BulletInfo.BulletType == DBBulletTrace.BulletTypes.BT_BIND)
            {
                Vector3 vec = mTargetStartPos - cacheTrans.position;

                vec.y = 0;
                if(vec.sqrMagnitude <= 3.5f*3.5f)
                {
                    OnHit();
                }
            }
        }
        else
        {
            //Debug.LogError("Target is lost");
            DestroySelf();
        }
    }

    bool mHasHit = false;

    // 子弹已命中目标
    void OnHit()
    {
        //Debug.LogError("Target is reached");
        mHasHit = true;
        if(SkillAttackInst != null)
        {
            SkillAttackInst.OnHit();
        }

        DestroySelf();
    }

    void DestroySelf()
    {
        if(mHasHit == false)
        {
            GameDebug.LogError("[TraceTargetComponent]Has not hit when Destroy");
            // 先强制命中
            if(mSkillAttackInst != null)
            {
                mSkillAttackInst.OnHit();
            }
        }

        if(mSkillAttackInst != null)
            mSkillAttackInst.DestroyAll();
    }
}
