using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Utils;
using xc.protocol;
using Net;

namespace xc
{
	public class GlobalSettings : xc.Singleton<GlobalSettings>
	{
		public GlobalSettings ()
		{
			Init();	
		}
		
		void Init()
		{
            bool inited = UserPlayerPrefs.Instance.Init("player_config");

			MusicVolume = UserPlayerPrefs.Instance.GetFloat("MusicVolume", 1.0f);
			SFXVolume = UserPlayerPrefs.Instance.GetFloat("SFXVolume", 1.0f);
            LastAccount = UserPlayerPrefs.Instance.GetString("LastAccount", "");
            LastServer = UserPlayerPrefs.Instance.GetString("LastServer", "");
            LastActorIndex = UserPlayerPrefs.Instance.GetInt("LastActorIndex", 0);
			GraphicLevel = UserPlayerPrefs.Instance.GetInt("GraphicLevel", 1);
            MaxPlayerCount = UserPlayerPrefs.Instance.GetInt("MaxPlayerCount", GlobalConst.MinPlayerCount);
            MusicMute = UserPlayerPrefs.Instance.GetInt("MusicMute", 0) == 1;
            CameraShake = UserPlayerPrefs.Instance.GetInt("CameraShake", 1) == 1;
            SFXMute = UserPlayerPrefs.Instance.GetInt("SFXMute", 0) == 1;
            NormalMonsterVisible = UserPlayerPrefs.Instance.GetInt("NormalMonsterVisible", 1) == 1;
            SummonMonsterVisible = UserPlayerPrefs.Instance.GetInt("SummonMonsterVisible", 1) == 1;
            MarryNotified = UserPlayerPrefs.Instance.GetInt("MarryNotified", 0) == 1;

            // 如果原来的配置不存在，则使用默认配置进行保存
            if (inited == false)
                Save();
		}

        public void RegisterAllMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_PLAYER_PERSONALITY, HandleServerData);
        }
		
		public void Save()
		{
			UserPlayerPrefs.Instance.SetFloat("MusicVolume", MusicVolume);
			UserPlayerPrefs.Instance.SetFloat("SFXVolume", SFXVolume);
            UserPlayerPrefs.Instance.SetString("LastAccount", LastAccount);
            UserPlayerPrefs.Instance.SetString("LastServer", LastServer);
            UserPlayerPrefs.Instance.SetInt("LastActorIndex", LastActorIndex);
			UserPlayerPrefs.Instance.SetInt("GraphicLevel", GraphicLevel); 
            UserPlayerPrefs.Instance.SetInt("MaxPlayerCount", MaxPlayerCount);
            UserPlayerPrefs.Instance.SetInt("CameraShake", CameraShake ? 1 : 0);
            UserPlayerPrefs.Instance.SetInt("MusicMute", MusicMute ? 1 : 0);
            UserPlayerPrefs.Instance.SetInt("SFXMute", SFXMute ? 1 : 0);
            UserPlayerPrefs.Instance.SetInt("NormalMonsterVisible", NormalMonsterVisible ? 1 : 0);
            UserPlayerPrefs.Instance.SetInt("SummonMonsterVisible", SummonMonsterVisible ? 1 : 0);
            UserPlayerPrefs.Instance.SetInt("MarryNotified", MarryNotified ? 1 : 0);
            UserPlayerPrefs.Instance.Save();
        }

        /// <summary>
        /// 普通怪物的可见性
        /// </summary>
        public bool NormalMonsterVisible = true;

        /// <summary>
        /// 召唤怪物的可见性
        /// </summary>
        public bool SummonMonsterVisible = true;

        /// <summary>
        /// 音乐的音量 
        /// </summary>
        public float MusicVolume = 1.0f;

        /// <summary>
        /// 是否已经弹出结婚预告的窗口
        /// </summary>
        public bool MarryNotified = false;

        float m_SFXVolume = 1.0f;

        /// <summary>
        /// 音效音量
        /// </summary>
        public float SFXVolume
        {
            get
            {
                return m_SFXVolume;
            }

            set
            {
                m_SFXVolume = value;
                UGUITools.soundVolume = m_SFXVolume;
            }
        }

		/// <summary>
        /// 音乐静音
        /// </summary>
		public bool MusicMute = false;

        /// <summary>
        /// 屏幕震动
        /// </summary>
        public bool CameraShake = true;

        bool m_SFXMute = false;

        /// <summary>
        /// 音效静音
        /// </summary>
        public bool SFXMute
        {
            get
            {
                return m_SFXMute;
            }

            set
            {
                m_SFXMute = value;
                UGUITools.Mute = SFXMute;
            }
        }
        
		/// <summary>
        /// 画面设置
        /// </summary>
		public int GraphicLevel = 0;    // 0最高

        int mMaxPlayerCount = 0;

        /// <summary>
        /// 同屏显示的最大玩家
        /// </summary>
        public int MaxPlayerCount
        {
            get
            {
                return Mathf.Max(mMaxPlayerCount, GlobalConst.MinPlayerCount);
            }

            set
            {
                mMaxPlayerCount = Mathf.Max(value, GlobalConst.MinPlayerCount);
            }
        }

        /// <summary>
        /// 上次登录账号
        /// </summary>
        public string LastAccount = "";

        /// <summary>
        /// 上次登录的ip地址
        /// </summary>
        public string LastServer = "";

        /// <summary>
        /// 上次选择的角色索引
        /// </summary>
        public int LastActorIndex = 0;

        // -------------与服务端同步的设置信息 ---------------
        /// <summary>
        /// 服务端保存的配置信息
        /// </summary>
        List<PkgPlayerPersonality> mPlayerSettings;

        /// <summary>
        /// 获取所有的设置数据(服务端发送的)
        /// </summary>
        public List<PkgPlayerPersonality> PlayerSettings
        {
            get { return mPlayerSettings; }
        }

        /// <summary>
        /// 获取指定的设置数据(服务端发送的)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public uint PlayerSettingValue(uint type)
        {
            if (mPlayerSettings == null)
                return 0;

            foreach (PkgPlayerPersonality settingInfo in mPlayerSettings)
            {
                if (settingInfo.type == type)
                {
                    return settingInfo.value;
                }
            }

            return 0;
        }

        /// <summary>
        /// 设置指定的设置数据(同步到服务端)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void ChangePlayerSetting(uint type, uint value)
        {
            if (mPlayerSettings == null)
                mPlayerSettings = new List<PkgPlayerPersonality>();

            bool hasValue = false;
            PkgPlayerPersonality changedSettingInfo = null;
            foreach (PkgPlayerPersonality settingInfo in mPlayerSettings)
            {
                if (settingInfo.type == type)
                {
                    settingInfo.value = value;
                    hasValue = true;
                    changedSettingInfo = settingInfo;
                }
            }

            if (hasValue == false)
            {
                PkgPlayerPersonality settingInfo = new PkgPlayerPersonality();
                settingInfo.type = type;
                settingInfo.value = value;
                mPlayerSettings.Add(settingInfo);
                changedSettingInfo = settingInfo;
            }

            C2SPlayerPersonality msg = new C2SPlayerPersonality();
            msg.setting = changedSettingInfo;
            NetClient.GetBaseClient().SendData<C2SPlayerPersonality>(NetMsg.MSG_PLAYER_PERSONALITY, msg);
        }

        //--------------------------------------------------------
        //  网络消息
        //--------------------------------------------------------  
        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_PLAYER_PERSONALITY:
                    {
                        S2CPlayerPersonality msg = S2CPackBase.DeserializePack<S2CPlayerPersonality>(data);

                        mPlayerSettings = msg.settings;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SETTING_CHANGED, null);
                        break;
                    }
            }
        }
    }
}

