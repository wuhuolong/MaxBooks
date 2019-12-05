//-----------------------------------
// File: MountEquipHelper.cs
// Desc: 坐骑装备工具类
// Author: luozhuocheng
// Date: 2018/9/7 14:03:15
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class MountEquipHelper
    {
        /// <summary>
        /// 根据 level 和 pos 来筛选 list
        /// </summary>
        /// <param name="level"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static List<GoodsMountEquip> GetFilterAndSortGoodsList(int level, int pos)
        {
            Dictionary<ulong, GoodsMountEquip> equip_dic = ItemManager.Instance.MountEquipGoodsOid;
            List<GoodsMountEquip> goods_list = new List<GoodsMountEquip>();
            foreach (GoodsMountEquip equip in equip_dic.Values)
            {
                equip.RefreshEquipUp();
                if ((equip.lv_step == level || level == 0) && (equip.pos_id == pos || pos == 0))
                    goods_list.Add(equip);
            }
            goods_list.Sort(SortFunc);
            return goods_list;
        }
        private static int SortFunc(GoodsMountEquip a, GoodsMountEquip b)
        {
            if (a.is_equipUp && b.is_equipUp == false)
                return -1;
            else if (a.is_equipUp == false && b.is_equipUp)
                return 1;
            if (a.sort_id < b.sort_id)
                return -1;
            else if (a.sort_id > b.sort_id)
                return 1;
            if (a.id < b.id)
                return -1;
            else if (a.id > b.id)
                return 1;
            return 0;
        }

        public static int GetMountLv()
        {
            int mountLv = (int)LocalPlayerManager.Instance.MountLv;
            return (mountLv - 1) / 10 + 1;
        }


        /// <summary>
        /// 有没有更好的装备可以穿
        /// </summary>
        /// <returns></returns>
        public static GoodsMountEquip GetBestMountEquip()
        {
            if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_MOUNT_EQUIP, false) == false)
                return null;

            GoodsMountEquip intall_equip = null;
            int mountLv = GetMountLv();
            List<uint> pos_list = DBMountEquipGoods.Instance.GetPosList();
            for (int i = 0; i < pos_list.Count; i++)
            {
                uint pos_id = pos_list[i];
                intall_equip = ItemManager.Instance.GetWearingMountEquipGoods(pos_id);

                if (ItemManager.Instance.CheckHavePos(GameConst.GIVE_TYPE_RIDE_EQUIP, pos_id))
                    continue;

                foreach (GoodsMountEquip value in ItemManager.Instance.MountEquipGoodsOid.Values)
                {
                    if (ItemManager.Instance.mCloseQuickUseGoodsIdArray.ContainsKey(value.type_idx))
                        continue;

                    if (value.pos_id == pos_id && value.lv_step <= mountLv)
                    {
                        if (intall_equip == null)
                        {
                            intall_equip = value;
                        }
                        else
                        {
                            if (value.Score > intall_equip.Score)
                            {
                                intall_equip = value;
                            }
                        }
                    }
                }
                if (intall_equip != null && intall_equip != ItemManager.Instance.GetWearingMountEquipGoods(pos_id))
                {
                    return intall_equip;
                }
            }
            return null;
        }


        /// <summary>
        /// 这个装备是否更好比身上的
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public static bool IsBetterMountEquip(GoodsMountEquip goods)
        {

            if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_MOUNT_EQUIP, false) == false)
                return false;


            int mountLv = GetMountLv();
            GoodsMountEquip mount_equip = ItemManager.Instance.GetWearingMountEquipGoods(goods.pos_id);
            if (mountLv >= goods.lv_step)
            {
                if (mount_equip == null)
                {
                    return true;
                }
                else
                {
                    if (goods.Score > mount_equip.Score)
                        return true;
                }

            }
            return false;
        }

    }
}
