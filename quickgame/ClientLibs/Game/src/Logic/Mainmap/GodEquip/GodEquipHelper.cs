using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xc.ui.ugui;

namespace xc.GodEquip
{
    [wxb.Hotfix]
    public class GodEquipHelper
    {
        public static bool CheckHadGoodsByPos(uint pos)
        {
            foreach (var goods in ItemManager.Instance.GodEquipGoodsOids)
            {
                if (goods.Value.PosId == pos)
                    return true;
            }
            return false;
        }

        public static uint GetTotalExp()
        {
            uint exp = 0;
            foreach (var goods in ItemManager.Instance.GodEquipGoodsOids)
            {
                exp += goods.Value.SwallowedExpValue;
            }
            return exp;
        }

        public static uint GetExpByList(List<ulong> oids)
        {
            uint exp = 0;
            for (var i = 0; i < oids.Count; i++)
            {
                if (ItemManager.Instance.GodEquipGoodsOids.ContainsKey(oids[i]))
                {
                    exp += ItemManager.Instance.GodEquipGoodsOids[oids[i]].SwallowedExpValue;
                }
            }
            return exp;
        }



        /// <summary>
        /// 计算器灵的属性加成
        /// activeCount 激活的升华属性数量
        /// </summary>
        public static void ComputeAttribute(GoodsGodEquip goods, uint activeCount, ActorAttribute attr)
        {
            if (attr == null || goods == null)
            {
                return;
            }

            foreach (var baseAttr in goods.BasicAttrs)
            {
                attr.Add(baseAttr.Value.Id, baseAttr.Value.Value);
            }

            for (var i = 0; i < goods.ExtraAttrs.Count; i++)
            {
                if (i >= activeCount)
                {
                    break;
                }
                var extraAttr = goods.ExtraAttrs[i];
                if (extraAttr.Id > 0)
                {
                    attr.Add(extraAttr.Data.SubAttrId, extraAttr.Values[0]);
                }
            }
        }


        public static List<GoodsGodEquip> GetBagItemByFilter(uint pos, uint level, uint colorType, List<uint> showPos = null, bool isDescending = true)
        {
            List<GoodsGodEquip> list = new List<GoodsGodEquip>();
            List<GoodsGodEquip> listNotShow = new List<GoodsGodEquip>();
            GoodsGodEquip goods;
            foreach (var goodsItem in ItemManager.Instance.GodEquipGoodsOids)
            {
                goods = goodsItem.Value;

                if ((pos == 0 || goods.PosId == pos)
                    && (level == 0 || goods.Level == level)
                    && (colorType == 0 || goods.color_type == colorType))
                {
                    if (showPos == null || showPos.Contains(goods.PosId))
                    {
                        list.Add(goods);
                    }
                    else
                    {
                        listNotShow.Add(goods);
                    }
                }
            }
            //默认降序
            int sortParam = isDescending ? 1 : -1;
            list.Sort((goods1, goods2) => sortParam * SortFunc(goods1, goods2));
            listNotShow.Sort((goods1, goods2) => sortParam * SortFunc(goods1, goods2));
            list.AddRange(listNotShow);
            return list;
        }

        private static int SortFunc(GoodsGodEquip goods1, GoodsGodEquip goods2)
        {
            if (goods1.Score < goods2.Score)
                return 1;
            else if (goods1.Score > goods2.Score)
                return -1;
            return 0;
        }


        public static string GetAttrMacro(uint attr_id)
        {
            DBAttrs dbAttrs = DBManager.GetInstance().GetDB<DBAttrs>();
            DBAttrs.DBAttrsItem item = dbAttrs.GetOneItem(attr_id);
            if (item == null)
            {
                return "";
            }
            else
            {
                return item.Macro;
            }
        }

        public static void ShowGodEquipTipsWindowLayer(int layer, GoodsGodEquip godEquip, string showType)
        {
            uint expPos = xc.GameConstHelper.GetUint("GAME_GOD_EQUIP_EXP_POS");

            if (godEquip.PosId == expPos)
            {
                UIManager.Instance.ShowWindowLayer("UIGoodsTipsWindow", layer, godEquip, showType);
            }
            else
            {
                UIManager.Instance.ShowWindowLayer("UIGodEquipGoodsTipsWindow", layer, godEquip, showType);
            }
        }



        public static void ShowGodEquipTipsWindow(GoodsGodEquip godEquip, string showType)
        {
            uint expPos = xc.GameConstHelper.GetUint("GAME_GOD_EQUIP_EXP_POS");

            if (godEquip.PosId == expPos)
            {
                UIManager.Instance.ShowWindow("UIGoodsTipsWindow", godEquip, showType);
            }
            else
            {
                UIManager.Instance.ShowWindow("UIGodEquipGoodsTipsWindow", godEquip, showType);
            }
        }

        private static bool CheckPosOpen(uint pos)
        {
            object[] param = { pos };
            System.Type[] return_type = { typeof(bool) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "GodEquipManager_CheckPosOpen", param, return_type);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    bool a = (bool)objs[0];
                    return a;
                }
            }

            return false;
        }

        public static bool IsBetterGodEquip(GoodsGodEquip goods)
        {
            if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_GOD_EQUIP, false) == false)
                return false;

            if (!CheckPosOpen(goods.PosId))
            {
                return false;
            }

            GoodsGodEquip wearingGoods = GetWearingGodEquipGoodsByPos(goods.PosId);
            if(wearingGoods == null)
            {
                return true;
            }
            else
            {
                return goods.Score > wearingGoods.Score;
            }
        }

        //需求修改后 神兵pos是唯一的 可以所以直接用pos拿
        private static GoodsGodEquip GetWearingGodEquipGoodsByPos(uint pos)
        {
            foreach (var item in ItemManager.Instance.InstallGodEquip)
            {
                if (item.Value.PosId == pos)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public static GoodsGodEquip GetBestGoodsGodEquip()
        {
            if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_GOD_EQUIP, false) == false)
                return null;

            List<uint> posList = GetAllOpenPos();
            if (posList != null)
            {
                for (var i = 0; i < posList.Count; i++)
                {
                    uint pos = posList[i];
                    GoodsGodEquip wearing = GetWearingGodEquipGoodsByPos(pos);
                    GoodsGodEquip ret = null;


                    if (ItemManager.Instance.CheckHavePos(GameConst.GIVE_TYPE_GOD_EQUIP, (uint)pos))
                        continue;

                    foreach (var item in ItemManager.Instance.GodEquipGoodsOids)
                    {
                        if (ItemManager.Instance.mCloseQuickUseGoodsIdArray.ContainsKey(item.Value.type_idx))
                            continue;

                        if (item.Value.PosId == pos)
                        {
                            if(ret == null)
                            {
                                if(wearing == null || item.Value.Score > wearing.Score)
                                {
                                    ret = item.Value;
                                }
                            }else
                            {
                                if(item.Value.Score > ret.Score)
                                {
                                    ret = item.Value;
                                }
                            }
                        }
                    }
                    if(ret != null)
                    {
                        return ret;
                    }
                }
            }

            return null;

        }

        private static List<uint> GetAllOpenPos()
        {
            object[] param = { };
            System.Type[] return_type = { typeof(List<uint>) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "GodEquipManager_GetAllOpenPos", param, return_type);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    List<uint> a = (List<uint>)objs[0];
                    return a;
                }
            }
            return null;
        }
    }
}
