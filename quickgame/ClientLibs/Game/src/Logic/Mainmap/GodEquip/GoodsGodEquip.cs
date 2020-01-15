using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xc.Equip;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsGodEquip : GoodsItem
    {
        private Net.PkgGodEquip PkgGodEquip;
        private uint _PosId;

        public GoodsGodEquip(uint typeId, Net.PkgGoodsInfo godEquip)
        {
            CreateGoodsByTypeId(typeId);

            if (DBData == null)
            {
                GameDebug.LogError(string.Format("神兵器灵表没有id[{0}]", typeId));
                return;
            }
            _PosId = DBData.Pos;

            if (godEquip != null && godEquip.god_equip != null)
            {
                UpdateGodEquip(godEquip.god_equip);
            }
            else
            {
                UpdateGodEquip(null);
            }

        }

        public void UpdateGodEquip(Net.PkgGodEquip godEquip)
        {
            PkgGodEquip = godEquip;
            if (PkgGodEquip == null)
            {
                InitBaseAttrsByConfig();
                return;
            }
            Net.PkgKvMin kv;

            if (BasicAttrs == null)
                BasicAttrs = new ActorAttribute();
            else
                BasicAttrs.Clear();

            for (var i = 0; i < godEquip.base_attrs.Count; i++)
            {
                kv = godEquip.base_attrs[i];
                BasicAttrs.Add(kv.k,kv.v);
            }


            if (ExtraAttrs == null)
                ExtraAttrs = new EquipAttributes();
            else
                ExtraAttrs.Clear();

            foreach (var attr in godEquip.spec_attrs)
            {
                ExtraAttrs.Add(attr.id, attr.vals);
            }
        }
        private void InitBaseAttrsByConfig()
        {
            if (DBData == null)
            {
                return;
            }

            if (BasicAttrs == null)
                BasicAttrs = new ActorAttribute();
            else
                BasicAttrs.Clear();
            foreach(var kv in DBData.BasicAttrs)
            {
                BasicAttrs.Add(kv.Key, (long)kv.Value);
            }
        }

        private DBGodEquipGoods.DBGodEquipGoodsItem DBData
        {
            get
            {
                return DBGodEquipGoods.Instance.GetData(type_idx);
            }
        }

        /// <summary>
        /// 阶数
        /// </summary>
        public uint Level
        {
            get { return DBData != null ? DBData.LvStep : 1; }
        }

        /// <summary>
        /// 被吞噬所化经验值
        /// </summary>
        public uint SwallowedExpValue
        {
            get { return DBData != null ? DBData.SwallowExpValue : 0; }
        }

        /// <summary>
        /// 所在神兵的id
        /// </summary>
        public uint GodEquipId
        {
            get { return PkgGodEquip != null ? PkgGodEquip.id : 0; }
        }

        /// <summary>
        /// 部位
        /// </summary>
        public uint PosId
        {
            get { return _PosId; }
        }

        // 基础属性
        public ActorAttribute BasicAttrs { get; private set; }

        // 升华属性
        public EquipAttributes ExtraAttrs { get; private set; }

        //public List<uint> ExtraAttrsIndex = new List<uint>();

        public uint Score
        {
            get
            {
                return (BasicAttrs == null ? 0 : BasicAttrs.Score) + (ExtraAttrs == null ? 0 : ExtraAttrs.Score);
            }
        }

        public bool IsWeared
        {
            get { return GodEquipId != 0; }
        }


        public uint GrooveNum
        {
            get { return DBData != null ? DBData.GrooveNum : 0; }
        }

    
        public bool IsReward()
        {
            return PkgGodEquip == null;
        }
    }
}
