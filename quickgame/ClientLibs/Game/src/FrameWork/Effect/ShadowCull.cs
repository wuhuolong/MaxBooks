//--------------------------------------------
// ShadowCull.cs
// 渲染阴影时，根据一定规则屏蔽阴影的显示
// raorui comments
// 2017.6.29
//--------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xc;

public class ShadowCull : MonoBehaviour
{
    /// <summary>
    /// 对应的GameObject
    /// </summary>
    GameObject m_CacheObject;

    /// <summary>
    /// 对应的角色
    /// </summary>
    WeakReference m_ActorRef;

    /// <summary>
    /// 渲染的层级
    /// </summary>
    int m_Layer;

    int m_ShadowLayer;

    bool mIsDestroy = false;

    bool mInited = false;

    // Use this for initialization
    void Awake()
    {
        Init();
    }

    void Init()
    {
        if (mInited)
            return;

        mInited = true;
        m_CacheObject = gameObject;
        m_ShadowLayer = LayerMask.NameToLayer("ShadowCaster");

        mIsDestroy = false;
    }

    /// <summary>
    /// 销毁时的回收
    /// </summary>
    void OnDestroy()
    {
        m_CacheObject = null;
        mIsDestroy = true;

        Actor actor = m_Actor;
        if(actor != null)
            actor.UnsubscribeActorEvent(Actor.ActorEvent.SHADOW_CHANGE, OnShadowChange);
    }

    bool IsRealShadow()
    {
        Actor actor = m_Actor;
        if (actor != null)
        {
            ShadowBehavior behaviour = actor.GetBehavior<ShadowBehavior>();
            if(behaviour != null)
                return behaviour.RealShadow;
        }
        return false;
    }

    public void Init(Actor actor)
    {
        Init();

        if (actor == null)
            return;

        if (m_ActorRef == null || !m_ActorRef.IsAlive)
        {
            m_ActorRef = new WeakReference(actor);
        }
        else
            m_ActorRef.Target = actor;

        actor.SubscribeActorEvent(Actor.ActorEvent.SHADOW_CHANGE, OnShadowChange);
    }

    Actor m_Actor
    {
        get
        {
            if (m_ActorRef != null && m_ActorRef.IsAlive)
            {
                Actor actor = (Actor)(m_ActorRef.Target);
                return actor;
            }

            return null;
        }
    }

    public void SetLayer(int layer)
    {
        m_Layer = layer;

        if(m_CacheObject == null)
        {
            Debug.LogError("asdfad");
            return;//修复报错
        }

        if(IsRealShadow())
        {
            m_CacheObject.layer = m_ShadowLayer;
        }
        else
            m_CacheObject.layer = m_Layer;
    }

    /// <summary>
    /// 当阴影类型发生改变时
    /// </summary>
    void OnShadowChange(CEventBaseArgs data)
    {
        if (mIsDestroy)
            return;

        bool enable = (bool)data.arg;

        if (enable)
        {
            if(m_CacheObject != null)
                m_CacheObject.layer = m_ShadowLayer;
        }
        else
        {
            if(m_CacheObject != null)
                m_CacheObject.layer = m_Layer;
        }
    }
}