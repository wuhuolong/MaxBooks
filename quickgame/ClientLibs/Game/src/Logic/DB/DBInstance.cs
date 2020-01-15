/*----------------------------------------------------------------
// 文件名： DBInstance.cs
// 文件功能描述： 副本配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mono.Data.Sqlite;

namespace xc
{
    public class DBInstance : DBSqliteTableResource
    {
        public static DBInstance Instance
        {
            get
            {
                return DBManager.Instance.GetDB<DBInstance>();
            }
        }

        public class InstanceInfo
        {
            public uint mId;							// id
            public int mMaxTime;                        // 最长时间
            public Dictionary<uint, uint> mNeedGoods;   // 需要的固定门票
            public List<List<uint>> mDyNeedGoods;       // 需要的动态门票
            public ushort mNeedLv;					    // 需求等级
            public ushort mLvUpLimit;                   //最大等级
            public Dictionary<uint, uint> mRecommendAttrs;  // 推荐属性
            public bool mSingleEnter;                   // 是否单人副本，此类型副本允许有队伍情况下单人进入
            public ushort mMinMemberCount;              // 进入最低人数要求
            public ushort mMaxMemberCount;              // 进入最高人数要求
            public string mName;						// 名字
            public uint mWarType;                       // 副本类型
            public uint mWarSubType;                    // 副本子类型类型
            public string mDesc;						// 描述
            public List<uint> mStages = new List<uint>();// 关卡
            public int mPKType;                        // 场景PK类型
            public ushort mReviveTimes;                 // 可复活次数
            public ushort mReadyCountDown;              // 准备倒计时
            public uint mResultCountDown;             // 结算倒计时
            public bool mIsShowMark;                    // 是否显示评分
            public List<uint> mRewardIds;               // 奖励id
            public List<uint> mShowRewardIds;               // 奖励id(前端显示用的奖励)
            public bool mIsReloadSceneWhenTheSame;      // 当切换同一个场景的副本的时候是否重新加载场景
            public bool mIsAutoFight;                   // 进入副本后是否自动开启自动战斗
            public bool mCanNotRide;                    // 是否不能骑坐骑
            public string mMiniMapName;                      //小地图名字
            public float mMiniMapWidth;                   // 小地图宽
            public float mMiniMapHeight;                   // 小地图高
            public Vector2 mMinPos;                     //左下角坐标
            public Vector2 mMaxPos;                     //右上角坐标
            public bool mIsCanOpenMiniMap;               //是否能打开小地图
            public List<uint> mNeedTrigram;             //需要的剑灵
            public uint mNeedTaskId;                    //需要的任务
            public uint mPlanesInstanceId;              // 位面副本
            public uint mStartTimeline;                 // 副本开始的剧情动画
            public uint mGuardedNpcId;                  // 守护npc角色ID
            public bool mShowBossAssistant;             // 是否显示boss助手
            public bool mForbidJumpOutAnimationOut;        // 从该副本跳出时禁止切出动画
            public bool mForbidWaterWaveEffect;         // 禁止切出动画
            public Dictionary<uint, uint> mSweepCosts;  // 扫荡消耗
            public Vector2 mSweepLimit;                 // 扫荡要求（x,等级; y,评分）
            public bool mIsCanSendPosition;             // 是否能发送位置（聊天界面）
            public uint mMergeLevel;                    // 合并等级限制
            public Dictionary<uint, uint> mMergeConsume;// 需要的固定门票

            //从1开始
            public uint GetTrigram(uint vocation)
            {
                int idx = (int)vocation - 1;
                if (mNeedTrigram != null && mNeedTrigram.Count > idx)
                {
                    return mNeedTrigram[idx];
                }
                else
                    return 0;
            }

            public List<uint> GetShowRewardIds()
            {
                List<uint> showRewardIds = new List<uint>();
                showRewardIds.Clear();
                if (mRewardIds != null)
                {
                    foreach (uint rewardId in mRewardIds)
                    {
                        showRewardIds.Add(rewardId);
                    }
                }
                if (mShowRewardIds != null)
                {
                    foreach (uint rewardId in mShowRewardIds)
                    {
                        showRewardIds.Add(rewardId);
                    }
                }
                return showRewardIds;
            }
		}
		Dictionary<uint, InstanceInfo> mInstanceInfos = new Dictionary<uint, InstanceInfo>();

        /// <summary>
        /// 通过反射读取GameConst的值的缓存
        /// </summary>
        Dictionary<string, uint> mGameConstUintValueCache;

        public DBInstance(string strName, string strPath)
            : base(strName, strPath)
		{
            mGameConstUintValueCache = new Dictionary<string, uint>();
            mGameConstUintValueCache.Clear();
        }

		/// <summary>
		/// 获取某个副本的信息
		/// </summary>
		/// <returns>The instance info.</returns>
		/// <param name="id">Identifier.</param>
		public InstanceInfo GetInstanceInfo(uint id)
		{
            InstanceInfo info = null;
            if (mInstanceInfos.TryGetValue(id, out info))
            {
                return info;
            }

            string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1}=\"{2}\"", mTableName, "id", id.ToString());
            var table_reader = DBManager.Instance.ExecuteSqliteQueryToReader(GlobalConfig.DBFile, mTableName, queryStr);
            if (table_reader == null)
            {
                mInstanceInfos.Add(id, null);
                return null;
            }

            if (!table_reader.HasRows)
            {
                mInstanceInfos.Add(id, null);
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            if (!table_reader.Read())
            {
                mInstanceInfos.Add(id, null);
                table_reader.Close();
                table_reader.Dispose();
                return null;
            }

            info = new InstanceInfo();
            Type gameConstType = typeof(GameConst);

            info.mId = DBTextResource.ParseUI_s(GetReaderString(table_reader, "id"), 0);
            info.mMaxTime = DBTextResource.ParseI(GetReaderString(table_reader, "max_time"));
            info.mNeedGoods = DBTextResource.ParseDictionaryUintUint(GetReaderString(table_reader, "need_goods"));
            info.mDyNeedGoods = DBTextResource.ParseArrayUintUint(GetReaderString(table_reader, "dy_need_goods"));
            info.mNeedLv = DBTextResource.ParseUS_s(GetReaderString(table_reader, "need_lv"), 0);
            info.mLvUpLimit = DBTextResource.ParseUS_s(GetReaderString(table_reader, "lv_up_limit"), 0);
            info.mRecommendAttrs = ParseRecommendAttrs(GetReaderString(table_reader, "recommend_attrs"));
            info.mSingleEnter = DBTextResource.ParseI(GetReaderString(table_reader, "single_enter")) == 1 ? true : false;
            string mbCountStr = GetReaderString(table_reader, "mb_count");
            ushort mbCount = 0;
            /* 进入人数四种要求:
            0：可单人，也可以任意组队(不用配)
            1：必须单人(可以没有队伍，也可以在只有他一个人的队伍中)
            N(N>=2)：必须N人以上组队
            {M,N}：大于等于M且小于等于N */
            if (string.IsNullOrEmpty(mbCountStr) == true)
            {
                info.mMinMemberCount = 0;
                info.mMaxMemberCount = GameConstHelper.GetShort("GAME_TEAM_MEMBER_LIMIT");
            }
            else if (ushort.TryParse(mbCountStr, out mbCount) == true)
            {
                info.mMinMemberCount = mbCount;
                if (info.mMinMemberCount == 0)
                {
                    info.mMaxMemberCount = GameConstHelper.GetShort("GAME_TEAM_MEMBER_LIMIT");
                }
                else if (info.mMinMemberCount == 1)
                {
                    info.mMinMemberCount = 0;
                    info.mMaxMemberCount = 1;
                }
                else
                {
                    info.mMaxMemberCount = GameConstHelper.GetShort("GAME_TEAM_MEMBER_LIMIT");
                }
            }
            else
            {
                List<uint> mbCountList = DBTextResource.ParseArrayUint(mbCountStr, ",");
                if (mbCountList.Count >= 2)
                {
                    info.mMinMemberCount = (ushort)mbCountList[0];
                    info.mMaxMemberCount = (ushort)mbCountList[1];
                }
            }
            info.mSweepCosts = DBTextResource.ParseDictionaryUintUint(GetReaderString(table_reader, "sweep_costs"));
            info.mSweepLimit = DBTextResource.ParseVector2(GetReaderString(table_reader, "sweep_limit"));

            info.mName = GetReaderString(table_reader, "name");

            //System.Reflection.FieldInfo fieldInfo = null;
            //string warTypeStr = GetReaderString(table_reader, "war_type");
            //if (mGameConstUintValueCache.ContainsKey(warTypeStr) == true)
            //{
            //    info.mWarType = mGameConstUintValueCache[warTypeStr];
            //}
            //else
            //{
            //    fieldInfo = gameConstType.GetField(warTypeStr);
            //    if (fieldInfo != null)
            //    {
            //        info.mWarType = Convert.ToUInt32(fieldInfo.GetValue(null));
            //        mGameConstUintValueCache[warTypeStr] = info.mWarType;
            //    }
            //    else
            //    {
            //        GameDebug.LogError("Can not find war type " + warTypeStr + " in db instance!!!");
            //    }
            //}

            //string warsubTypeStr = GetReaderString(table_reader, "war_subtype");
            //if (string.IsNullOrEmpty(warsubTypeStr) == false)
            //{
            //    if (mGameConstUintValueCache.ContainsKey(warsubTypeStr) == true)
            //    {
            //        info.mWarSubType = mGameConstUintValueCache[warsubTypeStr];
            //    }
            //    else
            //    {
            //        fieldInfo = gameConstType.GetField(warsubTypeStr);
            //        if (fieldInfo != null)
            //        {
            //            info.mWarSubType = Convert.ToUInt32(fieldInfo.GetValue(null));
            //            mGameConstUintValueCache[warsubTypeStr] = info.mWarSubType;
            //        }
            //        else
            //        {
            //            GameDebug.LogError("Can not find sub war type " + warsubTypeStr + " in db instance!!!");
            //        }
            //    }
            //}

            uint warType = 0;
            uint warSubType = 0;
            string warTypeStr = GetReaderString(table_reader, "war_type");
            string warSubTypeStr = GetReaderString(table_reader, "war_subtype");
            ConvertWarType(warTypeStr, warSubTypeStr, out warType, out warSubType);
            info.mWarType = warType;
            info.mWarSubType = warSubType;

            info.mDesc = GetReaderString(table_reader, "desc");

            info.mStages.Clear();
            string stagesStr = GetReaderString(table_reader, "stages");
            List<string> stages = DBTextResource.ParseArrayString(stagesStr);
            for (int j = 0; j < stages.Count; j++)
            {
                if (!String.IsNullOrEmpty(stages[j]))
                {
                    info.mStages.Add(DBTextResource.ParseUI(stages[j]));
                }
            }

            info.mPKType = DBTextResource.ParseI(GetReaderString(table_reader, "pk_type"));
            info.mReviveTimes = DBTextResource.ParseUS(GetReaderString(table_reader, "revive_times"));
            info.mReadyCountDown = DBTextResource.ParseUS(GetReaderString(table_reader, "ready_count_down"));
            info.mResultCountDown = DBTextResource.ParseUI(GetReaderString(table_reader, "result_count_down"));
            info.mIsReloadSceneWhenTheSame = DBTextResource.ParseI(GetReaderString(table_reader, "is_reload_scene_when_the_same")) == 0 ? false : true;

            info.mMinPos = DBTextResource.ParseVector2(GetReaderString(table_reader, "mini_map_pos_x"));
            info.mMaxPos = DBTextResource.ParseVector2(GetReaderString(table_reader, "mini_map_pos_y"));
            info.mMiniMapWidth = info.mMaxPos.x - info.mMinPos.x;
            info.mMiniMapHeight = info.mMaxPos.y - info.mMinPos.y;
            info.mMiniMapName = GetReaderString(table_reader, "mini_map");
            info.mIsCanOpenMiniMap = DBTextResource.ParseI(GetReaderString(table_reader, "is_open_mini_map")) == 0 ? false : true;
            string isShowMarkStr = GetReaderString(table_reader, "is_show_mark");
            if (isShowMarkStr == string.Empty || isShowMarkStr == "0")
            {
                info.mIsShowMark = false;
            }
            else
            {
                info.mIsShowMark = true;
            }

            string isAutoFightStr = GetReaderString(table_reader, "is_auto_fight");
            if (isAutoFightStr == string.Empty || isAutoFightStr == "0")
            {
                info.mIsAutoFight = false;
            }
            else
            {
                info.mIsAutoFight = true;
            }

            string canNotRideStr = GetReaderString(table_reader, "can_not_ride");
            if (canNotRideStr == string.Empty || canNotRideStr == "0")
            {
                info.mCanNotRide = false;
            }
            else
            {
                info.mCanNotRide = true;
            }

            info.mRewardIds = DBTextResource.ParseArrayUint(GetReaderString(table_reader, "reward_1"), ",");
            info.mShowRewardIds = DBTextResource.ParseArrayUint(GetReaderString(table_reader, "show_rewards"), ",");
            info.mNeedTaskId = DBTextResource.ParseUI_s(GetReaderString(table_reader, "need_task_id"), 0);

            info.mPlanesInstanceId = DBTextResource.ParseUI_s(GetReaderString(table_reader, "planes_dg_id"), 0);
            info.mStartTimeline = DBTextResource.ParseUI_s(GetReaderString(table_reader, "start_timeline"), 0);
            info.mGuardedNpcId = DBTextResource.ParseUI_s(GetReaderString(table_reader, "npc_id"), 0);

            string showBossAssStr = GetReaderString(table_reader, "show_boss_assistant");
            if (showBossAssStr == string.Empty || showBossAssStr == "0")
            {
                info.mShowBossAssistant = false;
            }
            else
            {
                info.mShowBossAssistant = true;
            }

            info.mForbidJumpOutAnimationOut = DBTextResource.ParseUI_s(GetReaderString(table_reader, "forbid_jump_out_animation_out"), 0) == 1;
            info.mForbidWaterWaveEffect = DBTextResource.ParseUI_s(GetReaderString(table_reader, "forbid_water_wave_effect"), 0) == 1;
            info.mIsCanSendPosition = DBTextResource.ParseUI_s(GetReaderString(table_reader, "is_can_send_position"), 0) == 1;
            info.mMergeLevel = DBTextResource.ParseUI_s(GetReaderString(table_reader, "merge_level"), 0);
            info.mMergeConsume = DBTextResource.ParseDictionaryUintUint(GetReaderString(table_reader, "merge_consume"));

#if UNITY_EDITOR
            if (mInstanceInfos.ContainsKey(info.mId))
            {
                GameDebug.LogError(string.Format("[{0}]表重复添加的域id[{1}]", mTableName, info.mId));

                table_reader.Close();
                table_reader.Dispose();
                return info;
            }
#endif
            mInstanceInfos.Add(info.mId, info);

            table_reader.Close();
            table_reader.Dispose();

            return info;
        }

        /// <summary>
        /// 把字符串类型的war type转换成整型
        /// </summary>
        /// <param name="warTypeStr"></param>
        /// <param name="warSubTypeStr"></param>
        /// <param name="warType"></param>
        /// <param name="warSubType"></param>
        void ConvertWarType(string warTypeStr, string warSubTypeStr, out uint warType, out uint warSubType)
        {
            warType = 0;
            warSubType = 0;

            object[] param = { warTypeStr, warSubTypeStr };
            System.Type[] return_type = { typeof(uint), typeof(uint) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "InstanceHelper_ConvertWarType", param, return_type);
            if (objs != null && objs.Length > 1)
            {
                if (objs[0] != null)
                {
                    warType = (uint)objs[0];
                }
                if (objs[1] != null)
                {
                    warSubType = (uint)objs[1];
                }
            }
        }

        /// <summary>
        /// 获得该副本的开始剧情动画
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public uint GetInstanceStartTimeline(uint id)
        {
            InstanceInfo instanceInfo = GetInstanceInfo(id);
            if (instanceInfo != null)
            {
                return instanceInfo.mStartTimeline;
            }

            return 0;
        }
        
        Dictionary<uint, uint> ParseRecommendAttrs(string str)
        {
            if (string.IsNullOrEmpty(str) == true)
            {
                return null;
            }

            Dictionary<uint, uint> recommendAttrs = new Dictionary<uint, uint>();
            recommendAttrs.Clear();
            List<List<string>> arrayStringString = DBTextResource.ParseArrayStringString(str);
            foreach (List<string> arrayString in arrayStringString)
            {
                if (arrayString.Count >= 2)
                {
                    uint attr = 0;
                    uint.TryParse(arrayString[0], out attr);
                    uint value = 0;
                    uint.TryParse(arrayString[1], out value);
                    recommendAttrs.Add(attr, value);
                }
            }

            return recommendAttrs;
        }

        public override void Unload()
        {
            base.Unload();
            mInstanceInfos.Clear();
        }

        public override void Load()
        {
            IsLoaded = true;
        }
	}
}
