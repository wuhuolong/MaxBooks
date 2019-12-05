//------------------------------------------------------------------------------
// Desc  :  跟踪子弹的组件
// Author:  raorui
// Date  ： 2016.8.30
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    public class BulletTrackInstance
    {
        public ulong SkillAttackId = 0;
        DBBulletTrace.BulletInfo  m_BulletInfo;
        DBSkillSev.SkillInfoSev m_SkillInfo;
        float m_DelayTime = 0.0f;

        public BulletTrackInstance(DBBulletTrace.BulletInfo bulllet_info, DBSkillSev.SkillInfoSev skill_info, float delayTime = -1.0f)
        {
            m_BulletInfo = bulllet_info;
            m_SkillInfo = skill_info;
            if (delayTime < 0)
            {
                if(m_SkillInfo.BattleFxInfo != null)
                    m_DelayTime = m_SkillInfo.BattleFxInfo.HitDelayTime;
                else
                {
                    m_DelayTime = 0.1f;
                    GameDebug.LogError(string.Format("skill, id: {0} has not battlefx info.", m_SkillInfo.Id));
                }
            }
            else
                m_DelayTime = delayTime;
        }

        /// <summary>
        /// Do the specified target, kPos, kRotation and sDir.
        /// </summary>
        /// <param name="target">子弹追踪的目标</param>
        /// <param name="bullet_pos">子弹发出的位置</param>
        /// <param name="bullet_rot">子弹的旋转量</param>
        /// <param name="bullet_dir">子弹追踪的方向</param>
        public void Do(ulong skill_attack_id, ActorMono src, ActorMono target, bool is_hide_effect, Vector3 bullet_pos, Quaternion bullet_rot, Vector3 bullet_dir, Action<SkillAttackInstance> hit_callback)
        {   
            if(target == null || target.BindActor == null)
                return;

            SkillAttackId = skill_attack_id;

            GameObject bullet_Obj = new GameObject("Bullet");
            InitBullet(bullet_Obj, src, target, skill_attack_id, bullet_pos, bullet_rot, bullet_dir, hit_callback);

            Actor src_actor = src != null ? src.BindActor : null;

            is_hide_effect = is_hide_effect || ShieldManager.Instance.IsHideBulletEffect(src_actor, target.BindActor);
            if (!string.IsNullOrEmpty(m_BulletInfo.AttackEffect) && !is_hide_effect)
            {
                EffectManager.GetInstance().GetEffectEmitter(m_BulletInfo.AttackEffect).CreateInstance(x => InitEffectObject(bullet_Obj,x));
            }
        }

        /// <summary>
        /// 初始化子弹的信息
        /// </summary>
        /// <param name="bulletObject"></param>
        /// <param name="src"></param>
        /// <param name="traceTarget"></param>
        /// <param name="effectId"></param>
        /// <param name="pos"></param>
        /// <param name="rotation"></param>
        /// <param name="dir"></param>
        /// <param name="hit_callback"></param>
        void InitBullet(GameObject bullet_object, ActorMono src, ActorMono trace_target, ulong effect_Id, Vector3 pos, Quaternion rotation, Vector3 dir, Action<SkillAttackInstance> hit_callback)
        {
            if (trace_target == null || trace_target.BindActor == null)
                return;

            pos.y += m_BulletInfo.OffsetY;
            pos += dir * m_BulletInfo.OffsetX; // 前向移动

            //GameDebug.Log("EffectId : "+effect_Id);
            Transform bulletTrans = bullet_object.transform;

            // 设置子弹的位置和方向
            bulletTrans.position = pos;
            bulletTrans.rotation = rotation;
            bulletTrans.localScale = Vector3.one;

            if (m_BulletInfo.BulletType == DBBulletTrace.BulletTypes.BT_BIND)
            {
                bulletTrans.parent = src.BindActor.Trans;
            }

            var skill_attack_inst = new SkillAttackInstance();
            var skill_base = bullet_object.AddComponent<SkillBaseComponent>();

            // 初始化
            skill_base.Init(skill_attack_inst);
            skill_attack_inst.Init(effect_Id, src.BindActor.UID, m_SkillInfo, 0, m_BulletInfo.FlyMaxTime, 1.0f, skill_base, hit_callback);

            // 子弹加到管理器
            EffectManager.GetInstance().AddSkillInstance(effect_Id, skill_attack_inst);

            if (m_BulletInfo.BulletType == DBBulletTrace.BulletTypes.BT_DIRECTION ||
               m_BulletInfo.BulletType == DBBulletTrace.BulletTypes.BT_BIND)
            {
                // 绑定追踪组件
                TraceTargetComponent trace_target_comp = bullet_object.AddComponent<TraceTargetComponent>();
                Vector3 v_dir = Quaternion.Euler(0.0f, 0.0f, 0.0f) * dir; // flyDir要转化到当前运行方向的坐标轴中
                bulletTrans.forward = v_dir;
                trace_target_comp.Init(src, trace_target, m_BulletInfo, skill_attack_inst);
                skill_base.AddMonoEnableOption(trace_target_comp, true, m_DelayTime);
            }
            else if (m_BulletInfo.BulletType == DBBulletTrace.BulletTypes.BT_LINK)
            {
                // 绑定追踪组件
                StretchComponent traceComp = bullet_object.AddComponent<StretchComponent>();
                traceComp.Init(src, trace_target, m_BulletInfo, skill_attack_inst);
                skill_base.AddMonoEnableOption(traceComp, true, m_DelayTime);
            }
            else if (m_BulletInfo.BulletType == DBBulletTrace.BulletTypes.BT_IMMEDIATE)
            {
                bulletTrans.parent = trace_target.BindActor.Trans;
                bulletTrans.localPosition = Vector3.zero;
                bulletTrans.rotation = Quaternion.identity;
                bulletTrans.localScale = Vector3.one;
                bulletTrans.parent = null;

                // 绑定追踪组件
                ImmediateHitComponent traceComp = bullet_object.AddComponent<ImmediateHitComponent>();
                traceComp.Init(src, trace_target, m_BulletInfo, skill_attack_inst);
                skill_base.AddMonoEnableOption(traceComp, true, m_DelayTime);
            }

            // 绑子弹音效
            if (m_BulletInfo.AttackSound != string.Empty)
            {
                var bind_sound = bullet_object.AddComponent<BindSoundComponent>();
                bind_sound.enabled = false;
                bind_sound.Init(m_BulletInfo.AttackSound, false);
                skill_base.AddMonoEnableOption(bind_sound, true, m_DelayTime);
            }
        }

        /// <summary>
        /// 初始化子弹和对应特效的位置和方向
        /// </summary>
        /// <param name="effectObject">特效跟节点物体</param>
        /// <param name="effectObject">特效物体</param>
        /// <param name="kPos">特效位置</param>
        /// <param name="kRotation">特效初始方向</param>
        /// <param name="sDir">子弹飞行的方向</param>
        void InitEffectObject(GameObject bullet_object, GameObject effect_object)
        {       
            if (bullet_object == null)
            {
                if(effect_object != null)
                    CommonTool.DestroyObjectImmediate(effect_object);
                return;
            }

            if (effect_object == null)
                return;

            Transform bullet_trans = bullet_object.transform;

            // 设置特效位置和方向
            effect_object.SetActive(false);
            Transform effect_trans = effect_object.transform;
            effect_trans.parent = bullet_trans;
            effect_trans.localPosition = Vector3.zero;
            effect_trans.localRotation = Quaternion.identity;
            effect_trans.localScale = Vector3.one;

            DelayEnableComponent delayEnable = bullet_object.GetComponent<DelayEnableComponent>();
            if(delayEnable == null)
                delayEnable = bullet_object.AddComponent<DelayEnableComponent>();
            delayEnable.DelayTime = m_DelayTime;
            delayEnable.SetEnable = true;
            delayEnable.SetEnableTarget(effect_object);
        }
    }
}

