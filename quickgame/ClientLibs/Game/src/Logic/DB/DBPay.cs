/*----------------------------------------------------------------
// 文件名： DBPay.cs
// 文件功能描述： 充值表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBPay : DBSqliteTableResource
    {
        public class PayItemInfo:IComparable
        {
            public uint Id; // id
            public string Channel; // 平台
            public float RmbLow; // 该档位的人民币
            public uint Diamond; // 获取的金锭数量
            public uint LimitGID; // 限购物品的id
            public Dictionary<uint, uint> TreasureGID; // 宝箱中物品的id列表
            public uint LimitTimes; // 物品每日限购数量
            public uint BonusFirstType; // 首充赠货币类型
            public uint BonusFirst; // 首充赠金锭
            public uint BonusOther; //普通赠金锭
            public uint BonusOtherType; // 普通赠货币类型
            public string Icon; // 该档位显示的图标
            public uint SortId;//排序id
            public bool IsShow; // 是否在充值界面显示（网页充值的在游戏界面不需要显示）
            //public string ProductId; // 商品ID
            //public string ProductName;// 商品名称
            //public string ProductDesc;// 商品描述

            //等于返回0值，大于返回大于0的值，小于返回小于0的值。
            public int CompareTo(object obj)
            {
                if (obj == null)
                    return -1;

                PayItemInfo item_info = (PayItemInfo)obj;
                int ret = LimitGID.CompareTo(item_info.LimitGID);
                if (ret != 0)
                    return ret*-1;
                else
                    return SortId.CompareTo(item_info.SortId);
            }
        }
        Dictionary<string, List<PayItemInfo>> mPayItemInfos = new Dictionary<string, List<PayItemInfo>>();

        public DBPay(string strName, string strPath)
            : base(strName, strPath)
		{
		}

        /// <summary>
        /// 获取当前平台下的所有充值信息
        /// </summary>
        public List<PayItemInfo> PayItemList
        {
            get
            {
                List<PayItemInfo> pay_item_list = new List<PayItemInfo>();
                pay_item_list.Clear();

                IBridge brideg = DBOSManager.getOSBridge();
                var channel = brideg.getSDKName();
                List<PayItemInfo> item_info_list = null;
                // 如果当前渠道找不到，则用undefined渠道标识
                if (!mPayItemInfos.TryGetValue(channel, out item_info_list))
                {
                    mPayItemInfos.TryGetValue("undefined", out item_info_list);
                }

                foreach (PayItemInfo item_info in item_info_list)
                {
                    if (item_info.IsShow == true)
                        pay_item_list.Add(item_info);
                }

                pay_item_list.Sort();
                return pay_item_list;
            }
        }

        public override void Unload()
        {
            base.Unload();
            mPayItemInfos.Clear();
        }

		protected override void ParseData(SqliteDataReader reader)
        {
            mPayItemInfos.Clear();

            if (reader == null || reader.HasRows == false)
                return;

            while (reader.Read())
            {
                var info = new PayItemInfo();

                info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                info.Channel = GetReaderString(reader, "channel");

                System.Type rmbLowFieldType = reader.GetFieldType(reader.GetOrdinal("rmb_low"));
                if (rmbLowFieldType == typeof(string))
                {
                    info.RmbLow = DBTextResource.ParseF_s(GetReaderString(reader, "rmb_low"), 0f);
                }
                else if (rmbLowFieldType == typeof(float))
                {
                    info.RmbLow = GetReaderFloat(reader, "rmb_low");
                }
                
                info.Diamond = DBTextResource.ParseUI_s(GetReaderString(reader, "diamond"), 0);
                info.LimitGID = DBTextResource.ParseUI_s(GetReaderString(reader, "gid"), 0);
                var good_ids = TextHelper.GetListFromString(GetReaderString(reader, "good_ids"));
                var good_num = TextHelper.GetListFromString(GetReaderString(reader, "good_num"));
                if (good_ids != null && good_num != null)
                {
                    info.TreasureGID = new Dictionary<uint, uint>();
                    int i = 0;
                    foreach(var id in good_ids)
                    {
                        var gid = DBTextResource.ParseUI_s(id, 0);
                        uint gnum = 1;
                        if(i < good_num.Length)
                        {
                            gnum = DBTextResource.ParseUI_s(good_num[i], 0);
                        }
                        info.TreasureGID[gid] = gnum;

                        i++;
                    }
                }

                info.LimitTimes = DBTextResource.ParseUI_s(GetReaderString(reader, "limit_times"), 0);
                info.BonusFirst = DBTextResource.ParseUI_s(GetReaderString(reader, "bonus_first"), 0);
                info.BonusFirstType = DBTextResource.ParseUI_s(GetReaderString(reader, "bonus_first_type"), 0);
                info.BonusOther = DBTextResource.ParseUI_s(GetReaderString(reader, "bonus_other"), 0);
                info.BonusOtherType = DBTextResource.ParseUI_s(GetReaderString(reader, "bonus_other_type"), 0);
                info.Icon = GetReaderString(reader, "icon");
                info.SortId = DBTextResource.ParseUI_s(GetReaderString(reader, "sort_id"), 0);
                info.IsShow = DBTextResource.ParseUI_s(GetReaderString(reader, "is_show"), 0) == 1;
                //info.ProductId = GetReaderString(reader, "product_id");
                //info.ProductName = GetReaderString(reader, "product_name");
                //info.ProductDesc = GetReaderString(reader, "product_desc");

                List<PayItemInfo> pay_item_list = null;
                if(!mPayItemInfos.TryGetValue(info.Channel, out pay_item_list))
                {
                    pay_item_list = new List<PayItemInfo>();
                    mPayItemInfos[info.Channel] = pay_item_list;
                }

                pay_item_list.Add(info);
            }
        }
	}
}
