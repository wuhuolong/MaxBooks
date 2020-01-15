using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc.Equip
{
    /// <summary>
    /// 基础属性集
    /// 
    /// key表示基础属性类型，value表示属性加成的值
    /// </summary>
    [wxb.Hotfix]
    public class Attributes : Dictionary<uint, uint>
    {
        /// <summary>
        /// 父属性集
        /// 
        /// 如果设置了父属性集，当自身属性变更时，会实时改变父属性集对应的属性
        /// </summary>
        public Attributes ParentAttributes { get; private set; }

        public Attributes(Attributes parent)
        {
            SetParent(parent);
        }

        public Attributes()
        {

        }

        /// <summary>
        /// 添加一条属性加成
        /// </summary>
        /// <param name="attr_type">属性类型</param>
        /// <param name="attr_value">加成的值</param>
        public void AddAttr(uint attr_type, uint attr_value)
        {
            if (attr_value <= 0)
                return;

            uint old_value = 0;
            if (TryGetValue(attr_type, out old_value))
            {
                this[attr_type] = old_value + attr_value;
            }
            else
            {
                this[attr_type] = attr_value;
            }

            // 更改父属性集
            if (ParentAttributes != null)
            {
                ParentAttributes.AddAttr(attr_type, attr_value);
            }
        }

        /// <summary>
        /// 去掉一条属性加成
        /// </summary>
        /// <param name="attr_type">属性类型</param>
        /// <param name="attr_value">属性加成的值</param>
        public void RemoveAttr(uint attr_type, uint attr_value)
        {
            if (attr_value <= 0)
                return;

            uint old_value = 0;
            if (TryGetValue(attr_type, out old_value))
            {
                var new_value = old_value - attr_value;
                if (new_value <= 0)
                    Remove(attr_type);
                else
                    this[attr_type] = new_value;
            }

            // 更改父属性集
            if (ParentAttributes != null)
            {
                ParentAttributes.RemoveAttr(attr_type, attr_value);
            }
        }

        /// <summary>
        /// 从父属性集脱离
        /// </summary>
        public void DetachFromParent()
        {
            if (ParentAttributes != null)
            {
                // 在父属性集中去掉自身所有的属性加成
                foreach (var attr in this)
                {
                    ParentAttributes.RemoveAttr(attr.Key, attr.Value);
                }
                ParentAttributes = null;
            }
        }

        /// <summary>
        /// 设置父属性集
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(Attributes parent)
        {
            DetachFromParent();

            ParentAttributes = parent;
            if (ParentAttributes != null)
            {
                foreach (var attr in this)
                {
                    ParentAttributes.AddAttr(attr.Key, attr.Value);
                }
            }
        }

        public new uint this[uint attr_type]
        {
            get
            {
                uint result = 0;
                if (TryGetValue(attr_type, out result))
                    return result;

                return 0;
            }
            set
            {
                base[attr_type] = value;
            }
        }

        public new void Clear()
        {
            if (ParentAttributes != null)
            {
                // 在父属性集中去掉自身所有的属性加成
                foreach (var attr in this)
                {
                    ParentAttributes.RemoveAttr(attr.Key, attr.Value);
                }
            }

            base.Clear();
        }
    }
}
