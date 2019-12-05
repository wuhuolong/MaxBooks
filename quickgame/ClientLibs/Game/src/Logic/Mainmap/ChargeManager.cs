//----------------------------------------------------------------
// File： ChargeManager.cs
// Desc： 充值管理类
// Author: raorui
// Date: 2018.5.15
//----------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    class ChargeManager : xc.Singleton<ChargeManager>
    {
        /// <summary>
        /// 每个档位充值的次数
        /// </summary>
        Dictionary<uint, uint> mBoughtTimes = new Dictionary<uint, uint>();

        /// <summary>
        /// 每个档位限购商品的次数
        /// </summary>
        Dictionary<uint, uint> mLimitTimes = new Dictionary<uint, uint>();

         
        

        public ChargeManager()
        {
            Game.Instance.SubscribeNetNotify((ushort)NetMsg.MSG_PLAYER_PAYMENT_BOUGHT, ProcessServerData);
            Game.Instance.SubscribeNetNotify((ushort)NetMsg.MSG_BIND_GOLD_BOX_INFO, ProcessServerData);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, SysConfigInit);
        }

        /// <summary>
        /// 获取某一档位充值的次数
        /// </summary>
        /// <param name="uid">充值表格id</param>
        /// <returns></returns>
        public uint GetBoughtTimes(uint uid)
        {
            uint times  = 0;
            mBoughtTimes.TryGetValue(uid, out times);
            return times;
        }

        /// <summary>
        /// 获取限购商品的已购买次数
        /// </summary>
        /// <param name="uid">充值表格id</param>
        /// <returns></returns>
        public uint GetLimitTimes(uint uid)
        {
            uint times = 0;
            mLimitTimes.TryGetValue(uid, out times);
            return times;
        }

        public void Reset()
        {
            isHaveOpen = false;
        }

        public void Pay(DBPay.PayItemInfo pay_info)
        {
            if (pay_info == null)
                return;

            var server_id = 0;
            var server_name = "0";
            var server_info = GlobalConfig.Instance.LoginInfo.ServerInfo;
            if (server_info == null)
                Debug.LogError("OnClickPayButton: server_info is null");
            else
            {
                server_id = server_info.ServerId;
                server_name = server_info.Name;
            }

        

#if UNITY_IPHONE
            var pay_request_info = new Dictionary<string, string>();
            //IPHONE 从ProductInfo.json里面读取商品数据
            ProductInfoManager.ProductInfo info = ProductInfoManager.GetInstance().GetProductInfo(pay_info.RmbLow);
            if (info == null)
            {
                //ProductInfo.json   不存在则 读取  C充值商品id.xlsx
                var db_pay_product = DBManager.Instance.GetDB<DBPayProduct>();
                DBPayProduct.PayDroductInfo product_info = db_pay_product.getProductInfo(pay_info.RmbLow);
                pay_request_info.Add("productID", product_info.ProductId);
                pay_request_info.Add("productName", product_info.ProductName);
                pay_request_info.Add("productDesc", product_info.ProductDesc);
            }
            else
            {
                //ProductInfo.json   存在则  读取  ProductInfo.json
                pay_request_info.Add("productID", info.productId);
                pay_request_info.Add("productName", info.productName);
                pay_request_info.Add("productDesc", info.productDesc);
            }
#else
            var db_pay_product = DBManager.Instance.GetDB<DBPayProduct>();
            DBPayProduct.PayDroductInfo product_info = db_pay_product.getProductInfo(pay_info.RmbLow);

            var pay_request_info = new Dictionary<string, string>();
            pay_request_info.Add("productID", product_info.ProductId);
            pay_request_info.Add("productName", product_info.ProductName);
            pay_request_info.Add("productDesc", product_info.ProductDesc);
#endif


            pay_request_info.Add("passport", GlobalConfig.Instance.LoginInfo.AccName);
            pay_request_info.Add("serverID", server_id.ToString());
            pay_request_info.Add("roleId", GlobalConfig.Instance.LoginInfo.RId.ToString());
            pay_request_info.Add("price", pay_info.RmbLow.ToString());
            if (Const.Region == RegionType.HKTW || Const.Region == RegionType.SEASIA)
                pay_request_info.Add("currency", GameConstHelper.GetString("GAME_PAYMENT_CURRENCY_USD"));
            else if (Const.Region == RegionType.KOREA)
                pay_request_info.Add("currency", GameConstHelper.GetString("GAME_PAYMENT_CURRENCY_KR"));
            else
                pay_request_info.Add("currency", GameConstHelper.GetString("GAME_PAYMENT_CURRENCY"));
            pay_request_info.Add("serverName", server_name);
            pay_request_info.Add("roleName", GlobalConfig.Instance.LoginInfo.Name);
            pay_request_info.Add("roleLevel", GlobalConfig.Instance.LoginInfo.Level.ToString());
            pay_request_info.Add("vip", VipHelper.GetVipValidLevel().ToString());//角色VIP等级
            pay_request_info.Add("coinNum", LocalPlayerManager.Instance.GetMoneyByConst(GameConst.MONEY_DIAMOND).ToString());//当前玩家身上拥有的金锭数量
            if (DBOSManager.getOSBridge().getAppID() == 529) // 卓梦
                pay_request_info.Add("currencyNum", LocalPlayerManager.Instance.GetMoneyByConst(GameConst.MONEY_DIAMOND).ToString());//当前玩家身上拥有的金锭数量

#if UNITY_IPHONE
            pay_request_info.Add ("gameMark", GlobalConfig.Instance.GameMark);//角色VIP等级
#endif


            //使用sdk接口发送充值请求
            string pay_requeset_str = MiniJSON.JsonEncode(new Hashtable(pay_request_info));
            DBOSManager.getDBOSManager().getBridge().pay(pay_requeset_str);
            Debug.Log(string.Format("OnClickPayButton pay_rmb: {0}", pay_info.RmbLow));
        }

        uint mBuyTime = 0;
        uint mGotTime = 0;

        /// <summary>
        /// 获取宝箱限购的状态
        /// </summary>
        /// <returns></returns>
        public uint GetLimitState()
        {
            //可购买0，可领取1，已领取2
            System.DateTime cur_date_time = Game.Instance.GetServerDateTime();

            //test
            //cur_date_time = DateHelper.GetDateTime(DebugCommand.serverTime);

            long cur_time_stamp = DateHelper.GetTimestamp(cur_date_time);

            System.DateTime buy_date_time = DateHelper.GetDateTime((int)mBuyTime);
            long buy_time_stamp = DateHelper.GetTimestamp(new System.DateTime(buy_date_time.Year, buy_date_time.Month, buy_date_time.Day, 0, 0, 0));

            System.DateTime got_date_time = DateHelper.GetDateTime((int)mGotTime);
            long got_time_stamp = DateHelper.GetTimestamp(new System.DateTime(got_date_time.Year, got_date_time.Month, got_date_time.Day, 0, 0, 0));

            if (cur_time_stamp - buy_time_stamp > GameConstHelper.GetUint("GAME_BIND_GOLD_BOX_DAYS") * 24 * 60 * 60)
            {
                //当前时间比上次购买的时间超过 7 天 为可以购买
                return 0;
            }
            else
            {
                if (cur_time_stamp - got_time_stamp > 24 * 60 * 60)
                {
                    //当前时间比上次领取的时间超过 1 天 为可以可领取
                    return 1;
                }
                else
                {
                    //当前时间比上次领取的时间小于 1 天 为已领取
                    return 2;
                }
            }

        }

        /// <summary>
        /// 获取限购剩余的天数
        /// </summary>
        /// <returns></returns>
        public long GetLimiteLastDay()
        {
            long day = 0;

            System.DateTime cur_date_time = Game.Instance.GetServerDateTime();

            //test
            //cur_date_time = DateHelper.GetDateTime(DebugCommand.serverTime);

            long cur_time_stamp = DateHelper.GetTimestamp(cur_date_time);

            System.DateTime buy_date_time = DateHelper.GetDateTime((int)mBuyTime);
            long buy_time_stamp = DateHelper.GetTimestamp(new System.DateTime(buy_date_time.Year, buy_date_time.Month, buy_date_time.Day, 0, 0, 0));
            long close_time_stamp = buy_time_stamp + GameConstHelper.GetUint("GAME_BIND_GOLD_BOX_DAYS") * 24 * 60 * 60;

            //结束时间距离当前时间 / (24 * 60 * 60)
            day = (close_time_stamp - cur_time_stamp) / (24 * 60 * 60);
            return day;
        }

        /// <summary>
        /// 获取剩余次数
        /// </summary>
        /// <returns></returns>
        public long GetLimitedLeftTime()
        {
            long left_time = 0;
            left_time += GetLimiteLastDay();
            uint state = GetLimitState();
            if (state == 1)
                left_time++;
            return left_time;
        }



        //获取今天剩余的时间
        public long GetTodayFreshTime()
        {
            System.DateTime cur_date_time = Game.Instance.GetServerDateTime();

            //test
            //cur_date_time = DateHelper.GetDateTime(DebugCommand.serverTime);

            long cur_time = cur_date_time.Hour * 60 * 60 + cur_date_time.Minute * 60 + cur_date_time.Second;
            long left_time = 24 * 60 * 60 - cur_time + 1;
            return left_time;
        }


        //是否点开过界面
        bool isHaveOpen = false;
        public void SetOpenState()
        {
            isHaveOpen = true;
            FireRedPoint();
        }


        //获取红点状态
        public bool GetRedPointState()
        {
            if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_CHARGE) == false)
                return false;

            //uint state = GetLimitState();
            ////可买且第一次打开界面
            //if (isHaveOpen == false && state == 0)
            //    return true;

            ////可领取显示红点
            //if (state == 1)
            //    return true;

            //已经不需要红点
            return false;
        }



        //触发红点变化
        private void FireRedPoint()
        {
            if(GetRedPointState())
                ClientEventMgr.Instance.FireEvent((int)xc.ClientEvent.CE_NEW_REDPOINT_SHOW, new CEventBaseArgs("13211"));
            else
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NEW_REDPOINT_DISAPPEAR, new CEventBaseArgs("13211"));
        }


        //数据初始化
        private void SysConfigInit(CEventBaseArgs args)
        {
            FireRedPoint();
        }


        void ProcessServerData(ushort protocol, byte[] data)
        {
            switch(protocol)
            {
                case (ushort)NetMsg.MSG_PLAYER_PAYMENT_BOUGHT:
                    {
                        var payment_bought = S2CPackBase.DeserializePack<S2CPlayerPaymentBought>(data);

                        mBoughtTimes.Clear();
                        foreach (var bought in payment_bought.all_bought)
                        {
                            mBoughtTimes[bought.k] = bought.v;
                        }

                        mLimitTimes.Clear();
                        foreach(var limit in payment_bought.limit_bought)
                        {
                            mLimitTimes[limit.k] = limit.v;
                        }

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CHARGEINFO_UPDATE, null);
                    }
                    break;
                case (ushort)NetMsg.MSG_BIND_GOLD_BOX_INFO:
                    var info = S2CPackBase.DeserializePack<S2CBindGoldBoxInfo>(data);
                    mBuyTime = info.buy_time;
                    mGotTime = info.got_time;
                    FireRedPoint();
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CHARGEINFO_UPDATE, null);
                    break;
            }
        }
    }
}
