using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using xc.Equip;
using xc.ui.ugui;

namespace xc.Decorate 
{
    [wxb.Hotfix]
    public class DecorateHelper
    {
        /// <summary>
        ///  获取饰品强化属性
        /// </summary>
        public static ActorAttribute GetStrengthAttr(uint strengthLv, GoodsDecorate decorate)
        {
            ActorAttribute ret = new ActorAttribute();

            uint lv = strengthLv;
            if (lv > decorate.MaxStrengthLv)
                lv = decorate.MaxStrengthLv;

            string key = string.Format("{0}_{1}", (uint)decorate.Pos, lv);
            List<string> rec = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_decorate_str", "csv_id", key, "str_attrs");
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
        /// 获取已获得的附魔属性
        /// </summary>
        public static ActorAttribute GetAppendAttr(GoodsDecorate decorate)
        {
            ActorAttribute ret = new ActorAttribute();
            if (decorate == null || !decorate.IsWeared)
                return ret;

            DecoratePosInfo posInfo = ItemManager.Instance.DecoratePosInfos.Find(
                delegate (DecoratePosInfo _info) { return _info.Pos == decorate.Pos; });
            if (posInfo == null)
                return ret;

            foreach(var attr in posInfo.AppendAttrs)
            {
                if (attr.IsOpen)
                    ret.Add(attr.AttrId, (long)attr.Value);
            }

            return ret;
        }

        /// <summary>
        /// 获取饰品 突破后的附魔属性
        /// </summary>
        public static ActorAttribute GetBreakAppendAttr(GoodsDecorate decorate)
        {
            ActorAttribute ret = new ActorAttribute();
            if (decorate == null)
                return ret;

            DecoratePosInfo posInfo = ItemManager.Instance.DecoratePosInfos.Find(
                delegate (DecoratePosInfo _info) { return _info.Pos == decorate.Pos; });

            if (posInfo == null)
                return ret;

            uint nextBreakLv = posInfo.BreakLv + 1;
            foreach (var attr in posInfo.AppendAttrs)
            {
                if (attr.IsOpen || attr.BreakLv == nextBreakLv)
                    ret.Add(attr.AttrId, (long)attr.Value);
            }

            return ret;
        }

        /// <summary>
        /// 获取正穿戴着的指定部位的饰品
        /// </summary>
        public static GoodsDecorate GetWearingDecorateByPos(uint pos)
        {
            GoodsDecorate decorate = null;
            if (ItemManager.Instance.WearingDecorate.TryGetValue(pos, out decorate))
                return decorate;

            return null;
        }

        /// <summary>
        /// 获取背包指定部位的饰品列表
        /// <para>can_use_limit: 添加可以使用限制</para>
        /// </summary>
        public static List<GoodsDecorate> GetBagDecoratesByPos(uint pos, bool can_use_limit = false)
        {
            List<GoodsDecorate> ret = new List<GoodsDecorate>();

            foreach (var kv in ItemManager.Instance.DecorateGoodsOids)
            {
                if (kv.Value != null && kv.Value is GoodsDecorate)
                {
                    GoodsDecorate decorate = kv.Value as GoodsDecorate;
                    if (decorate.Pos == pos)
                    {
                        if (can_use_limit)
                        {
                            if (decorate.can_use)
                                ret.Add(decorate);
                        }
                        else
                        {
                            ret.Add(decorate);
                        }
                    }
                }
            }

            ret.Sort(delegate (GoodsDecorate lhs, GoodsDecorate rhs)
            {
                if (lhs.BaseScore > rhs.BaseScore)
                    return -1;

                else if (lhs.BaseScore < rhs.BaseScore)
                    return 1;

                else
                    return 0;
            });

            return ret;
        }

        /// <summary>
        /// 获取饰品指定部位的部位信息
        /// </summary>
        public static DecoratePosInfo GetPosInfo(uint pos)
        {
            foreach(var info in ItemManager.Instance.DecoratePosInfos)
            {
                if (info.Pos == pos)
                    return info;
            }

            return null;
        }

        /// <summary>
        /// 判断一件饰品是否比现穿戴饰品更好(不包含等级限制)
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static bool IsBetterDecorateCanQuickUse(GoodsDecorate decorate)
        {
            if (decorate == null)
                return false;

            // 支持快捷使用 
            if (!decorate.is_quickuse)
                return false;

            // 是否能使用
            if (!decorate.can_use)
                return false;

            var wearingDecorate = GetWearingDecorateByPos(decorate.Pos);
            if (wearingDecorate == null)
                return true;

            //基础评分
            if (decorate.BaseScore <= wearingDecorate.BaseScore)
                return false;

            return true;
        }

        /// <summary>
        /// 返回背包中某个部位最好饰品(可以穿戴)
        /// </summary>
        /// <returns></returns>
        public static GoodsDecorate GetBestBagDecorate()
        {
            GoodsDecorate ret = null;

            foreach(var data in ItemManager.Instance.DecoratePosInfos)
            {

                if (ItemManager.Instance.CheckHavePos(GameConst.GIVE_TYPE_DECORATE, data.Pos))
                    continue;


                if (!data.IsUnlock)
                    continue;

                var wearingDecorate = GetWearingDecorateByPos(data.Pos);
                var canUseList = GetBagDecoratesByPos(data.Pos, true);

                if (canUseList != null && canUseList.Count > 0)
                {
                    int score = -99999;
                    if (wearingDecorate != null)
                        score = wearingDecorate.BaseScore;

                    foreach (var value in canUseList)
                    {
                        if (ItemManager.Instance.mCloseQuickUseGoodsIdArray.ContainsKey(value.type_idx))
                            continue;

                        if (value.BaseScore > score)
                        {
                            ret = value;
                            score = value.BaseScore;
                        }
                    }
                }

                if (ret != null)
                    return ret;
            }
           
            return ret;
        }

        /// <summary>
        /// 获取玩家穿戴的饰品总评分
        /// </summary>
        /// <returns></returns>
        public static int GetPlayerDecorateSumScore()
        {
            int ret = 0;

            foreach(var kv in ItemManager.Instance.WearingDecorate)
            {
                ret += kv.Value.Score;
            }

            return ret;
        }

        /// <summary>
        /// 获取玩家穿戴饰品总属性描述
        /// </summary>
        public static List<DBDecorate.LegendAttrDescItem> GetPlayerDecorateSumAttrsDesc()
        {
            ActorAttribute baseAtrrs = new ActorAttribute();
            EquipAttributes legendAttrs = new EquipAttributes();

            foreach (var kv in ItemManager.Instance.WearingDecorate)
            {
                var decorate = kv.Value;
                if (!decorate.IsWeared)
                    continue;

                // 基础属性
                foreach(var baseKv in decorate.BasicAttrs)
                {
                    baseAtrrs.Add(baseKv.Value.Id, baseKv.Value.Value);
                }

                // 强化属性
                var strengthenAttr = GetStrengthAttr(decorate.StrengthLv, decorate);

                foreach(var strengthenKv in strengthenAttr)
                {
                    baseAtrrs.Add(strengthenKv.Value.Id, strengthenKv.Value.Value);
                }

                // 附魔属性
                var appendAttr = GetAppendAttr(decorate);

                foreach(var appendKv in appendAttr)
                {
                    baseAtrrs.Add(appendKv.Value.Id, appendKv.Value.Value);
                }

                // 传奇属性
                foreach (var baseKv in decorate.LegendAttrs)
                {
                    var attrId = baseKv.Id;

                    List<uint> values = new List<uint>();

                    foreach (var e in baseKv.Values)
                    {
                        values.Add(e);
                    }
                    
                    legendAttrs.AddValue(attrId, values, true);
                }
            }

            // 套装属性
            var suitAttrList = GetDecorateSuitAttrList();

            foreach (var e in suitAttrList)
            {
                if (e.Count >= 2)
                {
                    uint attrId = e[0];
                    uint value = e[1];

                    if (attrId == GameConst.AR_ATTACK_BASE) // 基础攻击
                    {
                        // 最小攻击
                        var minAtk = baseAtrrs.GetAttr(GameConst.AR_MIN_ATTACK_BASE);
                        if (null != minAtk)
                            baseAtrrs.Add(GameConst.AR_MIN_ATTACK_BASE, value);

                        // 最大攻击
                        var maxAtk = baseAtrrs.GetAttr(GameConst.AR_MAX_ATTACK_BASE);
                        if (null != maxAtk)
                            baseAtrrs.Add(GameConst.AR_MAX_ATTACK_BASE, value); ;

                        if (null == minAtk && null == maxAtk)
                            baseAtrrs.Add(attrId, value);
                    }
                    else
                    {
                        baseAtrrs.Add(attrId, value);
                    }
                }
            }

            var ret = new List<DBDecorate.LegendAttrDescItem>();

            var baseDescArray = EquipHelper.GetEquipBaseDesItemArray(baseAtrrs, true);

            foreach (var item in baseDescArray)
            {
                var descItem = new DBDecorate.LegendAttrDescItem();
                descItem.Name = item.PropName;
                descItem.ValueStr = item.ValueStr;

                ret.Add(descItem);
            }

            foreach (var kv in legendAttrs)
            {
                var equipAttrData = EquipHelper.GetEquipAttrData(kv.Id);
                var attrList = GetSubAttrDescEx(equipAttrData, kv.Values.ToArray());
                if (attrList.Count >= 2)
                {
                    var descItem = new DBDecorate.LegendAttrDescItem();
                    descItem.Name = attrList[0];
                    descItem.ValueStr = attrList[1];

                    ret.Add(descItem);
                }
            }

            return ret;
        }
        /// <summary>
        /// 饰品当前激活套装的属性
        /// </summary>
        /// <returns></returns>
        public static List<List<uint>> GetDecorateSuitAttrList()
        {
            var ret = new List<List<uint>>();

            if (LuaScriptMgr.Instance != null)
            {
                object[] param = { };
                System.Type[] return_type = { typeof(List<string>) };
                object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "DecorateWearManager_GetAttrList", param, return_type);
                if (objs != null && objs.Length > 0)
                {
                    if (objs[0] != null)
                    {
                        List<string> attrList = (List<string>)objs[0];

                        foreach (var strAttr in attrList)
                        {
                            string[] arrSplite = strAttr.Split('_');
                            if (arrSplite.Length >= 2)
                            {
                                uint attrId = DBTextResource.ParseUI(arrSplite[0]);
                                uint value = DBTextResource.ParseUI(arrSplite[1]);
                                if (attrId > 0 && value > 0)
                                {
                                    var data = new List<uint>();
                                    data.Add(attrId);
                                    data.Add(value);

                                    ret.Add(data);
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// 饰品传奇属性描述
        /// </summary>
        /// <param name="equip"></param>
        /// <returns></returns>
        public static string GetDecorateLegendAttrStr(GoodsDecorate decorate)
        {
            if (decorate == null && decorate.LegendAttrs == null)
            {
                return string.Empty;
            }

            List<KeyValuePair<string, uint>> strColorPairs = new List<KeyValuePair<string, uint>>();
            strColorPairs.Clear();
            foreach (var kv in decorate.LegendAttrs)
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

        /// <summary>
        /// 返回饰品星级
        /// <returns></returns>
        public static uint GetDecorateStar(GoodsDecorate decorate)
        {
            uint ret = 0;
            if (decorate == null || decorate.LegendAttrs == null)
            {
                return 0;
            }

            if (decorate.ServerStar != 0xffffff)
                return decorate.ServerStar;

            bool has_attrs = false;
            foreach (var kv in decorate.LegendAttrs)
            {
                var attrData = EquipHelper.GetEquipAttrData(kv.Id);
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
                                    ret++;//对应就是0~4品质
                                }
                            }
                        }
                    }
                }
            }

            if (has_attrs == false)
            {
                if (decorate.DbData != null)
                    ret = decorate.DbData.DefaultStar;
            }

            return ret;
        }

        public static void ShowDecorateTipsWindowLayer(int layer, GoodsDecorate decorate, string showType)
        {
            // 饰品经验道具部位Id
            uint expPos = xc.GameConstHelper.GetUint("GAME_DECORATE_EXP_GOODS");
            if (decorate.Pos == expPos)
            {
                UIManager.Instance.ShowWindowLayer("UIGoodsTipsWindow", layer, decorate, "Player");
            }
            else
            {
                UIManager.Instance.ShowWindowLayer("UIDecorateTipsWindow", layer, decorate, showType);
            }
        }

        /// <summary>
        /// 展示饰品Tips 
        /// </summary>
        /// <returns></returns>
        public static void ShowDecorateTipsWindow(GoodsDecorate decorate, string showType)
        {
            // 饰品经验道具部位Id
            uint expPos = xc.GameConstHelper.GetUint("GAME_DECORATE_EXP_GOODS");
            if (decorate.Pos == expPos)
            {
                UIManager.Instance.ShowWindow("UIGoodsTipsWindow", decorate, showType);
            }
            else
            {
                UIManager.Instance.ShowWindow("UIDecorateTipsWindow", decorate, showType);
            }
        }

        /// <summary>
        /// 展示饰品Tips
        /// </summary>
        /// <returns></returns>
        public static void ShowDecorateTipsWindow(GoodsDecorate decorate, string showType, uint strengthenLv)
        {
            // 饰品经验道具部位Id
            uint expPos = xc.GameConstHelper.GetUint("GAME_DECORATE_EXP_GOODS");
            if (decorate.Pos == expPos)
            {
                UIManager.Instance.ShowWindow("UIGoodsTipsWindow", decorate, showType);
            }
            else
            {
                UIManager.Instance.ShowWindow("UIDecorateTipsWindow", decorate, showType, strengthenLv);
            }
        }

        public static List<string> GetSubAttrDescEx(EquipAttrData attrData, params uint[] values)
        {
            List<string> ret = new List<string>();

            EquipSubAttrData data = DBManager.GetInstance().GetDB<DBEquipSubAttr>().GetSubAttrData(attrData.SubAttrId);

            if (data != null)
            {
                List<string> des_value = new List<string>();
                for (int i = 0; i < data.DesType.Count; i++)
                {
                    if (i < values.Length)
                    {
                        switch (data.DesType[i])
                        {
                            case 0: // 整行
                                {
                                    string val = values[i].ToString();

                                    des_value.Add(val);
                                }
                                break;
                            case 1: // 浮点
                                {
                                    string val = (values[i] / ActorHelper.UnitConvert).ToString("0.00");
                                    val = ActorUtils.Instance.TrimFloatStr(val);
                                    des_value.Add(val);
                                }
                                break;
                            case 2: // 百分比
                                {
                                    string val_noSign = (values[i] / ActorHelper.DisplayPercentUnitConvert).ToString("0.00");
                                    val_noSign = ActorUtils.Instance.TrimFloatStr(val_noSign);
                                    string val = val_noSign + "%";
                                    des_value.Add(val);
                                }
                                break;
                        }
                    }
                }

                string data_des = data.Des;
                int startIdx = data_des.IndexOf("{", 0);
                string name = data_des.Substring(0, startIdx);
                string valueFormat = data_des.Substring(startIdx);
                string valueStr = "";

                if (des_value.Count > 0)
                    valueStr = string.Format(valueFormat, des_value.ToArray());

                ret.Add(name);
                ret.Add(valueStr);
            }

            return ret;
        }
    }
}
