using UnityEngine;
using System.Collections;

  public interface IBridge  {
	// 调用SDK登陆接口
	   void login ();
	// 获取SDK 初始化情况
	   int getInitSDKState ();
	// 初始化 SDK 
	   void initSDK ();
	// 获取登陆信息 没有登陆返回 “”
	   string getLoginMsg ();
	// 调用SDK 用户中心页面
	   void userCenter ();

	/*
		支付参数待定
	 */
	   void pay (string payInfo);
	/*
	 * 补丁合成接口 传递参数规范 为 json结构的String 具体参数如下
	 * 
	 * oldFilePath 原始文件路径
	 * newFilePath 合成新文件路径
	 * patchFilePath 补丁文件路径 
	 * 
	 * 返回 -1 标示 合成失败
	 * */

	  int installPatch (string patchInfo);
	//退出SDK 
	  void exitSDK();
	// 重启
	  void reboot();
	// 安装 android 为 安装APK IOS 为 安装IPA
	  void install(string installFilePath);
	// 设置 登陆信息 可用于切换账号
	  void setLoginMsg(string loginMsg);
	// 获取手机型号
	  string getPhoneModel();
	// 获取 APK/IPA 程序版本
	  string getAppVersion();
    // 获取手机的广告标识
    string GetPhoneIDFA();
    // 获取网络类型 
    /**/
    int getNetType();
	//获取 SDK 类型
	  int getSDKType();
	// 获取磁盘空间剩余内存大小（单位Mb）
	  int getStorageFreeSize();
	// 获取SDK  名称
	  string getSDKName();
	// 获取剩余空闲内存
	  float getAvailMemory();
	// 获取 SD卡路径
	  string getSDPath();
	// 获取 游戏工作根目录 如 /SDCARD/DBX2/
	  string getGameDocPath();
	// 获取 游戏资源目录路径 如 SDCARD/DBX2/Resources
	  string getGameResPath();
	// 获取 
	  string getGameLibPath();
	// 游戏崩溃之后 需要做的 log收集 工作
	  void doNativeCrash();
	// 此接口参数 为 //{"action":"","parameter":""} 
	// 调用 一些比较特殊 没有公共话的接口
	  void doAction2SDK( string  msg);
	// 获取系统版本
	  string getOSVersion();
	// 获取CPU 类型
	  string getCPUAPI();
	// 手机震动
	  void vibrate(int milliseconds);
	// 获取系统字体
	  string getSystemTTFs();
	// 获取手机 IMEI
	  string getPhoneIMEI();
	// 获取 MAC地址
	  string getPhoneMAC();

	  string getPhoneIMSI();

	//部署 资源文件
	  void installU3DAssets(string needDelFile,string needRenameFile); 
	  string getZipAdler32(string file);
    //本地读取DB 机器码
      string getDBMachineId();
    //更新读取DB 机器码
      void updateDBMachineId(string id);
      //判断是否可用
      bool isBridgeEnable();
      //是否需要响应返回按钮事件
      bool checkBackBtnAction();
      //SDK 注销功能
      void logout();
      //关闭laucherDialog
      void closeLaucherDialog();
      float getBattery();
      //获取安装包中的 资源目录
      string getPackageResourcePath();

    //获取更新信息
    string getUpdateCheckUrl();

    // 获取更新信息，加密版
    string getUpdateCheckUrlEx();

   // 请求更新信息 
    string getUpdatePatchUrl();

    string getBaseVersionJsonStr();
    string getExVersionJsonStr();
    void onTDLogin(string accoundID);
    void onTDCreateRole(string roleName);

    string getIPv6(string mHost);

    void openWebView(string url);

    string getNotifyURL();
    void setNotifyURL(string url);
    void registerFCM();
    void registerPush();
    void setTag(string tag);
    void registerPush(string account);
    string getAndroidId();
    string getBrand();
    string getManufacturer();
    string getServiceMark();

    /// <summary>
    /// 是否是凹形屏
    /// </summary>
    /// <returns></returns>
    bool hasNotch();

    /// <summary>
    /// 获取凹形区域的尺寸
    /// </summary>
    /// <returns></returns>
    Vector2 getNotchSize();

    /// <summary>
    /// 加载外部文件数据，安卓下是找asset文件夹里面的文件
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    byte[] loadExternalFileData(string fileName);

    /// <summary>
    /// 获取游戏启动时间戳
    /// </summary>
    /// <returns></returns>
    long getStartTimeStamp();

    /// <summary>
    /// 复制文本到剪贴板
    /// </summary>
    /// <param name="text"></param>
    void copyTextToClipboard(string text);

    /// <summary>
    /// 获取AppID
    /// </summary>
    /// <returns></returns>
    int getAppID();

    /// <summary>
    /// 获取sdk一级渠道
    /// </summary>
    /// <returns></returns>
    string getCurrChannel();

    /// <summary>
    /// 获取sdk二级渠道
    /// </summary>
    /// <returns></returns>
    string getSubChannel();

    /// <summary>
    /// 获取sdk三级渠道
    /// </summary>
    /// <returns></returns>
    string getExtChannel();


    /// <summary>
    /// 是否开启绑定手机活动
    /// </summary>
    bool isOpenBindMobileActivity();

    /// <summary>
    /// 是否已绑定手机
    /// </summary>
    /// <returns></returns>
    bool isBindMobile();

    /// <summary>
    /// 获取sdk的id
    /// </summary>
    /// <returns></returns>
    long getSdkID();

    /// <summary>
    /// 获取sdk的用户id
    /// </summary>
    /// <returns></returns>
    string getSdkUserID();

    /// <summary>
    /// 获取当前语言
    /// </summary>
    /// <returns></returns>
    string getLocaleLanguage();

    /// <summary>
    /// 设置当前语言
    /// </summary>
    /// <param name="lan"></param>
    void setLocaleLanguage(string lan);

    /// <summary>
    /// 获取sdk设备id
    /// </summary>
    /// <returns></returns>
    string getSDKDeviceID();

    /// <summary>
    /// 获取sdk版本号
    /// </summary>
    /// <returns></returns>
    string getSDKVersionName();

    /// <summary>
    /// 获取当前的运营商
    /// </summary>
    /// <returns></returns>
    string getOperator();

    /// <summary>
    /// 判断手机是否root/越狱
    /// </summary>
    /// <returns></returns>
    int isRoot();

    /// <summary>
    /// 获取手机时区(例如:+8)
    /// </summary>
    /// <returns></returns>
    string getTimeZone();

    /// <summary>
    /// 获取屏幕分辨率
    /// </summary>
    /// <returns></returns>
    int getWindowWidth();

    /// <summary>
    /// 获取屏幕分辨率
    /// </summary>
    /// <returns></returns>
    int getWindowHeigh();

    /// <summary>
    /// 获取APILevel
    /// </summary>
    /// <returns></returns>
    int getAPILevel();

    /// <summary>
    /// 获取内网ip
    /// </summary>
    /// <returns></returns>
    string getLocalIpAddress();

    /// <summary>
    /// 获取wifi名称
    /// </summary>
    /// <returns></returns>
    string getWfName();

    /// <summary>
    /// 获取手机的IDFV
    /// </summary>
    /// <returns></returns>
    string getPhoneIDFV();

    /// <summary>
    /// 云梯sdk 事件上报
    /// </summary>
    void cloudLadderEventWithAction(string msg);

    /// <summary>
    /// 获取信鸽access_id
    /// </summary>
    string getXgAccessId();
    void log2OSCmd(string tag, string msg);
}
