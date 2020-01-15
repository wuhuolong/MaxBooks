/*----------------------------------------------------------------
// 文件名： DBDataAllSkill.cs
// 文件功能描述： 活动表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBDataAllSkill : DBSqliteTableResource
    {
        public enum SKILL_TYPE : byte
        {
            None = 0,
            Active = 1,     // 主动技能
            Passive = 2,    // 被动技能
        }
        public enum SET_SLOT_TYPE //装配类型
        {
            None = 0,   //不能被装配
            BasicSkill = 1, //基础技能
            FurySkill = 2,  //怒气技能
            MateSKill = 3,  //情侣技能
        }
        public const uint CommonVocationType = 0;  //通用职业类型
        public const uint PetVocationType = 100;    //魔仆职业类型
        public class AllSkillInfo
        {
            public uint Id;                    // id
            public SKILL_TYPE SkillType;         // 技能类型
            public uint Sub_id;             //主动技能ID或者被动技能ID
            public ushort SortId;           // 在技能界面上的排序ID
            public string Name;             //技能名字
            public string Source;           //技能获取途径说明
            public string Desc;             //
            public string Icon;
            public uint ModelId;
            public string ModelAction;
            public uint Require_race;           //职业限制( 取值参见 EVocationType)
            public string Skill_type_descript;     //技能标签
            public bool Can_set_key;            //能否装备到技能槽：0否1是
            public uint FixedKeyPos = 0;             // 装配到技能槽的位置（固定位置，不能在技能面板中进行设置）
            public uint OpenHole = 0; //开放技能后默认开启的技能槽
            public SET_SLOT_TYPE SetSlotType;        //装配类型
            public List<uint> ReplaceIds; //替换技能列表(总表ID)
            public uint Level;  //技能等级（默认为0，表示没有等级概念）
            public bool ShowInPanel;
            public string LevelNotice; // 技能升级提示的文本
            public uint MinLevelTotalSkillId;   //对应等级为1的技能ID 
            public AllSkillInfo NextLevelSkillTmpl; //下一级技能数据
            public bool StopHookWhenGain;   // 获得技能时候是否打断挂机
            public List<List<uint>> Attrs;   // 获得技能增加属性

            public string zhuhun_txt;//铸魂额外配置文本

        }
        public class OneVocationActiveSkillInfos
        {
            public uint mVocation;   //职业
            public Dictionary<SET_SLOT_TYPE, List<AllSkillInfo>> mSkills;
            public OneVocationActiveSkillInfos(uint init_vocation)
            {
                mVocation = init_vocation;
                mSkills = new Dictionary<SET_SLOT_TYPE, List<AllSkillInfo>>();
            }
            public void AddSkillInfo(AllSkillInfo info)
            {
                if (mSkills.ContainsKey(info.SetSlotType) == false)
                    mSkills.Add(info.SetSlotType, new List<AllSkillInfo>());
                mSkills[info.SetSlotType].Add(info);
            }
        }

        Dictionary<uint, AllSkillInfo> mInfos = new Dictionary<uint, AllSkillInfo>();
        Dictionary<uint, AllSkillInfo> mInfosByActiveSkillId = new Dictionary<uint, AllSkillInfo>();    //主动技能ID作为主键的总表
        Dictionary<SKILL_TYPE, Dictionary<uint, List<AllSkillInfo>>> mInfosByType = new Dictionary<SKILL_TYPE, Dictionary<uint, List<AllSkillInfo>>>();
        //         Dictionary<uint, List<AllSkillInfo> > mInfosCanSetKey = new Dictionary<uint, List<AllSkillInfo>>();   //所有可以被装配的主动技能(主键是职业)
        //         Dictionary<uint, List<AllSkillInfo>> mInfosNoCanSetKey = new Dictionary<uint, List<AllSkillInfo>>();   //所有固定的主动技能(主键是职业)
        Dictionary<uint, OneVocationActiveSkillInfos> mInfosBySetSlotType = new Dictionary<uint, OneVocationActiveSkillInfos>();   //所有的主动技能(主键是职业,其次按设置键的类型)

        Dictionary<uint, List<AllSkillInfo>> mMinLevelSkillDict = new Dictionary<uint, List<AllSkillInfo>>();
        public DBDataAllSkill(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        /// <summary>
        /// 获得所有技能
        /// </summary>
        /// <returns></returns>
        /// <param name="skill_type"></param>
        public List<AllSkillInfo> GetAllSkillInfo(SKILL_TYPE skill_type, uint vocation)
        {
            Dictionary<uint, List<AllSkillInfo> > info = null;
            if (mInfosByType.TryGetValue(skill_type, out info) == false)
            {
                return null;
            }
            List<AllSkillInfo> oneVocationAllSkill;
            if (info == null)
                return null;
            if (info.TryGetValue(vocation, out oneVocationAllSkill) == false)
            {
                if(vocation != CommonVocationType && vocation != PetVocationType)
                {
                    if (info.TryGetValue(CommonVocationType, out oneVocationAllSkill) == false)
                        return null;
                    else
                        return oneVocationAllSkill;
                }
                return null;
            }
            return oneVocationAllSkill;
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mInfosByType.Clear();
            mInfosByActiveSkillId.Clear();
            //             mInfosCanSetKey.Clear();
            //             mInfosNoCanSetKey.Clear();
            mInfosBySetSlotType.Clear();
            mMinLevelSkillDict.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mMinLevelSkillDict.Clear();
            mInfos.Clear();
            mInfosByType.Clear();
            mInfosByActiveSkillId.Clear();
            //             mInfosCanSetKey.Clear();
            //             mInfosNoCanSetKey.Clear();
            mInfosBySetSlotType.Clear();
            DBSkillSlot db_slot = DBManager.Instance.GetDB<DBSkillSlot>();
            AllSkillInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new AllSkillInfo();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.SkillType = (SKILL_TYPE)System.Enum.Parse(typeof(SKILL_TYPE), GetReaderString(reader, "type"));
                        info.Sub_id = DBTextResource.ParseUI_s(GetReaderString(reader, "sub_id"), 0);             //主动技能ID或者被动技能ID
                        info.SortId = DBTextResource.ParseUS_s(GetReaderString(reader, "sort_id"), 0);
                        info.Name = GetReaderString(reader, "name");             //技能名字
                        info.Source = GetReaderString(reader, "source");           //技能获取途径说明
                        info.Desc = GetReaderString(reader, "desc");             //
                        info.Icon = GetReaderString(reader, "icon");
                        info.ModelId = DBTextResource.ParseUI_s(GetReaderString(reader, "model_id"), 0);
                        info.ModelAction = GetReaderString(reader, "model_action");
                        info.Require_race = DBTextResource.ParseUI_s(GetReaderString(reader, "require_race"), 0);           //职业限制( 取值参见 EVocationType)
                        info.Skill_type_descript = GetReaderString(reader, "skill_type_descript");     //技能标签

                        info.zhuhun_txt = GetReaderString(reader, "zhuhun_txt");    //铸魂额外配置文本

                        info.SetSlotType = (SET_SLOT_TYPE)DBTextResource.ParseUI_s(GetReaderString(reader, "set_slot_type"), 0);
                        if (info.SetSlotType == SET_SLOT_TYPE.None || info.SetSlotType == SET_SLOT_TYPE.MateSKill)
                            info.Can_set_key = false;            //能否装备到技能槽
                        else
                            info.Can_set_key = true;
                        info.ReplaceIds = DBTextResource.ParseArrayUint(GetReaderString(reader, "replace_ids"), ",");
                        
                        info.Level = DBTextResource.ParseUI_s(GetReaderString(reader, "level"), 0);
                        info.ShowInPanel = DBTextResource.ParseUI_s(GetReaderString(reader, "show_in_panel"), 1) == 1;
                        info.LevelNotice = GetReaderString(reader, "level_notice");
                        info.FixedKeyPos = DBTextResource.ParseUI_s(GetReaderString(reader, "fixed_key_pos"), 0);
                        info.OpenHole = DBTextResource.ParseUI_s(GetReaderString(reader, "open_hole"), 0);

                        string raw = GetReaderString(reader, "stop_hook_when_gain");
                        if (string.IsNullOrEmpty(raw) == true || raw.Equals("0") == true)
                        {
                            info.StopHookWhenGain = false;
                        }
                        else
                        {
                            info.StopHookWhenGain = true;
                        }

                        info.Attrs = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "attrs"));

                        mInfos.Add(info.Id, info);

                        if(mInfosByType.ContainsKey(info.SkillType) == false)
                        {
                            mInfosByType.Add(info.SkillType, new Dictionary<uint, List<AllSkillInfo>>());
                        }
                        if(mInfosByType[info.SkillType].ContainsKey(info.Require_race) == false)
                        {
                            mInfosByType[info.SkillType].Add(info.Require_race, new List<AllSkillInfo>());
                        }
                        mInfosByType[info.SkillType][info.Require_race].Add(info);

                        if(info.SkillType == SKILL_TYPE.Active)
                        {
                            mInfosByActiveSkillId[info.Sub_id] = info;
                            if (mInfosBySetSlotType.ContainsKey(info.Require_race) == false)
                                mInfosBySetSlotType.Add(info.Require_race, new OneVocationActiveSkillInfos(info.Require_race));
                            mInfosBySetSlotType[info.Require_race].AddSkillInfo(info);
                            db_slot.AddSlotDefaultSkillId(info.Require_race, info.OpenHole, info.Id);
                        }

                        if(info.Level == 1)
                        {//首先只记录等级为1
                            mMinLevelSkillDict.Add(info.Id, new List<DBDataAllSkill.AllSkillInfo>());
                            mMinLevelSkillDict[info.Id].Add(info);
                        }
                    }
                }
            }

            foreach(var item in mInfos)
            {
                if(item.Value.Level > 1 && item.Value.ReplaceIds != null &&
                    item.Value.ReplaceIds.Count > 0)
                {//检测所有大于等级1的技能
                    for(int index = 0; index < item.Value.ReplaceIds.Count; ++index)
                    {
                        uint skill_id = item.Value.ReplaceIds[index];
                        List<DBDataAllSkill.AllSkillInfo> find_info_array = null;
                        if (mMinLevelSkillDict.TryGetValue(skill_id, out find_info_array))
                        {//插入等级为1的技能列表中去
                            item.Value.MinLevelTotalSkillId = skill_id;   //设定等级为1的技能ID
                            find_info_array.Add(item.Value);
                        }
                    }
                }
            }

            //等级排序
            foreach(var item in mMinLevelSkillDict)
            {
                item.Value.Sort((a, b) =>
                {
                    if (a.Level < b.Level)
                        return -1;
                    else if (a.Level > b.Level)
                        return 1;
                    return 0;
                });
                for(int index = 0; index < item.Value.Count; ++index)
                {
                    if (index == item.Value.Count - 1)
                        item.Value[index].NextLevelSkillTmpl = null;
                    else
                        item.Value[index].NextLevelSkillTmpl = item.Value[index + 1];
                }
            }

            foreach( var item in mInfosByType)
            {
                if(item.Value.ContainsKey(CommonVocationType))
                {
                    foreach (var item2 in item.Value)
                    {
                        if (item2.Key != CommonVocationType && item2.Key != PetVocationType)
                        {
                            item2.Value.AddRange(item.Value[CommonVocationType]);
                        }
                    }
                }
            }

            if (mInfosBySetSlotType.ContainsKey(CommonVocationType))
            {
                foreach (var item in mInfosBySetSlotType)
                {
                    if (item.Key == PetVocationType)
                        continue;
                    if (item.Key == CommonVocationType)
                        continue;
                    foreach(var copy_item in mInfosBySetSlotType[CommonVocationType].mSkills)
                    {
                        if (item.Value.mSkills.ContainsKey(copy_item.Key) == false)
                            item.Value.mSkills.Add(copy_item.Key, new List<AllSkillInfo>());
                        item.Value.mSkills[copy_item.Key].AddRange(copy_item.Value);
                    }
                }
            }
        }

        public AllSkillInfo GetOneAllSkillInfo(uint id)
        {
            AllSkillInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            //GameDebug.LogError("[GetAllSkillInfo] Can not get info by skill_type: " + id);
            return null;
        }

        /// <summary>
        /// 根据技能总表ID，转换到主动或者被动技能ID
        /// </summary>
        /// <param name="all_skill_id"></param>
        /// <returns></returns>
        public uint GetSubSkillIdByAllSkillId(uint all_skill_id)
        {
            AllSkillInfo info = GetOneAllSkillInfo(all_skill_id);
            if (info == null)
                return 0;
            return info.Sub_id;
        }

        public AllSkillInfo GetOneAllSkillInfo_byActiveSkillId(uint active_skill_id)
        {
            AllSkillInfo info;
            if (mInfosByActiveSkillId.TryGetValue(active_skill_id, out info))
            {
                return info;
            }
            //GameDebug.LogError("[GetOneAllSkillInfo_byActiveSkillId] Can not get info by skill_type: " + active_skill_id);
            return null;
        }

        /// <summary>
        /// 获得所有“是否可以装配的”主动技能列表
        /// </summary>
        /// <param name="vocation"></param>
        /// <param name="canSetKey"></param>
        /// <returns></returns>
        public List<AllSkillInfo> GetAllActiveSkillInfoBySetSlotType(uint vocation, SET_SLOT_TYPE set_slot_type)
        {

            if(mInfosBySetSlotType != null)
            {
                OneVocationActiveSkillInfos vocation_info;
                if (mInfosBySetSlotType.TryGetValue(vocation, out vocation_info) == false)
                    return null;
                List<AllSkillInfo> oneVocationAllSkill;
                if (vocation_info.mSkills.TryGetValue(set_slot_type, out oneVocationAllSkill) == false)
                    return null;
                return oneVocationAllSkill;
            }
            return null;
        }
    }
}
