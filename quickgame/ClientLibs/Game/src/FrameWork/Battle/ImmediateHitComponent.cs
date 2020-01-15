//------------------------------------------------------------------------------
// Desc  :  跟踪目标的组件(立即命中)
// Author:  raorui
// Date  ： 2016.10.14
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using xc;

public class ImmediateHitComponent : TraceBaseComponent
{
    Transform cacheTrans;
    
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
    }
    
    void Awake()
    {
        cacheTrans = transform;
    }
    
    void Start()
    {
        OnHit();
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
        }
        
        StartCoroutine(DestroyImmediate());
    }

    IEnumerator DestroyImmediate()
    {
        yield return new WaitForSeconds(2.0f);
        if(mSkillAttackInst != null)
            mSkillAttackInst.DestroyAll();
    }
}
