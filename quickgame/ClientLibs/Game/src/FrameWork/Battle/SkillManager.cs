using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;
using Net;
using xc.protocol;
using Utils;

namespace xc
{
    [wxb.Hotfix]
    public class SkillManager : xc.Singleton<SkillManager>
    {
        static uint m_NormalFitIdx = 0;// 玩家使用的技能装配索引
        static uint m_ShiftFitIdx = 10;// 变身使用的技能装配索引

        /// <summary>
        /// 本职业玩家当前装配的技能 Key:技能ID
        /// </summary>
        Dictionary<uint, Skill> mFitSkillMap = new Dictionary<uint, Skill>();

        /// <summary>
        /// 服务发送的已装配技能id和位置 外层List:多套技能配置 内层Map: Key:按键位置 Value:技能信息
        /// </summary>
        Dictionary<uint, Dictionary<DBCommandList.OPFlag, SkillInfo>> mFitSkillIdPos = new Dictionary<uint, Dictionary<DBCommandList.OPFlag, SkillInfo>>();

        /// <summary>
        /// 当前正在使用的技能配置ID
        /// </summary>
        private uint mUsingtSkillConfigIndex = 0;

        UnitID mkSelfID;
        LocalPlayer mkSelfActor;

        /// <summary>
        /// 是否处在变身状态
        /// </summary>
        public bool ShapeShifted
        {
            get
            {
                return m_ShapeShifted;
            }
        }
        bool m_ShapeShifted = false;

        public void RegisterAllMessage()
        {
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SHAPE_SHIFT_BEGIN, OnShapeShiftBegin);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_SHAPE_SHIFT_END, OnShapeShiftEnd);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnSwitchScene);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_START_SWITCH_PLANE_INSTANCE, OnSwitchScene);

            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SKILLS_USING, HandleServerData); //更新技能面板上的技能列表
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SKILLS_INFO, HandleServerData); //更新所有技能列表
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SKILLS_DELETE, HandleServerData); //删除某个技能
        }
        
        public void ResetLocalPlayerSkill()
        {                           
            mFitSkillMap.Clear();
            
            foreach (SkillInfo info in UsingSkillConfig.Values)
            {
                if(info.Id != 0)
                    AddSelfSkill(info.Id);
            }
        }
        
        public void InitSkillOwner(LocalPlayer kActor)
        {
            mkSelfActor = kActor;
            
            if (mkSelfActor.UID.Equals(mkSelfID))
            {
                // 重设技能的拥有者
                foreach (Skill kSkill in mFitSkillMap.Values)
                {
                    kSkill.SetCaster(mkSelfActor);
                }
            }
            else
            {       
                mkSelfID = mkSelfActor.UID.Copy();
                ResetLocalPlayerSkill();
            }
        }
        
        /// <summary>
        /// 通过技能id增加技能到列表中
        /// </summary>
        public Skill AddSelfSkill(uint uiID)
        {       
            Skill kSkill = null;
            if (mkSelfActor == null || mFitSkillMap.TryGetValue(uiID, out kSkill))
                return kSkill;
            
            kSkill = DBSkill.Instance.CreateSkill(uiID, mkSelfActor);
            
            if (kSkill != null)
                mFitSkillMap.Add(uiID, kSkill);
            
            return kSkill;
        }

        void TryAddSkillIds(List<uint> skillIds, uint subSkillId)
        {
            if (mkSelfActor == null || mkSelfActor.CDCtrl == null || mkSelfActor.AttackCtrl == null)
                return;
            if (mkSelfActor.CDCtrl.IsInCD(subSkillId) == false && mkSelfActor.AttackCtrl.IsMpEnough(subSkillId) == true)
            {
                skillIds.Add(subSkillId);
            }
        }

        void TryAddSkillIds(List<uint> skillIds, DBDataAllSkill.AllSkillInfo allSkillInfo, DBSkillSev.SkillInfoSev skillInfo)
        {
            if (mkSelfActor == null || mkSelfActor.CDCtrl == null || mkSelfActor.AttackCtrl == null)
                return;
            if (allSkillInfo == null || skillInfo == null)
                return;

            if (mkSelfActor.CDCtrl.IsInCD(skillInfo.Id) == false && mkSelfActor.AttackCtrl.IsMpEnough(skillInfo.Id) == true)
            {
                // 怒气技能需要判断怒气是否足够
                if (allSkillInfo.SetSlotType == DBDataAllSkill.SET_SLOT_TYPE.FurySkill)
                {
                    if (LocalPlayerManager.Instance.Fury >= skillInfo.CostFury)
                    {
                        skillIds.Add(skillInfo.Id);
                    }
                }
                else if (allSkillInfo.SetSlotType == DBDataAllSkill.SET_SLOT_TYPE.MateSKill)
                {
                    //不加入到自动
                    //nothing
                }
                else
                {
                    skillIds.Add(skillInfo.Id);
                }
            }
        }


        /// <summary>
        /// 根据技能id判断该技能是否为情侣技能
        /// </summary>
        /// <param name="skill_id">技能id</param>
        /// <returns>是否情侣技能</returns>
        public bool IsMateSkill(uint skill_id)
        {
            var db_skill_info = DBManager.Instance.GetDB<DBDataAllSkill>();
            var skill_info = db_skill_info.GetOneAllSkillInfo(skill_id);
            if (skill_info != null && skill_info.SetSlotType == DBDataAllSkill.SET_SLOT_TYPE.MateSKill)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据技能id判断该技能是否为怒气技能
        /// </summary>
        /// <param name="skill_id">技能总表id</param>
        /// <returns>是否为怒气技能</returns>
        public bool IsFurySkill(uint skill_id)
        {
            var db_skill_info = DBManager.Instance.GetDB<DBDataAllSkill>();
            var skill_info = db_skill_info.GetOneAllSkillInfo(skill_id);
            if (skill_info != null && skill_info.SetSlotType == DBDataAllSkill.SET_SLOT_TYPE.FurySkill)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据战斗表的id判断该技能是否为情侣技能
        /// </summary>
        /// <param name="skill_id">战斗表的id</param>
        /// <returns>是否情侣技能</returns>
        public bool IsMateSkillByActive(uint skill_id)
        {
            var skill_info = DBManager.Instance.GetDB<DBDataAllSkill>().GetOneAllSkillInfo_byActiveSkillId(skill_id);
            if (skill_info != null && skill_info.SetSlotType == DBDataAllSkill.SET_SLOT_TYPE.MateSKill)
                return true;
            else
                return false;
        }




        /// <summary>
        /// 根据技能选择表获取当前可用的技能
        /// </summary>
        public uint GetAvailableSkill()
        {
            if (mkSelfActor == null || mkSelfActor.IsDestroy)
            {
                return 0;
            }

            List<uint> skillIds = new List<uint>();
            skillIds.Clear();
            if(m_ShapeShifted)
            {//变身阶段
                if (mFitSkillIdPos.ContainsKey(m_ShiftFitIdx))
                {
                    foreach (var item in mFitSkillIdPos[m_ShiftFitIdx])
                    {
                        if (item.Value != null)
                        {
                            uint subSkillId = item.Value.Id;
                            if (subSkillId != 0)
                                TryAddSkillIds(skillIds, subSkillId);
                        }
                     }
                }
            }
            else
            {
                var db_skill_info = DBManager.Instance.GetDB<DBDataAllSkill>();
                DBSkillSev dbSkillSev = DBManager.Instance.GetDB<DBSkillSev>();
                if (RockCommandSystem.Instance.DataSkillsInfoArray != null)
                {
                    foreach (Net.PkgSkillsOne pkgSkillsOne in RockCommandSystem.Instance.DataSkillsInfoArray)
                    {
                        var skill_info = db_skill_info.GetOneAllSkillInfo(pkgSkillsOne.id);// 判断是否是主动技能
                        if (skill_info != null && skill_info.SkillType == DBDataAllSkill.SKILL_TYPE.Active)
                        {
                            uint subSkillId = db_skill_info.GetSubSkillIdByAllSkillId(pkgSkillsOne.id);
                            TryAddSkillIds(skillIds, skill_info, dbSkillSev.GetSkillInfo(subSkillId));
                        }
                    }
                }
            }
            
            DBSkillSelection dbSkillSelection = DBManager.GetInstance().GetDB<DBSkillSelection>();
            uint skillId = dbSkillSelection.SelectSkill(Game.Instance.GetLocalPlayer(), skillIds);

            return skillId;
        }

        public Skill GetLearnedSkill(uint uiID)
        {
            Skill kResult;
            if (mFitSkillMap.TryGetValue(uiID, out kResult))
                return kResult;

            return null;
        }
        
        /// <summary>
        /// 重置管理类的数据
        /// </summary>
        public void Reset()
        {
            mkSelfActor = null;
            mkSelfID = null;
            mFitSkillMap.Clear();
            mFitSkillIdPos.Clear();

            mFitSkillIdPos[m_NormalFitIdx] = new Dictionary<DBCommandList.OPFlag, SkillInfo>();
            mFitSkillIdPos[m_ShiftFitIdx] = new Dictionary<DBCommandList.OPFlag, SkillInfo>();
        }


        /// <summary>
        /// 添加新手副本用的技能，其他地方不能随意使用
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="skill_id"></param>
        public void SetOpeningSkill(DBCommandList.OPFlag pos, uint skill_id)
        {
            var info = new SkillInfo();
            info.Pos = pos;
            info.Id = skill_id;

            Dictionary<DBCommandList.OPFlag, SkillInfo> infos = null;

            if (mFitSkillIdPos.TryGetValue(m_NormalFitIdx, out infos))
            {
                if (info.Id != 0)
                {
                    infos[pos] = info;
                }
            }
//          else
//              GameDebug.LogError("Get FitSkillId error");

            xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.SKILL_KEY_POS_SET, null);
        }

        /// <summary>
        /// 获取技能装配点上的技能id
        /// </summary>
        public uint GetFitSkillId(uint skillPos)
        {
            SkillInfo info = null;
            if(UsingSkillConfig.TryGetValue(DBCommandList.BtnToOPFlag(skillPos), out info))
            {
                return info.Id;
            }

            return 0;
        }

        /// <summary>
        /// 获取技能装配点上的技能id
        /// </summary>
        public uint GetNormalFitSkillId(uint skillPos)
        {
            SkillInfo info = null;
            if (NormalSkillConfig.TryGetValue(DBCommandList.BtnToOPFlag(skillPos), out info))
            {
                return info.Id;
            }

            return 0;
        }

        /// <summary>
        /// 判断一个主动技能ID是否在技能槽
        /// </summary>
        /// <param name="active_skill_id">主动技能ID</param>
        /// <returns></returns>
        public bool IsFitSkillId(uint active_skill_id)
        {
            Dictionary<DBCommandList.OPFlag, SkillInfo> infos = null;

            if (mFitSkillIdPos.TryGetValue(m_NormalFitIdx, out infos))
            {
                foreach(var item in infos)
                {
                    if (item.Value.Id == active_skill_id)
                        return true;
                }
            }
            return false;
        }

        public Dictionary<uint, Skill>.ValueCollection GetLocalSkill()
        {
            return mFitSkillMap.Values;
        }

        /// <summary>
        /// 当前正在使用的技能配置
        /// </summary>
        public uint UsingtSkillConfigIndex
        {
            get
            {
                return mUsingtSkillConfigIndex;
            }
            set
            {
                mUsingtSkillConfigIndex = value;

                // TODO Complete skill set
                ResetLocalPlayerSkill();

                xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.SKILL_KEY_CONFIG_CHOOSED, null);
            }
        }

        /// <summary>
        /// 当前使用的技能配置信息
        /// </summary>
        public Dictionary<DBCommandList.OPFlag, SkillInfo> UsingSkillConfig
        {
            get
            {
                Dictionary<DBCommandList.OPFlag, SkillInfo> config = null;
                if (mFitSkillIdPos.TryGetValue(mUsingtSkillConfigIndex, out config))
                {

                }
                else
                {
                    config = new Dictionary<DBCommandList.OPFlag, SkillInfo>();
                    mFitSkillIdPos[mUsingtSkillConfigIndex] = config;
                }

                return config;
            }
        }

        /// <summary>
        /// 当前主角使用的技能配置信息（非变身）
        /// </summary>
        public Dictionary<DBCommandList.OPFlag, SkillInfo> NormalSkillConfig
        {
            get
            {
                Dictionary<DBCommandList.OPFlag, SkillInfo> config = null;
                if (mFitSkillIdPos.TryGetValue(m_NormalFitIdx, out config))
                {

                }
                else
                {
                    config = new Dictionary<DBCommandList.OPFlag, SkillInfo>();
                    mFitSkillIdPos[m_NormalFitIdx] = config;
                }

                return config;
            }
        }


        /// <summary>
        /// 设置变身技能
        /// </summary>
        /// <param name="actor_id"></param>
        void SetShapeShiftSkill(uint actor_id)
        {
            DBActor db = DBManager.Instance.GetDB<DBActor>();
            if (db == null)
                return;

            Dictionary<DBCommandList.OPFlag, SkillInfo> config = null;
            if (!mFitSkillIdPos.TryGetValue(m_ShiftFitIdx, out config))
            {
                config = new Dictionary<DBCommandList.OPFlag, SkillInfo>();
                mFitSkillIdPos[m_ShiftFitIdx] = config;
            }

            // 拿到玩家职业的默认按键信息数据
            DBActor.ActorData act_data = db.GetData(actor_id);
            if (act_data != null)
            {
                for (uint i = 0; i < act_data.skill_count; ++i)
                {
                    SkillInfo info = new SkillInfo();
                    info.Id = act_data.skill_idx[i];
                    config[DBCommandList.BtnToOPFlag(i+1)] = info;
                }
            }
        }

        /// <summary>
        /// 开始变身
        /// </summary>
        /// <param name="data"></param>
        void OnShapeShiftBegin(CEventBaseArgs data)
        {
            m_ShapeShifted = true;
            uint type_id = (uint)data.arg;
            SetShapeShiftSkill(type_id);
            UsingtSkillConfigIndex = m_ShiftFitIdx;
        }

        /// <summary>
        /// 结束变身
        /// </summary>
        /// <param name="data"></param>
        void OnShapeShiftEnd(CEventBaseArgs data)
        {
            m_ShapeShifted = false;
            UsingtSkillConfigIndex = m_NormalFitIdx;
        }

        /// <summary>
        /// 响应切换场景
        /// </summary>
        /// <param name="data"></param>
        void OnSwitchScene(CEventBaseArgs data)
        {
            // 切换场景前先恢复到默认设置
            m_ShapeShifted = false;
            UsingtSkillConfigIndex = m_NormalFitIdx;
        }

        void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_SKILLS_USING://更新技能面板上的技能列表
                    {
                        S2CSkillsUsing s2cNwarSkill = S2CPackBase.DeserializePack<S2CSkillsUsing>(data);
                        RockCommandSystem.Instance.DataSkillsUsingArray = s2cNwarSkill.skills;
                    }
                    break;
                case NetMsg.MSG_SKILLS_INFO://更新所有技能列表
                    {
                        S2CSkillsInfo s2cNwarSkill = S2CPackBase.DeserializePack<S2CSkillsInfo>(data);
                        RockCommandSystem.Instance.AddSkillList(s2cNwarSkill.skills);
                    }
                    break;
                case NetMsg.MSG_SKILLS_DELETE://删除某个技能
                    {
                        S2CSkillsDelete s2cNwarSkill = S2CPackBase.DeserializePack<S2CSkillsDelete>(data);
                        RockCommandSystem.Instance.DeleteOneSkill(s2cNwarSkill.id);
                    }
                    break;
            }
        }
    }
}