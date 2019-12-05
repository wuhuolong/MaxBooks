//------------------------------------------------------------------------------
// Desc   :  任务帮助类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using xc.ui.ugui;
using Net;
using xc.protocol;

namespace xc
{
    [wxb.Hotfix]
    public class TaskHelper
    {
        static SafeCoroutine.Coroutine mTaskGuideCoroutine = null;
        public static uint TaskIdInGuideCoroutine = 0;    // 正在任务导航协程里面的任务id

        /// <summary>
        /// 自动主线任务开关，用于gm指令
        /// </summary>
        public static bool IsAutoMainTask = true;

        /// <summary>
        /// 任务目标是否和搜寻NPC相关
        /// </summary>
        public static bool StepGoalIsRelateSearchNpc(string goal)
        {
            if (goal == GameConst.GOAL_TALK)
            {
                return true;
            }

            return false;
        }

        static Dictionary<string, string> GetRelatedTrigramInfoImpl(List<Dictionary<string, string>> trigramInfos, uint taskId, uint instanceId)
        {
            foreach (Dictionary<string, string> trigramInfo in trigramInfos)
            {
                string unlockStr = trigramInfo["unlock"];
                if (string.IsNullOrEmpty(unlockStr) == false)
                {
                    List<string> unlock = DBTextResource.ParseArrayString(unlockStr);
                    if (unlock[0] == "quest_fin")
                    {
                        if (DBTextResource.ParseUI_s(unlock[1], 0) == taskId)
                        {
                            return trigramInfo;
                        }
                    }
                    else if(unlock[0] == "war_win")
                    {
                        if (DBTextResource.ParseUI_s(unlock[1], 0) == instanceId && instanceId != 0)
                        {
                            return trigramInfo;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 获取八卦牌的名字
        /// </summary>
        /// <param name="trigramId"></param>
        /// <returns></returns>
        public static string GetTrigramName(uint trigramId)
        {
            List<string> names = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_trigram", "id", trigramId, "name");
            if (names.Count > 0)
            {
                return names[0];
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取八卦牌的章节id
        /// </summary>
        /// <param name="trigramId"></param>
        /// <returns></returns>
        public static uint GetTrigramChapterId(uint trigramId)
        {
            List<int> chapterIds = DBManager.Instance.QuerySqliteField<int>(GlobalConfig.DBFile, "data_trigram", "id", trigramId, "chapter");
            if (chapterIds.Count > 0)
            {
                return (uint)chapterIds[0];
            }

            return 0;
        }

        /// <summary>
        /// 获取八卦牌的职业
        /// </summary>
        /// <param name="trigramId"></param>
        /// <returns></returns>
        public static uint GetTrigramRace(uint trigramId)
        {
            List<string> races = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_trigram", "id", trigramId, "race");
            if (races.Count > 0)
            {
                uint race = 0;
                uint.TryParse(races[0], out race);
                return race;
            }

            return 0;
        }

        /// <summary>
        /// 获取该任务相关的八卦牌信息
        /// </summary>
        static Dictionary<string, string> GetRelatedTrigramInfo(uint taskId)
        {
            uint instanceId = 0;
            Task task = TaskManager.Instance.GetTask(taskId);
            if (task != null)
            {
                instanceId = task.CurrentStep.InstanceId2;
            }

            uint race = Game.Instance.LocalPlayerVocation;

            // 人族篇
            string queryStr = string.Format("SELECT * FROM {0} WHERE ({0}.{1}=\"0\" or {0}.{1}=\"{2}\") and {0}.{3}=\"{4}\"", "data_trigram", "race", race, "chapter", 1);
            List<Dictionary<string, string>> trigramInfos = DBManager.Instance.QuerySqliteRow(GlobalConfig.DBFile, "data_trigram", queryStr);
            Dictionary<string, string> trigramInfo = GetRelatedTrigramInfoImpl(trigramInfos, taskId, instanceId);
            if (trigramInfo != null && trigramInfo.Count > 0)
            {
                return trigramInfo;
            }

            // 矮人篇
            queryStr = string.Format("SELECT * FROM {0} WHERE ({0}.{1}=\"0\" or {0}.{1}=\"{2}\") and {0}.{3}=\"{4}\"", "data_trigram", "race", race, "chapter", 2);
            trigramInfos = DBManager.Instance.QuerySqliteRow(GlobalConfig.DBFile, "data_trigram", queryStr);
            return GetRelatedTrigramInfoImpl(trigramInfos, taskId, instanceId);
        }

        static void OpenTaskInstanceWindow(Task task)
        {
            // 如果配置了系统id，则跳转到对应的系统
            if (task.CurrentStep.SysId > 0)
            {
                RouterManager.Instance.GenericGoToSysWindow(task.CurrentStep.SysId);
                return;
            }

            DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(task.CurrentStep.InstanceId2);
            if (instanceInfo != null && SceneHelp.CheckCanSwitch(instanceInfo.mWarType, instanceInfo.mWarSubType, true) == true)
            {
                if (instanceInfo.mWarType == GameConst.WAR_TYPE_DUNGEON)
                {
                    if (instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_SECRET_AREA)
                    {
                        UIManager.Instance.ShowSysWindow("UIKungfuGodWindow");
                    }
                    else if (instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_DEAD_SPACE)
                    {
                        UIManager.GetInstance().ShowSysWindow("UIDeadSpaceEnterWindow");
                    }
                    else if (instanceInfo.mWarSubType == GameConst.WAR_SUBTYPE_FAIRY_VALLEY)
                    {
                        UIManager.GetInstance().ShowSysWindow("UIFairyValleyEnterWindow");
                    }
                    else
                    {
                        Dictionary<string, string> trigramInfo = GetRelatedTrigramInfo(task.Define.Id);
                        if (trigramInfo != null)
                        {
                            UIManager.Instance.ShowSysWindow("UITrigramMainWindow", DBTextResource.ParseUI_s(trigramInfo["chapter"], 0), DBTextResource.ParseUI_s(trigramInfo["id"], 0));
                        }
                        else
                        {
                            // 野外才能打开副本进入界面
                            if (SceneHelp.Instance.IsInWildInstance() == true)
                            {
                                // 赏金任务的副本会自动进入
                                bool autoEnter = false;
                                if (task.Define.Type == GameConst.QUEST_SG)
                                {
                                    autoEnter = true;
                                }
                                // 满足VIP条件的帮派任务的副本会自动进入
                                else if (task.Define.Type == GameConst.QUEST_GUILD)
                                {
                                    if (VipHelper.GetIsAutoRunGuildTask() == true)
                                    {
                                        autoEnter = true;
                                    }
                                }
                                UIManager.GetInstance().ShowSysWindow("UIInstanceEnterWindow", instanceInfo, autoEnter, task);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行对话任务
        /// </summary>
        static void DoTalkTask(Task task, NpcPlayer npcPlayer)
        {
            string goal = task.CurrentGoal;
            uint dialogId = task.CurrentStep.DialogId;
            if (dialogId > 0)
            {
                uint actorId = 0;
                if (npcPlayer != null)
                {
                    actorId = npcPlayer.ActorId;
                }
                DialogManager.Instance.TriggerDialog(dialogId, "", npcPlayer, actorId, () => { TaskNet.Instance.DoTaskGoal(goal, (int)dialogId); }, null, task);
            }
            else
            {
                TaskNet.Instance.DoTaskGoal(goal, (int)dialogId);
            }
        }

        /// <summary>
        /// 首先待护送的npc跑到提交的npc的位置再提交任务
        /// </summary>
        /// <param name="task"></param>
        static void SubmitTask(Task task, NpcPlayer npcPlayer)
        {
            NpcPlayer followNpcPlayer = null;
            if (task.Define.FollowNpcs != null)
            {
                foreach (NpcScenePosition npcScenePosition in task.Define.FollowNpcs)
                {
                    if (npcScenePosition.SceneId == SceneHelp.Instance.CurSceneID)
                    {
                        followNpcPlayer = NpcManager.Instance.GetNpcByNpcId(npcScenePosition.NpcId);
                        break;
                    }
                }
            }

            uint npcActorId = 0;
            if (npcPlayer != null)
            {
                npcActorId = npcPlayer.ActorId;
            }

            if (followNpcPlayer != null && task.Define.SubmitNpc.SceneId != 0 && task.Define.SubmitNpc.NpcId != 0)
            {
                // 护送的NPC不用再跑到交任务的NPC那里了
                //Neptune.NPC npcInfo = Neptune.DataManager.Instance.Data.GetNode<Neptune.NPC>((int)task.Define.SubmitNpc.NpcId);
                //if (npcInfo != null)
                {
                    if (task.Define.SubmitDialogId > 0)
                    {
                        InstanceManager.Instance.IsAutoFighting = false;

                        DialogManager.Instance.TriggerDialog(task.Define.SubmitDialogId, "", npcPlayer, npcActorId, () =>
                        {
                            //followNpcPlayer.MoveCtrl.TryWalkToAlong(InstanceHelper.ClampInWalkableRange(npcInfo.Position), () =>
                            //{
                            //    TaskNet.Instance.SubmitTask(task.Define.Id);
                            //});
                            TaskNet.Instance.SubmitTask(task.Define.Id);
                        }, null, task);
                    }
                    else
                    {
                        //followNpcPlayer.MoveCtrl.TryWalkToAlong(InstanceHelper.ClampInWalkableRange(npcInfo.Position), () =>
                        //{
                        //    TaskNet.Instance.SubmitTask(task.Define.Id);
                        //});
                        TaskNet.Instance.SubmitTask(task.Define.Id);
                    }
                    return;
                }
            }

            if (task.Define.SubmitDialogId > 0)
            {
                InstanceManager.Instance.IsAutoFighting = false;

                DialogManager.Instance.TriggerDialog(task.Define.SubmitDialogId, "", npcPlayer, npcActorId, () =>
                {
                    TaskNet.Instance.SubmitTask(task.Define.Id);
                }, null, task);
            }
            else
            {
                TaskNet.Instance.SubmitTask(task.Define.Id);
            }
        }

        static IEnumerator TaskGuideDelayCoroutine(Task task)
        {
            yield return new SafeCoroutine.SafeWaitForSeconds(0.1f);

            TaskGuide(task);
        }

        /// <summary>
        /// 攻击是否结束，不包括后摇
        /// </summary>
        /// <returns></returns>
        static bool AttackActionIsEnded()
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer != null)
            {
                return !localPlayer.IsAttacking() || localPlayer.IsInSkillActionEndingStage();
            }

            return false;
        }

        /// <summary>
        /// 护送NPC是否已经创建完毕
        /// </summary>
        /// <returns></returns>
        static bool EscortNPCHaveCreated()
        {
            LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;
            if (localPlayer != null)
            {
                Actor escortNPC = localPlayer.GetEscortNPC();
                if (escortNPC != null && escortNPC.IsResLoaded == true)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 护送NPC是否不在播放Enter动画
        /// </summary>
        /// <returns></returns>
        static bool EscortNPCIsNotPlayingEnterAni()
        {
            LocalPlayer localPlayer = Game.GetInstance().GetLocalPlayer() as LocalPlayer;
            if (localPlayer != null)
            {
                Actor escortNPC = localPlayer.GetEscortNPC();
                if (escortNPC != null)
                {
                    return !escortNPC.IsPlaying("enter");
                }
            }

            return false;
        }

        public static IEnumerator TaskGuideCoroutine(Task task, bool needRecoverAutoFight)
        {
            yield return new SafeCoroutine.WaitForCondition(AttackActionIsEnded);

            // 是否需要恢复自动战斗
            if (needRecoverAutoFight == true)
            {
                InstanceManager.Instance.IsAutoFighting = true;
            }

            // 是否在系统开放中
            if (SysConfigManager.Instance.IsWaiting() == true)
            {
                GameDebug.LogWarning("TaskHelper.TaskGuideCoroutine SysConfigManager is waiting!!");
                yield break;
            }

            // 记录当弹出退出提示的时候是否要继续自动战斗
            if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
            {
                SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
            }

            //GameDebug.LogError("TaskHelper.TaskGuideCoroutine: " + task.Define.Id);

            if (task.State == GameConst.QUEST_STATE_ACCEPT || task.State == GameConst.QUEST_STATE_DONE || task.State == GameConst.QUEST_STATE_FAIL)
            {
                TaskUnProcessingGuide(task);
                yield break;
            }

            string goal = task.CurrentGoal;
            var currentStep = task.CurrentStep;
            var currentStepProgress = task.CurrentStepProgress;

            if (currentStep == null || string.IsNullOrEmpty(goal))
            {
                GameDebug.LogError("Task guide error, current step or goal is null!!!");
                yield break;
            }

            bool isNavigating = true;

            bool isNavigatingTag = false;
            if (currentStep.NavigationInstanceId != 0 && currentStep.NavigationTagId != 0)
            {
                // 默认可到达
                bool canReach = true;

                // 同一个场景内，tag点在不可到达区域，则不找这个tag点
                if (currentStep.NavigationInstanceId == SceneHelp.Instance.CurSceneID)
                {
                    Neptune.Tag tagInfo = Neptune.DataManager.Instance.Data.GetNode<Neptune.Tag>((int)currentStep.NavigationTagId);
                    canReach = InstanceHelper.CanWalkTo(tagInfo.Position);
                }

                if (canReach == true)
                {
                    if (SceneHelp.CheckCanSwitch(currentStep.NavigationInstanceId, true) == true)
                    {
                        TaskManager.Instance.NavigatingTask = task;
                        InstanceManager.Instance.IsAutoFighting = false;
                        TargetPathManager.Instance.ClearAllTargetPathNodes();

                        if (goal == GameConst.GOAL_TALK)
                        {
                            TargetPathManager.Instance.GoToTagPos(currentStep.NavigationInstanceId, currentStep.NavigationTagId, task, () =>
                                                {
                                                                    // 树配说以前做的护送npc逻辑先注释掉
                                                                    //NpcPlayer npcPlayer = task.Define.GetFollowNpcPlayer();
                                                                    //Neptune.Tag tagInfo = Neptune.DataManager.Instance.Data.GetNode<Neptune.Tag>((int)currentStep.NavigationTagId);
                                                                    //if (npcPlayer != null && tagInfo != null)
                                                                    //{
                                                                    //    npcPlayer.ActiveAI(false);
                                                                    //    // 护送的NPC先跑到寻路终点才做对话任务
                                                                    //    npcPlayer.MoveCtrl.TryWalkToAlong(InstanceHelper.ClampInWalkableRange(tagInfo.Position), () =>
                                                                    //    {
                                                                    //        DoTalkTask(task, task.Define.GetSubmitNpcPlayer());
                                                                    //    });
                                                                    //}
                                                                    //else
                                                                    //{
                                                                    //    DoTalkTask(task, task.Define.GetSubmitNpcPlayer());
                                                                    //}
                                                                });
                            isNavigatingTag = true;
                        }
                        else
                        {
                            TargetPathManager.Instance.GoToTagPos(currentStep.NavigationInstanceId, currentStep.NavigationTagId, task);
                            isNavigatingTag = true;
                        }
                    }
                }
            }

            if (isNavigatingTag == false)
            {
                switch (goal)
                {
                    case GameConst.GOAL_AUTO:
                        break;
                    case GameConst.GOAL_TALK:
                        {
                            if (SceneHelp.CheckCanSwitch(currentStep.InstanceId, true) == true)
                            {
                                TaskManager.Instance.NavigatingTask = task;
                                InstanceManager.Instance.IsAutoFighting = false;
                                TargetPathManager.Instance.ClearAllTargetPathNodes();

                                TargetPathManager.Instance.GoToNpcPos(currentStep.InstanceId, currentStep.NpcId, task);
                            }
                        }
                        break;
                    case GameConst.GOAL_KILL_MON:
                        {
                            if (SceneHelp.CheckCanSwitch(currentStep.InstanceId, true) == true)
                            {
                                TaskManager.Instance.NavigatingTask = task;
                                InstanceManager.Instance.IsAutoFighting = false;
                                TargetPathManager.Instance.ClearAllTargetPathNodes();

                                TargetPathManager.Instance.GoToMonsterPos(currentStep.InstanceId, 0, currentStep.MonsterId, task);
                            }
                        }
                        break;
                    case GameConst.GOAL_KILL_GROUP_MON:
                        {
                            if (SceneHelp.CheckCanSwitch(currentStep.InstanceId, true) == true)
                            {
                                TaskManager.Instance.NavigatingTask = task;
                                InstanceManager.Instance.IsAutoFighting = false;
                                TargetPathManager.Instance.ClearAllTargetPathNodes();

                                //TargetPathManager.Instance.GoToMonsterPos(currentStep.InstanceId, 0, currentStep.MonsterId, task);
                                Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(currentStep.InstanceId));
                                if (levelData != null)
                                {
                                    Vector3 pos = xc.Dungeon.LevelObjectHelper.GetMonsterPosition(currentStep.MonsterId, levelData);
                                    TargetPathManager.Instance.GoToConstPosition(currentStep.InstanceId, SceneHelp.Instance.CurLine, pos, task);
                                }
                            }
                        }
                        break;
                    case GameConst.GOAL_INTERACT:
                        {
                            Neptune.NPC npc = null;
                            if (currentStep.InstanceId == SceneHelp.Instance.CurSceneID)
                            {
                                Neptune.Data levelData = Neptune.DataManager.Instance.Data;
                                Dictionary<int, Neptune.BaseGenericNode> npcs = levelData.GetData<Neptune.NPC>().Data;
                                // 这里的npc id是指excel里面的id
                                foreach (Neptune.NPC tempNpc in npcs.Values)
                                {
                                    if (tempNpc.ExcelId == currentStep.NpcId)
                                    {
                                        npc = tempNpc;
                                    }
                                }
                            }
                            else
                            {
                                Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(currentStep.InstanceId));
                                Dictionary<int, Neptune.BaseGenericNode> npcs = levelData.GetData<Neptune.NPC>().Data;
                                // 这里的npc id是指excel里面的id
                                foreach (Neptune.NPC tempNpc in npcs.Values)
                                {
                                    if (tempNpc.ExcelId == currentStep.NpcId)
                                    {
                                        npc = tempNpc;
                                    }
                                }
                            }
                            if (npc != null)
                            {
                                if (SceneHelp.CheckCanSwitch(currentStep.InstanceId, true) == true)
                                {
                                    TaskManager.Instance.NavigatingTask = task;
                                    InstanceManager.Instance.IsAutoFighting = false;
                                    TargetPathManager.Instance.ClearAllTargetPathNodes();

                                    TargetPathManager.Instance.GoToNpcPos(currentStep.InstanceId, (uint)npc.Id, task, npc.ExcelId);
                                }
                            }
                            else
                            {
                                GameDebug.LogWarning("Can not find npc(excel id) " + currentStep.NpcId + " in instance  " + currentStep.InstanceId);
                            }
                        }
                        break;
                    case GameConst.GOAL_KILL_COLLECT:
                        {
                            if (SceneHelp.CheckCanSwitch(currentStep.InstanceId, true) == true)
                            {
                                TaskManager.Instance.NavigatingTask = task;
                                InstanceManager.Instance.IsAutoFighting = false;
                                TargetPathManager.Instance.ClearAllTargetPathNodes();

                                TargetPathManager.Instance.GoToMonsterPos(currentStep.InstanceId, 0, currentStep.MonsterId, task);
                            }
                        }
                        break;
                    case GameConst.GOAL_COLLECT_GOODS:
                        {
                            // 是否要打开世界Boss界面
                            if (currentStep.MinWorldBossSpecialMonId > 0 && currentStep.MaxWorldBossSpecialMonId > 0)
                            {
                                DBSpecialMon dbSpecialMon = DBManager.Instance.GetDB<DBSpecialMon>();
                                uint minLevel = dbSpecialMon.GetSpecialMonLevel(currentStep.MinWorldBossSpecialMonId);
                                uint maxLevel = dbSpecialMon.GetSpecialMonLevel(currentStep.MaxWorldBossSpecialMonId);
                                uint localPlayerLevel = LocalPlayerManager.Instance.Level;
                                if (localPlayerLevel < minLevel)    // 等级过低，选中最低的那个BOSS
                                {
                                    RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS, currentStep.MinWorldBossSpecialMonId);
                                }
                                else if (localPlayerLevel > maxLevel)   // 等级过高，选中等级最高的那个BOSS
                                {
                                    RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS, currentStep.MaxWorldBossSpecialMonId);
                                }
                                else
                                {
                                    RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS);
                                }
                            }
                            else
                            {
                                var hangInfo = DBHang.Instance.GetSuitableHangInfo();
                                if (hangInfo != null)
                                {
                                    if (SceneHelp.CheckCanSwitch(hangInfo.Dungeon, true) == true)
                                    {
                                        TaskManager.Instance.NavigatingTask = task;
                                        InstanceManager.Instance.IsAutoFighting = false;
                                        TargetPathManager.Instance.ClearAllTargetPathNodes();

                                        TargetPathManager.Instance.GoToTagPos(hangInfo.Dungeon, hangInfo.GetRandomTag().Id, task, () =>
                                        {
                                            InstanceManager.Instance.IsAutoFighting = true;
                                        });
                                    }
                                }
                            }
                        }
                        break;
                    case GameConst.GOAL_WAR_WIN:
                    case GameConst.GOAL_WAR_ENTER:
                    case GameConst.GOAL_WAR_GRADE:
                        {
                            if (currentStep.NpcId == 0)
                            {
                                OpenTaskInstanceWindow(task);
                                //UIManager.GetInstance().ShowSysWindow("UIInstanceEnterWindow", DBInstance.Instance.GetInstanceInfo(currentStep.InstanceId2));
                            }
                            else
                            {
                                if (SceneHelp.CheckCanSwitch(currentStep.InstanceId, true) == true)
                                {
                                    TaskManager.Instance.NavigatingTask = task;
                                    InstanceManager.Instance.IsAutoFighting = false;
                                    TargetPathManager.Instance.ClearAllTargetPathNodes();

                                    TargetPathManager.Instance.GoToNpcPos(currentStep.InstanceId, currentStep.NpcId, task);
                                }
                            }
                        }
                        break;
                    case GameConst.GOAL_EQUIP_SUBMIT:
                        {
                            UIManager.GetInstance().CloseSysWindow("UITaskWindow");
                            Dictionary<ulong, Goods> equips = xc.Equip.EquipHelper.GetBagEquipsOidsByColorAndLvStep(currentStep.EquipColor, currentStep.EquipLvStep);
                            UIManager.GetInstance().ShowWindow("UITaskSubmitEquipWindow", equips, task);
                        }
                        break;
                    case GameConst.GOAL_SECRET_AREA:
                        {
                            RouterManager.Instance.GotoSoulTownWnd();
                        }
                        break;
                    case GameConst.GOAL_TRIGRAM:
                        {
                            //isNavigating = false;

                            //uint chapterId = TaskHelper.GetTrigramChapterId(currentStep.TrigramId);
                            //RouterManager.Instance.GoToTrigram(chapterId, currentStep.TrigramId);
                        }
                        break;
                    case GameConst.GOAL_EQUIP_WEAR:
                        {
                            if (SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_BAG, true))
                            {
                                UIManager.Instance.ShowSysWindow("UIBagWindow");
                            }
                        }
                        break;
                    case GameConst.GOAL_EQUIP_STRENGTH:
                        {
                            RouterManager.Instance.GoToEquipStrength();
                        }
                        break;
                    case GameConst.GOAL_EQUIP_GEM:
                        {
                            RouterManager.Instance.GoToEquipGem();
                        }
                        break;
                    case GameConst.GOAL_PET_LV:
                        {
                            RouterManager.Instance.GotoPetWnd();
                        }
                        break;
                    case GameConst.GOAL_GROW_LV:
                        {
                            // 坐骑
                            if (currentStep.GrowType == 1)
                            {
                                RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_RIDE);
                            }
                        }
                        break;
                    case GameConst.GOAL_STAR_LV:
                    case GameConst.GOAL_EXP_JADE:
                        {
                            RouterManager.Instance.GoToBagWnd();
                        }
                        break;
                    case GameConst.GOAL_LIVENESS:
                        {
                            RouterManager.Instance.GotoPlayIngWnd();
                        }
                        break;
                    case GameConst.GOAL_GOODS_COMPOSE:
                        {
                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_COMPOSE, currentStep.GoodsId);
                        }
                        break;
                    case GameConst.GOAL_AFFILIED_ANY_BOSS:
                        {
                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS);
                        }
                        break;
                    case GameConst.GOAL_STIGMA_LV:
                        {
                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_STIGMA, 0, currentStep.StigmaId);
                        }
                        break;
                    case GameConst.GOAL_DRAGON_SOUL:
                        {
                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS);
                        }
                        break;
                    case GameConst.GOAL_CONTRACT_INHERIT:
                        {
                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_CONTRACT_INHERIT);
                        }
                        break;
                    case GameConst.GOAL_EQUIP_STRENGTH_TLV:
                        {
                            RouterManager.Instance.GoToEquipStrength();
                        }
                        break;
                    case GameConst.GOAL_TRIAL_BOSS:
                        {
                            RouterManager.Instance.GotoTrialBoss(currentStep.InstanceLv);
                        }
                        break;
                    case GameConst.GOAL_KILL_BOSS:
                        {
                            switch ((ushort)currentStep.WarTag)
                            {
                                case GameConst.WAR_TAG_WORLD_BOSS:  //世界BOSS
                                    {
                                        RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS);
                                        break;
                                    }
                                case GameConst.WAR_TAG_GOLD_THIEF:  //盗宝怪
                                    {
                                        // 盗宝怪是在普通野外的，暂时没法判断
                                        break;
                                    }
                                case GameConst.WAR_TAG_BOSS_HOME:   //boss之家
                                    {
                                        RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_BOSS_HOME);
                                        break;
                                    }
                                case GameConst.WAR_TAG_SOUTH_LAND:  //南天圣地
                                    {
                                        RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_SOUTH_LAND);
                                        break;
                                    }
                                case GameConst.WAR_TAG_ELEMENT_AREA://元素禁地
                                    {
                                        RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_ELEMENT_AREA);
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                        break;
                    case GameConst.GOAL_LIGHT_EQUIP:
                        {
                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_LIGHT_EQUIP);
                        }
                        break;
                    default:
                        {
                            TaskHelper.GotoTaskByLua(task);
                        }
                        break;
                }
            }

            mTaskGuideCoroutine = null;
            TaskIdInGuideCoroutine = 0;
            SceneHelp.Instance.IsAutoFightingWhenShowExitTips = false;
        }

        public static bool TaskGuide(Task task)
        {
            // 主角不存在或者已经死亡不能任务导航
            Actor localPlayer = Game.Instance.GetLocalPlayer();
            if (localPlayer == null || localPlayer.IsDead() == true)
            {
                GameDebug.LogWarning("TaskHelper.TaskGuide, Local player is null!!");
                return false;
            }

            // 没有帮派则不能做帮派任务
            if (task != null && task.Define.Type == GameConst.QUEST_GUILD)
            {
                if (LocalPlayerManager.Instance.GuildID == 0)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("TASK_ENTER_GUILD_TO_DO_TASK"));

                    GameDebug.LogWarning(DBConstText.GetText("TASK_ENTER_GUILD_TO_DO_TASK"));
                    return false;
                }
            }

            // 是否在系统开放中
            if (SysConfigManager.Instance.IsWaiting() == true)
            {
                GameDebug.LogWarning("TaskHelper.TaskGuide SysConfigManager is waiting!!");
                return false;
            }

            // 是否在进入副本的准备中
            if (InstanceManager.Instance.PollInfo != null)
            {
                GameDebug.LogWarning("TaskHelper.TaskGuide is in enter instance polling!!");
                return false;
            }

            // 是否在显示外观展示界面
            if (UIManager.Instance.GetWindow("UIGetNewEquipFashionWindow") != null)
            {
                GameDebug.LogWarning("TaskHelper.TaskGuide is showing UIGetNewEquipFashionWindow!!");
                return false;
            }

            if (task == null)
            {
                GameDebug.LogError("Task guide error!!! Task is null!!!");
                return false;
            }

            if (task.State == GameConst.QUEST_STATE_UNACCEPT)
            {
                // 不可接取状态总是飘字“等级不足”，后续再优化
                UINotice.Instance.ShowMessage(DBConstText.GetText("LEVEL_NOT_ENOUGH"));

                GameDebug.LogWarning("Task can not guide, state is + " + task.State);
                return false;
            }
            if (task.State == GameConst.QUEST_STATE_FIN)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("TASK_TIPS_FINISHED"));

                GameDebug.LogWarning("Task can not guide, state is + " + task.State);
                return false;
            }
            if (task.State == GameConst.QUEST_STATE_INVALID)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("TASK_TIPS_INVALID"));

                GameDebug.LogWarning("Task can not guide, state is + " + task.State);
                return false;
            }

            //if (TargetPathManager.Instance.RunningTargetPathNode != null && TargetPathManager.Instance.RunningTargetPathNode.RelateTask == task)
            //{
            //    GameDebug.LogWarning("Task can not guide, is already in guiding!!");
            //    return false;
            //}

            //GameDebug.LogError("TaskHelper.TaskGuide: " + task.Define.Id);

            // 任务指引，需要关闭自动战斗，否则下一步等待技能完成的步骤会等很久
            bool needRecoverAutoFight = false;
            if (InstanceManager.Instance.IsAutoFighting)
            {
                needRecoverAutoFight = true;
                InstanceManager.Instance.IsAutoFighting = false;
            }

            StopTaskGuideCoroutine();

            if (HookSettingManager.Instance.AutoPickDrop == true)
            {
                // 是否有掉落可以拾取
                if (InstanceDropManager.Instance.DropNum > 0 && ItemManager.Instance.BagIsFull(1) == false)
                {
                    DropComponent drop = InstanceDropManager.Instance.GetNearestDrop(GameConstHelper.GetFloat("GAME_AUTO_PICK_DROP_RANGE"));
                    if (drop != null)
                    {
                        TaskManager.Instance.NavigatingTask = task;

                        TargetPathManager.Instance.GoToConstPosition(SceneHelp.Instance.CurSceneID, SceneHelp.Instance.CurLine, drop.transform.position, null, () =>
                        {
                            SafeCoroutine.CoroutineManager.StartCoroutine(TaskGuideDelayCoroutine(task));
                        });
                        return true;
                    }
                }
            }

            TaskIdInGuideCoroutine = task.Define.Id;
            mTaskGuideCoroutine = SafeCoroutine.CoroutineManager.StartCoroutine(TaskGuideCoroutine(task, needRecoverAutoFight));

            return true;
        }

        public static bool TaskGuide(uint taskId)
        {
            Task task = TaskManager.Instance.GetTask(taskId);
            if (task != null)
            {
                return TaskGuide(task);
            }

            return false;
        }

        /// <summary>
        /// 停止任务导航协程
        /// </summary>
        public static void StopTaskGuideCoroutine()
        {
            if (mTaskGuideCoroutine != null)
            {
                mTaskGuideCoroutine.Stop();
                mTaskGuideCoroutine = null;
                TaskIdInGuideCoroutine = 0;
            }
        }

        /// <summary>
        /// 主线任务是否在任务导航协程里面
        /// </summary>
        public static bool MainTaskIsInGuideCoroutine
        {
            get
            {
                if (TaskIdInGuideCoroutine > 0 && TaskDefine.GetTaskType(TaskIdInGuideCoroutine) == GameConst.QUEST_MAIN)
                {
                    return true;
                }

                return false;
            }
        }

        public static ushort TaskTypeInGuideCoroutine
        {
            get
            {
                if (TaskIdInGuideCoroutine > 0)
                {
                    return TaskDefine.GetTaskType(TaskIdInGuideCoroutine);
                }
                return GameConst.QUEST_NONE;
            }
        }

        /// <summary>
        /// 非处理中的任务的导航
        /// </summary>
        static void TaskUnProcessingGuide(Task task)
        {
            if (task.Define == null)
            {
                return;
            }

            NpcScenePosition npcPos = new NpcScenePosition();

            if (task.State == GameConst.QUEST_STATE_ACCEPT || task.State == GameConst.QUEST_STATE_FAIL)
            {
                npcPos = task.Define.ReceiveNpc;

                if (npcPos.NpcId == 0 && npcPos.SceneId == 0)
                {
                    if (task.Define.ReceiveDialogId > 0)
                    {
                        InstanceManager.Instance.IsAutoFighting = false;
                        TargetPathManager.Instance.ClearAllTargetPathNodes();

                        DialogManager.Instance.TriggerDialog(task.Define.ReceiveDialogId, "", null, 0, () => { TaskNet.Instance.AcceptTask(task.Define.Id); }, null, null);
                    }
                    else
                    {
                        TaskNet.Instance.AcceptTask(task.Define.Id);
                    }
                    return;
                }
            }
            else if (task.State == GameConst.QUEST_STATE_DONE)
            {
                npcPos = task.Define.SubmitNpc;

                if (npcPos.NpcId == 0 && npcPos.SceneId == 0)
                {
                    SubmitTask(task, null);
                    return;
                }
            }

            if (SceneHelp.CheckCanSwitch(npcPos.SceneId, true) == true)
            {
                TaskManager.Instance.NavigatingTask = task;
                InstanceManager.Instance.IsAutoFighting = false;
                TargetPathManager.Instance.ClearAllTargetPathNodes();

                TargetPathManager.Instance.GoToNpcPos(npcPos.SceneId, npcPos.NpcId, task);
            }
        }

        /// <summary>
        /// 执行该NPC所关联的任务的导航
        /// </summary>
        public static void TaskNpcGuide(NpcPlayer npcPlayer)
        {
            List<Task> needDoTasks = new List<Task>();
            needDoTasks.Clear();
            List<Task> needAcceptAndSubmitTasks = new List<Task>();
            needAcceptAndSubmitTasks.Clear();

            GetNpcRelatedTasks(npcPlayer, out needDoTasks, out needAcceptAndSubmitTasks);

            if (needDoTasks.Count > 0)
            {
                if (needDoTasks[0].Define.Type == GameConst.QUEST_SG && TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true)
                {
                }
                else if (needDoTasks[0].Define.Type == GameConst.QUEST_GUILD && TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true)
                {

                }
                else
                {
                    if (needDoTasks[0].Define.AutoRunType != TaskDefine.EAutoRunType.None)
                    {
                        TaskGuide(needDoTasks[0]);
                    }
                }
            }
            else if (needAcceptAndSubmitTasks.Count > 0)
            {
                if (needAcceptAndSubmitTasks[0].Define.Type == GameConst.QUEST_SG && TaskManager.Instance.DoNotAutoRunBountyTaskNextTime == true)
                {
                }
                else if (needAcceptAndSubmitTasks[0].Define.Type == GameConst.QUEST_GUILD && TaskManager.Instance.DoNotAutoRunGuildTaskNextTime == true)
                {
                }
                else
                {
                    if (needAcceptAndSubmitTasks[0].Define.AutoRunType != TaskDefine.EAutoRunType.None)
                    {
                        TaskGuide(needAcceptAndSubmitTasks[0]);
                    }
                }
            }
            TaskManager.Instance.DoNotAutoRunBountyTaskNextTime = false;
            TaskManager.Instance.DoNotAutoRunGuildTaskNextTime = false;
        }

        /// <summary>
        /// 执行触碰交互任务NPC，有任务则返回true
        /// </summary>
        public static bool ProcessTouchInteractTasksNpc(NpcPlayer npcPlayer)
        {
            uint sceneId = SceneHelp.Instance.CurSceneID;

            List<Task> allTask = TaskManager.Instance.AllTasks;
            allTask.Sort();

            bool hasInteractTask = false;
            foreach (var taskItem in allTask)
            {
                for (int i = 0; i < taskItem.Define.Steps.Count; i++)
                {
                    var dbStep = taskItem.Define.Steps[i];

                    if (taskItem.State == GameConst.QUEST_STATE_DOING)
                    {
                        if (dbStep.Goal == GameConst.GOAL_INTERACT)
                        {
                            if ((dbStep.NpcId == npcPlayer.NpcData.ExcelId && dbStep.InstanceId == sceneId))
                            {
                                if (i == taskItem.CurrentStepIndex)
                                {
                                    hasInteractTask = true;

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (hasInteractTask == true)
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.INTERACT_TASK_NPC_TOUCHED, new CEventBaseArgs(npcPlayer));

                return true;
            }

            return false;
        }

        /// <summary>
        /// 执行触碰任务npc，有任务则返回true
        /// </summary>
        public static bool ProcessTouchTasksNpc(NpcPlayer npcPlayer)
        {
            // 导航过去的赏金任务
            if (TaskManager.Instance.IsNavigatingAcceptBountyTask == true && NpcHelper.NpcCanAcceptBountyTask((uint)npcPlayer.NpcData.Id) == true)
            {
                List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_SG_ACCEPT_NPC");
                if (accpetNpcParams.Count > 2)
                {
                    DialogManager.Instance.TriggerDialog(accpetNpcParams[2], "", npcPlayer, npcPlayer.ActorId, /*() => { TaskNet.Instance.AcceptBountyTask(); }*/null, null, null);
                    return true;
                }
            }

            // 导航获取的帮派任务
            if (TaskManager.Instance.IsNavigatingAcceptGuildTask == true && NpcHelper.NpcCanAcceptGuildTask((uint)npcPlayer.NpcData.Id) == true)
            {
                List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_GUILD_ACCEPT_NPC");
                if (accpetNpcParams.Count > 2)
                {
                    DialogManager.Instance.TriggerDialog(accpetNpcParams[2], "", npcPlayer, npcPlayer.ActorId, /*() => { TaskNet.Instance.AcceptGuildTask(); }*/null, null, null);
                    return true;
                }
            }

            // 导航获取的护送任务
            if (TaskManager.Instance.IsNavigatingAcceptEscortTask == true && NpcHelper.NpcCanAcceptEscortTask((uint)npcPlayer.NpcData.Id) == true)
            {
                UIManager.Instance.ShowSysWindow("UIEscortTaskWindow");
                return true;
            }

            List<Task> needDoTasks = new List<Task>();
            needDoTasks.Clear();
            List<Task> needAcceptAndSubmitTasks = new List<Task>();
            needAcceptAndSubmitTasks.Clear();

            GetNpcRelatedTasks(npcPlayer, out needDoTasks, out needAcceptAndSubmitTasks);

            // 进行中的任务
            if (needDoTasks.Count > 0)
            {
                //if ((Define.Function == (uint)NpcDefine.EFunction.EMPTY && needDoTasks.Count == 1) ||
                //    (Define.Function == (uint)NpcDefine.EFunction.INTERACTION))
                if (needDoTasks.Count == 1)
                {
                    string goal = needDoTasks[0].CurrentStep.Goal;
                    switch (goal)
                    {
                        case GameConst.GOAL_AUTO:
                            {
                                TaskNet.Instance.DoTaskGoal(goal);
                                break;
                            }
                        case GameConst.GOAL_TALK:
                            {
                                DoTalkTask(needDoTasks[0], npcPlayer);
                                break;
                            }
                        case GameConst.GOAL_INTERACT:
                            {
                                npcPlayer.StartInteract(() => { TaskNet.Instance.DoTaskGoal(goal, (int)npcPlayer.NpcData.ExcelId); });
                                break;
                            }
                        case GameConst.GOAL_WAR_WIN:
                        case GameConst.GOAL_WAR_ENTER:
                        case GameConst.GOAL_WAR_GRADE:
                            {
                                OpenTaskInstanceWindow(needDoTasks[0]);
                                break;
                            }
                        case GameConst.GOAL_EQUIP_SUBMIT:
                            {
                                UIManager.GetInstance().CloseSysWindow("UITaskWindow");
                                Dictionary<ulong, Goods> equips = xc.Equip.EquipHelper.GetBagEquipsOidsByColorAndLvStep(needDoTasks[0].CurrentStep.EquipColor, needDoTasks[0].CurrentStep.EquipLvStep);
                                //if (equips.Count == 0)
                                //{
                                //    UIManager.GetInstance().ShowWindow("UITaskGuideWindow", "GAME_QUEST_SUBMIT_EQUIP_GUIDE", needDoTasks[0]);
                                //}
                                //else
                                //{
                                //    UIManager.GetInstance().ShowWindow("UITaskSubmitEquipWindow", equips, needDoTasks[0]);
                                //}
                                UIManager.GetInstance().ShowWindow("UITaskSubmitEquipWindow", equips, needDoTasks[0]);
                            }
                            break;
                        case GameConst.GOAL_SECRET_AREA:
                            {
                                RouterManager.Instance.GotoSoulTownWnd();
                            }
                            break;
                        case GameConst.GOAL_TRIGRAM:
                            {
                                //uint chapterId = TaskHelper.GetTrigramChapterId(needDoTasks[0].CurrentStep.TrigramId);
                                //RouterManager.Instance.GoToTrigram(chapterId, needDoTasks[0].CurrentStep.TrigramId);
                            }
                            break;
                        case GameConst.GOAL_EQUIP_WEAR:
                            {
                                if (SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_BAG, true))
                                {
                                    UIManager.Instance.ShowSysWindow("UIBagWindow");
                                }
                            }
                            break;
                        case GameConst.GOAL_EQUIP_STRENGTH:
                            {
                                RouterManager.Instance.GoToEquipStrength();
                            }
                            break;
                        case GameConst.GOAL_EQUIP_GEM:
                            {
                                RouterManager.Instance.GoToEquipGem();
                            }
                            break;
                        case GameConst.GOAL_PET_LV:
                            {
                                RouterManager.Instance.GotoPetWnd();
                            }
                            break;
                        case GameConst.GOAL_GROW_LV:
                            {
                                // 坐骑
                                if (needDoTasks[0].CurrentStep.GrowType == 1)
                                {
                                    RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_RIDE);
                                }
                            }
                            break;
                        case GameConst.GOAL_STAR_LV:
                            {
                                RouterManager.Instance.GoToBagWnd();
                            }
                            break;
                        case GameConst.GOAL_STIGMA_LV:
                            {
                                RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_STIGMA, 0, needDoTasks[0].CurrentStep.StigmaId);
                            }
                            break;
                        case GameConst.GOAL_DRAGON_SOUL:
                            {
                                RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS);
                            }
                            break;
                        case GameConst.GOAL_CONTRACT_INHERIT:
                            {
                                RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_CONTRACT_INHERIT);
                            }
                            break;
                        case GameConst.GOAL_EQUIP_STRENGTH_TLV:
                            {
                                RouterManager.Instance.GoToEquipStrength();
                            }
                            break;
                        case GameConst.GOAL_TRIAL_BOSS:
                            {
                                RouterManager.Instance.GotoTrialBoss(needDoTasks[0].CurrentStep.InstanceLv);
                            }
                            break;
                        case GameConst.GOAL_KILL_BOSS:
                            {
                                switch ((ushort)needDoTasks[0].CurrentStep.WarTag)
                                {
                                    case GameConst.WAR_TAG_WORLD_BOSS:  //世界BOSS
                                        {
                                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_WORLD_BOSS);
                                            break;
                                        }
                                    case GameConst.WAR_TAG_GOLD_THIEF:  //盗宝怪
                                        {
                                            // 盗宝怪是在普通野外的，暂时没法判断
                                            break;
                                        }
                                    case GameConst.WAR_TAG_BOSS_HOME:   //boss之家
                                        {
                                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_BOSS_HOME);
                                            break;
                                        }
                                    case GameConst.WAR_TAG_SOUTH_LAND:  //南天圣地
                                        {
                                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_SOUTH_LAND);
                                            break;
                                        }
                                    case GameConst.WAR_TAG_ELEMENT_AREA://元素禁地
                                        {
                                            RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_ELEMENT_AREA);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }
                            break;
                        case GameConst.GOAL_LIGHT_EQUIP:
                            {
                                RouterManager.Instance.GenericGoToSysWindow(GameConst.SYS_OPEN_LIGHT_EQUIP);
                            }
                            break;
                        default:
                            {
                                TaskHelper.GotoTaskByLua(needDoTasks[0]);
                            }
                            break;
                    }
                }
                else
                {
                    UIManager.GetInstance().ShowSysWindow("UINpcDialogWindow", npcPlayer.Define, npcPlayer, npcPlayer.NpcData, needDoTasks);
                }

                return true;
            }
            // 可接取或提交的任务
            else if (needAcceptAndSubmitTasks.Count > 0)
            {
                if (needAcceptAndSubmitTasks.Count == 1)
                {
                    Task task = needAcceptAndSubmitTasks[0];
                    if (task.State == GameConst.QUEST_STATE_ACCEPT || task.State == GameConst.QUEST_STATE_FAIL)
                    {
                        DialogManager.Instance.TriggerDialog(task.Define.ReceiveDialogId, "", npcPlayer, npcPlayer.ActorId, () => { TaskNet.Instance.AcceptTask(task.Define.Id); }, null, null);
                    }
                    else
                    {
                        SubmitTask(task, npcPlayer);
                    }
                }
                else
                {
                    UIManager.GetInstance().ShowSysWindow("UINpcDialogWindow", npcPlayer.Define, npcPlayer, npcPlayer.NpcData, needAcceptAndSubmitTasks);
                }

                return true;
            }
            else
            {
                // 可接取的赏金任务
                if (NpcHelper.NpcCanAcceptBountyTask((uint)npcPlayer.NpcData.Id) == true)
                {
                    TaskManager.Instance.IsNavigatingAcceptBountyTask = true;
                    List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_SG_ACCEPT_NPC");
                    if (accpetNpcParams.Count > 2)
                    {
                        DialogManager.Instance.TriggerDialog(accpetNpcParams[2], "", npcPlayer, npcPlayer.ActorId, /*() => { TaskNet.Instance.AcceptBountyTask(); }*/null, null, null);
                        return true;
                    }
                }

                // 可接取的帮派任务
                if (NpcHelper.NpcCanAcceptGuildTask((uint)npcPlayer.NpcData.Id) == true)
                {
                    TaskManager.Instance.IsNavigatingAcceptGuildTask = true;
                    List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_GUILD_ACCEPT_NPC");
                    if (accpetNpcParams.Count > 2)
                    {
                        DialogManager.Instance.TriggerDialog(accpetNpcParams[2], "", npcPlayer, npcPlayer.ActorId, /*() => { TaskNet.Instance.AcceptGuildTask(); }*/null, null, null);
                        return true;
                    }
                }

                // 可接取的护送任务
                if (NpcHelper.NpcCanAcceptEscortTask((uint)npcPlayer.NpcData.Id) == true)
                {
                    UIManager.Instance.ShowSysWindow("UIEscortTaskWindow");
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取该NPC相关的任务列表
        /// </summary>
        public static bool GetNpcRelatedTasks(NpcPlayer npcPlayer, out List<Task> needDoTasks, out List<Task> needAcceptAndSubmitTasks)
        {
            uint sceneId = SceneHelp.Instance.CurSceneID;
            List<Task> allTask = TaskManager.Instance.AllTasks;
            allTask.Sort();

            needDoTasks = new List<Task>();
            needDoTasks.Clear();
            needAcceptAndSubmitTasks = new List<Task>();
            needAcceptAndSubmitTasks.Clear();

            foreach (var taskItem in allTask)
            {
                for (int i = 0; i < taskItem.Define.Steps.Count; i++)
                {
                    var dbStep = taskItem.Define.Steps[i];

                    if (taskItem.State == GameConst.QUEST_STATE_DOING)
                    {
                        // npc搜寻任务，副本任务
                        if (TaskHelper.StepGoalIsRelateSearchNpc(dbStep.Goal) || dbStep.Goal == GameConst.GOAL_WAR_WIN || dbStep.Goal == GameConst.GOAL_WAR_ENTER || dbStep.Goal == GameConst.GOAL_WAR_GRADE)
                        {
                            if ((dbStep.NpcId == npcPlayer.NpcData.Id && dbStep.InstanceId == sceneId))
                            {
                                if (i == taskItem.CurrentStepIndex)
                                {
                                    needDoTasks.Add(taskItem);

                                    break;
                                }
                            }
                        }

                        // 采集类任务，使用的是npc的excel id
                        if (dbStep.Goal == GameConst.GOAL_INTERACT)
                        {
                            if ((dbStep.NpcId == npcPlayer.NpcData.ExcelId && dbStep.InstanceId == sceneId))
                            {
                                if (i == taskItem.CurrentStepIndex)
                                {
                                    needDoTasks.Add(taskItem);

                                    break;
                                }
                            }
                        }
                    }
                }

                // 接受和提交任务的npc
                if (taskItem.State == GameConst.QUEST_STATE_ACCEPT || taskItem.State == GameConst.QUEST_STATE_FAIL)
                {
                    if (taskItem.Define.ReceiveNpc.NpcId == npcPlayer.NpcData.Id && taskItem.Define.ReceiveNpc.SceneId == sceneId)
                    {
                        needAcceptAndSubmitTasks.Add(taskItem);
                    }
                }
                else if (taskItem.State == GameConst.QUEST_STATE_DONE)
                {
                    if (taskItem.Define.SubmitNpc.NpcId == npcPlayer.NpcData.Id && taskItem.Define.SubmitNpc.SceneId == sceneId)
                    {
                        needAcceptAndSubmitTasks.Add(taskItem);
                    }
                }
            }

            bool ret = false;
            if (needDoTasks.Count > 0 || needAcceptAndSubmitTasks.Count > 0)
            {
                ret = true;
            }

            // 是否是导航任务过去的
            if (npcPlayer.IsInNavigating == true)
            {
                Task navigatingTask = TaskManager.Instance.NavigatingTask;
                if (navigatingTask != null)
                {
                    if (navigatingTask.State == GameConst.QUEST_STATE_DOING || (navigatingTask.CurrentStep != null && TaskHelper.StepGoalIsRelateSearchNpc(navigatingTask.CurrentStep.Goal)))
                    {
                        needDoTasks.Clear();
                        needAcceptAndSubmitTasks.Clear();
                        needDoTasks.Add(navigatingTask);
                    }

                    if (navigatingTask.State == GameConst.QUEST_STATE_ACCEPT || navigatingTask.State == GameConst.QUEST_STATE_FAIL)
                    {
                        needDoTasks.Clear();
                        needAcceptAndSubmitTasks.Clear();
                        needAcceptAndSubmitTasks.Add(navigatingTask);
                    }
                    else if (navigatingTask.State == GameConst.QUEST_STATE_DONE)
                    {
                        needDoTasks.Clear();
                        needAcceptAndSubmitTasks.Clear();
                        needAcceptAndSubmitTasks.Add(navigatingTask);
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// 当前任务目标能否使用飞鞋
        /// </summary>
        public static bool CanTransfer(uint id)
        {
            Task task = TaskManager.Instance.GetTask(id);
            if (task != null)
            {
                // 有护送NPC的任务不能使用飞鞋
                if (task.Define.FollowNpcs != null && task.Define.FollowNpcs.Count > 0)
                {
                    return false;
                }

                if (task.State == GameConst.QUEST_STATE_ACCEPT || task.State == GameConst.QUEST_STATE_FAIL)
                {
                    if (task.Define.ReceiveNpc.NpcId == 0)
                    {
                        return false;
                    }
                    return task.Define.CanUseBoots;
                }
                if (task.State == GameConst.QUEST_STATE_DONE)
                {
                    if (task.Define.SubmitNpc.NpcId == 0)
                    {
                        return false;
                    }
                    return task.Define.CanUseBoots;
                }

                TaskDefine.TaskStep step = task.CurrentStep;
                if (step != null)
                {
                    if (step.NavigationInstanceId != 0 && step.NavigationTagId != 0)
                    {
                        return task.Define.CanUseBoots;
                    }

                    // 跳转到世界BOSS界面且进行中的不能用小飞鞋
                    if (step.MinWorldBossSpecialMonId > 0 && step.MaxWorldBossSpecialMonId > 0)
                    {
                        return false;
                    }

                    string goal = step.Goal;
                    if (goal == GameConst.GOAL_TALK || goal == GameConst.GOAL_KILL_MON || goal == GameConst.GOAL_KILL_GROUP_MON
                        || goal == GameConst.GOAL_INTERACT || goal == GameConst.GOAL_KILL_COLLECT || goal == GameConst.GOAL_COLLECT_GOODS)
                    {
                        return task.Define.CanUseBoots;
                    }

                    if (goal == GameConst.GOAL_WAR_WIN || goal == GameConst.GOAL_WAR_ENTER || goal == GameConst.GOAL_WAR_GRADE)
                    {
                        if (step.NpcId > 0)
                        {
                            return task.Define.CanUseBoots;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 飞鞋传送过去的npc id
        /// </summary>
        public static int TransferingNpcId = 0;
        /// <summary>
        /// 飞鞋传送
        /// </summary>
        /// <param name="id"></param>
        public static void TransferToTaskTarget(uint id)
        {
            if (VipHelper.GetIsFlyFree() == false)
            {
                uint bootsGoodsId = GameConstHelper.GetUint("GAME_ITEM_TRAVEL_BOOTS");
                if (ItemManager.Instance.GetGoodsNumForBagByTypeId(bootsGoodsId) == 0)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("TASK_TRAVEL_NO_BOOTS"));
                    return;
                }
            }

            TransferingNpcId = 0;
            bool isAutoFighting = false;

            Task task = TaskManager.Instance.GetTask(id);
            if (task != null)
            {
                uint instanceId = 0;
                Vector3 pos = Vector3.zero;

                if (task.State == GameConst.QUEST_STATE_ACCEPT || task.State == GameConst.QUEST_STATE_FAIL)
                {
                    instanceId = task.Define.ReceiveNpc.SceneId;
                    Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(task.Define.ReceiveNpc.SceneId));
                    if (levelData != null)
                    {
                        Neptune.NPC npcInfo = levelData.GetNode<Neptune.NPC>((int)task.Define.ReceiveNpc.NpcId);
                        if (npcInfo != null)
                        {
                            pos = npcInfo.Position;
                            TransferingNpcId = (int)task.Define.ReceiveNpc.NpcId;
                        }
                    }
                }
                else if (task.State == GameConst.QUEST_STATE_DONE)
                {
                    instanceId = task.Define.SubmitNpc.SceneId;
                    Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(task.Define.SubmitNpc.SceneId));
                    if (levelData != null)
                    {
                        Neptune.NPC npcInfo = levelData.GetNode<Neptune.NPC>((int)task.Define.SubmitNpc.NpcId);
                        if (npcInfo != null)
                        {
                            pos = npcInfo.Position;
                            TransferingNpcId = (int)task.Define.SubmitNpc.NpcId;
                        }
                    }
                }
                else
                {
                    TaskDefine.TaskStep step = task.CurrentStep;
                    if (step != null)
                    {
                        string goal = step.Goal;
                        // 下面任务目标的任务使用飞鞋后要自动战斗
                        if (goal == GameConst.GOAL_KILL_MON || goal == GameConst.GOAL_KILL_GROUP_MON || goal == GameConst.GOAL_KILL_COLLECT || goal == GameConst.GOAL_COLLECT_GOODS)
                        {
                            isAutoFighting = true;
                        }

                        // 先找导航tag点位置
                        Neptune.Data levelData = null;
                        if (step.NavigationInstanceId != 0 && step.NavigationTagId != 0)
                        {
                            instanceId = step.InstanceId;
                            levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(step.InstanceId));
                            if (levelData != null)
                            {
                                Neptune.Tag tag = levelData.GetNode<Neptune.Tag>((int)step.NavigationTagId);
                                if (tag != null)
                                {
                                    pos = tag.Position;
                                }
                            }
                        }
                        
                        // 如果该tag点不可到达则直接找任务目标位置
                        if (InstanceHelper.CanWalkTo(pos) == false)
                        {
                            instanceId = step.InstanceId;
                            levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(step.InstanceId));
                            if (goal == GameConst.GOAL_TALK || goal == GameConst.GOAL_WAR_WIN || goal == GameConst.GOAL_WAR_ENTER || goal == GameConst.GOAL_WAR_GRADE)
                            {
                                if (levelData != null)
                                {
                                    Neptune.NPC npcInfo = levelData.GetNode<Neptune.NPC>((int)step.NpcId);
                                    if (npcInfo != null)
                                    {
                                        pos = npcInfo.Position;
                                        TransferingNpcId = (int)step.NpcId;
                                    }
                                }
                            }
                            else if (goal == GameConst.GOAL_INTERACT)
                            {
                                if (levelData != null)
                                {
                                    Dictionary<int, Neptune.BaseGenericNode> npcs = levelData.GetData<Neptune.NPC>().Data;
                                    // 这里的npc id是指excel里面的id
                                    foreach (Neptune.NPC tempNpc in npcs.Values)
                                    {
                                        if (tempNpc.ExcelId == step.NpcId)
                                        {
                                            pos = tempNpc.Position;
                                            TransferingNpcId = (int)tempNpc.Id;
                                        }
                                    }
                                }
                            }
                            else if (goal == GameConst.GOAL_KILL_MON || goal == GameConst.GOAL_KILL_COLLECT)
                            {
                                pos = xc.Dungeon.LevelObjectHelper.GetNearestMonsterPositionByActorId(step.MonsterId, levelData);
                            }
                            else if (goal == GameConst.GOAL_KILL_GROUP_MON)
                            {
                                pos = xc.Dungeon.LevelObjectHelper.GetMonsterPosition(step.MonsterId, levelData);
                            }
                            else if (goal == GameConst.GOAL_COLLECT_GOODS)
                            {
                                var hangInfo = DBHang.Instance.GetSuitableHangInfo();
                                if (hangInfo != null)
                                {
                                    instanceId = hangInfo.Dungeon;
                                    levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(hangInfo.Dungeon));
                                    if (levelData != null)
                                    {
                                        Neptune.Tag tagInfo = levelData.GetNode<Neptune.Tag>((int)hangInfo.GetRandomTag().Id);
                                        if (tagInfo != null)
                                        {
                                            pos = tagInfo.Position;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Vector3 newPos = pos;
                if (SceneHelp.Instance.CurSceneID == instanceId)
                {
                    Actor localPlayer = Game.GetInstance().GetLocalPlayer();
                    if (localPlayer != null)
                    {
                        if (Vector3.Distance(localPlayer.transform.position, pos) <= 10f)
                        {
                            UINotice.Instance.ShowMessage(DBConstText.GetText("TASK_NO_NEED_TRANSFER"));
                            TaskHelper.TaskGuide(task);
                            return;
                        }
                    }

                    NpcPlayer npcPlayer = NpcManager.Instance.GetNpcByNpcId((uint)TransferingNpcId);
                    if (npcPlayer != null)
                    {
                        float radius = NpcHelper.MakeNpcDefine((uint)npcPlayer.NpcData.ExcelId).Radius - 0.1f;
                        //newPos.x = pos.x + Random.Range(-radius, radius);
                        //newPos.z = Mathf.Sqrt(radius * radius - (newPos.x - pos.x) * (newPos.x - pos.x)) + pos.z;
                        // npc正前方radius距离的位置
                        newPos = newPos + radius * npcPlayer.ForwardDir;
                        bool result = false;
                        newPos = InstanceHelper.ClampInWalkableRange(newPos, newPos, out result, radius);
                    }
                }
                else
                {
                    // 如果是传到其他副本的npc，则通过jump到那个副本再post一个event来移动在npc旁边
                    if (TransferingNpcId > 0)
                    {
                        //Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(instanceId));
                        //Neptune.NPC npcInfo = levelData.GetNode<Neptune.NPC>(TransferingNpcId);
                        //if (npcInfo != null)
                        //{
                        //    float radius = NpcHelper.MakeNpcDefine((uint)npcInfo.ExcelId).Radius - 0.1f;
                        //    newPos.x = pos.x + Random.Range(-radius, radius);
                        //    newPos.z = Mathf.Sqrt(radius * radius - (newPos.x - pos.x) * (newPos.x - pos.x)) + pos.z;
                        //}

                        //SceneHelp.JumpToScene(instanceId);
                        //// 野外中要停止副本，不然这个event就马上触发了
                        //if (SceneHelp.Instance.IsInWildInstance() == true)
                        //{
                        //    InstanceHelper.CompleteInstance();
                        //}
                        //ClientEventMgr.GetInstance().PostEvent((int)ClientEvent.TRANSFER_TO_TASK_POS, new CEventEventParamArgs(newPos.x, newPos.z));
                        //return;
                    }
                }

                TargetPathManager.Instance.StopPlayerAndReset();
                SceneHelp.TravelBootsJump(newPos, instanceId, false, 1, isAutoFighting);

                NpcManager.Instance.NavigatingNpcId = (uint)TransferingNpcId;
                NpcManager.Instance.TravelBootsJumpNpcId = (uint)TransferingNpcId;
                TaskManager.Instance.NavigatingTask = task;
            }
        }

        /// <summary>
        /// 显示任务进度提示
        /// </summary>
        public static void ShowTaskProgressTips(Task task)
        {
            // 暂时屏蔽掉
            return;

            if (task == null)
            {
                return;
            }

            Task.StepProgress stepProgress = task.CurrentStepProgress;
            if (stepProgress != null && stepProgress.CurrentValue > 0)
            {
                TaskDefine.TaskStep curStep = task.CurrentStep;
                if (curStep != null)
                {
                    string str = string.Empty;
                    if (curStep.Goal == GameConst.GOAL_KILL_MON)
                    {
                        str = RoleHelp.GetActorName(curStep.MonsterId) + "(" + stepProgress.CurrentValue + "/" + curStep.ExpectResult + ")";
                    }
                    else if (curStep.Goal == GameConst.GOAL_INTERACT)
                    {
                        str = RoleHelp.GetActorName(NpcHelper.MakeNpcDefine(curStep.NpcId).ActorId) + "(" + stepProgress.CurrentValue + "/" + curStep.ExpectResult + ")";
                    }
                    if (curStep.Goal == GameConst.GOAL_KILL_COLLECT)
                    {
                        str = GoodsHelper.GetGoodsOriginalNameByTypeId(curStep.GoodsId) + "(" + stepProgress.CurrentValue + "/" + curStep.ExpectResult + ")";
                    }

                    UINotice.Instance.ShowMessage(str);
                }
            }
        }

        /// <summary>
        /// 执行领取赏金任务的导航
        /// </summary>
        public static void AcceptBountyTaskGuide()
        {
            TaskManager.Instance.DoNotAutoRunBountyTaskNextTime = false;

            InstanceManager.Instance.IsAutoFighting = false;

            TaskManager.Instance.NavigatingTask = null;

            List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_SG_ACCEPT_NPC");
            if (accpetNpcParams.Count > 2)
            {
                TaskManager.Instance.IsNavigatingAcceptBountyTask = true;
                TargetPathManager.Instance.GoToNpcPos(accpetNpcParams[0], accpetNpcParams[1], null);
            }
            else
            {
                TaskNet.Instance.AcceptBountyTask();

                // 如果在副本中，则退出副本
                if (SceneHelp.Instance.IsInInstance == true)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_EXITINSTANCE, null);
                }
            }
        }

        /// <summary>
        /// 执行领取帮派任务的导航
        /// </summary>
        public static void AcceptGuildTaskGuide()
        {
            if (LocalPlayerManager.Instance.GuildID == 0)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("TASK_ENTER_GUILD_TO_DO_TASK"));
                return;
            }

            TaskManager.Instance.DoNotAutoRunGuildTaskNextTime = false;

            // 记录当弹出退出提示的时候是否要继续自动战斗
            if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
            {
                SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            TaskManager.Instance.NavigatingTask = null;

            List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_GUILD_ACCEPT_NPC");
            if (accpetNpcParams.Count > 2)
            {
                TaskManager.Instance.IsNavigatingAcceptGuildTask = true;
                TargetPathManager.Instance.GoToNpcPos(accpetNpcParams[0], accpetNpcParams[1], null);
            }
            else
            {
                TaskNet.Instance.AcceptGuildTask();

                // 如果在副本中，则退出副本
                if (SceneHelp.Instance.IsInInstance == true)
                {
                    ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_EXITINSTANCE, null);
                }
            }
        }

        /// <summary>
        /// 执行领取护送任务的导航
        /// </summary>
        public static void AcceptEscortTaskGuide()
        {
            InstanceManager.Instance.IsAutoFighting = false;

            TaskManager.Instance.NavigatingTask = null;

            List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_ESCORT_ACCEPT_NPC");
            if (accpetNpcParams.Count >= 2)
            {
                TaskManager.Instance.IsNavigatingAcceptEscortTask = true;
                uint instanceId = accpetNpcParams[0];
                uint npcId = accpetNpcParams[1];

                // 如果足够接近，就不用飞过去了
                if (instanceId == SceneHelp.Instance.CurSceneID)
                {
                    NpcPlayer npcPlayer = NpcManager.Instance.GetNpcByNpcId(npcId);
                    if (npcPlayer != null)
                    {
                        if (npcPlayer.IsLocalPlayerCloseEnoughToEnter)
                        {
                            npcPlayer.FireTouchEvent();
                            return;
                        }
                    }
                }

                // 当前场景是否禁止使用飞鞋
                if (DBInstanceTypeControl.Instance.NoFlyShoe(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType) == true)
                {
                    UINotice.Instance.ShowMessage(DBConstText.GetText("TASK_ESCORT_CAN_NOT_ACCEPT_TIPS"));
                }
                else
                {
                    Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(instanceId));
                    Neptune.NPC npcInfo = levelData.GetNode<Neptune.NPC>((int)npcId);
                    if (npcInfo != null)
                    {
                        TransferingNpcId = (int)npcId;
                        SceneHelp.TravelBootsJump(npcInfo.Position, instanceId, true);
                    }
                    else
                    {
                        GameDebug.LogError("AcceptEscortTaskGuide error! Can not find npc info in instance " + instanceId + " by npc id " + npcId);
                    }
                }
            }
        }

        /// <summary>
        /// 任务是否可以接取
        /// </summary>
        public static bool TaskCanAccept(uint taskId)
        {
            Task task = TaskManager.Instance.GetTask(taskId);
            if (task != null)
            {
                return task.State == GameConst.QUEST_STATE_ACCEPT;
            }

            return false;
        }

        /// <summary>
        /// 任务是否可以已经接取（在进行过程中，但是没有完成）
        /// </summary>
        public static bool IsTaskAccepted(uint taskId)
        {
            Task task = TaskManager.Instance.GetTask(taskId);
            if (task != null)
            {
                return task.State == GameConst.QUEST_STATE_DOING;
            }

            return false;
        }

        /// <summary>
        /// 任务是否可提交（在进行过程中，已经完成）
        /// </summary>
        public static bool IsTaskCanSubmit(uint taskId)
        {
            Task task = TaskManager.Instance.GetTask(taskId);
            if (task != null)
            {
                return task.State == GameConst.QUEST_STATE_DONE;
            }

            return false;
        }

        /// <summary>
        /// 获取赏金任务最大次数
        /// </summary>
        /// <returns></returns>
        public static uint GetBountyTaskMaxTimes()
        {
            return ActivityHelper.GetActivityInfo<uint>(GameConst.SYS_OPEN_REC_SG, "GetMaxTimes");
        }

        /// <summary>
        /// 获取帮派任务最大次数
        /// </summary>
        /// <returns></returns>
        public static uint GetGuildTaskMaxTimes()
        {
            return ActivityHelper.GetActivityInfo<uint>(GameConst.SYS_OPEN_QUEST_GUILD, "GetMaxTimes");
        }

        /// <summary>
        /// 获取护送任务是否已经做完
        /// </summary>
        /// <returns></returns>
        public static bool GetEscortTaskIsDone()
        {
            return ActivityHelper.GetActivityInfo<bool>(GameConst.SYS_OPEN_QUEST_ESCORT, "IsDone");
        }

        /// <summary>
        /// 该主线任务是否已经通过
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public static bool MainTaskIsPassed(uint taskId)
        {
            Task task = TaskManager.Instance.GetTaskByTypeAndId(GameConst.QUEST_MAIN, taskId);
            if (task != null)
            {
                if (task.State == GameConst.QUEST_STATE_FIN)
                {
                    return true;
                }
            }
            else
            {
                List<Task> mainTasks = TaskManager.Instance.GetTasksByType(GameConst.QUEST_MAIN);
                if (mainTasks != null && mainTasks.Count > 0)
                {
                    if (taskId < mainTasks[0].Define.Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 获取前置主线任务的id列表
        /// </summary>
        /// <returns></returns>
        public static List<uint> GetPreMainTasksId(uint taskId)
        {
            List<uint> result = new List<uint>();
            result.Clear();

            Dictionary<uint, TaskDefine> mainTaskDefines = DBManager.Instance.GetDB<DBTask>().GetTaskDefineListByType(GameConst.QUEST_MAIN);
            foreach (TaskDefine taskDefine in mainTaskDefines.Values)
            {
                if (taskDefine.Id < taskId)
                {
                    result.Add(taskDefine.Id);
                }
            }

            return result;
        }

        /// <summary>
        /// 根据当前的主线任务判断是否要删除指定的npc，通过任务表的delete_npcs_when_received和delete_npcs_when_done两个属性来判断
        /// </summary>
        /// <param name="npcId"></param>
        /// <returns></returns>
        public static bool ShouldDeleteNpcInCurMainTask(int npcId)
        {
            List<Task> mainTasks = TaskManager.Instance.GetTasksByType(GameConst.QUEST_MAIN);
            if (mainTasks != null && mainTasks.Count > 0)
            {
                Task mainTask = mainTasks[0];
                uint instanceId = SceneHelp.Instance.CurSceneID;

                if (mainTask.Define.DeleteNpcsWhenReceived != null)
                {
                    foreach (NpcScenePosition npcScenePosition in mainTask.Define.DeleteNpcsWhenReceived)
                    {
                        if (npcScenePosition.SceneId == instanceId && npcScenePosition.NpcId == npcId)
                        {
                            return true;
                        }
                    }
                }
                if (mainTask.Define.DeleteNpcsWhenDone != null && (mainTask.State == GameConst.QUEST_STATE_DONE || mainTask.State == GameConst.QUEST_STATE_FIN))
                {
                    foreach (NpcScenePosition npcScenePosition in mainTask.Define.DeleteNpcsWhenDone)
                    {
                        if (npcScenePosition.SceneId == instanceId && npcScenePosition.NpcId == npcId)
                        {
                            return true;
                        }
                    }
                }

                List<uint> preMainTaskIds = GetPreMainTasksId(mainTask.Define.Id);
                foreach (uint preMainTaskId in preMainTaskIds)
                {
                    List<NpcScenePosition> deleteNpcsWhenReceived = TaskDefine.GetDeleteNpcsWhenReceived(preMainTaskId);
                    if (deleteNpcsWhenReceived != null)
                    {
                        foreach (NpcScenePosition npcScenePosition in deleteNpcsWhenReceived)
                        {
                            if (npcScenePosition.SceneId == instanceId && npcScenePosition.NpcId == npcId)
                            {
                                return true;
                            }
                        }
                    }
                    List<NpcScenePosition> DeleteNpcsWhenDone = TaskDefine.GetDeleteNpcsWhenDone(preMainTaskId);
                    if (DeleteNpcsWhenDone != null)
                    {
                        foreach (NpcScenePosition npcScenePosition in DeleteNpcsWhenDone)
                        {
                            if (npcScenePosition.SceneId == instanceId && npcScenePosition.NpcId == npcId)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 检查指定npc是否有跟随的任务，有的话激活跟随AI
        /// </summary>
        /// <param name="npcPlayer"></param>
        public static void CheckNpcAndActiveNpcFollowAI(NpcPlayer npcPlayer)
        {
            List<Task> doingTasks = TaskManager.Instance.GetTasksByState(GameConst.QUEST_STATE_DOING);
            uint instanceId = SceneHelp.Instance.CurSceneID;
            foreach (Task task in doingTasks)
            {
                List<NpcScenePosition> followNpcs = task.Define.FollowNpcs;
                if (followNpcs != null)
                {
                    foreach (NpcScenePosition npcScenePosition in followNpcs)
                    {
                        if (npcScenePosition.SceneId == instanceId && npcScenePosition.NpcId == npcPlayer.NpcData.Id)
                        {
                            npcPlayer.ActiveFollowAI(true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 检查指定任务是否有跟随的npc，有的话激活其跟随AI
        /// </summary>
        public static void CheckTaskAndActiveNpcFollowAI(uint taskId, bool active)
        {
            Task task = TaskManager.Instance.GetTask(taskId);
            uint instanceId = SceneHelp.Instance.CurSceneID;
            if (task != null)
            {
                List<NpcScenePosition> followNpcs = task.Define.FollowNpcs;
                if (followNpcs != null)
                {
                    foreach (NpcScenePosition npcScenePosition in followNpcs)
                    {
                        if (npcScenePosition.SceneId == instanceId)
                        {
                            NpcPlayer npcPlayer = NpcManager.Instance.GetNpcByNpcId(npcScenePosition.NpcId);
                            if (npcPlayer != null)
                            {
                                npcPlayer.ActiveFollowAI(active);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 本地玩家是否处于护送任务状态
        /// </summary>
        /// <returns></returns>
        public static bool LocalPlayerIsInEscortTaskState()
        {
            List<Task> escortTasks = TaskManager.Instance.GetTasksByType(GameConst.QUEST_ESCORT);
            if (escortTasks != null && escortTasks.Count > 0)
            {
                foreach (Task task in escortTasks)
                {
                    if (task.State == GameConst.QUEST_STATE_DOING)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 获取任务步骤描述，c#代码的lua扩展
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string GetStepFixedDescriptionByLua(TaskDefine.TaskStep step)
        {
            string ret = "";
            object[] param = { step };
            System.Type[] returnType = { typeof(string) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TaskHelper_GetStepFixedDescription", param, returnType);
            if (objs != null && objs.Length > 0 && objs[0] != null)
            {
                ret = (string)objs[0];
            }
            return ret;
        }

        /// <summary>
        /// 任务跳转的lua扩展
        /// </summary>
        /// <param name="task"></param>
        public static void GotoTaskByLua(Task task)
        {
            object[] param = { task };
            LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "TaskHelper_GotoTask", param);
        }

        /// <summary>
        /// 获取指定任务状态的任务数量
        /// </summary>
        /// <param name="taskType"></param>
        /// <param name="taskState"></param>
        /// <returns></returns>
        public static uint GetTaskNumByState(List<Task> tasks, uint state)
        {
            uint num = 0;
            foreach (Task task in tasks)
            {
                if (task.State == state)
                {
                    ++num;
                }
            }

            return num;
        }
    }
}
