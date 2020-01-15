using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.Equip
{
    /// <summary>
    /// 默认的属性
    /// </summary>
    [wxb.Hotfix]
    public class NullEquipAttribute : IEquipAttribute
    {
        public uint Id { get; private set; }

        public string Desc
        {
            get { return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_47"); }
        }
        public float Add{get {return 0.0f;} }
        public EquipAttrData Data
        {
            get { return null; }
        }

        public bool IsLegend
        {
            get { return false; }
        }

        public uint Score
        {
            get { return 0; }
        }

        public uint CutUseLv{get{return 0;} }

        /// <summary>
        /// 属性值
        /// </summary>
        public List<uint> Values { get;   set; }

         /// <summary>
        /// 特效属性类型
        /// </summary>
        public uint EffectType { get; set; }

        public NullEquipAttribute(uint equip_attr_id, List<uint> args)
        {
            Id = EquipAttrData.INVALID_EQUIP_ATTR_ID;
            Values = args;
        }


    }
}
