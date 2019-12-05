//------------------------------------------------------------------------------
// Desc   :  Npc帮助类
// Author :  ljy
// Date   :  2017.6.1
//------------------------------------------------------------------------------
using System.Collections.Generic;
using xc;
using xc.ui.ugui;

namespace xc
{
    [wxb.Hotfix]
    public class NpcHelper
    {
        /// <summary>
        /// NPC配置缓存
        /// </summary>
        private static Dictionary<uint, NpcDefine> mNpcDefineCache = null;

        public static NpcDefine MakeNpcDefine(uint npcId)
        {
            if (mNpcDefineCache == null)
            {
                mNpcDefineCache = new Dictionary<uint, NpcDefine>();
                mNpcDefineCache.Clear();
            }
            if (mNpcDefineCache.ContainsKey(npcId) == true)
            {
                return mNpcDefineCache[npcId];
            }

            NpcDefine define = new NpcDefine();
            define.NpcId = npcId;

            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "npc", "npc_id", npcId.ToString());

            if (dbs.Count <= 0)
            {
                GameDebug.LogError("Error in MakeNpcDefine, can not find npc data by id " + npcId);
                return null;
            }

            var dbNpc = dbs[0];

            if (dbNpc.Count <= 0)
            {
                return null;
            }

            if (dbNpc.Count > 0)
            {
                dbNpc.TryGetValue("idle_ani", out define.IdleAni);
                dbNpc.TryGetValue("const_title", out define.ConstTitle);
                dbNpc.TryGetValue("const_text", out define.ConstText);
                dbNpc.TryGetValue("const_btn_text", out define.ConstBtnText);
                dbNpc.TryGetValue("const_btn_pic", out define.ConstBtnPic);

                string rawData = string.Empty;
                dbNpc.TryGetValue("actor_id", out rawData);
                uint.TryParse(rawData, out define.ActorId);

                dbNpc.TryGetValue("light_mode", out rawData);
                if (string.IsNullOrEmpty(rawData) == true || rawData.Equals("0"))
                {
                    define.LightMode = NpcDefine.ELightMode.ROLE;
                }
                else
                {
                    uint lightModeUint = 0;
                    uint.TryParse(rawData, out lightModeUint);
                    define.LightMode = (NpcDefine.ELightMode)lightModeUint;
                }

                dbNpc.TryGetValue("radius", out rawData);
                float.TryParse(rawData, out define.Radius);

                dbNpc.TryGetValue("function", out rawData);
                define.Function = (NpcDefine.EFunction)System.Enum.Parse(typeof(NpcDefine.EFunction), rawData);

                define.FunctionParams.Clear();
                int i = 1;
                bool ret = dbNpc.TryGetValue("param" + i, out rawData);
                while (ret)
                {
                    define.FunctionParams.Add(rawData);

                    ++i;
                    ret = dbNpc.TryGetValue("param" + i, out rawData);
                }

                dbNpc.TryGetValue("voice", out rawData);
                define.VoiceIds = DBTextResource.ParseArrayUint(rawData,",");
            }


            mNpcDefineCache.Add(npcId, define);
            return define;
        }

        public static List<uint> GetExchangeInfo(uint id)
        {
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "data_exchange", "id", id.ToString());

            if (dbs.Count <= 0)
            {
                return null;
            }

            var db = dbs[0];

            if (db.Count <= 0)
            {
                return null;
            }

            List<uint> results = new List<uint>();

            string raw = string.Empty;
            db.TryGetValue("cost_goods", out raw);

            Utils.DataFormatHelper.DBRawStringReplaceBracketToIds(raw, results);

            raw = string.Empty;
            db.TryGetValue("get_goods", out raw);

            Utils.DataFormatHelper.DBRawStringReplaceBracketToIds(raw, results);

            return results;
        }

        /// <summary>
        /// 处理npc的功能，比RunNpcFunction更上一级
        /// </summary>
        public static void ProcessNpcFunction(NpcPlayer npcPlayer)
        {
            // 互动功能不需要打开对话框
            if (npcPlayer.Define.Function == NpcDefine.EFunction.INTERACTION)
            {
                // 有任务才能互动，所以这里要干掉
                //npcPlayer.StartInteract(null);
            }
            else
            {
                UIManager.GetInstance().ShowSysWindow("UINpcDialogWindow", npcPlayer.Define, npcPlayer);
            }
        }

        /// <summary>
        /// 执行NPC的功能
        /// </summary>
        public static void RunNpcFunction(NpcDefine npcDefine)
        {
            NpcDefine.EFunction func = npcDefine.Function;
            List<string> funcParams = npcDefine.FunctionParams;

            switch (func)
            {
                case NpcDefine.EFunction.EMPTY:
                    break;
                case NpcDefine.EFunction.TRANSFER:
                    {
                        uint instanceId = 0;
                        uint.TryParse(funcParams[0], out instanceId);
                        DBInstance.InstanceInfo instanceInfo = DBInstance.Instance.GetInstanceInfo(instanceId);
                        if (instanceInfo != null && instanceInfo.mWarType != GameConst.WAR_TYPE_WILD)
                        {
                            UIManager.GetInstance().ShowSysWindow("UIInstanceEnterWindow", instanceInfo);
                        }
                        else
                        {
                            SceneHelp.JumpToScene(instanceId);
                        }
                    }
                    break;
                case NpcDefine.EFunction.EXCHANGE:
                    {
                        xc.ui.UIWidgetHelp.Instance.ShowNoticeDlg(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_73") + npcDefine.FunctionParams[0]);
                    }
                    break;
                case NpcDefine.EFunction.DIALOG:
                    break;
                case NpcDefine.EFunction.EVENT:
                    {
                        uint triggerId = 0;
                        uint.TryParse(funcParams[0], out triggerId);
                        Uranus.Runtime.UranusManager.Instance.ActiveLevelNode(triggerId);
                    }
                    break;
                case NpcDefine.EFunction.INTERACTION:
                    {
                        CommonSliderHelper.Interrupt();
                        int second = 0;
                        int.TryParse(npcDefine.FunctionParams[0], out second);
                        CommonSliderHelper.Start(second, npcDefine.ConstBtnText, npcDefine.ConstBtnPic, null, () => { ; });
                    }
                    break;
                default:
                    break;
            }
        }

        public static uint GetNpcActorId(uint npcId)
        {
            var dbs = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "npc", "npc_id", npcId.ToString());

            if (dbs.Count <= 0)
            {
                return 0;
            }

            var dbNpc = dbs[0];

            if (dbNpc.Count <= 0)
            {
                return 0;
            }

            if (dbNpc.Count > 0)
            {
                string rawData = string.Empty;
                uint actorId = 0;
                dbNpc.TryGetValue("actor_id", out rawData);
                uint.TryParse(rawData, out actorId);

                return actorId;
            }

            return 0;
        }

        public static string GetNpcName(uint instanceId, uint npcJsonId)
        {
            if (instanceId == 0)
            {
                instanceId = SceneHelp.Instance.CurSceneID;
            }
            Neptune.Data levelData = xc.Dungeon.LevelManager.Instance.LoadLevelFileTemporary(SceneHelp.GetFirstStageId(instanceId));
            if (levelData != null)
            {
                Neptune.NPC npcInfo = levelData.GetNode<Neptune.NPC>((int)npcJsonId);
                if (npcInfo != null)
                {
                    return RoleHelp.GetActorName(NpcHelper.MakeNpcDefine(npcInfo.ExcelId).ActorId);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取指定npc的任务状态
        /// </summary>
        /// <returns></returns>
        public static uint GetNpcTaskState(uint npcJsonId, uint sceneId = 0)
        {
            if (0 == sceneId)
                sceneId = SceneHelp.Instance.CurSceneID;

            List<Task> tasks = TaskManager.Instance.GetNpcRelateCurrentStepTasks(npcJsonId, sceneId);
            if (tasks.Count > 0)
            {
                return tasks[0].State;
            }

            return 0;
        }

        /// <summary>
        /// 该NPC能否接取赏金任务
        /// </summary>
        public static bool NpcCanAcceptBountyTask(uint npcJsonId)
        {
            if (TaskManager.Instance.VisibleBountyTasks.Count == 0 && SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_REC_SG) == true)
            {
                List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_SG_ACCEPT_NPC");
                if (accpetNpcParams.Count > 2)
                {
                    if (accpetNpcParams[0] == SceneHelp.Instance.CurSceneID && accpetNpcParams[1] == npcJsonId)
                    {
                        BountyTaskInfo bountyTaskInfo = TaskManager.Instance.BountyTaskInfo;
                        if (bountyTaskInfo != null && bountyTaskInfo.num < TaskHelper.GetBountyTaskMaxTimes())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 该NPC能否接取帮派任务
        /// </summary>
        public static bool NpcCanAcceptGuildTask(uint npcJsonId)
        {
            if (TaskManager.Instance.VisibleGuildTasks.Count == 0 && LocalPlayerManager.Instance.GuildID > 0 && SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_QUEST_GUILD) == true)
            {
                List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_GUILD_ACCEPT_NPC");
                if (accpetNpcParams.Count > 2)
                {
                    if (accpetNpcParams[0] == SceneHelp.Instance.CurSceneID && accpetNpcParams[1] == npcJsonId)
                    {
                        GuildTaskInfo guildTaskInfo = TaskManager.Instance.GuildTaskInfo;
                        if (guildTaskInfo != null && guildTaskInfo.num < TaskHelper.GetGuildTaskMaxTimes())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 该NPC能否接取护送任务
        /// </summary>
        public static bool NpcCanAcceptEscortTask(uint npcJsonId)
        {
            if (TaskManager.Instance.VisibleEscortTasks.Count == 0 && SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_QUEST_ESCORT) == true)
            {
                List<uint> accpetNpcParams = xc.GameConstHelper.GetUintList("GAME_QUEST_ESCORT_ACCEPT_NPC");
                if (accpetNpcParams.Count >= 2)
                {
                    if (accpetNpcParams[0] == SceneHelp.Instance.CurSceneID && accpetNpcParams[1] == npcJsonId)
                    {
                        if (TaskHelper.GetEscortTaskIsDone() == false)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 该NPC能否打开结婚界面
        /// </summary>
        public static bool NpcCanOpenMarryWin(uint npcJsonId)
        {
            //if (SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_MARRY) == true)
            //{
                List<uint> npcParams = xc.GameConstHelper.GetUintList("GAME_MARRY_NPC");
                if (npcParams.Count >= 2)
                {
                    if (npcParams[0] == SceneHelp.Instance.CurSceneID && npcParams[1] == npcJsonId)
                    {
                        return true;
                    }
                }
            //}

            return false;
        }
    }
}
