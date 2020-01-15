using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
namespace xc
{
    public class DefaultActorAttribute : IActorAttribute
    {
        public uint Id {set;get;}
        private long _value = 0 ; 
        public long Value {
            set{
                _value = value;

                Name = string.Empty;

                var battle_power_info = DBBattlePower.Instance.GetBattlePowerInfo(Id);
                if (battle_power_info != null)
                {
                    // 获取装备评分
                    Score = (uint)Mathf.CeilToInt(_value * battle_power_info.equip_val);

                    // 根据不同的显示类型来计算最终的属性文本
                    var show_type = battle_power_info.show_type;
                    string desc = battle_power_info.desc;
                    OrigName = battle_power_info.name;
                    Desc = battle_power_info.tips_desc;

                    switch (show_type)
                    {
                        case 0:// 整形
                            {
                                string value_str = string.Format(": {0}", _value);
                                Name = string.Format(desc, value_str);
                                ValuesFormat = _value.ToString();
                            }
                            break;
                        case 1:// 浮点
                            {
                                string val = ((float)_value / ActorHelper.UnitConvert).ToString("0.00");
                                val = ActorUtils.Instance.TrimFloatStr(val);
                                string value_str = string.Format(": {0}", val);
                                Name = string.Format(desc, value_str);
                                ValuesFormat = val;
                            }
                            break;
                        case 2:// 百分比
                            {
                                string val_noSign = ((float)_value / ActorHelper.DisplayUnitConvert).ToString("0.00");
                                val_noSign = ActorUtils.Instance.TrimFloatStr(val_noSign);
                                string val = val_noSign + "%";
                                string value_str = string.Format(": {0}", val);
                                Name = string.Format(desc, value_str);
                                ValuesFormat = val;
                            }
                            break;
                    }
                }
            }
            get
            {
                return _value;
            }
        }

        /// <summary>
        /// 获得装备评分
        /// </summary>
        /// <returns></returns>
        public uint GetEquipScore()
        {
            return GetOtherScore("equip_val");
        }


        /// <summary>
        /// 获得强化评分
        /// </summary>
        /// <returns></returns>
        public uint GetEquipStrengthScore()
        {
            return GetOtherScore("equip_strength_val");
        }

        /// <summary>
        /// 获得强化评分
        /// </summary>
        /// <returns></returns>
        public uint GetEquipBaptizeScore()
        {
            return GetOtherScore("equip_baptize_val");
        }

        /// <summary>
        /// 获取各类型的战力系数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private uint GetOtherScore(string key)
        {
            uint score = 0;
            var battle_power_info = DBBattlePower.Instance.GetBattlePowerInfo(Id);
            if(battle_power_info != null)
            {
                if(key == "equip_val")
                {
                    score = (uint)Mathf.CeilToInt(_value * battle_power_info.equip_val);
                }
                else if(key == "equip_strength_val")
                {
                    score = (uint)Mathf.CeilToInt(_value * battle_power_info.equip_strength_val);
                }
                else if (key == "equip_baptize_val")
                {
                    score = (uint)Mathf.CeilToInt(_value * battle_power_info.equip_baptize_val);
                }
            }

            return score;
        }

        /// <summary>
        /// 属性的原始名字
        /// </summary>
        public string OrigName{set;get;}

        /// <summary>
        /// 格式化后的数值（包括百分号的显示等）
        /// </summary>
        public string ValuesFormat{set;get;}


        string nameShow = null;
        public string NameShow
        {
            get
            {
                if (nameShow == null)
                {
                    if (string.IsNullOrEmpty(Desc) == false && string.IsNullOrEmpty(Name) == false)
                    {
                        if (Desc.LastIndexOf("}") == Desc.Length - 1)
                            nameShow = Name;
                        else
                            nameShow = Name.Replace(":", "");
                    }
                    else
                    {
                        nameShow = "";
                    }
                }
                return nameShow;
            }
        }

        
        public bool IsMiddleDes
        {
            get
            {
                if (string.IsNullOrEmpty(Desc) == false)
                {
                    return Desc.LastIndexOf("}") != Desc.Length - 1;
                }
                else
                {
                    return false;
                }
            }
        }




        // <summary>
        /// 名字（包含属性名字和value）
        /// </summary>
        public string Name{set;get;}

        public string Desc{set;get;}
        public uint Score {set;get;}
        //public uint Type { set; get; }
        public DefaultActorAttribute(uint key , long ori_value)
        {
            Id = key;
            Value = ori_value;
        }
    }
}

