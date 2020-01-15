//---------------------------------------
// File: NetworkManager.cs
// Desc: 获取网络状态
// Author: raorui
// Date: 2018.8.2
//---------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    public class NetworkManager
    {
        static NetworkManager mInstance;
        public static NetworkManager Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new NetworkManager();

                return mInstance;
            }
        }

        NetworkReachability mNetState = NetworkReachability.NotReachable;
        float mLastTime = 0.0f;

        public NetworkManager()
        {
            mNetState = Application.internetReachability;
        }

        public void Update()
        {
            float cur_time = Time.unscaledTime;
            if(cur_time - mLastTime < 1.0f)
            {
                return;
            }

            mLastTime = cur_time;
            var network_state = Application.internetReachability;
            if(network_state != mNetState)
            {
                mNetState = network_state;
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_NETWORK_CHANGE, null);
            }
        }

        /// <summary>
        /// 获取网络状态
        /// </summary>
        /// <returns></returns>
        public string GetNetworkStateStr()
        {
            if (mNetState == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                return "Wifi";
            }
            else if (mNetState == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                return "4G";
            }
            else
            {
                return "Lost";
            }
        }

        /// <summary>
        /// 获取当前的网络状态
        /// </summary>
        public NetworkReachability NetState
        {
            get
            {
                return mNetState;
            }
        }
    }
}
