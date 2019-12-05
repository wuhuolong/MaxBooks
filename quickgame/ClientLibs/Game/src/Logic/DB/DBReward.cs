/*----------------------------------------------------------------
// 文件名： DBReward.cs
// 文件功能描述： 奖励配置表
//----------------------------------------------------------------*/
using UnityEngine;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace xc
{
    [wxb.Hotfix]
    public class DBReward : DBSqliteTableResource
    {
		public class RewardInfo
		{
            public RewardInfo()
            {
            }

            public RewardInfo(RewardInfo rewardInfo)
            {
                mItemID = rewardInfo.mItemID;
                mGID = rewardInfo.mGID;
                mFixedNum = rewardInfo.mFixedNum;
                mNum = rewardInfo.mNum;
                mVocation = rewardInfo.mVocation;
                mEffectByLevel = rewardInfo.mEffectByLevel;
                mLvLimit = rewardInfo.mLvLimit;
                mIsBind = rewardInfo.mIsBind;
                mOpenSysId = rewardInfo.mOpenSysId;
                mShowColorEffect2 = rewardInfo.mShowColorEffect2;
            }

			public uint mItemID;
			public uint mGID;
            public long mFixedNum;
            public long mNum;
            public byte mVocation;
            public byte mEffectByLevel;
            public uint mIsBind;
            public List<uint> mLvLimit;
            public uint mOpenSysId;
            public bool mShowColorEffect2;
		}
		//Dictionary<uint, RewardInfo> mRewardInfos = new Dictionary<uint, RewardInfo>();
        Dictionary<uint, List<RewardInfo>> mRewardInfosList = null;

        public DBReward(string strName, string strPath)
            : base(strName, strPath)
        {
        }

        /// <summary>
        /// 获取奖励item列表
        /// </summary>
        /// <returns>The reward item list.</returns>
        /// <param name="rewardId">Reward identifier.</param>
        public List<RewardInfo> GetRewardItemList(uint rewardId)
        {
            List<RewardInfo> rewardList = new List<RewardInfo>();
            rewardList.Clear();
            if (mRewardInfosList == null)
            {
                mRewardInfosList = new Dictionary<uint, List<RewardInfo>>();
                mRewardInfosList.Clear();
            }
            if (mRewardInfosList.ContainsKey(rewardId) == true)
            {
                foreach (RewardInfo rewardInfo in mRewardInfosList[rewardId])
                {
                    rewardList.Add(rewardInfo);
                }
            }
            else
            {
                List<RewardInfo> rewardInfos = new List<RewardInfo>();
                rewardInfos.Clear();

                //string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1} LIKE \"{2}__\"", "reward", "item_id", rewardId);
                //List<Dictionary<string, string>> rows = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, queryStr, true);
                List<Dictionary<string, string>> rows = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "reward", "cid", rewardId.ToString());
                if (rows.Count > 0)
                {
                    foreach (Dictionary<string, string> row in rows)
                    {
                        RewardInfo rewardInfo = new RewardInfo();

                        string raw = string.Empty;
                        row.TryGetValue("item_id", out raw);
                        uint itemId = DBTextResource.ParseUI_s(raw, 0);
                        rewardInfo.mItemID = itemId;

                        row.TryGetValue("gid", out raw);
                        uint gid = DBTextResource.ParseUI_s(raw, 0);
                        rewardInfo.mGID = gid;

                        row.TryGetValue("num", out raw);
                        long num = 0;
                        if (long.TryParse(raw, out num) == false)
                        {
                            List<long> nums = DBTextResource.ParseArrayLong(raw, ",");
                            if (nums.Count > 0)
                            {
                                rewardInfo.mFixedNum = nums[0];
                                rewardInfo.mNum = nums[0];
                            }
                            else
                            {
                                rewardInfo.mFixedNum = num;
                                rewardInfo.mNum = num;
                            }
                        }
                        else
                        {
                            rewardInfo.mFixedNum = num;
                            rewardInfo.mNum = num;
                        }

                        row.TryGetValue("race", out raw);
                        byte race = DBTextResource.ParseBT_s(raw, 0);
                        rewardInfo.mVocation = race;

                        row.TryGetValue("is_lv_eff", out raw);
                        byte isLvEff = DBTextResource.ParseBT_s(raw, 0);
                        rewardInfo.mEffectByLevel = isLvEff;

                        row.TryGetValue("lv_limit", out raw);
                        rewardInfo.mLvLimit = DBTextResource.ParseArrayUint(raw, ",");

                        row.TryGetValue("is_bind", out raw);
                        rewardInfo.mIsBind = DBTextResource.ParseUI_s(raw, 0);

                        row.TryGetValue("sys_open", out raw);
                        rewardInfo.mOpenSysId = DBTextResource.ParseUI_s(raw, 0);

                        row.TryGetValue("show_color_effect2", out raw);
                        if (string.IsNullOrEmpty(raw) == true || raw.Equals("0") == true)
                        {
                            rewardInfo.mShowColorEffect2 = false;
                        }
                        else
                        {
                            rewardInfo.mShowColorEffect2 = true;
                        }

                        rewardInfos.Add(rewardInfo);
                    }
                }

                foreach (RewardInfo rewardInfo in rewardInfos)
                {
                    rewardList.Add(rewardInfo);
                }
                mRewardInfosList.Add(rewardId, rewardInfos);
            }

            // 删除不是本职业的奖励
            for (int i = rewardList.Count - 1; i >= 0; i--)
            {
                if (rewardList[i].mVocation != 0 && (uint)rewardList[i].mVocation != LocalPlayerManager.Instance.LocalActorAttribute.Vocation)
                {
                    rewardList.Remove(rewardList[i]);
                }
            }

            if (rewardList == null)
            {
                rewardList = new List<RewardInfo>();
                rewardList.Clear();
            }
            return rewardList;
        }

        public override void Unload()
        {
            base.Unload();
            if (mRewardInfosList != null)
            {
                mRewardInfosList.Clear();
            }
        }

        public override void Load() // 不进行预加载
        {
            IsLoaded = true;
        }

        protected override void ParseData(SqliteDataReader reader)
		{
		}
    }
}
