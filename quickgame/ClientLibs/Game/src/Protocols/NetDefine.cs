using System;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public class LeaveBuff
    {
        public uint id;
        public ulong time;
        public uint layer;
        public uint no_tips;
        public LeaveBuff(uint _id, ulong _time, uint _layer, uint _no_tips)
        {
            id = _id;
            time = _time;
            layer = _layer;
            no_tips = _no_tips;
        }
    }

    /// <summary>
    /// AOI的信息（玩家/怪物/宠物）
    /// </summary>
    public class UnitEnterAOI
    {
        /// <summary>
        /// 玩家的AOI信息
        /// </summary>
        public class _Player
        {
            /// <summary>
            /// 角色表中的ID
            /// </summary>
            public uint type_idx;

            /// <summary>
            /// 角色的名字
            /// </summary>
            public string name = "";

            /// <summary>
            /// 角色当前的血量
            /// </summary>
            public uint hp;

            /// <summary>
            /// 角色的等级
            /// </summary>
            public short level;

            /// <summary>
            /// 角色的阵营
            /// </summary>
            public uint camp = 0;

            /// <summary>
            /// 队伍的ID
            /// </summary>
            public uint team_id = 0;
            
            /// <summary>
            /// 身体和物体的外观ID列表
            /// </summary>
            public List<uint> model_id_list;

            /// <summary>
            /// 时装外观ID列表
            /// </summary>
            public List<uint> fashions;

            /// <summary>
            /// 套装特效ID列表
            /// </summary>
            public List<uint> suit_effects;

            /// <summary>
            /// buff列表(添加buff时，角色还未创建，等待角色创建后再addbuff)
            /// </summary>
            public List<LeaveBuff> leave_buff_id_list;

            /// <summary>
            /// 宠物ID
            /// </summary>
            public uint pet_id;
  
            /// <summary>
            /// 坐骑ID
            /// </summary>
            public uint mount_id;

            /// <summary>
            ///  名字颜色(红名\白名等)
            /// </summary>
            public uint name_color;

            /// <summary>
            /// 玩家状态
            /// </summary>
            public uint state;

            /// <summary>
            /// 帮派名字
            /// </summary>
            public string guild_name = "";

            /// <summary>
            /// 帮派id
            /// </summary>
            public uint guild_id;

            /// <summary>
            /// 头衔Id 
            /// </summary>
            public uint honor_id;

            /// <summary>
            /// 称号Id
            /// </summary>
            public uint title_id;

            /// <summary>
            /// 正在进行中的护送任务id
            /// </summary>
            public uint escort_id = 0;

            /// <summary>
            /// 转职等级
            /// </summary>
            public uint transfer_lv = 0;

            /// <summary>
            /// 伴侣信息
            /// </summary>
            public Net.PkgMateInfo mate_info;
        }
        
        /// <summary>
        /// 怪物的AOI信息
        /// </summary>
        public class _Monster  
        {
            /// <summary>
            /// 角色表中的ID
            /// </summary>
            public uint type_idx;

            /// <summary>
            /// 当前血量
            /// </summary>
            public uint hp;

            /// <summary>
            /// 怪物的动态等级
            /// </summary>
            public uint level = (uint)0;

            /// <summary>
            /// 怪物的阵营
            /// </summary>
            public uint camp = 1;

            /// <summary>
            /// buff列表(添加buff时，角色还未创建，等待角色创建后再addbuff)
            /// </summary>
            public List<LeaveBuff> leave_buff_id_list;
        }

        /// <summary>
        /// 宠物信息
        /// </summary>
        public class _Pet
        {
            /// <summary>
            /// 宠物表中的ID
            /// </summary>
            public uint pet_id;

            /// <summary>
            /// 角色表中的ID
            /// </summary>
            public uint type_idx;

            /// <summary>
            /// 是否是本地玩家创建的宠物
            /// </summary>
            public bool is_local;
        }

        //--------------------------------------
    }

    /// <summary>
    /// AOI的类型
    /// </summary>
    public enum EUnitType
    {
        UNITTYPE_PLAYER= 0,  // 玩家
        UNITTYPE_MONSTER,    // 怪物
        UNITTYPE_NPC,        // npc
        UNITTYPE_PET,        // pet
    };

    // 战斗标签
    public enum EWarTag
    {
        None = 0,
        SpringGuard            = 1,  // 泉水守卫
        GuardStone             = 2,  // 守卫石
        Gate                   = 3,  // 城门
        Mercenary              = 4,  // 佣兵
        Vehicle                = 5,  // 攻城车
        BirthPos               = 6,  // 玩家出生点
        MonsterDefenceTower    = 7,  // 怪物防御塔
        MonsterShieldTower     = 8,  // 怪物护盾塔
        EnergyCore             = 9,  // 能量核心
        SummonedActor          = 10, // 角色召唤物
        DefCrystal             = 11, // 塔防水晶
        DefMercenary           = 12, // 塔防佣兵
        Goblin                 = 13, // 哥布林怪物
        CrosswarCampA          = 14, // 跨服战阵营A大本营
        CrosswarCampB          = 15, // 跨服战阵营B大本营
        CrosswarCampC          = 16, // 跨服战阵营C大本营
        CrosswarBigBuildingA   = 17, // 跨服战阵营A大建筑
        CrosswarBigBuildingB   = 18, // 跨服战阵营B大建筑
        CrosswarBigBuildingC   = 19, // 跨服战阵营C大建筑
        CrosswarSmallBuildingA = 20, // 跨服战阵营A小建筑
        CrosswarSmallBuildingB = 21, // 跨服战阵营B小建筑
        CrosswarSmallBuildingC = 22, // 跨服战阵营C小建筑
        CrosswarGuardA         = 23, // 跨服战阵营A守卫
        CrosswarGuardB         = 24, // 跨服战阵营B守卫
        CrosswarGuardC         = 25, // 跨服战阵营C守卫
    }

    /// <summary>
    /// 角色的唯一ID
    /// </summary>
    public class UnitID
    {
        public byte type;   // 角色类型
        public uint obj_idx;// 服务器产生的自增编号

        public UnitID()
        {
            type = 0;
            obj_idx = 0;
        }

        public UnitID(byte t, uint idx)
        {
            type = t;
            obj_idx = idx;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            if ((obj.GetType().Equals(GetType())) == false)
            {
                return false;
            }

            UnitID uid = (UnitID)obj;
            return obj_idx == uid.obj_idx;
        }

        public bool Equals(UnitID a)
        {
            if((Object)a == null)
                return false;

            return obj_idx == a.obj_idx;
        }
        
        public override int GetHashCode()
        {
            return (int)obj_idx;// 服务端设计的obj_idx不会重复，所以使用obj_idx作为索引
            //return (int) ((byte)obj_idx | (byte)type<<8 & 0x0000ffff);
        }

        public static bool operator == (UnitID a, UnitID b)
        {
            if(System.Object.ReferenceEquals(a,b))
                return true;

            if((Object)a == null || (Object)b == null)
                return false;

            return a.obj_idx == b.obj_idx;
        }

        public static bool operator != (UnitID a, UnitID b)
        {
            return !(a==b);
        }

        public UnitID Copy()
        {
            UnitID uid = new UnitID();
            uid.type = type;
            uid.obj_idx = obj_idx;
            
            return uid;
        }
        
        public override string ToString()
        {
            return string.Format("type={0} obj_idx={1}", type, obj_idx);
        }
    }
}
