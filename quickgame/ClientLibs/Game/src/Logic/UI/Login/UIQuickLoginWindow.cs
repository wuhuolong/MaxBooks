//-------------------------------------------
// File: UIQuickLoginWindow.cs
// Desc: SDK登录的界面
// Author: Raorui
// Date: 2017.12.5重构
//-------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using xc.ui;
using System;
using Net;
using Utils;

namespace xc
{
    namespace ui.ugui
    {

        /// <summary>
        /// SDK登录使用面板
        /// </summary>
        [wxb.Hotfix]
        public class UIQuickLoginWindow : UIBaseWindow
        {
            //--------------------------------------------------------
            //  变量定义
            //--------------------------------------------------------

            /// <summary>
            /// loading图标
            /// </summary>
            GameObject m_LoadingIcon;

            /// <summary>
            /// 切换SDK帐号按钮
            /// </summary>
            Button m_SDKAccountButton;

            /// <summary>
            /// 选择服务器的按钮
            /// </summary>
            Button m_ChooseServerButton; // 选择服务器按钮

            /// <summary>
            /// 登录游戏按钮
            /// </summary>
            Button m_LoginButton;

            /// <summary>
            /// 服务器状态的Image
            /// </summary>
            Image m_ServerStateImage;

            /// <summary>
            /// 选中服务器的名字
            /// </summary>
            Text m_ServerNameText;

            /// <summary>
            /// 选中的服务器信息
            /// </summary>
            ServerInfo m_SelectedServerInfo;


            /// <summary>
            /// 公告按钮
            /// </summary>
            Button mBtnAnnouncement;

            /// <summary>
            /// 用户中心按钮
            /// </summary>
            Button mUserButton;

            /// <summary>
            /// logo图片
            /// </summary>
            Image mLogo;

            /// <summary>
            /// 自定义logo图片 
            /// </summary>
            RawImage mCustomLogoRawImage;
            Texture mCustoLogoTexture;
            GameObject mKVPanel;

            /// <summary>
            /// 版号信息
            /// </summary>
            Text mVersionInfoText;

            /// <summary>
            /// 背景
            /// </summary>
            GameObject mBgParent;


            bool mInDelayTime = false;

            /// <summary>
            /// 是否已经销毁
            /// </summary>
            bool mIsDestroy = false;

            //--------------------------------------------------------
            //  构造函数
            //--------------------------------------------------------
            public UIQuickLoginWindow()
            {
                // 根据sdkname来选择配置信息
                //SDKConfig sdkConfig = SDKHelper.GetSDKConfig();
                //if (sdkConfig != null)
                //{
                //    mPrefabName = sdkConfig.LoginPrefab;
                //}
                //else
                //    mPrefabName = "UIQuickLoginWindow";

                mPrefabName = SDKHelper.GetPrefabName("UIQuickLoginWindow", false);

            }
                    
            //--------------------------------------------------------
            //  虚函数
            //--------------------------------------------------------
            protected override void InitUI()
            {
                mIsDestroy = false;

                base.InitUI();

                m_LoadingIcon = FindChild<Transform>("LoadingIcon").gameObject;
                m_LoadingIcon.SetActive(false);
                //m_SDKAccountButton = FindChild("SDKAccountButton").GetComponent<Button>();
                m_ChooseServerButton = FindChild("ChooseServerButton").GetComponent<Button>();
                m_LoginButton = FindChild("LoginButton").GetComponent<Button>();
                m_ServerStateImage = FindChild<Image>("ServerStateImage");
                m_ServerNameText = FindChild<Text>("ServerNameText");

                //m_SDKAccountButton.onClick.AddListener( OnClickSDKAccountButton);
                m_ChooseServerButton.onClick.AddListener(OnClickChooseServerButton);
                m_LoginButton.onClick.AddListener(OnClickLoginButton);


                mBtnAnnouncement = FindChild<Transform>("AnnouncementButton").gameObject.GetComponent<Button>();

                mBtnAnnouncement.onClick.AddListener(onShowLoginNotice);

                mUserButton = FindChild<Transform>("UserButton").gameObject.GetComponent<Button>();
                bool isShowUserCenterButton = true;
                string isShowUserCenterButtonStr = GameConstHelper.GetString("GAME_SYS_SHOW_SDK_USER_CENTER");
                if (Const.Region != RegionType.CHINA)
                    isShowUserCenterButtonStr = GameConstHelper.GetString("GAME_SYS_SHOW_SDK_USER_CENTER_OVERSEA");

                if (isShowUserCenterButtonStr == "" || isShowUserCenterButtonStr == "0")
                {
                    isShowUserCenterButton = false;
                }
                mUserButton.gameObject.SetActive(isShowUserCenterButton);
                mUserButton.onClick.AddListener(OnClickUserButton);

                mLogo = FindChild<Image>("Logo");
#if UNITY_ANDROID
                var app_id = DBOSManager.getOSBridge().getAppID();
                var item = DBAndroidMajia.Instance.GetData((uint)app_id);
                if (item != null)
                {
                    mLogo.gameObject.SetActive(item.ShowLogo);
                    mUserButton.gameObject.SetActive(item.ShowUserCenter);
                }
#endif

                mCustomLogoRawImage = FindChild<RawImage>("CustomLogoRawImage");

                GameObject ageIdentification = FindChild("AgeIdentification");
                if (ageIdentification != null)
                {
                    // 只有韩国版 onestore 渠道需要显示年龄分级图标
                    var ret = Const.Region == RegionType.KOREA && Application.identifier == GameConst.APK_NAME_KOREA_ONESTORE;
                    ageIdentification.gameObject.SetActive(ret);
                }
                //IOS
#if UNITY_IPHONE
                mLogo.gameObject.SetActive(true);
	            mCustomLogoRawImage.gameObject.SetActive(false);
	            LoadMaJiaImage majiaImage = mLogo.gameObject.AddComponent<LoadMaJiaImage>();
	            var logoName = "logo.png";
	            majiaImage.mPath = ResNameMapping.Instance.GetMappingName(logoName);
	            //majiaImage.SetCallBack(LoadImgSuccess);

	            GameObject go = FindChild("Bg");
	            LoadMaJiaImage majiaBg = go.AddComponent<LoadMaJiaImage>();
	            var picName = "QuickLogin.jpg";
	            majiaBg.mPath = ResNameMapping.Instance.GetMappingName(picName);

#endif



                mKVPanel = FindChild("KVPanel");
                if (mKVPanel != null)
                {
                    //if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                    //    mKVPanel.SetActive(false);

#if UNITY_IPHONE
                	mKVPanel.SetActive(SDKHelper.GetAuditInfo("is_show_login_kv"));
#endif

#if UNITY_ANDROID
	                item = DBAndroidMajia.Instance.GetData((uint)app_id);
	                if (item != null)
	                {
	                    mKVPanel.gameObject.SetActive(item.ShowKv);
	                }
#endif

                }

                mVersionInfoText = FindChild<Text>("VersionInfoText");

                mBgParent = FindChild("BgParent");

                if (Const.Region != RegionType.CHINA)
                {
                    // 隐藏健康提示
                    var login_panel_trans = FindChild<Transform>("LoginPanel");
                    if (login_panel_trans != null)
                    {
                        var health_text = login_panel_trans.Find("Text");
                        if (health_text != null)
                        {
                            health_text.gameObject.SetActive(false);
                        }
                    }
                }
                    
                // 注册网络消息

                // 注册客户端消息
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SDK_INITED, OnInitCallback); 
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SELECT_SERVER, OnSelectServerChange);
                ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_GET_SERVER_INFOS, OnStartGetServerInfos);
            }

            private void LoadImgSuccess()
            {
                if (mLogo != null)
                {
                    mLogo.gameObject.SetActive(false);
                }
            }


            private void onShowLoginNotice()
            {
                LoginNoticeUtil.ShowNormalNotice();
            }

            private void OnClickUserButton()
            {
                GlobalConfig globalConfig = GlobalConfig.GetInstance();
                if (string.IsNullOrEmpty(globalConfig.LoginInfo.AccName) == true)
                {
                    if (Const.Region != RegionType.KOREA)
                        UINotice.Instance.ShowMessage(DBConstText.GetText("PLEASE_LOGIN"));
                }
                else
                {
                    //if (SDKControler.getSDKControler().IsLoginSuccess)
                    if (Const.Region == RegionType.KOREA)
                        DBOSManager.getDBOSManager().getBridge().logout();
                    else
                        DBOSManager.getDBOSManager().getBridge().userCenter();
                }
            }

            protected override void UnInitUI()
            {

                // 取消注册客户端消息
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SDK_INITED, OnInitCallback);
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SELECT_SERVER, OnSelectServerChange);
                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_START_GET_SERVER_INFOS, OnStartGetServerInfos);
                // 取消注册网络消息

                // 取消注册控件消息
                //m_SDKAccountButton.onClick.RemoveAllListeners();
                m_ChooseServerButton.onClick.RemoveAllListeners();
                m_LoginButton.onClick.RemoveAllListeners();

                mBtnAnnouncement.onClick.RemoveAllListeners();
                mUserButton.onClick.RemoveAllListeners();


                if (mCustomLogoRawImage != null)
                {
                    mCustomLogoRawImage.texture = null;
                    mCustomLogoRawImage = null;
                }
                if (mCustoLogoTexture != null)
                {
                    Resources.UnloadAsset(mCustoLogoTexture);
                    mCustoLogoTexture = null;
                }

                if(Game.Instance.ManualCancelReconnect)
                    Game.Instance.ManualCancelReconnect = false;

                base.UnInitUI();

                mIsDestroy = true;
            }

            /// <summary>
            /// SDK延迟初始话的Timer
            /// </summary>
            Timer mInitSDKTimer = null;

            protected override void ResetUI()
            {
                base.ResetUI();

                var parmas = ShowParam;
                if (parmas != null && parmas.Length > 0)
                {
                    var get_last_server = Convert.ToBoolean(parmas[0]);
                    if (get_last_server)
                        StartGetServerInfos();
                }

                // 显示版本信息
                UIManager.Instance.ShowWindow("UIVersionWindow");

                GlobalConfig globalConfig = GlobalConfig.GetInstance();
                if (Game.Instance.ManualCancelReconnect)
                {
                    StartGetServerInfos();
                }
                else
                {
                    if (string.IsNullOrEmpty(globalConfig.LoginInfo.AccName) == true)
                    {
                        if (globalConfig.IsEnterSDK)
                        {
                            // 初始化sdk
                            if (AuditManager.Instance.AuditAndIOS() == false)
                            {
                                mInDelayTime = true;
                                DestroyInitSDKTimer();
                                mInitSDKTimer = new Utils.Timer(2000, false, 1000, OnDelayInitSDK);
                            }
                            else
                            {
                                OnDelayInitSDK(0);
                            }

                        }
                        else
                        {
                            mInDelayTime = false;
                            GameDebug.LogError("UIQucikWindow must be in sdk");
                        }
                    }
                }

                // 根据sdkname来选择配置信息
                SDKConfig sdkConfig = SDKHelper.GetSDKConfig();
                if (sdkConfig != null)
                {
                    // logo
                    Sprite sprite = LoadSprite(sdkConfig.LogoName);
                    if (sprite != null)
                    {
                        mLogo.sprite = sprite;
                    }
#if UNITY_IPHONE

                //mCustoLogoTexture = Resources.Load("logo") as Texture;
                ////从resource里面读出，如果存在，则优先显示
                //if (mCustoLogoTexture != null)
                //{
                //    if (mCustomLogoRawImage != null)
                //    {
                //        mCustomLogoRawImage.texture = mCustoLogoTexture;
                //        mCustomLogoRawImage.gameObject.SetActive(true);
                //        mCustomLogoRawImage.SetNativeSize();
                //    }
                //    if (mLogo != null)
                //    {
                //        mLogo.gameObject.SetActive(false);
                //    }
                //}
                //else
                //{
                //    if (mLogo != null)
                //        mLogo.gameObject.SetActive(true);
                //    if (mCustomLogoRawImage != null)
                //        mCustomLogoRawImage.gameObject.SetActive(false);
                //}
#endif
                    // 版号信息
                    if (Const.Region == RegionType.CHINA)
                    {
                        mVersionInfoText.text = sdkConfig.VersionInfo;

                        if (mVersionInfoText != null)
                            mVersionInfoText.gameObject.SetActive(AuditManager.Instance.AuditAndIOS() == false);
                    }
                    else
                    {
                        if (mVersionInfoText != null)
                            mVersionInfoText.gameObject.SetActive(false);
                    }

                    if (mBtnAnnouncement != null)
                        mBtnAnnouncement.gameObject.SetActive(AuditManager.Instance.AuditAndIOS() == false);
                }

#if UNITY_ANDROID
            // 安卓平台从assets文件夹查找是否存在"login_logo.png"图片，存在则优先显示
            string logoFileName = "login_logo.png";
            byte[] logoImageData = DBOSManager.getDBOSManager().getBridge().loadExternalFileData(logoFileName);
            if (logoImageData != null)
            {
                TextureFormat textureFormat = TextureFormat.RGBA4444;

                Texture2D newTexture2D = new Texture2D((int)mLogo.preferredWidth, (int)mLogo.preferredHeight, textureFormat, false);
                newTexture2D.LoadImage(logoImageData);
                mCustomLogoRawImage.texture = newTexture2D;
                mCustomLogoRawImage.gameObject.SetActive(true);
                mCustomLogoRawImage.SetNativeSize();

                mLogo.gameObject.SetActive(false);
            }
            else
            {
                GameDebug.LogError("Error, Can not load logo image: " + logoFileName);
            }
            
            // 安卓平台从assets文件夹查找是否存在"version_info"文件，存在则优先显示为版号信息
            string versionInfoFileName = "version_info";
            byte[] versionInfoFileData = DBOSManager.getDBOSManager().getBridge().loadExternalFileData(versionInfoFileName);
            if (versionInfoFileData != null)
            {
                mVersionInfoText.text = System.Text.Encoding.UTF8.GetString(versionInfoFileData);
            }

            RawImage bgImage = FindChild<RawImage>("Bg");
            GameObject effect = FindChild("Effect");
            // 安卓平台从assets文件夹查找是否存在"login_bg.jpg"图片，存在则优先显示
            string imageFileName = "login_bg.jpg";
            byte[] imageData = DBOSManager.getDBOSManager().getBridge().loadExternalFileData(imageFileName);
            if (imageData != null)
            {
                TextureFormat textureFormat = TextureFormat.DXT1;
                int width = Screen.currentResolution.width;
                int height = Screen.currentResolution.height;

                Texture2D newTexture2D = new Texture2D(width, height, textureFormat, false);
                newTexture2D.LoadImage(imageData);
                bgImage.texture = newTexture2D;

                effect.SetActive(false);

                var app_id = DBOSManager.getOSBridge().getAppID();
                var item = DBAndroidMajia.Instance.GetData((uint)app_id);
                if (item != null)
                {
                    effect.gameObject.SetActive(item.ShowEffect);
                }
            }
            else
            {
                //GameDebug.LogError("Error, Can not load loading bg image: " + imageFileName);
                effect.SetActive(true);
            }
#endif

                mLogo.SetNativeSize();

                if (Const.Region == RegionType.KOREA)
                    BuriedPointHelper.ReportAppsflyerEvnet("af_server");
            }
            
            protected override void HideUI()
            {
                base.HideUI();
                DestroyInitSDKTimer();
            }

            //--------------------------------------------------------
            //  内部调用
            //--------------------------------------------------------
            public void DestroyInitSDKTimer()
            {
                if(mInitSDKTimer != null)
                {
                    mInitSDKTimer.Destroy();
                    mInitSDKTimer = null;
                }
            }

            public void OnDelayInitSDK(float remainTime)
            {
                if(remainTime <=0)
                {
                    mInDelayTime = false;
                    SDKControler.getSDKControler().InitSDK();
                }
            }

            /// <summary>
            /// 设置SDK登录按钮上显示的文字
            /// </summary>
            public void SetSDKButtonText(string text)
            {
                if (m_SDKAccountButton != null)
                {
                    Transform trans = m_SDKAccountButton.transform;
                    if(trans != null)
                    {
                        trans = trans.Find("Text");
                        if(trans != null)
                        {
                            var label = trans.GetComponent<Text>();
                            if(label != null)
                                label.text = text;
                        }
                    }
                }
            }

            /// <summary>
            /// 根据服务器状态来获取对应的Sprite
            /// </summary>
            /// <param name="state"></param>
            /// <returns></returns>
            public Sprite GetSpriteByState(EServerState state)
            {
                if (mUIObject == null)
                {
                    return null;
                }

                CanvasInfo info = mUIObject.GetComponent<CanvasInfo>();
                if (info == null)
                {
                    GameDebug.LogError(string.Format("UIServerListWindow.GetSpriteByState {0}  CanvasInfo is null", mWndName));
                    return null;
                }

                Sprite sprite = null;
                if (state == EServerState.Smooth)
                {
                    sprite = info.LoadSprite("MainWindow_New@Common@ServerQuality");
                }
                else if (state == EServerState.Full)
                {
                    sprite = info.LoadSprite("MainWindow_New@Common@ServerQuality_2");
                }
                else
                {
                    sprite = info.LoadSprite("MainWindow_New@Common@ServerQuality_3");
                }
                return sprite;
            }

            /// <summary>
            /// 设置当前选中的服务器信息，并设置按钮状态
            /// </summary>
            /// <param name="serverInfo"></param>
            public void SetSelectedServerInfo(ServerInfo server_info)
            {
                m_SelectedServerInfo = server_info;

                if (this.IsShow == false)
                {
                    return;
                }

                if (server_info == null)
                {
                    m_ServerStateImage.sprite = GetSpriteByState(0);
                    m_ServerNameText.text = "";
                }
                else
                {
                    m_ServerStateImage.sprite = GetSpriteByState(server_info.State);
                    m_ServerNameText.text = server_info.Name;
                }
            }

            /// <summary>
            /// 获取登陆过或者推荐服务器列表的回调
            /// </summary>
            public void OnGetAllRecommServerFinished(List<ServerInfo> loginedServerList, List<ServerInfo> recomServerList, List<ServerInfo> loginServerList)
            {
                if (recomServerList != null && recomServerList.Count > 0)
                {
                    SetSelectedServerInfo(recomServerList[0]);

                    // 获取服务器列表
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.GetServerList);
                    ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.list_gs);
                }
                else
                {
                    UIManager.GetInstance().ShowWindow("UIServerListWindow", 0);
                }
            }

            /// <summary>
            /// 获取上次登陆服务器的回调
            /// </summary>
            public void OnGetLastLoginServerFinished(ServerInfo serverInfo)
            {
                if (serverInfo != null)
                {
                    SetSelectedServerInfo(serverInfo);

                    // 获取服务器列表
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.GetServerList);
                    ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.list_gs);
                }
                else
                {
                    ServerListHelper.GetInstance().GetAllRecommServer(OnGetAllRecommServerFinished);
                }
            }

            /// <summary>
            /// 根据获取的服务器信息来进行登陆
            /// </summary>
            public void LoginServer(ServerInfo serverInfo)
            {
                if (serverInfo == null)
                {
                    GameDebug.LogError("Error, server info is null!!!");
                    UINotice.GetInstance().ShowMessage(DBConstText.GetText("PLEASE_SELECT_ONE_SERVER"));
                    return;
                }

                if (m_LoadingIcon != null)
                {
                    m_LoadingIcon.SetActive(true);
                }

                ServerListHelper.GetInstance().CheckServerStateAndEnter(serverInfo, (ServerInfo retServerInfo, bool canEnter) =>
                {
                    if (canEnter == false)
                    {
                        UIManager.Instance.ShowWaitScreen(false);
                        if (m_LoadingIcon != null)
                        {
                            m_LoadingIcon.SetActive(false);
                        }
                    }
                });

                // 点击登录按钮
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ClickLoginButton);
            }

            //--------------------------------------------------------
            //  外部调用
            //--------------------------------------------------------


            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            /// <summary>
            /// 点击登录/切换账号按钮
            /// </summary>
            public void OnClickSDKAccountButton()
            {
                if(mInDelayTime)
                    return;

                SetSDKButtonText(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_100"));

                GlobalConfig globalConfig = GlobalConfig.GetInstance();
                if(globalConfig.IsEnterSDK)
                {
                    // sdk不在初始化、登陆状态下
                    if(!IsSDKWorking())
                    {
                        if(string.IsNullOrEmpty(globalConfig.LoginInfo.AccName) == true)
                        {
                            SDKControler.getSDKControler().loginSDK(OnLoginCallback);
                        }
                        else
                        {
                            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                            bridge.setLoginMsg("");
                            bridge.logout();
                            SetSelectedServerInfo(null);
                            SDKControler.getSDKControler().loginSDK(OnLoginCallback);
                        }
                    }
                }
                else
                {
                    GameDebug.LogError("UIQucikWindow must be in sdk");
                }
            }

            /// <summary>
            /// 点击选择服务器按钮
            /// </summary>
            public void OnClickChooseServerButton()
            {
                if(mInDelayTime)
                    return;

                GlobalConfig globalConfig = GlobalConfig.GetInstance();
                if (globalConfig.IsEnterSDK)
                {
                    if (!IsSDKWorking())
                    {
                        if (string.IsNullOrEmpty(globalConfig.LoginInfo.AccName) == true)
                        {
                            //SDKControler.getSDKControler().loginSDK(OnLoginCallback);
							if (Const.Region != RegionType.KOREA)
                            	UINotice.Instance.ShowMessage(DBConstText.GetText("PLEASE_LOGIN"));
                        }
                        else
                        {
                            UIManager.GetInstance().ShowWindow("UIServerListWindow", 0);
                        }
                    }
                }
                else
                {
                    UIManager.GetInstance().ShowWindow("UIServerListWindow", 0);
                }
                    
            }

            /// <summary>
            /// 点击开始游戏按钮
            /// </summary>
            public void OnClickLoginButton()
            {
                if(mInDelayTime)
                    return;

                GlobalConfig globalConfig = GlobalConfig.GetInstance();
                if (!IsSDKWorking())
                {
                    if (string.IsNullOrEmpty(globalConfig.LoginInfo.AccName) == true)
                    {
                        if (globalConfig.IsEnterSDK)
                        {
                            SDKControler.getSDKControler().loginSDK(OnLoginCallback);

                        }
                        else
                        {
                            GameDebug.LogError("UIQucikWindow must be in sdk");
                        }

                    }
                    else
                    {
                        LoginServer(m_SelectedServerInfo);
                    }
                }
            }

            /// <summary>
            /// sdk是否正在初始化和登陆过程中
            /// </summary>
            public bool IsSDKWorking()
            {
                if (SDKControler.getSDKControler().IsIniting())
                {
                    //显示正在初始化
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_101"));
                    GameDebug.LogError("sdk is initing .................");
                    return true;
                }

                if (SDKControler.getSDKControler().IsLogining())
                {
                    //显示正在登陆
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_102"));
                    GameDebug.LogError("sdk is logining .................");
                    return true;
                }
                
                return false;
            }
            //--------------------------------------------------------
            //  客户端消息
            //--------------------------------------------------------  
            /// <summary>
            /// 选中的服务器发生变化
            /// </summary>
            /// <param name="data"></param>
            public void OnSelectServerChange(CEventBaseArgs data)
            {
                ServerInfo server_info = (ServerInfo)data.arg;

                SetSelectedServerInfo(server_info);
            }

            /// <summary>
            /// 响应获取最后的服务器
            /// </summary>
            /// <param name="data"></param>
            public void OnStartGetServerInfos(CEventBaseArgs data)
            {
                StartGetServerInfos();
            }

            //--------------------------------------------------------
            //  网络消息
            //--------------------------------------------------------  
            /// <summary>
            /// 登陆sdk后请求上次登陆服务器的列表
            /// </summary>
            public void InitLoginCache()
            {

                //获取公告信息
                UIManager.Instance.ShowWaitScreen(true);
                //这里先获取后台通告信息
                string loginNoticeUrl = GlobalConfig.GetInstance().LoginNoticeUrl;

                GameDebug.Log("获取游戏公告" + loginNoticeUrl);

                MainGame.HttpRequest.GET(loginNoticeUrl, OnGetLoginNoticeInfo);

                //获取服务器列表
                //ServerListHelper.GetInstance().GetLastLoginServerInfo(OnGetLastLoginServerFinished);
                SetSDKButtonText(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_103"));
            }

            public void OnGetLoginNoticeInfo(string url, string error, string reply, object userData)
            {
                if (string.IsNullOrEmpty(error) == false)
                {
                    UIManager.Instance.ShowWaitScreen(false);

                    GameDebug.LogError("获取游戏公告失败: " + error);
                    string err = DBConstText.GetText("GET_LOGIN_NOTICE_INFO_FAIL");
#if UNITY_EDITOR
                    err += error;
#endif

                    UIWidgetHelp.GetInstance().ShowNoticeDlg(err, (object obj) => {
                        //获取公告信息失败，获取服务器信息
                        StartGetServerInfos();
                    });
                    return;
                }
                GameDebug.Log("游戏公告获取成功:" + reply);

                //判断是否需要弹出通告界面
                LoginNoticeData data;

                if (!LoginNoticeUtil.CheckData(reply, out data))
                {
                    UIManager.Instance.ShowWaitScreen(false);

                    GameDebug.LogError("获取游戏公告失败: " + reply);
                    string err = DBConstText.GetText("GET_LOGIN_NOTICE_INFO_FAIL");
#if UNITY_EDITOR
                    err += reply;
#endif
                    UIWidgetHelp.GetInstance().ShowNoticeDlg(err, (object obj) => {
                        //获取公告信息失败，开始获取服务器信息
                        StartGetServerInfos();
                    });
                    return;
                }

                int lastId = PlayerPrefs.GetInt(LoginNoticeData.LOGIN_ID_KEY, LoginNoticeData.DEFAULT_LOGIN_ID);

                //判断自动弹出
                if (lastId == LoginNoticeData.DEFAULT_LOGIN_ID)
                {
                    //第一次都弹出
                    ShowNoticePanel(data, true);
                }
                else
                {

                    //第二次判断是否为强制，或者通告信息发生了改变
                    if ( data.type == 1)
                    {
                        ShowNoticePanel(data, true);
                    }
                    else
                    {
                        //通告没有变化而且不是强制弹出，开始获取服务器信息
                        //设置当前弹出ID
                        //StartGetServerInfos();
                    }

                    ////第二次判断是否为强制，或者通告信息发生了改变
                    //if (data.id != lastId || data.type == 1)
                    //{
                    //    ShowNoticePanel(data, true);
                    //}
                    //else
                    //{
                    //    //通告没有变化而且不是强制弹出，开始获取服务器信息
                    //    //设置当前弹出ID
                    //    //StartGetServerInfos();
                    //}
                }

                // 总是获取服务器信息
                StartGetServerInfos();

                //PlayerPrefs.SetInt(LoginNoticeData.LOGIN_ID_KEY, data.id);
                UIManager.Instance.ShowWaitScreen(false);
            }

            public void ShowNoticePanel(LoginNoticeData data, bool isFromServer = false)
            {

                if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                    return;

                GameDebug.Log("弹出游戏公告窗口");
                UIManager.Instance.ShowWindow("UILoginNoticeWindow", data, isFromServer);

                //if (string.IsNullOrEmpty(data.content) == false)
                //{

                    
                //}
            }


            public void StartGetServerInfos()
            {
                ServerListHelper.GetInstance().GetLastLoginServerInfo(OnGetLastLoginServerFinished);
            }


            /// <summary>
            /// 登陆sdk成功后的回调
            /// </summary>
            public void OnLoginCallback(int code , string msg)
            {
                if (mIsDestroy == true)
                {
                    return;
                }

                Debug.Log("onLoginCallback code = " + code + " msg = " + msg);
                switch (code)
                {
                    case (int)SDKControler.SDK_STATU_CODE.LOGIN_SUCCESS :
                        InitLoginCache();
                        break;
                    case  (int)SDKControler.SDK_STATU_CODE.LOGIN_FAIL :
                        //确定按钮的提示框
                        string  errorMsg = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_104")+msg + xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_105");
                        xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(errorMsg);
                        break;
                    case  (int)SDKControler.SDK_STATU_CODE.LOGIN_CANCEL :
                        UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_106"));
                        break;
                    case  (int)SDKControler.SDK_STATU_CODE.LOGIN_QQ :
                        break;
                    case  (int)SDKControler.SDK_STATU_CODE.LOGIN_QQ_MORE_TIME :
                        SDKControler.getSDKControler().loginSDK(OnLoginCallback);
                        break;
                    default :
                        UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_107"));
                        break;
                }

            }

            /// <summary>
            /// 初始化sdk成功后的回调函数
            /// </summary>
            public void OnInitCallback(CEventBaseArgs data)
            {
                GameDebug.LogError("OnInitCallback");

                SDKControler.getSDKControler().loginSDK(OnLoginCallback);

                // 暂时屏蔽服务器更新信息的功能
                //ServerListHelper.GetInstance().RequestServerUpdateNotice(GetServerUpdateNoticeFinished);
            }
        }
        
    }
}
