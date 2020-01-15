//-------------------------------------
// File: BagConditionHelper.cs
// Desc: 背包中物品是否满足某些条件的判断(给lua调用，在lua中遍历背包有较大的消耗)
// Author: raorui
// Date: 2018.11.12
//-------------------------------------
using System;
using System.Collections.Generic;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class BagConditionHelper
    {
        public static BagConditionHelper Instance
        {
            get
            {
                if (mInstacne == null)
                {
                    mInstacne = new BagConditionHelper();
                }

                return mInstacne;
            }
        }

        static BagConditionHelper mInstacne;

        /// <summary>
        /// 背包物品中所有宠物口粮提供的经验总值
        /// </summary>
        /// <param name="need_exp"></param>
        /// <returns></returns>
        public ulong GetPetTotalExp()
        {
            ulong total_exp = 0;
            foreach (var goods in ItemManager.Instance.BagGoodsOids.Values)
            {
                if (goods == null)
                    continue;

                if (goods is GoodsEquip) // 不需要判断装备物品
                    continue;

                if (goods.sub_type == GameConst.GIVE_SUB_TYPE_PET_EXP && goods.effect == "add_pet_exp") // 宠物口粮
                {
                    uint exp = 0;
                    uint.TryParse(goods.arg, out exp);
                    if (exp > 0)
                    {
                        total_exp = total_exp + exp * goods.num;
                    }
                }
            }

            return total_exp;
        }

        /// <summary>
        /// 背包物品中是否有提供经验的宠物口粮
        /// </summary>
        /// <returns></returns>
        public bool HasPetExpGoods()
        {
            foreach (var goods in ItemManager.Instance.BagGoodsOids.Values)
            {
                if (goods == null)
                    continue;

                if (goods is GoodsEquip) // 不需要判断装备物品
                    continue;

                if (goods.sub_type == GameConst.GIVE_SUB_TYPE_PET_EXP && goods.effect == "add_pet_exp") // 宠物口粮
                {
                    uint exp = 0;
                    uint.TryParse(goods.arg, out exp);
                    if (exp > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 返回可以自动吞噬的装备物品ID列表
        /// </summary>
        /// <returns></returns>
        public List<ulong> GetAutoSwallowEquipList()
        {
            List<ulong> list = new List<ulong>();
            foreach (var goods in ItemManager.Instance.BagGoodsOids.Values)
            {
                if (goods == null)
                    continue;

                //装备物品
                var equipGoods = goods as GoodsEquip;
                if (equipGoods == null)
                    continue;

                // 可以获取宠物经验的紫装及以下的装备
                if (equipGoods.Data.PetExp > 0 && equipGoods.color_type <= GameConst.QUAL_COLOR_PURPLE)
                {
                    // 是否是本职业装备
                    bool is_local_player_equip = false;
                    if (equipGoods.use_job == 0 || equipGoods.use_job == xc.LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
                        is_local_player_equip = true;

                    // 0星装备或者非本职业的装备可以自动吞噬
                    bool can_auto_swallow = true;
                    if (is_local_player_equip && equipGoods.Star > 0)
                        can_auto_swallow = false;

                    if (can_auto_swallow)
                        list.Add(equipGoods.id);
                }
            }

            return list;
        }

        const int equipCount = 3;
        List<uint> equipIds = new List<uint>(equipCount);

        /// <summary>
        /// 判断是否能合成装备
        /// </summary>
        /// <returns></returns>
        public bool CanComposeEquip(List<uint> needEquips1, List<uint> needEquips2, List<uint> needEquips3)
        {
            if (equipIds.Count != equipCount)
            {
                equipIds.Clear();
                for (int i = 0; i < equipCount; i++)
                {
                    equipIds.Add(0);
                }
            }
            else
            {
                for (int i = 0; i < equipCount; i++)
                {
                    equipIds[i] = 0;
                }
            }

            foreach (var goods in ItemManager.Instance.BagGoodsOids.Values)
            {
                if (goods == null)
                    continue;

                //装备物品
                var equipGoods = goods as GoodsEquip;
                if (equipGoods == null)
                    continue;

                if (needEquips1.Count > 0 && equipIds[0] == 0 && needEquips1.Contains(goods.type_idx))
                    equipIds[0] = goods.type_idx;
                else if (needEquips2.Count > 0 && equipIds[1] == 0 && needEquips2.Contains(goods.type_idx))
                    equipIds[1] = goods.type_idx;
                else if (needEquips3.Count > 0 && equipIds[2] == 0 && needEquips3.Contains(goods.type_idx))
                    equipIds[2] = goods.type_idx;

                if ((needEquips1.Count <= 0 || equipIds[0] != 0) && (needEquips2.Count <= 0 || equipIds[1] != 0) && (needEquips3.Count <= 0 || equipIds[2] != 0))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 背包物品中是否有增加货币的物品
        /// </summary>
        /// <returns></returns>
        public bool HasAddMoneyGoods(uint moneyId)
        {
            foreach (var goods in ItemManager.Instance.BagGoodsOids.Values)
            {
                if (goods == null)
                    continue;

                if (goods is GoodsEquip) // 不需要判断装备物品
                    continue;

                if ( goods.effect == "add_money") 
                {
                    List<uint> arg = DBTextResource.ParseArrayUint(goods.arg,",");
                    if(arg.Count >= 2)
                    {
                        if (moneyId == arg[0] && arg[1] > 0)
                            return true;
                    }
                }
            }

            return false;
        }


    }
}
