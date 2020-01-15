using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Net;

using xc;
using xc.Maths;
using xc.ui;
using xc.ui.ugui;
using xc.protocol;
using Utils;
using SGameEngine;
using XLua;

namespace xc
{
    //[wxb.Hotfix]
    [LuaCallCSharp]
    public partial class Game : NetClient.IListener
    {
        public bool IsSkillEditorScene = false;
        public enum EGameMode
        {
            GM_Debug        = 0x00000000,   // 默认模式为调试+不联网
            GM_Net          = 0x00000001,   // 表示是否联网
        }

        public delegate void DataReplyDelegate(ushort protocol,byte[] data);

        private static Game msInstance;

        public EGameMode GameMode = EGameMode.GM_Debug;
        public string ServerIP;
        public int ServerPort;
        public string Account;
        public string Password;
        public uint ServerID = 50001;
        protected AsyncOperation mLoadASyncOp;

        public int GetScreenWidth()
        {
            return Screen.width;
        }
        public int GetScreenHeight()
        {
            return Screen.height;
        }
        


        /// <summary>
        /// 游戏状态机
        /// </summary>
        protected xc.Machine m_GameMachine;
        public bool mIsInited;
        protected Actor mLocalPlayer;
        protected UnitID mLocalPlayerID;
        protected uint mPlayerTypeID = 0;
        protected float mLocalPlayerRadius = 0; //玩家模型的大小
        protected Dictionary<ushort, List<DataReplyDelegate> > mNetHandlers;
        protected Dictionary<ushort, List<DataReplyDelegate>> mLuaNetHandlers;

        private int mAccountIdx = 0;
        private int mSplitSceneLayer = -1;

        private string mLocalPlayerName = "";
        private UnitEnterAOI._Player mLocalPlayerAOIInfo;
        private List<Net.PkgPlayerBrief> mRepCharacterList = null;

        /// <summary>
        /// 一个帐号可创建角色的最大数量
        /// </summary>
        private int mCharactorMaxCount = 4;

        private bool LogPosted = false;

        private bool mIsRebooting = false;

        public bool IsRebooting
        {
            get { return mIsRebooting; }
            set { mIsRebooting = value; }
        }

        private bool mManualCancelReconnect = false;

        public bool ManualCancelReconnect
        {
            get { return mManualCancelReconnect; }
            set { mManualCancelReconnect = value; }
        }

        public Camera MainCamera
        {
            get { return Camera.main; }
        }

        public CameraControl CameraControl
        {
            get
            {
                Camera cam = Camera.main;
                if (cam != null)
                    return cam.GetComponent<CameraControl>();
                return null;
            }
        }

        public GameObjectControl GameObjectControl
        {
            get
            {
                Camera cam = Camera.main;
                if (cam != null)
                    return cam.GetComponent<GameObjectControl>();
                return null;
            }
        }


        public int AccountIdx
        {
            get { return mAccountIdx; }
        }
        
        public List<Net.PkgPlayerBrief> CharacterList
        {
            get{ return mRepCharacterList;}
        }

        public int CharactorMaxCount
        {
            get{return mCharactorMaxCount; }
        }

        //[LuaExport]
        //[DisableLuaBugFix]
        static public Game GetInstance()
        {
            if (msInstance == null)
                msInstance = new Game();
            return msInstance;
        }

        //[DisableLuaBugFix]
        static public Game Instance
        {
            get
            {
                if (msInstance == null)
                    msInstance = new Game();
                return msInstance;
            }
        }

        public UnitID LocalPlayerID
        {
            get { return mLocalPlayerID; }
            
            set { mLocalPlayerID = value; }
        }

        public string LocalPlayerName
        {
            get
            {
                return mLocalPlayerName;
            }
            set
            {
                mLocalPlayerName = value;
                
                Actor localplayer = Game.GetInstance().GetLocalPlayer();
                if (localplayer != null)
                {
                    localplayer.UserName = value;
                    localplayer.SetNameText();
                }
                if (LocalPlayerManager.Instance.LocalActorAttribute != null)
                    LocalPlayerManager.Instance.LocalActorAttribute.Name = value;
            }
        }
        
        public uint LocalPlayerTypeID
        {
            get { return mPlayerTypeID; }
            set
            {
                mPlayerTypeID = value;
            }
        }
        
        public uint LocalPlayerVocation
        {
            get
            {
                return LocalPlayerTypeID - 100;
            }
        }

        public float LocalPlayerRadius
        {
            get
            {
                return mLocalPlayerRadius;
            }
            set
            {
                if (mLocalPlayerRadius == value)
                    return;
                mLocalPlayerRadius = value;
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CHANGE_LOCALPLAYER_RADIUS, null);
            }
        }

        public UnitEnterAOI._Player LocalPlayerAOIInfo
        {
            get { return mLocalPlayerAOIInfo; }
            set { mLocalPlayerAOIInfo = value; }
        }
       
        public uint GetCurStateId()
        {
            return Game.GetInstance().GetFSM().GetCurState().GetID();
        }

        /// <summary>
        ///  是否在切换场景中
        /// </summary>
        public bool IsSwitchingScene
        {
            get { return SceneHelp.Instance.IsSwitchingScene; }
            set { SceneHelp.Instance.IsSwitchingScene = value; }
        }
        
        public AsyncOperation GetLoadAsyncOp()
        {
            return mLoadASyncOp;
        }
        
        public void SetLoadAsyncOp(AsyncOperation op)
        {
            mLoadASyncOp = op;
        }
        
        public void SetLocalPlayer(Actor player)
        {
            mLocalPlayer = player;

            if (null != mLocalPlayer && null != LocalPlayerManager.Instance.LocalActorAttribute)
            {
                // 使用SetActorAttriBute接口在单人副本中赋值时，hp和mp没有赋值
                // 只有当SetPlayerInfoByConfig接口调用后，血量才赋值成功
                LocalPlayerManager.Instance.LocalActorAttribute.UnitId = mLocalPlayer.UID;
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ACTOR_BASEINFO_UPDATE, new CEventActorArgs(mLocalPlayer));

                // 这里再赋值确保uuid的正确
                GlobalConfig.GetInstance().LoginInfo.RId = mLocalPlayer.UID.obj_idx.ToString();
            }
        }
        
        //[DisableLuaBugFix]
        public Actor GetLocalPlayer()
        {
            if(mLocalPlayer != null && !mLocalPlayer.IsDestroy)
                return mLocalPlayer;
            else
            {
                mLocalPlayer = null;
                return null;
            }
        }

        // Register Net Notify.
        public void SubscribeNetNotify(ushort protocol, DataReplyDelegate func)
        {
            List<DataReplyDelegate> funcs;
            if (!mNetHandlers.TryGetValue(protocol, out funcs))
            {
                funcs = new List<DataReplyDelegate>();
                mNetHandlers.Add(protocol, funcs);
            }
            
            if (!funcs.Contains(func))
                funcs.Add(func);
        }
        
        // Unregister Net Notify.
        public void UnsubscribeNetNotify(ushort protocol, DataReplyDelegate func)
        {
            List<DataReplyDelegate> funcs;
            if (mNetHandlers.TryGetValue(protocol, out funcs))
            {
                funcs.Remove(func);
            }
        }

        //[LuaExport]
        public void SubscribeLuaNetNotify(ushort protocol, DataReplyDelegate func)
        {
            if (mLuaNetHandlers == null)
            {
                mLuaNetHandlers = new Dictionary<ushort, List<DataReplyDelegate>>();
                mLuaNetHandlers.Clear();
            }

            List<DataReplyDelegate> funcs;
            if (!mLuaNetHandlers.TryGetValue(protocol, out funcs))
            {
                funcs = new List<DataReplyDelegate>();
                mLuaNetHandlers.Add(protocol, funcs);
            }

            if (!funcs.Contains(func))
                funcs.Add(func);
        }

        //[LuaExport]
        public void UnsubscribeLuaNetNotify(ushort protocol, DataReplyDelegate func)
        {
            if (mLuaNetHandlers != null)
            {
                List<DataReplyDelegate> funcs;
                if (mLuaNetHandlers.TryGetValue(protocol, out funcs))
                {
                    funcs.Remove(func);
                }
            }
        }

        Game()
        {
            mIsInited = false;
            mSplitSceneLayer = 1 << LayerMask.NameToLayer("SplitScene");
        }
        
        public void Quit(bool callApplicationQuit)
        {
            // 保存用户配置
            GlobalSettings.GetInstance().Save();

            // 如果开启了跨服，关闭跨服Socket
            if (Net.NetClient.CrossToggle)
                CrossServerIntegration.GetInstance().Stop();

            StopNetClient();

            // 关闭Sqlite连接
            DBManager.Instance.CloseAllSqliteDB();

            //发送客户端关闭通知
            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_QUIT_GAME, null);

            LuaScriptMgr.Instance.Destroy();
#if !UNITY_EDITOR
            if(callApplicationQuit)
                Application.Quit();
#endif
        }

        public void Init()
        {
            // 引擎参数设置，不开垂直同步，默认30帧
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.runInBackground = true;
            QualitySettings.vSyncCount = 0;
            Time.fixedDeltaTime = 0.1f; //0.033333333f;
            Time.maximumDeltaTime = 0.16f;

            // 重要系统的实例化
            GlobalSettings.GetInstance();
            NetClient.GetBaseClient();

            // 本地玩家的ID
            mLocalPlayerID = new UnitID();
            mLocalPlayerID.type = (byte)EUnitType.UNITTYPE_PLAYER;
            mLocalPlayerID.obj_idx = 0xffffffff;

            // 网络初始化
            mNetHandlers = new Dictionary<ushort, List<DataReplyDelegate>>();
            // Now we directly connect to server.
            NetClient.GetBaseClient().mListener = this;

            // 所有系统的初始化和网络消息的注册
            RegisterAllMessage();
            
            // 日志回调
            Application.logMessageReceived += OnLog;
            xpatch.XPatchManager.Instance.onPatchFinished += OnPatchFinished;

    #if !UNITY_MOBILE_LOCAL
            VoiceManager.Instance.Init();
    #endif
        }

        public void OnLog(string log, string stackTrace, LogType type)
        {
            // 暂时屏蔽崩溃堆栈消息的发送
            if (type == LogType.Exception)
            {
                string text = string.Format("{0}\r\n------Call Stack:------\r\n{1}------------\r\n", log, stackTrace);

#if UNITY_EDITOR
                UINotice.GetInstance().ShowMessage("Program abnormal");
#endif

                if (LogPosted == false)//&& !Application.isEditor)// 在编辑器中不发送错误日志
                {
                    DBOSManager.writeCSDmpToFile(text);
                    LogPosted = true;
#if UNITY_EDITOR
                    // 游戏报错的时候要关闭数据库，不然退出游戏的时候退出不了
                    DBManager.Instance.CloseAllSqliteDB();
#endif
                }
            }

            var debugUI = MainGame.DebugUI;
            if (debugUI != null)
                debugUI.OnLog(log, stackTrace, type);
        }

        /// <summary>
        /// 分包id下载完毕的回调
        /// </summary>
        /// <param name="patch_id"></param>
        void OnPatchFinished(int patch_id)
        {
            // 向服务端发送当前已下载的分包id
            var send_patch_id = new C2SPlayerCurrentPatchId();
            send_patch_id.patch_id = (uint)patch_id;
            NetClient.GetBaseClient().SendData<C2SPlayerCurrentPatchId>(NetMsg.MSG_PLAYER_CURRENT_PATCH_ID, send_patch_id);
        }

        /// <summary>
        /// 游戏数据重置,在断线重连时ignore_reconnect设置为true
        /// </summary>
        /// <param name="ignore_reconnect"></param>
        public void Reset(bool ignore_reconnect = false)
        {
            mAllSystemInited = false;

            // 初始化单件对象，在计时器、表格和网络数据初始化之后
            if (ignore_reconnect == false)
            {
                TimerManager.GetInstance().Reset();
            }
            DecimalTimerManager.GetInstance().Reset();
            UIManager.GetInstance().Reset();
            NpcManager.GetInstance().Reset();
            ItemManager.GetInstance().Reset(ignore_reconnect);
            DialogManager.GetInstance().Reset();
            InstanceManager.GetInstance().Reset(ignore_reconnect);
            InstanceDropManager.GetInstance().Reset();
            LocalPlayerManager.Instance.Reset(ignore_reconnect);
            RedPointDataMgr.Instance.Reset();
            LockIconDataMgr.Instance.Reset();
            NewMarkerDataMgr.Instance.Reset();
            if (ignore_reconnect == false)
                RockCommandSystem.Instance.Reset();
            CooldownManager.Instance.Reset();
            ShadowManager.Instance.Reset();
            GuideManager.GetInstance().Reset();
            SysConfigManager.GetInstance().Reset();
            SysPreviewManager.GetInstance().Reset();
            CullManager.GetInstance().Reset();
            MailManager2.Instance.Reset();
            LockTargetManager.Instance.Reset();
            InterObjectManager.Instance.Reset();
            FriendsManager.Instance.Reset(ignore_reconnect);
            TeamManager.Instance.Reset(ignore_reconnect);
            SkillHoleManager.Instance.Reset();
            SkillManager.Instance.Reset();
            TimelineManager.Instance.Reset();
            TaskManager.Instance.Reset();
            HookSettingManager.Instance.Reset();
            ShieldManager.Instance.Reset();
            GuildLeagueManager.Instance.Reset();
            MarryManager.Instance.Reset();
            SpanServerManager.Instance.Reset();
            if (ignore_reconnect == false)
            {
                UINotice.GetInstance().Reset();
                NetReconnect.Instance.Reset();
            }

            DBGuide db_guide = DBManager.GetInstance().GetDB<DBGuide>();
            db_guide.Reset();
            DBGuideStep db_guide_step = DBManager.GetInstance().GetDB<DBGuideStep>();
            db_guide_step.Reset();

            LuaScriptMgr.Instance.Reset(ignore_reconnect);
            CustomDataMgr.Instance.Reset();
            ChargeManager.Instance.Reset();
            AudioManager.Instance.Reset();
        }


        public void ReAddComponent<T>() 
            where T : Component
        {
            GameObject core = MainGame.CoreObject;
            GameObject.Destroy(core.GetComponent<T>());
            core.AddComponent<T>();
        }

        public bool IsNetMode()
        {
            return (((int)GameMode & (int)EGameMode.GM_Net) == (int)EGameMode.GM_Net);
        }

        //[DisableLuaBugFix]
        public xc.Machine GetFSM()
        {
            return m_GameMachine;
        }
        
        /// <summary>
        /// 初始化游戏状态机
        /// </summary>
        /// <returns></returns>
        public xc.Machine.State InitFSM()
        {
            m_GameMachine = new xc.Machine();
            
            xc.Machine.State init_state = new xc.GameInitState(m_GameMachine);

            XLua.LuaFunction initFSMFunc = LuaScriptMgr.Instance.GetLuaFunction("Main_InitFSM");
            if (initFSMFunc != null)
            {
                initFSMFunc.Call(m_GameMachine, init_state);
            }

            m_GameMachine.SetCurState(init_state);
            return init_state;
        }

        public void Update()
        {
            if (!mIsInited)
                return;

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Debug.Log("KeyCode.Escape pressed");
#if UNITY_IPHONE
                IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                if (bridge != null && bridge.isBridgeEnable())
                {
                    // 退出游戏的时候通知sdk
                    SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.EXIT_GAME);
                    bridge.checkBackBtnAction();
                }
#else
                var exit_game = true;
                if(xc.Const.Region == RegionType.KOREA) {
                    if (UIManager.Instance.TryCloseAllWindow()) {
                        exit_game = false;
                    }
                }
                if (exit_game) {
                    Debug.Log("KeyCode.Escape pressed exit_game = true");
                    IBridge bridge = DBOSManager.getDBOSManager().getBridge();
                    if (bridge != null && bridge.isBridgeEnable())
                    {
                        // 退出游戏的时候通知sdk
                        SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.EXIT_GAME);
                        bridge.checkBackBtnAction();
                    }
                }
#endif
            }

            m_GameMachine.Update();
            UIManager.Instance.Update();

            // 场景加载完成的检查
            SceneLoadingUpdate();

            TimerManager.GetInstance().Update();
            DecimalTimerManager.GetInstance().Update();
            EffectManager.GetInstance().Update();
            TargetPathManager.Instance.Update();
            TaskManager.Instance.Update();
            InstanceManager.Instance.Update();
            UINotice.Instance.Update();
            TeamManager.Instance.Update();
            MainmapManager.Instance.Update();
            TimelineManager.Instance.Update();
            ShadowManager.Instance.Update();
            GuideManager.Instance.Update();

    #if !UNITY_MOBILE_LOCAL
            VoiceManager.Instance.Update();
    #endif

            NetReconnect.Instance.Update();
            if (ChangeRoleManager.Instance.IsChangeRole)
            {
                ChangeRoleManager.Instance.Update();
            }

#if UNITY_EDITOR
            TestUnit.Instance.Update();
#endif
            Uranus.Runtime.UranusManager.Instance.Update();
            MarryFireworkManager.Instance.Update();

            NetworkManager.Instance.Update();
            if (((int)GameMode & (int)EGameMode.GM_Net) == (int)EGameMode.GM_Net)
            {
                NetClient.GetBaseClient().Update();
                if (NetClient.CrossToggle)
                    NetClient.GetCrossClient().Update();
            }

            // 协程更新
            // 最好在其他模块都更新好，再更新协程
            SafeCoroutine.CoroutineManager.Update(Time.deltaTime);
        }

        float[] distances = new float[32];

        /// <summary>
        /// 加载场景完成的检查
        /// </summary>
        void SceneLoadingUpdate()
        {
            // 场景的Scene文件加载完毕
            if (mLoadASyncOp != null && mLoadASyncOp.isDone)
            {
                // 通过IsSwitchingScene变量确保场景初始化的逻辑只执行一次
                if (SceneHelp.Instance.IsSwitchingScene)
                {
                    QualitySetting.SetSceneGL((EGraphLevel)QualitySetting.GraphicLevel);

                    // 设置相机layer裁剪距离
                    Camera cur_camera = Game.Instance.MainCamera;
                    if (cur_camera != null)
                    {
                        

                        // 尝试从CameraCull组件中获取裁剪的距离
                        float cull_distance = 18;
                        var camera_cull = cur_camera.GetComponent<CameraCull>();
                        if (camera_cull != null)
                            cull_distance = camera_cull.CullDistance;

                        for(int i = 0; i< 32; ++i)
                        {
                            distances[i] = 0;
                        }

                        distances[23] = cull_distance; // Tree
                        distances[26] = cull_distance; // SplitScene

                        cur_camera.layerCullDistances = distances;
                        cur_camera.layerCullSpherical = false;

                        int invisible_mask = (1 << LayerMask.NameToLayer("UI")) | (1 << LayerMask.NameToLayer("UI2")) | (1 << LayerMask.NameToLayer("Hide"));
                        cur_camera.cullingMask = ~invisible_mask & cur_camera.cullingMask;
                        //cur_camera.gameObject.AddComponent<CameraScale>();
                    }

                    SceneHelp.Instance.IsSwitchingScene = false;
                    SceneHelp.Instance.IsLoadingQuadTreeScene = SceneHelp.LoadQuadTreeSceneState.Loading;
                    // 目前不自动隐藏loading界面的场景都未进行切割(登录\创角\选角)
                    if (SceneHelp.Instance.AutoHideLoadingUI)
                        QuadTreeSceneManager.Instance.StartLoadListener();
                    else
                        Application.targetFrameRate = Const.G_FPS;// 恢复帧率限制

                    ScenePostProcess.Instance.Do();
                }

                // 处理自动隐藏loading界面的逻辑
                if (SceneHelp.Instance.AutoHideLoadingUI)
                {
                    // 非野外和副本的时候，可以直接隐藏loading界面
                    if (SceneHelp.Instance.IsInWildInstance() || SceneHelp.Instance.IsInInstance)
                    {
                        if (MainCamera == null)
                            return;

                        var local_player = Game.Instance.GetLocalPlayer();
                        if (local_player != null)
                        {
                            // 本地玩家创建之后才设置SplitScene可见, 以防止加载额外的动态场景
                            if ((MainCamera.cullingMask & mSplitSceneLayer) == 0)
                                MainCamera.cullingMask = MainCamera.cullingMask | mSplitSceneLayer;

                            // 加载完毕后再隐藏loading界面
                            if (QuadTreeSceneManager.Instance.LoadFinish)
                            {
                                SceneHelp.Instance.IsLoadingQuadTreeScene = SceneHelp.LoadQuadTreeSceneState.LoadFinished;
                            }

                            if (SceneHelp.Instance.IsLoadingQuadTreeScene == SceneHelp.LoadQuadTreeSceneState.LoadFinished)
                            {
                                if (UIManager.Instance.LoadingBKIsShow == true)
                                {
                                    // 新手剧情prefab加载完毕后再隐藏loading界面
                                    if (SceneHelp.Instance.CurSceneID == GameConstHelper.GetUint("GAME_BORN_DUNGEON") && TimelineManager.Instance.ShouldPlayOpenningTimeline() == true)
                                    {
                                        if (TimelineManager.Instance.OpenningTimelineHavePlayed() == true && TimelineManager.Instance.IsLoading() == false && TimelineManager.Instance.IsPreloading() == false)
                                        {
                                            if (UIManager.Instance.LoadingBKIsShow == true)
                                            {
                                                UIManager.Instance.ShowLoadingBK(false);
                                                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FINISH_LOAD_SCENE, null);
                                            }
                                        }
                                    }
                                    else  // 没有新手剧情，直接隐藏loading界面
                                    {
                                        UIManager.Instance.ShowLoadingBK(false);
                                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_FINISH_LOAD_SCENE, null);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 没有localplayer的时候，SplitScene设置为不可见
                            if ((MainCamera.cullingMask & mSplitSceneLayer) != 0)
                                MainCamera.cullingMask = MainCamera.cullingMask & ~mSplitSceneLayer;
                        }
                    }
                    else
                        UIManager.Instance.ShowLoadingBK(false);
                }
            }
        }

        public static IEnumerator WaitForSceneLoadAsyncOp()
        {
            while (ResourceLoader.Instance.sceneLoadAsyncOp == null)
            {
                yield return new WaitForEndOfFrame();
            }
            Game.Instance.SetLoadAsyncOp(ResourceLoader.Instance.sceneLoadAsyncOp);
        }

        void Relogin()
        {
            // 如果开启了跨服，关闭跨服Socket
            if (Net.NetClient.CrossToggle)
                CrossServerIntegration.GetInstance().Stop();

            StopNetClient();
            m_GameMachine.React((uint)GameEvent.GE_DISCONNECT);
        }

        /// <summary>
        /// 登录SDK并进行重新登录流程(不重启APP）
        /// </summary>
        public void Rebot()
        {
#if UNITY_ANDROID
            // 退出游戏的时候通知sdk
            SDKControler.getSDKControler().sendRoleInfo2SDK((int)SDKControler.RoleEvent.EXIT_GAME);
#endif

            GlobalConfig.Instance.ResetLoginInfo();

            IsRebooting = true;
            Relogin();
        }

        public void RebotWithoutSdkLogout()
        {
            IsRebooting = true;
            Relogin();
        }

        public void ChangeRole()
        {
            ChangeRoleManager.Instance.IsChangeRole = true;
            m_GameMachine.React((uint)GameEvent.GE_DISCONNECT);
        }

        /// <summary>
        /// 点击重试排队按钮
        /// </summary>
        /// <param name="userData"></param>
        void OnClickRetryBtn(System.Object userData)
        {
            mQueueMax = false;
            //UIManager.GetInstance().SwitchUI("UIChooseServerWindow");
            // 因为sdk的按钮已经消失，必须取消窗口关闭按钮，不然会造成关闭后无法打开其他界面
            //UIChooseServerWindow wnd =  UIManager.GetInstance().GetWindowImm("UIChooseServerWindow") as UIChooseServerWindow;
            // if(wnd != null)   
            //  wnd.ActiveCloseBtn(false);
        }

        /// <summary>
        /// 点击重新登录SDK的按钮
        /// </summary>
        /// <param name="param"></param>
        void OnClickSDKRelogin(System.Object param)
        {
            // 关闭主连接
            StopNetClient();
            // 关闭副连接
            if (Net.NetClient.CrossToggle)
                CrossServerIntegration.GetInstance().Stop();

#if UNITY_ANDROID
            IBridge bridge = DBOSManager.getDBOSManager().getBridge();
            if(bridge != null)
                bridge.reboot();
#else
            Application.Quit();
#endif
        }

        void RequestAppendInfo()// 请求所有本地角色相关系统的信息
        {
            GameDebug.LogRed("RequestAppendInfo");
            var requeset_all_info = new C2SPlayerRequestAllInfo();
            NetClient.GetBaseClient().SendData<C2SPlayerRequestAllInfo>(NetMsg.MSG_PLAYER_REQUEST_ALL_INFO, requeset_all_info);

            // 向服务端发送当前已下载的分包id
            var send_patch_id = new C2SPlayerCurrentPatchId();
            send_patch_id.patch_id = (uint)xpatch.XPatchManager.Instance.GetDownloadPatchId();
            NetClient.GetBaseClient().SendData<C2SPlayerCurrentPatchId>(NetMsg.MSG_PLAYER_CURRENT_PATCH_ID, send_patch_id);
        }

        void UpdateServerTime(float deltaTime)
        {
            if (mUpdateServerTimeStopwatch != null)
                mServerTime = mServerLastUpdteTime + ((ulong)mUpdateServerTimeStopwatch.ElapsedMilliseconds);

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SERVER_TIME_CHANGED, null);
        }


        /// <summary>
        /// 是否从创角场景进入游戏
        /// </summary>
        public bool IsCreateRoleEnter { get; set; }
    }
}

