//------------------------------------------------------------------------------
// Desc: 控制角色名字的显示
// Date: 2016.6.29
// Author: raorui
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class HPProgressBarBehavior : IActorBehavior
    {
        protected UI3DProgressBar mHPComponent = null;

        public HPProgressBarBehavior(Actor owner)
        {
            mOwner = owner;
        }

        public override void InitBehaviors()
        {
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
        }

        public override void Update()
        {

        }

        public override void LateUpdate()
        {

        }

        public override void UnInitBehaviors()
        {
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);

            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
            base.UnInitBehaviors();

            if (null != mHPComponent)
            {
                UnityEngine.GameObject.DestroyImmediate(mHPComponent);
                mHPComponent = null;
            }
        }


        // leaf
        public override void EnableBehaviors(bool enable)
        {
            if (null != mHPComponent)
            {
                mHPComponent.enabled = enable;
            }
        }

        void OnAfterCreate(CEventBaseArgs param)
        {
            // 守护npc初始就需要血条
            if (mOwner.IsGuardedNpc())
            {
                if(mHPComponent == null)
                    CreateHPComponent();
            }
        }
        
        Transform mHeadTrans;
        void UpdateHeadTrans(Transform trans)
        {
            mHeadTrans = trans;
            if(null != mHPComponent)
            {
                mHPComponent.SetHeadTrans(trans);
            }
        }

        /// <summary>
        /// 创建血条的组件
        /// </summary>
        void CreateHPComponent()
        {
            if (mOwner.IsGuardedNpc() || (mOwner.IsMonster() && !mOwner.IsBoss()))// 非boss的怪物才显示血条、守护npc
            {
                if (mHPComponent != null)
                {
                    GameObject.DestroyImmediate(mHPComponent);
                    mHPComponent = null;
                }

                mHPComponent = mOwner.gameObject.AddComponent<UI3DProgressBar>();
                mHPComponent.SetTargetActor(mOwner);

                UpdateHeadTrans(mOwner.GetModelParent().transform);
                mHPComponent.HeadOffset = new Vector3(0f, mOwner.Height - 0.2f, 0f);
            }
        }

        void OnModelChange(CEventBaseArgs param)
        {
            if (mHPComponent != null)
            {
                mHPComponent.HeadOffset = new Vector3(0f, mOwner.Height - 0.2f, 0f);
            }
        }

        /// <summary>
        /// 选中目标发生变化
        /// </summary>
        /// <param name="data"></param>
        void OnSelectActorChange(CEventBaseArgs data)
        {
            if (mOwner == null)
                return;

            // 被选中的时候需要激活该组件
            var actorMono = (ActorMono)data.arg;
            if (actorMono != null && actorMono.BindActor != null)
            {
                if (actorMono.BindActor.UID == mOwner.UID)
                {
                    if (mHPComponent == null)
                        CreateHPComponent();

                    EnableBehaviors(true);
                }
            }
        }
    }
}

