using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using xc;
using Net;
namespace xc
{
    public class FriendShipInfo
    {
        public string Name = string.Empty;
        public string BuffDes = string.Empty;
        public uint Min = 0;
        public uint Max = 0;
        public string ShipSprName = string.Empty;
        public string Display = string.Empty;
        public bool isHave = false;
    }

    [wxb.Hotfix]
    public class FriendsHelper
    {
        public static  FriendShipInfo GetFriendShipInfo(uint friendShip)
        {
            List<Dictionary<string, string>> data_friend_close = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_friend_close");
            FriendShipInfo firendShip = new FriendShipInfo();
            foreach(var info in data_friend_close)
            {
                uint min = DBTextResource.ParseUI(info["low"]);
                uint max = DBTextResource.ParseUI(info["high"]);
             
                if(friendShip >= min && friendShip <= max)
                {
                    firendShip.Display = info["value_dis"];
                    firendShip.Min = min;
                    firendShip.Max = max;
                    firendShip.Name = info["name"];
                    firendShip.BuffDes = info["des"];
                    firendShip.ShipSprName = info["icon"];
                    firendShip.isHave = true;
                    break;
                }
            }

            return firendShip;
        }

        public static  List<FriendShipInfo> GetFriendShipInfoList(uint friendShip)
        {
            List<Dictionary<string, string>> data_friend_close = DBManager.Instance.QuerySqliteTable<string>(GlobalConfig.DBFile, "data_friend_close");
            List<FriendShipInfo> FirendShips = new List<FriendShipInfo>();
            foreach(var info in data_friend_close)
            {
                FriendShipInfo firendShip = new FriendShipInfo();
                uint min = DBTextResource.ParseUI(info["low"]);
                uint max = DBTextResource.ParseUI(info["high"]);
                firendShip.Min = min;
                firendShip.Max = max;
                if(friendShip >= min && friendShip <= max)
                    firendShip.isHave = true;
                else
                    firendShip.isHave = false;
                firendShip.Name = info["name"];
                firendShip.BuffDes = info["des"];
                firendShip.ShipSprName = info["icon"];
                firendShip.Display = info["value_dis"];
                FirendShips.Add(firendShip);
            }
            return FirendShips;
        }
    }
}
