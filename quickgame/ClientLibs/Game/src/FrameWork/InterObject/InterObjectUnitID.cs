using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    public enum InterObjectType : byte
    {
        TOMB_STONE = 0,// bosss死亡后的墓碑
    }

    /// <summary>
    /// 互动物体的唯一ID
    /// </summary>
    [wxb.Hotfix]
    public class InterObjectUnitID
    {
        public InterObjectType m_Type;// 互动物体的类型
        public uint m_Idx;// 互动物体的索引id

        public InterObjectUnitID()
        {
            m_Type = 0;
            m_Idx = 0;
        }

        public InterObjectUnitID(InterObjectType t, uint idx)
        {
            m_Type = t;
            m_Idx = idx;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            if ((obj.GetType().Equals(GetType())) == false)
            {
                return false;
            }

            InterObjectUnitID uid = (InterObjectUnitID)obj;
            return m_Idx == uid.m_Idx && m_Type == uid.m_Type;
        }

        public bool Equals(InterObjectUnitID a)
        {
            if ((Object)a == null)
                return false;

            return m_Idx == a.m_Idx && m_Type == a.m_Type;
        }

        public override int GetHashCode()
        {
            return (int) ((short)m_Idx | (byte)m_Type << 16 & 0x00ffffff);
        }

        public static bool operator == (InterObjectUnitID a, InterObjectUnitID b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;

            if ((Object)a == null || (Object)b == null)
                return false;

            return a.m_Idx == b.m_Idx && a.m_Type == b.m_Type;
        }

        public static bool operator !=(InterObjectUnitID a, InterObjectUnitID b)
        {
            return !(a == b);
        }

        public InterObjectUnitID Copy()
        {
            InterObjectUnitID uid = new InterObjectUnitID();
            uid.m_Idx = m_Idx;
            uid.m_Type = m_Type;

            return uid;
        }

        public override string ToString()
        {
            return string.Format("type={0} obj_idx={1}", m_Type, m_Idx);
        }
    }
}
