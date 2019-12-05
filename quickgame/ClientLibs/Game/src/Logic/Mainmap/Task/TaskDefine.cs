//------------------------------------------------------------------------------
// Desc   :  任务数据类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;
using xc;
using SGameEngine;

namespace xc
{
    [wxb.Hotfix]
    public class TaskDefine
    {
        /// <summary>
        /// 清除缓存
        /// </summary>
        public static void ClearCache()
        {
        }

        public uint Id;

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(mNameStr) == false)
                {
                    return mNameStr;
                }
                if (NameBytes != null)
                {
                    if (string.IsNullOrEmpty(mNameStr))
                    {
                        var str = string.Intern(System.Text.Encoding.UTF8.GetString(NameBytes));
                        mNameStr = xc.TextHelper.GetTranslateText(str);
                    }
                    return mNameStr;
                }
                else
                    return string.Empty;
            }
        }
        public byte[] NameBytes = null;
        string mNameStr = string.Empty;

        public string Description
        {
            get
            {
                if (string.IsNullOrEmpty(mDescriptionStr) == false)
                {
                    return mDescriptionStr;
                }
                if (DescriptionBytes != null)
                {
                    if (string.IsNullOrEmpty(mDescriptionStr))
                    {
                        var str = string.Intern(System.Text.Encoding.UTF8.GetString(DescriptionBytes));
                        mDescriptionStr = xc.TextHelper.GetTranslateText(str);
                    }
                    return mDescriptionStr;
                }
                else
                    return string.Empty;
            }
        }
        public byte[] DescriptionBytes = null;
        string mDescriptionStr = string.Empty;

        public ushort Type;

        public uint SubType;
        public int RequestLevelMin;
        public uint PreviousId;
        public uint NextId;
        public List<uint> RewardIds;
        public List<uint> GetSkills;
        public bool IsShowGetSkillProgress = false;
        public List<TaskStep> Steps;
        public uint ReceiveDialogId;
        public uint SubmitDialogId;

        /// <summary>
        /// 任务接取Npc
        /// </summary>
        public NpcScenePosition ReceiveNpc;

        /// <summary>
        /// 任务提交Npc
        /// </summary>
        public NpcScenePosition SubmitNpc;

        /// <summary>
        /// 显示优先级，值越小优先级越高
        /// </summary>
        public byte ShowPriority = 0;

        /// <summary>
        /// 显示优先级2，值越小优先级越高，此配置的优先级比动态排序的优先级高
        /// </summary>
        public byte ShowPriority2 = 0;

        /// <summary>
        /// 是否临时置顶
        /// </summary>
        public bool IsTemporaryOnTop = false;

        /// <summary>
        /// 接取后是否自动执行
        /// </summary>
        public enum EAutoRunType
        {
            None = 0,           // 不自动执行
            AutoRun = 1,        // 非挂机状态下自动执行
            ForceAutoRun = 2,   // 强制自动执行，无视挂机状态
            ForceAutoRun2 = 3,  // 强制自动执行，无视挂机状态和任务状态
        }
        EAutoRunType mAutoRunType = EAutoRunType.None;
        public EAutoRunType AutoRunType
        {
            get
            {
                // 如果是帮派任务且满足VIP的条件，则强制为自动执行
                if (Type == GameConst.QUEST_GUILD && VipHelper.GetIsAutoRunGuildTask() == true)
                {
                    return EAutoRunType.AutoRun;
                }
                return mAutoRunType;
            }
            set
            {
                mAutoRunType = value;
            }
        }

        /// <summary>
        /// 当接取或者完成任务的时候要创建和删除的npc
        /// </summary>
        public List<NpcScenePosition> CreateNpcsWhenReceived;
        public List<NpcScenePosition> DeleteNpcsWhenReceived;
        public List<NpcScenePosition> CreateNpcsWhenDone;
        public List<NpcScenePosition> DeleteNpcsWhenDone;

        /// <summary>
        /// 需要护送的NPC
        /// </summary>
        public List<NpcScenePosition> FollowNpcs;
        /// <summary>
        /// 获取第index个的跟随NPC的名字
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetFollowNpcName(int index)
        {
            if (FollowNpcs != null && FollowNpcs.Count > index)
            {
                NpcScenePosition npc = FollowNpcs[index];
                uint instanceId = npc.SceneId;
                uint npcId = npc.NpcId;
                return NpcHelper.GetNpcName(instanceId, npcId);
            }

            return string.Empty;
        }

        /// <summary>
        /// 是否可以使用飞鞋
        /// </summary>
        public bool CanUseBoots;

        /// <summary>
        /// 任务接取后和提交后要播放的剧情动画
        /// </summary>
        public uint ReceivedTimelineId;
        public uint SubmitedTimelineId;

        /// <summary>
        /// 直接完成消耗
        /// </summary>
        public List<List<string>> Costs;

        /// <summary>
        /// 前端展示的奖励物品、数量以及绑定状态
        /// </summary>
        public Dictionary<uint, uint> ShowRewardGoodsIds;
        public Dictionary<uint, uint> ShowRewardGoodsNums;
        public Dictionary<uint, byte> ShowRewardGoodsIsBinds;
        public uint ShowRewardGoodsId
        {
            get
            {
                uint vocation = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
                if (vocation > 0)
                {
                    if (ShowRewardGoodsIds.ContainsKey(vocation))
                    {
                        return ShowRewardGoodsIds[vocation];
                    }
                }

                return 0;
            }
        }
        public uint ShowRewardGoodsNum
        {
            get
            {
                uint vocation = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
                if (vocation > 0)
                {
                    if (ShowRewardGoodsNums.ContainsKey(vocation))
                    {
                        return ShowRewardGoodsNums[vocation];
                    }
                }

                return 0;
            }
        }
        public byte ShowRewardGoodsIsBind
        {
            get
            {
                uint vocation = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
                if (vocation > 0)
                {
                    if (ShowRewardGoodsIsBinds.ContainsKey(vocation))
                    {
                        return ShowRewardGoodsIsBinds[vocation];
                    }
                }

                return 0;
            }
        }

        public TaskStep GetStep(int index)
        {
            if (Steps == null || index >= Steps.Count || index < 0)
            {
                return null;
            }

            return Steps[index];
        }

        public string GetStepFixedDescription(int stepIndex)
        {
            var step = GetStep(stepIndex);

            if (step == null || step.Description == null)
            {
                return string.Empty;
            }

            string result = DBConstText.GetText(step.Description);

            // 对目标名字进行替换
            if (step.Goal == GameConst.GOAL_TALK)
            {
                result = string.Format(result, NpcHelper.GetNpcName(step.InstanceId, step.NpcId));
            }
            else if (step.Goal == GameConst.GOAL_KILL_MON)
            {
                result = string.Format(result, RoleHelp.GetActorName(step.MonsterId));
            }
            else if (step.Goal == GameConst.GOAL_INTERACT)
            {
                result = string.Format(result, RoleHelp.GetActorName(NpcHelper.MakeNpcDefine(step.NpcId).ActorId));
            }
            else if (step.Goal == GameConst.GOAL_KILL_COLLECT)
            {
                result = string.Format(result, GoodsHelper.GetGoodsOriginalNameByTypeId(step.GoodsId));
            }
            else if (step.Goal == GameConst.GOAL_COLLECT_GOODS)
            {
                if (step.MinWorldBossSpecialMonId > 0 && step.MaxWorldBossSpecialMonId > 0)
                {
                    DBSpecialMon dbSpecialMon = DBManager.Instance.GetDB<DBSpecialMon>();
                    uint minLevel = dbSpecialMon.GetSpecialMonLevel(step.MinWorldBossSpecialMonId);
                    uint maxLevel = dbSpecialMon.GetSpecialMonLevel(step.MaxWorldBossSpecialMonId);
                    result = string.Format(result, minLevel, maxLevel, GoodsHelper.GetGoodsOriginalNameByTypeId(step.GoodsId));
                }
                else
                {
                    result = string.Format(result, GoodsHelper.GetGoodsOriginalNameByTypeId(step.GoodsId));
                }
            }
            else if (step.Goal == GameConst.GOAL_WAR_WIN || step.Goal == GameConst.GOAL_WAR_ENTER || step.Goal == GameConst.GOAL_WAR_GRADE)
            {
                result = string.Format(result, InstanceHelper.GetInstanceName(step.InstanceId2));
            }
            else if (step.Goal == GameConst.GOAL_EQUIP_SUBMIT)
            {
                result = string.Format(result, GoodsHelper.GetGoodsColorName(step.EquipColor) + xc.Equip.EquipHelper.GetEquipLvStepName(step.EquipLvStep));
            }
            else if (step.Goal == GameConst.GOAL_SECRET_AREA)
            {
                result = string.Format(result, InstanceHelper.GetKungfuGodInstanceName(step.SecretAreaId));
            }
            else if (step.Goal == GameConst.GOAL_TRIGRAM)
            {
                result = string.Format(result, TaskHelper.GetTrigramName(step.TrigramId));
            }
            else if (step.Goal == GameConst.GOAL_EQUIP_WEAR)
            {
                result = string.Format(result, GoodsHelper.GetGoodsColorName(step.EquipColor) + xc.Equip.EquipHelper.GetEquipLvStepName(step.EquipLvStep));
            }
            else if (step.Goal == GameConst.GOAL_EQUIP_STRENGTH)
            {
                result = string.Format(result, step.EquipStrenghtLv);
            }
            else if (step.Goal == GameConst.GOAL_EQUIP_GEM)
            {
            }
            else if (step.Goal == GameConst.GOAL_PET_LV)
            {
                result = string.Format(result, step.PetLv);
            }
            else if (step.Goal == GameConst.GOAL_GROW_LV)
            {
            }
            else if (step.Goal == GameConst.GOAL_STIGMA_LV)
            {
                DBStigma dbStigma = DBManager.Instance.GetDB<DBStigma>();
                DBStigma.DBStigmaInfo stigmaInfo = dbStigma.GetOneDBStigmaInfo(step.StigmaId);
                if (stigmaInfo != null)
                {
                    string name = stigmaInfo.Name;
                    result = string.Format(result, name);
                }
                else
                {
                    GameDebug.LogError("GetStepFixedDescription error, can not find stigma info by id " + step.StigmaId);
                }
            }
            else if (step.Goal == GameConst.GOAL_DRAGON_SOUL)
            {
                result = string.Format(result, step.ExpectResult);
            }
            else if (step.Goal == GameConst.GOAL_EQUIP_STRENGTH_TLV)
            {
                result = string.Format(result, step.EquipStrenghtLv);
            }
            else if (step.Goal == GameConst.GOAL_KILL_BOSS)
            {
                if (step.MonsterLevel > 0)
                {
                    result = string.Format(result, step.ExpectResult, step.MonsterLevel);
                }
                else
                {
                    result = string.Format(result, step.ExpectResult);
                }
            }
            else if (step.Goal == GameConst.GOAL_LIGHT_EQUIP)
            {
                List<string> names = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_light_equip", "id", step.LightEquipLv.ToString(), "desc");
                if (names != null && names.Count > 0)
                {
                    result = string.Format(result, names[0]);
                }
            }
            else
            {
                result = TaskHelper.GetStepFixedDescriptionByLua(step);
            }
            return result;
        }

        public List<DBReward.RewardInfo> RewardInfos
        {
            get
            {
                DBReward dbReward = DBManager.Instance.GetDB<DBReward>();

                List<DBReward.RewardInfo> infos = new List<DBReward.RewardInfo>();

                foreach (var item in RewardIds)
                {
                    List<DBReward.RewardInfo> infos2 = dbReward.GetRewardItemList(item);

                    foreach (var info in infos2)
                    {
                        if (info.mVocation != 0 && (uint)info.mVocation != LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
                        {
                            continue;
                        }

                        //if (LocalPlayerManager.Instance.LocalActorAttribute.Level >= (uint)info.mLvLow && LocalPlayerManager.Instance.LocalActorAttribute.Level < (uint)info.mLvUp)
                        {
                            infos.Add(info);
                        }
                    }
                }

                return infos;
            }
        }

        /// <summary>
        /// 获取该任务当前场景的提交任务的NpcPlayer
        /// </summary>
        /// <returns></returns>
        public NpcPlayer GetSubmitNpcPlayer()
        {
            if (SubmitNpc.SceneId == SceneHelp.Instance.CurSceneID)
            {
                return NpcManager.Instance.GetNpcByNpcId(SubmitNpc.NpcId);
            }

            return null;
        }

        /// <summary>
        /// 获取该任务当前场景的跟随NpcPlayer
        /// </summary>
        public NpcPlayer GetFollowNpcPlayer()
        {
            if (FollowNpcs != null)
            {
                uint instanceId = SceneHelp.Instance.CurSceneID;
                foreach (NpcScenePosition npcScenePosition in FollowNpcs)
                {
                    if (instanceId == npcScenePosition.SceneId)
                    {
                        NpcPlayer npcPlayer = NpcManager.Instance.GetNpcByNpcId(npcScenePosition.NpcId);
                        if (npcPlayer != null)
                        {
                            return npcPlayer;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 获取该任务指定职业能够获取到的技能id
        /// </summary>
        /// <param name="vocation"></param>
        /// <returns></returns>
        public uint GetSkillByVocation(uint vocation = 0)
        {
            if (vocation == 0)
            {
                vocation = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
            }

            DBDataAllSkill dbAllSkill = DBManager.Instance.GetDB<DBDataAllSkill>();
            foreach (uint skillId in GetSkills)
            {
                var allSkillInfo = dbAllSkill.GetOneAllSkillInfo(skillId);
                if (allSkillInfo != null && (allSkillInfo.Require_race == 0 || allSkillInfo.Require_race == vocation))
                {
                    return skillId;
                }
            }

            return 0;
        }

        public class TaskStep
        {
            public string Goal;
            public uint ExpectResult;
            
            public uint DialogId;   // 对话id
            public uint InstanceId; // 副本id
            public uint InstanceId2;    // 副本id2
            public uint NpcId;  // npcid
            public uint MonsterId;  // 怪物id(GOAL_KILL_GROUP_MON目标为json文件里面的id，其余目标为角色id)
            public uint MonsterLevel;   // 怪物等级
            public uint GoodsId;    // 物品id
            public uint EquipColor; // 装备品质
            public uint EquipLvStep;    // 装备阶数
            public uint SecretAreaId;   // 武神秘境id
            public uint TrigramId;  // 八卦牌id
            public uint EquipStrenghtLv;    // 装备强化等级
            public uint GemType;    // 宝石类型
            public uint GemLv;  // 宝石等级
            public uint PetLv;  // 守护等级
            public uint GrowType;   // 成长类型，1为坐骑
            public uint GrowLv; // 成长升星
            public uint StigmaId;   // 圣痕ID
            public uint StigmaLv;   // 圣痕等级
            public uint SysId;  // 系统ID
            public ushort MinWorldBossSpecialMonId; // 最低等级的世界Boss，用于跳转到世界Boss界面
            public ushort MaxWorldBossSpecialMonId; // 最高等级的世界Boss，用于跳转到世界Boss界面
            public ushort InstanceLv;   // 副本等级
            public byte WarTag;         // 战斗标签
            public ushort LightEquipLv; // 光武等级
            public string Description;  // 描述

            /// <summary>
            /// 参数列表，用来做lua扩展
            /// </summary>
            public List<string> ServerParamStrings = null;
            public List<string> ClientParamStrings = null;

            /// <summary>
            /// 导航点
            /// </summary>
            public uint NavigationInstanceId = 0;
            public uint NavigationTagId = 0;

            public TaskStep()
            {
            }

            public static List<TaskStep> CreateStepsByRawString(string serverRawString, string clientRawString, string navigationPointsRawsString)
            {
                if (string.IsNullOrEmpty(serverRawString) || string.IsNullOrEmpty(clientRawString))
                {
                    return null;
                }

                List<TaskStep> steps = new List<TaskStep>();
                steps.Clear();

                List<List<string>> serverStepStringsStrings = DBTextResource.ParseArrayStringString(serverRawString);
                List<List<string>> clientStepStringsStrings = DBTextResource.ParseArrayStringString(clientRawString);
                if (serverStepStringsStrings.Count != clientStepStringsStrings.Count)
                {
                    return steps;
                }

                List<List<uint>> navigationPointsUintsUints = DBTextResource.ParseArrayUintUint(navigationPointsRawsString);

                for (int i = 0; i < serverStepStringsStrings.Count; ++i)
                {
                    List<string> serverStepStrings = serverStepStringsStrings[i];
                    List<string> clientStepStrings = clientStepStringsStrings[i];
                    TaskStep step = new TaskStep();

                    step.Goal = serverStepStrings[0];
                    if (step.Goal.Equals(GameConst.GOAL_AUTO))
                    {
                        step.ExpectResult = 1;
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_TALK))
                    {
                        step.ExpectResult = 1;
                        uint.TryParse(serverStepStrings[1], out step.DialogId);
                        uint.TryParse(clientStepStrings[0], out step.InstanceId);
                        uint.TryParse(clientStepStrings[1], out step.NpcId);
                        step.Description = clientStepStrings[2];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_KILL_MON))
                    {
                        uint.TryParse(serverStepStrings[1], out step.MonsterId);
                        uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        uint.TryParse(clientStepStrings[0], out step.InstanceId);
                        step.Description = clientStepStrings[1];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_KILL_GROUP_MON))
                    {
                        uint.TryParse(serverStepStrings[1], out step.InstanceId);
                        uint.TryParse(serverStepStrings[2], out step.MonsterId);
                        uint.TryParse(serverStepStrings[3], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_INTERACT))
                    {
                        uint.TryParse(serverStepStrings[1], out step.NpcId);
                        uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        uint.TryParse(clientStepStrings[0], out step.InstanceId);
                        step.Description = clientStepStrings[1];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_KILL_COLLECT))
                    {
                        uint.TryParse(serverStepStrings[1], out step.MonsterId);
                        uint.TryParse(serverStepStrings[3], out step.GoodsId);
                        uint.TryParse(serverStepStrings[4], out step.ExpectResult);
                        uint.TryParse(clientStepStrings[0], out step.InstanceId);
                        step.Description = clientStepStrings[1];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_COLLECT_GOODS))
                    {
                        uint.TryParse(serverStepStrings[1], out step.MonsterLevel);
                        uint.TryParse(serverStepStrings[3], out step.GoodsId);
                        uint.TryParse(serverStepStrings[4], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                        if (clientStepStrings.Count >= 3)
                        {
                            ushort.TryParse(clientStepStrings[1], out step.MinWorldBossSpecialMonId);
                            ushort.TryParse(clientStepStrings[2], out step.MaxWorldBossSpecialMonId);
                        }
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_WAR_WIN) || step.Goal.Equals(GameConst.GOAL_WAR_GRADE))
                    {

                        step.ExpectResult = 1;
                        uint.TryParse(serverStepStrings[1], out step.InstanceId2);
                        uint.TryParse(clientStepStrings[0], out step.InstanceId);
                        uint.TryParse(clientStepStrings[1], out step.NpcId);
                        step.Description = clientStepStrings[2];
                        if (clientStepStrings.Count > 3)
                        {
                            uint.TryParse(clientStepStrings[3], out step.SysId);
                        }
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_WAR_ENTER))
                    {
                        if(serverStepStrings.Count > 2)
                        {
                            uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        }
                        else
                        {
                            step.ExpectResult = 1;
                        }
                        uint.TryParse(serverStepStrings[1], out step.InstanceId2);
                        uint.TryParse(clientStepStrings[0], out step.InstanceId);
                        uint.TryParse(clientStepStrings[1], out step.NpcId);
                        step.Description = clientStepStrings[2];
                        if (clientStepStrings.Count > 3)
                        {
                            uint.TryParse(clientStepStrings[3], out step.SysId);
                        }
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_EQUIP_SUBMIT))
                    {
                        uint.TryParse(serverStepStrings[1], out step.EquipColor);
                        uint.TryParse(serverStepStrings[2], out step.EquipLvStep);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_SECRET_AREA))
                    {
                        uint.TryParse(serverStepStrings[1], out step.SecretAreaId);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_TRIGRAM))
                    {
                        uint race = Game.Instance.LocalPlayerVocation;
                        for (int j = 1; j < serverStepStrings.Count; ++j)
                        {
                            uint trigramId = 0;
                            uint.TryParse(serverStepStrings[j], out trigramId);
                            if (TaskHelper.GetTrigramRace(trigramId) == race)
                            {
                                step.TrigramId = trigramId;
                            }
                        }
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_EQUIP_WEAR))
                    {
                        uint.TryParse(serverStepStrings[1], out step.EquipColor);
                        uint.TryParse(serverStepStrings[2], out step.EquipLvStep);
                        uint.TryParse(serverStepStrings[3], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_EQUIP_STRENGTH))
                    {
                        uint.TryParse(serverStepStrings[1], out step.EquipStrenghtLv);
                        uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_EQUIP_GEM))
                    {
                        uint.TryParse(serverStepStrings[1], out step.GemType);
                        uint.TryParse(serverStepStrings[2], out step.GemLv);
                        uint.TryParse(serverStepStrings[3], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_PET_LV))
                    {
                        uint.TryParse(serverStepStrings[1], out step.PetLv);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_GROW_LV))
                    {
                        uint.TryParse(serverStepStrings[1], out step.GrowType);
                        uint.TryParse(serverStepStrings[2], out step.GrowLv);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_STAR_LV))
                    {
                        step.Description = clientStepStrings[0];
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_GEM_LV))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_LIVENESS))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_EXP_JADE))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_GOODS_COMPOSE))
                    {
                        uint.TryParse(serverStepStrings[1], out step.GoodsId);
                        uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_AFFILIED_ANY_BOSS))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_STIGMA_LV))
                    {
                        uint.TryParse(serverStepStrings[1], out step.StigmaId);
                        uint.TryParse(serverStepStrings[2], out step.StigmaLv);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_DRAGON_SOUL))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_CONTRACT_INHERIT))
                    {
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_EQUIP_STRENGTH_TLV))
                    {
                        uint.TryParse(serverStepStrings[1], out step.EquipStrenghtLv);
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_TRIAL_BOSS))
                    {
                        ushort.TryParse(serverStepStrings[1], out step.InstanceLv);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_KILL_BOSS))
                    {
                        byte.TryParse(serverStepStrings[1], out step.WarTag);
                        uint.TryParse(serverStepStrings[2], out step.MonsterLevel);
                        uint.TryParse(serverStepStrings[3], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_LIGHT_EQUIP))
                    {
                        ushort.TryParse(serverStepStrings[1], out step.LightEquipLv);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_RIDE_EQ_NUM))
                    {
                        uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_HONOR))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_ACT_FINISH))
                    {
                        uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_TRANSFER))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_SHOW_LV))
                    {
                        uint.TryParse(serverStepStrings[2], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else if (step.Goal.Equals(GameConst.GOAL_BAPTIZE_NUM))
                    {
                        uint.TryParse(serverStepStrings[1], out step.ExpectResult);
                        step.Description = clientStepStrings[0];
                    }
                    else
                    {
                        step.ExpectResult = 1;
                        step.Description = clientStepStrings[0];

                        step.ServerParamStrings = serverStepStrings;
                        step.ClientParamStrings = clientStepStrings;
                    }

                    if (i < navigationPointsUintsUints.Count)
                    {
                        List<uint> navigationPointsUints = navigationPointsUintsUints[i];
                        uint navigationInstanceId = 0;
                        if (navigationPointsUints.Count > 0)
                        {
                            navigationInstanceId = navigationPointsUints[0];
                        }
                        uint navigationTagId = 0;
                        if (navigationPointsUints.Count > 1)
                        {
                            navigationTagId = navigationPointsUints[1];
                        }

                        step.NavigationInstanceId = navigationInstanceId;
                        step.NavigationTagId = navigationTagId;
                    }

                    steps.Add(step);
                }

                return steps;
            }
        }

        public static TaskDefine MakeDefine(uint id)
        {
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define;
            }

            return null;
        }

        public static List<NpcScenePosition> MakeNpcScenePositions(string raw)
        {
            if (string.IsNullOrEmpty(raw) == true)
            {
                return null;
            }

            List<NpcScenePosition> result = new List<NpcScenePosition>();
            result.Clear();

            List<List<string>> stringsStrings = DBTextResource.ParseArrayStringString(raw);
            foreach (List<string> strings in stringsStrings)
            {
                result.Add(NpcScenePosition.Make(strings));
            }

            return result;
        }

        /// <summary>
        /// 获取任务名字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetTaskName(uint id)
        {
            // 首先在DBTask缓存里面找
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define.Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取任务类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ushort GetTaskType(uint id)
        {
            // 首先在DBTask缓存里面找
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define.Type;
            }

            return GameConst.QUEST_NONE;
        }

        /// <summary>
        /// 获取任务最低等级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetTaskRequestLevelMin(uint id)
        {
            // 首先在DBTask缓存里面找
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define.RequestLevelMin;
            }

            return 0;
        }

        /// <summary>
        /// 当接取任务的时候要创建的npc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="npcsRawString">已查询好的字符串，若是空则根据id重新读取</param>
        /// <returns></returns>
        public static List<NpcScenePosition> GetCreateNpcsWhenReceived(uint id, string npcsRawString = "")
        {
            // 首先在DBTask缓存里面找
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define.CreateNpcsWhenReceived;
            }

            return null;
        }

        /// <summary>
        /// 当接取任务的时候要删除的npc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="npcsRawString">已查询好的字符串，若是空则根据id重新读取</param>
        /// <returns></returns>
        public static List<NpcScenePosition> GetDeleteNpcsWhenReceived(uint id, string npcsRawString = "")
        {
            // 首先在DBTask缓存里面找
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define.DeleteNpcsWhenReceived;
            }

            return null;
        }

        /// <summary>
        /// 当完成任务的时候要创建的npc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="npcsRawString">已查询好的字符串，若是空则根据id重新读取</param>
        /// <returns></returns>
        public static List<NpcScenePosition> GetCreateNpcsWhenDone(uint id, string npcsRawString = "")
        {
            // 首先在DBTask缓存里面找
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define.CreateNpcsWhenDone;
            }

            return null;
        }

        /// <summary>
        /// 当完成任务的时候要删除的npc
        /// </summary>
        /// <param name="id"></param>
        /// <param name="npcsRawString">已查询好的字符串，若是空则根据id重新读取</param>
        /// <returns></returns>
        public static List<NpcScenePosition> GetDeleteNpcsWhenDone(uint id)
        {
            // 首先在DBTask缓存里面找
            TaskDefine define = DBManager.Instance.GetDB<DBTask>().GetTaskDefine(id);
            if (define != null)
            {
                return define.DeleteNpcsWhenDone;
            }

            return null;
        }
    }
}