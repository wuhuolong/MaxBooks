/*----------------------------------------------------------------
// 文件名： ServerListHelper.cs
// 文件功能描述： 服务器列表逻辑
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    public enum EServerState
    {
        WillOpen = 0,       // 即将开启
        Smooth = 1,         // 顺畅
        Full = 2,           // 爆满
        RoleIsFull = 3,     // 角色数量达到上限
        NotRecomm = 4,      // 不推荐
        Maintaining = 10,   // 维护中
    }

    public enum EServerType
    {
        Normal = 0,             // 普通
        Recommend = 1,          // 推荐
        New = 2,                // new
        RecommendAndNew = 3,    // 推荐+new
        LoginRecommend = 4,     // 登录推荐
    }

    public class ServerRoleInfo
    {
        public int ServerId;    // 服务器ID
        public int Level;       // 等级
        public uint RoleId;     // 角色id
        public int IconId;      // 职业
        public string Name;     // 呢称
        public uint TransferLv; // 转职等级
    }

    public class RegionInfo
    {
        public int Id;      // 大区ID
        public string Name; // 大区名称
    }

    public class ServerInfo
    {
        public int SId;         // 游戏服务器的ID
        public int ServerId;    // 控制服服务器的序号ID，
        public string Time = "";     // 开区时间
        public int ServerOrder; // 服务器排序
        public string Desc = "";     // 描述
        public string Name = "";     // 名称
        public int RegionId;    // 大区ID
        public EServerState State;// 服务器状态 0 将于XX开启； 1 顺畅；2 爆满 10 维护中，于XX开启
        public EServerType Type;  // 服务器类型 0 普通 1 推荐 2 new 3 推荐+new
        public string Url = "";      // 服务器地址
        public List<ServerRoleInfo> RoleList; // 角色信息数组
        public int CountDownTime;   // 开服倒计时
    };

    [wxb.Hotfix]
    public class ServerListHelper : xc.Singleton<ServerListHelper>
	{
        public delegate void GetServerDataFinishedDelegate(List<RegionInfo> regionList, List<ServerInfo> serverList, int lastLoginServerId);
        public delegate void GetLastLoginServerInfoFinishedDelegate(ServerInfo serverInfo);
        public delegate void GetAllRegionFinishedDelegate(List<RegionInfo> regionList);
        public delegate void GetLatelyLoginServerListFinishedDelegate(List<ServerInfo> serverList);
        public delegate void GetAllRecommServerFinishedDelegate(List<ServerInfo> recomServerList, List<ServerInfo> willOpenServerList, List<ServerInfo> loginServerList);
        public delegate void GetServerListFinishedDelegate(List<ServerInfo> serverList);
        public delegate void GetServerStateFinishedDelegate(ServerInfo serverInfo, bool canEnter);

        GetServerDataFinishedDelegate mGetServerDataFinishedCallback;
        GetLastLoginServerInfoFinishedDelegate mGetLastLoginServerInfoFinishedCallback;
        GetAllRegionFinishedDelegate mGetAllRegionFinishedCallback;
        GetLatelyLoginServerListFinishedDelegate mGetLatelyLoginServerListFinishedCallback;
        GetAllRecommServerFinishedDelegate mGetAllRecommServerFinishedCallback;
        GetServerListFinishedDelegate mGetServerListFinishedCallback;
        GetServerStateFinishedDelegate mGetServerStateFinishedCallback;

        bool mEnterWhenGetServerStateFinished = false;

        public ServerListHelper()
        {
        }

        /// <summary>
        /// 根据server id在服务器列表中获取指定的服务器信息
        /// </summary>
        public static ServerInfo GetServerInfoByServerId(List<ServerInfo> serverList, int serverId)
        {
            if (serverList != null)
            {
                foreach (ServerInfo serverInfo in serverList)
                {
                    if (serverInfo.ServerId == serverId)
                    {
                        return serverInfo;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 根据类型在服务器列表中获取指定的服务器信息
        /// </summary>
        public static ServerInfo GetServerInfoByType(List<ServerInfo> serverList, EServerType serverType)
        {
            if (serverList != null)
            {
                foreach (ServerInfo serverInfo in serverList)
                {
                    if (serverInfo.Type == serverType)
                    {
                        return serverInfo;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 在服务器列表中获取有角色的服务器列表
        /// </summary>
        public static List<ServerInfo> GetHaveRoleServerList(List<ServerInfo> serverList)
        {
            List<ServerInfo> haveRoleServerList = new List<ServerInfo>();
            haveRoleServerList.Clear();
            if (serverList != null)
            {
                foreach (ServerInfo serverInfo in serverList)
                {
                    if (serverInfo.RoleList != null && serverInfo.RoleList.Count > 0)
                    {
                        haveRoleServerList.Add(serverInfo);
                    }
                }
            }

            return haveRoleServerList;
        }

        public void ClearAllCallback()
        {
            mGetServerDataFinishedCallback = null;
            mGetLastLoginServerInfoFinishedCallback = null;
            mGetAllRegionFinishedCallback = null;
            mGetLatelyLoginServerListFinishedCallback = null;
            mGetAllRecommServerFinishedCallback = null;
            mGetServerListFinishedCallback = null;
            mGetServerStateFinishedCallback = null;
        }

        public bool CheckReply(string url, string error, System.Object replyObject)
        {
            if (string.IsNullOrEmpty(error) == false)
            {
                GameDebug.LogError("Control server error: " + error);
                xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("GET_SERVER_INFO_FAIL"));

                return false;
            }

            Hashtable hashtable = replyObject as Hashtable;
            if (hashtable != null)
            {
                System.Object resultObject = hashtable["result"];
                if (resultObject != null)
                {
                    int result = System.Convert.ToInt32(resultObject);
                    if (result == 1)
                    {
                        return true;
                    }
                    else if (result == 2)//result=2代表ticket过期
                    {
                        //登出游戏
                        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                        bridge.logout();
                        return false;
                    }
                }
            }

            return false;
        }

        public RegionInfo ParseRegionInfo(Hashtable hashtable)
        {
            if (hashtable == null || hashtable.Count == 0)
                return null;

            RegionInfo regionInfo = new RegionInfo();
            regionInfo.Id = System.Convert.ToInt32(hashtable["id"]);
            regionInfo.Name = System.Convert.ToString(hashtable["name"]);

            return regionInfo;
        }

        public List<RegionInfo> ParseRegionList(System.Object obj)
        {
            List<RegionInfo> regionList = new List<RegionInfo>();
            regionList.Clear();

            ArrayList arrayList = obj as ArrayList;
            if (arrayList != null)
            {
                foreach (System.Object o in arrayList)
                {
                    Hashtable hashtable = o as Hashtable;
                    if (hashtable != null)
                    {
                        RegionInfo regionInfo = ParseRegionInfo(hashtable);

                        if (regionInfo != null)
                        {
                            regionList.Add(regionInfo);
                        }
                    }
                }
            }

            return regionList;
        }

        public List<ServerRoleInfo> ParseRoleList(ArrayList arrayList)
        {
            List<ServerRoleInfo> roleList = new List<ServerRoleInfo>();
            roleList.Clear();

            if (arrayList != null)
            {
                foreach (System.Object obj in arrayList)
                {
                    Hashtable hashtable = obj as Hashtable;
                    if (hashtable != null)
                    {
                        ServerRoleInfo roleInfo = new ServerRoleInfo();

                        int.TryParse(hashtable["server_id"].ToString(), out roleInfo.ServerId);
                        int.TryParse(hashtable["level"].ToString(), out roleInfo.Level);
                        uint.TryParse(hashtable["role_id"].ToString(), out roleInfo.RoleId);
                        int.TryParse(hashtable["icon_id"].ToString(), out roleInfo.IconId);
                        roleInfo.Name = hashtable["role_name"].ToString();

                        Hashtable roleInfoHashtable =  hashtable["roleInfo"] as Hashtable;
                        if (roleInfoHashtable != null)
                        {
                            object transferLvObj = roleInfoHashtable["transfer_lv"];
                            if (transferLvObj != null)
                            {
                                uint.TryParse(transferLvObj.ToString(), out roleInfo.TransferLv);
                            }
                        }

                        //roleInfo.ServerId = System.Convert.ToInt32(hashtable["server_id"]);
                        //roleInfo.Level = System.Convert.ToInt32(hashtable["level"]);
                        //roleInfo.RoleId = System.Convert.ToUInt32(hashtable["role_id"]);
                        //roleInfo.IconId = System.Convert.ToInt32(hashtable["icon_id"]);
                        //roleInfo.Name = System.Convert.ToString(hashtable["role_name"]);

                        roleList.Add(roleInfo);
                    }
                }
            }

            return roleList;
        }

        public ServerInfo ParseServerInfo(Hashtable hashtable)
        {
            if (hashtable == null || hashtable.Count == 0)
                return null;

            ServerInfo serverInfo = new ServerInfo();
            serverInfo.SId = System.Convert.ToInt32(hashtable["sid"]);
            serverInfo.ServerId = System.Convert.ToInt32(hashtable["server_id"]);
            serverInfo.Time = System.Convert.ToString(hashtable["time"]);
            serverInfo.ServerOrder = System.Convert.ToInt32(hashtable["server_order"]);
            serverInfo.Desc = System.Convert.ToString(hashtable["desc"]);
            serverInfo.Name = System.Convert.ToString(hashtable["name"]);
            serverInfo.RegionId = System.Convert.ToInt32(hashtable["region_id"]);
            serverInfo.State = (EServerState)System.Convert.ToInt32(hashtable["state"]);
            serverInfo.Type = (EServerType)System.Convert.ToInt32(hashtable["type"]);
            serverInfo.Url = System.Convert.ToString(hashtable["url"]);

            ArrayList arrayList = hashtable["roles"] as ArrayList;
            serverInfo.RoleList = ParseRoleList(arrayList);

            serverInfo.CountDownTime = System.Convert.ToInt32(hashtable["count_down_time"]);

            return serverInfo;
        }

        public List<ServerInfo> ParseServerList(System.Object obj)
        {
            List<ServerInfo> serverList = new List<ServerInfo>();
            serverList.Clear();

            ArrayList arrayList = obj as ArrayList;
            if (arrayList != null)
            {
                foreach (System.Object o in arrayList)
                {
                    Hashtable hashtable = o as Hashtable;
                    if (hashtable != null)
                    {
                        ServerInfo serverInfo = ParseServerInfo(hashtable);

                        if (serverInfo != null)
                        {
                            serverList.Add(serverInfo);
                        }
                    }
                }
            }

            serverList.Sort(delegate (ServerInfo a, ServerInfo b)
            {
                if (a.ServerOrder < b.ServerOrder)
                    return 1;
                else if (a.ServerOrder > b.ServerOrder)
                    return -1;
                else
                    return 0;
            });
            return serverList;
        }

        public void OnGetServerDataFinished(string url, string error, string reply, System.Object userData)
        {
            System.Object replyObject = MiniJSON.JsonDecode(reply);
            if (CheckReply(url, error, replyObject) == false)
            {
                if (mGetServerDataFinishedCallback != null)
                {
                    mGetServerDataFinishedCallback(null, null, 0);
                }
                return;
            }

            List<RegionInfo> regionList = new List<RegionInfo>();
            regionList.Clear();
            List<ServerInfo> serverList = new List<ServerInfo>();
            serverList.Clear();
            int lastLoginServerId = 0;

            Hashtable hashtable = (replyObject as Hashtable)["args"] as Hashtable;
            if (hashtable != null)
            {
                System.Object obj = hashtable["region_list"];
                regionList = ParseRegionList(obj);

                obj = hashtable["server_list"];
                serverList = ParseServerList(obj);

                System.Object lastLoginObject = hashtable["last_login"];
                if (lastLoginObject != null)
                {
                    lastLoginServerId = System.Convert.ToInt32((lastLoginObject as Hashtable)["server_id"]);
                }
            }

            if (mGetServerDataFinishedCallback != null)
            {
                mGetServerDataFinishedCallback(regionList, serverList, lastLoginServerId);
            }
        }

        /// <summary>
        /// 获取服务器信息
        /// </summary>
        public void GetServerData(GetServerDataFinishedDelegate finishCallback)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = globalConfig.CSURLV + "GetServerData?account=" + loginInfo.AccName
                + "&show_marked=" + globalConfig.ServerType
                + "&game_mark=" + globalConfig.GameMark
                + "&imei=" + bridge.getPhoneIMEI()
                + "&device_mark=" + globalConfig.DeviceMark;

            MainGame.HttpRequest.GET(url, OnGetServerDataFinished, null);

            mGetServerDataFinishedCallback = finishCallback;
        }

        public void OnGetLastLoginServerInfoFinished(string url, string error, string reply, System.Object userData)
        {
#if UNITY_IPHONE
            reply = Utils.AES.Decode(reply, Const.CS_URL_KEY, Const.CS_URL_IV);
#endif
            System.Object replyObject = MiniJSON.JsonDecode(reply);
            if (CheckReply(url, error, replyObject) == false)
            {
                if (mGetLastLoginServerInfoFinishedCallback != null)
                {
                    mGetLastLoginServerInfoFinishedCallback(null);
                }
                return;
            }

            ServerInfo serverInfo = ParseServerInfo((replyObject as Hashtable)["args"] as Hashtable);

            if (mGetLastLoginServerInfoFinishedCallback != null)
            {
                mGetLastLoginServerInfoFinishedCallback(serverInfo);
            }
        }

        /// <summary>
        /// 获取账号最后登录服务器
        /// </summary>
        public void GetLastLoginServerInfo(GetLastLoginServerInfoFinishedDelegate finishCallback)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;

#if UNITY_IPHONE
            string url = globalConfig.CSURLVEX + "GetLastLoginServerInfo?show_marked=" + globalConfig.ServerType
             + "&account=" + loginInfo.AccName
             + "&game_mark=" + GlobalConfig.Instance.GameMark
             + "&device_mark=" + globalConfig.DeviceMark
             + "&ticket=" + WWW.EscapeURL(loginInfo.Ticket);
#else
            string url = globalConfig.CSURLV + "GetLastLoginServerInfo?show_marked=" + globalConfig.ServerType
                         + "&account=" + loginInfo.AccName
                         + "&game_mark=" + GlobalConfig.Instance.GameMark
                         + "&device_mark=" + globalConfig.DeviceMark
                         + "&ticket=" + WWW.EscapeURL(loginInfo.Ticket);
#endif

            MainGame.HttpRequest.GET(url, OnGetLastLoginServerInfoFinished, null);

            mGetLastLoginServerInfoFinishedCallback = finishCallback;
        }

        public void OnGetAllRegionFinished(string url, string error, string reply, System.Object userData)
        {
            System.Object replyObject = MiniJSON.JsonDecode(reply);
            if (CheckReply(url, error, replyObject) == false)
            {
                if (mGetAllRegionFinishedCallback != null)
                {
                    mGetAllRegionFinishedCallback(null);
                }
                return;
            }

            List<RegionInfo> regionList = ParseRegionList((replyObject as Hashtable)["args"]);

            if (mGetAllRegionFinishedCallback != null)
            {
                mGetAllRegionFinishedCallback(regionList);
            }
        }

        /// <summary>
        /// 获取全部大区列表
        /// </summary>
        public void GetAllRegion(GetAllRegionFinishedDelegate finishCallback)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = globalConfig.CSURLV + "GetAllRegion?show_marked=" + globalConfig.ServerType
                + "&account=" + loginInfo.AccName
                + "&game_mark=" + GlobalConfig.Instance.GameMark
                + "&device_mark=" + globalConfig.DeviceMark
                + "&ticket=" + WWW.EscapeURL(loginInfo.Ticket);

            MainGame.HttpRequest.GET(url, OnGetAllRegionFinished, null);

            mGetAllRegionFinishedCallback = finishCallback;
        }

        public void OnGetLatelyLoginServerInfoFinished(string url, string error, string reply, System.Object userData)
        {
            System.Object replyObject = MiniJSON.JsonDecode(reply);
            if (CheckReply(url, error, replyObject) == false)
            {
                if (mGetLatelyLoginServerListFinishedCallback != null)
                {
                    mGetLatelyLoginServerListFinishedCallback(null);
                }
                return;
            }

            List<ServerInfo> serverList = ParseServerList((replyObject as Hashtable)["args"]);

            if (mGetLatelyLoginServerListFinishedCallback != null)
            {
                mGetLatelyLoginServerListFinishedCallback(serverList);
            }
        }

        /// <summary>
        /// 获取最近登录服务器列表
        /// </summary>
        public void GetLatelyLoginServerInfo(GetLatelyLoginServerListFinishedDelegate finishCallback)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = globalConfig.CSURLV + "GetLatelyLoginServerInfo?show_marked=" + globalConfig.ServerType
                + "&game_mark=" + GlobalConfig.Instance.GameMark
                + "&account=" + globalConfig.LoginInfo.AccName
                + "&device_mark=" + globalConfig.DeviceMark;

            MainGame.HttpRequest.GET(url, OnGetLatelyLoginServerInfoFinished, null);

            mGetLatelyLoginServerListFinishedCallback = finishCallback;
        }

        public void OnGetAllRecommServerFinished(string url, string error, string reply, System.Object userData)
        {
            System.Object replyObject = MiniJSON.JsonDecode(reply);
            if (CheckReply(url, error, replyObject) == false)
            {
                if (mGetAllRecommServerFinishedCallback != null)
                {
                    mGetAllRecommServerFinishedCallback(null, null, null);
                }
                return;
            }

            List<ServerInfo> recommsServerList = new List<ServerInfo>();
            recommsServerList.Clear();
            List<ServerInfo> willOpenServerList = new List<ServerInfo>();
            willOpenServerList.Clear();
            List<ServerInfo> loginServerList = new List<ServerInfo>();
            loginServerList.Clear();

            Hashtable hashtable = (replyObject as Hashtable)["args"] as Hashtable;
            if (hashtable != null)
            {
                System.Object obj = hashtable["recomms"];
                recommsServerList = ParseServerList(obj);

                obj = hashtable["toOpen"];
                willOpenServerList = ParseServerList(obj);

                obj = hashtable["logins"];
                loginServerList = ParseServerList(obj);
            }

            if (mGetAllRecommServerFinishedCallback != null)
            {
                mGetAllRecommServerFinishedCallback(recommsServerList, willOpenServerList, loginServerList);
            }
        }

        /// <summary>
        /// 获取推荐服务器列表
        /// </summary>
        public void GetAllRecommServer(GetAllRecommServerFinishedDelegate finishCallback)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = globalConfig.CSURLV + "GetAllRecommServer?account=" + globalConfig.LoginInfo.AccName
                         + "&show_marked=" + globalConfig.ServerType
                         + "&game_mark=" + GlobalConfig.Instance.GameMark
                         + "&imei=" + bridge.getPhoneIMEI()
                         + "&device_mark=" + globalConfig.DeviceMark;

            if(Const.Region == RegionType.SEASIA)
                url += "&lang=" + Const.LanguageName();

            MainGame.HttpRequest.GET(url, OnGetAllRecommServerFinished, null);

            mGetAllRecommServerFinishedCallback = finishCallback;
        }

        public void OnGetServerListFinished(string url, string error, string reply, System.Object userData)
        {
            System.Object replyObject = MiniJSON.JsonDecode(reply);
            if (string.IsNullOrEmpty(error) == false)
            {
                GameDebug.LogError("Control server error: " + error);
                xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("GET_SERVER_INFO_FAIL"));

                if (mGetServerListFinishedCallback != null)
                {
                    mGetServerListFinishedCallback(null);
                }

                return;
            }

            List<ServerInfo> serverList = ParseServerList((replyObject as Hashtable)["args"]);

            if (mGetServerListFinishedCallback != null)
            {
                mGetServerListFinishedCallback(serverList);
            }
        }

        /// <summary>
        /// 获取服务器列表
        /// </summary>
        /// <param name="region_id">Section identifier.</param>
        /// <param name="finishedCallback">Finished callback.</param>
        public void GetServerList(int region_id, GetServerListFinishedDelegate finishedCallback)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            string url = globalConfig.CSURLV + "GetServerList?show_marked=" + globalConfig.ServerType 
                + "&region_id=" + region_id
                + "&game_mark=" + globalConfig.GameMark
                + "&account=" + globalConfig.LoginInfo.AccName
                + "&device_mark=" + globalConfig.DeviceMark;

            MainGame.HttpRequest.GET(url, OnGetServerListFinished, null);

            mGetServerListFinishedCallback = finishedCallback;
        }

        public bool CheckServerState(ServerInfo serverInfo, bool isShowTips = true)
        {
            bool canEnter = true;
            if (serverInfo.State == EServerState.WillOpen)
            {
                canEnter = false;
                if (isShowTips == true)
                {
                    UINotice.Instance.ShowMessage(serverInfo.Desc);
                }
            }
            else if (serverInfo.State == EServerState.RoleIsFull)
            {
                canEnter = false;
                if (isShowTips == true)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("SERVER_CAN_NOT_LOGIN_TIPS"));
                }
            }
            else if (serverInfo.State == EServerState.Maintaining)
            {
                canEnter = false;
                if (isShowTips == true)
                {
                    UINotice.Instance.ShowMessage(serverInfo.Desc);
                }
            }

            return canEnter;
        }

        public void OnGetServerStateFinished(string url, string error, string reply, System.Object userData)
        {
#if UNITY_IPHONE
            reply = Utils.AES.Decode(reply, Const.CS_URL_KEY, Const.CS_URL_IV);
#endif
            System.Object replyObject = MiniJSON.JsonDecode(reply);
            if (CheckReply(url, error, replyObject) == false)
            {
                if (mGetServerStateFinishedCallback != null)
                {
                    mGetServerStateFinishedCallback(null, false);
                }
                return;
            }

            ServerInfo serverInfo = userData as ServerInfo;
            if (serverInfo == null)
            {
                GameDebug.LogError("Error in OnGetServerStateFinished, serverInfo is null!!!");
                return;
            }

            Hashtable hashtable = (replyObject as Hashtable)["args"] as Hashtable;
            if (hashtable != null)
            {
                serverInfo.State = (EServerState)DBTextResource.ParseI(hashtable["status"].ToString());
            }
            bool canEnter = CheckServerState(serverInfo);

            // 如果是不推荐进入的服务器，则读取recomm属性选中推荐的服务器
            if (serverInfo.State == EServerState.NotRecomm)
            {
                if (hashtable != null)
                {
                    Hashtable recommHashtable = hashtable["recomm"] as Hashtable;
                    if (recommHashtable != null)
                    {
                        ServerInfo recommServerInfo = ParseServerInfo(recommHashtable);
                        if (recommServerInfo != null)
                        {
                            xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(DBConstText.GetText("SERVER_NOT_RECOMM_TIPS"), (x) =>
                            {
                                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SELECT_SERVER, new CEventBaseArgs(recommServerInfo));
                            });
                            canEnter = false;
                        }
                    }
                }
            }

            if (mGetServerStateFinishedCallback != null)
            {
                mGetServerStateFinishedCallback(serverInfo, canEnter);
            }

            if (canEnter == false || mEnterWhenGetServerStateFinished == false)
            {
                return;
            }

            GlobalConfig.GetInstance().LoginInfo.ServerInfo = serverInfo;

            string[] ips = serverInfo.Url.Split(':');
            Game game = Game.GetInstance();
            game.ServerIP = ips[0];
            game.ServerPort = DBTextResource.ParseI(ips[1]);
            game.ServerID = (uint)serverInfo.SId;

            ControlServerLogHelper.GetInstance().PostAccountLoginLogS(serverInfo.ServerId, serverInfo.State);

            game.GameMode = (Game.EGameMode)((int)game.GameMode | (int)xc.Game.EGameMode.GM_Net);
            game.Login();
        }

        /// <summary>
        /// 获取指定服务器的状态，如果可以进入则直接进入
        /// </summary>
        public void CheckServerStateAndEnter(ServerInfo serverInfo, GetServerStateFinishedDelegate getServerStateFinishedCallback = null, bool enter = true)
        {
            if (serverInfo == null)
            {
                return;
            }

            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;

#if UNITY_IPHONE
            string sign = string.Format("server_id={0}&game_mark={1}&device_mark={2}&show_marked={3}&account={4}", 
                serverInfo.ServerId, GlobalConfig.Instance.GameMark, globalConfig.DeviceMark, globalConfig.ServerType, loginInfo.AccName);
            Debug.Log(string.Format("controlServer_oriSign_SrvSt2 = {0}", sign));
            sign = WWW.EscapeURL(Utils.AES.Encode(sign, Const.CS_URL_KEY, Const.CS_URL_IV));

            var url = string.Format("{0}SrvSt2?sign={1}", GlobalConfig.Instance.CSURLVEX, sign);
#else
            string url = globalConfig.CSURLV + "GetServerState?server_id=" + serverInfo.ServerId
            + "&game_mark=" + GlobalConfig.Instance.GameMark
            + "&device_mark=" + globalConfig.DeviceMark
            + "&show_marked=" + globalConfig.ServerType
            + "&account=" + loginInfo.AccName;
#endif

            MainGame.HttpRequest.GET(url, OnGetServerStateFinished, serverInfo);

            mGetServerStateFinishedCallback = getServerStateFinishedCallback;

            mEnterWhenGetServerStateFinished = enter;
        }
    }
}
