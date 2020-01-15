//-----------------------------------
// File: GoodsMountEquip.cs
// Desc: 坐骑装备  容器
// Author: luozhuocheng
// Date: 2018/8/29 15:32:39
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsMountEquip : GoodsItem
    {
        private Net.PkgGoodsInfo _netInfo;
        public GoodsMountEquip(uint typeId, Net.PkgGoodsInfo goodsInfo)
        {
            _netInfo = goodsInfo;
            CreateGoodsByTypeId(typeId);
            if (BasicAttrs == null)
                BasicAttrs = new ActorAttribute();
            else
                BasicAttrs.Clear();

            if (DBData != null)
            {
                List<DBTextResource.DBAttrItem> list = DBData.attrs;
                for (int i = 0; i < list.Count; i++)
                {
                    BasicAttrs.Add(list[i].attr_id, list[i].attr_num);
                }
            }

        }

        private DBMountEquipGoods.DBMountEquipGoodsItem DBData
        {
            get
            {
                return DBMountEquipGoods.Instance.GetData(type_idx);
            }
        }

        public uint ride_limit
        {
            get
            {
                return DBData != null ? DBData.ride_limit : 0;
            }
        }


        //品质
        public uint color
        {
            get
            {
                return color_type;
                //return mountEquip != null ? mountEquip.color : 0;
            }
        }

        //阶数
        public uint lv_step
        {
            get
            {
                return DBData != null ? DBData.lv_step : 0;
                //return mountEquip != null ? mountEquip.lv : 0;
            }
        }

        //部位
        public uint pos_id
        {
            get
            {
                return DBData != null ? DBData.pos_id : 0;
                //return mountEquip != null ? mountEquip.pos_id : 0;
            }
        }

        // 基础属性
        public ActorAttribute BasicAttrs { get; private set; }

        //坐骑装备 锻造等级
        public uint lv;

        //套装  阶数等级
        public uint suit_lv;
        


        //是否在穿着
        public bool IsWearing
        {
            get
            {
                GoodsMountEquip equip = ItemManager.Instance.GetWearingMountEquipGoods(pos_id);
                if (equip != null && equip.id == id)
                    return true;
                else
                    return false;
            }
        }


        public uint Score
        {
            get
            {
                return (BasicAttrs == null ? 0 : BasicAttrs.Score);
            }
        }


        public new GoodsMountEquip Clone()
        {
            GoodsMountEquip equip = new GoodsMountEquip(this.type_idx, this._netInfo);
            equip.id = this.id;
            equip.BasicAttrs = this.BasicAttrs;
            equip.lv = this.lv;
            equip.suit_lv = this.suit_lv;
            return equip;
        }



        public override void RefreshEquipUp()
        {
            is_equipUp = false;
            is_equipDown = false;
            if (LocalPlayerManager.Instance.LocalActorAttribute.Vocation != this.use_job && this.use_job != 0)
            {
                return;
            }
            if (this.IsInEnableTime() == false)
            {//物品过期
                is_equipUp = false;
                is_equipDown = false;
                return;
            }
            GoodsMountEquip equip = ItemManager.Instance.GetWearingMountEquipGoods(pos_id);
            if (equip == null)
            {
                is_equipUp = true;
                is_equipDown = false;
                return;
            }
            uint this_equipRank = this.Score;
            uint equip_rank = equip.Score;
            if (this_equipRank > equip_rank)
                is_equipUp = true;
            else if (this_equipRank < equip_rank)
                is_equipDown = true;
        }


    }
}
