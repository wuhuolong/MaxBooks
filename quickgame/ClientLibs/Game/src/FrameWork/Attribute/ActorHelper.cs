using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Net;
using xc.protocol;

using xc;

namespace xc
{
    [wxb.Hotfix]
    public class ActorHelper
    {
        public const float UnitConvert = 10000.00f;//人物属性转浮点系数
        public const float UnitConvertInv = 0.0001f;//人物属性转浮点系数
        public const float DisplayUnitConvert = 100.00f;//人物属性转浮点系数
        public const float DisplayPercentUnitConvert = 100.00f;//人物属性转百分比

        public static uint GetRaceIdByActorId(uint rid)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;

            if (db.ContainsKey(rid) == false)
            {
                GameDebug.LogError("Record does't exist. type_id:" + rid);
                return 0;
            }

            return db.GetData(rid).race_id;
        }


        static public long GetDisplayBattlePower(long orig)
        {
            return orig;
            // ulong转float可能会丢失精度
            // 所有要先用double计算
            //return (uint)Mathf.CeilToInt((float)((double)orig / (double)ActorHelper.UnitConvert));
        }


        #region AOICREATE
        /// <summary>
        /// 根据PkgPlayerBrief来初始化AOI数据
        /// </summary>
        public static UnitCacheInfo CreateUnitCacheInfo(PkgPlayerBrief info, Vector3 pos)
        {
            var cache_info = new xc.UnitCacheInfo(EUnitType.UNITTYPE_PLAYER,info.uuid);
            cache_info.CacheType = xc.UnitCacheInfo.EType.ET_Create;
            cache_info.PosBorn = pos;
            cache_info.AOIPlayer.type_idx = ActorHelper.RoleIdToTypeId(info.rid);
            cache_info.AOIPlayer.name = System.Text.Encoding.UTF8.GetString(info.name);
            cache_info.AOIPlayer.model_id_list = new List<uint>();
            cache_info.AOIPlayer.fashions = new List<uint>();
            ActorHelper.GetModelFashionList(info.shows, cache_info.AOIPlayer.model_id_list, cache_info.AOIPlayer.fashions);
            cache_info.AOIPlayer.suit_effects = info.effects;
            cache_info.AOIPlayer.level = (short)info.level;
            cache_info.AOIPlayer.mount_id = info.ride;
            cache_info.AOIPlayer.name_color = info.name_color;
            cache_info.AOIPlayer.state = info.state;
            cache_info.AOIPlayer.honor_id = info.honor;
            cache_info.AOIPlayer.title_id = info.title;
            cache_info.AOIPlayer.transfer_lv = info.transfer;
            cache_info.AOIPlayer.mate_info = info.mate;

            if (info.war != null)
            {
                cache_info.AOIPlayer.camp = info.war.side;
                cache_info.AOIPlayer.team_id = info.war.team_id;
                cache_info.AOIPlayer.pet_id = info.war.pet_skin; //宠物皮肤
                cache_info.AOIPlayer.escort_id = info.war.escort_id;
            }
            else
            {
                cache_info.AOIPlayer.camp = 0;
                cache_info.AOIPlayer.team_id = 0;
                cache_info.AOIPlayer.pet_id = 0;
                cache_info.AOIPlayer.escort_id = 0;
            }
            if (info.guild != null)
            {
                cache_info.AOIPlayer.guild_id = info.guild.guild_id;
                cache_info.AOIPlayer.guild_name = System.Text.Encoding.UTF8.GetString(info.guild.guild_name);
            }
            else
            {
                cache_info.AOIPlayer.guild_id = 0;
                cache_info.AOIPlayer.guild_name = "";
            }
  
            return cache_info;
        }

        /// <summary>
        /// 根据PkgMonBrief来初始化AOI数据
        /// </summary>
        /// <param name="info"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static UnitCacheInfo CreateUnitCacheInfo(PkgMonBrief info, Vector3 pos)
        {
            var unit_cache_info = new xc.UnitCacheInfo(EUnitType.UNITTYPE_MONSTER, info.uuid);
            unit_cache_info.CacheType = xc.UnitCacheInfo.EType.ET_Create;
            unit_cache_info.PosBorn = pos;
            unit_cache_info.AOIMonster.type_idx = info.actor_id;
            unit_cache_info.AOIMonster.camp = info.side;
            unit_cache_info.AOIMonster.level = info.lv;
            Actor parent = ActorManager.Instance.GetPlayer(info.father_id);
            unit_cache_info.ParentActor = parent;
            unit_cache_info.AttrElements = info.attr_elm;

            Neptune.MonsterBase monster = Neptune.DataManager.Instance.Data.GetNode<Neptune.MonsterBase>((int)(info.group_id));
            if (monster != null)
            {
                unit_cache_info.Rotation = monster.Rotation;
            }

            return unit_cache_info;
        }

        /// <summary>
        /// 根据宠物信息创建UnitCacheInfo
        /// </summary>
        /// <param name="pet_uid"></param>
        /// <param name="pet_id"></param>
        /// <param name="actor_id"></param>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static UnitCacheInfo CreatePetUnitCacheInfo(uint pet_uid, uint pet_id, uint actor_id, Vector3 pos, Quaternion rot, Actor parent)
        {
            var unit_cache_info = new xc.UnitCacheInfo(EUnitType.UNITTYPE_PET, pet_uid);

            unit_cache_info.CacheType = xc.UnitCacheInfo.EType.ET_Create;
            unit_cache_info.PosBorn = pos;
            unit_cache_info.Rotation = rot;
            unit_cache_info.AOIPet.pet_id = pet_id;
            unit_cache_info.AOIPet.type_idx = actor_id;
            if (parent != null)
                unit_cache_info.AOIPet.is_local = (parent.UID.Equals(Game.GetInstance().LocalPlayerID));
            unit_cache_info.ParentActor = parent;

            return unit_cache_info;
        }
        #endregion AOICREATE

        public static float GetActorAttributeToFloat(uint value)
        {
            return (float)value / UnitConvert;
        }

        public static string MakeActorPropertyValueStringByCustom(uint id, uint value, string str)
        {
            string name = "";
            var battle_power_info = DBBattlePower.Instance.GetBattlePowerInfo(id);
            if (battle_power_info == null)
                return "";

            var show_type = battle_power_info.show_type;
            var desc = battle_power_info.desc;
            name = string.Format(desc, str);

            switch (show_type)
            {
                case 0:
                    {
                        name = name + value.ToString();
                    }
                    break;
                case 1:
                    {
                        string val = ((float)value / ActorHelper.UnitConvert).ToString("0.##");
                        name = name + val;
                    }
                    break;
                case 2:
                    {
                        string val = ((float)value / ActorHelper.DisplayUnitConvert).ToString("0.#") + "%";
                        name = name + val;
                    }
                    break;
            }

            return name;
        }

        public static string MakeActorPropertyValueString(uint id, uint value)
        {
            return MakeActorPropertyValueStringByCustom(id, value, "");
        }

        public static uint GetSvrRawId(uint id)
        {
            return DBServerIdMaping.Instace.GetServerZoneId(id);
        }

        public static uint GetSvrId(uint uuid)
        {
            return GetSvrRawId((uint)System.Math.Floor(uuid / 10000000f));
        }

        public static void GetPKColorName(uint nameColor, ref string name, bool isLocalPlayer)
        {
            if (nameColor > 0)
            {
                if (nameColor == GameConst.NAME_COLOR_GREEN)
                {
                    name = string.Format("<color=#0be700>{0}</color>", name);
                }
                else if (nameColor == GameConst.NAME_COLOR_WHITE)
                {
                    if (isLocalPlayer == true)
                    {
                        name = string.Format("<color=#5ec4ff>{0}</color>", name);
                    }
                    else
                    {
                        name = string.Format("<color=#90dcf5>{0}</color>", name);
                    }
                }
                else if (nameColor == GameConst.NAME_COLOR_YELLOW)
                {
                    name = string.Format("<color=#FFFF00>{0}</color>", name);
                }
                else if (nameColor == GameConst.NAME_COLOR_GRAY)
                {
                    name = string.Format("<color=#848485>{0}</color>", name);
                }
                else if (nameColor == GameConst.NAME_COLOR_RED)
                {
                    name = string.Format("<color=#ff1833>{0}</color>", name);
                }
            }
            else
                name = string.Format("<color=#5ec4ff>{0}</color>", name);

            name = string.Format("{0}", name);
        }

        public static string GetVocationIconName(uint vocation)
        {
            var spriteName = "zhanshi";
            if (vocation == 1)
                spriteName = "shengzhi";
            else if (vocation == 2)
                spriteName = "fashi";
            return spriteName;
        }

        /// <summary>
        /// 职业id转化为角色表中的id
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static uint RoleIdToTypeId(uint rid)
        {
            return (rid + 100);
        }

        /// <summary>
        /// 是否是玩家镜像
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static bool IsShemale(uint uuid)
        {
            return uuid >= GameConst.INIT_SHEMALE_UUID && uuid < GameConst.INIT_HUMAN_UUID;
        }

        /// <summary>
        /// 是否是玩家
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static bool IsPlayer(uint uuid)
        {
            return uuid >= GameConst.INIT_HUMAN_UUID && uuid < GameConst.INIT_PARTNER_UUID;
        }

        /// <summary>
        /// 是否是召唤怪
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static bool IsSummon(uint uuid)
        {
            return uuid >= GameConst.INIT_PARTNER_UUID && uuid < GameConst.INIT_VIRTUAL_UUID;
        }

        /// <summary>
        /// 是否是本地玩家的召唤怪
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static bool IsMySummon(uint uuid)
        {
            var local_player = Game.GetInstance().GetLocalPlayer();
            if (local_player != null)
            {
                foreach (var summon in local_player.SonActors)
                {
                    if (summon != null && summon.UID.obj_idx == uuid)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 职业id转化为角色表中的id(创角)
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static uint RoleIdToCreateTypeId(uint rid)
        {
            return rid;
        }

        /// <summary>
        /// 角色表中的id转化为职业id
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static uint TypeIdToRoleId(uint type_id)
        {
            return (type_id - 100);
        }

        /// <summary>
        /// 过滤出装备列表中的时装列表，并删除原列表中的时装id
        /// </summary>
        /// <param name="modle_list"></param>
        /// <returns></returns>
        public static void GetModelFashionList(List<uint> all_model_list, List<uint> model_list, List<uint> fashion_list)
        {
            if (all_model_list == null || model_list == null || fashion_list == null)
                return;

            DBAvatarPart db = DBManager.Instance.GetDB<DBAvatarPart>();
            if (db == null)
                return;

            for (int i = all_model_list.Count - 1; i >= 0; --i)
            {
                uint model_id = all_model_list[i];
                if (db.IsFashion(model_id))
                {
                    fashion_list.Add(model_id);
                    //all_modle_list.RemoveAt(i);
                }
                else
                    model_list.Add(model_id);
            }
        }

        public static uint GetPartInList(List<uint> fashionList, DBAvatarPart.BODY_PART part)
        {
            DBAvatarPart db = DBManager.Instance.GetDB<DBAvatarPart>();
            if (db == null)
                return 0;

            for (int i = 0; i < fashionList.Count; i++)
            {
                uint fashion = fashionList[i];
                if (DBManager.Instance.GetDB<DBAvatarPart>().mData.ContainsKey(fashion))
                {
                    var item = DBManager.Instance.GetDB<DBAvatarPart>().mData[fashion];
                    if (item.part == part)
                    {
                        return fashion;
                    }
                }
            }
            return 0;
        }

        public static uint GetPartInList(XLua.LuaTable fashionListLua, DBAvatarPart.BODY_PART part)
        {
            List<uint> fashionList = XLua.XUtils.CreateListByLuaTable<uint, uint>(fashionListLua);
            return GetPartInList(fashionList,part);
        }

        /// <summary>
        /// 从碰撞节点中获取ActorMono的组件
        /// </summary>
        /// <param name="collider_obj"></param>
        /// <returns></returns>
        public static ActorMono GetActorMono(GameObject collider_obj)
        {
            if (collider_obj == null)
                return null;

            return collider_obj.transform.root.GetComponent<ActorMono>();
        }

        /// <summary>
        /// 从碰撞节点中获取ActorMono的组件
        /// </summary>
        /// <param name="collider_obj"></param>
        /// <returns></returns>
        public static ActorMono GetActorMono(Transform collider_trans)
        {
            if (collider_trans == null)
                return null;

            return collider_trans.root.GetComponent<ActorMono>();
        }

        public static string GetDeadNotify(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;

            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return string.Empty;
            }

            var notify_notice = db.GetData(actorId).dead_notify;
            if (notify_notice != null)
                return System.Text.Encoding.UTF8.GetString(notify_notice);
            else
                return string.Empty;
        }

        public static uint GetSpawnTimeline(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;

            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return 0;
            }

            return db.GetData(actorId).spawn_timeline;
        }

        public static uint GetDeadTimeline(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;

            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return 0;
            }

            return db.GetData(actorId).dead_timeline;
        }

        public static bool GetIsHideShadow(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;

            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }

            return db.GetData(actorId).is_hide_shadow;
        }

        public static bool GetIsHideSelectEffect(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;

            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }

            return db.GetData(actorId).is_hide_select_effect;
        }

        /// <summary>
        /// 角色加点取系数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Dictionary<uint, float> GetAddProperty(string key)
        {
            List<string> data_attr_conv = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_attr_conv", "csv_id", key, "client_attrs");
            if (data_attr_conv.Count == 0)
                return null;
            string raw = data_attr_conv[0];
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            Dictionary<uint, float> list = new Dictionary<uint, float>();
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    uint id = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    var value = (DBTextResource.ParseF(_match.Groups[2].Value)/ 100.0f);
                    list.Add(id, value);
                }
            }
            return list;
        }

        public static List<Dictionary<uint, float>> GetRecommendAttrByVocation(uint vocation)
        {
            List<Dictionary<uint, float>> finalList = new List<Dictionary<uint, float>>();
            List<string> lvpoint_recommend = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "lvpoint_recommend", "vocation", vocation.ToString(), "recommend_attr");

            if (lvpoint_recommend.Count == 0)
                return finalList;
            string raw = lvpoint_recommend[0];
            raw = raw.Replace(" ", "");
            var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
            foreach (Match _match in matchs)
            {
                if (_match.Success)
                {
                    Dictionary<uint, float> list = new Dictionary<uint, float>();
                    uint id = (DBTextResource.ParseUI(_match.Groups[1].Value));
                    var value = (DBTextResource.ParseF(_match.Groups[2].Value) / 100.0f);
                    list.Add(id, value);
                    finalList.Add(list);
                }
            }
            return finalList;
        }

        /// <summary>
        /// 根据角色id判断是否为怪
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static bool IsMonsterByActorId(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            var UnitType = (EUnitType)data.type;
            if (UnitType == EUnitType.UNITTYPE_MONSTER)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据角色id判断是否为世界boss
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static bool IsWorldBoss(uint actorId)
        {
            if (IsMonsterByActorId(actorId) == false)
                return false;
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            return data.war_tag == GameConst.WAR_TAG_WORLD_BOSS;
        }

        /// <summary>
        /// 根据角色id判断是否为精英怪
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static bool IsEliteMonster(uint actorId)
        {
            if (IsMonsterByActorId(actorId) == false)
                return false;
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            var UnitType = data.color;
            return UnitType ==  Monster.QualityColor.ELITE;
        }

        /// <summary>
        /// 根据角色id判断是否为boss
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static bool IsBoss(uint actorId)
        {
            if (IsMonsterByActorId(actorId) == false)
                return false;
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            return data.color == Monster.QualityColor.BOSS;
        }

        /// <summary>
        /// 根据角色id判断是否为boss之家boss
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static bool IsHomeBoss(uint actorId)
        {
            if (IsMonsterByActorId(actorId) == false)
                return false;

            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            return data.war_tag == GameConst.WAR_TAG_BOSS_HOME;
        }

        /// <summary>
        /// 根据角色id判断是否为南天圣地boss
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static bool IsSouthLandBoss(uint actorId)
        {
            if (IsMonsterByActorId(actorId) == false)
                return false;

            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            return data.war_tag == GameConst.WAR_TAG_SOUTH_LAND;
        }

        /// <summary>
        /// 根据角色id判断是否为元素禁地boss
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static bool IsElementAreaBoss(uint actorId)
        {
            if (IsMonsterByActorId(actorId) == false)
                return false;

            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            return data.war_tag == GameConst.WAR_TAG_ELEMENT_AREA;
        }

        /// <summary>
        /// 根据角色id判断是否为跨服boss
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="isLocal">是否是单服</param>
        /// <returns></returns>
        public static bool IsServerBoss(uint actorId,bool isLocal = false)
        {
            if (IsMonsterByActorId(actorId) == false)
                return false;

            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return false;
            }
            var data = db.GetData(actorId);
            if (isLocal)
                return data.war_tag == GameConst.WAR_TAG_SPAN_BOSS_LOCAL;
            else
                return data.war_tag == GameConst.WAR_TAG_SPAN_BOSS;
        }

        public static string GetActorName(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return string.Empty;
            }
            var data = db.GetData(actorId);
            return data.name;
        }

        public static uint GetActorLevel(uint actorId)
        {
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            if (db.ContainsKey(actorId) == false)
            {
                GameDebug.LogError("Record does't exist. actor id:" + actorId);
                return 0;
            }
            var data = db.GetData(actorId);
            return (uint)data.level;
        }

        public static string GetColorNameByActorId(uint actorId)
        {
            string oriName = GetActorName(actorId);
            if (IsMonsterByActorId(actorId) == false)
                return oriName;
            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            var _Color = db.GetData(actorId).color;
            string colorText = "<color=#ffffff>";

            switch (_Color)
            {
                case Monster.QualityColor.BOSS:
                    {
                        colorText = "<color=#FF3F40>";
                        break;
                    }
                case Monster.QualityColor.ELITE:
                    {
                        colorText = "<color=#FF3F40>";
                        break;
                    }
                default:
                    {
                        colorText = "<color=#ffffff>";
                        break;
                    }
            }

            return string.Format("{0}{1}</color>", colorText, oriName);
        }

        /// <summary>
        /// 获取在ui上使用的角色颜色(区分浅色和深色)
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="bk_type">0: 浅色 1: 深色</param>
        /// <returns></returns>
        public static string GetColorNameDiff(uint actorId, uint bk_type)
        {
            string oriName = GetActorName(actorId);
            if (IsMonsterByActorId(actorId) == false)
                return oriName;

            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            var _Color = db.GetData(actorId).color;
            string colorText = "<color=#ffffff>";

            switch (_Color)
            {
                case Monster.QualityColor.BOSS: // 红色
                case Monster.QualityColor.ELITE:
                    {
                        colorText = GoodsHelper.GetTextColor(GameConst.QUAL_COLOR_RED, bk_type);// "<color=#FF3F40>";
                        break;
                    }
                default:
                    {
                        colorText = GoodsHelper.GetTextColor(GameConst.QUAL_COLOR_WHITE, bk_type); //"<color=#ffffff>";
                        break;
                    }
            }

            return string.Format("{0}{1}</color>", colorText, oriName);
        }

        /// <summary>
        /// 获取在ui上使用的角色等级颜色(区分浅色和深色)
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="bk_type">0: 浅色 1: 深色</param>
        /// <returns></returns>
        public static string GetColorLvDiff(uint actorId, uint bk_type)
        {
            string oriLv = GetActorLevel(actorId).ToString();
            if (IsMonsterByActorId(actorId) == false)
                return oriLv;

            DBActor db = DBManager.GetInstance().GetDB(typeof(DBActor).Name) as DBActor;
            var _Color = db.GetData(actorId).color;
            string colorText = "<color=#ffffff>";

            switch (_Color)
            {
                case Monster.QualityColor.BOSS: // 红色
                case Monster.QualityColor.ELITE:
                    {
                        colorText = GoodsHelper.GetTextColor(GameConst.QUAL_COLOR_RED, bk_type);// "<color=#FF3F40>";
                        break;
                    }
                default:
                    {
                        colorText = GoodsHelper.GetTextColor(GameConst.QUAL_COLOR_WHITE, bk_type); //"<color=#ffffff>";
                        break;
                    }
            }

            return string.Format("{0}Lv{1}</color>", colorText, oriLv);
        }

        /// <summary>
        /// 获取指定角色id的指定范围内的离玩家最近的怪物
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        public static Actor GetNearestMonsterByActorIds(XLua.LuaTable actorIds, float range)
        {
            float minDistance = float.MaxValue;
            Actor nearestMonster = null;
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            float sqrRange = range * range;
            if (localPlayer != null && actorIds != null)
            {
                List<uint> actorIdList = XLua.XUtils.CreateListByLuaTable<uint, uint>(actorIds);
                Vector3 localPlayerPos = localPlayer.Trans.position;
                foreach (Actor monster in ActorManager.Instance.MonsterSet.Values)
                {
                    if (monster != null && actorIdList.Contains(monster.TypeIdx))
                    {
                        float distance = (localPlayerPos - monster.Trans.position).sqrMagnitude;
                        if (distance < sqrRange && distance < minDistance)
                        {
                            minDistance = distance;
                            nearestMonster = monster;
                        }
                    }
                }
            }

            return nearestMonster;
        }
    }
}
