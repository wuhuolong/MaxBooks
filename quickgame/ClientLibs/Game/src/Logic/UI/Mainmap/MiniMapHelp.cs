using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AI;
using xc;
using xc.ui;
using Utils;
using Net;
using xc.protocol;

public enum MiniMapPointType
{
    None = 0,
    Npc,
    Transfer,//传送点

    Monster,//普通怪
    EliteMonster,//精英怪

    Boss, // BOSS
}

public class MiniMapPointInfo
{
    public Vector3 Position = Vector3.zero;
    public MiniMapPointType PointType = MiniMapPointType.None;
    public int Id;
    public uint ActorId;
    public uint MapId;

    public string Name;

    /// <summary>
    /// 深色底的名字
    /// </summary>
    public string BlackName;

    public uint Level;
    public bool ListNeedShow = false;
    public int Tag;
}

public class MiniMapHelp
{
    /// <summary>
    /// 获取指定副本中标记的普通刷怪点和特殊怪物点
    /// </summary>
    /// <returns></returns>
    public static List<MiniMapPointInfo> GetInstanceAllNormalMonster(uint instance_id)
    {
        List<MiniMapPointInfo> map_point_infos = new List<MiniMapPointInfo>();
        var nep_data = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(instance_id));
        if (nep_data == null)
        {
            GameDebug.LogError("get nep_data failed,instance id: " + instance_id);
            return map_point_infos;
        }

        Dictionary<int, Neptune.BaseGenericNode> all_node_data = nep_data.GetData<Neptune.Tag>().Data;// 获取关卡中所有标记为Tag的物体数据
        var special_monster_info = DBManager.Instance.GetDB<DBSpecialMon>().GetDungeonData(instance_id);// 获取当前副本中特殊怪物的数据(世界boss，盗宝怪)
        foreach (var item in all_node_data)
        {
            Neptune.Tag tag = item.Value as Neptune.Tag;
            if (tag == null || tag.Type == null)
                continue;

            if (tag.Type.CompareTo("map_mon_pos") == 0)// Tag 为怪物标识点
            {
                MiniMapPointInfo info = new MiniMapPointInfo();
                info.Id = tag.Id;
                info.Tag = tag.Id;
                info.Position = tag.Position;
                info.MapId = instance_id;
                string key = string.Format("{0}_{1}", tag.Id, instance_id);// 唯一id由{tag_id}_{map_id}组成
                var data_actor_tag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_actor_tag", "csv_id", key);


                //服务端不建议改表格式
                //List<Dictionary<string, string>> data_actor_tag = null;
                //string key = string.Empty;
                //SDKConfig sdk_config = SDKHelper.GetSDKConfig();
                //if (sdk_config != null && SDKHelper.IsCopyBag() && AuditManager.Instance.Open)
                //{
                //    key = string.Format("{0}_{1}{2}", tag.Id, instance_id, sdk_config.SDKNamePrefix);
                //    data_actor_tag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_actor_tag", "csv_id", key);
                //}
                

                ////当对应的马甲包没配置对应的数据时，就直接用正式数据
                //if (data_actor_tag == null || data_actor_tag.Count == 0)
                //{
                //    key = string.Format("{0}_{1}", tag.Id, instance_id);// 唯一id由{tag_id}_{map_id}组成
                //    data_actor_tag = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_actor_tag", "csv_id", key);
                //}



                if (data_actor_tag.Count > 0)
                {
                    var table = data_actor_tag[0];
                    info.ActorId = DBTextResource.ParseUI(table["actor_id"]);
                    info.ListNeedShow = DBTextResource.ParseUI(table["need_show"]) == 1 ? true : false;

                    if (ActorHelper.IsEliteMonster(info.ActorId))// 判断怪物是否是精英怪
                    {
                        info.PointType = MiniMapPointType.EliteMonster;
                    }
                    else
                    {
                        info.PointType = MiniMapPointType.Monster;
                    }

                    info.Name = ActorHelper.GetColorNameDiff(info.ActorId, 0);
                    info.BlackName = ActorHelper.GetColorNameDiff(info.ActorId, 1);
                    info.Level = ActorHelper.GetActorLevel(info.ActorId);
                    map_point_infos.Add(info);
                }
            }
            else if (tag.Type.CompareTo("boss_pos") == 0 && special_monster_info != null)
            {
                //boss读表
                string tagGroup = "boss_pos_" + tag.Id;
                DBSpecialMon.DBSpecialMonItem boss = special_monster_info.Find(delegate (DBSpecialMon.DBSpecialMonItem specialMon)
                {
                    return (specialMon.TagGroup.CompareTo(tagGroup) == 0 );
                });

                if (boss != null)
                {
                    MiniMapPointInfo info = new MiniMapPointInfo();
                    info.Id = (int)boss.Id;
                    info.Tag = tag.Id;
                    info.Position = tag.Position;
                    info.MapId = instance_id;
                    info.ActorId = boss.ActorId;
                    info.Name = ActorHelper.GetColorNameDiff(info.ActorId,0);
                    info.BlackName = ActorHelper.GetColorNameDiff(info.ActorId, 1);
                    info.Level = ActorHelper.GetActorLevel(info.ActorId);
                    info.PointType = MiniMapPointType.Boss;

                    map_point_infos.Add(info);
                }
            }
        }
        return map_point_infos;
    }

    /// <summary>
    /// 获得场景中所有npc
    /// </summary>
    /// <returns></returns>
    public static List<MiniMapPointInfo> GetInstanceAllNpc(uint instance_id)
    {
        List<MiniMapPointInfo> map_point_infos = new List<MiniMapPointInfo>();
        var nep_data = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(instance_id));
        if (nep_data == null)
        {
            GameDebug.LogError("get nep_data failed,instance id: "+ instance_id);
            return map_point_infos;
        }

        Dictionary<int, Neptune.BaseGenericNode> monstersData = nep_data.GetData<Neptune.NPC>().Data;
        foreach (var item in monstersData)
        {
            if (item.Value is Neptune.NPC)
            {
                Neptune.NPC npc = item.Value as Neptune.NPC;
                //if (npc.SpawnDirectly)
                {
                    MiniMapPointInfo info = new MiniMapPointInfo();
                    info.Id = npc.Id;
                    info.MapId = instance_id;
                    info.ActorId = NpcHelper.GetNpcActorId(npc.ExcelId);
                    info.Name = RoleHelp.GetActorName(info.ActorId);
                    info.BlackName = info.Name;
                    info.Position = npc.Position;
                    info.PointType = MiniMapPointType.Npc;
                    map_point_infos.Add(info);
                }
            }
        }
        return map_point_infos;
    }

    //是否能打开地图
    public static bool IsCanOpenMinimap()
    {
        DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(SceneHelp.Instance.CurSceneID);
        if (instanceInfo == null)
            return false;
        return instanceInfo.mIsCanOpenMiniMap;
    }

    /// <summary>
    /// 地图是否开启
    /// </summary>
    /// <param name="mapid"></param>
    /// <returns></returns>
    public static bool isMapOpen(uint mapid)
    {
        // 等级限制
        uint needLevel = InstanceHelper.GetInstanceNeedRoleLevel((uint)mapid);
        var instance = DBInstance.Instance.GetInstanceInfo(mapid);
        bool bLvLimit = needLevel <= LocalPlayerManager.Instance.Level;

        // 任务限制
        bool bTaskLimit = false;
        if (instance != null && instance.mNeedTaskId != 0)
        {
            if (TaskHelper.MainTaskIsPassed(instance.mNeedTaskId))
            {
                bTaskLimit = true;
            }
        }
        else
        {
            bTaskLimit = true;
        }


        return bLvLimit && bTaskLimit;
    }

    /// <summary>
    /// 传送点
    /// </summary>
    /// <returns></returns>
    public static List<MiniMapPointInfo> GetInstanceAllTrasnspot(uint instance_id)
    {
        List<MiniMapPointInfo> map_point_infos = new List<MiniMapPointInfo>();
        var nep_data = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(instance_id));
        if (nep_data == null)
        {
            GameDebug.LogError("get nep_data failed,instance id: " + instance_id);
            return map_point_infos;
        }

        var monstersData = nep_data.GetData<Neptune.Collider>().Data;
        foreach (var item in monstersData)
        {
            if (item.Value is Neptune.Collider)
            {
                Neptune.Collider tag = item.Value as Neptune.Collider;
                if (tag.Comment != null&& tag.Comment.CompareTo("transfer") == 0)
                {
                    MiniMapPointInfo info = new MiniMapPointInfo();
                    info.Id = tag.Id;
                    info.MapId = instance_id;
                    info.Position = tag.Position;
                    info.PointType = MiniMapPointType.Transfer;
                    map_point_infos.Add(info);
                }
            }
        }
        return map_point_infos;
    }
}

