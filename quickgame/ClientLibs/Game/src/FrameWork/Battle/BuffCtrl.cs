using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;

using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
	public class BuffCtrl : BaseCtrl
	{
        Dictionary<uint, Buff> mBuffMap; //记录当前所有存在的buff
        public Dictionary<uint, Buff> AllBuffs
        {
            get
            {
                return mBuffMap;
            }
        }

        /// <summary>
        /// 根据buffid进行排序的buff列表
        /// </summary>
        List<Buff> mBuffList;
        public List<Buff> SortBuffs
        {
            get
            {
                if (mBuffList == null)
                    mBuffList = new List<Buff>();

                var allBuffs = mBuffMap;

                // 获取最新的buffid列表
                var buffIds = SGameEngine.Pool<uint>.List.New(mBuffMap.Count);
                using (var enumerator = allBuffs.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        var cur = enumerator.Current;
                        var buff = cur.Value;
                        buffIds.Add(cur.Key);
                    }
                }
                buffIds.Sort();

                // 将buff数据push到table中
                mBuffList.Clear();
                foreach (var id in buffIds)
                {
                    var buff = allBuffs[id];
                    mBuffList.Add(buff);
                }
                SGameEngine.Pool<uint>.List.Free(buffIds);

                return mBuffList;
            }
        }

        /// <summary>
        /// 获取指定id的buff
        /// </summary>
        /// <param name="buff_id"></param>
        /// <returns></returns>
        public Buff GetBuff(uint buff_id)
        {
            Buff buff = null;
            if (mBuffMap.TryGetValue(buff_id, out buff))
            {
                return buff;
            }

            return null;
        }

        /// <summary>
        /// 待删除的buff
        /// </summary>
        List<uint> mRemoveList;

        public BuffCtrl(Actor owner) : base(owner)
		{
            mBuffMap = new Dictionary<uint, Buff>();
            mBuffMap.Clear();
            mRemoveList = new List<uint>();
            mRemoveList.Clear();
        }

        ~BuffCtrl()
        {
            mBuffMap.Clear();
            if(mBuffList != null)
                mBuffList.Clear();
        }
		
		public static void RegisterAllMessage()
		{
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_ADD, HandleNotifyAddBuff);
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_BUFF_DEL, HandleNotifyDeleteBuff);
		}
		
		public override void Destroy ()
		{
            base.Destroy();

            foreach (var item in mEffectObjs)
            {
                item.Value.DestroyInstance();
            }
            mEffectObjs.Clear();
		}


		/// <summary>
        /// 增加buff， kCasterID为技能释放者的id
        /// lifeTime 为服务端的剩余时间
		/// </summary>
        public Buff AddBuff(uint buff_id,  float life_time, uint layer = 1)
		{
            Buff.BuffInfo buff_info = DBManager.GetInstance().GetDB<DBBuffSev>().GetBuffInfo(buff_id) as Buff.BuffInfo;
            if (buff_info == null)
            {
                GameDebug.LogError(string.Format("使用了不存在的Buff: {0}", buff_id));
                return null;                
            }

            bool shiftExcept = false;
            // 同时只能存在一个变身buff
            if (buff_info.shape_shift != 0)
            {
                using (var iter = mBuffMap.GetEnumerator())
                {
                    while(iter.MoveNext())
                    {
                        var cur = iter.Current;
                        var buff = cur.Value;

                        if (buff.OwnBuffInfo.buff_id != buff_id && buff.OwnBuffInfo.shape_shift != 0 && !buff.ShiftExcept)
                        {
                            shiftExcept = true;
                            break;
                        }
                    }
                }
            }

            Buff cur_buff;
            if (mBuffMap.TryGetValue(buff_info.buff_id, out cur_buff))
			{
                cur_buff.ShiftExcept = shiftExcept;

                if (cur_buff.NeedDel)// 如果原有buff将要销毁, 则用新buff参数进行重设
				{
                    cur_buff.Reset(buff_info, life_time, layer);
				}
				else
				{
                    cur_buff.ResetTime(life_time, layer);// 需要重设所有相同buff的时间
				}
			}
			else
			{
                cur_buff = Buff.Construct(this, buff_info, life_time, layer, shiftExcept);
				if (cur_buff != null)
				{
                    mBuffMap.Add(cur_buff.m_BuffId, cur_buff);
				}
			}

            if (mOwner.IsLocalPlayer)
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_BUFF_UPDATE, null);

			return cur_buff;
		}

        //FIXME 在buff叠加时，这种删除方式可能有问题
        /// <summary>
        /// 根据buff表中的id来删除buff
        /// </summary>
        public void DelBuff(uint buff_id)
        {
            foreach (Buff buff in mBuffMap.Values)
            {
                if (!buff.NeedDel && buff.OwnBuffInfo.buff_id == buff_id)
                {
                    buff.Delete();
                }
            }

            DestroyInvalid();
        }

        /// <summary>
        /// 是否存在指定类型的buff
        /// </summary>
        public bool HasActive(uint buff_id)
        {
            foreach (Buff buff in mBuffMap.Values)
            {
                if (!buff.NeedDel && buff.OwnBuffInfo.buff_id == buff_id)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除某种设置战斗状态的buff
        /// </summary>
        public void DelBattleStatus(string status)
        {
            BattleStatusType battle_status = Buff.GetBattleState(status);
            foreach (Buff buff in mBuffMap.Values)
            {
                if (!buff.NeedDel && buff.OwnBuffInfo.battle_effect_type == battle_status)
                {
                    buff.Delete();
                }
            }

            DestroyInvalid();
        }

        /// <summary>
        /// 从字典中删除所有已经无效的buff
        /// </summary>
        void DestroyInvalid()
		{
            mRemoveList.Clear();
            foreach (KeyValuePair<uint, Buff> kItem in mBuffMap)
		    {
                if (kItem.Value.NeedDel)
                {
                    mRemoveList.Add(kItem.Key);
                }
		    }

            foreach (uint usKey in mRemoveList)
			{
                mBuffMap.Remove(usKey);
			}

            if (mRemoveList.Count > 0)
            {
                if (mOwner.IsLocalPlayer)
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_BUFF_UPDATE, null);

                mRemoveList.Clear();
            }
        }
		
        /// <summary>
        /// buff的更新函数
        /// </summary>
		public override void Update()
		{
            // buff数量不为空时重设Buff数组，然后再更新中重算所有属性加成数值
            if(mBuffMap.Count > 0)
            {
                // 在buff的更新过程中，目标角色可能会死亡，最后触发删除buff的逻辑
                List<uint> buff_ids = Pool<uint>.List.New(mBuffMap.Count);
                foreach(var buff_id in mBuffMap.Keys)
                {
                    buff_ids.Add(buff_id);
                }
                
                Buff buff;
                for(int i = 0; i< buff_ids.Count; ++i)
                {
                    if(mBuffMap.TryGetValue(buff_ids[i], out buff))
                    {
                        if (!buff.NeedDel)
                            buff.Update();
                    }
                }

                Pool<uint>.List.Free(buff_ids);

                DestroyInvalid();
            }
		}

        private static Dictionary<uint, float> m_mustShowBuffIds = new Dictionary<uint, float>();

        private static UnitID mBuffActorUID = new UnitID(0, 0);

		/// <summary>
        /// 响应增加buff的消息
        /// </summary>
		public static void HandleNotifyAddBuff(ushort protocol, byte[] data)
		{
            S2CNwarBuffAdd buff_add_msg = S2CPackBase.DeserializePack<S2CNwarBuffAdd>(data);
   
            Actor actor = ActorManager.Instance.GetPlayer(buff_add_msg.act_id);
            if (actor == null)
            {
                if(Game.Instance.LocalPlayerID != null && Game.Instance.LocalPlayerID.obj_idx == buff_add_msg.act_id
                    && buff_add_msg.no_tips == 2)
                {
                    m_mustShowBuffIds[buff_add_msg.buff_id] = Time.realtimeSinceStartup;
                }

                mBuffActorUID.obj_idx = buff_add_msg.act_id;
                var cache_info = ActorManager.Instance.GetUnitCacheInfo(mBuffActorUID);
                if(cache_info != null && cache_info.CacheType == UnitCacheInfo.EType.ET_Create)
                {
                    if(cache_info.UnitType == EUnitType.UNITTYPE_PLAYER)
                    {
                        if(cache_info.AOIPlayer.leave_buff_id_list == null)
                            cache_info.AOIPlayer.leave_buff_id_list = new List<LeaveBuff>();
                        cache_info.AOIPlayer.leave_buff_id_list.Add(new LeaveBuff(buff_add_msg.buff_id, buff_add_msg.expire, buff_add_msg.layer, buff_add_msg.no_tips));
                    }
                    else if(cache_info.UnitType == EUnitType.UNITTYPE_MONSTER)
                    {
                        if (cache_info.AOIMonster.leave_buff_id_list == null)
                            cache_info.AOIMonster.leave_buff_id_list = new List<LeaveBuff>();
                        cache_info.AOIMonster.leave_buff_id_list.Add(new LeaveBuff(buff_add_msg.buff_id, buff_add_msg.expire, buff_add_msg.layer, buff_add_msg.no_tips));
                    }
                }
                return;
            }
            actor.BuffCtrl.AddBuff_out(buff_add_msg.buff_id, buff_add_msg.expire * GlobalConst.MilliToSecond, buff_add_msg.layer, buff_add_msg.no_tips);
        } 

        public void AddBuff_out(uint buff_id, float life_time, uint layer, uint no_tips)
        {
            bool has_active_buff = HasActive(buff_id);
            var buff = AddBuff(buff_id, life_time, layer);

            if (buff == null)
                return;

            if (mOwner != null && Owner.IsLocalPlayer)
            {
                bool must_show_tips = false;
                uint no_tips_flag = no_tips;
                //LocalPlayerManager.Instance.m_canShowBuffTips || LocalPlayerManager.Instance.m_isFirstLoadingScene
                if (SceneHelp.Instance.PreSceneID == 0 && m_mustShowBuffIds.ContainsKey(buff_id))
                {
                    float last_time = m_mustShowBuffIds[buff_id];
                    if (Time.realtimeSinceStartup < last_time + 5)
                    {
                        no_tips_flag = 2;
                    }
                    m_mustShowBuffIds.Remove(buff_id);
                }
                if (no_tips_flag == 2)
                    must_show_tips = true;
                if (buff != null && mOwner.IsLocalPlayer &&
                    ((has_active_buff == false && no_tips_flag == 0) || must_show_tips))
                {//buff标志位为2时，一定显示;标志位为0，前端自己判定；标志位为1，前端一定不显示；
                    mOwner.ShowBuffTip(buff_id);
                }

            }
        }
			
        /// <summary>
        /// 响应删除buff的消息
        /// </summary>
		public static void HandleNotifyDeleteBuff(ushort protocol, byte[] data)
		{
            S2CNwarBuffDel kMsg = S2CPackBase.DeserializePack<S2CNwarBuffDel>(data);

            Actor kTarget = ActorManager.Instance.GetPlayer(kMsg.act_id);
            if (kTarget == null)
            {
                mBuffActorUID.obj_idx = kMsg.act_id;
                var cache_info = ActorManager.Instance.GetUnitCacheInfo(mBuffActorUID);
                if (cache_info != null && cache_info.CacheType == UnitCacheInfo.EType.ET_Create)
                {
                    if (cache_info.UnitType == EUnitType.UNITTYPE_PLAYER)
                    {
                        if (cache_info.AOIPlayer.leave_buff_id_list != null)
                        {
                            var find_data = cache_info.AOIPlayer.leave_buff_id_list.Find((a) => { return a.id == kMsg.buff_id; });
                            if (find_data != null)
                                cache_info.AOIPlayer.leave_buff_id_list.Remove(find_data);
                        }
                    }
                    else if (cache_info.UnitType == EUnitType.UNITTYPE_MONSTER)
                    {
                        if (cache_info.AOIMonster.leave_buff_id_list != null)
                        {
                            var find_data = cache_info.AOIMonster.leave_buff_id_list.Find((a) => { return a.id == kMsg.buff_id; });
                            if (find_data != null)
                                cache_info.AOIMonster.leave_buff_id_list.Remove(find_data);
                        }
                    }
                }
                return;
            }
            DBBuffSev.DBBuffInfo kInfo = DBBuffSev.GetInstance().GetBuffInfo(kMsg.buff_id);
            if(kInfo != null)  
            {
                kTarget.BuffCtrl.DelBuff(kMsg.buff_id);
            }
		}

		/// <summary>
        /// 角色死亡后需要删除的buff
        /// </summary>
		public bool DelAllBuff()
		{
            Dictionary<uint, Buff>.Enumerator kEnumerator = mBuffMap.GetEnumerator();
			Buff buff;
			while(kEnumerator.MoveNext())		
			{
                buff = kEnumerator.Current.Value;
				if (!buff.NeedDel)
				{		
					if (buff.OwnBuffInfo != null && 
						FlagOperate.HasFlag((int)buff.OwnBuffInfo.buff_flags, (int)Buff.BuffFlags.AF_RECOVERY_AFTER_DIE))
					{
                        buff.Delete();
					}
				}
			}
		
            // 死亡后BuffCtrl不更新，所以需要立即删除buff
            Update();

			return true;
		}

        /// <summary>
        /// 设置buff的层级
        /// </summary>
        /// <param name="layer"></param>
        public void SetBuffLayer(uint buff_id, uint layer)
        {
            foreach (Buff buff in mBuffMap.Values)
            {
                if (buff.OwnBuffInfo.buff_id == buff_id)
                {
                    buff.SetOverlayNum(layer);
                }
            }
        }

        /// <summary>
        /// 获取buff的层级
        /// </summary>
        /// <param name="buff_id"></param>
        /// <param name="layer"></param>
        public uint GetBuffLayer(uint buff_id)
        {
            foreach (Buff buff in mBuffMap.Values)
            {
                if (buff.OwnBuffInfo.buff_id == buff_id)
                {
                    return buff.GetOverlayNum();
                }
            }

            return 0;
        }

        #region buff_effect_obj
        // 保存buff对应的特效数据
        Dictionary<uint, BindEffectInfo> mEffectObjs = new Dictionary<uint, BindEffectInfo>();

		/// <summary>
        /// 增加buff的特效
        /// </summary>
		public void AddEffectObj(DBBuffSev.DBBuffInfo buff_info)
		{
			if (buff_info == null)
				return;
			
			if (mEffectObjs.ContainsKey(buff_info.buff_id))
				return;			
			
			if (buff_info.effect_file == string.Empty)
				return;

            int effect_max_count = GameConstHelper.GetInt("GAME_BUFF_EFFECT_MAX_COUNT");
            if (effect_max_count == 0)
                effect_max_count = 5;

            bool can_show = true;
            if(buff_info.other_hide) // 其他玩家需要隐藏的特效
            {
                can_show = !ShieldManager.Instance.IsHideBuffEffect(mOwner);
            }

            if(can_show && buff_info.force_show == false)// 需要通过顶替规则进行显示的特效
            {
                // 统计当前可能被顶替的特效数量
                int current_count = 0;
                uint low_priority_buff = 0;
                uint low_priority = uint.MaxValue;
                bool del_low_priority = false;
                foreach (uint id in mEffectObjs.Keys)
                {
                    DBBuffSev.DBBuffInfo t_buff_info = DBBuffSev.GetInstance().GetBuffInfo(id);
                    if (t_buff_info.force_show == false)
                    {
                        if (buff_info.priority > t_buff_info.priority)//可顶替
                        {
                            if(low_priority > t_buff_info.priority)// 寻找最低优先级的特效
                            {
                                low_priority = t_buff_info.priority;
                                low_priority_buff = id;
                            }
                        }

                        current_count++;
                    }

                    if (current_count >= effect_max_count)
                    {
                        del_low_priority = true;
                    }
                }

                if (del_low_priority)
                {
                    if (low_priority_buff != 0)
                    {
                        DestroyEffectObj(low_priority_buff);
                    }
                    else
                        can_show = false;
                }
            }

            if(can_show)
            {
                BindEffectInfo new_effect = mOwner.InitBindEffectInfo(buff_info.effect_file, buff_info.bind_pos, buff_info.follow_target, buff_info.scale, buff_info.auto_scale, buff_info.max_count);

                new_effect.CreateInstance();
                mEffectObjs.Add(buff_info.buff_id, new_effect);
            }
		}
		
        /// <summary>
        /// 销毁buff对应的特效
        /// </summary>
		public void DestroyEffectObj(uint buff_id)
		{
            BindEffectInfo effect_info;
			if (mEffectObjs.TryGetValue(buff_id, out effect_info))
			{
                effect_info.DestroyInstance();
                mEffectObjs.Remove(buff_id);
			}
		}

        /// <summary>
        /// 重新绑定特效(角色上下马使用)
        /// </summary>
        public void ResetAllEffectObj()
        {
            List<uint> reset_effect_buffIdArray = new List<uint>();
            foreach(var item in mEffectObjs)
            {
                if(item.Value.IsDestroy == false && item.Value.mEffectObject != null)
                {
                    reset_effect_buffIdArray.Add(item.Key);
                }
            }

            for (int index = 0; index < reset_effect_buffIdArray.Count; ++index)
            {
                uint buff_id = reset_effect_buffIdArray[index];
                
                BindEffectInfo info = mEffectObjs[buff_id];
                DestroyEffectObj(buff_id);
                BindEffectInfo new_effect = mOwner.InitBindEffectInfo(info.mEffectResPath, info.BindPos, info.FollowTarget, info.mScale, false, info.MaxCount);

                new_effect.CreateInstance();
                mEffectObjs.Add(buff_id, new_effect);
            }

        }
        #endregion

        #region

        /// <summary>
        /// 加BUFF飘字（移动速度，攻击速度）
        /// </summary>
        /// <param name="buff_info"></param>
        public void AddBuffWord(DBBuffSev.DBBuffInfo buff_info)
        {
            if (this.Owner == null || this.Owner.IsLocalPlayer == false)
                return;
            if (buff_info == null)
                return;
            if (buff_info.add_eff == null || buff_info.add_eff.Count == 0)
                return;
            for(int index = 0; index < buff_info.add_eff.Count; ++index)
            {
                DBSkillEffect dbEffect = DBManager.GetInstance().GetDB<DBSkillEffect>();
                DBSkillEffect.SkillEffectInfo info = dbEffect.GetSkillEffectInfo(buff_info.add_eff[index]);
                if(info != null)
                {
                    if(info.attr == "speed_add")
                    {//移动速度，绝对数字
                        if (info.p1 > 0)
                        {
                            mOwner.ShowDamageEffect(FightEffectHelp.FightEffectType.Accelerate, 0, Mathf.CeilToInt(info.p1), false);
                        }
                    }
                    else if(info.attr == "speed")
                    {//移动速度，表中是万分比，显示内容百分比
                        if (info.p1 > 0)
                        {
                            mOwner.ShowDamageEffect(FightEffectHelp.FightEffectType.Accelerate, 0, Mathf.CeilToInt(100 * info.p1 * GlobalConst.AttrConvert), true);
                        }
                    }
                    else if (info.attr == "atk_speed")
                    {//攻击速度，表中是万分比，显示内容百分比
                        if (info.p1 > 0)
                        {
                            mOwner.ShowDamageEffect(FightEffectHelp.FightEffectType.AttackSp, 0, Mathf.CeilToInt(100 * info.p1 * GlobalConst.AttrConvert), true);
                        }
                    }
                    else if (info.attr == "atk_speed_base" && info.p2_potentialParam != null)
                    {//攻击速度(只显示潜力格式)，表中是常量，显示内容 = 表数据/100
                        if(LuaScriptMgr.Instance != null)
                        {
                            float final_num = info.p1;// + info.p2_potentialParam.value * level;
                            if (final_num > 0)
                            {   
                                mOwner.ShowDamageEffect(FightEffectHelp.FightEffectType.AttackSp, 0, Mathf.CeilToInt(final_num), false);
                            }
                        }
                        
                    }

                }
            }
        }
        #endregion
    }
}
