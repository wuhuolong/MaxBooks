using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using xc;
using Net;
namespace xc.Equip
{
    [wxb.Hotfix]
    public class EquipHelper
    {

        public class EquipEffectWashSelectData
        {
            public List<uint> AttrCount = new List<uint>();
            public List<string> AttrLv = new List<string>();
        }

        public static EquipModData GetEquipModData(uint equip_id)
        {
            return DBManager.GetInstance().GetDB<DBEquipMod>().GetModData(equip_id);
        }

        public static EquipAttrData GetEquipAttrData(uint attr_id)
        {
            return DBManager.GetInstance().GetDB<DBEquipAttr>().GetAttrData(attr_id);
        }

        public static string GetEquipPosStr(uint pos)
        {
            DBEquipPos.DBEquipPosItem item = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
            if (item == null)
                return string.Empty;
            return item.Name;
        }

        public static string GetEquipPosEngraveAtrrsDesc(uint pos)
        {
            DBEquipPos.DBEquipPosItem item = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
            if (item == null)
                return string.Empty;
 
            return item.EngraveAtrrsDesc;
        }

        public static ActorAttribute GetEquipPosEngraveShowAttrs(uint pos)
        {
            ActorAttribute ret = new ActorAttribute();

            DBEquipPos.DBEquipPosItem item = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
            if (item == null)
                return ret;

            foreach (var id in item.EngraveShowAttrIds)
            {
                ret.Add(id, 0);
            }

            return ret;
        }

        /// <summary>
        /// 根据装备GID，得到装备名称
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static string GetEquipNameByGid(uint gid)
        {
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_ep", "gid", gid);

            if (dbs.Count <= 0)
            {
                return string.Empty;
            }

            var db = dbs[0];

            string raw = string.Empty;
            if (db.TryGetValue("name", out raw))
            {
                return raw;
            }

            return string.Empty;
        }
        /// <summary>
        /// 得到穿戴装备对应idx
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static uint GetInstallEquipIndex(GoodsEquip equip)
        {
            return 1;
        }
        /// <summary>
        /// 获得套装列表
        /// </summary>
        /// <returns></returns>
        public static List<EquipPosInfo> GetSuitInfos(uint suitLv = 0)
        {
            List<EquipPosInfo> infos = new List<EquipPosInfo>();
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                var info = ItemManager.Instance.StrengthInfos[i];
                uint pos = info.Pos;
                if (suitLv == 0 || (info.InstallPosEquip != null && info.InstallPosEquip.SuitLv == suitLv))
                {
                    DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
                    if (dbEquipPosItem != null)
                    {
                        if (dbEquipPosItem.CanSuit)
                        {
                            infos.Add(info);
                        }
                    }
                }
            }
            SortPosInfos(infos);
            return infos;
        }

        /// <summary>
        /// 获得宝石列表
        /// </summary>
        /// <returns></returns>
        public static List<EquipPosInfo> GetGemInfos()
        {
            List<EquipPosInfo> infos = new List<EquipPosInfo>();
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                var info = ItemManager.Instance.StrengthInfos[i];
                uint pos = info.Pos;
                DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
                if (dbEquipPosItem != null)
                {
                    if (dbEquipPosItem.CanInlay)
                    {
                        infos.Add(info);
                    }
                }
            }
            SortPosInfos(infos);
            return infos;
        }

        ///<summary>
        /// 获取铭刻部位信息列表
        /// </summary>
        public static List<EquipPosInfo> GetEngraveEquipPosInfoList()
        {
            List<EquipPosInfo> infos = new List<EquipPosInfo>();
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                var info = ItemManager.Instance.StrengthInfos[i];
                uint pos = info.Pos;
                DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
                if (dbEquipPosItem != null)
                {
                    if (dbEquipPosItem.CanEngrave)
                    {
                        infos.Add(info);
                    }
                }
            }

            SortPosInfos(infos);
            return infos;
        }

        /// <summary>
        /// 获取铭刻部位信息
        /// </summary>
        public static EquipPosInfo GetEngraveEquipPosInfo( uint equipPos )
        {
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                var info = ItemManager.Instance.StrengthInfos[i];
                if (info.Pos == equipPos)
                {
                    uint pos = info.Pos;
                    DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
                    if (dbEquipPosItem != null && dbEquipPosItem.CanEngrave)
                    {
                        return info;
                    }

                }
            }

            return null;
        }

        /// <summary>
        /// 排序部位
        /// </summary>
        /// <returns></returns>
        public static void SortBaptizePosInfos(List<EquipPosInfo> list)
        {
            list.Sort(
                delegate (EquipPosInfo a, EquipPosInfo b)
                {
                    if (a.BaptizeNeedLv < b.BaptizeNeedLv)
                        return -1;
                    else if (a.BaptizeNeedLv > b.BaptizeNeedLv)
                        return 1;
                    else
                    {
                        if (a.InstallPosEquip != null && b.InstallPosEquip == null)
                            return -1;
                        else if (a.InstallPosEquip == null && b.InstallPosEquip != null)
                            return 1;
                        else
                        {
                            if (a.SortId > b.SortId)
                                return 1;
                            else if (a.SortId < b.SortId)
                                return -1;
                            else
                            {
                                if (a.Index > b.Index)
                                    return 1;
                                else if (a.Index < b.Index)
                                    return -1;
                                else
                                    return 0;
                            }
                        }
                    }
                }
                );
        }

        /// <summary>
        /// 获得洗练列表
        /// </summary>
        /// <returns></returns>
        public static List<EquipPosInfo> GetBaptizeInfos()
        {
            List<EquipPosInfo> infos = new List<EquipPosInfo>();
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                var info = ItemManager.Instance.StrengthInfos[i];
                uint pos = info.Pos;
                DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
                if (dbEquipPosItem != null)
                {
                    if (dbEquipPosItem.CanBaptize)
                    {
                        infos.Add(info);
                    }
                }
            }
            SortBaptizePosInfos(infos);
            return infos;
        }


        /// <summary>
        /// 获得强化列表
        /// </summary>
        /// <returns></returns>
        public static List<EquipPosInfo> GetStrengthInfos()
        {
            List<EquipPosInfo> infos = new List<EquipPosInfo>();
            infos.Clear();
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                var info = ItemManager.Instance.StrengthInfos[i];
                uint pos = info.Pos;
                DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pos);
                if (dbEquipPosItem != null)
                {
                    if (dbEquipPosItem.CanStrength)
                    {
                        infos.Add(info);
                    }
                }
            }
            SortPosInfosForStrength(infos);
            return infos;
        }

        /// <summary>
        /// 排序部位
        /// </summary>
        /// <returns></returns>
        public static void SortPosInfos(List<EquipPosInfo> list)
        {
            list.Sort(
                delegate (EquipPosInfo a, EquipPosInfo b)
                {
                    if (a.InstallPosEquip != null && b.InstallPosEquip == null)
                        return -1;
                    else if (a.InstallPosEquip == null && b.InstallPosEquip != null)
                        return 1;
                    else
                    {
                        if (a.SortId > b.SortId)
                            return 1;
                        else if (a.SortId < b.SortId)
                            return -1;
                        else
                        {
                            if (a.Index > b.Index)
                                return 1;
                            else if (a.Index < b.Index)
                                return -1;
                            else
                                return 0;
                        }
                    }
                }
                );
        }

        /// <summary>
        /// 强化界面的排序部位
        /// </summary>
        /// <returns></returns>
        public static void SortPosInfosForStrength(List<EquipPosInfo> list)
        {
            list.Sort(
                delegate(EquipPosInfo a , EquipPosInfo b)
                {
                    if (a.InstallPosEquip != null && b.InstallPosEquip == null)
                        return -1;
                    else if (a.InstallPosEquip == null && b.InstallPosEquip != null)
                        return 1;
                    else
                    {
                        // 强化满级的要排后面
                        if (a.ReachMaxStrengthLv == true && b.ReachMaxStrengthLv == false)
                        {
                            return 1;
                        }
                        else if (a.ReachMaxStrengthLv == false && b.ReachMaxStrengthLv == true)
                        {
                            return -1;
                        }
                        else
                        {
                            // 可以强化(有小红点)的排前面
                            if (CheckEquipCanStrength(a.InstallPosEquip) == false && CheckEquipCanStrength(b.InstallPosEquip) == true)
                            {
                                return 1;
                            }
                            else if (CheckEquipCanStrength(a.InstallPosEquip) == true && CheckEquipCanStrength(b.InstallPosEquip) == false)
                            {
                                return -1;
                            }
                            else
                            {
                                if (a.SortId > b.SortId)
                                    return 1;
                                else if (a.SortId < b.SortId)
                                    return -1;
                                else
                                {
                                    if (a.Index > b.Index)
                                        return 1;
                                    else if (a.Index < b.Index)
                                        return -1;
                                    else
                                        return 0;
                                }
                            }
                        }
                    }
                }
                );
        }

        /// <summary>
        /// 得到装备表里面的bind状态
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static uint GetEquipDBInfoBindState(uint gid)
        {
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_ep", "gid", gid);

            if (dbs.Count <= 0)
            {
                return 0;
            }

            var db = dbs[0];

            string raw = string.Empty;
            if (db.TryGetValue("bind", out raw))
            {
                uint result = 0;
                uint.TryParse(raw, out result);
                return result;
            }

            return 0;
        }

        /// <summary>
        /// 根据装备GID，得到装备等级
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static uint GetEquipLevelByGid(uint gid)
        {
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_ep", "gid", gid);

            if (dbs.Count <= 0)
            {
                return 0;
            }

            var db = dbs[0];

            string raw = string.Empty;
            if (db.TryGetValue("init_lv", out raw))
            {
                uint result = 0;
                uint.TryParse(raw, out result);
                return result;
            }

            return 0;
        }

        public static uint GetEquipPosByGid(uint gid)
        {
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_ep", "gid", gid);

            if (dbs.Count <= 0)
            {
                return 0;
            }

            var db = dbs[0];

            string raw = string.Empty;
            if (db.TryGetValue("pos", out raw))
            {
                uint result = 0;
                uint.TryParse(raw, out result);
                return result;
            }

            return 0;
        }

        /// <summary>
        /// 根据装备名称，得到装备GID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static uint GetEquipGidByName(string name)
        {
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_ep", "name", name);

            if (dbs.Count <= 0)
            {
                return 0;
            }

            var db = dbs[0];

            string raw = string.Empty;
            if (db.TryGetValue("gid", out raw))
            {
                uint id = 0;
                uint.TryParse(raw, out id);
                return id;
            }

            return 0;
        }



        /// <summary>
        /// 根据模糊的名称得到匹配的装备GID合集
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<uint> GetGoodsGidByMurkyName(string name)
        {
            List<uint> ids = new List<uint>();

            var dbs = DBManager.Instance.QuerySqliteLikeKeyRow<string>(GlobalConfig.DBFile, "data_ep", "name", name);

            foreach (var item in dbs)
            {
                string raw = string.Empty;
                if (item.TryGetValue("gid", out raw))
                {
                    uint id = 0;
                    uint.TryParse(raw, out id);

                    ids.Add(id);
                }
            }

            return ids;
        }

        public static uint ChangeEquipPart(UnitID id , uint modelId , uint equipPos)
        {
            var actor = ActorManager.Instance.GetActor(id);
            if (actor == null)
                return 0;
            uint EquipModelChange = 0;

            if (actor.IsLocalPlayer == true)
            {
                AvatarProperty tempAvatarProperty = actor.mAvatarCtrl.GetLatestAvatartProperty();
                if (tempAvatarProperty != null)
                {
                    // 这里要拷贝一份AvatarProperty来保存换装前的信息，不然有可能在其他地方被修改
                    AvatarProperty oldAvatarProperty = new AvatarProperty(tempAvatarProperty);
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_EQUIP_FASHION_CHANGED, new CEventEventParamArgs(oldAvatarProperty, modelId, equipPos));
                }
            }

            if (equipPos == GameConst.POS_ARMOUR)
            {
                actor.mAvatarCtrl.ChangeEquipPart(DBAvatarPart.BODY_PART.BODY, modelId, actor.VocationID);
                EquipModelChange = modelId;
            }
            else if (equipPos == GameConst.POS_WEAPON)
            {
                actor.mAvatarCtrl.ChangeEquipPart(DBAvatarPart.BODY_PART.WEAPON, modelId, actor.VocationID);
                EquipModelChange = modelId;
            }
            else if (equipPos == GameConst.POS_WING)
            {
                actor.mAvatarCtrl.ChangeFashionPart(DBAvatarPart.BODY_PART.WING, modelId, actor.VocationID);
                EquipModelChange = modelId;
            }
            else if(equipPos == GameConst.POS_ELFIN)
            {
                actor.mAvatarCtrl.ChangeEquipPart(DBAvatarPart.BODY_PART.ELFIN, modelId, actor.VocationID);
                EquipModelChange = modelId;
            }
            return EquipModelChange;
        }

        /// <summary>
        /// 获得基础属性原始名字
        /// </summary>
        /// <param name="baseId"></param>
        /// <returns></returns>
        public static string GetEquipBaseAttrOri(uint baseId)
        {
            string str = string.Empty;
            var battle_power_info = DBBattlePower.Instance.GetBattlePowerInfo(baseId);
            if(battle_power_info != null)
            {
                str = battle_power_info.name;
            }

            if (str.Length == 2)
            {
                str = string.Format("{0}      {1}", str[0], str[1]);
            }

            return str;
        }

        /// <summary>
        /// 判断一个装备在加点合适的情况下是否可以穿戴
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool IsPlayerAllocationCanInstall(GoodsEquip equip)
        {
            bool isCan = false;
            if (equip.Data == null)
            {
                return false;
            }

            //转职等级限制
            object[] param = { };
            System.Type[] returnType = { typeof(int) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TransferMgr_GetTransferLevel", param, returnType);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    if ((int)objs[0] < equip.use_transfer)
                    {
                        return false;
                    }
                }
            }

            if ((equip.use_job == 0 || (equip.use_job == LocalPlayerManager.Instance.LocalActorAttribute.Vocation))
                         && (equip.use_lv <= LocalPlayerManager.Instance.LocalActorAttribute.Level)
                         && (equip.expire_time == 0 || equip.expire_time >= Game.Instance.ServerTime))
            {
                long count = 0;
                if(equip.Data.NeedARCON > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_CON].Value)
                    count = equip.Data.NeedARCON - LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_CON].Value;

                if (equip.Data.NeedARSTR > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_STR].Value)
                    count += equip.Data.NeedARSTR - LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_STR].Value;

                if (equip.Data.NeedARAGI > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_AGI].Value)
                    count += equip.Data.NeedARAGI - LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_AGI].Value;

                if (equip.Data.NeedARINT > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_INT].Value)
                    count += equip.Data.NeedARINT - LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_INT].Value;
                if (LocalPlayerManager.Instance.ReaminLvPoint >= count)
                    isCan = true;
            }

            if(equip.Data != null && equip.EquipPos == GameConst.POS_WING && equip.ExtraAttrs.Count == 0 && equip.Data.CanIdentify)
            {//未鉴定的翅膀一直不允许穿戴
                return false;
            }
            return isCan;
        }

        /// <summary>
        /// 弹出是否加点二次确认
        /// </summary>
        /// <param name="equip"></param>
        public static bool ShowInstallEquipAllocation(GoodsEquip equip , uint index)
        {
            bool iscan = IsPlayerAllocationCanInstall(equip);
            if (!iscan)
                return false;

            string conStr = "";
            if (equip.Data.NeedARCON > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_CON].Value)
            {
                var attr = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_CON] as DefaultActorAttribute;
                var detal = equip.Data.NeedARCON - attr.Value;
                conStr = string.Format(DBConstText.GetText("GAME_GOODS_INSTALL_ADD_POINT_1"), detal, attr.OrigName, GameConst.COLOR_BRIGHT_GREEN);
            }

            string strStr = "";
            if (equip.Data.NeedARSTR > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_STR].Value)
            {
                var attr = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_STR] as DefaultActorAttribute;
                var detal = equip.Data.NeedARSTR - attr.Value;
                strStr = string.Format(DBConstText.GetText("GAME_GOODS_INSTALL_ADD_POINT_1"), detal, attr.OrigName, GameConst.COLOR_BRIGHT_GREEN);
            }

            string agiStr = "";
            if (equip.Data.NeedARAGI > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_AGI].Value)
            {
                var attr = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_AGI] as DefaultActorAttribute;
                var detal = equip.Data.NeedARAGI - attr.Value;
                agiStr = string.Format(DBConstText.GetText("GAME_GOODS_INSTALL_ADD_POINT_1"), detal, attr.OrigName, GameConst.COLOR_BRIGHT_GREEN);
            }

            string intStr = "";
            if (equip.Data.NeedARINT > LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_INT].Value)
            {
                var attr = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_INT] as DefaultActorAttribute;
                var detal = equip.Data.NeedARINT - attr.Value;
                intStr = string.Format(DBConstText.GetText("GAME_GOODS_INSTALL_ADD_POINT_1"), detal, attr.OrigName, GameConst.COLOR_BRIGHT_GREEN);
            }

            if (conStr == "" && strStr == "" && agiStr == "" && intStr == "")
            {
                return false;
            }
            else
            {   //"穿戴该装备还需要{0}{1}{2}{3}是否立即分配{0}{1}{2}{3}穿戴装备？"
                string str = string.Format(DBConstText.GetText("GAME_GOODS_INSTALL_ADD_POINT_2"), conStr, strStr, agiStr, intStr);


                ui.UIWidgetHelp.Instance.ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel, "", str,
                    (param) =>
                    {
                        if (ItemManager.Instance.BagGoodsOids.ContainsKey(equip.id) == false)
                        {
                            return;
                        }
                        var isCan = IsPlayerAllocationCanInstall(equip);
                        if (!isCan)
                        {
                            UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_48"));
                            return;
                        }
                        var data = new C2SEquipUpAuto();
                        data.oid = equip.id;
                        data.index = index;
                        NetClient.GetBaseClient().SendData<C2SEquipUpAuto>(protocol.NetMsg.MSG_EQUIP_UP_AUTO, data);

                    }, null, null, null, xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel);
                return true;
            }

            
        }


        /// <summary>
        /// 这个装备是否穿上
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static bool EquipIsInstall(ulong oid)
        {
            if (ItemManager.Instance.InstallEquip.ContainsKey(oid))
                return true;
            else
                return false;
        }


        /// <summary>
        /// 获得该部位的装备
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static GoodsEquip EquipIsInstallByPos(uint pos , uint index)
        {
            GoodsEquip equip = null;

            foreach (var item in ItemManager.Instance.InstallEquip)
            {
                if (item.Value.EquipPos == pos && index == item.Value.Index)
                {
                    equip = item.Value;
                    break;
                }
            }
            return equip;
        }

        public static int GetStarAddEquip(ulong oid)
        {
            Goods goods = ItemManager.Instance.GetGoodsForAllByOId(oid);
            if (goods != null)
            {
                GoodsEquip goodsEquip = goods as GoodsEquip;
                if (goodsEquip != null)
                {
                    return GetStarAddEquip(goodsEquip);
                }
            }
            return 0;
        }

        /// <summary>
        /// 返回该装备星数
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static int GetStarAddEquip(GoodsEquip equip)
        {
            int star = 0;
            if (equip == null || equip.LegendAttrs == null)
            {
                return 0;
            }
            if (equip.ServerStar != 0xffffff)
                return (int)(equip.ServerStar);
            bool has_attrs = false;
            foreach (var kv in equip.LegendAttrs)
            {
                var attrData = GetEquipAttrData(kv.Id);
                if (attrData != null)
                {
                    EquipSubAttrData data = null;
                    if (DBManager.GetInstance().GetDB<DBEquipSubAttr>().EquipSubAttrDescs.TryGetValue(attrData.SubAttrId, out data))
                    {
                        has_attrs = true;
                        List<string> des_value = new List<string>();
                        for (int i = 0; i < data.DesType.Count; i++)
                        {
                            if (attrData.ColorType.Count > 4)
                            {
                                var valuerange = attrData.ColorType[3];
                                if (kv.Values[i] >= valuerange.Min)
                                {
                                    star++;//对应就是0~4品质
                                }
                            }
                        }
                    }
                }
                else
                {
                    GameDebug.LogError(string.Format("装备属性id（{0}）不存在！", kv.Id));
                }
            }
            if(has_attrs == false)
            {
                EquipModData mod_data = equip.Data;
                if (mod_data != null)
                {
                    star = (int)mod_data.DefaultStar;
                }
            }
            return star;
        }
        /// <summary>
        /// 找出身上穿的同部位装备
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static GoodsEquip GetInstallEquipByPos(uint pos)
        {
            if (ItemManager.Instance.InstallEquip.Count == 0)
                return null;
            List<GoodsEquip> equips = new List<GoodsEquip>();
            foreach (var kv in ItemManager.Instance.InstallEquip)
            {
                if (kv.Value.EquipPos == pos)
                {
                    equips.Add(kv.Value);
                }
            }


            if (equips.Count > 0)
                return equips[0];
            else
                return null;
        }

        /// <summary>
        /// 找出身上穿的同部位装备列表
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static List<GoodsEquip> GetInstallEquipListByPos(uint pos)
        {
            if (ItemManager.Instance.InstallEquip.Count == 0)
                return null;
            List<GoodsEquip> equips = new List<GoodsEquip>();
            equips.Clear();
            foreach (var kv in ItemManager.Instance.InstallEquip)
            {
                if (kv.Value.EquipPos == pos)
                {
                    equips.Add(kv.Value);
                }
            }

            return equips;
        }

        /// <summary>
        /// 判断一个装备本地玩家是否可用
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool CheckEquipCanInstall(GoodsEquip equip)
        {
            if (equip == null || equip.Data == null || xc.LocalPlayerManager.Instance.LocalActorAttribute == null)
                return false;
            var need_con = equip.Data.NeedARCON;
            var need_str = equip.Data.NeedARSTR;
            var need_agi = equip.Data.NeedARAGI;
            var need_int = equip.Data.NeedARINT;
            var _con = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_CON].Value;
            var _str = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_STR].Value;
            var _agi = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_AGI].Value;
            var _int = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_INT].Value;
            if (need_int > _int)
            {
                return false;
            }
            else if (need_agi > _agi)
            {
                return false;
            }
            else if (need_str > _str)
            {
                return false;
            }
            else if (need_con > _con)
            {
                return false;
            }
            else if (equip.use_job != 0 && equip.use_job != LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 根据装备得到该装备回收的得到的物品
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static Goods GetEquipRecycleRewardGoods(GoodsEquip equip)
        {

            List<Goods> recycleGoods = new List<Goods>();
            var data_ep = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_ep", "gid", equip.type_idx);
            if (data_ep.Count > 0)
            {
                Dictionary<string, string> table = data_ep[0];
                string raw = string.Empty;
                if (table.TryGetValue("recycle", out raw))
                {
                    raw = raw.Replace(" ", "");
                    var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
                    foreach (Match _match in matchs)
                    {
                        if (_match.Success)
                        {
                            uint goodsId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                            uint num = DBTextResource.ParseUI(_match.Groups[2].Value);
                            var _goods = new GoodsItem(goodsId);
                            _goods.num = num;
                            recycleGoods.Add(_goods);
                        }
                    }
                }
            }



            GoodsItem goods = null;
            if (recycleGoods.Count > 0)
            {
                goods = new GoodsItem(recycleGoods[0].type_idx);
                goods.num = recycleGoods[0].num;
            }
            return goods;
        }

        /// <summary>
        /// 封装一个list返回用于自定义处理(使用环境：洗练属性，套装属性；格式："{属性名} +{属性值}")
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static List<string> GetEquipCustomBaseDes(ActorAttribute attr)
        {
            List<string> strs = new List<string>();
            if (attr.ContainsKey(GameConst.AR_MIN_ATTACK_EQUIP) && attr.ContainsKey(GameConst.AR_MAX_ATTACK_EQUIP))
            {
                if (attr.GetAttr(GameConst.AR_MIN_ATTACK_EQUIP).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value)
                {
                    var str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_49"),  attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value);
                    strs.Add(str);
                }
                else
                {
                    var str = string.Format("攻击 +{0}-{1}", attr.GetAttr(GameConst.AR_MIN_ATTACK_EQUIP).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value);
                    strs.Add(str);
                }
                   
            }


            if (attr.ContainsKey(GameConst.AR_MIN_ATTACK_BASE) && attr.ContainsKey(GameConst.AR_MAX_ATTACK_BASE))
            {
                if (attr.GetAttr(GameConst.AR_MIN_ATTACK_BASE).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value)
                {
                    var str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_49"), attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value);
                    strs.Add(str);
                }
                else
                {
                    var str = string.Format("攻击 +{0}-{1}", attr.GetAttr(GameConst.AR_MIN_ATTACK_BASE).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value);
                    strs.Add(str);
                }
            }

            if (attr.ContainsKey(GameConst.AR_MIN_ATTACK) && attr.ContainsKey(GameConst.AR_MAX_ATTACK))
            {
                if (attr.GetAttr(GameConst.AR_MIN_ATTACK).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK).Value)
                {
                    var str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_49"), attr.GetAttr(GameConst.AR_MAX_ATTACK).Value);
                    strs.Add(str);
                }
                else
                {
                    var str = string.Format("攻击 +{0}-{1}", attr.GetAttr(GameConst.AR_MIN_ATTACK).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK).Value);
                    strs.Add(str);
                }
            }

            foreach (var item in attr)
            {
                if (item.Key != GameConst.AR_MIN_ATTACK_EQUIP && item.Key != GameConst.AR_MAX_ATTACK_EQUIP
                    && item.Key != GameConst.AR_MIN_ATTACK && item.Key != GameConst.AR_MAX_ATTACK
                    && item.Key != GameConst.AR_MIN_ATTACK_BASE && item.Key != GameConst.AR_MAX_ATTACK_BASE)
                {
                    if (item.Value is DefaultActorAttribute)
                    {
                        var DefaulAttr = item.Value as DefaultActorAttribute;
                        strs.Add(string.Format("{0} +{1}", DefaulAttr.OrigName, DefaulAttr.ValuesFormat));
                    }
                }
            }
            return strs;
        }

        /// <summary>
        /// 获得装备基础属性描述（把物攻法功合并）
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static string GetEquipBaseDes(ActorAttribute attr, string color)
        {
            string str = string.Empty;
            if (attr.ContainsKey(GameConst.AR_MIN_ATTACK_EQUIP) && attr.ContainsKey(GameConst.AR_MAX_ATTACK_EQUIP))
            {

                if (color.CompareTo(string.Empty) == 0)
                {
                    if (attr.GetAttr(GameConst.AR_MIN_ATTACK_EQUIP).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value)
                        str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_51"), attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value);
                    else
                        str = string.Format("攻击 {0}-{1}\n", attr.GetAttr(GameConst.AR_MIN_ATTACK_EQUIP).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value);
                }
                else
                {
                    if (attr.GetAttr(GameConst.AR_MIN_ATTACK_EQUIP).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value)
                        str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_53"), color, attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value);
                    else
                        str = string.Format("{0}攻击 {1}-{2}</color>\n", color, attr.GetAttr(GameConst.AR_MIN_ATTACK_EQUIP).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK_EQUIP).Value);
                }
            }


            if (attr.ContainsKey(GameConst.AR_MIN_ATTACK) && attr.ContainsKey(GameConst.AR_MAX_ATTACK))
            {
                if (color.CompareTo(string.Empty) == 0)
                {
                    if (attr.GetAttr(GameConst.AR_MIN_ATTACK).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK).Value)
                        str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_51"), attr.GetAttr(GameConst.AR_MAX_ATTACK).Value);
                    else
                        str = string.Format("攻击 {0}-{1}\n", attr.GetAttr(GameConst.AR_MIN_ATTACK).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK).Value);
                }
                else
                {
                    if (attr.GetAttr(GameConst.AR_MIN_ATTACK).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK).Value)
                        str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_53"), color, attr.GetAttr(GameConst.AR_MAX_ATTACK).Value);
                    else
                        str = string.Format("{0}攻击 {1}-{2}</color>\n", color, attr.GetAttr(GameConst.AR_MIN_ATTACK).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK).Value);
                }
            }


            if (attr.ContainsKey(GameConst.AR_MIN_ATTACK_BASE) && attr.ContainsKey(GameConst.AR_MAX_ATTACK_BASE))
            {
                if (color.CompareTo(string.Empty) == 0)
                {
                    if (attr.GetAttr(GameConst.AR_MIN_ATTACK_BASE).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value)
                        str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_51"),  attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value);
                    else
                        str = string.Format("攻击 {0}-{1}\n", attr.GetAttr(GameConst.AR_MIN_ATTACK_BASE).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value);
                }
                else
                {
                    if (attr.GetAttr(GameConst.AR_MIN_ATTACK_BASE).Value == attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value)
                        str = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_53"), color,  attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value);
                    else
                        str = string.Format("{0}攻击 {1}-{2}</color>\n", color, attr.GetAttr(GameConst.AR_MIN_ATTACK_BASE).Value, attr.GetAttr(GameConst.AR_MAX_ATTACK_BASE).Value);

                }
            }

            foreach (var item in attr)
            {
                if (item.Key != GameConst.AR_MIN_ATTACK_EQUIP && item.Key != GameConst.AR_MAX_ATTACK_EQUIP
                    && item.Key != GameConst.AR_MIN_ATTACK && item.Key != GameConst.AR_MAX_ATTACK
                    && item.Key != GameConst.AR_MIN_ATTACK_BASE && item.Key != GameConst.AR_MAX_ATTACK_BASE)
                {
                    if (item.Value is DefaultActorAttribute)
                    {
                        var DefaulAttr = item.Value as DefaultActorAttribute;
                        if (color.CompareTo(string.Empty) == 0)
                        {

                            str += DefaulAttr.Name + "\n";
                        }
                        else
                        {
                            str += color + DefaulAttr.Name + "</color>\n";
                        }
                    }
                }
            }
            return str;
        }

        public class AttributeDescItem
        {
            public string PropName;
            public string ValueStr;
            public uint PropSortId;
            public bool IsMiddle;
        }
        /// <summary>
        /// 获得装备基础属性描述（把物攻法功合并）
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static List<AttributeDescItem> GetEquipBaseDesItemArray(ActorAttribute attr, bool needSort = true)
        {
            List<AttributeDescItem> descItemArray = new List<AttributeDescItem>();
            DBAttrs dbAttrs = DBManager.GetInstance().GetDB<DBAttrs>();
            DBAttrs.DBAtkGroupItem atkGroupItem = dbAttrs.GetAtkGroupItem(attr);
            if (atkGroupItem != null)
            {
                AttributeDescItem tmp_AttributeDescItem = new AttributeDescItem();
                tmp_AttributeDescItem.PropName = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_55"));
                tmp_AttributeDescItem.PropSortId = atkGroupItem.ItemArray[0].Id;
                long value0 = attr.GetAttr(atkGroupItem.ItemArray[0].Id).Value;
                long value1 = attr.GetAttr(atkGroupItem.ItemArray[1].Id).Value;
                tmp_AttributeDescItem.ValueStr = dbAttrs.GetGroupStr(value0, value1);
                descItemArray.Add(tmp_AttributeDescItem);
            }

            foreach (var item in attr)
            {
                if (!dbAttrs.IsAtkGroupAttr(item.Key) && item.Value is DefaultActorAttribute)
                {
                    var DefaulAttr = item.Value as DefaultActorAttribute;
                    AttributeDescItem tmp_AttributeDescItem = new AttributeDescItem();
                    tmp_AttributeDescItem.IsMiddle = DefaulAttr.IsMiddleDes;
                    if (DefaulAttr.IsMiddleDes)
                    {
                        tmp_AttributeDescItem.PropName = DefaulAttr.Desc;
                        tmp_AttributeDescItem.ValueStr = DefaulAttr.ValuesFormat;
                    }
                    else
                    {
                        tmp_AttributeDescItem.PropName = DefaulAttr.OrigName;
                        tmp_AttributeDescItem.ValueStr = DefaulAttr.ValuesFormat;
                    }

                    tmp_AttributeDescItem.PropSortId = item.Key;
                    descItemArray.Add(tmp_AttributeDescItem);
                }
            }

            if (needSort)
            {
                descItemArray.Sort((a, b) =>
                {
                    if (a.PropSortId < b.PropSortId)
                        return -1;
                    else if (a.PropSortId > b.PropSortId)
                        return 1;
                    return 0;
                });
            }
            
            return descItemArray;
        }

        /// <summary>
        /// 获取背包里面指定品质和阶数的装备
        /// </summary>
        /// <param name="color"></param>
        /// <param name="lvStep"></param>
        /// <returns></returns>
        public static Dictionary<ulong, Goods> GetBagEquipsOidsByColorAndLvStep(uint color, uint lvStep)
        {
            Dictionary<ulong, Goods> bagGoodsOids = new Dictionary<ulong, Goods>();
            bagGoodsOids.Clear();

            foreach (KeyValuePair<ulong, Goods> kv in ItemManager.Instance.BagGoodsOids)
            {
                Goods goods = kv.Value;
                GoodsEquip goodsEquip = goods as GoodsEquip;
                if (goodsEquip != null && goodsEquip.color_type == color && goodsEquip.LvStep == lvStep)
                {
                    bagGoodsOids.Add(kv.Key, goods);
                }
            }

            return bagGoodsOids;
        }

        /// <summary>
        /// 获取背包里面指定id和星级的装备
        /// </summary>
        public static Dictionary<ulong, Goods> GetBagEquipsByIdsAndStar(XLua.LuaTable idTable, uint star)
        {
            Dictionary<ulong, Goods> bagEquips = new Dictionary<ulong, Goods>();
            bagEquips.Clear();
            List<uint> idList = XLua.XUtils.CreateListByLuaTable<uint, uint>(idTable);
            if (idList == null || idList.Count == 0)
            {
                return bagEquips;
            }
            foreach (KeyValuePair<ulong, Goods> kv in ItemManager.Instance.BagGoodsOids)
            {
                Goods goods = kv.Value;
                GoodsEquip goodsEquip = goods as GoodsEquip;
                if (goodsEquip != null && idList.Contains(goodsEquip.Data.Id) && goodsEquip.Star == star)
                {
                    bagEquips.Add(kv.Key, goods);
                }
            }
            return bagEquips;
        }

        #region 合成相关接口
        /// <summary>
        /// 获得合成所需的货币
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static Dictionary<uint, uint> GetComposeMoney(uint gid)
        {
            Dictionary<uint, uint> moneys = new Dictionary<uint, uint>();
            List<string> data_goods_compose = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_goods_compose", "gid", gid.ToString(), "cost_moneys");
            if (data_goods_compose.Count == 0)
                return moneys;
            string raw = data_goods_compose[0];
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint moneyid = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint moneynum = DBTextResource.ParseUI(_match.Groups[2].Value);
                    moneys.Add(moneyid, moneynum);
                }
            }
            return moneys;
        }


        /// <summary>
        /// 根据id获得该物品所需的材料
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static List<Goods> GetComposeStuffs(uint gid)
        {
            List<Goods> stuffs = new List<Goods>();
            List<string> data_goods_compose = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_goods_compose", "gid", gid.ToString(), "cost_goods");
            if (data_goods_compose.Count == 0)
                return stuffs;
            string raw = data_goods_compose[0];
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint goodsid = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    uint goodsnum = DBTextResource.ParseUI(_match.Groups[2].Value);
                    Goods goods = GoodsFactory.Create(goodsid, null);
                    goods.num = goodsnum;
                    stuffs.Add(goods);
                }
            }
            return stuffs;
        }
        #endregion

        #region 装备宝石相关接口
        /// <summary>
        /// 获得下个等级宝石
        /// </summary>
        /// <param name="currentTypeId"></param>
        /// <returns></returns>
        public static GoodsLuaEx GetGemNextGems(uint currentTypeId)
        {
            uint nextGemId = 0;
            DBGem.GemInfo gemInfo = DBManager.Instance.GetDB<DBGem>().GetGemInfo(currentTypeId);
            if (gemInfo != null)
            {
                nextGemId = gemInfo.NextGemId;
            }
            else
            {
                return null;
            }
            if (nextGemId == 0)
                return null;

            var lua_script = string.Format("Model.Goods.GoodsGem");
            GoodsLuaEx goods = null;
            if (LuaScriptMgr.Instance.IsLuaScriptExist(lua_script))
            {
                goods = new GoodsLuaEx(nextGemId, lua_script);
            }
            return goods;
        }

        /// <summary>
        /// 获取宝石类型名字
        /// </summary>
        /// <param name="hole"></param>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static string GetGemTypeNameByHole(uint hole, GoodsEquip equip)
        {
            string name = "";
            var list = GetGemTypeHole(hole, equip);
            if (list == null || list.Count == 0)
                return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_56");
            else
            {
                var type = list[0];
                List<DBGem.GemInfo> gemInfos = DBManager.Instance.GetDB<DBGem>().GetGemInfosByType((byte)type);
                if (gemInfos != null && gemInfos.Count > 0)
                {
                    ushort lv = 0;
                    foreach (DBGem.GemInfo gemInfo in gemInfos)
                    {
                        ushort _lv = gemInfo.Lv;
                        if (lv == 0)
                            lv = _lv;
                        else
                        {
                            if (_lv > lv)
                            {
                                lv = _lv;
                                name = gemInfo.TypeName;
                            }

                        }
                    }
                }
                else
                {
                    return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_56");
                }
            }
            return name;
        }

        /// <summary>
        /// 获得背包中宝石集合
        /// </summary>
        /// <returns></returns>
        public static List<GoodsLuaEx> GetBagGemSordList(List<uint> gemTypes)
        {
            List<GoodsLuaEx> gems = new List<GoodsLuaEx>();
            var goods = ItemManager.Instance.GetGoodsListBySubType(GameConst.GIVE_TYPE_GOODS, GameConst.GIVE_SUB_TYPE_GEM);
            foreach (var item in goods)
            {
                if (item is GoodsLuaEx)
                {
                    GoodsLuaEx gem = (GoodsLuaEx)item;
                    GoodsLuaEx _gem = gems.Find(delegate (GoodsLuaEx __gem) { return (__gem.type_idx == gem.type_idx && __gem.bind == gem.bind); });
                    uint currentGemType = 1;
                    if (gem.ExData.ContainsKey("GemType"))
                    {
                        var val = gem.ExData["GemType"];
                        currentGemType = uint.Parse(val);
                    }
                    uint type = gemTypes.Find(delegate (uint __gemType) { return __gemType == currentGemType; });
                    if (type != 0)
                    {
                        if (_gem != null)
                        {
                            //GameDebug.LogError("before _gem.num = " + _gem.num);
                            _gem.num += gem.num;
                            //GameDebug.LogError("after _gem.num = " + _gem.num);
                        }
                        else
                        {
                            GoodsLuaEx copy_gem = new GoodsLuaEx();
                            copy_gem.Copy(gem);
                            gems.Add(copy_gem);
                        }
                    }
                }
            }

            gems.Sort(delegate (GoodsLuaEx gem1, GoodsLuaEx gem2)
            {
                uint lv1 = 0;
                uint lv2 = 1;
                if (gem1.ExData.ContainsKey("GemLv"))
                {
                    
                    lv1 = uint.Parse(gem1.ExData["GemLv"]);
                }

                if (gem2.ExData.ContainsKey("GemLv"))
                {
                    lv2 = uint.Parse(gem2.ExData["GemLv"]);
                }
                if (lv1 > lv2)
                    return -1;
                else if (lv1 < lv2)
                    return 1;
                else
                    return 0;
            });

            return gems;
        }
        /// <summary>
        /// 判断该宝石是否可合成
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static bool isCanComposeGem(uint gid)
        {
            bool isCan = true;
            uint currentGemId = 0;

            DBGem.GemInfo gemInfo = DBManager.Instance.GetDB<DBGem>().GetGemInfo(gid);
            if (gemInfo != null)
            {
                currentGemId = gemInfo.NextGemId;
            }

            if (currentGemId == 0)
                return false;
            List<Goods> stuff = GetComposeStuffs(currentGemId);
//            Dictionary<uint, uint> moneys = GetComposeMoney(currentGemId);
//             foreach (var kv in moneys)
//             {
//                 uint bagMoenyNum = LocalPlayerManager.Instance.GetMoneyByConst((ushort)kv.Key);
//                 if (bagMoenyNum < kv.Value)
//                 {
//                     isCan = false;
//                     break;
//                 }
//             }
            if (stuff.Count > 0)
            {
                for (int i = 0; i < stuff.Count; i++)
                {
                    Goods goods = stuff[i];
                    ulong bagGoodsnum = ItemManager.Instance.GetGoodsNumForBagByTypeId(goods.type_idx);
                    // 也要加上当前镶嵌的宝石
                    // https://www.tapd.cn/20249401/prong/stories/view/1120249401001005217
                    if (gid == goods.type_idx)
                    {
                        bagGoodsnum++;
                    }
                    if (goods.num > bagGoodsnum)
                    {
                        isCan = false;
                        break;
                    }
                }
            }
            // 已经是最高级的宝石了
            else
            {
                isCan = false;
            }

            return isCan;
        }

        /// <summary>
        /// 是否可合成升级该铭刻
        /// </summary>
        public static bool IsCanComposeEngrave(uint gid)
        {
            uint nextEngraveId = 0;

            DBEngrave.EngraveInfo gemInfo = DBManager.Instance.GetDB<DBEngrave>().GetEngraveInfoByGid(gid);
            if (gemInfo != null)
            {
                nextEngraveId = gemInfo.NextEngraveId;
            }

            if (nextEngraveId == 0)
                return false;

            bool ret = true;
            List<Goods> stuff = GetComposeStuffs(nextEngraveId);

            if (stuff.Count > 0)
            {
                for (int i = 0; i < stuff.Count; i++)
                {
                    Goods goods = stuff[i];
                    ulong bagGoodsnum = ItemManager.Instance.GetGoodsNumForBagByTypeId(goods.type_idx);
                    if (gid == goods.type_idx)
                    {
                        bagGoodsnum++;
                    }

                    if (goods.num > bagGoodsnum)
                    {
                        ret = false;
                        break;
                    }
                }
            }
            else
            {
                // 已经是最高级铭刻
                ret = false;
            }

            return ret;
        }

        /// <summary>
        /// 根据宝石gid返回该宝石的类型
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static uint GetGemTypeByGemGid(uint gid)
        {
            DBGem.GemInfo gemInfo = DBManager.Instance.GetDB<DBGem>().GetGemInfo(gid);
            if (gemInfo != null)
            {
                return gemInfo.Type;
            }

            return 0;
        }

        /// <summary>
        /// 根据宝石gid返回该宝石的等级
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public static uint GetGemLevelByGemGid(uint gid)
        {
            DBGem.GemInfo gemInfo = DBManager.Instance.GetDB<DBGem>().GetGemInfo(gid);
            if (gemInfo != null)
            {
                return gemInfo.Lv;
            }

            return 0;
        }

        /// <summary>
        /// 找出适合改孔改部位的宝石类型
        /// </summary>
        /// <param name="hole"></param>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static List<uint> GetGemTypeHole(uint hole, GoodsEquip equip)
        {
            DBGemHole.GemHoleInfo gemHoleInfo = DBManager.Instance.GetDB<DBGemHole>().GetGemHoleInfo((byte)equip.EquipPos, (byte)hole);
            if (gemHoleInfo == null)
            {
                return null;
            }
            return gemHoleInfo.GemList;
        }

        /// <summary>
        /// 根据宝石类型获得宝石最低级的gid
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static uint GetGemMinLvByGemType(uint type)
        {
            ushort lv = ushort.MaxValue;
            uint gid = 0;

            List<DBGem.GemInfo> gemInfos = DBManager.Instance.GetDB<DBGem>().GetGemInfosByType((byte)type);
            if (gemInfos != null && gemInfos.Count > 0)
            {
                foreach (DBGem.GemInfo gemInfo in gemInfos)
                {
                    ushort _lv = gemInfo.Lv;
                    if (lv == 0)
                        lv = _lv;
                    else
                    {
                        if (_lv < lv)
                        {
                            lv = _lv;
                            gid = gemInfo.Id;
                        }
                    }
                }
            }

            return gid;
        }

        /// <summary>
        /// 根据宝石孔返回背包所有满足条件的宝石
        /// </summary>
        /// <param name="hole"></param>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static List<Goods> GetBagGemByHole(uint hole, GoodsEquip equip)
        {
            DBGemHole.GemHoleInfo gemHoleInfo = DBManager.Instance.GetDB<DBGemHole>().GetGemHoleInfo((byte)equip.EquipPos, (byte)hole);
            if (gemHoleInfo == null)
            {
                return null;
            }

            List<Goods> bagGem = new List<Goods>();
            bagGem.Clear();

            uint equipLv = gemHoleInfo.LvStepLimit;
            if (equip.LvStep < equipLv)
            {
                return bagGem;
            }
            List<uint> gems = gemHoleInfo.GemList;

            var bagGoods = ItemManager.Instance.BagGoodsOids;
            foreach (var kv in bagGoods)
            {
                if (kv.Value.sub_type == GameConst.GIVE_SUB_TYPE_GEM)
                {
                    uint type = GetGemTypeByGemGid(kv.Value.type_idx);
                    uint findId = 0;
                    findId = gems.Find(delegate (uint gemId) { return gemId == type; });
                    if (findId != 0)
                    {
                        bagGem.Add(kv.Value);
                    }
                }
                
            }

            return bagGem;
        }
        /// <summary>
        /// 背包是否还有可镶嵌的宝石
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool GetBagIsCanGemInstall(GoodsEquip equip)
        {
            bool isCan = false;
            int hole = 0;
            if (equip == null)
                return false;
            for (int i = 1; i < 4; i++)
            {
                var condtion = GetGemHoleInstallCondtion((uint)i, equip);
                if (condtion != null && condtion.Count != 0)
                {
                    hole = i;
                    break;
                }
            }

            int haveEmptySlot = 0;
            for (int i = 1; i < hole; i++)
            {
                if (equip.Gems.ContainsKey((uint)i) == false)
                {
                    haveEmptySlot++;
                }
            }

            if (haveEmptySlot == 0)
                return false;
            

            var gemTypes = GetGemTypeHole((uint)hole, equip);
            if (gemTypes != null && gemTypes.Count > 0)
            {
                var goods = ItemManager.Instance.GetGoodsListBySubType(GameConst.GIVE_TYPE_GOODS, GameConst.GIVE_SUB_TYPE_GEM);
                foreach (var item in goods)
                {
                    if (item is GoodsLuaEx)
                    {
                        GoodsLuaEx gem = (GoodsLuaEx)item;
                        uint currentGemType = 1;
                        if (gem.ExData.ContainsKey("GemType"))
                        {
                            var val = gem.ExData["GemType"];
                            currentGemType = uint.Parse(val);
                        }
                        uint type = gemTypes.Find(delegate (uint __gemType) { return __gemType == currentGemType; });
                        if (type != 0)
                        {
                            isCan = true;
                            break;
                        }
                    }
                }
            }
            return isCan;
        }

        /// <summary>
        /// 背包是否还有更高级可镶嵌的宝石
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool GetBagIsCanHigherGemInstall(GoodsEquip equip, uint hole)
        {
            if (equip == null)
                return false;

            bool isCan = false;

            var goods = ItemManager.Instance.GetGoodsListBySubType(GameConst.GIVE_TYPE_GOODS, GameConst.GIVE_SUB_TYPE_GEM);

            uint gemHoleNum = DBManager.Instance.GetDB<DBGemHole>().GetGemHoleNum();
            for (uint i = 1; i <= gemHoleNum; i++)
            {
                if (hole == 0 || hole == i)
                {
                    Dictionary<string, uint> condtion = GetGemHoleInstallCondtion((uint)i, equip);
                    if (condtion == null || condtion.Count == 0)
                    {
                        var gemTypes = GetGemTypeHole(i, equip);
                        if (gemTypes != null && gemTypes.Count > 0)
                        {
                            foreach (var item in goods)
                            {
                                if (item is GoodsLuaEx)
                                {
                                    GoodsLuaEx gem = (GoodsLuaEx)item;
                                    uint currentGemType = 1;
                                    if (gem.ExData.ContainsKey("GemType"))
                                    {
                                        var val = gem.ExData["GemType"];
                                        currentGemType = uint.Parse(val);
                                    }
                                    uint type = gemTypes.Find(delegate (uint __gemType) { return __gemType == currentGemType; });
                                    if (type != 0)
                                    {
                                        if (equip.Gems.ContainsKey(i) == false)   // 该装备还没镶嵌该宝石
                                        {
                                            isCan = true;
                                            break;
                                        }
                                        else  // 该装备已经镶嵌该宝石，则判断是否有更高级的宝石
                                        {
                                            uint currentGemLv = GetGemLevelByGemGid(item.type_idx);
                                            uint gemLv = GetGemLevelByGemGid(equip.Gems[i]);
                                            if (currentGemLv > gemLv)
                                            {
                                                isCan = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return isCan;
        }

        static Dictionary<string, uint> GemHoleInstallCondtion = null;
        /// <summary>
        /// 宝石孔镶嵌条件 除开宝石类型
        /// </summary>
        /// <param name="hole"></param>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static Dictionary<string, uint> GetGemHoleInstallCondtion(uint hole, GoodsEquip equip)
        {
            DBGemHole.GemHoleInfo gemHoleInfo = DBManager.Instance.GetDB<DBGemHole>().GetGemHoleInfo((byte)equip.EquipPos, (byte)hole);
            if (gemHoleInfo == null)
            {
                return null;
            }
            if (GemHoleInstallCondtion == null)
            {
                GemHoleInstallCondtion = new Dictionary<string, uint>();
            }
            GemHoleInstallCondtion.Clear();
            
            uint equipLv = gemHoleInfo.LvStepLimit;
            uint vip = gemHoleInfo.VipLimit;
            if (vip != 0)
            {
                uint vipLevel = VipHelper.GetVipValidLevel();
                if (vipLevel < vip)
                {
                    GemHoleInstallCondtion.Add("vip_limit", vip);
                    return GemHoleInstallCondtion;
                }
            }
            if (equip.LvStep < equipLv)
            {
                GemHoleInstallCondtion.Add("lv_step_limit", equipLv);
                return GemHoleInstallCondtion;
            }

// 
//             if (equip.LvStep < equipLv)
//             {
//                 Condtion.Add("lv_step_limit", equipLv);
//                 return Condtion;
//             }
            return GemHoleInstallCondtion;
        }

        /// <summary>
        /// 计算该装备的宝石所有加成
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static ActorAttribute GetAllEquipGemAttr(GoodsEquip equip)
        {
            ActorAttribute BasicAttrs = new ActorAttribute();
            Dictionary<uint, uint> attrkv = new Dictionary<uint, uint>();
            foreach (var kv in equip.Gems)
            {
                DBGem.GemInfo gemInfo = DBManager.Instance.GetDB<DBGem>().GetGemInfo(kv.Value);
                if (gemInfo != null && gemInfo.Attrs != null && gemInfo.Attrs.Count > 0)
                {
                    foreach (List<uint> attr in gemInfo.Attrs)
                    {
                        if (attr.Count >= 2)
                        {
                            uint attrId = attr[0];
                            uint attrValue = attr[1];
                            if (attrkv.ContainsKey(attrId))
                            {
                                attrkv[attrId] = attrkv[attrId] + attrValue;
                            }
                            else
                                attrkv.Add(attrId, attrValue);
                        }
                    }
                }
            }
            foreach (var kv in attrkv)
            {
                BasicAttrs.Add(kv.Key, kv.Value);
            }

            return BasicAttrs;
        }
        /// <summary>
        /// 某个宝石的属性
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static ActorAttribute GetGemAttr(uint type_id)
        {
            ActorAttribute BasicAttrs = new ActorAttribute();

            DBGem.GemInfo gemInfo = DBManager.Instance.GetDB<DBGem>().GetGemInfo(type_id);
            if (gemInfo != null && gemInfo.Attrs != null && gemInfo.Attrs.Count > 0)
            {
                foreach (List<uint> attr in gemInfo.Attrs)
                {
                    if (attr.Count >= 2)
                    {
                        uint attrId = attr[0];
                        uint attrValue = attr[1];
                        BasicAttrs.Add(attrId, attrValue);
                    }
                }
            }

            return BasicAttrs;
        }

        /// <summary>
        /// 获取铭刻属性
        /// </summary>
        public static ActorAttribute GetEngraveAttrs(xc.DBEngrave.EngraveInfo engraveInfo)
        {
            ActorAttribute ret = new ActorAttribute();

            if (engraveInfo.Attrs != null && engraveInfo.Attrs.Count > 0)
            {
                foreach (List<uint> attr in engraveInfo.Attrs)
                {
                    if (attr.Count >= 2)
                    {
                        uint attrId = attr[0];
                        uint attrValue = attr[1];

                        ret.Add(attrId, attrValue);
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// 获取身上宝石的总等级
        /// </summary>
        /// <returns></returns>
        public static uint GetGemTotalLv()
        {
            uint totalLv = 0;
            foreach (GoodsEquip goodsEquip in ItemManager.Instance.InstallEquip.Values)
            {
                foreach (uint gemId in goodsEquip.Gems.Values)
                {
                    totalLv += GetGemLevelByGemGid(gemId);
                }
            }

            return totalLv;
        }

        /// <summary>
        /// 根据宝石总等级获取属性
        /// </summary>
        /// <param name="totalLv"></param>
        /// <returns></returns>
        public static ActorAttribute GetGemAttrByTotalLv(uint totalLv)
        {
            ActorAttribute BasicAttrs = new ActorAttribute();
            List<string> data_gem_fixed_total_lv = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_gem_fixed_total_lv", "lv", totalLv.ToString(), "attr");
            if (data_gem_fixed_total_lv.Count > 0)
            {
                string raw = data_gem_fixed_total_lv[0];
                raw = raw.Replace(" ", "");
                var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                        BasicAttrs.Add(attrId, attrValue);
                    }
                }
            }
            return BasicAttrs;
        }

        /// <summary>
        /// 根据铭刻总等级获取属性
        /// </summary>
        public static ActorAttribute GetEngraveAttrByTotalLv(uint totalLv)
        {
            ActorAttribute BasicAttrs = new ActorAttribute();
            List<string> data_gem_fixed_total_lv = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_engrave_total_lv", "lv", totalLv.ToString(), "attr");
            if (data_gem_fixed_total_lv.Count > 0)
            {
                string raw = data_gem_fixed_total_lv[0];
                raw = raw.Replace(" ", "");
                var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                        BasicAttrs.Add(attrId, attrValue);
                    }
                }
            }
            return BasicAttrs;
        }

        /// <summary>
        /// 根据身上真实的宝石总等级获得表里面的等级
        /// </summary>
        /// <param name="realLv"></param>
        /// <returns></returns>
        public static uint GetGemDataTotalLv(uint realLv)
        {
            if (realLv == 0)
                return 0;
            uint dataLv = 0;
            List<Dictionary<string, string>> data_gem_fixed_total_lv = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_gem_fixed_total_lv");
            List<Dictionary<string, string>> _data_gem_fixed_total_lv = data_gem_fixed_total_lv;
            for (int i = 0; i < data_gem_fixed_total_lv.Count; i++)
            {
                Dictionary<string, string> data = data_gem_fixed_total_lv[i];
                var lv = DBTextResource.ParseUI(data["lv"]);
                for (int j = 0; j < _data_gem_fixed_total_lv.Count; j++)
                {
                    Dictionary<string, string> _data = _data_gem_fixed_total_lv[j];
                    var _lv = DBTextResource.ParseUI(_data["lv"]);
                    if (realLv >= lv)
                    {

                        if (realLv < _lv)
                        {
                            dataLv = lv;
                            break;
                        }
                        else if (i == data_gem_fixed_total_lv.Count - 1)
                        {
                            dataLv = lv;
                            break;
                        }
                    }
                }
            }
            return dataLv;
        }

        #endregion

        #region 套装相关接口
        /// <summary>
        /// 装备是否可套装锻造
        /// </summary>
        /// <param name="equip"></param>
        /// <param name="suitLv">要锻造的套装目标等级</param>
        /// <returns></returns>
        public static bool CheckEquipCanSuit(GoodsEquip equip, uint suitLv)
        {
            if (equip == null)
                return false;
            if (equip.IsInstalled == false)
                return false;
            if (equip.SuitInfo == null || equip.SuitId == 0)
                return false;
            var maxlv = GameConstHelper.GetInt("GAME_EP_SUIT_MAX_LV");
            if (equip.SuitLv >= maxlv)
                return false;
            if (suitLv <= equip.SuitLv)
                return false;
            DBSuit.DBSuitInfo targetSuitInfo = DBManager.Instance.GetDB<DBSuit>().GetOneInfo(equip.SuitId, suitLv);
            if (targetSuitInfo != null)
            {
                bool meetColorAndStar = DBSuit.MeetColorAndStarCondition(equip.color_type, equip.Star, targetSuitInfo.NeedInfos);
                if (meetColorAndStar == false)
                {
                    return false;
                }
            }
            if (equip.SuitInfo.CostGoods == null)
                return false;
            bool noHave = true;
            GoodsEquip nextEquip = equip.Clone();
            if (nextEquip.SuitLv >= maxlv)
            {
                nextEquip.SuitLv = equip.SuitLv;
            }
            else
            {
                nextEquip.SuitLv = equip.SuitLv + 1;
            }
            for (int i = 0; i < nextEquip.SuitInfo.CostGoods.Count; i++)
            {
                var goods = nextEquip.SuitInfo.CostGoods[i];
                var bagNum = ItemManager.Instance.GetGoodsNumForBagByTypeId(goods.type_idx);
                if (bagNum < goods.num)
                {
                    noHave = false;
                    break;
                }
            }
            if (noHave == false)
                return false;
            return true;
        }
        /// <summary>
        /// 获得套装最大数量
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static uint GetMaxNum(GoodsEquip equip)
        {
            uint maxNum = 0;
            if (equip.SuitLv == 0 || equip.SuitInfo == null)
                return maxNum;
            uint idx = 0;
            foreach (var item in equip.SuitInfo.SuitAttrs)
            {
                if (idx == equip.SuitInfo.SuitAttrs.Count - 1)
                {
                    maxNum = item.Key;
                }
                idx++;
            }
            return maxNum;
        }

        /// <summary>
        /// 获得tips显示的装备综合评分
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static int GetEquipTipsUpgradeRank(GoodsEquip equip)
        {
            int rank = 0;
            if (equip.IsInstalled == false)
                return rank;
            ///强化
            var attr = GetEquipStrengthAttr(equip.StrenghtLv, equip);
            rank = rank + GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, attr);

            ///套装
            if (equip.SuitLv > 0)
                rank = rank +GetSuitRank(equip);

            //洗练
            rank = rank + GetEquipBaptizeRankType(equip.EquipPos, equip.Index, AttrScoreGType.EquipBase);

            // 精炼
            rank = rank + GetSuitRefineRank(equip);

            return rank;
        }

        /// <summary>
        /// 获得其他玩家的tips显示的装备综合评分
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static int GetOtherPlayerEquipTipsUpgradeRank(GoodsEquip equip)
        {
            int rank = 0;
            if (equip.IsInstalledByOtherPlayer == false)
                return rank;
            ///强化
            var attr = GetEquipStrengthAttr(equip.StrenghtLv, equip);
            rank = rank + GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, attr);

            ///套装
            if (equip.SuitLv > 0)
                rank = rank + GetSuitRank(equip);

            //洗练
            EquipPosInfo posinfo = MainmapManager.Instance.GetOtherPlayerEquipPosInfos(equip.EquipPos);
            rank = rank + GetEquipBaptizeRankType(equip.EquipPos, equip.Index, AttrScoreGType.EquipBase, posinfo);

            // 精炼
            rank = rank + GetSuitRefineRank(equip);

            return rank;
        }


        /// <summary>
        /// 套裝rank
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static int GetSuitRank(GoodsEquip equip)
        {
            int rank = 0;
            if (equip.SuitInfo == null)
                return rank;

            if (equip.SuitInfo.ActiveNum == 0)
            {
                return rank;
            }

            int totalRank = 0;
            foreach (var item in equip.SuitInfo.SuitAttrs)
            {
                // 小于已激活件数的属性才算进总分
                if (equip.SuitInfo.ActiveNum >= item.Key)
                {
                    totalRank += EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, item.Value);
                }
            }
            rank = totalRank / (int)equip.SuitInfo.MaxNum;
            return rank;
        }

        /// <summary>
        /// 套装精炼评分
        /// </summary>
        public static int GetSuitRefineRank(GoodsEquip equip)
        {
            int ret = 0;

            if (equip == null || equip.RefineLv <= 0 || equip.BasicAttrs == null)
                return ret;

            var baseAttr = new ActorAttribute();

            foreach(var v in equip.BasicAttrs)
            {
                baseAttr.Add(v.Value.Id, v.Value.Value);
            }

            string key = string.Format("{0}_{1}_{2}", equip.EquipPos, equip.LvStep, equip.RefineLv);
            var item = DBSuitRefine.Instance.GetData(key);
            if (item == null)
                return ret;

            float addPercent = item.Addition / 10000f; // 基础属性加成

            foreach(var v in baseAttr)
            {
                var attrValue = v.Value.Value;
                v.Value.Value = (long)Math.Floor(attrValue * (1 + addPercent));
            }

            // 源基础属性评分
            var origBaseRank = GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, equip.BasicAttrs);

            // 加成后属性评分
            var addBaseRank = GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, baseAttr);

            ret = addBaseRank - origBaseRank;

            return ret;
        }

        /// <summary>
        /// 根据一个装备计算出该装备在穿戴装备中激活的个数主要用于计算预览装备因为装备预览等级>0的
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static uint CalculatorInstallSuitNum(GoodsEquip equip, Dictionary<ulong, GoodsEquip> installEquip = null)
        {
            uint finalnum = 0;
            if (equip.SuitLv == 0)
                return finalnum;

            int Lv2Count = 0;
            int Lv1Count = 0;

            if (installEquip == null)
            {
                installEquip = ItemManager.Instance.InstallEquip;
            }
            foreach (var kv in installEquip)
            {
                if (equip.SuitId != 0 && kv.Value.SuitLv != 0 && equip.SuitId == kv.Value.SuitId && equip.SuitLv == kv.Value.SuitLv)
                {
                    //if (kv.Key != equip.id)
                    {
                        if (kv.Value.SuitLv == 2)
                        {
                            Lv2Count++;
                        }
                        else if (kv.Value.SuitLv == 1)
                        {
                            Lv1Count++;
                        }
                    }
                }
            }

            uint count = 0;
            if (equip.SuitLv == 1)
                count = (uint)Lv1Count;
            else
                count = (uint)Lv2Count;

            return count;

            ////拿出套装对应的数量长度
            //List<uint> suitsNum = equip.SuitInfo.SuitAttrs.Keys.ToList<uint>();

            //for (int i = 0; i < suitsNum.Count; i++)
            //{
            //    if (count >= suitsNum[i])
            //    {
            //        return suitsNum[i];
            //    }
            //}

            //uint maxNum = 0;
            ////找出最大达成的最大数量
            //for (int i = 0; i < suitsNum.Count; i++)
            //{
            //    if (suitsNum[i] <= Lv2Count)
            //    {
            //        maxNum = suitsNum[i];
            //    }
            //}
            //if (maxNum != 0)
            //{
            //    if (Lv2Count > maxNum)
            //    {
            //        uint _lv1Count = suitsNum.Find(delegate (uint __num) { return (Lv1Count + 1) == (uint)__num; });
            //        if (_lv1Count != 0)
            //        {
            //            Lv2Count -= 1;
            //            Lv1Count += 1;
            //        }
            //    }
            //}
            //else
            //{
            //    if(Lv2Count != 0&& Lv1Count != 0)
            //    {
            //        uint _lv1Count = suitsNum.Find(delegate (uint __num) { return (Lv1Count + 1) == (uint)__num; });
            //        if (_lv1Count != 0)
            //        {
            //            Lv2Count -= 1;
            //            Lv1Count += 1;
            //        }
            //    }

            //}

            //if (equip.SuitLv == 1)
            //    finalnum = (uint)Lv1Count;
            //else
            //    finalnum = (uint)Lv2Count;

            //return finalnum;
        }

        /// <summary>
        /// 根据当前容器返回该容器种归类的套装列表
        /// </summary>
        /// <param name="installEquip"></param>
        /// <returns></returns>
        public static void CalculatorSuitNum(Dictionary<ulong, GoodsEquip> installEquip)
        {
            //Dictionary<uint, Dictionary<uint,List<GoodsEquip>>>  suitEquips = new Dictionary<uint, Dictionary<uint, List<GoodsEquip>>>();
            foreach (var item in installEquip)
            {
                if (item.Value.SuitInfo != null)
                    item.Value.SuitInfo.RealNum = 0;
                if (item.Value.SuitId == 0|| item.Value.SuitLv == 0)
                    continue;
                if (item.Value.SuitInfo.UpgradeNeed != null)
                {
                    bool meetColorAndStar = DBSuit.MeetColorAndStarCondition(item.Value.color_type, item.Value.Star, item.Value.SuitInfo.UpgradeNeed);
                    if (meetColorAndStar == false)
                    {
                        continue;
                    }
                }
                item.Value.SuitInfo.RealNum = CalculatorInstallSuitNum(item.Value, installEquip);
            }
        }

        /// <summary>
        /// 根据当前容器返回该容器种归类的套装列表
        /// </summary>
        /// <param name="installEquip"></param>
        /// <returns></returns>
        public static void CalculatorSuitNum(List<GoodsEquip> installEquip)
        {
            //Dictionary<uint, Dictionary<uint, List<GoodsEquip>>> suitEquips = new Dictionary<uint, Dictionary<uint, List<GoodsEquip>>>();
            Dictionary<ulong, GoodsEquip> installEquipDict = new Dictionary<ulong, GoodsEquip>();
            installEquipDict.Clear();
            foreach (var item in installEquip)
            {
                installEquipDict.Add(item.id, item);
            }
            foreach (var item in installEquip)
            {
                if (item.SuitInfo != null)
                    item.SuitInfo.RealNum = 0;
                if (item.SuitId == 0 || item.SuitLv == 0)
                    continue;
                if (item.SuitInfo.UpgradeNeed != null)
                {
                    bool meetColorAndStar = DBSuit.MeetColorAndStarCondition(item.color_type, item.Star, item.SuitInfo.UpgradeNeed);
                    if (meetColorAndStar == false)
                    {
                        continue;
                    }
                }
                item.SuitInfo.RealNum = CalculatorInstallSuitNum(item, installEquipDict);
            }
        }

        /// <summary>
        /// 获得激活当前套装数量
        /// </summary>
        /// <param name="suitId"></param>
        /// <param name="suitLv"></param>
        /// <param name="suitNum"></param>
        /// <returns></returns>
        public static uint GetActiveSuitNum(uint suitId, uint suitLv, uint suitNum)
        {
            uint num = 0;
            var attrInfos = DBManager.Instance.GetDB<DBSuitAttr>().GetAttrInfos(suitId, suitLv);
            if(attrInfos != null)
            {
                foreach (var info in attrInfos)
                {
                    if (info.Num <= suitNum)
                    {
                        if(info.Num > num)
                            num = info.Num;
                    }
                }
            }

            return num;
        }

        /// <summary>
        /// 获取当前穿戴的套装件数
        /// </summary>
        /// <returns></returns>
        public static uint GetInstallEquipSuitNum()
        {
            uint num = 0;
            foreach (var kv in ItemManager.Instance.InstallEquip)
            {
                if (kv.Value.SuitId > 0 && kv.Value.SuitLv > 0)
                {
                    ++num;
                }
            }

            return num;
        }
        #endregion

        #region 洗练相关接口
        /// <summary>
        /// 判断装备洗练小红点是否显示
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool EnableEquipBaptizeRedPoint(GoodsEquip equip)
        {
            if (equip == null)
                return false;
            if (equip.IsInstalled == false)
                return false;
            //EquipPosInfo Posinfo = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == equip.EquipPos && _info.Index == equip.Index); });
            EquipPosInfo Posinfo = GetStrengthInfoByPosAndIndex(equip.EquipPos, equip.Index);
            if (Posinfo == null)
                return false;
            if (LocalPlayerManager.Instance.LocalActorAttribute == null)
                return false;
            if (LocalPlayerManager.Instance.LocalActorAttribute.Level < Posinfo.BaptizeNeedLv)
                return false;
            var total = GameConstHelper.GetInt("GAME_EP_BAPTIZE_FREE_NUM");
            var CurrentNum = (int)ItemManager.Instance.BaptizeCount;
            if (total <= CurrentNum)
            {
                // 消耗物品足够也不用显示小红点了
                //var lockCount = EquipHelper.GetLockCountByPos(equip.EquipPos, equip.Index);
                //var costGoods = EquipHelper.GetBaptizeLockCostGoods(lockCount);
                //var bagNum = ItemManager.Instance.GetGoodsNumForBagByTypeId(costGoods.type_idx);
                //if (costGoods.num > bagNum)
                //{
                //    if (Posinfo.BaptizeNeedLv > LocalPlayerManager.Instance.LocalActorAttribute.Level)
                //    {
                //        return false;
                //    }
                //    else
                //    {
                //        int index = 0;
                //        foreach (var kv in Posinfo.BaptizeInfos)
                //        {
                //            if (kv.Value.State == EquipBaptizeInfo.EquipBaptizeState.NO_Open)
                //            {
                //                index++;
                //            }
                //        }
                //        if (index == Posinfo.BaptizeInfos.Count)
                //        {
                //            return true;
                //        }
                //        else
                //        {
                //            return false;
                //        }
                //    }

                //}

                uint index = 0;
                foreach (var kv in Posinfo.BaptizeInfos)
                {
                    if (kv.Value.State == EquipBaptizeInfo.EquipBaptizeState.NO_Open)
                    {
                        ++index;
                    }
                }
                // 一个洗练槽都没开启也要显示小红点
                if (index == Posinfo.BaptizeInfos.Count)
                {
                    return true;
                }

                return false;
            }
            return true;

        }
        /// <summary>
        /// 获得洗练评分
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetEquipBaptizeRank(uint pos, uint index)
        {
            return GetEquipBaptizeRankType(pos, index,AttrScoreGType.EquipBaptize);
        }
        /// <summary>
        /// 获得洗练评分
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetEquipBaptizeRankType(uint pos, uint index, AttrScoreGType _type)
        {
            return GetEquipBaptizeRankType(pos, index, _type, GetStrengthInfoByPosAndIndex(pos, index));
        }

        /// <summary>
        /// 获得洗练评分
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetEquipBaptizeRankType(uint pos, uint index, AttrScoreGType _type, EquipPosInfo posinfo)
        {            
            if (posinfo == null)
                return 0;
            int score = 0;
            ActorAttribute finalAttr = new ActorAttribute();
            foreach (var kv in posinfo.BaptizeInfos)
            {
                foreach (var item in kv.Value.BaptizeAttr)
                {
                    uint finalVal = (uint)Mathf.CeilToInt((float)item.Value.Value * (1.0f + ((float)kv.Value.AttrAdd / 100.0f)));
                    if (finalAttr.ContainsKey(item.Key) == false)
                        finalAttr.Add(item.Key, finalVal);
                }
            }


            score += GetEquipBaseAttrScoreByType(_type, finalAttr);

            Dictionary<uint, DBBaptizeGroove.DBBaptizeGrooveInfo> allDBBaptizeGrooveInfos = DBManager.Instance.GetDB<DBBaptizeGroove>().AllInfos;
            foreach (DBBaptizeGroove.DBBaptizeGrooveInfo dbBaptizeGrooveInfo in allDBBaptizeGrooveInfos.Values)
            {
                uint id = dbBaptizeGrooveInfo.Id;
                if (posinfo.BaptizeInfos.ContainsKey(id) && posinfo.BaptizeInfos[id].State != EquipBaptizeInfo.EquipBaptizeState.NO_Open)
                {
                    score += (int)dbBaptizeGrooveInfo.BaseRank;
                }
            }

            return score;
        }

        /// <summary>
        /// 获得当前未锁定的格子个数
        /// </summary>
        /// <returns></returns>
        public static uint GetLockCountByPos(uint pos, uint index)
        {
            uint count = 0;
            //EquipPosInfo Posinfo = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == pos && _info.Index == index); });
            EquipPosInfo Posinfo = GetStrengthInfoByPosAndIndex(pos, index);
            if (Posinfo == null)
                return 0;
            foreach (var kv in Posinfo.BaptizeInfos)
            {
                if (kv.Value.State == EquipBaptizeInfo.EquipBaptizeState.Lock)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// 获得当前开启的格子
        /// </summary>
        /// <returns></returns>
        public static uint GetOpenCountByPos(uint pos, uint index)
        {
            uint count = 0;
            //EquipPosInfo Posinfo = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == pos && _info.Index == index); });
            EquipPosInfo Posinfo = GetStrengthInfoByPosAndIndex(pos, index);
            if (Posinfo == null)
                return 0;
            foreach (var kv in Posinfo.BaptizeInfos)
            {
                if (kv.Value.State != EquipBaptizeInfo.EquipBaptizeState.NO_Open)
                    count++;
            }
            return count;
        }
        /// <summary>
        /// 根据装备返回装备洗练属性（如果该装备没有被装备那么返回string.Empty）
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static string GetCurrentEquipBaptizeAttrDes(GoodsEquip equip)
        {
            string str = string.Empty;
            if (!equip.IsInstalled)
                return str;
            var info = EquipHelper.GetStrengthInfoByPosAndIndex(equip.EquipPos, equip.Index);
            if (info == null)
                return str;

            foreach (var kv in info.BaptizeInfos)
            {
                var _str = GetBaptizeAddBaseAttrDisplay(equip, kv.Value);
                if (_str.CompareTo(string.Empty) != 0)
                {
                    _str = _str + "\n";
                }
                str += _str;
            }
            // 去除结尾的换行符
            if (str.EndsWith("\n") == true)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        /// <summary>
        /// 获得当前未锁定的格子个数
        /// </summary>
        /// <returns></returns>
        public static uint GetUnLockCountByPos(uint pos , uint index)
        {
            uint count = 0;
            //EquipPosInfo Posinfo = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == pos && _info.Index == index); });
            EquipPosInfo Posinfo = GetStrengthInfoByPosAndIndex(pos, index);
            if (Posinfo == null)
                return 0;
            foreach (var kv in Posinfo.BaptizeInfos)
            {
                if (kv.Value.State == EquipBaptizeInfo.EquipBaptizeState.Open)
                    count++;
            }
            return count;
        }
        /// <summary>
        /// 获得锁定消耗的道具
        /// </summary>
        /// <param name="lockCount"></param>
        /// <returns></returns>
        public static Goods GetBaptizeLockCostGoods(uint lockCount)
        {
            DBBaptizeCost.DBBaptizeCostInfo info = DBManager.Instance.GetDB<DBBaptizeCost>().GetOneInfo(lockCount);
            if (info != null && info.CostGoods != null)
            {
                foreach (KeyValuePair<uint, uint> kv in info.CostGoods)
                {
                    GoodsItem goods = new GoodsItem(kv.Key);
                    goods.num = kv.Value;
                    return goods;
                }
            }
            
            return null;
        }
        /// <summary>
        /// 获取锁定槽需要的钻石
        /// </summary>
        /// <param name="lockCount"></param>
        /// <returns></returns>
        public static uint GetBaptizeLockCostDiamond(uint lockCount)
        {
            DBBaptizeCost.DBBaptizeCostInfo info = DBManager.Instance.GetDB<DBBaptizeCost>().GetOneInfo(lockCount);
            if (info != null)
            {
                return info.CostDiamond;
            }
            
            return 0;
        }

        /// <summary>
        /// 获得洗练加成后的最终属性描述
        /// </summary>
        /// <param name="installEquip"></param>
        /// <param name="baptizeInfo"></param>
        /// <returns></returns>
        public static string GetBaptizeAddBaseAttrDisplay(GoodsEquip installEquip, EquipBaptizeInfo baptizeInfo)
        {
            ActorAttribute BasicAttrs = new ActorAttribute();
            string str = string.Empty;
            foreach (var item in baptizeInfo.BaptizeAttr)
            {
                uint id = item.Key;
                long finalVal = 0;
                var color = EquipHelper.GetBaptizeColor(installEquip, baptizeInfo);
                var colorStr = GoodsHelper.GetGoodsColor(color);
                if (baptizeInfo.AttrAdd != 0)
                {
                    finalVal = (long)Mathf.CeilToInt((float)item.Value.Value * (1.0f + ((float)baptizeInfo.AttrAdd / 100.0f)));
                }
                else
                {
                    finalVal = item.Value.Value;
                }
                if(BasicAttrs.ContainsKey(id) == false)
                    BasicAttrs.Add(id, finalVal);
                var attr = BasicAttrs[id];
                if (attr is DefaultActorAttribute)
                {
                    DefaultActorAttribute _attr = attr as DefaultActorAttribute;
                    str = string.Format("{0}{1}+{2}</color>", colorStr, _attr.OrigName , _attr.ValuesFormat);
                    
                }
                   
                break;
            }
            return str;
        }

        /// <summary>
        /// 获得洗练属性最小值
        /// </summary>
        /// <param name="installEquip"></param>
        /// <param name="baptizeInfo"></param>
        /// <returns></returns>
        public static ActorAttribute GetBaptizeMinValue(GoodsEquip installEquip, EquipBaptizeInfo baptizeInfo)
        {
            ActorAttribute BasicAttrs = GetBaptizeMaxValue(installEquip, baptizeInfo);
            DBBaptizeColorPool.DBBaptizeColorPoolInfo info = DBManager.Instance.GetDB<DBBaptizeColorPool>().GetOneInfo(0);
            if (BasicAttrs != null && info != null)
            {
                var min = info.AttrRatioMin;
                foreach (var item in BasicAttrs)
                {
                    uint value = (uint)Mathf.CeilToInt((float)item.Value.Value * (float)(min / 100));
                    item.Value.Value = value;
                }
            }
            return BasicAttrs;
        }
        /// <summary>
        /// 获得洗练属性的最大值
        /// </summary>
        /// <param name="installEquip"></param>
        /// <param name="baptizeInfo"></param>
        /// <returns></returns>
        public static ActorAttribute GetBaptizeMaxValue(GoodsEquip installEquip, EquipBaptizeInfo baptizeInfo)
        {
            ActorAttribute BasicAttrs = new ActorAttribute();
            if (installEquip == null || baptizeInfo == null)
                return BasicAttrs;

            DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo info = DBManager.Instance.GetDB<DBBaptizeAttrStandard>().GetOneInfo(installEquip.LvStep);
            if (info != null && info.BaseAttrs != null)
            {
                foreach (KeyValuePair<uint, IActorAttribute> kv in info.BaseAttrs)
                {
                    uint attrId = kv.Value.Id;
                    var attr = baptizeInfo.BaptizeAttr.GetAttr(attrId);
                    if (attr != null)
                    {
                        var attrVal = kv.Value.Value;
                        BasicAttrs.Add(attrId, attrVal);
                        break;
                    }
                }
            }

            return BasicAttrs;
        }

        /// <summary>
        /// 获得洗练属性颜色
        /// </summary>
        /// <param name="installEquip"></param>
        /// <param name="baptizeInfo"></param>
        /// <returns></returns>
        public static uint GetBaptizeColor(GoodsEquip installEquip, EquipBaptizeInfo baptizeInfo)
        {
            if (installEquip == null || baptizeInfo == null)
                return 0;
            long maxValue = 0;
            long nowValue = 0;

            DBBaptizeAttrStandard.DBBaptizeAttrStandardInfo dbBaptizeAttrStandardInfo = DBManager.Instance.GetDB<DBBaptizeAttrStandard>().GetOneInfo(installEquip.LvStep);
            if (dbBaptizeAttrStandardInfo != null && dbBaptizeAttrStandardInfo.BaseAttrs != null)
            {
                foreach (KeyValuePair<uint, IActorAttribute> kv in dbBaptizeAttrStandardInfo.BaseAttrs)
                {
                    uint attrId = kv.Value.Id;
                    var attr = baptizeInfo.BaptizeAttr.GetAttr(attrId);
                    if (attr != null)
                    {
                        maxValue = kv.Value.Value;
                        nowValue = attr.Value;
                        break;
                    }
                }
            }

            var ceilAdd = ((float)nowValue/ (float)maxValue)*100;

            Dictionary<uint, DBBaptizeColorPool.DBBaptizeColorPoolInfo> infos = DBManager.Instance.GetDB<DBBaptizeColorPool>().AllInfos;
            foreach (DBBaptizeColorPool.DBBaptizeColorPoolInfo info in infos.Values)
            {
                var attr_ratio = info.AttrRatio;
                var attr_ratio_min = info.AttrRatioMin;
                if (ceilAdd >= attr_ratio_min && ceilAdd <= attr_ratio)
                {
                    return info.Color;
                }
            }
            return 0;
        }

        #endregion

        #region 强化相关接口
        /// <summary>
        ///判断一个装备是否可强化（材料跟已穿戴）
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool CheckEquipCanStrength(GoodsEquip equip)
        {
            if (equip == null)
                return false;
            if (equip.IsInstalled == false)
                return false;
            //EquipPosInfo info = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == equip.EquipPos && _info.Index == equip.Index); });
            EquipPosInfo info = GetStrengthInfoByPosAndIndex(equip.EquipPos, equip.Index);
            if (info == null)
                return false;
            if (info.StrengthLv >= equip.MaxStrengthLv)
                return false;
            var bagNum = ItemManager.Instance.GetGoodsNumForBagByTypeId(info.StrengthStuff.gid);
            if(info.StrengthStuff.num > bagNum)
                return false;
            if (info.StrengthShowRedPointGoods != null)
            {
                bagNum = ItemManager.Instance.GetGoodsNumForBagByTypeId(info.StrengthShowRedPointGoods.gid);
                if (info.StrengthShowRedPointGoods.num > bagNum)
                    return false;
            }
            return true;
        }

        public static bool CheckAllInstallEquipsCanStrength()
        {
            foreach (var equip in ItemManager.Instance.InstallEquip.Values)
            {
                bool can = CheckEquipCanStrength(equip);
                if (can == true)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 根据身上真实的强化等级获得表种的表等级
        /// </summary>
        /// <param name="realLv"></param>
        /// <returns></returns>
        public static uint GetStrengthDataLv(uint realLv)
        {
            if (realLv == 0)
                return 0;
            uint dataLv = 0;
            List<Dictionary<string, string>> data_strength_ext = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_strength_ext");
            List<Dictionary<string, string>> _data_strength_ext = data_strength_ext;
            for (int i = 0; i < data_strength_ext.Count; i++)
            {
                Dictionary<string, string> data = data_strength_ext[i];
                var lv = DBTextResource.ParseUI(data["lv"]);
                for (int j = 0; j < _data_strength_ext.Count; j++)
                {
                    Dictionary<string, string> _data = _data_strength_ext[j];
                    var _lv = DBTextResource.ParseUI(_data["lv"]);
                    if (realLv >= lv)
                    {

                        if (realLv < _lv)
                        {
                            dataLv = lv;
                            break;
                        }
                        else if (i == data_strength_ext.Count - 1)
                        {
                            dataLv = lv;
                            break;
                        }
                    }
                }
            }
            return dataLv;
        }

        /// <summary>
        /// 獲得身上縂强化等級
        /// </summary>
        /// <returns></returns>
        public static uint GetInstallStrength()
        {
            uint allStrength = 0;
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                if (ItemManager.Instance.StrengthInfos[i].InstallPosEquip != null)
                {
                    allStrength += ItemManager.Instance.StrengthInfos[i].StrengthLv;
                }
            }
            return allStrength;
        }

        /// <summary>
        /// 获得总强化等级
        /// </summary>
        /// <param name="allLv"></param>
        /// <returns></returns>
        public static ActorAttribute GetAllStrengthExAttribute(uint current,uint vocation)
        {
            // data_strength_ext配置表里面所有职业的base_attr都用同一个配置了，所以这个vocation参数没用了
            uint _vocation = 0;
            if (vocation == 0)
                _vocation = 1;
            else
                _vocation = vocation;

            ActorAttribute BasicAttrs = new ActorAttribute();
            List<string> data_strength_ext = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_strength_ext", "lv", current.ToString(), "base_attr");
            if (data_strength_ext.Count > 0)
            {
                string raw = data_strength_ext[0];
                raw = raw.Replace(" ", "");
                var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
                foreach (Match _match in matchs)
                {
                    if (_match.Success)
                    {
                        uint attrId = (DBTextResource.ParseUI(_match.Groups[1].Value));
                        uint attrValue = DBTextResource.ParseUI(_match.Groups[2].Value);
                        BasicAttrs.Add(attrId, attrValue);
                    }
                }
            }
            return BasicAttrs;
        }

        /// <summary>
        /// 获得强化等级消耗的材料
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static PkgGoodsGidnum GetStrengthStuff(uint lv)
        {
            PkgGoodsGidnum goods = null;
            DBStrengthLv.StrengthLvInfo strengthLvInfo = DBStrengthLv.Instance.GetStrengthLvInfo(lv);
            if (strengthLvInfo != null && strengthLvInfo.Costs != null)
            {
                foreach (KeyValuePair<uint, ulong> kv in strengthLvInfo.Costs)
                {
                    goods = new PkgGoodsGidnum();
                    goods.gid = kv.Key;
                    goods.num = kv.Value;
                }
            }
            return goods;
        }

        /// <summary>
        /// 获得显示强化小红点需要达到的货币数量
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static PkgGoodsGidnum GetStrengthShowRedPointGoods(uint lv)
        {
            PkgGoodsGidnum goods = null;
            DBStrengthLv.StrengthLvInfo strengthLvInfo = DBStrengthLv.Instance.GetStrengthLvInfo(lv);
            if (strengthLvInfo != null && strengthLvInfo.ShowRedPointGoodsNums != null)
            {
                foreach (KeyValuePair<uint, ulong> kv in strengthLvInfo.ShowRedPointGoodsNums)
                {
                    goods = new PkgGoodsGidnum();
                    goods.gid = kv.Key;
                    goods.num = kv.Value;
                }
            }
            return goods;
        }

        /// <summary>
        /// 获得可强化已穿戴装备列表
        /// </summary>
        /// <returns></returns>
        public static List<GoodsEquip> GetStrengGoodsEquip()
        {
            List<GoodsEquip> InstallEquip = new List<GoodsEquip>();
            foreach (var kv in ItemManager.Instance.InstallEquip)
            {
                //EquipPosInfo info = ItemManager.Instance.StrengthInfos.Find(delegate (EquipPosInfo _info) { return (_info.Pos == kv.Value.EquipPos&& _info.Index == kv.Value.Index); });
                EquipPosInfo info = GetStrengthInfoByPosAndIndex(kv.Value.EquipPos, kv.Value.Index);
                if (info != null && info.IsCanStrength)
                {
                    InstallEquip.Add(kv.Value);
                }
            }

            InstallEquip.Sort(delegate (GoodsEquip equip1, GoodsEquip equip2)
            {
                DBEquipPos.DBEquipPosItem dbEquipPosItem1 = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(equip1.EquipPos);
                DBEquipPos.DBEquipPosItem dbEquipPosItem2 = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(equip2.EquipPos);
                if (dbEquipPosItem1 != null && dbEquipPosItem2 != null)
                {
                    if (dbEquipPosItem1.SortId > dbEquipPosItem2.SortId)
                    {
                        return 1;
                    }
                    else if (dbEquipPosItem1.SortId < dbEquipPosItem2.SortId)
                    {
                        return -1;
                    }
                }
                return 0;
            }
           );
            return InstallEquip;
        }

        /// <summary>
        /// 获得根据部位返回部位信息
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static EquipPosInfo GetPosInfoByPos_suitIgnoreIndex(uint pos, uint index)
        {
            EquipPosInfo _info = null;
            for (int find_index = 0; find_index < ItemManager.Instance.StrengthInfos.Count; ++find_index)
            {
                EquipPosInfo tmp_info = ItemManager.Instance.StrengthInfos[find_index];
                if (tmp_info.Pos == pos)
                {
                    if (index == tmp_info.Index)
                        return tmp_info;
                    else
                        _info = tmp_info;
                }
            }
            return _info;
        }

        /// <summary>
        /// 获得强化评分
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static int GetEquipStrengthRank(uint lv,GoodsEquip equip)
        {
            var attr = GetEquipStrengthAttr(lv, equip);
            return GetEquipBaseAttrScoreByType(AttrScoreGType.EquipStrength , attr); 
        }

        /// <summary>
        /// 根据类型返回基础属性对应系数
        /// </summary>
        /// <param name="type"></param>
        /// <param name="baseAttr"></param>
        /// <returns></returns>
        public static int GetEquipBaseAttrScoreByType(AttrScoreGType type , ActorAttribute baseAttr)
        {
            int score = 0;

            foreach (var item in baseAttr)
            {
                if (item.Value is DefaultActorAttribute)
                {
                    DefaultActorAttribute defaultAttr = item.Value as DefaultActorAttribute;
                    switch (type)
                    {
                        case AttrScoreGType.EquipBaptize:
                            score += (int)defaultAttr.GetEquipBaptizeScore();
                            break;
                        case AttrScoreGType.EquipBase:
                            score += (int)defaultAttr.GetEquipScore();
                            break;
                        case AttrScoreGType.EquipStrength:
                            score += (int)defaultAttr.GetEquipStrengthScore();
                            break;
                        case AttrScoreGType.DecorateBase:
                            score += (int)defaultAttr.GetEquipScore();
                            break;
                        case AttrScoreGType.DecorateStrength:
                            score += (int)defaultAttr.GetEquipStrengthScore();
                            break;

                        default:
                            score += (int)defaultAttr.Score;
                            break;
                    }
                }
            }
            return score;
        }

        /// <summary>
        /// 获得强化基础属性
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static ActorAttribute GetEquipStrengthAttr(uint Strengthlv , GoodsEquip equip)
        {
            uint lv = Strengthlv;
            if (lv > equip.MaxStrengthLv)
                lv = equip.MaxStrengthLv;
            return DBStrengthAttr.GetStrengthAttr(lv, equip.EquipPos);
        }

        /// <summary>
        /// 根据部位和index获取装备强化信息
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static EquipPosInfo GetStrengthInfoByPosAndIndex(uint pos, uint index)
        {
            for (int i = 0; i < ItemManager.Instance.StrengthInfos.Count; i++)
            {
                var info = ItemManager.Instance.StrengthInfos[i];

                if (info.Pos == pos && info.Index == index)
                {
                    return info;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据强化和洗炼的pkg信息返回部位信息
        /// </summary>
        /// <param name="pkgStrengthInfos"></param>
        /// <param name="pkgBaptizeInfos"></param>
        /// <returns></returns>
        public static Dictionary<uint, EquipPosInfo> GetEquipPosInfosByPkgInfos(List<PkgStrengthInfo> pkgStrengthInfos, List<PkgBaptizeInfo> pkgBaptizeInfos)
        {
            Dictionary<uint, EquipPosInfo> equipPosInfos = new Dictionary<uint, EquipPosInfo>();
            equipPosInfos.Clear();

            foreach (var pkgStrengthInfo in pkgStrengthInfos)
            {
                DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pkgStrengthInfo.pos);
                if (dbEquipPosItem != null && equipPosInfos.ContainsKey(pkgStrengthInfo.pos) == false)
                {
                    EquipPosInfo equipPosInfo = new EquipPosInfo();
                    equipPosInfo.Pos = pkgStrengthInfo.pos;
                    equipPosInfo.Index = pkgStrengthInfo.index;
                    equipPosInfo.IsCanStrength = dbEquipPosItem.CanStrength;
                    equipPosInfo.SortId = dbEquipPosItem.SortId;
                    equipPosInfo.StrengthLv = pkgStrengthInfo.lv;
                    equipPosInfo.StrengthDegree = pkgStrengthInfo.degree;
                    DBStrengthLv.StrengthLvInfo strengthLvInfo = DBStrengthLv.Instance.GetStrengthLvInfo(equipPosInfo.StrengthLv);
                    if (strengthLvInfo != null)
                    {
                        equipPosInfo.StrengthMaxDegree = strengthLvInfo.Degree;
                    }
                    equipPosInfo.StrengthStuff = EquipHelper.GetStrengthStuff(equipPosInfo.StrengthLv);
                    equipPosInfo.StrengthShowRedPointGoods = EquipHelper.GetStrengthShowRedPointGoods(equipPosInfo.StrengthLv);

                    equipPosInfos.Add(pkgStrengthInfo.pos, equipPosInfo);
                }
            }

            foreach (var pkgBaptizeInfo in pkgBaptizeInfos)
            {
                if (equipPosInfos.ContainsKey(pkgBaptizeInfo.pos) == true)
                {
                    EquipPosInfo equipPosInfo = equipPosInfos[pkgBaptizeInfo.pos];

                    if (equipPosInfo.BaptizeInfos == null)
                    {
                        equipPosInfo.BaptizeInfos = new Dictionary<uint, EquipBaptizeInfo>();
                    }
                    equipPosInfo.BaptizeInfos.Clear();
                    foreach (var baptizeGroove in pkgBaptizeInfo.infos)
                    {
                        EquipBaptizeInfo baptizeInfo = null;
                        if (baptizeGroove.attr != null && baptizeGroove.attr.Count > 0)
                        {
                            baptizeInfo = new EquipBaptizeInfo(baptizeGroove.id, baptizeGroove.state, baptizeGroove.attr[0], equipPosInfo.Pos, equipPosInfo.Index);
                            equipPosInfo.AllBaptizeAttr.Add(baptizeGroove.attr[0].attr, baptizeGroove.attr[0].value);
                        }
                        else
                        {
                            baptizeInfo = new EquipBaptizeInfo(baptizeGroove.id, baptizeGroove.state, null, equipPosInfo.Pos, equipPosInfo.Index);
                        }
                        equipPosInfo.BaptizeInfos.Add(baptizeInfo.Id, baptizeInfo);
                    }
                }
            }

            return equipPosInfos;
        }

        /// <summary>
        /// 根据强化和洗炼的pkg信息返回部位信息
        /// </summary>
        /// <param name="pkgStrengthInfos"></param>
        /// <param name="pkgBaptizeInfos"></param>
        /// <returns></returns>
        public static EquipPosInfo GetEquipPosInfoByPkgInfo(PkgStrengthInfo pkgStrengthInfo, PkgBaptizeInfo pkgBaptizeInfo)
        {
            if (pkgStrengthInfo == null || pkgBaptizeInfo == null)
            {
                return null;
            }

            EquipPosInfo equipPosInfo = new EquipPosInfo();

            if (pkgStrengthInfo != null)
            {
                DBEquipPos.DBEquipPosItem dbEquipPosItem = DBManager.Instance.GetDB<DBEquipPos>().GetOneInfo(pkgStrengthInfo.pos);
                if (dbEquipPosItem != null)
                {
                    equipPosInfo.Pos = pkgStrengthInfo.pos;
                    equipPosInfo.Index = pkgStrengthInfo.index;
                    equipPosInfo.IsCanStrength = dbEquipPosItem.CanStrength;
                    equipPosInfo.SortId = dbEquipPosItem.SortId;
                    equipPosInfo.StrengthLv = pkgStrengthInfo.lv;
                    equipPosInfo.StrengthDegree = pkgStrengthInfo.degree;
                    DBStrengthLv.StrengthLvInfo strengthLvInfo = DBStrengthLv.Instance.GetStrengthLvInfo(equipPosInfo.StrengthLv);
                    if (strengthLvInfo != null)
                    {
                        equipPosInfo.StrengthMaxDegree = strengthLvInfo.Degree;
                    }
                    equipPosInfo.StrengthStuff = EquipHelper.GetStrengthStuff(equipPosInfo.StrengthLv);
                    equipPosInfo.StrengthShowRedPointGoods = EquipHelper.GetStrengthShowRedPointGoods(equipPosInfo.StrengthLv);
                }
            }

            if (pkgBaptizeInfo != null)
            {
                if (equipPosInfo.Pos == pkgBaptizeInfo.pos)
                {
                    if (equipPosInfo.BaptizeInfos == null)
                    {
                        equipPosInfo.BaptizeInfos = new Dictionary<uint, EquipBaptizeInfo>();
                    }
                    equipPosInfo.BaptizeInfos.Clear();
                    foreach (var baptizeGroove in pkgBaptizeInfo.infos)
                    {
                        EquipBaptizeInfo baptizeInfo = null;
                        if (baptizeGroove.attr != null && baptizeGroove.attr.Count > 0)
                        {
                            baptizeInfo = new EquipBaptizeInfo(baptizeGroove.id, baptizeGroove.state, baptizeGroove.attr[0], equipPosInfo.Pos, equipPosInfo.Index);
                            equipPosInfo.AllBaptizeAttr.Add(baptizeGroove.attr[0].attr, baptizeGroove.attr[0].value);
                        }
                        else
                        {
                            baptizeInfo = new EquipBaptizeInfo(baptizeGroove.id, baptizeGroove.state, null, equipPosInfo.Pos, equipPosInfo.Index);
                        }
                        equipPosInfo.BaptizeInfos.Add(baptizeInfo.Id, baptizeInfo);
                    }
                }
            }

            return equipPosInfo;
        }

        #endregion

        #region 获取装备属性表述

        public static string GetSubAttrDes(IEquipAttribute attr)
        {
            uint color = 0;
            return GetSubAttrDes(attr.Id, attr.Values, "", out color);
        }

        public static string GetSubAttrDes(uint id, List<uint> values, string insert_str, out uint color)
        {
            string str = string.Empty;
            color = 0;
            var attrData = GetEquipAttrData(id);
            if (attrData != null)
                str = DBManager.GetInstance().GetDB<DBEquipSubAttr>().GetSubAttrDesc(attrData, insert_str, attrData.SubAttrId, out color, values.ToArray());
            return str;
        }


        /// <summary>
        /// 装备传奇属性描述
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static string GetEquipLegendAttrStr(GoodsEquip equip)
        {
            if (equip == null && equip.LegendAttrs == null)
            {
                return string.Empty;
            }
            List<KeyValuePair<string, uint>> strColorPairs = new List<KeyValuePair<string, uint>>();
            strColorPairs.Clear();
            foreach (var kv in equip.LegendAttrs)
            {
                uint color = 0;
                string des = GetSubAttrDes(kv.Id, kv.Values, " +", out color);
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

        public static List<string> GetLegendAttrDesStrArray(EquipAttributes attrs)
        {
            List<string> list = new List<string>();
            foreach (var kv in attrs)
            {
                uint color = 0;
                list.Add(GetSubAttrDes(kv.Id, kv.Values, " +", out color));
            }
            return list;
        }

        /// <summary>
        /// 根据星数返回升星属性
        /// </summary>
        /// <param name="star"></param>
        /// <returns></returns>
        public static ActorAttribute GetEquipStarAttr(int star)
        {
            string des = string.Empty;
            var starAttr = new ActorAttribute();
            List<Dictionary<string, string>> data_qua_color_attr = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_qua_color_attr", "lv", star.ToString());
            if (data_qua_color_attr.Count > 0)
            {
                Dictionary<string, string> table = data_qua_color_attr[0];
                string raw = string.Empty;
                if (table.TryGetValue("base_attr", out raw))
                {
                    var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
                    foreach (Match _match in matchs)
                    {
                        if (_match.Success)
                        {
                            uint id = (DBTextResource.ParseUI(_match.Groups[1].Value));
                            uint value = DBTextResource.ParseUI(_match.Groups[2].Value);
                            starAttr.Add(id, value);
                        }
                    }
                }
            }
            return starAttr;
        }

        /// <summary>
        /// 获取等阶名字
        /// </summary>
        public static string GetEquipLvStepName(uint lvStep)
        {
            return lvStep + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_57");
        }

        /// <summary>
        /// 将表格的属性字符串转换成属性结构
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ActorAttribute GetAttrbutesByDBStr(string str)
        {
            ActorAttribute list = new ActorAttribute();
            var matchs = Regex.Matches(str, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint id = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    var value = (DBTextResource.ParseL(_match.Groups[2].Value));
                    list.Add(id, value);
                }
            }
            return list;
        }

        #endregion

        #region 换装接口
        public static void DelEquipPart(List<uint> shows, DBAvatarPart.BODY_PART body_part)
        {
            if (shows == null)
                return;
            for(int index = shows.Count - 1; index >= 0; --index)
            {
                uint part_id = shows[index];
                var data = DBAvatarPart.GetAvatarPartData(part_id);
                if(data != null && data.part == body_part)
                {
                    shows.RemoveAt(index);
                }
            }
        }

        public static List<uint> GetShowsAfterDelEquipPart(List<uint> shows, DBAvatarPart.BODY_PART body_part)
        {
            List<uint> new_shows = new List<uint>();
            if (shows == null)
                return new_shows;
            for (int index = shows.Count - 1; index >= 0; --index)
            {
                uint part_id = shows[index];
                var data = DBAvatarPart.GetAvatarPartData(part_id);
                if (data != null && data.part != body_part)
                {
                    new_shows.Add(part_id);
                }
            }
            return new_shows;
        }
        #endregion
    }
}
