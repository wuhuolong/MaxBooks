
namespace xc
{
    [wxb.Hotfix]
    public class ActorUtils : xc.Singleton<ActorUtils>
    {
        public ActorUtils()
        {

        }

        // Lv.{0}
        /// <summary>
        /// 获得一个等级描述
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetLevelStr(int level)
        {
            if (GlobalConst.IsBanshuVersion)
                return string.Format(xc.DBConstText.GetText("ACTOR_PLAYER_LEVEL_FORMAT_BAN_SU"), level);
            else
                return string.Format(xc.DBConstText.GetText("ACTOR_PLAYER_LEVEL_FORMAT"), level);
        }

        /// <summary>
        /// 获取职业图标
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetVocationIcon(Actor.EVocationType vocation_type)
        {
            return string.Format("GuildWindow@Occupation_{0}", (int)vocation_type);
        }

        public string CSharpReplaceStr(string old_str, string find_str, string new_str)
        {
            return old_str.Replace(find_str, new_str);
        }

        public string TrimFloatStr(string str)
        {
            str = str.TrimEnd('0');
            if (str.Length > 0 && str[str.Length - 1] == '.')
                str = str.Substring(0, str.Length - 1);
            return str;
        }

        /// <summary>
        /// 返回一个ID是否人形怪
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public bool IsShemale(uint uuid)
        {
            return uuid >= GameConst.INIT_SHEMALE_UUID && uuid < GameConst.INIT_HUMAN_UUID;
        }

        /// <summary>
        /// 返回一个ID是否人形怪
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public UnityEngine.Vector3 GetBezierPoint(UnityEngine.Vector3 p0, UnityEngine.Vector3 p1, UnityEngine.Vector3 p2, UnityEngine.Vector3 p3, float percent)
        {
            float one_minus_percent = 1 - percent;
            float one_minus_percent_square = one_minus_percent * one_minus_percent;
            float one_minus_percent_cube = one_minus_percent_square * one_minus_percent;
            float percent_square = percent * percent;
            float percent_cube = percent_square * percent;
            UnityEngine.Vector3 tmp_local_pos = one_minus_percent_cube * p0 + 2 * percent * one_minus_percent_square * p1 + 2 * percent_square * one_minus_percent * p2 + percent_cube * p3;
            return tmp_local_pos;
        }

        public bool HasExistResourceAvatarPartId(uint id)
        {
            var avartaPartData = DBManager.GetInstance().GetDB<DBAvatarPart>().mData;
            if (!avartaPartData.ContainsKey(id))
            {
                return false;
            }
            string path = string.Format("Assets/Res/{0}.prefab", avartaPartData[id].path);

            return SGameEngine.ResourceLoader.Instance.is_exist_asset(path);
        }

        
        public string GetFileNameByModelId(uint modelId)
        {
            var db = DBManager.Instance.GetDB<DBAvatarPart>();
            if (db == null || db.mData == null)
            {
                return string.Empty;
            }
            DBAvatarPart.Data avatarPart;
            if(db.mData.TryGetValue(modelId,out avatarPart))
            {
                return avatarPart.SuitablePath(true);
            }
            return string.Empty;
        }
    }
}
