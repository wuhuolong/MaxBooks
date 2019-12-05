using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using xc.Equip;
using xc.Decorate;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsDecorate : GoodsItem
    {
        #region  属性
        public Net.PkgGoodsInfo NetDecorate;

        public new bool can_use
        {
            get
            {
                return (base.use_job == 0 || base.use_job == LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
                         //&& (base.use_lv <= LocalPlayerManager.Instance.LocalActorAttribute.Level)
                         && (base.expire_time == 0 || base.expire_time >= Game.Instance.ServerTime)
                         && IsUnlock;
            }
        }

        /// <summary>
        /// DB数据
        /// </summary>
        public DBDecorate.DBDecorateItem DbData
        {
            get
            {
                return DBDecorate.Instance.GetData(type_idx);
            }
        }

        public string DefaultExtraDesc
        {
            get
            {
                if (DbData == null)
                    return string.Empty;

                return DbData.DefaultExtraDesc;
            }
        }

        /// <summary>
        /// 阶数
        /// </summary>
        public uint LvStep
        {
            get { return DbData != null ? DbData.LvStep : 1; }
        }

        /// <summary>
        /// 最大可强化等级
        /// </summary>
        public uint MaxStrengthLv
        {
            get { return DbData != null ? DbData.StrengthMax : 1; }
        }

        /// <summary>
        /// 部位
        /// </summary>
        public uint Pos
        {
            get { return DbData != null ? DbData.Pos : 0; }
        }

        /// <summary>
        /// 被吞噬所化经验值(熟练度)
        /// </summary>
        public uint SwallowedExpValue
        {
            get { return DbData != null ? DbData.SwallowExpValue : 0; }
        }

        /// <summary>
        /// 部位是否解锁
        /// </summary>
        public bool IsUnlock
        {
            get
            {
                foreach (var posInfo in ItemManager.Instance.DecoratePosInfos)
                {
                    if (posInfo.Pos == Pos)
                        return posInfo.IsUnlock;
                }

                return false;
            }
        }

        /// <summary>
        /// 是否被佩戴 
        /// </summary
        public bool IsWeared
        {
            get
            {
                var wearingDecorates = ItemManager.Instance.WearingDecorate;
                if (wearingDecorates.ContainsKey(Pos))
                    return wearingDecorates[Pos].id == id;

                return false;
            }
        }

        /// <summary>
        /// 基础属性（通过读表就可以生成）
        /// </summary>
        public ActorAttribute BasicAttrs { get; private set; }

        /// <summary>
        /// 传奇属性集
        /// </summary>
        public EquipAttributes LegendAttrs { get; set; }

        private uint mLegendAttrsDefaultScore = 0;

        public uint LegendAttrsDefaultScore
        {
            get
            {
                if (mLegendAttrsDefaultScore == 0)
                {
                    if (DbData == null)
                        return 0;

                    if (DbData.LegendAttrs == null || DbData.LegendAttrs.Count == 0)
                        return 0;

                    for (int i = 0; i < DbData.LegendAttrs.Count; i++)
                    {
                        List<uint> temp = DbData.LegendAttrs[i];
                        mLegendAttrsDefaultScore += GoodsHelper.GetLegendTopScoreByGroupId(temp[0], temp[1]);
                    }
                }

                return mLegendAttrsDefaultScore;
            }
        }

        /// <summary>
        /// 基础评分
        /// </summary>
        public int BaseScore 
        {
            get
            {
                int ret = 0;
                if (BasicAttrs != null)
                    ret = EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.DecorateBase, BasicAttrs);

                if (LegendAttrs != null && (int)LegendAttrs.Score != 0)
                    ret = ret + (int)LegendAttrs.Score;

                else
                    ret = ret + (int)LegendAttrsDefaultScore;

                return ret;
            }
        }

        /// <summary>
        /// 强化等级
        /// </summary>
        public uint StrengthLv
        {
            get
            {
                if (!IsWeared)
                    return 0;

                uint ret = 0;
                DecoratePosInfo posInfo = ItemManager.Instance.DecoratePosInfos.Find(
                    delegate (DecoratePosInfo _info) { return _info.Pos == Pos; });
                if (posInfo != null)
                {
                    ret = posInfo.StrengthLv;
                }

                if (ret > MaxStrengthLv)
                    ret = MaxStrengthLv;

                return ret;
            }
        }

        public uint ServerStar = 0xffffff;    //服务器的强制星级

        public uint Star
        {
            get
            {
                if (ServerStar != 0xffffff)
                    return ServerStar;

                return DecorateHelper.GetDecorateStar(this);
            }
        }

        public int ServerForceScore = 0xffffff;    //服务器的强制评分

        /// <summary>
        /// 综合评分
        /// </summary>
        public int Score
        {
            get
            {
                if (ServerForceScore != 0xffffff)
                    return ServerForceScore;

                // 基础评分
                int ret = BaseScore;

                if (IsWeared)
                {
                    // 强化评分
                    var attr = DecorateHelper.GetStrengthAttr(StrengthLv, this);
                    ret += EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.DecorateStrength, attr);

                    // 已解锁附魔评分
                    var appendAttrs = DecorateHelper.GetAppendAttr(this);
                    ret += EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.DecorateStrength, appendAttrs);
                }

                return ret;
            }
        }

        /// <summary>
        /// 突破后综合评分（仅突破后，附魔属性的变化带来的新综合评分）
        /// </summary>

        public int AfterBreakScore
        {
            get
            {
                if (ServerForceScore != 0xffffff)
                    return ServerForceScore;

                // 基础评分
                int ret = BaseScore;

                if (IsWeared)
                {
                    // 强化评分
                    var attr = DecorateHelper.GetStrengthAttr(StrengthLv, this);
                    ret += EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.DecorateStrength, attr);

                    // 已解锁附魔评分
                    var appendAttrs = DecorateHelper.GetBreakAppendAttr(this);
                    ret += EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.DecorateStrength, appendAttrs);
                }

                return ret;
            }
        }

        /// <summary>
        /// 饰品名字
        /// </summary>
        public string Name
        {
            get
            {
                string ret = base.name;
                if (IsWeared)
                {
                    string colorStr = GoodsHelper.GetGoodsColor(color_type);
                    ret = string.Format("{0}{1}</color>", colorStr, ret);

                    if (StrengthLv != 0)
                        ret = string.Format("{0}+{1}", ret, StrengthLv);
                }

                return ret;
            }
        }

        /// <summary>
        /// 未加工的饰品名字
        /// </summary>
        public string RawName
        {
            get
            {
                string ret = base.raw_name;
                if (IsWeared && StrengthLv != 0)
                {
                    ret = string.Format("{0}+{1}", ret, StrengthLv);
                }

                return ret;
            }
        }

        #endregion

        #region  函数
        public GoodsDecorate()
        {

        }

        public GoodsDecorate(uint typeId, Net.PkgGoodsInfo decorate)
        {
            NetDecorate = decorate;
            CreateGoodsByTypeId(typeId);
        }

        public override void CreateGoodsByTypeId(uint gid)
        {
            base.CreateGoodsByTypeId(gid);
            UpdateAttr(gid, NetDecorate);
        }

        public override void RefreshDecorateUp()
        {
            base.RefreshDecorateUp();

            if (!can_use)
                return;

            GoodsDecorate decorate = DecorateHelper.GetWearingDecorateByPos(Pos);
            if (decorate == null)
            {
                is_decorateUp = true;
                return;
            }

            is_decorateUp = BaseScore > decorate.BaseScore;
        }

        public void UpdateAttr(uint gid, Net.PkgGoodsInfo decorate)
        {
            NetDecorate = decorate;

            if (BasicAttrs == null)
                BasicAttrs = new ActorAttribute();
            else
                BasicAttrs.Clear();

            if (LegendAttrs == null)
                LegendAttrs = new EquipAttributes();
            else
                LegendAttrs.Clear();

            var rec = DBDecorate.Instance.GetData(gid);
            if (rec != null)
            {
                string raw = rec.Attrs;
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

            if (decorate != null && decorate.decorate != null && decorate.decorate.legend_attrs != null)
            {
                foreach (var attr in decorate.decorate.legend_attrs)
                {
                    LegendAttrs.Add(attr.id, attr.vals);
                }
            }
        }

        public new GoodsDecorate Clone()
        {
            GoodsDecorate decorate = new GoodsDecorate(type_idx, NetDecorate);
            decorate.id = id;
            decorate.CreateGoodsByTypeId(type_idx);

            return decorate;
        }

        #endregion
    }
}