using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Utils;

namespace xc
{
	public class DBSkill:xc.Singleton<DBSkill>
	{	
        private Dictionary<uint, SkillData> mClientSkillInfos;//客户端的技能表格数据
        Dictionary<uint, HierarchyInfo> mSkillHierarchyInfos;//技能实际ID与父技能ID的索引

        public class SkillData
		{
            // 技能Root节点的ID
			public uint SkillID;
            // 父技能的ID
            public uint SkillParentID;	
			// 子技能
			public List<SkillActionData> SkillActionList;

			public static SkillData CreateSkillData(DBSkillSev.SkillInfoSev info)
			{
                SkillData skill_data = new SkillData();
                skill_data.SkillID = info.Id;
                skill_data.SkillParentID = info.ParentSkillId;
                skill_data.SkillActionList = new List<SkillActionData>();

                var action_data = SkillActionData.CreateSkillActionData(info);

                skill_data.SkillActionList.Add(action_data);

                return skill_data;
            }
		}
		
		public class SkillActionData
		{
			public string SkillAnimation;					    // 技能动画名称
            public string CastingReadyAnimation = string.Empty;       // 吟唱阶段的动画
			public string CastingAnimation = string.Empty;	    // 施法阶段动画
            public string CastingEndAnimation = string.Empty;   // 施法结束动画

            // 各阶段的持续时间和时间点
			public float CastStageTime = 0.0f;					// 前摇阶段的时长
            public float CastingReadyStageTime = 0.0f;          // 吟唱时间

            public float CastingStageTime = 0.0f;				// 施法阶段时长
            public float RigidityTime = 0.0f;                   // 硬直时间点
            public float RigidityStageTime = 0.0f;              // 硬直阶段的时长
            public float EndStageTime = -1.0f;					// 结束阶段的时长
            public float CacheTime = 0.0f;                      // 技能缓存时长,只有当技能时间大于该缓存时间时，才能释放下一个技能
						
			public DBSkillSev.SkillInfoSev SkillInfo;

            public static SkillActionData CreateSkillActionData(DBSkillSev.SkillInfoSev info)
            {
                SkillActionData skill_action_data = new SkillActionData();

                skill_action_data.SkillInfo = info;
                skill_action_data.SkillAnimation = info.AnimationName;
                skill_action_data.CastingAnimation = info.CastingAnimationName;
                skill_action_data.CastingReadyAnimation = info.CastingReadyName;
                skill_action_data.CastingEndAnimation = info.CastingEndAnimationName;
                skill_action_data.RigidityTime = info.RigidityTime;
                skill_action_data.CacheTime = info.CacheTime;

                // 计算各阶段时间
                skill_action_data.CalcTimePoint(1.0f);

                return skill_action_data;
            }

            /// <summary>
            /// 计算技能释放各阶段的时间点
            /// </summary>
            private void CalcTimePoint( float speedScale)
            {
                // 计算前摇段的时长
                CastStageTime = SkillInfo.ForwardTime / speedScale;

                //计算吟唱的时长
                CastingReadyStageTime = SkillInfo.MaxSingTime;

                // 计算施法段的时长
                CastingStageTime = SkillInfo.CastingTime; // 施法阶段暂不受攻速影响

                // 计算硬直段的时长
                RigidityStageTime = RigidityTime - SkillInfo.ForwardTime;
                if (RigidityStageTime < 0)
                {
                    GameDebug.LogError(string.Format("skill[{0}]:RigidityFrame不能小于前摇时间", SkillInfo.Id));
                    RigidityTime = SkillInfo.ForwardTime;
                    RigidityStageTime = 0;
                }
                RigidityStageTime = RigidityStageTime / speedScale;

                EndStageTime = -1;

                //CacheTime = Mathf.Clamp(CacheTime, 0, RigidityTime);
                // 如果缓存时间大于前摇时间，则缓存时间 = 施法时间+缓存帧时间
                //if (CachePoint > CastPoint)
                //{
                //  CachePoint += (SkillAnimation != CastingAnimation ? GetCastingLength() : 0.0f);
                //}
            }
			
            /// <summary>
            /// 更新技能的结束时间点，依赖于动作的时长
            /// </summary>
			public void UpdateEndPoint(float fAnimationLength)
			{
                if (fAnimationLength == 0.0f)
                    return;

				if (EndStageTime < 0.0f)
				{
                    EndStageTime = fAnimationLength - RigidityTime;
                    if(EndStageTime < 0)
                    {
                        EndStageTime = 0;
                        GameDebug.Log("[UpdateEndPoint]EndTime less zero");
                    }
                }
			}
		}
				
		public class HierarchyInfo
        {
			public uint ParentID;//父技能的ID
			public int HierarchyIndex;//当前技能在父技能列表中的索引
		}
		
		public DBSkill()
		{
            mClientSkillInfos = new Dictionary<uint, SkillData>();
            mSkillHierarchyInfos = new Dictionary<uint, HierarchyInfo>();
        }
		
		public void Unload()
		{
            mSkillHierarchyInfos.Clear();
            mClientSkillInfos.Clear();
		}
		
        /// <summary>
        /// 从技能ID获取父/子技能关系
        /// </summary>
        /// <param name="skill_id"></param>
        /// <returns></returns>
		public HierarchyInfo GetHierarchyInfo(uint skill_id)
		{
            HierarchyInfo info = null;
			if (!mSkillHierarchyInfos.TryGetValue(skill_id, out info))
            {
                var skill_info = DBSkillSev.Instance.GetSkillInfo(skill_id);

                // 有子技能
                if(skill_info != null && skill_info.ParentSkillId != 0)
                {
                    info = new HierarchyInfo();
                    info.ParentID = skill_info.ParentSkillId;

                    // 计算当前子技能的序号
                    var parent_skill_info = DBSkillSev.Instance.GetSkillInfo(skill_info.ParentSkillId);
                    if (parent_skill_info != null)
                    {
                        int index = 0;
                        var cur_skill_info = parent_skill_info;
                        while (cur_skill_info.ChildSkillId != 0 && cur_skill_info.Id != skill_info.Id)
                        {
                            cur_skill_info = DBSkillSev.Instance.GetSkillInfo(cur_skill_info.ChildSkillId);
                            if (cur_skill_info == null)
                            {
                                GameDebug.LogError("cur_skill_info is null, id:" + cur_skill_info.ParentSkillId);
                                break;
                            }

                            index++;
                        }
                        info.HierarchyIndex = index;
                    }
                    else
                        GameDebug.LogError("parent_skill_info is null, id:" + skill_info.ParentSkillId);

                    mSkillHierarchyInfos[skill_id] = info;
                }
            }
			
			return info;
		}

        /// <summary>
        /// 从指定的字典中获取对应的key的value
        /// </summary>
        /// <param name="info"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetString(Dictionary<string, string> info, string key)
        {
            string value = string.Empty;
            info.TryGetValue(key, out value);
            return value;
        }

        public Skill CreateSkill(uint skill_id, Actor owner)
		{
            SkillData skill_data = null;
            if(!mClientSkillInfos.TryGetValue(skill_id, out skill_data))
            {
                var skill_info = DBSkillSev.Instance.GetSkillInfo(skill_id);
                if(skill_info != null)
                {
                    skill_data = SkillData.CreateSkillData(skill_info);

                    // 如果有子技能
                    if(skill_info.ParentSkillId != 0 && skill_info.ParentSkillId == skill_info.Id)
                    {
                        var cur_skill_data = skill_info;
                        while (cur_skill_data.ChildSkillId != 0)
                        {
                            var child_skill_info = DBSkillSev.Instance.GetSkillInfo(cur_skill_data.ChildSkillId);
                            if (child_skill_info == null)
                                break;

                            var child_action_data = SkillActionData.CreateSkillActionData(child_skill_info);

                            if (!skill_data.SkillActionList.Contains(child_action_data))
                                skill_data.SkillActionList.Add(child_action_data);

                            cur_skill_data = child_skill_info;
                        }
                    }
                }
            }

            if (skill_data != null)
            {
                Skill skill = new Skill(skill_data);
                skill.SetCaster(owner);
                return skill;
            }

            return null;
		}		
	}
}
