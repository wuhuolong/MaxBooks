using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace xc
{

    [wxb.Hotfix]
    public class GoodsItem:Goods
    {
        public bool is_equipUp { set; get; }
        public bool is_equipDown { set; get; } //是否是下降箭头
        public bool is_decorateUp { set; get; }
        public bool isUpdateFlag { set; get; }  //是否被标记过(常用过界面中的勾选，如回收界面标记是否已经判定过勾选)
        public bool isUICheck { set; get; }  //是否被勾选
        public uint recycle_price { set; get; }//回收收益价格金币
        public uint need_count { set; get; }//所需格子
        public uint expire_time { set; get;}//保护时间
        public uint expire_time_inTmpl { set; get; }
        public uint create_time { set; get; }//物品创建时间
        public bool is_display_goods { set; get; } //是否是展示类物品
        public uint show_step { get; set; }//icon右上角显示的阶数，0和不填不显示，填3显示3
        public uint cd{set; get;}
        public uint start_cd{set; get;}
        private string mRawName = "";
        public uint main_type{set;get;}
        public string raw_name
        {
            get
            {
                return mRawName; 
            }
            set
            {
                mRawName = value;
            }
        }
        public uint use_lv{set;get;}
        public string arg{set; get;}//使用参数
        public uint client_use{set; get;}//客户端使用类型（单指不与服务端交互）
        private bool mTipsShow = false;
        public bool tips_show{
            set
            {
                mTipsShow = value;
            }
            get{
                return mTipsShow;
            }
        }//是否提示
        private string mEffect = "0";
        public string gain_text { set; get; }//获得途径文本
        public bool is_mutil_use { set; get; }//是否可以被批量使用
        public string gain_from { set; get; }//获得途径导航
        public uint use_job { set; get; }//使用条件_职业
        public uint use_transfer { set; get; }//使用条件_转职次数
        public uint use_pay { set; get; }//使用条件_充值额度
        public uint use_cost { set; get; }//使用条件_消费额度
        public uint sort_id { set; get; }//背包排序
        public uint sort_top { set; get; }//置顶排序
        public bool is_quickuse { set; get; }//是否快速使用
        public bool is_quickuse_always { set; get; }// 是否一直快速使用(对于非新增加物品)
        public bool is_quickuse_autoUse { set; get; }//是否快速使用(有倒计时)
        public bool is_deleted { set; get; } //是否已经删除
        public bool is_sell_confirmation { set; get; }
        public uint cd_id { set; get; }    //CD的ID (2018/1/15)

        public uint price_recommend { get; set; } //推荐价格
        public float price_lower_limit { get; set; } //市场单价下限
        public float price_upper_limit { get; set; } //市场单价上限
        public uint mktype_1 { get; set; } //市场一级类型
        public uint mktype_2 { get; set; } //市场二级类型
        public uint daily_use_limit { get; set; } //每日使用次数上限
        public uint guild_wpoint { get; set; }
        public uint max_stack { get; set; }
        public uint wing_exp { get; set; } //精炼翅膀获得的经验

        Net.PkgGoodsInfo pkgGoodsInfo;

        public string effect
        {
            set
            {
                mEffect = value;
            }
            get
            {
                return mEffect;
            }
        }
        public bool can_use
        {
            set
            {
                
            }
            get
            {
                if (mEffect.CompareTo("0") == 0&& client_use == 0)
                    return false;

                if ((this.use_job == 0 || this.use_job == LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
                    //&& this.use_lv <= LocalPlayerManager.Instance.LocalActorAttribute.Level
                    && (expire_time == 0 || expire_time >= Game.Instance.ServerTime))
                    return true;
                else
                    return false;
            }
        }


        private ulong mId = 0;//唯一id
        public ulong id {
            set{
                mId = value;
            }
            get{
                return mId;
            }
        }
        private uint mType_idx;
        public uint type_idx  // 类型id
        {
            set{
                mType_idx = value;
            }
            get{
                return mType_idx;
            }
        }
        private uint mColor_type;
        public uint color_type //物品通用品质
        {
            set{
                mColor_type = value;
            }
            get
            {
                return mColor_type;
            }
        }
        private uint mBind;
        private bool mGoodsTmplIsBind = false;    //背包是否是绑定状态
        public uint bind//是否绑定 0 非绑定 1绑定
        {
            set{
                if(mGoodsTmplIsBind)
                {//如果物品数据已经绑定，不允许设定其他任何值
                    mBind = 1;
                    return;
                }
                mBind = value;
            }
            get{
                return mBind;
            }
        }
        private uint mIcon_id;
        public uint icon_id//图片id
        {
            set{
                mIcon_id = value;
            }
            get{
                return mIcon_id;
            }
        }
        private string mName = "";
        public string name // 名字
        {
            set{
                mName = value;
            }
            get{
                return mName;
            }
        }
        private ulong mNum;
        public ulong num//个数
        {
            set{
                mNum = value;
            }
           get
            {
                return mNum;
            }
        }
        private string mDescription = "";

        public string src_description { set; get; } //表中的说明字段
        public string description//说明
        {
            set{
                mDescription = value;
            }
            get {
                if(effect == "add_lv_exp")
                {
                    ulong exp_num = 0;
                    uint player_level = LocalPlayerManager.Instance.Level;
                    
                    if (player_level <= m_level_in_add_lv_exp)
                    {//直接升一级
                        DBLevelExp.LevelExpInfo info = DBLevelExp.Instance.GetLevelInfo(player_level);
                        if (info != null)
                            exp_num = info.Exp;
                    }
                    else if(m_group_info != null)
                    {
                        exp_num = (ulong)m_group_info.GetExpOrCoinNum(player_level);
                    }
                    string num_str = xc.ui.UIWidgetHelp.GetLargeNumberString(exp_num);
                    this.description = string.Format(this.src_description, num_str);
                }
                else if(m_group_info != null)
                {
                    uint player_level = LocalPlayerManager.Instance.Level;
                    ulong expOrCoinNum = (ulong)m_group_info.GetExpOrCoinNum(player_level);
                    string num_str = xc.ui.UIWidgetHelp.GetLargeNumberString(expOrCoinNum);
                    if (m_group_info.IsCoinReward)
                    {
                        this.description = string.Format(DBConstText.GetText("GAME_GOODS_TIPS_COIN_FORMAT"), num_str);
                    }
                    else if (m_group_info.IsExpReward)
                    {
                        this.description = string.Format(this.src_description, num_str);
                    }
                }

                if (this.daily_use_limit != 0)
                {
                    string final_desc = mDescription;
                    if (final_desc != "")
                        final_desc = final_desc + "\n";
                    uint has_use_times = ItemManager.Instance.HasUseTimesByGid(this.type_idx);
                    if (has_use_times < this.daily_use_limit)
                    {//有可用次数
                        final_desc = final_desc + string.Format(DBConstText.GetText("GAME_GOODS_HAS_TIMES_FOR_LIMIT_GOODS"), this.daily_use_limit - has_use_times, this.daily_use_limit);
                    }
                    else
                    {
                        final_desc = final_desc + string.Format(DBConstText.GetText("GAME_GOODS_NO_TIMES_FOR_LIMIT_GOODS"), this.daily_use_limit);
                    }
                    return final_desc;
                }

                return mDescription;
            }
        }
        private uint mSub_type = 1;
        public uint sub_type//;
        {
            set{
                mSub_type = value;
            }
            get{
                return mSub_type;
            }
        }
        private string mDrop_effect = "";
        public string drop_effect
        {
            set{
                mDrop_effect = value;
            }
            get{
                return mDrop_effect;
            }
        }

        public uint is_precious { get; set; }
        public uint discount { get; set; }
        public uint overdue_notice_time { get; set; }

        public uint IsSourceCompose { set; get; }  // 是否由合成产出. 1-合成产出 0-非合成产出

        public uint m_level_in_add_lv_exp { get; set; } //只有在 effect = "add_lv_exp" 才使用
        public DBRewardGroup.DBRewardGroupInfo m_group_info { get; set; }   //奖励组

        public virtual void CreateGoodsByTypeId(uint _id)
        {
            this.type_idx = _id;
            var goods_info = GoodsHelper.GetGoodsInfo(_id);
            if(goods_info != null)
            {
                this.main_type = goods_info.type;
                this.SetIdFindData(_id);
            }
            else
                GameDebug.LogWarning(string.Format("itme gid: {0} not exist", _id));
        }

        /// <summary>
        /// 根据TypeId返回默认Goods
        /// </summary>
        public virtual Goods SetIdFindData(uint _id)
        {
            this.type_idx = _id;

            var goods_info = GoodsHelper.GetGoodsInfo(_id);
            if(goods_info != null)
            {
                this.sub_type = goods_info.sub_type;
                this.effect = goods_info.effect; 
                this.mRawName = goods_info.name;
                this.name = string.Format("{0}{1}</color>", GoodsHelper.GetGoodsColor(goods_info.color_type), goods_info.name);
                bool is_special_desc = false;
                if (goods_info.effect == "reward_group")//经验和金币类的礼包类的描述需要额外显示
                {
                    List<uint> reward_group_id_array = DBTextResource.ParseArrayUint(goods_info.arg);
                    if(reward_group_id_array != null)
                    {
                        DBRewardGroup db_reward_group = DBManager.Instance.GetDB<DBRewardGroup>();
                        for (int index = 0; index < reward_group_id_array.Count; ++index)
                        {
                            uint reward_group_id = reward_group_id_array[index];
                            DBRewardGroup.DBRewardGroupInfo group_info = db_reward_group.GetOneDBRewardGroupInfo(reward_group_id);
                            if(group_info != null && 
                                (group_info.IsCoinReward || group_info.IsExpReward))
                            {
                                m_group_info = group_info;
                                is_special_desc = true;
                            }

                        }
                    }
                }
                else if(goods_info.effect == "add_lv_exp")//等级经验丹
                {
                    List<uint> arg_array = DBTextResource.ParseArrayUint(goods_info.arg, ",");
                    if (arg_array != null && arg_array.Count >= 2)
                    {
                        uint level = arg_array[0]; //直接升级的等级
                        uint reward_id = arg_array[1]; //奖励ID
                        m_level_in_add_lv_exp = level;
                        DBRewardGroup.DBRewardGroupInfo group_info = new DBRewardGroup.DBRewardGroupInfo();
                        group_info.RewardId = reward_id;
                        if (group_info != null &&
                            (group_info.IsCoinReward || group_info.IsExpReward))
                        {
                            m_group_info = group_info;
                            is_special_desc = true;
                        }
                    }
                }
                string des = goods_info.desc;
                this.src_description = goods_info.desc;
                if (des.CompareTo("") != 0 && is_special_desc == false)
                {
                    if(des[0] == '"')
                        this.description = des.Substring(1 , des.Length-2);
                    else
                        this.description = des;
                }

                this.arg = goods_info.arg;
                this.use_lv = goods_info.use_lv;
                this.use_job = goods_info.use_job;
                this.use_transfer = goods_info.use_transfer;
                this.gain_text = goods_info.gain_text;
                this.cd_id = goods_info.cd_id;
                this.is_mutil_use = goods_info.is_mutil_use == 1 ? true : false;
                this.gain_from = goods_info.gain_from;
                uint is_quick_int = goods_info.is_quick;
                if (is_quick_int == 0)
                    this.is_quickuse = false;
                else
                    this.is_quickuse = true;

                if (is_quick_int == 2)
                    this.is_quickuse_autoUse = true;
                else
                    this.is_quickuse_autoUse = false;//是否快速使用(有倒计时)

                if (is_quick_int == 3)
                    this.is_quickuse_always = true;
                else
                    this.is_quickuse_always = false;

                this.is_sell_confirmation = goods_info.is_confirmation == 1 ? true : false;
                this.client_use = goods_info.client_use;
                //暂时没有子类型
                //this.sub_type = DBTextResource.ParseUI(data["sub_type"]);
                this.color_type = goods_info.color_type; 
                this.icon_id = goods_info.icon_id;
                this.sort_id = goods_info.sort_id;
                this.sort_top = goods_info.sort_top;
                this.recycle_price = goods_info.sell_price;

                if (goods_info.is_show == 0)
                    this.tips_show = false;
                else
                    this.tips_show = true; 

                this.price_recommend = goods_info.price_recommend;
                this.price_lower_limit = goods_info.price_lower_limit;
                this.price_upper_limit = goods_info.price_upper_limit;
                this.mktype_1 = goods_info.mktype_1;
                this.mktype_2 = goods_info.mktype_2;
                this.daily_use_limit = goods_info.daily_use_limit;
                this.guild_wpoint = goods_info.guild_wpoint;
                this.max_stack = goods_info.max_stack;
                this.is_display_goods = goods_info.is_display_goods == 1;
                this.show_step = goods_info.show_step;
                uint tmpl_is_bind = goods_info.bind;
                if (tmpl_is_bind == 1)
                    mGoodsTmplIsBind = true;
                this.bind = tmpl_is_bind;
                this.wing_exp = goods_info.wing_exp;
                this.expire_time_inTmpl = goods_info.expire_time;
                this.is_precious = goods_info.is_precious;
                this.discount = goods_info.discount;
                this.overdue_notice_time = goods_info.overdue_notice_time;
            }
            return this;
        }



        public Goods Clone()
        {
            if (pkgGoodsInfo != null)
                return new GoodsItem(pkgGoodsInfo);
            else
            {
                var goods = new GoodsItem(type_idx);
                goods.id = id;
                goods.bind = bind;
                goods.num = num;
                goods.expire_time = expire_time;
                return goods;
            }

        }

        /// <summary>
        /// goods之间赋值要采用此方法
        /// </summary>
        public Goods Copy(Goods _goods)
        {
            //GoodsItem goods = new GoodsItem(_goods.type_idx);
            // 类型id
            id = _goods.id;
            bind = _goods.bind;
            type_idx = _goods.type_idx; 
            color_type = _goods.color_type;
            icon_id = _goods.icon_id;
            name = _goods.name;
            raw_name = _goods.raw_name;
            num = _goods.num;
            description = _goods.description;
            sub_type = _goods.sub_type;
            drop_effect = _goods.drop_effect;
            effect = _goods.effect;
            can_use = _goods.can_use;
            tips_show = _goods.tips_show;
            cd = _goods.cd;
            start_cd = _goods.start_cd;
            client_use = _goods.client_use;
            main_type = _goods.main_type;
            expire_time = _goods.expire_time;
            create_time = _goods.create_time;
            is_display_goods = _goods.is_display_goods;
            show_step = _goods.show_step;
            need_count = _goods.need_count;
            recycle_price = _goods.recycle_price;
            arg = _goods.arg;
            m_group_info = _goods.m_group_info;
            use_lv = _goods.use_lv;
            gain_text = _goods.gain_text;
            src_description = _goods.src_description;
            m_level_in_add_lv_exp = _goods.m_level_in_add_lv_exp;
            is_precious = _goods.is_precious;
            discount = _goods.discount;
            overdue_notice_time = _goods.overdue_notice_time;

            return this;
        }

        /// <summary>
        /// goods字段清除
        /// </summary>
        public void Clear()
        {
            // 类型id
            id = 0;
            bind = 0;
            type_idx = 0; 
            color_type = 0;
            icon_id = 0;
            name = "";
            raw_name = "";
            num = 0;
            description = "";
            sub_type = 0;
            drop_effect = "";
            effect = "";
            can_use = false;
            tips_show = false;
            cd = 0;
            start_cd = 0;
            client_use = 0;
            main_type = 0;
            expire_time = 0;
            create_time = 0;
            is_display_goods = false;
            show_step = 0;
            need_count = 1;
            recycle_price = 0;
            arg = "";
            is_precious = 0;
            discount = 0;
            overdue_notice_time = 0;
            IsSourceCompose = 0;
        }
       
        /// <summary>
        /// new goods时可指定类型id填充数据，查表未找到时数据都为空(会将类型id也赋值为0)
        /// </summary>
        public GoodsItem(uint type_id)
        {
            isUpdateFlag = false;
            is_deleted = false;
            CreateGoodsByTypeId(type_id);
        }

        public GoodsItem()
        {
            isUpdateFlag = false;
            isDefaultGoods = false;
            is_deleted = false;
        }

        public GoodsItem(Net.PkgGoodsInfo pkgGoodsInfo) : this(pkgGoodsInfo.gid)
        {
            if (pkgGoodsInfo != null)
            {
                id = pkgGoodsInfo.oid;
                num = pkgGoodsInfo.num;
                bind = pkgGoodsInfo.bind;
                expire_time = pkgGoodsInfo.expire_time;
                this.pkgGoodsInfo = pkgGoodsInfo;
            }
        }

        public virtual void RefreshEquipUp()
        {
            is_equipUp = false;
            is_equipDown = false;
        }

        public virtual void RefreshDecorateUp()
        {
            is_decorateUp = false;
        }

        public bool isDefaultGoods { get; set; }
        public uint unknownGoodsId { get; set; }    //未知的物品ID

        /// <summary>
        /// 是否可以上架到市场
        /// </summary>
        public bool CanAddShelvesToMarket
        {
            get
            {
                //绑定的物品，不能出售
                if (bind == 1)
                    return false;
                if(this is GoodsEquip)
                {
                    //有宝石的装备，不能出售
                    if ((this as GoodsEquip).IsGem)
                        return false;
                }
                //市场主类型是1，不允许上架
                if (mktype_1 == 0)
                    return false;
                return true;
            }
        }

        public virtual void ParseClientGoodsStr_inner(Dictionary<string, string> param_dict)
        {
            if(param_dict.ContainsKey("bind"))
            {
                uint var_bind;
                if (uint.TryParse(param_dict["bind"], out var_bind))
                    bind = var_bind;
            }
        }

        public virtual void GetClientGoodsStr_inner(ref System.Text.StringBuilder builder)
        {
            builder.AppendFormat("type_idx={0};", type_idx);
            builder.AppendFormat("bind={0};", bind);
            return;
        }

        public virtual bool IsInEnableTime()
        {
            if (expire_time == 0 || expire_time > Game.Instance.ServerTime)
                return true;
            return false;
        }


        //背包类型 兼容服务端
        public ushort bag_type = GameConst.BAG_TYPE_NORMAL;

    }
}

