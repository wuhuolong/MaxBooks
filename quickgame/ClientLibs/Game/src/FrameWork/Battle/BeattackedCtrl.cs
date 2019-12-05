using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class BeattackedCtrl : BaseCtrl
	{
        /// <summary>
        /// 上一次受击的攻击者的ID
        /// </summary>
        public uint LastAttackerId { get; set; }

		public BeattackedCtrl (Actor owner) : base(owner) 
		{
		}
		
		public static void RegisterAllMessage()
		{
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_HIT, HandleServerData); // 受击
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_THUNDER, HandleServerData); // 闪电链受击
			Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_UNIT_DEAD, HandleServerData);   // 死亡
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_SUB_HP, HandleServerData);  // buff减血
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_SUB_EN, HandleServerData); // buff加蓝
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_ADD_HP, HandleServerData); // buff加血
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_SKILL_SING, HandleServerData); //吟唱技能提前
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_IMMUNE, HandleServerData); //免疫飘字
            Game.Instance.SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_WORD, HandleServerData); //buff飘字效果
        }
		
		public static void HandleServerData(ushort protocol, byte[] data)
		{
			switch (protocol)
			{
                case NetMsg.MSG_NWAR_HIT:// 受击
                    {
                        var nwar_hit = S2CPackBase.DeserializePack<S2CNwarHit>(data);

                        var actor = ActorManager.Instance.GetPlayer(nwar_hit.hit.dst_id);
                        if (actor != null)
                            actor.BeattackedCtrl.HandleBeattacked(nwar_hit);
                    }
                    break;
                case NetMsg.MSG_NWAR_THUNDER:// 闪电链的伤害
                    {
                        var nwar_thunder = S2CPackBase.DeserializePack<S2CNwarThunder>(data);

                        SkillAttackInstance attac_inst = EffectManager.GetInstance().GetAttackInstance(nwar_thunder.em_id);
                        if (attac_inst != null)
                        {
                            ThunderHitInfo hit_info = new ThunderHitInfo();
                            hit_info.ActorID = nwar_thunder.act_id;
                            hit_info.EmitID = nwar_thunder.em_id;//伤害id
                            hit_info.SkillID = nwar_thunder.skill_id;// 技能id
                            hit_info.HitPlayers = nwar_thunder.uuids;//依次打到的玩家列表
                            hit_info.SkillAttackInst = attac_inst;

                            if(hit_info.Init())
                                attac_inst.SetThunderHitInfo(hit_info);
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_UNIT_DEAD://死亡
                    {
                        var death_msg = S2CPackBase.DeserializePack<S2CNwarUnitDead>(data);

                        var actor = ActorManager.Instance.GetPlayer(death_msg.id);
                        if (actor != null)
                            actor.BeattackedCtrl.HandleKillActor(death_msg);
                    }
                    break;
                case NetMsg.MSG_NWAR_BUFF_SUB_HP:// buff减血
                    {
                        var rep = S2CPackBase.DeserializePack<S2CNwarBuffSubHp>(data);
                        Actor act = ActorManager.Instance.GetPlayer(rep.uuid);
                        if (act != null && !act.IsDead())
                        {
                            act.DoDamage(rep.act_id, (int)rep.hp, 0f, false, 0);
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_BUFF_SUB_EN:// buff减蓝
                    {

                    }
                    break;
                case NetMsg.MSG_NWAR_BUFF_ADD_HP:// buff加血
                    {
                        var rep = S2CPackBase.DeserializePack<S2CNwarBuffAddHp>(data);
                        Actor act = ActorManager.Instance.GetPlayer(rep.uuid);
                        if (act != null && !act.IsDead() && act.IsLocalPlayer)
                        {
                            act.ShowDamageEffect(FightEffectHelp.FightEffectType.AddHp, rep.act_id, (int)rep.hp);
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_SKILL_SING: //结束吟唱阶段
                    {
                        var rep = S2CPackBase.DeserializePack<S2CNwarSkillSing>(data);
                        Actor act = ActorManager.Instance.GetPlayer(rep.uuid);
                        if (act != null && !act.IsDead() && act.IsLocalPlayer == false)
                        {
                            Skill skill = act.GetCurSkill();
                            if (skill != null && skill.SkillID == rep.skill_id)
                            {
                                if(skill.CurAction != null)
                                    skill.CurAction.FinishCastingReadyStage();
                            }
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_BUFF_IMMUNE: //免疫飘字
                    {
                        var rep = S2CPackBase.DeserializePack<S2CNwarBuffImmune>(data);
                        Actor defender = ActorManager.Instance.GetActor(rep.uuid);
                        if(defender != null)
                        {
                            defender.ShowDamageEffect(FightEffectHelp.FightEffectType.Immune, rep.act_id, 0);
                        }
                    }
                    break;
                case NetMsg.MSG_NWAR_BUFF_WORD: //buff飘字效果
                    {
                        var rep = S2CPackBase.DeserializePack<S2CNwarBuffWord>(data);
                        var word_id = rep.word;
                        string word = DBFlyWord.GetFlyWordById(word_id);
                        if(word != "")
                        {
                            UINotice.Instance.ShowMessage(word);
                        }
                    }
                    break;
                default:
				break;
			}
		}
           
        public void KillSelf()
		{
			mOwner.CurLife = 0;

            if(mOwner.IsDead() == false)
            {
                mOwner.ActorMachine.DeathFlyInfo = new ActorMachine.DeathInfo();
                mOwner.Kill();
            }
		}

        /// <summary>
        /// 在当前AOI中丢失的玩家ID
        /// </summary>
        UnitID mMissUID = new UnitID(0, 0);

        /// <summary>
        /// 响应受击消息
        /// </summary>
        /// <param name="beattackMsg"></param>
        void HandleBeattacked(S2CNwarHit beattackMsg)
		{
			if (!mIsRecvMsg)
				return;

            DBSkillSev.SkillInfoSev skillInfo = DBSkillSev.Instance.GetSkillInfo(beattackMsg.hit.skill_id);
            if(skillInfo == null)
            {  
                GameDebug.LogError(string.Format("[HandleBeattacked]Skill ID:{0} info is null",beattackMsg.hit.skill_id));
                return;
            }

            Damage dmg = new Damage();
            uint src_id = beattackMsg.hit.act_id;
            Actor actor = ActorManager.Instance.GetPlayer(beattackMsg.hit.act_id);

            // 本地玩家受击，攻击者在角色列表中找不到的时候，需要给服务端发送look消息(目前AOI有bug)
            if (actor == null && mOwner != null && mOwner.IsLocalPlayer)
            {
                mMissUID.obj_idx = beattackMsg.hit.act_id;
                var cacheInfo = ActorManager.Instance.GetUnitCacheInfo(mMissUID);
                if (cacheInfo == null)
                {
                    var sendLookFix = new C2SNwarLookFix();
                    sendLookFix.uuid = beattackMsg.hit.act_id;
                    NetClient.GetCrossClient().SendData<C2SNwarLookFix>(NetMsg.MSG_NWAR_LOOK_FIX, sendLookFix);
                }
            }

            if (beattackMsg.hit.ori_type == GameConst.SKILL_ORI_PET)
            {
                if (actor != null)
                {
                    Player player = actor as Player;
                    if (player != null && player.CurrentPet != null)
                    {
                        src_id = player.CurrentPet.obj_idx;
                    }
                }
            }
            
            dmg.SrcID = src_id;
            dmg.TargetID = beattackMsg.hit.dst_id;
            dmg.SkillID = beattackMsg.hit.skill_id;
            dmg.BeattackState = Damage.EBeattackState.BS_BendBack;
            dmg.DamageEffectType = beattackMsg.hit.hit_type;
            dmg.DamageValue = (int)beattackMsg.hit.dmg;
            dmg.DamageSpecs = new Dictionary<uint, int>(beattackMsg.hit.specs.Count);
            foreach (var spec in beattackMsg.hit.specs)
            {
                dmg.DamageSpecs.Add(spec.k , (int)spec.v);
            }
			
            SkillAttackInstance inst = EffectManager.GetInstance().GetAttackInstance(beattackMsg.hit.em_id);
            if(inst != null)
            {
                inst.AddHurtInfo(dmg);
            }
            else
            {
                dmg.HitEffect();
            }

            LastAttackerId = beattackMsg.hit.act_id;
        }

        /// <summary>
        /// 显示未命中时候的效果
        /// </summary>
        public static void ShowDamageEffect(Damage dmg, uint effectType, int value = 0)
        {
            var damageEffects = DBDamageEffect.GetInstance().DamagetEffects;
            using (var enumer = damageEffects.GetEnumerator())
            {
                while(enumer.MoveNext())
                {
                    var info = enumer.Current.Value;

                    // 从DBDamageEffect配表中获取匹配的特殊伤害类型
                    if ((effectType & info.ID) != 0)
                    {
                        FightEffectHelp.FightEffectType type = FightEffectHelp.GetFightEffectTypeByDamageEffect((Damage.EDamageEffect)info.ID);

                        if (info.Target == DBDamageEffect.EffectTarget.ET_DEST)
                        {
                            var targer_actor = dmg.target;
                            if (targer_actor != null)
                                targer_actor.ShowDamageEffect(type, dmg.SrcID, value);
                        }
                        else if (info.Target == DBDamageEffect.EffectTarget.ET_SRC)
                        {
                            var src_actor = dmg.src;
                            if (src_actor != null)
                            {
                                if (type == FightEffectHelp.FightEffectType.OneHitKill)
                                    continue;
                                src_actor.ShowDamageEffect(type, dmg.SrcID, value);
                            }
                        }
                    }
                }
            }
        }

        void HandleKillActor(S2CNwarUnitDead kDeathMsg)
		{
			if (!mIsRecvMsg)
				return;

            bool has_trigger = false;
            SkillAttackInstance inst = EffectManager.GetInstance().GetAttackInstance(kDeathMsg.em_id);
            if(inst != null)
            {
                // 需要从伤害信息中获取攻击者（此处要求服务端的伤害消息一定在死亡消息之前发送）
                Actor src = ActorManager.Instance.GetActor(inst.SrcActorID);
                if(src != null && src.Trans != null && mOwner.Trans != null)
                {
                    has_trigger = true;

                    Vector3 vec = mOwner.Trans.position - src.Trans.position;
                    vec.y = 0;
                    vec.Normalize();
                    // 设置击飞方向信息
                    SkillAttackInstance.DeathAppendInfo info = new SkillAttackInstance.DeathAppendInfo();
                    info.Id = kDeathMsg.id;
                    info.FlyDir = vec;
                    inst.AddDeathInfo(info);
                }
            }

            if(has_trigger == false)
            {
                mOwner.ActorMachine.DeathFlyInfo = new ActorMachine.DeathInfo();
                mOwner.Kill();
            }
        }
	}
}

