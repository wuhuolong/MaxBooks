using Net;
using System.Collections.Generic;
using xc.protocol;

namespace xc
{
    /// <summary>
    /// 野外玩家管理
    /// </summary>
    public class WildPlayerManager
    {
        /// <summary>
        /// 视野内的玩家信息
        /// </summary>
        protected Dictionary<uint, WildPlayerInfo> mAppearWildPlayersInfo = new Dictionary<uint, WildPlayerInfo>();

        /// <summary>
        /// 缓存的玩家信息
        /// </summary>
        protected Dictionary<uint, WildPlayerInfo> mDisappearWildPlayersInfo = new Dictionary<uint, WildPlayerInfo>();

        /// <summary>
        /// 视野内的怪物信息
        /// </summary>
        protected Dictionary<uint, WildMonsterInfo> mAppearWildMonstersInfo = new Dictionary<uint, WildMonsterInfo>();

        /// <summary>
        /// 缓存的怪物信息
        /// </summary>
        protected Dictionary<uint, WildMonsterInfo> mDisappearWildMonstersInfo = new Dictionary<uint, WildMonsterInfo>();


        public void Reset()
        {
            mAppearWildPlayersInfo.Clear();
            mDisappearWildPlayersInfo.Clear();
            mAppearWildMonstersInfo.Clear();
            mDisappearWildMonstersInfo.Clear();

            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CLEAR_UNITCACHE, OnClearUnitCache);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLEAR_UNITCACHE, OnClearUnitCache);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_ACTOR_FRIEND_MARCK_CHANGED, OnFriendMarkChanged);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_ACTOR_FRIEND_MARCK_CHANGED, OnFriendMarkChanged);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, OnFriendMarkChanged);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_TEAM_INFO_CHANGED, OnFriendMarkChanged);
        }

        /// <summary>
        /// 所有单位离开aoi
        /// </summary>
        public void ClearAllUnits()
        {
            // 清除玩家的aoi信息
            foreach (var player in mAppearWildPlayersInfo)
            {
                player.Value.HandleDisappear();
            }
            mAppearWildPlayersInfo.Clear();
            mDisappearWildPlayersInfo.Clear();

            // 清除怪物的aoi信息
            foreach (var monster in mAppearWildMonstersInfo)
            {
                monster.Value.HandleDisappear();
            }
            mAppearWildMonstersInfo.Clear();
            mDisappearWildMonstersInfo.Clear();
        }

        /// <summary>
        /// 由于aoi问题，在其他玩家死亡到复活这个时间段，如果离开了死亡玩家aoi范围
        /// 那么这个玩家复活时我是不知道的，这里需要定期收尸一下。。
        /// </summary>
        public void CleanupDeadPlayers()
        {
            ///TODO 目前有保留尸体的逻辑，暂时不需要清除
            /*List<WildPlayerInfo> dead_list = null;
            foreach (var player in mAppearWildPlayersInfo)
            {
                if (player.Value.IsDeadForALongTime)
                {
                    if (dead_list == null)
                        dead_list = new List<WildPlayerInfo>();

                    dead_list.Add(player.Value);
                }
            }

            if (dead_list != null)
            {
                foreach (var player in dead_list)
                {
                    GameDebug.Log("CleanupDeadPlayer id = " + player.UUID);
                    HandleUnitDisapper(player.UUID);
                }
            }*/
        }

        /// <summary>
        /// 是否需要更新本地玩家的aoi信息
        /// </summary>
        bool mLookLocalPlayer = false;

        public void UpdateLook()
        {
            if(mLookLocalPlayer)
            {
                var look_pack = new C2SNwarLook();
                look_pack.uuids.Add(Game.Instance.LocalPlayerID.obj_idx);
                NetClient.GetCrossClient().SendData<C2SNwarLook>(NetMsg.MSG_NWAR_LOOK, look_pack);
                mLookLocalPlayer = false;
            }

            WildPlayerInfo.SendLookImpl();
        }

        #region AOI信息的获取和创建
        /// <summary>
        /// 根据id获取玩家信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="created_when_not_exist">如果不存在则创建一个新的</param>
        /// <returns></returns>
        public WildPlayerInfo GetWildPlayerInfo(uint uuid, bool created_when_not_exist)
        {
            WildPlayerInfo info = null;

            if (created_when_not_exist)
            {
                // 先找缓存中的，有的话直接把缓存中的放入appear列表，并返回
                if (mDisappearWildPlayersInfo.TryGetValue(uuid, out info))
                {
                    mAppearWildPlayersInfo[info.UUID] = info;
                    mDisappearWildPlayersInfo.Remove(info.UUID);

                    return info;
                }
            }

            // 找appear中的，找不到则创建一个
            if (!mAppearWildPlayersInfo.TryGetValue(uuid, out info))
            {
                if (created_when_not_exist)
                {
                    info = CreateWildPlayerInfo(uuid);
                    mAppearWildPlayersInfo[uuid] = info;
                }
            }

            return info;
        }

        /// <summary>
        /// 根据id获取怪物信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="created_when_not_exist"></param>
        /// <returns></returns>
        public WildMonsterInfo GetWildMonsterInfo(uint uuid, bool created_when_not_exist)
        {
            WildMonsterInfo info = null;

            if (created_when_not_exist)
            {
                // 先找缓存中的，有的话直接把缓存中的放入appear列表，并返回
                if (mDisappearWildMonstersInfo.TryGetValue(uuid, out info))
                {
                    mAppearWildMonstersInfo[info.UUID] = info;
                    mDisappearWildMonstersInfo.Remove(info.UUID);
                    return info;
                }
            }

            // 找appear中的，找不到则创建一个
            if (!mAppearWildMonstersInfo.TryGetValue(uuid, out info))
            {
                if (created_when_not_exist)
                {
                    info = CreateWildMonsterInfo(uuid);
                    mAppearWildMonstersInfo[uuid] = info;
                }

                return info;
            }

            if (info == null)
            {
                GameDebug.LogError(string.Format("GetWildMonsterInfo({0}, {1})里找到的是null", uuid, created_when_not_exist));
            }

            return info;
        }

        /// <summary>
        /// 创建一个玩家信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        protected WildPlayerInfo CreateWildPlayerInfo(uint uuid)
        {
            // 如果有缓存，则从缓存中随便拿一个来初始化
            if (mDisappearWildPlayersInfo.Count > 0)
            {
                var e = mDisappearWildPlayersInfo.GetEnumerator();
                e.MoveNext();

                var info = e.Current;

                mDisappearWildPlayersInfo.Remove(info.Key);
                info.Value.Reset(uuid);
                return info.Value;
            }
            else
            {
                // 创建一个新的
                return new WildPlayerInfo(uuid);
            }
        }

        /// <summary>
        /// 创建怪物信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        protected WildMonsterInfo CreateWildMonsterInfo(uint uuid)
        {
            // 如果有缓存，则从缓存中随便拿一个来初始化
            if (mDisappearWildMonstersInfo.Count > 0)
            {
                var e = mDisappearWildMonstersInfo.GetEnumerator();
                e.MoveNext();

                var info = e.Current;

                mDisappearWildMonstersInfo.Remove(info.Key);
                if (info.Value == null)
                {
                    GameDebug.LogError("CreateWildMonsterInfo info.Value == null, uuid = " + uuid);
                    return null;
                }

                info.Value.Reset(uuid);
                return info.Value;
            }
            else
            {
                // 创建一个新的
                return new WildMonsterInfo(uuid);
            }
        }

        /// <summary>
        /// 将玩家信息添加到缓存中，同时从appear列表中移除
        /// </summary>
        /// <param name="player"></param>
        protected void AddPlayerToDisappear(WildPlayerInfo player_info)
        {
            mAppearWildPlayersInfo.Remove(player_info.UUID);

            // TODO 判断下最多可以缓存多少个player
            mDisappearWildPlayersInfo[player_info.UUID] = player_info;
        }

        /// <summary>
        /// 将怪物信息添加到缓存中，同时从appear列表中移除
        /// </summary>
        /// <param name="player"></param>
        protected void AddMonsterToDisappear(WildMonsterInfo monster_info)
        {
            mAppearWildMonstersInfo.Remove(monster_info.UUID);

            // TODO 判断下最多可以缓存多少个player
            mDisappearWildMonstersInfo[monster_info.UUID] = monster_info;
        }
        #endregion

        #region 客户端消息响应函数
        /// <summary>
        /// 响应清除所有aoi信息的函数
        /// </summary>
        /// <param name="arg"></param>
        private void OnClearUnitCache(CEventBaseArgs arg)
        {
            ClearAllUnits();
        }

        private void OnFriendMarkChanged(CEventBaseArgs arg)
        {
            foreach (KeyValuePair<UnitID, Actor> kvp in ActorManager.Instance.PlayerSet)
            {
                kvp.Value.SetNameText();
                kvp.Value.UpdateNameStyle();   //更新头顶PK模式
            }
        }
        #endregion

        #region 副本AOI组件中调用
        /// <summary>
        /// 响应aoi出现的消息
        /// </summary>
        /// <param name="pack"></param>
        public void HandleUnitAppear(S2CNwarAppear pack)
        {
            var uuid = pack.move.id;

            // 如果是玩家或者人形怪
            if(ActorHelper.IsPlayer(uuid) || ActorHelper.IsShemale(uuid))
            {
#if TEST_WILD_PROTOCOL
                GameDebug.Log(">>>MSG_NWAR_APPEAR player id = " + pack.moves.id);
#endif
                // 不需要处理本地玩家的appear
                if (uuid == Game.GetInstance().LocalPlayerID.obj_idx)
                    return;

                // 超出极限了，直接抛弃
                if (IsPlayerReachLimit())
                    return;

                var info = GetWildPlayerInfo(pack.move.id, true);
                if (info != null)
                    info.HandleAppear(pack.move, pack.version, pack.buffs, (uint)pack.appear_bit);
            }
            // 如果是召唤怪物
            else if (ActorHelper.IsSummon(uuid))
            {
#if TEST_WILD_PROTOCOL
                GameDebug.Log(">>>MSG_NWAR_APPEAR summon id = " + pack.moves.id);
#endif
                // 不需要处理本地玩家的召唤怪
                if (ActorHelper.IsMySummon(uuid))
                    return;

                var monster_info = GetWildMonsterInfo(pack.move.id, true);
                if (monster_info != null)
                    monster_info.HandleAppear(pack.move, pack.buffs);
            }
            // 如果是普通怪物
            else
            {
#if TEST_WILD_PROTOCOL
                GameDebug.Log(">>>MSG_NWAR_APPEAR monster id = " + pack.moves.id);
#endif
                var monster_info = GetWildMonsterInfo(pack.move.id, true);
                if (monster_info != null)
                    monster_info.HandleAppear(pack.move, pack.buffs);
            }

            var monBrief = pack.mon_brief;
            if (monBrief != null)
            {
                GetWildMonsterInfo(monBrief.uuid, true).HandleBriefInfo(monBrief);
            }
        }


        /// <summary>
        /// 响应aoi消失的消息
        /// </summary>
        /// <param name="pack"></param>
        public void HandleUnitDisapper(S2CNwarDisappear pack)
        {
#if TEST_WILD_PROTOCOL
            if (IsPlayer(pack.uuid))
                GameDebug.Log(">>>MSG_NWAR_DISAPPEAR player id = " + pack.uuid);
            else if (IsSummon(pack.uuid))
                GameDebug.Log(">>>MSG_NWAR_DISAPPEAR summon id = " + pack.uuid);
            else
                GameDebug.Log(">>>MSG_NWAR_DISAPPEAR monster id = " + pack.uuid);
#endif

            var uuid = pack.uuid;

            // 不需要处理本地玩家的disappear
            if (uuid == Game.Instance.LocalPlayerID.obj_idx)
                return;

            // 如果是玩家或者人形怪
            if (ActorHelper.IsPlayer(uuid) || ActorHelper.IsShemale(uuid))
            {
                var player_info = GetWildPlayerInfo(uuid, false);
                if (player_info != null)
                {
                    player_info.HandleDisappear();

                    AddPlayerToDisappear(player_info);
                }
            }
            // 如果是召唤怪
            else if (ActorHelper.IsSummon(uuid))
            {
                var monster_info = GetWildMonsterInfo(uuid, false);
                if (monster_info != null)
                {
                    monster_info.HandleDisappear();
                    AddMonsterToDisappear(monster_info);
                }
            }
            // 如果是普通怪物
            else
            {
                var monster_info = GetWildMonsterInfo(uuid, false);
                if (monster_info != null)
                {
                    monster_info.HandleDisappear();
                    AddMonsterToDisappear(monster_info);
                }
            }
        }

        /// <summary>
        /// 响应aoi版本信息改变的消息
        /// </summary>
        /// <param name="pack"></param>
        public void HandleUnitNewVersion(S2CNwarNewVersion pack)
        {
            if (pack.uuid == Game.Instance.LocalPlayerID.obj_idx)// 本地玩家没有appear消息，但是因为本地玩家的数据也需要通过aoi来更新
            {
                mLookLocalPlayer = true;
            }
            else
            {
                WildPlayerInfo info = null;
                info = GetWildPlayerInfo(pack.uuid, false);

                if (info != null)
                {
                    info.HandleNewVersion();
                }
            }
        }

        /// <summary>
        /// 响应角色死亡的消息
        /// </summary>
        /// <param name="pack"></param>
        public void HandleUnitDead(S2CNwarUnitDead pack)
        {
            var uuid = pack.id;

            if (ActorHelper.IsPlayer(uuid))
            {
                // 玩家死亡暂时不用做任何处理
            }
            else
            {
                var monster = GetWildMonsterInfo(uuid, false);
                if (monster != null)
                {
                    if (pack.killer_id == xc.Game.Instance.LocalPlayerID.obj_idx)
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MONSTER_DEAD, new CEventBaseArgs(uuid));

                    monster.HandleDead();

                    mAppearWildMonstersInfo.Remove(uuid);
                    mDisappearWildMonstersInfo.Remove(uuid);
                }
            }
        }

        /// <summary>
        /// 响应获取角色详细AOI信息的函数
        /// </summary>
        /// <param name="pack"></param>
        public void HandleUnitLook(S2CNwarLook pack)
        {
            var playerBrief = pack.brief;
            if (playerBrief != null)
            {
                var uuid = playerBrief.uuid;
                if (uuid == Game.GetInstance().LocalPlayerID.obj_idx)
                {
                    UpdateLocalPlayerAOIInfo(playerBrief);
                    return;
                }

                // 需要找到玩家的appear信息才创建角色
                var player_info = GetWildPlayerInfo(uuid, false);
                if (player_info != null)
                    player_info.HandleBriefInfo(playerBrief);
                //else
                //    GameDebug.LogWarning("[HandleUnitLook]can not find wild player info");
            }

            var monBrief = pack.mon_brief;
            if (monBrief != null)
            {
                // 需要找到怪物的appear信息才创建角色
                var monster_info = GetWildMonsterInfo(monBrief.uuid, false);
                if(monster_info != null)
                    monster_info.HandleBriefInfo(monBrief);
                //else
                //    GameDebug.LogWarning("[HandleUnitLook]can not find wild monster info");
            }
        }

        /// <summary>
        /// 根据AOI信息更新本地玩家
        /// </summary>
        /// <param name="info"></param>
        void UpdateLocalPlayerAOIInfo(PkgPlayerBrief info)
        {
            var local_player = Game.Instance.GetLocalPlayer() as LocalPlayer;
            if (local_player == null)
                return;

            List<uint> model_list = new List<uint>();
            List<uint> fashion_list = new List<uint>();
            ActorHelper.GetModelFashionList(info.shows, model_list, fashion_list);
            local_player.mAvatarCtrl.ChangeFacade(model_list, fashion_list, info.effects, local_player.VocationID);
            var client_model_set = ActorManager.Instance.ClientModelSet;
            foreach(var client_modle in client_model_set.Values)
            {
                if(client_modle != null && client_modle.RawUID == local_player.UID.obj_idx && client_modle.UpdateWithRawActor)
                {
                    client_modle.mAvatarCtrl.ChangeFacade(model_list, fashion_list, info.effects, local_player.VocationID);
                }
            }

            if (info.guild != null)
            {
                local_player.ActorAttribute.GuildId = info.guild.guild_id; 
                local_player.ActorAttribute.GuildName = System.Text.Encoding.UTF8.GetString(info.guild.guild_name);
            }
            else
            {
                local_player.ActorAttribute.GuildId = 0;
                local_player.ActorAttribute.GuildName = "";
            }

            local_player.UpdateNameColor(info.name_color);

            local_player.ActorAttribute.Honor = info.honor;
            local_player.ActorAttribute.Title = info.title;
            local_player.ActorAttribute.TransferLv = info.transfer;

            local_player.MateInfo = info.mate;

            local_player.SetNameText();
            local_player.ActorAttribute.BattlePower = info.battle_power;
            local_player.ActorAttribute.Level = info.level;

            uint oldEscortId = local_player.ActorAttribute.EscortId;

            if (info.war != null)
            {
                local_player.ActorAttribute.TeamId = info.war.team_id;
                local_player.ActorAttribute.EscortId = info.war.escort_id;

                if (local_player != null)
                {
                    local_player.UpdateAOIAttrElement(info.war.attr_elm);
                }

                local_player.UpdateByBitState(info.bit_states);
                local_player.SetHeadIcons(Actor.EHeadIcon.TEAM);
                local_player.UpdatePetId(info.war.pet_skin);
            }
            else
            {
                local_player.ActorAttribute.TeamId = 0;
                local_player.ActorAttribute.EscortId = 0;
            }
            if (oldEscortId != local_player.ActorAttribute.EscortId)
            {
                local_player.UpdateEscortNPC();
            }
            if (local_player.ActorAttribute.EscortId > 0)
            {
                // 如果有进行中的护送任务，则寻路做这个任务
                if (oldEscortId != local_player.ActorAttribute.EscortId)
                {
                    RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_QUEST_ESCORT);
                }
            }

            local_player.SetHeadIcons(Actor.EHeadIcon.PEAK);

            LocalPlayerManager.Instance.LocalActorAttribute.EscortId = local_player.ActorAttribute.EscortId;

            local_player.MountId = info.ride;
        }

        public void HandlePlayerCreate(Player player)
        {
            var player_info = GetWildPlayerInfo(player.UID.obj_idx, false);
            if (player_info != null)
                player_info.HandleActorCreate(player);
        }

        public void HandleMonsterCreate(Monster actor)
        {
            var player = GetWildMonsterInfo(actor.UID.obj_idx, false);
            if (player != null)
                player.HandleActorCreate(actor);
        }
        #endregion

        #region 判断函数

        /// <summary>
        /// 是否已经达到了可显示玩家的最大数量
        /// </summary>
        /// <returns></returns>
        public bool IsPlayerReachLimit()
        {
            return mAppearWildPlayersInfo.Count >= QualitySetting.GetMaxPlayerProcessCount() * 1.2f;
        }
        #endregion
    }
}
