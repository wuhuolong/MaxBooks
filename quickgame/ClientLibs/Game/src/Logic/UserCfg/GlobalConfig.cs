/*----------------------------------------------------------------
// 文件名： GlobalConfig.cs
// 文件功能描述： 全局配置类
//----------------------------------------------------------------*/
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class GlobalConfig : xc.Singleton<GlobalConfig>
    {
        // 是否通过SDK登录
        bool mIsEnterSDK = false;

        // 调试用的参数
        public static string DebugHostURL = "";
        public static string DebugGameMark = "";
        public static int DebugServerType = 0;

#if !TEST_HOST
#if PRE_RELEASE
        //  外网预发布
        static Dictionary<RegionType, string> msHostURLDict = new Dictionary<RegionType, string>()
        {
            [RegionType.CHINA] = "http://gweb.stage.519ame.com:8086/XControl/",
            [RegionType.HKTW] = "http://gweb.stage.519ame.com:8086/XControl/",
            [RegionType.KOREA] = "http://gweb.stage.519ame.com:8086/XControl/",
            [RegionType.SEASIA] = "http://119.28.107.69:8087/XControl/",
        };
#else
        //  外网
        static Dictionary<RegionType, string> msHostURLDict = new Dictionary<RegionType, string>()
        {
            [RegionType.CHINA] = "http://gweb.519ame.com:8086/XControl/",
            [RegionType.HKTW] = "http://jmjy-platform.bbgame.com.tw:8086/XControl/",
            [RegionType.KOREA] = "http://gweb.longtugames.kr:8086/XControl/",
            [RegionType.SEASIA] = "http://gweb.519ame.com:8086/XControl/",
        };
#endif
        public static string HostURL {
            get
            {

#if UNITY_IPHONE
                string controlUrl = ControlServerInfo.Instance.GetConfig();
                if (string.IsNullOrEmpty(controlUrl) == false)
                    return controlUrl;
                else
                    return "http://gweb.519ame.com:8086/XControl/";
#endif

                string url;
                if (msHostURLDict.TryGetValue(Const.Region, out url))
                    return url;
                return "";
            }
        }
#else
#if UNITY_ANDROID || UNITY_IPHONE
        // 内网
        static Dictionary<RegionType, string> msHostURLDict = new Dictionary<RegionType, string>()
        {
            [RegionType.CHINA] = "http://gmt.heiqi.ml:8087/XControl/",
            [RegionType.HKTW] = "http://gmt.heiqi.ml:8087/XControl/",
            [RegionType.KOREA] = "http://150.109.80.201:8087/XControl/",
            [RegionType.SEASIA] = "http://gmt.heiqi.ml:8087/XControl/",
        };
#else
        static Dictionary<RegionType, string> msHostURLDict = new Dictionary<RegionType, string>()
        {
            [RegionType.CHINA] = "http://gmt.heiqi.ml:8087/XControl/",
            [RegionType.HKTW] = "http://gmt.heiqi.ml:8087/XControl/",
            [RegionType.KOREA] = "http://gmt.heiqi.ml:8087/XControl/",
            [RegionType.SEASIA] = "http://gmt.heiqi.ml:8087/XControl/",
        };
#endif
        public static string HostURL
        {
            get
            {
#if TEST_HOST
                if (string.IsNullOrEmpty(DebugHostURL) == false)
                {
                    return DebugHostURL;
                }
#endif

#if UNITY_MOBILE_LOCAL // 性能测试
                return "http://gweb.519ame.com:8086/XControl/";
#else
                string url;
                if (msHostURLDict.TryGetValue(Const.Region, out url))
                    return url;
                return "";
#endif
            }
        }
#endif

        public void ResetHostURL()
        {
            mCSURLV = HostURL + "v2/servlet/";
            mLogURLV = HostURL + "v2/log/";
            mLoginURL = HostURL + "v3/login/";
            mCSURLVEx = HostURL + "v3/servlet/";

            //mLoginNoticeURL = mHostURL + "v3/servlet/";
            mLoginNoticeURL = HostURL + "v2/servlet/";

            mPackCodeURL = HostURL + "packcode/";
            mCommonURL = HostURL + "common/";

            mClientURL = HostURL + "v2/client/";
        }

#if !TEST_HOST
#if UNITY_IPHONE
        const string PlatformTypeKey = "ios";

        string ServerTypeKey
        {
            get
            {
                if (AuditManager.Instance.Open)
                    return "audit_id";
                else
                    return "official_id";
            }
        }
#else
        const string PlatformTypeKey = "android";
        const string ServerTypeKey = "official_id";
#endif

#else
                const string PlatformTypeKey = "android";
        const string ServerTypeKey = "test_id";
#endif

        /// <summary>
        /// 服务器类型
        /// 测试环境：888
        /// 版署 : 3
        /// 公司内部测试 : 5
        /// 安卓线上 : 3
        /// 苹果测试&提审: 101
        /// 苹果线上: 4
        /// 云测试 : 102
        /// UWA性能测试 : 103
        /// 渠道评测包: 203
        /// 应用宝: 202
        /// </summary>
#if !TEST_HOST
    #if UNITY_IPHONE
        int mServerType = 4;
    #else
        int mServerType = 3;
    #endif
#else
        int mServerType = 888;
#endif
        string mCSURLV = HostURL + "v2/servlet/";
        string mLogURLV = HostURL + "v2/log/";
        string mLoginURL = HostURL + "v3/login/";
        string mCSURLVEx = HostURL + "v3/servlet/";

        //const string mLoginNoticeURL = mHostURL + "v3/servlet/";
        string mLoginNoticeURL = HostURL + "v2/servlet/";

        string mPackCodeURL = HostURL + "packcode/";
        string mCommonURL = HostURL + "common/";

        string mClientURL = HostURL + "v2/client/";

        const string mAppStoreGID = "1";

        // 以下变量不能手动修改
        string mAppDocPath;
        string mAppResPath;
        string mPlatformName = "";
        string mSDKName;
        string mDeviceMark;
        int mAppId;    // AppId
        string mChannel;    // 渠道id
        string mSubChannel;    // 二级渠道id
        long mStartTimeStamp;   // 游戏启动时间戳

        /// <summary>
        /// 信鸽的设备id
        /// </summary>
        public string XgDeviceId { get; set; }

#if UNITY_STANDALONE_WIN
        int mBindMobileState = 0; // -1, 不支持；0，支持未绑定；1，支持已绑定；
#else
        int mBindMobileState = -1; 
#endif

        bool mIsDebugMode;

        public class LoginInfoStruct
        {
            public ServerInfo ServerInfo = null;
            public string AccName = ""; // passport
            public string Ticket = "";
            public string Status = "";
            public string Name = ""; // 角色的名字
            public string Level = "";// 角色的等级
            public string RId = ""; // 角色的uuid
            public string Job = ""; // 角色的职业id
            public string ProviderPassport = "";
            public string CreateRoleTime = "";
            public uint RollServer = 0; // 滚服次数
        }

        /// <summary>
        /// 用于服务端的断线重连
        /// </summary>
        public byte[] Token;

        public LoginInfoStruct LoginInfo = null;

        public GlobalConfig()
        {
            LoginInfo = new LoginInfoStruct();

            IBridge bridge = DBOSManager.getDBOSManager().getBridge();

            mDeviceMark = bridge.getDBMachineId();
            mSDKName = bridge.getSDKName();
            mAppDocPath = bridge.getGameDocPath();
            mAppResPath = bridge.getGameResPath();

            mAppId = 0;
            mChannel = "";
            mSubChannel = "";

            // 从SDKName中解析出Channel
            string[] sdkNameStrs = mSDKName.Split('_');
#if UNITY_ANDROID
            if (sdkNameStrs.Length >= 3)
            {
                mAppId = DBTextResource.ParseI_s(sdkNameStrs[1], 0);
                mChannel = sdkNameStrs[2];
            }
#elif UNITY_IPHONE
            if (sdkNameStrs.Length >= 2)
            {
                mAppId = DBTextResource.ParseI_s(sdkNameStrs[1], 0);
            }
#else
#endif

            int appId = bridge.getAppID();
            if (appId > 0)
            {
                mAppId = appId;
            }
            string channel = bridge.getCurrChannel();
            if (string.IsNullOrEmpty(channel) == false)
            {
                mChannel = channel;
            }
            string subChannel = bridge.getSubChannel();
            if (string.IsNullOrEmpty(subChannel) == false)
            {
                mSubChannel = subChannel;
            }

            // 获取游戏启动时间戳，非安卓平台在NewInitSceneLoader那边获取
#if UNITY_ANDROID
            mStartTimeStamp = bridge.getStartTimeStamp();
#endif

            if (bridge.isBridgeEnable() == false)
            {
                mIsEnterSDK = false;
                mPlatformName = "";

#if UNITY_ANDROID
                mPlatformName = "android";
#elif UNITY_IPHONE
                mPlatformName = "ios";
#elif UNITY_EDITOR
                mPlatformName = "editor";
#else
                mPlatformName = "win";
#endif
                return;
            }

#if UNITY_ANDROID
#if HD_RESOURCE // 高清版
                mIsEnterSDK = false;
                Const.IsFullApp = true;
#else
                mIsEnterSDK = true;
#endif

            mPlatformName = "android";
            mDeviceMark = bridge.getDBMachineId();
#elif UNITY_IPHONE
            mIsEnterSDK = true;
            //mIsEnterUpgradeScene = false;
            mPlatformName = "ios";
            // iOS的DeviceMark需要从本地保存的文件读取
            GlobalSettings.GetInstance();
            mDeviceMark = UserPlayerPrefs.Instance.GetString("DeviceMark", "");

#if FULL_APP
                mIsEnterSDK = true;
                Const.IsFullApp = true;
#else
                mIsEnterSDK = true;
#endif


#elif UNITY_STANDALONE_WIN
            mPlatformName = "win";
#else
            mPlatformName = "android";
            mDeviceMark = bridge.getDBMachineId();
#endif

            mIsDebugMode = false;

#if TEST_HOST || CMPT_RELEASE
            //通过SDK登录
            mIsEnterSDK = false;
#if UNITY_ANDROID || UNITY_IPHONE
            mIsEnterSDK = false;
#endif
#endif
        }

        public void ResetLoginInfo()
        {
            LoginInfo.ServerInfo = null;
            LoginInfo.AccName = string.Empty;
            LoginInfo.Ticket = string.Empty;
            LoginInfo.Status = string.Empty;
            LoginInfo.Name = string.Empty;
            LoginInfo.Level = string.Empty;
            LoginInfo.RId = string.Empty;
            LoginInfo.Job = string.Empty;
            LoginInfo.ProviderPassport = string.Empty;
            LoginInfo.CreateRoleTime = string.Empty;
        }

        public string CSURLV
        {
            get { return mCSURLV; }
        }

        public string LogURLV
        {
            get { return mLogURLV; }
        }

        public string LoginURL
        {
            get { return mLoginURL; }
        }

        public string CSURLVEX
        {
            get { return mCSURLVEx; }
        }

        public string LoginNoticeUrl
        {
            get {
                GlobalConfig globalConfig = GlobalConfig.GetInstance();
                //return string.Format("{0}getLoginNoticet?game_mark={1}&provider={2}&os={3}", mLoginNoticeURL, GameMark, globalConfig.SDKName, globalConfig.PlatformName);
                string platform = "0";

#if UNITY_ANDROID
                platform = "android";
#endif

#if UNITY_IPHONE
                platform = "ios";
#endif

                return string.Format("{0}getNoticeData?game_mark={1}&account={2}&type=&platform={3}&provider={4}&sub_chn={5}", mLoginNoticeURL, GameMark, 23339, platform, globalConfig.SDKName, globalConfig.SubChannel);
            }
        }

        public string PackCodeURL
        {
            get
            {
                return mPackCodeURL;
            }
        }

        public string CommonURL
        {
            get
            {
                return mCommonURL;
            }
        }

        public string PhoneBindURL
        {
            get
            {
                return mCSURLV;
            }
        }

        public string ClientURL
        {
            get
            {
                return mClientURL;
            }
        }

        public string GameMark
        {
            get
            {
#if TEST_HOST
                if (string.IsNullOrEmpty(DebugGameMark) == false)
                {
                    return DebugGameMark;
                }
#endif

#if !TEST_HOST // 正式发布环境
#if HD_RESOURCE || CMPT_RELEASE // 目前用在线上版预发布的ci
            if (Const.Region == RegionType.KOREA)
                return "zl_kr";
            return "zl_cehua";
#elif GAMEMARK_PLUS // 目前用在最新线上版的ci
            if (Const.Region == RegionType.HKTW)
                return "zl_hktw";
            else if (Const.Region == RegionType.KOREA)
                return "zl_kr";
            else if (Const.Region == RegionType.SEASIA)
                return "zl_sea";

#if UNITY_IPHONE

            if (string.IsNullOrEmpty(AuditManager.Instance.game_mark) == false)
                return AuditManager.Instance.game_mark;
            else
                return "zl_plus";

#endif

            return "zl_plus";
#else // 目前用在1.8.0线上版的ci
            if (Const.Region == RegionType.HKTW)
                return "zl_hktw";
            else if (Const.Region == RegionType.KOREA)
                return "zl_kr";
            else if (Const.Region == RegionType.SEASIA)
                return "zl";
            return "zl";
#endif
#else //　测试发布环境
#if UNITY_ANDROID || UNITY_IPHONE
                if (Const.Region == RegionType.KOREA)
                    return "zl_kr";
#endif
                return "zl_cehua";
#endif
            }
        }

        /// <summary>
        /// 是否通过sdk来进行登陆
        /// </summary>
        public bool IsEnterSDK
        {
            get { return mIsEnterSDK; }
        }

        public int ServerType
        {
            get 
            {
#if TEST_HOST
                if (DebugServerType != 0)
                {
                    return DebugServerType;
                }
#endif

#if PERFORMANCE_TEST || CMPT_RELEASE || UNITY_MOBILE_LOCAL // 性能测试和兼容测试
                return 103;
#elif HD_RESOURCE // 线上版预发布整包
                if (Const.Region == RegionType.KOREA)
                {
                    return 666;
                }
                return 5;
#endif

                int type = 0;
                
                var db_server_type = DBManager.Instance.GetDB<DBServerType> ();
                if (db_server_type != null)
                {
                    var service_mark = DBOSManager.getDBOSManager().getBridge().getServiceMark();
                    // 如果ServiceMark不为空则返回ServiceMark
                    if (string.IsNullOrEmpty(service_mark) == false)
                    {
                        int.TryParse(service_mark, out type);
                    }
                    else
                    {
                        var sdk_name = DBOSManager.getDBOSManager().getBridge().getSDKName();
                        type = db_server_type.GetServerType(sdk_name, ServerTypeKey);
                        if (type == 0)
                            type = db_server_type.GetServerType(PlatformTypeKey, ServerTypeKey);
                    }
                }
                else
                    GameDebug.LogError ("db_server_type is null.");

                if (type == 0)
                    return mServerType;
                else
                    return type;
            }
        }

        /// <summary>
        /// 是否取消把参数发给SDK
        /// </summary>
        public bool IsDisableDoAction2SDK
        {
            get
            {
#if PERFORMANCE_TEST || CMPT_RELEASE
                return true;
#endif
                int type = 0;

                var db_server_type = DBManager.Instance.GetDB<DBServerType>();
                if (db_server_type != null)
                {
                    var sdk_name = DBOSManager.getDBOSManager().getBridge().getSDKName();
                    type = db_server_type.GetServerType(sdk_name, ServerTypeKey);
                    return type == 5;   // 服务器标识为5（内部体验）则不把参数发给SDK
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsPostCloudLadderAction
        {
            get
            {
#if UNITY_IPHONE || UNITY_ANDROID
                return true;
#else
                return false;
#endif
            }
        }

        public string AppDocPath
        {
            get { return mAppDocPath; }
        }

        public string AppResPath
        {
            get { return mAppResPath; }
        }

        public string PlatformName
        {
            get { return mPlatformName; }
        }

        public string SDKName
        {
            get { return mSDKName; }
        }

        public int AppId
        {
            get { return mAppId; }
        }

        public string Channel
        {
            get { return mChannel; }
        }

        public string SubChannel
        {
            get { return mSubChannel; }
        }

        public long StartTimeStamp
        {
            get { return mStartTimeStamp; }
            set { mStartTimeStamp = value; }
        }

        public string DeviceMark
        {
            get { return mDeviceMark; }
            set { mDeviceMark = value; }
        }

        public bool IsDebugMode
        {
            get { return mIsDebugMode; }
            set { mIsDebugMode = value; }
        }

        public string AppStoreGID
        {
            get
            {
                return mAppStoreGID;
            }
        }

        public int BindMobileState
        {
            get { return mBindMobileState; }
            set { mBindMobileState = value; }
        }

        public static string DBFile
        {
            get
            {
                return "data";
            }
        }

        public static string GoodsNameDBFile
        {
            get
            {
                return "goods_name";
            }
        }
    }
}
