
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
    /// <summary>
    /// 伤害飘字
    /// </summary>
    [wxb.Hotfix]
    public class DBFightFlyWord : xc.Singleton<DBFightFlyWord>
    {
        public class DBFightFlyWordISev
        {
            public int Id;          // id
            public bool IsScreenCenterBone; //是否是中心屏幕挂点
            public string Bone;     //初始挂点位置
            public float XOffset;
            public float YOffset;
        }

        public const string ScreenCenterBoneString = "screen_center";
        Dictionary<int, DBFightFlyWordISev> mInfos;
        HashSet<int> mNoExistKeyIdData;

        public DBFightFlyWord()
        {
            mNoExistKeyIdData = new HashSet<int>();
            mInfos = new Dictionary<int, DBFightFlyWordISev>();
        }

        /// <summary>
        /// 获取表格中的飘字数据
        /// </summary>
        public DBFightFlyWordISev GetFightFlyWordInfo(int effect_type)
        {
            DBFightFlyWordISev kResult;
            if (mInfos.TryGetValue(effect_type, out kResult))
            {
                return kResult;
            }
            else if(mNoExistKeyIdData.Contains(effect_type) == false)
            {
                var list = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_fight_fly_word", "id", effect_type.ToString());
                if (list.Count > 0)
                {
                    DBFightFlyWordISev info = new DBFightFlyWordISev();
                    Dictionary<string, string> table = list[0];
                    info.Id = int.Parse(table["id"]);

                    
                    info.Bone = table["bone"];
                    info.IsScreenCenterBone = info.Bone == ScreenCenterBoneString;
                    info.XOffset = DBTextResource.ParseI_s(table["xOffset"], 0);
                    info.YOffset = DBTextResource.ParseI_s(table["yOffset"], 0);

                    if (!mInfos.ContainsKey(info.Id))
                    {
                        mInfos.Add(info.Id, info);
                        return info;
                    }
                    else
                        Debug.LogError("[DBFightFlyWord]Key conflict, Id : " + info.Id);
                }
                else
                    mNoExistKeyIdData.Add(effect_type);
            }
            return null;
        }
    }

}


