
/*----------------------------------------------------------------
// 文件名： DBPet.cs
// 文件功能描述： 宠物表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBPet : DBSqliteTableResource
    {
        public enum PetUnLockType
        {
            None = 0,
            PlayerLevel = 1,
            PrePetDegree = 2,   //前置魔仆等阶
            CostGoods = 3,      //消耗道具
            EvolutionReplace = 4,   //进化替换
        }
        public class PetSkillItem
        {
            public uint skill_id;
            public uint open_degree;
        }
        public class UnLockGoodsCondition
        {
            public uint goods_id;
            public uint goods_num;
        }
        public class UnLockPrePetCondition
        {
            public uint pet_id;
            public uint step_level;
        }
        public class PetInfo
        {
            public uint Id;                    // id
            public string Desc;                 //说明
            public PetUnLockType UnlockType;        //解锁方式
            public uint UnlockPlayerLevel;           //解锁需要的玩家等级
            public List<UnLockGoodsCondition> UnLockGoodsConditionArray;           //解锁需要的解锁物品
            public UnLockPrePetCondition UnLockPrePetConditionData;           //解锁需要的前置宠物等阶
            public uint PreIdInEvolution = 0;   //进化前置的守护ID（表中配置的是此项数据）
            public bool HasCheckEvolution = false;
            public uint FirstPetIdInEvolution = 0; //进化的第一个守护ID
            //public uint NextIdInEvolution = 0; //进化后置的守护ID
            public string Unlock_desc;          //解锁说明
            public uint Rank;       //排序规则
            public uint Actor_id;   //角色ID
            public uint Quality;    //品质
            public uint MaxStep;    //最高升阶
            public uint MaxQual;    //最高升品
            public List<PetSkillItem> AllSkills;   //主动和被动技能列表(技能总表ID)
            public List<PetSkillItem> Skills;   //主动技能列表(技能总表ID)
            public List<PetSkillItem> PassivitySkills; //被动技能（技能总表）
            public Vector3 ModelCameraOffset;
            public Vector3 ModelCameraOffsetInfo;
            public Vector3 ModelCameraRotate;
            public Vector3 ModelDefaultAngle;
            public Vector3 ModelCameraOffset2;
            public Vector3 ModelCameraOffset3;
            public Vector3 ModelLocalPos;
            public Vector3 ModelLocalScale;
            public Vector3 ModelLocalAngles;
            public Vector3 ModelLocalPos2;
            public Vector3 ModelLocalScale2;

            public Vector3 ModelShowModelOffset;
            public Vector3 ModelShowCameraOffset;
            public Vector3 ModelShowCameraRotation;
            public Vector3 ModelShowScale;

            public Dictionary<uint, List<PetSkillItem>> PlayerSkills; //玩家技能列表（主键是玩家职业）
            public string Head_icon;  // 头像
            //public string Icon;
            public string GetQualityDescStr()
            {
                return xc.DBConstText.GetText(string.Format("PET_QUALITY_DESC_{0}", Quality));
            }

            public List<PetSkillItem> GetVocationPlayerSkills(uint vocation)
            {
                List<PetSkillItem> find_lists = null;
                if (PlayerSkills.TryGetValue(vocation, out find_lists) == false)
                {
                    if(PlayerSkills.TryGetValue(DBDataAllSkill.CommonVocationType, out find_lists) == false)
                        return null;
                }
                return find_lists;
            }
        }
        Dictionary<uint, PetInfo> mInfos = new Dictionary<uint, PetInfo>();
        
        public List<PetInfo> mSortInfos = new List<PetInfo>();   //所有的宠物表的排序后的列表
        //进化解锁的前置id列表(key: 第一个进化的ID; value: 当前id的所有id列表(包括第一个进化的ID))
        Dictionary<uint, List<uint>> mEvolutionIds = new Dictionary<uint, List<uint>>();
          
        public DBPet(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mSortInfos.Clear();
            mEvolutionIds.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mSortInfos.Clear();
            mEvolutionIds.Clear();
            DBDataAllSkill db_all_skill = DBManager.Instance.GetDB<DBDataAllSkill>();
            PetInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new PetInfo();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Desc = GetReaderString(reader, "desc");                 //说明
                        info.UnlockType = (PetUnLockType)DBTextResource.ParseUI_s(GetReaderString(reader, "unlock_type"), 0);      //解锁方式
                        if(info.UnlockType == PetUnLockType.PlayerLevel)
                        {
                            info.UnlockPlayerLevel = DBTextResource.ParseUI_s(GetReaderString(reader, "unlock_condition"), 0);          //解锁条件
                        }
                        else if(info.UnlockType == PetUnLockType.CostGoods)
                        {
                            info.UnLockGoodsConditionArray = new List<UnLockGoodsCondition>();
                            List<List<uint>> str_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "unlock_condition"));
                            for (int index = 0; index < str_array.Count; ++index)
                            {
                                if (str_array[index].Count >= 2)
                                {
                                    UnLockGoodsCondition tmp_item = new UnLockGoodsCondition();
                                    tmp_item.goods_id = str_array[index][0];
                                    tmp_item.goods_num = str_array[index][1];
                                    info.UnLockGoodsConditionArray.Add(tmp_item);
                                }
                                else
                                {
                                    GameDebug.LogError(string.Format("There is error unlock_condition (id = {0}) in data_pet", info.Id));
                                }
                            }
                        }
                        else if(info.UnlockType == PetUnLockType.PrePetDegree)
                        {
                            List<uint> str_array = DBTextResource.ParseArrayUint(GetReaderString(reader, "unlock_condition"), ",");
                            if (str_array != null && str_array.Count >= 2)
                            {
                                info.UnLockPrePetConditionData = new UnLockPrePetCondition();
                                info.UnLockPrePetConditionData.pet_id = str_array[0];
                                info.UnLockPrePetConditionData.step_level = str_array[1];
                            }
                            else
                            {
                                GameDebug.LogError(string.Format("There is error unlock_condition (id = {0}) in data_pet", info.Id));
                            }
                        }
                        else if(info.UnlockType == PetUnLockType.EvolutionReplace)
                        {
                            info.PreIdInEvolution = DBTextResource.ParseUI_s(GetReaderString(reader, "unlock_condition"), 0);
                            info.HasCheckEvolution = false;
                            info.FirstPetIdInEvolution = 0;
                        }
                        else
                        {

                        }

                        info.Unlock_desc = GetReaderString(reader, "unlock_desc");  //解锁说明
                        info.Rank = DBTextResource.ParseUI_s(GetReaderString(reader, "rank"), 0);       //排序规则
                        info.Actor_id = DBTextResource.ParseUI_s(GetReaderString(reader, "actor_id"), 0);   //角色ID
                        info.Quality = DBTextResource.ParseUI_s(GetReaderString(reader, "quality"), 1);    //品质
                        info.MaxQual = DBTextResource.ParseUI_s(GetReaderString(reader, "max_qual"), 1);    //最高升品
                        info.MaxStep = DBTextResource.ParseUI_s(GetReaderString(reader, "max_step"), 1);    //最高升阶
                        info.Head_icon = GetReaderString(reader, "head_icon"); // 头像

                        info.ModelCameraOffset = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_offset"));
                        info.ModelCameraOffsetInfo = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_offset_info"));
                        info.ModelCameraRotate = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_rotate"));
                        info.ModelDefaultAngle = DBTextResource.ParseVector3(GetReaderString(reader, "model_default_angle"));
                        info.ModelCameraOffset2 = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_offset_2"));
                        info.ModelCameraOffset3 = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_offset_3"));
                        info.ModelLocalPos = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_pos"));
                        info.ModelLocalScale = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_scale"));
                        info.ModelLocalAngles = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_angles"));
                        info.ModelLocalPos2 = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_pos2"));
                        info.ModelLocalScale2 = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_scale2"));

                        info.ModelShowModelOffset = DBTextResource.ParseVector3(GetReaderString(reader, "model_show_model_offset"));
                        info.ModelShowCameraRotation = DBTextResource.ParseVector3(GetReaderString(reader, "model_show_camera_rotation"));
                        info.ModelShowCameraOffset = DBTextResource.ParseVector3(GetReaderString(reader, "model_show_camera_offset"));

                        
                        info.ModelShowScale = DBTextResource.ParseVector3(GetReaderString(reader, "model_show_scale"));

                        //技能列表
                        info.AllSkills = new List<PetSkillItem>();
                        info.Skills = new List<PetSkillItem>();
                        info.PassivitySkills = new List<PetSkillItem>();
                        List<List<uint>> skills_str_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "skills"));
                        for(int index = 0; index < skills_str_array.Count; ++index)
                        {
                            if(skills_str_array[index].Count >= 2)
                            {
                                PetSkillItem tmp_PetSkillItem = new PetSkillItem();
                                tmp_PetSkillItem.skill_id = skills_str_array[index][0];
                                tmp_PetSkillItem.open_degree = skills_str_array[index][1];
                                info.AllSkills.Add(tmp_PetSkillItem);
                                DBDataAllSkill.AllSkillInfo skill_info = db_all_skill.GetOneAllSkillInfo(tmp_PetSkillItem.skill_id);
                                if (skill_info != null)
                                {
                                    if (skill_info.SkillType == DBDataAllSkill.SKILL_TYPE.Active)
                                        info.Skills.Add(tmp_PetSkillItem);
                                    else if (skill_info.SkillType == DBDataAllSkill.SKILL_TYPE.Passive)
                                        info.PassivitySkills.Add(tmp_PetSkillItem);
                                }
                                else
                                    GameDebug.LogError(string.Format("[DBPet] can't find the skill! pet_id = {0} skill_id = {1}",
                                       info.Id, tmp_PetSkillItem.skill_id));
                            }
                            else
                            {
                                GameDebug.LogError(string.Format("There is error skills (id = {0}) in data_pet", info.Id));
                            }
                        }

                        //玩家技能
                        info.PlayerSkills = new Dictionary<uint, List<PetSkillItem>>();
                        skills_str_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "player_skills"));
                        for (int index = 0; index < skills_str_array.Count; ++index)
                        {
                            if (skills_str_array[index].Count >= 2)
                            {
                                PetSkillItem tmp_PetSkillItem = new PetSkillItem();
                                tmp_PetSkillItem.skill_id = skills_str_array[index][0];
                                tmp_PetSkillItem.open_degree = skills_str_array[index][1];

                                DBDataAllSkill.AllSkillInfo skill_info = db_all_skill.GetOneAllSkillInfo(tmp_PetSkillItem.skill_id);
                                uint vocation = 0;
                                if (skill_info != null)
                                    vocation = skill_info.Require_race;
                                if (info.PlayerSkills.ContainsKey(vocation) == false)
                                    info.PlayerSkills.Add(vocation, new List<PetSkillItem>());
                                info.PlayerSkills[vocation].Add(tmp_PetSkillItem);
                            }
                            else
                            {
                                GameDebug.LogError(string.Format("There is error player_skills (id = {0}) in data_pet", info.Id));
                            }
                        }
                        if(info.PlayerSkills.ContainsKey(DBDataAllSkill.CommonVocationType))
                        {
                            foreach(var item in info.PlayerSkills)
                            {
                                if (item.Key == DBDataAllSkill.CommonVocationType)
                                    continue;
                                item.Value.AddRange(info.PlayerSkills[DBDataAllSkill.CommonVocationType]);
                            }
                        }
                        //info.Icon = GetReaderString(reader, "icon");

                        mInfos.Add(info.Id, info);
                        mSortInfos.Add(info);
                    }
                }
            }

            int no_deal_evolution_count = 0;
            while(true)
            {
                no_deal_evolution_count = 0;
                foreach (var item in mInfos)
                {
                    if (item.Value.UnlockType != PetUnLockType.EvolutionReplace)
                        continue;
                    if (item.Value.HasCheckEvolution)
                        continue;//已经处理过
                    if (item.Value.PreIdInEvolution == 0)
                    {//第一个进化的ID
                        uint first_pet_id = item.Value.Id;
                        mEvolutionIds[first_pet_id] = new List<uint>();
                        mEvolutionIds[first_pet_id].Add(item.Value.Id);
                        item.Value.HasCheckEvolution = true;
                        item.Value.FirstPetIdInEvolution = first_pet_id;
                    }
                    else if (mInfos.ContainsKey(item.Value.PreIdInEvolution) &&
                        mInfos[item.Value.PreIdInEvolution].HasCheckEvolution)
                    {//非第一个进化的ID且前置进化ID已经计算过
                        uint first_pet_id = mInfos[item.Value.PreIdInEvolution].FirstPetIdInEvolution;
                        mEvolutionIds[first_pet_id].Add(item.Value.Id);
                        item.Value.HasCheckEvolution = true;
                        item.Value.FirstPetIdInEvolution = first_pet_id;
                    }
                    else//后续循环处理
                        no_deal_evolution_count++;
                }

                if (no_deal_evolution_count <= 0)
                    break;
            }
            
           
            mSortInfos.Sort((a, b) => {
                if (a.Rank < b.Rank)
                    return -1;
                else if (a.Rank > b.Rank)
                    return 1;
                if (a.Id < b.Id)
                    return -1;
                else if (a.Id > b.Id)
                    return 1;
                return 0;
            });
        }

        public PetInfo GetOnePetInfo(uint id)
        {
            PetInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            //GameDebug.LogError("[GetOnePetInfo] Can not get info by id: " + id);
            return null;
        }

        public PetInfo GetOnePetInfoByGoodsId(uint goods_id)
        {
            foreach(var item in mInfos)
            {
                if (item.Value.UnlockType != PetUnLockType.CostGoods)
                    continue;
                if (item.Value.UnLockGoodsConditionArray == null)
                    continue;
                for(int index = 0; index < item.Value.UnLockGoodsConditionArray.Count; ++index)
                {
                    if (item.Value.UnLockGoodsConditionArray[index].goods_id == goods_id)
                        return item.Value;
                }
            }
            return null;
        }
        public List<uint> GetEvolutionIds(uint first_pet_id)
        {
            List<uint> re;
            if (mEvolutionIds.TryGetValue(first_pet_id, out re))
            {
                return re;
            }
            return null;
        }

        public Dictionary<uint, PetInfo> Infos
        {
            get
            {
                return mInfos;
            }
        }

    }
}
