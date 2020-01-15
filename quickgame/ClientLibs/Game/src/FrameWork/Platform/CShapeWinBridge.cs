using UnityEngine;
using System.Collections;
using xc;

// win下IBridge的实现
// demo
/*
[DllImport("__Internal")] 
private static extern void _copyModelConfigFiles(); 

*/
public class CShapeWinBridge : IBridge
{
    private static CShapeWinBridge dbBridge = null;

    // Use this for initialization
    CShapeWinBridge()
    {
        GameDebug.Log("CShapeWinBridge init");
    }
    
    public static CShapeWinBridge getInstance()
    {
        if (dbBridge == null)
        {
            dbBridge = new CShapeWinBridge();  
        }
        return dbBridge; 
    }
    
    public  void login()
    {
    }
    
    public  int getInitSDKState()
    {
        return 1; 
    }
    
    public  void initSDK()
    {
    }
    
    public  string getLoginMsg()
    {
        //return "LoginMsg";
        return "{\"version\":\"2\",\"os\":\"2\",\"sid\":\"sst1gamec40cbc204f2647fe908b030ca4f87d6e192614\",\"serverid\":\"0\",\"_LoginAction_\":\"uc\",\"gameid\":\"560229\"}";
    }
    
    public  void userCenter()
    {
        GameDebug.LogError("userCenter");
    }
    
    public  void pay(string payInfo)
    {
        GameDebug.Log("Pay info: " + payInfo);
    }
    
    public  int installPatch(string patchInfo)
    {
        return 0;
    }
    
    public  void exitSDK()
    {
    }
    
    public  void reboot()
    {
    }
    
    // 安装 android 为 安装APK IOS 为 安装IPA
    public  void install(string installFilePath)
    {
    }
    
    // 设置 登陆信息 可用于切换账号
    public  void setLoginMsg(string loginMsg)
    {
    }
    
    // 获取手机型号
    public string getPhoneModel()
    {
        return "Windows";
    }
    
    // 获取 APK/IPA 程序版本
    public string getAppVersion()
    {
        return "0.0.1";
    }
    
    // 获取网络类型 
    /**/
    public int getNetType()
    {
        return 1;
    }
    
    //获取 SDK 类型
    public int getSDKType()
    {
        return 0;
    }
    
    // 获取磁盘空间剩余内存大小
    public int getStorageFreeSize()
    {
        return 1024;
    }
    
    // 获取SDK  名称
    public string getSDKName()
    {
        return "undefined";
    }
    
    // 获取剩余空闲内存
    public float getAvailMemory()
    {
        return 0f;
    }
    
    // 获取 SD卡路径
    public string getSDPath()
    {
        return getGameDocPath();
    }
    
    // 获取 游戏工作根目录 如 /SDCARD/DBX2/
    public string getGameDocPath()
    {
        string path = Const.persistentDataPath + "/doc/";
        if(!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
        return path;
    }
    
    // 获取 游戏资源目录路径 如 SDCARD/DBX2/Resources
    public string getGameResPath()
    {
#if UNITY_IPHONE && PROFILER
        return Const.persistentDataPath + "/";
#else
        #if UNITY_MOBILE_LOCAL
        string path = Const.persistentDataPath+"/";
        #else
        string path = getGameDocPath() + "Resources/";
        #endif

        if(!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
        return path;
#endif
    }

    // 获取 
    public string getGameLibPath()
    {
        return "";
    }
    
    // 游戏崩溃之后 需要做的 log收集 工作
    public void doNativeCrash()
    {
    }

    // 此接口参数 为 //{"action":"","parameter":""} 
    // 调用 一些比较特殊 没有公共话的接口
    public void doAction2SDK(string msg)
    {
        GameDebug.Log(msg);
        Hashtable hashtable = MiniJSON.JsonDecode(msg) as Hashtable;
        if (hashtable != null)
        {
            string action = string.Empty;
            if (hashtable["action"] != null)
            {
                action = hashtable["action"].ToString();
                if (action == "bind")
                {
                    GlobalConfig.Instance.BindMobileState = 1;
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SDK_BIND_MOBILE_SUC, null);
                }
            }
        }
    }
            // 获取系统版本
    public string getOSVersion()
    {
        return "";
    }
    
    // 获取CPU 类型
    public string getCPUAPI()
    {
        return "";
    }
    
    // 手机震动
    public void vibrate(int milliseconds)
    {
        GameDebug.Log("vibrate: " + milliseconds);
    }
    
    // 获取系统字体
    public string getSystemTTFs()
    {
        return "";
    }
    
    // 获取手机 IMEI
    public string getPhoneIMEI()
    {
        return "";
    }
    
    // 获取 MAC地址
    public string getPhoneMAC()
    {
        return "";
    }
    
    public string getPhoneIMSI()
    {
        return "";
    }

    /// <summary>
    /// 获取广告标识
    /// </summary>
    /// <returns></returns>
    public string GetPhoneIDFA()
    {
        return "";
    }

    //删除原有 资源文件  
    //重命名  资源文件
    public void installU3DAssets(string needDelFile, string needRenameFile)
    {
    }
    
    //拉取 zip文件的 adler32 指纹 这是一个耗时的操作
    public string getZipAdler32(string file)
    {
        return "";
    }
    //本地读取DB 机器码
    public string getDBMachineId()
    {
        return "WinMachineId";
    }
    //更新读取DB 机器码
    public void updateDBMachineId(string id)
    {
        
    }
    public bool isBridgeEnable()
    {
        return false;
    }
    public bool checkBackBtnAction() {

        return false;
    }
    //获取本地所有运行时的程序
    public string getRunningTasks()
    {
        return "";
    }
    //SDK 注销功能
    public  void logout(){
        xc.MainGame.HeartBehavior.SystemMessage("FinishedLogout");
    }
    public void closeLaucherDialog(){

    }
    public float getBattery(){return 1.0f;}
    //获取安装包中的 资源目录
    public string getPackageResourcePath(){
        
        return Application.streamingAssetsPath + Const.BUNDLE_FOLDER + "/";
    }
    //获取更新信息
    public string getUpdateCheckUrl(){
        return "http://db.game2.test5.9game.cn/XControl/v2/servlet/UpdateCheck?platform=android_uc&app_v=1.6.3&mobile=TianTian&lib_v=0.0.0&marked=268744135649712&cpu=armeabi-v7a&game_mark=x7-daily&device_mark=a262e986-7a46-49ec-b2ce-596288fad3b8&brand=TTAndroid&time_stamp=1457424640692&res_v=999999&res_v=999999";
    }

    public string getUpdateCheckUrlEx() {
        return ""; 
    }
    public string getUpdatePatchUrl()
    {
        return "";
    }

    public string getBaseVersionJsonStr(){
        return "{ \"size\":\"11029817\",\"version\":\"42\",\"md5\":\"8DF3BE2CEB85E52682D631BAEB91C829\"}";
    }
    public string getExVersionJsonStr(){
        return "[{\"adler32\":\"adler32\",\"index\":1,\"isZip\":false,\"md5\":\"669281141C195E1D6A0928D41F4BAD05\",\"size\":2204330,\"target\":\"x_cf.uass\",\"version\":42}]";
    }
    public void onTDLogin(string accoundID) {
        GameDebug.Log("onTDLogin : " + accoundID);
    }
    public void onTDCreateRole(string roleName) {
        GameDebug.Log("onTDCreateRole : " + roleName);
    }
    public string getIPv6(string host){
        return null;
    }
    public void openWebView(string url){
        GameDebug.Log("openWebView   : " + url);
    }
    public string getNotifyURL(){
        return null;
    }
    public void setNotifyURL(string url){
        
    }

    public void registerFCM()
    {
    }

    public void registerPush()
    {
        GameDebug.Log("int register Push ");
    }
    public void setTag(string tag)
    {
        GameDebug.Log("setTag   : " + tag);
    }
    public void registerPush(string account)
    {
        GameDebug.Log("registerPush & account   : " + account);
    }
    public string getAndroidId()
    {
        return "";
    }
    public string getBrand()
    {
        return "";
    }
    public string getManufacturer()
    {
        return "";
    }
    public string getServiceMark()
    {
        return "";
    }

    public bool hasNotch()
    {
        return false;
    }

    public Vector2 getNotchSize()
    {
        return Vector2.zero;
    }

    public byte[] loadExternalFileData(string fileName)
    {
        System.IO.FileStream fs = null;
        try
        {
            string path = Application.dataPath + "/../" + fileName;
            if (System.IO.File.Exists(path) == true)
            {
                fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);

                return buffer;
            }
            else
            {
                return null;
            }
        }
        catch (System.Exception ex)
        {
            return null;
        }
        finally
        {
            if (fs != null)
            {
                //关闭资源
                fs.Close();
                fs.Dispose();
                fs = null;
            }
        }
    }

    public long getStartTimeStamp()
    {
        return 0;
    }

    public void copyTextToClipboard(string text)
    {
        TextEditor t = new TextEditor();
        t.text = text;
        t.OnFocus();
        t.Copy();
    }

    public int getAppID()
    {
        return 0;
    }

    public string getCurrChannel()
    {
        return "";
    }

    public string getSubChannel()
    {
        return "";
    }

    public string getExtChannel()
    {
        return "";
    }


    public bool isOpenBindMobileActivity()
    {
        return false;
    }

    public bool isBindMobile()
    {
        return false;
    }

    public long getSdkID()
    {
        return 0;
    }

    public string getSdkUserID()
    {
        return "";
    }

    public string getLocaleLanguage()
    {
        string playerSetLang = PlayerPrefs.GetString("PlayerSetLang", "");
        return playerSetLang;
    }

    public void setLocaleLanguage(string lan)
    {
        PlayerPrefs.SetString("PlayerSetLang", lan);
        PlayerPrefs.Save();
    }

    public string getSDKDeviceID()
    {
        return "";
    }

    public string getSDKVersionName()
    {
        return "";
    }

    public string getOperator()
    {
        return "";
    }

    public int isRoot()
    {
        return 0;
    }

    public string getTimeZone()
    {
        return "";
    }

    public int getWindowWidth()
    {
        return Screen.width;
    }

    public int getWindowHeigh()
    {
        return Screen.height;
    }

    public int getAPILevel()
    {
        return 0;
    }

    public string getLocalIpAddress()
    {
        return Network.player.ipAddress;
    }

    public string getWfName()
    {
        return "";
    }

    public string getPhoneIDFV()
    {
        return "";
    }

    public void cloudLadderEventWithAction(string msg)
    {
    }

    public string getXgAccessId()
    {
        return "";
    }
    public void log2OSCmd(string tag, string msg) { }
}
