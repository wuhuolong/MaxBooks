//------------------------------------------------------------------------------
// Desc   :  角色的辅助类，包含创建角色等接口
// Author :  Raorui
// Date   :  2015.7.16
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace xc
{
    public class RoleHelp
    {
        /// <summary>
        /// 通过角色id来获取角色对应的资源名字
        /// </summary>
        public static string GetPrefabName(uint type_id, bool is_local_player = false)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();

            if (!db.ContainsKey(type_id))
            {
                GameDebug.LogError(string.Format("GetPreFabName Id:[{0}] don't exist", type_id));
                return "";
            }

            DBActor.ActorData data = db.GetData(type_id);
            string name = ModelHelper.GetModelPrefab(data.model_id, is_local_player);
            if (name.Length == 0)
                return string.Empty;

            return name;
        }

        /// <summary>
        /// 通过角色id来获取角色对应的资源名字
        /// </summary>
        public static string GetPrefabName(xc.UnitCacheInfo info)
        {
            uint id = GetActorId(info);

            DBActor db = DBManager.GetInstance().GetDB<DBActor>();
            if (!db.ContainsKey(id))
            {
                return string.Empty;
            }
            
            string name = ModelHelper.GetModelPrefab(db.GetData(id).model_id, info.IsUIModel);
            if (name.Length == 0)
                return string.Empty;
            
            return name;
        }

        /// <summary>
        /// 通过角色id来获取角色对应的角色头像
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static string GetRoleIcon(uint type_id)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();

            if (!db.ContainsKey(type_id))
            {
                GameDebug.LogError(string.Format("GetRoleIcon Id:[{0}] don't exist", type_id));
                return "";
            }

            DBActor.ActorData data = db.GetData(type_id);
            string icon = ModelHelper.GetModelIcon(data.model_id);
            if (icon.Length == 0)
                return string.Empty;

            return icon;
        }

        /// <summary>
        /// 通过角色id来获取角色对应的资源缩放
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static Vector3 GetPrefabScale(uint type_id)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();

            if (!db.ContainsKey(type_id))
            {
                GameDebug.LogError(string.Format("GetPrefabScale Id:[{0}] don't exist", type_id));
                return Vector3.one;
            }

            DBActor.ActorData data = db.GetData(type_id);
            float scale = ModelHelper.GetModelScale(data.model_id);

            return new Vector3(scale, scale, scale);
        }

        public static float GetPrefabFloatScale(uint type_id)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();

            if (!db.ContainsKey(type_id))
            {
                GameDebug.LogError(string.Format("GetPrefabScale Id:[{0}] don't exist", type_id));
                return 1f;
            }

            DBActor.ActorData data = db.GetData(type_id);
            return ModelHelper.GetModelScale(data.model_id);
        }

        /// <summary>
        /// 通过角色id来获取角色对应的资源缩放
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Vector3 GetPrefabScale(xc.UnitCacheInfo info)
        {
            uint id = GetActorId(info);

            DBActor db = DBManager.GetInstance().GetDB<DBActor>();
            if (!db.ContainsKey(id))
            {
                return Vector3.one;
            }

            float scale = ModelHelper.GetModelScale(db.GetData(id).model_id);

            return new Vector3(scale, scale, scale);
        }

        /// <summary>
        /// 通过角色id来获取角色对应的在对话框里面的摄像机偏移
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static Vector3 GetPrefabCamOffsetInDialogWnd(uint type_id)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();

            if (!db.ContainsKey(type_id))
            {
                GameDebug.LogError(string.Format("GetPrefabCamOffsetInDialogWnd Id:[{0}] don't exist", type_id));
                return Vector3.zero;
            }

            DBActor.ActorData data = db.GetData(type_id);
            return ModelHelper.GetModelCamOffsetInDialogWnd(data.model_id);
        }

        /// <summary>
        /// 通过角色id来获取角色对应的在对话框里面的摄像机旋转
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static Vector3 GetPrefabCamRotateInDialogWnd(uint type_id)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();

            if (!db.ContainsKey(type_id))
            {
                GameDebug.LogError(string.Format("GetPrefabCamRotateInDialogWnd Id:[{0}] don't exist", type_id));
                return Vector3.zero;
            }

            DBActor.ActorData data = db.GetData(type_id);
            return ModelHelper.GetModelCamRotateInDialogWnd(data.model_id);
        }

        /// <summary>
        /// 通过角色id来获取角色在场景里面的偏移位置
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static float GetHeightInScene(uint type_id, float x, float z)
        {
            float height = PhysicsHelp.GetHeight(x, z);

            return height;
        }

        /// <summary>
        /// 通过角色id来获取角色在场景里面的偏移位置
        /// </summary>
        /// <param name="type_id"></param>
        /// <returns></returns>
        public static Vector3 GetPositionInScene(uint type_id, float x, float z)
        {
            Vector3 pos = PhysicsHelp.GetPosition(x, z);

            return pos;
        }

        static uint GetActorId(xc.UnitCacheInfo info)
        {
            uint id = 0;
            if (info.UnitType == EUnitType.UNITTYPE_PLAYER)
                id = info.AOIPlayer.type_idx;
            else if (info.UnitType == EUnitType.UNITTYPE_MONSTER)
                id = info.AOIMonster.type_idx;
            else if (info.UnitType == EUnitType.UNITTYPE_NPC)
                id = (uint)info.ClientNpcDefine.ActorId;
            else if (info.UnitType == EUnitType.UNITTYPE_PET)
                id = (uint)info.AOIPet.type_idx;

            return id;
        }

        /// <summary>
        /// 根据角色表id来获取角色的名字
        /// </summary>
        public static string GetActorName(uint type_id)
        {
            DBActor db = DBManager.GetInstance().GetDB<DBActor>();
            if (!db.ContainsKey(type_id))
            {
                GameDebug.LogError(string.Format("GetActorName Id:[{0}] don't exist", type_id));
                return "";
            }

            DBActor.ActorData data = db.GetData(type_id);
            string name = data.name;
            if (name.Length == 0)
                return "";
            
            return name;
        }

        /// <summary>
        /// 获取玩家头像名(圆形头像)
        /// </summary>
        /// <param name="vocationId"> 职业 </param>
        /// <param name="transferLv"> 转职等级, 默认未转职 </param>
        /// <returns></returns>

        public static string GetPlayerIconName(uint vocationId, uint transferLv = 0, bool showTips = true)
        {
            if (showTips == true)
                GameDebug.LogError("CS.xc.RoleHelp.GetPlayerIconName方法已经废弃了，请使用lua的RoleLuaHelper.GetPlayerIconName");

            switch ((Actor.EVocationType)vocationId)
            {
                case Actor.EVocationType.ROLE1:
                    {
                        if (transferLv <= 0)
                            return "MainWindow_New@Player_1";

                        return string.Format("MainFuntion@PlayerSmall_A{0}", transferLv); 
                    }
                case Actor.EVocationType.ROLE2:
                    {
                        if (transferLv <= 0)
                            return "MainWindow_New@Player_2";

                        return string.Format("MainFuntion@PlayerSmall_B{0}", transferLv); 
                    }
                case Actor.EVocationType.ROLE3:
                    {
                        if (transferLv <= 0)
                            return "MainWindow_New@Player_3";

                        return string.Format("MainFuntion@PlayerSmall_C{0}", transferLv);
                    }
                default:
                    {
                        GameDebug.LogError("unknown vocationId = " + vocationId);
                        return "MainWindow_New@Player_1";
                    }
            }
        }

        /// <summary>
        /// 获取角色在不同副本中的名字
        /// </summary>
        public static string GetInstColorName(Actor act, string name)
        {
            //bool isRedName = SceneHelp.Instance.IsInWildInstance() && act.IsRedName;
            //bool isGrayName = SceneHelp.Instance.IsInWildInstance() && act.IsGrayName;

            Monster monster = act as Monster;
            if (act.UnitType == EUnitType.UNITTYPE_MONSTER && monster != null)
            {
                string colorText = monster.GetMonsterColorStr();

                name = "[" + colorText + "]" + name + "[-]";
            }

            ActorHelper.GetPKColorName(act.NameColor, ref name, act is LocalPlayer);

            return name;
        }
    }
}

