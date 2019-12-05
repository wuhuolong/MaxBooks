//------------------------------------------------------------------------------
// Desc   :  组队帮助类
// Author :  ljy
// Date   :  2017.7.11
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;
using Net;

namespace xc
{
    [wxb.Hotfix]
    public class TeamHelper
    {
        public static uint GetTeamTargetInstanceId()
        {
            uint targetId = TeamManager.Instance.TargetId;
            List<string> strs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_team_target", "id", targetId.ToString(), "dungeon_id");
            if (strs.Count > 0)
            {
                uint instanceId = 0;
                if (uint.TryParse(strs[0], out instanceId) == true)
                {
                    return instanceId;
                }
            }

            return 0;
        }

        /// <summary>
        /// 获取对应的组队目标队伍人数上限
        /// </summary>
        /// <returns></returns>
        public static uint GetTeamTargetMemberLimit()
        {
            uint targetId = TeamManager.Instance.TargetId;
            List<string> strs = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_team_target", "id", targetId.ToString(), "member_limit");
            if (strs.Count > 0)
            {
                uint memberLimit = 0;
                if (uint.TryParse(strs[0], out memberLimit) == true)
                {
                    return memberLimit;
                }
            }

            return GameConstHelper.GetUint("GAME_TEAM_MEMBER_LIMIT");
        }
    }
}
