
//---------------------------------------
// File:    DBTrialBoss.cs
// Desc:    试炼BOSS
// Author:  xusong
// Date:    2017.10.30
//---------------------------------------
using UnityEngine;
using System;
using System.Collections.Generic;
using xc.ui;
using System.Collections;
using Guide;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBTrialBoss : DBSqliteTableResource
    {
        public const uint TrialType_Basic = 1; //基础
        public const uint TrialType_High = 2;  //巅峰

        public class TrialBossItem
        {
            public uint DgnId; //副本ID
            public uint TrialType;
            public uint Rank;
            public uint ActorId;    //BOSS的角色ID
            public List<DBTextResource.DBGoodsItem> ShowAward;
            public List<DBTextResource.DBGoodsItem> ShowAssistAward;    // 助战奖励
            public Vector3 ModelCameraOffset;
            public Vector3 DefaultAngles;
            public float CameraViewField;
            public Vector3 CameraRotate;
            public string DefaultActionName;
            public string Icon;
        }
        private Dictionary<uint, TrialBossItem> mInfos = new Dictionary<uint, TrialBossItem>();

        private Dictionary<uint, List<TrialBossItem>> mSortInfos = new Dictionary<uint, List<TrialBossItem>>();

        public DBTrialBoss(string strName, string strPath)
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
            if (reader == null || !reader.HasRows)
            {
                return;
            }
            mInfos.Clear();
            mSortInfos.Clear();
            while (reader.Read())
            {
                var tmp_info = new TrialBossItem();
                tmp_info.DgnId = DBTextResource.ParseUI(GetReaderString(reader, "dgn_id")); //副本ID
                tmp_info.TrialType = DBTextResource.ParseUI(GetReaderString(reader, "type"));
                tmp_info.Rank = DBTextResource.ParseUI(GetReaderString(reader, "rank"));
                tmp_info.ActorId = DBTextResource.ParseUI(GetReaderString(reader, "actor_id"));
                tmp_info.ShowAward = DBTextResource.ParseDBGoodsItem(GetReaderString(reader, "show_award"));
                tmp_info.ShowAssistAward = DBTextResource.ParseDBGoodsItem(GetReaderString(reader, "show_assist_award"));
                tmp_info.ModelCameraOffset = DBTextResource.ParseVector3(GetReaderString(reader, "model_camera_offset"));
                tmp_info.DefaultAngles = DBTextResource.ParseVector3(GetReaderString(reader, "default_angles"));
                tmp_info.CameraViewField = DBTextResource.ParseF(GetReaderString(reader, "camera_view_field"));
                tmp_info.CameraRotate = DBTextResource.ParseVector3(GetReaderString(reader, "camera_rotate"));
                tmp_info.DefaultActionName = GetReaderString(reader, "default_action_name");
                tmp_info.Icon = GetReaderString(reader, "icon");

                if (mInfos.ContainsKey(tmp_info.DgnId) == false)
                {
                    mInfos.Add(tmp_info.DgnId, tmp_info);
                    if (mSortInfos.ContainsKey(tmp_info.TrialType) == false)
                        mSortInfos.Add(tmp_info.TrialType, new List<TrialBossItem>());
                    mSortInfos[tmp_info.TrialType].Add(tmp_info);
                }
                else
                    GameDebug.LogError("DBTrialBoss contain the same info; Dgn_id = " + tmp_info.DgnId);
            }

            foreach(var item in mSortInfos)
            {
                mSortInfos[item.Key].Sort((a, b) => {
                    if (a.Rank < b.Rank)
                        return -1;
                    else if (a.Rank > b.Rank)
                        return 1;
                    return 0;
                });
            }
        }

        
        public List<TrialBossItem> GetSortItemArray(uint trial_boss_type)
        {
            if (!mSortInfos.ContainsKey(trial_boss_type))
            {
                return null;
            }
            
            return mSortInfos[trial_boss_type];
        }

        public TrialBossItem GetItem(uint dungeon_id)
        {
            TrialBossItem item;
            if (mInfos.TryGetValue(dungeon_id, out item) == false)
                return null;
            return item;
        }
    }
}