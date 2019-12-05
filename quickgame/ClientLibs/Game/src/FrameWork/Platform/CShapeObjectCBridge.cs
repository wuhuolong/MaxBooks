using UnityEngine;
using System.Collections;
using xc;


#if UNITY_IPHONE
// 实现 OC 的 调用
// 
using System.Runtime.InteropServices;

public class CShapeObjectCBridge : IBridge
{

    //native apis 

    [DllImport("__Internal")] 
    private static extern void _initXlib(); 
    [DllImport("__Internal")]
    private static extern void _gotoLogin ();
    [DllImport("__Internal")]
    private static extern void _gotoExecute (string info);
    [DllImport("__Internal")]
    private static extern string _getLoginMsg ();
    [DllImport("__Internal")]
    private static extern void _initSDK ();
    [DllImport("__Internal")]
    private static extern void _exitSDK ();
    [DllImport("__Internal")]
    private static extern void _goHome ();
    [DllImport("__Internal")]
    private static extern int _getInitSDKStatuCode();
    [DllImport("__Internal")]
    private static extern int _doAction2SDK(string jsonMsg);
    [DllImport("__Internal")]
    private static extern string _getPhoneModel();
    [DllImport("__Internal")]
    private static extern string _getAppVersion();
    [DllImport("__Internal")]
    private static extern int _getNetType();
    [DllImport("__Internal")]
    private static extern int _getStorageFreeSize();
    [DllImport("__Internal")]
    private static extern int _getAvailMemory();
    [DllImport("__Internal")]
    private static extern string _getTelephonyIMEI();
    [DllImport("__Internal")]
    private static extern string _getOSVersion();
    [DllImport("__Internal")]
    private static extern int _clipboardCopy(string msg);
    [DllImport("__Internal")]
    private static extern string _getClipboardMsg();
    [DllImport("__Internal")]
    private static extern int _doSafari(string url);
    [DllImport("__Internal")]
    private static extern string _getADUUID();
    [DllImport("__Internal")]
    private static extern void _setLoginMsg(); 
    [DllImport("__Internal")]
    private static extern string _getSDKType();
    [DllImport("__Internal")]
    private static extern string _getSDKName();
    [DllImport("__Internal")]
    private static extern string _getGameDocPath();
    [DllImport("__Internal")]
    private static extern string _getGameResPath();
    [DllImport("__Internal")]
    private static extern float _getBattery();
    [DllImport("__Internal")]
    private static extern void _onTDLogin(string accoundID);
    [DllImport("__Internal")]
    private static extern void _onTDCreateRole(string roleName);
    [DllImport("__Internal")] 
    private static extern string _getIPv6(string host);


    [DllImport("__Internal")]
    private extern static void GetSafeAreaImpl(out float x, out float y, out float w, out float h);

    [DllImport("__Internal")]
    private static extern int _getAppId();

    [DllImport("__Internal")]
    private static extern string _getChannelId();

    [DllImport("__Internal")]
    private static extern string _getSubChannelId();

    [DllImport("__Internal")]
    private static extern string _getExtChannelId();

    [DllImport("__Internal")]
    private static extern bool _isOpenBindMobileActivity();

    [DllImport("__Internal")]
    private static extern bool _isBindMobile();

    [DllImport("__Internal")]
    private static extern long _getSdkID();

    [DllImport("__Internal")]
    private static extern string _getSdkUserID();

    [DllImport("__Internal")]
    private static extern string _getLocaleLanguage();

    [DllImport("__Internal")]
    private static extern void _setLocaleLanguage(string lan);

    [DllImport("__Internal")]
    private static extern string _getSDKDeviceID();

    [DllImport("__Internal")]
    private static extern string _getOperator();

    [DllImport("__Internal")]
    private static extern int _isRoot();

    [DllImport("__Internal")]
    private static extern string _getTimeZone();

    [DllImport("__Internal")]
    private static extern int _getAPILevel();

    [DllImport("__Internal")]
    private static extern string _getWfName();

    [DllImport("__Internal")]
    private static extern string _getPhoneIDFV();

    [DllImport("__Internal")]
    private static extern void _cloudLadderEventWithAction(string jsonMsg);

    [DllImport("__Internal")]
    private static extern string _getXinGeAccessId();

    private static CShapeObjectCBridge dbBridge = null;

    // Use this for initialization
    CShapeObjectCBridge()
    {
        Debug.Log("CShapeObjectCBridge init");
    }
    
    public static CShapeObjectCBridge getInstance()
    {
        if (dbBridge == null)
        {
            dbBridge = new CShapeObjectCBridge();  
            _initXlib();
        }
        return dbBridge; 
    }
    public void openWebView(string url){
        GameDebug.Log("openWebView   : " + url);
    }
    public  void login()
    {
        _gotoLogin();
    }
    
    public  int getInitSDKState()
    {
        return _getInitSDKStatuCode(); 
    }
    
    public  void initSDK()
    {
        _initSDK();
    }
    
    public  string getLoginMsg()
    {
        return _getLoginMsg(); 
    }
    
    public  void userCenter()
    {
        _goHome();
    }
    
    public  void pay(string info)
    {
        _gotoExecute(info);
    }
    
    public  int installPatch(string patchInfo)
    {
        return 0;
    }
    
    public  void exitSDK()
    {
        // 玩家发起退出游戏，通知sdk
        SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.EXIT_GAME);

        _exitSDK();
    }
    
    public  void reboot()
    {
       // Debug.Log("ios cannot reboot the game");
        Application.Quit();
    }
    
    // 安装 android 为 安装APK IOS 为 安装IPA
    public  void install(string url)
    {
        // make the url with HTTPS server
        _doSafari(url);
    }
    
    // 设置 登陆信息 可用于切换账号
    public  void setLoginMsg(string loginMsg)
    {
        _setLoginMsg();
    }
    
    // 获取手机型号
    public string getPhoneModel()
    {
        return _getPhoneModel();
    }
    
    // 获取 APK/IPA 程序版本
    public string getAppVersion()
    {
        return _getAppVersion();
    }
    
    // 获取网络类型 

    public int getNetType()
    {
        return _getNetType();
    }
    
    //获取 SDK 类型
    public int getSDKType()
    {
        return System.Int32.Parse(_getSDKType());
    }
    
    // 获取磁盘空间剩余内存大小
    public int getStorageFreeSize()
    {
        return _getStorageFreeSize();
    }
    
    // 获取SDK  名称
    public string getSDKName()
    {
        return _getSDKName();
    }
    
    // 获取剩余空闲内存
    public float getAvailMemory()
    {
        return _getAvailMemory();
    }
    
    // 获取 SD卡路径
    public string getSDPath()
    {
        return "";
    }
    
    // 获取 游戏工作根目录 如 /SDCARD/DBX2/
    public string getGameDocPath()
    {
        return Const.persistentDataPath+ "/";
    }
    
    // 获取 游戏资源目录路径 如 SDCARD/DBX2/Resources
    public string getGameResPath()
    {
        return Const.persistentDataPath + "/";
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
    public void doAction2SDK(string  jsonMsg)
    {
        _doAction2SDK(jsonMsg);
    }
    
    // 获取系统版本
    public string getOSVersion()
    {
        return _getOSVersion();
    }
    
    // 获取CPU 类型
    public string getCPUAPI()
    {
        return "";
    }
    
    // 手机震动
    public void vibrate(int milliseconds)
    {

    }
    
    // 获取系统字体
    public string getSystemTTFs()
    {
        return "";
    }
    
    // 获取手机 IMEI
    public string getPhoneIMEI()
    {
        return _getADUUID();
    }
    
    // 获取 MAC地址 IOS7 doesnot work
    public string getPhoneMAC()
    {
        return _getADUUID();
    }
    
    public string getPhoneIMSI()
    {
        return _getADUUID();
    }

    /// <summary>
    /// 获取广告标识
    /// </summary>
    /// <returns></returns>
    public string GetPhoneIDFA()
    {
        return _getADUUID();
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
        return "";
    }
    //更新读取DB 机器码
    public void updateDBMachineId(string id)
    {
       
    }
    public bool isBridgeEnable() {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
            return true;
        else
            return false;
    }
    public bool checkBackBtnAction()
    {

        return false;
    }
    //获取本地所有运行时的程序
    public string getRunningTasks()
    {
        return "";
    }
    //SDK 注销功能
    public  void logout(){
        exitSDK();
    }
    public void closeLaucherDialog(){}
    public float getBattery(){return _getBattery();}
    //获取更新信息
    public string getUpdateCheckUrl(){
        IBridge bridge = DBOSManager.getOSBridge();
        string url = string.Format("{0}UpdateCheck?platform={1}&app_v={2}&mobile={3}&lib_v=0.0.0&game_mark={4}&cpu=armeabi-v7a&api_ver=1.0&device_mark={5}&imei={6}&res_v=0&res_v=0",
                                   GlobalConfig.GetInstance().CSURLV, "ios_" + bridge.getSDKName(), bridge.getAppVersion(), bridge.getPhoneModel(), GlobalConfig.Instance.GameMark, GlobalConfig.Instance.DeviceMark, bridge.GetPhoneIDFA());
        return url;
    }

    // 获取更新信息，加密版
    public string getUpdateCheckUrlEx()
    {
        IBridge bridge = DBOSManager.getOSBridge();

        var fmt = "platform={0}&app_v={1}&mobile={2}&lib_v=0.0.0&game_mark={3}&cpu=armeabi-v7a&api_ver=1.0&device_mark={4}&imei={5}&res_v=0&res_v=0";
        string sign = string.Format(fmt, "ios_" + bridge.getSDKName(), bridge.getAppVersion(),
            bridge.getPhoneModel(), GlobalConfig.Instance.GameMark, GlobalConfig.Instance.DeviceMark, bridge.GetPhoneIDFA());
        Debug.Log(string.Format("controlServer_oriSign_ZYGXCheck2 = {0}", sign));
        sign = WWW.EscapeURL(Utils.AES.Encode(sign, Const.CS_URL_KEY, Const.CS_URL_IV));

        string url = string.Format("{0}ZYGXCheck2?sign={1}", GlobalConfig.GetInstance().CSURLVEX, sign);
        return url;
    }

    // 请求更新信息
    // 第三个res_v是之前的补丁（res3），第四个res_v是新的散文件0.unity3d的版本（res4）
    // 这里将res_v=0是为了获取当前最新版本的下载地址（版本号一致时服务器不返回下载信息的）
    public string getUpdatePatchUrl()
    {
        IBridge bridge = DBOSManager.getOSBridge();

        int localVersion = 0;
        if (xpatch.XPatchConfig.IsBinPatchPlatform())
            localVersion = xpatch.XPatchManager.Instance.LocalVersion;

        var fmt = "platform={0}&app_v={1}&mobile={2}&lib_v=0.0.0&game_mark={3}&cpu=armeabi-v7a&api_ver=1.0&device_mark={4}&imei={5}&res_v=0&res_v=0&res_v={6}&res_v={7}&server_id={8}";
        string sign = string.Format(fmt, "ios_" + bridge.getSDKName(), bridge.getAppVersion(),
            bridge.getPhoneModel(), GlobalConfig.Instance.GameMark, GlobalConfig.Instance.DeviceMark, bridge.GetPhoneIDFA(),
            localVersion, 0, GrayServerManager.Instance.GetLoginServer());
        Debug.Log(string.Format("controlServer_oriSign_ZYGXCheck2 = {0}", sign));
        sign = WWW.EscapeURL(Utils.AES.Encode(sign, Const.CS_URL_KEY, Const.CS_URL_IV));

        string url = string.Format("{0}ZYGXCheck2?sign={1}", GlobalConfig.GetInstance().CSURLVEX, sign);
        return url;
    }

    public string getBaseVersionJsonStr(){
        return null;
    }
    private string mBaseVersionStr = null;
    public string getExVersionJsonStr()
    {
        if (mBaseVersionStr == null)
        {
            string targetPath = getGameResPath();
            string fileVerPath = targetPath + ResNameMapping.Instance.GetExVersionName(true);
            bool isEXVerExist = false;
            if (System.IO.File.Exists(fileVerPath))
            {
                isEXVerExist = true;
            }
            else
            {
                fileVerPath = Application.dataPath + "/Raw/" + ResNameMapping.Instance.GetExVersionName();
                if (System.IO.File.Exists(fileVerPath))
                {
                    isEXVerExist = true;
                }
            }
            if (isEXVerExist)
            {
                mBaseVersionStr = System.IO.File.ReadAllText(fileVerPath);
            }
        }
        return mBaseVersionStr;
    }
    //获取安装包中的 资源目录
    public string getPackageResourcePath(){
        
        return Application.streamingAssetsPath + Const.BUNDLE_FOLDER + "/";
    }
    public void onTDLogin(string accoundID) {
        GameDebug.Log("onTDLogin : " + accoundID);
        _onTDLogin(accoundID);
    }
    public void onTDCreateRole(string roleName) {
        GameDebug.Log("onTDCreateRole : " + roleName);
        _onTDCreateRole(roleName);    
	}
    public string getIPv6(string host){
        return _getIPv6(host);
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
        
    }

    public void registerPush(string content)
    {
        
    }

    public void setTag(string tag)
    {
        
    }
    public string getAndroidId ()
    {
        return "";
    }
    public string getBrand ()
    {
        return "APPLE";
    }
    public string getManufacturer()
    {
        return "APPLE";
    }
    public string getServiceMark()
    {
        return "";
    }
    public bool hasNotch()
    {
        float x, y, w, h;
        GetSafeAreaImpl(out x, out y, out w, out h);
        Debug.Log("--GetSafeAreaImpl  x:" + x + "y:" + y + "w" + w + "h" + h);
        Debug.Log("--GetSafeAreaImpl  Screen w:" + Screen.width + "Screen h:" + Screen.height);
        return false;
    }

    public Vector2 getNotchSize()
    {
        return Vector2.zero;
    }

    public byte[] loadExternalFileData(string fileName)
    {
        return null;
    }

    public long getStartTimeStamp()
    {
        return 0;
    }

    public void copyTextToClipboard(string text)
    {
        _clipboardCopy(text);
    }

    public int getAppID()
    {
        return _getAppId();
    }

    public string getCurrChannel()
    {
        return _getChannelId();
    }

    public string getSubChannel()
    {
        return _getSubChannelId();
    }

    public string getExtChannel()
    {
        return _getExtChannelId();
    }

    public bool isOpenBindMobileActivity()
    {
        return _isOpenBindMobileActivity();
    }

    public bool isBindMobile()
    {
        return _isBindMobile();
    }

    public long getSdkID()
    {
        return _getSdkID();
    }

    public string getSdkUserID()
    {
        return _getSdkUserID();
    }

    string settingLanguageToIosanguage(string lan)
    {
        if (lan.Equals("ASIAN_ENGLISH"))
        {
            return "en";
        }
        else if (lan.Equals("SIMPLE_CHINESE"))
        {
            return "zh_CN";
        }
        else if (lan.Equals("VIETNAMESE"))
        {
            return "vi";
        }
        else if (lan.Equals("THAI"))
        {
            return "th";
        }
        return "en";
    }

    string iosLanguageToSettingLanguage(string lan)
    {
        if (lan.Equals("en"))
        {
            return "ASIAN_ENGLISH";
        }
        else if (lan.Equals("zh_CN"))
        {
            return "SIMPLE_CHINESE";
        }
        else if (lan.Equals("vi"))
        {
            return "VIETNAMESE";
        }
        else if (lan.Equals("th"))
        {
            return "THAI";
        }
        return "ASIAN_ENGLISH";
    }

    public string getLocaleLanguage()
    {
        GameDebug.LogError("get lan 1 " + PlayerPrefs.GetString("PlayerSetLang", ""));
        return PlayerPrefs.GetString("PlayerSetLang", "");
    }

    public void setLocaleLanguage(string lan)
    {
        _setLocaleLanguage(settingLanguageToIosanguage(lan));

        PlayerPrefs.SetString("PlayerSetLang", lan);
        PlayerPrefs.Save();
    }

    public string getSDKDeviceID()
    {
        return _getSDKDeviceID();
    }

    public string getSDKVersionName()
    {
        return "";
    }

    public string getOperator()
    {
        return _getOperator();
    }

    public int isRoot()
    {
        return _isRoot();
    }

    public string getTimeZone()
    {
        return _getTimeZone();
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
        return _getAPILevel();
    }

    public string getLocalIpAddress()
    {
        return Network.player.ipAddress;
    }

    public string getWfName()
    {
        return _getWfName();
    }

    public string getPhoneIDFV()
    {
        return _getPhoneIDFV();
    }

    // "{'action':'', 'userId':'', 'parameter':''}"
    public void cloudLadderEventWithAction(string jsonMsg)
    {
        _cloudLadderEventWithAction(jsonMsg);
    }

    public string getXgAccessId()
    {
       return _getXinGeAccessId();
    }
    public void log2OSCmd(string tag, string msg){}
}

#else



// 实现 OC 的 调用
// demo
/*
[DllImport("__Internal")] 
private static extern void _copyModelConfigFiles(); 

*/
public class CShapeObjectCBridge : IBridge
{
    private static CShapeObjectCBridge dbBridge = null;

    // Use this for initialization
    CShapeObjectCBridge()
    {
        GameDebug.Log("CShapeObjectCBridge init");
    }
    
    public static CShapeObjectCBridge getInstance()
    {
        if (dbBridge == null)
        {
            dbBridge = new CShapeObjectCBridge();  
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
        return "AppStoreLogin"; 
    }
    
    public  void userCenter()
    {
    }
    
    public  void pay(string info)
    {
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
        return "iPhone";
    }
    
    // 获取 APK/IPA 程序版本
    public string getAppVersion()
    {
        return "0.0.0";
    }
    
    // 获取网络类型 
    /**/
    public int getNetType()
    {
        return 0;
    }
    
    //获取 SDK 类型
    public int getSDKType()
    {
        return 0;
    }
    
    // 获取磁盘空间剩余内存大小
    public int getStorageFreeSize()
    {
        return 0;
    }
    
    // 获取SDK  名称
    public string getSDKName()
    {
        return "AppStore";
    }
    
    // 获取剩余空闲内存
    public float getAvailMemory()
    {
        return 0f;
    }
    
    // 获取 SD卡路径
    public string getSDPath()
    {
        return "";
    }
    
    // 获取 游戏工作根目录 如 /SDCARD/DBX2/
    public string getGameDocPath()
    {
        return "";
    }
    
    // 获取 游戏资源目录路径 如 SDCARD/DBX2/Resources
    public string getGameResPath()
    {
        return "";
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
    public void doAction2SDK(string  msg)
    {
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
        return "";
    }
    //更新读取DB 机器码
    public void updateDBMachineId(string id)
    {
       
    }
    public bool isBridgeEnable() {
        if(Application.platform == RuntimePlatform.IPhonePlayer)
            return true;
        else
            return false;
    }
    public bool checkBackBtnAction()
    {

        return false;
    }
    //获取本地所有运行时的程序
    public string getRunningTasks()
    {
        return "";
    }
    //SDK 注销功能
    public  void logout(){
        exitSDK();
    }
    public void closeLaucherDialog(){}
    public float getBattery(){return 1.0f;}
    //获取安装包中的 资源目录
    public string getPackageResourcePath(){
        
        return Application.streamingAssetsPath + Const.BUNDLE_FOLDER + "/";
    }
    //获取更新信息
    public string getUpdateCheckUrl(){
        IBridge bridge = DBOSManager.getOSBridge();
        string url = string.Format("{0}UpdateCheck?platform=ios_appstore&app_v={1}&mobile={2}&lib_v=0.0.0&game_mark={3}&cpu=armeabi-v7a&api_ver=1.0&device_mark={4}&imei={5}&res_v=0&res_v=0",
                                   GlobalConfig.GetInstance().CSURLV, bridge.getAppVersion(), bridge.getPhoneModel(), GlobalConfig.Instance.GameMark, GlobalConfig.Instance.DeviceMark, bridge.GetPhoneIDFA());
        return url;
    }

    public string getUpdateCheckUrlEx(){ 
        return "";
    }

    public string getUpdatePatchUrl(){
        return "";
    }

    public string getBaseVersionJsonStr(){
        return null;
    }
    public string getExVersionJsonStr(){
        return null;
    }
    public void onTDLogin(string accoundID)
    {
        GameDebug.Log("onTDLogin : " + accoundID);
    }
    public void onTDCreateRole(string roleName)
    {
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
        return "APPLE";
    }
    public string getManufacturer()
    {
        return "APPLE";
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
        return null;
    }

    public long getStartTimeStamp()
    {
        return 0;
    }

    public void copyTextToClipboard(string text)
    {

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
        return "";
    }

    public void setLocaleLanguage(string lan)
    {
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
#endif
