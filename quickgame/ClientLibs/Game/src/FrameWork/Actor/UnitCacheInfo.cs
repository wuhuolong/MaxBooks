using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net;
namespace xc
{
    /// <summary>
    /// AOI的缓存数据
    /// </summary>
    [wxb.Hotfix]
    public class UnitCacheInfo
    {
        /// <summary>
        /// 缓存的类型(创建\销毁)
        /// </summary>
        public enum EType : byte
        {
            ET_Create = 0,
            ET_Destroy,
        }

        public UnitCacheInfo(EUnitType type, uint obj_idx)
        {
            UnitID = new UnitID();
            UnitID.type = (byte)type;
            UnitID.obj_idx = obj_idx;

            if (type == EUnitType.UNITTYPE_PLAYER)
            {
                AOIPlayer = new UnitEnterAOI._Player();
            }
            else if(type == EUnitType.UNITTYPE_MONSTER)
            {
                AOIMonster = new UnitEnterAOI._Monster();
            }
            else if (type == EUnitType.UNITTYPE_PET)
            {
                AOIPet = new UnitEnterAOI._Pet();
            }
        }

        /// <summary>
        /// 唯一ID
        /// </summary>
        public UnitID UnitID = null;

        // 各类型AOI数据的对象
        public UnitEnterAOI._Player AOIPlayer = null;
        public UnitEnterAOI._Monster AOIMonster = null;
        public UnitEnterAOI._Pet AOIPet = null;
        public NpcDefine ClientNpcDefine = null;// 数据由客户端填充
        public Neptune.NPC ClientNpc = null; // 数据由客户端填充

        public EType CacheType;

        /// <summary>
        ///  出生位置
        /// </summary>
        public Vector3 PosBorn = new Vector3();

        /// <summary>
        /// 出生朝向
        /// </summary>
        public Quaternion Rotation = Quaternion.AngleAxis(90, Vector3.up);

        /// <summary>
        /// 宠物/召唤怪的父角色
        /// </summary>
        public Actor ParentActor
        {
            set
            {
                if (m_ParentActor == null || !m_ParentActor.IsAlive)
                {
                    m_ParentActor = new WeakReference(value);
                }
                else
                    m_ParentActor.Target = value;
            }

            get
            {
                if (m_ParentActor != null && m_ParentActor.IsAlive)
                {
                    return (Actor)m_ParentActor.Target;
                }
                else
                    return null;
            }
        }

        private WeakReference m_ParentActor;

        public EUnitType UnitType
        {
            get { return (EUnitType)UnitID.type; }
        }

        /// <summary>
        /// 服务端发送下来的角色属性（可能只发一部分,目前只有怪物用到）
        /// </summary>
        public List<PkgAttrElm> AttrElements
        {
            get{return m_AttrElements; }
            set{ m_AttrElements = value;}
        }
        List<PkgAttrElm> m_AttrElements;

        public bool IsUIModel = false;
    }       
}

