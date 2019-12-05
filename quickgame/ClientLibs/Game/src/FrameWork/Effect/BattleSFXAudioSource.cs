using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;

namespace xc
{
    class BattleSFXAudioSource : MonoBehaviour
    {
        private Dictionary<SoundType, IAudioTrack> audioTrack;
        private Dictionary<string, AudioMixerGroup> audioMixerGroups;
        private GameObject go;

        private float mVolume = 1;

        public float Volume
        {
            set
            {
                mVolume = value;
                foreach (var track in audioTrack.Values)
                {
                    track.SetVolume(mVolume);
                }
            }
        }

        void Awake()
        {
            audioTrack = new Dictionary<SoundType, IAudioTrack>();
            go = new GameObject("BattleSFXAudioSource");
            go.transform.SetParent(gameObject.transform);
            go.transform.localPosition = Vector3.zero;
        }

        public void Init(Dictionary<string, AudioMixerGroup> audioMixerGroups)
        {
            this.audioMixerGroups = audioMixerGroups;
        }

        public void Pause()
        {
            foreach (var track in audioTrack.Values)
            {
                track.Pause();
            }
        }

        public void Play()
        {
            foreach (var track in audioTrack.Values)
            {
                track.Play();
            }
        }

        public bool PlaySound(AudioClip clip, SoundType type, uint id)
        {
            IAudioTrack audio = GetAudioTrack(type);
            if (audio != null)
            {
                audio.PlaySound(id, clip);
                return true;
            }
            return false;
        }

        public void StopSound(uint id)
        {
            foreach (var track in audioTrack.Values)
            {
                track.Stop(id);
            }
            AudioManager.Instance.DestroySFX(id);
        }


        public IAudioTrack GetAudioTrack(SoundType type)
        {
            IAudioTrack audio;
            if (!audioTrack.TryGetValue(type, out audio))
            {
                AudioMixerGroup audioMixerGroup;
                audioMixerGroups.TryGetValue(type.ToString(), out audioMixerGroup);
                switch (type)
                {
                    case SoundType.LocalPlayer:
                        audio = new NormalTrack(go, audioMixerGroup);
                        break;
                    case SoundType.Boss:
                    case SoundType.Monster:
                        audio = new FrequencyAndQuantityLimit(go, audioMixerGroup, GameConstHelper.GetInt("MONSTER_GROUP_SOUND_NUM"), GameConstHelper.GetFloat("MONSTER_GROUP_SOUND_INTERVAL"));
                        break;
                    case SoundType.Voice:
                        audio = new OneClipPerTime(go, audioMixerGroup);
                        break;
                    case SoundType.NPC:
                        audioMixerGroups.TryGetValue(SoundType.Voice.ToString(), out audioMixerGroup);
                        audio = new OneClipPerTimeInterruption(go, audioMixerGroup);
                        break;
                    default:
                        audio = new NormalTrack(go, audioMixerGroup);
                        break;
                }

                audioTrack.Add(type, audio);

            }
            return audio;
        }

        void OnDestroy()
        {
            foreach (var track in audioTrack.Values)
            {
                track.OnDestroy();
            }
            audioTrack = null;
            audioMixerGroups = null;
            go = null;
        }





        public interface IAudioTrack
        {
            void Play();
            void Pause();
            void Stop(uint id);
            void PlaySound(uint id, AudioClip clip);
            void SetVolume(float volume);
            void OnDestroy();
        }


        #region NormalTrack
        /// <summary>
        /// 无限制 不打断
        /// </summary>
        public class NormalTrack : IAudioTrack
        {
            private AudioSource audioSource;
            public NormalTrack(GameObject go, AudioMixerGroup mixerGroup)
            {
                audioSource = go.AddComponent<AudioSource>();
                audioSource.outputAudioMixerGroup = mixerGroup;
                audioSource.loop = false;
            }

            public void OnDestroy()
            {
                audioSource = null;
            }

            public void Pause()
            {
                audioSource.mute = true;
            }

            public void Play()
            {
                audioSource.mute = false;
            }

            public void PlaySound(uint id, AudioClip clip)
            {
                audioSource.PlayOneShot(clip);
                AudioManager.Instance.DestroySFX(id, clip.length);
            }

            public void SetVolume(float volume)
            {
                audioSource.volume = volume;
            }

            public void Stop(uint id)
            {
            }
        }
        #endregion

        #region FrequencyAndQuantityLimit
        /// <summary>
        /// 有频率和数量限制
        /// </summary>
        public class FrequencyAndQuantityLimit : IAudioTrack
        {
            private float Interval = 0;
            private float cd = 0;
            private int maxNum;
            private GameObject go;
            private AudioMixerGroup mixerGroup;
            private List<AudioSourceItem> itemList;

            public FrequencyAndQuantityLimit(GameObject go, AudioMixerGroup mixerGroup, int maxNum, float interval)
            {
                Interval = interval;
                this.go = go;
                this.mixerGroup = mixerGroup;
                this.maxNum = maxNum;
                itemList = new List<AudioSourceItem>(maxNum);
            }

            public void OnDestroy()
            {
            }

            public void PlaySound(uint id, AudioClip clip)
            {
                if (Time.time < cd)
                {
                    AudioManager.Instance.DestroySFX(id);
                    return;
                }
                AudioSourceItem item = GetAudioSourceItem();
                if (item == null)
                {
                    AudioManager.Instance.DestroySFX(id);
                    return;
                }

                cd = Time.time + Interval;
                item.Play(clip, id);
                AudioManager.Instance.DestroySFX(id, clip.length);
            }

            public void SetVolume(float volume)
            {
                for (var i = 0; i < itemList.Count; i++)
                {
                    itemList[i].SetVolume(volume);
                }
            }

            public void Stop(uint id)
            {
                for (var i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].soundId == id)
                    {
                        itemList[i].Stop();
                        break;
                    }
                }
            }

            public void Play()
            {
                for (var i = 0; i < itemList.Count; i++)
                {
                    itemList[i].Play();
                }
            }

            public void Pause()
            {
                for (var i = 0; i < itemList.Count; i++)
                {
                    itemList[i].Pause();
                }
            }


            AudioSourceItem GetAudioSourceItem()
            {
                AudioSourceItem item = null;
                for (var i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i].cd < Time.time)
                    {
                        item = itemList[i];
                        break;
                    }
                }
                if (item == null && itemList.Count < maxNum)
                {
                    item = new AudioSourceItem(go, mixerGroup);
                    itemList.Add(item);
                }
                return item;
            }

            #region AudioSourceItem
            class AudioSourceItem
            {
                public float cd;
                private GameObject go;
                public uint soundId;
                private AudioSource audioSource;
                private AudioMixerGroup mixerGroup;

                public AudioSourceItem(GameObject go, AudioMixerGroup mixerGroup)
                {
                    this.go = go;
                    this.mixerGroup = mixerGroup;
                }

                public void Stop()
                {
                    cd = 0;
                    audioSource.clip = null;
                    audioSource.Pause();
                }

                public void Play(AudioClip clip, uint id)
                {
                    InitAudioSource();
                    soundId = id;
                    cd = Time.time + clip.length;
                    audioSource.clip = clip;
                    audioSource.Play();
                }

                public void SetVolume(float volume)
                {
                    audioSource.volume = volume;
                }

                public void Play()
                {
                    InitAudioSource();
                    audioSource.mute = false;
                }

                public void Pause()
                {
                    InitAudioSource();
                    audioSource.mute = true;
                }

                private void InitAudioSource()
                {
                    if (go == null || !UGUITools.GetActive(go))
                    {
                        return;
                    }
                    if (audioSource == null || !UGUITools.GetActive(audioSource))
                    {
                        audioSource = go.AddComponent<AudioSource>();
                        audioSource.outputAudioMixerGroup = mixerGroup;
                    }
                }
            }
            #endregion

        }
        #endregion

        #region OneClipPerTime
        /// <summary>
        /// 同一时间只有一个在播，后来的存入队列按顺序播放
        /// </summary>
        public class OneClipPerTime : IAudioTrack
        {
            private AudioSource audioSource;
            private Utils.Timer timer;
            private List<ClipInfo> waitList = new List<ClipInfo>();
            private ClipInfo playingInfo = null;

            public OneClipPerTime(GameObject go, AudioMixerGroup mixerGroup)
            {
                audioSource = go.AddComponent<AudioSource>();
                audioSource.outputAudioMixerGroup = mixerGroup;
                audioSource.loop = false;

                timer = new Utils.Timer(1000, true, 10, TimerCallBack);
                timer.Pause = true;
            }

            public void OnDestroy()
            {
                audioSource.clip = null;
                audioSource = null;
                timer.Destroy();
                if (waitList.Count > 0)
                {
                    foreach (var info in waitList)
                    {
                        AudioManager.Instance.DestroySFX(info.id);
                    }
                }
                waitList.Clear();

                if (playingInfo != null)
                {
                    AudioManager.Instance.DestroySFX(playingInfo.id);
                    playingInfo = null;
                }
            }

            public void Pause()
            {
                audioSource.mute = true;
            }

            public void Play()
            {
                audioSource.mute = false;
            }

            public void PlaySound(uint id, AudioClip clip)
            {
                waitList.Add(new ClipInfo(id, clip));
                if (playingInfo == null)
                {
                    PlayNext();
                }
            }

            public void SetVolume(float volume)
            {
                audioSource.volume = volume;
            }

            public void Stop(uint id)
            {
                if (playingInfo != null && playingInfo.id == id)
                {
                    timer.Pause = true;
                    audioSource.clip = null;
                    playingInfo = null;
                    PlayNext();
                    return;
                }

                for (var i = 0; i < waitList.Count; i++)
                {
                    if (waitList[i].id == id)
                    {
                        waitList.RemoveAt(i);
                        return;
                    }
                }
            }

            void TimerCallBack(float remainTime)
            {
                if (remainTime <= 0)
                {
                    timer.Pause = true;
                    audioSource.clip = null;
                    playingInfo = null;
                    PlayNext();
                }
            }

            void PlayNext()
            {
                if (!timer.Pause) //正在播
                {
                    return;
                }
                if (waitList.Count == 0)
                {
                    return;
                }
                playingInfo = waitList[0];
                waitList.RemoveAt(0);
                audioSource.clip = playingInfo.clip;
                audioSource.Play();
                AudioManager.Instance.DestroySFX(playingInfo.id, playingInfo.clip.length);
                float ms = playingInfo.clip.length * 1000;
                timer.Reset(ms);
            }

            class ClipInfo
            {
                public uint id;
                public AudioClip clip;
                public ClipInfo(uint id, AudioClip clip)
                {
                    this.id = id;
                    this.clip = clip;
                }
            }

        }
        #endregion

        #region OneClipPerTimeInterruption
        public class OneClipPerTimeInterruption : IAudioTrack
        {
            private AudioSource audioSource;
            private uint playingId = 0;
            private float endTime = 0;

            public OneClipPerTimeInterruption(GameObject go, AudioMixerGroup mixerGroup)
            {
                audioSource = go.AddComponent<AudioSource>();
                audioSource.outputAudioMixerGroup = mixerGroup;
                audioSource.loop = false;
            }

            public void OnDestroy()
            {
                audioSource = null;
            }

            public void Pause()
            {
                audioSource.mute = true;
            }

            public void Play()
            {
                audioSource.mute = false;
            }

            public void PlaySound(uint id, AudioClip clip)
            {
                if(clip == null)
                {
                    return;
                }
                audioSource.clip = clip;
                audioSource.Play();
                endTime = Time.time + clip.length;
                AudioManager.Instance.DestroySFX(id, clip.length);
            }

            public void SetVolume(float volume)
            {
                audioSource.volume = volume;
            }

            public void Stop(uint id)
            {
                if(CheckPlaying(id))
                {
                    audioSource.clip = null;
                }
            }

            private bool CheckPlaying(uint id)
            {
                if (playingId != id || Time.time > endTime)
                {
                    return false;
                }
                return true;
            }
        }

        #endregion



    }
}
