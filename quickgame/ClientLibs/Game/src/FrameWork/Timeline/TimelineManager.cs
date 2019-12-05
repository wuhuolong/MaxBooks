//------------------------------------------------------------------------------
// Desc   :  Timeline剧情管理类
// Author :  ljy
// Date   :  2017.9.13
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using SGameEngine;

namespace xc
{
    class TimelineInfo
    {
        public uint Id;                             // 剧情配置表里面的id
        public PlayableDirector PlayableDirector;   // 挂在prefab上的PlayableDirector对象
        public GameObject RelatedGameObject;        // 关联的GameObject
        public System.Action FinishCallback;        // 播放完毕回调
        public AvatarProperty AvatarProperty;       // 指定换装信息
        public bool NeedCameraFollowInterpolationWhenFinished = false;  // 播放完毕后是否需要镜头融合
        public bool ShowLocalPlayer;    // 播放时是否显示主角
        public bool NoStopLocalPlayer;  // 播放时是否不停止主角行为
        public bool ShowUI; // 播放时是否显示ui
        public bool PauseMusic; // 播放时是否暂停背景音乐
        public bool NeedGC; // 播放完毕后是否要触发gc
    }

    /// <summary>
    /// 配置表数据
    /// </summary>
    class TimelineConfig
    {
        public uint Id; // id
        public string PrefabPath;   // prefab路径
        public Vector3 Pos; // prefab放置的位置
        public Vector3 Rotation; // prefab放置的旋转
        public bool NeedCameraFollowInterpolationWhenFinished;  // 播放完毕后是否需要镜头融合
        public bool ShowLocalPlayer;    // 播放时是否显示主角
        public bool NoStopLocalPlayer;  // 播放时是否不停止主角行为
        public bool ShowUI; // 播放时是否显示ui
        public uint MinMemory;  // 播放的最低内存要求
        public bool PauseMusic; // 播放时是否暂停背景音乐
        public string RelatedPrefabPath;    // 关联prefab的路径
        public Vector3 RelatedPrefabPos;    // 关联prefab的位置
        public string BehaviorScript;  // 绑定的lua脚本
        public bool NeedGC; // 播放完毕后是否要触发gc
    }

    [wxb.Hotfix]
    public class TimelineManager : xc.Singleton<TimelineManager>
    {
        TimelineInfo mPlayingTimeline;

        /// <summary>
        /// 加载剧情资源的协程
        /// </summary>
        List<Coroutine> mLoadPrefabCoroutines = new List<Coroutine>();

        /// <summary>
        /// 缓存列表
        /// </summary>
        Queue<TimelineInfo> mCacheTimelineList = new Queue<TimelineInfo>();

        /// <summary>
        /// 所有剧情（包括在缓存列表里面的）播放完毕后的回调
        /// </summary>
        List<System.Action> mAllFinishCallbacks = new List<System.Action>();

        /// <summary>
        /// 正在加载prefab的timeline
        /// </summary>
        List<uint> mLoadingTimelineIdList = new List<uint>();

        /// <summary>
        /// 播放剧情之前自动战斗状态，播放结束后要恢复
        /// </summary>
        bool mIsAutoFightingWhenPlaying = false;

        /// <summary>
        /// 播放剧情之前摄像机的旋转，播放结束后要恢复
        /// </summary>
        Quaternion mCameraRotationBeforePlay;

        /// <summary>
        /// 播放剧情之前摄像机的fov，播放结束后要恢复
        /// </summary>
        float mCameraFOVBeforePlay = 0;

        /// <summary>
        /// 播放剧情之前正在导航的任务，播放结束后要恢复
        /// </summary>
        uint mNavigatingTaskIdBeforePlay = 0;

        /// <summary>
        /// 已经播放了的剧情动画
        /// </summary>
        List<uint> mPlayedTimelineIds = new List<uint>();

        /// <summary>
        /// 预加载的资源
        /// </summary>
        Dictionary<uint, SGameEngine.AssetResource> mPreloadedTimelineReses = new Dictionary<uint, SGameEngine.AssetResource>();

        /// <summary>
        /// 正在预加载资源的timeline
        /// </summary>
        List<uint> mPreloadingTimelines = new List<uint>();

        /// <summary>
        /// 上个场景最后的AvatarProperty
        /// 切场景之前会保存player当前的AvatarProperty
        /// 用于跳场景后player未加载时的换装处理
        /// </summary>
        AvatarProperty mPlayerLastSceneAvatarProperty = null;

        public AvatarProperty PlayerLastSceneAvatarProperty
        {
            get
            {
                return mPlayerLastSceneAvatarProperty;
            }
        }

        public bool changeSkin = false;

        public TimelineManager()
        {
            mLoadPrefabCoroutines.Clear();
            mPreloadedTimelineReses.Clear();
            mPreloadingTimelines.Clear();

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnSwitchScene);
        }

        public void Reset()
        {
            mCacheTimelineList.Clear();
            mAllFinishCallbacks.Clear();
            mLoadingTimelineIdList.Clear();
            mIsAutoFightingWhenPlaying = false;
            mPlayedTimelineIds.Clear();

            Clear();
        }

        public void Update()
        {
            TimelineInfo timelineInfoToDestroy = null;
            if (mPlayingTimeline != null)
            {
                PlayableDirector playableDirector = mPlayingTimeline.PlayableDirector;
                if (playableDirector != null && playableDirector.isActiveAndEnabled)
                {
                    //GameDebug.LogError("playableDirector.state: " + playableDirector.state.ToString()
                    //    + ", playableDirector.time: " + playableDirector.time
                    //    + ", playableDirector.duration: " + playableDirector.duration);
                    if (playableDirector.state == PlayState.Paused)
                    {
                        if (playableDirector.time > 0f) // 暂停状态下，如果已经走了一段时间则算是播放结束
                        {
                            timelineInfoToDestroy = mPlayingTimeline;
                        }
                        else  // 否则需要恢复播放
                        {
                            playableDirector.Resume();
                        }
                    }
                    else if (playableDirector.time >= playableDirector.duration)    // 时间大于等于总时间，则算是播放结束
                    {
                        timelineInfoToDestroy = mPlayingTimeline;
                    }
                }
            }
            if (timelineInfoToDestroy != null)
            {
                StopImpl(timelineInfoToDestroy);

                // 播放缓存下来的动画
                if (mCacheTimelineList.Count > 0)
                {
                    TimelineInfo cacheTimelineInfo = mCacheTimelineList.Dequeue();
                    PlayImpl(cacheTimelineInfo);
                }
                else
                {
                    if (mAllFinishCallbacks.Count > 0)
                    {
                        foreach (System.Action finishCallback in mAllFinishCallbacks)
                        {
                            if (finishCallback != null)
                            {
                                finishCallback();
                            }
                        }
                        mAllFinishCallbacks.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// 停止播放剧情
        /// </summary>
        /// <param name="timelineInfo"></param>
        void StopImpl(TimelineInfo timelineInfo)
        {
            //GameDebug.LogError("TimelineManager.StopImpl: " + timelineInfo.Id);

            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null)
            {
                if (Game.Instance.CameraControl != null)
                {
                    Game.Instance.CameraControl.Target = localPlayer.Trans;
                    Game.Instance.CameraControl.NeedFollowInterpolation = timelineInfo.NeedCameraFollowInterpolationWhenFinished;
                }
                else
                {
                    GameDebug.LogError("Stop timeline error, CameraControl is null!!!");
                }
            }
            else
            {
                // 播放动画的时候有可能还没登录游戏，所以LocalPlayer有可能不存在，这里的报错屏蔽掉
                //GameDebug.LogError("Stop timeline error, can not get local player!!!");
            }
            if (Game.Instance.MainCamera != null)
            {
                Cinemachine.CinemachineBrain cinemachineBrain = Game.Instance.MainCamera.GetComponent<Cinemachine.CinemachineBrain>();
                if (cinemachineBrain != null)
                {
                    cinemachineBrain.enabled = false;
                }
                Game.Instance.MainCamera.transform.rotation = mCameraRotationBeforePlay;
                Game.Instance.MainCamera.fieldOfView = mCameraFOVBeforePlay;
            }
            else
            {
                GameDebug.LogError("Stop timeline error, can not get main camera!!!");
            }

            if (timelineInfo.PlayableDirector != null)
            {
                timelineInfo.PlayableDirector.time = timelineInfo.PlayableDirector.duration;
                GameObject.DestroyImmediate(timelineInfo.PlayableDirector.gameObject);
            }
            else
            {
                GameDebug.LogError("Stop timeline error, PlayableDirector is null!!!");
            }
            if (timelineInfo.RelatedGameObject != null)
            {
                GameObject.DestroyImmediate(timelineInfo.RelatedGameObject);
            }
            mPlayingTimeline = null;

            SetAllActorsVisible(true, timelineInfo.ShowLocalPlayer);

            // 恢复主角的自动战斗
            if (InstanceManager.Instance.IsAutoFighting != mIsAutoFightingWhenPlaying)
            {
                InstanceManager.Instance.IsAutoFighting = mIsAutoFightingWhenPlaying;
            }
            mIsAutoFightingWhenPlaying = false;

            GameInput.Instance.EnableInput(true, true);

            // 恢复CullManager的Update
            CullManager.Instance.IsEnabled = true;

            // 显示UI
            if (timelineInfo.ShowUI == false)
            {
                xc.ui.ugui.UIManager.Instance.ShowAllWindow();
            }

            // 恢复新手引导
            //GuideManager.Instance.Resume();

            // 恢复任务寻路
            if (mNavigatingTaskIdBeforePlay > 0)
            {
                Task task = TaskManager.Instance.GetTask(mNavigatingTaskIdBeforePlay);
                if (task != null)
                {
                    TaskHelper.TaskGuide(task);
                }
                mNavigatingTaskIdBeforePlay = 0;
            }

            // 恢复背景音乐
            if (!GlobalSettings.Instance.MusicMute && timelineInfo.PauseMusic)
            {
                AudioManager.Instance.PauseMusic(false);
            }

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TIMELINE_FINISH, new CEventBaseArgs(timelineInfo.Id));

            if (timelineInfo.FinishCallback != null)
            {
                timelineInfo.FinishCallback();
            }

            // 释放预加载的资源
            SGameEngine.AssetResource ar = null;
            if (mPreloadedTimelineReses.TryGetValue(timelineInfo.Id, out ar) == true)
            {
                if (ar != null)
                {
                    ar.destroy();
                }

                mPreloadedTimelineReses.Remove(timelineInfo.Id);
            }

            // 如果有待播放的系统开放动画，则重新开放
            if (SysConfigManager.Instance.IsWaiting() == true)
            {
                if (SceneHelp.Instance.IsInWildInstance())
                {
                    TargetPathManager.Instance.StopPlayerAndReset();//有系统开启停止寻路
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
                }
                else
                    ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());
            }

            // 短时间内播放同一个模型的动画两次，第二个剧情会播放不出来，调用一下ResourceLoader的gc就好了，通过表格配置
            if (timelineInfo.NeedGC == true)
            {
                ResourceLoader.Instance.gc();
            }
        }

        /// <summary>
        /// 开始播放剧情
        /// </summary>
        /// <param name="timelineInfo"></param>
        void PlayImpl(TimelineInfo timelineInfo)
        {
            //GameDebug.LogError("TimelineManager.PlayImpl: " + timelineInfo.Id);

            mPlayingTimeline = timelineInfo;

            PlayableDirector playableDirector = timelineInfo.PlayableDirector;
            if (playableDirector == null)
            {
                if (timelineInfo.FinishCallback != null)
                {
                    timelineInfo.FinishCallback();
                }

                if (timelineInfo.RelatedGameObject != null)
                {
                    GameObject.DestroyImmediate(timelineInfo.RelatedGameObject);
                }

                return;
            }

            if (playableDirector.playableAsset == null)
            {
                if (timelineInfo.FinishCallback != null)
                {
                    timelineInfo.FinishCallback();
                }

                GameDebug.LogError("Play timeline " + playableDirector.gameObject.name + " error, playable asset is null!");

                mPlayingTimeline = null;
                GameObject.DestroyImmediate(playableDirector.gameObject);
                if (timelineInfo.RelatedGameObject != null)
                {
                    GameObject.DestroyImmediate(timelineInfo.RelatedGameObject);
                }
                return;
            }

            if (Game.Instance.MainCamera == null)
            {
                if (timelineInfo.FinishCallback != null)
                {
                    timelineInfo.FinishCallback();
                }

                GameDebug.LogError("Play timeline " + playableDirector.gameObject.name + " error, main camera is null!");

                mPlayingTimeline = null;
                GameObject.DestroyImmediate(playableDirector.gameObject);
                if (timelineInfo.RelatedGameObject != null)
                {
                    GameObject.DestroyImmediate(timelineInfo.RelatedGameObject);
                }
                return;
            }

            Cinemachine.CinemachineBrain cinemachineBrain = Game.Instance.MainCamera.GetComponent<Cinemachine.CinemachineBrain>();
            if (cinemachineBrain == null)
            {
                cinemachineBrain = Game.Instance.MainCamera.gameObject.AddComponent<Cinemachine.CinemachineBrain>();
            }
            if (cinemachineBrain != null)
            {
                cinemachineBrain.enabled = true;
            }
            else
            {
                GameDebug.LogError("Play timeline " + playableDirector.gameObject.name + " error, can not find CinemachineBrain component in main camera!");

                mPlayingTimeline = null;
                GameObject.DestroyImmediate(playableDirector.gameObject);
                if (timelineInfo.RelatedGameObject != null)
                {
                    GameObject.DestroyImmediate(timelineInfo.RelatedGameObject);
                }

                if (timelineInfo.FinishCallback != null)
                {
                    timelineInfo.FinishCallback();
                }

                return;
            }

            // 隐藏所有角色
            SetAllActorsVisible(false, timelineInfo.ShowLocalPlayer);

            // 野外场景中记住正在寻路的任务
            if (SceneHelp.Instance.IsInWildInstance() == true)
            {
                Task navigatingTask = TaskManager.Instance.NavigatingTask;
                if (navigatingTask != null)
                {
                    mNavigatingTaskIdBeforePlay = navigatingTask.Define.Id;
                }
            }

            Actor localPlayer = Game.Instance.GetLocalPlayer();

            TimelineAsset asset = playableDirector.playableAsset as TimelineAsset;
            foreach (TrackAsset track in asset.GetOutputTracks())
            {
                GroupTrack group = track.GetGroup();
                if (group != null)
                {
                    // 绑定主摄像机
                    if (group.name.StartsWith("Camera") == true)
                    {
                        Camera mainCamera = Game.Instance.MainCamera;
                        if (mainCamera != null)
                        {
                            foreach (PlayableBinding output in track.outputs)
                            {
                                if (output.sourceObject != null)
                                {
                                    playableDirector.SetGenericBinding(output.sourceObject, mainCamera.gameObject);
                                }
                            }
                        }
                    }

                    if (group.name.StartsWith("Hero") == true)
                    {
                        if (localPlayer != null)
                        {
                            foreach (PlayableBinding output in track.outputs)
                            {
                                GameObject actorModel = null;
                                if (output.sourceObject != null)
                                {
                                    Object binding = playableDirector.GetGenericBinding(output.sourceObject);
                                    if (binding == null)
                                    {
                                        GameDebug.LogError("Player timeline " + timelineInfo.PlayableDirector.name + " error!!! " + output.sourceObject.name + " 's binding object is null!!!");
                                        continue;
                                    }
                                    GameObject bindingObj = binding as GameObject;
                                    if (bindingObj != null)
                                    {
                                        bindingObj.SetActive(false);
                                    }

                                    // 根据职业显示主角的模型
                                    if (bindingObj != null && bindingObj.name.StartsWith("Hero_") == true)
                                    {
                                        uint vocation = uint.Parse(bindingObj.name.Substring(5));
                                        if (vocation == LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
                                        {
                                            //playableDirector.SetGenericBinding(output.sourceObject, localPlayer.gameObject);
                                            CommonTool.SetActive(bindingObj,true);
                                            actorModel = bindingObj;
                                        }
                                        else
                                        {
                                            CommonTool.SetActive(bindingObj,false);
                                        }
                                    }
                                }
                                if(actorModel != null && changeSkin)
                                {
                                    //changeSkin = false;
                                    if (timelineInfo.AvatarProperty != null)
                                    {
                                        ResourceLoader.Instance.StartCoroutine(AvatarUtils.ChangeModel(actorModel, timelineInfo.AvatarProperty));
                                    }
                                    else
                                    {
                                        AvatarProperty avatarProperty; 
                                        if(localPlayer.mAvatarCtrl != null && localPlayer.mAvatarCtrl.GetLatestAvatartProperty() != null)
                                        {
                                            avatarProperty = localPlayer.mAvatarCtrl.GetLatestAvatartProperty();
                                        }
                                        else
                                        {
                                            avatarProperty = mPlayerLastSceneAvatarProperty;
                                        }
                                        ResourceLoader.Instance.StartCoroutine(AvatarUtils.ChangeModel(actorModel, avatarProperty));
                                    }
                                }
                            }
                        }
                    }
                }

                // 音效是否静音
                AudioTrack audioTrack = track as AudioTrack;
                if (audioTrack != null)
                {
                    audioTrack.muted = GlobalSettings.Instance.SFXMute;
                }
            }

            if (Game.Instance.CameraControl != null)
            {
                Game.Instance.CameraControl.Target = null;
            }

            // 记住当前状态并暂停主角的自动战斗
            mIsAutoFightingWhenPlaying = InstanceManager.Instance.IsAutoFighting;
            InstanceManager.Instance.IsAutoFighting = false;

            // 停止主角的寻路
            if (timelineInfo.NoStopLocalPlayer == false)
            {
                TargetPathManager.Instance.StopPlayerAndReset();
            }

            mCameraRotationBeforePlay = Game.Instance.MainCamera.transform.rotation;
            mCameraFOVBeforePlay = Game.Instance.MainCamera.fieldOfView;

            bool setUI = true;
            if (timelineInfo.ShowUI == true)
            {
                setUI = false;
            }
            GameInput.Instance.EnableInput(false, setUI);

            // 暂停CullManager的Update
            CullManager.Instance.IsEnabled = false;

            // 隐藏UI
            if (timelineInfo.ShowUI == false)
            {
                xc.ui.ugui.UIManager.Instance.CloseAllWindow();
            }

            if (!GlobalSettings.Instance.MusicMute && timelineInfo.PauseMusic)
            {
                AudioManager.Instance.PauseMusic(true);
            }

            playableDirector.gameObject.SetActive(true);

            if (timelineInfo.RelatedGameObject != null)
            {
                timelineInfo.RelatedGameObject.SetActive(true);
            }

            playableDirector.Play();

            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_TIMELINE_START, new CEventBaseArgs(timelineInfo.Id));
        }

        /// <summary>
        /// 加载timeline prefab协程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prefabPath"></param>
        /// <param name="finishCallback"></param>
        /// <param name="pos"></param>
        /// <param name="needCameraFollowInterpolationWhenFinished"></param>
        /// <param name="showLocalPlayer"></param>
        /// <returns></returns>
        IEnumerator LoadPrefabCoroutine(TimelineConfig config, System.Action finishCallback, AvatarProperty avatarProperty)
        {
            uint id = config.Id;
            string prefabPath = config.PrefabPath;
            Vector3 pos = config.Pos;
            Vector3 rotation = config.Rotation;
            bool needCameraFollowInterpolationWhenFinished = config.NeedCameraFollowInterpolationWhenFinished;
            bool showLocalPlayer = config.ShowLocalPlayer;
            bool noStopLocalPlayer = config.NoStopLocalPlayer;
            bool showUI = config.ShowUI;
            bool pauseMusic = config.PauseMusic;
            bool needGC = config.NeedGC;

            SGameEngine.PrefabResource pr = new SGameEngine.PrefabResource();
            yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(string.Format("Assets/Res{0}.prefab", prefabPath), pr));

            // 延迟资源的加载，测试用
            //yield return new WaitForSeconds(5f);

            // 恢复玩家操作
            GameInput.Instance.EnableInput(true, true);

            GameObject obj = pr.obj_;
            if (obj == null)
            {
                if (finishCallback != null)
                {
                    finishCallback();
                }

                if (mLoadingTimelineIdList.Contains(id) == true)
                {
                    mLoadingTimelineIdList.Remove(id);
                }

                GameDebug.LogError("Play timeline " + prefabPath + " error, can not load prefab!");
                yield break;
            }

            PlayableDirector playableDirector = obj.GetComponent<PlayableDirector>();
            if (playableDirector == null)
            {
                GameObject.DestroyImmediate(obj);

                if (finishCallback != null)
                {
                    finishCallback();
                }

                if (mLoadingTimelineIdList.Contains(id) == true)
                {
                    mLoadingTimelineIdList.Remove(id);
                }

                GameDebug.LogError("Play timeline " + prefabPath + " error, can not find PlayableDirector component!");
                yield break;
            }

            string relatedPrefabPath = config.RelatedPrefabPath;
            SGameEngine.PrefabResource relatedPrefabPr = null;
            if (string.IsNullOrEmpty(relatedPrefabPath) == false)
            {
                relatedPrefabPr = new SGameEngine.PrefabResource();
                yield return SGameEngine.ResourceLoader.Instance.StartCoroutine(SGameEngine.ResourceLoader.Instance.load_prefab(string.Format("Assets/Res{0}.prefab", relatedPrefabPath), relatedPrefabPr));
            }

            obj.SetActive(false);
            obj.transform.position = pos;
            obj.transform.localScale = Vector3.one;
            obj.transform.localEulerAngles = rotation;

            TimelineInfo timelineInfo = new TimelineInfo();
            playableDirector.time = 0;
            timelineInfo.Id = id;
            timelineInfo.PlayableDirector = playableDirector;
            timelineInfo.FinishCallback = finishCallback;
            timelineInfo.AvatarProperty = avatarProperty;
            timelineInfo.NeedCameraFollowInterpolationWhenFinished = needCameraFollowInterpolationWhenFinished;
            timelineInfo.ShowLocalPlayer = showLocalPlayer;
            timelineInfo.NoStopLocalPlayer = noStopLocalPlayer;
            timelineInfo.ShowUI = showUI;
            timelineInfo.PauseMusic = pauseMusic;
            timelineInfo.NeedGC = needGC;

            // 关联GameObject
            timelineInfo.RelatedGameObject = null;
            if (relatedPrefabPr != null)
            {
                if (relatedPrefabPr.obj_ != null)
                {
                    timelineInfo.RelatedGameObject = relatedPrefabPr.obj_;
                    timelineInfo.RelatedGameObject.SetActive(false);
                    timelineInfo.RelatedGameObject.transform.position = config.RelatedPrefabPos;
                    timelineInfo.RelatedGameObject.transform.localScale = Vector3.one;
                    timelineInfo.RelatedGameObject.transform.localEulerAngles = Vector3.zero;
                }
                else
                {
                    GameDebug.LogError("Play timeline " + id + " error, can not load related prefab " + relatedPrefabPath);
                }
            }

            // lua脚本
            if (string.IsNullOrEmpty(config.BehaviorScript) == false)
            {
                if (LuaScriptMgr.Instance != null && LuaScriptMgr.Instance.IsLuaScriptExist(config.BehaviorScript))
                {
                    LuaMonoBehaviour com = obj.AddComponent<LuaMonoBehaviour>();
                    com.Init(config.BehaviorScript);
                }
                else
                {
                    System.Type t = System.Type.GetType(config.BehaviorScript);
                    if (t != null)
                    {
                        obj.AddComponent(t);
                    }
                }
            }

            // 延迟资源的加载，测试用
            //yield return new WaitForSeconds(10f);

            if (mPlayingTimeline != null)
            {
                mCacheTimelineList.Enqueue(timelineInfo);
            }
            else
            {
                PlayImpl(timelineInfo);
            }

            if (mLoadingTimelineIdList.Contains(id) == true)
            {
                mLoadingTimelineIdList.Remove(id);
            }

            //GameDebug.LogError("TimelineManager.LoadPrefabCoroutine: " + id);
        }

        /// <summary>
        /// 播放Timeline动画
        /// </summary>
        /// <param name="id">剧情配置表里面的id</param>
        /// <param name="finishCallback">播放结束回调</param>
        public void Play(uint id, System.Action finishCallback = null, AvatarProperty avatarProperty = null)
        {
            //GameDebug.LogError("TimelineManager.Play: " + id);
            //GameDebug.Log("TimelineManager.Play: " + id);

            TimelineConfig timelineConfig = null;
            if (GetTimelineConfig(id, out timelineConfig) == false)
            {
                if (finishCallback != null)
                {
                    finishCallback();
                }

                GameDebug.LogError("Play timeline error, can not find timeline id: " + id);
                return;
            }

            if (QualitySetting.SkipTimeline(timelineConfig.MinMemory) == true)
            {
                // 野外场景中记住正在寻路的任务
                uint navigatingTaskId = 0;
                if (SceneHelp.Instance.IsInWildInstance() == true)
                {
                    Task navigatingTask = TaskManager.Instance.NavigatingTask;
                    if (navigatingTask != null)
                    {
                        navigatingTaskId = navigatingTask.Define.Id;
                    }
                }
                bool isAutoFighting = InstanceManager.Instance.IsAutoFighting;

                if (finishCallback != null)
                {
                    finishCallback();
                }

                // 恢复自动战斗和任务寻路
                InstanceManager.Instance.IsAutoFighting = isAutoFighting;
                if (navigatingTaskId > 0)
                {
                    TaskHelper.TaskGuide(navigatingTaskId);
                }

                return;
            }

            mPlayedTimelineIds.Add(id);

            if (mLoadingTimelineIdList.Contains(id) == false)
            {
                mLoadingTimelineIdList.Add(id);
            }

            // 停止并禁止玩家操作
            if (timelineConfig.NoStopLocalPlayer == false)
            {
                Actor localPlayer = Game.Instance.GetLocalPlayer();
                if (localPlayer != null)
                {
                    localPlayer.Stop();
                    localPlayer.MoveCtrl.TryWalkAlongStop();
                }
            }
            GameInput.Instance.EnableInput(false, true);

            Coroutine coroutine = SGameEngine.ResourceLoader.Instance.StartCoroutine(LoadPrefabCoroutine(timelineConfig, finishCallback, avatarProperty));
            mLoadPrefabCoroutines.Add(coroutine);
        }

        /// <summary>
        /// 停止播放剧情
        /// </summary>
        public void Stop()
        {
            if (mPlayingTimeline != null)
            {
                StopImpl(mPlayingTimeline);
            }
        }

        /// <summary>
        /// 停止播放所有剧情，包括在缓存列表上的
        /// </summary>
        public void StopAll()
        {
            foreach (TimelineInfo timelineInfo in mCacheTimelineList)
            {
                if (timelineInfo != null)
                {
                    if (timelineInfo.PlayableDirector != null && timelineInfo.PlayableDirector.gameObject != null)
                    {
                        GameObject.DestroyImmediate(timelineInfo.PlayableDirector.gameObject);
                    }
                    if (timelineInfo.RelatedGameObject != null)
                    {
                        GameObject.DestroyImmediate(timelineInfo.RelatedGameObject);
                    }
                }
            }
            mCacheTimelineList.Clear();
            Stop();
        }

        /// <summary>
        /// 预加载资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Preload(uint id, System.Action finishCallback = null)
        {
            TimelineConfig timelineConfig = null;
            if (GetTimelineConfig(id, out timelineConfig) == false)
            {
                if (finishCallback != null)
                {
                    finishCallback();
                    finishCallback = null;
                }
                GameDebug.LogError("Preload timeline error, can not find timeline id: " + id);
                return false;
            }

            if (QualitySetting.SkipTimeline(timelineConfig.MinMemory) == true)
            {
                if (finishCallback != null)
                {
                    finishCallback();
                    finishCallback = null;
                }
                return false;
            }

            string prefabPath = timelineConfig.PrefabPath;
            bool needCameraFollowInterpolationWhenFinished = timelineConfig.NeedCameraFollowInterpolationWhenFinished;

            // 是否已经预加载过
            if (mPreloadedTimelineReses.ContainsKey(id) == true)
            {
                if (finishCallback != null)
                {
                    finishCallback();
                    finishCallback = null;
                }
                //GameDebug.LogError("Preload timeline error, this timeline have been preloaded, id:" + id);
                return false;
            }

            // 加载前放一个空值进去，防止多次预加载
            mPreloadedTimelineReses.Add(id, null);

            if (mPreloadingTimelines.Contains(id) == false)
            {
                mPreloadingTimelines.Add(id);
            }

            SGameEngine.ResourceLoader.Instance.LoadAssetAsync(string.Format("Assets/Res{0}.prefab", prefabPath), (ar) =>
            {
                if (ar != null)
                {
                    mPreloadedTimelineReses[id] = ar;

                    if (mPreloadingTimelines.Contains(id) == true)
                    {
                        mPreloadingTimelines.Remove(id);
                    }
                }

                if (finishCallback != null)
                {
                    finishCallback();
                    finishCallback = null;
                }
            });

            return true;
        }

        /// <summary>
        /// 是否正在预加载
        /// </summary>
        /// <returns></returns>
        public bool IsPreloading()
        {
            return mPreloadingTimelines.Count > 0;
        }

        /// <summary>
        /// 获取timeline配置表内容
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timelineConfig"></param>
        /// <returns></returns>
        bool GetTimelineConfig(uint id, out TimelineConfig timelineConfig)
        {
            timelineConfig = new TimelineConfig();
            timelineConfig.Id = id;

            List<Dictionary<string, string>> dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_timeline", "id", id.ToString());
            if (dbs.Count > 0)
            {
                Dictionary<string, string> db = dbs[0];

                // prefab路径
                string prefabPath = string.Empty;
                string prefabKey = "prefab_" + LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
                db.TryGetValue(prefabKey, out prefabPath);
                if (string.IsNullOrEmpty(prefabPath) == true)
                {
                    db.TryGetValue("prefab_1", out prefabPath);
                }
                if (string.IsNullOrEmpty(prefabPath) == true)
                {
                    GameDebug.LogError("Get timeline config error, can not find timeline prefab config, id: " + id);
                    return false;
                }
                timelineConfig.PrefabPath = prefabPath;

                // prefab位置
                string rawStr = string.Empty;
                db.TryGetValue("pos", out rawStr);
                timelineConfig.Pos = DBTextResource.ParseVector3(rawStr);

                // prefab旋转
                rawStr = string.Empty;
                db.TryGetValue("rotation", out rawStr);
                timelineConfig.Rotation = DBTextResource.ParseVector3(rawStr);

                // 播放完毕后是否需要镜头融合
                db.TryGetValue("need_camera_follow_interpolation_when_finished", out rawStr);
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0"))
                {
                    timelineConfig.NeedCameraFollowInterpolationWhenFinished = false;
                }
                else
                {
                    timelineConfig.NeedCameraFollowInterpolationWhenFinished = true;
                }

                // 播放时是否显示主角
                db.TryGetValue("show_local_player", out rawStr);
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0"))
                {
                    timelineConfig.ShowLocalPlayer = false;
                }
                else
                {
                    timelineConfig.ShowLocalPlayer = true;
                }

                // 播放时是否不停止主角行为
                db.TryGetValue("no_stop_local_player", out rawStr);
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0"))
                {
                    timelineConfig.NoStopLocalPlayer = false;
                }
                else
                {
                    timelineConfig.NoStopLocalPlayer = true;
                }

                // 播放时是否显示ui
                db.TryGetValue("show_ui", out rawStr);
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0"))
                {
                    timelineConfig.ShowUI = false;
                }
                else
                {
                    timelineConfig.ShowUI = true;
                }

                // 播放的最低内存要求
                db.TryGetValue("min_memory", out rawStr);
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0"))
                {
                    timelineConfig.MinMemory = 0;
                }
                else
                {
                    uint.TryParse(rawStr, out timelineConfig.MinMemory);
                }

                // 播放时是否显示ui
                db.TryGetValue("pause_music", out rawStr);
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0"))
                {
                    timelineConfig.PauseMusic = false;
                }
                else
                {
                    timelineConfig.PauseMusic = true;
                }

                // 关联prefab的路径
                db.TryGetValue("related_prefab", out rawStr);
                timelineConfig.RelatedPrefabPath = rawStr;

                // 关联prefab的位置
                db.TryGetValue("related_prefab_pos", out rawStr);
                timelineConfig.RelatedPrefabPos = DBTextResource.ParseVector3(rawStr);

                // 绑定的lua脚本
                db.TryGetValue("behavior_script", out timelineConfig.BehaviorScript);

                // 播放完毕后是否要触发gc
                db.TryGetValue("need_gc", out rawStr);
                if (string.IsNullOrEmpty(rawStr) == true || rawStr.Equals("0"))
                {
                    timelineConfig.NeedGC = false;
                }
                else
                {
                    timelineConfig.NeedGC = true;
                }

                return true;
            }
            else
            {
                GameDebug.LogError("Get timeline config error, can not find timeline id: " + id);
                return false;
            }
        }

        /// <summary>
        /// 是否在播放Timeline动画
        /// </summary>
        /// <returns></returns>
        public bool IsPlaying()
        {
            //if (mPlayingTimeline != null && mPlayingTimeline.PlayableDirector != null)
            //{
            //    if (mPlayingTimeline.PlayableDirector.state == PlayState.Playing)
            //    {
            //        return true;
            //    }
            //}
            if(IsPlayableDirectorPlaying())
            {
                return true;
            }

            if (IsLoading())
            {
                return true;
            }

            return false;
        }

        public bool IsPlayableDirectorPlaying()
        {
            if (mPlayingTimeline != null && mPlayingTimeline.PlayableDirector != null)
            {
                if (mPlayingTimeline.PlayableDirector.state == PlayState.Playing)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 是否正在加载动画
        /// </summary>
        /// <returns></returns>
        public bool IsLoading()
        {
            if (mLoadingTimelineIdList.Count > 0)
            {
                return true;
            }

            return false;
        }

        public void AddFinishCallback(System.Action finishCallback)
        {
            if (IsPlaying() == true)
            {
                mAllFinishCallbacks.Add(finishCallback);
            }
            else
            {
                finishCallback();
            }
        }

        void Clear()
        {
            StopAll();
        }

        void OnSwitchScene(CEventBaseArgs kArgs)
        {
            Clear();

            foreach (SGameEngine.AssetResource ar in mPreloadedTimelineReses.Values)
            {
                if (ar != null)
                {
                    ar.destroy();
                }
            }
            mPreloadedTimelineReses.Clear();

            foreach (Coroutine coroutine in mLoadPrefabCoroutines)
            {
                SGameEngine.ResourceLoader.Instance.StopCoroutine(coroutine);
            }
            mLoadPrefabCoroutines.Clear();

            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer != null && localPlayer.mAvatarCtrl != null && localPlayer.mAvatarCtrl.GetLatestAvatartProperty() != null)
            {
                mPlayerLastSceneAvatarProperty = localPlayer.mAvatarCtrl.GetLatestAvatartProperty();
            }
        }

        void SetAllActorsVisible(bool bVisible, bool showLocalPlayer)
        {
            if (Game.Instance.MainCamera != null)
            {
                int actorMask = (1 << LayerMask.NameToLayer("Monster"))
                    | (1 << LayerMask.NameToLayer("Npc"))
                    | (1 << LayerMask.NameToLayer("Pet"))
                    | (1 << LayerMask.NameToLayer("Ground"))
                    | (1 << LayerMask.NameToLayer("InterObject"));

                // 是否需要显示或者隐藏主角
                if (showLocalPlayer == false)
                {
                    // 主角的层级为Player和ShadowCaster
                    actorMask = actorMask | (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("ShadowCaster"));
                }

                if (bVisible == true)
                {
                    Game.Instance.MainCamera.cullingMask = actorMask | Game.Instance.MainCamera.cullingMask;
                }
                else
                {
                    Game.Instance.MainCamera.cullingMask = ~actorMask & Game.Instance.MainCamera.cullingMask;
                }
            }
        }

        /// <summary>
        /// 指定的副本开始timeline是否播放过(仅用于断线重连后和位面副本的判断)
        /// </summary>
        /// <param name="timeline_id"></param>
        /// <returns></returns>
        public bool IsInstanceStartTimelinePlayed(string timeline_id)
        {
            object[] param = { timeline_id };
            System.Type[] return_type = { typeof(bool) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TimelineLuaManager_IsInstanceStartTimelinePlayed", param, return_type);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    bool a = (bool)objs[0];
                    return a;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否要播放开场剧情动画
        /// </summary>
        /// <returns></returns>
        public bool ShouldPlayOpenningTimeline()
        {
            // 如果配置为0则不用播放
            if (xc.GameConstHelper.GetUint("GAME_OPENING_TIMELINE_ID") == 0)
            {
                return false;
            }

            if (SceneHelp.Instance.CurSceneID == GameConstHelper.GetUint("GAME_BORN_DUNGEON"))
            {
                uint localPlayerLevel = 0;
                uint.TryParse(GlobalConfig.GetInstance().LoginInfo.Level, out localPlayerLevel);
                //GameDebug.LogError("ShouldPlayOpenningTimeline localPlayerLevel: " + localPlayerLevel);
                if (localPlayerLevel <= 1)
                {
                    string uuid = GlobalConfig.GetInstance().LoginInfo.RId;
                    string key = "HavePlayOpeningTimeline_" + uuid;
                    if (GlobalConfig.GetInstance().LoginInfo != null && GlobalConfig.GetInstance().LoginInfo.ServerInfo != null)
                    {
                        key = key + "_" + GlobalConfig.GetInstance().LoginInfo.ServerInfo.ServerId;
                    }
                    //GameDebug.LogError("ShouldPlayOpenningTimeline key: " + key);
                    int havePlayOpeningTimeline = xc.UserPlayerPrefs.GetInstance().GetInt(key, 0);
                    //GameDebug.LogError("ShouldPlayOpenningTimeline havePlayOpeningTimeline: " + havePlayOpeningTimeline);
                    if (havePlayOpeningTimeline == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool OpenningTimelineHavePlayed()
        {
            uint openningTimeline = xc.GameConstHelper.GetUint("GAME_OPENING_TIMELINE_ID");
            return mPlayedTimelineIds.Contains(openningTimeline);
        }

        public void PlayWeddingChapelTimeline()
        {
            LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "TimelineLuaManager_PlayWeddingChapelTimeline");
        }
    }
}
