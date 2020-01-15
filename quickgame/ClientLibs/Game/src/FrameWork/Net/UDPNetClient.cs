#define USE_MULTIPACK
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using xc;

namespace Net
{
    public class UDPNetClient : NetClient
    {       
        UDPNetClient():base()
        {
            mNetType = NetType.NT_UDP;
        }

        static public NetClient GetUDPInstance()
        {
            //if (!msCrossToggle)
            {
                if (NetClient.msUDPInstance == null)
                {
                    NetClient.msUDPInstance = new UDPNetClient();
                    NetClient.msUDPInstance.Encrypt = null;//new DBEncrypt();
                }
                return NetClient.msUDPInstance;
            }
            //else
            {
                /*if (NetClient.msCrossInstance == null)
                {
                    NetClient.msCrossInstance = new NetClient();
                    NetClient.msCrossInstance.Encrypt = null;
                }
                return NetClient.msCrossInstance;*/
            }
        }
        
        static public NetClient GetBaseUDPClient()
        {
            if (NetClient.msUDPInstance == null)
            {
                NetClient.msUDPInstance = new UDPNetClient();
                NetClient.msUDPInstance.Encrypt = null;
            }
            return NetClient.msUDPInstance;
        }
        
        /*static public NetClient GetCrossClient()
        {
            if (NetClient.msCrossInstance == null)
            {
                NetClient.msCrossInstance = new NetClient();
                NetClient.msCrossInstance.Encrypt = null;
            }
            return NetClient.msCrossInstance;
        }*/
    }
}

