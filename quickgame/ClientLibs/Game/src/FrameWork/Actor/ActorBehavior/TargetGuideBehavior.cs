//------------------------------------------------------------------------------
// Desc: 目标指引的显示
// Date: 2017.9.20
// Author: ljy
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class TargetGuideBehavior : IActorBehavior
    {
        protected UI3DTargetGuide mComponent = null;

        public UI3DTargetGuide.StyleInfo DataStyleInfo
        {
            get { return mStyleInfo; }
        }

        public TargetGuideBehavior(Actor owner)
        {
            mOwner = owner;
        }

        public override void InitBehaviors()
        {
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
        }
        
        public override void Update()
        {
            //Debug.Log("ActorTextNameBehavior");
        }
        
        
        public override void LateUpdate()
        {

        }
        
        public override void UnInitBehaviors()
        {
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
            base.UnInitBehaviors();

            if (null != mComponent)
            {
                UnityEngine.GameObject.Destroy(mComponent);
                mComponent = null;
            }
        }

        // leaf
        public override void EnableBehaviors(bool enable)
        {
            if (null != mComponent && mComponent.enabled != enable)
            {
                mComponent.enabled = enable;
            }
        }

        public UI3DTargetGuide Component
        {
            get
            {
                return mComponent;
            }
        }

        UI3DTargetGuide.StyleInfo mStyleInfo;
        public void SetStyle(UI3DTargetGuide.StyleInfo style_info)
        {
            mStyleInfo = style_info;
            if (mComponent != null)
            {
                mComponent.ResetStyleInfo(mStyleInfo);
            }
        }

        void UpdateOwnerTrans(Transform trans)
        {
            if (mComponent == null)
            {
                mComponent = trans.gameObject.AddComponent<UI3DTargetGuide>();
            }

            mComponent.SetOwnerTrans(trans);
            mComponent.ResetStyleInfo(mStyleInfo);
        }

        void OnAfterCreate(CEventBaseArgs param)
        {
            UpdateOwnerTrans(mOwner.GetModelParent().transform);
        }

        void OnModelChange(CEventBaseArgs param)
        {
        }
    }
}

