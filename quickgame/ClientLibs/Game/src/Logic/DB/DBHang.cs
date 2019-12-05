//-------------------------------------------------------------------
//   File : DBHang.cs
//   Desc : 离线挂机的配置
//   Author : raorui
//   Date   : 2017.11.16
//-------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;
using System.Text;

namespace xc
{
    /// <summary>
    /// 离线挂机的信息
    /// </summary>
    public class HangInfo
    {
        public class TagInfo
        {
            public uint Index;
            public uint Id;
            public string Type;
        }

        public uint Id;// id
        public uint Level;// 角色等级
        public uint Dungeon;// 副本id
        public List<TagInfo> PosTagList;// 位置的Tag列表

        public TagInfo GetRandomTag()
        {
            if (PosTagList == null || PosTagList.Count == 0)
            {
                return null;
            }

            int randomIndex = UnityEngine.Random.Range(0, PosTagList.Count);
            return PosTagList[randomIndex];
        }
    }

    public class DBHang : DBSqliteTableResource
    {
        private List<HangInfo> m_HangInfo = new List<HangInfo>();

        static DBHang mInstace;
        public static DBHang Instance
        {
            get
            {
                return mInstace;
            }
        }

        public DBHang(string name, string path): base(name, path)
        {
            mInstace = this;
        }

        public override void Unload()
        {
            base.Unload();
            m_HangInfo.Clear();
        }

        List<HangInfo.TagInfo> ParseTagList(string str)
        {
            List<HangInfo.TagInfo> tagList = new List<HangInfo.TagInfo>();
            tagList.Clear();

            List<string> tagStrs = DBTextResource.ParseArrayString(str);
            uint index = 1;
            foreach (string tagStr in tagStrs)
            {
                HangInfo.TagInfo tagInfo = new HangInfo.TagInfo();
                tagInfo.Index = index;

                var matches = Regex.Matches(tagStr, @"([_a-zA-Z]+)_(\d+)");
                foreach (Match match in matches)
                {
                    tagInfo.Type = match.Groups[1].Value;
                    tagInfo.Id = DBTextResource.ParseUI(match.Groups[2].Value);
                }

                tagList.Add(tagInfo);

                index++;
            }

            return tagList;
        }

        protected override void ParseData(SqliteDataReader reader)
        {
            if (reader == null || !reader.HasRows)
            {
                return;
            }

            m_HangInfo.Clear();

            while (reader.Read())
            {
                var info = new HangInfo();
                info.Id = GetReaderUint(reader, "oid");
                info.Level = GetReaderUint(reader, "lv");
                info.Dungeon = DBTextResource.ParseUI_s(GetReaderString(reader, "dungeon"), 0);
                info.PosTagList = ParseTagList(GetReaderString(reader, "pos"));

                m_HangInfo.Add(info);
            }
        }

        /// <summary>
        /// 寻找当前角色等级下合适的离线挂机信息
        /// </summary>
        /// <returns></returns>
        public HangInfo GetSuitableHangInfo()
        {
            uint lv = LocalPlayerManager.Instance.LocalActorAttribute.Level;
            foreach(var info in m_HangInfo)
            {
                if (lv <= info.Level)// 寻找等级比角色等级高的挂机配置
                {
                    return info;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据副本id和tag id获取tag的id
        /// </summary>
        public uint GetHangIdByInstanceIdAndTagId(uint instanceId, uint tagId)
        {
            foreach (var info in m_HangInfo)
            {
                if (info.Dungeon == instanceId)
                {
                    foreach (HangInfo.TagInfo tagInfo in info.PosTagList)
                    {
                        if (tagInfo.Id == tagId)
                        {
                            return info.Id;
                        }
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 根据副本id和tag id获取tag的索引
        /// </summary>
        public uint GetTagIndexByInstanceIdAndTagId(uint instanceId, uint tagId)
        {
            foreach (var info in m_HangInfo)
            {
                if (info.Dungeon == instanceId)
                {
                    foreach (HangInfo.TagInfo tagInfo in info.PosTagList)
                    {
                        if (tagInfo.Id == tagId)
                        {
                            return tagInfo.Index;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
