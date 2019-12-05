using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Net;
namespace xc.Equip
{
    /// <summary>
    /// 装备信息
    /// </summary>
    [wxb.Hotfix]
    public class EquipInfo
    {
        /// <summary>
        /// 是否穿上了
        /// </summary>
        public bool IsInstalled { get; set; }

        /// <summary>
        /// 装备底模id
        /// </summary>
        public uint EquipId { get; private set; }
        /// <summary>
        /// 是否是珍品装备
        /// </summary>
        public bool IsGem
        {
            get
            {
//                 var qualityData = DBManager.GetInstance().GetDB<DBEquipMod>().GetModData(EquipId);
//                 if (qualityData.BatCount <= BasicRank)
//                 {
//                     return true;
//                 }

                return false;
            }
        }      
        
        /// <summary>
        /// 装备底模数据
        /// </summary>
        public EquipModData Data { get { return DBManager.GetInstance().GetDB<DBEquipMod>().GetModData(EquipId); } }

        /// <summary>
        /// 装备总加成的属性集
        /// </summary>
        public Attributes Attrs { get; private set; }

        /// <summary>
        /// 装备的基础属性集
        /// 
        /// 只有基础属性（通过读表就可以生成）
        /// </summary>
        public ActorAttribute BasicAttrs { get; private set; }

        /// <summary>
        /// 传奇属性集
        /// </summary>
        public EquipAttributes LegendAttrs { get; private set; }


        /// <summary>
        /// 装备名称
        /// </summary>
        public string Name { get{
                return Data.Name;
            } 
        }
        /// <summary>
        /// 装备的部位
        /// </summary>
        public EEquipPos EquipPos
        {
            get { return Data.Pos; }
        }

        /// <summary>
        /// 装备绑定状态
        /// </summary>
        private uint bind = 0;

        public uint Bind
        {
            set{
                bind = value;
            }
            get { return bind; }
        }

        /// <summary>
        /// 装备宝石信息 没有镶嵌是0 list长度就是宝石孔
        /// </summary>
        public List<uint> GemInfo = new List<uint>();



        /// <summary>
        /// 装备禁用时间戳
        /// </summary>
        public uint DisEnableTime {set;get;}

        /// <summary>
        /// 综合评分
        /// </summary>
        public uint Rank
        {
            get 
            {
                return 0/*未写*/;
//                return (uint)EquipHelper.CalculateEquipBattlePower(Attrs, Data.InitRank) + EquipAttrs.Score;
            }
        }

        /// <summary>
        /// 基础属性评分包含神赐（2016.9.28腾基：该评分只有基础属性+无钻+神赐！）
        /// </summary>
        public uint BasicRank
        {
            get
            {
                return 0/*未写*/;
//                return (uint)EquipHelper.CalculateEquipBattlePower(BasicAttrs, Data.InitRank) + EquipAttrs.Score;
            }
        }

        /// <summary>
        /// 是否为武器
        /// </summary>
        public bool IsWeapon
        {
            get { return Data.Pos == EEquipPos.POS_10;}
        }

        public EquipInfo(uint eid)
        {
            IsInstalled = false;
            EquipId = eid;
            Init(null);
        }

        public EquipInfo(Net.PkgGoodsInfo equip)
        {
            EquipId = equip.gid;
            IsInstalled = false;
            Init(equip);
//             if (equip.equip != null)
//             {
//                 IsInstalled = equip.equip.index == 0 ? true : false;
//             }
        }



        public void Init(Net.PkgGoodsInfo equip)
        {
            Attrs = new Attributes();
            BasicAttrs = new ActorAttribute();
            LegendAttrs = new EquipAttributes();
            if (equip != null)
            {
                //处理LegendAttrs
            }
        }
    }
}