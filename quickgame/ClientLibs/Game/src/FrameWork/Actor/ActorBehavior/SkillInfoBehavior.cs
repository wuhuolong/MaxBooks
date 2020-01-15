//------------------------------------------------------------------------------
// Desc: 包含角色技能信息的组件
// Date: 2016.7.4
// Author: raorui
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class SkillInfoBehavior : IActorBehavior
    {
        // ------------------------------------------------
        // 接口的实现
        // ------------------------------------------------
        public override void InitBehaviors()
        {
            
        }
        
        public override void Update()
        {

        }
        
        
        public override void LateUpdate()
        {
            
        }
        
        public override void UnInitBehaviors()
        {
            base.UnInitBehaviors();

            mSkillIDList.Clear();
            foreach (Skill skill in mSkillMap.Values)
            {
                if(skill != null)
                    skill.SetCaster(null);
            }
            mSkillMap.Clear();
        }
        
        
        // leaf
        public override void EnableBehaviors(bool enable)
        {

        }

        // ------------------------------------------------
        // 组件的类型定义
        // ------------------------------------------------


        // ------------------------------------------------
        // 组件的变量定义
        // ------------------------------------------------
        List<Actor.SkillCastInfo> mSkillIDList = new List<Actor.SkillCastInfo>();
        protected Dictionary<uint, Skill> mSkillMap = new Dictionary<uint, Skill>();

        // ------------------------------------------------
        // 组件的内部方法
        // ------------------------------------------------

        // ------------------------------------------------
        // 组件的外部接口
        // ------------------------------------------------
        public SkillInfoBehavior(Actor act)
        {
            mOwner = act;
        }

        public uint NormalAttackID
        {
            get
            {
                if (mSkillIDList.Count >= 1)
                    return mSkillIDList [0];
                return 0xffffffff;
            }
        }

        /// <summary>
        /// 设置技能id到列表中，默认权重为100
        /// </summary>
        public void SetSkillCastInfo(List<uint> skillList)
        {
            if(skillList == null || skillList.Count <= 0)
                return;
            
            mSkillIDList.Clear();
            for(int  i =0 ;i < skillList.Count; ++i)
            {
                uint uiSkillID = skillList[i];
                mSkillIDList.Add(new Actor.SkillCastInfo(uiSkillID, 100));
            }
        }

        /// <summary>
        /// 添加技能id和释放的权重到技能列表中
        /// </summary>
        public void AddSkillCastInfo(uint uiSkillID, ushort rate)
        {
            foreach (Actor.SkillCastInfo kInfo in mSkillIDList)
            {
                if (kInfo.muiID == uiSkillID)
                    return;
            }
            
            mSkillIDList.Add(new Actor.SkillCastInfo(uiSkillID, rate));
        }

        /// <summary>
        /// 得到技能Cast Info
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public Actor.SkillCastInfo GetSkillCastInfo(uint skillId)
        {
            foreach (var item in mSkillIDList)
            {
                if(item.muiID == skillId)
                {
                    return item;
                }
            }
            
            return null;
        }

        /// <summary>
        /// 根据序号来获取技能
        /// </summary>
        public Actor.SkillCastInfo GetSkillIDByIndex(int index) // 根据idx获取技能数据
        {
            if (index < mSkillIDList.Count)
                return mSkillIDList [index];
            GameDebug.LogError(string.Format("GetSkillIDByIndex index[{0}] is out of range[{1}]", index, mSkillIDList.Count));
            return null;
        }

        /// <summary>
        /// 用于怪物ai和机器人ai中
        /// </summary>
        public int GetSkillCount()
        {
            return mSkillIDList.Count;
        }

        public Skill GetSelfSkill(uint skillID)
        {
            // 当前没有使用的技能，使用新的仅能
            // 先查看是否能使用这个技能
            Skill targetSkill;
            if (!mSkillMap.TryGetValue(skillID, out targetSkill) || targetSkill == null)
            {   
                // 能使用，看看否曾经使用过，没有则从DBSkill中创建一个
                targetSkill = DBSkill.Instance.CreateSkill(skillID, mOwner);
                mSkillMap [skillID] = targetSkill;          // 记录曾经使用过这个技能          
            }
            
            return targetSkill;
        }
    }
}

