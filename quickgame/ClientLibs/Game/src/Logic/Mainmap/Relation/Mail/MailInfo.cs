using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using xc.ui;
using xc;

namespace xc
{
    public class Money
    {
        public ushort Type  = 0;
        public ulong Num = 0;
    }

    [wxb.Hotfix]
    public class MailInfo
    {
        public enum JumpType : ushort
        {
            TRADE_FOCUS = 401,
            TRADE_DARK = 402,
            TRADE_SUIT = 403,
            TRADE_SELL = 404,
            TRADE_AUCTION = 405,
            TRADE_COLLECT = 406,
            TRADE_CROSS_COLLECT = 407
        }

       

        public Net.PkgMail netEmailInfo;
        public List<Net.PkgAttachment> netEmailAttachs = new List<Net.PkgAttachment>();
        public ulong MailId {
            get{
                if(netEmailInfo == null)
                    return 0;
                else
                    return netEmailInfo.mail_id;
                } 
        }

        public bool IsNew = false;

        public uint CreateTime{
            get{
                if(netEmailInfo == null)
                    return 0;
                else
                    return netEmailInfo.createtime;
            }
        }
        public string From{
            get{
                if(netEmailInfo == null)
                    return "";
                else
                    return System.Text.Encoding.UTF8.GetString(netEmailInfo.from);
            }

        }
        public string Title{
            get{
                if(netEmailInfo == null)
                    return "";
                else
                    return System.Text.Encoding.UTF8.GetString(netEmailInfo.title);
            }
        }
        private string mContent = string.Empty;
        public string Content{
            get{return mContent;}
            set{mContent = value;}
        }

        public bool IsGet {
            set{
                netEmailInfo.state = 3;
            }
            get{
                if(netEmailInfo == null)
                    return false;
                else
                    return netEmailInfo.state == 3 ? true:false;
            }
        }//是否已领取
        public string LinkUrl {get;set;}
        public string LinkTitle{get;set;}
        public MailInfo(Net.PkgMail  net)
        {
            netEmailInfo = net;
        }

        public MailInfo()
        {

        }

        public List<Net.PkgAttachment> Accessories
        {
            get
            {
                return netEmailAttachs;
            }
        }

        public  List<Money> GetAccessoriesMoney()
        {
            //是不是货币需要先判断type是否为GIVE_TYPE_MONEY 如果是那么gid一定是常量表中的money_type
            List<Money> money = new List<Money>();
            if(IsHaveAccessories())
            {
                foreach (var acc in netEmailAttachs)
                {
                    if(acc.type == GameConst.GIVE_TYPE_MONEY)
                    {
                        Money moneyInfo = new Money();
                        moneyInfo.Type = (ushort)acc.goods.gid;
                        moneyInfo.Num = acc.goods.num;
                        money.Add(moneyInfo);
                    }
                }
            }
            return money;
        }

        public List<Goods> GetAccessoriesGoods()
        {
            List<Goods> goods = new List<Goods>();
            if(IsHaveAccessories())
            {
                foreach (var acc in netEmailAttachs)
                {
                    if(acc.type == GameConst.GIVE_TYPE_EQUIP)
                    {
                        Goods equip = GoodsHelper.CreateEquipFromNet(acc.goods);
                        goods.Add(equip);
                    }
                    else if(acc.type == GameConst.GIVE_TYPE_GOODS)
                    {
                        Goods goodsItem = GoodsHelper.GetGoodsFromPkgInfo(acc.goods);
                        goods.Add(goodsItem);
                    }
                }
            }
            return goods;
        }

        public string GetStringTime()
        {
            System.DateTime converted = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 格林威治时间
            System.DateTime createDate = converted.AddSeconds(CreateTime);

            System.DateTime nowTime = Game.Instance.GetServerDateTime();

            // 转换成本地时间
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(nowTime).Hours;
            createDate = createDate.AddHours(offset);

            TimeSpan spanTime = nowTime - createDate;
            float deltaTime = (float)spanTime.TotalSeconds;

            if (deltaTime <= 10.0f)
            {
                return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_78");
            }

            if (deltaTime <= 60.0f)
            {
                return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_79");
            }

            int mins = (int)deltaTime / 60;

            if (mins < 60)
            {
                return mins.ToString() + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_80");
            }

            if (mins <= 70)
            {
                return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_81");
            }

            int hours = (int)spanTime.TotalHours;

            if(hours < 24)
            {
                return hours + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_82");
            }

            return createDate.ToString("MM-dd");
        }

        //是否有附件
        public bool IsHaveAccessories()
        {
            if(netEmailInfo == null)
            {
                return false;
            }

            if(netEmailInfo.is_attached == 0)
            {
                return false;
            }

            return true;
        }

        //是否有附件未领取
        public bool IsHaveAccessoriesToGet()
        {
            if (IsHaveAccessories() == false)
            {
                return false;
            }

            return !IsGet;
        }

        public bool IsRead
        {
            set{netEmailInfo.state = 2;}
            get
            {
                if(netEmailInfo == null)
                    return false;
                else
                    return netEmailInfo.state >= 2 ?true : false;
            }
        }
    }
}
