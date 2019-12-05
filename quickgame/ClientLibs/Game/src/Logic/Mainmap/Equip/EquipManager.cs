//#define SIMULATE_EQUIP_NET
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Net;
using xc.protocol;
using System.Collections;
using Utils;

namespace xc.Equip
{
    public class CEquipStarEventArgs : CEventBaseArgs
    {
        public EquipInfo Equip;
        public List<PkgGoodsGidnum> Materials;

        public CEquipStarEventArgs(EquipInfo equip, List<PkgGoodsGidnum> materials)
        {
            Equip = equip;
            Materials = materials;
        }
    }

    /// <summary>
    /// 装备管理器
    /// </summary>
    [wxb.Hotfix]
    public class EquipManager : Utils.Singleton<EquipManager>
    {

        /// <summary>
        /// 玩家背包
        /// key是物品id
        /// </summary>
        public Dictionary<ulong, EquipInfo> BagEquips { get; private set; }

        /// <summary>
        /// 玩家临时背包
        /// key是物品id
        /// </summary>
        public Dictionary<ulong, EquipInfo> TmpBagEquips { get; private set; }

        /// <summary>
        /// 玩家仓库
        /// key是物品id
        /// </summary>
        public Dictionary<ulong, EquipInfo> WarehouseEquips { get; private set; }

        /// <summary>
        /// 玩家回收站
        /// key是物品id
        /// </summary>
        public Dictionary<ulong, EquipInfo> TrashEquips { get; private set; }


        /// <summary>
        /// 玩家所有的装备
        /// key是物品id
        /// </summary>
        public Dictionary<ulong, EquipInfo> AllEquips { get; private set; }

        public EquipManager()
        {
            BagEquips = new Dictionary<ulong, EquipInfo>();
            TmpBagEquips = new Dictionary<ulong, EquipInfo>();
            WarehouseEquips = new Dictionary<ulong, EquipInfo>();
            TrashEquips = new Dictionary<ulong, EquipInfo>();


            AllEquips = new Dictionary<ulong, EquipInfo>();

            var game = Game.GetInstance();
//            game.SubscribeNetNotify(NetMsg.MSG_EQUIP_RESULT, HandleServerData);



#if SIMULATE_EQUIP_NET
//            new Timer(5, false, 5, (dt) => 
            {
                var pack = new S2CEquipPlayer();

                var equip = Simulate_CreateEquip(10001, 1);
                Simulate_AddBaseAttr(equip, GameConst.PL_ATTR_HURT_MIN, 110);
                Simulate_AddBaseAttr(equip, GameConst.PL_ATTR_HURT_MAX, 210);
                Simulate_AddBaseAttr(equip, GameConst.PL_ATTR_FREQ, 1100);

                Simulate_AddApAttr(equip, 10001, 15);
                Simulate_AddApAttr(equip, 10004, 11);
                Simulate_AddApAttr(equip, 10006, 5);

                pack.equips.Add(equip);
//                HandleEquipPlayer(pack);

//                var pack2 = new S2CEquipBag();

                equip = Simulate_CreateEquip(10002, 2);
                Simulate_AddBaseAttr(equip, GameConst.PL_ATTR_DEF, 120);

                Simulate_AddApAttr(equip, 10002, 15);
                Simulate_AddApAttr(equip, 10005, 11);
                Simulate_AddApAttr(equip, 10008, 5);

                pack.equips.Add(equip);
                HandleEquipPlayer(pack);
//                pack2.equips.Add(equip);

//                HandleEquipBag(pack2);
            };
#endif
        }

        public void Reset()
        {
            BagEquips.Clear();
            WarehouseEquips.Clear();
            TmpBagEquips.Clear();
            TrashEquips.Clear();

            AllEquips.Clear();
        }

        public EquipInfo GetEquipInfoByOid(ulong oid)
        {
            EquipInfo result = null;
            if (AllEquips.TryGetValue(oid, out result))
            {
                return result;
            }
                

            if (BagEquips.TryGetValue(oid, out result))
            {
                return result;
            }

            if (TmpBagEquips.TryGetValue(oid, out result))
            {
                return result;
            }

            if (WarehouseEquips.TryGetValue(oid, out result))
            {
                return result;
            }

            if (TrashEquips.TryGetValue(oid, out result))
            {
                return result;
            }

            return null;
        }

#if SIMULATE_EQUIP_NET
        private static uint SimualteIdGenerator = 1;

        private PkgEquipInfo Simulate_CreateEquip(uint eid, uint color)
        {
            var equip = new PkgEquipInfo();
            equip.oid = SimualteIdGenerator++;
            equip.eid = eid;
            equip.color = color;

            return equip;
        }

        private void Simulate_AddBaseAttr(PkgEquipInfo equip, uint attr_type, uint val)
        {
            var attr = new PkgEquipBaseAttr();
            attr.attr_id = attr_type;
            attr.val = val;

            equip.base_attrs.Add(attr);
        }

        private void Simulate_AddApAttr(PkgEquipInfo equip, uint attr_id, uint val)
        {
            var attr = new PkgEquipApAttr();
            attr.id = attr_id;
            attr.val = val;

            equip.ap_attrs.Add(attr);
        }
#endif
        

        /// <summary>
        /// 穿戴装备
        /// </summary>
        /// <param name="equip"></param>
        public void InstallEquip(EquipInfo equip)
        {
            if(LocalPlayerManager.Instance.InBallteStatus)
            {
                UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_58"));
                return;
            }

//            if(equip.Lv > LocalPlayerManager.instance.LocalActorAttribute.Level)
//            {
//                UINotice.instance.ShowMessage("无法装备,该装备等级超过玩家等级!");
//                return;
//            }
//
//            if (equip.HiLv > LocalPlayerManager.instance.LocalActorAttribute.HiLevel)
//            {
//                UINotice.instance.ShowMessage("无法装备,该装备巅峰等级超过玩家巅峰等级!");
//                return;
//            }
            var pack = new C2SEquipInstall();

            NetClient.GetBaseClient().SendData<C2SEquipInstall>(NetMsg.MSG_EQUIP_INSTALL, pack);
        }

        /// <summary>
        /// 脱下装备
        /// </summary>
        /// <param name="equip"></param>
        public void UnInstallEquip(EquipInfo equip)
        {
            if(LocalPlayerManager.Instance.InBallteStatus)
            {
                UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_59"));
                return;
            }
            
            var pack = new C2SEquipUninstall();

            NetClient.GetBaseClient().SendData<C2SEquipUninstall>(NetMsg.MSG_EQUIP_UNINSTALL, pack);
        }

        #region 网络消息处理

        public void HandleServerData(ushort protocol, byte[] data)
        {
            var pack = new S2CPackBase();

            switch (protocol)
            {
//                case NetMsg.MSG_EQUIP:
//                    {
//                        var pack2 = pack.DeserializePack<S2CEquip>(data);
//                        if (pack2.type == 1)
//                            HandleEquipBag(pack2.equips);
//                        if (pack2.type == 2)
//                        {
                            //更新当前是第几套装备
//                            InstalledEquips.EquipSchemeIndex = pack2.index;
//                            HandleEquipPlayer(pack2.equips);
//                        }
//                        else if (pack2.type == 3)
//                            HandleEquipWare(pack2.equips);
//                        else if (pack2.type == 4)
//                            HandleEquipChat(pack2.equips);
//                        else if (pack2.type == 5)
//                            HandleEquipTmpBag(pack2.equips);
//                        else if (pack2.type == 6)
//                            HandleTradingEquips(pack2.equips);
//                        break;
//                    }
//                case NetMsg.MSG_EQUIP_RESULT:
//                    {
//                        HandleEquipResult(pack.DeserializePack<S2CEquipResult>(data));
//                        break;
//                    }

            }
        }
        
        public bool IsEquipEidExist(uint eid)
        {
            return DBManager.GetInstance().GetDB<DBEquipMod>().GetModData(eid) != null;
        }

        /// <summary>
        /// 通过网络包创建装备信息
        /// </summary>
        /// <param name="net_info"></param>
        /// <returns></returns>
        public EquipInfo CreateEquipFromNet(PkgGoodsInfo net_info , uint bind = 0)
        {
            // pre check
            if (!IsEquipEidExist(net_info.gid))
            {
                GameDebug.LogWarning("装备Eid找不到：" + net_info.gid);
                return null;
            }

            var equip = new EquipInfo(net_info);
            equip.Bind = bind;
// 
//             foreach (var ap_attr in net_info.equip.effects)
//             {
//                 equip.EffectAttrs.Add(ap_attr.id, ap_attr.vals, ap_attr.ep_type);
//             }
// 
//             foreach (var base_attr in net_info.equip.base_attrs)
//             {
//                 equip.BasicAttrs.Add(base_attr.attr_id, base_attr.val, 0);
//             }
// 
//            
// 
//             equip.StrongLv = net_info.equip.sgth_lv;
//             equip.StrongAdd =  (float)net_info.equip.sgth_rate / 100.0f;//除100得到真实值
//             equip.StrongStar = EquipHelper.GetStrongStar(net_info.equip.sgth_rate , net_info.equip.sgth_lv);
//             equip.GemInfo = net_info.equip.gems;
//             equip.WashScore = net_info.equip.enchant_score;
// //            equip.ProtectedTime = net_info.protect_time;
//             equip.DisEnableTime = net_info.equip.disable_time;
            return equip;
        }


        /// <summary>
        /// 通过网络包更新现有装备
        /// </summary>
        /// <param name="equip"></param>
        /// <param name="net_info"></param>
        protected void UpdateEquipFromNet(EquipInfo equip, PkgGoodsInfo net_info)
        {
            equip.LegendAttrs.Clear();
//             foreach (var ap_attr in net_info.equip.effects)
//             {
//                 // 只更新附魔后的属性
//                 equip.EffectAttrs.Add(ap_attr.id, ap_attr.vals, ap_attr.ep_type);
//             }
// 
//             equip.BasicAttrs.Clear();
//             foreach (var base_attr in net_info.equip.base_attrs)
//             {
//                 equip.BasicAttrs.Add(base_attr.attr_id, base_attr.val , 0);
//             }
//             equip.Bind = net_info.bind;
//             equip.StrongLv = net_info.equip.sgth_lv;
//             equip.StrongAdd =  (float)net_info.equip.sgth_rate / 100.0f;//除100得到真实值
//             equip.StrongStar = EquipHelper.GetStrongStar(net_info.equip.sgth_rate , net_info.equip.sgth_lv);
//             equip.GemInfo = net_info.equip.gems;
//             equip.WashScore = net_info.equip.enchant_score;
// //            equip.ProtectedTime = net_info.protect_time;
//             equip.DisEnableTime = net_info.equip.disable_time;

            // 更新附魔状态
            //foreach (var ap_attr in net_info.ap_attrs)
            //{
            //    equip.EquipAttrs.SetEquipAttrEnchant(ap_attr.id, ap_attr.is_enc == 1);
            //}

            // FIXME 确定下更新装备信息时，其基础属性会不会变

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_EQUIP_INFO_CHANGED, new CEventBaseArgs(equip));

            if (equip.IsInstalled)
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTALLED_EQUIP_INFO_CHANGED, new CEventBaseArgs(equip));
        }

        /// <summary>
        /// 处理换装消息
        /// </summary>
        /// <param name="pack2"></param>
        protected void HandleEquipChangeAllResult(S2CEquipChangeAll pack2)
        {
//            if (pack2.type == 2)
//            {
//                InstalledEquips.RemoveAllEquips();
//                //更新当前是第几套装备
//                InstalledEquips.EquipSchemeIndex = pack2.index;
//                HandleEquipPlayer(pack2.equips);
//
//                for (int i = (int)EEquipPos.Weapon; i < (int)EEquipPos.TypeEnd; i++)
//                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_INSTALLED_EQUIP_CHANGED, new CEventBaseArgs((EEquipPos)i));
//
//
//            }
                
        }
        #endregion
    }
}
