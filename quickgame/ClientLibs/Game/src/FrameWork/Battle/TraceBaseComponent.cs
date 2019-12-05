//------------------------------------------------------------------------------
// Desc  :  跟踪目标的组件的基类
// Author:  raorui
// Date  ： 2016.9.8
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using xc;

public class TraceBaseComponent : MonoBehaviour
{
    /// <summary>
    /// 子弹信息
    /// </summary>
    protected DBBulletTrace.BulletInfo m_BulletInfo;

    /// <summary>
    /// 技能攻击的实例
    /// </summary>
    protected SkillAttackInstance mSkillAttackInst;

    /// <summary>
    /// 追踪的目标Actor
    /// </summary>
    protected ActorMono mTarget;

    public SkillAttackInstance SkillAttackInst
    {
        get
        {
            return mSkillAttackInst;
        }
    }

    public virtual void Init(xc.ActorMono s, xc.ActorMono d, DBBulletTrace.BulletInfo bulletInfo, SkillAttackInstance attackInst)
    {
        mSkillAttackInst = attackInst;
    }

    /// <summary>
    /// 获取目标点的位置
    /// </summary>
    protected Vector3 TargetPos
    {
        get
        {
            if(mTarget == null)
            {
                GameDebug.LogError("[TraceTargetComponent]GetTargetPos failed,Target is null");
                return Vector3.zero;
            }

            Transform targetTrans = mTarget.BindActor.Trans;
            if(targetTrans != null)
            {
                Vector3 pos = targetTrans.position;
                pos.y += mTarget.BindActor.Height * 0.6f;
                return pos;
            }
            else
            {
                GameDebug.LogError("[TraceTargetComponent]GetTargetPos failed,Target's Trans is null");
                return Vector3.zero;
            }
        }
    }
}

