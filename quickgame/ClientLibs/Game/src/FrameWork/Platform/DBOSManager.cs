using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using xc;
using gcloud_voice;
public class DBOSManager
{
    private IBridge bridge = null ;
    private ISpeechManager speech= null;
    private static DBOSManager osManager = null ;

    public string Res1Version
    {
        get
        {
            return mRes1Version;
        }
    }

    public string Res2Version
    {
        get
        {
            return mRes2Version;
        }
    }

    /// <summary>
    /// 资源组1的版本号
    /// </summary>
    private string mRes1Version = "0";

    /// <summary>
    /// 资源组2的版本号
    /// </summary>
    private string mRes2Version = "0";

    public DBOSManager()
    {
        bridge = CShapeWinBridge.getInstance();

        #if !UNITY_MOBILE_LOCAL
        #if UNITY_ANDROID
        bridge = CShapeJavaBridge.getInstance();
        
        //BuglyAgent.PrintLog(LogSeverity.LogWarning, "Init bugly sdk done");
        #elif UNITY_IPHONE
                bridge = CShapeObjectCBridge.getInstance();
        #endif
        #endif
    }

    public static DBOSManager getDBOSManager()
    {
        if (osManager == null)
        {
            osManager = new DBOSManager();
        }
        return osManager; 
    }

    public IBridge getBridge()
    {
        return bridge; 
    }

    public ISpeechManager getSpeechManager(){

        return speech;

    }

    public static IBridge getOSBridge()
    {
        return getDBOSManager().getBridge();
    }

    //上传文件 参数为文件路径
    public static int uploadRecordFile(string filePath){
        int ret = 0;
        return ret;

    }

    //下载文件 参数为文件路径
    public static int downLoadRecordFile(string filePath){
        int ret = 0;
        return ret;
    }
    public static void writeCSDmpToFile(string text){
        string logDir = GlobalConfig.GetInstance().AppResPath + "log";
        if(!Directory.Exists(logDir))
            Directory.CreateDirectory(logDir);

        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);  
        String time = Convert.ToInt64(ts.TotalSeconds).ToString();
        StreamWriter streamWriter = new StreamWriter(GlobalConfig.GetInstance().AppResPath + "log/" + time + ".sdmp", false);
        streamWriter.Write(text);
        streamWriter.Close();
    }

    public static void writeLuaDmpToFile(string text){
        string logDir = GlobalConfig.GetInstance().AppResPath + "log";
        if(!Directory.Exists(logDir))
            Directory.CreateDirectory(logDir);

        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);  
        String time = Convert.ToInt64(ts.TotalSeconds).ToString();
        StreamWriter streamWriter = new StreamWriter(GlobalConfig.GetInstance().AppResPath + "log/" + time + ".ldmp", false);
        streamWriter.Write(text);
        streamWriter.Close();
    }

    /// <summary>
    /// 初始化bugly
    /// </summary>
    public void InitBuglySDK()
    {
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_IOS
        // TODO NOT Required. Set the crash reporter type and log to report
        // BuglyAgent.ConfigCrashReporter (1, 2);

        // TODO NOT Required. Enable debug log print, please set false for release version
#if DEBUG
        BuglyAgent.ConfigDebugMode(true);
#endif
        //BuglyAgent.ConfigDebugMode(true);
        // TODO NOT Required. Register log callback with 'BuglyAgent.LogCallbackDelegate' to replace the 'Application.RegisterLogCallback(Application.LogCallback)'
        // BuglyAgent.RegisterLogCallback (CallbackDelegate.Instance.OnApplicationLogCallbackHandler);

        // BuglyAgent.ConfigDefault ("Bugly", null, "ronnie", 0);

#if UNITY_IPHONE || UNITY_IOS
        if (Const.Region == RegionType.CHINA)
        {
            var channel = string.Format("{0}_{1}", GlobalConfig.Instance.Channel, GlobalConfig.Instance.SubChannel);

            BuglyAgent.ConfigDefault(channel, null, null, 0);
            BuglyAgent.InitWithAppId ("d47e3e83c9");
        }
        else if (Const.Region == RegionType.HKTW)
            BuglyAgent.InitWithAppId("af2d9108c7");
        else if (Const.Region == RegionType.KOREA)
            BuglyAgent.InitWithAppId("c5ab48ff08");
        else if (Const.Region == RegionType.SEASIA)
            BuglyAgent.InitWithAppId("9baaf461f1");
        // iOS工程启动初始化
#elif UNITY_ANDROID
        // BuglyAgent.InitWithAppId ("900036622");
        // android工程启动初始化
#endif

        //BuglyAgent.SetUserId();
        // TODO Required. If you do not need call 'InitWithAppId(string)' to initialize the sdk(may be you has initialized the sdk it associated Android or iOS project),
        // please call this method to enable c# exception handler only.
        BuglyAgent.EnableExceptionHandler();

        // If you need to report extra data with exception, you can set the extra handler
        //BuglyAgent.SetLogCallbackExtrasHandler(LogCallbackExtrasHandler);

        

        BuglyAgent.ConfigAutoReportLogLevel(LogSeverity.LogException);
        BuglyAgent.PrintLog(LogSeverity.LogInfo, "Init the bugly sdk");
        LogExtraInfo();
#endif
    }

    /// <summary>
    /// 设置玩家id
    /// </summary>
    /// <param name="user_id"></param>
    public void SetUserId(string user_id)
    {
        BuglyAgent.SetUserId(user_id);
    }

    // Extra data handler to packet data and report them with exception.
    // Please do not do hard work in this handler 
    void LogExtraInfo()
    {

        Dictionary<string, string> extras = new Dictionary<string, string>();

        //----设备信息------
        extras.Add("solution", string.Format("{0}x{1}", Screen.width, Screen.height));
        extras.Add("deviceModel", SystemInfo.deviceModel);
        extras.Add("deviceName", SystemInfo.deviceName);
        extras.Add("deviceType", SystemInfo.deviceType.ToString());
        extras.Add("deviceUId", SystemInfo.deviceUniqueIdentifier);
        //系统内存大小
        extras.Add("systemMemorySize", SystemInfo.systemMemorySize.ToString());

        //----显卡信息------
        //显卡设备标识ID
        extras.Add("gDeviceID", SystemInfo.graphicsDeviceID.ToString());
        //显卡名称
        extras.Add("gDeviceName", SystemInfo.graphicsDeviceName);
        //显卡类型
        extras.Add("gDeviceType", SystemInfo.graphicsDeviceType.ToString());
        //显卡供应商
        extras.Add("gDeviceVendor", SystemInfo.graphicsDeviceVendor);
        //显卡供应唯一ID
        extras.Add("gDeviceVendorID", SystemInfo.graphicsDeviceVendorID.ToString());
        //显卡版本号
        extras.Add("gDeviceVersion", SystemInfo.graphicsDeviceVersion);
        //显卡内存大小
        extras.Add("gMemorySize", SystemInfo.graphicsMemorySize.ToString());
        extras.Add("gShaderLevel", SystemInfo.graphicsShaderLevel.ToString());

        //----CPU信息------
        //CPU核数
        extras.Add("processorCount", SystemInfo.processorCount.ToString());
        //CPU主频
        extras.Add("processorFrequency", SystemInfo.processorFrequency.ToString());
        //CPU类型
        extras.Add("processorType", SystemInfo.processorType);

        //extras.Add("graphicLevel", QualitySetting.GraphicLevel.ToString());
       
        var bridge = DBOSManager.getDBOSManager().getBridge();
        string res1_version = "0";
        string res2_version = "0";
        if (bridge != null)
        {
            // 解析res1
            var version_str = bridge.getBaseVersionJsonStr();
            if (string.IsNullOrEmpty(version_str) == false)
            {
                Hashtable jsonObject = MiniJSON.JsonDecode(version_str) as Hashtable;
                if (jsonObject != null)
                    res1_version = (string)jsonObject["version"];
            }

            // 解析res2

#if UNITY_IPHONE
            version_str = bridge.getExVersionJsonStr();
            
            if (string.IsNullOrEmpty(version_str) == false)
            {
                Debug.Log("current res2 version_str : " + version_str);
                Hashtable verTabel = MiniJSON.JsonDecode(version_str) as Hashtable;
                if (verTabel != null)
                {
                    res2_version = verTabel["ver"].ToString();
                }
                Debug.Log("current res2 res2_version:" + res2_version);
            }
            else
            {
                Debug.Log("current res2 version_str is null");
            }
#else
            version_str = bridge.getExVersionJsonStr();
            if (string.IsNullOrEmpty(version_str) == false)
            {
                ArrayList version_list = MiniJSON.JsonDecode(version_str) as ArrayList;

                if (version_list != null && version_list.Count > 0)
                {
                    Hashtable version_table = version_list[0] as Hashtable;
                    if (version_table != null)
                    {
                        res2_version = string.Format("{0}", (System.Int32)(System.Double)version_table["version"]);
                    }
                }
            }
#endif




        }

        //----版本信息------
        extras.Add("res1_version", res1_version);
        extras.Add("res2_version", res2_version);
        mRes1Version = res1_version;
        mRes2Version = res2_version;

        //----场景等附加信息------
        var active_scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        if (active_scene != null)
        {
            extras.Add("sceneName", active_scene.name);
        }
        else
            extras.Add("sceneName", "unknown");
        
        foreach (var k in extras.Keys)
        {
            var info = extras[k];
            BuglyAgent.PrintLog(LogSeverity.LogInfo, string.Format("{0}:{1}", k, info));
        }
    }


}
