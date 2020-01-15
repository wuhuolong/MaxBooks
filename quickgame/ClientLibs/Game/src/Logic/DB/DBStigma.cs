
/*----------------------------------------------------------------
// 文件名： DBStigma.cs
// 文件功能描述： 圣痕
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBStigma : DBSqliteTableResource
    {

        public class DBStigmaSkillItemSkillItem
        {
            public uint skill_id;
            public uint open_level;
        }
        public class DBStigmaInfo
        {
            public uint Id;                    // id
            public string Name;                    //名字
            public uint Quality;            // 品质
            public uint CostGoodsId;       //消耗的物品ID
            public uint Exp;            //每次获得经验

            public uint Rank;       //排序规则
            public uint Actor_id;   //角色ID

            public Vector3 ModelLocalPos;
            public Vector3 ModelLocalScale;
            public Vector3 ModelLocalAngles;
            public Vector3 ModelParentDefaultAngles;
            public Vector3 ModelParentLocalPos;

            public string Icon;     //图标
            public Dictionary<uint, List<DBStigmaSkillItemSkillItem>> PlayerSkills; //玩家技能列表（主键是玩家职业）
            public List<DBStigmaSkillItemSkillItem> GetVocationPlayerSkills(uint vocation)
            {
                List<DBStigmaSkillItemSkillItem> find_lists = null;
                if (PlayerSkills.TryGetValue(vocation, out find_lists) == false)
                {
                    if (PlayerSkills.TryGetValue(DBDataAllSkill.CommonVocationType, out find_lists) == false)
                        return null;
                    return find_lists;
                }
                return find_lists;
            }
        }
        Dictionary<uint, DBStigmaInfo> mInfos = new Dictionary<uint, DBStigmaInfo>();

        public List<DBStigmaInfo> mSortInfos = new List<DBStigmaInfo>();   //所有的宠物表的排序后的列表
        public DBStigma(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mSortInfos.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            mSortInfos.Clear();
            DBDataAllSkill db_all_skill = DBManager.Instance.GetDB<DBDataAllSkill>();
            DBStigmaInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBStigmaInfo();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        info.Name = GetReaderString(reader, "name");
                        info.Quality = DBTextResource.ParseUI_s(GetReaderString(reader, "quality"), 0);     // 品质
                        info.CostGoodsId = DBTextResource.ParseUI_s(GetReaderString(reader, "cost"), 0);       //消耗的物品ID
                        info.Exp = DBTextResource.ParseUI_s(GetReaderString(reader, "exp"), 0);            //每次获得经验

                        info.Rank = DBTextResource.ParseUI_s(GetReaderString(reader, "rank"), 0);       //排序规则
                        info.Actor_id = DBTextResource.ParseUI_s(GetReaderString(reader, "actor_id"), 0);   //角色ID

                        info.ModelLocalPos = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_pos"));
                        info.ModelLocalScale = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_scale"));
                        info.ModelLocalAngles = DBTextResource.ParseVector3(GetReaderString(reader, "model_local_angles"));
                        info.ModelParentDefaultAngles = DBTextResource.ParseVector3(GetReaderString(reader, "model_parent_default_angles"));
                        info.ModelParentLocalPos = DBTextResource.ParseVector3(GetReaderString(reader, "model_parent_local_pos"));

                        info.Icon = GetReaderString(reader, "icon");     //图标

                        List<List<uint>> skills_str_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "skills"));
                        //玩家技能列表（主键是玩家职业）
                        info.PlayerSkills = new Dictionary<uint, List<DBStigmaSkillItemSkillItem>>();
                        skills_str_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "skills"));
                        for (int index = 0; index < skills_str_array.Count; ++index)
                        {
                            if (skills_str_array[index].Count >= 2)
                            {
                                uint skill_id = skills_str_array[index][0];
                                DBDataAllSkill.AllSkillInfo skill_info = db_all_skill.GetOneAllSkillInfo(skill_id);
                                if (skill_info != null)
                                {
                                    uint vocation = skill_info.Require_race;
                                    DBStigmaSkillItemSkillItem tmp_DBStigmaSkillItemSkillItem = new DBStigmaSkillItemSkillItem();
                                    tmp_DBStigmaSkillItemSkillItem.skill_id = skill_id;
                                    tmp_DBStigmaSkillItemSkillItem.open_level = skills_str_array[index][1];
                                    if (info.PlayerSkills.ContainsKey(vocation) == false)
                                        info.PlayerSkills.Add(vocation, new List<DBStigmaSkillItemSkillItem>());
                                    info.PlayerSkills[vocation].Add(tmp_DBStigmaSkillItemSkillItem);
                                }
                                else
                                {
                                    GameDebug.LogError(string.Format("Can't find the DBAllSkill = {0}", skill_id));
                                }
                            }
                            else
                            {
                                GameDebug.LogError(string.Format("There is error player_skills (id = {0}) in DBStigma", info.Id));
                            }
                        }
                        if (info.PlayerSkills.ContainsKey(DBDataAllSkill.CommonVocationType))
                        {
                            foreach (var item in info.PlayerSkills)
                            {
                                if (item.Key == DBDataAllSkill.CommonVocationType)
                                    continue;
                                item.Value.AddRange(info.PlayerSkills[DBDataAllSkill.CommonVocationType]);
                            }
                        }

                        mInfos.Add(info.Id, info);
                        mSortInfos.Add(info);
                    }
                }
            }
            mSortInfos.Sort((a, b) =>
            {
                if (a.Rank < b.Rank)
                    return -1;
                else if (a.Rank > b.Rank)
                    return 1;
                return 0;
            });
        }

        public DBStigmaInfo GetOneDBStigmaInfo(uint id)
        {
            DBStigmaInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            GameDebug.LogError("[GetOneDBStigmaInfo] Can not get info by id: " + id);
            return null;
        }
    }
}
