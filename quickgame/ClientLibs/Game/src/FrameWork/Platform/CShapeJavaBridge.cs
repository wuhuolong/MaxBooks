using UnityEngine;
using System.Collections;
using System;

#if !UNITY_IPHONE

//实现 对JAVA的调用
public class CShapeJavaBridge : IBridge
{
    /*

        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity")
     */
    private static CShapeJavaBridge dbBridge = null ;
    private string JAVA_CLASS_NAME = "com.ucweb.db.xlib.bridge.GameBridge" ;
    private string JAVA_CLASS_NAME_NEW_BRIDGE = "com.huiwan.bridge.BackDoor";
    private string JAVA_PUSH_CLASS_NAME = "com.huiwan.push.PushBridge";
    private string JAVA_CLIPBOARD_CLASS_NAME = "com.ucweb.db.xlib.bridge.DBClipboard";
    private string JAVA_LOG_CLASS_NAME = "android.util.Log";
    // Use this for initialization
    CShapeJavaBridge()
    {
        GameDebug.Log("CShapeJavaBridge init");
    }

    public static CShapeJavaBridge getInstance()
    {
        if (dbBridge == null)
        {
            dbBridge = new CShapeJavaBridge();  
        }
        return dbBridge; 
    }

    ~CShapeJavaBridge()
    {

    }

    public bool isBridgeEnable()
    {
        bool isEnable = true;
        try
        {
            using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
            {
                javaClass.CallStatic<string>("getAppVersionJNI");
            }
        }
        catch (Exception e ) {
            if(!Application.isEditor)
                GameDebug.LogError("CShapeJavaBridge is  no enable!");

            isEnable = false;
        }
        return isEnable;
    }
    public  void login()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {  
            if (javaClass.GetRawClass() != IntPtr.Zero)
                javaClass.CallStatic("dbGotoLoginJNI");
        }
    }

    public  int getInitSDKState()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {  
            if (javaClass.GetRawClass() != IntPtr.Zero)
            {
                var ret = javaClass.CallStatic<int>("dbGetInitSDKState");
                return ret; 
            }
            else
            {
                Debug.LogError(JAVA_CLASS_NAME +" class is null");
                return 0;
            }
        }
    }

    public  void initSDK()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            if (javaClass.GetRawClass() != IntPtr.Zero)
                javaClass.CallStatic("dbGotoInitSDKJNI");
        }
    }

    public  string getLoginMsg()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            var loginMsg = javaClass.CallStatic<string>("getLoginMsgJNI");
            return loginMsg;
        }
    }

    public  void userCenter()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            javaClass.CallStatic("dbGotoHomeJNI");
        }
    }

    public  void pay(string payInfo)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME_NEW_BRIDGE))
        {
            javaClass.CallStatic("pay", payInfo);
        }
    }

    public  int installPatch(string patchInfo)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            return javaClass.CallStatic<int>("installPatch", patchInfo);
        }
    }

    public  void exitSDK()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            javaClass.CallStatic("dbGotoExitSDKJNI");
        }
    }

    public  void reboot()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            javaClass.CallStatic("dbRebootJNI");
        }
    }

    // 安装 android 为 安装APK IOS 为 安装IPA
    public  void install(string installFilePath)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            javaClass.CallStatic("dbInstallAPKJNI",installFilePath);
        }
    }

    // 设置 登陆信息 可用于切换账号
    public  void setLoginMsg(string loginMsg)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            javaClass.CallStatic("setLoginMsgJNI", loginMsg);
        }
    }

    // 获取手机型号
    public  string getPhoneModel()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            var ret = javaClass.CallStatic<string>("getPhoneModelJNI");
            if(string.IsNullOrEmpty(ret))
                ret = "0";

            return ret;
        }
    }

    // 获取 APK/IPA 程序版本
    public  string getAppVersion()
    {
        if(Application.isEditor)
            return "";
        else
        {
            using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
            {
                var ret = javaClass.CallStatic<string>("getAppVersionJNI");
                return ret;
            }
        }
    }

    // 获取网络类型 
    /**/
    public  int getNetType()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<int>("getNetTypeJNI");
        return ret;
        }
    }

    //获取 SDK 类型
    public  int getSDKType()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<int>("getSDKTypeJNI");
        return ret;
        }
    }

    // 获取磁盘空间剩余内存大小
    public  int getStorageFreeSize()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<int>("getStorageFreeSizeJNI");
        return ret;
        }
    }

    // 获取SDK  名称
    public  string getSDKName()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getSDKNameJNI");
        return ret;
        }
    }

    // 获取剩余空闲内存
    public  float getAvailMemory()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<float>("getAvailMemoryJNI");
        return ret;
        }
    }

    // 获取 SD卡路径
    public  string getSDPath()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getSDPathJNI");
        return ret + "/";
        }
    }

    // 获取 游戏工作根目录 如 /SDCARD/DBX2/
    public  string getGameDocPath()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getGameDocPathJNI");
        return ret;
        }
    }

    // 获取 游戏资源目录路径 如 SDCARD/DBX2/Resources
    public  string getGameResPath()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getGameResPathJNI");
        return ret;
        }
    }

    // 获取 
    public  string getGameLibPath()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getGameLibPathJNI");
        return ret;
        }
    }

    // 游戏崩溃之后 需要做的 log收集 工作
    public  void doNativeCrash()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        javaClass.CallStatic("doNativeCrash4JNI");
        }
    }

    // 此接口参数 为 //{"action":"","parameter":""} 
    // 调用 一些比较特殊 没有公共话的接口
    public  void doAction2SDK(string  msg)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        javaClass.CallStatic("doAction2SDKJNI", msg);
        }
    }

    // 获取系统版本
    public  string getOSVersion()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getOSVersion");
        return ret;
        }
    }

    // 获取CPU 类型
    public  string getCPUAPI()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getCPUAPI");
        return ret;
        }
    }

    // 手机震动
    public  void vibrate(int milliseconds)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        javaClass.CallStatic("doAction2SDKJNI", milliseconds);
        }
    }

    // 获取系统字体
    public  string getSystemTTFs()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            var ret = javaClass.CallStatic<string>("getSystemTTFs");
            return ret;
        }
    }

    // 获取手机 IMEI
    public  string getPhoneIMEI()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            var ret = javaClass.CallStatic<string>("getPhoneIMEI");
            if(string.IsNullOrEmpty(ret))
                ret = "0";

            return ret;
        }
    }

    // 获取 MAC地址
    public  string getPhoneMAC()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            var ret = javaClass.CallStatic<string>("getPhoneMAC");
            if(string.IsNullOrEmpty(ret))
                ret = "0";

            return ret;
        }
    }
    
    public string getPhoneIMSI()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            var ret = javaClass.CallStatic<string>("getPhoneIMSI");
            if(string.IsNullOrEmpty(ret))
                ret = "0";

            return ret;
        }
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
    public  void installU3DAssets(string needDelFile, string needRenameFile)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        javaClass.CallStatic("installU3DAssets", needDelFile, needRenameFile);
        }
    }

    //拉取 zip文件的 adler32 指纹 这是一个耗时的操作
    public string getZipAdler32(string file)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getZipAdler32", file);
        return ret;
        }
    }
    //本地读取DB 机器码
    public string getDBMachineId()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getDBMachineId");
        return ret;
        }
    }
    //更新读取DB 机器码
    public void updateDBMachineId(string id)
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        javaClass.CallStatic("updateDBMachineId", id);
        }
    }
    public bool checkBackBtnAction()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {

        bool ret = javaClass.CallStatic<bool>("isNeedBackBtnAction");
        if (ret)
        {
            javaClass.CallStatic("doBackBtnAction");
        }
        return ret ; 
        }
    }
    //获取本地所有运行时的程序
    public string getRunningTasks()
    {
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
        var ret = javaClass.CallStatic<string>("getRunningTasks");
        return ret;
        }
    }
    //SDK 注销功能
    public  void logout(){
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            xc.ControlServerLogHelper.Instance.PostPlayerFollowRecord(xc.PlayerFollowRecordSceneId.StartLogout);
            javaClass.CallStatic("logout");
        }
    }
    //关闭laucherDialog
    public void closeLaucherDialog(){
        //GameDebug.LogError("closeLaucherDialog   + getBattery()" + getBattery());
        //using(AndroidJavaClass javaClass = new AndroidJavaClass("com.ucweb.db.xlib.ui.activity.UnityPlayerNativeActivity")){
            //javaClass.CallStatic("closeLaucherDialog");
        //}

    }
    //获取电量
    public float getBattery(){

        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            float ret = javaClass.CallStatic<float>("getBattery");
            return ret ; 
        }
    }
    //获取安装包中的 资源目录
    public string getPackageResourcePath(){

        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            var ret = javaClass.CallStatic<string>("getPackageResourcePath");
            ret = string.Format("{0}/!/assets{1}/", ret, xc.Const.BUNDLE_FOLDER);
            return ret;
        }
    }
    //获取更新信息
    public string getUpdateCheckUrl(){
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            string ret = javaClass.CallStatic<string>("getUpdateCheckUrl");
            return ret;
        }
    }

    public string getUpdateCheckUrlEx()
    {
        return "";
    }

    public string getUpdatePatchUrl(){
        return "";
    }

    /// <summary>
    /// res1的版本号
    /// </summary>
    /// <returns></returns>
    public string getBaseVersionJsonStr(){
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            string ret = javaClass.CallStatic<string>("getBaseVersionJsonStr");
            return ret;
        }
    }

    /// <summary>
    /// res2的版本号
    /// </summary>
    /// <returns></returns>
    public string getExVersionJsonStr(){
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            string ret = javaClass.CallStatic<string>("getExVersionJsonStr");
            return ret;
        }
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
        using(AndroidJavaClass javaClass = new AndroidJavaClass("com.ucweb.db.xlib.WebViewBridge"))
        {
            javaClass.CallStatic("openWebView", url);
        }
    }
    public string getNotifyURL(){
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            string ret = javaClass.CallStatic<string>("getNotifyURL");
            return ret;
        }
    }
    public void setNotifyURL(string url){
        using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            javaClass.CallStatic("setNotifyURL", url);
        }
    }

    public void registerFCM()
    {
        try
        {
            using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_PUSH_CLASS_NAME))
            {
                javaClass.CallStatic("registerFcm");
            }
        }
        catch (System.Exception ex)
        {
            GameDebug.LogError(ex.Message);
        }
    }

    public void registerPush()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_PUSH_CLASS_NAME))
        {
            javaClass.CallStatic("registerPush");
        }
    }
    public void setTag(string tag)
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_PUSH_CLASS_NAME))
        {
            javaClass.CallStatic("setTag", tag);
        }
    }
    public void registerPush(string account)
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_PUSH_CLASS_NAME))
        {
            javaClass.CallStatic("registerPush", account);
        }
    }
    public string getAndroidId() {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            string ret = javaClass.CallStatic<string>("getAndroidId");
            return ret;
        }
    }
    public string getBrand() {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            string ret = javaClass.CallStatic<string>("getBrand");
            return ret;
        }
    }
    public string getManufacturer()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                string ret = javaClass.CallStatic<string>("getManufacturer");
                return ret;
            }
            catch (System.Exception ex)
            {

            }
        }
        return "";
    }
    public string getServiceMark()
    {
        string mark = "";
        try
        {
            using(AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME_NEW_BRIDGE))
        {
                mark = javaClass.CallStatic<string>("getServiceMark");
                
            }
        }
        catch (Exception e)
        {
            
        }
        return mark;
    }

    public bool hasNotch()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                var ret = javaClass.CallStatic<bool>("hasNotch");
                return ret;
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("hasNotch error: " + ex.Message);
            }
        }

        return false;
    }

    public Vector2 getNotchSize()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                var ret = javaClass.CallStatic<string>("getNotchSize");
                return xc.DBTextResource.ParseVector2(ret);
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getNotchSize error: " + ex.Message);
            }
        }

        return Vector2.zero;
    }

    public byte[] loadExternalFileData(string fileName)
    {
        using (var javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = null;
            AndroidJavaObject stream = null;
            AndroidJavaObject assetManager = null;
            try
            {
                //取得应用的Activity
                activity = javaClass.GetStatic<AndroidJavaObject>("currentActivity");

                //从Activity取得AssetManager实例
                assetManager = activity.Call<AndroidJavaObject>("getAssets");

                //打开文件流
                stream = assetManager.Call<AndroidJavaObject>("open", fileName);
                //获取文件长度
                var availableBytes = stream.Call<int>("available");

                byte[] bytes = null;
                if (availableBytes > 0)
                {
                    //取得InputStream.read的MethodID
                    var clsPtr = AndroidJNI.FindClass("java.io.InputStream");
                    var METHOD_read = AndroidJNIHelper.GetMethodID(clsPtr, "read", "([B)I");

                    //申请一个Java ByteArray对象句柄
                    var byteArray = AndroidJNI.NewByteArray(availableBytes);
                    //调用方法
                    int readCount = AndroidJNI.CallIntMethod(stream.GetRawObject(), METHOD_read, new[] { new jvalue() { l = byteArray } });
                    //从Java ByteArray中得到C# byte数组
                    bytes = AndroidJNI.FromByteArray(byteArray);
                    //删除Java ByteArray对象句柄
                    AndroidJNI.DeleteLocalRef(byteArray);
                }

                //关闭文件流
                if (stream != null)
                {
                    stream.Call("close");
                    stream.Dispose();
                }
                if (assetManager != null)
                {
                    assetManager.Dispose();
                }
                if (activity != null)
                {
                    activity.Dispose();
                }
                //返回结果
                return bytes;
            }
            catch (System.Exception ex)
            {
                //关闭文件流
                if (stream != null)
                {
                    stream.Call("close");
                    stream.Dispose();
                }
                if (assetManager != null)
                {
                    assetManager.Dispose();
                }
                if (activity != null)
                {
                    activity.Dispose();
                }

                GameDebug.LogError("loadExternalFileData error: " + ex.Message);
            }
        }

        return null;
    }

    public long getStartTimeStamp()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<long>("getStartTimeStamp");
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getStartTimeStamp error: " + ex.Message);
            }
        }

        return 0;
    }

    public void copyTextToClipboard(string text)
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLIPBOARD_CLASS_NAME))
        {
            try
            {
            	javaClass.CallStatic("clipboardCopy", text);
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("copyTextToClipboard error: " + ex.Message);
            }
        }
    }

    public int getAppID()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<int>("getAppID");
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getAppID error: " + ex.Message);
            }
        }
        return 0;
    }

    public string getCurrChannel()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<int>("getCurrChannel").ToString();
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getCurrChannel error: " + ex.Message);
            }
        }
        return "";
    }

    public string getSubChannel()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
            	return javaClass.CallStatic<int>("getSubChannel").ToString();
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getSubChannel error: " + ex.Message);
            }
        }
        return "";
    }

    public string getExtChannel()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<string>("getExtChannel");
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getExtChannel error: " + ex.Message);
            }
        }
        return "";
    }

    public bool isOpenBindMobileActivity()
    {
        bool ret = false;
        try
        {
            using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME_NEW_BRIDGE))
            {
                ret = javaClass.CallStatic<bool>("isSupportMethod", "bindMobile");

            }
        }
        catch (Exception e)
        {
            GameDebug.LogError("isOpenBindMobileActivity error: " + e.Message);
        }
        return ret;
    }


    public bool isBindMobile()
    {
        bool ret = false;
        try
        {
            using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME_NEW_BRIDGE))
            {
                ret = javaClass.CallStatic<bool>("isBindMobile");

            }
        }
        catch (Exception e)
        {
            GameDebug.LogError("isBindMobile error: " + e.Message);
        }
        return ret;
    }

    public long getSdkID()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<long>("getSdkID");
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getSdkID error: " + ex.Message);
            }
        }

        return 0;
    }

    public string getSdkUserID()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<string>("getSdkUserID");
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getSdkUserID error: " + ex.Message);
            }
        }

        return "";
    }

    string settingLanguageToAndroidLanguage(string lan)
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
        return "zh";
    }

    string androidLanguageToSettingLanguage(string lan)
    {
        if (lan.StartsWith("en"))
        {
            return "ASIAN_ENGLISH";
        }
        else if (lan.Equals("zh_CN"))
        {
            return "SIMPLE_CHINESE";
        }
        else if (lan.StartsWith("vi"))
        {
            return "VIETNAMESE";
        }
        else if (lan.StartsWith("th"))
        {
            return "THAI";
        }
        return "SIMPLE_CHINESE";
    }

    public string getLocaleLanguage()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return androidLanguageToSettingLanguage(javaClass.CallStatic<string>("getLocaleLanguage").ToString());
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getLocaleLanguage error: " + ex.Message);
            }
        }
        return "";
    }

    public void setLocaleLanguage(string lan)
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                javaClass.CallStatic("setLocaleLanguage", settingLanguageToAndroidLanguage(lan));
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("setLocaleLanguage error: " + ex.Message);
            }
        }
    }

    public string getSDKDeviceID()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<string>("getSDKDeviceID").ToString();
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getSDKDeviceID error: " + ex.Message);
            }
        }
        return "";
    }

    public string getSDKVersionName()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<string>("getSDKVersionName").ToString();
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getSDKVersionName error: " + ex.Message);
            }
        }
        return "";
    }

    string mOperator = "";
    public string getOperator()
    {
        if (string.IsNullOrEmpty(mOperator) == false)
        {
            return mOperator;
        }
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                mOperator = javaClass.CallStatic<string>("getOperator").ToString();
                return mOperator;
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getOperator error: " + ex.Message);
            }
        }
        return "";
    }

    int mIsRoot = -1;
    public int isRoot()
    {
        if (mIsRoot != -1)
        {
            return mIsRoot;
        }
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                mIsRoot = javaClass.CallStatic<int>("isRoot");
                return mIsRoot;
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("isRoot error: " + ex.Message);
            }
        }
        return 0;
    }

    string mTimeZone = "";
    public string getTimeZone()
    {
        if (string.IsNullOrEmpty(mTimeZone) == false)
        {
            return mTimeZone;
        }
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                mTimeZone = javaClass.CallStatic<string>("getTimeZone").ToString();
                return mTimeZone;
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getTimeZone error: " + ex.Message);
            }
        }
        return "";
    }

    int mWindowWidth = 0;
    public int getWindowWidth()
    {
        if (mWindowWidth != 0)
        {
            return mWindowWidth;
        }
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                mWindowWidth = javaClass.CallStatic<int>("getWindowWidth");
                return mWindowWidth;
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getWindowWidth error: " + ex.Message);
            }
        }
        return 0;
    }

    int mWindowHeigh = 0;
    public int getWindowHeigh()
    {
        if (mWindowHeigh != 0)
        {
            return mWindowHeigh;
        }
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                mWindowHeigh = javaClass.CallStatic<int>("getWindowHeigh");
                return mWindowHeigh;
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getWindowHeigh error: " + ex.Message);
            }
        }
        return 0;
    }

    public int getAPILevel()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<int>("getAPILevel");
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getAPILevel error: " + ex.Message);
            }
        }
        return 0;
    }

    public string getLocalIpAddress()
    {
        return Network.player.ipAddress;
    }

    public string getWfName()
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                return javaClass.CallStatic<string>("getWifiName").ToString();
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getWifiName error: " + ex.Message);
            }
        }
        return "";
    }

    public string getPhoneIDFV()
    {
        return "";
    }

    public void cloudLadderEventWithAction(string msg)
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
            	javaClass.CallStatic("cloudLadderEventWithAction", msg);
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("cloudLadderEventWithAction error: " + ex.Message);
            }
        }
    }

    string mXgAccessId = "";
    public string getXgAccessId()
    {
        if (string.IsNullOrEmpty(mXgAccessId) == false)
        {
            return mXgAccessId;
        }

        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_CLASS_NAME))
        {
            try
            {
                mXgAccessId = javaClass.CallStatic<string>("getApplicationMetaData", "XG_V2_ACCESS_ID");
                return mXgAccessId;
            }
            catch (System.Exception ex)
            {
                GameDebug.LogError("getXgAccessId error: " + ex.Message);
            }
        }
        return "";
    }
    public void log2OSCmd(string tag, string msg)
    {
        using (AndroidJavaClass javaClass = new AndroidJavaClass(JAVA_LOG_CLASS_NAME))
        {
            javaClass.CallStatic<int>("i", tag, msg);
        }
    }

}

#endif
