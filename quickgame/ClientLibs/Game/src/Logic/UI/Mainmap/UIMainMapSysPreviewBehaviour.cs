//---------------------------------------------
// File: UIMainMapSysPreviewBehaviour.cs
// Desc: 系统开放预览的组件
// Author: raorui 重构
// Date: 2017.11.16
//---------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using xc;
using xc.ui;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIMainMapSysPreviewBehaviour: IUIBehaviour
    {
        /// <summary>
        /// 主界面上的系统开放预览按钮
        /// </summary>
        Button m_SysPreviewBtn;

        /// <summary>
        /// 系统的图标
        /// </summary>
        Image m_SysIcon;

        /// <summary>
        /// 显示开放系统的名字
        /// </summary>
        Text m_NameText;

        /// <summary>
        /// 显示系统开放条件的文本
        /// </summary>
        Text m_ConditionText;

        /// <summary>
        /// 领取奖励提示
        /// </summary>
        GameObject m_RewardPanel;

        /// <summary>
        /// 是否在断线重连
        /// </summary>
        bool m_Reconnecting = false;

        DBSysConfig.SysConfig m_SysConfig;
        DBSysPreview.DBSysPreviewInfo m_SysPreviewInfo;

        /// <summary>
        /// 初始化组件
        /// </summary>
        public override void InitBehaviour()
        {
            base.InitBehaviour();

            // 获取UI组件
            m_SysPreviewBtn = Window.FindChild("SysPreviewBtn").GetComponent<Button>();
            m_SysPreviewBtn.onClick.AddListener(OnClickSysPreviewBtn);
            m_ConditionText = UIHelper.FindChild(m_SysPreviewBtn.gameObject, "LevelLabel").GetComponent<Text>();
            m_RewardPanel = UIHelper.FindChild(m_SysPreviewBtn.gameObject, "Panel");
            m_NameText = UIHelper.FindChild(m_SysPreviewBtn.gameObject, "NameLabel").GetComponent<Text>();
            m_SysIcon = UIHelper.FindChild(m_SysPreviewBtn.gameObject, "SysIcon").GetComponent<Image>();

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, CheckAndSetUI);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_NET_MAIN_DISCONNECT, OnNetMainDisconnect);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SYS_PREVIEW_REWARDED_LISTS, CheckAndSetUI);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SYS_PREVIEW_REWARD, CheckAndSetUI);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, CheckAndSetUI);
        }

        /// <summary>
        /// 销毁组件
        /// </summary>
        public override void DestroyBehaviour()
        {
            m_SysConfig = null;
            m_SysPreviewInfo = null;
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SYS_OPEN, CheckAndSetUI);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_NET_MAIN_DISCONNECT, OnNetMainDisconnect);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_NET_RECONNECT, OnNetReconnect);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SYS_PREVIEW_REWARDED_LISTS, CheckAndSetUI);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SYS_PREVIEW_REWARD, CheckAndSetUI);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_SYS_CONFIG_INIT, CheckAndSetUI);
            base.DestroyBehaviour();
        }

        /// <summary>
        /// 激活/取消激活
        /// </summary>
        /// <param name="is_enable"></param>
        public override void EnableBehaviour(bool is_enable)
        {
            base.EnableBehaviour(is_enable);

            if (is_enable)
            {
                // 组件激活时候进行一次检查
                CheckDisplaySysConfig();
                SetUI();
            }
        }

        /// <summary>
        /// 检查当前还未开启的系统
        /// </summary>
        void CheckDisplaySysConfig()
        {
            m_SysConfig = null;
            m_SysPreviewInfo = null;
            uint sysId = SysPreviewManager.Instance.GetCurrentSysId();
            if (sysId != 0)
            {
                m_SysConfig = DBManager.Instance.GetDB<DBSysConfig>().GetConfigById(sysId);
                m_SysPreviewInfo = DBManager.Instance.GetDB<DBSysPreview>().GetData(sysId);
            }
        }

        /// <summary>
        /// 系统已经在主UI中开启
        /// </summary>
        /// <param name="evt"></param>
        void CheckAndSetUI(CEventBaseArgs evt)
        {
            if (IsEnable == false || m_Reconnecting)
                return;

            // 系统开放后进行一次检查
            CheckDisplaySysConfig();
            
            SetUI();
            var win = UIManager.Instance.GetWindow("UIForecastWindow");
            if (win != null && win.IsShow)
            {
                OnClickSysPreviewBtn(); 
            }
        }

        /// <summary>
        /// 主连接断开
        /// </summary>
        void OnNetMainDisconnect(CEventBaseArgs evt)
        {
            m_Reconnecting = true;
        }

        /// <summary>
        /// 断线重连成功
        /// </summary>
        void OnNetReconnect(CEventBaseArgs evt)
        {
            m_Reconnecting = false;
            CheckAndSetUI(new CEventBaseArgs());
        }

        /// <summary>
        /// 设置系统预览的提示信息
        /// </summary>
        void SetUI()
        {
            if (Window == null)
                return;

            // 当前没有预览提示的话，取消按钮显示
            if (m_SysConfig == null)
            {
                m_SysPreviewBtn.gameObject.SetActive(false);
                var win = UIManager.Instance.GetWindow("UIForecastWindow");
                if (win != null && win.IsShow)
                {
                    UIManager.Instance.CloseWindow("UIForecastWindow");
                }
                return;
            }

            // 显示按钮信息
            m_SysPreviewBtn.gameObject.SetActive(true);
            m_SysIcon.sprite = Window.LoadSprite(m_SysConfig.BtnSprite);
            m_SysIcon.SetNativeSize();
            m_NameText.text = m_SysConfig.BtnText;
            m_ConditionText.gameObject.SetActive(!m_SysConfig.IsOpened);
            m_ConditionText.text = m_SysPreviewInfo.Notice;
            m_RewardPanel.SetActive(m_SysConfig.IsOpened);
        }

        /// <summary>
        /// 点击系统预览的按钮
        /// </summary>
        void OnClickSysPreviewBtn()
        {
            UIManager.Instance.ShowWindow("UIForecastWindow");
        }
    }
}
