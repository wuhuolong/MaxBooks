using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace xc.Equip
{
    /// <summary>
    /// 装备属性集
    /// 
    /// key表示装备属性id（不是通用id），value表示 IEquipAttribute
    /// </summary>
    [wxb.Hotfix]
    public class EquipAttributes : List<IEquipAttribute>
    {
        /// <summary>
        /// 属性集的总评分
        /// </summary>
        public uint Score { get; private set; }


        public int Length{get{return this.Count;}}

        public IEquipAttribute GetAttr(int idx)
        {
            if(idx >= this.Count)
                return null;
            else
                return this[idx];
        }

        public void Insert(int idx , uint id , List<uint> value)
        {
            IEquipAttribute equip_attr;
            equip_attr = EquipAttrFactory.CreateEquipAttr(id, value);
            Score += equip_attr.Score;
            base.Insert(idx , equip_attr);
        }

        public void Add(uint id, List<uint> value)
        {
            IEquipAttribute equip_attr;
            equip_attr = EquipAttrFactory.CreateEquipAttr(id, value);
            Score += equip_attr.Score;
            base.Add(equip_attr);
        }

        public void AddValue(uint id, List<uint> value, bool bMerge)
        {
            IEquipAttribute newAttrData;
            newAttrData = EquipAttrFactory.CreateEquipAttr(id, value);
            Score += newAttrData.Score;

            if (bMerge)
            {
                IEquipAttribute findAttr = null;
                findAttr = Find(delegate (IEquipAttribute e) {
                    if (e.Data != null && newAttrData.Data != null)
                    {
                        var eAttrId = e.Data.AttrId;
                        var newAttrId = newAttrData.Data.AttrId;

                        return (eAttrId != 0) && (eAttrId == newAttrId);
                    }

                    return false;
                });

                if (null == findAttr)
                {
                    base.Add(newAttrData);
                }
                else
                {
                    for (int i = 0; i < findAttr.Values.Count; i++)
                    {
                        if (i < newAttrData.Values.Count)
                            findAttr.Values[i] += newAttrData.Values[i];
                    }
                }
            }
            else
            {
                base.Add(newAttrData);
            }
        }

        //public void Add(uint id, XLua.LuaTable valueList)
        //{
        //    List<uint> value = XLua.XUtils.CreateListByLuaTable<uint, uint>(valueList);
        //    Add(id, value);
        //}

        public new void Clear()
        {
            Score = 0;
            base.Clear();
        }

        public EquipAttributes()
        {
            Score = 0;
        }

        ~EquipAttributes()
        {
            Score = 0;
        }

        /// <summary>
        /// 根据PkgExotic列表生成EquipAttributes
        /// </summary>
        /// <param name="pkgExotics"></param>
        /// <returns></returns>
        public static EquipAttributes ParseByPkgKvMins(List<Net.PkgExotic> pkgExotics)
        {
            EquipAttributes equipAttributes = new EquipAttributes();

            foreach (var attr in pkgExotics)
            {
                equipAttributes.Add(attr.id, attr.vals);
            }

            return equipAttributes;
        }
    }
}
