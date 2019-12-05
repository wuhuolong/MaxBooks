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
    public class DefaultAttribute : IEquipAttribute
    {
        public uint Id { get; private set; }

        public EquipAttrData Data
        {
            get { return EquipHelper.GetEquipAttrData(Id); }
        }


        public string Desc
        {
            // 描述是固定的
            get
            {
                if (Data != null)
                {
                    return Data.SubAttrDesc;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 属性值
        /// </summary>
        public List<uint> Values { get;   set; }
            

        public uint Score
        {
            get
            {
                if (Data != null)
                {
                    return Data.GetScore(Values);
                }
                else
                {
                    return 0;
                }
            }
        }

        public DefaultAttribute(uint equip_attr_id, List<uint> args)
        {
            Id = equip_attr_id;
            Values = args;
        }
    }

}
