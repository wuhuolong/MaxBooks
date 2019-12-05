using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace xc.ui.ugui
{

    /// <summary>
    /// 日常开发面板
    /// </summary>
    public class UILoginWindow : UIBaseWindow
    {
        //--------------------------------------------------------
        //  变量定义
        //--------------------------------------------------------
        ServerInfo mSelectedServerInfo;

        List<Utils.DecimalTimer> mMaintainingServerTimers;

        // 登录界面
        GameObject m_MaskObject;
        //GameObject mLoginPanel;
        GameObject mLoadingIcon;
        Image mSelectedServerStateImage;
        Text mSelectedServerNameText;
        Button mLoginButton;
        Button mGotoServerListButton;
        GameObject mKVPanel;

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

        /// <summary>
        /// 版号信息
        /// </summary>
        Text mVersionInfoText;

        /// <summary>
        /// 背景
        /// </summary>
        GameObject mBgParent;
        
        //--------------------------------------------------------
        //  构造函数
        //--------------------------------------------------------
        public UILoginWindow()
        {
            mWndName = "UILoginWindow";
        }

        //--------------------------------------------------------
        //  虚函数
        //--------------------------------------------------------
        protected override void InitUI()
        {
            base.InitUI();

            mSelectedServerInfo = null;
            mMaintainingServerTimers = new List<Utils.DecimalTimer>();
            mMaintainingServerTimers.Clear();

            // 登录界面
            m_MaskObject = FindChild("mask");
            //mLoginPanel = FindChild<Transform>("LoginPanel").gameObject;
            mLoadingIcon = FindChild<Transform>("LoadingIcon").gameObject;
            mLoadingIcon.SetActive(false);
            mSelectedServerStateImage = FindChild<Image>("ServerStateImage");
            mSelectedServerNameText = FindChild<Text>("ServerNameText");

            mLoginButton = FindChild<Button>("LoginButton");
            mLoginButton.onClick.AddListener(OnClickLoginButton);
            mGotoServerListButton = FindChild<Button>("ChooseServerButton");
            mGotoServerListButton.onClick.AddListener(OnClickGotoServerListButton);


            mBtnAnnouncement = FindChild<Transform>("AnnouncementButton").gameObject.GetComponent<Button>();

            mBtnAnnouncement.onClick.AddListener(onShowLoginNotice);

            mUserButton = FindChild<Transform>("UserButton").gameObject.GetComponent<Button>();
            bool isShowUserCenterButton = true;
            string isShowUserCenterButtonStr = GameConstHelper.GetString("GAME_SYS_SHOW_SDK_USER_CENTER");
            if (isShowUserCenterButtonStr == "" || isShowUserCenterButtonStr == "0")
            {
                isShowUserCenterButton = false;
            }
            mUserButton.gameObject.SetActive(isShowUserCenterButton);
            mUserButton.onClick.AddListener(OnClickUserButton);

            mLogo = FindChild<Image>("Logo");
            mCustomLogoRawImage = FindChild<RawImage>("CustomLogoRawImage");

            //IOS
#if UNITY_IPHONE
            mLogo.gameObject.SetActive(true);
            mCustomLogoRawImage.gameObject.SetActive(false);
            LoadMaJiaImage majiaImage = mLogo.gameObject.AddComponent<LoadMaJiaImage>();
            var logoName = "logo.png";
            majiaImage.mPath = ResNameMapping.Instance.GetMappingName(logoName);

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

            }


            mVersionInfoText = FindChild<Text>("VersionInfoText");

            mBgParent = FindChild("BgParent");

            SetSelectedServerInfo(null);

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

#if UNITY_ANDROID
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
            }
            else
            {
                //GameDebug.LogError("Error, Can not load loading bg image: " + imageFileName);
                effect.SetActive(true);
            }
#endif

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SELECT_SERVER, OnSelectServerChange);
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
            if (SDKControler.getSDKControler().IsLoginSuccess)
                DBOSManager.getDBOSManager().getBridge().userCenter();
        }

        private void OnSelectServerChange(CEventBaseArgs data)
        {
            ServerInfo server_info = (ServerInfo)data.arg;

            SetSelectedServerInfo(server_info);
        }

        //for test
        private void onClickTestClear()
        {
            PlayerPrefs.DeleteKey(LoginNoticeData.LOGIN_ID_KEY);
        }

        protected override void UnInitUI()
        {
            base.UnInitUI();

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SELECT_SERVER, OnSelectServerChange);

            mLoginButton.onClick.RemoveAllListeners();
            mUserButton.onClick.RemoveAllListeners();
            mGotoServerListButton.onClick.RemoveAllListeners();


            mBtnAnnouncement.onClick.RemoveAllListeners();

            DestoryMaintainingServerTimers();

            ServerListHelper.Instance.ClearAllCallback();


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

        }

        protected override void ResetUI()
        {
            base.ResetUI();

            // 显示版本信息
            UIManager.Instance.ShowWindow("UIVersionWindow");

            UpdateLoginNotice();
            SetSelectedServerInfo(null);

            GlobalConfig globalConfig = GlobalConfig.GetInstance();

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
                }
                else
                {
                    mVersionInfoText.text = "";
                }
                if (mVersionInfoText != null)
                    mVersionInfoText.gameObject.SetActive(AuditManager.Instance.AuditAndIOS() == false);
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
#endif

            mLogo.SetNativeSize();
        }

        private void UpdateLoginNotice()
        {
            GameDebug.Log("开始获取游戏公告");

            UIManager.Instance.ShowWaitScreen(true);
            ////这里先获取后台通告信息
            string loginNoticeUrl = GlobalConfig.GetInstance().LoginNoticeUrl;

            GameDebug.Log("获取游戏公告" + loginNoticeUrl);

            MainGame.HttpRequest.GET(loginNoticeUrl, OnGetLoginNoticeInfo);
        }

        public void UpdateServerLogic()
        {

            bool show_login_btn = false;

            if (ShowParam.Length > 0)
            {
                show_login_btn = (int)ShowParam[0] == 1;
            }

            m_MaskObject.SetActive(true);
            mLoginButton.gameObject.SetActive(true);
            mGotoServerListButton.gameObject.SetActive(true);
            UIManager.Instance.ShowWaitScreen(true);
            ServerListHelper.Instance.GetLastLoginServerInfo(GetLastLoginServerInfoFinished);

        }


        private void OnGetLoginNoticeInfo(string url, string error, string reply, object userData)
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
                    UpdateServerLogic();
                });
                return;
            }
            GameDebug.Log("游戏公告获取成功");

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
                    //获取公告信息失败，获取服务器信息
                    UpdateServerLogic();
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
                if (data.type == 1)
                {
                    ShowNoticePanel(data, true);
                }
                else
                {
                    //通告没有变化而且不是强制弹出，开始获取服务器信息
                    //设置当前弹出ID
                    //UpdateServerLogic();
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
                //    //UpdateServerLogic();
                //}
            }

            // 总是获取服务器信息
            UpdateServerLogic();

            //PlayerPrefs.SetInt(LoginNoticeData.LOGIN_ID_KEY, data.id);
            UIManager.Instance.ShowWaitScreen(false);
        }


        private void ShowNoticePanel(LoginNoticeData data, bool isFromServer = false)
        {

            if (AuditManager.Instance.AuditAndIOS() && SDKHelper.GetSwitchModel())
                return;

            GameDebug.Log("弹出游戏公告窗口");
            UIManager.Instance.ShowWindow("UILoginNoticeWindow", data, isFromServer);

            //if (string.IsNullOrEmpty(data.content) == false)
            //{
                
            //}
        }


        protected override void HideUI()
        {
            base.HideUI();
        }

        //--------------------------------------------------------
        //  内部调用
        //--------------------------------------------------------
        void GetLastLoginServerInfoFinished(ServerInfo serverInfo)
        {
            UIManager.Instance.ShowWaitScreen(false);

            SetSelectedServerInfo(serverInfo);

            if (serverInfo != null)
            {
                // 获取服务器列表
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.GetServerList);
                ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.list_gs);
            }
        }
        

        void SetSelectedServerInfo(ServerInfo serverInfo)
        {
            mSelectedServerInfo = serverInfo;

            if (this.IsShow == false)
            {
                return;
            }

            if (serverInfo == null)
            {
                mSelectedServerStateImage.sprite = GetSpriteByState(0);
                mSelectedServerNameText.text = "";
            }
            else
            {
                mSelectedServerStateImage.sprite = GetSpriteByState(serverInfo.State);
                mSelectedServerNameText.text = serverInfo.Name;
            }
        }

        Sprite GetSpriteByState(EServerState state)
        {
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

        void LoginServer(ServerInfo serverInfo)
        {
            if (serverInfo == null)
            {
                GameDebug.LogError("Error, server info is null!!!");
                return;
            }

            //UIManager.Instance.ShowWaitScreen(true);
            mLoadingIcon.SetActive(true);

            ServerListHelper.GetInstance().CheckServerStateAndEnter(serverInfo, (ServerInfo retServerInfo, bool canEnter) =>
            {
                if (canEnter == false)
                {
                    UIManager.Instance.ShowWaitScreen(false);
                    mLoadingIcon.SetActive(false);
                }
            });

            // 点击登录按钮
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.ClickLoginButton);
        }

        void DestoryMaintainingServerTimers()
        {
            foreach (var timer in mMaintainingServerTimers)
            {
                timer.Destroy();
            }
            mMaintainingServerTimers.Clear();
        }

        //--------------------------------------------------------
        //  控件消息
        //--------------------------------------------------------       
        void OnClickLoginButton()
        {
            if (mSelectedServerInfo != null)
            {
                LoginServer(mSelectedServerInfo);
            }
            else
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("PLEASE_SELECT_ONE_SERVER"));
            }
        }

        // 点击选择服务器列表的按钮
        void OnClickGotoServerListButton()
        {
            //ShowServerListPanel();

            UIManager.Instance.ShowWindow("UIServerListWindow");
        }

    }
}
