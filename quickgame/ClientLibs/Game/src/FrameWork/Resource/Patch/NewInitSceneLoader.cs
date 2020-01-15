using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using xc;
using xc.ui;
using xc.ui.ugui;
using System;


namespace SGameFirstPass
{
    public class NewInitSceneLoader : MonoBehaviour
    {
        /// <summary>
        /// 是否开启补丁更新
        /// @note Editor下可打开本变量来测试bundle更新
        /// 其他平台下本变量由配置决定开关状态
        /// </summary>
        public bool PATCH_ON = false;

        public xpatch.XPatchManager PatchMgr;

        public static NewInitSceneLoader Instance;

        protected Canvas mCanvas; // 更新界面的Canvas
        protected Transform mMiniGameContainer; 
        protected Transform mVideoMovieContainer;
        protected PatchUI mPatchUI; //显示更新进度的UI
        public MessageBoxUI MessageBoxUI
        {
            get
            {
                return mMessageBoxUI;
            }
        }
        protected MessageBoxUI mMessageBoxUI; //显示提示框的UI

        public AssetBundleInfoRuntime g_server_bundle_info; //包含所有bundle信息
        public AssetPatchInfoRuntime g_server_patch_info; //包含所有patch信息
        public int BundleVersion; //当前获取到的bundle的版本号
        public float LoadProgressTime = 5.0f; // 预留给加载的等待时间

        private float mLastStepTime = 0; // 记录上一次登录/更新步骤的时间

        private Dictionary<LanguageType, string> langPathDic = new Dictionary<LanguageType, string>()
        {
            {LanguageType.SIMPLE_CHINESE, "" },
            {LanguageType.ASIAN_ENGLISH,"Eng" },
            {LanguageType.THAI, "Thai" },
            {LanguageType.VIETNAMESE, "Viet" },
        };

        protected bool mIsMiniGameInitSuccess = false;
        protected bool mIsVideoMovieInitSuccess = false;

        protected string[] mMiniGameActiveWhiteList =  new string[] { "UICamera", "MiniGameContainer", "Bg1", "Mask", "Wait", "MessageBox", "MiddleText" };

        public void Awake()
        {
            GlobalSettings.GetInstance();
            InitLocalizeRegion();
            InitQualitySettingConfig();

            var canvasName = "Canvas";
            var canvas = GameObject.Find(canvasName);
            if (canvas == null)
            {
                string canvasPath = string.Format("Core/Init{0}/Canvas", langPathDic[Const.Language]);
                //GameDebug.LogError("加载Canvas:" + canvasPath);
                var canvasPrefab = Resources.Load<GameObject>(canvasPath);
                canvas = GameObject.Instantiate(canvasPrefab) as GameObject;
                canvas.name = canvasName;

                // 新启动游戏_首次
                var firstStart = UserPlayerPrefs.Instance.GetInt(BuriedPointConst.firstStart, 0);
                if (firstStart == 0) {
                    UserPlayerPrefs.Instance.SetInt(BuriedPointConst.firstStart, 1);
                    UserPlayerPrefs.Instance.Save();
                    BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "launchgame_new_firsttime", 1);
                }
            }


#if UNITY_IPHONE
            // 初始化文件映射配置
            var mapJson = Application.streamingAssetsPath + "/map.json";
            ResNameMapping.Instance.Init(mapJson);

            //需要提前获取gameMark
            var fileName = ResNameMapping.Instance.GetMappingName("ios_audit_info.json");
            var filePath = string.Format("{0}/{1}", Application.streamingAssetsPath, fileName);
            AuditManager.Instance.ReadAuditInfo(filePath);
#endif


            // 获取游戏启动时间戳，安卓平台在安卓代码那边获取
#if !UNITY_ANDROID
            GlobalConfig.Instance.StartTimeStamp = CommonTool.GetCurTimeStamp();
#endif

            mLastStepTime = Time.realtimeSinceStartup;

            if (xc.Const.Region != xc.RegionType.CHINA)
            {
                if (Application.unityVersion != "2017.4.29f1")
                    Debug.LogError("当前unity版本不是2017.4.29f1, 请及时升级!!!");
            }
            else
            {
                if (Application.unityVersion != "2017.4.5f1")
                    Debug.LogError("当前unity版本不是2017.4.5f1, 请及时升级!!!");
            }

            // 初始化静态实例
            if (Instance != null)
            {
                Destroy(this);
                Debug.LogError("init scene loader is inited twice!");
                return;
            }
            Instance = this;

            mMiniGameContainer = canvas.transform.Find("MiniGameContainer");
            mVideoMovieContainer = canvas.transform.Find("VideoMovieContainer");

            // 获取各UI控件
            mPatchUI = canvas.GetComponent<PatchUI>();

            mMiniGameContainer = canvas.transform.Find("MiniGameContainer");

#if UNITY_IPHONE
            string tipFileName = ResNameMapping.Instance.GetMappingName("tip.json");
            var tipFilePath = string.Format("{0}/{1}", Application.streamingAssetsPath, tipFileName);
            mPatchUI.ReadContentInfo(tipFilePath);
#endif
            mCanvas = mPatchUI.GetComponent<Canvas>();
            mMessageBoxUI = canvas.GetComponentInChildren<MessageBoxUI>();
            if (mMessageBoxUI != null)
                mMessageBoxUI.gameObject.SetActive(false);

#if UNITY_IPHONE
            if (Const.Region == RegionType.CHINA)
            {
	            Transform bg1 = UIHelper.FindChildInHierarchy(mPatchUI.gameObject.transform, "Bg1");
	            if (bg1 != null)
	            {
	                LoadMaJiaImage majiaImage = bg1.gameObject.AddComponent<LoadMaJiaImage>();
	                var picName = "FirstLoad.png";
	                majiaImage.mPath = ResNameMapping.Instance.GetMappingName(picName);
	            }
            }
#endif
            if (Const.Region == RegionType.KOREA)
            {
                Transform bg1 = UIHelper.FindChildInHierarchy(mPatchUI.gameObject.transform, "Bg1");
                if (bg1 != null && bg1.parent != null)
                {
                    var parent_size = bg1.parent.GetComponent<RectTransform>().sizeDelta;
                    var screen_width = parent_size.x;
                    var cur_scale = screen_width / parent_size.y;
                    var min_scale = 1334.0f / 750;
                    if (cur_scale < min_scale)
                    {
                        var height = screen_width / min_scale;
                        var width = height * min_scale;
                        bg1.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                    }
                }
            }
            SetProcess(0);

            // 等分辨率设置完毕后再显示Canvas
            if(mCanvas != null)
                mCanvas.enabled = false;

            // sleep will block the download when longtime download
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            // 取消帧率锁定，进入游戏后再锁定帧率
            Application.targetFrameRate = Const.MAX_FPS;

            // 需要用到HttpRequest组件
            HttpRequest.Instance = this.gameObject.GetComponent<HttpRequest>();
            if (HttpRequest.Instance == null)
            {
                HttpRequest.Instance = this.gameObject.AddComponent<HttpRequest>();
            }

            // 点击流需要用到ComponentEmployer
            AssemblyBridge.Instance.ComponentEmployer = new XComponent();

            StartCoroutine(DeviceInit());
        }

        /// <summary>
        /// 初始化本地化地区、语言
        /// </summary>
        private void InitLocalizeRegion()
        {
            GameDebug.Log("InitLocalizeRegion");
            try
            {
                var localize_config = "Localize/localize_config";
                var text_asset = Resources.Load<TextAsset>(localize_config);
                var content = text_asset.text;
                var tex_format = MiniJSON.JsonDecode(content) as Hashtable;
                var region_str = (string)tex_format["region"];
                if (!string.IsNullOrEmpty(region_str))
                {
                    var region_type = (RegionType)Enum.Parse(typeof(RegionType), region_str);
                    Const.SetRegion(region_type);
                }
            }
            catch (Exception ex)
            {
                GameDebug.LogError(ex.Message);
            }

            LocalizeManager.Instance.Init();
        }

        /// <summary>
        /// 初始化图像配置
        /// </summary>
        private void InitQualitySettingConfig()
        {
            GameDebug.Log("InitQualitySettingConfig");
            try
            {
                var config = "QualitySetting/quality_setting_config";
                var text_asset = Resources.Load<TextAsset>(config);
                var content = text_asset.text;
                var tex_format = MiniJSON.JsonDecode(content) as Hashtable;
                var str = (string)tex_format["have_high_graphic_level"];
                if (!string.IsNullOrEmpty(str))
                {
                    if (str.Equals("True"))
                    {
                        Const.HAVE_HIGH_GRAPHIC_LEVEL = true;
                    }
                    else if (str.Equals("False"))
                    {
                        Const.HAVE_HIGH_GRAPHIC_LEVEL = false;
                    }
                }
            }
            catch (Exception ex)
            {
                GameDebug.LogError(ex.Message);
            }
        }

        /// <summary>
        /// 刘海屏适配
        /// </summary>
        public void FringeScreenFit()
        {
            // 先通过bridge的接口进行判断
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            bool isFringeScreen = bridge.hasNotch();

            // bridge的接口可能获取不到参数(ios\vivo等)，需要通过safeArea进行判断
            if (!isFringeScreen)
            {
                // TODO 增加刘海屏的机型列表
                
                // 当前屏幕分辨率
                int width = Screen.width;
                int height = Screen.height;

                // 安全区的屏幕分辨率
                var rect = Screen.safeArea;
                var safe_width = rect.width;
                var safe_height = rect.height;

                float design_scale = safe_width / safe_height;
                float current_scale = (float)width / (float)height;

                // 安全区的比例小于屏幕分辨率的时候表示是刘海屏
                isFringeScreen = current_scale > design_scale;
            }

            UIFitTool.IsFringeScreen = isFringeScreen;
        }
       
        /// <summary>
        /// 设置屏幕分辨率
        /// </summary>
        void SetScreenResolution()
        {
            // 当前屏幕分辨率
            int width = Screen.currentResolution.width;
            int height = Screen.currentResolution.height;

            // ui设计时的最大屏幕分辨率
            int design_width = 1280;
            int design_height = 720;
#if UNITY_IPHONE
            // 系统内存低于1G的ios设备，分辨率降低到1024以下
            if(SystemInfo.systemMemorySize <= 1024)
            {
                design_width = 1024;
                design_height = 576;
            }
#endif
            float design_scale = (float)design_width / design_height;
            float current_scale = (float)width / height;

            // 如果当前屏幕比例大于设计的比例，design_height不变
            if (current_scale > design_scale)
            {
                design_width = Mathf.FloorToInt(design_height * current_scale);
            }
            // 如果当前屏幕比例小于设计的比例，design_width不变
            else if (current_scale < design_scale)
            {
                design_height = Mathf.FloorToInt(design_width / current_scale);
            }

            // 如果目标分辨率比当前分辨率小，则需要进行缩放
            if (design_width < width)
            {
                if (design_width % 2 != 0)
                    design_width -= 1;

                if (design_height % 2 != 0)
                    design_height -= 1;

                Screen.SetResolution(design_width, design_height, true);
            }
        }

        /// <summary>
        /// 安卓平台从assets文件夹查找是否存在"loading_bg.jpg"图片，存在则优先显示
        /// </summary>
        public void SetCustomLoadingBg()
        {
#if UNITY_ANDROID
            string imageFileName = "loading_bg.jpg";
            byte[] imageData = DBOSManager.getDBOSManager().getBridge().loadExternalFileData(imageFileName);
            if (imageData != null)
            {
                TextureFormat textureFormat = TextureFormat.DXT1;
                int width = Screen.currentResolution.width;
                int height = Screen.currentResolution.height;

                Texture2D newTexture2D = new Texture2D(width, height, textureFormat, false);
                newTexture2D.LoadImage(imageData);
                mPatchUI.CustomBackground.texture = newTexture2D;
            }
            else
            {
                //GameDebug.LogError("Error, Can not load loading image: " + imageFileName);
            }
#endif
        }

        /// <summary>
        /// 进行设备初始化
        /// </summary>
        /// <returns></returns>
        IEnumerator DeviceInit()
        {
#if UNITY_ANDROID || UNITY_IPHONE || UNITY_MOBILE_LOCAL
            FringeScreenFit();
            SetScreenResolution();
            SetCustomLoadingBg();
            yield return new WaitForSeconds(0.5f);
#else
            yield return null;
#endif
            if(mCanvas != null)
                mCanvas.enabled = true;

            // iOS平台下先发送DeviceInit到控制服，成功之后才进入下一步初始化，否则一直让玩家重试
#if UNITY_IPHONE
            // 向后台请求设备标识
            ControlServerLogHelper.Instance.PostDeviceInit(PostDeviceInitFinished);
#else
            StartCoroutine(Init());
#endif
        }

        void DebugTimeMark(int step, string step_desc)
        {
            float current_time = Time.realtimeSinceStartup;
            Debug.Log(string.Format("step{0}: {1} cost:{2}", step, step_desc, current_time - mLastStepTime));
            mLastStepTime = current_time;
        }

        void OnDestroy()
        {
            Instance = null;
        }

        /// <summary>
        /// 请求设备标识错误
        /// </summary>
        /// <returns></returns>
        IEnumerator PostDeviceInitFinishedError()
        {
            string str = xc.TextHelper.InitSceneFailed;
            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(str, xc.TextHelper.BtnConfirm));

#if UNITY_ANDROID
            if (mPatchUI != null)
            {
                mPatchUI.show_wait_screen(true);
            }
#endif

            ControlServerLogHelper.Instance.PostDeviceInit(PostDeviceInitFinished);
        }

        /// <summary>
        /// 在更新时显示提示对话框
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ok_text"></param>
        /// <param name="cancel_text"></param>
        /// <param name="ok_action"></param>
        /// <param name="cancel_action"></param>
        public void ShowMessageBox(string text, string ok_text, string cancel_text, UnityAction ok_action = null, UnityAction cancel_action = null)
        {
            if (mMessageBoxUI == null)
            {
                GameDebug.LogError("ShowMessageBox:cannot find messagebox");
                return;
            }

            mMessageBoxUI.Show(text, ok_text, cancel_text, ok_action, cancel_action);
        }

        /// <summary>
        /// 在更新时显示提示对话框
        /// </summary>
        /// <param name="text"></param>
        /// <param name="btn_text"></param>
        /// <param name="click_action"></param>
        public void ShowMessageBox(string text, string btn_text, UnityAction click_action = null)
        {
            if (mMessageBoxUI == null)
            {
                GameDebug.LogError("ShowMessageBox:cannot find messagebox");
                return;
            }

            mMessageBoxUI.Show(text, btn_text, click_action);
        }

        public IEnumerator ShowRoutine(string text, string btn_text)
        {
            if (mMessageBoxUI == null)
            {
                GameDebug.LogError("ShowMessageBox:cannot find messagebox");
                yield break;
            }

            yield return mMessageBoxUI.ShowRoutine(text, btn_text);
        }

        public void SetProcessText(string text)
        {
            if(mPatchUI == null)
            {
                GameDebug.LogError("SetProcessText:cannot find PatchUI");
                return;
            }
            mPatchUI.set_process_text(text);
        }

        public void SetProcess(float process)
        {
            if (mPatchUI == null)
            {
                GameDebug.LogError("SetProcess:cannot find PatchUI");
                return;
            }
            mPatchUI.set_process(process);
        }

        public void SetProcessRatio(string ratio_text)
        {
            if (mPatchUI == null)
            {
                GameDebug.LogError("SetProcess:cannot find PatchUI");
                return;
            }
            mPatchUI.set_total_size_in_mb(ratio_text);
        }

        /// <summary>
        /// 从process进度条自动跑满
        /// </summary>
        /// <param name="process"></param>
        public void AutoProcess(float process, string process_text, int time = 0)
        {
            if (mPatchUI == null)
            {
                GameDebug.LogError("SetProcess:cannot find PatchUI");
                return;
            }

            mPatchUI.set_process_text(process_text);

            // 没有传入时间参数的时候，使用默认参数5s
            float realTime = 0;
            if (time != 0)
                realTime = time;
            else
                realTime = LoadProgressTime;

            mPatchUI.AutoProcess(process, realTime);
        }

        /// <summary>
        /// 完成设备标识的请求
        /// </summary>
        /// <param name="ret"></param>
        void PostDeviceInitFinished(bool ret)
        {
#if UNITY_ANDROID
            if (mPatchUI != null)
            {
                mPatchUI.show_wait_screen(false);
            }
#endif

            if (ret == true) // 返回正确
            {
                StartCoroutine(Init());
            }
            else // 返回错误
            {
                ShowCamera ();
                StartCoroutine(PostDeviceInitFinishedError());
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public IEnumerator Init()
        {
            DebugTimeMark(1, "device init");

#if UNITY_IPHONE
            // 初始化提审状态
            yield return StartCoroutine(InitAuditState());
            string fileUrl = string.Format("{0}/{1}", Application.streamingAssetsPath, ResNameMapping.Instance.GetMappingName("ProductInfo.json"));
            ProductInfoManager.GetInstance().ReadProductInfo(fileUrl);
#endif

                        //yield return StartCoroutine(UnPackRes());

                        // 添加Patch管理器
                        var go = new GameObject("patch");
            PatchMgr = go.AddComponent<xpatch.XPatchManager>();
            GameObject.DontDestroyOnLoad(go);

            // 通过宏定义设置各平台是否开启补丁下载
#if UNITY_EDITOR
            // editor下可自行打开PATCH_ON，打开后可以在editor下测试bundle更新和加载
            SGameEngine.ResourceLoader.EnableBundleInEditor = PATCH_ON;
            PatchMgr.EnableBundleInEditor = PATCH_ON;
#elif UNITY_ANDROID

#if UNITY_MOBILE_LOCAL || HD_RESOURCE
            PATCH_ON = false;
#else
            PATCH_ON = true;
#endif

#elif UNITY_IPHONE


#if UNITY_MOBILE_LOCAL || HD_RESOURCE
            PATCH_ON = false;
#else
            PATCH_ON = true;
#endif

#else
            PATCH_ON = false;
#endif

            // 各项初始化操作
            Application.logMessageReceived += OnLog;
            // 初始化bugly平台
            DBOSManager.getDBOSManager().InitBuglySDK();

            // 安卓环境下APK包的路径需要从Bridge接口重新获取
#if !UNITY_EDITOR && UNITY_ANDROID
            // 安卓平台assetbundle包的地址在APK内
            Const.BUNDLE_FILE_FOLDER_PACKAGE = DBOSManager.getOSBridge().getPackageResourcePath();
            Const.BUNDLE_FILE_FOLDER_PACKAGE =  "jar:file://" + Const.BUNDLE_FILE_FOLDER_PACKAGE.Substring (0, Const.BUNDLE_FILE_FOLDER_PACKAGE.Length - 1);
#endif

#if UNITY_IPHONE
            StartCheckUpdateApp();
#else
            StartPatch();
#endif

            yield return null;
        }


        /// <summary>
        /// 进行资源解压的操作
        /// </summary>
        /// <returns></returns>
        IEnumerator UnPackRes()
        {
#if UNITY_ANDROID
            // 从list.json中获取需要解压的文件
            var bundleFolder = wipe_file_sprit(Const.BUNDLE_FILE_FOLDER_DISK);
            Debug.Log("UnPackRes: " + bundleFolder);
            List<string> unPackList = new List<string>();
            /*var unPackFiles = Directory.GetFiles(bundleFolder, "*.bin");
            foreach(var file in unPackFiles)
            {
                unPackList.Add(Path.GetFileName(file));
            }*/
            unPackList.Add("1.bin");
            unPackList.Add("2.bin");
            unPackList.Add("3.bin");
            unPackList.Add("4.bin");

            /*using (var fileStream = new System.IO.FileStream(bundleFolder + "/list.json", FileMode.Open, FileAccess.Read))
            {
                try
                {
                    byte[] fileBytes = new byte[fileStream.Length];
                    fileStream.Read(fileBytes, 0, fileBytes.Length);
                    var jsonObject = MiniJSON.JsonDecodeFromBinary(fileBytes) as Hashtable;
                    var copyList = jsonObject["list"] as ArrayList;
                    foreach(var item in copyList)
                    {
                        var fileName = (string)item;
                        if(System.IO.Path.GetExtension(fileName) == ".bin")
                        {
                            unPackList.Add(fileName);
                        }
                    }

                }
                catch (Exception e)
                {
                    Debug.LogError("UnPackRes failed:" + e.Message);
                }
            }*/

            for (int i = 0; i< unPackList.Count; ++i)
            {
                var fileName = unPackList[i];
                Debug.Log("UnPackRes: " + fileName);
                var filePath = bundleFolder + "/" + fileName;
                var resUnPacker = new ResUnPacker(filePath, bundleFolder);
                if (!resUnPacker.Init())
                    yield break;

                resUnPacker.UnpackFiles();
                resUnPacker.Finish();
                File.Delete(filePath);
                yield return null;
            }
            
#endif
            yield return null;
        }

        /// <summary>
        /// 初始化提审信息
        /// </summary>
        /// <returns></returns>
        IEnumerator InitAuditState()
        {
            //AuditManager.Instance.ReadAuditInfo();

            //AuditManager.Instance.Open = true;
            //yield break;

            string urlKey = Const.CS_URL_KEY;
            string urlIV = Const.CS_URL_IV;
            string sign = string.Format("os=ios&packageVersion={0}&game_mark={1}", AuditManager.Instance.AuditVersion, GlobalConfig.Instance.GameMark);
            Debug.Log(string.Format("controlServer_oriSign_ps1 = {0}", sign));
            sign = WWW.EscapeURL(Utils.AES.Encode(sign, urlKey, urlIV));

            var server_url = string.Format("{0}ps1?sign={1}", GlobalConfig.Instance.CSURLV, sign);

            var www = new WWW(server_url);
            yield return www;

            while (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError("InitAuditState error:" + www.error);
                yield return null;

                www = new WWW(server_url);
                yield return www;
            }

            while (string.IsNullOrEmpty(www.text))
            {
                Debug.LogError("InitAuditState error: return is null");
                yield return null;

                www = new WWW(server_url);
                yield return www;
            }

            string wwwText = Utils.AES.Decode(www.text, urlKey, urlIV);
            var json_data = MiniJSON.JsonDecode(wwwText) as Hashtable;
            if (json_data == null)
            {
                Debug.LogError("InitAuditState error: json_data is null");

                yield return null;

                www = new WWW(server_url);
                yield return www;
            }

            var ret = json_data["result"];
            if (ret == null)
            {
                Debug.LogError("InitAuditState error: ret is null");

                yield return null;

                www = new WWW(server_url);
                yield return www;
            }

            var result = (int)(double)ret;

            if (xpatch.XPatchConfig.GetApkType() == xpatch.XPatchConfig.ApkType.EMPTY)
                AuditManager.Instance.OpenButCanPatch = (result == 1);
            else
                AuditManager.Instance.Open = (result == 1);

            if(AuditManager.Instance.Open && GlobalConfig.Instance.PlatformName == "ios")
            {
                GameObject go = new GameObject ("video");
                go.AddComponent<SplashVideo> ();
            }
            else
            {
                ShowCamera ();
            }
        }

        private void ShowCamera()
        {
            GameObject canvas = GameObject.Find ("Canvas");
            if (canvas != null) {
                Transform tran = canvas.transform.Find ("UICamera");
                if (tran != null)
                    tran.gameObject.SetActive (true);
            }
        }


        /// <summary>
        /// 开始检查苹果APP的更新
        /// </summary>
        void StartCheckUpdateApp()
        {
            // 检查App更新
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.AppUpdateCheckStart, "", false);

            HttpRequest.Instance.GET(GetAppUdateUrl(), OnGetAppVersion);
        }

        /// <summary>
        /// 获取苹果APP的更新的url
        /// </summary>
        /// <returns></returns>
        string GetAppUdateUrl()
        {
            var url = DBOSManager.getOSBridge().getUpdateCheckUrlEx();
            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }
            return url;
        }

        IEnumerator CheckUpdateAppError()
        {
            string str = xc.TextHelper.InitSceneFailed;
            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(str, xc.TextHelper.BtnConfirm));

            StartCheckUpdateApp();
        }

        /// <summary>
        /// 获取苹果APP的更新的回调
        /// </summary>
        /// <param name="url"></param>
        /// <param name="error"></param>
        /// <param name="reply"></param>
        /// <param name="userData"></param>
        void OnGetAppVersion(string url, string error, string reply, System.Object userData)
        {
            if (reply != null)
                Debug.Log("OnGetAppVersion, reply: " + reply);

            if (!string.IsNullOrEmpty(error))
            {
                // 检查App更新
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.AppUpdateCheckFail, error, false);

                StartCoroutine(CheckUpdateAppError());
                return;
            }

            reply = Utils.AES.Decode(reply, Const.CS_URL_KEY, Const.CS_URL_IV);
            Hashtable versionHashtable = MiniJSON.JsonDecode(reply) as Hashtable;
            if (versionHashtable == null)
            {
                StartCoroutine(CheckUpdateAppError());
                return;
            }

            Hashtable argsHashtable = versionHashtable["args"] as Hashtable;
            if (argsHashtable == null)
            {
                // 检查App更新
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.AppUpdateCheckFail, "Get update args error", false);

                StartCoroutine(CheckUpdateAppError());
                return;
            }

            // 检查App更新
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.AppUpdateCheckEnd, "", false);

            ArrayList update_cfg = argsHashtable["update_cfg"] as ArrayList;

            string app_url = "";
            string app_ver = "";
            int must_update = 1;
            if (update_cfg != null)
            {
                for (int i = 0; i < update_cfg.Count; ++i)
                {
                    Hashtable update_table = update_cfg[i] as Hashtable;

                    if (update_table != null)
                    {
                        string type = update_table["type"] as string;
                        if (!string.IsNullOrEmpty(type) && type == "app")
                        {
                            System.Object isAppStore = update_table["isAPPStore"];
                            if (isAppStore != null)
                            {
                                int appstore = (int)(double)isAppStore;

                                if (appstore == 1)
                                {
                                    app_url = update_table["url"] as string;
                                    app_ver = update_table["ver"] as string;
                                    must_update = (int)(double)update_table["must"];
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            IBridge bridge = DBOSManager.getOSBridge();
            if (app_ver != "" && bridge.getAppVersion() != app_ver)
            {
                string str = xc.TextHelper.InitSceneNewVersion;
                if (must_update == 1)   // 强制更新
                {
                    ShowMessageBox(str, xc.TextHelper.BtnDownload, () =>
                    {
                        GotoDownloadApp(app_url);
                    });
                }
                else  // 不强制更新
                {
                    ShowMessageBox(str, xc.TextHelper.BtnDownload, xc.TextHelper.BtnCancel, () =>
                    {
                        GotoDownloadApp(app_url);
                    }, () =>
                    {
                        StartPatch();
                    });
                }
            }
            else
            {
                StartPatch();
            }
        }

        /// <summary>
        /// 跳转到下载app的页面
        /// </summary>
        /// <param name="app_url"></param>
        void GotoDownloadApp(string app_url)
        {
            DebugTimeMark(2, "app update check");
            Application.OpenURL(app_url);
            Application.Quit();
        }

        /// <summary>
        /// 开始更新
        /// </summary>
        protected void StartPatch()
        {
            mPatchUI.init();

            // 未开启更新的时候就直接进入游戏
            if (PATCH_ON && AuditManager.Instance.Open == false)
            {
                if (IsShowMiniGame())
                {
                    if (IsKoreanMiniGamePlatform())
                        UIHelper.SetChildrenActiveExclude(mPatchUI.transform, false, mMiniGameActiveWhiteList);
                    else
                        mPatchUI.set_process_text(xc.TextHelper.StartUpgrade);

                    StartCoroutine(CoCheckStartMiniGame());
                }
                else if (IsVideoMoviePlatform())
                {
                    mPatchUI.set_process_text(xc.TextHelper.StartUpgrade);
                    StartCoroutine(CoCheckStartVideoMovie());
                }
                else
                {      
					mPatchUI.set_process_text(xc.TextHelper.StartUpgrade);             
                    StartCoroutine(Patch());
                }                 
            }
            else
            {
                StartCoroutine(EntetGameWithoutPatch());
            }
        }

        /// <summary>
        /// 更新完毕，进入游戏
        /// </summary>
        protected IEnumerator EnterGame()
        {
            DebugTimeMark(8, "enter game start");

            DBTableManager.Instance.Init();

            // 更新完毕后就加载表格，以免一些游戏常量获取不到
            yield return StartCoroutine(DBManager.GetInstance().Load());

            // 保存游戏版本号
            string json = DBManager.Instance.LoadDBFile("DB/Common/version.json");
            if (!string.IsNullOrEmpty(json))
            {
                var jsonObj = MiniJSON.JsonDecode(json) as Hashtable;
                if (jsonObj != null)
                {
                    var ver = jsonObj["version"];
                    if (ver != null)
                    {
                        VersionInfoManager.Instance.GameVersion = ver.ToString();
                    }
                }
            }

            // 由于更新界面不采用游戏内的UI系统，所以存在2个EventSystem
            // 这里要提前将自身的EventSystem干掉，否则游戏内的EventSystem会无法正常使用
            var evt_sys = FindObjectOfType<EventSystem>();
            if (evt_sys != null)
            {
                evt_sys.enabled = false;
                GameObject.Destroy(evt_sys.gameObject);
            }

            DebugTimeMark(9, "enter game end");
#if UNITY_IPHONE
            yield return StartCoroutine(GetAuditWidgetIds());
#endif

#if USE_HOT && !UNITY_EDITOR
            // ios提审时候不进行c#代码热更
            if(!AuditManager.Instance.Open)
                yield return StartCoroutine(wxb.hotMgr.Init());
#endif
            Application.logMessageReceived -= OnLog;

            yield return StartCoroutine(xc.MainGame.EnterGame());
        }

        //获取送审时候需要屏蔽的控件列表
        private IEnumerator GetAuditWidgetIds()
        {
            //送审的时候  获取需要屏蔽的控件id 和 系统id
            if (AuditManager.Instance.Open == false && AuditManager.Instance.OpenButCanPatch == false)
             	yield break;

            string urlKey = Const.CS_URL_KEY;
            string urlIV = Const.CS_URL_IV;
            string sign = string.Format("os=ios&game_mark={0}&packageVersion={1}", GlobalConfig.Instance.GameMark, AuditManager.Instance.AuditVersion);
            Debug.Log(string.Format("controlServer_oriSign_PBSysWigetIds2 = {0}", sign));
            sign = WWW.EscapeURL(Utils.AES.Encode(sign, urlKey, urlIV));

            var audit_url = string.Format("{0}PBSysWigetIds2?sign={1}", GlobalConfig.Instance.CSURLVEX, sign);
            
            var audit_www = new WWW(audit_url);
            yield return audit_www;

            string wwwText = Utils.AES.Decode(audit_www.text, urlKey, urlIV);
            Hashtable json_data = MiniJSON.JsonDecode(wwwText) as Hashtable;
            ArrayList type_list = json_data["args"] as ArrayList;
            for (int i = 0; i < type_list.Count; i++)
            {
                AddShieldId("systemId", type_list[i] as Hashtable);
                AddShieldId("widgetId", type_list[i] as Hashtable);
            }
        }
        private void AddShieldId(string key, Hashtable json_data)
        {
            Hashtable type_hash = json_data[key] as Hashtable;
            if (type_hash == null)
                return;
            string type_ids = type_hash["ids"] as string;
            string[] type_array_ids = type_ids.Split(',');
            for (int i = 0; i < type_array_ids.Length; i++)
            {
                if (key == "widgetId")
                {
                    AuditManager.Instance.AddShieldWId(Convert.ToUInt32(type_array_ids[i]));
                }
                else
                {
                    AuditManager.Instance.AddShiledSId(Convert.ToUInt32(type_array_ids[i]));
                }
            }
        }

         




        /// <summary>
        /// 从StreamingAsset目录中拷贝Bundle文件
        /// </summary>
        /// <returns></returns>
        protected IEnumerator CopyBundleFromStreamingAsset()
        {
            // 拷贝资源打点
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResStart, "", false);

            mPatchUI.set_process_text(xc.TextHelper.InitSceneFirstRunTips);

            // 创建bundle文件夹
            if (!Directory.Exists(xc.Const.BUNDLE_FILE_FOLDER_DISK_FOR_WRITE))
            {
                Directory.CreateDirectory(xc.Const.BUNDLE_FILE_FOLDER_DISK_FOR_WRITE);
            }

            // 获取bundle资源文件夹路径
#if UNITY_IPHONE
            var bundle_path_at_apk = xc.Const.BUNDLE_FILE_FOLDER_PACKAGE;
            bundle_path_at_apk = wipe_file_sprit(bundle_path_at_apk);
#else
            var bundle_path_at_apk = xc.Const.BUNDLE_FILE_FOLDER_PACKAGE;
#endif

            var total = 0L; // 需要拷贝的文件数量

            // 获取需要拷贝的文件数量和大小，并进行剩余空间检查(android测试模式可以不用检查)
#if UNITY_IPHONE
            // 加载包内的dl_res.data
            var dlResPath = string.Format("{0}/dl_res.data", bundle_path_at_apk);
            dlResPath = ResNameMapping.Instance.GetMappingPath(dlResPath, Const.BUNDLE_FOLDER_NAME , "dl_res.data");
            Debug.Log("start read dl_res.data:" + dlResPath);

            var total_bytes_to_copy = 0L; // 需要拷贝的文件字节数
            try
            {
                using (var fileStream = new FileStream(dlResPath, FileMode.Open, FileAccess.Read))
                {
                    using (var dlResFileReader = new BinaryReader(fileStream))
                    {
                        var resInfoText = dlResFileReader.ReadString();
                        var resInfo = resInfoText.Split(',');
                        if (resInfo.Length >= 2)
                        {
                            total = long.Parse(resInfo[0]);
                            total_bytes_to_copy = long.Parse(resInfo[1]);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogErrorFormat("read (dl_res.data) from apk failed! Error = {0}", e.Message);
                
                // 拷贝资源打点
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, e.Message, false);
                yield break;
            }

            var total_bytes_to_copy_in_mb = total_bytes_to_copy / 1024.0f / 1024.0f;
            var need_space_in_mb = total_bytes_to_copy_in_mb * 1.5;
            if (need_space_in_mb - total_bytes_to_copy_in_mb > 50)
            {
                need_space_in_mb = total_bytes_to_copy_in_mb + 50;
            }

            // 磁盘空间检查
            var free_space_in_mb = DBOSManager.getOSBridge().getStorageFreeSize();
            if (free_space_in_mb < need_space_in_mb)
            {
                VideoMovieManager.Instance.EndPlay();
				// 拷贝资源打点
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, xc.TextHelper.InitSceneLackStorage, false);
                
                yield return StartCoroutine(mMessageBoxUI.ShowRoutine(xc.TextHelper.InitSceneLackStorage, xc.TextHelper.BtnConfirm));

                Application.Quit();
            }     
#endif

            var current = 0; // 当前拷贝的文件数量
#if UNITY_IPHONE
            var start = Time.realtimeSinceStartup;

            CopyProgress.Stage = 0;

            // 从文件映射表中读取bin文件路径
            var binFilesPath = ResNameMapping.Instance.GetBinFiles();
            if(binFilesPath.Count <= 0)
            {
                Debug.LogError("read bin file info failed");
                
                // 拷贝资源打点
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, "read bin file info failed", false);
                yield break;
            }

            // 获取bin文件的完整路径
            var streamAssetPath = Application.streamingAssetsPath;
            var unPackFiles = new List<string>();
            foreach (var path in binFilesPath)
            {
                var filePath = string.Format("{0}/{1}", streamAssetPath, path);
                unPackFiles.Add(filePath);
            }

            // 获取文件夹路径
            var targetFolder = wipe_file_sprit(Const.BUNDLE_FILE_FOLDER_DISK);

            // 第一阶段资源解压开始
            BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_decompression1_begin", 1);

            List<string> unPackList1 = new List<string>();
            int halfLen = unPackFiles.Count / 2;
            int i = 0;
            for (;i< halfLen; ++i)
            {
                var file = unPackFiles[i];
                unPackList1.Add(file);
            }

            List<string> unPackList2 = new List<string>();
            for (; i < unPackFiles.Count; ++i)
            {
                var file = unPackFiles[i];
                unPackList2.Add(file);
            }

            var copying1 = new ResCopying();
            copying1.TargetFolder = targetFolder;
            copying1.UnPackList = unPackList1;
            var copyThread1 = new System.Threading.Thread(copying1.Start);
            copyThread1.IsBackground = true;
            copyThread1.Start();

            var copying2 = new ResCopying();
            copying2.TargetFolder = targetFolder;
            copying2.UnPackList = unPackList2;
            var copyThread2 = new System.Threading.Thread(copying2.Start);
            copyThread2.IsBackground = true;
            copyThread2.Start();

            bool decompress_30per_done = false;
            bool decompress_60per_done = false;

            while (CopyProgress.Stage != 2)
            {
                current = CopyProgress.Progress;

                var per = current / (float)total;

                if (Const.Region == RegionType.SEASIA && decompress_30per_done == false && per > 0.3)
                {
                    decompress_30per_done = true;
                    BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_decompression1_30per", 1);
                }

                if (Const.Region == RegionType.SEASIA && decompress_60per_done == false && per > 0.6)
                {
                    decompress_60per_done = true;
                    BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_decompression1_60per", 1);
                }

                SetProcess(per);
                mPatchUI.set_total_size_in_mb(string.Format("{0}/{1}", current, total));
                yield return null;
            }
            // 第一阶段资源解压 结束
            BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_decompression1_end", 1);

            // 拷贝 配置文件
            List<string> configs = new List<string>();
            configs.Add("dl_files.data");
            configs.Add("dl_patches.data");
            configs.Add("0.unity3d");  // 最后才拷贝 0.unity3d
            var configfileBytes = new byte[512 * 1024]; // 512K
            foreach (var config_file in configs)
            {
                var config_file_path = string.Format("{0}/{1}", Const.persistentDataPath, config_file);
                try
                {
                    var url = string.Format("{0}/{1}", bundle_path_at_apk, config_file);
                    url = ResNameMapping.Instance.GetMappingPath(url, Const.BUNDLE_FOLDER_NAME, config_file);
                    Debug.Log("read file:" + url);
                    using (var fileStream = new FileStream(url, FileMode.Open, FileAccess.Read))
                    {
                        var filelen = (int)fileStream.Length;
                        if (filelen > configfileBytes.Length)
                            configfileBytes = new byte[filelen];
  
                        fileStream.Read(configfileBytes, 0, filelen);

                        using (var outFileStream = new FileStream(config_file_path, FileMode.Create, FileAccess.Write))
                        {
                            outFileStream.Write(configfileBytes, 0, filelen);
                            outFileStream.Flush();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogErrorFormat("wrtie config file failed! error = {0}", e.Message);

                    // 拷贝资源打点
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, e.Message, false);
                }
            }
            
            configfileBytes = null;
            float current_time = Time.realtimeSinceStartup;
            Debug.Log(string.Format("copying cost:{0}",current_time - start));
#else
            var configWWW = new WWW(string.Format("{0}/0.unity3d", bundle_path_at_apk)); // 加载包内的0.unity3d
            yield return configWWW;

            if (!string.IsNullOrEmpty(configWWW.error))
            {
                Debug.LogErrorFormat("read (0.unity3d) from apk failed! Error = {0}", configWWW.error);

                // 拷贝资源打点
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, configWWW.error, false);
                yield break;
            }

            var assetBundle = configWWW.assetBundle;
            if (assetBundle == null)
            {
                Debug.LogError("read (0.unity3d) from apk failed! assetbundle is null");

                // 拷贝资源打点
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, "read (0.unity3d) from apk failed! assetbundle is null", false);
                yield break;
            }

            var bundle_info_runtime = assetBundle.LoadAsset<AssetBundleInfoRuntime>("1");
            var asset_path_to_bundle_info = bundle_info_runtime.to_dictionary();
            var patch_info_runtime = assetBundle.LoadAsset<AssetPatchInfoRuntime>("2");

            // 根据分包配置来设置需要拷贝的bundle信息
            List<AssetBundleInfoItem> need_copy_bundle_info = new List<AssetBundleInfoItem>();
            foreach (var patch_info in patch_info_runtime.info)
            {
                if (patch_info.id == 0)
                {
                    foreach (var bundle_id in patch_info.bundleIds)
                    {
                        var bundle_info = asset_path_to_bundle_info[bundle_info_runtime.assetpathList[bundle_id]];
                        need_copy_bundle_info.Add(bundle_info);
                        total++;
                    }
                    break;
                }
            }

            // 拷贝bundle文件
            foreach (var bundle in need_copy_bundle_info)
            {
                if (bundle != null)
                {
                    var file_url = string.Format("{0}/{1}.unity3d", bundle_path_at_apk, bundle.bundleName);
                    var file_save_path = string.Format("{0}/{1}.unity3d", xc.Const.BUNDLE_FILE_FOLDER_DISK_FOR_WRITE, bundle.bundleName);

                    if (!File.Exists(file_save_path))
                    {
                        WWW www = new WWW(file_url);
                        yield return www;

                        if (!string.IsNullOrEmpty(www.error))
                        {
                            Debug.LogErrorFormat("read bundle ({0}) from apk failed! Error = {1}", bundle.bundleName, www.error);

                            // 拷贝资源打点
                            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, www.error, false);
                        }
                        else
                        {
                            try
                            {
                                File.WriteAllBytes(file_save_path, www.bytes);
                            }
                            catch (Exception e)
                            {
                                Debug.LogErrorFormat("write bundle ({0}) to sdcard failed! Error = {1}", bundle.bundleName, e.Message);

                                // 拷贝资源打点
                                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, e.Message, false);
                            }
                        }

                        www.Dispose();
                    }
                }

                ++current;

                SetProcess(current / (float)total);
                mPatchUI.set_total_size_in_mb(string.Format("{0}/{1}", current, total));
            }

            // 最后才拷贝 0.unity3d
            try
            {
                var bundle_config_file_path = string.Format("{0}/0.unity3d", Const.persistentDataPath);
                File.WriteAllBytes(bundle_config_file_path, configWWW.bytes);
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("write (0.unity3d) to sdcard failed! Error = {0}", e.Message);

                // 拷贝资源打点
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResFail, e.Message, false);
            }

            assetBundle.Unload(true);
            configWWW.Dispose();
#endif

            // 拷贝资源打点
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.CopyResEnd, "", false);
            ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.unzip_res);
        }

        /// <summary>
        /// 开始进行补丁更新
        /// </summary>
        protected IEnumerator Patch()
        {
            Debug.Log("InitSceneLoader::Patch: patch-start");
            Debug.Log(string.Format("InitSceneLoader::Patch: patch-stream dir{0}", Const.BUNDLE_FILE_FOLDER_PACKAGE));
            Debug.Log(string.Format("InitSceneLoader::Patch: patch-persisit dir{0}", Const.BUNDLE_FILE_FOLDER_DISK));

            // 获取更新地址
#if UNITY_EDITOR
            // editor下使用android的资源来测试（因为ftp上没有部署window的资源）
            var server_url = @"http://s01.huiwaninfo.net:8087/XControl/v2/servlet/UpdateCheck?game_mark=zl_cehua&platform=android&appv=2.0.0&libv=0.0.0&imei=359786050902015&device_mark=&cpu=Intel&extend=&api_ver=1.0&res_v=1&res_v=1";

#elif UNITY_IPHONE
            var server_url = DBOSManager.getOSBridge().getUpdatePatchUrl();
#else
            var server_url = DBOSManager.getOSBridge().getUpdateCheckUrl();
#endif
            PatchMgr.SetUpdateCheckUrl(server_url);

            // 检查更新开始
            BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "check_update_begin", 1);

            var progress = PatchMgr.CreatePatchProcess();

#if UNITY_IPHONE
            // 首次运行将bundle拷贝到sdcard上
            var need_copy = false;

            string sdVersionFile = Const.persistentDataPath + "/" + "bundle_version.unity3d";
            string packageVersionFile = string.Format("{0}/{1}", Application.streamingAssetsPath, ResNameMapping.Instance.GetMappingName("bundle_version.unity3d"));
            if (!File.Exists(sdVersionFile))
            {
                need_copy = true;
            }
            else
            {
                if (xpatch.XPatchConfig.IsBinPatchPlatform())
                {
                    need_copy = false;
                }
                else
                {
	                var sdVersion = int.Parse(File.ReadAllText(sdVersionFile));
	                var packageVersion = int.Parse(File.ReadAllText(packageVersionFile));
	                if (packageVersion > sdVersion)// 覆盖资源
	                {
	                    need_copy = true;

	                    // 读取SD卡文件列表信息
	                    PatchMgr.InitSDFileInfo();
	                }
	            }
            }
#else
            var need_copy = false;
#endif

            // 安卓版本由app程序进行资源的拷贝
#if UNITY_ANDROID
            Debug.Log("skip CopyBundleFromStreamingAsset");
#else
            if (need_copy)// ios非提审状态下需要拷贝bundle文件
            {
                yield return StartCoroutine(CopyBundleFromStreamingAsset());
            }
#endif

            DebugTimeMark(3, "copy bundle");

            // iOS版本需要把bundle_version.unity3d文件拷贝到外面
#if UNITY_IPHONE
            if (need_copy)
            {
                var bundle_path_at_apk = Const.BUNDLE_FILE_FOLDER_PACKAGE;
                var src_folder = wipe_file_sprit(bundle_path_at_apk) + "/Patch";
                var dl_patch_res = string.Format("{0}/dl_res.data", src_folder);
                dl_patch_res = ResNameMapping.Instance.GetMappingPath(dl_patch_res, Const.BUNDLE_PATCH_FOLDER_NAME, "dl_res.data");

                // 对于马甲包，需要将在包内的补丁释放到包外
                if (File.Exists(dl_patch_res))
                {
                    CopyProgress.Stage = 0;

                    mPatchUI.set_process_text("释放补丁文件");

                    Debug.Log("start read dl_patch_res.data:" + dl_patch_res);

                    var total = 0L; // 需要拷贝的文件数量
                    var total_bytes_to_copy = 0L; // 需要拷贝的文件字节数
                    try
                    {
                        using (var fileStream = new FileStream(dl_patch_res, FileMode.Open, FileAccess.Read))
                        {
                            using (var dlResFileReader = new BinaryReader(fileStream))
                            {
                                var resInfoText = dlResFileReader.ReadString();
                                var resInfo = resInfoText.Split(',');
                                if (resInfo.Length >= 2)
                                {
                                    total = long.Parse(resInfo[0]);
                                    total_bytes_to_copy = long.Parse(resInfo[1]);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogErrorFormat("read (dl_patch_apply.data) from apk failed! Error = {0}", e.Message);
                        yield break;
                    }

                    var targetFolder = wipe_file_sprit(Const.BUNDLE_FILE_FOLDER_DISK);

                    // 获取.patch文件列表
                    var patchFiles = ResNameMapping.Instance.GetPatchFiles();
                    if(patchFiles.Count <= 0)
                    {
                        Debug.LogError("read patch file config error");
                        yield break;
                    }

                    // 获取映射之后的.patch文件名
                    var streamAssetPath = Application.streamingAssetsPath;
                    var unPackList = new List<string>();
                    foreach(var patch_file in patchFiles)
                    {
                        var filePatch = string.Format("{0}/{1}", streamAssetPath, patch_file);
                        unPackList.Add(filePatch);
                    }

                    var copying = new ResCopying();
                    copying.TargetFolder = targetFolder;
                    copying.UnPackList = unPackList;
                    var copyThread = new System.Threading.Thread(copying.Start);
                    copyThread.IsBackground = true;
                    copyThread.Start();

                    while(CopyProgress.Stage != 1)
                    {
                        var current = CopyProgress.Progress;
                        SetProcess(current / (float)total);
                        mPatchUI.set_total_size_in_mb(string.Format("{0}/{1}", current, total));
                        yield return null;
                    }

                    // 拷贝 配置文件
                    List<string> configs = new List<string>();
                    configs.Add("dl_files.data");
                    configs.Add("0.unity3d");  // 最后才拷贝 0.unity3d
                    var configfileBytes = new byte[512 * 1024]; // 512K
                    foreach (var config_file in configs)
                    {
                        var config_file_path = string.Format("{0}/{1}", Const.persistentDataPath, config_file);
                        try
                        {
                            var url = string.Format("{0}/{1}", src_folder, config_file);
                            url = ResNameMapping.Instance.GetMappingPath(url, Const.BUNDLE_PATCH_FOLDER_NAME, config_file);
                            Debug.Log("read file:" + url);
                            using (var fileStream = new FileStream(url, FileMode.Open, FileAccess.Read))
                            {
                                var filelen = (int)fileStream.Length;
                                if (filelen > configfileBytes.Length)
                                    configfileBytes = new byte[filelen];

                                fileStream.Read(configfileBytes, 0, filelen);

                                using (var outFileStream = new FileStream(config_file_path, FileMode.Create, FileAccess.Write))
                                {
                                    outFileStream.Write(configfileBytes, 0, filelen);
                                    outFileStream.Flush();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.LogErrorFormat("wrtie config file failed! error = {0}", e.Message);
                        }
                    }
                    configfileBytes = null;

                    // 拷贝马甲包补丁的版本号
                    string[] filePath = new string[1];
                    filePath[0] = ResNameMapping.Instance.GetMappingName("bundle_version.unity3d");
                    yield return NewInitSceneLoader.Instance.StartCoroutine(NewInitSceneLoader.Instance.copy_streamassets(filePath, Const.persistentDataPath + "/", new string[] { "bundle_version.unity3d" }, true));
                }
                else
                {
                    // 拷贝版本号
                    string[] filePath = new string[1];
                    filePath[0] = ResNameMapping.Instance.GetMappingName("bundle_version.unity3d");
                    yield return NewInitSceneLoader.Instance.StartCoroutine(NewInitSceneLoader.Instance.copy_streamassets(filePath, Const.persistentDataPath + "/",new string[] { "bundle_version.unity3d" }, true));
                }
            }
#endif

            DebugTimeMark(4, "copy bundle_version.unity3d");

            // 拷贝bundle文件之后再进行文件信息的初始化
            PatchMgr.InitFileInfo();

            // 获取资源更新信息
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res4UpdateCheckStart, "", false);

            // 进行一些初始化操作，包括版本号检查、更新0.unity3d等
            yield return StartCoroutine(PatchMgr.Init(progress));

            // 从控制服请求更新信息
            var error_cnt = 0;
            while (PatchMgr.State != xpatch.EPatchState.Ready)
            {
                if (progress.HasError)
                {
                    Debug.LogError("InitSceneLoader::Patch init failed, error = " + progress.Error);

                    if (error_cnt < 3)
                    {
                        ++error_cnt;

                        // retry
                       yield return StartCoroutine(PatchMgr.Init(progress));
                    }
                    else
                    {
                        mPatchUI.set_process_text(progress.Error);
                        VideoMovieManager.Instance.EndPlay();
                        // 获取资源更新信息
                        ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res4UpdateCheckFail, progress.Error, false);

                        yield return StartCoroutine(mMessageBoxUI.ShowRoutine(xc.TextHelper.InitSceneGetUpgradeInfoFailed, xc.TextHelper.BtnRetry, xc.TextHelper.BtnCancel));

                        if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                        {
                            Application.Quit();
                        }
                        else
                        {
                            error_cnt = 0;

                            // retry
                            yield return StartCoroutine(PatchMgr.Init(progress));
                        }
                    }
                }

                mPatchUI.set_process_text(progress.StepTxt);
                SetProcess(progress.Value);
                mPatchUI.set_total_size_in_mb(string.Format("{0}/{1}", progress.Current, progress.Total));

                // wait one frame
                yield return null;
            }

            DebugTimeMark(5, "request bundle update info");

            // 统计所有需要下载的信息
            PatchMgr.CollectAllPatchInfo(progress);

            // 获取资源更新信息
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res4UpdateCheckEnd, "", false);
            ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.check_update);

            while (!progress.IsReady)
            {
                mPatchUI.set_process_text(progress.StepTxt);
                SetProcess(progress.Value);

                // wait one frame
                yield return null;
            }

            DebugTimeMark(6, "collect patch info");

            BundleVersion = PatchMgr.ServerVersion;
            g_server_bundle_info = PatchMgr.BundleConfig;
            g_server_patch_info = PatchMgr.PatchConfig;

            // 保存本地资源版本信息
            string local_version = string.Format("{0}.{1}.{2}", DBOSManager.getDBOSManager().Res1Version, DBOSManager.getDBOSManager().Res2Version, PatchMgr.LocalVersion);
            VersionInfoManager.Instance.LocalVersion = local_version;
            var versionInfo = VersionInfoManager.Instance.LocalVersionInfo;
            var version = 0;
            int.TryParse(DBOSManager.getDBOSManager().Res1Version, out version);
            versionInfo[1] = version;
            version = 0;
            int.TryParse(DBOSManager.getDBOSManager().Res2Version, out version);
            versionInfo[2] = version;

            // 保存最新资源版本信息
            string res1_remote_ver = DBOSManager.getDBOSManager().Res1Version;
            if(PatchMgr.LatestVersionInfo.ContainsKey(1))
            {
                res1_remote_ver = PatchMgr.LatestVersionInfo[1].ToString();
            }

            string res2_remote_ver = DBOSManager.getDBOSManager().Res2Version;
            if (PatchMgr.LatestVersionInfo.ContainsKey(2))
            {
                res2_remote_ver = PatchMgr.LatestVersionInfo[2].ToString();
            }

            // bundle资源版本号
            int res4_ver = PatchMgr.ServerVersion > PatchMgr.LocalVersion ? PatchMgr.ServerVersion : PatchMgr.LocalVersion;
            versionInfo[4] = res4_ver;

            string remote_version = string.Format("{0}.{1}.{2}", res1_remote_ver, res2_remote_ver, res4_ver);
            VersionInfoManager.Instance.RemoteVersion = remote_version;

            var total_bytes_to_download = progress.TotalBytesToDownload;
            var total_bytes_to_download_in_mb = total_bytes_to_download / 1024.0f / 1024.0f;

            // 检查更新结束
            BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "check_update_end", 1);

            if (progress.NeedDownload)
            {
                // 更新资源
                ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res4UpdateStart, "", false);
                // 磁盘空间检查
                var free_space_in_mb = DBOSManager.getOSBridge().getStorageFreeSize();

                // 计算需要的磁盘空间（预留多点空间，是下载需求大1.5倍，最多不多于50Mb）
                var need_space_in_mb = total_bytes_to_download_in_mb * 1.5;
                if (need_space_in_mb - total_bytes_to_download_in_mb > 50) {
                    need_space_in_mb = total_bytes_to_download_in_mb + 50;
                }

                if (free_space_in_mb < need_space_in_mb)
                {
                    // 更新资源
                    ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res4UpdateFail, xc.TextHelper.InitSceneLackStorage, false);

                    VideoMovieManager.Instance.EndPlay();
                    yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                            xc.TextHelper.InitSceneLackStorage, xc.TextHelper.BtnConfirm));

                    Application.Quit();
                }

                // 移动数据网络
                var cur_network_state = Application.internetReachability;
                if (Const.Region == RegionType.CHINA)
                {
                    if (cur_network_state == NetworkReachability.ReachableViaCarrierDataNetwork)
                    {
                        if (total_bytes_to_download_in_mb > 10)
                        {
                            VideoMovieManager.Instance.EndPlay();
                            // wait messagebox 提示下载
                            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                                string.Format(xc.TextHelper.UpgradeNoWifiTips, total_bytes_to_download_in_mb), xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel));

                            if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                            {
                                Application.Quit();
                            }
                        }
                    }
                }
                else
                {
                    if (IsShowMiniGame() && IsKoreanMiniGamePlatform()) // 只有韩国minigame弹框提示特殊处理
                    {
                        VideoMovieManager.Instance.EndPlay();
                        yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                            string.Format(xc.LocalizeManager.Instance.Localize.UpgradeWithMiniGameTips, total_bytes_to_download_in_mb), xc.LocalizeManager.Instance.Localize.UpgradeWithMiniGameButton));

                        if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                        {
                            Application.Quit();
                        }

                        UIHelper.SetChildrenActiveExclude(mPatchUI.transform, true, mMiniGameActiveWhiteList);

                        if (mIsMiniGameInitSuccess)
                            MiniGameManager.Instance.Run();

                        mPatchUI.set_process_text(xc.TextHelper.StartUpgrade);
                    }
                    else if (PatchMgr.IsBinPatch && IsVideoMoviePlatform())
                    {
                        if (cur_network_state == NetworkReachability.ReachableViaCarrierDataNetwork)
                        {
                            VideoMovieManager.Instance.EndPlay();
                            // wait messagebox 提示下载
                            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                                string.Format(xc.LocalizeManager.Instance.Localize.UpgradeNoWifiTips2, total_bytes_to_download_in_mb), xc.LocalizeManager.Instance.Localize.BtnContinue, xc.TextHelper.BtnCancel));

                            if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                            {
                                Application.Quit();
                            }
                        }
                        else
                        {
                            VideoMovieManager.Instance.EndPlay();
                            // wait messagebox 提示下载
                            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                                string.Format(xc.LocalizeManager.Instance.Localize.UpgradeWithWifiTips, total_bytes_to_download_in_mb), xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel));

                            if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                            {
                                Application.Quit();
                            }
                        }

                        if (mIsVideoMovieInitSuccess)
                            VideoMovieManager.Instance.Play();
                    }
                    else if (AuditManager.Instance.OpenButCanPatch == false)
                    {
                        if (cur_network_state == NetworkReachability.ReachableViaCarrierDataNetwork)
                        {
                            VideoMovieManager.Instance.EndPlay();
                            // wait messagebox 提示下载
                            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                                string.Format(xc.LocalizeManager.Instance.Localize.UpgradeNoWifiTips2, total_bytes_to_download_in_mb), xc.LocalizeManager.Instance.Localize.BtnContinue, xc.TextHelper.BtnCancel));

                            if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                            {
                                Application.Quit();
                            }
                        }
                        else
                        {
                            VideoMovieManager.Instance.EndPlay();
                            // wait messagebox 提示下载
                            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                                string.Format(xc.LocalizeManager.Instance.Localize.UpgradeWithWifiTips, total_bytes_to_download_in_mb), xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel));

                            if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                            {
                                Application.Quit();
                            }
                        }
                    }
                }

                if (Const.Region == RegionType.KOREA)
                    BuriedPointHelper.ReportTapjoyEvnet("resources", "PlayGame");

                // 资源更新开始
                BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_update_begin", 1);

                bool update_30per_done = false;
                bool update_60per_done = false;

                // 开始下载
                progress.Start();

                // 在下载过程中进行状态的检查，并进行进度的更新
                while (!progress.IsFinish)
                {
                    // 下载时，错误信息会记录在PatchMgr，不用检查progress的error
                    //if (progress.HasError) {
                    //    on_patch_failed(progress.Error);
                    //    yield break;
                    //}

                    // 检查网络状态是否发生改变了
                    var last_network_state = cur_network_state;
                    cur_network_state = Application.internetReachability;

                    if (last_network_state != cur_network_state)
                    {
                        if (cur_network_state == NetworkReachability.ReachableViaLocalAreaNetwork)
                        {
                            // wifi
                            // do nothing
                        }
                        else if (last_network_state == NetworkReachability.ReachableViaLocalAreaNetwork)
                        {
                            // 从wifi切到移动网络，或者断开网络
                            PatchMgr.Pause();
                            VideoMovieManager.Instance.EndPlay();
                            yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                                xc.TextHelper.NoWifiContinue, xc.TextHelper.ContinueDownload, xc.TextHelper.BtnCancel));

                            if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel) {
                                Application.Quit();
                            }

                            PatchMgr.Resume();
                        }
                    }

                    if (PatchMgr.FatalError)
                    {
                        VideoMovieManager.Instance.EndPlay();
                        yield return StartCoroutine(mMessageBoxUI.ShowRoutine(
                            xc.TextHelper.DownloadException, xc.TextHelper.ContinueDownload, xc.TextHelper.BtnCancel));

                        if (mMessageBoxUI.Result == MessageBoxUI.EResult.Cancel)
                        {
                            Application.Quit();
                        }

                        PatchMgr.Resume();
                    }

                    if (!PatchMgr.IsBinPatch && AuditManager.Instance.OpenButCanPatch == true)
                    {
                        mPatchUI.set_process_text(xc.TextHelper.LoadingNotice);
                    }
                    else
                    {
                        mPatchUI.set_process_text(string.Format(xc.TextHelper.DownloadProcess, progress.Current, progress.Total));

                        var download_speed_str = PatchMgr.DownloadSpeedStr;

                        if (total_bytes_to_download_in_mb < 1)
                        {
                            var total_bytes_to_download_in_kb = total_bytes_to_download / 1024.0f;
                            var bytes_download_in_kb = progress.BytesDownloaded / 1024.0f;

                            if (Const.Region == RegionType.SEASIA && update_30per_done == false && (bytes_download_in_kb / total_bytes_to_download > 0.3))
                            {
                                update_30per_done = true;
                                BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_update_30per", 1);
                            }

                            if (Const.Region == RegionType.SEASIA && update_60per_done == false && (bytes_download_in_kb / total_bytes_to_download > 0.6))
                            {
                                update_60per_done = true;
                                BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_update_60per", 1);
                            }

                            mPatchUI.set_total_size_in_mb(string.Format(xc.TextHelper.DownloadSizeKb, bytes_download_in_kb, total_bytes_to_download_in_kb, download_speed_str));
                        }
                        else
                        {
                            var bytes_download_in_mb = progress.BytesDownloaded / 1024.0f / 1024.0f;

                            if (Const.Region == RegionType.SEASIA && update_30per_done == false && (bytes_download_in_mb / total_bytes_to_download > 0.3))
                            {
                                update_30per_done = true;
                                BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_update_30per", 1);
                            }

                            if (Const.Region == RegionType.SEASIA && update_60per_done == false && (bytes_download_in_mb / total_bytes_to_download > 0.6))
                            {
                                update_60per_done = true;
                                BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_update_60per", 1);
                            }

                            mPatchUI.set_total_size_in_mb(string.Format(xc.TextHelper.DownloadSizeMb, bytes_download_in_mb, total_bytes_to_download_in_mb, download_speed_str));
                        }
                    }
  

                    SetProcess(progress.Value);

                    // wait one frame
                    yield return null;
                }

                // 删除不用的bundle
                delete_unuse_bundles();
            }

            if (PatchMgr.IsBinPatch)
            {
                yield return StartCoroutine(UnpackBinPatch());

                var srcFolder = wipe_file_sprit(Const.persistentDataPath);
                var unPackFiles = Directory.GetFiles(srcFolder, "*.bin");
                bool unpack_success = unPackFiles.Length == 0;
                if (unpack_success)
                {
                    yield return StartCoroutine(PatchMgr.UpdateDLFileRoutine(progress));
                }
                else
                {
                    PatchMgr.AddDownloadedPatch(0);

                    GameDebug.LogError("unpack fail");
                }

                PatchMgr.IsBinPatch = false;

                PatchMgr.CleanUp();

                yield return StartCoroutine(Patch());
            }

            if (mIsMiniGameInitSuccess)
                MiniGameManager.Instance.EndGame();
            if(mIsVideoMovieInitSuccess)
                VideoMovieManager.Instance.EndPlay();

            // 资源更新结束
            BuriedPointHelper.ReportEsaAppsflyerEvnet("custom_loss", "resource_update_end", 1);

            // 更新资源
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.Res4UpdateEnd, "", false);
            ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.update_res);

            yield return new WaitForEndOfFrame();
            Debug.Log("InitSceneLoader::Patch: patch-success!");

            DebugTimeMark(7, "dowload patch");

            //enter game
            SetProcess(1);
            mPatchUI.set_process_text(xc.TextHelper.UpgradeSuccess);
            mPatchUI.set_total_size_in_mb(string.Empty);

            yield return StartCoroutine(EnterGame());
        }

        /// <summary>
        /// 解压bin文件
        /// </summary>
        /// <returns></returns>
        protected IEnumerator UnpackBinPatch()
        {
            mPatchUI.set_process_text(xc.TextHelper.InitSceneFirstRunTips);

            // 创建bundle文件夹
            if (!Directory.Exists(xc.Const.BUNDLE_FILE_FOLDER_DISK_FOR_WRITE))
            {
                Directory.CreateDirectory(xc.Const.BUNDLE_FILE_FOLDER_DISK_FOR_WRITE);
            }

            // 加载包内的dl_res.data
            var dlResPath = string.Format("{0}/dl_res.data", xc.Const.persistentDataPath);
            Debug.Log("start read dl_res.data:" + dlResPath);

            var total = 0L; // 需要拷贝的文件数量
            var total_bytes_to_copy = 0L; // 需要拷贝的文件字节数
            try
            {
                using (var fileStream = new FileStream(dlResPath, FileMode.Open, FileAccess.Read))
                {
                    using (var dlResFileReader = new BinaryReader(fileStream))
                    {
                        var resInfoText = dlResFileReader.ReadString();
                        var resInfo = resInfoText.Split(',');
                        if (resInfo.Length >= 2)
                        {
                            total = long.Parse(resInfo[0]);
                            total_bytes_to_copy = long.Parse(resInfo[1]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("read (dl_res.data) from apk failed! Error = {0}", e.Message);
                yield break;
            }

            var total_bytes_to_copy_in_mb = total_bytes_to_copy / 1024.0f / 1024.0f;
            var need_space_in_mb = total_bytes_to_copy_in_mb * 1.5;
            if (need_space_in_mb - total_bytes_to_copy_in_mb > 50)
            {
                need_space_in_mb = total_bytes_to_copy_in_mb + 50;
            }

            // 磁盘空间检查
            var free_space_in_mb = DBOSManager.getOSBridge().getStorageFreeSize();
            if (free_space_in_mb < need_space_in_mb)
            {
                VideoMovieManager.Instance.EndPlay();
                yield return StartCoroutine(mMessageBoxUI.ShowRoutine(xc.TextHelper.InitSceneLackStorage, xc.TextHelper.BtnConfirm));

                Application.Quit();
            }

            var current = 0;

            var start = Time.realtimeSinceStartup;

            CopyProgress.Stage = 0;
            var srcFolder = wipe_file_sprit(Const.persistentDataPath);
            var targetFolder = wipe_file_sprit(Const.BUNDLE_FILE_FOLDER_DISK);
            var unPackFiles = Directory.GetFiles(srcFolder, "*.bin");
            if (unPackFiles.Length > 0)
            {
                var count = 0;

                List<string> unPackList1 = new List<string>();
                int halfLen = unPackFiles.Length / 2;
                int i = 0;
                for (; i < halfLen; ++i)
                {
                    var file = unPackFiles[i];
                    unPackList1.Add(Path.GetFileName(file));
                }

                List<string> unPackList2 = new List<string>();
                for (; i < unPackFiles.Length; ++i)
                {
                    var file = unPackFiles[i];
                    unPackList2.Add(Path.GetFileName(file));
                }

                if (unPackList1.Count > 0)
                {
                    var copying1 = new ResCopying();
                    copying1.SrcFolder = srcFolder;
                    copying1.TargetFolder = targetFolder;
                    copying1.UnPackList = unPackList1;
                    copying1.DeletePackage = true;
                    var copyThread1 = new System.Threading.Thread(copying1.Start);
                    copyThread1.IsBackground = true;
                    copyThread1.Start();

                    count++;
                }

                if (unPackList2.Count > 0)
                {
                    var copying2 = new ResCopying();
                    copying2.SrcFolder = srcFolder;
                    copying2.TargetFolder = targetFolder;
                    copying2.UnPackList = unPackList2;
                    copying2.DeletePackage = true;
                    var copyThread2 = new System.Threading.Thread(copying2.Start);
                    copyThread2.IsBackground = true;
                    copyThread2.Start();

                    count++;
                }

                while (CopyProgress.Stage != count)
                {
                    current = CopyProgress.Progress;
                    SetProcess(current / (float)total);
                    mPatchUI.set_total_size_in_mb(string.Format("{0}/{1}", current, total));
                    yield return null;
                }

            float current_time = Time.realtimeSinceStartup;
            Debug.Log(string.Format("copying cost:{0}", current_time - start));
        }
        }

        /// <summary>
        /// 不更新时直接加载本地bundle信息即可
        /// </summary>
        protected IEnumerator EntetGameWithoutPatch()
        {
#if UNITY_MOBILE_LOCAL
            var bundle_config_file_path = string.Format("{0}/0.unity3d", Const.persistentDataPath);
            if (!File.Exists(bundle_config_file_path))
                yield return StartCoroutine(CopyBundleFromStreamingAsset());

#elif UNITY_IPHONE
            // ios提审标记开启的时候，也需要进行资源拷贝操作
            if (AuditManager.Instance.Open)
            {
                //var bundle_config_file_path = string.Format("{0}/0.unity3d", Const.persistentDataPath);
                //if (!File.Exists(bundle_config_file_path))
                //    yield return StartCoroutine(CopyBundleFromStreamingAsset());
            }
#endif

            // 拷贝bundle文件之后再进行文件信息的初始化
            PatchMgr.InitFileInfo();


            yield return StartCoroutine(LoadLocalBundleInfo());


            SetProcess(1);
            mPatchUI.set_process_text(string.Format(xc.TextHelper.UpgradeSuccess));

            yield return StartCoroutine(EnterGame());
        }

        bool IsShowMiniGame()
        {
            return IsMiniGamePlatform() && !RainMiniGame.IsFinish();
        }

        bool IsMiniGamePlatform()
        {
            return IsKoreanMiniGamePlatform() || IsSeaMiniGamePlatform();
        }

        bool IsKoreanMiniGamePlatform()
        {
            return GlobalConfig.Instance.PlatformName == "ios" && Const.Region == RegionType.KOREA;
        }

        bool IsSeaMiniGamePlatform()
        {
            return GlobalConfig.Instance.PlatformName == "android" && Const.Region == RegionType.SEASIA;
        }

        bool IsVideoMoviePlatform()
        {
            return false;
            //             IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            //             //android 4.0不支持
            //             return (GlobalConfig.Instance.PlatformName == "android" && bridge.getOSVersion().StartsWith("4.") == false && Const.Region == RegionType.KOREA);
        }

        /// <summary>
        /// 协程请求后台MiniGame开关
        /// </summary>
        IEnumerator CoCheckStartMiniGame()
        {
            string url = GlobalConfig.HostURL + string.Format("servlet/GetMiniGameState?game_mark={0}", GlobalConfig.Instance.GameMark);
            GameDebug.Log("CoCheckStartMiniGame " + url);
            yield return StartCoroutine(HttpRequest.Instance.CoGET(url, OnCheckOpenMiniGame, null));

            if (mIsMiniGameInitSuccess)
            {
                while (!MiniGameManager.Instance.IsReady())
                {
                    yield return null;
                }
            }

            yield return StartCoroutine(Patch());
        }

        IEnumerator CoCheckStartVideoMovie()
        {
            
            if (IsVideoMoviePlatform())
            {
                string url = GlobalConfig.HostURL + string.Format("servlet/GetMiniGameState?game_mark={0}", GlobalConfig.Instance.GameMark);
                GameDebug.LogError("CoCheckStartVideoMovie " + url);
                yield return StartCoroutine(HttpRequest.Instance.CoGET(url, OnCheckOpenVideoMovie, null));
            }


            yield return StartCoroutine(Patch());
        }

        void OnCheckOpenVideoMovie(string url, string error, string reply, System.Object userData)
        {

            if (!string.IsNullOrEmpty(error))
                return;

            int result = 0;
            Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
            if (hashtable == null)
            {
                return;
            }
            result = DBTextResource.ParseI(hashtable["data"].ToString());
            if (result == 1)
            {
                mIsVideoMovieInitSuccess = VideoMovieManager.Instance.InitVideo(mVideoMovieContainer);
            }
        }

        void OnCheckOpenMiniGame(string url, string error, string reply, System.Object userData)
        {

            if (!string.IsNullOrEmpty(error))
                return;

            int result = 0;
            Hashtable hashtable = MiniJSON.JsonDecode(reply) as Hashtable;
            if (hashtable == null)
            {
                return;
            }
            result = DBTextResource.ParseI(hashtable["data"].ToString());
            if(result == 1)
            {
                mIsMiniGameInitSuccess = MiniGameManager.Instance.StartGame(mMiniGameContainer);
            }
        }



        string wipe_file_sprit(string bundle_url)
        {
            string url_no_sprit = "";
            if (bundle_url.IndexOf("file://") == 0)
            {
                url_no_sprit = bundle_url.Substring("file://".Length);
            }
            else
                url_no_sprit = bundle_url;

            return url_no_sprit;
        }

        /// <summary>
        /// 加载本地的bundle信息
        /// </summary>
        protected IEnumerator LoadLocalBundleInfo()
        {
#if UNITY_EDITOR
            if (!SGameEngine.ResourceLoader.EnableBundleInEditor)
            {
                // 编辑器下不需要获取bundle信息
            }
            else
#endif
            {
                // 从安装包目录获取本地bundle信息
#if HD_RESOURCE
                var bundle_url = string.Format("file://{0}/0.unity3d", Const.BUNDLE_FILE_FOLDER_DISK_FOR_WRITE);
#else
                var bundle_url = string.Format("{0}/0.unity3d", Const.BUNDLE_FILE_FOLDER_PACKAGE);
#endif
                bundle_url = ResNameMapping.Instance.GetMappingPath(bundle_url, Const.BUNDLE_FOLDER_NAME, "0.unity3d");

                Debug.Log("bundle_url:" + bundle_url);

                AssetBundle bundle = null;
#if UNITY_IPHONE
                // ios streamingasset目录下的文件也可以通过LoadFromFileAsync来读取
                bundle_url = wipe_file_sprit(bundle_url);
                var requeset = AssetBundle.LoadFromFileAsync(bundle_url);
                yield return requeset;
                bundle = requeset.assetBundle;
#else
                var www = new WWW(bundle_url);
                yield return www;
                bundle = www.assetBundle;
                www.Dispose();
#endif

                // 加载bundle_info信息
                var request = bundle.LoadAssetAsync(Const.BUNDLE_MAIN, typeof(AssetBundleInfoRuntime));
                yield return request;

                g_server_bundle_info = request.asset as AssetBundleInfoRuntime;

                // 加载patch_info信息
                request = bundle.LoadAssetAsync(Const.PATCH_MAIN, typeof(AssetPatchInfoRuntime));
                yield return request;

                g_server_patch_info = request.asset as AssetPatchInfoRuntime;

                bundle.Unload(false);

                // ios提升标记开启的时候, 从包外读取资源
                bool is_from_install_package = AuditManager.Instance.Open == false;

                // 本地打安卓包的时候，bundle也已经拷贝到sd卡上了
                foreach (var item in g_server_bundle_info.info)
                {
#if UNITY_MOBILE_LOCAL || HD_RESOURCE
                    item.is_from_install_package_ = false;
#elif UNITY_IPHONE
                    item.is_from_install_package_ = is_from_install_package;
#else
                    item.is_from_install_package_ = true;
#endif
                }

                PatchMgr.SetBundleAndPatchConfig(g_server_bundle_info, g_server_patch_info);
            }

            Debug.Log("LoadLocalBundleInfo: loaded package/0.unity3d");
            Debug.Log(string.Format("LoadLocalBundleInfo: package bundler ver {0}", BundleVersion));

            mPatchUI.set_version_text(string.Format("version 1.0"));

            yield return new WaitForEndOfFrame();
        }

        /// <summary>
        /// 删除本地不用的bundle，并且标记bundle来源
        /// </summary>
        protected void delete_unuse_bundles()
        {
            // TODO 删除sd卡上多余的的bundle文件
            //foreach (var item in g_server_bundle_info.info) {
            //    var file_path = string.Format("{0}/{1}.unity3d", Const.BUNDLE_FILE_FOLDER_DISK_FOR_WRITE, item.bundleName);
            //    if (File.Exists(file_path)) {
            //        File.Delete(file_path);
            //    }
            //}
        }

        /// <summary>
        /// 保存报错信息到物理文件
        /// </summary>
        protected void OnLog(string log, string stackTrace, LogType type)
        {
            if (type == LogType.Exception)
            {
                string text = log;
                text += "\r\n";
                text += "-------------------Call Stack:------------------\r\n";
                text += stackTrace;
                text += "------------------------------------------------\r\n";
                DBOSManager.writeCSDmpToFile(text);
            }
        }

        public delegate void StreamAssetsCopyed (string error);

        /// <summary>
        /// 将StreamingAssets目录中的某一文件拷贝到外部文件夹中(暂时给拷贝表格使用)
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public IEnumerator copy_streamassets(string [] files, string targetPath = "", string[] target_files = null, bool force_copy = false)
        {
            if (string.IsNullOrEmpty(targetPath) == true)
            {
                IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                targetPath = bridge.getGameResPath();
            }
            string assetsPackPath = "";

            if (Application.platform == RuntimePlatform.Android)
                assetsPackPath = string.Format ("{0}", Application.streamingAssetsPath);
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                assetsPackPath = string.Format ("file://{0}", Application.streamingAssetsPath);
            }
            else
            {
                string fullPath = Path.GetFullPath (Application.streamingAssetsPath);
                fullPath = fullPath.Replace ("\\", "/");
                assetsPackPath = string.Format ("file://{0}", fullPath);
            }

            string errorInfo = null;

            for (int i = 0; i < files.Length; ++i)
            {
                string fileName = files [i];
                string targetFileName = fileName;
                if (target_files != null && i < target_files.Length)
                {
                    targetFileName = target_files[i];
                }

                string destPath = string.Format ("{0}{1}", targetPath, targetFileName);
                if (System.IO.File.Exists (destPath) && force_copy == false)// 如果目标文件夹的已存在该文件，则不拷贝
                    continue;

                string fullPath = string.Format ("{0}/{1}", assetsPackPath, fileName);
                WWW wwwStream = new WWW (fullPath);
                yield return wwwStream;

                errorInfo = wwwStream.error;
                if (string.IsNullOrEmpty (wwwStream.error))
                {
                    string dir = System.IO.Path.GetDirectoryName (destPath);
                    if (!System.IO.Directory.Exists (dir))
                    {
                        System.IO.Directory.CreateDirectory (dir);
                    }

                    System.IO.FileStream fileStream = new System.IO.FileStream (destPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                    fileStream.Write (wwwStream.bytes, 0, wwwStream.bytes.Length);
                    fileStream.Flush ();
                    fileStream.Close ();
                }
                else
                {
                    GameDebug.LogError ("streamasset file load failed: " + wwwStream.error);
                    break;
                }
            }
        }
    }
}

