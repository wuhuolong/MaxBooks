using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace xc
{
    [wxb.Hotfix]
    public class GoodsSoul : GoodsItem
    {
        public GoodsSoul(uint typeId, Net.PkgGoodsInfo info)
        {
            
            CreateGoodsByTypeId(typeId);
            var data_soul = DBManager.Instance.QuerySqliteLikeKeyRow<string>(GlobalConfig.DBFile, "data_soul", "gid", type_idx.ToString());
            if (data_soul.Count > 0)
            {
                var table = data_soul[0];
                ResolveGetVal = DBTextResource.ParseUI(table["resolve"]);
            }

            if (info != null)
                UpdateSoul(info.soul);
        }
        public void UpdateSoul(Net.PkgSoul soul)
        {
            if (soul != null)
            {
                NetSoul = soul;
                Lv = soul.lv;
                HoleId = soul.hole_id;
                UpdateSoul();
            }
            
        }
        private bool isShowAttr = false;
        public void UpdateSoul(uint lv)
        {
            Lv = lv;
            isShowAttr = true;
            UpdateSoul();
        }
        public void UpdateSoul()
        {
 
            if (BasicAttrs == null)
                BasicAttrs = new ActorAttribute();
            BasicAttrs.Clear();


            CurLvHaveVal = 0;
            if (Lv >= 2)
            {
                for (int i = 1; i < Lv; i++)
                {
                    string csv_id = string.Format("{0}_{1}", type_idx, i);
                    var info = DBSoulLv.Instance.GetData(csv_id);
                    if (info != null)
                    {
                        CurLvHaveVal += info.cream;
                    }
                }
            }



            string key = string.Format("{0}_{1}", type_idx, Lv);
            SetAttribute(key, BasicAttrs, true);



            if (MaxBasicAttrs == null)
                MaxBasicAttrs = new ActorAttribute();
            MaxBasicAttrs.Clear();
            var data_soul_list = DBManager.Instance.QuerySqliteLikeKeyRow<string>(GlobalConfig.DBFile, "data_soul", "gid", type_idx.ToString());
            if (data_soul_list.Count <= 0)
            {
                GameDebug.LogError("不存在该武魂id" + type_idx.ToString());
                return;
            }

            var data_soul = data_soul_list[0];
            MaxLv = DBTextResource.ParseUI(data_soul["max_lv"]);
            Tips = data_soul["tips"];


            mSoulType = DBTextResource.ParseUI(data_soul["type"]);

            if (data_soul["s_type"].Contains("["))
            {
                mTypeList = DBTextResource.ParseArrayUint(data_soul["s_type"], ",");
            }
            else
            {
                mTypeList = new List<uint>();
                uint value = DBTextResource.ParseUI(data_soul["s_type"]);
                mTypeList.Add(value);
            }


            key = string.Format("{0}_{1}", type_idx, MaxLv);
            SetAttribute(key, MaxBasicAttrs, false);


            IsMaxLv = MaxLv == Lv;


            string oriDes = GoodsHelper.GetGoodsDescriptionByTypeId(type_idx);
       
            if(isShowAttr)
                base.description = GetShowDetailText();
            else
                base.description = oriDes;
        }

        private void SetAttribute(string key ,ActorAttribute attr, bool isCur)
        {
            var info = DBSoulLv.Instance.GetData(key);
            if (info != null)
            {
                using(var iter = info.attr.GetEnumerator())
                {
                    while(iter.MoveNext())
                    {
                        var cur = iter.Current;
                        attr.Add(cur.Key, cur.Value);
                    }
                }

                if (isCur)
                    UpLvNeedVal = info.cream;
            }
        }

        public string GetTextByAttr(ActorAttribute attr)
        {
            int index = 1;

            //string attrStr = "";
            //foreach (var kv in attr)
            //{
            //    DefaultActorAttribute default_attr = kv.Value as DefaultActorAttribute;
            //    string name = default_attr.Name;
            //    if (index < attr.Count)
            //    {
            //        name = name + "\n";
            //    }
            //    attrStr = attrStr + name;
            //    index++;
            //}


            List<xc.Equip.EquipHelper.AttributeDescItem> list = xc.Equip.EquipHelper.GetEquipBaseDesItemArray(attr);
            StringBuilder showStr = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                showStr.Append(list[i].PropName);
                showStr.Append(": ");
                showStr.Append(list[i].ValueStr);
                if (i < list.Count - 1)
                    showStr.Append("\n");
            }


            return showStr.ToString();
            /*
<color=#ebded6>武魂等级：30</color>
<color=#ebded6>镶嵌后获得属性：</color>
<color=#2ae961>命中+137</color>

<color=#ebded6>武魂满级之后:</color>
<color=#2ae961>命中+5600</color>

<color=#0fc5f9>目不窥园，心无旁骛</color>
             */

            //return attrStr;
        }
        private string GetShowDetailText()
        {
            string cur_attr = GetTextByAttr(BasicAttrs);
            string nex_attr = GetTextByAttr(MaxBasicAttrs);
            string detail_text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_64");
            string show_text = string.Format(detail_text, Lv, cur_attr, nex_attr, Tips);
            return show_text;
        }

        public uint HolyWater
        {
            get
            {
                uint water = 0;
                var data_cost = DBManager.Instance.QuerySqliteLikeKeyRow<string>(GlobalConfig.DBFile, "data_soul_compose", "gid", type_idx.ToString());
                if (data_cost.Count > 0)
                {
                    var table = data_cost[0];
                    List<DBTextResource.DBGoodsItem> goodItemList = DBTextResource.ParseDBGoodsItem(table["goods_cost"].ToString());
                    for (int i = 0; i < goodItemList.Count; i++)
                    {
                        DBTextResource.DBGoodsItem goodItem = goodItemList[i];
                        if (goodItem.goods_id == GameConst.MONEY_SOUL_HOLY_WATER)
                        {
                            water = water + goodItem.goods_num;
                        }
                    }
                }
                return water;
            }

        }




        public Net.PkgSoul NetSoul;
        public new bool can_use
        {
            set { }
            get { return false; }
        }
        //等级
        public uint Lv = 0;
        //分解得到的武魂精髓
        public uint ResolveGetVal;
        public bool IsMaxLv;
        public uint UpLvNeedVal;
        public uint HoleId = 0;//如果是0就代表没有镶嵌

        public uint MaxLv = 0;
        public string Tips = "";

        public uint CurLvHaveVal;


        //属性
        public ActorAttribute BasicAttrs { get; private set; }
        //最高级的属性
        public ActorAttribute MaxBasicAttrs { get; private set; }

        /// <summary>
        /// 装备名字
        /// </summary>
        public new string name
        {
            get
            {
                if (Lv > 0 && IsExpSoul == false)
                {
                    if (GlobalConst.IsBanshuVersion)
                    {
                        return string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_65"), GoodsHelper.GetGoodsColor(base.color_type), base.raw_name, Lv);
                    }
                    else
                    {
                        if (MaxLv == 1)
                        {
                            return string.Format("{0}{1}</color>", GoodsHelper.GetGoodsColor(base.color_type), base.raw_name);
                        }
                        else
                        {
							if (Const.Region == RegionType.SEASIA)
                            	return string.Format("{0}{1} Lv.{2}</color>", GoodsHelper.GetGoodsColor(base.color_type), base.raw_name, Lv);
							else
								return string.Format("{0}{1}LV.{2}</color>", GoodsHelper.GetGoodsColor(base.color_type), base.raw_name, Lv);
                        }
                    }
                }
                else
                    return base.name;
            }
            set { /* 不能这样设置的~ */ }
        }

        public bool mCanInstallHole = false;
        public void RefreshSoulCanInstallHole(uint holdId)
        {
            mCanInstallHole = GoodsHelper.SoulCanInstallHole(holdId, this) == 1;
        }



        //武魂类型
        public uint SoulType
        {
            get
            {
                return mSoulType;
            }
        }
        private uint mSoulType = 0;


        //是否武魂经验
        public bool IsExpSoul
        {
            get
            {
                return mSoulType == GameConst.GIVE_SUB_TYPE_SOUL_ONLY_ADD_EXP;
            }
        }


        //武魂属性类型
        private List<uint> mTypeList = null;
        public List<uint> TypeList
        {
            get
            {
                if (mTypeList == null)
                    mTypeList = new List<uint>();
                return mTypeList;
            }
        }


        private uint mTypeCount = 0;
        public uint TypeCount
        {
            get
            {
                return (uint)TypeList.Count;
            }
        }




        public bool IsHaveSame(List<uint> listA)
        {
            List<uint> listB = TypeList;
            for (int i = 0; i < listA.Count; i++)
            {
                if (listB.Contains(listA[i]))
                    return true;
            }
            return false;
        }



    }
}
