using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Net;
using xc.protocol;

namespace xc
{
    // 跨服相关的管理类
    public class CrossServerIntegration : NetClient.IListener
    {
        public static CrossServerIntegration GetInstance()
        {
            if (msInstance == null)
                msInstance = new CrossServerIntegration();
            return msInstance;
        }

        static CrossServerIntegration msInstance;
        public string mIP = "";
        public int mPort;
        public byte[] mToken = null;
        private bool mConnected = false;
        public bool Connected
        {
            get
            {
                return mConnected;
            }
        }
        
        CrossServerIntegration()
        {
        }
        
        // 开启新连接
        public void StartConnect(string ip, int port, byte[] token)
        {
            NetClient.CrossToggle = true;
            NetClient.GetCrossClient().mListener = this;
            
            // 向portal请求IP和PORT，这里先暂时写死，直接登录
            mIP = ip;
            mPort = port;
            mToken = token;
            Login(mIP, mPort);
        }

        /// <summary>
        /// 使用旧的ip和port进行重连
        /// </summary>
        public void StartConnect()
        {
            NetClient.CrossToggle = true;
            NetClient.GetCrossClient().mListener = this;

            // 向portal请求IP和PORT，这里先暂时写死，直接登录
            Login(mIP, mPort);
        }
        
        // 关闭跨服模式
        public void Stop()
        {
            NetClient.CrossToggle = false;
            NetClient.GetCrossClient().Stop();
            mConnected = false;
        }
        
        public void Login(string ip, int port)
        {
            // 切换服务器时，需要断开连接再重连
            NetClient.GetCrossClient().Stop();

            if (NetClient.GetCrossClient().NetState == NetClient.ENetState.ES_Disconnect ||
                NetClient.GetCrossClient().NetState == NetClient.ENetState.ES_UnInit)
            {
                Debug.Log(string.Format("Begin to connect cross server, ip:{0} port: {1}", ip, port));
                NetClient.GetCrossClient().Start(ip, port);
            }
            else
            {
                if (NetClient.GetCrossClient().NetState == NetClient.ENetState.ES_Connected)
                    Debug.Log("Connection has been established");
            }
        }

        public void OnNetConnect(NetType netType)
        {
            Debug.Log("Cross connect success.");

            mConnected = true;
            
            C2SMwarLogin mwarLogin = new C2SMwarLogin();
            mwarLogin.uuid = Game.GetInstance().LocalPlayerID.obj_idx;
            mwarLogin.token = mToken;

            // 确保在副链接发这条消息
            NetClient.GetCrossClient().SendData<C2SMwarLogin>(NetMsg.MSG_MWAR_LOGIN, mwarLogin);
        }
        
        public void OnNetDisconnect(NetType netType, int e)
        {
            Debug.Log("Disconnect to cross server! Error:" + e.ToString());

            // 跨服Socket断开，停掉跨服
            Stop();
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NET_CROSS_DISCONNECT, null);
        }
        
        public void OnNetDataReply(NetType netType, ushort protocol, byte[] data)
        {
            Game.GetInstance().ProcessServerData(protocol , data);
        }
    }
}

