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
using xc.Dungeon;

[wxb.Hotfix]
public class InstanceHelper
{
    /// <summary>
    /// 副本投票
    /// </summary>
    public static void Vote(uint vote, uint reason = 0)
    {
        InstanceManager.InstancePollInfo pollInfo = InstanceManager.Instance.PollInfo;
        if (pollInfo != null)
        {
            C2SDungeonPollPersonal msg = new C2SDungeonPollPersonal();
            msg.poll_id = pollInfo.PollId;
            msg.vote = vote;
            msg.reason = reason;
            Net.NetClient.GetBaseClient().SendData<C2SDungeonPollPersonal>(NetMsg.MSG_DUNGEON_POLL_PERSONAL, msg);
        }
    }
    
    /// <summary>
    /// 催促开启投票
    /// </summary>
    public static void HastenVote(uint instanceId)
    {
        C2SDungeonPollHasten msg = new C2SDungeonPollHasten();
        msg.dungeon_id = instanceId;
        Net.NetClient.GetBaseClient().SendData<C2SDungeonPollHasten>(NetMsg.MSG_DUNGEON_POLL_HASTEN, msg);
    }

    public static void JumpToInstance(uint id, uint warType, uint warSubType, System.Action sendJumpFunc)
    {
        object[] param = { id, warType, warSubType, sendJumpFunc };
        LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "InstanceHelper_JumpToInstance", param);
    }

    /// <summary>
    /// 进入武神塔
    /// </summary>
    public static void EnterKungFuGod()
    {
        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_SECRET_AREA) == false)
        {
            return;
        }

        if (PKModeManagerEx.Instance.TryToOtherDungeonScene() == false)
        {
            return;
        }

        JumpToInstance(0, GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_SECRET_AREA, () => {
            var pack = new C2SDungeonSecretAreaEnter();
            NetClient.GetBaseClient().SendData<C2SDungeonSecretAreaEnter>(NetMsg.MSG_DUNGEON_SECRET_AREA_ENTER, pack);
        });
    }

    /// <summary>
    /// 进入破碎死域
    /// </summary>
    public static void EnterDeadSpace()
    {
        if (SceneHelp.Instance.IsInDeadSpaceInstance == true)
        {
            xc.UINotice.Instance.ShowMessage(DBConstText.GetText("INSTANCE_ALREADY_IN_IT"));
            return;
        }

        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_DEAD_SPACE) == false)
        {
            return;
        }

        if (PKModeManagerEx.Instance.TryToOtherDungeonScene() == false)
        {
            return;
        }

        JumpToInstance(0, GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_DEAD_SPACE, () => {
            var pack = new C2SDungeonDeadSpaceEnter();
            NetClient.GetBaseClient().SendData<C2SDungeonDeadSpaceEnter>(NetMsg.MSG_DUNGEON_DEAD_SPACE_ENTER, pack);
        });
    }

    /// <summary>
    /// 进入剑域盛会
    /// </summary>
    public static void EnterWorshipMeeting()
    {
        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_WORSHIP_MEETING) == false)
        {
            return;
        }

        if (PKModeManagerEx.Instance.TryToOtherDungeonScene() == false)
        {
            return;
        }

        JumpToInstance(0, GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_WORSHIP_MEETING, () => {
            var pack = new C2SDungeonWorshipMeetingEnter();
            NetClient.GetBaseClient().SendData<C2SDungeonWorshipMeetingEnter>(NetMsg.MSG_DUNGEON_WORSHIP_MEETING_ENTER, pack);
        });
    }

    public static void EnterGuildManor(bool playJumpOutAnimation = true)
    {
        if (SceneHelp.Instance.IsInGuildManor == true)
        {
            UINotice.Instance.ShowMessage(DBConstText.GetText("GUILD_ALREADY_IN_GUILD_MANOR"));
            return;
        }

        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_WILD, GameConst.WAR_SUBTYPE_GUILD_MANOR) == false)
        {
            return;
        }

        if (PKModeManagerEx.Instance.TryToOtherDungeonScene() == false)
            return;

        if (playJumpOutAnimation)
        {
            JumpToInstance(0, GameConst.WAR_TYPE_WILD, GameConst.WAR_SUBTYPE_GUILD_MANOR, () => {
                var pack = new C2SGuildManorEnter();
                NetClient.GetBaseClient().SendData<C2SGuildManorEnter>(NetMsg.MSG_GUILD_MANOR_ENTER, pack);
            });
        }
        else
        {
            var pack = new C2SGuildManorEnter();
            NetClient.GetBaseClient().SendData<C2SGuildManorEnter>(NetMsg.MSG_GUILD_MANOR_ENTER, pack);
        }
    }

    /// <summary>
    /// 进入帮派红包雨
    /// </summary>
    /// <param name="playJumpOutAnimation"></param>
    public static void EnterGuildRainRedPacket(bool playJumpOutAnimation = true)
    {
        if (SceneHelp.Instance.IsInGuildManor == true)
        {
            UINotice.Instance.ShowMessage(DBConstText.GetText("GUILD_ALREADY_IN_GUILD_MANOR"));
            return;
        }

        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_WILD, GameConst.WAR_SUBTYPE_GUILD_MANOR) == false)
        {
            return;
        }

        if (PKModeManagerEx.Instance.TryToOtherDungeonScene() == false)
            return;

        if (playJumpOutAnimation)
        {
            JumpToInstance(0, GameConst.WAR_TYPE_WILD, GameConst.WAR_SUBTYPE_GUILD_MANOR, () =>
            {
                
                var pack = new C2SMoneyRainStart();
                NetClient.GetBaseClient().SendData<C2SMoneyRainStart>(NetMsg.MSG_MONEY_RAIN_START, pack);
            });
        }
        else
        {
            var pack = new C2SMoneyRainStart();
            NetClient.GetBaseClient().SendData<C2SMoneyRainStart>(NetMsg.MSG_MONEY_RAIN_START, pack);
        }
    }


    /// <summary>
    /// 进入远洋海盗船
    /// </summary>
    /// <param name="type"></param>
    public static void EnterCorsair(uint type)
    {
        if (type == 1)
        {
            if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_CORSAIR) == false)
            {
                return;
            }

            if (PKModeManagerEx.Instance.TryToOtherDungeonScene() == false)
                return;

            JumpToInstance(0, GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_CORSAIR, () => {
                var pack = new C2SDungeonCorsairEnter();
                pack.type = type;
                NetClient.GetBaseClient().SendData<C2SDungeonCorsairEnter>(NetMsg.MSG_DUNGEON_CORSAIR_ENTER, pack);
            });
        }
        else
        {
            var pack = new C2SDungeonCorsairEnter();
            pack.type = type;
            NetClient.GetBaseClient().SendData<C2SDungeonCorsairEnter>(NetMsg.MSG_DUNGEON_CORSAIR_ENTER, pack);
        }
    }

    /// <summary>
    /// 进入帮派BOSS
    /// </summary>
    public static void EnterGuildBoss()
    {
        if (SceneHelp.Instance.IsInGuildBossInstance == true)
        {
            UINotice.Instance.ShowMessage(DBConstText.GetText("GUILD_ALREADY_IN_GUILD_BOSS"));
            return;
        }

        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_GUILD_BOSS) == false)
        {
            return;
        }

        JumpToInstance(0, GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_GUILD_BOSS, () => {
            var pack = new C2SGuildBossEnter();
            NetClient.GetBaseClient().SendData<C2SGuildBossEnter>(NetMsg.MSG_GUILD_BOSS_ENTER, pack);
        });
    }

    /// <summary>
    /// 进入帮派联赛
    /// </summary>
    public static void EnterGuildLeague()
    {
        if (SceneHelp.Instance.IsInGuildLeagueInstance() == true)
        {
            UINotice.Instance.ShowMessage(DBConstText.GetText("GUILD_ALREADY_IN_GUILD_LEAGUE"));
            return;
        }

        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_GUILD_LEAGUE) == false)
        {
            return;
        }

        JumpToInstance(0, GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_GUILD_LEAGUE, () => {
            var pack = new C2SGuildLeagueEnter();
            NetClient.GetBaseClient().SendData<C2SGuildLeagueEnter>(NetMsg.MSG_GUILD_LEAGUE_ENTER, pack);
        });
    }

    /// <summary>
    /// 进入婚宴副本
    /// </summary>
    public static void EnterWeddingInstance()
    {
        if (SceneHelp.Instance.IsInWeddingInstance == true)
        {
            UINotice.Instance.ShowMessage(DBConstText.GetText("INSTANCE_ALREADY_IN_IT"));
            return;
        }

        if (SceneHelp.CheckCanSwitch(GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_WEDDING) == false)
        {
            return;
        }

        JumpToInstance(0, GameConst.WAR_TYPE_DUNGEON, GameConst.WAR_SUBTYPE_WEDDING, () =>
        {
            var pack = new C2SDungeonWeddingEnter();
            NetClient.GetBaseClient().SendData<C2SDungeonWeddingEnter>(NetMsg.MSG_DUNGEON_WEDDING_ENTER, pack);
        });
    }

    /// <summary>
    /// 使用药水在副本中
    /// </summary>
    public static void UseDrugInInstance()
    {
        //C2SWarUseHpDrug msg = new C2SWarUseHpDrug();
        //NetClient.GetBaseClient().SendData<C2SWarUseHpDrug>(NetMsg.MSG_WAR_USE_HP_DRUG, msg);
    }

    public static Vector3 FindAvailableWalkablePos(Vector3 center, float radius)
    {
        int angle = 60;

        Vector3 result = center;

        for (int i = 0; i < 360 / angle; i++)
        {
            result.x = center.x + radius * Mathf.Cos(angle * i);
            result.z = center.z + radius * Mathf.Sin(angle * i);

            Vector3 clamp = ClampInWalkableRange(result);

            if(AIHelper.RoughlyEqual(clamp, result))
            {
                return result;
            }
        }

        return ClampInWalkableRange(result);
    }

    public static Vector3 ClampInWalkableRange(Vector3 raw, float maxDistance = 30)
    {
        Vector3 defaultPos = raw;
        if (InstanceIsInCave() == false)
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                defaultPos = localPlayer.transform.position;
            }
        }
        return ClampInWalkableRange(raw, defaultPos, maxDistance);
    }

    /// <summary>
    /// 武神塔对应副本的id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static uint GetKungfuGodInstanceId(uint id)
    {
        List<string> data_secret_area = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_secret_area", "id", id.ToString(), "dgn_id");
        if (data_secret_area.Count == 0)
        {
            return 0;
        }

        uint instanceId = 0;
        uint.TryParse(data_secret_area[0], out instanceId);

        return instanceId;
    }

    /// <summary>
    /// 武神塔对应副本的名字
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string GetKungfuGodInstanceName(uint id)
    {
        List<string> data_secret_area = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_secret_area", "id", id.ToString(), "dgn_id");
        if (data_secret_area.Count == 0)
        {
            return "";
        }

        uint instanceId = 0;
        uint.TryParse(data_secret_area[0], out instanceId);
        DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
        if (instanceInfo != null)
        {
            return instanceInfo.mName;
        }

        return "";
    }

    /// <summary>
    /// 武神塔获得物品
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static List<Goods> GetKungfuGodReward(uint id)
    {
        List<Goods> goodsList = new List<Goods>();
        List<string> data_secret_area = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_secret_area", "id", id.ToString(), "goods");
        if (data_secret_area.Count == 0)
            return goodsList;

        string raw = data_secret_area[0];
        raw = raw.Replace(" ", "");
        var matchs = Regex.Matches(raw, @"\{(\d+),(\d+)\}");
        foreach (Match _match in matchs)
        {
            if (_match.Success)
            {
                uint goodsid = DBTextResource.ParseUI(_match.Groups[1].Value);
                uint goodsnum = DBTextResource.ParseUI(_match.Groups[2].Value);
                Goods goods = GoodsFactory.Create(goodsid, null);
                if (goods != null)
                {
                    goods.num = goodsnum;
                    goodsList.Add(goods);
                }
            }
        }
        return goodsList;
    }

    /// <summary>
    /// 将坐标约束在范围内,这个函数如果短时间内调用多次会直接在安德猴上面的卡死
    /// </summary>
    /// <returns>The in walkable range.</returns>
    /// <param name="raw">Raw.</param>
    /// <param name="defaultPos">Default position.</param>
    public static Vector3 ClampInWalkableRange(Vector3 raw, Vector3 defaultPos, float maxDistance = 30)
    {
        bool result = false;

        return ClampInWalkableRange(raw, defaultPos, out result, maxDistance);
    }

    public static Vector3 ClampInWalkableRange(Vector3 raw, Vector3 defaultPos, out bool result, float maxDistance = 30)
    {
        XNavMeshHit nearestHit;

        result = XNavMesh.SamplePosition(raw, out nearestHit, maxDistance, LevelManager.GetInstance().AreaExclude);

        if (result)
        {
            return nearestHit.position;
        }
        else
        {
            GameDebug.Log("Instance Helper::ClampInWalkableRange can not clamp position:" + raw.ToString());

            return defaultPos;
        }
    }

    public static string GetInstanceDifficultyName(uint instanceDifficulty)
    {
        string str = DBConstText.GetText("INST_DIFF_" + instanceDifficulty);
        if (string .IsNullOrEmpty(str) == false)
        {
            return str;
        }
        return xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_46");
//        if (instanceDifficulty == 1)
//            return "普通";
//        else if (instanceDifficulty == 2)
//            return "困难";
//        else if (instanceDifficulty == 3)
//            return "专家";
//        else if (instanceDifficulty == 4)
//            return "折磨";
//        else if (instanceDifficulty == 5)
//            return "噩梦";
//
//        return "未知难度";
    }

    public static bool CanWalkTo(Vector3 dst)
    {
        Actor localPlayer = Game.GetInstance().GetLocalPlayer();
        if (localPlayer != null)
        {
            var path = new XNavMeshPath();
            Vector3 playerPos = localPlayer.transform.position;
            dst = PhysicsHelp.GetPosition(dst.x, dst.z);
            XNavMesh.CalculatePath(playerPos, dst, LevelManager.GetInstance().AreaExclude, path);
//            GameDebug.LogWarning("NavMesh.CalculatePath src: " + playerPos);
//            GameDebug.LogWarning("NavMesh.CalculatePath dst: " + dst);
//            GameDebug.LogWarning("NavMesh.CalculatePath status: " + path.status);
//            string str = "NavMesh.CalculatePath corners:";
//            for (int i = 0; i < path.corners.Length; ++i)
//            {
//                str += " " + path.corners[i];
//            }
//            GameDebug.LogWarning(str);
            if (path.status == XNavMeshPathStatus.PathComplete)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 获取自动战斗下一目标位置
    /// </summary>
    /// <returns>The auto runner target location.</returns>
    public static Vector3 GetAutoRunnerTargetLocation()
    {
        // 野外地图和洞穴
        uint instanceType = InstanceManager.GetInstance().InstanceType;
        if (instanceType == GameConst.WAR_TYPE_WILD)
        {
            xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
            CommonLuaInstanceState wildInstanceState = curState as CommonLuaInstanceState;
        }

        // 目标首先是最近的中立NPC和宝箱
        NpcPlayer closestNpc = NpcManager.Instance.GetClosestNpc(Neptune.Relationship.NEUTRAL);
        if (closestNpc != null && CanWalkTo(closestNpc.transform.position))
        {
            return closestNpc.transform.position;
        }

        // 当前已经生成的boss
        Dictionary<UnitID, Actor> monsterList = ActorManager.Instance.MonsterSet;
        if (monsterList != null && monsterList.Count > 0)
        {
            Actor targetMonster = null;
            foreach (Actor actor in monsterList.Values)
            {
                Monster monster = actor as Monster;

                if(monster is Pet)
                {
                    continue;
                }

                if (actor.IsDead() == false && monster != null)
                {
                    // 目标首先是boss
                    if (monster.IsBoss() == true)
                    {
                        targetMonster = monster;
                        break;
                    }
                }
            }

            if (targetMonster != null && CanWalkTo(targetMonster.transform.position))
                return targetMonster.transform.position;
        }

        // 还没生成的boss
        //List<MonsterGroupInfo> monsterGroupInfos = MonsterInfoManager.GetInstance().MonsterGroupInfos;
        //if (monsterGroupInfos != null && monsterGroupInfos.Count > 0)
        //{
        //    foreach (MonsterGroupInfo monsterGroupInfo in monsterGroupInfos)
        //    {
        //        if (monsterGroupInfo != null && monsterGroupInfo.HasSpawned == false && monsterGroupInfo.SpawnDirectly == true)
        //        {
        //            MonsterInfo targetMonster = null;
        //            foreach (MonsterInfo monster in monsterGroupInfo.Monsters)
        //            {
        //                DBFixedMonster dbFixedMonster = DBManager.GetInstance().GetDB<DBFixedMonster>();
        //                DBFixedMonster.FixedMonsterInfo fixedMonsterInfo = dbFixedMonster.GetFixedMonsterInfo((uint)monster.ActorId);
        //                if (fixedMonsterInfo != null)
        //                {
        //                    if (fixedMonsterInfo.mIsBoss == true)
        //                    {
        //                        targetMonster = monster;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    GameDebug.LogError("GetAutoRunnerTargetLocation error, can not find actor id " + monster.ActorId);
        //                }
        //            }
                    
        //            if (targetMonster != null && CanWalkTo(targetMonster.Position))
        //                return targetMonster.Position;
        //        }
        //    }
        //}

        // 已经生成的怪物
        if (monsterList != null && monsterList.Count > 0)
        {
            Actor targetMonster = null;
            int index = 0;
            foreach (Actor actor in monsterList.Values)
            {
                Monster monster = actor as Monster;


                if (monster is Pet)
                {
                    continue;
                }

                if (monster.IsDead())
                {
                    continue;
                }

                if (monster != null && monster.BeSummonedType == Monster.BeSummonType.NULL)
                {
                    // 目标有可能是第一个怪物
                    if (index == 0)
                    {
                        targetMonster = monster;
                    }
                }
                
                ++index;
            }
            
            if (targetMonster != null && CanWalkTo(targetMonster.transform.position))
                return targetMonster.transform.position;
        }

        // 触发器
        //Dictionary<int, TriggerCollider> triggers = TriggerManager.Instance.Triggers;
        //if (triggers != null && triggers.Count > 0)
        //{
        //    foreach (TriggerCollider trigger in triggers.Values)
        //    {
        //        if (trigger.TriggerInfo.NeedNavigation == true)
        //        {
        //            bool hasEvent = false;
        //            //foreach (var eventId in trigger.TriggerInfo.EventsId)
        //            //{
        //            //    Destiny.DestinyNode node = Destiny.DestinyManager.Instance.GetRootNode(eventId);
        //            //    if (node != null)
        //            //    {
        //            //        Destiny.DestinyEventNode eventNode = node as Destiny.DestinyEventNode;

        //            //        if(eventNode != null && eventNode.Active)
        //            //        {
        //            //            hasEvent = true;
        //            //        }

        //            //        break;
        //            //    }
        //            //}

        //            if(hasEvent && CanWalkTo(trigger.transform.position))
        //            {
        //                return trigger.transform.position;
        //            }
        //        }

        //        if (trigger.TriggerInfo.Info == TriggerInfo.InfoType.PORTAL && trigger.TriggerInfo.NeedNavigation && CanWalkTo(trigger.transform.position))
        //        {
        //            return trigger.transform.position;
        //        }
        //    }
        //}

        // 还没生成的怪物
        //if (monsterGroupInfos != null && monsterGroupInfos.Count > 0)
        //{
        //    foreach (MonsterGroupInfo monsterGroupInfo in monsterGroupInfos)
        //    {
        //        if (monsterGroupInfo != null && monsterGroupInfo.HasSpawned == false && monsterGroupInfo.SpawnDirectly == true && CanWalkTo(monsterGroupInfo.Position))
        //            return monsterGroupInfo.Position;
        //    }
        //}

        // 传送点
        //        Dictionary<int, TriggerInfo> triggers = TriggerInfoManager.GetInstance().mTriggers;
        //        if (triggers != null && triggers.Count > 0)
        //        {
        //            foreach (TriggerInfo trigger in triggers.Values)
        //            {
        //                if (trigger.Info == TriggerInfo.InfoType.PORTAL)
        //                {
        //                    // 目标是第一个传送点
        //                    return trigger.Position;
        //                }
        //                if (trigger.NeedNavigation == true)
        //                {
        //
        //                }
        //            }
        //        }

        return Vector3.zero;
    }

    public static bool InstanceIsInPlay()
    {
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        //PlayingInstanceState playingState = curState as PlayingInstanceState;
        //if (playingState != null)
        //{
        //    return playingState.IsInPlay();
        //}

        return true;
    }

    public static bool InstanceIsInCave()
    {
        //xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        //PlayingInstanceState playingState = curState as PlayingInstanceState;
        //if (playingState != null)
        //{
        //    return playingState.IsInCave();
        //}
        
        return false;
    }

    public static void ExitInstance()
    {
        System.Action sendJumpFunc = SendExitInstance;
        object[] param = { sendJumpFunc };
        LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "InstanceHelper_ExitInstance", param);
        
    }

    private static void SendExitInstance()
    {
        C2SDungeonExit msg = new C2SDungeonExit();
        Net.NetClient.GetBaseClient().SendData<C2SDungeonExit>(NetMsg.MSG_DUNGEON_EXIT, msg);
    }

    /// <summary>
    /// 完成副本
    /// </summary>
    public static void CompleteInstance()
    {
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        if (curState is CommonInstanceState)
        {
            var commstate = curState as CommonInstanceState;
            commstate.CompleteInstance();
        }
    }

    /// <summary>
    /// 暂停副本
    /// </summary>
    public static void PauseInstance()
    {
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        if (curState is CommonInstanceState)
        {
            var commstate = curState as CommonInstanceState;
            commstate.PauseInstance();
        }
    }

    /// <summary>
    /// 恢复副本
    /// </summary>
    public static void ResumeInstance()
    {
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        if (curState is CommonInstanceState)
        {
            var commstate = curState as CommonInstanceState;
            commstate.ResumeInstance();
        }
    }

    /// <summary>
    /// 当前是否在指定的副本状态
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public static bool InstanceIsInState(uint state)
    {
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        if (curState is CommonInstanceState)
        {
            var commstate = curState as CommonInstanceState;
            return commstate.IsInState(state);
        }

        return false;
    }

    /// <summary>
    /// 在已经生成的怪物中，根据角色id获取Actor
    /// </summary>
    /// <returns>The monsters.</returns>
    /// <param name="actorId">Actor identifier.</param>
    public static List<Actor> GetMonsters(uint actorId)
    {
        List<Actor> actorList = new List<Actor>();
        actorList.Clear();
        foreach (Actor actor in ActorManager.Instance.MonsterSet.Values)
        {
            Monster monster = actor as Monster;
            if (actor.IsDead() == false && monster != null)
            {
                if (monster.TypeIdx == actorId)
                {
                    actorList.Add(actor);
                }
            }
        }
        
        return actorList;
    }

    /// <summary>
    /// 得到玩家进入副本需要的等级
    /// </summary>
    /// <param name="instanceId"></param>
    /// <returns></returns>
    public static uint GetInstanceNeedRoleLevel(uint instanceId)
    {
        DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
        uint needLv = 0;
        if (instanceInfo != null)
        {
            needLv = instanceInfo.mNeedLv;
        }

        return needLv;
    }

    /// <summary>
    /// 获取副本名字
    /// </summary>
    public static string GetInstanceName(uint instanceId)
    {
        DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
        if (instanceInfo != null)
        {
            return instanceInfo.mName;
        }

        return string.Empty;
    }

    public static bool IsNeedShowRuneTips(uint id)
    {
        var data_secret_area = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_secret_area", "id", id.ToString());
        if (data_secret_area.Count == 0)
            return false;
        var table = data_secret_area[0];
        var slot = table["soul_slot"];
        var gid = table["soul_gid"];
        if (gid == "0" && slot == "0")
            return false;
        else
            return true;

    }

    /// <summary>
    /// 检查是否满足进入副本所推荐的属性
    /// </summary>
    public static bool CheckInstanceEnterAttrs(DBInstance.InstanceInfo instanceInfo)
    {
        if (instanceInfo != null)
        {
            Dictionary<uint, uint> recommendAttrs = instanceInfo.mRecommendAttrs;
            if (recommendAttrs != null)
            {
                foreach (KeyValuePair<uint, uint> recommendAttr in recommendAttrs)
                {
                    long curValue = LocalPlayerManager.Instance.LocalActorAttribute.Attribute[recommendAttr.Key].Value;
                    if (curValue < recommendAttr.Value)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    /// <summary>
    /// 是否是该副本的被守护的npc
    /// </summary>
    public static bool IsGuardedNpc(uint actorId, uint instanceId)
    {
        if (actorId == 0)
            return false;

        var info = DBInstance.Instance.GetInstanceInfo(instanceId);
        if (null == info)
            return false;

        return actorId == info.mGuardedNpcId;
    }

    /// <summary>
    /// 是否是当前副本的守护Npc
    /// </summary>
    public static bool IsGuardedNpc(uint actorId)
    {
        return IsGuardedNpc(actorId, SceneHelp.Instance.CurSceneID);
    }

    /// <summary>
    /// 是否正在播放切换场景动作
    /// </summary>
    public static bool IsJumpingOut()
    {
        object[] param = {  };
        System.Type[] returnType = { typeof(bool) };
        object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "InstanceHelper_IsJumpingOut", param, returnType);
        if (objs != null && objs.Length > 0 && objs[0] != null)
        {
            return (bool)objs[0];
        }
        return false;
    }

    /// <summary>
    /// 指定uuid的角色是否显示归属
    /// </summary>
    /// <param name="uuid"></param>
    /// <returns></returns>
    public static bool IsAffiliation(uint uuid, uint teamId)
    {
        xc.Machine.State curState = Game.GetInstance().GetFSM().GetCurState();
        CommonLuaInstanceState wildInstanceState = curState as CommonLuaInstanceState;
        if (wildInstanceState != null && wildInstanceState.DataBossBehaviour != null)
        {
            return wildInstanceState.DataBossBehaviour.IsAffiliation(uuid, teamId);
        }

        return false;
    }
}
