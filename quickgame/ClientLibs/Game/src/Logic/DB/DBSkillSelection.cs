/*----------------------------------------------------------------
// 文件名： DBSkillSelection.cs
// 文件功能描述： 技能选择表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSkillSelection : DBSqliteTableResource
    {
        public enum ECondition
        {
            None = 0,
            Low_HP,             // 生命低于某百分比
            In_PVP,             // PVP环境下（目标是玩家）
            Target_Num_More,    // 周围目标数量大于X个
            Low_Level,          // 自身等级低于N级
            HaveBuff,           // 是否携带指定BUFF
            In_PVE,             // PVE环境下（目标非玩家）
            Must_Be_Using,      // 必须先安装
        }

        public class SkillSelectionInfo : IComparable
        {
            public uint SkillId;            // 技能ID
            public uint Priority;           // 优先级
            public ECondition Condition;    // 特定条件
            public string Param;            // 条件参数

            public int CompareTo(object obj)
            {
                SkillSelectionInfo skillSelectionInfo = (SkillSelectionInfo)obj;

                if (this.Priority < skillSelectionInfo.Priority)
                {
                    return -1;
                }

                return 0;
            }
        }
        Dictionary<uint, SkillSelectionInfo> mSkillSelectionInfos = new Dictionary<uint, SkillSelectionInfo>();
        
        public DBSkillSelection(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public SkillSelectionInfo GetSkillSelectionInfo(uint skillId)
        {
            if (mSkillSelectionInfos.ContainsKey(skillId) == true)
            {
                return mSkillSelectionInfos[skillId];
            }

            return null;
        }

        /// <summary>
        /// 该技能是否满足施放条件
        /// </summary>
        public bool CheckSkillCondition(Actor actor, SkillSelectionInfo skillSelectionInfo)
        {
            if (skillSelectionInfo.Priority > 0)
            {
                if (skillSelectionInfo.Condition == ECondition.None)
                {
                    return true;
                }
                else if (skillSelectionInfo.Condition == ECondition.Low_HP)
                {
                    if (actor != null)
                    {
                        float hpRatio = 0f;
                        float.TryParse(skillSelectionInfo.Param, out hpRatio);
                        if ((float)((double)actor.CurLife / (double)actor.FullLife) < (hpRatio / 100f))
                        {
                            return true;
                        }
                    }
                }
                else if (skillSelectionInfo.Condition == ECondition.In_PVP)
                {
                    bool ret = false;
                    // 目标是玩家
                    if (actor != null)
                    {
                        if (actor.AttackCtrl != null && actor.AttackCtrl.CurSelectActor != null)
                        {
                            Actor target = actor.AttackCtrl.CurSelectActor.BindActor;
                            if (target is Player)
                            {
                                ret = true;
                            }
                        }
                    }
                    return ret;
                }
                else if (skillSelectionInfo.Condition == ECondition.Target_Num_More)
                {
                    // TODO
                }
                else if (skillSelectionInfo.Condition == ECondition.Low_Level)
                {
                    if (actor != null)
                    {
                        uint level = 0;
                        uint.TryParse(skillSelectionInfo.Param, out level);
                        if (actor.Level < level)
                        {
                            return true;
                        }
                    }
                }
                else if (skillSelectionInfo.Condition == ECondition.HaveBuff)
                {
                    if (actor != null)
                    {
                        uint buffId = 0;
                        uint.TryParse(skillSelectionInfo.Param, out buffId);
                        if (actor.BuffCtrl.HasActive(buffId) == false)
                        {
                            return true;
                        }
                    }
                }
                else if (skillSelectionInfo.Condition == ECondition.In_PVE)
                {
                    bool ret = false;
                    // 目标非玩家
                    if (actor != null)
                    {
                        if (actor.AttackCtrl != null && actor.AttackCtrl.CurSelectActor != null)
                        {
                            Actor target = actor.AttackCtrl.CurSelectActor.BindActor;
                            if ((target is Player) == false)
                            {
                                ret = true;
                            }
                        }
                    }
                    return ret;
                }
                else if (skillSelectionInfo.Condition == ECondition.Must_Be_Using)
                {
                    return SkillManager.Instance.IsFitSkillId(skillSelectionInfo.SkillId);
                }
            }

            return false;
        }

        List<SkillSelectionInfo> skillSelectionInfos = new List<SkillSelectionInfo>();
        /// <summary>
        /// 选择技能
        /// </summary>
        public uint SelectSkill(Actor actor, List<uint> skillIds)
        {
            skillSelectionInfos.Clear();
            foreach (uint skillId in skillIds)
            {
                // 检查角色可攻击状态和技能清除debuff
                if (actor != null && actor.AttackCtrl != null)
                {
                    if (actor.AttackCtrl.IsAttackDisable(skillId) == true)
                    {
                        continue;
                    }
                }

                SkillSelectionInfo skillSelectionInfo = GetSkillSelectionInfo(skillId);
                if (skillSelectionInfo != null)
                {
                    skillSelectionInfos.Add(skillSelectionInfo);
                }
            }
            skillSelectionInfos.Sort();

            uint minPriority = 0;
            if (skillSelectionInfos.Count > 0)
            {
                minPriority = skillSelectionInfos[0].Priority;
            }
            else
            {
                return 0;
            }

            List<SkillSelectionInfo> toSelectSkillSelectionInfos = GetMeetConditionSkills(actor, skillSelectionInfos, minPriority);

            if (toSelectSkillSelectionInfos.Count > 0)
            {
                int rand = UnityEngine.Random.Range(0, toSelectSkillSelectionInfos.Count);
                return toSelectSkillSelectionInfos[rand].SkillId;
            }

            return 0;
        }

        /// <summary>
        /// 获取指定优先级且满足特定条件的技能列表
        /// </summary>
        /// <param name="skillSelectionInfos 待筛选的技能列表"></param>
        /// <param name="minPriority 最小优先级，这个优先级找不到就找下一个优先级的，如此递增"></param>
        /// <returns></returns>
        public List<SkillSelectionInfo> GetMeetConditionSkills(Actor actor, List<SkillSelectionInfo> skillSelectionInfos, uint minPriority)
        {
            List<SkillSelectionInfo> retSkillSelectionInfos = new List<SkillSelectionInfo>();

            foreach (SkillSelectionInfo skillSelectionInfo in skillSelectionInfos)
            {
                if (skillSelectionInfo.Priority == minPriority && CheckSkillCondition(actor, skillSelectionInfo) == true)
                {
                    retSkillSelectionInfos.Add(skillSelectionInfo);
                }
            }

            if (retSkillSelectionInfos.Count == 0)
            {
                uint nextPriority = GetNextPriority(skillSelectionInfos, minPriority);
                if (nextPriority > 0)
                {
                    return GetMeetConditionSkills(actor, skillSelectionInfos, nextPriority);
                }
            }

            return retSkillSelectionInfos;
        }

        /// <summary>
        /// 获取下一个优先级
        /// </summary>
        public uint GetNextPriority(List<SkillSelectionInfo> skillSelectionInfos, uint priority)
        {
            for (int i = 0; i < skillSelectionInfos.Count; ++i)
            {
                SkillSelectionInfo skillSelectionInfo = skillSelectionInfos[i];
                if (skillSelectionInfo.Priority == priority && i < (skillSelectionInfos.Count - 1) && skillSelectionInfo.Priority != skillSelectionInfos[i + 1].Priority)
                {
                    return skillSelectionInfos[i + 1].Priority;
                }
            }

            return 0;
        }

        public override void Unload()
        {
            base.Unload();
            mSkillSelectionInfos.Clear();
        }
        
        protected override void ParseData(SqliteDataReader reader)
        {
            mSkillSelectionInfos.Clear();
            SkillSelectionInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new SkillSelectionInfo();

                        info.SkillId = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Priority = DBTextResource.ParseUI_s(GetReaderString(reader, "priority"), 0);
                        string conditionStr = GetReaderString(reader, "condition");
                        if (string.IsNullOrEmpty(conditionStr) == true)
                        {
                            info.Condition = ECondition.None;
                        }
                        else
                        {
                            info.Condition = (ECondition)System.Enum.Parse(typeof(ECondition), conditionStr);
                        }
                        info.Param = GetReaderString(reader, "param");

#if UNITY_EDITOR
                        if (mSkillSelectionInfos.ContainsKey(info.SkillId))
                        {
                            GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.SkillId));
                            continue;
                        }
#endif
                        mSkillSelectionInfos.Add(info.SkillId, info);
                    }
                }
            }
        }
    }
}
