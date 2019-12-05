//------------------------------------------------------------------------------
// File ： AttackCtrl.cs
// Desc ： 控制角色进行技能释放的类
// Author : raorui 
// Date : 2016.9.21 Comments
//------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;


using Net;
using xc.Maths;
using xc.protocol;
using Utils;
using xc.Dungeon;

namespace xc
{
    [wxb.Hotfix]
    public class AttackCtrl : BaseCtrl
	{
        public bool IsUseMP = true;// 是否耗蓝
        public bool IsUseCD = true;// 是否有cd
        public uint LastSkillID;// 在走到攻击范围内再进行释放的技能
		protected uint m_NextSkill = 0xffffffff;

        /// <summary>
        /// 上一次攻击的目标的ID
        /// </summary>
        public uint LastTargetId { get; set; }

        public static bool IsFireSkillEvent = false;// 释放技能时，是否有消息出发（给新手引导使用）
        /// <summary>
        /// 注册所有网络消息
        /// </summary>
        public static void RegisterAllMessage()
		{
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_SKILL, HandleServerData);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_SKILL_TRIGGERED, HandleServerData); 
        }
		
        /// <summary>
        /// 构造函数中进行初始化
        /// </summary>
		public AttackCtrl (Actor owner):base(owner)
		{
            // 本地玩家需要响应的消息
            if(mOwner.IsLocalPlayer)
            {
                ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKMONSTER, OnClickTarget);
                ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CLICKPLAYER, OnClickTarget);
                ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CHANGE_LOCKTARGET, OnClickChangeTarget);
                mOwner.SubscribeActorEvent(Actor.ActorEvent.REACH_TARGET, OnReachTarget);
                mOwner.SubscribeActorEvent(Actor.ActorEvent.SHAPE_SHIFT, OnShapeShift);

                ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LEAVEAOI, OnLeaveAOI);
            }
		}	

        /// <summary>
        /// 析构函数
        /// </summary>
        public override void Destroy()
        {
            m_cachekMsg = null;
            m_is_exchange_mount_to_battle_processing = false;
            if (mOwner.IsLocalPlayer)
            {
                ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CLICKMONSTER, OnClickTarget);
                ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CLICKPLAYER, OnClickTarget);
                ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CHANGE_LOCKTARGET, OnClickChangeTarget);

                mOwner.UnsubscribeActorEvent(Actor.ActorEvent.REACH_TARGET, OnReachTarget);
                mOwner.UnsubscribeActorEvent(Actor.ActorEvent.SHAPE_SHIFT, OnShapeShift);

                ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_LEAVEAOI, OnLeaveAOI);
            }  

            base.Destroy();
        }

        /// <summary>
        /// 响应网络消息
        /// </summary>
		public static void HandleServerData(ushort protocol, byte[] data)
		{
			switch(protocol)
			{
                case NetMsg.MSG_NWAR_SKILL: // 释放技能的消息
                    {
                        S2CNwarSkill nwar_skill = S2CPackBase.DeserializePack<S2CNwarSkill>(data);

                        // 获取技能释放者
                        Actor actor = ActorManager.Instance.GetPlayer(nwar_skill.uuid);
                        if (actor == null)
                            return;

                        Actor target = FirstTarget(nwar_skill.target_ids);

                        // 服务端会把自己发送的消息也转发回来

                        // 技能释放者是本地玩家
                        if (actor.IsLocalPlayer)
                        {
                            // 本地玩家魔仆技能的处理
                            if (nwar_skill.ori_type == GameConst.SKILL_ORI_PET)
                            {
                                Player player = actor as Player;
                                if (player != null && player.CurrentPet != null)
                                {
                                    var pet_actor = ActorManager.Instance.GetActor(player.CurrentPet.obj_idx);
                                    if(pet_actor != null)
                                        BulletAction(nwar_skill.em_id, nwar_skill.skill_id, pet_actor, target);
                                }
                            }
                            // 本地玩家技能的处理
                            else
                            {
                                BulletAction(nwar_skill.em_id, nwar_skill.skill_id, actor, target);
                            }
                        }
                        // 技能释放者非本地玩家
                        else
                        {
                            // 其他玩家魔仆技能的处理
                            if (nwar_skill.ori_type == GameConst.SKILL_ORI_PET)
                            {
                                Player player = actor as Player;
                                if (player != null && player.CurrentPet != null)
                                {
                                    var pet_actor = ActorManager.Instance.GetActor(player.CurrentPet.obj_idx);
                                    if (pet_actor != null)
                                    {
                                        pet_actor.AttackCtrl.HandleSkillStart(nwar_skill);
                                        BulletAction(nwar_skill.em_id, nwar_skill.skill_id, pet_actor, target);// BulletAction中用到了AttackSpeed,要放到HandleSkillStart之后
                                    }
                                }
                            }
                            // 其他玩家技能的处理
                            else
                            {
                                // 本地玩家召唤出来的怪物
                                if (actor.ParentActor != null && actor.ParentActor.IsLocalPlayer)
                                {
                                    BulletAction(nwar_skill.em_id, nwar_skill.skill_id, actor, target);
                                }
                                // 其他玩家和怪物
                                else
                                {
                                    actor.AttackCtrl.HandleSkillStart(nwar_skill);
                                    BulletAction(nwar_skill.em_id, nwar_skill.skill_id, actor, target);// BulletAction中用到了AttackSpeed,要放到HandleSkillStart之后
                                }
                            }
                        }
                    }break;
                case NetMsg.MSG_NWAR_SKILL_TRIGGERED: // 触发类技能的消息
                    {
                        var nwar_skill_trigger = S2CPackBase.DeserializePack<S2CNwarSkillTriggered>(data);

                        // 获取技能喊话的文字
                        var skill_info = DBSkillSev.Instance.GetSkillInfo(nwar_skill_trigger.skill_id);
                        string skill_annouce = skill_info.SkillAnnounce;
                        if (string.IsNullOrEmpty(skill_annouce) == false)
                        {
                            // 获取技能释放者
                            var attack_actor = ActorManager.Instance.GetPlayer(nwar_skill_trigger.act_id);
                            if (attack_actor == null)
                                return;

                            // 替换技能释放者的名字
                            skill_annouce = skill_annouce.Replace("[NAME]", attack_actor.Name);

                            // 替换目标玩家的名字
                            var beattack_actor = ActorManager.Instance.GetPlayer(nwar_skill_trigger.tar_id);
                            if (beattack_actor != null)
                            {
                                if (beattack_actor.IsPlayer())
                                    skill_annouce = skill_annouce.Replace("[name]", beattack_actor.UserName);
                                else
                                    skill_annouce = skill_annouce.Replace("[name]", beattack_actor.Name);
                            }
                            UINotice.Instance.ShowWarnning(skill_annouce);
                        }
                    }
                    break;
                default:
				break;
			}
		}

        static Actor FirstTarget(List<uint> target_ids)
        {
            Actor target = null;
            if(target_ids.Count > 0)
            {
                UnitID uid = new UnitID();
                uid.obj_idx = target_ids[0];
                uid.type = (byte)EUnitType.UNITTYPE_PLAYER;
                target = ActorManager.Instance.GetActor(uid);
            }

            return target;
        }

        static void BulletAction(uint emitterId,uint skillid,Actor src, Actor target)
        {
            DBSkillSev.SkillInfoSev skillInfo = DBSkillSev.Instance.GetSkillInfo(skillid);
            if(skillInfo != null)
            {
                if(src != null && src.Trans != null && src.GetActorMono() != null)
                {
                    if(skillInfo.BulletTrace != null && skillInfo.Target != "thunder")// 子弹类型(闪电链通过特殊协议处理)
                    {
                        // 子弹类型的技能要求必须要有目标角色
                        if(target != null && target.GetActorMono() != null)
                            skillInfo.BulletTrace.Do(emitterId, src.GetActorMono(), target.GetActorMono(), false, src.Trans.position, src.Trans.rotation, src.Trans.forward, null);
                        else
                        {
                            // 前摇时间
                            if (skillInfo.BattleFxInfo != null)
                            {
                                float delayTime = skillInfo.BattleFxInfo.HitDelayTime;

                                SkillAttackInstance skillAttackInstance = new SkillAttackInstance();
                                skillAttackInstance.Init(emitterId, src.UID, skillInfo, delayTime, delayTime + 30.0f, src.AttackSpeed, null, null);
                                //加到管理器
                                EffectManager.GetInstance().AddSkillInstance(emitterId, skillAttackInstance);
                            }
                        }
                    }
                    else
                    {
                        // 前摇时间
                        if(skillInfo.BattleFxInfo != null)
                        {
                            float delayTime = skillInfo.BattleFxInfo.HitDelayTime;
                            if(delayTime != 0)
                            {
                                SkillAttackInstance skillAttackInstance = new SkillAttackInstance();;
                                skillAttackInstance.Init(emitterId, src.UID, skillInfo, delayTime, delayTime + 30.0f, src.AttackSpeed, null, null);
                                //加到管理器
                                EffectManager.GetInstance().AddSkillInstance(emitterId, skillAttackInstance);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 检查攻击范围，如果在攻击范围外则走近目标
        /// </summary>
        bool CheckAttackRange(uint skill_id, float skill_range, Vector3 target_pos, bool force_stop = false)
        {
            // 设置技能范围内最近的目标位置
            Vector3 target_vec = target_pos - mOwner.Trans.position;
            float target_len = target_vec.magnitude;
            if (target_len > skill_range && (target_len - skill_range) > 0.5f)
            {
                // 需要走到角色面前
                target_pos = mOwner.Trans.position + target_vec * (target_len - skill_range) / target_len;
                XNavMeshHit nesrestHit;
                if (XNavMesh.SamplePosition(target_pos, out nesrestHit, 5.0f, LevelManager.GetInstance().AreaExclude))
                {
                    target_pos = nesrestHit.position;
                }

                LastSkillID = skill_id;
                if(force_stop)
                    mOwner.Stop();// 寻路前线退出攻击状态
                m_WalkId = mOwner.MoveCtrl.TryWalkToAlong(target_pos);
                //GameDebug.Log("Approach to target");
                return false;
            }

            return true;
        }

        public bool IsInSkillActionEndingStage()
        {
            Skill current_skill = mOwner.GetCurSkill();
            if (current_skill == null)
                return false;
            return current_skill.IsInSkillActionEndingStage();
        }

        int m_WalkId = 0;

        /// <summary>
        /// 使用指定的技能进行攻击
        /// </summary>
        /// <param name="skill_id">战斗表中的id</param>
        /// <param name="is_manual">是否是由ai触发的</param>
        /// <returns></returns>
		public bool Attack(uint skill_id, bool is_ai_trigger = false)
		{	
			if (skill_id == 0xffffffff)
				return false;
			
            if (!mOwner.FSM.CanReact((uint)ActorMachine.EFSMEvent.DE_NormalAttack) || IsAttackDisable(skill_id))
				return false;

			Skill current_skill = mOwner.GetCurSkill();
			Skill target_skill = mOwner.GetSelfSkill(skill_id);
			if(target_skill == null)
			{
				GameDebug.LogError("TargetSkill is null");
                return false;
			}

			bool attack_succ = false;
            if (current_skill == null)
            {
                if (IsSkillCanCast(target_skill, 0))
                {
                    Actor target = null;
                    uint find_target_type = 0;
                    if (mIsSendMsg && IsFindTarget(target_skill, 0, ref find_target_type))
                    {
                        bool show_tips = false;
                        if(find_target_type == 2)
                        {
                            target = mOwner.ParentActor;
                        }
                        else
                            target = FindTarget(target_skill, out show_tips);
                        if (target == null)
                        {
                            if (show_tips)
                            {
                                // 自动战斗状态不显示这个提示
                                if (InstanceManager.Instance.IsAutoFighting == false && mOwner != null && mOwner.IsLocalPlayer)
                                {
                                    UINotice.GetInstance().ShowMessage_showMaxOne(DBConstText.GetText("TARGET_LOST"));
                                    //UINotice.GetInstance().ShowMessage(DBConstText.GetText("TARGET_LOST"));
                                }
                            }
                            return false;
                        }
                        else
                        {
                            // 设置技能范围内最近的目标位置
                            Vector3 target_pos = target.Trans.position;
                            float skill_range = target_skill.GetAction(0).ActionData.SkillInfo.Range;
                            if (CheckAttackRange(skill_id, skill_range, target_pos) == false)// 不在攻击范围内，因为有缓存技能ID，所以也算成功
                                return true;
                        }
                    }

                    if(mIsSendMsg)
                    {
                        if (Owner.IsLocalPlayer)
                        {
                            if (Owner.mRideCtrl != null && Owner.mRideCtrl.IsRiding())
                            {//正在骑乘
                                Owner.mRideCtrl.UnRide(true);//下马
                                Owner.OnBattleTrigger();
                                m_is_exchange_mount_to_battle_processing = true;
                                LastSkillID = skill_id;
                                return true;
                            }
                            else if (Owner.mRideCtrl != null && Owner.mRideCtrl.Rider != null)
                            {
                                m_is_exchange_mount_to_battle_processing = true;
                                LastSkillID = skill_id;
                                return true;
                            }
                        }
                    }
                    // 开始攻击
                    if (mOwner.IsWalking())
                    {
                        mOwner.MoveCtrl.SendWalkEnd();
                    }

                    // 为了给连续自动释放功能提供初始数据，这里在范围内的攻击也需要保存
                    LastSkillID = skill_id;
                    if (mOwner.Attack(skill_id))
                    {
                        AttackAction(0, target);
                        attack_succ = true;
                    }
                    else
                        attack_succ = false;
                }
                else
                {
                    ShowMessage();
                    attack_succ = false;
                }

                m_NextSkill = 0xffffffff;
            }
            else if (current_skill.IsCanCacheNext())
            {
                if (m_NextSkill == 0xffffffff || is_ai_trigger == false) // 本次是手动触发的技能才能覆盖上次缓存的技能
                {
                    if(mOwner.IsLocalPlayer && GameInput.Instance.IsInput)// 如果是本地玩家，并且正在移动，则不缓存技能
                    {
                        attack_succ = false;
                    }
                    else
                    {
                        m_NextSkill = skill_id;
                        attack_succ = true;//因为有缓存技能ID，所以也算成功
                    }
                }
                else
                    attack_succ = false;

            }
            else
                attack_succ = false;

            return attack_succ;
		}
		
        /// <summary>
        /// 响应本地玩家到达目标点的消息
        /// </summary>
        /// <param name="data"></param>
        public void OnReachTarget(CEventBaseArgs data)
        {
            int walk_id = (int)data.arg;
            if (walk_id != m_WalkId)
                return;

            //GameDebug.Log("Reach Target, Attack: " + LastSkillID);
            mOwner.Stop();
            Attack(LastSkillID);
        }

        /// <summary>
        /// 变身前先恢复动画的播放速度
        /// </summary>
        /// <param name="data"></param>
        void OnShapeShift(CEventBaseArgs data)
        {
            mOwner.SetAnimationSpeed(1.0f);
        }

        public void ClearCacheSkill()
		{
            m_NextSkill = 0xffffffff;
		}

        /// <summary>
        /// 手动选中的角色
        /// </summary>
        List<ActorMono> mSelectedActors = new List<ActorMono>();
        ActorMono m_CurSelectActor;
        ActorMono mCurSelectActor
        {
            get { return m_CurSelectActor; }
        }
        bool m_isHandleSelectActor;   //是否是手动选中的目标
        bool m_isPrepearAutoSelectActor;    //是否是预备自动选择的目标
        public void SetCurSelectActor(ActorMono new_actorMono, bool var_isHandleSelct = false, bool var_isPrepearAutoSelect = false)
        {
            m_CurSelectActor = new_actorMono;
            m_isHandleSelectActor = var_isHandleSelct;
            m_isPrepearAutoSelectActor = var_isPrepearAutoSelect;
        }

        /// <summary>
        /// 选中怪物显示的特效
        /// </summary>
        GameObject mSelectActorEffect;

        bool mIsLoadingSelectActorEffect = false;   //正在加载“选中怪物显示的特效”

        /// <summary>
        /// 点击到玩家\怪物上时，需要切换攻击目标
        /// </summary>
        void OnClickTarget(CEventBaseArgs data)
        {
            GameObject selectedObj = (GameObject)data.arg;
            if(selectedObj != null)
            {
                ActorMono act_mono = ActorHelper.GetActorMono(selectedObj);
                if(act_mono != null)
                {
                    if(act_mono.BindActor.IsDead() || act_mono.BindActor.CanBeChoosed() == false || act_mono.BindActor.CanBeHited() == false)
                        return;

                    // 召唤怪不能作为攻击目标
                    Monster monster = act_mono.BindActor as Monster;
                    if (monster != null && (monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_PLAYER || monster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_ROBOT))
                    {
                        return;
                    }

                    SetCurSelectActor(act_mono, true, false);
                    mSelectedActors.Clear();
                    mSelectedActors.Add(act_mono);
                    SetSelectEffect();
                }
            }
        }

        /// <summary>
        /// 当选择目标的特效已经加载完毕
        /// </summary>
        void OnEffectResLoad(GameObject effectObject, Transform parentTrans)
        {
            mIsLoadingSelectActorEffect = false;
            if (mCurSelectActor == null)
            {
                return;
            }

            mSelectActorEffect = effectObject;
            if(mSelectActorEffect != null && parentTrans != null)
            {
                Transform selectTrans = mSelectActorEffect.transform;
                selectTrans.parent = parentTrans;
                selectTrans.localPosition = new Vector3(0, 0.1f, 0);

                var scale = MoveImpl.mDefaultCharacterRadius;
                // 如果模型还没加载好，就使用默认的半径
                if (mCurSelectActor.BindActor.IsResLoaded == true)
                {
                    scale = mCurSelectActor.BindActor.MoveImplement.CharacterRadius / MoveImpl.mDefaultCharacterRadius;
                }
                selectTrans.localScale = new Vector3(scale, scale, scale);

                // 先隐藏再显示是用于播放动画特效，而无需知道美术动画挂载点
                mSelectActorEffect.SetActive(false);
                mSelectActorEffect.SetActive(true);

                // 设置层级是为了播放剧情的时候方便隐藏这个特效
                xc.ui.ugui.UIHelper.SetLayer(selectTrans, LayerMask.NameToLayer("Monster"));
            }
        }

        /// <summary>
        /// 设置选中目标的特效
        /// </summary>
        void SetSelectEffect()
        {
            // 非主角不能有选中目标的效果
            if ((mOwner is LocalPlayer) == false)
            {
                return;
            }

            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, new CEventBaseArgs(mCurSelectActor));
            if(mCurSelectActor == null)
            {
                if (mSelectActorEffect != null)
                {
                    mSelectActorEffect.SetActive(false);
                }
                return;
            }

            if (mCurSelectActor.BindActor != null)
            {
                if (ActorHelper.GetIsHideSelectEffect(mCurSelectActor.BindActor.ActorId) == true)
                {
                    return;
                }

                Transform parentTrans = mCurSelectActor.BindActor.Trans;
                if(parentTrans != null)
                {
                    if (mSelectActorEffect == null)
                    {
                        if (mIsLoadingSelectActorEffect == false)
                        {
                            mIsLoadingSelectActorEffect = true;
                            EffectManager.GetInstance().GetEffectEmitter("Effects/Prefabs/EF_SelectActor.prefab").CreateInstance(x => OnEffectResLoad(x));
                        }
                    } 
                    else
                        OnEffectResLoad(mSelectActorEffect, parentTrans);
                }
            }
        }

        void OnEffectResLoad(GameObject effectObject)
        {
            if (mCurSelectActor != null && mCurSelectActor.BindActor != null)
            {
                Transform parentTrans = mCurSelectActor.BindActor.Trans;
                if (parentTrans != null)
                {
                    OnEffectResLoad(effectObject, parentTrans);
                    return;
                }
            }
            OnEffectResLoad(effectObject, null);
        }
        private uint mMaxSelectCount;
        private uint MaxSelectCout
        {
            get
            {
                if(mMaxSelectCount == 0)
                {
                    uint c = GameConstHelper.GetUint("GAME_MAX_SELECT_COUNT");
                    if(c == 0)
                        mMaxSelectCount = 5;
                    else
                        mMaxSelectCount = c;
                }
                return mMaxSelectCount;
            }
        }

        private static float mMaxTargetRange;// 周围目标的最大距离
        public static float MaxTargetRange 
        {
            get
            {
                if(mMaxTargetRange == 0)
                {
                    float c = GameConstHelper.GetFloat("GAME_MAX_TARGET_RANGE");
                    if(c == 0)
                        mMaxTargetRange = 11.0f;
                    else
                        mMaxTargetRange = c;
                }
                return mMaxTargetRange;
            }
        }

        private float mLeaveRange;// 选中目标脱离攻击的距离
        public float LeaveRange 
        {
            get
            {
                if(mLeaveRange == 0)
                {
                    float c = GameConstHelper.GetFloat("GAME_LEAVE_FIGHT_RANGE");
                    if(c == 0)
                        mLeaveRange = 11.0f;
                    else
                        mLeaveRange = c;
                }
                return mLeaveRange;
            }
        }

        void FillNearestActorList(Dictionary<UnitID, Actor> target_list, List<Actor> nearest_actors, float sqr_attack_dis, Vector3 cur_pos)
        {
            foreach (Actor actor in target_list.Values)
            {
                if (actor == null || actor.Trans == null)
                {
                    Debug.LogError("Actor in set is null");
                    continue;
                }

                if (actor.IsDead())
                    continue;

                if (actor.CanBeChoosed() == false)
                    continue;

                if (actor.CanBeHited() == false)
                    continue;

                // 判断距离是否在范围内
                Vector3 toward = actor.Trans.position - cur_pos;
                float sqrDis = toward.sqrMagnitude;
                if (sqrDis < sqr_attack_dis) // !actor.IsDead() 在点击按钮切换目标时，先不检查角色是否死亡，只有在使用技能时才能判读
                {
                    nearest_actors.Add(actor);
                }
            }
        }

        /// <summary>
        /// 切换已锁定的攻击目标
        /// </summary>
        void OnClickChangeTarget(CEventBaseArgs data)
        {
            if(mOwner.Trans == null)
            {
                GameDebug.LogError("Transform is null");
                return;
            }

            Vector3 cur_pos = mOwner.Trans.position;
            Vector3 curDir = mOwner.Trans.forward;

            float sqr_attack_dis = MaxTargetRange * MaxTargetRange;
            Dictionary<UnitID,Actor> target_list = GetTargetList(false);
            List<Actor> nearest_actors = new List<Actor>();
            // 找出距离最近的五个角色
            if(target_list != null)
            {
                FillNearestActorList(target_list, nearest_actors, sqr_attack_dis, cur_pos);

                if(nearest_actors.Count > 0)
                {
                    bool player_first = SceneHelp.Instance.PrecedentPlayer;
                    bool monster_first = false;
                    if(player_first == false && SceneHelp.Instance.UsePKMode)
                    {
                        if (PKModeManagerEx.Instance.PKMode == GameConst.PK_MODE_PEACE)
                            monster_first = true;//和平模式：优先筛选范围距离最近的怪物
                        else
                            monster_first = false;
                    }
                    nearest_actors.Sort(delegate(Actor a, Actor b) {
                        if(player_first)
                        {
                            // 玩家排序在前面
                            if (a.IsPlayer())
                            {
                                if (b.IsPlayer() == false)
                                    return -1;
                            }
                            else if (b.IsPlayer())
                            {
                                return 1;
                            }
                        }
                        else if(monster_first)
                        {//怪物优先
                            if (a.IsMonster())
                            {
                                if (b.IsMonster() == false)
                                    return -1;
                            }
                            else if (b.IsMonster())
                            {
                                return 1;
                            }
                        }
                        Vector3 len1 = a.Trans.position - cur_pos;
                        Vector3 len2 = b.Trans.position - cur_pos;
                        if(len1.sqrMagnitude < len2.sqrMagnitude)
                            return -1;
                        else if(len1.sqrMagnitude > len2.sqrMagnitude)
                            return 1;
                        else
                            return 0;});

                    //剔除选不中
                    if(SceneHelp.Instance.UsePKMode && nearest_actors.Count > 0)
                    {
                        // 和平模式，若没有怪物才会选中最近的其他玩家
                        if (PKModeManagerEx.Instance.PKMode == GameConst.PK_MODE_PEACE)
                        {
                            Actor act = nearest_actors[0];
                            if (act.IsMonster()) //周围有怪物，直接删除其他玩家
                            {
                                for (int i = nearest_actors.Count - 1; i >= 0 ; --i)
                                {
                                    if (nearest_actors[i].IsPlayer())
                                        nearest_actors.RemoveAt(i);
                                }
                            }
                        }
                        else if(PKModeManagerEx.Instance.PKMode == GameConst.PK_MODE_FRIENDLY)
                        {   //强制模式：优先筛选范围距离最近的敌方玩家或怪物（非独有公会），
                            //若怪物敌方均没有，才会选中最近的友方（盟友或队友）
                            bool show_tips = false;
                            List<bool> isEnemyArray = new List<bool>();
                            bool has_enemy = false; //是否有敌人
                            for (int i = 0; i < nearest_actors.Count; ++i)
                            {
                                Actor act = nearest_actors[i];
                                if (PKModeManagerEx.Instance.IsEnemyRelation(mOwner, act, ref show_tips))
                                {
                                    isEnemyArray.Add(true);//是敌人
                                    has_enemy = true;
                                }
                                else
                                    isEnemyArray.Add(false);//非敌人
                            }
                            if(has_enemy)//有敌人，删除“非敌人”
                            {
                                for (int i = nearest_actors.Count - 1; i >= 0; --i)
                                {
                                    if (isEnemyArray[i] == false)
                                        nearest_actors.RemoveAt(i);
                                }
                            }
                        }
                        else if(PKModeManagerEx.Instance.PKMode == GameConst.PK_MODE_KILLER)//全体模式：优先筛选范围距离最近的任意玩家或怪物
                        {

                        }
                        else if (PKModeManagerEx.Instance.PKMode == GameConst.PK_MODE_ATTACK)//进攻模式
                        {
                            nearest_actors = FilterPKAttack(nearest_actors);
                        }
                        else if (PKModeManagerEx.Instance.PKMode == GameConst.PK_MODE_SERVER)//同服模式
                        {
                            nearest_actors = FilterPKServer(nearest_actors);
                        }
                    }
                    

                    Actor firstActor = null;
                    for(int i = 0; i < nearest_actors.Count && i < MaxSelectCout; ++i)
                    {
                        Actor act = nearest_actors[i];

                        // 如果已在选择列表中，则排除掉
                        if(mSelectedActors.Contains(act.GetActorMono()))
                            continue;

                        firstActor = act;
                        break;
                    }

                    if(firstActor != null)
                    {
                        SetCurSelectActor(firstActor.GetActorMono(), true, false);
                        if(!mSelectedActors.Contains(mCurSelectActor))
                            mSelectedActors.Add(mCurSelectActor);
                    }
                    else
                    {
                        if(nearest_actors.Count > 0)
                        {
                            SetCurSelectActor(nearest_actors[0].GetActorMono(), true, false);
                            mSelectedActors.Clear();
                            mSelectedActors.Add(mCurSelectActor);
                        }
                    }

                    SetSelectEffect();
                }
            }
        }

        List<Actor> FilterPKAttack(List<Actor> actorList)
        {
            return actorList;
        }

        List<Actor> FilterPKServer(List<Actor> actorList)
        {
            return actorList;
        }

        /// <summary>
        /// 根据副本类型获取所有可攻击的目标
        /// </summary>
        private Dictionary<UnitID,Actor> GetTargetList(bool choose_player_first = false)
        {
            bool is_local_player = mOwner is LocalPlayer;
            
            Dictionary<UnitID, Actor> target_set = null;

            if(SceneHelp.Instance.PrecedentPlayer)// 优先选择玩家
            {
                // 本地玩家才找目标对手
                if(is_local_player)
                {
                    if(choose_player_first)// 优先选择玩家
                    {
                        target_set = ActorManager.Instance.PlayerSet;
                        if(target_set.Count <= 0)
                            target_set = ActorManager.Instance.ActorSet;
                    }
                    else// 玩家列表中找不到可攻击目标时，会选择所有角色
                        target_set = ActorManager.Instance.ActorSet;
                }
            }
            else if(is_local_player)
            {
                target_set = ActorManager.Instance.ActorSet;
            }

            // 变身状态下的目标需要进行过滤
            if (is_local_player && mOwner.IsShapeShift)
            {
                var info = DBShiftStateControl.Instance.GetInfo(mOwner.ShiftState);
                if (info != null)
                {
                    target_set = ActorManager.Instance.ActorSet;
                    var tag = info.target_type;
                    var new_target_set = new Dictionary<UnitID, Actor>();
                    using (var iter = target_set.GetEnumerator())
                    {
                        while (iter.MoveNext())
                        {
                            var cur = iter.Current;

                            if (cur.Value.WarTag == tag)
                            {
                                new_target_set[cur.Key] = cur.Value;
                            }
                        }
                    }
                    target_set = new_target_set;
                }
            }

            return target_set;
        }

        /// <summary>
        /// 是否和对方在同一阵营，并可以攻击对方(可以攻击，返回false)
        /// </summary>
        private bool InSameCamp(Actor actor,DBSkillSev.SkillInfoSev skill_info_sev, ref bool show_tips)
        {
            if (actor == null)
                return false;

            if(actor == this.mOwner)
                return true;

            if(skill_info_sev != null && skill_info_sev.TargetLimit != null && skill_info_sev.TargetLimit.Length > 0)
            {
                if(skill_info_sev.TargetLimit == DBSkillSev.TARGETLIMIT_PVE_STR)//只能在PVE中使用的技能
                {
                    if (actor.IsMonster() == false)
                    {
                        if (show_tips)
                        {
                            show_tips = false;
                            xc.UINotice.Instance.ShowMessage(xc.DBConstText.GetText("SKILL_TARGET_LIMIT_PVE_TIPS"));
                        }
                        return true;
                    }
                }
                else if(skill_info_sev.TargetLimit == DBSkillSev.TARGETLIMIT_PVP_STR)//只能PVP中使用的技能
                {
                    if (actor.IsPlayer() == false)
                    {
                        if (show_tips)
                        {
                            show_tips = false;
                            xc.UINotice.Instance.ShowMessage(xc.DBConstText.GetText("SKILL_TARGET_LIMIT_PVP_TIPS"));
                        }
                        return true;
                    }   
                }
            }

            if (actor.Camp == mOwner.Camp)
            {
                if (show_tips && !SceneHelp.Instance.NoShowAtkCampTips)
                {
                    show_tips = false;
                    xc.UINotice.Instance.ShowMessage(xc.DBConstText.GetText("SKILL_CANNT_ATTACK_FRIEND"));
                }
                return true;
            }
            else if (SceneHelp.Instance.UsePKMode) // 当前副本使用pk模式
            {
                bool can_attack = PKModeManagerEx.Instance.IsLocalPlayerCanAttackActor(actor, ref show_tips);
                return !can_attack;
            }

            //if(mOwner.IsInSafeArea || actor.IsInSafeArea)
            if(PKModeManagerEx.Instance.IsInSafeArea)
            {
                if (show_tips)
                {
                    show_tips = false;
                    xc.UINotice.Instance.ShowMessage(xc.DBConstText.GetText("SKILL_CANNT_ATTACK_IN_SAFE_AREA"));
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// 执行技能里的单个攻击动作，一个技能由多个攻击动作组成
        /// </summary>
		void AttackAction(int skillIndex, Actor target)
		{
            if (mOwner == null || mOwner.IsDestroy)
                return;				
			Skill CurSkill = mOwner.GetCurSkill();
						
			if (CurSkill != null)
			{
                // 获取当前技能action
                xc.SkillAction skill_action = CurSkill.GetAction(skillIndex);
                if (skill_action == null || skill_action.ActionData == null || skill_action.ActionData.SkillInfo == null)
                    return;
                string skill_annouce = skill_action.ActionData.SkillInfo.SkillAnnounce;
                if (string.IsNullOrEmpty(skill_annouce) == false)
                {
                    skill_annouce = skill_annouce.Replace("[NAME]", mOwner.Name);// 替换技能释放者的名字
                    if(target != null)// 替换目标玩家的名字
                    {
                        if(target.IsPlayer())
                            skill_annouce = skill_annouce.Replace("[name]", target.UserName);
                        else
                            skill_annouce = skill_annouce.Replace("[name]", target.Name);
                    }
                    UINotice.Instance.ShowWarnning(skill_annouce);
                }

                if(IsUseCD)
                {
                    uint cd_typeid = skill_action.ActionData.SkillInfo.Id;// 使用技能id来标识不同的cd
					if (cd_typeid != 0 && mOwner.CDCtrl != null)
                    {
                        if (SkillManager.GetInstance().IsMateSkillByActive(cd_typeid))
                        {
                            //情侣技能的cd 不能在这里直接开始，因为可能传送失败，cd由服务端 
                            //31144 S2SMarryRingTransSuccess 来 开始
                        }
                        else
                        {
                            mOwner.CDCtrl.StartCD(cd_typeid);
                        }
                    }
				}

                // 根据角色属性来设置技能攻速
                //if (kAction.ActionData.mkSkillInfo.ChangeSpeed)
                CurSkill.SpeedScale = Mathf.Clamp(mOwner.AttackSpeed, 0.1f, 10.0f);

                if (mOwner != null && mOwner.IsLocalPlayer)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL, new CEventBaseArgs(skill_action.ActionData.SkillInfo.Id));
                }
                if (mOwner != null && mOwner is LocalPet)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PET_TRIGGER_SKILL, new CEventBaseArgs(skill_action.ActionData.SkillInfo.Id));
                }

                // 发送使用技能的消息
                if (mIsSendMsg)
                {
                    C2SNwarSkill nwar_skill = new C2SNwarSkill();
                    nwar_skill.uuid = mOwner.UID.obj_idx;
                    nwar_skill.skill_id = skill_action.ActionData.SkillInfo.Id;
                    PkgNwarPos pos = new PkgNwarPos();
                    Vector3 kPos = mOwner.Trans.position;
                    pos.px = (int)(kPos.x * 100);
                    pos.py = (int)(kPos.z * 100);
                    nwar_skill.cur_pos = pos;

                    // 魔仆技能的处理
                    if (mOwner is Pet)
                    {
                        Pet pet = mOwner as Pet;
                        if (pet != null && pet.ParentActor != null)
                        {
                            nwar_skill.uuid = pet.ParentActor.UID.obj_idx;
                        }
                        nwar_skill.ori_type = GameConst.SKILL_ORI_PET;
                    }
                    else
                    {
                        nwar_skill.ori_type = GameConst.SKILL_ORI_NORMAL;
                    }

                    if (skill_action.ActionData.SkillInfo.FindTarget)
                    {
                        if (target != null)
                        {
                            if (mOwner.ActorAttribute != null && mOwner.ActorAttribute.AttackRotaion > 0 && target.Trans != null)
                            {
                                Vector3 dir = target.Trans.position - mOwner.Trans.position;
                                mOwner.TurnDir(dir);// 设置攻击方向指向目标
                            }
                            CurSkill.AttackDir = mOwner.ForwardDir;
                            nwar_skill.dir = Maths.Util.VectorToAngle(CurSkill.AttackDir);

                            nwar_skill.target_ids.Add(target.UID.obj_idx);
                            Actor actor = ActorManager.Instance.GetActor(target.UID);
                            if (actor != null)
                            {
                                PkgNwarPos target_pos = new PkgNwarPos();
                                kPos = actor.Trans.position;
                                target_pos.px = (int)(kPos.x * 100);
                                target_pos.py = (int)(kPos.z * 100);
                                nwar_skill.tar_pos = target_pos;
                            }

                            LastTargetId = target.UID.obj_idx;
                            if( nwar_skill.ori_type != GameConst.SKILL_ORI_PET)
                            {//不是魔仆，要执行停止发送同步协议
                                if (mOwner.IsLocalPlayer && mOwner.MoveCtrl != null)
                                    mOwner.MoveCtrl.IsMoving = false;
                            }
                            Net.NetClient.GetCrossClient().SendData<C2SNwarSkill>(NetMsg.MSG_NWAR_SKILL, nwar_skill);

                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ATTACK_SUCC, new CEventBaseArgs(nwar_skill.skill_id));
                        }
                        else
                        {
                            // 自动战斗状态不显示这个提示
                            if (InstanceManager.Instance.IsAutoFighting == false && mOwner != null && mOwner.IsLocalPlayer)
                            {
                                UINotice.GetInstance().ShowMessage_showMaxOne(DBConstText.GetText("TARGET_LOST"));
                                //UINotice.GetInstance().ShowMessage(DBConstText.GetText("TARGET_LOST"));
                            }
                        }
                    }
                    else
                    {
                        CurSkill.AttackDir = mOwner.ForwardDir;// 设置攻击方向为角色朝向
                        nwar_skill.dir = Maths.Util.VectorToAngle(CurSkill.AttackDir);

                        if (target != null)
                        {
                            nwar_skill.target_ids.Add(target.UID.obj_idx);
                            Actor actor = ActorManager.Instance.GetActor(target.UID);
                            if (actor != null)
                            {
                                PkgNwarPos target_pos = new PkgNwarPos();
                                kPos = actor.Trans.position;
                                target_pos.px = (int)(kPos.x * 100);
                                target_pos.py = (int)(kPos.z * 100);
                                nwar_skill.tar_pos = target_pos;
                            }

                            LastTargetId = target.UID.obj_idx;
                        }
                        if (nwar_skill.ori_type != GameConst.SKILL_ORI_PET)
                        {//不是魔仆，要执行停止发送同步协议
                            if (mOwner.IsLocalPlayer && mOwner.MoveCtrl != null)
                                mOwner.MoveCtrl.IsMoving = false;
                        }
                        if (SkillManager.GetInstance().IsMateSkillByActive(nwar_skill.skill_id))
                        {
                            //情侣技能有独立的消息号
                            //情侣技能的使用成功 不能直接在这里触发，因为可能传送失败，由服务端 
                            //31144 s2c_marry_ring_trans 来触发 
                            //使用 ClientEvent.SKILL_MATE_USE_SUCCESS  来代替 ClientEvent.CE_ATTACK_SUCC
                            if (Owner.IsLocalPlayer)
                            {
                                //C2SMarryRingTrans data = new C2SMarryRingTrans();
                                //Net.NetClient.GetBaseClient().SendData<C2SMarryRingTrans>(NetMsg.MSG_MARRY_RING_TRANS, data);

                                ClientEventMgr.GetInstance().FireEvent(xc.EnumUtil.EnumToInt(xc.ClientEvent.CE_MATE_SKILL_ACTION), new CEventBaseArgs());
                            }
                        }
                        else
                        {
                            Net.NetClient.GetCrossClient().SendData<C2SNwarSkill>(NetMsg.MSG_NWAR_SKILL, nwar_skill);
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ATTACK_SUCC, new CEventBaseArgs(nwar_skill.skill_id));
                        }
                    }
                }

                // 设置角色达到技能攻击范围内是否冲向目标
                CurSkill.TargetID = target != null ? target.UID.obj_idx : 0;
                CurSkill.BeginIndex(skillIndex);
			}
			else
			{
				mOwner.Stop();
			}		
		}

        /// <summary>
        /// 找出最近的一个角色
        /// </summary>
        /// <param name="target_list"></param>
        /// <param name="skill"></param>
        /// <param name="max_sqr_dis"></param>
        /// <param name="cur_pos"></param>
        Actor FindNearesetActor(Dictionary<UnitID, Actor> target_list, Skill skill, float max_sqr_dis, Vector3 cur_pos)
        {
            if (target_list == null)
                return null;

            float nearest_dis = 10000.0f; // 正面最近
            Actor nearestActor = null;
            foreach (Actor actor in target_list.Values)
            {
                if (actor == null)
                {
                    Debug.LogError("[FindNearesetActor]Actor is null");
                    continue;
                }

                if (actor.Trans == null)
                {
                    Debug.LogError("[FindNearesetActor]Actor transform is null");
                    continue;
                }

                if (actor.CanBeHited() == false)
                    continue;

                if (actor.CanBeChoosed() == false)
                    continue;

                bool same_camp = false;
                bool tmp_show_tips = false;
                if (skill != null)
                {
                    bool is_heal = false;
                    same_camp = InSameCamp(actor, skill.GetAction(0).ActionData.SkillInfo, ref tmp_show_tips);
                    if ((same_camp && !is_heal) || (!same_camp && is_heal))
                        continue;
                }
                else
                {
                    same_camp = InSameCamp(actor, null, ref tmp_show_tips);
                    if (same_camp)
                        continue;
                }

                //判断怪物是否在攻击范围内
                Vector3 toward = actor.Trans.position - cur_pos;
                float sqr_dis = toward.sqrMagnitude;
                if (sqr_dis < max_sqr_dis && sqr_dis < nearest_dis && !actor.IsDead())
                {
                    nearest_dis = sqr_dis;
                    nearestActor = actor;
                }
            }

            return nearestActor;
        }

        /// <summary>
        /// 查找可攻击目标
        /// </summary>
        Actor FindTarget(Skill skill, out bool show_tips)
        {
            show_tips = true;

            if (mOwner == null || mOwner.Trans == null)
            {
                return null;
            }
            
            // 寻找最近的目标物体
            Actor nearest_actor = null;  // 最近的角色
            if(mOwner.IsPlayer())
            {
                Vector3 cur_pos = mOwner.Trans.position;
                float max_sqr_dis = MaxTargetRange * MaxTargetRange;
                Dictionary<UnitID,Actor> target_list = GetTargetList(true);

                // 如果存在手动选中的目标且在脱离攻击范围内
                if(mCurSelectActor != null)
                {
                    Actor selectActor = mCurSelectActor.BindActor;

                    // 有可能手动选中的目标不在可攻击列表中
                    bool exist_actor = false;
                    if(target_list != null)
                    {
                        exist_actor = target_list.ContainsKey(selectActor.UID);
                        if(exist_actor == false && SceneHelp.Instance.PrecedentPlayer)
                        {
                            var full_target = GetTargetList(false);
                            exist_actor = full_target.ContainsKey(selectActor.UID);
                        }
                    }

                    if(selectActor != null && !selectActor.IsDead()
                       && exist_actor && (selectActor.Trans.position - cur_pos).sqrMagnitude <= LeaveRange * LeaveRange)
                    {
                        bool is_heal = false;//是否是治疗技能
                        bool same_camp = InSameCamp(selectActor,skill.GetAction(0).ActionData.SkillInfo, ref show_tips);

                        if ((same_camp && is_heal) || (!same_camp && !is_heal))
                        {
                            nearest_actor = selectActor;
                            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL, new CEventBaseArgs(mCurSelectActor));
                            return nearest_actor;
                        }
                    }

                    //选中状态无效
                    if(mSelectedActors.Contains(mCurSelectActor))
                        mSelectedActors.Remove(mCurSelectActor);
                    SetCurSelectActor(null);
                    SetSelectEffect();
                }

                nearest_actor = FindNearesetActor(target_list, skill, max_sqr_dis, cur_pos);
                if(nearest_actor == null && SceneHelp.Instance.PrecedentPlayer)
                {
                    target_list = GetTargetList(false);
                    nearest_actor = FindNearesetActor(target_list, skill, max_sqr_dis, cur_pos);
                }
            }
            else
            {
                Monster ownerMonster = mOwner as Monster;
                if (ownerMonster != null && (ownerMonster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_PLAYER || ownerMonster.BeSummonedType == Monster.BeSummonType.BE_SUMMON_BY_ROBOT))
                {
                    if (ownerMonster.ParentActor != null && ownerMonster.ParentActor.AttackCtrl != null && ownerMonster.ParentActor.AttackCtrl.CurSelectActor != null)
                    {
                        nearest_actor = ownerMonster.ParentActor.AttackCtrl.CurSelectActor.BindActor;
                    }
                }

                Pet pet = mOwner as Pet;
                if (pet != null)
                {
                    if (pet.AttackCtrl != null && pet.AttackCtrl.CurSelectActor != null)
                    {
                        nearest_actor = pet.AttackCtrl.CurSelectActor.BindActor;
                    }
                }
            }

            if (nearest_actor != null)
            {
                ActorMono actMono = nearest_actor.GetActorMono();
                if(actMono != null)
                {
                    SetCurSelectActor(actMono);
                    mSelectedActors.Clear();
                    mSelectedActors.Add(actMono);
                    SetSelectEffect();
                }
            }

            return nearest_actor;
        }

        /// <summary>
        /// 查找可攻击目标(若立即攻击，“很有可能”选中的目标对象)
        /// </summary>
        public void AutoFindTarget(float var_PrepearAutoSelectSearchRadius)
        {
            if (mOwner == null)
                return;
            if (mOwner.IsLocalPlayer == false)
                return;

            if (mCurSelectActor != null && m_isHandleSelectActor)
                return; //手动选中的目标，不允许切换

            if (mCurSelectActor != null && m_isPrepearAutoSelectActor)
                return; //预选中的目标，也不允许切换

            if (mOwner.Trans == null)
                return;
            // 寻找最近的目标物体
            Actor nearestActor = null;  // 最近的角色

            Vector3 cur_pos = mOwner.Trans.position;
            float max_sqr_dis = var_PrepearAutoSelectSearchRadius * var_PrepearAutoSelectSearchRadius;

            Dictionary<UnitID, Actor> target_list = GetTargetList(true);
            nearestActor = FindNearesetActor(target_list, null, max_sqr_dis, cur_pos);
            if(nearestActor == null && SceneHelp.Instance.PrecedentPlayer)
            {
                target_list = GetTargetList(false);
                nearestActor = FindNearesetActor(target_list, null, max_sqr_dis, cur_pos);
            }

            if (nearestActor != null)
            {
                ActorMono actMono = nearestActor.GetActorMono();
                if (actMono != null)
                {
                    if(actMono != mCurSelectActor)
                    {
                        SetCurSelectActor(actMono, false, true);
                        mSelectedActors.Clear();
                        mSelectedActors.Add(actMono);
                        SetSelectEffect();
                    }
                }
            }
        }
        /// <summary>
        /// 如果技能切换返回true，否则返回false
        /// </summary>
		public bool UpdateRigidity()
		{
			bool update_succ = false;
			if (m_NextSkill != 0xffffffff)
			{
				Skill current_skill = mOwner.GetCurSkill();
				int CurIndex = current_skill.CurIndex;
				if (current_skill.SkillID == m_NextSkill)
				{
					++CurIndex;
					if (CurIndex == current_skill.GetSkillActionCount())
					{
						CurIndex = 0;
					}
					
					if (IsSkillCanCast(current_skill, CurIndex))
					{
                        Actor target = null;
                        uint find_target_type = 0;
                        if (mIsSendMsg && IsFindTarget(current_skill, 0, ref find_target_type))
                        {
                            bool show_tips = false;
                            if (find_target_type == 2)
                            {
                                target = mOwner.ParentActor;
                            }
                            else
                                target = FindTarget(current_skill, out show_tips);

                            if(target == null)
                            {
                                if (show_tips)
                                {
                                    // 自动战斗状态不显示这个提示
                                    if (InstanceManager.Instance.IsAutoFighting == false && mOwner != null && mOwner.IsLocalPlayer)
                                    {
                                        UINotice.GetInstance().ShowMessage_showMaxOne(DBConstText.GetText("TARGET_LOST"));
                                    }
                                }
                                return false;
                            }
                            else
                            {
                                // 设置技能范围内最近的目标位置
                                Vector3 target_pos = target.Trans.position;
                                SkillAction skill_action = current_skill.GetAction(CurIndex);
                                float skill_range = skill_action.ActionData.SkillInfo.Range;
                                if (CheckAttackRange(skill_action.ActionData.SkillInfo.Id, skill_range, target_pos, true) == false)
                                    return false;
                            }
                        }

						if (mOwner.Attack(current_skill.SkillID))
						{
                            m_NextSkill = 0xffffffff;
                            AttackAction(CurIndex, target);
                            update_succ = true;
						}
					}
					else
						ShowMessage();

                    m_NextSkill = 0xffffffff;
				}
				else
				{
                    Skill next_skill = mOwner.GetSelfSkill(m_NextSkill);
					if (next_skill != null && IsSkillCanCast(next_skill, 0))
					{
                        Actor target = null;
                        uint find_target_type = 0;
                        if (mIsSendMsg && IsFindTarget(next_skill, 0, ref find_target_type))
                        {
                            bool show_tips = false;
                            if (find_target_type == 2)
                            {
                                target = mOwner.ParentActor;
                            }
                            else
                                target = FindTarget(next_skill, out show_tips);

                            // 找不到可攻击的目标
                            if (target == null)
                            {
                                if (show_tips)
                                {
                                    // 自动战斗状态不显示这个提示
                                    if (InstanceManager.Instance.IsAutoFighting == false && mOwner != null && mOwner.IsLocalPlayer)
                                    {
                                        UINotice.GetInstance().ShowMessage_showMaxOne(DBConstText.GetText("TARGET_LOST"));
                                    }
                                }

                                // 找不到目标时，立即清除缓存技能
                                m_NextSkill = 0xffffffff;
                                return false;
                            }
                            else
                            {
                                // 设置技能范围内最近的目标位置
                                Vector3 target_pos = target.Trans.position;
                                SkillAction skill_action = next_skill.GetAction(0);
                                float skill_range = skill_action.ActionData.SkillInfo.Range;
                                if (CheckAttackRange(skill_action.ActionData.SkillInfo.Id, skill_range, target_pos, true) == false)
                                    return false;
                            }
                        }

                        bool can_attack = mOwner.FSM.CanReact((uint)ActorMachine.EFSMEvent.DE_NormalAttack) && !IsAttackDisable(m_NextSkill);
                        if (can_attack)
                        {
                            current_skill.Interrupt();// 中断当前技能
                            LastSkillID = m_NextSkill;
                            if (mOwner.Attack(m_NextSkill))
                            {
                                m_NextSkill = 0xffffffff;
                                AttackAction(0, target);
                                update_succ = true;
                            }
                            else
                                update_succ = false;
                        }
                        else
                        {
                            update_succ = false;
                        }
					}
					else					
						ShowMessage();
                }				
			}
			
			return update_succ;
		}

        /// <summary>
        /// 不能释放技能时的反馈
        /// </summary>
		void ShowMessage()
		{

		}

		/// <summary>
        /// 技能能否释放，会检测当前角色处于不可攻击状态，蓝量是否够、是否处于cd中
        /// </summary>
		public bool IsSkillCanCast(Skill kSkill, int iActionIndex)
		{
#if UNITY_EDITOR
			if (!Game.GetInstance().IsNetMode())
				return true;
#endif

            if (kSkill == null)
                return false;

            xc.SkillAction kAction = kSkill.GetAction(iActionIndex);
            //当角色处于不能攻击状态（冰冻、晕眩、致盲等）下，返回
            if (kAction == null || IsAttackDisable(kAction.ActionData.SkillInfo.Id))
                return false;

            int cost_mp = kAction.ActionData.SkillInfo.MpCost;

            return mOwner.IsMPEnough(cost_mp) && !kAction.IsInCD();
        }

        public bool IsMpEnough(uint skillId)
        {
            DBSkillSev dbSkillSev = DBManager.Instance.GetDB<DBSkillSev>();
            DBSkillSev.SkillInfoSev info = dbSkillSev.GetSkillInfo(skillId);
            if (info != null)
            {
                int cost_mp = info.MpCost;

                return mOwner.IsMPEnough(cost_mp);
            }
            else
            {
                //GameDebug.LogError("Check skill mp cost error, can not find skill info by id " + skillId);
                return false;
            }
        }

        public bool IsSkillCanCast_showTipsWhenFalse(Skill kSkill, int iActionIndex, ref RockCommandSystem.ClickRockButtonTipsType tips_type)
        {
            tips_type = RockCommandSystem.ClickRockButtonTipsType.None;
#if UNITY_EDITOR
            if (!Game.GetInstance().IsNetMode())
                return true;
#endif

            if (kSkill == null)
                return false;

            xc.SkillAction kAction = kSkill.GetAction(iActionIndex);
            //当角色处于不能攻击状态（冰冻、晕眩、致盲等）下，返回
            if (kAction == null || IsAttackDisable(kAction.ActionData.SkillInfo.Id))
            {
                UINotice.GetInstance().ShowMessage(DBConstText.GetText("CANT_RELEASE"));
                return false;
            }
            int cost_mp = kAction.ActionData.SkillInfo.MpCost;
            if (kAction.IsInCD())
            {
                tips_type = RockCommandSystem.ClickRockButtonTipsType.IsInCD;
                return false;
            }
            if (mOwner.IsMPEnough(cost_mp) == false)
            {
                tips_type = RockCommandSystem.ClickRockButtonTipsType.NotEnoughMp;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 技能能否是锁定目标类型的技能
        /// find_target_type : 锁定目标的类型
        /// </summary>
        public bool IsFindTarget(Skill kSkill, int iActionIndex, ref uint find_target_type)
        {
            find_target_type = 0;
            #if UNITY_EDITOR
            if (!Game.GetInstance().IsNetMode())
                return false;
            #endif
            
            if (kSkill == null)
                return false;

            xc.SkillAction kAction = kSkill.GetAction(iActionIndex);
            if (kAction == null)
                return false;

            find_target_type = kAction.ActionData.SkillInfo.FindTargetType;
            return kAction.ActionData.SkillInfo.FindTarget;
        }

        /// <summary>
        /// 检查角色可攻击状态和技能清除debuff
        /// </summary>
        public bool IsAttackDisable(uint skillId)
        {
            return mOwner.GetBehavior<BattleStateBehavior>().IsAttackDisable(skillId);
        }

        /// <summary>
        /// 响应技能释放的消息
        /// </summary>
        protected void HandleSkillStart(S2CNwarSkill kMsg)
        {
            if (!mIsRecvMsg)
                return;

            if (mOwner == null || mOwner.Trans == null)
            {
                GameDebug.LogError("[HandleSkillStart]mOwner.Trans is null");
                return;
            }
            //GameDebug.LogError(string.Format("ID = {0} skill_id = {1}", mOwner.UID.obj_idx, kMsg.skill_id));    

            Vector3 kPos;
            kPos.x = kMsg.cur_pos.px*0.01f;
            kPos.y = mOwner.Trans.position.y;
            kPos.z = kMsg.cur_pos.py*0.01f;
            mOwner.SetPosition(kPos);
            mOwner.Stop();
            
            if (mOwner.ActorAttribute.AttackRotaion > 0)
            {
                Vector3 dir = Maths.Util.AngleToVector(kMsg.dir);
                mOwner.TurnDir(dir);
            }
            if (Owner.mRideCtrl != null && Owner.mRideCtrl.IsRiding())
            {//正在骑乘
                Owner.mRideCtrl.UnRide(true);//下马
                Owner.OnBattleTrigger();
                m_is_exchange_mount_to_battle_processing = true;
                m_cachekMsg = kMsg;
                return;
            }
            else if (Owner.mRideCtrl != null && Owner.mRideCtrl.Rider != null)
            {
                m_is_exchange_mount_to_battle_processing = true;
                m_cachekMsg = kMsg;
                return;
            }
            m_cachekMsg = null;
            m_is_exchange_mount_to_battle_processing = false;
            DBSkill.HierarchyInfo info = DBSkill.Instance.GetHierarchyInfo(kMsg.skill_id);
            uint skill_id = kMsg.skill_id;
            int action_idx = 0;
            if (info != null)
            {
                skill_id = info.ParentID;
                action_idx = info.HierarchyIndex;
            }

            if (mOwner.Attack(skill_id))
            {
                Actor target = null;
                if (kMsg.target_ids.Count > 0)
                {
                    target = ActorManager.Instance.GetPlayer(kMsg.target_ids[0]);
                }

                // 同步攻速属性,服务端发送的攻速数值可能为0
                if (kMsg.atk_speed != 0)
                    mOwner.AttackSpeed = kMsg.atk_speed * GlobalConst.AttrConvert;
                else
                    mOwner.AttackSpeed = 1.0f;

                AttackAction(action_idx, target);
            }
        }

        public ActorMono CurSelectActor
        {
            get
            {
                return mCurSelectActor;
            }
            set
            {
                SetCurSelectActor(value);
                mSelectedActors.Clear();
                mSelectedActors.Add(mCurSelectActor);
                SetSelectEffect();
            }
        }
        bool m_is_exchange_mount_to_battle_processing = false;
        public bool IsExchangeMountToBattleProcessing
        {
            get { return m_is_exchange_mount_to_battle_processing; }
        }
        S2CNwarSkill m_cachekMsg = null;

        public override void Update()
        {
            base.Update();
            if(mIsSendMsg)
            {
#if UNITY_STANDALONE_WIN
                if(Input.GetKey(KeyCode.T))
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, new CEventBaseArgs(0xF0000000));
                }
#endif
                // 已经死亡的角色立即不选中
                if (CurSelectActor != null)
                {
                    if (CurSelectActor.BindActor.IsDead())
                        CurSelectActor = null;
                }
                
                if (mOwner != null && mOwner.transform != null && mCurSelectActor != null)
                {
                    float max_range = LeaveRange;
                    if(m_isPrepearAutoSelectActor)
                    {
                        Actor player = Game.GetInstance().GetLocalPlayer();
                        if (player != null && player is LocalPlayer)
                        {
                            max_range = Mathf.Min(max_range, (player as LocalPlayer).PrepearAutoSelectSearchRadius);
                        }
                    }
                        
                    // 如果存在手动选中的目标且在脱离攻击范围内
                    bool need_clear_select = true;
                    Actor selectActor = mCurSelectActor.BindActor;
                    if (selectActor != null && selectActor.IsDead() == false
                       && (selectActor.Trans.position - mOwner.transform.position).sqrMagnitude <= max_range * max_range)
                    {
                        need_clear_select = false;
                    }
                    if (need_clear_select)
                    {
                        SetCurSelectActor(null);
                        SetSelectEffect();
                    }
                }
            }
            if (m_is_exchange_mount_to_battle_processing)
            {
                if (Owner.mRideCtrl != null)
                {
                    if(Owner.mRideCtrl.Rider == null)
                    {
                        if (mIsSendMsg && LastSkillID != 0)
                        {//主角流程
                            m_is_exchange_mount_to_battle_processing = false;
                            mOwner.Stop();
                            Attack(LastSkillID);
                        }
                        else if (mIsSendMsg == false && m_cachekMsg != null)
                        {//非主角流程
                            m_is_exchange_mount_to_battle_processing = false;
                            mOwner.Stop();
                            HandleSkillStart(m_cachekMsg);
                        }
                    }
                }
                else
                    m_is_exchange_mount_to_battle_processing = false;
            }
        }

        void OnLeaveAOI(CEventBaseArgs data)
        {
            if (data == null || data.arg == null)
                return;
            uint leave_uuid = (uint)data.arg;
            if (mCurSelectActor != null && mCurSelectActor.BindActor != null && leave_uuid == mCurSelectActor.BindActor.UID.obj_idx)
            {
                if (mSelectedActors.Contains(mCurSelectActor))
                    mSelectedActors.Remove(mCurSelectActor);
                CurSelectActor = null;
            }
        }
    }
}

