//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xc
{
    [wxb.Hotfix]
    public class FightEffectPlayData
    {
//         public float NormalPlayTimeBySeconds = 1.0f;
         public float HurryPlayTimeBySeconds = 2.0f;

        public float NormalPlayDeltaTimeBySeconds = 0.5f;
        public float HurryPlayDeltaTimeBySeconds = 0.2f;

        public int NormalContainerSize = 20;
        public int HurryContainerSize = 20;
    }

    public class FightEffectHelp
    {
        public enum FightEffectPanelType
        {
            MonsterDamage = 1,
            PlayerDamage = 2,
            DamageEffect = 3,
            BuffTip = 4,
        }

        public enum FightEffectType
        {
            none,

            /// <summary>
            /// 技能伤害
            /// </summary>
            EnemyDamage,

            /// <summary>
            /// 魔仆伤害
            /// </summary>
            Attendant_damage,

            /// <summary>
            /// 暴击伤害
            /// </summary>
            CriticEnemyDamage,

            /// <summary>
            /// 魔仆暴击伤害
            /// </summary>
            CriticAttendantDamage,

            /// <summary>
            /// 自身伤害
            /// </summary>
            OurDamage,

            /// <summary>
            /// 伤害反弹
            /// </summary>
            BounceDamage,
            /// <summary>
            /// 闪避
            /// </summary>
            Dodge,
            /// <summary>
            /// 格挡
            /// </summary>
            Parry,
            /// <summary>
            /// 无敌
            /// </summary>
            Invincible,

            /// <summary>
            /// 移动加速
            /// </summary>
            Accelerate,

            /// <summary>
            /// 加血
            /// </summary>
            AddHp,
            AddMp,      //回蓝
            AddExp,     //经验获得
            AddSp,      //SP加成

            AttackSp,   //攻速(2017/8/18)
            Immune,     //免疫(2017/8/18)
            OneHitKill, //斩杀（2017/10/17）
            DamageDrain,    //伤害吸收(2018/1/3)

            AbsoluteDoge,  // 绝对闪避
            FollowAttack,  // 追命一击
        }


        static Dictionary<int/* FightEffectPanelType */, FightEffectPlayData> mFightEffectPlayDataMap;
        //static Dictionary<int/* FightEffectType */, int/* Level */> mFightEffectTypeLayoutMap;
        static DBFightEfffectLayout m_db_layout;
        public static FightEffectPlayData GetFightEffectPlayData(FightEffectPanelType type)
        {
            if (mFightEffectPlayDataMap == null)
            {
                mFightEffectPlayDataMap = new Dictionary<int, FightEffectPlayData>();
            }

            FightEffectPlayData result = null;
            if (!mFightEffectPlayDataMap.TryGetValue((int)type, out result))
            {
                result = new FightEffectPlayData();

                var list = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_fight_effect", "id", ((int)type).ToString());
                if (list.Count > 0)
                {
                    Dictionary<string, string> table = list[0];
//                     result.NormalPlayTimeBySeconds = float.Parse(table["normal_play_time"]);
                    result.HurryPlayTimeBySeconds = float.Parse(table["hurry_play_time"]);
                    result.NormalPlayDeltaTimeBySeconds = float.Parse(table["normal_play_delta_time"]);
                    result.HurryPlayDeltaTimeBySeconds = float.Parse(table["hurry_play_delta_time"]);
                    result.NormalContainerSize = int.Parse(table["normal_container_size"]);
                    result.HurryContainerSize = int.Parse(table["hurry_container_size"]);

                    mFightEffectPlayDataMap.Add((int)type, result);
                }
            }

            return result;
        }

        public static int GetLayoutLevel(FightEffectType type)
        {
            if(m_db_layout == null)
                m_db_layout = DBManager.Instance.GetDB<DBFightEfffectLayout>();
            int result = 0;
            var item = m_db_layout.GetOneItem(type.ToString());
            if (item != null)
                result = item.Level;
            return result;
        }

        /// <summary>
        /// 根据伤害类型获取特殊的战斗状态
        /// </summary>
        /// <param name="effect"></param>
        /// <returns></returns>
        public static FightEffectType GetFightEffectTypeByDamageEffect(Damage.EDamageEffect effect)
        {
            FightEffectType result = FightEffectType.none;
            switch (effect)
            {
                case Damage.EDamageEffect.DE_BLOCK:
                    result = FightEffectType.Parry;
                    break;
                case Damage.EDamageEffect.DE_CRITIC:
                    result = FightEffectType.CriticEnemyDamage;
                    break;
                case Damage.EDamageEffect.DE_DODGE:
                    result = FightEffectType.Dodge;
                    break;
                case Damage.EDamageEffect.DE_HP_STEAL:
                    result = FightEffectType.AddHp;
                    break;
                case Damage.EDamageEffect.DE_EN_STEAL:
                    result = FightEffectType.AddMp;
                    break;
                case Damage.EDamageEffect.DE_RE_HURT:
                    result = FightEffectType.BounceDamage;
                    break;
                case Damage.EDamageEffect.DE_HURT_RELIEF:
                    result = FightEffectType.DamageDrain;
                    break;
                case Damage.EDamageEffect.DE_EN_SHIELD:
                    //result = FightEffectType.Parry;(暂时不处理)
                    break;
                case Damage.EDamageEffect.DE_SUPER:
                    result = FightEffectType.Invincible;
                    break;
                case Damage.EDamageEffect.DE_KILL:
                    result = FightEffectType.OneHitKill;
                    break;
                case Damage.EDamageEffect.DE_ABSOLUTE_DOGE: // 绝对闪避
                    result = FightEffectType.AbsoluteDoge;
                    break;
                case Damage.EDamageEffect.DB_FOLLOW_ATTACK:// 追命一击
                    result = FightEffectType.FollowAttack;
                    break;
                default:
                    break;
            }

            return result;
        }

        public static void SetEffectValue(FightEffectType effectType, Text valueLabel, long value = 0, bool show_percent = false, string push_str = "")
        {
            bool must_be_damage = false;
            if(effectType == FightEffectType.BounceDamage)
            {
                must_be_damage = true;
                if (value > 0)
                    value = -value;
            }
            string value_string;
            if(show_percent)
            {
                if (value > 0)
                    value_string = string.Format("+{0}%", value);
                else
                    value_string = string.Format("{0}%", value);
            }
            else
            {
                if (value > 0)
                    value_string = string.Format("+{0}", value);
                else
                    value_string = string.Format("{0}", value);
            }
            
            switch (effectType)
            {
                //有数字，不包含“文字”
                case FightEffectType.EnemyDamage:   //技能伤害
                case FightEffectType.OurDamage:   //自身伤害
                case FightEffectType.BounceDamage:   //伤害反弹
                case FightEffectType.AddHp:   //加血
                case FightEffectType.AddMp:   //回蓝
                case FightEffectType.AddSp:   //SP获得
                    if (valueLabel != null)
                        valueLabel.text = value_string;
                    break;
                case FightEffectType.Attendant_damage:   //魔仆伤害
                    if (valueLabel != null)
                        valueLabel.text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_25") + value_string;// 印用来表示脚印图片
                    break;

                //有“文字”（不需要修改），有数字
                case FightEffectType.CriticEnemyDamage:   //暴击伤害
                case FightEffectType.CriticAttendantDamage:   //魔仆暴击伤害
                case FightEffectType.Accelerate:   //移动加速
                case FightEffectType.AddExp:   //经验获得
                case FightEffectType.AttackSp:  //攻速
                case FightEffectType.FollowAttack:  // 追命一击
                    if (valueLabel != null)
                        valueLabel.text = value_string;
                    break;

                //只有“文字”，不包含任何数字
                case FightEffectType.Dodge:   //闪避
                case FightEffectType.AbsoluteDoge: // 绝对闪避
                case FightEffectType.Parry:   //格挡
                case FightEffectType.Invincible:   //无敌
                case FightEffectType.Immune:  //免疫
                case FightEffectType.OneHitKill: //斩杀
                case FightEffectType.DamageDrain: //伤害吸收
                    break;
                default:
                    Debug.LogError(string.Format("undefined FightEffectType {0}", effectType.ToString()));
                    break;
            }

            if (push_str != null && push_str != "" && valueLabel != null)
                valueLabel.text = valueLabel.text + push_str;
        }

    }
}

