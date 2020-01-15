using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Reflection;
using UnityEngine;

namespace xc
{
    public class ActorAttributeData
    {
        /// <summary>
        /// 属性数值为0时，使用的默认替换值
        /// </summary>
        static uint m_DefaultAttr = 10000;

        //当前血量和蓝量,通过战斗协议同步
        public long HP{ set;get;}

        public long MP{ set;get;}

        #region 属性的快捷访问器
        //最大血量
        public long HPMax
        {
            set
            {
                Attribute[GameConst.AR_MAX_HP].Value = value;
            }
            get
            {
                return Attribute[GameConst.AR_MAX_HP].Value;
            }
        }

        //最大蓝量
        public long MPMax
        {
            set
            {
                Attribute[GameConst.AR_MAX_MP].Value = value;
            }
            get
            {
                return Attribute[GameConst.AR_MAX_MP].Value;
            }
        }

        /// <summary>
        /// 攻速
        /// </summary>
        public int AttackSpeed
        {
            set
            {
                Attribute[GameConst.AR_ATK_SPEED].Value = (int)value;
            }
            get
            {
                var speed = (int)Attribute[GameConst.AR_ATK_SPEED].Value;
                if (speed == 0)// 服务端发送的攻速属性可能为0
                    return (int)m_DefaultAttr;
                else
                    return speed;
            }
        }

        /// <summary>
        /// 通过基础属性计算出的攻速
        /// </summary>
        public float AttackSpeedComb
        {
            get
            {
                var atk_speed_base = (int)Attribute[GameConst.AR_ATK_SPEED_BASE].Value;
                var atk_speed_add = (int)Attribute[GameConst.AR_ATK_SPEED_ADD].Value;
                float speed = GameConstHelper.GetFloat("GAME_CF_SPEED1") *(atk_speed_base * (10000.0f + atk_speed_add) / 10000.0f)/((atk_speed_base * (10000.0f + atk_speed_add) / 10000.0f)+ GameConstHelper.GetFloat("GAME_CF_SPEED2"));
                return speed;
            }
        }

        /// <summary>
        /// 移动速度的缩放数值
        /// </summary>
        public int MoveSpeedScale
        {
            set
            {
                Attribute[GameConst.AR_SPEED].Value = (int)value;
            }
            get
            {
                var speed = (int)Attribute[GameConst.AR_SPEED].Value;
                if (speed == 0)// 服务端发送的攻速属性可能为0
                    return (int)m_DefaultAttr;
                else
                    return speed;
            }
        }

        /// <summary>
        /// 移动速度的增加数值
        /// </summary>
        public int MoveSpeedAdd
        {
            set
            {
                Attribute[GameConst.AR_SPEED_ADD].Value = (int)value;
            }
            get
            {
                var speed = (int)Attribute[GameConst.AR_SPEED_ADD].Value;
                return speed;
            }
        }

        /// <summary>
        /// 战斗力
        /// </summary>
        public long BattlePower
        {
            set
            {
                Attribute[GameConst.AR_BAT_PW].Value = (uint)value;
            }
            get
            {
                return (uint)Attribute[GameConst.AR_BAT_PW].Value;
            }
        }
        #endregion

        #region AOI单独属性
        /// <summary>
        /// 角色在服务器的唯一id
        /// </summary>
        public UnitID UnitId = new UnitID();

        /// <summary>
        /// 角色名字
        /// </summary>
        public string Name = "";

        /// <summary>
        /// 等级
        /// </summary>
        public uint Level = 0;

        /// <summary>
        /// 队伍id
        /// </summary>
        public uint TeamId = 0;

        /// <summary>
        /// /帮派ID
        /// </summary>
        public uint GuildId = 0;

        /// <summary>
        /// 帮派名字
        /// </summary>
        public string GuildName = "";

        /// <summary>
        /// 阵营
        /// </summary>
        public uint Camp;

        /// <summary>
        /// 玩家状态
        /// </summary>
        public uint State;

        /// <summary>
        /// 头衔Id 
        /// </summary>
        public uint Honor;

        /// <summary>
        /// 称号Id
        /// </summary>
        public uint Title;

        /// <summary>
        /// 正在进行中的护送任务id
        /// </summary>
        public uint EscortId;

        /// <summary>
        /// 转职等级
        /// </summary>
        public uint TransferLv;

        #endregion

        #region 表格中字段
        /// <summary>
        /// 职业
        /// </summary>
        public uint Vocation;

        /// <summary>
        /// 行为树路径
        /// </summary>
        public string BehaviourTree;

        /// <summary>
        /// 被召唤出来之后的行为树路径
        /// </summary>
        public string SummonBehaviourTree;

        /// <summary>
        /// 默认的运动范围半径
        /// </summary>
        public int DefaultMotionRadius = 0;

        /// <summary>
        /// 战斗标签
        /// </summary>
        public byte WarTag;

        /// <summary>
        /// 攻击时是否转向
        /// </summary>
        public uint AttackRotaion = 1;

        /// <summary>
        /// 角色品质
        /// </summary>
        public uint Quality = 1;

        /// <summary>
        /// 角色重力参数
        /// </summary>
        public ushort Gravity = 50;
        #endregion

        /// <summary>
        /// 服务端下发的属性
        /// </summary>
        public ActorAttribute Attribute = new ActorAttribute();

        public ActorAttributeData()
        {
            // 设置默认属性，保证初始的攻速为1
            Attribute[GameConst.AR_ATK_SPEED_BASE].Value = 100;
            Attribute[GameConst.AR_ATK_SPEED_ADD].Value = 0;
        }

        /// <summary>
        /// 通过角色表id来进行属性字段的初始化(用于LocalActorAttribure的初始化)
        /// </summary>
        /// <param name="type_id"></param>
        public void InitAttributeData(uint type_id)
        {
            //查表根据类型填充属性字段
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();
            if (null == db)
            {
                GameDebug.Log("[ActorAttributeData]DBActor is null");
                return;
            }
            
            if (!db.ContainsKey(type_id))
            {
                GameDebug.Log("[ActorAttributeData]DBActor not exist type_id: " + type_id);
                return;
            }

            DBActor.ActorData data = db.GetData(type_id);
            Vocation = data.vocation;
            BehaviourTree = data.behaviour_tree + ".json";
            SummonBehaviourTree =  data.summon_behaviour_tree + ".json";  
            DefaultMotionRadius = data.motion_radius;
            WarTag = data.war_tag;
            AttackRotaion = data.attack_rotaion;
            Quality = (uint)data.color;
            Gravity = data.gravity;

            // 设置默认属性，保证初始的攻速为1
            Attribute[GameConst.AR_ATK_SPEED_BASE].Value = 100;
            Attribute[GameConst.AR_ATK_SPEED_ADD].Value = 0;
            Attribute[GameConst.AR_MOVE_REAL_SPEED].Value = (uint)(data.runspeed);
        }

        /// <summary>
        /// 拷贝属性字段
        /// </summary>
        /// <param name="at"></param>
        public void Copy(ActorAttributeData at)
        {
            //同步AOI属性
            UnitId = at.UnitId;
            Name = at.Name;//角色名字
            Level = at.Level; //等级
            TeamId = at.TeamId;//队伍id
            GuildId = at.GuildId; // 帮派id
            Camp = at.Camp; // 阵营id
            Honor = at.Honor; // 头衔Id
            Title = at.Title; // 称号Id
            EscortId = at.EscortId; // 正在进行中的护送任务id
            TransferLv = at.TransferLv; // 转职等级

            //同步表格属性
            Vocation = at.Vocation; //职业
            BehaviourTree = at.BehaviourTree; //行为树路径
            SummonBehaviourTree = at.SummonBehaviourTree;
            DefaultMotionRadius = at.DefaultMotionRadius;
            WarTag = at.WarTag;
            AttackRotaion = at.AttackRotaion;
            Quality = at.Quality;
            Gravity = at.Gravity;
            GuildName = at.GuildName;

            // 同步服务端下发的属性
            foreach (var k in at.Attribute.Keys)
            {
                Attribute[k] = at.Attribute[k];
            }

            MP = at.MP;
            HP = at.HP;
        }

        public void Clear()
        {
            UnitId = null;
            if(Attribute != null)
            {
                Attribute.Clear();
                Attribute = null;
            }
        }
    }
}


