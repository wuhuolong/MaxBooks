
/*----------------------------------------------------------------
// 文件名： DBPassiveSkill.cs
// 文件功能描述： 被动技能表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBPassiveSkill : DBSqliteTableResource
    {
        
        public class DBPassiveSkillInfo
        {
            public uint Id;                    // id
            public List<uint> Exotics;      //独特属性
        }
        Dictionary<uint, DBPassiveSkillInfo> mInfos = new Dictionary<uint, DBPassiveSkillInfo>();
        public DBPassiveSkill(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        /// <summary>
        /// 获得被动技能Info
        /// </summary>
        /// <returns></returns>
        /// <param name="skill_type"></param>
        public DBPassiveSkillInfo GetDBPassiveSkillInfo(uint passive_skill_id)
        {
            DBPassiveSkillInfo info = null;
            if (mInfos.TryGetValue(passive_skill_id, out info) == false)
            {
                return null;
            }
            return info;
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();

        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mInfos.Clear();
            DBPassiveSkillInfo info;
            if (reader != null)
            {
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        info = new DBPassiveSkillInfo();

                        info.Id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0);
                        if (info.Id == 0)
                            continue;
                        
                        info.Exotics = DBTextResource.ParseArrayUint(GetReaderString(reader, "exotics"), ",");
                        if(mInfos.ContainsKey(info.Id) == false)
                            mInfos.Add(info.Id, info);
                    }
                }
            }
        }

        public DBPassiveSkillInfo GetOneDBPassiveSkillInfo(uint id)
        {
            DBPassiveSkillInfo info;
            if (mInfos.TryGetValue(id, out info))
            {
                return info;
            }
            GameDebug.LogError("[GetOneDBPassiveSkillInfo] Can not get info by id: " + id);
            return null;
        }
    }
}
