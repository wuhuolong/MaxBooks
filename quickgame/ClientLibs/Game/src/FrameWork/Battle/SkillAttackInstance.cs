//------------------------------------------------------------------------------
// File : SkillAttackInstance.cs
// Desc : 一次技能攻击的实例
// Autohr : raorui
// Date : 2016.10.10
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using Net;

namespace xc
{
    public class SkillAttackInstance
    {
        // 收到服务端死亡消息时，需要添加的信息
        public class DeathAppendInfo
        {
            public uint Id; // 死亡角色的id
            public Vector3 FlyDir; // 死亡后击飞的方向
        }

        /// <summary>
        /// 技能攻击的索引ID
        /// </summary>
        ulong mID;

        /// <summary>
        /// 技能信息
        /// </summary>
        DBSkillSev.SkillInfoSev m_SkillInfo;

        public UnitID SrcActorID
        {
            get { return m_SrcActorID; }
        }

        /// <summary>
        /// 技能释放者的ID
        /// </summary>
        UnitID m_SrcActorID;
        
        /// <summary>
        /// 总共的时间
        /// </summary>
        public float mfTimeCount;

        /// <summary>
        /// 前摇时间
        /// </summary>
        public float mForwardTime;

        public float mAttackSpeed = 1.0f;

        /// <summary>
        /// 经过的时间
        /// </summary>
        public float mfElapseTime;

        /// <summary>
        /// 闪电链命中玩家的列表信息
        /// </summary>
        protected ThunderHitInfo mThunderHitInfo;

        /// <summary>
        /// 技能造成的伤害信息
        /// </summary>
        protected List<Damage> mDamageInfos = new List<Damage>();

        /// <summary>
        /// 死亡的信息
        /// </summary>
        protected List<DeathAppendInfo> mDeaths = new List<DeathAppendInfo>();

        /// <summary>
        /// 掉落的信息
        /// </summary>
        protected List<S2CNwarDrop> mDrops = new List<S2CNwarDrop>();

        /// <summary>
        /// 子弹特效相关的组件
        /// </summary>
        SkillBaseComponent mEffectBaseComponent;

        /// <summary>
        /// 命中后的回调
        /// </summary>
        Action<SkillAttackInstance> m_HitCallback;

        /// <summary>
        /// 是否已经过了HitFrame帧
        /// </summary>
        bool m_HasHited = false;

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(ulong id, UnitID actor_id, DBSkillSev.SkillInfoSev skill_info, float forwardTime, float totalTime, float attack_speed, SkillBaseComponent AnimationTriggerOption, Action<SkillAttackInstance> hit_callback)
        {
            mID = id;
            m_SrcActorID = actor_id;
            m_SkillInfo = skill_info;
            mForwardTime = forwardTime;
            mfTimeCount = totalTime;
            if(mForwardTime > mfTimeCount)
            {
                mForwardTime = mfTimeCount;
                GameDebug.LogError("[SkillAttackInstance]前摇时间大于总时间");
            }
            mAttackSpeed = attack_speed;
            mfElapseTime = 0.0f;
            mEffectBaseComponent = AnimationTriggerOption;
            m_HitCallback = hit_callback;
            m_HasHited = false;
            Update();
        }

        /// <summary>
        /// 设置闪电链伤害的信息
        /// </summary>
        /// <param name="info"></param>
        public void SetThunderHitInfo(ThunderHitInfo info)
        {
            mThunderHitInfo = info;
        }

        /// <summary>
        /// 设置伤害数据
        /// </summary>
        public void AddHurtInfo(Damage damage_info)
        {
            // 如果有闪电链的伤害数据, 则将Damage信息截获
            if (mThunderHitInfo != null)
                mThunderHitInfo.AddHurtInfo(damage_info);
            else
            {
                mDamageInfos.Add(damage_info);
                if (m_HasHited)// 如果已经过了HitFrame，则直接表现伤害效果
                    OnDamage();
            }
        }

        /// <summary>
        /// 设置死亡数据
        /// </summary>
        public void AddDeathInfo(DeathAppendInfo info)
        {
            if (mThunderHitInfo != null)
                mThunderHitInfo.AddDeathInfo(info);
            else
            {
                mDeaths.Add(info);
                if (m_HasHited)// 如果已经过了HitFrame，则直接表现死亡效果
                    OnDeath();
            }
        }

        /// <summary>
        /// 设置掉落数据
        /// </summary>
        public void AddDropInfo(S2CNwarDrop info)
        {
            mDrops.Add(info);
            if (m_HasHited)// 如果已经过了HitFrame，则直接表现掉落效果
                OnCreateDrop();
        }

        public void OnHit()
        {
            if (m_HasHited)
                return;
            m_HasHited = true;

            OnDamage();
            OnDeath();
            OnCreateDrop();

            if (m_HitCallback != null)
                m_HitCallback(this);
        }

        /// <summary>
        /// 表示伤害飘字效果
        /// </summary>
        void OnDamage()
        {
            for (int i = 0; i < mDamageInfos.Count; ++i)
                mDamageInfos[i].HitEffect();
            mDamageInfos.Clear();
        }

        /// <summary>
        /// 表现死亡效果
        /// </summary>
        void OnDeath()
        {
            if (mDeaths.Count <= 0)
                return;

            // 计算死亡击飞的参数
            ActorMachine.DeathInfo deathInfo = new ActorMachine.DeathInfo();
            float flyAngle = 60;
            if (m_SkillInfo != null)
            {
                DBBattleFx.BattleFxInfo battleFxInfo = m_SkillInfo.BattleFxInfo;
                if (battleFxInfo != null)
                {
                    deathInfo.IsFlying = battleFxInfo.IsFlying;

                    // 计算移动的方向
                    flyAngle = battleFxInfo.FlyingAngle;

                    // 移动速度
                    deathInfo.MoveXSpeed = battleFxInfo.FlyingXSpeed;
                    deathInfo.MoveXFric = battleFxInfo.FlyingXFric;
                    deathInfo.MoveYSpeed = battleFxInfo.FlyingXSpeed * Mathf.Tan(battleFxInfo.FlyingAngle * DBActor.ANGLE_TO_RADIAN);
                }
            }

            // 表现死亡效果
            for (int i = 0; i < mDeaths.Count; ++i)
            {
                Actor act = ActorManager.Instance.GetPlayer(mDeaths[i].Id);
                if (act != null)
                {
                    // 玩家不被击飞
                    if (act is Player)
                        deathInfo.IsFlying = false;

                    if (deathInfo.IsFlying)
                    {
                        // 立即转向攻击者
                        act.TurnDir(-mDeaths[i].FlyDir);

                        // 计算移动的方向
                        Vector3 rightDir = Vector3.Cross(Vector3.up, mDeaths[i].FlyDir);
                        Vector3 dir = Quaternion.AngleAxis(-flyAngle, rightDir) * mDeaths[i].FlyDir;
                        deathInfo.MoveDir = dir.normalized;
                    }
                    act.ActorMachine.DeathFlyInfo = deathInfo;

                    act.Kill();
                }
            }
            mDeaths.Clear();
        }

        /// <summary>
        /// 表现拾取效果
        /// </summary>
        void OnCreateDrop()
        {
            foreach (S2CNwarDrop drop in mDrops)
            {
                xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
                if (curState is CommonInstanceState)
                {
                    var commstate = curState as CommonInstanceState;
                    //var pickDropBehaviour = commstate.GetComponent<xc.instance_behaviour.PickDropBehaviour>();
                    //if (pickDropBehaviour != null)
                    //{
                    //    //pickDropBehaviour.CreateDrops(drop.drops, 0, 0, 0, drop.pos);
                    //}
                }
            }
            mDrops.Clear();
        }

        // 更新逻辑
        public virtual void Update ()
        {
            if (mfElapseTime <= mfTimeCount)
            {
                if(mEffectBaseComponent != null)
                {
                    mfElapseTime += Time.deltaTime;
                    mEffectBaseComponent.UpdateCycle(mfElapseTime);
                }
                else
                {
                    mfElapseTime += Time.deltaTime * mAttackSpeed;
                    if (mfElapseTime >= mForwardTime)
                    {
                        OnHit();
                        //DestroyAll();
                    }
                }
            }
            else
            {
                DestroyAll();
            }
        }

        /// <summary>
        /// 销毁GameObject前要进行的操作
        /// </summary>
        public void DestroyAll()
        {
            mThunderHitInfo = null;
            m_HitCallback = null;
            m_SkillInfo = null;

            EffectManager.GetInstance().RemoveSkillInstance(mID);
            if(mEffectBaseComponent != null)
                mEffectBaseComponent.DestroyAll();
        }
    }
}

