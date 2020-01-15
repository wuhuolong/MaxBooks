//---------------------------------------
// File: NetReconnect.cs
// Desc: 控制网络重连时候的状态转换
// Author: raorui
// Date: 2017.11.6
//---------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;
using Net;
using xc.protocol;

namespace xc
{
    public partial class NetReconnect : xc.Singleton<NetReconnect>
    {
        //-----------------------------------------------
        //    类型定义
        //-----------------------------------------------
        public enum EFSMState : byte
        {
            DS_Init, // 初始状态
            DS_Normal,// 网络正常
            DS_Reconnect, // 网络重连
            DS_Fail,// 重连失败
        }

        public enum EFSMEvent : byte
        {
            /// <summary>
            /// 网络断开
            /// </summary>
            DE_NetDisconnnect = 0,

            /// <summary>
            /// 网络重连成功
            /// </summary>
            DE_ReconnectSucc,

            /// <summary>
            /// 网络重连失败
            /// </summary>
            DE_ReconnectFail,

            /// <summary>
            /// 失败后，重试网络重连
            /// </summary>
            DE_Retry,

            /// <summary>
            /// 不能进行断线重连
            /// </summary>
            DE_CannotReconnect,

            /// <summary>
            /// // 重置状态
            /// </summary>
            DE_Reset
        }

        /// <summary>
        /// 是否自动重连
        /// </summary>
        static bool m_AutoConnect = true;

        /// <summary>
        /// 状态机
        /// </summary>
        Machine m_Machine;

        /// <summary>
        /// 初始状态(网络还未开始连接)
        /// </summary>
        Machine.State m_InitState;

        /// <summary>
        /// 网络正常状态
        /// </summary>
        Machine.State m_NormalState;

        /// <summary>
        /// 断线重连状态
        /// </summary>
        Machine.State m_ReconnectState;

        /// <summary>
        /// 断线重连失败
        /// </summary>
        Machine.State m_FailState;

        byte[] m_CrossToken;

        /// <summary>
        /// 下次心跳包的更新时间
        /// </summary>
        float m_NextHeartTime = float.MaxValue;
        Utils.Timer m_HeartTimeout;// 网络超时检测

        float m_NextCrossHeartTime = float.MaxValue;
        Utils.Timer mCrossHeartTimeout;

        private int m_HeartInterval = 0;
        float mLastPingTime = 0f;

        public NetReconnect()
        {
            InitMachine();
            InitEvent();
            m_HeartInterval = GameConstHelper.GetInt("GAME_SYS_HEART_INTERVAL");
        }

        public void Reset()
        {
            if (m_Machine != null)
                m_Machine.React((uint)EFSMEvent.DE_Reset);

            m_DisconnectReason = DisconnectReason.None;
            m_DisconnectEnterReason = DisconnectReason.None;
        }

        public void Update()
        {
            if (m_Machine != null)
            {
                m_Machine.Update();
            }

            // 发送心跳包
            if (Game.Instance.Connected)// 连上了服务器才发送心跳包
            {
                float cur_time = Time.time;
                if (cur_time > m_NextHeartTime)
                {
                    OnHeartTimeUpdate();
                    m_NextHeartTime = cur_time + m_HeartInterval;
                }

                // 需要给附连接也发送心跳包，以防止被服务器踢下线
                if (NetClient.HasCrossClient && (NetClient.GetCrossClient().NetState == NetClient.ENetState.ES_Connected || Game.GetInstance().GetLocalPlayer() != null))
                {
                    if (cur_time > m_NextCrossHeartTime)
                    {
                        OnCrossHeartTimeUpdate();
                        m_NextCrossHeartTime = cur_time + m_HeartInterval;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化状态机
        /// </summary>
        void InitMachine()
        {
            m_Machine = new Machine();
            m_InitState = new xc.Machine.State((uint)EFSMState.DS_Init, m_Machine);
            m_NormalState = new xc.Machine.State((uint)EFSMState.DS_Normal, m_Machine);
            m_ReconnectState = new xc.Machine.State((uint)EFSMState.DS_Reconnect, m_Machine);
            m_FailState = new xc.Machine.State((uint)EFSMState.DS_Fail, m_Machine);

            //// 构建状态图
            m_InitState.AddTransition((uint)EFSMEvent.DE_ReconnectSucc, m_NormalState);// 进入游戏
            m_InitState.AddTransition((uint)EFSMEvent.DE_NetDisconnnect, m_ReconnectState);// 进入游戏前，如果附链接断开的话，也需要重连
            m_InitState.AddTransition((uint)EFSMEvent.DE_CannotReconnect, m_FailState);// 不进行断线重连

            m_NormalState.AddTransition((uint)EFSMEvent.DE_NetDisconnnect, m_ReconnectState);// 网络断开
            m_NormalState.AddTransition((uint)EFSMEvent.DE_CannotReconnect, m_FailState);// 不进行断线重连
            m_NormalState.AddTransition((uint)EFSMEvent.DE_Reset, m_InitState);// 重新登录

            m_ReconnectState.AddTransition((uint)EFSMEvent.DE_ReconnectSucc, m_NormalState);// 断线重连成功
            m_ReconnectState.AddTransition((uint)EFSMEvent.DE_ReconnectFail, m_FailState);// 断线重连失败
            m_ReconnectState.AddTransition((uint)EFSMEvent.DE_CannotReconnect, m_FailState);// 不进行断线重连
            m_ReconnectState.AddTransition((uint)EFSMEvent.DE_Reset, m_InitState);// 重连过程中取消

            m_FailState.AddTransition((uint)EFSMEvent.DE_Retry, m_ReconnectState);
            m_FailState.AddTransition((uint)EFSMEvent.DE_Reset, m_InitState);

            /// 设置Enter/Exit/Update State的函数
            m_NormalState.SetEnterFunction(EnterState_Normal);
            m_NormalState.SetUpdateFunction(UpdateState_Normal);
            m_NormalState.SetExitFunction(ExitState_Normal);
            m_ReconnectState.SetEnterFunction(EnterState_Reconnect);
            m_ReconnectState.SetUpdateFunction(UpdateState_Reconnect);
            m_ReconnectState.SetExitFunction(ExitState_Reconnect);
            m_FailState.SetEnterFunction(EnterState_FailState);
            m_FailState.SetUpdateFunction(UpdateState_FailState);
            m_Machine.SetCurState(m_InitState);
        }

        void InitEvent()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_MAIN_CONNECTED, OnMainNetConnected);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_CROSS_CONNECTED, OnCrossNetConnected);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_MAIN_DISCONNECT, OnMainNetDisconnect);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_NET_CROSS_DISCONNECT, OnCrossNetDisconnect);

            Game.Instance.SubscribeNetNotify(NetMsg.MSG_ACC_SESSION, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_ACC_SESSION_LOGIN, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MWAR_TOKEN, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_MWAR_LOGIN, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_ACC_HEART, HandleServerData);
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_ACC_HEART_MWAR, HandleServerData);
        }

        //-----------------------------------------------
        //  事件消息
        //-----------------------------------------------
        /// <summary>
        /// 主连接连上了
        /// </summary>
        /// <param name="data"></param>
        void OnMainNetConnected(CEventBaseArgs data)
        {
            m_NextHeartTime = Time.time + 0.1f;
        }

        /// <summary>
        /// 副连接连上了
        /// </summary>
        /// <param name="data"></param>
        void OnCrossNetConnected(CEventBaseArgs data)
        {
            if (m_Machine != null)// 副连接连上了才表示网络连接成功
            {
                if (IsReconnect)
                {
                    UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_86"));

                    if(m_DisconnectEnterReason == DisconnectReason.Corss)
                    {
                        m_DisconnectEnterReason = DisconnectReason.None;
                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NET_RECONNECT, null);
                    }
                }

                m_Machine.React((uint)EFSMEvent.DE_ReconnectSucc);
            }
            m_NextCrossHeartTime = Time.time + 0.1f;
        }

        public void ReconnectSucc()
        {
            if (m_DisconnectEnterReason == DisconnectReason.Main)
            {
                m_DisconnectEnterReason = DisconnectReason.None;
                xc.ui.ugui.UIManager.Instance.CloseAllWindowExcept();
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NET_RECONNECT, null);
            }
        }

        /// <summary>
        /// 主连接网络断开
        /// </summary>
        /// <param name="data"></param>
        void OnMainNetDisconnect(CEventBaseArgs data)
        {
            if(Game.Instance.ForceDisconnect == false)
            {
                if (m_Machine != null )// 网络断开分为链路断开和心跳包超时两种情况
                {
                    m_DisconnectReason = DisconnectReason.Main;
                    m_Machine.React((uint)EFSMEvent.DE_NetDisconnnect);
                }
                Game.Instance.Reset(true);
            }

            if (m_HeartTimeout != null)
            {
                m_HeartTimeout.Destroy();
                m_HeartTimeout = null;
            }
            m_NextHeartTime = float.MaxValue;
        }

        /// <summary>
        /// 副连接网络断开
        /// </summary>
        /// <param name="data"></param>
        void OnCrossNetDisconnect(CEventBaseArgs data)
        {
            if (m_Machine != null && Game.Instance.ForceDisconnect == false)// 网络断开分为链路断开和心跳包超时两种情况
            {
                m_DisconnectReason = DisconnectReason.Corss;
                m_Machine.React((uint)EFSMEvent.DE_NetDisconnnect);
            }

            if (mCrossHeartTimeout != null)
            {
                mCrossHeartTimeout.Destroy();
                mCrossHeartTimeout = null;
            }
            m_NextCrossHeartTime = float.MaxValue;
        }

        Coroutine m_WaitConnect;
        void ConnectCrossServer(byte[] ip, int port, byte[] token)
        {
            string serverIp = System.Text.Encoding.UTF8.GetString(ip);
            CrossServerIntegration.GetInstance().StartConnect(serverIp, (int)port, token);
        }

        IEnumerator WaitConnectCrossServer(byte[] ip, int port, byte[] token)
        {
            while(Game.Instance.Connected == false)
            {
                yield return null;
            }

            ConnectCrossServer(ip, port, token);
        }

        /// <summary>
        /// 主连接心跳包的更新
        /// </summary>
        void OnHeartTimeUpdate()
        {
            //GameDebug.Log("<<<MSG_ACC_HEART:"+Time.unscaledTime);
            mLastPingTime = UnityEngine.Time.realtimeSinceStartup;

            C2SAccHeart acc_heart = new C2SAccHeart();
            NetClient.GetBaseClient().SendData<C2SAccHeart>(NetMsg.MSG_ACC_HEART, acc_heart);
            if(m_HeartTimeout != null)
            {
                m_HeartTimeout.Destroy();
                m_HeartTimeout = null;
            }

            m_HeartTimeout = new Utils.Timer(GameConstHelper.GetInt("GAME_SYS_PING_TIMEOUT") * 1000, false, GameConstHelper.GetInt("GAME_SYS_PING_TIMEOUT") * 1000.0f, OnHeartTimeout);
        }

        /// <summary>
        /// 副连接心跳包更新
        /// </summary>
        void OnCrossHeartTimeUpdate()
        {
            //GameDebug.Log("<<<MSG_ACC_HEART_MWAR:" + Time.unscaledTime);
            var cross_acc_heart = new C2SAccHeartMwar();
            NetClient.GetCrossClient().SendData<C2SAccHeartMwar>(NetMsg.MSG_ACC_HEART_MWAR, cross_acc_heart);
            if (mCrossHeartTimeout != null)
            {
                mCrossHeartTimeout.Destroy();
                mCrossHeartTimeout = null;
            }

            mCrossHeartTimeout = new Utils.Timer(GameConstHelper.GetInt("GAME_SYS_PING_TIMEOUT") * 1000, false, GameConstHelper.GetInt("GAME_SYS_PING_TIMEOUT") * 1000.0f, OnCrossHeartTimeout);
        }

        /// <summary>
        /// 主连接心跳包超时
        /// </summary>
        void OnHeartTimeout(float remainTime)
        {
            if (remainTime > 0)
                return;

            if (m_HeartTimeout != null)
            {
                m_HeartTimeout.Destroy();
                m_HeartTimeout = null;
            }

            //如果Timeout时间内没有消息返回，则表示网络已断开
            Game.GetInstance().OnNetDisconnect(NetType.NT_TCP, -2);
        }

        /// <summary>
        /// 副连接心跳包超时
        /// </summary>
        void OnCrossHeartTimeout(float remainTime)
        {
            if (remainTime > 0)
                return;

            if (mCrossHeartTimeout != null)
            {
                mCrossHeartTimeout.Destroy();
                mCrossHeartTimeout = null;
            }

            //如果Timeout时间内没有消息返回，则表示网络已断开
            //if (NetClient.CrossToggle)
            //CrossServerIntegration.GetInstance().Stop();

            CrossServerIntegration.GetInstance().OnNetDisconnect(NetType.NT_TCP, -2);
        }

        //-----------------------------------
        //      网络消息
        //-----------------------------------
        void HandleServerData(ushort protocol, byte[] data)
        {
            switch(protocol)
            {
                case NetMsg.MSG_ACC_SESSION:// 接收主连接Token
                    {
                        GameDebug.Log(">>>MSG_ACC_SESSION");

                        var session = S2CPackBase.DeserializePack<S2CAccSession>(data);
                        GlobalConfig.Instance.Token = session.token;

                        break;
                    }
                case NetMsg.MSG_ACC_SESSION_LOGIN:// 接收主连接Token登录的结果
                    {
                        GameDebug.Log(">>>MSG_ACC_SESSION_LOGIN");

                        var session_login = S2CPackBase.DeserializePack<S2CAccSessionLogin>(data);
                        if(session_login.result == 0)
                        {
                            GameDebug.Log("主连接重连失败");
                            m_ForceRebot = true;
                            m_Machine.React((uint)EFSMEvent.DE_ReconnectFail);
                        }
                        else
                        {
                            GameDebug.Log("主连接重连成功");
                        }
                        break;
                    }
                case NetMsg.MSG_MWAR_TOKEN:// 收到副连接的Token信息就开始Connect
                    {
                        GameDebug.Log(">>>MSG_MWAR_TOKEN");

                        if (NetClient.CrossToggle)
                            CrossServerIntegration.GetInstance().Stop();
                        S2CMwarToken rep = S2CPackBase.DeserializePack<S2CMwarToken>(data);
                        m_IsRecvToken = true;
                        m_CrossToken = rep.token;
                        if (Game.Instance.Connected)// 主连接连上了再连接副连接
                            ConnectCrossServer(rep.ip, (int)rep.port, rep.token);
                        else
                            m_WaitConnect = MainGame.HeartBehavior.StartCoroutine(WaitConnectCrossServer(rep.ip, (int)rep.port, rep.token));
                        break;
                    }
                case NetMsg.MSG_MWAR_LOGIN: // 副连接登录成功
                    {
                        GameDebug.Log(">>>MSG_MWAR_LOGIN");

                        var mwar_login = S2CPackBase.DeserializePack<S2CMwarLogin>(data);
                        if(mwar_login.result == 0)
                        {
                            if (m_Machine != null)// 副连接连上了才表示网络连接成功
                            {
                                UINotice.Instance.ShowMessage(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_87"));
                                m_Machine.React((uint)EFSMEvent.DE_ReconnectFail);
                            }
                        }
                        else if(mwar_login.result == 1)
                        {
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NET_CROSS_CONNECTED, null);
                        }
                        
                        break;
                    }
                case NetMsg.MSG_ACC_HEART:// 主连接心跳包
                    {
                        //Debug.Log(">>>MSG_ACC_HEART");
                        // 服务器有返回消息，则将计时器销毁
                        if (m_HeartTimeout != null)
                        {
                            m_HeartTimeout.Destroy();
                            m_HeartTimeout = null;
                        }

                        var dt = UnityEngine.Time.realtimeSinceStartup - mLastPingTime;
                        PingTime.GetInstance().DelayTime = dt;
                    }
                    break;
                case NetMsg.MSG_ACC_HEART_MWAR:// 副连接心跳包
                    {
                        //Debug.Log(">>>MSG_ACC_HEART_MWAR");
                        // 服务器有返回消息，则将计时器销毁
                        if (mCrossHeartTimeout != null)
                        {
                            mCrossHeartTimeout.Destroy();
                            mCrossHeartTimeout = null;
                        }
                    }
                    break;
            }
        }
    }
}
