using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xc.Equip;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsElementEquip : GoodsItem
    {
        private Net.PkgElementEp pkgElementEp;

        public GoodsElementEquip(uint typeId, Net.PkgGoodsInfo elementEquip)
        {
            CreateGoodsByTypeId(typeId);

            if (elementEquip != null)
            {
                UpdateGodEquip(elementEquip.element_ep);
            }
        }

        public void UpdateGodEquip(Net.PkgElementEp elementEquip)
        {
            pkgElementEp = elementEquip;

            if (ExtraAttrs == null)
                ExtraAttrs = new EquipAttributes();
            else
                ExtraAttrs.Clear();

            foreach (var attr in elementEquip.legend_attrs)
            {
                ExtraAttrs.Add(attr.id, attr.vals);
            }
        }

        private DBElementEquipGoods.DBElementEquipGoodsItem DBData
        {
            get
            {
                return DBElementEquipGoods.Instance.GetData(type_idx);
            }
        }

        /// <summary>
        /// 阶数
        /// </summary>
        public uint LvStep
        {
            get { return DBData != null ? DBData.LvStep : 1; }
        }

        /// <summary>
        /// 星级
        /// </summary>
        public uint Star
        {
            get { return DBData != null ? DBData.Star : 1; }
        }

        /// <summary>
        /// 强化等级上限
        /// </summary>
        public uint StrenthenLimit
        {
            get { return DBData != null ? DBData.StrenthenLimit : 1; }
        }

        /// <summary>
        /// 被吞噬所化经验值
        /// </summary>
        public uint Exp
        {
            get { return DBData != null ? DBData.Exp : 0; }
        }

        /// <summary>
        /// 部位
        /// </summary>
        public uint PosId
        {
            get { return DBData != null ? DBData.Pos : 0; }
        }

        // 基础属性
        public ActorAttribute BasicAttrs
        {
            get { return DBData != null ? DBData.BasicAttrs : null; }
        }

        // 附加属性
        public EquipAttributes ExtraAttrs { get; private set; }

        public uint BaseScore
        {
            get
            {
                return (BasicAttrs == null ? 0 : BasicAttrs.Score);
            }
        }

        public uint ExtraScore
        {
            get
            {
                if (Star <= 0)  //0星没有附加属性
                {
                    return 0;
                }
                else
                {
                    if (ExtraAttrs == null || ExtraAttrs.Count <= 0)    //没有生成真实属性时用默认评分
                    {
                        return DBData != null ? GoodsHelper.GetLegendTopScoreByGroupId(DBData.LegendAttrId, Star) : 0;
                    }
                    else
                    {
                        return ExtraAttrs.Score;
                    }
                }
            }
        }

        public uint ServerScore = 0xffffff;    //服务器的评分
        public uint Score
        {
            get
            {
                if (ServerScore != 0xffffff)
                {
                    return ServerScore;
                }
                return BaseScore + ExtraScore;
            }
        }

        //public bool IsWeared
        //{
        //    get { return ItemManager.Instance.InstallElementEquip.ContainsKey(id); }
        //}

        public bool IsReward()
        {
            return pkgElementEp == null;
        }
    }
}
