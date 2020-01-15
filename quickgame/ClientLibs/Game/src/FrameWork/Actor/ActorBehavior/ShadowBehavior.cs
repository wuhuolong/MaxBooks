//------------------------------------------------------------------------------
// Desc: 控制角色阴影的显示
// Date: 2016.7.7
// Author: raorui
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SGameEngine;

namespace xc
{
    public enum ShadowType
    {
        NONE = 0,
        FAKE_SHADOW = 1, // 假阴影
        REAL_SHADOW = 2, //实时阴影
    }

    [wxb.Hotfix]
    public class ShadowBehavior : IActorBehavior
    {
        // ------------------------------------------------
        // 接口的实现
        // ------------------------------------------------
        public override void InitBehaviors()
        {
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.DEAD, OnDead);

            if (ActorHelper.GetIsHideShadow(mOwner.TypeIdx) == true)
            {
                mShadowType = ShadowType.NONE;
            }
            else
            {
                if (mOwner.IsPlayer())
                    mShadowType = ShadowType.REAL_SHADOW;
                else
                    mShadowType = ShadowType.FAKE_SHADOW;
            }
        }
        
        public override void Update()
        {

        }

        
        public override void LateUpdate()
        {
            if (mOwner.Trans == null)
            {
                return;
            }

            Vector3 actPos = mOwner.Trans.position;

            // 更新阴影
            if(mShadowType == ShadowType.FAKE_SHADOW)
            {
                if (mFakeShadow != null)
                {
                    //mFakeShadow.SetActive(true);
                    CommonTool.SetActive(mFakeShadow, true);
                }
                else
                    EnableFakeShadow();
            }
            else if(mShadowType == ShadowType.REAL_SHADOW)
            {
                if (mFakeShadow != null)
                {
                    //mFakeShadow.SetActive(!mRealShadow);
                    CommonTool.SetActive(mFakeShadow, !mRealShadow);
                }
            }
            else if(mShadowType == ShadowType.NONE)
            {
                if (mFakeShadow != null)
                {
                    //mFakeShadow.SetActive(false);
                    CommonTool.SetActive(mFakeShadow, false);
                }
            }
        }
        
        public override void UnInitBehaviors()
        {
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.DEAD, OnDead);

            base.UnInitBehaviors();

            RecycleFakeShadow();
        }
        
        // leaf
        public override void EnableBehaviors(bool enable)
        {

        }

        // ------------------------------------------------
        // 组件的类型定义
        // ------------------------------------------------

        
        // ------------------------------------------------
        // 组件的变量定义
        // ------------------------------------------------
        const string ShadowEffectPrefab = "Core/ShadowProjector/ShadowProjector";
        int mHideLayer = LayerMask.NameToLayer("Hide");// 需要在主相机中隐藏的层级
        int mDefaultLayer = LayerMask.NameToLayer("Monster");// 需要在主相机中隐藏的层级

        public ShadowType ShadowType
        {
            set
            {
                mShadowType = value;

                // 设置坐骑的阴影
                if (mOwner.mRideCtrl != null)
                {
                    Actor rider = mOwner.mRideCtrl.Rider;
                    if (rider != null && rider.IsDestroy == false)
                    {
                        if (value == ShadowType.REAL_SHADOW)
                        {
                            var shadow_behavior = rider.GetBehavior<ShadowBehavior>();
                            if(shadow_behavior != null)
                                shadow_behavior.ShadowType = value;
                        }
                        else
                        {
                            var shadow_behavior = rider.GetBehavior<ShadowBehavior>();
                            if (shadow_behavior != null)
                            {
                                shadow_behavior.ShadowType = ShadowType.NONE;
                            }
                        }
                    }
                }
            }

            get
            {
                return mShadowType;
            }
        }

        /// <summary>
        /// 当前显示的阴影类型
        /// </summary>
        ShadowType mShadowType = ShadowType.FAKE_SHADOW;
          
        /// <summary>
        /// 角色假阴影对应的GameObject
        /// </summary>
        GameObject mFakeShadow;

        private Material shadowDynMat;
        private Material shadowStaMat;

        /// <summary>
        /// 是否开启实时阴影
        /// </summary>
        public bool RealShadow
        {
            get
            {
                return mRealShadow;
            }

            set
            {
                // shadowtype的优先级更高
                bool enable = false;
                if (mShadowType == ShadowType.REAL_SHADOW)
                    enable = value;
                else
                    enable = false;

                if(enable != mRealShadow)
                {
                    mRealShadow = enable;
                    if(mOwner != null && mOwner.IsDestroy == false)
                        mOwner.FireActorEvent(Actor.ActorEvent.SHADOW_CHANGE, new CEventBaseArgs(mRealShadow));
                }

                // 设置坐骑的实时阴影
                if (mOwner != null && mOwner.IsDestroy == false && mOwner.mRideCtrl != null)
                {
                    Actor rider = mOwner.mRideCtrl.Rider;
                    if (rider != null && rider.IsDestroy == false)
                    {
                        var shadow_behavior = rider.GetBehavior<ShadowBehavior>();
                        if (shadow_behavior != null)
                            shadow_behavior.RealShadow = value;
                    }
                }
            }
        }

        bool mRealShadow = false;

        /// <summary>
        /// 当可见模式发生改变时
        /// </summary>
        /// <param name="visible_mode"></param>
        public void OnVisibleChange(EVisibleMode visible_mode)
        {
            if(visible_mode == EVisibleMode.Invisible)
            {
                ShadowType = ShadowType.NONE;
                RealShadow = false;
            }
            else if(visible_mode == EVisibleMode.Name)
            {
                if (ActorHelper.GetIsHideShadow(mOwner.TypeIdx) == true)
                {
                    ShadowType = ShadowType.NONE;
                }
                else
                {
                    ShadowType = ShadowType.FAKE_SHADOW;
                }
                RealShadow = false;
            }
            else if(visible_mode == EVisibleMode.Visible)
            {
                if (ActorHelper.GetIsHideShadow(mOwner.TypeIdx) == true)
                {
                    ShadowType = ShadowType.NONE;
                }
                else
                {
                    if (mOwner.IsPlayer())
                    {
                        ShadowType = ShadowType.REAL_SHADOW;
                        // 此时的realshadow由cullmanger来设置
                    }
                    else
                    {
                        ShadowType = ShadowType.FAKE_SHADOW;
                        RealShadow = false;
                    }
                }
            }
            else
            {
                ShadowType = ShadowType.NONE;
                RealShadow = false;
            }
        }

        // ------------------------------------------------
        // 组件的内部方法
        // ------------------------------------------------
        bool mFakeShadowLoaded = false;
        void EnableFakeShadow()
        {
            if(mFakeShadowLoaded)
                return;

            mFakeShadowLoaded = true;
            if(mFakeShadow == null)
            {
                ActorManager.Instance.StartCoroutine(LoadFakeShadow());
            }
        }

        public void ReloadShadow()
        {
            if (this.shadowDynMat)
            {
                ShadowManager.Instance.FreeDynShadowMat(this.shadowDynMat);
                this.shadowDynMat = null;
            }

            if (this.shadowStaMat)
            {
                this.shadowStaMat = null;
            }

            if (mFakeShadow && mFakeShadowRender == null)
            {
                mFakeShadowRender = mFakeShadow.GetComponent<Renderer>();
                SetFakeShadowLayer();
            }

            if (mFakeShadowRender)
            {
                mFakeShadowRender.sharedMaterial = null;

                this.shadowStaMat = ShadowManager.Instance.GetShadowMaterial(mStaColor);
                mFakeShadowRender.sharedMaterial = this.shadowStaMat;
            }

        }

        private IEnumerator LoadFakeShadow()
        {
            ObjectWrapper ow = new ObjectWrapper();
            
            yield return  ObjCachePoolMgr.Instance.StartCoroutine(ObjCachePoolMgr.Instance.LoadPrefab(ShadowEffectPrefab, ObjCachePoolType.SMALL_PREFAB, ShadowEffectPrefab, ow));

            mFakeShadow = ow.obj as GameObject;

            // 异步加载资源时，可能角色已经被销毁了
            if(mIsDestroy)
            {
                RecycleFakeShadow();
                yield break;
            }

            if(mFakeShadow != null)
            {
                Transform mFakeShadowTrans = mFakeShadow.transform;
                mFakeShadowTrans.parent = mOwner.Trans;
                mFakeShadowTrans.localPosition = Vector3.zero;
                mFakeShadowTrans.localScale = Vector3.one;
                mFakeShadow.layer = mOwner.GetModelLayer();

                mFakeShadowRender = mFakeShadow.GetComponent<Renderer>();
                SetFakeShadowLayer();

                if (mFakeShadowRender != null)
                {
                    mFakeShadowRender.sharedMaterial = ShadowManager.Instance.GetShadowMaterial(mStaColor);
                }
            }
        }

        /// <summary>
        /// 回收假阴影的资源
        /// </summary>
        void RecycleFakeShadow()
        {
            mFadeColor.a = 1.0f;
            if(mFakeShadowRender != null)
            {
                mFakeShadowRender.sharedMaterial = null;
                mFakeShadowRender = null;
            }

            if (this.shadowDynMat)
            {
                ShadowManager.Instance.FreeDynShadowMat(this.shadowDynMat);
                this.shadowDynMat = null;
            }

            if (this.shadowStaMat)
            {
                this.shadowStaMat = null;
            }

            if (mFakeShadow != null)
                ObjCachePoolMgr.Instance.RecyclePrefab(mFakeShadow, ObjCachePoolType.SMALL_PREFAB, ShadowEffectPrefab);
        }

        // ------------------------------------------------
        // 组件的外部接口
        // ------------------------------------------------
        public ShadowBehavior(Actor act) 
        {
            mOwner = act;
        }

        void OnAfterCreate(CEventBaseArgs data)
        {
            if (mFakeShadow != null)
            {
                Transform mFakeShadowTrans = mFakeShadow.transform;
                mFakeShadowTrans.parent = mOwner.Trans;
                mFakeShadowTrans.localPosition = Vector3.zero;
            }

            this.ReloadShadow();
        }

        Renderer mFakeShadowRender;
        Utils.Timer mShadowTimer;
        Color mFadeColor = new Color(1,1,1,1);
        Color mStaColor = new Color(1, 1, 1, 1);

        /// <summary>
        /// 角色死亡后，假阴影淡出
        /// </summary>
        /// <param name="data"></param>
        void OnDead(CEventBaseArgs data)
        {
            if(mShadowTimer != null)
            {
                mShadowTimer.Destroy();
            }

            if (mFakeShadow != null)
            {
                mFakeShadowRender = mFakeShadow.GetComponent<Renderer>();
				SetFakeShadowLayer();            
			}

            if (mFakeShadowRender)
            {
                shadowDynMat = ShadowManager.Instance.GetNewDynShadowMaterial();
                mFakeShadowRender.sharedMaterial = shadowDynMat;
            }

            //获取一个假阴影动态资源

            mShadowTimer = new Utils.Timer((int)(GlobalConst.MonsterDestroyDelay * 1000), false, 100, OnFakeShadowUpdate);
        }

        /// <summary>
        /// 假阴影淡出
        /// </summary>
        /// <param name="remain_time"></param>
        void OnFakeShadowUpdate(float remain_time)
        {
            if(remain_time <= 0 || mIsDestroy)
            {
                //mFakeShadowRender = null;
            }
            else if (mFakeShadowRender != null && this.shadowDynMat)
            {
                mFadeColor.a = Mathf.Clamp01(remain_time / (GlobalConst.MonsterDestroyDelay * 1000));
                shadowDynMat.SetColor("_Color", mFadeColor);
            }
        }

        /// <summary>
        /// 初始化假阴影的Alpha数值
        /// </summary>
        public void InitColor()
        {
            if (mShadowTimer != null)
            {
                mShadowTimer.Destroy();
            }
            if (mFakeShadowRender != null)
            {
                mFakeShadowRender.sharedMaterial = null;
            }

            //if (this.shadowDynMat)
            //{
            //    ShadowManager.Instance.FreeDynShadowMat(this.shadowDynMat);
            //    this.shadowDynMat = null;
            //}

            this.ReloadShadow();

        }

        bool mHideFakeShadow = false;

        /// <summary>
        /// 显示/隐藏假阴影(通过Renderer来控制)
        /// </summary>
        public bool HideFakeShadow
        {
            set
            {
                bool oldValue = mHideFakeShadow;
                mHideFakeShadow = value;

                if (mHideFakeShadow != oldValue)
                {
                    SetFakeShadowLayer();
                }
            }
        }

        /// <summary>
        /// 根据mHideFakeShadow变量来设置阴影片的层级
        /// </summary>
        void SetFakeShadowLayer()
        {
            if(mFakeShadow != null)
            {
                if (mHideFakeShadow)
                    mFakeShadow.layer = mHideLayer;
                else
                    mFakeShadow.layer = mDefaultLayer;
            }
        }
    }
}

