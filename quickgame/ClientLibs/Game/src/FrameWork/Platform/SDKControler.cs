//------------------------------------------------------------------------------
// SDK 登陆控制器
// 提供4个 delegate
// 1 初始化成功回调
// 2 登陆回调
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using xc;
using xc.ui; 
using System.IO;

[wxb.Hotfix]
public class SDKControler
{

    public enum SDK_STATU_CODE {
        INIT_SUCCESS,
        INIT_FAIL,


        LOGIN_SUCCESS,
        LOGIN_FAIL,
        LOGIN_MSG_FAIL,
        LOGIN_CANCEL,
        LOGIN_QQ,
        LOGIN_QQ_MORE_TIME,
    }


#if UNITY_IPHONE
    /// <summary>
    /// 在不同时候发送消息通知SDK
    /// </summary>
    public enum RoleEvent
    {
        SELECT_SERVER = 1, //选择服务器
        CREATE_ROLE = 2, // 创建角色
        ENTER_GAME, // 进入游戏
        LEVEL_UP, // 角色升级
        EXIT_GAME // 退出游戏
    }
#else
    /// <summary>
    /// 在不同时候发送消息通知SDK
    /// </summary>
    public enum RoleEvent
    {
        SELECT_SERVER = 1, //选择服务器
        CREATE_ROLE = 2, // 创建角色
        ENTER_GAME, // 进入游戏
        LEVEL_UP, // 角色升级
        EXIT_GAME // 退出游戏
    }
#endif

    public delegate void OnLoginCallback(int code, string msg);
    private OnLoginCallback mLoginCallback;

    public delegate void OnInitCallback(int code);
    private static SDKControler sdkControler;
    private bool mIsLogining;
    bool mIsTencentLoginFirstTime = true;
    public bool mIsIniting = false;
    public bool IsLoginSuccess {
        get {
            return mIsLoginSuccess;
        }
    }
    private bool mIsLoginSuccess = false;
    private SDKControler()
    {
        ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SDK_INITED, OnSDKInited);
        ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SDK_LOGINSUCC, OnSDKLogined);
    }

    void OnSDKInited(CEventBaseArgs data)
    {
        mIsIniting = false;

        // SDK初始化
        ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.SDKInit, "", false);
        ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.boot_sdk);
    }

    void OnSDKLogined(CEventBaseArgs data)
    {
        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
        string msg = bridge.getLoginMsg();
        if (!string.IsNullOrEmpty(msg))
        {
            // SDK登录
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.SDKLogin, "", false);
            ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.login_sdk);

            GotoCSLogin(msg);
        }
    }

    public static SDKControler getSDKControler(){
        if (sdkControler == null)
        {
            sdkControler = new SDKControler();
        }
        return sdkControler;
    } 
    public  void InitSDK()
    {
        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
        if(bridge != null)
        {
            bridge.initSDK();
            mIsIniting = true;
        }
    }

    public bool IsIniting()
    {
        return mIsIniting;
    }

    public void loginSDK(OnLoginCallback callback)
    {

        this.mLoginCallback = callback;


        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
        //bridge.setLoginMsg("");
        bridge.login();

    }
    
    public void GotoCSLogin(string msg)
    {
        mIsLogining = true;
        Hashtable hashtable = MiniJSON.JsonDecode(msg) as Hashtable;

        if (hashtable != null)
        {
            if (hashtable.Count <= 2)
            {
                if(mLoginCallback != null ){
                    endLogin((int)SDK_STATU_CODE.LOGIN_CANCEL,xc.TextHelper.SDKLoginCancel);
                }
                return;
            }
            GlobalConfig globalConfig = GlobalConfig.GetInstance();

            string loginAction = hashtable["_LoginAction_"] as string;
            
            string data = "";
            foreach (DictionaryEntry de in hashtable)
            {
                string key = de.Key.ToString();
                string value = de.Value.ToString();
                if (!key.Equals("_LoginAction_"))
                {
                    value = WWW.EscapeURL(value,System.Text.Encoding.UTF8);
                    data = data + key + "=" + value + "&";
                }
            }

            IBridge bridge = DBOSManager.getOSBridge();

            string url = "";
            // AppID超过350使用新接口
            if (GlobalConfig.Instance.AppId > 350)
            {
                url = globalConfig.LoginURL + "eagleV4/" + loginAction + "?" + data + "game_mark=" + GlobalConfig.Instance.GameMark + "&net=" + bridge.getNetType() + "&provider=" + GlobalConfig.Instance.Channel;
                // os_ext 韩国版用来标识是one_store还是google_play,还是app_store
                if (Const.Region == RegionType.KOREA)
                {
                    url += "&os_ext=" + Application.identifier;
                    url += "&sdkUserId=" + bridge.getSdkUserID();
                }
            }
            else
            {
                url = globalConfig.LoginURL + loginAction + "?" + data + "game_mark=" + GlobalConfig.Instance.GameMark + "&net=" + bridge.getNetType() + "&provider=" + GlobalConfig.Instance.Channel;
                if (Const.Region == RegionType.KOREA)
                {
                    url += "&os_ext=" + Application.identifier;
                    url += "&sdkUserId=" + bridge.getSdkUserID();
                }
            }

#if UNITY_IPHONE
            url = globalConfig.LoginURL + loginAction + "?" + data + "game_mark=" + GlobalConfig.Instance.GameMark + "&net=" + bridge.getNetType();
            if (Const.Region == RegionType.KOREA)
            {
                url += "&os_ext=" + Application.identifier;
                url += "&sdkUserId=" + bridge.getSdkUserID();
            }
            //ios 在xcode 已经传了
#endif



#if UNITY_IPHONE
            url = url + "&device_mark=" + globalConfig.DeviceMark;
            Debug.Log("SDKControler.GotoCSLogin" + url);
#endif

            // 加上二级渠道
            url = url + "&sub_chn=" + globalConfig.SubChannel;

            // 扩展参数
            Hashtable extendParams = new Hashtable();
            extendParams.Add("did", WWW.EscapeURL(bridge.getSDKDeviceID()));
            extendParams.Add("idfa", WWW.EscapeURL(bridge.GetPhoneIDFA()));
            extendParams.Add("extc", bridge.getExtChannel()); //三级渠道
            
            var extend = MiniJSON.JsonEncode(extendParams);
            url = url + "&extend=" + extend;

            MainGame.HttpRequest.GET(url, OnCSLoginFinished, null);
           
        }
        else
        {
            if(mLoginCallback != null ){
                mLoginCallback((int)SDK_STATU_CODE.LOGIN_MSG_FAIL, xc.TextHelper.SDKLoginCancel);
            }
            return;
        }

    }
    private void OnCSLoginFinished(string url, string error, string reply, System.Object userData)
    {
        //GameDebug.LogError("OnCSLoginFinished url: " + url);
        if (String.IsNullOrEmpty(error)==false)
        {
            GameDebug.LogError("OnCSLoginFinished error: " + error);
            if (String.IsNullOrEmpty(error))
                error = xc.TextHelper.SDKLogingFail + "("+error+")";
            endLogin((int)SDK_STATU_CODE.LOGIN_FAIL,error);
            return;
        }
        GameDebug.Log("CS Login succeed, msg = " + reply);
        Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
        if (hashtable != null)
        {
            int errorCode = 0;
            Hashtable retArgs = hashtable["args"] as Hashtable;
            if (hashtable["result"] != null)
            {
                errorCode = DBTextResource.ParseI(hashtable["result"].ToString());
            }
            if (errorCode != 1)
            {
                string msg = "CS login error";
                if (retArgs["error_msg"] != null)
                {
                    msg = retArgs["error_msg"] as string;
                }
                endLogin((int)SDK_STATU_CODE.LOGIN_FAIL,msg);
                return;
            }
            string passport = "";
            if (retArgs["passport"] != null)
            {
                passport = "" + DBTextResource.ParseI(retArgs["passport"].ToString());//(hashtable["passport"] as int) + "";
                //数据发送给 talking data
                //DBOSManager.getOSBridge().onTDLogin(passport);
            }
            string providerPassport = "";
            if (retArgs["provider_passport"] != null)
            {
                providerPassport = retArgs["provider_passport"] as string;
            }
            string ticket = "";
            if (retArgs["ticket"] != null)
            {
                ticket = retArgs["ticket"] as string;
            }
            string errorMsg = "";
            if (retArgs["error_msg"] != null)
            {
                errorMsg = retArgs["error_msg"] as string;
            }
            
            
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            
            if (retArgs["status"] != null)  // 是否需要输入激活码
            {
                globalConfig.LoginInfo.Status = retArgs["status"].ToString();
            }
            if (retArgs["roll_server"] != null)  // 滚服次数
            {
                globalConfig.LoginInfo.RollServer = DBTextResource.ParseUI(retArgs["roll_server"].ToString());
            }
            if (errorCode == 1 && passport != null && ticket != null)
            {
                GameDebug.Log("Get status success, sdkname:" + globalConfig.SDKName + ", passport:" + passport + ", ticket:" + ticket + ", errorMsg:" + errorMsg
                              + ", errorCode:" + errorCode);
                
                globalConfig.LoginInfo.AccName = passport;
                globalConfig.LoginInfo.ProviderPassport = providerPassport;
                globalConfig.LoginInfo.Ticket = ticket;
                //添加初始化话绑定手机逻辑

                int bindMobileState = -1;
                int bindMobileSwitch = 0;
                if (retArgs["bindMobileSwitch"] != null)
                {
                    bindMobileSwitch = DBTextResource.ParseI(retArgs["bindMobileSwitch"].ToString());
                    if (bindMobileSwitch == 1)
                    {
                        bindMobileState = 0;
                        int isBindMobile = 0;
                        if (retArgs["isBindMobile"] != null)
                        {
                            isBindMobile = DBTextResource.ParseI(retArgs["isBindMobile"].ToString());
                            if (isBindMobile == 1)
                            {
                                bindMobileState = 1;
                            }
                        }
                    }
                }

                GlobalConfig.Instance.BindMobileState = bindMobileState;
                OnSDKLoginSucceed(passport,ticket);

                // 首次登录_37wan渠道
                var first37WanUjoy = PlayerPrefs.GetInt(BuriedPointConst.first37WanUjoy, 0);
                if (first37WanUjoy == 0) {
                    PlayerPrefs.SetInt(BuriedPointConst.first37WanUjoy, 1);
                    PlayerPrefs.Save();
                    BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "finishlogin_new_37wan_ujoy_firsttime", 1);
                }
            }
            else
            {
                endLogin((int)SDK_STATU_CODE.LOGIN_FAIL,errorMsg);
            }
        }
        else
        {
            endLogin((int)SDK_STATU_CODE.LOGIN_FAIL,reply);
        }
    }
    private void OnSDKLoginSucceed(string passport, string ticket)
    {
        GlobalConfig globalConfig = GlobalConfig.GetInstance();
        globalConfig.LoginInfo.AccName = passport;
        globalConfig.LoginInfo.Ticket = ticket;
        
        Game game = xc.Game.GetInstance();
        game.Account = passport;
        
        // 保存账号到文件
        StreamWriter streamWriter = new StreamWriter(GlobalConfig.GetInstance().AppResPath + "passport", false);
        streamWriter.Write(passport + ";");
        streamWriter.Close();
        
        GlobalSettings.GetInstance().LastAccount = passport;
        endLogin((int)SDK_STATU_CODE.LOGIN_SUCCESS,"SUCCESS");
    }

    public bool IsLogining()
    {
        return mIsLogining;
    }

    private void endLogin(int code,string msg){
        mIsLogining = false;
        if(mLoginCallback != null ){
            mLoginCallback(code,msg);
        }
        mIsLoginSuccess = (code == (int)SDK_STATU_CODE.INIT_SUCCESS);
    }
    /*
     * 发送消息给SDK，SDK会把这些参数发送给有角色采集需求的SDK
      
        dataType	int	调用时机， 1、选择服务器。2、创建角色。3、进入游戏。4、等级提升。5退出游戏
        serverID	String	玩家所在服务器的ID
        serverName	String	玩家所在的服务器名称
        roleID	String	玩家角色ID
        roleType	String	玩家角色类型
        roleName	String	玩家角色名字
        roleLevel	String	玩家角色等级
        moneyNum	String	当前角色身上拥有的游戏币
        roleCreateTime	Long	角色创建时间
        roleLevelUpTime	Long	角色等级变化
        Vip	String	玩家VIP等级

     */
    public void sendRoleInfo2SDK(int dataType, string serverID, string serviceName,string roleId,string roleType,string roleName,string roleLevel,string moneyNum,string roleCreateTime, string roleLevelUpTime,string vip,string accName)
    {
        if (GlobalConfig.Instance.IsDisableDoAction2SDK == true)
        {
            return;
        }

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("dataType", dataType.ToString());//1.选择服务器2.创建角色3.进入游戏4.等级提升5.退出游戏
        parameters.Add("serverID", serverID);
        parameters.Add("serviceName", serviceName);
        parameters.Add("moneyNum", moneyNum);//金币数量
        parameters.Add("roleCreateTime", roleCreateTime);
        parameters.Add("service",serviceName);
        parameters.Add("roleId", roleId);
        parameters.Add("roleType", roleType);
        parameters.Add("roleName", roleName);
        parameters.Add("roleLevel", roleLevel);
        parameters.Add("roleLevelUpTime", roleLevelUpTime);
        parameters.Add("vip", vip);
        parameters.Add ("accName", accName);
        
        Dictionary <string, string> all = new Dictionary<string, string>();
        all.Add("action", "roleInfo");
        all.Add("parameter", MiniJSON.JsonEncode(new Hashtable(parameters)));
        Hashtable hashtable = new Hashtable(all);
        string str = MiniJSON.JsonEncode(hashtable);
        IBridge bridge = DBOSManager.getDBOSManager().getBridge();
        bridge.doAction2SDK(str);
    }

    public void sendRoleInfo2SDK(int dataType)
    {
        string serverID = "";
        string serverName = "";
        string roleId = "0";
        string roleType = "";
        string roleName = "";
        string roleLevel = "0";
        string moneyNum = "0";
        string roleCreateTime = "";
        string roleLevelUpTime = "";
        string vip = "0";
        string roleAccName = "";
        ServerInfo serverInfo = GlobalConfig.GetInstance().LoginInfo.ServerInfo;
        GlobalConfig.LoginInfoStruct loginInfo = GlobalConfig.GetInstance().LoginInfo;
        LocalPlayerManager localPlayerManager = LocalPlayerManager.Instance;
        uint serverTime = Game.Instance.ServerTime;

        if (serverInfo != null)
        {
            serverID = serverInfo.ServerId.ToString();
            serverName = serverInfo.Name;
        }
        if (loginInfo != null)
        {
            roleId = loginInfo.RId;
            roleType = loginInfo.Job;
            roleName = loginInfo.Name;
            roleLevel = loginInfo.Level;
            roleCreateTime = loginInfo.CreateRoleTime;
            roleAccName = loginInfo.AccName;
        }
        moneyNum = localPlayerManager.Diamond.ToString();
        if (serverTime <= 0)
        {
            serverTime = Convert.ToUInt32(xc.Maths.Util.ConvertDateTimeToTimestamp(System.DateTime.Now));
        }
        roleLevelUpTime = serverTime.ToString();

        sendRoleInfo2SDK(dataType, serverID, serverName, roleId, roleType, roleName, roleLevel, moneyNum, roleCreateTime, roleLevelUpTime, vip, roleAccName);
    }
}
