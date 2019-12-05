//------------------------------------------------------------------------------
// Desc: 控制角色绑定在身上特效的加载
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
    [wxb.Hotfix]
    public class BindEffectBehavior : IActorBehavior
    {
        // ------------------------------------------------
        // 接口的实现
        // ------------------------------------------------
        public override void InitBehaviors()
        {
            
        }
        
        public override void Update()
        {
            
        }

        
        public override void LateUpdate()
        {

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
        
        // ------------------------------------------------
        // 组件的内部方法
        // ------------------------------------------------
        void BindEffect(GameObject effect_object, BindEffectInfo bind_effect)
        {
            if (effect_object == null)
            {
                return;
            }
            
            if (mOwner != null && mOwner.ActorTrans != null && bind_effect != null && !bind_effect.IsDestroy && !mOwner.IsDestroy)
            {           
                // 特效的加载是异步的，有可能设置角色Visible属性的时候，特效的可见性没有进行设置
                if(mOwner.mVisibleCtrl != null && mOwner.mVisibleCtrl.VisibleMode != EVisibleMode.Visible)
                {
                    Renderer[] rds = effect_object.GetComponentsInChildren<Renderer>(true);
                    foreach (Renderer rd in rds)
                    {
                        rd.enabled = false;
                    }
                }
                
                Transform effect_trans = effect_object.transform;
                Transform root_trans = mOwner.ActorTrans.Find(AvatarCtrl.ROOT_NODE); //特效需要挂接到玩家模型身上
                if (root_trans == null)
                    root_trans = mOwner.ActorTrans;

                // 根据目标的buff,如果找不到挂点，则将特效销毁
                if(root_trans == null && bind_effect.FollowTarget)
                {
                    GameObject.Destroy(effect_object);
                    return;
                }

                effect_trans.parent = root_trans;

                Vector3 offset = Vector3.zero;
                var bind_pos = bind_effect.BindPos;
                if (bind_pos == DBBuffSev.BindPos.BP_Body)
                {
                    offset.y = mOwner.CharacterHeight * 0.75f;
                }
                else if(bind_pos == DBBuffSev.BindPos.BP_Head)
                {
                    offset.y = mOwner.CharacterHeight;
                }

                effect_trans.localRotation = Quaternion.identity;
                effect_trans.localPosition = offset;

                // 如果不根据目标，则设置父节点为空
                if (!bind_effect.FollowTarget)
                    effect_trans.parent = null;

                bind_effect.mEffectObject = effect_object;

                ParticleControl particle_control = effect_object.GetComponent<ParticleControl>();
                if(particle_control == null)
                    particle_control = effect_object.AddComponent<ParticleControl>();
                particle_control.Scale = bind_effect.mScale;

                // 设置层级
                xc.ui.ugui.UIHelper.SetLayer(effect_object.transform, mOwner.GetModelLayer());
            }
            else
            {
                GameObject.Destroy(effect_object);
            }
        }
        
        // ------------------------------------------------
        // 组件的外部接口
        // ------------------------------------------------
        public BindEffectBehavior(Actor act)
        {
            mOwner = act;
        }

        public BindEffectInfo InitBindEffectInfo(string effect, DBBuffSev.BindPos bind_pos, bool follow_target, float scale, bool auto_scale, int maxCount)
        {
            float scale_auto = auto_scale ? mOwner.Radius / GlobalConst.StandardRadius : 1.0f;
            BindEffectInfo bind_effect_info = new BindEffectInfo(effect, bind_pos, follow_target, scale * scale_auto, maxCount);
            bind_effect_info.mInitFunc = x => BindEffect(x, bind_effect_info);
            
            return bind_effect_info;
        }
    }
}

