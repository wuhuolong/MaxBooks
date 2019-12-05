using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc.protocol;

namespace xc
{
    /// <summary>
    /// 野外玩家信息
    /// </summary>
    public class WildPlayerInfo : WildAoiInfo<PkgPlayerBrief>
    {
        public static uint PLAYER_RIVIVE_CD = 20;

        public float DeadTime { get; private set; }
        public bool IsDead { get { return DeadTime > 0f; } }
        public bool IsDeadForALongTime
        {
            get
            {
                if (!IsDead)
                    return false;

                return (Time.realtimeSinceStartup - DeadTime) > PLAYER_RIVIVE_CD;
            }
        }

        /// <summary>
        /// 从AOI范围内进入时，角色身上带有的buff
        /// </summary>
        List<PkgKv> BuffList{ get; set; }

        /// <summary>
        /// 出生的标识
        /// </summary>
        uint AppearBit { get; set; }

        public WildPlayerInfo(uint uuid)
            : base(uuid)
        {

        }

        protected override bool IsInfoOutOfDate
        {
            get
            {
                if (LastUpdateTime == null)
                    return true;

                var now = Game.GetInstance().GetServerDateTime();
                return (now - LastUpdateTime).TotalSeconds >= 60 * 5;
            }
        }

        public static List<uint> WaittingLookExtList = new List<uint>();

        /// <summary>
        /// 实际创建Actor
        /// </summary>
        protected override void CreateActor()
        {
            base.CreateActor();

            // 位置这里先填Vector3.zero，等创建好之后再直接设置其移动信息
            ActorManager.Instance.PushUnitCacheData(ActorHelper.CreateUnitCacheInfo(Info, Vector3.zero));
        }

        /// <summary>
        /// 更新AOI的数据
        /// </summary>
        /// <param name="info"></param>
        protected override void UpdateAoiInfo(PkgPlayerBrief info)
        {
            if (Actor == null)
            {
                return;
            }

            Actor.ActorAttribute.State = info.state;

            List<uint> model_list = new List<uint>();
            List<uint> fashion_list = new List<uint>();
            ActorHelper.GetModelFashionList(info.shows, model_list, fashion_list);
            Actor.mAvatarCtrl.ChangeFacade(model_list, fashion_list, info.effects, Actor.VocationID);

            if (info.guild != null)
            {
                Actor.ActorAttribute.GuildId = info.guild.guild_id;
                Actor.ActorAttribute.GuildName = System.Text.Encoding.UTF8.GetString(info.guild.guild_name);
            }
            else
            {
                Actor.ActorAttribute.GuildId = 0;
                Actor.ActorAttribute.GuildName = "";
            }

            Actor.ActorAttribute.Honor = info.honor;
            Actor.ActorAttribute.Title = info.title;
            Actor.ActorAttribute.TransferLv = info.transfer;
            Actor.UpdateNameColor(info.name_color);
            Actor.MateInfo = info.mate;
            Actor.SetNameText();
            Actor.ActorAttribute.BattlePower = info.battle_power;
            Actor.ActorAttribute.Level = info.level;

            uint oldEscortId = Actor.ActorAttribute.EscortId;

            if (info.war != null)
            {
                Actor.ActorAttribute.TeamId = info.war.team_id;
                Actor.ActorAttribute.EscortId = info.war.escort_id;

                //Actor.PKLvProtect = Info.war.pk_lv_protect;
                if (Actor != null)
                {
                    Actor.UpdateAOIAttrElement(info.war.attr_elm);
                }

                Actor.UpdateByBitState(Info.bit_states);
                Actor.SetHeadIcons(Actor.EHeadIcon.TEAM);
                if (Actor is Player)
                {
                    (Actor as Player).UpdatePetId(info.war.pet_skin);
                }
            }
            else
            {
                Actor.ActorAttribute.TeamId = 0;
                Actor.ActorAttribute.EscortId = 0;
            }
            Actor.SetHeadIcons(Actor.EHeadIcon.PEAK);

            // 远程玩家的护送npc暂时屏蔽掉
            //Player player = Actor as Player;
            //if (player != null)
            //{
            //    if (oldEscortId != Actor.ActorAttribute.EscortId)
            //    {
            //        player.UpdateEscortNPC();
            //    }
            //}

            Actor.MountId = info.ride;
        }

        /// <summary>
        /// 处理actor创建成功
        /// </summary>
        /// <param name="actor"></param>
        public override void HandleActorCreate(Actor actor)
        {
            base.HandleActorCreate(actor);

            mActorUID = actor.UID;

            if (Actor == null)
            {
                return;
            }

            // 设置玩家坐标
            Actor.Stop();

            if (AppearInfo == null)
            {
                GameDebug.LogError("HandleActorCreate AppearInfo == null, uuid = " + UUID);
                return;
            }

            var unit_scale = GlobalConst.UnitScale;
            var x = AppearInfo.pos.px * unit_scale;
            var z = AppearInfo.pos.py * unit_scale;
            var pos = new Vector3(x, RoleHelp.GetHeightInScene(Actor.ActorId, x, z), z);
            //pos = InstanceHelper.ClampInWalkableRange(pos);

            Actor.transform.position = pos;

            // 进入AOI视野增加buff
            if(BuffList != null)
            {
                uint server_time = Game.Instance.ServerTime;
                for (int i = 0; i < BuffList.Count; ++i)
                {
                    uint end_time = (uint)(BuffList[i].v / 1000);
                    uint second = 1;
                    if (end_time > server_time)
                        second = end_time - server_time;
                    //GameDebug.LogError(string.Format("servertime = {0} BuffList[i].v = {1} second = {2}", server_time, end_time, second));
                    Actor.BuffCtrl.AddBuff(BuffList[i].k, second);
                }
            }

            if (FlagOperate.HasFlag(AppearBit, GameConst.APPEAR_BIT_IS_DEAD))// 初始就是死亡状态
            {
                if (!Actor.IsDead())
                    Actor.BeattackedCtrl.KillSelf();
            }
            else
            {
                if (Actor.IsDead())
                    Actor.Relive();
            }

            if (AppearInfo.speed > 0)
                Actor.MoveCtrl.ReceiveWalkBegin(AppearInfo);

            if (Info == null)
            {
                GameDebug.LogError("HandleActorCreate Info == null, uuid = " + UUID);
                return;
            }

            if (Info.war != null)
            {
                foreach (PkgAttrElm attrElm in Info.war.attr_elm)
                {
                    if(attrElm.attr == GameConst.AR_MAX_HP)
                    {
                        Actor.FullLife = attrElm.value;
                    }
                    else if(attrElm.attr == GameConst.AR_MAX_MP)
                    {
                        Actor.FullMp = attrElm.value;
                        Actor.CurMp = Actor.FullMp; // 初始化时将蓝量加满
                    }
                }
                    
                Actor.CurLife = Info.war.hp;
                // 进入AOI视野增加buff
                /*for(int i = 0; i < Info.war.buffs.Count; ++i)
                {
                    Actor.AuraCtrl.AddAura(Info.war.buffs[i].k);
                }*/
            }

            Actor.SubscribeActorEvent(Actor.ActorEvent.DEAD, OnActorDead);
            Actor.UpdateNameColor(Info.name_color);
            if (Info.war != null)
            {
                //Actor.PKLvProtect = Info.war.pk_lv_protect;
                Actor.UpdateByBitState(Info.bit_states);
            }

            WaittingLookExtList.Add(UUID);
        }

        private void OnActorDead(CEventBaseArgs evt)
        {
            DeadTime = Time.realtimeSinceStartup;
        }

        protected override bool RemoveUnitCacheData(xc.UnitCacheInfo info)
        {
            return info.UnitID.obj_idx == UUID && 
                info.CacheType == xc.UnitCacheInfo.EType.ET_Create &&
                info.UnitID.type == (byte)EUnitType.UNITTYPE_PLAYER;
        }

        public void HandleAppear(PkgNwarMove appear, uint version, List<PkgKv> buffs, uint appear_bit)
        {
            DeadTime = 0f;

            var redundancy_appear = false;

            if (AppearInfo != null)
                redundancy_appear = true;

            AppearInfo = appear;
            BuffList = buffs;
            AppearBit = appear_bit;

            if (Actor != null)
            {
                if (FlagOperate.HasFlag(appear_bit, GameConst.APPEAR_BIT_IS_DEAD))// 初始就是死亡状态
                {
                    if (!Actor.IsDead())
                        Actor.BeattackedCtrl.KillSelf();
                }
                else
                {
                    if (Actor.IsDead())
                        Actor.Relive();
                }

                // Actor已经创建了，直接更新下就好
                var unit_scale = GlobalConst.UnitScale;
                var x = AppearInfo.pos.px * unit_scale;
                var z = AppearInfo.pos.py * unit_scale;
                var pos = new Vector3(x, RoleHelp.GetHeightInScene(Actor.ActorId, x, z), z);

                Actor.transform.position = pos;

                // 进入AOI视野增加buff
                if (BuffList != null)
                {
                    uint server_time = Game.Instance.ServerTime;
                    for (int i = 0; i < BuffList.Count; ++i)
                    {
                        uint end_time = (uint)(BuffList[i].v / 1000);
                        uint second = 1;
                        if (end_time > server_time)
                            second = end_time - server_time;
                        //GameDebug.LogError(string.Format("servertime = {0} BuffList[i].v = {1} second = {2}", server_time, end_time, second));
                        Actor.BuffCtrl.AddBuff(BuffList[i].k, second);
                    }
                }

                if (AppearInfo.speed > 0)
                    Actor.MoveCtrl.ReceiveWalkBegin(appear);

                // version有变化的时候更新缓存
                if (Info != null && Info.version != version)
                {
                    SendUpdateInfo();
                }

                return;
            }

            // 如果已经appear过了，不要再处理了
            if (redundancy_appear)
                return;

            if (Info == null || IsInfoOutOfDate || Info.version != version)
            {
                // 获取玩家信息
                SendUpdateInfo();
                return;
            }

            if (!mIsWaittingCreateActor)
                CreateActor();
        }

        public void HandleNewVersion()
        {
            if (Info != null)
            {
                // 获取玩家信息
                SendUpdateInfo();
            }
        }

        public override void HandleDead()
        {
        }
    }
}
