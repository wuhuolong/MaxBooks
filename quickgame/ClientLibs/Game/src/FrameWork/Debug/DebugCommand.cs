using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

using Net;
using ProtoBuf;
using xc.protocol;
using xc.Dungeon;
using xc.ui.ugui;

namespace xc
{
    public class DebugCommand
    {
        public static bool mTestRide = false;
        public static uint xihun_sound_id = 1;
        public DebugCommand()
        {

        }

        /// <summary>
        /// gm命令入口
        /// </summary>
        public static void SendGMCommandForDebugUI(DebugUI.Command cmd)
        {
            string str = "";
            for (int i = 2; i < cmd.main.ToLower().Length; i++)
            {
                str = str + cmd.main.ToLower()[i];
            }

            C2SChatCommon data = new C2SChatCommon();
            data.type = GameConst.CHAT_BCAST_ALL;
            data.info = new PkgChatC2S();
            // data.info.voice_id = System.Text.Encoding.UTF8.GetBytes("0");
            data.info.content = System.Text.Encoding.UTF8.GetBytes(str);

            NetClient.GetBaseClient().SendData<C2SChatCommon>(NetMsg.MSG_CHAT_COMMON, data);
        }

        /// <summary>
        /// 通过主链接发送GM指令
        /// </summary>
        /// <param name="cmd"></param>
        public static void SendGMCommandThroughMajorConnect(DebugUI.Command cmd)
        {
            string str = "";
            for (int i = 2; i < cmd.main.ToLower().Length; i++)
            {
                str = str + cmd.main.ToLower()[i];
            }

            C2SChatCommon data = new C2SChatCommon();
            data.type = GameConst.CHAT_BCAST_ALL;
            data.info.content = System.Text.Encoding.UTF8.GetBytes(str);

            NetClient.GetBaseClient().SendData<C2SChatCommon>(NetMsg.MSG_CHAT_COMMON, data);
        }


        public static bool OnProcessCmd(DebugUI.Command cmd)
        {
            DebugUI debugUI = MainGame.DebugUI;

            string main = cmd.main;
            if (main.ToLower() [0] == 'c' && main.ToLower() [1] == ':')
            {
                if (((int)xc.Game.GetInstance().GameMode & (int)xc.Game.EGameMode.GM_Net) == (int)xc.Game.EGameMode.GM_Net)
                    SendGMCommandForDebugUI(cmd);
                else
                {
                    debugUI.PushLog("非联网模式无法发送聊天");
                    debugUI.PushLog(main.ToLower());
                }
                return true;
            }

            if(main.ToLower()[0] == 'x' && main.ToLower()[1] == ':')
            {
                if (((int)xc.Game.GetInstance().GameMode & (int)xc.Game.EGameMode.GM_Net) == (int)xc.Game.EGameMode.GM_Net)
                {
                    SendGMCommandThroughMajorConnect(cmd);
                }
            }


            return ToProcessCommand(main, cmd.paramArray, debugUI);
        }

        public static bool ToProcessCommand(string main, List<string> paramArray, DebugUI debugUI)
        {
            if (main.ToLower() == "h" || main.ToLower() == "help")
            {
                string desc = "常用GM指令如下:";
                debugUI.PushLog(desc);
                desc = "monster [type_id] [num] : 创建n个怪物";
                debugUI.PushLog(desc);
                desc = "playerai : 开启/关闭玩家ai";
                debugUI.PushLog(desc);
                return true;
            }
            else if (main.ToLower() == "playerai")
            {
                LocalPlayer act = (LocalPlayer)Game.GetInstance().GetLocalPlayer();

                if (act != null)
                {
                    bool aiEnable = act.GetAIEnable();
                    act.ActiveAI(!aiEnable);
                }
            }
            else if (main.ToLower() == "aoinum")
            {
                debugUI.DrawActorCount = !debugUI.DrawActorCount;
            }
            else if (main.ToLower() == "fsm_trace")
            {
                // 输入UnitID，开启或关闭状态调试
                // 第一个参数是UnitID的
                if (paramArray.Count == 3)
                {
                    UnitID uid = new UnitID();
                    uid.type = byte.Parse(paramArray[0]);
                    uid.obj_idx = uint.Parse(paramArray[1]);

                    Actor actor = ActorManager.Instance.GetActor(uid);
                    if (actor != null)
                    {
                        actor.FSM.bIsDebug = !actor.FSM.bIsDebug;
                        return true;
                    }
                }
            }
            else if (main.ToLower() == "fsm_getcurstate")
            {
                // 输入UnitID，开启或关闭状态调试
                // 第一个参数是UnitID的type, 第二个是serial_idx, 第三个是obj_idx
                if (paramArray.Count == 3)
                {
                    UnitID uid = new UnitID();
                    uid.type = byte.Parse(paramArray[0]);
                    uid.obj_idx = uint.Parse(paramArray[1]);

                    Actor actor = ActorManager.Instance.GetActor(uid);
                    if (actor != null)
                    {
                        string name = actor.FSM.GetCurState().Name;
                        debugUI.PushLog("CurState: " + name);

                        return true;
                    }
                }
            }
            else if (main.ToLower() == "localplayerid")
            {
                debugUI.PushLog("type:" + Game.GetInstance().LocalPlayerID.type +
                    ",obj_id:" + Game.GetInstance().LocalPlayerID.obj_idx);
                return true;
            }
            else if (main.ToLower() == "attackspeed")
            {
                float fSpeed = 1.0f;
                if (paramArray.Count >= 1)
                {
                    if (paramArray[0] != "")
                        fSpeed = float.Parse(paramArray[0]);
                }

                Game.GetInstance().GetLocalPlayer().AttackSpeed = fSpeed;
                return true;
            }
            else if (main.ToLower() == "movespeed")
            {
                float fSpeed = 1.0f;
                if (paramArray.Count >= 1)
                {
                    if (paramArray[0] != "")
                        fSpeed = float.Parse(paramArray[0]);
                }

                Game.GetInstance().GetLocalPlayer().SetMoveSpeedScale(fSpeed, 0);
                return true;
            }
            else if (main.ToLower() == "clear")
            {
                debugUI.Clear();
                return true;
            }
            else if (main.ToLower() == "globalcfg")
            {
                if (paramArray.Count >= 2)
                {
                    try
                    {
                        xc.GlobalSettings settings = xc.GlobalSettings.GetInstance();
                        System.Reflection.FieldInfo[] fields = settings.GetType().GetFields();
                        foreach (System.Reflection.FieldInfo field in fields)
                        {
                            if (field.Name.ToLower() == paramArray[0].ToLower())
                            {
                                if (field.FieldType == typeof(bool))
                                {
                                    field.SetValue(settings, bool.Parse(paramArray[1]));
                                    return true;
                                }
                                else if (field.FieldType == typeof(float))
                                {
                                    field.SetValue(settings, float.Parse(paramArray[1]));
                                    return true;
                                }
                                else if (field.FieldType == typeof(int))
                                {
                                    field.SetValue(settings, int.Parse(paramArray[1]));
                                    return true;
                                }

                                return true;
                            }
                        }
                    }
                    catch (System.Exception e)
                    {
                        GameDebug.Log(e.Message);
                    }
                }
            }
            else if (main.ToLower() == "test_voice")
            {
                AudioManager.Instance.PlayBattleSFX(GlobalConst.ResPath + "Sound/voice/Test4.ogg", SoundType.NPC);
                //AudioManager.Instance.PlayBattleSFX(GlobalConst.ResPath + "Sound/voice/Test2.ogg", SoundType.Voice);
                //AudioManager.Instance.PlayBattleSFX(GlobalConst.ResPath + "Sound/voice/Test3.ogg", SoundType.Voice);

                return true;
            }
            else if (main.ToLower() == "test_fight")
            {
                //LocalPlayerManager.Instance.TryShowFightRankAnim(100);
                int num = 0;
                for (var i = 0; i < paramArray.Count; i++)
                {
                    if (int.TryParse(paramArray[i], out num))
                    {
                        LocalPlayerManager.Instance.TryShowFightRankAnim(num);
                        ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_LOCALPLAYER_BATTLE_POWER_CHANGED, null); 
                    }
                }
                return true;
            }

            else if (main.ToLower() == "ip")
            {
                if (paramArray.Count >= 1)
                {
                    Game.GetInstance().ServerIP = paramArray[0];
                }

                if (paramArray.Count >= 2)
                {
                    Game.GetInstance().ServerPort = int.Parse(paramArray[1]);
                }
                return true;
            }
            else if (main.ToLower() == "pos")
            {
                LocalPlayer player = Game.GetInstance().GetLocalPlayer() as LocalPlayer;
                if (player != null)
                    debugUI.PushLog("Player Pos:" + player.transform.position);
                return true;
            }
            else if (main.ToLower() == "gl")
            {
                if (paramArray.Count > 0)
                {
                    int lv = 0;
                    if (int.TryParse(paramArray[0], out lv))
                    {
                        QualitySetting.GraphicLevel = lv;
                        return true;
                    }
                }
            }
            else if (main.ToLower() == "test")
            {
                // **** 临时测试命令
                int alpha = 0;
                if (paramArray.Count > 0)
                    int.TryParse(paramArray[0], out alpha);
                Game.GetInstance().GetLocalPlayer().Alpha = Mathf.Clamp01((float)(alpha / 255.0f));

                return true;
            }
            else if (main.ToLower() == "openallsys")
            {
                debugUI.ProcessCommand("c:#set_open&1");
                return true;
            }
            else if (main.ToLower() == "sleep_guide")
            {
                GuideManager.GetInstance().ForceToSleepGuide();
                return true;
            }
            else if (main.ToLower() == "sg")
            {
                GuideManager.GetInstance().ForceToSleepGuide();
                return true;
            }
            else if (main.ToLower() == "sleep_auto")
            {
                TaskHelper.IsAutoMainTask = false;
                return true;
            }
            else if (main.ToLower() == "sa")
            {
                TaskHelper.IsAutoMainTask = false;
                return true;
            }
            else if (main.ToLower() == "reset_guide")
            {
                GuideManager.GetInstance().ResetAllSysGuide();
                return true;
            }
            else if (main.ToLower() == "diaobao")
            {
                // sleep guide
                GuideManager.GetInstance().ForceToSleepGuide();
                /*xc.ui.UIMainmapSysOpenWindow.ShowSysOpenAnim = false;*/

                // lv max
                debugUI.ProcessCommand("c:#lv&70");

                // rich
                debugUI.ProcessCommand("c:#rich");

                // gm equip
                debugUI.ProcessCommand("c:#e_new&1000905&8");
                debugUI.ProcessCommand("c:#e_new&1000906&8");
            }
            else if (main.ToLower() == "test_equip&1")
            {
                //                 string str = GameConstHelper.GetString("GAME_TEST_ADD_EQUIPS1");
                //                 string[] strList = str.Split(',');
                //                 for (int i = 0; i < strList.Length; i++)
                //                 {
                //                     string str1 = strList[i].Replace(" ", "");
                //                     str1 = str1.Substring(1, str1.Length - 2);
                //                     debugUI.ProcessCommand(str1);
                //                 }
                debugUI.ProcessCommand("c:#add_goods&100001&1");
                debugUI.ProcessCommand("c:#add_goods&100002&1");
                debugUI.ProcessCommand("c:#add_goods&100003&1");
                debugUI.ProcessCommand("c:#add_goods&100004&1");
                debugUI.ProcessCommand("c:#add_goods&100005&1");
                debugUI.ProcessCommand("c:#add_goods&100006&1");
                debugUI.ProcessCommand("c:#add_goods&100007&1");
                debugUI.ProcessCommand("c:#add_goods&100008&1");
                debugUI.ProcessCommand("c:#add_goods&100009&1");
            }
            else if (main.ToLower() == "test_equip&2")
            {
                string str = GameConstHelper.GetString("GAME_TEST_ADD_EQUIPS2");
                string[] strList = str.Split(',');
                for (int i = 0; i < strList.Length; i++)
                {
                    string str1 = strList[i].Replace(" ", "");
                    str1 = str1.Substring(1, str1.Length - 2);
                    debugUI.ProcessCommand(str1);
                }
            }
            else if (main.ToLower() == "test_equip&3")
            {
                string str = GameConstHelper.GetString("GAME_TEST_ADD_EQUIPS3");
                string[] strList = str.Split(',');
                for (int i = 0; i < strList.Length; i++)
                {
                    string str1 = strList[i].Replace(" ", "");
                    str1 = str1.Substring(1, str1.Length - 2);
                    debugUI.ProcessCommand(str1);
                }
            }
            else if (main.ToLower() == "test_equip")
            {
                string str = GameConstHelper.GetString("GAME_TEST_ADD_EQUIPS");
                string[] strList = str.Split(',');
                for (int i = 0; i < strList.Length; i++)
                {
                    string str1 = strList[i].Replace(" ", "");
                    str1 = str1.Substring(1, str1.Length - 2);
                    debugUI.ProcessCommand(str1);
                }

                return true;
            }
            else if (main.ToLower() == "test_refining")
            {
                debugUI.ProcessCommand("c:#add_goods&30001&90");
                debugUI.ProcessCommand("c:#add_goods&30002&45");
                debugUI.ProcessCommand("c:#add_goods&30003&30");
                debugUI.ProcessCommand("c:#add_goods&30004&60");
                return true;
            }
            else if (main.ToLower() == "start_guide")
            {
                GuideManager.Instance.StartGuide(DBTextResource.ParseUI(paramArray[0]), null);
                return true;
            }
            else if (main.ToLower() == "open_sys")
            {
                foreach (var param in paramArray)
                {
                    SysConfigManager.Instance.ForceOpenSys(uint.Parse(param));
                }
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_NEW_WAITING_SYS, new CEventBaseArgs());

                return true;
            }
            else if (main.ToLower() == "close_sys")
            {
                foreach (var param in paramArray)
                {
                    SysConfigManager.Instance.ForceCloseSys(uint.Parse(param));
                }

                return true;
            }
            else if (main.ToLower().StartsWith("start_inst"))
            {
                if (paramArray.Count > 0)
                {
                    uint instanceId = DBTextResource.ParseUI_s(paramArray[0], 0);
                    SceneHelp.JumpToScene(instanceId);
                }
            }
            else if (main.ToLower().StartsWith("jump"))
            {
                if (paramArray.Count > 0)
                {
                    uint instanceId = DBTextResource.ParseUI_s(paramArray[0], 0);
                    SceneHelp.JumpToScene(instanceId);
                }
            }
            else if (main.ToLower().StartsWith("dialog"))
            {
                if (paramArray.Count > 0)
                {
                    uint dialogId = DBTextResource.ParseUI_s(paramArray[0], 0);
                    DialogManager.GetInstance().TriggerDialog(dialogId);
                }
            }
            else if (main.ToLower().StartsWith("ride_all"))
            {
                mTestRide = true;
                foreach (var item in ActorManager.Instance.PlayerSet)
                {

                    item.Value.mRideCtrl.RemotePlayerUsingRideId = 400001;
                    item.Value.mRideCtrl.RemotePlayerServerStatusRiding = true;

                }
                return true;
            }
            else if (main.ToLower().StartsWith("unride_all"))
            {
                mTestRide = false;
                foreach (var item in ActorManager.Instance.PlayerSet)
                {

                    item.Value.mRideCtrl.RemotePlayerServerStatusRiding = false;
                }
                return true;
            }
            else if (main.ToLower().StartsWith("exit"))
            {
                ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_EXITINSTANCE, null);
                return true;
            }
            else if (main.ToLower() == "fast_sys_open")
            {
                //                 xc.ui.UIMainmapSysOpenWindow.ShowSysOpenAnim = false;
                return true;
            }
            else if (main.ToLower().Equals("show_win"))
            {
                if (paramArray.Count > 2)
                {
                    int param_int = 0;
                    int param_int_2 = 0;
                    if (int.TryParse(paramArray[1], out param_int) && int.TryParse(paramArray[2], out param_int_2))
                    {
                        xc.ui.ugui.UIManager.Instance.ShowWindow(paramArray[0], param_int, param_int_2);
                    }
                }
                else if(paramArray.Count > 1)
                {
                    int param_int = 0;
                    if(int.TryParse(paramArray[1], out param_int))
                    {
                        xc.ui.ugui.UIManager.Instance.ShowWindow(paramArray[0], param_int);
                    }
                }
                else if (paramArray.Count > 0)
                {
                    //xc.ui.UIManager.Instance.UIMain.StartCoroutine(xc.ui.UIManager.GetInstance().ShowWindow(paramArray[0]));
                    xc.ui.ugui.UIManager.Instance.ShowWindow(paramArray[0]);
                }
                return true;
            }
            else if (main.ToLower().Equals("show_sys_win"))
            {
                if (paramArray.Count > 0)
                {
                    xc.ui.ugui.UIManager.Instance.ShowSysWindow(paramArray[0]);
                }
                return true;
            }
            else if (main.ToLower().Equals("close_win"))
            {
                if (paramArray.Count > 0)
                {
                    //xc.ui.UIManager.Instance.UIMain.StartCoroutine(xc.ui.UIManager.GetInstance().ShowWindow(paramArray[0]));
                    xc.ui.ugui.UIManager.Instance.CloseWindow(paramArray[0]);
                }
                return true;
            }
            else if (main.ToLower().Equals("close_sys_win"))
            {
                if (paramArray.Count > 0)
                {
                    xc.ui.ugui.UIManager.Instance.CloseSysWindow(paramArray[0]);
                }
                return true;
            }
            else if (main.ToLower().StartsWith("crashu"))
            {
                //becarefull!
                Debug.Log("crash c#");
                MainGame.HeartBehavior.StartCoroutine(CreateNewObject());
                return true;
            }
            else if (main.ToLower().StartsWith("hangup"))
            {
                //becarefull!
                System.Threading.Thread.Sleep(10000);
                return true;
            }
            else if (main.ToLower() == "test_lua")
            {
                //xc.ui.UIManager.Instance.ShowWindow("LuaTestWindow");
                var funcName = paramArray[0];
                var method = typeof(LuaTestMgr).GetMethod(funcName);
                if (method != null)
                {
                    method.Invoke(LuaTestMgr.Instance, null);
                }
                else
                {
                    GameDebug.LogError("Can not find method " + funcName + " in LuaTestMgr");
                }
                return true;
            }
            else if (main.ToLower() == "save_call")
            {
                //LuaBugFixMgr.SaveCallFile();
                return true;
            }
            else if (main.ToLower().StartsWith("play_movie"))
            {
#if UNITY_ANDROID || UNITY_IPHONE
                var path = paramArray[0];
                Handheld.PlayFullScreenMovie(path, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
#endif
                return true;
            }
            else if (main.ToLower() == "test_avatar")// 测试变身技能
            {
                uint type_id = 0;// 角色id
                if (paramArray.Count > 0)
                    uint.TryParse(paramArray[0], out type_id);

                var player = Game.Instance.GetLocalPlayer();
                if (player != null)
                {
                    //bool isShifted = player.mAvatarCtrl.IsShapeShift;
                    //player.mAvatarCtrl.ShapeShift(!isShifted, type_id, 0);
                    //player.mAvatarCtrl.ShapeShift(isShifted, type_id, 1);

                    player.BuffCtrl.AddBuff(20018, 3.0f);
                    player.BuffCtrl.AddBuff(23005, 5.0f);//test_avatar 19001
                }
                return true;
            }
            else if (main.ToLower() == "test_shift")// 测试变身技能
            {
                uint type_id = 0;// 角色id
                if (paramArray.Count > 0)
                    uint.TryParse(paramArray[0], out type_id);

                var player = Game.Instance.GetLocalPlayer();
                if (player != null)
                {
                    player.BuffCtrl.AddBuff(23005, 30.0f);
                    player.Kill();
                }
                return true;
            }

            else if (main.ToLower() == "fightingtip")
            {
                var str = paramArray[0];
                buffID = uint.Parse(str);

                new Utils.Timer((int)(20 * 1000f), true, 0.5f * 1000f, OnFightEffectTimer);
                return true;
            }
            else if (main.ToLower() == "clearcd")
            {
                uint skill_id = 0;// 角色id
                if (paramArray.Count > 0)
                    uint.TryParse(paramArray[0], out skill_id);

                Actor localplayer = Game.GetInstance().GetLocalPlayer();
                if (localplayer != null)
                {
                    localplayer.CDCtrl.RemoveCD(skill_id);
                }
                debugUI.ProcessCommand("c:#ignore_skill_cd");

                return true;
            }
            else if (main.ToLower() == "setskill")
            {
                uint skill_id = 0;// 技能id
                uint skill_pos = 0;// 技能pos
                if (paramArray.Count < 2)
                    return false;

                uint.TryParse(paramArray[0], out skill_id);
                uint.TryParse(paramArray[1], out skill_pos);

                SkillManager.Instance.SetOpeningSkill(DBCommandList.BtnToOPFlag(skill_pos), skill_id);
                return true;
            }
            else if (main.ToLower().StartsWith("float_tips"))
            {
                UINotice.Instance.ShowMessage(paramArray[0]);
                return true;
            }
            else if (main.ToLower().StartsWith("rolling_notice"))
            {
                UINotice.Instance.ShowRollingNotice(paramArray[0]);
                return true;
            }
            else if (main.ToLower().StartsWith("warnning"))
            {
                UINotice.Instance.ShowWarnning(paramArray[0]);
                return true;
            }
            else if (main.ToLower().StartsWith("danmu"))
            {
                UINotice.Instance.ShowDanmaku(paramArray[0]);
                return true;
            }
            else if (main.ToLower().StartsWith("bottom_message"))
            {
                UINotice.Instance.ShowBottomMessage(paramArray[0]);
                return true;
            }
            else if (main.ToLower().StartsWith("reloadui"))
            {
                string name = "";
                if (paramArray.Count > 0)
                {
                    name = paramArray[0];
                    xc.ui.ugui.UIManager.Instance.CloseWindow(name);
                    xc.ui.ugui.UIManager.Instance.ShowWindow(name);
                    return true;
                }
                else
                    return false;
            }
            else if (main.ToLower().StartsWith("pet_attack_parent_target"))
            {
                if (paramArray.Count > 0)
                {
                    int useParentTarget = DBTextResource.ParseI_s(paramArray[0], 0);
                    LocalPlayer localPlayer = Game.Instance.GetLocalPlayer() as LocalPlayer;
                    if (localPlayer != null)
                    {
                        Pet currentPet = localPlayer.GetPet();
                        if (currentPet != null)
                        {
                            BehaviourAI ai = currentPet.GetAI() as BehaviourAI;
                            if (ai != null && ai.RunningProperty != null)
                            {
                                if (useParentTarget == 0)
                                {
                                    ai.RunningProperty.IsAttackParentTarget = false;
                                }
                                else
                                {
                                    ai.RunningProperty.IsAttackParentTarget = true;
                                }
                            }
                        }
                    }
                }
            }
            else if (main.ToLower().Equals("p"))
            {
                TestUnit.DisplayDebugDraw = !TestUnit.DisplayDebugDraw;
                return true;
            }
            else if (main.ToLower() == "test_db")
            {
                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < 1; ++i)
                {
                    List<Dictionary<string, string>> ret = DBManager.Instance.QuerySqliteRow<string>(GlobalConfig.DBFile, "reward", "item_id", "100101");
                }
                GameDebug.LogRed("Db query time: " + stopwatch.ElapsedMilliseconds);
                stopwatch.Stop();
                stopwatch.Start();
                for (int i = 0; i < 1; ++i)
                {
                    string queryStr = string.Format("SELECT * FROM {0} WHERE {0}.{1} LIKE \"{2}__\"", "reward", "item_id", 1001);
                    List<Dictionary<string, string>> ret = DBManager.Instance.QuerySqliteRow(GlobalConfig.DBFile, "reward", queryStr);
                }
                GameDebug.LogRed("Db query time: " + stopwatch.ElapsedMilliseconds);
                return true;
            }
            else if (main.ToLower() == "notice_dlg")
            {
                if (paramArray.Count > 0)
                {
                    string text = paramArray[0];
                    xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, "", text, null, null);
                }
                else
                {
                    xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, "teset", null, null);
                }
                return true;
            }
            else if (main.ToLower() == "toggle_notice_dlg")
            {
                xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_Cancel_Toggle, "title", "content", null, null, null, null, "", "", "toggle_text", false);
                return true;
            }
            else if (main.ToLower() == "reload") // 重载表格
            {
                string table_name = "";
                if (paramArray.Count > 0)
                {
                    DBManager.Instance.ClearCache();
                    table_name = paramArray[0];
                    var table = DBManager.Instance.GetDB(table_name);
                    if(table != null)
                    {
                        table.Unload();
                        table.Load();
                    }
                }
                
                return true;
            }
            else if (main.ToLower() == "newskill")// 新技能的指令
            {
                uint skill_id = 0;
                if (paramArray.Count > 0)
                {
                    skill_id = uint.Parse(paramArray[0]);
                    SkillHoleManager.Instance.ClearSkill(skill_id);
                    SkillHoleManager.Instance.OpenNewSkill(skill_id);
                }

                return true;
            }
            else if (main.ToLower().Equals("hide_debug_ui"))
            {
                MainGame.HideDebugUI();
                return true;
            }
            else if (main.ToLower().Equals("hide_ui"))
            {
                MainGame.HideDebugUI();
                xc.ui.ugui.UIManager.Instance.ClearUI();
                return true;
            }
            else if (main.ToLower().Equals("hide_ui_and_hook"))
            {
                MainGame.HideDebugUI();
                xc.ui.ugui.UIManager.Instance.ClearUI();
                InstanceManager.Instance.SetOnHook(true);
                return true;
            }
            else if (main.ToLower().Equals("play_timeline"))
            {
                if (paramArray.Count > 0)
                {
                    uint id = uint.Parse(paramArray[0]);
                    TimelineManager.Instance.Play(id, null);
                }
                return true;
            }
            else if (main.ToLower().Equals("timeline_change_skin"))
            {
                if (paramArray.Count > 0)
                {
                    uint param = uint.Parse(paramArray[0]);
                    TimelineManager.Instance.changeSkin = param == 1;
                }
                return true;
            }
            else if (main.ToLower().Equals("play_timeline_and_jump"))
            {
                if (paramArray.Count > 1)
                {
                    uint id = uint.Parse(paramArray[0]);
                    uint instanceId = uint.Parse(paramArray[1]);
                    TimelineManager.Instance.Play(id, () =>
                    {
                        xc.SceneHelp.JumpToScene(instanceId);
                    });
                }
                return true;
            }
            else if (main.ToLower().Equals("preload_timeline"))
            {
                if (paramArray.Count > 0)
                {
                    uint id = uint.Parse(paramArray[0]);
                    TimelineManager.Instance.Preload(id);
                }
                return true;
            }
            else if (main.ToLower().Equals("st"))
            {
                TimelineManager.Instance.Stop();
                return true;
            }
            else if (main.ToLower().Equals("npc_unload_model"))
            {
                if (paramArray.Count > 0)
                {
                    uint id = uint.Parse(paramArray[0]);
                    NpcPlayer npc = NpcManager.Instance.GetNpcByNpcId(id);
                    if (npc != null)
                    {
                        npc.mAvatarCtrl.UnloadModel();
                    }
                }
                return true;
            }
            else if (main.ToLower().Equals("npc_reload_model"))
            {
                if (paramArray.Count > 0)
                {
                    uint id = uint.Parse(paramArray[0]);
                    NpcPlayer npc = NpcManager.Instance.GetNpcByNpcId(id);
                    if (npc != null)
                    {
                        npc.mAvatarCtrl.ReloadModel();
                    }
                }
                return true;
            }
            else if (main.ToLower().Equals("ui_delay"))
            {
                if (paramArray.Count < 0)
                    return false;
                float delay;
                float.TryParse(paramArray[0], out delay);
                if (delay >= 0)
                {
                    UIManager.Instance.MainCtrl.Delay = delay;
                }
                return true;
            }
            else if (main.ToLower().Equals("skip_sys_open") || main.ToLower().Equals("sso"))
            {
                SysConfigManager.Instance.SkipSysOpen = true;
                return true;
            }
            else if (main.ToLower() == "show_chip")// 显示碎片动画
            {
                if (paramArray.Count >= 2)
                {
                    uint goods_id = uint.Parse(paramArray[0]);
                    uint goods_num = uint.Parse(paramArray[1]);
                    xc.ui.ugui.UIManager.Instance.ShowWindow("UIBossFragmentsWindow", goods_id, goods_num);
                }
                return true;
            }
            else if (main.ToLower() == "show_pet")// 显示获得守护
            {
                if (paramArray.Count >= 1)
                {
                    uint pet_id = uint.Parse(paramArray[0]);
                    xc.ui.ugui.UIManager.Instance.ShowWindow("UIGetNewPetWindow", pet_id);
                }
                return true;
            }
            else if (main.ToLower() == "play_xihun")
            {
                string sound_path = "Assets/" + ResPath.Sound_ui_xihun;

                xc.AudioManager.DynamicAudioParam param = new xc.AudioManager.DynamicAudioParam();
                param.res_path = sound_path;
                param.is_loop = false;
                param.volume = 1;
                xihun_sound_id = xc.AudioManager.Instance.PlayAudio_dynamic_out(param);
                return true;
            }
            else if (main.ToLower() == "stop_xihun")
            {
                xc.AudioManager.Instance.StopAudio_dynamic(xihun_sound_id);
                return true;
            }
            else if(main.ToLower() == "show_mount")// 显示坐骑获得动画
            {
                if (paramArray.Count >= 1)
                {
                    uint mount_id = uint.Parse(paramArray[0]);
                    xc.ui.ugui.UIManager.Instance.ShowWindow("UIGetNewMountWindow", mount_id);
                }
                
            }
            else if (main.ToLower() == "set_mount")// 设置主角坐骑ID
            {
                if (paramArray.Count >= 1)
                {
                    uint mount_id = uint.Parse(paramArray[0]);
                    Actor local_player = xc.Game.Instance.GetLocalPlayer();
                    if (local_player != null)
                        local_player.MountId = mount_id;
                }

            }
            else if(main.ToLower() == "router")   //跳转
            {
                if (paramArray.Count == 1)
                {
                    uint sys_id = uint.Parse(paramArray[0]);
                    RouterManager.Instance.GenericGoToSysWindow(sys_id);
                }
                else if(paramArray.Count == 2)
                {
                    uint sys_id = uint.Parse(paramArray[0]);
                    uint param1 = uint.Parse(paramArray[1]);
                    RouterManager.Instance.GenericGoToSysWindow(sys_id, param1);
                }
            }
            else if (main.ToLower() == "pause_instance")// 暂停副本
            {
                InstanceHelper.PauseInstance();
            }
            else if (main.ToLower() == "resume_instance")// 恢复副本
            {
                InstanceHelper.ResumeInstance();
            }
            else if (main.ToLower().Equals("task_changed"))// fire一个任务变化的事件
            {
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_CHANGED, null);
                return true;
            }
            else if (main.ToLower().Equals("finish_task"))// fire一个完成任务的事件
            {
                if (paramArray.Count > 0)
                {
                    uint id = uint.Parse(paramArray[0]);
                    ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_FINISHED, new CEventBaseArgs(id));
                }
                return true;
            }
            else if (main.ToLower().Equals("cam_zoom"))// 拉近拉远摄像机
            {
                if (paramArray.Count > 0)
                {
                    float zoom = float.Parse(paramArray[0]);
                    if (Game.Instance.CameraControl != null)
                    {
                        Game.Instance.CameraControl.Zoom = zoom;
                    }
                }
                return true;
            }
            else if (main.ToLower().Equals("cam_fov"))// 拉近拉远摄像机
            {
                if (paramArray.Count > 0)
                {
                    float fov = float.Parse(paramArray[0]);
                    if (Game.Instance.CameraControl != null)
                    {
                        Game.Instance.CameraControl.FOV = fov;
                    }
                }
                return true;
            }
            else if (main.ToLower().Equals("cam_follow_dis"))// 拉近拉远摄像机
            {
                if (paramArray.Count > 0)
                {
                    float followDistance = float.Parse(paramArray[0]);
                    if (Game.Instance.CameraControl != null)
                    {
                        Game.Instance.CameraControl.FollowDistance = followDistance;
                    }
                }
                return true;
            }
            else if (main.ToLower().Equals("stop_navigate"))// 停止寻路
            {
                TargetPathManager.Instance.StopPlayerAndReset();
                return true;
            }
            else if (main.ToLower().Equals("large_num_float_tips"))// 大数字飘字
            {
                if (paramArray.Count > 0)
                {
                    ulong num = ulong.Parse(paramArray[0]);
                    uint decimalPlaces = 1;
                    if (paramArray.Count > 1)
                    {
                        decimalPlaces = uint.Parse(paramArray[1]);
                    }
                    UINotice.Instance.ShowMessage(xc.ui.UIWidgetHelp.GetLargeNumberString(num, decimalPlaces));
                }
                return true;
            }
            else if (main.ToLower().Equals("enter_guild_manor"))// 进入帮派领地
            {
                InstanceHelper.EnterGuildManor();
                return true;
            }
            else if (main.ToLower().Equals("fly"))// 主角瞬移
            {
                if (paramArray.Count > 1)
                {
                    float x = float.Parse(paramArray[0]);
                    float z = float.Parse(paramArray[1]);
                    Actor localPlayer = Game.Instance.GetLocalPlayer();
                    if (localPlayer != null)
                    {
                        localPlayer.MoveCtrl.SendFly(new Vector3(x, 0f, z));
                    }
                }
                return true;
            }
            else if (main.ToLower().Equals("-jumpscene"))// 跳场景动画测试
            {
                var local_player = Game.Instance.GetLocalPlayer();
                if (local_player != null)
                {
                    local_player.BeginJumpScene("jumpout");
                }

                return true;
            }
            else if (main.ToLower().Equals("posteffect"))// 后处理效果测试
            {
                WaterWaveEffect.Instance.Start(2.0f, null);

                return true;
            }
            else if (main.ToLower().Equals("lowfps"))// fps较低
            {
                ClientEventMgr.Instance.PostEvent((int)ClientEvent.CE_SETTING_LOW_FPS, null);

                return true;
            }
            else if (main.ToLower().Equals("event"))//
            {
                int eventId = 0;
                if (paramArray.Count > 0)
                {
                    eventId = int.Parse(paramArray[0]);
                }
                ClientEventMgr.GetInstance().FireEvent(eventId, null);
            }
            else if(main.ToLower().Equals("testdb"))
            {
                var buff_info = DBBuffSev.GetInstance().GetBuffInfo(25103);

                /*var db_stigmalv = DBManager.Instance.GetDB<DBStigmaLv>();
                var max_lv = db_stigmalv.GetMaxLevel(100001);
                var info = db_stigmalv.GetOneInfo(100001, 1);

                var text = DBConstText.GetText("GUILD_FIRE_DRINK_WINE_ROLLING_NOTICE");
                var random_text = DBConstText.GetRandomText("GUILD_FIRE_GET_MEAT_SYS_MSG_",3);
                var db_guildskill = DBManager.Instance.GetDB<DBGuildSkill>();
                var skill_info = db_guildskill.GetOneItem(1, 10);
                
                var dv_equip_attr = DBManager.Instance.GetDB<DBEquipAttr>();
                var a = dv_equip_attr.GetAttrData(993901);
                var b = dv_equip_attr.GetAttrDataByGroupId(9939);

                var d = DBSuitRefine.Instance.GetRefineListByPos(EEquipPos.POS_ARMOUR, 5);
                var s = DBSuitRefine.Instance.GetData("3_7_3");*/

                return true;
            }
            else if(main.ToLower().Equals("testdrop"))
            {
                //InstanceDropManager.Instance.DestroyAllDrops();

                var drop = new S2CNwarDrop();
                drop.em_id = 0;
                drop.drop_type = 1;
                for (int i = 0; i < 100; ++i)
                {
                    var give = new PkgDropGive();
                    give.oid = (uint)i + 1;
                    give.type = GameConst.GIVE_TYPE_GOODS;
                    give.gid = 1085;
                    give.num = 1;
                    give.time = Game.Instance.ServerTime;
                    give.name = System.Text.Encoding.UTF8.GetBytes("掉落归属者");
                    drop.drops.Add(give);
                }
                
                byte[] serialData = null;
                using (MemoryStream m = new MemoryStream())
                {
                    Serializer.Serialize<S2CNwarDrop>(m, drop);
                    m.Position = 0;

                    serialData = new byte[m.Length];
                    m.Read(serialData, 0, (int)m.Length);
                }

                Game.GetInstance().ProcessServerData(NetMsg.MSG_NWAR_DROP, serialData);
            }
            else if (main.ToLower().Equals("clear_drop"))
            {
                InstanceDropManager.Instance.DestroyAllDrops();
            }
            else if (main.ToLower().Equals("copy"))
            {
                if (paramArray.Count > 0)
                {
                    TextHelper.CopyTextToClipboard(paramArray[0]);
                }
            }
            else if (main.ToLower().Equals("test_download"))
            {
                if (paramArray.Count > 0)
                {
                    xpatch.http.Request httpRequest = new xpatch.http.Request();
                    httpRequest.Url = paramArray[0];
                    httpRequest.SavePath = Application.dataPath + "/../download";
                    httpRequest.ResumeSize = 0;
                    httpRequest.ExecuteDownload();
                }
            }
            else if (main.ToLower().Equals("log_msg"))
            {
                xc.Game.Instance.PackRecorder.EnableLogFile = true;
            }

            LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "LuaProcessDebugCommand", main, paramArray);

            return false;

        }

        static uint buffID = 1100;
        static void OnFightEffectTimer(float deltatime)
        {
            var player = Game.Instance.GetLocalPlayer();
            player.ShowBuffTip(buffID);
        }

        static IEnumerator CreateNewObject()
        {
            while (true)
            {
                for (int i=0; i< 1000; i++)
                {
                    new GameObject();
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}


