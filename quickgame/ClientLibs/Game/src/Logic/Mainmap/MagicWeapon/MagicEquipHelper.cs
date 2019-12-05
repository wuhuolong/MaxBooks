using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using xc.Equip;
using xc.ui.ugui;

namespace xc.Magic 
{
    [wxb.Hotfix]
    public class MagicEquipHelper
    {
        /// <summary>
        ///  获取法宝装备强化属性
        /// </summary>
        public static ActorAttribute GetStrengthAttr(uint strengthLv, GoodsMagicEquip equip)
        {
            ActorAttribute ret = new ActorAttribute();

            uint lv = strengthLv;
            if (lv > equip.MaxStrengthLv)
                lv = equip.MaxStrengthLv;

            string key = string.Format("{0}_{1}", (uint)equip.PosId, lv);
            List<string> rec = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_magic_goods_str", "csv_id", key, "str_attrs");
            if (rec.Count == 0)
                return ret;

            string raw = rec[0];
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");

            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                    ret.Add(attrId, attrValue);
                }
            }

            return ret;
        }

        /// <summary>
        /// 获取法宝穿戴中的装备列表
        /// </summary>
        public static List<GoodsMagicEquip> GetWearingEquipListByMagicId(uint magicId)
        {
            List<GoodsMagicEquip> ret = new List<GoodsMagicEquip>();

            foreach (var kv in ItemManager.Instance.WearingMagicEquip)
            {
                var equip = kv.Value;
                if (equip.MagicId == magicId)
                {
                    ret.Add(equip);
                }
            }

            return ret;
        }

        /// <summary>
        /// 获取法宝指定部位的穿戴中的法宝装备
        /// </summary>
        public static GoodsMagicEquip GetWearingEquipByMagicIdAndPosId(uint magicId, uint posId)
        {
            foreach (var kv in ItemManager.Instance.WearingMagicEquip)
            {
                var equip = kv.Value;
                if(equip.MagicId == magicId && equip.PosId == posId)
                {
                    return equip;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取法宝助战基础属性
        /// </summary>
        public static ActorAttribute GetMagicAssistBaseAtts(uint magicId)
        {
            ActorAttribute ret = new ActorAttribute();

            var magicInfo = DBMagic.Instance.GetData(magicId);
            if (magicInfo == null)
                return ret;

            foreach (var v in magicInfo.AssistAttrs)
            {
                ret.Add(v.attr_id, v.attr_num);
            }

            return ret;
        }

        /// <summary>
        /// 获取法宝助战属性（装备加成）
        /// </summary>
        public static ActorAttribute GetMagicAssistEquipsAddAttrs(uint magicId)
        {
            ActorAttribute ret = new ActorAttribute();

            foreach (var kv in ItemManager.Instance.WearingMagicEquip)
            {
                var equip = kv.Value;
                if (equip.MagicId == magicId)
                {
                    // 装备基础属性
                    foreach (var baseKv in equip.BasicAttrs)
                    {
                        ret.Add(baseKv.Key, baseKv.Value.Value);
                    }

                    // 装备强化属性
                    var strengthAttr = GetStrengthAttr(equip.StrengthLv, equip);

                    foreach (var strengthKv in strengthAttr)
                    {
                        ret.Add(strengthKv.Key, strengthKv.Value.Value);
                    }

                    // 装备附加属性
                    foreach (var appendKv in equip.AppendAttrs)
                    {
                        ret.Add(appendKv.Id, appendKv.Values[0]);
                    }
                }
            }

            return ret;
        }

        /// <summary>
        ///  获取法宝当前评分
        /// </summary>
        public static int GetMagicScore(uint magicId)
        {
            int ret = 0;

            // 法宝自身评分
            ret += DBMagic.Instance.GetMagicSelfScore(magicId);

            // 穿戴的各装备综合评分
            foreach (var kv in ItemManager.Instance.WearingMagicEquip)
            {
                var equip = kv.Value;
                if (equip.MagicId == magicId)
                {
                    ret += equip.Score;
                }
            }

            return ret;
        }

        /// <summary>
        /// 背包是否有指定法宝的特定装备可穿戴
        /// </summary>
        public static bool IsHaveMatchEquip(uint posId, uint color)
        {
            foreach (var kv in ItemManager.Instance.MagicEquipGoodsOids)
            {
                var equip = kv.Value;
                if (equip.PosId == posId && equip.color_type >= color)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取EquipAttributers结构属性描述字符串
        /// </summary>
        public static string GetEquipAttributesString(EquipAttributes attrs)
        {
            List<KeyValuePair<string, uint>> strColorPairs = new List<KeyValuePair<string, uint>>();
            strColorPairs.Clear();

            foreach (var kv in attrs)
            {
                uint color = 0;
                string des = EquipHelper.GetSubAttrDes(kv.Id, kv.Values, " +", out color);
                KeyValuePair<string, uint> strColorPair = new KeyValuePair<string, uint>(des, color);
                strColorPairs.Add(strColorPair);
            }

            string str = string.Empty;
            strColorPairs.Sort((a, b) =>
            {
                if (a.Value > b.Value)
                {
                    return -1;
                }
                else if (a.Value < b.Value)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            foreach (KeyValuePair<string, uint> strColorPair in strColorPairs)
            {
                str += strColorPair.Key + "\n";
            }
            
            if (str.Length > 0)
                str = str.Substring(0, str.Length - 1);

            return str;
        }

        public static void ShowMagicEquipTipsWindowLayer(int layer, GoodsMagicEquip equip, string showType)
        {
            // 经验道具部位Id
            uint expPos = xc.GameConstHelper.GetUint("GAME_MAGIC_EQUIP_EXP_POS");
            if (equip.PosId == expPos)
            {
                UIManager.Instance.ShowWindowLayer("UIGoodsTipsWindow", layer, equip, "Player");
            }
            else
            {
                UIManager.Instance.ShowWindowLayer("UIMagicWeaponTipsWindow", layer, equip, showType);
            }
        }

        public static void ShowMagicEquipTipsWindow(GoodsMagicEquip equip, string showType)
        {
            // 经验道具部位Id
            uint expPos = xc.GameConstHelper.GetUint("GAME_MAGIC_EQUIP_EXP_POS");
            if (equip.PosId == expPos)
            {
                UIManager.Instance.ShowWindow("UIGoodsTipsWindow", equip, showType);
            }
            else
            {
                UIManager.Instance.ShowWindow("UIMagicWeaponTipsWindow", equip, showType);
            }
        }

        /// <summary>
        /// 展示法宝装备Tips 
        /// </summary>
        /// <returns></returns>
        public static void ShowMagicEquipTipsWindow(GoodsMagicEquip equip, string showType, uint magicId)
        {
            // 经验道具部位Id
            uint expPos = xc.GameConstHelper.GetUint("GAME_MAGIC_EQUIP_EXP_POS");
            if (equip.PosId == expPos)
            {
                UIManager.Instance.ShowWindow("UIGoodsTipsWindow", equip, showType);
            }
            else
            {
                UIManager.Instance.ShowWindow("UIMagicWeaponTipsWindow", equip, showType, magicId);
            }
        }

        /// <summary>
        /// 根据typeId返回法宝装备背包总数量
        /// </summary>
        public static ulong GetGoodsNumForMagicEquipBagByTypeId(uint eid)
        {
            GoodsMagicEquip goods1 = null;
            List<ulong> oids = null;
            ulong num = 0;
            if (ItemManager.Instance.MagicEquipTypeIdAndOids.TryGetValue(eid, out oids) == true)
            {
                foreach (ulong oid in oids)
                {
                    if (ItemManager.Instance.MagicEquipGoodsOids.TryGetValue(oid, out goods1) == true)
                    {
                        num = num + goods1.num;
                    }
                }
            }
            return num;
        }
    }
}
