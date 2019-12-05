
/*----------------------------------------------------------------
// 文件名： DBGuildSkill.cs
// 文件功能描述： 帮派技能
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBGuildSkill : DBSqliteTableResource
    {
        public class DBCommonAttrItem
        {
            public uint attr_id;
            public uint attr_num;
        }

        public class DBGuildSkillItem
        {
            public uint SkillId; // 技能ID
            public string Name;  //技能名字
            public uint Level;   //等级
            public uint OpenLv;     //开放等级(玩家等级)
            public uint OpenCost;   //开启消耗帮贡
            public uint LvUpCost;   //升级消耗帮贡
            public List<DBCommonAttrItem> AttrArray; //属性
            public string Icon;     //图标
            public uint CurAttrId;  //当前属性
            public List<List<uint>> CurShowAttrArray; //当前需要显示的属性
        }

        /// <summary>
        /// 保存uid和公会技能的信息
        /// </summary>
        Dictionary<uint, DBGuildSkillItem> mInfos = new Dictionary<uint, DBGuildSkillItem>();

        /// <summary>
        /// 保存所有的技能ID
        /// </summary>
        public List<uint> mSortSkillArray = new List<uint>();
        public DBGuildSkill(string strName, string strPath) : base(strName, strPath)
        {
        }

        public override void Unload()
        {
            base.Unload();
            mInfos.Clear();
            mSortSkillArray.Clear();
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            mSortSkillArray.Clear();
            if (reader == null || !reader.HasRows)
                return;

            while (reader.Read())
            {
                var skill_id = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0); // 技能ID

                if (!mSortSkillArray.Contains(skill_id))
                    mSortSkillArray.Add(skill_id);
            }

            mSortSkillArray.Sort((a, b) =>
            {
                if (a < b)
                    return -1;
                else if (a > b)
                    return 1;
                return 0;
            });
        }

        /// <summary>
        /// 根据技能id和技能等级获取一个公会技能的信息
        /// </summary>
        /// <param name="skill_id"></param>
        /// <param name="skill_level"></param>
        /// <returns></returns>
        public DBGuildSkillItem GetOneItem(uint skill_id, uint skill_level)
        {
            uint uid = skill_id * 1000 + skill_level;
            DBGuildSkillItem info;
            if (mInfos.TryGetValue(uid, out info))
            {
                return info;
            }

            string query_str = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\" AND {0}.{3}=\"{4}\"", mTableName, "id", skill_id, "lv", skill_level);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query_str);
            if (reader == null)
            {
                mInfos[uid] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mInfos[uid] = null;
                reader.Close();
                reader.Dispose();
                return null;
            }

            info = new DBGuildSkillItem();
            info.SkillId = DBTextResource.ParseUI_s(GetReaderString(reader, "id"), 0); // 技能ID
            info.Name = GetReaderString(reader, "name"); //技能名字
            info.Level = DBTextResource.ParseUI_s(GetReaderString(reader, "lv"), 0);  //等级
            info.OpenLv = DBTextResource.ParseUI_s(GetReaderString(reader, "open_lv"), 0);     //开放等级(玩家等级)
            info.OpenCost = DBTextResource.ParseUI_s(GetReaderString(reader, "open_cost"), 0);  //开启消耗帮贡
            info.LvUpCost = DBTextResource.ParseUI_s(GetReaderString(reader, "lv_up_cost"), 0); //升级消耗帮贡
            info.AttrArray = new List<DBCommonAttrItem>();
            List<List<uint>> uint_uint_array = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "attr"));
            for (int index = 0; index < uint_uint_array.Count; ++index)
            {
                if (uint_uint_array[index].Count >= 2)
                {
                    DBCommonAttrItem item = new DBCommonAttrItem();
                    item.attr_id = uint_uint_array[index][0];
                    item.attr_num = uint_uint_array[index][1];
                    info.AttrArray.Add(item);
                }
            }

            info.Icon = GetReaderString(reader, "icon");  //图标
            info.CurShowAttrArray = DBTextResource.ParseArrayUintUint(GetReaderString(reader, "cur_attr_id")); //玩家当前属性
            info.CurAttrId = 0;   //当前属性ID
            if (info.CurShowAttrArray != null && info.CurShowAttrArray.Count > 0 &&
                info.CurShowAttrArray[0] != null && info.CurShowAttrArray[0].Count > 0)
            {
                info.CurAttrId = info.CurShowAttrArray[0][0];
            }

            mInfos[uid] = info;

            reader.Close();
            reader.Dispose();

            return info;
        }
    }
}
