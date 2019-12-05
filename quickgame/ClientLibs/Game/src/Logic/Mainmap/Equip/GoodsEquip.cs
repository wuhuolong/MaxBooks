using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using xc.Equip;
namespace xc
{
    /// <summary>
    /// 套装相关字段
    /// </summary>
    [wxb.Hotfix]
    public class EquipSuitInfo
    {
        /// <summary>
        /// 套装id
        /// </summary>
        public uint Id = 0;

        /// <summary>
        /// 部位
        /// </summary>
        public uint EquipPos;

        /// <summary>
        /// 套装属性必须是已穿戴才计算
        /// </summary>
        public Dictionary<uint,ActorAttribute> SuitAttrs { get; set; }

        /// <summary>
        /// 套装等级
        /// </summary>
        private uint _lv = 0;

        public uint Lv
        {
            set
            {
                if (_lv != value)
                {
                    _lv = value;
                    Update(_lv);
                }
            }
            get
            {
                return _lv;
            }
        }
        /// <summary>
        /// 套装名字
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 套装预览名字
        /// </summary>
        public string PreviewName { set; get; }
        /// <summary>
        /// 套装外观id
        /// </summary>
        public uint SuitId { set; get; }
        /// <summary>
        /// 锻造所需品质和星级
        /// </summary>
        public List<DBSuit.DBSuitInfo.NeedInfo> UpgradeNeed { set; get; }
        /// <summary>
        /// 锻造所需消耗品
        /// </summary>
        public List<Goods> CostGoods { set; get; }

        public uint ActiveNum { set; get; }
        /// <summary>
        /// 当前套装满足的装备数量
        /// </summary>
        private uint _num = 0;
        public uint RealNum
        {
            set {
                if (_num != value)
                {
                    _num = value;
                    UpdateAttr(_lv, _num);
                }
            }
            get
            {
                return _num;
            }
        }

        /// <summary>
        /// 套装的最大件数
        /// </summary>
        public uint MaxNum { set; get; }

        public void UpdateAttr(uint lv , uint num)
        {
            _lv = lv;
            _num = num;
            ActiveNum = EquipHelper.GetActiveSuitNum(Id, Lv, RealNum);
        }

        public void Update(uint lv)
        {
            _lv = lv;
            if (CostGoods == null)
                CostGoods = new List<Goods>();
            else
                CostGoods.Clear();

            ///很傻逼的设计 如果0级要读1级的 其他的读当前等级说了很久服务端跟策划不改
            uint currentLv = 0;
            if (_lv == 0)
                currentLv = 1;
            else
                currentLv = _lv;

            DBSuit.DBSuitInfo dbSuitInfo = DBManager.Instance.GetDB<DBSuit>().GetOneInfo(Id, currentLv);
            if (dbSuitInfo != null)
            {
                if (currentLv == dbSuitInfo.Lv)
                {
                    Name = dbSuitInfo.Name;
                    PreviewName = dbSuitInfo.PreviewName;
                    SuitId = dbSuitInfo.SuitId;
                    UpgradeNeed = dbSuitInfo.NeedInfos;
                    List<GoodsItem> costGoods = dbSuitInfo.GetCostGoods(EquipPos);
                    foreach (GoodsItem goods in costGoods)
                    {
                        CostGoods.Add(goods);
                    }
                }
            }

            if (SuitAttrs == null)
                SuitAttrs = new Dictionary<uint, ActorAttribute>();
            else
                SuitAttrs.Clear();

            MaxNum = 0;

            var attrInfos = DBManager.Instance.GetDB<DBSuitAttr>().GetAttrInfos(Id, Lv);
            if(attrInfos != null)
            {
                foreach (var info in attrInfos)
                {
                    SuitAttrs.Add(info.Num, info.BasicAttrs);

                    if (info.Num > MaxNum)
                        MaxNum = info.Num;
                }
            }
            
        }

        public void Clear()
        {
            RealNum = 0;
            if (CostGoods != null)
                CostGoods.Clear();
            if (SuitAttrs != null)
                SuitAttrs.Clear();
            _lv = 0;
            Id = 0;
            EquipPos = GameConst.POS_WEAPON; ;
            RealNum = 0;
        }

        public EquipSuitInfo(uint id , uint lv, uint equipPos)
        {
            Id = id;
            EquipPos = equipPos;
            Update(lv);
        }
    }

    /// <summary>
    /// 装备物品
    /// </summary>
    [wxb.Hotfix]
    public class GoodsEquip : GoodsItem
    {
        public GoodsEquip()
        {
        }

        public Net.PkgGoodsInfo NetEquip;

        /// <summary>
        /// 扩展属性
        /// </summary>
        public Dictionary<string, string> ExtendPropertys;

        /// <summary>
        /// 阶数
        /// </summary>
        public uint LvStep
        {
            get
            {
                if (Data != null)
                    return Data.LvStep;
                else
                    return 1;
            }

        }

        public new bool can_use
        {
            set
            {

            }
            get
            {
                if ((base.use_job == 0 || (base.use_job == LocalPlayerManager.Instance.LocalActorAttribute.Vocation))
                         && (base.expire_time == 0 || base.expire_time >= Game.Instance.ServerTime)
                         && (Data.NeedARCON <= LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_CON].Value)
                         && (Data.NeedARSTR <= LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_STR].Value)
                         && (Data.NeedARAGI <= LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_AGI].Value)
                         && (Data.NeedARINT <= LocalPlayerManager.Instance.LocalActorAttribute.Attribute[GameConst.AR_INT].Value))
                    return true;
                else
                    return false;
            }
        }


        /// <summary>
        /// 装备最大可强化等级
        /// </summary>
        public uint MaxStrengthLv
        {
            get
            {
                if (Data != null)
                    return Data.StrengthMax;
                else
                    return 1;
            }

        }

        /// <summary>
        /// 宝石信息
        /// </summary>
        public Dictionary<uint, uint> Gems = new Dictionary<uint, uint>();
        /// <summary>
        /// 是否穿上了
        /// </summary>
        public bool IsInstalled { get { return EquipHelper.EquipIsInstall(id); } }

        /// <summary>
        /// 是否是其他玩家穿上的装备
        /// </summary>
        bool mIsInstalledByOtherPlayer = false;
        public bool IsInstalledByOtherPlayer
        {
            get
            {
                return mIsInstalledByOtherPlayer;
            }
            set
            {
                mIsInstalledByOtherPlayer = value;
            }
        }

        /// <summary>
        /// 是否有宝石
        /// </summary>
        public bool IsGem
        {
            get
            {
                if (Gems.Count > 0)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// 是否为武器
        /// </summary>
        public bool IsWeapon
        {
            get { return Data.Pos == GameConst.POS_WEAPON; }
        }

        EquipModData mData = null;
        uint mEquipModeData_type_idx = 0; 
        /// <summary>
        /// 装备底模数据
        /// </summary>
        public EquipModData Data
        {
            get
            {
                if (mData == null || mEquipModeData_type_idx != type_idx)
                {
                    mData = DBManager.GetInstance().GetDB<DBEquipMod>().GetModData(type_idx);
                    mEquipModeData_type_idx = type_idx;
                }
                return mData;
            }
        }


        /// <summary>
        /// 装备的部位
        /// </summary>
        public uint EquipPos
        {
            get {
                if (Data != null)
                    return Data.Pos;
                else
                    return GameConst.POS_WEAPON; }
        }
        /// <summary>
        /// 装备部位对应的索引 比如圣器都是部位18但是可以装在不同的槽
        /// </summary>
        public uint Index
        {
            get
            {
                // 圣器取消了两个index，所有装备的index都是1了
                return 1;

                if (NetEquip == null || NetEquip.equip == null)
                    return 0;
                else
                {
                    return NetEquip.equip.index;
                }
            }
        }

        public uint ServerStar = 0xffffff;    //服务器的强制星级
        
        public uint Star
        {
            get {
                if (ServerStar != 0xffffff)
                    return ServerStar;
                return (uint)EquipHelper.GetStarAddEquip(this);
            }
        }

        public string DefaultExtraDesc
        {
            get
            {
                if (Data == null)
                    return null;
                return Data.DefaultExtraDesc;
            }
        }

        /// <summary>
        /// 只有基础属性（通过读表就可以生成）
        /// </summary>
        public ActorAttribute BasicAttrs { get; private set; }

        /// <summary>
        /// 传奇属性集
        /// </summary>
        public EquipAttributes LegendAttrs { get; set; }

        /// <summary>
        /// 额外属性集
        /// </summary>
        public ActorAttribute ExtraAttrs { get; set; }

        /// <summary>
        /// 洗练属性 没有包含最终加成后的
        /// </summary>
        public ActorAttribute BaptizeAttrs {
            get
            {
                if (IsInstalled)
                {
                    var info = EquipHelper.GetStrengthInfoByPosAndIndex(EquipPos, Index);
                    if (info == null)
                        return null;
                    else
                    {
                        return info.AllBaptizeAttr;
                    }
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 套装相关字段
        /// </summary>
        public EquipSuitInfo SuitInfo { get; private set; }

        /// <summary>
        /// 套装id
        /// </summary>
        public uint SuitId
        {
            get
            {
                if (Data != null)
                    return Data.SuitId;
                else
                    return 0;
            }
        }


        private uint mSuitLv = 0;//默认是0即在表中找不到
        /// <summary>
        /// 套装等级默认是0
        /// </summary>
        public uint SuitLv {
            set {

                if (SuitInfo == null)
                {
                    mSuitLv = value;
                    SuitInfo = new EquipSuitInfo(SuitId, mSuitLv, EquipPos);
                }
                else
                {

                    if (value != mSuitLv)
                    {
                        mSuitLv = value;
                        SuitInfo.Lv = mSuitLv;
                    }
                }

                
            }
            get {
                    return mSuitLv;
            }
        }

        private uint mRefineLv = 0;

        /// <summary>
        /// 套装精炼等级
        /// </summary>
        public uint RefineLv
        {
            set
            {
                mRefineLv = value;
            }
            get
            {
                return mRefineLv;
            }
        }

        private uint mLegendAttrsDefaultScore = 0;

        public uint LegendAttrsDefaultScore
        {
            get
            {
                if (mLegendAttrsDefaultScore == 0)
                {
                    if (Data == null)
                        return 0;
                    if (Data.LegendAttrs == null || Data.LegendAttrs.Count == 0)
                        return 0;
                    for (int i = 0; i < Data.LegendAttrs.Count; i++)
                    {
                        List<uint> temp = Data.LegendAttrs[i];
                        mLegendAttrsDefaultScore += GoodsHelper.GetLegendTopScoreByGroupId(temp[0], temp[1]);
                    }
                }
                return mLegendAttrsDefaultScore;
            }
        }
    



        public int ServerEquipRank = 0xffffff;    //服务器的强制装备评分
        /// <summary>
        /// 装备评分
        /// </summary>
        public int EquipRank
        {
            get
            {

                if (ServerEquipRank != 0xffffff)
                    return ServerEquipRank;
                int score = 0;
                if (BasicAttrs != null)
                    score = EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, BasicAttrs);
                if (LegendAttrs != null && (int)LegendAttrs.Score != 0)
                    score = score + (int)LegendAttrs.Score;
                else
                    score = score + (int)LegendAttrsDefaultScore;
                if (ExtraAttrs != null)
                    score = score + (int)ExtraAttrs.Score;
                return score;
            }
        }
        /// <summary>
        /// 强化等级
        /// </summary>
        private uint mStrenghtLv = 0;
        public uint StrenghtLv
        {
            set {
                if (IsInstalled || IsInstalledByOtherPlayer)
                {
                    mStrenghtLv = value;
                }
                else
                    mStrenghtLv = 0;
            }
            get
            {
                if (IsInstalled || IsInstalledByOtherPlayer)
                {
                    return mStrenghtLv;
                }
                else
                    return 0;
            }
        }


        /// <summary>
        /// 综合评分
        /// </summary>
        public int Rank
        {
            get
            {
                int score = 0;
                if (BasicAttrs != null)
                    score = EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, BasicAttrs);
                if (LegendAttrs != null && (int)LegendAttrs.Score != 0)
                    score = score + (int)LegendAttrs.Score;
                else
                    score = score + (int)LegendAttrsDefaultScore;
                if (ExtraAttrs != null)
                    score = score + (int)ExtraAttrs.Score;
                if (IsInstalled)
                {
                    score = score + EquipHelper.GetEquipTipsUpgradeRank(this);
                }
                if (IsInstalledByOtherPlayer)
                {
                    score = score + EquipHelper.GetOtherPlayerEquipTipsUpgradeRank(this);
                }
                return score;
            }
        }

        public int Rank_CheckExpireTime
        {
            get
            {
                if (EquipPos == GameConst.POS_ELFIN && IsInEnableTime() == false)
                    return 0;
                return EquipRank;
            }
        }

        private uint mCastSoulLv = 0;

        /// <summary>
        /// 铸魂等级
        /// </summary>
        public uint CastSoulLv
        {
            set
            {
                mCastSoulLv = value;
            }
            get
            {
                return mCastSoulLv;
            }
        }


        public GoodsEquip(uint typeId, Net.PkgGoodsInfo equip)
        {
            NetEquip = equip;
            CreateGoodsByTypeId(typeId);
            if (equip != null)
            {
                id = equip.oid;
                bind = equip.bind;
                IsSourceCompose = equip.source_compose;
            }
        }

        public void UpdateGem(Net.PkgGoodsInfo equip)
        {
            NetEquip = equip;
            Gems.Clear();
            if (NetEquip == null)
                return;
            if (NetEquip.equip != null && NetEquip.equip.gems != null)
            {
                foreach (var item in NetEquip.equip.gems)
                {
                    if (Gems.ContainsKey(item.id) == true)
                        Gems[item.id] = item.gem_id;
                    else
                        Gems.Add(item.id, item.gem_id);
                }
            }
        }

        public void UpdateAttr(uint gid, Net.PkgGoodsInfo equip)
        {
            NetEquip = equip;
            if (LegendAttrs == null)
                LegendAttrs = new EquipAttributes();
            else
                LegendAttrs.Clear();
            if (BasicAttrs == null)
                BasicAttrs = new ActorAttribute();
            else
                BasicAttrs.Clear();

            if (ExtraAttrs == null)
                ExtraAttrs = new ActorAttribute();
            else
                ExtraAttrs.Clear();

            //生成基础属性
            var base_attr = DBEquipBase.Instance.GetAttrInfo(gid);
            if(base_attr != null)
            {
                using (var iter = base_attr.GetEnumerator())
                {
                    while(iter.MoveNext())
                    {
                        var cur = iter.Current;
                        BasicAttrs.Add(cur.Key, cur.Value);
                    }
                }
            }

            if (NetEquip == null)
                return;
            if (equip != null && equip.equip != null && equip.equip.legend_attrs != null)
            {
                foreach (var attr in equip.equip.legend_attrs)
                {
                    LegendAttrs.Add(attr.id, attr.vals);
                }
            }
            if (equip != null && equip.equip != null && equip.equip.extra_attrs != null)
            {
                foreach (var attr in equip.equip.extra_attrs)
                {
                    ExtraAttrs.Add(attr.k, attr.v);
                }
            }
            if (equip != null && equip.equip != null)
            {
                SuitLv = equip.equip.suit_lv;
                foreach (var item in equip.equip.gems)
                {
                    if (Gems.ContainsKey(item.id) == true)
                        Gems[item.id] = item.gem_id;
                    else
                        Gems.Add(item.id, item.gem_id);
                }

                // 套装精炼等级
                RefineLv = equip.equip.refine_lv;

                // 铸魂等级
                CastSoulLv = equip.equip.cast_soul_lv;

                // 记录扩展属性
                if (equip.equip.extend_propertys != null && equip.equip.extend_propertys.Count > 0)
                {
                    ExtendPropertys = new Dictionary<string, string>();
                    ExtendPropertys.Clear();
                    foreach (Net.PkgStrStr pkgStrStr in equip.equip.extend_propertys)
                    {
                        ExtendPropertys.Add(System.Text.Encoding.UTF8.GetString(pkgStrStr.k), System.Text.Encoding.UTF8.GetString(pkgStrStr.v));
                    }
                }
            }
            if(IsHasIdentifyWing())
                this.color_type = equip.equip.qual; //装备的品质
        }

        /// <summary>
        /// 是否是已经鉴定过的翅膀
        /// </summary>
        /// <returns></returns>
        public bool IsHasIdentifyWing()
        {
            if (EquipPos == GameConst.POS_WING && NetEquip != null && NetEquip.equip != null &&
                NetEquip.equip.extra_attrs != null && NetEquip.equip.extra_attrs.Count > 0)
                return true;
            return false;
        }
        public override void CreateGoodsByTypeId(uint gid)
        {
            base.CreateGoodsByTypeId(gid);
            UpdateAttr(gid, NetEquip);
            UpdateGem(NetEquip);
        }

        /// <summary>
        /// 装备名字
        /// </summary>
        public new string name
        {
            get
            {
                string _name = base.name;
                if (SuitLv > 0)
                    _name = GoodsHelper.GetGoodsColor(base.color_type) + SuitInfo.Name + "</color>" + _name;
                if (StrenghtLv != 0)
                    _name = _name + string.Format("+{0}", StrenghtLv);
                //if (StrenghtLv >= MaxStrengthLv)
                //    _name = _name + GoodsHelper.GetGoodsColor(GameConst.QUAL_COLOR_GREEN) + "(MAX)" + "</color>";
                return _name;
            }
            set { /* 不能这样设置的~ */ }
        }

        /// <summary>
        /// 装备原始名字，不包含强化
        /// </summary>
        public string OrigName
        {
            get
            {
                string _name = base.name;
                if (SuitLv > 0)
                    _name = GoodsHelper.GetGoodsColor(base.color_type) + SuitInfo.Name + "</color>" + _name;

                return _name;
            }
            set { /* 不能这样设置的~ */ }
        }


        public new string raw_name
        {
            get
            {
                string _name = base.raw_name;
                if (SuitLv > 0)
                    _name = SuitInfo.Name + _name;
                if (StrenghtLv != 0)
                    _name = _name + string.Format("+{0}", StrenghtLv);
                return _name;
            }
            set { /* 不能这样设置的~ */ }
        }

        /// <summary>
        /// 显示预览的套装名字
        /// </summary>
        public string preview_raw_name
        {
            get
            {
                string _name = base.raw_name;
                if (SuitLv > 0)
                {
                    _name = SuitInfo.PreviewName;
                    _name = SuitInfo.Name + _name;
                }
                //if (StrenghtLv != 0)
                //    _name = _name + string.Format("+{0}", StrenghtLv);
                return _name;
            }
            set { /* 不能这样设置的~ */ }
        }

        /// <summary>
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public new GoodsEquip Clone()
        {
            GoodsEquip equip = new GoodsEquip(this.type_idx ,this.NetEquip );
            equip.id = this.id;
            equip.BasicAttrs = this.BasicAttrs;
            equip.LegendAttrs = this.LegendAttrs;
            equip.StrenghtLv = this.StrenghtLv;
            equip.ExtraAttrs = this.ExtraAttrs;
            return equip;
        }

        public new void Clear()
        {
            base.Clear();
        }

        public override void RefreshEquipUp()
        {
            is_equipUp = false;
            is_equipDown = false;
            if (LocalPlayerManager.Instance.LocalActorAttribute.Vocation != this.use_job && this.use_job != 0)
            {
                return;
            }
            if (this.IsInEnableTime() == false)
            {//物品过期
                is_equipUp = false;
                is_equipDown = false;
                return;
            }
            GoodsEquip equip = EquipHelper.GetInstallEquipByPos(this.EquipPos);
            if (equip == null)
            {
                is_equipUp = true;
                is_equipDown = false;
                return;
            }
            int this_equipRank = this.EquipRank;
            int equip_rank = equip.EquipRank;
            if (this_equipRank > equip_rank)
                is_equipUp = true;
            else if (this_equipRank < equip_rank)
                is_equipDown = true;
        }

        public override void ParseClientGoodsStr_inner(Dictionary<string, string> param_dict)
        {
            base.ParseClientGoodsStr_inner(param_dict);
            if (NetEquip == null)
                NetEquip = new Net.PkgGoodsInfo();
            if(NetEquip.equip == null)
                NetEquip.equip = new Net.PkgEquip();
            if(NetEquip.equip.legend_attrs != null)
                NetEquip.equip.legend_attrs.Clear();
            if(NetEquip.equip.extra_attrs != null)
                NetEquip.equip.extra_attrs.Clear();
            LegendAttrs.Clear();
            if (param_dict.ContainsKey("LegendAttrs"))
            {//传奇属性
                string legend_str = param_dict["LegendAttrs"];
                var matches = Regex.Matches(legend_str, @"(\d+),\[([\d|,]+)\]");
                foreach (System.Text.RegularExpressions.Match _match in matches)
                {
                    if (_match.Success)
                    {
                        uint attr_id = 0;
                        if (uint.TryParse(_match.Groups[1].Value, out attr_id) == false)
                            continue;
                        List<uint> attr_uint_list = DBTextResource.ParseArrayUint(_match.Groups[2].Value, ",", false);
                        if (attr_uint_list == null || attr_uint_list.Count == 0)
                            continue;
                        LegendAttrs.Add(attr_id, attr_uint_list);
                    }
                }
            }
            ExtraAttrs.Clear();
            if (param_dict.ContainsKey("ExtraAttrs"))
            {//额外属性
                string legend_str = param_dict["ExtraAttrs"];
                var matches = Regex.Matches(legend_str, @"(\d+),(\d+)");
                foreach (System.Text.RegularExpressions.Match _match in matches)
                {
                    if (_match.Success)
                    {
                        uint attr_id = 0;
                        if (uint.TryParse(_match.Groups[1].Value, out attr_id) == false)
                            continue;
                        uint attr_num = 0;
                        if (uint.TryParse(_match.Groups[2].Value, out attr_num) == false)
                            continue;
                        ExtraAttrs.Add(attr_id, attr_num);
                    }
                }
            }

            if (IsHasIdentifyWing() && param_dict.ContainsKey("color_type"))
            {
                uint var_color_type = 0;
                if(uint.TryParse(param_dict["color_type"], out var_color_type))
                {
                    this.color_type = var_color_type; //装备的品质
                }
            }
        }

        public override void GetClientGoodsStr_inner(ref System.Text.StringBuilder builder)
        {
            base.GetClientGoodsStr_inner(ref builder);
            if(LegendAttrs.Count > 0)
            {//传奇属性
                builder.AppendFormat("LegendAttrs=");
                bool is_first_attr = true;
                foreach (var item in LegendAttrs)
                {
                    string legend_str = DBTextResource.GetStringArrayUint(item.Values, ",", "[", "]");
                    if (is_first_attr)
                    {
                        builder.AppendFormat("{0},{1}", item.Id, legend_str);
                        is_first_attr = false;
                    }
                    else
                        builder.AppendFormat(",{0},{1}", item.Id, legend_str);
                }
                
                builder.AppendFormat(";");
            }

            if (IsHasIdentifyWing())
            {//已经鉴定翅膀的品质
                builder.AppendFormat("color_type={0};", this.color_type);
            }
        }

        public uint ModelId
        {
            get
            {
                if (Data == null)
                    return 0;
                if (expire_time == 0 || expire_time > Game.Instance.ServerTime)
                {
                    return Data.ModelId;
                }
                else
                    return 0;
            }
        }
    }
}
