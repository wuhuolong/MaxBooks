//------------------------------------------------------------------------------
// Desc   :  帮派联赛管理类
// Author :  ljy
// Date   :  2018.3.23
//------------------------------------------------------------------------------
using Net;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using xc.protocol;
using xc.Maths;
using xc.ui;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class GuildLeagueManager : xc.Singleton<GuildLeagueManager>
    {
        /// <summary>
        /// 副本里面的帮派id列表
        /// </summary>
        List<uint> mGuildIds;

        /// <summary>
        /// 级别信息
        /// </summary>
        List<PkgGlLevelInfo> mLevelInfos = null;

        /// <summary>
        /// 对战信息
        /// </summary>
        List<PkgGlBattleInfo> mBattleInfos = null;

        public GuildLeagueManager()
        {
        }

        public void Reset()
        {
            mGuildIds = null;
            mLevelInfos = null;
            mBattleInfos = null;
        }

        public void RegisterAllMessages()
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GLEAGUE_CAMP, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GUILD_LEAGUE_LEVEL_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GUILD_LEAGUE_BATTLE_INFO, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_GUILD_LEAGUE_REFRESH, HandleServerData);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_FIRST_ENTER_SCENE, OnFirstEnterScene);
        }

        /// <summary>
        /// 获取帮派所在阵营
        /// </summary>
        /// <param name="guildId"></param>
        /// <returns></returns>
        public uint GetGuildCamp(uint guildId)
        {
            uint camp = 0;
            uint index = 0;
            if (mGuildIds != null && mGuildIds.Count > 0)
            {
                foreach (uint tempGuildId in mGuildIds)
                {
                    ++index;
                    if (tempGuildId == guildId)
                    {
                        camp = index;
                        break;
                    }
                }
            }

            return camp;
        }

        /// <summary>
        /// 指定帮派是否有资格参加帮派联赛
        /// </summary>
        /// <param name="guildId"></param>
        public bool CanJoinLeague(uint guildId = 0)
        {
            if (guildId == 0)
            {
                guildId = LocalPlayerManager.Instance.GuildID;
            }

            if (mLevelInfos != null)
            {
                foreach (PkgGlLevelInfo levelInfo in mLevelInfos)
                {
                    if (levelInfo.guilds != null)
                    {
                        foreach (PkgKvStr guildInfo in levelInfo.guilds)
                        {
                            if (guildInfo.k == guildId)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            if (mBattleInfos != null)
            {
                foreach (PkgGlBattleInfo battleInfo in mBattleInfos)
                {
                    if (battleInfo.round_one != null)
                    {
                        foreach (PkgGlRoundInfo roundInfo in battleInfo.round_one)
                        {
                            if (roundInfo.guilds != null)
                            {
                                foreach (PkgKvStr guildInfo in roundInfo.guilds)
                                {
                                    if (guildInfo.k == guildId)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }

                    if (battleInfo.round_two != null)
                    {
                        foreach (PkgGlRoundInfo roundInfo in battleInfo.round_two)
                        {
                            if (roundInfo.guilds != null)
                            {
                                foreach (PkgKvStr guildInfo in roundInfo.guilds)
                                {
                                    if (guildInfo.k == guildId)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 第一轮是否结束
        /// </summary>
        public bool RoundOneIsOver(uint guildId = 0)
        {
            if (mBattleInfos == null)
            {
                return false;
            }

            if (guildId == 0)
            {
                guildId = LocalPlayerManager.Instance.GuildID;
            }

            foreach (PkgGlBattleInfo battleInfo in mBattleInfos)
            {
                if (battleInfo.round_one != null)
                {
                    foreach (PkgGlRoundInfo roundInfo in battleInfo.round_one)
                    {
                        if (roundInfo.winner > 0 && roundInfo.guilds != null)
                        {
                            foreach (PkgKvStr guildInfo in roundInfo.guilds)
                            {
                                if (guildInfo.k == guildId)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 第二轮是否结束
        /// </summary>
        public bool RoundTwoIsOver(uint guildId = 0)
        {
            if (mBattleInfos == null)
            {
                return false;
            }

            if (guildId == 0)
            {
                guildId = LocalPlayerManager.Instance.GuildID;
            }

            foreach (PkgGlBattleInfo battleInfo in mBattleInfos)
            {
                if (battleInfo.round_two != null)
                {
                    foreach (PkgGlRoundInfo roundInfo in battleInfo.round_two)
                    {
                        if (roundInfo.winner > 0 && roundInfo.guilds != null)
                        {
                            foreach (PkgKvStr guildInfo in roundInfo.guilds)
                            {
                                if (guildInfo.k == guildId)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_GLEAGUE_CAMP:
                    {
                        S2CGleagueCamp msg = S2CPackBase.DeserializePack<S2CGleagueCamp>(data);

                        mGuildIds = msg.guild_ids;

                        break;
                    }
                case NetMsg.MSG_GUILD_LEAGUE_LEVEL_INFO:
                    {
                        S2CGuildLeagueLevelInfo msg = S2CPackBase.DeserializePack<S2CGuildLeagueLevelInfo>(data);

                        mLevelInfos = msg.infos;
                        mBattleInfos = null;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_GUILD_LEAGUE_INFO_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_GUILD_LEAGUE_BATTLE_INFO:
                    {
                        S2CGuildLeagueBattleInfo msg = S2CPackBase.DeserializePack<S2CGuildLeagueBattleInfo>(data);

                        mLevelInfos = null;
                        mBattleInfos = msg.infos;

                        ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_GUILD_LEAGUE_INFO_CHANGED, null);

                        break;
                    }
                case NetMsg.MSG_GUILD_LEAGUE_REFRESH:
                    {
                        C2SGuildLeagueInfo msg = new C2SGuildLeagueInfo();
                        NetClient.BaseClient.SendData<C2SGuildLeagueInfo>(NetMsg.MSG_GUILD_LEAGUE_INFO, msg);

                        break;
                    }
                default:
                    break;
            }
        }

        void OnFirstEnterScene(CEventBaseArgs args)
        {
            C2SGuildLeagueInfo msg = new C2SGuildLeagueInfo();
            NetClient.BaseClient.SendData<C2SGuildLeagueInfo>(NetMsg.MSG_GUILD_LEAGUE_INFO, msg);
        }
    }
}
