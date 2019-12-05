
/*----------------------------------------------------------------
// 文件名： DBPetFetter.cs
// 文件功能描述： 宠物羁绊表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBPetFetter : DBSqliteTableResource
    {
        public class FetterSkillItem
        {
            public uint skill_id;
            public uint vocation;
        }
        public class DBPetFetterItem
        {
            public uint PetId;
            public uint Index;
            public List<DBPet.UnLockPrePetCondition> Condition;
            public List<DBTextResource.DBAttrItem> Attr; //属性
            //public List<FetterSkillItem> Skills; //赋予主角的技能列表
            public Dictionary<uint, List<FetterSkillItem> > Skills; //赋予主角的技能列表

            public List<FetterSkillItem> GetSkills(uint vocation)
            {
                if (Skills.ContainsKey(vocation) == false)
                {
                    if (Skills.ContainsKey(DBDataAllSkill.CommonVocationType) == false)
                        return null;
                    return Skills[DBDataAllSkill.CommonVocationType];
                }
                return Skills[vocation];
            }
        }
       
        Dictionary<uint, List<DBPetFetterItem>> mInfos = new Dictionary<uint, List<DBPetFetterItem>>();

        //Key是技能总表ID，value 是对于的守护羁绊表
        Dictionary<uint, DBPetFetterItem> mOpenSkillInfos = new Dictionary<uint, DBPetFetterItem>();
        public DBPetFetter(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();

        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mOpenSkillInfos.Clear();
            DBDataAllSkill db_all_skill = DBManager.Instance.GetDB<DBDataAllSkill>();
            DBPetFetterItem info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBPetFetterItem();
                        info.PetId = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Index = DBTextResource.ParseUI_s(GetReaderString(reader, "index"), 0);
                        info.Condition = new List<DBPet.UnLockPrePetCondition>();
                        List<List<uint>> str_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "condition"));
                        if(str_array != null)
                        {
                            for (int index = 0; index < str_array.Count; ++index)
                            {
                                if (str_array[index] != null && str_array[index].Count >= 2)
                                {
                                    DBPet.UnLockPrePetCondition condition = new DBPet.UnLockPrePetCondition();
                                    condition.pet_id = str_array[index][0];
                                    condition.step_level = str_array[index][1];
                                    info.Condition.Add(condition);
                                }
                            }
                        }
                        info.Attr = DBTextResource.ParseDBAttrItems(GetReaderString(reader, "attr"));
                        List<uint> skill_array = DBTextResource.ParseArrayUint(GetReaderString(reader, "skills"), ",");
                        info.Skills = new Dictionary<uint, List<FetterSkillItem>>();
                        if (skill_array != null)
                        {
                            for(int index = 0; index < skill_array.Count; ++index)
                            {
                                FetterSkillItem item = new FetterSkillItem();
                                item.skill_id = skill_array[index];
                                DBDataAllSkill.AllSkillInfo skill_info = db_all_skill.GetOneAllSkillInfo(item.skill_id);
                                uint vocation = 0;
                                if (skill_info != null)
                                    vocation = skill_info.Require_race;
                                item.vocation = vocation;
                                if (info.Skills.ContainsKey(item.vocation) == false)
                                    info.Skills.Add(item.vocation, new List<FetterSkillItem>());
                                info.Skills[item.vocation].Add(item);

                                mOpenSkillInfos[item.skill_id] = info;
                            }
                        }
                        if (info.Skills.ContainsKey(DBDataAllSkill.CommonVocationType))
                        {
                            foreach (var item in info.Skills)
                            {
                                if (item.Key == DBDataAllSkill.CommonVocationType)
                                    continue;
                                item.Value.AddRange(info.Skills[DBDataAllSkill.CommonVocationType]);
                            }
                        }
                        if (mInfos.ContainsKey(info.PetId) == false)
                        {
                            mInfos.Add(info.PetId, new List<DBPetFetterItem>());
                        }
                        mInfos[info.PetId].Add(info);
                    }
                }
            }

            foreach(var item in mInfos)
            {
                item.Value.Sort((a, b) =>
                {
                    if (a.Index < b.Index)
                        return -1;
                    else if (a.Index > b.Index)
                        return 1;
                    return 0;
                });
            }
        }

        public List<DBPetFetterItem> GetOneInfo(uint pet_id)
        {
            List<DBPetFetterItem> info;
            if (mInfos.TryGetValue(pet_id, out info))
            {
                return info;
            }
            return null;
        }

        public DBPetFetterItem GetOneInfoByTotalSkillId(uint total_skill_id)
        {
            DBPetFetterItem info;
            if (mOpenSkillInfos.TryGetValue(total_skill_id, out info) == false)
                return null;
            return info;
        }
    }
}
