//------------------------------------------------------------------------------
// Desc   :  跨服管理类
// Author :  ljy
// Date   :  2018.8.13
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;
using xc.ui;

namespace xc
{
    [wxb.Hotfix]
    public class SpanServerManager : xc.Singleton<SpanServerManager>
    {
        class ServerInfo
        {
            public uint ControlServerId;    // 控制服务器的id
            public uint ServerId;           // 游戏服务器的id
            public string ServerName;       // 服务器名字
        }

        /// <summary>
        /// 是否处于跨服中
        /// </summary>
        public bool IsSpaning { get; set; }

        /// <summary>
        /// 服务器名字列表，从游戏服务器拿到的
        /// </summary>
        private Dictionary<uint, string> mSpanServerNames = new Dictionary<uint, string>();

        /// <summary>
        /// 服务器名字列表，从控制服务器拿到的
        /// </summary>
        private Dictionary<uint, ServerInfo> mSpanServerInfosFromControlServer = new Dictionary<uint, ServerInfo>();

        private List<uint> mMergedEntrances = new List<uint>();

        public SpanServerManager()
        {
            mSpanServerInfosFromControlServer.Clear();
        }
        
        ~SpanServerManager()
        {
        }

        //--------------------------------------------------------
        //  内部调用
        //--------------------------------------------------------

        //--------------------------------------------------------
        //  客户端消息
        //--------------------------------------------------------  

        //--------------------------------------------------------
        //  网络消息
        //--------------------------------------------------------
        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_ACC_SPAN_INFO:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CAccSpanInfo>(data);

                        if (pack.is_spaning == 1)
                        {
                            IsSpaning = true;
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SPAN_SERVER_OPEN, null);
                        }
                        else
                        {
                            IsSpaning = false;
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SPAN_SERVER_CLOSE, null);
                        }

                        break;
                    }
                case NetMsg.MSG_ACC_SPAN_NAME:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CAccSpanName>(data);

                        mSpanServerNames.Clear();
                        foreach (PkgKvStr kv in pack.names)
                        {
                            mSpanServerNames.Add(kv.k, System.Text.Encoding.UTF8.GetString(kv.v));
                        }

                        break;
                    }
                case NetMsg.MSG_ACC_MERGED_ENTRANCE:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CAccMergedEntrance>(data);

                        mMergedEntrances = pack.ids;

                        break;
                    }
                default:
                    break;
            }
        }

        //--------------------------------------------------------
        //  外部调用
        //--------------------------------------------------------
        public void Reset()
        {
            IsSpaning = false;
            mSpanServerNames.Clear();
        }

        public void RegisterAllMessage()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_ACC_SPAN_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_ACC_SPAN_NAME, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_ACC_MERGED_ENTRANCE, HandleServerData);
        }

        /// <summary>
        /// 根据server id 获取服务器名字
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public string GetServerNameByServerId(uint serverId)
        {
            if (mSpanServerNames.ContainsKey(serverId) == true)
            {
                return mSpanServerNames[serverId];
            }
            foreach (ServerInfo serverInfo in mSpanServerInfosFromControlServer.Values)
            {
                if (serverInfo.ServerId == serverId)
                {
                    return serverInfo.ServerName;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 根据玩家的uuid获取所在的服务器名字
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public string GetServerNameByUuid(uint uuid)
        {
            uint serverId = 0;
            // 如果是人形怪，则使用本地登录的服务器id
            if (ActorHelper.IsShemale(uuid) == true)
            {
                serverId = (uint)GlobalConfig.Instance.LoginInfo.ServerInfo.SId;
            }
            else
            {
                serverId = UuidToServerId(uuid);
            }

            return GetServerNameByServerId(serverId);
        }

        /// <summary>
        /// 根据玩家的uuid获取所在的服务器id
        /// </summary>
        /// <returns></returns>
        public uint UuidToServerId(uint uuid)
        {
            uint sid0 = uuid / 1000000;
            uint d2 = uuid % 1000000;
            if (d2 < 400000)
            {
                return sid0;
            }
            else if (d2 < 800000)
            {
                return sid0 + 2000;
            }
            else
            {
                return sid0 + 4000;
            }
        }

        /// <summary>
        /// 判断玩家是否和本地玩家在同一服务器
        /// </summary>
        public bool IsInSameServer(uint uuid)
        {
            // 如果是人形怪，则使用本地登录的服务器id，直接返回true
            if (ActorHelper.IsShemale(uuid) == true)
            {
                return true;
            }

            // 本地玩家服务器
            uint localUuid = xc.Game.Instance.LocalPlayerID.obj_idx;
            uint curServerId = UuidToServerId(localUuid);

            // 玩家服务器
            uint serverId = UuidToServerId(uuid);

            // 是否都在当前服的入口列表中
            if (mMergedEntrances.Contains(curServerId) == true && mMergedEntrances.Contains(serverId) == true)
            {
                return true;
            }

            return curServerId == serverId;
        }

        /// <summary>
        /// 判断两个玩家是否在同一服务器
        /// </summary>
        public bool IsInSameServer(uint uuid, uint uuid2)
        {
            // 如果是人形怪，则使用本地登录的服务器id，直接返回true
            if (ActorHelper.IsShemale(uuid) == true && ActorHelper.IsShemale(uuid2) == true)
            {
                return true;
            }

            uint serverId2 = UuidToServerId(uuid2);

            // 玩家服务器
            uint serverId = UuidToServerId(uuid);

            // 是否都在当前服的入口列表中
            if (mMergedEntrances.Contains(serverId2) == true && mMergedEntrances.Contains(serverId) == true)
            {
                return true;
            }

            return serverId2 == serverId;
        }

        public void AddServerNameFromControlServer(uint controlServerId, uint serverId, string serverName)
        {
            if (mSpanServerInfosFromControlServer.ContainsKey(controlServerId) == true)
            {
                GameDebug.LogError("AddServerNameFromControlServer error, already exist, control server id:" + controlServerId);
                return;
            }

            ServerInfo serverInfo = new ServerInfo();
            serverInfo.ControlServerId = controlServerId;
            serverInfo.ServerId = serverId;
            serverInfo.ServerName = serverName;
            mSpanServerInfosFromControlServer.Add(controlServerId, serverInfo);
        }

        /// <summary>
        /// 根据控制服id获取服务器名字
        /// </summary>
        /// <param name="controlServerId"></param>
        /// <returns></returns>
        public string GetServerNameByControlServerId(uint controlServerId)
        {
            if (mSpanServerInfosFromControlServer.ContainsKey(controlServerId) == true)
            {
                return mSpanServerInfosFromControlServer[controlServerId].ServerName;
            }

            return string.Empty;
        }
    }
}
