//------------------------------------------------------------------------------
// 文件名 ： DBLevelExp.cs
// 描述   ： 等级经验的对照表
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBLevelExp : DBSqliteTableResource
    {
        public class LevelExpInfo
        {
            public uint Level; // 角色等级
            public ulong Exp; //升级等级需要的经验
            public uint SkillScore; // 升级需要的技能总分
        }

        private Dictionary<uint, LevelExpInfo> mLevelInfos = new Dictionary<uint, LevelExpInfo>();

        static DBLevelExp mInstance = null;

        public static DBLevelExp GetInstance()
        {
            return mInstance;
        }

        public static DBLevelExp Instance
        {
            get
            {
                return mInstance;
            }
        }

        public DBLevelExp(string strName, string strPath) :
            base(strName, strPath)
        {           
            mInstance = this;
        }

        LevelExpInfo GetItemInfo(uint lv)
        {
            string query = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "lv", lv);
            var reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, query);
            if (reader == null)
            {
                mLevelInfos[lv] = null;
                return null;
            }

            if (!reader.HasRows || !reader.Read())
            {
                mLevelInfos[lv] = null;

                reader.Close();
                reader.Dispose();
                return null;
            }

            LevelExpInfo info = new LevelExpInfo();
            info.Level = lv;
            info.Exp = DBTextResource.ParseUL_s(GetReaderString(reader, "exp"), 0);
            info.SkillScore = DBTextResource.ParseUI(GetReaderString(reader, "skill_score"));

            mLevelInfos.Add(info.Level, info);

            reader.Close();
            reader.Dispose();
            return info;
        }

        public override void Load()
        {
            IsLoaded = true;
        }

        public override void Unload()
        {
            mLevelInfos.Clear();
        }

        /// <summary>
        /// 获取表格中的技能数据
        /// </summary>
        public LevelExpInfo GetLevelInfo(uint lv)
        {
            LevelExpInfo info = null;
            if (!mLevelInfos.TryGetValue(lv, out info))
                info = GetItemInfo(lv);

            return info;
        }
    }

}
