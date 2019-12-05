using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using xc.Equip;
using xc.Magic;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsMagicEquip : GoodsItem
    {
        #region  属性
        public Net.PkgMagicEquip NetMagicEquip;
        private uint mStrengthLv = 0;

        public new bool can_use
        {
            get
            {
                return (base.use_job == 0 || base.use_job == LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
                         //&& (base.use_lv <= LocalPlayerManager.Instance.LocalActorAttribute.Level)
                         && (base.expire_time == 0 || base.expire_time >= Game.Instance.ServerTime);
            }
        }

        /// <summary>
        /// DB数据
        /// </summary>
        public DBMagicEquip.DBMagicEquipItem DbData
        {
            get
            {
                return DBMagicEquip.Instance.GetData(type_idx);
            }
        }

        /// <summary>
        /// 星级 
        /// </summary>
        public uint Star 
        {
            get { return DbData != null ? DbData.Star : 0; }
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
        public uint PosId
        {
            get { return DbData != null ? DbData.PosId : 0; }
        }

        /// <summary>
        /// 是否被穿戴 
        /// </summary
        public bool IsWeared
        {
            get
            {
                var wearingMagicEquips = ItemManager.Instance.WearingMagicEquip;
                if (wearingMagicEquips.ContainsKey(id))
                    return true;

                return false;
            }
        }

        /// <summary>
        /// 基础属性（通过读表就可以生成）
        /// </summary>
        public ActorAttribute BasicAttrs { get; private set; }

        /// <summary>
        /// 附加属性集
        /// </summary>
        public EquipAttributes AppendAttrs { get; private set;}

        /// <summary>
        /// 法宝Id 
        /// </summary>
        public uint MagicId { get; set; }

        /// <summary>
        /// 被吞噬所化经验值(熟练度)
        /// </summary>
        public uint SwallowedExpValue
        {
            get
            {
                uint baseValue = DbData != null ? DbData.SwallowExpValue : 0;

                return baseValue + TotalExp;
            }
        }

        /// <summary>
        /// 吞噬掉的总经验
        /// </summary>
        public uint TotalExp { get; set; }

        /// <summary>
        /// 当前经验值
        /// </summary>
        public uint CurExp { get; set; }

        /// <summary>
        /// 基础评分
        /// </summary>
        public int BaseScore 
        {
            get
            {
                int ret = 0;

                // 基础属性评分
                if (BasicAttrs != null)
                    ret = EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.EquipBase, BasicAttrs);

                // 附加属性评分
                ret += (int)AppendAttrs.Score;

                return ret;
            }
        }

        /// <summary>
        /// 强化等级
        /// </summary>
        public uint StrengthLv
        {
            get { return mStrengthLv; }
            set
            {
                mStrengthLv = (value > MaxStrengthLv) ? MaxStrengthLv : value;
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

                // 强化评分
                var attr = MagicEquipHelper.GetStrengthAttr(StrengthLv, this);
                ret += EquipHelper.GetEquipBaseAttrScoreByType(AttrScoreGType.EquipStrength, attr);

                return ret;
            }
        }

        /// <summary>
        /// 法宝装备名字
        /// </summary>
        public string Name
        {
            get
            {
                string ret = base.name;
                string colorStr = GoodsHelper.GetGoodsColor(color_type);
                ret = string.Format("{0}{1}</color>", colorStr, ret);

                if (StrengthLv != 0)
                    ret = string.Format("{0}+{1}", ret, StrengthLv);

                return ret;
            }
        }

        /// <summary>
        /// 未加工的法宝装备名字
        /// </summary>
        public string RawName
        {
            get
            {
                string ret = base.raw_name;
                if (StrengthLv != 0)
                {
                    ret = string.Format("{0}+{1}", ret, StrengthLv);
                }

                return ret;
            }
        }

        #endregion

        #region  函数
        public GoodsMagicEquip()
        {

        }

        public GoodsMagicEquip(uint typeId, Net.PkgGoodsInfo goods)
        {
            if (goods != null)
                NetMagicEquip = goods.magic_equip;

            CreateGoodsByTypeId(typeId);
        }

        public GoodsMagicEquip(uint typeId, Net.PkgMagicEquip equip)
        {
            NetMagicEquip = equip;
            CreateGoodsByTypeId(typeId);
        }

        public void UpdateMagicEquip(Net.PkgMagicEquip magicEquip)
        {
            NetMagicEquip = magicEquip;
            
            if (magicEquip != null)
            {
                MagicId = magicEquip.id;
                StrengthLv = magicEquip.str_lv;
                TotalExp = magicEquip.total_exp;
                CurExp = magicEquip.exp;
            }

            UpdateAttr(NetMagicEquip);
        }
        public override void CreateGoodsByTypeId(uint gid)
        {
            base.CreateGoodsByTypeId(gid);
            UpdateAttr(NetMagicEquip);
        }

        public void UpdateAttr(Net.PkgMagicEquip equip)
        {
            // 基础属性
            if (BasicAttrs == null)
                BasicAttrs = new ActorAttribute();

            else
                BasicAttrs.Clear();

            if (DbData != null)
            {
                foreach (var v in DbData.BaseAttrs)
                {
                    BasicAttrs.Add(v.attr_id, v.attr_num);
                }
            }

            // 附加属性
            if (AppendAttrs == null)
                AppendAttrs = new EquipAttributes();

            else
                AppendAttrs.Clear();

            if (equip == null)
                return;

            foreach (var attr in equip.spec_attrs)
            {
                AppendAttrs.Add(attr.id, attr.vals);
            }
        }

        public new GoodsMagicEquip Clone()
        {
            GoodsMagicEquip magicEquip = new GoodsMagicEquip(type_idx, NetMagicEquip);
            magicEquip.id = id;
            magicEquip.MagicId = MagicId;
            magicEquip.StrengthLv = StrengthLv;
            magicEquip.TotalExp = TotalExp;
            magicEquip.CurExp = CurExp;

            magicEquip.CreateGoodsByTypeId(type_idx);

            return magicEquip;
        }

        #endregion
    }
}