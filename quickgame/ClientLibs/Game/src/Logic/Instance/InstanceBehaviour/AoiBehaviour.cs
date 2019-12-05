using Net;
using System.Collections.Generic;
using xc.protocol;

namespace xc.instance_behaviour
{
    /// <summary>
    /// aoi广播
    /// </summary>
    public class AoiBehaviour : Behaviour
    {
        protected WildPlayerManager mWildPlayerMgr = new WildPlayerManager();
        protected Utils.Timer mUpdateTimer = null;

        public override void Enter(params object[] param)
        {
            if (mUpdateTimer != null)
                mUpdateTimer.Destroy();

            mUpdateTimer = new Utils.Timer(1000, true, 1000f, OnWildUpdate);

            mWildPlayerMgr.Reset();

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_APPEAR, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_DISAPPEAR, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_NEW_VERSION, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_LOOK, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_UNIT_REVIVE, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_UNIT_DEAD, HandleServerData);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_REMOTEPLAYER_CREATE, OnRemotePlayerCreated);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_REMOTEMONSTERCREATEED, OnMonsterCreate);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LOCALMONSTERCREATEED, OnMonsterCreate); 
        }

        public override void Exit()
        {
            if (mUpdateTimer != null)
            {
                mUpdateTimer.Destroy();
                mUpdateTimer = null;
            }

            mWildPlayerMgr.ClearAllUnits();

            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_APPEAR, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_DISAPPEAR, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_NEW_VERSION, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_LOOK, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_UNIT_REVIVE, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_UNIT_DEAD, HandleServerData);

            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_REMOTEPLAYER_CREATE, OnRemotePlayerCreated);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_REMOTEMONSTERCREATEED, OnMonsterCreate);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_LOCALMONSTERCREATEED, OnMonsterCreate);
        }

        /// <summary>
        /// 定时更新的逻辑
        /// </summary>
        /// <param name="dt"></param>
        protected void OnWildUpdate(float dt)
        {
            // 清除已经死亡的玩家
            mWildPlayerMgr.CleanupDeadPlayers();
            // 发送需要获取aoi详细信息的列表给服务端
            mWildPlayerMgr.UpdateLook();
        }

        /// <summary>
        /// 响应远程玩家创建完成的消息
        /// </summary>
        /// <param name="evt"></param>
        protected void OnRemotePlayerCreated(CEventBaseArgs evt)
        {
            var player = evt.arg as Player;
            if (player == null)
            {
                GameDebug.LogError("[OnRemotePlayerCreated] player is null");
                return;
            }

            mWildPlayerMgr.HandlePlayerCreate(player);
        }

        /// <summary>
        /// 响应怪物创建完成的消息
        /// </summary>
        /// <param name="evt"></param>
        protected void OnMonsterCreate(CEventBaseArgs evt)
        {
            var monster = evt.arg as Monster;
            if (monster == null)
            {
                GameDebug.LogError("[OnRemoterMonsterCreate] monster is null");
                return;
            }

            mWildPlayerMgr.HandleMonsterCreate(monster);
        }

        /// <summary>
        /// 处理复活消息
        /// </summary>
        /// <param name="pack"></param>
        protected virtual void HandleUnitRevive(S2CNwarUnitRevive pack)
        {
            var is_local_player = pack.id == Game.GetInstance().LocalPlayerID.obj_idx;
            if (!is_local_player)
            {
                // 如果找到了玩家，就让其复活，否则需要再次出现 @rr 2016.9.28
                Actor actor = ActorManager.Instance.GetPlayer(pack.id);
                if(actor != null)
                    actor.Relive();
                else
                {
                    S2CNwarAppear appearPack = new S2CNwarAppear();
                    appearPack.move = new PkgNwarMove();
                    appearPack.move.id = pack.id;
                    appearPack.move.pos = pack.pos;
                    mWildPlayerMgr.HandleUnitAppear(appearPack);
                }
            }
        }

        /// <summary>
        /// 响应网络消息
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="data"></param>
        protected virtual void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_NWAR_APPEAR:// aoi出现
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarAppear>(data);
                        mWildPlayerMgr.HandleUnitAppear(pack);
                    }
                    return;
                case NetMsg.MSG_NWAR_DISAPPEAR:// aoi消失
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarDisappear>(data);
                        mWildPlayerMgr.HandleUnitDisapper(pack);
                    }
                    return;
                case NetMsg.MSG_NWAR_NEW_VERSION:// aoi信息需要更新
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarNewVersion>(data);
                        mWildPlayerMgr.HandleUnitNewVersion(pack);
                    }
                    return;
                case NetMsg.MSG_NWAR_LOOK:// 查看详细aoi信息
                    {
                        var pack =  S2CPackBase.DeserializePack<S2CNwarLook>(data);
                        mWildPlayerMgr.HandleUnitLook(pack);
                    }
                    return;
                case NetMsg.MSG_NWAR_UNIT_REVIVE: // 复活成功
                    {
                        var msg = S2CPackBase.DeserializePack<S2CNwarUnitRevive>(data);
                        HandleUnitRevive(msg);
                    }
                    return;
                case NetMsg.MSG_NWAR_UNIT_DEAD: // 死亡消息
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarUnitDead>(data);

                        if (pack.id == Game.Instance.LocalPlayerID.obj_idx)
                        {
                            var local = Game.Instance.GetLocalPlayer();
                            if (local != null)
                                local.CurLife = 0;

                            // 自己死亡后清除掉其他所有玩家和怪物
                            //mWildPlayerMgr.ClearAllUnits();
                        }
                        else
                        {
                            mWildPlayerMgr.HandleUnitDead(pack);
                        }
                    }
                    return;
            }
        }
    }
}
