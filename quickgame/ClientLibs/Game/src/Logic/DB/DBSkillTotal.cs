//------------------------------------------------------------------------------
// 文件名 ： DBSkillTotal.cs
// 描述   ： 技能总表
//------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBSkillTotal : DBSqliteTableResource
    {
        /// <summary>
        /// 技能基本信息
        /// </summary>
        public class SkillBasicInfo
        {
            public uint Id;
            public ushort Type;  // 主动还是被动 1 主动 2 被动
            public ushort SubType; // 攻击，防御，绝技, 天赋
            public string Name; // 技能名字
            public string Icon; // 技能图片的名字
            public string SkillTypeDescript = string.Empty;
            public uint ShowInUI; // 是否在UI中显示
        }

        private Dictionary<uint, SkillBasicInfo> mSkillInfos = new Dictionary<uint, SkillBasicInfo>();
        /// <summary>
        /// 对应职业所拥有的所有技能信息
        /// </summary>
        private Dictionary<uint, List<SkillBasicInfo>> mRaceSkillInfos = new Dictionary<uint, List<SkillBasicInfo>>();

        public DBSkillTotal(string strName, string strPath) :
            base(strName, strPath)
        {

        }

        protected override void ParseData(SqliteDataReader reader)
        {
            base.ParseData(reader);

            mSkillInfos.Clear();

            int fieldCount = reader.FieldCount;
            while(reader.Read())
            {
                SkillBasicInfo info = new SkillBasicInfo();

                for (int i = 0; i < fieldCount; i++)
                {
                    string rawName = reader.GetName(i);

                    if(rawName == "id")
                    {
                        info.Id = DBTextResource.ParseUI(reader.GetString(i));
                    }
                    else if(rawName == "show_in_ui")
                    {
                        info.ShowInUI = DBTextResource.ParseUI(reader.GetString(i));
                    }
                    else if(rawName == "name")
                    {
                        info.Name = reader.GetString(i);
                    }
                    else if (rawName == "type")
                    {
                        info.Type = DBTextResource.ParseUS_s(reader.GetString(i), 1);
                    }
                    else if (rawName == "sub_type")
                    {
                        info.SubType = DBTextResource.ParseUS_s(reader.GetString(i), 1);
                    }
                    else if (rawName == "icon")
                    {
                        info.Icon = reader.GetString(i);
                    }
                    else if(rawName == "skill_type_descript")
                    {
                        info.SkillTypeDescript = reader.GetString(i);
                    }
                }

                mSkillInfos.Add(info.Id, info);
            }
        }

        public static DBSkillTotal Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBSkillTotal>();
            }
        }

        public SkillBasicInfo GetSkillBasicInfo(uint id)
        {
            SkillBasicInfo info = null;
            mSkillInfos.TryGetValue(id, out info);

            return info;
        }
    }
}