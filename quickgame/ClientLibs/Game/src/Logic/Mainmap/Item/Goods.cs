using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace xc
{
    public interface Goods
    {
        /// <summary>
        /// 物品类型
        /// </summary>

        ulong id { set; get; }//唯一id
        uint bind { set; get; }//是否绑定 0 非绑定 1绑定
        uint type_idx { set; get; }// 主类型id
        uint color_type { set; get; }//品质
        uint icon_id { set; get; } //图片id
        string name { set; get; }// 名字
        string raw_name { set; get; }
        ulong num { set; get; }//个数
        string src_description { set; get; } //表中的说明字段
        string description { set; get; }//说明
        uint sub_type { set; get; }// 子类型
        string drop_effect { set; get; }
        string effect { set; get; }//效果
        bool can_use { set; get; }//是否可发送使用
        uint use_lv { set; get; }//使用等级
        bool tips_show { set; get; }//是否提示
        uint start_cd { set; get; }//cd开始时间
        uint cd { set; get; }//cd到期时间戳
        uint expire_time { set; get; }//保护时间
        uint expire_time_inTmpl { set; get; }//有效期(物品表中数据)
        uint main_type { set; get; }//主类型
        string arg { set; get; }//使用参数
        uint client_use { set; get; }//客户端使用类型（单指不与服务端交互）
        uint need_count { set; get; }//所需格子数
        uint recycle_price { set; get; }//回收收益价格金币
        uint use_job { set; get; }//使用条件_职业
        uint use_transfer { set; get; }//使用条件_转职次数
        string gain_text { set; get; }//获得途径文本
        string gain_from { set; get; }//获得途径导航
        bool is_quickuse { set; get; }//是否快速使用
        bool is_quickuse_always { set; get; }// 是否一直快速使用(对于非新增加物品)
        bool is_sell_confirmation { set; get; }//是否出售二次确认
        uint sort_id { set; get; }//背包排序
        uint sort_top { set; get; }//置顶排序


        bool is_equipUp { set; get; }//是否是上升装备（临时背包排序）
        bool is_equipDown { set; get; } //是否是下降装备（临时背包排序）
        bool is_decorateUp { set; get; }//是否是上升饰品（临时背包排序）

        bool is_mutil_use { set; get; }//是否批量使用
        uint cd_id { set; get; }    //CD的ID (2018/1/15)
        bool isUpdateFlag { set; get; } //2018/1/19
        bool isDefaultGoods { get; set; }    //是否是默认物品ID
        uint unknownGoodsId { get; set; }    //未知的物品ID
        DBRewardGroup.DBRewardGroupInfo m_group_info { get; set; }   //奖励组
        uint price_recommend { get; set; } //推荐价格
        float price_lower_limit { get; set; } //市场单价下限
        float price_upper_limit { get; set; } //市场单价上限
        uint mktype_1 { get; set; } //市场一级类型
        uint mktype_2 { get; set; } //市场二级类型
        uint daily_use_limit { get; set; }  //每天使用的最大次数（0表示不限制次数）
        uint guild_wpoint { get; set; } //帮派捐赠，兑换价格
        uint max_stack { get; set; } //最大堆叠数
        uint create_time { set; get; }  //物品创建时间
        bool is_display_goods { set; get; } //是否是展示类物品
        uint wing_exp { set; get; } //翅膀精炼获得的经验
        uint m_level_in_add_lv_exp { set; get; }
        bool is_quickuse_autoUse { set; get; }//是否快速使用(有倒计时)
        bool is_deleted { set; get; }//是否已经删除
        uint show_step { set; get; }//icon右上角显示的阶数，0和不填不显示，填3显示3
        uint is_precious { set; get; }
        uint discount { set; get; }//显示折扣
        uint overdue_notice_time { set; get; }//即将过期提示时间
        Goods Copy(Goods goods);
        Goods Clone();
        void RefreshEquipUp();
        void RefreshDecorateUp();
        void ParseClientGoodsStr_inner(Dictionary<string, string> param_dict);
        void GetClientGoodsStr_inner(ref System.Text.StringBuilder builder);
        bool IsInEnableTime();  //是否在有效期内
    }

    [wxb.Hotfix]
    public class GoodsFactory
    {
        public static Goods Create(uint typeId, Net.PkgGoodsInfo info)
        {
            uint mainType = GoodsHelper.GetGoodsType(typeId);
            return Create(mainType, typeId, info);
        }

        public static Goods Create(uint mainType , uint typeId , Net.PkgGoodsInfo info)
        {
            Goods goods = null;
            switch (mainType)
            {
                case GameConst.GIVE_TYPE_EQUIP:
                    {
                        goods = new GoodsEquip(typeId , info);
                        break;
                    }
                case GameConst.GIVE_TYPE_SOUL:
                    {
                        goods = new GoodsSoul(typeId, info);
                        break;
                    }
                case GameConst.GIVE_TYPE_DECORATE:
                    {
                        goods = new GoodsDecorate(typeId, info);
                        break;
                    }
                case GameConst.GIVE_TYPE_GOD_EQUIP:
                    {
                        goods = new GoodsGodEquip(typeId, info);
                        break;
                    }
                case GameConst.GIVE_TYPE_RIDE_EQUIP:
                    {
                        goods = new GoodsMountEquip(typeId, info);
                        break;
                    }
                case GameConst.GIVE_TYPE_LIGHT_SOUL:
                    {
                        if  (info != null)
                        {
                            goods = new GoodsLightWeaponSoul(info);
                            break;
                        }
                        goods = new GoodsLightWeaponSoul(typeId);
                        break;
                    }
                case GameConst.GIVE_TYPE_MAGIC_EQUIP:
                    {
                        goods = new GoodsMagicEquip(typeId, info);
                        break;
                    }
                case GameConst.GIVE_TYPE_ARCHIVE:
                {
                    if (info != null)
                    {
                        goods = new GoodsItem(info) {bag_type = GameConst.BAG_TYPE_ARCHIVE};
                    }
                    else
                    {
                        goods = new GoodsItem(typeId) {bag_type = GameConst.BAG_TYPE_ARCHIVE};
                    }
                    break;
                }

                default:
                    {
                        var goods_info = GoodsHelper.GetGoodsInfo(typeId);
                        if(goods_info != null)
                        {
                            string luaScript = GoodsHelper.GetGoodsLuaScriptByGoodsId(typeId);
                            if (!string.IsNullOrEmpty(luaScript))
                            {
                                if (LuaScriptMgr.Instance == null)
                                {
                                    goods = new GoodsItem(typeId);
                                }
                                if (LuaScriptMgr.Instance.IsLuaScriptExist(luaScript))
                                {
                                    goods = new GoodsLuaEx(typeId, luaScript);
                                }
                                else
                                {
                                    Debug.LogWarning(string.Format("{0}未找到名字为的组件", luaScript));
                                    goods = null;
                                }
                            }
                            else
                            {
                                if (info != null)
                                {
                                    goods = new GoodsItem(info);
                                    break;
                                }
                                goods = new GoodsItem(typeId);
                            }
                        }
                        break;
                    }
            }
            if(goods == null)
            {//无法正常创建物品
                goods = GetDefaultGoods(typeId);
            }
            return goods;
        }

        private static uint mDefaultGoodsId = 0;
        private static bool isInitDefaultGoodsId = false;
        public static uint DefaultGoodsId
        {
            get {
                if (isInitDefaultGoodsId == false)
                {
                    isInitDefaultGoodsId = true;
                    mDefaultGoodsId = GameConstHelper.GetUint("GAME_GOODS_DEFAULT_ID");
                }
                return mDefaultGoodsId;
            }
        }
        public static GoodsItem GetDefaultGoods(uint typeId)
        {
            GameDebug.LogError("return default goods! typeId = " + typeId);
            GoodsItem goods = new GoodsItem(DefaultGoodsId);
            goods.isDefaultGoods = true;
            goods.unknownGoodsId = typeId;
            return goods;
        }
        public static void Update(Net.PkgGoodsInfo info, Goods goods)
        {
            if (info == null || goods == null)
                return;
            if (goods.type_idx != info.gid)
            {//更换了模型ID
                goods.type_idx = info.gid;
                var goods_info = GoodsHelper.GetGoodsInfo(info.gid);
                if (goods_info != null)
                {
                    goods.main_type = goods_info.type;
                    if(goods is GoodsItem)
                        (goods as GoodsItem).SetIdFindData(info.gid);
                }
            }
            goods.num = info.num;
            goods.bind = info.bind;
            goods.expire_time = info.expire_time;
            goods.create_time = info.create_time;
            if (info.equip != null) //代表它为装备
            {
                GoodsEquip equip = goods as GoodsEquip;
                if(equip != null)
                {
                    equip.UpdateAttr(info.gid, info);
                    equip.UpdateGem(info);
                }
            }
            else if (info.soul != null)
            {
                GoodsSoul soul = goods as GoodsSoul;
                if(soul != null)
                    soul.UpdateSoul(info.soul);
            }
            else if (info.decorate != null)
            {
                GoodsDecorate decorate = goods as GoodsDecorate;
                if (decorate != null)
                    decorate.UpdateAttr(info.gid, info);

            }else if (info.god_equip != null)
            {
                GoodsGodEquip godEquip = goods as GoodsGodEquip;
                if (godEquip != null)
                    godEquip.UpdateGodEquip(info.god_equip);
            }
            else if (info.ride_equip != null)
            {
                //GoodsMountEquip mountEquip = goods as GoodsMountEquip;
                //if (mountEquip != null)
                //    mountEquip.UpdateMountEquip(info.ride_equip);
            }
            else if (info.magic_equip != null)
            {
                GoodsMagicEquip magicEquip = goods as GoodsMagicEquip;
                if (magicEquip != null)
                    magicEquip.UpdateMagicEquip(info.magic_equip);
            }

        }
    }
}

