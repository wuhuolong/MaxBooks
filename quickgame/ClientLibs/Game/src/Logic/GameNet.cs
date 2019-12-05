using Net;
using xc.protocol;
using xc.ui;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
//using XLua;
namespace xc
{
    //[LuaExport(LuaExportOption.SELECTED)]
    //[LuaCallCSharp]
    [wxb.Hotfix]
    public partial class Game : NetClient.IListener
    {
        /// <summary>
        /// 网络主连接是否已经连接上了
        /// </summary>
        public bool Connected
        {
            get
            {
                return mConnected;
            }
        }
        private bool mConnected = false;

        /// <summary>
        /// 是否已经进入了游戏
        /// </summary>
        public bool IsEnterGame = false;

        private Utils.Timer mServerTimeTimer;

        /// <summary>
        /// 更新客户端时间的计时器
        /// </summary>
        protected System.Diagnostics.Stopwatch mUpdateServerTimeStopwatch;

        /// <summary>
        /// 收到服务器的Ping消息时，服务器的时间戳
        /// </summary>
        protected ulong mServerLastUpdteTime;

        /// <summary>
        /// 当前最新的服务器的时间戳
        /// </summary>
        protected ulong mServerTime;

        private System.DateTime converted = new System.DateTime(1970, 1, 1, 8, 0, 0, 0);
        public System.DateTime Converted
        {
            get
            {
                return converted;
            }
        }

        /// <summary>
        /// 开服时间戳
        /// </summary>
        protected uint mServerOpenTime = 0;
        public uint ServerOpenTime { get { return mServerOpenTime; } }
        public System.DateTime ServerOpenDateTime
        {
            get
            {
                if (mServerOpenTime == 0)
                {
                    return System.DateTime.Now;
                }
                else
                {
                    System.DateTime newDate = converted.AddSeconds(mServerOpenTime);

                    return newDate;
                }
            }
        }

        /// <summary>
        /// 时区
        /// </summary>
        protected int mTimeZone = 0;
        public int TimeZone { get { return mTimeZone; } }

        public int TimeZoneHour()
        {
            return (int)Mathf.Floor(mTimeZone / 100); 
        }
        public int TimeZoneMin()
        {
            return (int)mTimeZone % 100; 
        }

        /// <summary>
        /// 获取开服时间天数
        /// 服务器时间戳-开服时间戳
        /// 第一天0开始计算
        /// </summary>
        /// <returns></returns>
        public int GetOpenDay()
        {

            Debug.Log(mServerTime);
            Debug.Log(mServerOpenTime);

            ulong diff = (mServerTime / 1000) - (ulong)mServerOpenTime;

            ulong day = diff / (60 * 60 * 24);

            return (int)day;
        }

        /// <summary>
        /// 合服时间戳
        /// </summary>
        protected uint mMergeServerTime = 0;
        public uint MergeServerTime { get { return mMergeServerTime; } }
        public System.DateTime MergeServerDateTime
        {
            get
            {
                System.DateTime newDate = converted.AddSeconds(mMergeServerTime);
                return newDate;
            }
        }


        // 查询排队人数的时间
        Utils.Timer mCheckQueueTime;

        bool mAllSystemInited = false;

        /// <summary>
        /// 所有的系统是否初始化完毕
        /// </summary>
        public bool AllSystemInited
        {
            get
            {
                return mAllSystemInited;
            }
        }

        protected PackRecorder mPackRecorder = new PackRecorder();
        public PackRecorder PackRecorder
        {
            get {
                return mPackRecorder;
            }
        }

        public void OnNetConnect(NetType netType)
        {
            Debug.Log("Connect server successed!");

            // 设置连接状态
            mConnected = true;
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NET_MAIN_CONNECTED, null);

            if (ChangeRoleManager.Instance.IsChangeRole)// 更换角色发送C2SAccRoleChangeLogin协议
            {
                var acc_role_change_login = new C2SAccRoleChangeLogin();
                acc_role_change_login.token = GlobalConfig.Instance.Token;
                acc_role_change_login.uuid = ChangeRoleManager.Instance.PreUuid;
                NetClient.GetBaseClient().SendData<C2SAccRoleChangeLogin>(NetMsg.MSG_ACC_ROLE_CHANGE_LOGIN, acc_role_change_login);
                return;
            }

            if (NetReconnect.Instance.IsReconnect)// 在断线重连状态下，不需要发送C2SEasyLogin协议
            {
                var session_login = new C2SAccSessionLogin();
                session_login.token = GlobalConfig.Instance.Token;
                session_login.uuid = Game.Instance.LocalPlayerID.obj_idx;
                NetClient.GetBaseClient().SendData<C2SAccSessionLogin>(NetMsg.MSG_ACC_SESSION_LOGIN, session_login);
                return;
            }

            // 游戏帐号为空则直接返回
            if (string.IsNullOrEmpty(Game.GetInstance().Account))
            {
                GameDebug.LogError("Game account is null");
                return;
            }

            IBridge bridge = DBOSManager.getDBOSManager().getBridge();

            // 发送C2SEasyLogin协议
            C2SEasyLogin easy_login = new C2SEasyLogin();
            easy_login.username = System.Text.Encoding.UTF8.GetBytes(Game.GetInstance().Account);
            if (string.IsNullOrEmpty(GlobalConfig.GetInstance().LoginInfo.Ticket))
            {
                easy_login.password = System.Text.Encoding.UTF8.GetBytes("ticket");
            }
            else
            {
                easy_login.password = System.Text.Encoding.UTF8.GetBytes(GlobalConfig.GetInstance().LoginInfo.Ticket);
            }
            easy_login.channel = System.Text.Encoding.UTF8.GetBytes(GlobalConfig.GetInstance().SDKName);
            easy_login.server_id = (uint)GlobalConfig.GetInstance().LoginInfo.ServerInfo.SId;
            easy_login.sub_channel = System.Text.Encoding.UTF8.GetBytes(GlobalConfig.GetInstance().SubChannel);
            easy_login.sdk_user_id = System.Text.Encoding.UTF8.GetBytes(DBOSManager.getOSBridge().getSdkUserID());
            easy_login.roll_sever = GlobalConfig.GetInstance().LoginInfo.RollServer;
            easy_login.ext_channel = System.Text.Encoding.UTF8.GetBytes(bridge.getExtChannel());
            easy_login.main_channel = System.Text.Encoding.UTF8.GetBytes(bridge.getCurrChannel());
            NetClient.GetBaseClient().SendData<C2SEasyLogin>(NetMsg.MSG_EASY_LOGIN, easy_login);

#if !UNITY_IPHONE
            // 选择服务器的时候通知sdk
            SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.SELECT_SERVER);
#endif
        }

        bool mQueueMax = false;

        /// <summary>
        /// /服务器人数达到上限
        /// </summary>
        public bool QueueMax
        {
            get{ return mQueueMax; }
        }

        bool mLoginConflict = false;

        /// <summary>
        /// 是否帐号在其他设备上登录
        /// </summary>
        public bool LoginConflict
        {
            get{ return mLoginConflict; }
        }

        bool mMaintainServer = false;
        string mMaintainServerNotice = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_31");

        /// <summary>
        /// 是否因为维护服务器而断网
        /// </summary>
        public bool MaintainServer
        {
            get { return mMaintainServer; }
        }

        /// <summary>
        /// 是否因为帐号在其他设备上登录等情况下强制断网
        /// </summary>
        public bool ForceDisconnect
        {
            get
            {
                return mLoginConflict || mQueueMax || IsRebooting || mMaintainServer || ChangeRoleManager.Instance.IsChangeRole || !IsEnterGame;
            }
        }

        string mLoginConflictNotice = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_32");

        public void OnNetDisconnect(NetType netType, int e)
        {
            if (netType == NetType.NT_UDP)
                return;
            
            Debug.Log("Disconnect to server! Error:" + e.ToString());

            // 如果开启了跨服，关闭跨服Socket
            if (Net.NetClient.CrossToggle)
                CrossServerIntegration.GetInstance().Stop();
            
            // 关闭主Socket
            StopNetClient();

            string notice = "";
            if(mQueueMax) // 排队中
            {
                notice = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_33");
                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, notice, OnClickRetryBtn, null);
            }
            else if(mLoginConflict)
            {
                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, mLoginConflictNotice,
                    x =>
                    {
                        mLoginConflict = false;

                        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                        bridge.logout();
                    }, null, "UINotice2Window");
            }
            else if(mMaintainServer)// 维护服务器中
            {
                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, mMaintainServerNotice,
                    x =>
                    {
                        mMaintainServer = false;

                        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                        bridge.logout();
                    }, null, "UINotice2Window");
            }
            else if (!IsEnterGame)// 还未进入游戏
            {
                ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_34"),
                    x =>
                    {
                        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                        bridge.logout();
                    }, null, "UINotice2Window");
            }

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NET_MAIN_DISCONNECT, null);
        }

        public void OnNetDataReply(NetType netType, ushort protocol, byte[] data)
        {
            ProcessServerData(protocol, data);
        }

        public void ProcessServerData(ushort protocol, byte[] data)
        {
#if UNITY_EDITOR
            if (GlobalConfig.Instance.IsDebugMode)
                GameDebug.Log("S------>C: " + protocol);
#endif
#if UNITY_STANDALONE_WIN
            PackRecorder.RecordRecvPack(protocol, data);
#elif TEST_HOST && UNITY_ANDROID
            var pack_recorder = xc.Game.Instance.PackRecorder;
            if (!pack_recorder.NotRecordDict.ContainsKey(protocol)) {
                GameDebug.Log("S------>C: " + protocol);
            }
#endif
            //处理错误信息
            if (protocol == NetMsg.MSG_SYS_ERROR)
            {
                S2CSysError errReport = S2CPackBase.DeserializePack<S2CSysError>(data);
                
                xc.ui.ugui.UIManager.Instance.ShowWaitScreen(false);
                
                switch (errReport.err_code)
                {
                    case ErrorCode.ERR_QUEUE_MAX:// 服务器人数达到上限后，会马上断开网络
                        {
                            mQueueMax = true;
                        }
                        break;
                    case ErrorCode.ERR_ACCOUNT_LOGIN_AGAIN:// 顶号之后，会马上断开网络
                        {
                            mLoginConflict = true;
                            string notice = DBErrorCode.GetErrorString((uint)ErrorCode.ERR_ACCOUNT_LOGIN_AGAIN);
                            if (!string.IsNullOrEmpty(notice))
                            {
                                mLoginConflictNotice = notice;
                            }
                        }
                        break;
                    case ErrorCode.ERR_SERVER_MANTAIN:// 服务器维护
                        {
                            mMaintainServer = true;
                            string notice = DBErrorCode.GetErrorString((uint)ErrorCode.ERR_SERVER_MANTAIN);
                            if (!string.IsNullOrEmpty(notice))
                            {
                                mMaintainServerNotice = notice;
                            }
                        }
                        break;
                    default:
                    {
                        string content = ""; 

                        // 错误码为0时，直接使用服务端发送过来的错误信息
                        if(errReport.err_code == 0)
                        {
                            if (errReport.err_msg == null)
                            {
                                content = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_35") + errReport.err_code;
                            }
                            else
                            {
                                content = System.Text.Encoding.UTF8.GetString(errReport.err_msg);
                            }
                        }
                        else
                        {
                            DBErrorCode db = (DBErrorCode)DBManager.GetInstance().GetDB(typeof(DBErrorCode).Name);
                            DBErrorCode.ErrorInfo errorInfo = db.GetErrorInfo(errReport.err_code);
                            if (errorInfo == null) 
                                content = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_35") + errReport.err_code;
                            else
                                content = errorInfo.mDesc;
                        }

                        if (errReport.@params != null && errReport.@params.Count > 0)
                        {
                            int paramsCount = errReport.@params.Count;
                            if (paramsCount == 1)
                            {
                                content = string.Format(content, System.Text.Encoding.UTF8.GetString(errReport.@params[0]));
                            }
                            else if (paramsCount == 2)
                            {
                                content = string.Format(content, System.Text.Encoding.UTF8.GetString(errReport.@params[0]), System.Text.Encoding.UTF8.GetString(errReport.@params[1]));
                            }
                            else if (paramsCount == 3)
                            {
                                content = string.Format(content, System.Text.Encoding.UTF8.GetString(errReport.@params[0]), System.Text.Encoding.UTF8.GetString(errReport.@params[1]), System.Text.Encoding.UTF8.GetString(errReport.@params[2]));
                            }
                            else
                            {
                                GameDebug.LogError("MSG_SYS_ERROR 参数过多!!!");
                            }
                        }
                        
                        string log = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_36"), content);
                        UINotice.GetInstance().ShowMessage(content);
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SYS_ERROR, new CEventBaseArgs(errReport.err_code));
                        GameDebug.LogWarning(log);
                        break;
                    }
                }
                return;
            }
            //处理Debug信息
            else if (protocol == NetMsg.MSG_SYS_DEBUG)
            {
                S2CSysDebug msg = S2CPackBase.DeserializePack<S2CSysDebug>(data);
                
                xc.ui.ugui.UIManager.Instance.ShowWaitScreen(false);
                
                string content = System.Text.Encoding.UTF8.GetString(msg.err);
                string log = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_37"), content);
                //UINotice.GetInstance().ShowMessage(content);
                GameDebug.LogWarning(log);
            }
            // 登录验证失败
            else if (protocol == NetMsg.MSG_ACC_LOGIN_FAIL)
            {
                S2CAccLoginFail loginFail = S2CPackBase.DeserializePack<S2CAccLoginFail>(data);
                uint reason = loginFail.reason;
                if (reason != 1)
                {
                    UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK, xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_38"), OnClickSDKRelogin, null);
                }
                
                return;
            }

            bool process = false;
            List<DataReplyDelegate> funcs;
            if (mNetHandlers.TryGetValue(protocol, out funcs))
            {
                // Broacast the net notify.
                for (int i=0; i<funcs.Count; ++i)
                {
                    DataReplyDelegate func = funcs [i];
                    func(protocol, data);

                    // 这里不再catch异常，不然有报错不好找
                    //try
                    //{
                    //    func(protocol, data);
                    //}
                    //catch (System.Exception e)
                    //{
                    //    GameDebug.LogError("Protocol " + protocol + " error: " + e.Message);
                    //}
                }
                process = true;
            }

            if (mLuaNetHandlers != null)
            {
	            if (mLuaNetHandlers.TryGetValue(protocol, out funcs))
	            {
	                // Broacast the net notify.
	                for (int i = 0; i < funcs.Count; ++i)
	                {
	                    DataReplyDelegate func = funcs[i];
                        try
                        {
                            func(protocol, data);
                        }
                        catch (System.Exception e)
                        {
                            GameDebug.LogError("Protocol " + protocol + " error: " + e.Message);
                        }
                    }
                    process = true;
                }
            }

            if(process == false)
                GameDebug.Log("未处理的协议:" + protocol);
        }

        void ShowCreateActorWnd()
        {
            ui.ugui.UIManager uiMgr = ui.ugui.UIManager.GetInstance();
            uiMgr.ClearUI();

            string wndName = "";

            if (mRepCharacterList.Count != 0)
            {
                wndName = "UISelectActorWindow";
            }
            else
            {
                wndName = "UICreateActorWindow";
            }

            uiMgr.ShowWindow(wndName);
//          UIChooseServerWindow chooseServerWindow = ui.UIManager.GetInstance().GetWindowImm("UIChooseServerWindow") as UIChooseServerWindow;
//          if (chooseServerWindow != null)
//              chooseServerWindow.Hide();
//          UIWidgetHelp.GetInstance().HideNoticeDlg();
        }

        public void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_EASY_LOGIN:
                {
                    GameDebug.Log(">>>MSG_EASY_LOGIN");

                    ChangeRoleManager.Instance.IsChangeRole = false;
                    IsRebooting = false;

                    S2CEasyLogin eazyLogin = S2CPackBase.DeserializePack<S2CEasyLogin>(data);
                    mCharactorMaxCount = (int)eazyLogin.role_limit;
                    mAccountIdx = (int)eazyLogin.uid;
                        for (int index = 0; index < eazyLogin.role_brief.Count; ++index)
                        {
                            Equip.EquipHelper.DelEquipPart(eazyLogin.role_brief[index].shows, DBAvatarPart.BODY_PART.ELFIN);
                            Equip.EquipHelper.DelEquipPart(eazyLogin.role_brief[index].shows, DBAvatarPart.BODY_PART.MAGICAL_PET);
                        }
                    mRepCharacterList = eazyLogin.role_brief;

                    if (Const.Region == RegionType.KOREA)
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SERVERLIST_TO_CREATEACTOR_BEGIN, new CEventBaseArgs());

                    if (mRepCharacterList.Count != 0)
                    {
                        SceneHelp.Instance.SwitchPreposeScene(GlobalConst.SelectActorScene, false);// 选角场景
                    }
                    else
                    {
#if UNITY_ANDROID || UNITY_IPHONE
                        //Handheld.PlayFullScreenMovie("Movie/YuanGu2CG.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
#endif
                        SceneHelp.Instance.SwitchPreposeScene(GlobalConst.CreateActorScene, false);// 创角场景
                    }
                    GameDebug.Log("AccountIdx: " + mAccountIdx);

                    // 登录服务器成功
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.LoginServerSuccess);
                    ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.login_gs);

                    if (xc.Const.Region == xc.RegionType.KOREA)
                    {
                        xc.BuriedPointHelper.ReportTapjoyEvnet("server");
                    }

                    //UIManager.Instance.UIMain.StartCoroutine(ShowCreateActorWnd());
                    ShowCreateActorWnd();
                }
                break;
                case NetMsg.MSG_ACC_QUEUE: // 登录排队信息
                {
                    GameDebug.Log(">>>MSG_ACC_QUEUE");
                    
                    S2CAccQueue rep = S2CPackBase.DeserializePack<S2CAccQueue>(data);
                
                    GameDebug.Log("Queue Num: " + rep.total);
                
                    xc.ui.ugui.UIManager.Instance.ShowWaitScreen(false);
                    //UIManager.GetInstance().UIMain.ShowQueueNotice(true, string.Format("前方还有: {0}人", rep.total));
                    if(mCheckQueueTime == null)
                        mCheckQueueTime = new Utils.Timer(15000, true, 15000, OnQueueChecking);
                }
                break;
                case NetMsg.MSG_ACC_QUEUE_OK:// 排队成功
                {
                    GameDebug.Log(">>>MSG_ACC_QUEUE_OK");

                    //UIManager.GetInstance().UIMain.ShowQueueNotice(false, "");
                    CancelQueueTime();
                }
                break;
                case NetMsg.MSG_ENTER_GAME:
                    {
                        GameDebug.Log(">>>MSG_ENTER_GAME");

                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ENTER_GAME, null);

                        S2CEnterGame enter_game = S2CPackBase.DeserializePack<S2CEnterGame>(data);
                        mServerTime = enter_game.ts;
                        mServerLastUpdteTime = mServerTime;
                        GlobalConfig.GetInstance().LoginInfo.CreateRoleTime = enter_game.birth.ToString();

                        // 开启定时器
                        if (mUpdateServerTimeStopwatch == null)
                            mUpdateServerTimeStopwatch = new System.Diagnostics.Stopwatch();
                        else
                            mUpdateServerTimeStopwatch.Reset();
                        mUpdateServerTimeStopwatch.Start();

                        if (mServerTimeTimer != null)
                            mServerTimeTimer.Destroy();
                        mServerTimeTimer = new Utils.Timer(1000, true, Mathf.Infinity, UpdateServerTime);

                        // 设置角色属性
                        LocalPlayerManager.Instance.InitAttribute(Game.GetInstance().LocalPlayerTypeID, Game.Instance.LocalPlayerName);
                        OnEnterGame();

                        // 进入游戏的时候通知sdk
                        SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.ENTER_GAME);
                        // 设置bugly的userid
                        if (Game.GetInstance().LocalPlayerID != null)
                            DBOSManager.getDBOSManager().SetUserId(Game.GetInstance().LocalPlayerID.obj_idx.ToString());

                        IsEnterGame = true;
                    }
                    break;
                case NetMsg.MSG_ACC_PING:
                    {
                        S2CAccPing s2c_acc_ping = S2CPackBase.DeserializePack<S2CAccPing>(data);
                        mServerTime = s2c_acc_ping.time;
                        mServerLastUpdteTime = mServerTime;

                        // 重置定时器
                        if (mUpdateServerTimeStopwatch == null)
                            mUpdateServerTimeStopwatch = new System.Diagnostics.Stopwatch();
                        else
                            mUpdateServerTimeStopwatch.Reset();
                        mUpdateServerTimeStopwatch.Start();

                        // 发送ping消息给服务器
                        C2SAccPing c2s_ping = new C2SAccPing();
                        c2s_ping.time = mServerTime;
                        NetClient.GetBaseClient().SendData<C2SAccPing>(NetMsg.MSG_ACC_PING, c2s_ping);
                    }
                    break;
                case NetMsg.MSG_ACC_HOTUP: // 数据有更新，需要在游戏内提示玩家
                {
                    Debug.Log(">>>MSG_ACC_HOTUP");
                }
                break;
                case NetMsg.MSG_ACC_SYS_SETTING:
                {
                    /*var pack = S2CPackBase.DeserializePack<S2CAccSysSetting>(data);
                    foreach (var set in pack.sets)
                    {
                        QualitySetting.SetPlayerCount(set.key, set.val);
                    }*/
                }
                break;
                case NetMsg.MSG_PLAYER_REQUEST_ALL_INFO_END:
                    {
                        mAllSystemInited = true;
                        NetReconnect.Instance.ReconnectSucc();
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_ALL_SYSTEM_INITED, null);
                    }
                    break;
                case NetMsg.MSG_ACC_ROLE_CHANGE_FAIL:
                    {
                        ChangeRoleManager.Instance.IsChangeRole = false;
                        m_GameMachine.React((uint)GameEvent.GE_CHANGE_ROLE_FINISH);

                        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                        bridge.logout();
                    }
                    break;
                case NetMsg.MSG_PLAYER_OPEN_TIME:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CPlayerOpenTime>(data);

                        mServerOpenTime = pack.time;
                        mMergeServerTime = pack.merge_time;
                        mTimeZone = pack.time_zone;
                        var timeZoneHour = TimeZoneHour();
                        var timeZoneMin = TimeZoneMin();
                        converted = new System.DateTime(1970, 1, 1, timeZoneHour, timeZoneMin, 0, 0);
                    }
                    break;
                case NetMsg.MSG_PLAYER_DAILY_RESET:
                    {
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_PLAYER_DAILY_RESET, null);
                    }
                    break;
                default:
                break;
            }
        }

        public void Login()
        {
            Login(ServerIP, ServerPort);
        }
        
        public void Login(string ip, int port)
        {
            // 切换服务器时，需要断开连接再重连
            StopNetClient();

            if (NetClient.GetBaseClient().NetState == NetClient.ENetState.ES_Disconnect ||
                NetClient.GetBaseClient().NetState == NetClient.ENetState.ES_UnInit)
            {
                Debug.Log(string.Format("Begin to connect server, ip:{0} port: {1}", ServerIP ,ServerPort));
                NetClient.GetBaseClient().Start(ip, port);
            }
            else
            {
                if (NetClient.GetBaseClient().NetState == NetClient.ENetState.ES_Connected)
                    GameDebug.Log("Connection has been established");
                // 正在连接中，等待即可
                //else if (NetClient.GetInstance().NetState == NetClient.ENetState.ES_Connecting)
                //xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg("连接中,请稍后...");
            }
        }

        public void StopNetClient()
        {
            mConnected = false;
            if (IsNetMode())
            {
                NetClient.GetBaseClient().Stop();
                CancelQueueTime();
            }
        }

        /// <summary>
        /// 得到服務器的時間
        /// </summary>
        /// <returns></returns>
        public System.DateTime GetServerDateTime()
        {
            if (ServerTime == 0)
                return System.DateTime.Now;
            else
            {
                System.DateTime newDate = converted.AddSeconds(ServerTime);

                return newDate;
            }
        }

        /// <summary>
        /// 服务器时间戳
        /// </summary>
        /// <value>The server time.</value>
        public uint ServerTime
        {
            get
            {
                if (mUpdateServerTimeStopwatch == null)
                    return 0;

                mServerTime = mServerLastUpdteTime + ((ulong)mUpdateServerTimeStopwatch.ElapsedMilliseconds);

                return (uint)(0.001 * (double)mServerTime);
            }
        }

        // 查询排队人数
        void OnQueueChecking(float remainTime)
        {
            C2SAccQueueNum queueNum = new C2SAccQueueNum();
            NetClient.GetBaseClient().SendData<C2SAccQueueNum>(NetMsg.MSG_ACC_QUEUE_NUM, queueNum);
        }

        public void CancelQueueTime()
        {
            if(mCheckQueueTime != null)
            {
                mCheckQueueTime.Destroy();
                mCheckQueueTime = null;
            }
        }

        private void OnEnterGame()
        {
            RequestAppendInfo(); // 请求所有本地角色相关系统的信息
            ControlServerLogHelper.SendMobileInfo();// 发送客户端的数据
        }

        void RegisterAllMessage()
        {
            SubscribeNetNotify(NetMsg.MSG_ENTER_GAME, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_EASY_LOGIN, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_ACC_QUEUE, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_ACC_QUEUE_OK, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_ACC_PING, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_ACC_HOTUP, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_ACC_SYS_SETTING, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_ACC_UDP_TOKEN, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_PLAYER_REQUEST_ALL_INFO_END, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_ACC_ROLE_CHANGE_FAIL, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_PLAYER_OPEN_TIME, HandleServerData);
            SubscribeNetNotify(NetMsg.MSG_PLAYER_DAILY_RESET, HandleServerData);

            CustomDataMgr.Instance.RegisterMessages();
            DebugServer.Instance.RegisterAllMessage();
            MainmapManager.Instance.RegisterAllMessage();
            GlobalSettings.Instance.RegisterAllMessages();
            MoveCtrl.RegisterAllMessage();
            AttackCtrl.RegisterAllMessage();
            BeattackedCtrl.RegisterAllMessage();
            BuffCtrl.RegisterAllMessage();
            CooldownManager.Instance.RegisterAllMessage();
            LocalPlayerManager.Instance.RegisterAllMessage();
            GuideManager.Instance.RegisterAllMessages();
            SysConfigManager.Instance.RegisterAllMessages();
            SysPreviewManager.Instance.RegisterAllMessages();
            CullManager.Instance.RigisterAllMessage();
            InstanceManager.Instance.RegisterAllMessages();
            ChatNetEx.Instance.RegisterMessages();
            FriendsNet.Instance.RegisterMessages();
            TaskNet.Instance.RegisterMessages();
            ItemManager.Instance.RegisterAllMessage();
            TaskManager.Instance.RegisterAllMessage();
            MailNet.Instance.RegisterAllMessage();
            InstanceDropManager.Instance.RegisterAllMessages();
            TeamManager.Instance.RegisterAllMessage();
            SkillManager.Instance.RegisterAllMessage();
            xc.Dungeon.CollectionObjectManager.Instance.RegisterMessages();
            HookSettingManager.Instance.RegisterMessages();
            GuildLeagueManager.Instance.RegisterAllMessages();
            SpanServerManager.Instance.RegisterAllMessage();
            MarryManager.Instance.RegisterAllMessage();
            MiniGameManager.Instance.RegisterAllMessages();


        }
    }
}

