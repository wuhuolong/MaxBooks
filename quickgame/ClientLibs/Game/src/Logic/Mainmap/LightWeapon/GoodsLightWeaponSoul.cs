using System;
using xc.Equip;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsLightWeaponSoul : GoodsItem
    {

        #region 属性

        /// <summary>
        /// 部位_光武类型
        /// </summary>
        public uint Pos_Type { get { return DBSoul != null ? DBSoul.Pos_Type : 1; } }

        /// <summary>
        /// 部位_孔位
        /// </summary>
        public uint Pos_Index { get { return DBSoul != null ? DBSoul.Pos_Index : 1; } }

        /// <summary>
        /// 分解获得魂魄数量
        /// </summary>
        public uint ResolveAmount { get { return DBSoul != null ? DBSoul.ResolveAmount : 0; } }

        /// <summary>
        /// 分解类型
        /// </summary>
        public uint ResolveType { get { return DBSoul != null ? DBSoul.ResolveType : 1; } }

        /// <summary>
        /// 升级等级
        /// </summary>
        public uint Level;

        /// <summary>
        /// 基础属性
        /// </summary>
        public ActorAttribute BasicAttrs { get; private set; }

        /// <summary>
        /// 基础评分
        /// </summary>
        public uint Score
        {
            get
            {
                return (BasicAttrs == null ? 0 : BasicAttrs.Score);
            }
        }

        /// <summary>
        /// 是否已经穿戴
        /// </summary>
        public bool IsWearing;

        /// <summary>
        /// 升级属性
        /// </summary>
        public ActorAttribute UpgradeAttrs;

        public uint TotalScore
        {
            get
            {
                return (BasicAttrs == null ? 0 : BasicAttrs.Score) + (UpgradeAttrs == null ? 0 : UpgradeAttrs.Score);
            }
        }

        #endregion

        #region 函数
        public GoodsLightWeaponSoul(Net.PkgGoodsInfo pkgGoodsInfo) : this(pkgGoodsInfo.gid)
        {
            this.id = pkgGoodsInfo.oid;
            this.num = pkgGoodsInfo.num;
            this.bind = pkgGoodsInfo.bind;
            this.bag_type = GameConst.BAG_TYPE_LIGHT_SOUL;
        }

        public GoodsLightWeaponSoul(uint GID)
        {
            CreateGoodsByTypeId(GID);
            if (DBSoul == null)
            {
                GameDebug.LogError("光武兵魂找不到ID[{0}]的数据");
                return;
            }
            InitBaseAttr();
            UpgradeAttrs = new ActorAttribute();
            IsWearing = false;
        }

        #endregion

        void InitBaseAttr()
        {
            BasicAttrs = new ActorAttribute();
            if (DBSoul != null)
            {
                foreach (var kv in DBSoul.BasicAttrs)
                    BasicAttrs.Add(kv.Key, (long)kv.Value);
            }
        }

        public DBLightWeaponSoul.LightWeaponSoul DBSoul
        {
            get
            {
                return DBLightWeaponSoul.Instance.GetData(type_idx);
            }
        }
    }

}
