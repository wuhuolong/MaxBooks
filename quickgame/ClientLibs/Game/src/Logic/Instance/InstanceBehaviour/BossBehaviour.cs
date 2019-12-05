//------------------------------------
// BossBehavious.cs
// 野外中boss的相关逻辑
// raorui
// 2017.7.20
//------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net;
using xc.protocol;

namespace xc
{
    namespace instance_behaviour
    {
        [wxb.Hotfix]
        public class BossBehaviour : Behaviour
        {
            static uint m_affili_times = 0;
            //public static List<PkgBossInfo> mBossInfoAll;
            public class RedefinePos
            {
                public int px;
                public int py;
            }
            public class RedefineBossKiller
            {
                public uint time; // 时间
                public byte[] name; // 名字
                public uint team_id; // 队伍ID
                public uint rid; // 职业
                public List<byte[]> aff_names; // 归属者名字
            }
            [wxb.Hotfix]
            public class RedefineBossInfo
            {
                public uint id;
                public uint state;
                public uint refresh_time;
                public RedefinePos pos;
                public List<RedefineBossKiller> killers;
                public RedefineBossInfo()
                {
                    killers = new List<RedefineBossKiller>();
                }
                public static RedefineBossInfo GetInfo(PkgBossInfo pkg_info)
                {
                    if (pkg_info == null)
                        return null;
                    RedefineBossInfo protocol_info = new RedefineBossInfo();
                    protocol_info.id = pkg_info.id;
                    protocol_info.state = pkg_info.state;
                    protocol_info.refresh_time = pkg_info.refresh_time;

                    if (pkg_info.pos != null)
                    {
                        protocol_info.pos = new RedefinePos();
                        protocol_info.pos.px = pkg_info.pos.px;
                        protocol_info.pos.py = pkg_info.pos.py;
                    }
                    else
                        protocol_info.pos = null;
                    protocol_info.killers.Clear();
                    if(pkg_info.killers != null)
                    {
                        for (int index = 0; index < pkg_info.killers.Count; ++index)
                        {
                            var tmp_killer = pkg_info.killers[index];
                            RedefineBossKiller killer = new RedefineBossKiller();
                            killer.time = tmp_killer.time;
                            killer.name = tmp_killer.name;
                            killer.team_id = tmp_killer.team_id;
                            killer.rid = tmp_killer.rid;
                            killer.aff_names = tmp_killer.aff_names;
                            protocol_info.killers.Add(killer);
                        }
                    }
                    return protocol_info;
                }
            }
            public static List<RedefineBossInfo> mBossInfoAll = new List<RedefineBossInfo>();
            public static uint DataAffiliTimes
            {
                get { return m_affili_times; }
            }
            [wxb.Hotfix]
            public class BossInfoItem
            {
                public PkgBossInfo m_pkgBossInfo;
                public bool m_need_update_exchange_model = false;
                public InterObjectUnitID m_uid;
                public string m_monster_name;
                public Quaternion m_model_Quaternion;
                public Vector3 m_pos;
                bool has_created_inter_object = false;
                public bool HasCreatedInterObject { get { return has_created_inter_object; } }
                public void Update()
                {
                    UpdateExchangeModel();
                    if (m_pkgBossInfo == null || m_pkgBossInfo.state == 1)
                        return;

                    //刷新墓碑状态下的名字倒计时
                    InterObject inter_object = InterObjectManager.Instance.GetObject(m_uid);
                    if (inter_object != null)
                    {
                        // 查询特殊怪物表
                        var data_mon_attr = DBManager.Instance.GetDB<DBSpecialMon>().GetData(m_pkgBossInfo.id);
                        if (data_mon_attr == null)
                        {
                            GameDebug.LogError("Cannot find special monster info,id:" + m_pkgBossInfo.id);
                            return;
                        }

                        var actor_id = data_mon_attr.ActorId;
                        uint leave_time = 0;
                        if (m_pkgBossInfo.refresh_time > Game.GetInstance().ServerTime)
                            leave_time = (m_pkgBossInfo.refresh_time - Game.GetInstance().ServerTime);

                        string time_format = CommonTool.SecondsToStr((int)leave_time);

                        string fmt = xc.DBConstText.GetText("BOSS_REFRESH_TXT_NAME");
                        if (ActorHelper.IsHomeBoss(actor_id) // boss之家
                            || ActorHelper.IsSouthLandBoss(actor_id)    // 南天圣地
                            || ActorHelper.IsElementAreaBoss(actor_id)    // 元素禁地 
                            || ActorHelper.IsServerBoss(actor_id)  // 跨服boss
                            )
                        {
                            fmt = xc.DBConstText.GetText("BOSS_REFRESH_TXT_NAME_2");
                        }

                        string name_str = string.Format(fmt, m_monster_name, time_format);
                        inter_object.SetNameLabel(name_str);
                    }
                }

                public void UpdateExchangeModel()
                {
                    if (m_need_update_exchange_model == false)
                        return;

                    if (m_pkgBossInfo == null)
                        return;

                    if (m_pkgBossInfo.state == 1)//世界BOSS处于存活状态，删除墓碑
                    {
                        if (m_uid != null)
                        {
                            InterObjectManager.Instance.DestroyObject(m_uid);
                            m_uid = null;
                        }
                        m_need_update_exchange_model = false;
                    }
                    else//BOSS已经死亡; BOSS播放完死亡动画=>删除BOSS怪物=>创建墓碑
                    {
                        // 查询特殊怪物表
                        var data_mon_attr = DBManager.Instance.GetDB<DBSpecialMon>().GetData(m_pkgBossInfo.id);
                        if (data_mon_attr == null)
                        {
                            GameDebug.LogError("Cannot find special monster info,id:" + m_pkgBossInfo.id);
                            return;
                        }

                        var actor_id = data_mon_attr.ActorId;

                        Dictionary<UnitID, Actor> boss_actor_dict = ActorManager.Instance.GetMonsterSetByActorId(actor_id);
                        bool can_destroy_model = true;
                        foreach (var item in boss_actor_dict)
                        {
                            Actor death_boss_actor = item.Value;
                            if (death_boss_actor != null && death_boss_actor.transform != null)
                            {
                                m_model_Quaternion = death_boss_actor.transform.rotation;
                                Vector3 new_pos = death_boss_actor.transform.position;
                                if(new_pos.y < -500)
                                {
                                    GameDebug.LogError(string.Format("boss_actor pos maybe is error new_pos = {0}, {1}, {2}", 
                                        new_pos.x, new_pos.y, new_pos.z));
                                }
                                else
                                    m_pos = death_boss_actor.transform.position;
                            }

                            if(death_boss_actor != null)
                            {
                                AnimationOptions op = death_boss_actor.GetAnimationOptions(Actor.EAnimation.death);
                                if(op != null && can_destroy_model)
                                {
                                    if (death_boss_actor.IsPlaying())
                                        can_destroy_model = false;
                                }
                            }
                        }

                        if(has_created_inter_object == false)
                        {
                            has_created_inter_object = true;
                            m_monster_name = RoleHelp.GetActorName(actor_id);
                            string prefab = string.Format("Assets/Res/{0}.prefab", RoleHelp.GetPrefabName(actor_id));
                            InterObject create_inter_object = InterObjectManager.Instance.CreateObject<InterObject>(m_uid, prefab, m_pos, m_model_Quaternion, RoleHelp.GetPrefabScale(actor_id));
                            if (create_inter_object != null)
                            {
                                create_inter_object.m_StyleInfo.Offset = new Vector3(0, 2.8f, 0);
                                create_inter_object.m_StyleInfo.HeadOffset = new Vector3(0, 2.0f, 0);
                                create_inter_object.m_StyleInfo.ScreenOffset = UI3DText.NameTextScreenOffset;
                                create_inter_object.m_StyleInfo.Scale = Vector3.one;
                                create_inter_object.m_StyleInfo.IsShowBg = false;
                                create_inter_object.m_StyleInfo.SpritName = "";

                                create_inter_object.IsVisible = false;
                                DBWorldBoss.DBWorldBossItem boss_item = DBManager.Instance.GetDB<DBWorldBoss>().GetData(m_pkgBossInfo.id);
                                if(boss_item != null)
                                    create_inter_object.SetCollider(boss_item.DeathModelCenter, boss_item.DeathModelRadius);
                            }
                        }
                            
                        if (can_destroy_model)
                        {
                            InterObject create_inter_object = InterObjectManager.Instance.GetObject(m_uid);
                            if (create_inter_object != null)
                            {
                                create_inter_object.IsVisible = true;
                                create_inter_object.SetPosAndQuaternion(m_pos, m_model_Quaternion);

                            }
                            m_need_update_exchange_model = false;
                        }
                    }
                }
            }

            public class UpdateBossAffiItem
            {
                public uint m_player_id;
                //public bool m_update = false;
                public bool m_before_isAffi = false;
                public bool m_now_isAffi = false;
            }

            /// <summary>
            /// boss被击杀时间，用于世界boss体验副本的伪造数据
            /// </summary>
            static uint mBossKillTime = 0;

            List<BossInfoItem> m_bossArray;
            //bool m_isNeedUpdate = false;
            public override void Enter(params object[] param)
            {
                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_BOSS_INFO, HandleServerData);
                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_BOSS_AFFILIS, HandleServerData);
                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_BOSS_INFO_ALL, HandleServerData);
                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DUNGEON_BOSS_GUIDE_AFFI, HandleServerData);
                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_SPAN_BOSS_INFO, HandleServerData);
                ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnSwitchScene);
                ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SCENE_DESTROY_ALL_INTER_OBJECT, OnSwitchScene);
                ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_MONSTERDEAD, OnMonsterDead);
                C2SBossInfoAll data = new C2SBossInfoAll();
                Net.NetClient.GetBaseClient().SendData<C2SBossInfoAll>(NetMsg.MSG_BOSS_INFO_ALL, data);

                mBossKillTime = 0;
            }

            public override void Exit()
            {
                Clear();

                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_BOSS_INFO, HandleServerData);
                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_BOSS_AFFILIS, HandleServerData);
                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_BOSS_INFO_ALL, HandleServerData);
                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_DUNGEON_BOSS_GUIDE_AFFI, HandleServerData);
                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_SPAN_BOSS_INFO, HandleServerData);
                ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnSwitchScene);
                ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SCENE_DESTROY_ALL_INTER_OBJECT, OnSwitchScene);
                ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_MONSTERDEAD, OnMonsterDead);
            }

            void OnSwitchScene(CEventBaseArgs data)
            {
                Clear();
            }

            public void OnMonsterDead(CEventBaseArgs data)
            {
                mBossKillTime = Game.Instance.ServerTime;
            }

            public void Clear()
            {
                if (m_bossArray == null)
                {
                    m_bossArray = new List<BossInfoItem>();
                }
                ClearBossModels();
                mBossAffiTeamIds.Clear();
                m_updateBossAffiItemArray.Clear();
            }

            public void ClearBossModels()
            {
                if (m_bossArray == null)
                    return;
                for (int index = 0; index < m_bossArray.Count; ++index)
                {
                    if (m_bossArray[index].m_uid != null)
                        InterObjectManager.Instance.DestroyObject(m_bossArray[index].m_uid);
                }
                m_bossArray.Clear();
            }
            public virtual void HandleServerData(ushort protocol, byte[] data)
            {
                switch (protocol)
                {
                    case NetMsg.MSG_SPAN_BOSS_INFO:
                        {
                            var pack = S2CPackBase.DeserializePack<S2CSpanBossInfo>(data);
                            var boss_list = pack.mon_boss;

                            UpdateInfo(boss_list);

                            ClientEventMgr.Instance.FireEvent(xc.EnumUtil.EnumToInt(xc.ClientEvent.CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL), null);
                            break;
                        }
                    case NetMsg.MSG_BOSS_INFO:
                        {
                            var pack = S2CPackBase.DeserializePack<S2CBossInfo>(data);
                            var boss_list = pack.mons;
                            //m_isNeedUpdate = true;

                            UpdateInfo(boss_list);

                            ClientEventMgr.Instance.FireEvent(xc.EnumUtil.EnumToInt(xc.ClientEvent.CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL), null);
                            break;
                        }
                    case NetMsg.MSG_BOSS_AFFILIS:
                        {
                            S2CBossAffilis pack = S2CPackBase.DeserializePack<S2CBossAffilis>(data);

                            mBossAffiTeamIds[pack.boss] = pack.team_id;

                            List<UpdateBossAffiItem> item_array = GetOneBossAffiItemArray_tryAdd(pack.boss);
                            for (int index = 0; index < item_array.Count; ++index)
                            {
                                item_array[index].m_before_isAffi = item_array[index].m_now_isAffi;
                                item_array[index].m_now_isAffi = false;
                            }
                            //GameDebug.LogError("************** start");
                            //GameDebug.LogError(string.Format("[pack.uuids] pack.uuids.Count = {0}", pack.uuids.Count));
                            for (int index = 0; index < pack.uuids.Count; ++index)
                            {
                                //GameDebug.LogError(string.Format("[pack.uuids] index = {0} player_id = {1}", index, pack.uuids[index]));
                                UpdateBossAffiItem item = item_array.Find((a) =>
                                {
                                    return a.m_player_id == pack.uuids[index];
                                });
                                if (item == null)
                                {
                                    UpdateBossAffiItem tmp_item = new UpdateBossAffiItem();
                                    tmp_item.m_player_id = pack.uuids[index];
                                    tmp_item.m_now_isAffi = true;
                                    item_array.Add(tmp_item);
                                }
                                else
                                {
                                    item.m_now_isAffi = true;
                                }
                            }
// 
//                             for(int index = 0; index < m_updateBossAffiItemArray.Count; ++index)
//                             {
//                                 GameDebug.LogError(string.Format("index = {0} player_id = {1} m_now_isAffi = {2}", index, m_updateBossAffiItemArray[index].m_player_id,
//                                     m_updateBossAffiItemArray[index].m_now_isAffi));
//                             }

                           // GameDebug.LogError("************** end");
                            UpdateAffiliation(item_array);
                            break;
                        }
                    case NetMsg.MSG_BOSS_INFO_ALL:
                        {
                            var pack = S2CPackBase.DeserializePack<S2CBossInfoAll>(data);
                            m_affili_times = pack.affili_times;
                            mBossInfoAll.Clear();
                            for (int index = 0; index < pack.mons.Count; ++index)
                            {
                                var tmp_protocol_info = RedefineBossInfo.GetInfo(pack.mons[index]);
                                mBossInfoAll.Add(tmp_protocol_info);
                            }

                            C2SSpanBossInfo pkg = new C2SSpanBossInfo();
                            Net.NetClient.GetBaseClient().SendData<C2SSpanBossInfo>(NetMsg.MSG_SPAN_BOSS_INFO, pkg);

                            ClientEventMgr.Instance.FireEvent(xc.EnumUtil.EnumToInt(xc.ClientEvent.CE_WORLD_BOSS_UPDATE_BOSS_INFO_ALL), null);
                            break;
                        }
                    case NetMsg.MSG_DUNGEON_BOSS_GUIDE_AFFI:
                        {
                            if (SceneHelp.Instance.IsInWorldBossExperienceInstance == false)
                                return;
                            S2CDungeonBossGuideAffi pack = S2CPackBase.DeserializePack<S2CDungeonBossGuideAffi>(data);
                            List<UpdateBossAffiItem> item_array = GetOneBossAffiItemArray_tryAdd(1);
                            for (int index = 0; index < item_array.Count; ++index)
                            {
                                item_array[index].m_before_isAffi = item_array[index].m_now_isAffi;
                                item_array[index].m_now_isAffi = false;
                            }
                            //GameDebug.LogError("************** start");
                            //GameDebug.LogError(string.Format("[pack.uuids] pack.uuids.Count = {0}", pack.uuids.Count));
                            for (int index = 0; index < pack.uuids.Count; ++index)
                            {
                                //GameDebug.LogError(string.Format("[pack.uuids] index = {0} player_id = {1}", index, pack.uuids[index]));
                                UpdateBossAffiItem item = item_array.Find((a) =>
                                {
                                    return a.m_player_id == pack.uuids[index];
                                });
                                if (item == null)
                                {
                                    UpdateBossAffiItem tmp_item = new UpdateBossAffiItem();
                                    tmp_item.m_player_id = pack.uuids[index];
                                    tmp_item.m_now_isAffi = true;
                                    item_array.Add(tmp_item);
                                }
                                else
                                {
                                    item.m_now_isAffi = true;
                                }
                            }
                            UpdateAffiliation(item_array);
                            break;
                        }
                    default:
                        break;
                }
            }

            public void UpdateInfo(List<PkgBossInfo> boss_list)
            {
                if (m_bossArray == null)
                    m_bossArray = new List<BossInfoItem>();

                foreach (var boss_info in boss_list)
                {
                    if (mBossInfoAll != null)
                    {
                        var find_item = mBossInfoAll.Find((a) =>
                        {
                            if (a.id == boss_info.id)
                                return true;
                            return false;
                        });
                        if (find_item != null)
                        {
                            mBossInfoAll.Remove(find_item);
                        }
                        var protocol_info = RedefineBossInfo.GetInfo(boss_info);
                        mBossInfoAll.Add(protocol_info);
                    }

                    var data_mon_attr = DBManager.Instance.GetDB<DBSpecialMon>().GetData(boss_info.id);
                    if (data_mon_attr == null)
                    {
                        GameDebug.LogError("Cannot find special monster info,id:" + boss_info.id);
                        continue;
                    }

                    if (xc.SceneHelp.Instance.CurSceneID != data_mon_attr.DungeonId)
                        continue;

                    BossInfoItem tmp_item = new BossInfoItem();
                    tmp_item.m_pkgBossInfo = boss_info;
                    tmp_item.m_need_update_exchange_model = true;
                    tmp_item.m_uid = new InterObjectUnitID(InterObjectType.TOMB_STONE, tmp_item.m_pkgBossInfo.id);
                    if (tmp_item.m_pkgBossInfo.pos != null)
                    {
                        tmp_item.m_pos.x = tmp_item.m_pkgBossInfo.pos.px * 0.01f;
                        tmp_item.m_pos.z = tmp_item.m_pkgBossInfo.pos.py * 0.01f;
                    }
                    tmp_item.m_pos.y = PhysicsHelp.GetHeight(tmp_item.m_pos.x, tmp_item.m_pos.z);
                    if (tmp_item.m_pos.y < -500)
                    {
                        GameDebug.LogError(string.Format("[MSG_BOSS_INFO] boss_actor pos maybe is error new_pos = {0}, {1}, {2}",
                                tmp_item.m_pos.x, tmp_item.m_pos.y, tmp_item.m_pos.z));
                        tmp_item.m_pos.y = 0;
                        var local_player = Game.Instance.GetLocalPlayer();
                        if (local_player != null && local_player.transform != null)
                            tmp_item.m_pos.y = local_player.transform.position.y;
                    }
                    tmp_item.m_model_Quaternion = Quaternion.identity;
                    bool can_add_new_monster = true;
                    for (int index = 0; index < m_bossArray.Count; ++index)
                    {
                        BossInfoItem find_item = m_bossArray[index];
                        if (find_item.m_uid != null && find_item.m_uid.m_Idx == tmp_item.m_uid.m_Idx)
                        {
                            if (find_item.m_pkgBossInfo != null &&
                                find_item.m_pkgBossInfo.state == tmp_item.m_pkgBossInfo.state)
                                can_add_new_monster = false;
                            else
                            {
                                InterObjectManager.Instance.DestroyObject(find_item.m_uid);
                                m_bossArray.Remove(find_item);
                            }
                            break;
                        }
                    }
                    if (can_add_new_monster)
                        m_bossArray.Add(tmp_item);
                }
            }

            public override void Update()
            {
                base.Update();
                UpdateModel();
            }

            public void UpdateModel()
            {

                if (m_bossArray == null)
                    return;
                for (int index = 0; index < m_bossArray.Count; ++index)
                {
                    m_bossArray[index].Update();
                }
            }

            //List<uint> m_uuids = new List<uint>();
            Dictionary<uint, uint> mBossAffiTeamIds = new Dictionary<uint, uint>();
            Dictionary<uint, List<UpdateBossAffiItem>> m_updateBossAffiItemArray = new Dictionary<uint, List<UpdateBossAffiItem>>();
            List<UpdateBossAffiItem> GetOneBossAffiItemArray_tryAdd(uint boss_id)
            {
                List<UpdateBossAffiItem> re_array;
                if (m_updateBossAffiItemArray.TryGetValue(boss_id, out re_array) == false)
                {
                    m_updateBossAffiItemArray.Add(boss_id, new List<UpdateBossAffiItem>());
                    re_array = m_updateBossAffiItemArray[boss_id];
                }
                return re_array;
            }
            public void UpdateAffiliation(List<UpdateBossAffiItem> item_array)
            {
                for(int index = item_array.Count - 1; index >= 0; --index)
                {
                    if(item_array[index].m_before_isAffi != item_array[index].m_now_isAffi)
                    {//归属状态发生变化，需要更新
                        Actor player = ActorManager.Instance.GetActor(item_array[index].m_player_id);
                        if(player != null)
                        {
                            player.UpdateNameStyle();
                        }
                        if(item_array[index].m_now_isAffi == false)
                        {//不再是自己的归属
                         //                             GameDebug.LogError(string.Format("[RemoveAt] index = {0} player_id = {1} m_now_isAffi = {2}", index, m_updateBossAffiItemArray[index].m_player_id,
                         //                                     m_updateBossAffiItemArray[index].m_now_isAffi));
                            item_array.RemoveAt(index);
                        }
                    }
                }
            }

            /// <summary>
            /// 是否显示归属
            /// </summary>
            /// <param name="actor"></param>
            /// <returns></returns>
            public bool IsAffiliation(Actor actor)
            {
                if (actor == null)
                    return false;
                if (actor.IsPlayer() == false)
                    return false;
                foreach (var item in m_updateBossAffiItemArray)
                {
                    UpdateBossAffiItem find_item = item.Value.Find((a) =>
                    {
                        return a.m_player_id == actor.UID.obj_idx;
                    });
                    if (find_item != null && find_item.m_now_isAffi)
                        return true;
                }

                return false;
            }

            /// <summary>
            /// 是否显示归属
            /// </summary>
            /// <param name="uuid"></param>
            /// <returns></returns>
            public bool IsAffiliation(uint uuid, uint teamId)
            {
                foreach (var item in m_updateBossAffiItemArray)
                {
                    UpdateBossAffiItem find_item = item.Value.Find((a) =>
                    {
                        return a.m_player_id == uuid;
                    });
                    if (find_item != null && find_item.m_now_isAffi)
                        return true;
                }
                if (teamId > 0)
                {
                    foreach (uint item in mBossAffiTeamIds.Values)
                    {
                        if (item == teamId)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public static RedefineBossInfo GetPkgBossInfo(uint special_id)
            {
                if (mBossInfoAll == null)
                    return null;
                foreach (RedefineBossInfo info in mBossInfoAll)
                {
                    if (info.id == special_id)
                    {
                        return info;
                    }
                }
                return null;
            }

            /// <summary>
            /// 获取指定角色id的boss信息
            /// </summary>
            /// <param name="actor_id"></param>
            /// <returns></returns>
            public static RedefineBossInfo GetPkgBossInfoByActorId(uint actor_id)
            {
                // 世界BOSS体验副本伪造一个PkgBossInfo数据
                if (SceneHelp.Instance.IsInWorldBossExperienceInstance == true)
                {
                    RedefineBossInfo bossInfo = new RedefineBossInfo();

                    //Dictionary<UnitID, Actor> bossList = ActorManager.Instance.GetMonsterSetByActorId(actor_id);
                    //UnitID bossUuid = null;
                    //foreach (UnitID uuid in bossList.Keys)
                    //{
                    //    bossUuid = uuid;
                    //}
                    //Actor bossActor = ActorManager.Instance.GetActor(bossUuid);
                    // mBossKillTime大于0表示boss已经死了
                    if (mBossKillTime > 0)
                    {
                        byte[] localPlayerName = System.Text.Encoding.UTF8.GetBytes(Game.Instance.LocalPlayerName);
                        uint localPlayerVocation = LocalPlayerManager.Instance.LocalActorAttribute.Vocation;
                        bossInfo.state = 0;
                        bossInfo.refresh_time = mBossKillTime + 60;
                        bossInfo.killers.Clear();
                        RedefineBossKiller killer = new RedefineBossKiller();
                        killer.time = mBossKillTime;
                        killer.name = localPlayerName;
                        killer.team_id = TeamManager.Instance.TeamId;
                        killer.rid = localPlayerVocation;
                        killer.aff_names = new List<byte[]> { localPlayerName };
                        bossInfo.killers.Add(killer);
                    }
                    else
                    {
                        bossInfo.state = 1;
                    }

                    return bossInfo;
                }
                else
                {
                    if (mBossInfoAll == null)
                        return null;

                    foreach (var boss_info in mBossInfoAll)
                    {
                        var data_special_mon = DBManager.Instance.GetDB<DBSpecialMon>().GetData(boss_info.id);
                        if (data_special_mon != null && data_special_mon.ActorId == actor_id)
                            return boss_info;
                    }

                    return null;
                }
            }

            public static List<RedefineBossInfo> GetPkgBossInfoBySceneId(uint scene_id)
            {
                if (mBossInfoAll == null)
                    return null;
                List<RedefineBossInfo> m_find_info_array = new List<RedefineBossInfo>();
                for(int boss_index = 0; boss_index < mBossInfoAll.Count; ++boss_index)
                {
                    uint id = mBossInfoAll[boss_index].id;
                    var data_mon_attr = DBManager.Instance.GetDB<DBSpecialMon>().GetData(id);
                    if (data_mon_attr == null)
                    {
                        GameDebug.LogError("Cannot find special monster info,id:" + id);
                        continue;
                    }

                    var dungeon_id = data_mon_attr.DungeonId;
                    if (scene_id == dungeon_id)
                    {
                        m_find_info_array.Add(mBossInfoAll[boss_index]);
                    }
                }
                return m_find_info_array;
            }
        }
    }
}
