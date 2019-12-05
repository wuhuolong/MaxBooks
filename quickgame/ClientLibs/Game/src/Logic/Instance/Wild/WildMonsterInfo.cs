using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc.protocol;

namespace xc
{
    public class WildMonsterInfo : WildAoiInfo<PkgMonBrief>
    {
        /// <summary>
        /// 从AOI范围内进入时，角色身上带有的buff
        /// </summary>
        List<PkgKv> BuffList { get; set; }

        public WildMonsterInfo(uint uuid)
            : base(uuid)
        {
            
        }
        
        /// <summary>
        /// 实际创建Actor
        /// </summary>
        protected override void CreateActor()
        {
            base.CreateActor();
            
            Vector3 pos_born = Vector3.zero;
            if (AppearInfo != null)
            {
                var unit_scale = GlobalConst.UnitScale;
                var x = AppearInfo.pos.px * unit_scale;
                var z = AppearInfo.pos.py * unit_scale;
                pos_born = new Vector3(x, RoleHelp.GetHeightInScene(Info.actor_id, x, z), z);
            }

            var cache_info = ActorHelper.CreateUnitCacheInfo(Info, pos_born);
            
            ActorManager.Instance.PushUnitCacheData(cache_info);
        }
        
        protected override void UpdateAoiInfo(PkgMonBrief info)
        {
            // update hp...
            //Actor.ActorAttribute.Level = info.lv;
            if (Actor != null)
            {
                Actor.UpdateAOIAttrElement(info.attr_elm);
            }
        }
        
        public override void HandleActorCreate(Actor actor)
        {
            base.HandleActorCreate(actor);
            
            mActorUID = actor.UID;

            if (Actor == null)
            {
                return;
            }
            
            var monster = actor as Monster;
            monster.Color = (Monster.QualityColor)Info.color;
            monster.SetNameText();
            monster.CurLife = Info.hp; // 同步当前血量
            monster.AlwaysShowHpBar = true;
            //monster.SpartanMonsterGroupId = (int)Info.group_id;
            
            // 设置玩家坐标
            Actor.Stop();
            
            var unit_scale = GlobalConst.UnitScale;
            var x = AppearInfo.pos.px * unit_scale;
            var z = AppearInfo.pos.py * unit_scale;
            var pos = new Vector3(x, RoleHelp.GetHeightInScene(Actor.ActorId, x, z), z);
            //pos = InstanceHelper.ClampInWalkableRange(pos);
            
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
                Actor.MoveCtrl.ReceiveWalkBegin(AppearInfo);
        }
        
        public void HandleAppear(PkgNwarMove appear, List<PkgKv> buffs)
        {
            AppearInfo = appear;
            BuffList = buffs;

            if (Actor != null)
            {
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

                // Actor已经创建了，直接更新下就好
                Actor.MoveCtrl.ReceiveWalkBegin(appear);
                return;
            }
            
            // 怪物是不需要发送look的
            if (Info == null)
                return;
            
            if (IsInfoOutOfDate)
            {
                // 获取玩家信息
                SendUpdateInfo();
                return;
            }
            
            if (!mIsWaittingCreateActor)
                CreateActor();
        }
        
        protected override bool RemoveUnitCacheData(xc.UnitCacheInfo info)
        {
            return info.UnitID.obj_idx == UUID &&
                info.CacheType == xc.UnitCacheInfo.EType.ET_Create &&
                    info.UnitID.type == (byte)EUnitType.UNITTYPE_MONSTER;
        }
        
        protected override void SendUpdateInfo()
        {
            // 怪物不需要look
        }
        
        public override void HandleDead()
        {
            AppearInfo = null;
            Info = null;
            
            if (mIsWaittingCreateActor)
            {
                ActorManager.Instance.RemoveUnitCacheData(RemoveUnitCacheData);
                mIsWaittingCreateActor = false;
            }
        }
    }
}