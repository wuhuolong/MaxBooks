//------------------------------------------------------------------------------
// ThunderHitInfo.cs
// 闪电攻击的命中信息
// @raorui
// 2017.6.7 comments
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    public class ThunderHitInfo
    {
        public struct HitCacheInfo
        {
            ulong m_SubEmitID; //攻击该玩家使用的sub_emit

            public HitCacheInfo(ulong sub_emit_id)
            {
                m_SubEmitID = sub_emit_id;
            }

            public ulong SubEmitID { get { return m_SubEmitID; } }
        }

        public uint ActorID; //攻击者的ID
        public uint EmitID;// 攻击实例的id
        public SkillAttackInstance SkillAttackInst; // 攻击的实例
        public uint SkillID;// 攻击的技能id
        public List<uint> HitPlayers = new List<uint>(); // 一次闪电攻击按顺序攻击到的所有角色
       
        public ulong m_SubEmitId = 0;

        Dictionary<uint, HitCacheInfo> m_HitEmits = new Dictionary<uint, HitCacheInfo>(); // 保存受击玩家与攻击该玩家使用的sub_emit的对应关系
        Dictionary<uint, Damage> m_DamageInfos = new Dictionary<uint, Damage>(); // 受击玩家id与伤害信息的索引
        Dictionary<uint, SkillAttackInstance.DeathAppendInfo> m_DeathAppendInfos = new Dictionary<uint, SkillAttackInstance.DeathAppendInfo>(); // 受击过程中死亡玩家的索引
        List<BulletTrackInstance> m_TraceInsts = new List<xc.BulletTrackInstance>();// 保存闪电链每次攻击的实例
        DBSkillSev.SkillInfoSev m_SkillInfo;// 技能信息
        DBBulletTrace.BulletInfo m_BulletInfo;// 子弹信息
        uint mLastThunderPlayer = 0;// 上次命中的玩家
        bool mHideEffect = false; // 是否隐藏子弹特效

        /// <summary>
        /// 初始化
        /// </summary>
        public bool Init()
        {
            m_SkillInfo = DBSkillSev.Instance.GetSkillInfo(SkillID);
            m_SubEmitId = (ulong)( ((ulong)ActorID << 32 & 0xffffffff00000000) | ((ulong)SkillID << 16 & 0xffffffffffff0000)); // 暂时使用技能ID和角色ID来进行组合
            if (m_SkillInfo != null && m_SkillInfo.BulletId != 0)
            {
                m_BulletInfo = DBBulletTrace.GetInstance().GetBulletInfo(m_SkillInfo.BulletId);
                if (m_BulletInfo != null)
                {
                    if (HitPlayers.Count > 0)
                    {
                        uint hit_player_id = HitPlayers[0];
                        Actor src_player = ActorManager.Instance.GetPlayer(ActorID);
                        Actor hitPlayer = ActorManager.Instance.GetPlayer(hit_player_id);

                        if (src_player == null || hitPlayer == null || src_player.GetActorMono()== null || hitPlayer.GetActorMono() == null)
                            return false;

                        ActorMono src_actormono = src_player.GetActorMono();
                        ActorMono hit_actormono = hitPlayer.GetActorMono();

                        BulletTrackInstance sub_bullet_trace = new xc.BulletTrackInstance(m_BulletInfo, m_SkillInfo, 0);
                        m_TraceInsts.Add(sub_bullet_trace);

                        // 开启新的BulletTrackInstance
                        mHideEffect = ShieldManager.Instance.IsHideBulletEffect(src_player, hitPlayer);
                        sub_bullet_trace.Do(m_SubEmitId, src_actormono, hit_actormono, mHideEffect, src_player.transform.position, src_player.transform.rotation, src_player.transform.forward, OnHit);
                        
                        // 将伤害信息添加到新创建的SkillAttackInstance列表中
                        SkillAttackInstance attack_inst = EffectManager.GetInstance().GetAttackInstance(m_SubEmitId);
                        if (attack_inst != null)
                        {
                            Damage dmgInfo = null;
                            if (m_DamageInfos.TryGetValue(hit_player_id, out dmgInfo))
                            {
                                attack_inst.AddHurtInfo(dmgInfo);
                            }
                        }

                        m_HitEmits[hit_player_id] = new HitCacheInfo(m_SubEmitId);
                        m_SubEmitId++;

                        mLastThunderPlayer = hit_player_id;
                        HitPlayers.RemoveAt(0);
                        return true;
                    }

                }
            }

            return false;
        }

        /// <summary>
        /// 当命中一个角色后的回调
        /// </summary>
        /// <param name="sub_inst"></param>
        void OnHit(SkillAttackInstance sub_inst)
        {
            if (m_BulletInfo != null)
            {
                if (HitPlayers.Count > 0)
                {
                    uint hit_player_id = HitPlayers[0];
                    Actor src_player = ActorManager.Instance.GetPlayer(mLastThunderPlayer);
                    Actor hitPlayer = ActorManager.Instance.GetPlayer(hit_player_id);

                    if (src_player == null || hitPlayer == null || src_player.GetActorMono() == null || hitPlayer.GetActorMono() == null)
                    {
                        GameDebug.Log("player is null");
                    }
                    else
                    {
                        BulletTrackInstance sub_bullet_trace = new xc.BulletTrackInstance(m_BulletInfo, m_SkillInfo, 0);
                        m_TraceInsts.Add(sub_bullet_trace);

                        // 开启新的BulletTrackInstance
                        sub_bullet_trace.Do(m_SubEmitId, src_player.GetActorMono(), hitPlayer.GetActorMono(), mHideEffect, src_player.transform.position, src_player.transform.rotation, src_player.transform.forward, OnHit);
                        
                        // 将伤害信息添加到新创建的SkillAttackInstance列表中
                        SkillAttackInstance attack_inst = EffectManager.GetInstance().GetAttackInstance(m_SubEmitId);
                        if (attack_inst != null)
                        {
                            Damage dmgInfo = null;
                            if (m_DamageInfos.TryGetValue(hit_player_id, out dmgInfo))
                            {
                                attack_inst.AddHurtInfo(dmgInfo);
                            }
                        }

                        m_HitEmits[hit_player_id] = new HitCacheInfo(m_SubEmitId);
                        m_SubEmitId++;
                    }
  
                    mLastThunderPlayer = hit_player_id;
                    HitPlayers.RemoveAt(0);
                }
                else// 此时表示闪电链的攻击结束了
                {
                    Destroy();
                }
            }
        }

        /// <summary>
        /// 添加伤害数据
        /// </summary>
        public void AddHurtInfo(Damage damageInfo)
        {
            m_DamageInfos[damageInfo.TargetID] = damageInfo;

            HitCacheInfo info;
            if (m_HitEmits.TryGetValue(damageInfo.TargetID, out info))
            {
                SkillAttackInstance attack_inst = EffectManager.GetInstance().GetAttackInstance(info.SubEmitID);
                if (attack_inst != null)
                {
                    attack_inst.AddHurtInfo(damageInfo);
                }
            }
        }

        /// <summary>
        /// 添加命中的死亡数据
        /// </summary>
        public void AddDeathInfo(SkillAttackInstance.DeathAppendInfo death_info)
        {
            m_DeathAppendInfos[death_info.Id] = death_info;

            HitCacheInfo info;
            if (m_HitEmits.TryGetValue(death_info.Id, out info))
            {
                SkillAttackInstance attack_inst = EffectManager.GetInstance().GetAttackInstance(info.SubEmitID);
                if (attack_inst != null)
                {
                    attack_inst.AddDeathInfo(death_info);
                }
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        void Destroy()
        {
            SkillAttackInst.DestroyAll();
            SkillAttackInst = null;

            foreach(var bullet_trace in m_TraceInsts)
            {
                var skill_attack_id = bullet_trace.SkillAttackId;
                var attack_instance = EffectManager.Instance.GetAttackInstance(skill_attack_id);
                if(attack_instance != null)
                {
                    attack_instance.DestroyAll();
                }
            }
            m_TraceInsts.Clear();

            // 有可能有没有表现的受击效果
            foreach (var damg in m_DamageInfos.Values)
            {
                if(damg != null)
                    damg.HitEffect();
            }
            m_DamageInfos.Clear();
            foreach (var item in m_DeathAppendInfos.Values)
            {
                if (item != null)
                {
                    Actor actor = ActorManager.Instance.GetActor(item.Id);
                    if(actor != null)
                        actor.Kill();
                }
            }
            m_DeathAppendInfos.Clear();
            m_SkillInfo = null;
            m_BulletInfo = null;
            HitPlayers.Clear();
            m_HitEmits.Clear();
        }
    }
}
