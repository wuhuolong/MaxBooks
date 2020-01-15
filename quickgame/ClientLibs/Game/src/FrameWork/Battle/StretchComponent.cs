//*******************************************************
//  File: StretchComponent.cs
//  Author : raorui
//  Date: 2016.9.8
//  Desc: 用来控制拉伸模型时，同时控制纹理的Tile数值，
//  以达到模型、特效可以在一个方向不断延伸的效果
//*******************************************************
using UnityEngine;
using System.Collections;
using xc;

/// <summary>
/// 拉伸模型时，同时设置纹理Title数值
/// </summary>
public class StretchComponent : TraceBaseComponent
{
	/// <summary>
	/// 需要拉伸的物体
	/// </summary>
	Transform m_StretchTarget;

    /// <summary>
    /// 在拉伸时，是否对UV进行缩放
    /// </summary>
    bool m_ScaleUV = false;

    /// <summary>
    /// 设置UV的数值是否倒转
    /// </summary>
    bool UVInv = false;

	/// <summary>
	/// Target下所有的MeshRender
	/// </summary>
	private MeshRenderer[] m_AllRender;

    /// <summary>
    ///  拉伸的起点Transform
    /// </summary>
	public Transform m_BeginTrans;

    /// <summary>
    /// 拉伸的结束点Transform
    /// </summary>
    public Transform m_EndTrans;

    /// <summary>
    /// 拉伸时，每秒移动的速度
    /// </summary>
    public float MoveSpeed = 6.0f;

    /// <summary>
    /// 目标物体的高度
    /// </summary>
    float m_TargetHeight = 2.0f;

    /// <summary>
    /// 模型的拉伸
    /// </summary>
	private Vector3 Scale = Vector3.one;

    /// <summary>
    /// 贴图UV的Scale
    /// </summary>
	private Vector2 UVScale = Vector2.one;
	
	bool arrowReached = false;
	Transform cacheTrans;

	void Awake()
	{
		cacheTrans = transform;
	}

	void Start ()
	{
		if(m_StretchTarget == null)
		{
			StretchTarget t = cacheTrans.GetComponentInChildren<StretchTarget>(true);
			if(t != null)
			{
                m_StretchTarget = t.transform;
			}
		}

		if(m_ScaleUV && m_StretchTarget != null)
            m_AllRender = m_StretchTarget.GetComponentsInChildren<MeshRenderer>(true);

        cacheTrans.position = BeginPos;
    }

	// Update is called once per frame
	void Update ()
	{
		if(!mInitPoint)
			return;

        if(m_BeginTrans == null || m_EndTrans == null || mIsDestroy)
		{
            DestroySelf();
			return;
		}

		if(!arrowReached)
		{
			// 逐渐移动到目标点
			Vector3 dest_vec = EndPos - cacheTrans.position;
            float move_len = Time.deltaTime * MoveSpeed;
            float dest_len = dest_vec.magnitude;
            if (move_len > dest_len)
                move_len = dest_len;
            cacheTrans.position += dest_vec.normalized * move_len;
            // 设置当前旋转量
            Vector3 src_vec = cacheTrans.position - BeginPos;
			cacheTrans.rotation = Quaternion.LookRotation(src_vec);
			SetStretch(1, src_vec.magnitude);
			// 检查是否到达目标点
            if((cacheTrans.position - EndPos).magnitude < 0.1f)
			{
				arrowReached = true;
			}
			return;
		}

        cacheTrans.position = EndPos;
        Vector3 vec = EndPos - BeginPos;
		cacheTrans.rotation = Quaternion.LookRotation(vec);
		SetStretch(1,vec.magnitude);
        OnHit();
    }

    /// <summary>
    /// 是否进行了初始化
    /// </summary>
	bool mInitPoint = false;

    public override void Init(xc.ActorMono begin_actor, xc.ActorMono end_actor, DBBulletTrace.BulletInfo bulletInfo, SkillAttackInstance inst)
	{
        base.Init(begin_actor, end_actor, bulletInfo, inst);

		mInitPoint = true;

        if(begin_actor == null || begin_actor.BindActor == null || end_actor == null || end_actor.BindActor == null)
        {
            GameDebug.LogError("[StretchComponent]Target is lost");
            DestroySelf();
            return;
        }
        
        if(bulletInfo == null)
        {
            GameDebug.LogError("[StretchComponent]BulletInfo is null");
            DestroySelf();
            return;
        }

        m_BulletInfo = bulletInfo;
		m_BeginTrans = begin_actor.BindActor.Trans;
        m_EndTrans = end_actor.BindActor.Trans;
        mTarget = end_actor;
        m_TargetHeight = end_actor.BindActor.Height;
        MoveSpeed = bulletInfo.FlySpeed;

        // 先设置方向
        Vector3 vec = TargetPos - BeginPos;
        cacheTrans.position = BeginPos + vec*0.1f;
		cacheTrans.rotation = Quaternion.LookRotation(vec);
		SetStretch(1,vec.magnitude * 0.1f);
		arrowReached = false;
	}

    /// <summary>
    /// 设置拉伸
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
	public void SetStretch(float x, float z)
	{
		if(m_StretchTarget != null)
		{
			Scale.x = x;
			Scale.z = z;

            m_StretchTarget.localScale = Scale;
			
			if(m_ScaleUV && m_AllRender != null)
			{
                if (UVInv)
                {
                    UVScale.x = x;
                    UVScale.y = z;
                }
                else
                {
                    UVScale.x = z;
                    UVScale.y = x;
                }

                for (int i = 0; i < m_AllRender.Length; ++i)
				{
                    m_AllRender[i].material.mainTextureScale = UVScale;
				}
			}
		}
	}

    bool mHasHit = false;
    // 子弹已命中目标
    void OnHit()
    {
        //GameDebug.Log("[StretchComponent]Target is reached");
        mHasHit = true;
        if (mSkillAttackInst != null)
        {
            mSkillAttackInst.OnHit();
        }

        //DestroySelf();
    }

    void DestroySelf()
	{
        if (mSkillAttackInst != null)
        {
            mSkillAttackInst.DestroyAll();
            mSkillAttackInst = null;
        }

        if (mHasHit == false)
        {
            GameDebug.LogError("[StretchComponent]Has not hit when Destroy");
            // 先强制命中
            if (mSkillAttackInst != null)
            {
                mSkillAttackInst.OnHit();
            }
        }
    }

    /// <summary>
    /// 是否已经被销毁
    /// </summary>
    bool mIsDestroy = false;
    void OnDestroy()
    {
        mIsDestroy = true;
    }

    /// <summary>
    /// 获取目标点的位置
    /// </summary>
    protected Vector3 BeginPos
    {
        get
        {       
            if(m_BeginTrans != null)
            {
                Vector3 pos = m_BeginTrans.position;
                pos.y += m_TargetHeight * 0.6f;
                return pos;
            }
            else
            {
                GameDebug.LogError("[StretchComponent]Get beginpos failed, begin_actor's transform is null");
                return Vector3.zero;
            }
        }
    }

    /// <summary>
    /// 获取目标点的位置
    /// </summary>
    protected Vector3 EndPos
    {
        get
        {
            if (m_EndTrans == null)
            {
                GameDebug.LogError("[TraceTargetComponent]TargetTrans is null");
                return Vector3.zero;
            }

            Vector3 pos = m_EndTrans.position;
            pos.y += m_TargetHeight * 0.6f;
            return pos;
        }
    }
}
