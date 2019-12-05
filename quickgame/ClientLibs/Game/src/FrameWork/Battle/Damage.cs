//----------------------------------------------
// Damage.cs
// 进行伤害数字的飘字、受击效果等的表现
// @raorui
// 2017.5.25
//----------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    [wxb.Hotfix]
    public class Damage
    {
        /// <summary>
        /// 伤害的攻击者(在同一函数中，需要进行缓存，避免多次从角色列表中获取)
        /// </summary>
        public Actor src
        {
            get
            {
                return ActorManager.Instance.GetPlayer(SrcID);
            }
        }

        /// <summary>
        /// 伤害的目标(在同一函数中，需要进行缓存，避免多次从角色列表中获取)
        /// </summary>
        public Actor target
        {
            get
            {
                return ActorManager.Instance.GetPlayer(TargetID);
            }
        }

        public uint SrcID;// 攻击者
        public uint TargetID;// 受击者
        
        public enum EDamageEffect //伤害类型
        {
            DE_BLOCK    = 1,// 招架,有部分伤害
            DE_CRITIC   = 2,// 暴击
            DE_DODGE    = 4,// 闪避,完全无伤害
            DE_HP_STEAL = 8,// 生命偷取
            DE_EN_STEAL = 16,// 能量偷取
            DE_RE_HURT  = 32,// 伤害反弹
            DE_HURT_RELIEF = 64,// 伤害吸收
            DE_EN_SHIELD = 128,// 能量盾吸收
            DE_SUPER = 256, // 无敌
            DE_KILL = 1024, //斩杀
            DE_ABSOLUTE_DOGE = 2048, // 绝对闪避
            DB_FOLLOW_ATTACK = 4096, // 追命一击
            DB_FIVE_ATTR = 8192, // 五行属性不足
            DE_NOHIT = DE_DODGE | DE_ABSOLUTE_DOGE | DB_FIVE_ATTR
        }
    
        public enum EBeattackState // 受击效果
        {
            BS_None = 0,  // 无效果
            BS_BendBack,  // 后仰（只有受击动作）
        }

        public EBeattackState BeattackState = EBeattackState.BS_None;

        public int DamageValue = 0;
        public uint DamageEffectType = 0; // 保存战斗时是否有躲闪、暴击和格挡的变量

        /// <summary>
        /// 特殊状态列表(k: 状态标识 v: 状态造成的伤害数值)
        /// </summary>
        public Dictionary<uint,int> DamageSpecs;

        /// <summary>
        /// 特殊状态列表(多段状态数值)
        /// </summary>
        List<Dictionary<uint, int>> mDamageSpecsSplitValues = null;

        public uint SkillID;// 攻击者使用的技能ID
        List<int> mDamageSplitValues = null;// 多段技能的伤害列表

        /// <summary>
        /// 是否已经表现过受击效果
        /// </summary>
        bool m_IsHited = false;

        public void HitEffect()
        {
            if (m_IsHited)
                return;

            m_IsHited = true;
            MainGame.HeartBehavior.StartCoroutine(HitEffectRoutine());
        }

        /// <summary>
        /// 进行命中效果的展示
        /// </summary>
        IEnumerator HitEffectRoutine()
        {
            DBSkillSev.SkillInfoSev skillInfo = DBSkillSev.Instance.GetSkillInfo(this.SkillID);
            if (skillInfo == null)
                yield break;

            // 普通伤害数值，如果有伤害分片，则将其添加到多段伤害的列表中
            if (mDamageSplitValues == null)
            {
                if(skillInfo.MultiHitRatios != null)
                {
                    mDamageSplitValues = new List<int>(skillInfo.MultiHitRatios.Count);
                    int leave_num = DamageValue;
                    for (int i = 0; i < skillInfo.MultiHitRatios.Count; ++i)
                    {
                        int show_damage = (int)(DamageValue * skillInfo.MultiHitRatios[i]);
                        if (i == (skillInfo.MultiHitRatios.Count - 1) && leave_num > show_damage)
                            show_damage = leave_num;//最后一下，弥补伤害；防止出现多段伤害：0 + 0，最终伤害是 1 的情况
                        mDamageSplitValues.Add(show_damage);
                        leave_num -= show_damage;
                    }
                }
                else
                {
                    mDamageSplitValues = new List<int>(1);
                    mDamageSplitValues.Add(DamageValue);
                }
            }

            // 特殊状态的伤害数值，如果有伤害分片，则将其添加到多段状态的列表中
            if (this.DamageSpecs != null && mDamageSpecsSplitValues == null)
            {
                if (skillInfo.MultiHitRatios != null)
                {
                    mDamageSpecsSplitValues = new List<Dictionary<uint, int>>();
                    for (int i = 0; i < skillInfo.MultiHitRatios.Count; ++i)
                    {
                        mDamageSpecsSplitValues.Add(new Dictionary<uint, int>());
                    }

                    // 需要进行合并处理的特殊状态(不进行分段显示)
                    Dictionary<uint, int> combineSpecValues = null;
                    foreach(var item in DamageSpecs)
                    {
                        if(DBDamageEffect.Instance.IsCombineValue(item.Key))
                        {
                            if (combineSpecValues == null)
                                combineSpecValues = new Dictionary<uint, int>();

                            combineSpecValues[item.Key] = item.Value;
                        }
                    }

                    //对每一个特殊状态进行分段处理
                    foreach (var item in DamageSpecs)
                    {
                        if (DBDamageEffect.Instance.IsCombineValue(item.Key))
                            continue;

                        uint state_type = item.Key;
                        int leave_num = item.Value;
                        for (int i = 0; i < skillInfo.MultiHitRatios.Count; ++i)
                        {
                            int show_damage = (int)(item.Value * skillInfo.MultiHitRatios[i]);
                            if (i == (skillInfo.MultiHitRatios.Count - 1) && leave_num > show_damage)
                                show_damage = leave_num;//最后一下，弥补伤害；防止出现多段伤害：0 + 0，最终伤害是 1 的情况

                            mDamageSpecsSplitValues[i].Add(state_type, show_damage);
                            leave_num -= show_damage;
                        }
                    }

                    // 将合并的伤害数值添加到最后
                    if(combineSpecValues != null && mDamageSpecsSplitValues.Count > 0)
                    {
                        var last = mDamageSpecsSplitValues.Count - 1;
                        var lastValues = mDamageSpecsSplitValues[last];
                        foreach(var item in combineSpecValues)
                            lastValues[item.Key] = item.Value;
                    }
                }
                else
                {
                    mDamageSpecsSplitValues = new List<Dictionary<uint, int>>(1);
                    mDamageSpecsSplitValues.Add(DamageSpecs);
                }
            }

            if (mDamageSplitValues.Count <= 0)
            {
                GameDebug.LogError("HitEffect is excute when splitvalues is empty.");
                yield break;
            }

            // 当前伤害数值
            int cur_damage_value = mDamageSplitValues[0];
            mDamageSplitValues.RemoveAt(0);

            // 当前特殊伤害效果数值
            var curSpecsValues = mDamageSpecsSplitValues[0]; ;
            mDamageSpecsSplitValues.RemoveAt(0);

            var src_actor = src;
            var target_actor = target;
            if (target_actor != null && target_actor.transform != null)
            {
                if ((this.DamageEffectType & (uint)Damage.EDamageEffect.DE_NOHIT) != 0) // 闪避
                {
                    if((this.DamageEffectType & (uint)Damage.EDamageEffect.DE_ABSOLUTE_DOGE) != 0)// 绝对闪避
                    {
                        target_actor.ShowDamageEffect(FightEffectHelp.FightEffectType.AbsoluteDoge, SrcID);
                    }
                    else if ((this.DamageEffectType & (uint)Damage.EDamageEffect.DE_DODGE) != 0)// 闪避
                    {
                        target_actor.ShowDamageEffect(FightEffectHelp.FightEffectType.Dodge, SrcID);
                    }
                    else if ((this.DamageEffectType & (uint)Damage.EDamageEffect.DB_FIVE_ATTR) != 0)// 五行属性不足
                    {
                        if(src_actor.IsLocalPlayer)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_FIVE_ATTR_NOENOUGH, null);
                        }
                    }
                }
                else
                {
                    // 攻击者进入战斗状态
                    if(src_actor != null)
                        src_actor.OnBattleTrigger();

                    // 伤害数字飘字
                    bool isCritic = (this.DamageEffectType & (uint)Damage.EDamageEffect.DE_CRITIC) != 0;
                    target_actor.DoDamage(SrcID, cur_damage_value, 0, isCritic, this.DamageEffectType);

                    // 受击效果飘字
                    if ((this.DamageEffectType == (uint)Damage.EDamageEffect.DE_BLOCK))//招架效果，需要显示伤害数字
                        BeattackedCtrl.ShowDamageEffect(this, (uint)Damage.EDamageEffect.DE_BLOCK, cur_damage_value);
                    else if ((this.DamageEffectType == (uint)Damage.EDamageEffect.DE_SUPER) )//无敌
                        BeattackedCtrl.ShowDamageEffect(this, (uint)Damage.EDamageEffect.DE_BLOCK, cur_damage_value);

                    // 附加伤害效果飘字
                    if (curSpecsValues != null)
                    {
                        foreach (var kv in curSpecsValues)
                            BeattackedCtrl.ShowDamageEffect(this, kv.Key, (int)kv.Value);
                    }

                    // 无敌类型不表现受击动作
                    if (this.DamageEffectType != (uint)Damage.EDamageEffect.DE_SUPER)
                        target_actor.Beattacked(this);

                    // 受击特效
                    if(!ShieldManager.Instance.IsHideBeattackEffect(src_actor, target_actor))
                    {
                        AnimationEffect.ResInitData effect_init_data = null;
                        if (skillInfo.BattleFxInfo != null)
                        {
                            effect_init_data = skillInfo.BattleFxInfo.BeattackEffectData;
                        }
                        else
                        {
                            effect_init_data = new AnimationEffect.ResInitData();
                            effect_init_data.BindNode = "root_node";
                            effect_init_data.FollowTarget = true;
                            effect_init_data.Effect = string.Format("{0}.prefab", GameConstHelper.GetString("GAME_COMMON_BEATTACK_EFFECT"));
                            effect_init_data.Audio = GameConstHelper.GetString("GAME_COMMON_BEATTACK_SOUND");
                            effect_init_data.EndTime = 3.0f;
                        }
                        target_actor.ShowDamageEffectModel(effect_init_data);
                    }
                }
            }

            if(mDamageSplitValues.Count > 0)
            {
                float delay = 0.1f;
                if (skillInfo.MultiHitDelayTimes != null)
                    delay = skillInfo.MultiHitDelayTimes[skillInfo.MultiHitRatios.Count - mDamageSplitValues.Count];
                float attackspeed = 1.0f;
                if (src_actor != null)
                    attackspeed = src_actor.AttackSpeed;
                yield return new SafeCoroutine.SafeWaitForSeconds(delay/attackspeed);
                SafeCoroutine.CoroutineManager.StartCoroutine(HitEffectRoutine());
            }
        }
    }
}

