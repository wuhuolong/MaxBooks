//------------------------------------------------------------------------------
// 文件名 ： DBSkillSev.cs
// 描述   ： 技能战斗表的读取
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSkillSev : DBSqliteTableResource
    {
        public const string TARGETLIMIT_PVP_STR = "pvp";
        public const string TARGETLIMIT_PVE_STR = "pve";
        public class SkillInfoSev
        {
            public uint Id;          // 技能id
            public bool IsPg;       // 是否普攻
            public bool FindTarget;  // 技能是否锁定目标
            public uint FindTargetType; //锁定目标的类型 (0: 不锁定， 1: 锁定 2: 锁定主人（用于宠物）)
            public string TargetLimit;  //是否限定PVP或者PVE
            public bool IsTrigger; //是否是触发类技能
            public uint CDTime;      // 技能cd时间的长度
            public float Range;      // 技能的攻击范围
            private int mMpCost;       //技能能量消耗
            public float ForwardSpeed;//前摇阶段的移动速度
            public float ForwardTime;//前摇阶段的时间
            public float MaxSingTime;   //吟唱阶段的时间
            public float CastingSpeed;//施法阶段的移动速度
            public float CastingTime;//施法阶段的时间
            public string Target;   // 施法对象
            public List<float> MultiHitRatios;
            public List<float> MultiHitDelayTimes;
            public uint BulletId;// 追踪目标的子弹ID   
            public BulletTrackInstance BulletTrace;// 追踪目标类型的子弹
            public DBBattleFx.BattleFxInfo BattleFxInfo; // 受击的效果信息

            public uint ParentSkillId; //父技能的ID
            public uint ChildSkillId; //子技能的ID
            public string AnimationName;//技能动作的名字
            public string Sound; // 技能音效的名字(仅用于通用一套动作的技能)
            public string CastingReadyName;     //吟唱动作的名字
            public string CastingAnimationName;// 施法动作的名字
            public string CastingEndAnimationName; //施法结束后动作的名字
            public float RigidityTime;//技能的硬直帧(毫秒)
            public float CacheTime;//技能的缓存帧(毫秒)
            public string SkillAnnounce; //技能喊话

            public bool IsFalseHitBack;   //是否假击退

            public bool Invisible;   // 释放技能时是否隐身

            public uint CostFury; //怒气消耗
            public uint GenFury;    //产生怒气

            public List<string> UiEffectIconList; // 技能特效图标名列表
            public string UiEffectSoundName; // 技能音效

            /// <summary>
            /// 获得当前职业的蓝量消耗
            /// </summary>
            public int MpCost
            {
                get
                {
                    return mMpCost;
                }
                set
                {
                    mMpCost = value;
                }
            }
        }

        private Dictionary<uint, SkillInfoSev> mSkillInfoMap = new Dictionary<uint, SkillInfoSev>();
        
        static DBSkillSev mkInstance = null;

        public static DBSkillSev GetInstance()
        {
            return mkInstance;
        }

        public static DBSkillSev Instance
        {
            get
            {
                return mkInstance;
            }
        }
        
        public DBSkillSev(string strName, string strPath) :
            base(strName, strPath)
        {           
            mkInstance = this;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            mSkillInfoMap.Clear();
        }

        /// <summary>
        /// 获取表格中的技能数据
        /// </summary>
        public SkillInfoSev GetSkillInfo(uint skill_id)
        {
            SkillInfoSev skill_info = null;
            if (!mSkillInfoMap.TryGetValue(skill_id, out skill_info))
            {
                string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", "data_skill", "id", skill_id);

                var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, "data_skill", query_str);
                if (table_reader == null)
                {
                    mSkillInfoMap[skill_id] = null;
                    return null;
                }

                if (!table_reader.HasRows || !table_reader.Read())
                {
                    mSkillInfoMap[skill_id] = null;
                    table_reader.Close();
                    table_reader.Dispose();
                    return null;
                }

                skill_info = new SkillInfoSev();

                skill_info.Id = DBTextResource.ParseUI(GetReaderString(table_reader, "id"));
                skill_info.IsPg = DBTextResource.ParseUS_s(GetReaderString(table_reader, "is_pg"), 0) == 1;
                skill_info.FindTargetType = DBTextResource.ParseUS_s(GetReaderString(table_reader, "find_target"), 1);
                skill_info.FindTarget = skill_info.FindTargetType != 0;
                skill_info.TargetLimit = GetReaderString(table_reader, "target_limit");
                skill_info.IsTrigger = GetReaderString(table_reader, "action_type") != "active";
                skill_info.CDTime = DBTextResource.ParseUI_s(GetReaderString(table_reader, "cd"), 0);
                skill_info.Range = DBTextResource.ParseUI_s(GetReaderString(table_reader, "range"), 0) * 0.01f - 0.5f;  // 因为服务端减少了容错，攻击范围变得更小了，所以这里减0.5
                skill_info.Range = Mathf.Max(0f, skill_info.Range);
                skill_info.MpCost = DBTextResource.ParseI_s(GetReaderString(table_reader, "cost"), 0);
                skill_info.Target = GetReaderString(table_reader, "target");

                skill_info.ForwardSpeed = (float)DBTextResource.ParseI_s(GetReaderString(table_reader, "forward_move_speed"), 0) * 0.01f;
                skill_info.ForwardTime = (float)DBTextResource.ParseI_s(GetReaderString(table_reader, "forward_move_time"), 0) * GlobalConst.MilliToSecond;
                skill_info.MaxSingTime = (float)DBTextResource.ParseI_s(GetReaderString(table_reader, "max_sing_time"), 0) * GlobalConst.MilliToSecond;
                skill_info.CastingSpeed = (float)DBTextResource.ParseI_s(GetReaderString(table_reader, "casting_move_speed"), 0) * 0.01f;
                skill_info.CastingTime = (float)DBTextResource.ParseI_s(GetReaderString(table_reader, "casting_move_time"), 0) * GlobalConst.MilliToSecond;
                skill_info.BulletId = DBTextResource.ParseUI_s(GetReaderString(table_reader, "bullet_id"), 0);

                skill_info.ParentSkillId = DBTextResource.ParseUI_s(GetReaderString(table_reader, "parent_skill"), 0);
                skill_info.ChildSkillId = DBTextResource.ParseUI_s(GetReaderString(table_reader, "child_skill"), 0);
                skill_info.AnimationName = GetReaderString(table_reader, "skill_ani");
                skill_info.Sound = GetReaderString(table_reader, "skill_sound");
                skill_info.CastingReadyName = GetReaderString(table_reader, "skill_sing_ani");
                skill_info.CastingAnimationName = GetReaderString(table_reader, "skill_casting_ani");
                skill_info.CastingEndAnimationName = GetReaderString(table_reader, "skill_casting_end_ani");
                skill_info.RigidityTime = DBTextResource.ParseUS_s(GetReaderString(table_reader, "rigidity_time"), 0) * GlobalConst.MilliToSecond;
                skill_info.CacheTime = DBTextResource.ParseUS_s(GetReaderString(table_reader, "cache_time"), 0) * GlobalConst.MilliToSecond;
                skill_info.SkillAnnounce = GetReaderString(table_reader, "skill_announce");

                skill_info.CostFury = DBTextResource.ParseUI_s(GetReaderString(table_reader, "cost_fury"), 0);
                skill_info.GenFury = DBTextResource.ParseUI_s(GetReaderString(table_reader, "gen_fury"), 0);
                skill_info.IsFalseHitBack = DBTextResource.ParseUS_s(GetReaderString(table_reader, "isFalseHitBack"), 0) == 1;

                skill_info.UiEffectIconList = DBTextResource.ParseArrayString(GetReaderString(table_reader, "ui_effect_icon_list"), ",", true);
                skill_info.UiEffectSoundName = GetReaderString(table_reader, "ui_effect_sound");

                string[] ratios = TextHelper.GetTupleFromString(GetReaderString(table_reader, "multi_hit_ratio"));
                if (ratios != null)
                {
                    skill_info.MultiHitRatios = new List<float>();
                    for (int j = 0; j < ratios.Length; ++j)
                    {
                        float ratio = DBTextResource.ParseF(ratios[j]);
                        skill_info.MultiHitRatios.Add(ratio);
                    }
                }

                string[] delays = TextHelper.GetTupleFromString(GetReaderString(table_reader, "multi_hit_delay"));
                if (delays != null)
                {
                    skill_info.MultiHitDelayTimes = new List<float>();
                    for (int j = 0; j < delays.Length; ++j)
                    {
                        float delay = DBTextResource.ParseF(delays[j]);
                        skill_info.MultiHitDelayTimes.Add(delay);
                    }
                }

                if (skill_info.MultiHitDelayTimes != null && skill_info.MultiHitDelayTimes.Count != skill_info.MultiHitRatios.Count)
                {
                    string log = string.Format("SkillId: {0} 多段伤害系数与延迟时间不匹配", skill_info.Id);
                    Debug.LogError(log);
                }

                string[] effects = TextHelper.GetTupleFromString(GetReaderString(table_reader, "effects"));

                // 先把table_reader关闭，因为在GetBattleFxInfo和GetSkillEffectInfo中需要获取新的Reader
                table_reader.Close();
                table_reader.Dispose();

                // 获取技能特效参数
                DBBattleFx.BattleFxInfo battleInfo = DBBattleFx.Instance.GetBattleFxInfo(skill_info.Id);
                if (battleInfo != null)
                {
                    skill_info.BattleFxInfo = battleInfo;
                }
                else
                {
                    if (skill_info.IsTrigger == false)// 非触发类型的技能才需要战斗效果信息
                        GameDebug.LogError(string.Format("Skill: {0}没有对应的战斗效果信息", skill_info.Id));
                }

                // 追踪目标类型的子弹(依赖于battleInfo，所以要放在battleInfo数据读取之后)
                if (skill_info.BulletId != 0 && skill_info.IsTrigger == false)
                {
                    DBBulletTrace.BulletInfo bulletInfo = DBBulletTrace.GetInstance().GetBulletInfo(skill_info.BulletId);
                    if (bulletInfo != null)
                    {
                        skill_info.BulletTrace = new BulletTrackInstance(bulletInfo, skill_info);
                    }
                }

                // 获取技能效果参数
                if (effects != null)
                {
                    for (int j = 0; j < effects.Length; ++j)
                    {
                        uint effectId = DBTextResource.ParseUI(effects[j]);
                        var effect_info = DBSkillEffect.GetInstance().GetSkillEffectInfo(effectId);
                        if (effect_info == null)
                        {
                            string log = string.Format("SkillId: {0} 对应的技能效果Id: {1} 错误", skill_info.Id, effectId);
                            Debug.LogError(log);
                        }
                        else
                        {
                            if (effect_info.type == "charge" || effect_info.type == "teleport")// 冲锋、瞬移技能的移动速度参数放在效果表中配置
                            {
                                skill_info.CastingSpeed = effect_info.p1 * GlobalConst.UnitScale;
                                if (effect_info.type == "teleport")
                                    skill_info.Invisible = true;
                            }
                        }
                    }
                }

                mSkillInfoMap[skill_info.Id] = skill_info;
            }

            return skill_info;
        }

        /// <summary>
        /// 指定的技能id是否有吟唱阶段
        /// </summary>
        /// <param name="skill_id"></param>
        /// <returns></returns>
        public bool HasCastingReadyStage(uint skill_id)
        {
            var skill_info = GetSkillInfo(skill_id);

            if (skill_info != null)
                return skill_info.MaxSingTime > 0;
            else
                return false;
        }
    }

}
