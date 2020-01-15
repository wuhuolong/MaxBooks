using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xc.Equip;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsLightWeaponHelper
    {
        public static void AddInstalledSoul(GoodsLightWeaponSoul soul)
        {
            if (!ItemManager.Instance.InstalledLightWeaponSoul.ContainsKey(soul.Pos_Type))
                ItemManager.Instance.InstalledLightWeaponSoul[soul.Pos_Type] = new Dictionary<uint, GoodsLightWeaponSoul>();
            soul.IsWearing = true;
            ItemManager.Instance.InstalledLightWeaponSoul[soul.Pos_Type][soul.Pos_Index] = soul;
        }

        public static List<GoodsLightWeaponSoul> GetBagSortedSouls()
        {
            List<GoodsLightWeaponSoul> Sorted = ItemManager.Instance.LightWeaponGoodsOids.Values.ToList();
            Sorted.Sort(SortFunc);
            return Sorted;
        }

        public static int SortFunc(GoodsLightWeaponSoul a, GoodsLightWeaponSoul b)
        {
            if (a.Pos_Type == b.Pos_Type)
            {
                if (a.Pos_Index == b.Pos_Index)
                {
                    if (a.Score == b.Score)
                    {
                        if (a.color_type == b.color_type)
                        {
                            if (a.sort_id == b.sort_id)
                            {
                                return (int)(b.id - a.id);
                            }
                            return (int)b.sort_id - (int)a.sort_id;
                        }
                        else
                            return (int)b.color_type - (int)a.color_type;
                    }
                    else
                        return (int)b.Score - (int)a.Score;
                }
                else
                    return (int)a.Pos_Index - (int)b.Pos_Index;
            }
            else
                return (int)a.Pos_Type - (int)b.Pos_Type;
        }

        /// <summary>
        /// 获取对应光武类型上镶嵌的兵魂的所有属性
        /// </summary>
        /// <param name="Pos_Type"></param>
        /// <returns></returns>
        public static ActorAttribute GetTotalAttrs(uint Pos_Type)
        {
            ActorAttribute TotalAttr = new ActorAttribute();
            if (ItemManager.Instance.InstalledLightWeaponSoul.ContainsKey(Pos_Type))
            {
                foreach (var Souls in ItemManager.Instance.InstalledLightWeaponSoul[Pos_Type])
                {
                    foreach (var basicAttr in Souls.Value.BasicAttrs)
                    {
                        TotalAttr.Add(basicAttr.Key, basicAttr.Value.Value);
                    }

                    foreach (var upgradeAttr in Souls.Value.UpgradeAttrs)
                    {
                        TotalAttr.Add(upgradeAttr.Key, upgradeAttr.Value.Value);
                    }
                }

            }
            return TotalAttr;
        }

        /// <summary>
        /// 获取对应光武类型上的兵魂总等级
        /// </summary>
        /// <param name="Pos_Type"></param>
        /// <returns></returns>
        public static uint GetTotalLv(uint Pos_Type)
        {
            uint num = 0;
            if (ItemManager.Instance.InstalledLightWeaponSoul.ContainsKey(Pos_Type))
            {
                foreach (var Souls in ItemManager.Instance.InstalledLightWeaponSoul[Pos_Type])
                {
                    num += Souls.Value.Level;
                }
            }
            return num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pos_Type"></param>
        /// <param name="Pos_Index"></param>
        /// <returns></returns>
        public static bool HasInstalledSoul(uint Pos_Type, uint Pos_Index)
        {
            if (ItemManager.Instance.InstalledLightWeaponSoul.ContainsKey(Pos_Type))
            {
                if (ItemManager.Instance.InstalledLightWeaponSoul[Pos_Type].ContainsKey(Pos_Index))
                    return true;
                return false;
            }
            else
                return false;
        }

        public static GoodsLightWeaponSoul GetInstalledSoulByTypeAndIndex(uint Pos_Type, uint Pos_Index)
        {
            if (ItemManager.Instance.InstalledLightWeaponSoul.ContainsKey(Pos_Type))
                if (ItemManager.Instance.InstalledLightWeaponSoul[Pos_Type].ContainsKey(Pos_Index))
                    return ItemManager.Instance.InstalledLightWeaponSoul[Pos_Type][Pos_Index];
            return null;
        }

        public static Dictionary<uint, Dictionary<uint, GoodsLightWeaponSoul>> GetTheBestSouls()
        {
            Dictionary<uint, Dictionary<uint, GoodsLightWeaponSoul>> Best = new Dictionary<uint, Dictionary<uint, GoodsLightWeaponSoul>>();
            Dictionary<uint, Dictionary<uint, GoodsLightWeaponSoul>> BestInBag = new Dictionary<uint, Dictionary<uint, GoodsLightWeaponSoul>>();
            foreach (var soul in ItemManager.Instance.LightWeaponGoodsOids.Values)
            {
                if (!BestInBag.ContainsKey(soul.Pos_Type))
                    BestInBag[soul.Pos_Type] = new Dictionary<uint, GoodsLightWeaponSoul>();
                if (!BestInBag[soul.Pos_Type].ContainsKey(soul.Pos_Index))
                    BestInBag[soul.Pos_Type][soul.Pos_Index] = soul;
                if (soul.Score > BestInBag[soul.Pos_Type][soul.Pos_Index].Score)
                    BestInBag[soul.Pos_Type][soul.Pos_Index] = soul;
            }

            foreach (var soulDict in BestInBag.Values)
            {
                foreach (var Soul in soulDict.Values)
                {
                    if (HasInstalledSoul(Soul.Pos_Type, Soul.Pos_Index))
                    {
                        var InstalledSoul = ItemManager.Instance.InstalledLightWeaponSoul[Soul.Pos_Type][Soul.Pos_Index];
                        if (Soul.Score > InstalledSoul.Score)
                        {
                            if (!Best.ContainsKey(Soul.Pos_Type))
                                Best[Soul.Pos_Type] = new Dictionary<uint, GoodsLightWeaponSoul>();
                            Best[Soul.Pos_Type][Soul.Pos_Index] = Soul;
                        }
                    }
                    else
                    {
                        if (!Best.ContainsKey(Soul.Pos_Type))
                            Best[Soul.Pos_Type] = new Dictionary<uint, GoodsLightWeaponSoul>();
                        Best[Soul.Pos_Type][Soul.Pos_Index] = Soul;
                    }

                }
            }

            return Best;
        }
    }
}
