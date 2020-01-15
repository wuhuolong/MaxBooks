using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using xc;
using Net;
namespace xc
{
    [wxb.Hotfix]
    public class RankManager: Utils.Singleton<RankManager>
    {
        public enum RankType//好友类型
        {
            PlayerLevel = 1000,//个人等级
            PlayerRich = 2000,//个人财富
            PlayerBat = 3000,//个人战力
            PlayerArena = 4000,//竞技场
            PlayerPet = 5000,//个人宠物
            SoicetyPractice = 6000,//修炼
            SoicetyBat = 7000,//公会战力
            SoicetyRich = 8000,//公会财富
            SoicetyCount = 9000,//公会规模
        }

        public class RankInfo
        {
            public string Name = string.Empty;
            public List<uint> Ids = new  List<uint>();//每一个标签对应的id
            public List<string> SubNames = new List<string>();//分类标签
            public  Dictionary<uint ,List<string>> SubMarks = new Dictionary<uint ,List<string>>();//具体显示的标题
        }

        public RankInfo GetRankById(uint ranktype)//根据大类Id取内容
        {
            List<Dictionary<string, string>> data_rank = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_rank", "parent_id", ranktype.ToString());
            RankInfo info = new RankInfo();
            foreach(var randInfo in data_rank)
            {
                uint childId = DBTextResource.ParseUI(randInfo["child_id"]);
                info.Ids.Add(childId);
                info.Name = randInfo["name"];
                string subName = randInfo["sub_name"];
                info.SubNames.Add(subName);
                List<string> marks = new  List<string>();
                string subMarks = randInfo["sub_mark"];
                subMarks = subMarks.Replace(" ","");
                subMarks = subMarks.Substring(1,subMarks.Length -2);
                var str =  subMarks.Split(',');
                for(int i = 0 ; i < str.Length ; i ++)
                {
                    marks.Add(str[i]);
                }
                if(info.SubMarks.ContainsKey(childId) == false)
                    info.SubMarks.Add(childId , marks);
            }

            return info;
        }
    }
}


