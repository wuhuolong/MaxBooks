//-----------------------------------
// File: BackgroundAudio.cs
// Desc: 
// Author: luozhuocheng
// Date: 2019/1/17 11:02:01
//-----------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Audio;

namespace xc
{
    [wxb.Hotfix]
    class BackGroundAudio : MonoBehaviour
    {
        private MainAudioSource mMainAudio;
        private FightAudioSource mFightAudio;
        private Dictionary<BackGroundType, IBackGroundAudio> mAudioDic = new Dictionary<BackGroundType, IBackGroundAudio>();

        public void Init()
        {
            mMainAudio = new MainAudioSource();
            mMainAudio.Init();
            mFightAudio = new FightAudioSource();
            mFightAudio.Init();
            mAudioDic.Add(BackGroundType.Main, mMainAudio);
            mAudioDic.Add(BackGroundType.Fight, mFightAudio);
        }

        private IBackGroundAudio GetBackGroundAudio(BackGroundType type)
        {
            IBackGroundAudio audio = null;
            if (mAudioDic.TryGetValue(type, out audio))
            {
                return audio;
            }
            return null;
        }
        public void SetClip(AudioClip clip, BackGroundType type)
        {
            IBackGroundAudio audio = GetBackGroundAudio(type);
            if (audio != null)
            {
                audio.SetClip(clip);
            }
        }


        
        private TranState mCurState = TranState.TranOut;
        private enum TranState
        {
            None,TranIn,TranOut
        }


        public void TransferInMusic(AudioClip audioClip)
        {
            if (mCurState == TranState.TranIn)
                return;

            TranVO tran = new TranVO();
            tran.OriValue = xc.GlobalSettings.GetInstance().MusicVolume;
            tran.DestValue = 0f;
            tran.Time = 2f;
            mMainAudio.SetTranVO(tran);

            tran = new TranVO();
            tran.OriValue = 0;
            tran.DestValue = xc.GlobalSettings.GetInstance().MusicVolume;
            tran.Time = 2f;
            tran.Clip = audioClip;
            mFightAudio.SetTranVO(tran);

            mCurState = TranState.TranIn;
        }

        public void TransferOut()
        {

            if (mCurState == TranState.TranOut)
                return;

            TranVO tran = new TranVO();
            tran.OriValue = 0;
            tran.DestValue = xc.GlobalSettings.GetInstance().MusicVolume;
            tran.Time = 2f;
            mMainAudio.SetTranVO(tran);

            tran = new TranVO();
            tran.OriValue = xc.GlobalSettings.GetInstance().MusicVolume;
            tran.DestValue = 0f;
            tran.Time = 2f;
            mFightAudio.SetTranVO(tran);

            mCurState = TranState.TranOut;
        }


        public void Update()
        {
            //if (mCurState != TranState.None)
            {
                if (mMainAudio != null)
                    mMainAudio.UpdateVolume();
                if (mFightAudio != null)
                    mFightAudio.UpdateVolume();
                //if (mMainAudio != null && mFightAudio != null)
                //{
                //    if (mMainAudio.IsReach() && mFightAudio.IsReach())
                //        mCurState = TranState.None;
                //}
            }
        }




        public void PauseMusic(bool pause)
        {
            //for (int i = 0; i < mAudioList.Count; i++)
            //{
            //    mAudioList[i].PauseMusic(pause);
            //}
            if (mMainAudio != null)
                mMainAudio.PauseMusic(pause);
            if (mFightAudio != null)
                mFightAudio.PauseMusic(pause);
        }
        public void KillMusic()
        {
            if (mMainAudio != null)
                mMainAudio.KillMusic();
            if (mFightAudio != null)
                mFightAudio.KillMusic();
        }

        public void SetMusicVolume(float volume)
        {
            if (mMainAudio != null)
                mMainAudio.SetMusicVolume(volume);
            if (mFightAudio != null)
                mFightAudio.SetMusicVolume(volume);
        }


        public class MainAudioSource : IBackGroundAudio
        {
            private AudioSource mAudioSource;
            private AudioSource mAudio
            {
                get
                {
                    if (mAudioSource == null)
                    {
                        GameObject core_object = xc.MainGame.CoreObject;
                        if (core_object == null)
                            return null;
                        mAudioSource = core_object.GetComponent<AudioSource>();
                    }
                    return mAudioSource;
                }
            }

            public void Init()
            {

            }

            public void KillMusic()
            {
                if (mAudio != null)
                    mAudio.clip = null;
            }

            public void PauseMusic(bool pause)
            {
                if (mAudio != null)
                {
                    mAudio.enabled = true;
                    if (!pause)
                        mAudio.Play();
                    else
                        mAudio.Pause();
                }
            }

            public void SetClip(AudioClip clip)
            {
                if (mAudio != null)
                {
                    if (mAudio.clip != clip)
                    {
                        mAudio.clip = clip;
                    }
                }
            }

            public void SetMusicVolume(float volume)
            {
                if (mAudio != null)
                {
                    mAudio.volume = volume;
                }
            }

            public float GetMusicVolume()
            {
                if (mAudio != null)
                {
                    return mAudio.volume;
                }
                return 0;
            }


            private TranVO mTranVO;
            public void SetTranVO(TranVO tran)
            {
                mTranVO = tran;
                if (mAudio != null)
                    mAudio.volume = tran.OriValue;
            }

            public void UpdateVolume()
            {
                if (mTranVO != null && mAudio != null)
                {
                    if (mAudio.volume == mTranVO.DestValue)
                    {
                        mTranVO = null;
                        return;
                    }

                    if (mTranVO.DestValue > mTranVO.OriValue)
                    {
                        float nextValue = mAudio.volume + mTranVO.Step;
                        mAudio.volume = nextValue > mTranVO.DestValue ? mTranVO.DestValue : nextValue;
                    }
                    else
                    {
                        float nextValue = mAudio.volume - mTranVO.Step;
                        mAudio.volume = nextValue < mTranVO.DestValue ? mTranVO.DestValue : nextValue;
                    }
                    mAudio.mute = mAudio.volume == 0;
                }
            }

            public bool IsReach()
            {
                if (mTranVO != null && mAudio != null)
                {
                    if (mAudio.volume == mTranVO.DestValue)
                        return true;
                }
                return false;
            }
        }
        public class FightAudioSource : IBackGroundAudio
        {
            private AudioSource mAudio;
            private GameObject mGameObj;
            public void Init()
            {
                mGameObj = new GameObject("FightSource");
                GameObject.DontDestroyOnLoad(mGameObj);
                mGameObj.transform.SetParent(xc.MainGame.CoreObject.transform);

                mAudio = mGameObj.AddComponent<AudioSource>();
                mAudio.playOnAwake = true;
                mAudio.loop = true;
                mAudio.outputAudioMixerGroup = AudioManager.Instance.GetAudioMixerGroup("Music");
                mAudio.volume = 0;
                mAudio.mute = true;
            }

            public void KillMusic()
            {
                if (mAudio != null)
                    mAudio.clip = null;
            }

            public void PauseMusic(bool pause)
            {
                if (mAudio != null)
                {
                    mAudio.enabled = true;
                    if (!pause)
                        mAudio.Play();
                    else
                        mAudio.Pause();
                }
            }

            public void SetClip(AudioClip clip)
            {
                if (mAudio != null)
                    mAudio.clip = clip;
            }

            public void SetMusicVolume(float volume)
            {
                if (mAudio != null)
                {
                    mAudio.volume = volume;
                }
            }

            public float GetMusicVolume()
            {
                if (mAudio != null)
                {
                    return mAudio.volume;
                }
                return 0;
            }

            private TranVO mTranVO;
            public void SetTranVO(TranVO tran)
            {
                mTranVO = tran;
                if (mAudio != null )
                {
                    if (mTranVO != null)
                    {
                        mAudio.volume = mTranVO.OriValue;
                        if (mTranVO.Clip != null)
                            mAudio.clip = mTranVO.Clip;
                    }
                    if (mAudio.isPlaying == false)
                        PauseMusic(GlobalSettings.GetInstance().MusicMute);
                }
            }
            public void UpdateVolume()
            {
                if (mTranVO != null && mAudio != null)
                {
                    if (mAudio.volume == mTranVO.DestValue)
                    {
                        mTranVO = null;
                        return;
                    }

                    if (mTranVO.DestValue > mTranVO.OriValue)
                    {
                        float nextValue = mAudio.volume + mTranVO.Step;
                        mAudio.volume = nextValue > mTranVO.DestValue ? mTranVO.DestValue : nextValue;
                    }
                    else
                    {
                        float nextValue = mAudio.volume - mTranVO.Step;
                        mAudio.volume = nextValue < mTranVO.DestValue ? mTranVO.DestValue : nextValue;
                    }
                    mAudio.mute = mAudio.volume == 0;
                }
            }

            public bool IsReach()
            {
                if (mTranVO != null && mAudio != null)
                {
                    if (mAudio.volume == mTranVO.DestValue)
                        return true;
                }
                return false;
            }
        }


        public interface IBackGroundAudio
        {
            void Init();
            void PauseMusic(bool pause);
            void KillMusic();
            void SetMusicVolume(float volume);
            void SetClip(AudioClip clip);
            float GetMusicVolume();
            void SetTranVO(TranVO tran);
            void UpdateVolume();
        }

        public class TranVO
        {
            public AudioClip Clip = null;
            public float OriValue = 0f;
            public float DestValue = 0f;
            public float Time = 0f;
            private float step = 0f;
            public float Step
            {
                get
                {
                    if (step == 0)
                    {
                        step = Math.Abs(DestValue - OriValue) / Time * UnityEngine.Time.deltaTime;
                    }
                    return step;
                }
            }
        }

    }

}


