/*----------------------------------------------------------------
// 文件名： ControlServerLogHelper.cs
// 文件功能描述： 控制服务器日志上传
//----------------------------------------------------------------*/
using UnityEngine;

using xc.ui;
using xc.protocol;
using Net;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using XLua;

namespace xc
{
    /// <summary>
    /// 点击流统计
    /// </summary>
    public enum PlayerFollowRecordSceneId
    {
        [Description("设备信息初始化开始")]
        DeviceInitStart = 1,

        [Description("设备信息初始化成功")]
        DeviceInitEnd,

        [Description("设备信息初始化失败")]
        DeviceInitFail,

        [Description("拷贝资源文件开始")]
        CopyResStart,

        [Description("拷贝资源文件成功")]
        CopyResEnd,

        [Description("拷贝资源文件失败")]
        CopyResFail,

        [Description("检查App更新开始")]
        AppUpdateCheckStart,

        [Description("检查App更新成功")]
        AppUpdateCheckEnd,

        [Description("检查App更新失败")]
        AppUpdateCheckFail,

        [Description("安卓代码和配置表更新开始")]
        Res1And2UpdateCheckStart,

        [Description("安卓代码和配置表更新成功")]
        Res1And2UpdateCheckEnd,

        [Description("安卓代码和配置表更新失败")]
        Res1And2UpdateCheckFail,

        [Description("检查配置表文件更新开始（iOS）")]
        Res2iOSUpdateCheckStart,

        [Description("检查配置表文件更新成功（iOS）")]
        Res2iOSUpdateCheckEnd,

        [Description("检查配置表文件更新失败（iOS）")]
        Res2iOSUpdateCheckFail,

        [Description("下载配置表文件开始（iOS）")]
        Res2iOSUpdateStart,

        [Description("下载配置表文件成功（iOS）")]
        Res2iOSUpdateEnd,

        [Description("下载配置表文件失败（iOS）")]
        Res2iOSUpdateFail,

        [Description("获取资源更新信息开始")]
        Res4UpdateCheckStart,

        [Description("获取资源更新信息成功")]
        Res4UpdateCheckEnd,

        [Description("获取资源更新信息失败")]
        Res4UpdateCheckFail,

        [Description("更新资源开始")]
        Res4UpdateStart,

        [Description("更新资源成功")]
        Res4UpdateEnd,

        [Description("更新资源失败")]
        Res4UpdateFail,

        [Description("预加载资源开始")]
        PreloadResStart,

        [Description("预加载资源成功")]
        PreloadResEnd,

        [Description("初始化SDK")]
        SDKInit,

        [Description("注册SDK")]
        SDKRegister,

        [Description("登录SDK")]
        SDKLogin,

        [Description("获取服务器列表")]
        GetServerList,

        [Description("点击登录按钮")]
        ClickLoginButton,

        [Description("登录服务器成功")]
        LoginServerSuccess,

        [Description("进入创角场景")]
        EnterCreateActorScene,

        [Description("点击创角按钮")]
        ClickCreateActorButton,

        [Description("进入选角场景")]
        EnterSelectActorScene,

        [Description("点击选角按钮")]
        ClickSelectActorButton,

        [Description("第一次进入场景")]
        EnterFirstScene,

        [Description("StartLogout")]
        StartLogout,

        [Description("FinishedLogout")]
        FinishedLogout,

        [Description("资源下载失败")]
        ResDownloadFail,

        [Description("资源加载失败")]
        ResLoadFail,
    }

    /// <summary>
    /// 云梯事件上报标识
    /// </summary>
    public enum CloudLadderMarkEnum
    {
        [Description("启动")] //scene=设备信息初始化成功 
        boot_app = 100,

        [Description("解压安装包")] //scene=拷贝资源文件成功
        unzip_res = 120,

        [Description("检查更新")] //scene=获取资源更新信息成功
        check_update = 200,

        [Description("更新完成")] //scene=更新资源成功 
        update_res = 220,

        [Description("加载资源")] //scene=预加载资源成功
        load_res = 240,

        [Description("启动SDK")] //scene=初始化SDK
        boot_sdk = 300,

        [Description("登录SDK")] //scene=登录SDK
        login_sdk = 320,

        [Description("获取服务器列表")] //scene=获取服务器列表 
        list_gs = 400,

        [Description("登录游戏服")] //scene=登录服务器成功
        login_gs = 420,

        [Description("创建角色")] //scene=点击创角按钮
        create_role = 440,

        [Description("选择角色")] //scene=点击选角按钮 
        select_role = 460,

        [Description("进入游戏")] //scene=第一次进入场景 
        enter_game = 500,
    }
    
    /// <summary>
    /// 渠道信息
    /// </summary>
    class ChannelInfo
    {
        public uint Id;
        public string Name;
        public string Title;
    }

    [wxb.Hotfix]
    public class ControlServerLogHelper : xc.Singleton<ControlServerLogHelper>
    {
        private Utils.Timer mPostRoleInfoTimer = null;
        uint mPostRoleInfoTimes = 0;

        // 渠道信息列表
        private List<ChannelInfo> mChannelList;
        private string mLogContent = "TestinLog-Event>>>> ID LaunchGame, Key LaunchGame, Value 1";
        private static string mLogFmt = "TestinLog-Event>>>> ID GameQuality, Key GameQuality, Value {0}";

        public ControlServerLogHelper()
        {
            //ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_ACTOR_LEVEL_UPDATE , OnLevelup);
        }

        System.Action<bool> mPostDeviceInitFinishedCallback;
        public void OnPostDeviceInitFinished(string url, string error, string reply, System.Object userData)
        {
            int result = 0;
            Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
            if (hashtable != null)
            {
                result = DBTextResource.ParseI(hashtable["result"].ToString());
            }

            bool ret = false;
            string errorMsg = "";
            Hashtable argsHashtable = hashtable["args"] as Hashtable;
            if (result == 1)
            {
                if (argsHashtable != null)
                {
                    string deviceMark = argsHashtable["device_mark"].ToString();

                    if (GlobalConfig.Instance.DeviceMark.Equals(deviceMark) == false)
                    {
                        GlobalConfig.Instance.DeviceMark = deviceMark;

                        GlobalSettings.GetInstance();
                        UserPlayerPrefs.Instance.SetString("DeviceMark", deviceMark);
                        UserPlayerPrefs.Instance.Save();
                    }

                    ret = true;
                }
            }
            else
            {
                if (argsHashtable != null)
                {
                    errorMsg = argsHashtable["error_msg"].ToString();
                }
            }

            if (ret == true)
            {
                // DeviceInit成功
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.DeviceInitEnd, "", false);
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.boot_app);
            }
            else
            {
                // DeviceInit失败
                if (string.IsNullOrEmpty(errorMsg) == true)
                {
                    if (string.IsNullOrEmpty(error) == false)
                    {
                        ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.DeviceInitFail, error, false);
                    }
                    else
                    {
                        ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.DeviceInitFail, "Unknown error", false);
                    }
                }
                else
                {
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.DeviceInitFail, errorMsg, false);
                }
            }

            // action保存了NewInitSceneLoader中的函数，调用之后需要赋空
            if(mPostDeviceInitFinishedCallback != null)
            {
                mPostDeviceInitFinishedCallback.Invoke(ret);
                mPostDeviceInitFinishedCallback = null;
            }
        }

        public void PostDeviceInit(System.Action<bool> callback = null)
        {
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.DeviceInitStart, "", false);

            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();

            string url = GlobalConfig.GetInstance().CSURLV + "DeviceInit";
            url += "?os=" + globalConfig.PlatformName;
            url += "&os_ver=" + bridge.getOSVersion();
            url += "&imei=" + bridge.GetPhoneIDFA();
            url += "&mac=" + bridge.getPhoneMAC();
            url += "&imsi=" + bridge.getPhoneIMSI();
            url += "&brand=";
            url += "&mobile=" + bridge.getPhoneModel();
            url += "&app_ver=" + bridge.getAppVersion();
            url += "&cpu_t=" + bridge.getCPUAPI();
            url += "&net=" + bridge.getNetType();
            url += "&device_mark=" + globalConfig.DeviceMark;
            url += "&provider=" + globalConfig.SDKName;
            url += "&device_id=";
            url += "&game_mark=" + globalConfig.GameMark;
            url += "&ram=" + bridge.getAvailMemory();
            url += "&rom=" + bridge.getStorageFreeSize();

            mPostDeviceInitFinishedCallback = callback;

            Debug.Log(string.Format("[PostDeviceInit] {0}", url));

            HttpRequest.Instance.GET(url, OnPostDeviceInitFinished, null);
        }

        public void PostRoleInfoWithDelay(float remainTime)
        {
            if (mPostRoleInfoTimer != null)
            {
                mPostRoleInfoTimer.Destroy();
                mPostRoleInfoTimer = null;
            }

            PostRoleInfo();
        }

        public void OnPostRoleInfoFinished(string url, string error, string reply, System.Object userData)
        {
            int result = 0;
            Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
            if (hashtable != null)
            {
                result = DBTextResource.ParseI(hashtable["result"].ToString());
            }

            if (result != 1)
            {
                if (mPostRoleInfoTimer != null)
                {
                    mPostRoleInfoTimer.Destroy();
                    mPostRoleInfoTimer = null;
                }
                // 超过10次就不要再尝试了
                if (mPostRoleInfoTimes <= 10)
                {
                    mPostRoleInfoTimer = new Utils.Timer(3000, false, 3000, PostRoleInfoWithDelay);

                    mPostRoleInfoTimes++;
                }
                else
                {
                    mPostRoleInfoTimes = 0;
                }
            }
            else
            {
                mPostRoleInfoTimes = 0;
            }
        }

        /// <summary>
        /// 角色日志接口
        /// </summary>
        public void PostRoleInfo()
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();

            if (loginInfo == null || loginInfo.ServerInfo == null)
            {
                return;
            }

            string url = GlobalConfig.GetInstance().LogURLV + "RoleInfo";
            url += "?account=" + loginInfo.AccName;
            url += "&provider=" + globalConfig.SDKName;
            url += "&device_mark=" + globalConfig.DeviceMark;
            url += "&server_id=" + loginInfo.ServerInfo.ServerId;
            url += "&os=" + globalConfig.PlatformName;
            url += "&level=" + loginInfo.Level;
            url += "&role_id=" + loginInfo.RId;
            url += "&role_name=" + WWW.EscapeURL(loginInfo.Name);
            url += "&icon_id=" + loginInfo.Job;
            url += "&job=" + loginInfo.Job;
            url += "&game_mark=" + globalConfig.GameMark;
            url += "&mobile=" + bridge.getPhoneModel();
            url += "&net=" + bridge.getNetType();
            url += "&ticket=" + WWW.EscapeURL(loginInfo.Ticket);
            // 获取不到IMEI（例如玩家不给权限），就用玩家唯一id代替
            string imei = bridge.getPhoneIMEI();
            if (string.IsNullOrEmpty(imei) == false)
            {
                url += "&imei=" + imei;
            }
            else
            {
                url += "&imei=" + loginInfo.RId;
            }
            url += "&roleInfo=" + "transfer_lv:" + TransferHelper.GetTransferLevel();   // 自定义角色数据，例：roleInfo=tran_lv:213#icon_id:3#gander:man
            url += "&xg_device_id=" + globalConfig.XgDeviceId;
            url += "&vip=" + VipHelper.GetVipValidLevel();
            url += "&app_id=" + globalConfig.AppId;
            url += "&access_id=" + bridge.getXgAccessId();

            MainGame.HttpRequest.GET(url, OnPostRoleInfoFinished, null);
        }

        //void OnLevelup(CEventBaseArgs args)
        //{
        //    PostRoleInfo();
        //}

        /// <summary>
        /// 客户端启动日志采集
        /// </summary>
        public void PostStartClientLog()
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = GlobalConfig.GetInstance().LogURLV + "StartClientLog?provider=" + globalConfig.SDKName;
            url += "&device_mark=" + globalConfig.DeviceMark;
            url += "&os=" + globalConfig.PlatformName;
            url += "&os_ver=" + bridge.getOSVersion();
            url += "&mobile=" + bridge.getPhoneModel();
            url += "&net=" + bridge.getNetType();
            url += "&imei=" + bridge.getPhoneIMEI();
            url += "&mac=" + bridge.getPhoneMAC();
            url += "&imsi=" + bridge.getPhoneIMSI();
            url += "&use_time=" + ((int)Time.time).ToString();
            url += "&game_mark=" + globalConfig.GameMark;

            MainGame.HttpRequest.GET(url, null, null);
        }

        /// <summary>
        /// 账号登陆日志记录(已经选服登陆请求)
        /// </summary>
        /// <param name="serverId">Server identifier.</param>
        /// <param name="serverType">Server type.</param>
        public void PostAccountLoginLogS(int serverId, EServerState serverType)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();
            
            string url = GlobalConfig.GetInstance().LogURLV + "AccountLoginLogS?account=" + loginInfo.AccName;
            url += "&server_id=" + serverId;
            url += "&server_type=" + (int)serverType;
            url += "&show_marked=" + globalConfig.ServerType;
            url += "&provider=" + globalConfig.SDKName;
            url += "&device_mark=" + globalConfig.DeviceMark;
            url += "&os=" + globalConfig.PlatformName;
            url += "&os_ver=" + bridge.getOSVersion();
            url += "&mobile=" + bridge.getPhoneModel();
            url += "&net=" + bridge.getNetType();
            url += "&imei=" + bridge.getPhoneIMEI();
            url += "&mac=" + bridge.getPhoneMAC();
            url += "&imsi=" + bridge.getPhoneIMSI();
            url += "&game_mark=" + globalConfig.GameMark;
            url += "&sub_chn=" + globalConfig.SubChannel;

            MainGame.HttpRequest.GET(url, null, null);
        }

        System.Action<bool> mPostGetPackFinishedCallback;
        public void OnGetPackFinished(string url, string error, string reply, System.Object userData)
        {
            if (string.IsNullOrEmpty(error) == false)
            {
                GameDebug.LogError("OnGetPackFinished error: " + error);
                UINotice.GetInstance().ShowMessage(DBConstText.GetText("GIFT_BAG_FAIL"));

                mPostGetPackFinishedCallback?.Invoke(false);
                return;
            }

            bool ret = false;
            Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;

            if (hashtable != null)
            {
                int result = DBTextResource.ParseI(hashtable["result"].ToString());
                if (result == 1)
                {
                    UINotice.GetInstance().ShowMessage(DBConstText.GetText("GIFT_BAG_EXCHANGE_SUCCESS"));

                    ret = true;
                }
                else
                {
                    Hashtable argsHashtable = hashtable["args"] as Hashtable;
                    if (argsHashtable != null)
                    {
                        string msg = argsHashtable["error_msg"].ToString();
                        string translatedMsg = xc.TextHelper.GetTranslateText(msg);
                        UINotice.GetInstance().ShowMessage(translatedMsg);
                    }
                    else
                    {
                        UINotice.GetInstance().ShowMessage(DBConstText.GetText("GIFT_BAG_FAIL"));
                    }
                }
            }
            else
            {
                GameDebug.LogError("OnGetPackFinished error: " + reply);
            }

            mPostGetPackFinishedCallback?.Invoke(ret);
        }

        /// <summary>
        /// 礼包兑换码接口
        /// </summary>
        /// <param name="code">Code.</param>
        public void PostGetPack(string code, System.Action<bool> callback = null)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = GlobalConfig.GetInstance().CSURLV + "GetPack";
            url += "?game_mark=" + globalConfig.GameMark;
            url += "&code=" + code;
            url += "&server_id=" + loginInfo.ServerInfo.ServerId;
            url += "&provider=" + globalConfig.SDKName;
            url += "&account=" + loginInfo.AccName;
            url += "&role_id=" + loginInfo.RId;
            url += "&ticket=" + WWW.EscapeURL(loginInfo.Ticket);

            mPostGetPackFinishedCallback = callback;

            MainGame.HttpRequest.GET(url, OnGetPackFinished, null);
        }

        public static void CreatePkgAccPhoneInfos(List<PkgAccPhoneInfo> infos)
        {
            IBridge bridge = DBOSManager.getOSBridge();
            GlobalConfig globalConfig = GlobalConfig.GetInstance();

            infos.Clear();

            // 手机平台
            PkgAccPhoneInfo info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("platform");
            info.val = Encoding.UTF8.GetBytes(globalConfig.PlatformName);
            GameDebug.Log("platform: " + globalConfig.PlatformName);
            infos.Add(info);

            // 系统版本
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("sys_ver");
            info.val = Encoding.UTF8.GetBytes(SystemInfo.operatingSystem);
            GameDebug.Log("system: " + SystemInfo.operatingSystem);
            infos.Add(info);

            // 手机型号
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("model");
            info.val = Encoding.UTF8.GetBytes(SystemInfo.deviceModel);
            GameDebug.Log("model: " + SystemInfo.deviceModel);
            infos.Add(info);

            // 芯片型号参数
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("chip");
            //CPU核数#CPU主频#CPU名称#GPU名称
            string chip_info = string.Format("{0}#{1}#{2}#{3}", SystemInfo.processorCount, SystemInfo.processorFrequency, SystemInfo.processorType, SystemInfo.graphicsDeviceName);
            info.val = Encoding.UTF8.GetBytes(chip_info);
            GameDebug.Log("chip_info: " + chip_info);
            infos.Add(info);

            // imei
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("imei");
            info.val = Encoding.UTF8.GetBytes(bridge.getPhoneIMEI());
            GameDebug.Log("imei: " + bridge.getPhoneIMEI());
            infos.Add(info);

            // imsi
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("imsi");
            info.val = Encoding.UTF8.GetBytes(bridge.getPhoneIMSI());
            GameDebug.Log("imsi: " + bridge.getPhoneIMSI());
            infos.Add(info);

            // mac
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("mac");
            info.val = Encoding.UTF8.GetBytes(bridge.getPhoneMAC());
            GameDebug.Log("mac: " + bridge.getPhoneMAC());
            infos.Add(info);

            // 画质选择
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("grahics");
            info.val = Encoding.UTF8.GetBytes(QualitySetting.GraphicLevel.ToString());
            GameDebug.Log("grahics: " + QualitySetting.GraphicLevel);
            infos.Add(info);

            // 召唤物开关
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("summon");
            var summon_str_val = (GlobalSettings.Instance.SummonMonsterVisible ? 1 : 0).ToString();
            info.val = Encoding.UTF8.GetBytes(summon_str_val);
            GameDebug.Log("summon: " + summon_str_val);
            infos.Add(info);

            // 同屏人数
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("player");
            info.val = Encoding.UTF8.GetBytes(GlobalSettings.Instance.MaxPlayerCount.ToString());
            GameDebug.Log("player: " + GlobalSettings.Instance.MaxPlayerCount);
            infos.Add(info);

            // 联网方式
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("net");
            var net_str_val = ((uint)Application.internetReachability).ToString();
            info.val = Encoding.UTF8.GetBytes(net_str_val);
            GameDebug.Log("net: " + net_str_val);
            infos.Add(info);

            // 分辨率
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("screen");
            var screnn_str_val = string.Format("{0}*{1}", Screen.width, Screen.height);
            info.val = Encoding.UTF8.GetBytes(screnn_str_val);
            GameDebug.Log("screen: " + screnn_str_val);
            infos.Add(info);

            // DeviceMark
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("device_mark");
            info.val = Encoding.UTF8.GetBytes(globalConfig.DeviceMark);
            GameDebug.Log("device_mark: " + globalConfig.DeviceMark);
            infos.Add(info);

            // appid
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("appid");
            info.val = Encoding.UTF8.GetBytes(globalConfig.AppId.ToString());
            GameDebug.Log("appid: " + globalConfig.AppId);
            infos.Add(info);

            if (globalConfig.LoginInfo.ServerInfo != null)
            {
                // 控制服务器的id
                info = new PkgAccPhoneInfo();
                info.key = Encoding.UTF8.GetBytes("control_id");
                info.val = Encoding.UTF8.GetBytes(globalConfig.LoginInfo.ServerInfo.ServerId.ToString());
                GameDebug.Log("control_id: " + globalConfig.LoginInfo.ServerInfo.ServerId);
                infos.Add(info);

                // 服务器名字
                info = new PkgAccPhoneInfo();
                info.key = Encoding.UTF8.GetBytes("server_name");
                info.val = Encoding.UTF8.GetBytes(globalConfig.LoginInfo.ServerInfo.Name);
                GameDebug.Log("server_name: " + globalConfig.LoginInfo.ServerInfo.Name);
                infos.Add(info);
            }

            // did
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("did");
            info.val = Encoding.UTF8.GetBytes(bridge.getSDKDeviceID());
            GameDebug.Log("did: " + bridge.getSDKDeviceID());
            infos.Add(info);

            // idfa
            info = new PkgAccPhoneInfo();
            info.key = Encoding.UTF8.GetBytes("idfa");
            info.val = Encoding.UTF8.GetBytes(bridge.GetPhoneIDFA());
            GameDebug.Log("idfa: " + bridge.GetPhoneIDFA());
            infos.Add(info);

            // lua扩展
            object[] param = { };
            System.Type[] return_type = { typeof(string) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "GetExtendPhoneInfo", param, return_type);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    string ret = (string)objs[0];
                    System.Object retObject = MiniJSON.JsonDecode(ret);
                    if (retObject != null)
                    {
                        Hashtable hashtable = retObject as Hashtable;
                        if (hashtable != null)
                        {
                            foreach (DictionaryEntry kv in hashtable)
                            {
                                info = new PkgAccPhoneInfo();
                                info.key = Encoding.UTF8.GetBytes(kv.Key.ToString());
                                info.val = Encoding.UTF8.GetBytes(kv.Value.ToString());
                                GameDebug.Log(kv.Key.ToString() + ": " + kv.Value.ToString());
                                infos.Add(info);
                            }
                        }
                    }
                }
            }

            if (Const.Region == RegionType.SEASIA)
            {
                //当前选中语言
                info = new PkgAccPhoneInfo();
                info.key = Encoding.UTF8.GetBytes("language");
                info.val = Encoding.UTF8.GetBytes(TranslateManager.GetInstance().ConvertToServerLang(Const.Language).ToString());
                GameDebug.Log("language: " + TranslateManager.GetInstance().ConvertToServerLang(Const.Language).ToString());
                infos.Add(info);
            }

            // os_ext 韩国版用来标识是one_store还是google_play,还是app_store
            if (Const.Region == RegionType.KOREA)
            {
                info = new PkgAccPhoneInfo();
                info.key = Encoding.UTF8.GetBytes("os_ext");
                info.val = Encoding.UTF8.GetBytes(Application.identifier);
                GameDebug.Log("os_ext: " + Application.identifier);
                infos.Add(info);
            }
        }

        public static void SendMobileInfo()
        {
            var phone_info = new C2SAccPhoneInfo();
            CreatePkgAccPhoneInfos(phone_info.info);

            NetClient.GetBaseClient().SendData<C2SAccPhoneInfo>(NetMsg.MSG_ACC_PHONE_INFO, phone_info);
        }

        /// <summary>
        /// 反馈系统获取配置面板信息
        /// </summary>
        public void GetFeedbackInfo(System.Action<LuaTable> callback = null)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;

            string url = GlobalConfig.GetInstance().CSURLV + "Feedback/GetConfig";
            url += "?role_id=" + loginInfo.RId;
            url += "&game_mark=" + globalConfig.GameMark;
            url += "&os=" + globalConfig.PlatformName;
            url += "&provider=" + globalConfig.SDKName;

            mGetFeedbackCallback = callback;

            MainGame.HttpRequest.GET(url, OnGetFeedbackInfo, null);
        }

        System.Action<LuaTable> mGetFeedbackCallback;
        public void OnGetFeedbackInfo(string url, string error, string reply, System.Object userData)
        {
            LuaTable replyTable = LuaScriptMgr.Instance.Lua.NewTable();
            if (replyTable == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(error))
            {
                GameDebug.LogWarning("OnGetFeedbackInfo reply: " + reply);
                Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
                if (hashtable != null)
                {
                    Hashtable argsTable = hashtable["args"] as Hashtable;
                    if (argsTable == null)
                    {
                        return;
                    }
                    replyTable.Set("day_num", argsTable["day_num"]);
                    LuaTable contactsTable = LuaScriptMgr.Instance.Lua.NewTable();
                    if (contactsTable == null)
                    {
                        return;
                    }
                    ArrayList contactArrayList = argsTable["contact"] as ArrayList;
                    if (contactArrayList == null)
                    {
                        return;
                    }
                    for (int i = 0; i < contactArrayList.Count; i++)
                    {
                        Hashtable contactHashtable = contactArrayList[i] as Hashtable;
                        LuaTable contactTable = LuaScriptMgr.Instance.Lua.NewTable();
                        if (contactHashtable == null || contactTable == null)
                        {
                            return;
                        }
                        contactTable.Set("name", contactHashtable["name"]);
                        contactTable.Set("type", contactHashtable["type"]);
                        contactTable.Set("value", contactHashtable["value"]);
                        contactsTable.Set(i + 1, contactTable);
                    }
                    replyTable.Set("contacts", contactsTable);
                    LuaTable typeTable = LuaScriptMgr.Instance.Lua.NewTable();
                    ArrayList typeArrayList = argsTable["types"] as ArrayList;
                    if (typeTable == null || typeArrayList == null)
                    {
                        return;
                    }
                    foreach (Hashtable typeHashTable in typeArrayList)
                    {
                        if (typeHashTable == null)
                        {
                            return;
                        }
                        typeTable.Set(typeHashTable["type"], typeHashTable["value"]);
                    }
                    replyTable.Set("types", typeTable);
                }
                mGetFeedbackCallback?.Invoke(replyTable);
            }
        }

        /// <summary>
        /// 反馈信息接口
        /// </summary>
        /// <param name="data">用户反馈的数据</param>
        public void PostFeedback(int type, string msg, System.Action<bool> callback = null)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = GlobalConfig.GetInstance().CSURLV + "Feedback";
            url += "?account=" + loginInfo.AccName;
            url += "&game_mark=" + globalConfig.GameMark;
            url += "&ticket=" + WWW.EscapeURL(loginInfo.Ticket);
            url += "&device_mark=dm" + globalConfig.DeviceMark;
            url += "&provider=" + globalConfig.SDKName;
            url += "&server_id=" + loginInfo.ServerInfo.ServerId;
            url += "&role_id=" + loginInfo.RId;
            url += "&role_name=" + WWW.EscapeURL(LocalPlayerManager.Instance.LocalActorAttribute.Name, System.Text.Encoding.UTF8);
            url += "&lv=" + LocalPlayerManager.Instance.LocalActorAttribute.Level;
            url += "&type=" + type;
            url += "&title=" + WWW.EscapeURL(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_18"), System.Text.Encoding.UTF8);
            url += "&msg=" + WWW.EscapeURL(msg, System.Text.Encoding.UTF8);
            //url = System.Uri.EscapeUriString(url);

            mPostFeedbackCallback = callback;

            MainGame.HttpRequest.GET(url, OnFeedback, null);
        }

        System.Action<bool> mPostFeedbackCallback;
        public void OnFeedback(string url, string error, string reply, System.Object userData)
        {
            bool result;
            if (string.IsNullOrEmpty(error))
            {
                Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
                if (hashtable != null)
                {
                    if (DBTextResource.ParseI(hashtable["result"].ToString()) == 1)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            mPostFeedbackCallback?.Invoke(result);
        }

        public void LoadImage(string path, System.Action<Sprite> callback)
        {
            if (path == null || path == "")
            {
                GameDebug.LogError("图片路径不能为空");
                callback.Invoke(null);
                return;
            }
            MainGame.GetGlobalMono().StartCoroutine(_LoadImage(path, callback));
        }

        public IEnumerator _LoadImage(string path, System.Action<Sprite> callback)
        {
            WWW www = new WWW(path);
            yield return www;

            Texture2D texture2D = www.texture;
            if (texture2D == null)
            {
                callback.Invoke(null);
                yield break;
            }

            // 需要销毁旧资源
            int width = texture2D.width;
            int height = texture2D.height;
            GameObject.DestroyImmediate(texture2D, true);

            // 重新创建RBGA16的贴图, 并禁用mipmap
            TextureFormat texture_format = TextureFormat.RGBA32;
#if UNITY_ANDROID || UNITY_IPHONE
            texture_format = TextureFormat.RGBA4444;
#else
            texture_format = TextureFormat.ARGB4444;
#endif

            Texture2D newTexture2D = new Texture2D(width, height, texture_format, false);
            newTexture2D.LoadImage(www.bytes);
            if (newTexture2D == null)
            {
                callback.Invoke(null);
                yield break;
            }

            Sprite sprite = Sprite.Create(newTexture2D, new Rect(0, 0, newTexture2D.width, newTexture2D.height), new Vector2(0, 0));
            callback.Invoke(sprite);
        }

        /// <summary>
        /// 玩家登录轨迹
        /// </summary>
        public void PostPlayerFollowRecord(PlayerFollowRecordSceneId sceneId, string desc = "", bool isEnterGame = true)
        {
            if (sceneId == PlayerFollowRecordSceneId.EnterFirstScene)
            {
                // TestinExternalLog
                DBOSManager.getOSBridge().log2OSCmd("TestinExternalLog", mLogContent);

                // TestinExternalLog
                var logContent = string.Format(mLogFmt, 3 - QualitySetting.GraphicLevel);
                DBOSManager.getOSBridge().log2OSCmd("TestinExternalLog", logContent);

                // 云梯第一次进入场景
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.enter_game);
            }

            FieldInfo fi = sceneId.GetType().GetField(sceneId.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string scene = (attributes.Length > 0) ? attributes[0].Description : sceneId.ToString();

            LanguageType languageType = Const.Language;
            fi = languageType.GetType().GetField(languageType.ToString());
            attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string language = (attributes.Length > 0) ? attributes[0].Description : languageType.ToString();

            //GameDebug.LogError("PostPlayerFollowRecord scene: " + scene);

            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            GlobalConfig.LoginInfoStruct loginInfo = globalConfig.LoginInfo;
            IBridge bridge = DBOSManager.getOSBridge();

            string url = globalConfig.CommonURL + "playerFollowRecord";
            url += "?gameMark=" + globalConfig.GameMark;
            if (string.IsNullOrEmpty(loginInfo.AccName) == true)
            {
                url += "&account=none";
            }
            else
            {
                url += "&account=" + loginInfo.AccName;
            }
            if (loginInfo.ServerInfo != null)
            {
                url += "&server_id=" + loginInfo.ServerInfo.ServerId;
            }
            url += "&role_id=" + loginInfo.RId;
            url += "&role_name=" + WWW.EscapeURL(loginInfo.Name);
            url += "&level=" + loginInfo.Level;
            if (isEnterGame == true)
            {
                url += "&vip=" + VipHelper.GetVipValidLevel();
            }
            else
            {
                url += "&vip=0";
            }
            url += "&provider=" + globalConfig.SDKName;
            url += "&scene=" + WWW.EscapeURL(scene);
            url += "&msg=" + WWW.EscapeURL(desc);
            url += "&position=0";
            url += "&os=" + globalConfig.PlatformName;
            url += "&osVer=" + bridge.getOSVersion();
            url += "&brand=" + WWW.EscapeURL(bridge.getBrand());
            url += "&model=" + WWW.EscapeURL(bridge.getPhoneModel());
            url += "&job=" + loginInfo.Job;
            url += "&net=" + bridge.getNetType();
            if (isEnterGame == true)
            {
                if (Game.Instance.ServerTime > 0)
                {
                    url += "&time=" + Game.Instance.ServerTime;
                }
                else
                {
                    url += "&time=" + System.Convert.ToUInt32(xc.Maths.Util.ConvertDateTimeToTimestamp(System.DateTime.Now)); ;
                }
            }
            else
            {
                url += "&time=0";
            }
            url += "&device_mark=" + globalConfig.DeviceMark;
            url += "&start_time=" + globalConfig.StartTimeStamp;
#if UNITY_IPHONE
            url += "&imei=" + bridge.GetPhoneIDFA();
#else
            url += "&imei=" + bridge.getPhoneIMEI();
#endif
            url += "&mac=" + bridge.getPhoneMAC();
            url += "&imsi=" + bridge.getPhoneIMSI();
            url += "&app_version=" + bridge.getAppVersion();
            url += "&chn_id=" + bridge.getSdkID();

            url += "&carrier=" + WWW.EscapeURL(bridge.getOperator());
            url += "&jbk=" + bridge.isRoot();
            url += "&did=" + bridge.getSDKDeviceID();
            url += "&tz=" + WWW.EscapeURL(bridge.getTimeZone());
            url += "&lang=" + language;
            url += "&width=" + bridge.getWindowWidth();
            url += "&height=" + bridge.getWindowHeigh();
            url += "&apil=" + bridge.getAPILevel();
            url += "&idfa=" + bridge.GetPhoneIDFA();
            url += "&idfv=" + bridge.getPhoneIDFV();
            url += "&ip=" +WWW.EscapeURL(bridge.getLocalIpAddress());
            url += "&wifi=" + WWW.EscapeURL(bridge.getWfName());
            url += "&factory=" + WWW.EscapeURL(bridge.getManufacturer());
            url += "&game_version=" + VersionInfoManager.Instance.GameVersion;
            url += "&appId=" + bridge.getAppID();
            url += "&sdkv=" + bridge.getSDKVersionName();

            HttpRequest.Instance.GET(url, null, null);

            GameDebug.Log("PostPlayerFollowRecord: " + scene);
        }

        /// <summary>
        /// 向控制服请求渠道列表
        /// </summary>
        /// <param name="channelList">作筛选用，不传则表示获取全部列表</param>
        public void GetChannelList(uint channelId = 0)
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            string url = globalConfig.ClientURL + "channelList";
            url += "?game_mark=" + globalConfig.GameMark;
            if (channelId > 0)
            {
                url += "&cid=" + channelId;
            }

            HttpRequest.Instance.GET(url, OnGetChannelList, null);
        }

        public void OnGetChannelList(string url, string error, string reply, System.Object userData)
        {
            if (string.IsNullOrEmpty(error) == false)
            {
                GameDebug.LogError("OnGetChannelList error: " + error);
                return;
            }

            mChannelList = new List<ChannelInfo>();
            mChannelList.Clear();

            Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
            if (hashtable != null)
            {
                if (DBTextResource.ParseI(hashtable["result"].ToString()) == 1)
                {
                    ArrayList arrayList = hashtable["args"] as ArrayList;
                    if (arrayList != null)
                    {
                        foreach (System.Object o in arrayList)
                        {
                            Hashtable channelInfoHashtable = o as Hashtable;
                            if (channelInfoHashtable != null && channelInfoHashtable.Count > 0)
                            {
                                ChannelInfo channelInfo = new ChannelInfo();
                                channelInfo.Id = System.Convert.ToUInt32(channelInfoHashtable["id"]);
                                channelInfo.Name = System.Convert.ToString(channelInfoHashtable["name"]);
                                channelInfo.Title = System.Convert.ToString(channelInfoHashtable["title"]);

                                mChannelList.Add(channelInfo);
                            }
                        }
                    }
                }
                else
                {
                    Hashtable argsHashtable = hashtable["args"] as Hashtable;
                    if (argsHashtable != null)
                    {
                        string msg = argsHashtable["error_msg"].ToString();
                        GameDebug.LogError("GetChannelList error, msg:" + msg);
                    }
                    else
                    {
                        GameDebug.LogError("GetChannelList error, unknown reason");
                    }
                }
            }
        }

        /// <summary>
        /// 根据渠道id获取渠道名字
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        public string GetChannelName(string channel)
        {
            if (mChannelList != null)
            {
                foreach (ChannelInfo channelInfo in mChannelList)
                {
                    if (channelInfo.Title == channel)
                    {
                        return channelInfo.Name;
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// 向控制服请求所有服务器列表
        /// </summary>
        public void GetServerList()
        {
            GlobalConfig globalConfig = GlobalConfig.GetInstance();
            string url = globalConfig.ClientURL + "serverList";
            url += "?game_mark=" + globalConfig.GameMark;

            HttpRequest.Instance.GET(url, OnGetServerList, null);
        }

        public void OnGetServerList(string url, string error, string reply, System.Object userData)
        {
            if (string.IsNullOrEmpty(error) == false)
            {
                GameDebug.LogError("OnGetServerList error: " + error);
                return;
            }

            Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
            if (hashtable != null)
            {
                if (DBTextResource.ParseI(hashtable["result"].ToString()) == 1)
                {
                    ArrayList arrayList = hashtable["args"] as ArrayList;
                    if (arrayList != null)
                    {
                        foreach (System.Object o in arrayList)
                        {
                            Hashtable serverInfoHashtable = o as Hashtable;
                            if (serverInfoHashtable != null && serverInfoHashtable.Count > 0)
                            {
                                uint controlServerId = System.Convert.ToUInt32(serverInfoHashtable["server_id"]);
                                uint serverId = System.Convert.ToUInt32(serverInfoHashtable["s_id"]);
                                string name = System.Convert.ToString(serverInfoHashtable["name"]);

                                SpanServerManager.Instance.AddServerNameFromControlServer(controlServerId, serverId, name);
                            }
                        }
                    }
                }
                else
                {
                    Hashtable argsHashtable = hashtable["args"] as Hashtable;
                    if (argsHashtable != null)
                    {
                        string msg = argsHashtable["error_msg"].ToString();
                        GameDebug.LogError("OnGetServerList error, msg:" + msg);
                    }
                    else
                    {
                        GameDebug.LogError("OnGetServerList error, unknown reason");
                    }
                }
            }
        }

        /// <summary>
        /// 云梯事件上报
        /// </summary>
        public void PostCloudLadderEventAction(CloudLadderMarkEnum mark)
        {
            if (GlobalConfig.Instance.IsPostCloudLadderAction == false)
                return;

            FieldInfo fi = mark.GetType().GetField(mark.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string desc = (attributes.Length > 0) ? attributes[0].Description : "";
            var descBytes = Encoding.UTF8.GetBytes(desc);
            desc = Encoding.UTF8.GetString(descBytes);

            var loginInfo = GlobalConfig.Instance.LoginInfo;

            Hashtable parameters = new Hashtable();
            parameters.Add("step", ((int)mark).ToString());//步骤编号
            parameters.Add("mark", mark.ToString()); // 步骤标识
            parameters.Add("desc", desc);//描述
            parameters.Add("gamever", VersionInfoManager.Instance.GameVersion);  // 游戏版本
            parameters.Add("ram", SystemInfo.systemMemorySize.ToString());


            string rid = ""; // 游戏角色id
            if (null != loginInfo)
                rid = loginInfo.RId;

            parameters.Add("rid", rid);

            Hashtable all = new Hashtable();
            all.Add("action", "checkpoint");

            string uid = ""; // 游戏后台分配的账号id(passport)
            if (null != loginInfo)
                uid = loginInfo.AccName;

            all.Add("userId", uid);
            all.Add("parameter", MiniJSON.JsonEncode(parameters));

            string str = MiniJSON.JsonEncode(all);
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            bridge.cloudLadderEventWithAction(str);
        }
    }
}
