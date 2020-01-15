//-----------------------------------
// File: GoodsWeddingRing.cs
// Desc: 婚戒存储类
// Author: luozhuocheng
// Date: 2018/11/7 15:23:33
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class GoodsWeddingRing : GoodsItem
    {

        private uint mIdInfo;
        public uint IdInfo
        {
            set { mIdInfo = value; }
            get { return mIdInfo; }
        }


        private XLua.LuaTable mMateInfo;
        public XLua.LuaTable MateInfo
        {
            set { mMateInfo = value; }
            get { return mMateInfo; }
        }


        public GoodsWeddingRing(uint idInfo, XLua.LuaTable mateInfo)
        {
            mIdInfo = idInfo;
            mMateInfo = mateInfo;
            CreateGoodsByTypeId(DBData.gid);


            if (normal_attrs == null)
                normal_attrs = new ActorAttribute();
            else
                normal_attrs.Clear();

            if (DBData != null)
            {
                List<DBTextResource.DBAttrItem> list = DBData.normal_attrs;
                for (int i = 0; i < list.Count; i++)
                {
                    normal_attrs.Add(list[i].attr_id, list[i].attr_num);
                }
            }



            if (couple_attrs == null)
                couple_attrs = new ActorAttribute();
            else
                couple_attrs.Clear();

            if (DBData != null)
            {
                List<DBTextResource.DBAttrItem> list = DBData.couple_attrs;
                for (int i = 0; i < list.Count; i++)
                {
                    couple_attrs.Add(list[i].attr_id, list[i].attr_num);
                }
            }


        }

        private DBWeddingRingGoods.DBWeddingRingGoodsItem DBData
        {
            get
            {
                return DBWeddingRingGoods.Instance.GetData(mIdInfo);
            }
        }



        //阶数
        public uint step
        {
            get
            {
                return DBData != null ? DBData.step : 0;
            }
        }

        //等级
        public uint lv
        {
            get
            {
                return DBData != null ? DBData.lv : 0;
            }
        }

        //升级需要的经验
        public uint need_exp
        {
            get
            {
                return DBData != null ? DBData.need_exp : 0;
            }
        }


        //技能id
        public uint skill
        {
            get
            {
                return DBData != null ? DBData.skill : 0;
            }
        }


        //对应的物品id
        public uint gid
        {
            get
            {
                return DBData != null ? DBData.gid : 0;
            }
        }

        // 基础属性
        public ActorAttribute normal_attrs { get; private set; }

        //情侣属性
        public ActorAttribute couple_attrs { get; private set; }






        public new GoodsWeddingRing Clone()
        {
            GoodsWeddingRing equip = new GoodsWeddingRing(this.mIdInfo, this.mMateInfo);
            return equip;
        }


    }
}
