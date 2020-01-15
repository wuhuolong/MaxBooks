//------------------------------------------------------------------------------
// Desc: 控制角色名字的显示
// Date: 2016.6.29
// Author: raorui
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class TextNameBehavior : IActorBehavior
    {
        public class TextNameStruct
        {
            public string GuildNameText = "";
            public string MateNameText = "";
            public string HangUpText = "";
            public uint Honor = 0;
            public uint Title = 0;
        }
        TextNameStruct mTextNameStruct = new TextNameStruct();
        
        protected UI3DText mNameComponent = null;

        /// <summary>
        /// 角色是否被选中
        /// </summary>
        bool m_IsActived = false;

        public UI3DText.StyleInfo DataStyleInfo
        {
            get { return m_StyleInfo; }
        }

        public TextNameBehavior(Actor owner)
        {
            mOwner = owner;
        }

        public override void InitBehaviors()
        {
            mOwner.SubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.SubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
        }
        
        public override void Update()
        {
            //Debug.Log("ActorTextNameBehavior");
        }
        
        
        public override void LateUpdate()
        {

        }
        
        public override void UnInitBehaviors()
        {
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.AFTER_CREATE, OnAfterCreate);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.MODEL_CHANGE, OnModelChange);
            mOwner.UnsubscribeActorEvent(Actor.ActorEvent.RES_LOADED_CHANGE, OnModelChange);
            base.UnInitBehaviors();

            if (null != mNameComponent)
            {
                UnityEngine.GameObject.Destroy(mNameComponent);
                mNameComponent = null;
            }

            m_IsActived = false;
        }

        // leaf
        public override void EnableBehaviors(bool enable)
        {
            if (null != mNameComponent && mNameComponent.enabled != enable)
            {
                mNameComponent.enabled = enable;
            }
        }

        public UI3DText NameComponent
        {
            get
            {
                return mNameComponent;
            }
        }

        string mName = string.Empty;
        public string NameText
        {
            set
            {
                if(mNameComponent != null)
                    mNameComponent.Text = value;

                mName = value;
            }
            get
            {
                return mName;
            }
        }

        public Color NameColor
        {
            set
            {
                if(mNameComponent != null)
                {
                    mNameComponent.TextColor = value;
                }
            }
        }

        Vector3 m_HeadOffset;
        public Vector3 HeadOffset
        {
            set
            {
                m_HeadOffset = value;
                if (mNameComponent != null)
                {
                    mNameComponent.HeadOffset = value;
                }
                if(m_StyleInfo != null)
                {
                    m_StyleInfo.HeadOffset = value;
                }
            }
        }

        public void ClearNameText()
        {
            if(mNameComponent != null && mNameComponent.TextLabel != null)
                mNameComponent.TextLabel.text = string.Empty;
        }

        Transform mHeadTrans;
        void UpdateHeadTrans(Transform trans)
        {
            mHeadTrans = trans;
            if(null != mNameComponent)
            {
                mNameComponent.SetHeadTrans(trans);
            }
        }
        public bool ShowDialogBubble(string text, int time)
        {
            if (null != mNameComponent)
            {
                return mNameComponent.SetDialogBubbleText(text, time);
            }
            else
                return false;
        }

        public void Active(GameObject bind_object)
        {
            if (!m_IsActived)
            {
                m_IsActived = true;
                Start(bind_object);
            }
        }

        /// <summary>
        /// 创建角色头顶的名字组件
        /// </summary>
        void Start(GameObject bind_object)
        {
            if(mNameComponent == null)
                mNameComponent = bind_object.AddComponent<UI3DText>();

            if (m_StyleInfo != null)
                mNameComponent.ResetStyleInfo(m_StyleInfo);

            if (mHeadTrans != null)
                mNameComponent.SetHeadTrans(mHeadTrans);

            mNameComponent.HeadOffset = m_HeadOffset;
            mNameComponent.Text = mName;
            SetGuildName(mTextNameStruct.GuildNameText);
            SetHangUp(mTextNameStruct.HangUpText);
            SetHonor(mTextNameStruct.Honor);
            SetTitle(mTextNameStruct.Title);

            DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
            if (instanceInfo != null)
            {
                if (DBInstanceTypeControl.Instance.HideHpBar(instanceInfo.mWarType, instanceInfo.mWarSubType))
                {
                    HideHpBar();
                }
                if (DBInstanceTypeControl.Instance.HideCamp(instanceInfo.mWarType, instanceInfo.mWarSubType))
                {
                    HideCamp();
                }
            }
        }

        UI3DText.StyleInfo m_StyleInfo;
        public void SetStyle(UI3DText.StyleInfo style_info)
        {
            m_StyleInfo = style_info;
            if(mNameComponent != null)
            {
                if (style_info.IsShowBar || style_info.IsShowBg || style_info.IsShowBgPreHead)
                {
                    DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
                    if (instanceInfo != null)
                    {
                        if (DBInstanceTypeControl.Instance.HideHpBar(instanceInfo.mWarType, instanceInfo.mWarSubType))
                        {
                            style_info.IsShowBar = false;
                        }
                        if (DBInstanceTypeControl.Instance.HideCamp(instanceInfo.mWarType, instanceInfo.mWarSubType))
                        {
                            style_info.IsShowBg = false;
                            style_info.IsShowBgPreHead = false;
                        }
                    }
                }
                mNameComponent.ResetStyleInfo(style_info, mOwner);
            }
        }

        public void RefreshStyle()
        {
            if (mNameComponent != null)
            {
                if (m_StyleInfo.IsShowBar || m_StyleInfo.IsShowBg || m_StyleInfo.IsShowBgPreHead)
                {
                    DBInstance.InstanceInfo instanceInfo = InstanceManager.Instance.InstanceInfo;
                    if (instanceInfo != null)
                    {
                        if (DBInstanceTypeControl.Instance.HideHpBar(instanceInfo.mWarType, instanceInfo.mWarSubType))
                        {
                            m_StyleInfo.IsShowBar = false;
                        }
                        if (DBInstanceTypeControl.Instance.HideCamp(instanceInfo.mWarType, instanceInfo.mWarSubType))
                        {
                            m_StyleInfo.IsShowBg = false;
                            m_StyleInfo.IsShowBgPreHead = false;
                        }
                    }
                }
                mNameComponent.ResetStyleInfo(m_StyleInfo, mOwner);
            }
        }

        void OnAfterCreate(CEventBaseArgs param)
        {
            mHeadTrans = mOwner.GetModelParent().transform;
            HeadOffset = new Vector3(0f, mOwner.Height, 0f);
        }

        void OnModelChange(CEventBaseArgs param)
        {
            HeadOffset = new Vector3(0f, mOwner.Height, 0f);
        }

        public void SetGuildName(string guild_name)
        {
            mTextNameStruct.GuildNameText = guild_name;
            if (mNameComponent != null)
            {
                if(DBInstanceTypeControl.Instance.HideGuild(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType))
                {
                    mNameComponent.GuildNameTextLabel = "";
                }
                else
                {
                    mNameComponent.GuildNameTextLabel = mTextNameStruct.GuildNameText;
                }
            }
        }

        public void SetMateName(string mate_name)
        {
            mTextNameStruct.MateNameText = mate_name;
            if (mNameComponent != null)
            {
                if (DBInstanceTypeControl.Instance.HideMate(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType))
                {
                    mNameComponent.MateNameTextLabel = "";
                }
                else
                {
                    if (mate_name == "" || mate_name == string.Empty)
                    {
                        mNameComponent.MateNameTextLabel = "";
                    }
                    else
                    {
                        mNameComponent.MateNameTextLabel = string.Format(xc.DBConstText.GetText("MATE_TITLE_NAME"), mTextNameStruct.MateNameText);
                    }
                }
            }
        }

        public void SetHangUp(string hangup)
        {
            mTextNameStruct.HangUpText = hangup;
            if (mNameComponent != null)
                mNameComponent.HangUpTextLabel = mTextNameStruct.HangUpText;
        }

        public void ShowTeamIcon(string spriteName, bool isShow)
        {
            if (mNameComponent != null)
            {
                mNameComponent.ShowTeamIcon(spriteName, isShow);
            }
        }

        public void ShowPeakTeamIcon(bool isShow)
        {
            if (mNameComponent != null)
            {
                mNameComponent.ShowPeakTeamIcon(isShow);
            }
        }

        public void SetHonor(uint id)
        {
            mTextNameStruct.Honor = id;

            if (mNameComponent != null)
                mNameComponent.Honor = mTextNameStruct.Honor; 

        }

        public void SetTitle(uint id)
        {
            mTextNameStruct.Title = id;

            if (mNameComponent != null)
                mNameComponent.Title = mTextNameStruct.Title;
        }

        public void HideHpBar()
        {
            if (mNameComponent != null)
                mNameComponent.IsShowBar = false;
        }

        public void HideCamp()
        {
            if (mNameComponent != null)
                mNameComponent.ShowFrame(false, false);
        }

        public void SetLayoutVisiable(bool is_visiable)
        {
            if (mNameComponent != null)
                mNameComponent.SetLayoutVisiable(is_visiable);
        }
    }
}

