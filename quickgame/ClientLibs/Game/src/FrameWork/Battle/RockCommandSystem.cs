using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc;

namespace xc
{
    // 搓招系统
    [wxb.Hotfix]
    public class RockCommandSystem : xc.Singleton<RockCommandSystem>
    {
        public enum ClickRockButtonTipsType
        {
            None = 0,
            IsInCD = 1,
            NotEnoughMp = 2,    //Mp不够
        }
        //<主动技能ID，List<key = ClickRockButtonTipsType; value = 上次弹出提示的时间>>
        Dictionary<uint, Dictionary<ClickRockButtonTipsType, float>> m_clickRockButtonTips = new Dictionary<uint, Dictionary<ClickRockButtonTipsType, float>>();
        float m_rockButtonTipsInterval = 0;
        RockCommandSystem.ClickRockButtonTipsType m_tips_type = ClickRockButtonTipsType.None;

        List<Net.PkgSkillsPos> m_skills_using_array;    //技能面板上的技能列表
        List<Net.PkgSkillsOne> m_skills_info_array; //所有技能列表（包括主动和被动）
        List<uint> m_ActiveSkillIdList; // 所有主动技能ID的列表
        List<uint> m_new_skills_array;          //“新”学习的技能(技能总表ID)
        //已经被替换掉的技能ID（用于技能界面显示用）
        //key 是等级低的技能ID(总表ID)； value 是等级高的技能ID(总表ID)
        Dictionary<uint, uint> mHasReplaceIds = new Dictionary<uint, uint>();
        public List<Net.PkgSkillsPos> DataSkillsUsingArray
        {
            get { return m_skills_using_array; }
            set {
                m_skills_using_array = value;

                DBDataAllSkill db_all_skill = DBManager.Instance.GetDB<DBDataAllSkill>();
                
                foreach (var info in m_skills_using_array)
                {
                    uint skill_total_id = info.id;
                    uint skill_pos = info.pos;
                    var skil_total_info = db_all_skill.GetOneAllSkillInfo(skill_total_id);
                    if(skil_total_info != null)
                        SkillManager.Instance.SetOpeningSkill((DBCommandList.OPFlag)skill_pos, skil_total_info.Sub_id);
                }
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_CHANGE_LOCALPLAYER_SKILL_SLOT_LIST, null);
            }
        }

        public List<Net.PkgSkillsOne> DataSkillsInfoArray
        {
            get { return m_skills_info_array; }
//             set
//             {
//                 m_skills_info_array = value;
//             }
        }
        public bool IsLearnedSkill(uint skill_total_id)
        {
            if (m_skills_info_array == null)
                return false;
            var skillsInfo = GetOneSkillsInfo(skill_total_id);
            if (skillsInfo == null)
                return false;
            return true;
        }
        public bool Enable
		{
			get { return mEnable; }
			set { mEnable = value; }
		}
		bool mEnable = true;

		// 技能按键信息
		public class Command
		{
			public uint mSkillID = 0;// 触发的技能ID
			public DBCommandList.OPFlag CommandKey = DBCommandList.OPFlag.OP_None;//对应的按键信息
		}

        
        public RockCommandSystem()
        {
            Init();
        }

        public void Reset()
        {
            m_skills_info_array = null;
            m_ActiveSkillIdList = null;
            m_new_skills_array = null;
            m_skills_using_array = null;
            RefreshSkillLevel();
        }

        void Init()
		{
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_CLICK_BUTTON, OnClick);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_PRESS_BUTTON, OnPress);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TRIGGER_SKILL_RELEASE_BUTTON, OnRelease);

            m_skills_using_array = null;
            m_skills_info_array = null;

            m_rockButtonTipsInterval = GameConstHelper.GetFloat("GAME_ROCK_BUTTON_TIPS_INTERVAL");
        }

        /// <summary>
        /// 点击技能按钮
        /// </summary>
        /// <param name="arg"></param>
        void OnClick(CEventBaseArgs arg)
        {
            uint skill_id = System.Convert.ToUInt32(arg.arg);

            if(skill_id == 0xF0000000)
            {
                skill_id = SkillManager.Instance.GetAvailableSkill();
            }
            bool attack_succ = TrggerSkill(skill_id);

//             if(attack_succ)
//                 ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_ATTACK_SUCC, new CEventBaseArgs(skill_id));
        }

        /// <summary>
        /// 按下技能按钮
        /// </summary>
        /// <param name="arg"></param>
        void OnPress(CEventBaseArgs arg)
        {
            uint skill_id = (uint)arg.arg;

            SetPressState(skill_id, true);
        }

        /// <summary>
        /// 释放技能按钮
        /// </summary>
        /// <param name="arg"></param>
        void OnRelease(CEventBaseArgs arg)
        {
            uint skill_id = (uint)arg.arg;

            SetPressState(skill_id, false);
        }

        /// <summary>
        /// 触发技能
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
		bool TrggerSkill(uint skill_id)
        {
            LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;
            if (localPlayer == null)
                return false;

            if (!localPlayer.IsResLoaded)
                return false;

            Skill skill = localPlayer.GetSelfSkill(skill_id);
            if (skill == null)
                return false;

            if (localPlayer.AttackCtrl.IsSkillCanCast_showTipsWhenFalse(skill, 0, ref m_tips_type) == false)
            {
                if(m_tips_type != ClickRockButtonTipsType.None)
                {
                    Dictionary<ClickRockButtonTipsType, float> m_tipsData;
                    if(m_clickRockButtonTips.TryGetValue(skill_id, out m_tipsData) == false)
                    {
                        m_clickRockButtonTips[skill_id] = new Dictionary<ClickRockButtonTipsType, float>();
                        m_tipsData = m_clickRockButtonTips[skill_id];
                    }
                    if(m_tipsData.ContainsKey(m_tips_type) == false)
                    {
                        m_tipsData[m_tips_type] = 0;
                    }
                    if(Time.realtimeSinceStartup >= m_tipsData[m_tips_type] + m_rockButtonTipsInterval)
                    {
                        m_tipsData[m_tips_type] = Time.realtimeSinceStartup;
                        if (m_tips_type == ClickRockButtonTipsType.IsInCD)
                        {
                            UINotice.GetInstance().ShowMessage(DBConstText.GetText("SKILL_IN_CD"));
                        }
                        else if (m_tips_type == ClickRockButtonTipsType.NotEnoughMp)
                        {
                            UINotice.GetInstance().ShowMessage(DBConstText.GetText("MP_NOT_ENOUGH"));
                        }
                    }
                }
                
                return false;
            }

            bool needAi = false;
            if (skill.GetAction(0).ActionData.SkillInfo.Target == "rival")
            {
                needAi = true;
                //InstanceManager.Instance.IsInAutoFireOneSkillModel = true;
            }

            bool attack_succ = false;

            if (localPlayer.IsGrounded())
            {
                attack_succ = localPlayer.AttackCtrl.Attack(skill.SkillData.SkillID);

                localPlayer.MoveCtrl.Interrupt();
            }
			
			return attack_succ;
		}

        /// <summary>
        /// 设置技能的按键状态
        /// </summary>
        void SetPressState(uint skill_id, bool press)
        {
            LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;
            if (localPlayer == null)
                return;

            if (!localPlayer.IsResLoaded)
                return;

            Skill skill = localPlayer.GetSelfSkill(skill_id);
            // 在技能cd中的技能不触发
            if (skill == null)
                return;

            skill.IsPress = press;
        }

        /// <summary>
        /// 获得一个总技能ID在技能槽的数据
        /// </summary>
        /// <param name="id">总技能ID</param>
        /// <returns></returns>
        public Net.PkgSkillsPos GetOneSkillsUsing(uint id)
        {
            if (m_skills_using_array == null)
                return null;
            return m_skills_using_array.Find((a) =>
            {
                if (a.id == id)
                    return true;
                return false;
            });
        }
        public Net.PkgSkillsOne GetOneSkillsInfo(uint id)
        {
            if (m_skills_info_array == null)
                return null;
            return m_skills_info_array.Find((a) =>
            {
                if (a.id == id)
                    return true;
                return false;
            });
        }
        public void DeleteOneSkill(uint skill_id)
        {
            if (m_skills_info_array == null)
                return;
            Net.PkgSkillsOne find_item = m_skills_info_array.Find((a) =>
            {
                if (a.id == skill_id)
                    return true;
                return false;
            });
            if(find_item != null)
                m_skills_info_array.Remove(find_item);
            if(m_skills_using_array != null)
            {
                for(int index = 0; index < m_skills_using_array.Count; ++index)
                {
                    if(m_skills_using_array[index].id == skill_id)
                    {
                        m_skills_using_array.RemoveAt(index);
                        break;
                    }
                }
            }
            RefreshSkillLevel();


            //情侣技能需要把hole删除
            if (SkillManager.Instance.IsMateSkill(skill_id))
            {
                SkillHoleManager.GetInstance().DeleteSkill(skill_id);
            }

        }

        /// <summary>
        /// 获得某个技能槽的总技能ID
        /// </summary>
        /// <param name="id">总技能ID</param>
        /// <returns></returns>
        public uint GetSetTotalSkillId_bySkillPos(uint pos)
        {
            if (m_skills_using_array == null)
                return 0;
            Net.PkgSkillsPos skill_pos = m_skills_using_array.Find((a) =>
            {
                if (a.pos == pos)
                    return true;
                return false;
            });
            if (skill_pos != null)
                return skill_pos.id;
            return 0;
        }

        /// <summary>
        /// 根据服务端的数据来设置所有已开放的主动和被动技能
        /// </summary>
        /// <param name="add_skills"></param>
        public void AddSkillList(List<Net.PkgSkillsOne> add_skills)
        {
            DBDataAllSkill db_all_skill = DBManager.Instance.GetDB<DBDataAllSkill>();

            // 获取新的技能的id，需要在返回野外的时候表现获取的动画，同时获得多个时，只表现最后一个技能的动画
            uint new_active_skill_id = 0;

            if (m_skills_info_array == null)
            {
                m_skills_info_array = new List<Net.PkgSkillsOne>();
                if (m_new_skills_array == null)
                {
                    m_new_skills_array = new List<uint>();
                    // m_new_skills_array的数据 用于在技能系统面板中显示'新'的标识
                    string newSkillSaveNameStr = string.Format("{0}NewSkillList", Game.GetInstance().LocalPlayerID.obj_idx);
                    string newSkillListStr = UserPlayerPrefs.GetInstance().GetString(newSkillSaveNameStr, "");
                    string[] substr = newSkillListStr.Split(',');
                    uint skill_id = 0;
                    for (int index = 0; index < substr.Length; ++index)
                    {
                        string cur = substr[index];

                        if (uint.TryParse(cur, out skill_id))
                        {
                            if (skill_id != 0)
                                m_new_skills_array.Add(skill_id);
                        }
                    }
                }
            }
            else // m_skills_info_array不为空时
            {
                bool add_newLearnSkill = false;
                foreach (var item in add_skills)
                {
                    if (m_new_skills_array.Contains(item.id) == false)
                    {
                        m_new_skills_array.Add(item.id);
                        add_newLearnSkill = true;
                    }

                    // 判断是否有新获取的主动技能
                    var skil_info = db_all_skill.GetOneAllSkillInfo(item.id);
                    if (skil_info != null && skil_info.SkillType == DBDataAllSkill.SKILL_TYPE.Active)
                    {
                        if (m_ActiveSkillIdList != null && !m_ActiveSkillIdList.Contains(item.id))
                        {
                            new_active_skill_id = item.id;
                        }
                    }
                }

                if (add_newLearnSkill)
                {
                    SaveNewSkillList();
                }
            }

            m_skills_info_array.AddRange(add_skills);
            if(m_ActiveSkillIdList == null)
                m_ActiveSkillIdList = new List<uint>();

            // 获取已经开放的技能列表，来设置固定装配位置的技能
            foreach (var info in m_skills_info_array)
            {
                // 不处理被动技能
                var skil_info = db_all_skill.GetOneAllSkillInfo(info.id);
                if (skil_info == null || skil_info.SkillType != DBDataAllSkill.SKILL_TYPE.Active)
                    continue;

                if (m_ActiveSkillIdList.Contains(info.id) == false)
                {
                    //GameDebug.LogError("m_ActiveSkillIdList " + info.id);
                    m_ActiveSkillIdList.Add(info.id);// 将技能id添加到列表中
                }
                // 固定技能槽的位置
                if (skil_info.Can_set_key == false)
                {
                    SkillManager.Instance.SetOpeningSkill((DBCommandList.OPFlag)skil_info.FixedKeyPos, skil_info.Sub_id);
                }
                else
                {
                    uint skill_pos = SkillHoleManager.Instance.GetOpenSkillHole(skil_info.Id);
                    if (skill_pos != 0)
                    {
                        // 对应位置没有装配的时候自动设置
                        uint has_exist_skill_id_in_slot = SkillManager.Instance.GetNormalFitSkillId(skill_pos);
                        bool needSetOpeningSkill = false;
                        if (has_exist_skill_id_in_slot == 0)
                            needSetOpeningSkill = true;
                        else if (skil_info.ReplaceIds != null)
                        {
                            DBDataAllSkill.AllSkillInfo all_info = db_all_skill.GetOneAllSkillInfo_byActiveSkillId(has_exist_skill_id_in_slot);
                            if (all_info != null && skil_info.ReplaceIds.Contains(all_info.Id))
                            {//技能升级，直接替换
                                needSetOpeningSkill = true;
                            }
                        }
                        if(needSetOpeningSkill)
                        {
                            SkillManager.Instance.SetOpeningSkill((DBCommandList.OPFlag)skill_pos, skil_info.Sub_id);
                        }
                    }
                }

                if (info.id == new_active_skill_id)// 是新获取的技能，需要进行动画表现
                {
                    //GameDebug.LogError("[OpenNewSkill] info.id = " + info.id);
                    SkillHoleManager.Instance.OpenNewSkill(info.id);
                }
                else // 直接开启对应的技能孔
                {
                    //GameDebug.LogError("[OpenSkill] info.id = " + info.id);
                    SkillHoleManager.Instance.OpenSkill(info.id);
                }
            }
            RefreshSkillLevel();
        }

        void SaveNewSkillList()
        {
            string newSkillSaveNameStr = string.Format("{0}NewSkillList", Game.GetInstance().LocalPlayerID.obj_idx);
            System.Text.StringBuilder newSkillListBuilder = new System.Text.StringBuilder();
            for (int index = 0; index < m_new_skills_array.Count; ++index)
            {
                if (index != m_new_skills_array.Count - 1)
                {
                    newSkillListBuilder.AppendFormat("{0},", m_new_skills_array[index]);
                }
                else
                    newSkillListBuilder.AppendFormat("{0}", m_new_skills_array[index]);
            }
            UserPlayerPrefs.GetInstance().SetString(newSkillSaveNameStr, newSkillListBuilder.ToString());
            UserPlayerPrefs.GetInstance().Save();
        }

        /// <summary>
        /// 判断一个技能是否是新学习的技能
        /// </summary>
        /// <param name="skill_total_id"></param>
        /// <returns></returns>
        public bool IsNewLearnSkill(uint skill_total_id)
        {
            if (m_new_skills_array == null)
                return false;
            return m_new_skills_array.Contains(skill_total_id);
        }

        /// <summary>
        /// 从“新学习”技能列表中删除某个技能
        /// </summary>
        /// <param name="skill_total_id"></param>
        public void RemoveFromNewLearnSkillList(uint skill_total_id)
        {
            if (m_new_skills_array != null)
            {
                if(m_new_skills_array.Remove(skill_total_id))
                    SaveNewSkillList();
            }
        }

        public void RefreshSkillLevel()
        {
            mHasReplaceIds.Clear();
            if (m_skills_info_array == null)
                return;
            DBDataAllSkill db_all_skill = DBManager.Instance.GetDB<DBDataAllSkill>();
            for (int index = 0; index < m_skills_info_array.Count; ++index)
            {
                uint all_skill_id = m_skills_info_array[index].id;
                DBDataAllSkill.AllSkillInfo info = db_all_skill.GetOneAllSkillInfo(all_skill_id);
                if(info != null && info.ReplaceIds != null)
                {
                    foreach(var item in info.ReplaceIds)
                    {
                        if(mHasReplaceIds.ContainsKey(item) == false)
                            mHasReplaceIds.Add(item, all_skill_id);
                        else
                        {
                            GameDebug.LogRed(string.Format("old_skill_id = {0} new_skill_id",
                                mHasReplaceIds[item], all_skill_id));
                        }
                    }
                }
            }
        }

        public bool IsInReplaceIds(uint all_skill_id)
        {
            return mHasReplaceIds.ContainsKey(all_skill_id);
        }

        /// <summary>
        /// 获得最新的技能ID
        /// </summary>
        /// <param name="all_skill_id"></param>
        /// <returns></returns>
        public uint GetLastestSkillId(uint all_skill_id)
        {
            if (mHasReplaceIds.ContainsKey(all_skill_id))
                return mHasReplaceIds[all_skill_id];
            return all_skill_id;
        }
    }
}