//------------------------------------------------------------------------------
// File ： CooldownCtrl.cs
// Desc ： 各类型的冷却控制器，可以被技能CD等使用
//         可以作为任何类型的成员变量，由外部来维护每个冷却的type_idx表示什么含义
// Author : raorui 
// Date : 2016.9.21 Comments
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class CooldownCtrl : BaseCtrl
    {
        public CooldownCtrl(Actor owner) : base(owner)
		{
        }

        public void SetOwner(Actor owner)
        {
            mOwner = owner;
        }

        public class CDInstance
		{
			public uint type_idx = 0; // cd的id
			public uint life_time = 0;// cd的生命周期
			public uint time = 0;// 当前的cd时间
			
            /// <summary>
            /// 更新cd, return true 时表示冷却时间到
            /// </summary>
			public bool Update()
			{
				time += (uint)(Time.deltaTime * 1000.0f);
				if (time >= life_time)
				{
					time = life_time;
					return true;
				}
				return false;
			}
			
            /// <summary>
            /// 从技能信息中获取cd时间
            /// </summary>
            public void Init(uint skill_id, float skillCDReduce)
			{
                type_idx = skill_id;
                time = 0;

				DBSkillSev skill_db = DBManager.GetInstance().GetDB<DBSkillSev>();
				if (skill_db == null)
				{
					GameDebug.LogError("skill database not exsit!");
					return;
				}

				DBSkillSev.SkillInfoSev skill_info = skill_db.GetSkillInfo(type_idx);
				if (skill_info == null)
					GameDebug.LogError("skillInfo is null! type_idx: " + type_idx);
				else
                    life_time = (uint)(Mathf.Max(skill_info.CDTime, 0) * (1f - skillCDReduce));
			}

            /// <summary>
            /// 从外部数据设置cd时间
            /// </summary>
            public void Init(uint skill_id, uint cd_life_time, float skillCDReduce)
            {
                type_idx = skill_id;
                time = 0;
                life_time = (uint)(Mathf.Max(cd_life_time, 0) * (1f - skillCDReduce));
            }

            public bool IsInCD()
            {
                if (time >= life_time)
                    return false;
                return true;
            }

            /// <summary>
            /// 返回技能CD的百分比（0表示CD已经走完；1表示刚开始技能CD）
            /// </summary>
            /// <returns></returns>
            public float GetCDPercent()
            {
                if (time >= life_time)
                {
                    time = life_time;
                    return 0;
                }
                return 1 - 1.0f * time / life_time;
            }

            /// <summary>
            /// 获取剩余的cd时间
            /// </summary>
            /// <returns></returns>
            public float GetRemainSeconds()
            {
                if (time >= life_time)
                {
                    time = life_time;
                    return 0;
                }
                return (life_time - time) / 1000.0f;
            }
		}

		Dictionary<uint, CDInstance> mCDInstances = new Dictionary<uint, CDInstance>();//所有的cd数据
        List<uint> m_IgnoreSkills = new List<uint>();// 需要被忽略cd的技能，在GM指令中使用
		List<uint> m_DeadCDs = new List<uint>(); // 已经到时间,需要被销毁的cd列表

        /// <summary>
        /// 启动CD计时
        /// </summary>
        /// <param name="type_idx"></param>
        public void StartCD(uint type_idx)
		{
#if UNITY_EDITOR
            if (m_IgnoreSkills.Contains(type_idx))
                return;
#endif
			if (mCDInstances.ContainsKey(type_idx))
				return;

            CDInstance cd = new CDInstance();
            uint cd_life_time = CooldownManager.Instance.GetCDFromServer(type_idx);

            // 角色属性里面的技能cd减少
            float skillCDReduce = 0f;
            if (mOwner != null)
            {
                skillCDReduce = mOwner.ActorAttribute.Attribute[GameConst.AR_SKILL_CD_REDUCE].Value / 10000f;
            }
            if  (skillCDReduce < 0f || skillCDReduce > 1f)  // 边界检查
            {
                GameDebug.LogError("Actor " + mOwner.UID.obj_idx + "'s skill cd reduce attr is " + skillCDReduce + ", is a wrong value!!!");
                if (skillCDReduce < 0f)
                {
                    skillCDReduce = 0f;
                }
                if (skillCDReduce > 1f)
                {
                    skillCDReduce = 1f;
                }
            }

            if (cd_life_time != 0)
                cd.Init(type_idx, cd_life_time, skillCDReduce);
            else
                cd.Init(type_idx, skillCDReduce);
			mCDInstances.Add(type_idx, cd);
			return;
		}
		
        /// <summary>
        /// 移除某一技能的cd
        /// </summary>
        /// <param name="type_idx"></param>
        public void RemoveCD(uint type_idx)
        {
            if(mCDInstances.ContainsKey(type_idx))
            {
                mCDInstances.Remove(type_idx);
            }

#if UNITY_EDITOR
            if (!m_IgnoreSkills.Contains(type_idx))
                m_IgnoreSkills.Add(type_idx);
#endif
        }
		
		/// <summary>
        /// 技能是否在CD中
        /// type_idx 对应技能id
        /// </summary>
        /// <returns><c>true</c> if this instance is in C the specified type_idx; otherwise, <c>false</c>.</returns>
		public bool IsInCD(uint type_idx)
		{
            CDInstance find_cd;
            if (mCDInstances.TryGetValue(type_idx, out find_cd) == false)
                return false;
            return find_cd.IsInCD();
        }

        /// <summary>
        /// 获取CD的数据
        /// type_idx 可以对应技能id
        /// </summary>
		public CDInstance GetCDInstance(uint type_idx)
		{
			CDInstance kResult;
			if (mCDInstances.TryGetValue(type_idx, out kResult))
			{
				return kResult;
			}
			
			return null;
		}
		
        /// <summary>
        /// 更新CDCtrl
        /// </summary>
		public override void Update()
		{
            base.Update();

            using (var enumerator = mCDInstances.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var cur = enumerator.Current.Value;

                    if (cur.Update())
                    {
                        m_DeadCDs.Add(cur.type_idx);
                    }
                }
            }

                //foreach (CDInstance cd in mCDInstances.Values)
                //{
                //    if (cd.Update())
                //        m_DeadCDs.Add(cd.type_idx);
                //}

            // 删除不需要的cd
            if (m_DeadCDs.Count > 0)
            {
                foreach (uint type_idx in m_DeadCDs)
                {
                    mCDInstances.Remove(type_idx);
                }
                m_DeadCDs.Clear();
            }
		}

        
	}
}

