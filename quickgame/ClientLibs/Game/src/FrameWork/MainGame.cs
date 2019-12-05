//------------------------------------------------------------------------------
// File : MainGame.cs
// Desc : 游戏总入口
// Author: raorui
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using SGameEngine;
using SGameFirstPass;
using xc;
using xc.ui.ugui;
using UnityEngine.Audio;

namespace xc
{
    [wxb.Hotfix]
    public class MainGame
    {
        static GameObject mCoreObject;
        static Heart mHeartBehavior;
        static DebugUI mDebugUI;

        public static UnityEngine.Object mEmojiTxt;
        public static UnityEngine.Object mEmojiTxt_equipTips;
        public static GameObject CoreObject
        {
            get
            {
                return mCoreObject;
            }
        }

        public static Heart HeartBehavior
        {
            get
            {
                return mHeartBehavior;
            }
        }

        static ShaderVariantCollection mShaderVarInfo;
        public static ShaderVariantCollection ShaderVarInfo
        {
            get
            {
                if(mShaderVarInfo == null)
                {
                    var global_mono = GetGlobalMono();
                    if(global_mono != null)
                    {
                        var shader_info = global_mono.GetComponent<ShaderVariantInfo>();
                        if (shader_info != null)
                            mShaderVarInfo = shader_info.ShaderVariantUsed;
                    }
                }

                return mShaderVarInfo;
            }
        }

        public static DebugWindow debugWindow;

		public static IEnumerator EnterGame()
		{
            // 预加载资源
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.PreloadResStart, "", false);

#if UNITY_EDITOR
            MikuLuaProfiler.HookLuaSetup.OnStartGame();
#endif

            // 创建Core物体
            mCoreObject = new GameObject ("Core");
			GameObject.DontDestroyOnLoad (mCoreObject);

			// 实例化Game
			Game mGame = Game.GetInstance();
            mHeartBehavior = mCoreObject.AddComponent<Heart>();
            AssemblyBridge.Instance.TimelinePlayableEmployee = new TimelinePlayableEmployee();

            ClientEventMgr.GetInstance();

            // 增加各种Component
            var resource_loader = mCoreObject.AddComponent<ResourceLoader>();
            resource_loader.BundleVersion = NewInitSceneLoader.Instance.BundleVersion;
            resource_loader.ServerBundleInfo = NewInitSceneLoader.Instance.g_server_bundle_info;

            mCoreObject.AddComponent<ResourceUtilEx> ();
			ResourceLoader.Instance.init();
            mCoreObject.AddComponent<ObjCachePoolMgr>();

            // 因为部分表格资源放在bundle资源中，因此要尽早进行加载
            yield return GlobalMono.StartCoroutine(DBTableManager.Instance.Preload());

            mCoreObject.AddComponent<ActorManager>();
            HttpRequest.Instance = mCoreObject.AddComponent<HttpRequest>();
            mCoreObject.AddComponent<QuadTreeSceneManager>();
            mCoreObject.AddComponent<PushManager>();
            xc.RedPointDataMgr.GetInstance();   //小红点实例化
            xc.LockIconDataMgr.GetInstance();
		    xc.NewMarkerDataMgr.GetInstance();  //New标记
#if !DISABLE_LUA
            //mCoreObject.AddComponent<LuaClient>().Init();
            LuaClient luaClient = mCoreObject.AddComponent<LuaClient>();
            yield return GlobalMono.StartCoroutine(luaClient.InitRoutine());
#endif

#if (TEST_HOST && !PERFORMANCE_TEST) || HD_RESOURCE
            //mCoreObject.AddComponent<DebugFPS>();// 因为gc的问题暂时屏蔽
            mDebugUI = mCoreObject.AddComponent<DebugUI>();
            mDebugUI.UnsubscribeAllProcessCmd();
            mDebugUI.SubscribeProcessCmd(DebugCommand.OnProcessCmd);
            //测试环境打开DebugWindow，取消仅在编辑器打开的判断
            //#if UNITY_EDITOR
            var window = GameObject.Instantiate(Resources.Load<GameObject>("Debug/DebugWindow"));

            GameObject.DontDestroyOnLoad(window);
            debugWindow = window.AddComponent<DebugWindow>();
            //#endif
#endif

            CullManager.Instance.Factor = 1.0f;

            QualitySetting.DeviceAdaptation();

            AssetResource ar = new AssetResource();
            // 加载混音设置
            yield return GetGlobalMono().StartCoroutine(ResourceLoader.Instance.load_asset("Assets/Res/Sound/AudioMixer.mixer", typeof(UnityEngine.Object), ar));
            AudioManager.Instance.InitMixer(ar.asset_ as AudioMixer);
            AudioSource audio = mCoreObject.AddComponent<AudioSource>();
            audio.playOnAwake = true;
            audio.loop = true;
            audio.outputAudioMixerGroup = AudioManager.Instance.GetAudioMixerGroup("Music");


            BackGroundAudio backAudio = mCoreObject.AddComponent<BackGroundAudio>();
            backAudio.Init();

		    if (Const.Language != LanguageType.SIMPLE_CHINESE)
		    {
		        string localizeData = LocalizeManager.Instance.GetLocalizationDataPath(Const.Language);
		        yield return GetGlobalMono().StartCoroutine(GameLocalizeHelper.CoLoadLocalizeFile(localizeData));
		    }

		    // 加载Font
            ar = new AssetResource();
            yield return GetGlobalMono().StartCoroutine(ResourceLoader.Instance.load_asset("Assets/Res/UI/Textures/Emoji/Output/emoji.txt", typeof(UnityEngine.Object), ar));
            mEmojiTxt = ar.asset_;
            if (mEmojiTxt == null)
                Debug.LogError("emmoji.txt load failed.");
            ar = new AssetResource();
            yield return GetGlobalMono().StartCoroutine(ResourceLoader.Instance.load_asset(EmojiText.GetEmojiTextName(EmojiText.EmojiMaterialType.EquipTips), typeof(UnityEngine.Object), ar));
            mEmojiTxt_equipTips = ar.asset_;
            if (mEmojiTxt_equipTips == null)
                Debug.LogError("emoji_equipTips.txt load failed.");

            // 加载UIMain，程序中只加载一次
            PrefabResource pr = new PrefabResource();
            yield return GetGlobalMono().StartCoroutine(ResourceLoader.Instance.load_prefab("Assets/Res/UI/Widget/Preset/UIRoot.prefab", pr, false));
            pr.obj_.transform.position = new Vector3(0, 1000.0f, 0);
			GameObject.DontDestroyOnLoad(pr.obj_);
			mGame.Init();

            // 加载Start场景
            if (Game.Instance.IsSkillEditorScene)
            {
                var scene_asset_path = string.Format("Assets/Res/Map/scenes/{0}.unity", GlobalConst.DefaultTestScene);
                yield return GetGlobalMono().StartCoroutine(ResourceLoader.Instance.load_scene(scene_asset_path, GlobalConst.DefaultTestScene, null));
            }

			// destroy initscenloader
			GameObject.DestroyImmediate(NewInitSceneLoader.Instance.gameObject, true);

            // 初始化Game的状态机
            mGame.InitFSM();
            mGame.mIsInited = true;

            Application.targetFrameRate = Const.G_FPS;

            var fps_respond = mCoreObject.AddComponent<FPSRespond>();
            fps_respond.FPSUpdateWaitTime = 15.0f;

            var fps_notice = mCoreObject.AddComponent<FPSNotice>();

            // 预加载资源
            ControlServerLogHelper.Instance.PostPlayerFollowRecord(PlayerFollowRecordSceneId.PreloadResEnd);
            ControlServerLogHelper.Instance.PostCloudLadderEventAction(CloudLadderMarkEnum.load_res);

            // 向后台请求渠道信息列表和服务器列表
#if !UNITY_IPHONE
            ControlServerLogHelper.Instance.GetChannelList();
#endif
            ControlServerLogHelper.Instance.GetServerList();
        }

        static bool mExtraLoadStarted = false;

        /// <summary>
        /// 预加载额外的资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerator PreloadExtra()
        {
            if (mExtraLoadStarted)
                yield break;

            mExtraLoadStarted = true;

            // 提前加载资源
            yield return GetGlobalMono().StartCoroutine(Preload());
            //预加载图标对象缓冲池
            yield return GetGlobalMono().StartCoroutine(UIManager.Instance.UICache.InitCachedItems());
            //预加载小红点
            yield return GetGlobalMono().StartCoroutine(UIManager.Instance.UICache.InitRedPointGameObject());
            //预加载锁头
            yield return GetGlobalMono().StartCoroutine(UIManager.Instance.UICache.InitLockIconGameObject());
            //预加载New标记
            yield return GetGlobalMono().StartCoroutine(UIManager.instance.UICache.InitNewMarkerGameObject());

            //预加载PreviewTexture背景图材质
            yield return GetGlobalMono().StartCoroutine(UIManager.Instance.UICache.InitPreviewBackgroundMat());
        }

        //get a global mon obehaviour for coroutine
        public static MonoBehaviour GetGlobalMono()
		{
			return ResourceLoader.Instance;
		}

        public static MonoBehaviour GlobalMono
        {
            get
            {
                return ResourceLoader.Instance;
            }
        }

        public static IEnumerator Preload()
		{
			yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/Materials/HurtHighLight.mat", 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/Materials/Dissolve.mat", 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/"+ResPath.MAT_TOMBSTONE, 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/" + ResPath.MAT_OUTLING, 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/Core/ShadowProjector/HardShadowProjector.prefab", 0));
            // 预加载ai文件
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/AI/empty.json", 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/AI/player.json", 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/AI/normal_pet.json", 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/AI/normal_summon_monster.json", 0));
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/AI/normal_summon_monster_not_follow.json", 0));
            //yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/Res/UI/Widget/Dynamic/UIGoodsItem.prefab", 0));

            // 预加载掉落物品
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.preload("Assets/" + ResPath.path12, 0));
        }

        public static HttpRequest HttpRequest
        {
            get
            {
                return mCoreObject.GetComponent<HttpRequest>();
            }
        }

        public static DebugUI DebugUI
        {
            get
            {
                return mDebugUI;
            }
        }
        
        /// <summary>
        /// 隐藏调试UI
        /// </summary>
        public static void HideDebugUI()
        {
            DebugUI debugUI = DebugUI;
            if (debugUI != null)
            {
                debugUI.enabled = false;
            }

            var fps_respond = mCoreObject.GetComponent<FPSRespond>();
            if (fps_respond != null)
            {
                fps_respond.enabled = false;
            }

            DebugFPS debugFPS = mCoreObject.GetComponent<DebugFPS>();
            if (debugFPS != null)
            {
                debugFPS.enabled = false;
            }

            if (debugWindow != null)
            {
                debugWindow.gameObject.SetActive(false);
            }
        }
    }
}

