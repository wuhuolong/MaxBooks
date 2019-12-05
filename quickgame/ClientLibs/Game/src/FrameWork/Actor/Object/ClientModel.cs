using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace xc
{
    [wxb.Hotfix]
    public class ClientModel :Actor
    {
        /// <summary>
        /// 是否是上坐骑的角色
        /// </summary>
        public bool IsRidePlayer = false;

        /// <summary>
        /// 用于创建预览模型的玩家的uid
        /// </summary>
        public uint RawUID = 0;


        /// <summary>
        /// 创建预览模型的源玩家的AOIInfo更新时，同步更新预览模型
        /// </summary>
        public bool UpdateWithRawActor = false;

        //         private static uint mClientModelId = 0;
        //         const uint ClientModelStartId = 300; // 起始ID, 预留300给NPC和膜拜雕像使用
        //         const uint ClientModelIdCount = 10000 - ClientModelStartId; // ClientModel可拥有ID的最大数量，服务端ID从10000开始

        public override void AfterCreate()
        {
            base.AfterCreate();
            Camp = 0xffffffff;

#if UNITY_EDITOR
            gameObject.name = "ClientModel_" + UID.obj_idx + "_" + ActorId;
#endif
        }


        protected override void InitAOIData(xc.UnitCacheInfo info)
        {
            base.InitAOIData(info);

            if (ActorManager.Instance.ClientModelSet.ContainsKey(info.UnitID) == false)
            {
                ActorManager.Instance.ClientModelSet.Add(info.UnitID, this);
            }
            else
            {
                GameDebug.LogError("ClientModel has conflict key " + info.UnitID.obj_idx);
            }
        }


        public override bool IsClientModel()
        {
            return true;
        }

        /// <summary>
        /// 创建玩家的预览模型(用于创角和选角场景)
        /// </summary>
        /// <returns></returns>
        public static ClientModel CreateClientModel(uint type_id, uint uid, List<uint> modleIdLst, List<uint> fashions, List<uint> suit_effects, Action<Actor> cbResLoad = null,bool updateWithRawActor = true, bool isUIModel = false)
        {

            UnitID unit_id = ActorManager.GetAvailableModelId((byte)EUnitType.UNITTYPE_PLAYER);
            xc.UnitCacheInfo info = new xc.UnitCacheInfo(EUnitType.UNITTYPE_PLAYER, unit_id.obj_idx);
            info.AOIPlayer.model_id_list = modleIdLst;
            info.AOIPlayer.fashions = fashions;
            info.AOIPlayer.suit_effects = suit_effects;
            info.AOIPlayer.type_idx = type_id;
            info.PosBorn = Vector3.zero;
            info.IsUIModel = isUIModel;

            var client_model = ActorManager.Instance.CreateActor<ClientModel>(info, Quaternion.identity, null, true,cbResLoad);
            if (client_model == null)
                return null;
            ShadowBehavior shadow_behavior = client_model.GetBehavior<ShadowBehavior>();
            if (shadow_behavior != null)
                shadow_behavior.HideFakeShadow = true;
            client_model.UpdateWithRawActor = updateWithRawActor;
            client_model.RawUID = uid;
            return client_model;
        }

        /// <summary>
        /// 通过actor的avatar数据来创建角色（用于创建上坐骑的角色）
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="actionAfterLoad"></param>
        /// <returns></returns>
        public static ClientModel CreateClientModelByClone(Actor actor, Action<Actor> actionAfterLoad)
        {
            if (actor == null || actor.mAvatarCtrl == null)
                return null;
            AvatarProperty ap = actor.mAvatarCtrl.GetLatestAvatartProperty();

            if(ap == null || actor == null)
            {
                return null;
            }

            List<uint> suit_effects = ap.SuitEffectIds != null ? new List<uint>(ap.SuitEffectIds) : null;
            ClientModel cm = CreateClientModel(actor.TypeIdx, actor.UID.obj_idx, ap.GetEquipModleIds(), ap.GetFashionModleIds(), suit_effects, actionAfterLoad);
            cm.mAvatarCtrl.CloneAvatar(actor);
            cm.IsRidePlayer = true;
            //ActorManager.Instance.StartCoroutine(RotineCreateClientModelByClone(actor ,cm,  actionAfterLoad));
            return cm;
        }

        /// <summary>
        /// 使用传入的actor的换装数据来创建新的预览角色
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="actionAfterLoad"></param>
        /// <returns></returns>
        public static UnitID CreateClientModelByCloneForLua(Actor actor, Action<Actor> actionAfterLoad, bool updateWithRawActor = true,bool isUIModel = true)
        {
            if (actor == null || actor.mAvatarCtrl == null)
                return null;
            AvatarProperty ap = actor.mAvatarCtrl.GetLatestAvatartProperty();
            List<uint> modelList = new List<uint>();
            List<uint> fashionList = new List<uint>();
            List<uint> suit_effects = null;
            if (ap != null)
            {
                modelList = ap.GetEquipModleIds();
                fashionList = ap.GetFashionModleIds();
                suit_effects = ap.SuitEffectIds != null ? new List<uint>(ap.SuitEffectIds) : null;
            }
            ClientModel client_model = CreateClientModel(actor.TypeIdx, actor.UID.obj_idx, modelList, fashionList, suit_effects, actionAfterLoad, updateWithRawActor, isUIModel);
            if (client_model == null)
                return null;

            ShadowBehavior shadow_behavior = client_model.GetBehavior<ShadowBehavior>();
            if (shadow_behavior != null)
                shadow_behavior.HideFakeShadow = true;

            return client_model.UID;
        }

        public static uint CheckResourceActorId(uint actorId)
        {
            string prefab = RoleHelp.GetPrefabName(actorId);
            if (prefab != "" && SGameEngine.ResourceLoader.Instance.is_exist_asset("Assets/Res/" + prefab + ".prefab") == false)
            {//资源不存在，尝试默认资源
                DBActor db = DBManager.GetInstance().GetDB<DBActor>();

                if (!db.ContainsKey(actorId))
                {
                    return actorId;
                }

                DBActor.ActorData data = db.GetData(actorId);
                if(data.default_actor_id != 0)
                    return data.default_actor_id;
                return actorId;
            }
            else
                return actorId;
        }

        public static bool HasExistResourceActorId(uint actorId)
        {
            string prefab = RoleHelp.GetPrefabName(actorId);
            if (prefab == null || prefab == "")
                return false;
            if (prefab != "" && SGameEngine.ResourceLoader.Instance.is_exist_asset("Assets/Res/" + prefab + ".prefab"))
                return true;

            //资源不存在，尝试默认资源
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();
            if (!db.ContainsKey(actorId))
            {
                return false;
            }

            DBActor.ActorData data = db.GetData(actorId);
            if (data.default_actor_id == 0 || actorId == data.default_actor_id)
                return false;
            return HasExistResourceActorId(data.default_actor_id);
        }

        /// <summary>
        /// 使用角色表中的ID来创建预览角色(一般用于怪物)
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="actionAfterLoad"></param>
        /// <returns></returns>
        public static UnitID CreateClientModelByActorIdForLua(uint actorId, Action<Actor> actionAfterLoad, bool is_ui_model = false)
        {
            actorId = CheckResourceActorId(actorId);
            UnitID unit_id = ActorManager.GetAvailableModelId((byte)EUnitType.UNITTYPE_MONSTER);

            xc.UnitCacheInfo info = new xc.UnitCacheInfo(EUnitType.UNITTYPE_MONSTER, unit_id.obj_idx);
            info.AOIMonster.type_idx = actorId;
            info.PosBorn = Vector3.zero;
            info.IsUIModel = is_ui_model;
            ClientModel client_model = ActorManager.Instance.CreateActor<ClientModel>(info, Quaternion.identity, null, true, actionAfterLoad);
            if (client_model == null)
                return null;

            ShadowBehavior shadow_behavior = client_model.GetBehavior<ShadowBehavior>();
            if (shadow_behavior != null)
                shadow_behavior.HideFakeShadow = true;

            return client_model.UID;
        }

        /// <summary>
        /// 创于预览角色(使用luatable的接口)
        /// </summary>
        /// <param name="type_id"></param>
        /// <param name="uid"></param>
        /// <param name="modIdLst"></param>
        /// <param name="fashions"></param>
        /// <param name="suit_effects"></param>
        /// <param name="cbResLoad"></param>
        /// <param name="no_show_parts">不允许显示的模型部位列表（lua table）</param>
        /// <returns></returns>
        public static UnitID CreateClientModelForLua(uint type_id, uint uid, XLua.LuaTable modIdLst, XLua.LuaTable fashions, XLua.LuaTable suit_effects, Action<Actor> cbResLoad = null, XLua.LuaTable no_show_parts = null, bool is_ui_model = true, bool updateWithRawActor = true)
        {
            List<uint> model_id_list = XLua.XUtils.CreateListByLuaTable<uint, uint>(modIdLst);
            List<uint> fashions_list = XLua.XUtils.CreateListByLuaTable<uint, uint>(fashions);

            List<uint> suit_effects_list = XLua.XUtils.CreateListByLuaTable<uint, uint>(suit_effects);
            List<xc.DBAvatarPart.BODY_PART> no_show_parts_list = null;
            if(no_show_parts != null)
            {
                no_show_parts_list = XLua.XUtils.CreateListByLuaTable<uint, xc.DBAvatarPart.BODY_PART>(no_show_parts);
            }
            return CreateClientModelForLua(type_id, uid, model_id_list, fashions_list, suit_effects_list, cbResLoad, no_show_parts_list, is_ui_model, updateWithRawActor);
        }

        /// <summary>
        /// 创于预览角色(使用List的接口) 
        /// </summary>
        public static UnitID CreateClientModelForLua(uint type_id, uint uid, List<uint> modIdLst, List<uint> fashions, List<uint> suit_effects, Action<Actor> cbResLoad = null, List<xc.DBAvatarPart.BODY_PART> no_show_parts = null, bool is_ui_model = true, bool updateWithRawActor = true)
        {
            UnitID unit_id = ActorManager.GetAvailableModelId((byte)EUnitType.UNITTYPE_PLAYER);

            xc.UnitCacheInfo info = new xc.UnitCacheInfo(EUnitType.UNITTYPE_PLAYER, unit_id.obj_idx);
            List<uint> model_id_list = new List<uint>(modIdLst);
            List<uint> fashions_list = new List<uint>(fashions);
            if(suit_effects != null)
            {
                info.AOIPlayer.suit_effects = new List<uint>(suit_effects);
            }

            List<xc.DBAvatarPart.BODY_PART> no_show_part_list = null;
            if (no_show_parts != null)
            {
                no_show_part_list = new List<DBAvatarPart.BODY_PART>(no_show_parts);
                for (int index = 0; index < no_show_part_list.Count; ++index)
                {
                    xc.DBAvatarPart.BODY_PART del_body_part = no_show_part_list[index];
                    Equip.EquipHelper.DelEquipPart(model_id_list, del_body_part);
                    Equip.EquipHelper.DelEquipPart(fashions_list, del_body_part);
                }
            }

            model_id_list.AddRange(fashions_list);

            info.AOIPlayer.model_id_list = new List<uint>();
            info.AOIPlayer.fashions = new List<uint>();

            ActorHelper.GetModelFashionList(model_id_list, info.AOIPlayer.model_id_list, info.AOIPlayer.fashions);

            info.AOIPlayer.type_idx = type_id;
            info.PosBorn = Vector3.zero;
            info.IsUIModel = is_ui_model;

            var client_model = ActorManager.Instance.CreateActor<ClientModel>(info, Quaternion.identity, null, true, cbResLoad);
            if (client_model == null)
                return null;

            client_model.UpdateWithRawActor = updateWithRawActor;
            client_model.RawUID = uid;

            if (client_model.mAvatarCtrl != null && no_show_part_list != null && no_show_part_list.Count > 0)
                client_model.mAvatarCtrl.mNoShowParts = no_show_part_list;
            ShadowBehavior shadow_behavior = client_model.GetBehavior<ShadowBehavior>();
            if (shadow_behavior != null)
                shadow_behavior.HideFakeShadow = true;

            return info.UnitID;
        }


    }
}

