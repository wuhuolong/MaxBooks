using System;
using System.Collections.Generic;
using Utils;
using UnityEngine;
using xc.ui.ugui;
using Net;
using xc.protocol;

namespace xc
{
    partial class NetReconnect
    {
        public enum DisconnectReason:byte
        {
            None = 0,
            Main, // 主连接断开
            Corss // 副连接断开
        }

        DisconnectReason m_DisconnectReason = DisconnectReason.None;
        DisconnectReason m_DisconnectEnterReason = DisconnectReason.None;

        /// <summary>
        /// 是否在断线重连状态下
        /// </summary>
        public bool IsReconnect
        {
            get
            {
                return m_IsReconnect;
            }
        }
        bool m_IsReconnect = false;

        /// <summary>
        /// 是否已经发送了重连的协议
        /// </summary>
        bool m_IsSendRecon = false;

        /// <summary>
        /// 是否已经接收到Token
        /// </summary>
        bool m_IsRecvToken = false;

        /// <summary>
        /// 重试连接服务器
        /// </summary>
        /// <param name="remainTime"></param>
        void RetryConnect()
        {
            if(Game.Instance.Connected)// 副连接断开的时候等待副连接连接成功的消息即可
            {
                if(m_IsSendRecon == false)// 没有发送MSG_MWAR_RECONN协议的时候先发送
                {
                    m_IsSendRecon = true;
                    m_IsRecvToken = false;
                    GameDebug.Log("<<<MSG_MWAR_RECONN");
                    var mwar_recon = new C2SMwarReconn();
                    mwar_recon.token = m_CrossToken;
                    NetClient.GetBaseClient().SendData<C2SMwarReconn>(NetMsg.MSG_MWAR_RECONN, mwar_recon);
                }
                else
                {
                    if(m_IsRecvToken == true)// 等待副连接Token协议
                    {
                        if(CrossServerIntegration.GetInstance().Connected == false)// 副连接未连接上的时候，尝试重连
                        {
                            CrossServerIntegration.GetInstance().Stop();
                            CrossServerIntegration.GetInstance().StartConnect();
                        }
                    }
                }
            }
            else
            {
                Game.Instance.StopNetClient();
                Game.Instance.Login();
            }
        }

        int m_RetryCount = 0;
        float m_RetryTime = 0;
        float m_RetryNextTime = 0;
        uint m_OfflineTimeout = 30;

        /// <summary>
        /// Reconnect
        /// </summary>
        /// <param name="s"></param>
        public void EnterState_Reconnect(xc.Machine.State s)
        {
            m_DisconnectEnterReason = m_DisconnectReason;
            GameDebug.LogRed("disconnect reason: "+ m_DisconnectEnterReason);
            GameDebug.Log("EnterState_Reconnect");
            m_RetryTime = 0;
            m_RetryNextTime = 0;
            m_RetryCount = 0;
            m_IsReconnect = true;
            m_IsSendRecon = false;
            uint time_out = GameConstHelper.GetUint("GAME_OFFLINE_TIMEOUT");
            if(time_out != 0)
            {
                m_OfflineTimeout = time_out;
            }
            UIManager.Instance.ShowWindow("UIAutoConnectWindow");
        }

        public void UpdateState_Reconnect(xc.Machine.State s)
        {
            if (!m_AutoConnect)
            {
                m_Machine.React((uint)EFSMEvent.DE_CannotReconnect);
                return;
            }

            m_RetryTime += Time.deltaTime;
            if (m_RetryTime > m_OfflineTimeout)
            {
                m_ForceRebot = false;
                m_Machine.React((uint)EFSMEvent.DE_ReconnectFail);
                return;
            }

            float cur_time = Time.time;
            if(cur_time < m_RetryNextTime)
            {
                return;
            }
            m_RetryNextTime = cur_time + 5.0f;// 5s尝试一次重连

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                
            }
            else
            {
                m_RetryCount++;
                RetryConnect();
                GameDebug.Log(string.Format("重连{0}次", m_RetryCount));
            }
        }

        public void ExitState_Reconnect(xc.Machine.State state)
        {
            m_IsReconnect = false;
            UIManager.Instance.CloseWindow("UIAutoConnectWindow");
        }
    }
}
