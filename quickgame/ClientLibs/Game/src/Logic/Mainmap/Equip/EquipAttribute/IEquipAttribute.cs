using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.Equip
{
    /// <summary>
    /// 装备属性比较的结果
    /// </summary>
    public enum EquipAttrCompareResult
    {
        Bigger = 0, // 对方比我大
        Smaller = 1, // 对方比我小
        Equal = 2, // 相等
        CannotCompare = 3 // 无法对比
    }

    /// <summary>
    /// 装备属性抽象接口
    /// </summary>
    public interface IEquipAttribute
    {
        /// <summary>
        /// 装备属性id
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// 装备值
        /// </summary>
        List<uint> Values { get; }

        /// <summary>
        /// 属性描述（动态生成的）
        /// </summary>
        string Desc { get; }

        /// <summary>
        /// 属性评分
        /// </summary>
        uint Score { get; }

        EquipAttrData Data { get; }

    }

    /// <summary>
    /// 装备属性工厂
    /// </summary>
    [wxb.Hotfix]
    public class EquipAttrFactory
    {
        public static IEquipAttribute CreateEquipAttr(uint equip_attr_id, List<uint> attr_args)
        {
            var equip_attr_data = EquipHelper.GetEquipAttrData(equip_attr_id);
            if (equip_attr_data == null)
            {
                GameDebug.LogError(string.Format("装备属性id（{0}）不存在！", equip_attr_id));
            }
            return new DefaultAttribute(equip_attr_id, attr_args);
            //             switch (equip_attr_data.Type)
            //             {
            //                 case EEquipAttrType.NormalAttr:
            //                 case EEquipAttrType.NoDiamond:
            //                 case EEquipAttrType.God:
            //                 case EEquipAttrType.CutUseLv:
            // //                case EEquipAttrType.NormalAttrEx:
            //                     {
            //                     return new DefaultAttribute(equip_attr_id, attr_args , (uint)equip_attr_data.Type);
            // //                    if (attr_args.Count == 1)
            // //                            return new EquipAttr.OneBasicAttr(equip_attr_id, attr_args);
            // //                    else if (attr_args.Count == 2)
            // //                            return new EquipAttr.TwoBasicAttr(equip_attr_id, attr_args);
            // //                        else
            //                             // TODO 添加多属性的情况
            // //
            // //                        break;
            //                     }
            //                 case EEquipAttrType.Listener:
            //                     {
            //                     return new DefaultAttribute(equip_attr_id, attr_args , (uint)equip_attr_data.Type);
            //                     }
            //                 default:
            //                     {
            //                         GameDebug.LogWarning("[EquipAttrFactory]暂时还没支持的类型：" + equip_attr_data.Type);
            //                     return new DefaultAttribute(equip_attr_id, attr_args , (uint)equip_attr_data.Type);
            //                     }
            //             }

            //            return null;
        }
    }
}