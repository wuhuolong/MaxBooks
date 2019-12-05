using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xc.Equip;

namespace xc.ElementEquip
{
    public class ElementEquipHelper
    {
        //public static bool CheckHadGoodsByPos(uint pos)
        //{
        //    foreach (var goods in ItemManager.Instance.ElementEquipGoodsOids)
        //    {
        //        if (goods.Value.PosId == pos)
        //            return true;
        //    }
        //    return false;
        //}

        //public static GoodsElementEquip GetWearingGoodsByPos(uint pos)
        //{
        //    foreach (var goods in ItemManager.Instance.InstallElementEquip)
        //    {
        //        if (goods.Value.PosId == pos)
        //            return goods.Value;
        //    }
        //    return null;
        //}

        //public static uint GetTotalExp()
        //{
        //    uint exp = 0;
        //    foreach (var goods in ItemManager.Instance.ElementEquipGoodsOids)
        //    {
        //        exp += goods.Value.Exp;
        //    }
        //    return exp;
        //}

        /// <summary>
        /// 有没有更好的装备可以穿
        /// </summary>
        /// <returns></returns>
        //public static GoodsElementEquip GetBestElementEquip()
        //{
        //    if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_ELEMENT_EQUIP, false) == false)
        //        return null;

        //    GoodsElementEquip intall_equip = null;
        //    uint lv = LocalPlayerManager.Instance.Level;
        //    for (int pos_id = 1; pos_id <= 6; pos_id ++)
        //    {
        //        intall_equip = ElementEquipHelper.GetWearingGoodsByPos((uint)pos_id);

        //        if (ItemManager.Instance.CheckHavePos(GameConst.GIVE_TYPE_ELEMENT_EP, (uint)pos_id))
        //            continue;


        //        foreach (GoodsElementEquip value in ItemManager.Instance.ElementEquipGoodsOids.Values)
        //        {
        //            if (ItemManager.Instance.mCloseQuickUseGoodsIdArray.ContainsKey(value.type_idx))
        //                continue;

        //            if (value.PosId == pos_id && lv >= value.use_lv)
        //            {
        //                if (intall_equip == null)
        //                {
        //                    intall_equip = value;
        //                }
        //                else
        //                {
        //                    if (value.Score > intall_equip.Score)
        //                    {
        //                        intall_equip = value;
        //                    }
        //                }
        //            }
        //        }
        //        if (intall_equip != null && intall_equip != ElementEquipHelper.GetWearingGoodsByPos((uint)pos_id))
        //        {
        //            return intall_equip;
        //        }
        //    }
        //    return null;
        //}

        /// <summary>
        /// 根据条件筛选背包中的元素装备并且排序
        /// </summary>
        /// <returns></returns>
        //public static List<GoodsElementEquip> GetSortedBagEquips(uint posId, int colorType, uint lvStep)
        //{
        //    List<GoodsElementEquip> result = new List<GoodsElementEquip>();
        //    foreach (GoodsElementEquip value in ItemManager.Instance.ElementEquipGoodsOids.Values)
        //    {
        //        if ((posId == 0 || value.PosId == posId) && (colorType == -1 || value.color_type == colorType) && (lvStep == 0 || value.LvStep == lvStep))
        //        {
        //            result.Add(value);
        //        }
        //    }
        //    result.Sort((a, b) =>
        //    {
        //        GoodsElementEquip installA = ElementEquipHelper.GetWearingGoodsByPos(a.PosId);
        //        bool isBetterA = installA == null || a.Score > installA.Score;
        //        GoodsElementEquip installB = ElementEquipHelper.GetWearingGoodsByPos(b.PosId);
        //        bool isBetterB = installB == null || b.Score > installB.Score;
        //        if (isBetterA && !isBetterB)
        //            return -1;
        //        else if (isBetterB && !isBetterA)
        //            return 1;
        //        if (a.sort_id < b.sort_id)
        //            return -1;
        //        else if (a.sort_id > b.sort_id)
        //            return 1;
        //        if (a.id < b.id)
        //            return -1;
        //        else if (a.id > b.id)
        //            return 1;
        //        return 0;
        //    });
        //    return result;
        //}

        /// <summary>
        /// 这个装备是否更好比身上的
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        //public static bool IsBetterElementEquip(GoodsElementEquip goods)
        //{
        //    if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_ELEMENT_EQUIP, false) == false)
        //        return false;

        //    GoodsElementEquip installEquip = ElementEquipHelper.GetWearingGoodsByPos(goods.PosId);
        //    if (installEquip == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return goods.Score > installEquip.Score;
        //    }
        //}

        /// <summary>
        /// 这个装备是否更好比身上的,并且能够快捷使用
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        //public static bool IsBetterElementEquipCanQuickUse(GoodsElementEquip goods)
        //{
        //    if (!IsBetterElementEquip(goods))
        //    {
        //        return false;
        //    }

        //    return LocalPlayerManager.Instance.Level >= goods.use_lv;
        //}

        const int equipCount = 3;
        static List<uint> equipIds = new List<uint>(equipCount);

        /// <summary>
        /// 检查身上的元素装备数量是否足够合成
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        //public static bool CheckCanCompose(List<uint> needEquips1, List<uint> needEquips2, List<uint> needEquips3)
        //{
        //    if (equipIds.Count != equipCount)
        //    {
        //        equipIds.Clear();
        //        for (int i = 0; i < equipCount; i++)
        //        {
        //            equipIds.Add(0);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < equipCount; i++)
        //        {
        //            equipIds[i] = 0;
        //        }
        //    }

        //    foreach (var goods in ItemManager.Instance.ElementEquipGoodsOids.Values)
        //    {
        //        if (goods == null)
        //            continue;

        //        //装备物品
        //        var equipGoods = goods as GoodsElementEquip;
        //        if (equipGoods == null)
        //            continue;

        //        if (needEquips1.Count > 0 && equipIds[0] == 0 && needEquips1.Contains(goods.type_idx))
        //            equipIds[0] = goods.type_idx;
        //        else if (needEquips2.Count > 0 && equipIds[1] == 0 && needEquips2.Contains(goods.type_idx))
        //            equipIds[1] = goods.type_idx;
        //        else if (needEquips3.Count > 0 && equipIds[2] == 0 && needEquips3.Contains(goods.type_idx))
        //            equipIds[2] = goods.type_idx;

        //        if ((needEquips1.Count <= 0 || equipIds[0] != 0) && (needEquips2.Count <= 0 || equipIds[1] != 0) && (needEquips3.Count <= 0 || equipIds[2] != 0))
        //            return true;
        //    }

        //    return false;
        //}

        /// <summary>
        /// 根据指定typeId返回oid Goods列表
        /// </summary>
        //public static Dictionary<ulong, GoodsElementEquip> GetElementEquipListForBagByTypeId(uint eid)
        //{
        //    Dictionary<ulong, GoodsElementEquip> goods_list = new Dictionary<ulong, GoodsElementEquip>();
        //    GoodsElementEquip goods = null;
        //    List<ulong> oids = new List<ulong>();
        //    if (ItemManager.Instance.ElementEquipTypeIdAndOids.TryGetValue(eid, out oids) == true)
        //    {
        //        foreach (ulong oid in oids)
        //        {
        //            if (ItemManager.Instance.ElementEquipGoodsOids.TryGetValue(oid, out goods) == true)
        //            {
        //                goods_list.Add(oid, goods);
        //            }
        //        }
        //        return goods_list;
        //    }
        //    else
        //        return null;
        //}

        /// <summary>
        /// 根据唯一id返回goods
        /// </summary>
        //public static GoodsElementEquip GetElementEquipForBagByOId(ulong oid)
        //{
        //    GoodsElementEquip goods = null;
        //    if (ItemManager.Instance.ElementEquipGoodsOids.TryGetValue(oid, out goods) == true)
        //    {
        //        return goods;
        //    }
        //    else
        //        return null;
        //}
    }
}
