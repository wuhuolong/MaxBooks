//-------------------------------------------------------------------
// Desc : 音效的管理类
// Author : raorui
// Date : 2016.9.14 重构
//-------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;
using UnityEngine.Events;
using System.IO;
using UnityEngine.Audio;

namespace xc
{

    public enum SoundType
    {
        Other,
        LocalPlayer,//本地玩家战斗音效
        Boss,       //boss的战斗音效
        Monster,    //怪物及其他玩家的战斗音效
        Voice,      //引导语音
        NPC         //npc语音
    }

    public enum BackGroundType
    {
        Main,
        Fight
    }

    [wxb.Hotfix]
    public class AudioManager : xc.Singleton<AudioManager>
    {
        private static int GC_INTERVAL = 60; //gc周期1分钟
        private static int AUDIO_ASSET_MAX_LIFE_TIME = 300; //生命周期5分钟 自动销毁

        /// <summary>
        /// 动态加载的音效资源，管理销毁
        /// </summary>
        Dictionary<uint, AssetResource> mLoadedAudioAsset = new Dictionary<uint, AssetResource>();
        Dictionary<uint, float> mAudioAssetDestroyTime = new Dictionary<uint, float>();

        AudioListener m_Listener;
        AudioMixer mMixer;
        Dictionary<string, AudioMixerGroup> audioMixerGroups = new Dictionary<string, AudioMixerGroup>();
        Utils.Timer mGCTimer;

        public void Reset()
        {
            if (mGCTimer != null)
            {
                mGCTimer.Destroy();
            }
            mGCTimer = new Utils.Timer(GC_INTERVAL * 1000, true, GC_INTERVAL * 1000, GCTimerUpdate);
        }

        public void InitMixer(AudioMixer mixer)
        {
            this.mMixer = mixer;
            if (mixer != null)
            {
                AudioMixerGroup[] mixerGroup = mixer.FindMatchingGroups("Master");
                foreach (AudioMixerGroup amg in mixerGroup)
                {
                    audioMixerGroups.Add(amg.name, amg);
                }
            }
         
        }

        public AudioMixerGroup GetAudioMixerGroup(string name)
        {
            if(audioMixerGroups.ContainsKey(name))
            {
                return audioMixerGroups[name];
            }
            return null;
        }

        /// <summary>
        /// 加载声音资源，并将声音资源的生命周期绑定在bind_node上
        /// </summary>
        /// <param name="bind_node"></param>
        /// <param name="res_path"></param>
        /// <param name="is_loop"></param>
        public void BindAudio(GameObject bind_node, string res_path, bool is_loop)
        {
            if (string.IsNullOrEmpty(res_path) == false)
            {
                MainGame.HeartBehavior.StartCoroutine(LoadAudio(bind_node, res_path, is_loop));
            }
        }

        /// <summary>
        /// 加载音效资源
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadAudio(GameObject bind_node, string res_path, bool is_loop)
        {
            AssetResource ar = new AssetResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(res_path, typeof(Object), ar));
            if (ar.asset_ == null)
            {
                GameDebug.LogError(string.Format("the res {0} does not exist", res_path));
                yield break;
            }

            if (bind_node != null)
            {
                ResourceUtilEx.Instance.host_res_to_gameobj(bind_node, ar);// 将asset资源的生命周期与GameObject关联起来
                var audio_clip = ar.asset_ as AudioClip;
                if (audio_clip != null)
                {
                    PlayAudio(audio_clip, is_loop);
                }
            }
            else
            {
                ar.destroy();
            }
        }

        public void StopBattleSFX(uint id)
        {
            if (id == 0)
            {
                return;
            }
            InitListener();
            if (m_Listener != null && m_Listener.enabled && UGUITools.GetActive(m_Listener.gameObject))
            {
                BattleSFXAudioSource source = GetSFXAudioSource();
                if (source != null)
                    source.StopSound(id);
            }
        }

        public void GCTimerUpdate(float remainTime)
        {
            //Debug.Log("GCTimerUpdate ");
            GC_DestroySFX();
        }

        private void GC_DestroySFX()
        {
            float time = Time.time;
            List<uint> destriyIdList = new List<uint>();

            foreach(var kv in mAudioAssetDestroyTime)
            {
                if(time > kv.Value)
                {
                    destriyIdList.Add(kv.Key);
                }
            }

            foreach (var id in destriyIdList)
            {
                mAudioAssetDestroyTime.Remove(id);
                mLoadedAudioAsset[id].destroy();
                mLoadedAudioAsset.Remove(id);
            }
        }

        public void DestroySFX(uint id,float delayTime = 0)
        {
            if (mLoadedAudioAsset.ContainsKey(id))
            {
                float destroyTime = Time.time + delayTime;
                if (mAudioAssetDestroyTime.ContainsKey(id))
                {
                    if(mAudioAssetDestroyTime[id] > destroyTime)
                    {
                        mAudioAssetDestroyTime[id] = destroyTime;
                    }
                }else
                {
                    mAudioAssetDestroyTime.Add(id, destroyTime);
                }
            }
        }

        public uint PlayBattleSFX( string res_path, SoundType type)
        {
            float volume = GlobalSettings.GetInstance().SFXVolume;
            if (!GlobalSettings.GetInstance().SFXMute && volume > 0.01f)
            {
                uint id = GetNewSoundId();
                if (string.IsNullOrEmpty(res_path) == false)
                {
                    MainGame.HeartBehavior.StartCoroutine(LoadSFXAudio(res_path, type, id));
                }
                return id;
            }
            return 0;
        }

        /// <summary>
        /// 加载音效资源
        /// </summary>
        /// autoDestroy 加载完自动设置保底过期时间 5分钟
        /// <returns></returns>
        public IEnumerator LoadSFXAudio( string res_path, SoundType type,uint id, UnityAction<AudioClip> callback = null,bool autoDestroy = true)
        {
            AssetResource ar = new AssetResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(res_path, typeof(Object), ar));
            if (ar.asset_ == null)
            {
                GameDebug.LogError(string.Format("the res {0} does not exist", res_path));
                yield break;
            }

            AudioClip audio_clip = ar.asset_ as AudioClip;
            if (audio_clip == null)
            {
                GameDebug.LogError(string.Format("the res {0} is not audio clip", res_path));
                ar.destroy();
                yield break;
            }
            if (mLoadedAudioAsset.ContainsKey(id))
            {
                ar.destroy();
                yield break;
            }
            mLoadedAudioAsset.Add(id, ar);

            if(autoDestroy)
            {
                DestroySFX(id, AUDIO_ASSET_MAX_LIFE_TIME);
            }

            if (callback != null)
            {
                callback(audio_clip);
                yield break;
            }

            PlayBattleSFX(audio_clip, type, id);
        }


      

        public uint PlayBattleSFX(AudioClip clip, SoundType type)
        {
            uint id = GetNewSoundId();
            PlayBattleSFX(clip, type, id);
            return id;
        }

        private void PlayBattleSFX(AudioClip clip, SoundType type, uint id)
        {
            float volume = GlobalSettings.GetInstance().SFXVolume;

            if (clip != null && !GlobalSettings.GetInstance().SFXMute && volume > 0.01f)
            {
                InitListener();

                if (m_Listener != null && m_Listener.enabled && UGUITools.GetActive(m_Listener.gameObject))
                {
                    BattleSFXAudioSource source = GetSFXAudioSource();
                    if (source != null)
                    {
                        bool playSuccess = source.PlaySound(clip, type, id);
                        if(!playSuccess)
                        {
                            PlayAudio(clip);
                            DestroySFX(id, clip.length);
                        }
                    }
                }
            }
        }

        private BattleSFXAudioSource GetSFXAudioSource()
        {
            BattleSFXAudioSource source = m_Listener.GetComponent<BattleSFXAudioSource>();
            if (source == null)
            {
                source = m_Listener.gameObject.AddComponent<BattleSFXAudioSource>();
                source.Init(audioMixerGroups);
            }
            return source;
        }

        private void InitListener()
        {
            if (m_Listener == null || !UGUITools.GetActive(m_Listener))
            {
                Camera cam = Camera.main;
                if (cam == null) cam = GameObject.FindObjectOfType(typeof(Camera)) as Camera;
                if (cam != null)
                {
                    m_Listener = cam.gameObject.GetComponent<AudioListener>();
                    if (m_Listener == null)
                        m_Listener = cam.gameObject.AddComponent<AudioListener>();
                }
            }
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="is_loop"></param>
        /// <returns></returns>
        public void PlayAudio(AudioClip clip, bool is_loop = false, UnityAction cbFunc = null)
        {
            float volume = GlobalSettings.GetInstance().SFXVolume;

            if (clip != null && volume > 0.01f)
            {
                InitListener();

                if (m_Listener != null && m_Listener.enabled && UGUITools.GetActive(m_Listener.gameObject))
                {
                    AudioSource source = m_Listener.GetComponent<AudioSource>();
                    if (source == null)
                        source = m_Listener.gameObject.AddComponent<AudioSource>();

                    if (is_loop)
                    {
                        source.loop = true;
                        source.clip = clip;
                        source.Play();

                        return;
                    }

                    source.pitch = 1.0f;
                    if (!GlobalSettings.GetInstance().SFXMute)
                    {
                        source.PlayOneShot(clip, volume);
                        
                        if (null != cbFunc)
                            xc.MainGame.GetGlobalMono().StartCoroutine(DelayedCallback(clip.length, cbFunc));
                    }
                }
            }
        }

        /// <summary>
        /// 停止当前播放的AudioClip
        /// </summary>
        public void StopAuidoClip()
        {
            InitListener();

            if (m_Listener != null && m_Listener.enabled && UGUITools.GetActive(m_Listener.gameObject))
            {
                AudioSource source = m_Listener.GetComponent<AudioSource>();
                if (source == null)
                    source = m_Listener.gameObject.AddComponent<AudioSource>();

                source.clip = null;
                source.Stop();
            }
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="cbFunc"> 音效播放完后的回调函数 </param>
        /// <returns></returns>
        public void PlayAudio(AudioClip clip, UnityAction cbFunc)
        {
            PlayAudio(clip, false, cbFunc);
        }

        private IEnumerator DelayedCallback(float time, UnityAction cbFunc)
        {
            yield return new WaitForSeconds(time);
            cbFunc();
        }

        /// <summary>
        /// 停止正在播放的循环音效
        /// </summary>
        /// <param name="clip_name"></param>
        /// <returns></returns>
        public void StopLoopAudio(string clip_name)
        {
            if (m_Listener != null && m_Listener.enabled && UGUITools.GetActive(m_Listener.gameObject))
            {
                AudioSource source = m_Listener.GetComponent<AudioSource>();
                if (null == source)
                    return;

                AudioClip curClip = source.clip;
                if (null == curClip)
                    return;

                if (0 == curClip.name.CompareTo(clip_name))
                {
                    source.Stop();
                    source.loop = false;
                    source.clip = null;
                }
            }
        }


        private BackGroundAudio mBackGroundAudio = null;
        private BackGroundAudio GetBackGroundAudio()
        {
            if (mBackGroundAudio == null)
            {
                GameObject core_object = xc.MainGame.CoreObject;
                if (core_object == null)
                    return null;
                mBackGroundAudio = core_object.GetComponent<BackGroundAudio>();
            }
            return mBackGroundAudio;
        }
        public void SetClip(AudioClip audio, BackGroundType type)
        {
            BackGroundAudio backGroundAudio = GetBackGroundAudio();
            if (backGroundAudio != null)
                backGroundAudio.SetClip(audio, type);
        }



        /// <summary>
        /// 播放/暂停音乐
        /// </summary>
        /// <param name="play"></param>
        public void PauseMusic(bool pause)
        {
            //GameObject core_object = xc.MainGame.CoreObject;
            //if (core_object == null)
            //    return;

            //var core_audio = core_object.GetComponent<AudioSource>();
            //if(core_audio != null)
            //{
            //    if (!pause)
            //        core_audio.Play();
            //    else
            //        core_audio.Pause();
            //}

            BackGroundAudio audio = GetBackGroundAudio();
            if (audio != null)
                audio.PauseMusic(pause);

        }

        public void KillMusic()
        {
            //GameObject core_object = xc.MainGame.CoreObject;
            //if (core_object == null)
            //    return;

            //var core_audio = core_object.GetComponent<AudioSource>();
            //if (core_audio != null)
            //{
            //    core_audio.clip = null;
            //}

            BackGroundAudio audio = GetBackGroundAudio();
            if (audio != null)
                audio.KillMusic();

        }

        /// <summary>
        /// 设置音乐的音量
        /// </summary>
        /// <param name="volume"></param>
        public void SetMusicVolume(float volume)
        {
            //GameObject core_object = xc.MainGame.CoreObject;
            //if (core_object == null)
            //    return;

            //var core_audio = core_object.GetComponent<AudioSource>();
            //if (core_audio != null)
            //{
            //    core_audio.volume = volume;
            //}

            BackGroundAudio audio = GetBackGroundAudio();
            if (audio != null)
                audio.SetMusicVolume(volume);

        }

        private const string MusicPath = "Assets/Res/Sound/music/TranMusic/";
        public void TransferMusic(string resName)
        {
            //GameDebug.LogError("-----TransferMusic");
            uint id = GetNewSoundId();
            if (string.IsNullOrEmpty(resName) == false)
            {

                MainGame.HeartBehavior.StartCoroutine(LoadSFXAudio(MusicPath + resName + ".ogg", SoundType.Other, id, LoadMusicFinish,false));
            }
        }
        private void LoadMusicFinish(AudioClip audioClip)
        {
            if (audioClip != null)
            {
                BackGroundAudio audio = GetBackGroundAudio();
                if (audio != null)
                    audio.TransferInMusic(audioClip);
            }
        }
        public void TransferOut()
        {
            //GameDebug.LogError("-----TransferOut");
            BackGroundAudio audio = GetBackGroundAudio();
            if (audio != null)
                audio.TransferOut();
        }



        /// <summary>
        /// 播放/暂停音效
        /// </summary>
        /// <param name="play"></param>
        public void PauseSFX(bool pause)
        {
            if (m_Listener != null && m_Listener.enabled && UGUITools.GetActive(m_Listener.gameObject))
            {
                AudioSource source = m_Listener.GetComponent<AudioSource>();
                if (source == null) source = m_Listener.gameObject.AddComponent<AudioSource>();

                if (!pause)
                    source.Play();
                else
                    source.Pause();

                BattleSFXAudioSource battleSFXAudioSource = GetSFXAudioSource();
                if (source != null)
                {
                    if (!pause)
                        battleSFXAudioSource.Play();
                    else
                        battleSFXAudioSource.Pause();
                }
            }
        }

        /// <summary>
        /// 设置音效的音量
        /// </summary>
        /// <param name="volume"></param>
        public void SetSFXVolume(float volume)
        {
            if (m_Listener != null && m_Listener.enabled && UGUITools.GetActive(m_Listener.gameObject))
            {
                AudioSource source = m_Listener.GetComponent<AudioSource>();
                if (source == null) source = m_Listener.gameObject.AddComponent<AudioSource>();
                source.volume = volume;

                BattleSFXAudioSource battleSFXAudioSource = GetSFXAudioSource();
                if (source != null)
                    battleSFXAudioSource.Volume = volume;
            }
        }

        /// <summary>
        /// 选中某一UI时候的处理
        /// </summary>
        /// <param name="select_ui"></param>
        /// <param name="sprite_name"></param>
        public void OnSelectUI(Selectable select_ui, string sprite_name, string check_sprite_name)
        {
            var sound_path = "";
            if (string.IsNullOrEmpty(check_sprite_name) == false)
            {
                sound_path = DBUISoundCommon.Instance.GetSoundPath(check_sprite_name);
                if (string.IsNullOrEmpty(sound_path))
                {
                    sound_path = DBUISoundCommon.Instance.GetSoundPath(sprite_name);
                }
            }
            else
            {
                sound_path = DBUISoundCommon.Instance.GetSoundPath(sprite_name);
            }
                

            if (string.IsNullOrEmpty(sound_path) == false)
            {
                var play_sound = select_ui.gameObject.GetComponent<UIPlaySound>();
                if (play_sound == null)
                    play_sound = select_ui.gameObject.AddComponent<UIPlaySound>();

                string soundName = Path.GetFileNameWithoutExtension(sound_path);
                if((play_sound.audioClip == null) || !soundName.Equals(play_sound.audioClip.name))
                {
                    MainGame.HeartBehavior.StartCoroutine(LoadAudioClip("Assets/"+sound_path, play_sound));
                }
            }
        }

        IEnumerator LoadAudioClip(string sound_path, UIPlaySound play_sound)
        {
            AssetResource asset_res = new AssetResource();
            yield return ResourceLoader.Instance.load_asset(sound_path, typeof(AudioClip), asset_res);
            var audio_clip = asset_res.asset_ as AudioClip;
            if(play_sound != null && audio_clip != null)
            {
                play_sound.audioClip = audio_clip;
                play_sound.ForceClick();// 需要主动调用一次
            }
        }

        uint m_next_sound_id = 1;
        public class DynamicAudioItem
        {
            public AudioSource audioSource;
            public AudioClip clip;
            public string res_path;
            public bool is_loop;
            public uint unique_id;
            public float volume = 1;
            public bool is_destroy = false;
        }

        public class DynamicAudioParam
        {
            public string res_path;
            public bool is_loop;
            public float volume = 1;
        }

        Dictionary<uint, DynamicAudioItem> m_dynamicItemArray = new Dictionary<uint, DynamicAudioItem>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sound_path"></param>
        /// <param name="is_loop"></param>
        /// <param name="volume"></param>
        /// <returns>返回唯一ID；若返回0，则播放不成功；返回其他表示成功</returns>
        public uint PlayAudio_dynamic_out(string sound_path, bool is_loop, float volume)
        {
            xc.AudioManager.DynamicAudioParam param = new xc.AudioManager.DynamicAudioParam();
            param.res_path = sound_path;
            param.is_loop = false;
            param.volume = volume;
            return xc.AudioManager.Instance.PlayAudio_dynamic_out(param);
        }
        public uint PlayAudio_dynamic_out(DynamicAudioParam param)
        {
            if (param == null)
                return 0;
            if (string.IsNullOrEmpty(param.res_path))
            {
                return 0;
            }
            uint soundId = GetNewSoundId();

            DynamicAudioItem item = new DynamicAudioItem();
            m_dynamicItemArray[soundId] = item;
            item.audioSource = null;
            item.clip = null;
            item.res_path = param.res_path;
            item.is_loop = param.is_loop;
            item.unique_id = soundId;
            item.is_destroy = false;
            item.volume = param.volume;
            MainGame.HeartBehavior.StartCoroutine(LoadAudio_dynamic(item));
            
            return soundId;
        }

        public void StopAudio_dynamic(uint unique_id)
        {
            DynamicAudioItem item;
            if (m_dynamicItemArray.TryGetValue(unique_id, out item) == false)
                return;
            if (item.is_destroy)
                return;
            if(item.audioSource != null)
            {
                item.audioSource.Stop();
                item.audioSource.clip = null;
                ObjCachePoolMgr.Instance.RecyclePrefab(item.audioSource.gameObject, ObjCachePoolType.SMALL_PREFAB, UISoundTemplate);
                item.audioSource = null;
            }
            item.clip = null;
            item.is_destroy = true;
            m_dynamicItemArray.Remove(unique_id);
        }
        private const string UISoundTemplate = "Assets/Res/UI/Widget/Dynamic/SoundTemplate.prefab";
        /// <summary>
        /// 加载音效资源
        /// </summary>
        /// <returns></returns>
        IEnumerator LoadAudio_dynamic(DynamicAudioItem item)
        {
            if (item == null)
                yield break;
            if (item.is_destroy)
                yield break;

            GameObject go = ObjCachePoolMgr.Instance.LoadFromCache(ObjCachePoolType.SMALL_PREFAB, UISoundTemplate) as GameObject;
            if (go == null)
            {
                PrefabResource ar_prefab = new PrefabResource();
                
                yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_prefab(UISoundTemplate, ar_prefab));

                if (ar_prefab.obj_ == null)
                {
                    StopAudio_dynamic(item.unique_id);
                    yield break;
                }
                
                GameObject obj = ar_prefab.obj_;
                if (item.is_destroy)
                {
                    GameObject.DestroyImmediate(obj);
                    yield break;
                }

                PoolGameObject pg = obj.AddComponent<PoolGameObject>();
                if(pg != null)
                {
                    pg.poolType = ObjCachePoolType.SMALL_PREFAB;
                    pg.key = UISoundTemplate;
                }
                go = obj;
            }

            item.audioSource = go.GetComponent<AudioSource>();
            if (item.audioSource == null)
            {
                item.audioSource = go.AddComponent<AudioSource>();
            }
            go.SetActive(true);
            Camera cam = Camera.main;
            if (cam == null) cam = GameObject.FindObjectOfType(typeof(Camera)) as Camera;
            if (cam != null)
            {
                item.audioSource.transform.SetParent(cam.transform);
                item.audioSource.transform.localScale = Vector3.one;
                item.audioSource.transform.localPosition = Vector3.zero;
                item.audioSource.transform.localEulerAngles = Vector3.zero;
            }

            AssetResource ar = new AssetResource();
            yield return ResourceLoader.Instance.StartCoroutine(ResourceLoader.Instance.load_asset(item.res_path, typeof(Object), ar));
            if (ar.asset_ == null)
            {
                GameDebug.LogError(string.Format("the res {0} does not exist", item.res_path));
                StopAudio_dynamic(item.unique_id);
                yield break;
            }
            if(item.is_destroy)
            {
                ar.destroy();
                yield break;
            }
            AudioClip audio_clip = ar.asset_ as AudioClip;
            if (audio_clip == null)
            {
                GameDebug.LogError(string.Format("the res {0} is not audio clip", item.res_path));
                ar.destroy();
                yield break;
            }

            item.clip = audio_clip;
            item.audioSource.clip = item.clip;
            item.audioSource.loop = item.is_loop;
            float volume = GlobalSettings.GetInstance().SFXVolume;
            item.audioSource.volume = volume * item.volume;
            item.audioSource.mute = GlobalSettings.GetInstance().SFXMute;
            item.audioSource.Play();
            UnityAction cbFunc = () =>
            {
                if (item != null)
                    StopAudio_dynamic(item.unique_id);
            };
            if (item.is_loop == false)
                xc.MainGame.GetGlobalMono().StartCoroutine(DelayedCallback(item.clip.length, cbFunc));
        }

        private uint GetNewSoundId()
        {
            m_next_sound_id = m_next_sound_id + 1;
            if (m_next_sound_id > 100000)
                m_next_sound_id = 1;
            return m_next_sound_id;
        }

        public bool CheckSFXValid(uint id)
        {
            if (!mLoadedAudioAsset.ContainsKey(id))
                return false;

            if (!mAudioAssetDestroyTime.ContainsKey(id))
                return true;

            var destroyTime = mAudioAssetDestroyTime[id];
            //是否过期失效
            return destroyTime > Time.time; 
        }

        public static SoundType GetSFXSoundType(Actor actor)
        {
            if (actor.UID == Game.Instance.LocalPlayerID)
            {
                return SoundType.LocalPlayer;
            }
            else if (actor.IsBoss())
            {
                return SoundType.Boss;
            }else
            {
                return SoundType.Monster;
            }
        }


    }
}
