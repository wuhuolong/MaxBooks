using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using xc.ui.ugui;

namespace xc
{
    [wxb.Hotfix]
    public class RouterManager : xc.Singleton<RouterManager>
    {
        public delegate bool OpenSysWindowDelegate(params object[] args);
        protected Dictionary<uint, OpenSysWindowDelegate> RouterDict;

        //--------------------------------------------------------
        //  构造函数
        //--------------------------------------------------------
        public RouterManager()
        {
            RouterDict = new Dictionary<uint, OpenSysWindowDelegate>();
            RegisterRouter(GameConst.SYS_OPEN_ROLE, GoToPlayerMainWnd);
            RegisterRouter(GameConst.SYS_OPEN_MAIL, GoToMailWnd);
            RegisterRouter(GameConst.SYS_OPEN_BAG, GoToBagWnd);
            RegisterRouter(GameConst.SYS_OPEN_SKILL, GoToSkillWnd);
            RegisterRouter(GameConst.SYS_OPEN_FRIEND, GoToFriendsWnd);
            RegisterRouter(GameConst.SYS_OPEN_STRENGTH, GoToEquipStrength);
            RegisterRouter(GameConst.SYS_OPEN_BAPTIZE, GoToEquipBaptize);
            RegisterRouter(GameConst.SYS_OPEN_GEM, GoToEquipGem);
            RegisterRouter(GameConst.SYS_OPEN_SUIT, GoToEquipSuit);
            //RegisterRouter(GameConst.SYS_OPEN_SUIT_REFINE, GoToEquipSuitRefine);
            RegisterRouter(GameConst.SYS_OPEN_GUILD, GoToGuildWnd);
            RegisterRouter(GameConst.SYS_OPEN_SOUL, GotoSoulWnd);
            RegisterRouter(GameConst.SYS_OPEN_SETTING, GotoSettingWnd);
            RegisterRouter(GameConst.SYS_OPEN_SOUL_TOWN, GotoSoulTownWnd);
            RegisterRouter(GameConst.SYS_OPEN_PET, GotoPetWnd);
            RegisterRouter(GameConst.SYS_OPEN_MAP, GotoMapWnd);
            RegisterRouter(GameConst.SYS_OPEN_PLAYING, GotoPlayIngWnd);
            RegisterRouter(GameConst.SYS_OPEN_WELFARE, GotoWelfareWnd);
            RegisterRouter(GameConst.SYS_OPEN_DEAD_SPACE, GotoDeadSpace);
            //RegisterRouter(GameConst.SYS_OPEN_RIDE, GotoOpenRide);
            RegisterRouter(GameConst.SYS_OPEN_REC_SG, GotoBountyTask);
            RegisterRouter(GameConst.SYS_OPEN_SHOP, GotoShopWnd);
            RegisterRouter(GameConst.SYS_OPEN_GUILD_BOSS, GotoGuildBoss);
            RegisterRouter(GameConst.SYS_OPEN_QUEST_GUILD, GotoGuildTask);
            //RegisterRouter(GameConst.SYS_OPEN_WORLD_BOSS, GotoWorldBoss);
            RegisterRouter(GameConst.SYS_OPEN_TRIAL_BOSS, GotoTrialBoss);
            RegisterRouter(GameConst.SYS_OPEN_RANK, GotoRank);
            RegisterRouter(GameConst.SYS_OPEN_TREASURE, GotoTreasure);
            RegisterRouter(GameConst.SYS_OPEN_CORSAIR, GotoCorsair);
            RegisterRouter(GameConst.SYS_OPEN_FAIRY_VALLEY, GotoFairyValley);
            RegisterRouter(GameConst.SYS_OPEN_WORSHIP_MEETING, GotoWorshipMeeting);
            //RegisterRouter(GameConst.SYS_OPEN_STIGMA, GotoStigma);
            RegisterRouter(GameConst.SYS_OPEN_FORGOTTEN_TOMB, GotoForgottenTomb);
            RegisterRouter(GameConst.SYS_OPEN_TRANSFER, GotoTransfer);
            RegisterRouter(GameConst.SYS_OPEN_DRAGON_FOREST, GotoOpenDragonForest);
            RegisterRouter(GameConst.SYS_OPEN_SOUTH_LAND, GotoOpenSouthLand);
            RegisterRouter(GameConst.SYS_OPEN_TARGET, GotoOpenTargetSys);
			RegisterRouter(GameConst.SYS_OPEN_LEAGUE_PRE_SHOW, GotoGuildLeaguePreview);
            RegisterRouter(GameConst.SYS_OPEN_LEAGUE_READY, GotoGuildLeague);
            RegisterRouter(GameConst.SYS_OPEN_LEAGUE_QUALIFY, GotoGuildLeague);
            RegisterRouter(GameConst.SYS_OPEN_LEAGUE, GotoGuildLeague);
            RegisterRouter(GameConst.SYS_OPEN_LEAGUE_PRIME, GotoGuildLeaguePrime);
            RegisterRouter(GameConst.SYS_OPEN_ARENA, GotoArena);
            RegisterRouter(GameConst.SYS_OPEN_SEVEN_GIFT, GotoSevenGift);
            RegisterRouter(GameConst.SYS_OPEN_SECRET_DEFEND, GotoSecretDefend);
            RegisterRouter(GameConst.SYS_OPEN_GUILD_FIRE, GotoGuildFire);
            //RegisterRouter(GameConst.SYS_OPEN_RAIN_RED_PACKET, GotoGuilRainRedPacket);
            RegisterRouter(GameConst.SYS_OPEN_CHOSEN_BUY, GotoCloudBuy);
            RegisterRouter(GameConst.SYS_OPEN_TREASURE_HOME, GotoTreasureHome);
            RegisterRouter(GameConst.SYS_OPEN_QUEST, GotoQuest);
            RegisterRouter(GameConst.SYS_OPEN_OPEN_SERVER_ACT, GotoOpenServerAct);
            RegisterRouter(GameConst.SYS_OPEN_WING_INSTANCE, GotoWingInstance);
            RegisterRouter(GameConst.SYS_OPEN_EQUIP_COMPOSE, GotoEquipCompose);
            RegisterRouter(GameConst.SYS_OPEN_GOD_GOODS_COMPOSE, GotoGodGoodsCompose);
            RegisterRouter(GameConst.SYS_OPEN_BATTLE_HALL, GotoBattleHall);
            RegisterRouter(GameConst.SYS_OPEN_EXCHANGE_MALL, GotoExchangeMall);
            RegisterRouter(GameConst.SYS_OPEN_EQUIP_EXCHANGE, GotoEquipExchange);
            RegisterRouter(GameConst.SYS_OPEN_SOUL_EXCHANGE, GotoSoulExchange);
            RegisterRouter(GameConst.SYS_OPEN_INSTANCE_HALL, GotoInstanceHall);
        }

        ~RouterManager ()
        {

        }

        #region Open Window
        public bool CheckSysDownloaded(uint sys_id)
        {
            int patch_id;
            if (!SysConfigManager.Instance.CheckSysHasDownloaded(sys_id, out patch_id))
            {
                //需要下载最新资源才能体验当前内容
                var content = DBConstText.GetText("DOWNLOAD_PATCH_TIPS");
                ui.UIWidgetHelp.Instance.ShowNoticeDlg(ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, content,
                        (param) => { ui.ugui.UIManager.Instance.ShowSysWindow("UIPatchWindow", patch_id); }, null);
                return false;
            }

            return true;
        }

        public bool GenericGoToSysWindow(uint sys_id, params object[] args)
        {
            //先判断是否有下拉系统列表
            DBSysConfig.SysConfig config = DBSysConfig.Instance.GetConfigById(sys_id);
            if (config.DropDown != null && config.DropDown.Count > 0)
            {
                if (!SysConfigManager.GetInstance().CheckSysHasOpened(sys_id, true))
                {
                    return false;
                }
                if (!CheckSysDownloaded(sys_id))
                {
                    return false;
                }

                if (config.DropDownType == 0)
                {
                    UIManager.GetInstance().ShowWindow("UISysDropDownWindow", sys_id, args);
                }
                else if(config.DropDownType == 1)
                {
                    //只有韩国版开放
                    if (Const.Region == RegionType.KOREA)
                    {
                        UIManager.GetInstance().ShowWindow("UIActivityEntryWindow", sys_id, args);
                    }
                }

                return true;
            }

            //只有韩国版开放
            if (Const.Region == RegionType.KOREA)
            {
                //如果是正常跳转到系统界面，需要关闭下拉窗
                if (UIManager.GetInstance().GetWindow("UISysDropDownWindow") != null)
                    UIManager.GetInstance().CloseWindow("UISysDropDownWindow");
                if (UIManager.GetInstance().GetWindow("UIActivityEntryWindow") != null)
                    UIManager.GetInstance().CloseWindow("UIActivityEntryWindow");
            }

            //再执行正常流程
            OpenSysWindowDelegate dlg;
            if (RouterDict.TryGetValue(sys_id, out dlg))
            {
                dlg(args);
            }
            else
            {
                UINotice.Instance.ShowMessage(xc.DBConstText.GetText("MODULE_IS_DEVELOPING"));
                GameDebug.LogError(string.Format("没有配置系统({0})的点击事件！", sys_id));
            }

            return true;
        }

        public void RegisterRouter(uint sys_type, OpenSysWindowDelegate dlg)
        {
            RegisterRouterById((uint)sys_type, dlg);
        }

        public void RegisterRouterById(uint sys_id, OpenSysWindowDelegate dlg)
        {
            if(!RouterDict.ContainsKey(sys_id))
                RouterDict[sys_id] = dlg;
        }

        public bool GoToBagWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_BAG, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_BAG))
            {
                return false;
            }
            UIManager.Instance.ShowSysWindow("UIBagWindow");
            return true;
        }

        /// <summary>
        /// show mail window.
        /// </summary>
        /// <returns><c>true</c>, if to mail window was create, <c>false</c> otherwise.</returns>
        public bool GoToMailWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(2, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(2))
            {
                return false;
            }
            //             var friendManagerWindow = UIManager.Instance.GetWindow<UIFriendsManagerWindow>(true);
            //             friendManagerWindow.ShowMailPage();
            return true;
        }

        public bool GoToSkillWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SKILL, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SKILL))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UISkillWindow");
            return true;
        }

        public bool GoToFriendsWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_FRIEND, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_FRIEND))
            {
                return false;
            }
            UIManager.Instance.ShowSysWindow("UIFriendSystemWindow", "Friend");
            return true;
        }

        public bool GoToChatWindow(params object[] args)
        {
//             if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_FRIEND, true))
//             {
//                 return false;
//             }

            UIManager.GetInstance().ShowSysWindow("UIChatWindow");

            return true;
        }

        public bool GoToPlayerMainWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_ROLE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_ROLE))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIPlayerPropertyWindow");
            return true;
        }

        public bool GotoSoulWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SOUL, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SOUL))
            {
                return false;
            }
            UIManager.Instance.ShowSysWindow("UISpiritRunesWindow", args);
            return true;
        }

        /// <summary>
        /// 打开设置系统
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool GotoSettingWnd(params object[] args)
        {
            UIManager.Instance.ShowSysWindow("UISettingMainWindow");
            return true;
        }

        public bool GotoSoulTownWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SOUL_TOWN, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SOUL_TOWN))
            {
                return false;
            }
            if (SceneHelp.Instance.IsKungfuInstance == false)
            {
                UIManager.Instance.ShowSysWindow("UIKungfuGodWindow");
            }
            else
            {
                xc.UINotice.Instance.ShowMessage(DBConstText.GetText("INSTANCE_ALREADY_IN_IT"));
            }
            return true;
        }


        public bool GotoPetWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_PET, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_PET))
            {
                return false;
            }
            UIManager.Instance.ShowSysWindow("UIPetWindow");
            return true;
        }

        /// <summary>
        /// 跳转到地图界面
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool GotoMapWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_MAP, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_MAP))
            {
                return false;
            }
            UIManager.Instance.ShowSysWindow("UIMapWindow", args);
            return true;
        }

        /// <summary>
        /// 打开玩法系统
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool GotoPlayIngWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_PLAYING, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_PLAYING))
            {
                return false;
            }
            if (args.Length == 1)
            {
                UIManager.Instance.ShowSysWindow("UITowerClimbWindow", GameConst.SYS_OPEN_PLAYING, args[0]);
            }
            else
            {
                UIManager.Instance.ShowSysWindow("UITowerClimbWindow");
            }
            return true;
        }

        /// <summary>
        /// 打开福利系统
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool GotoWelfareWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_WELFARE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_WELFARE))
            {
                return false;
            }
            UIManager.Instance.ShowSysWindow("UIWelfareWindow");
            return true;
        }

        /// <summary>
        /// 打开商城系统
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool GotoShopWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SHOP, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SHOP))
            {
                return false;
            }
            LuaScriptMgr.Instance.CallLuaFunction(LuaScriptMgr.Instance.Lua.Global, "MallHelper_OnOpenMallAndSelectItem", args);
            return true;
        }

        
        public bool GoToGuildWnd(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_GUILD, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_GUILD))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIGuildWindow");
            return true;
        }

        public bool GotoTrialBoss(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_TRIAL_BOSS, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_TRIAL_BOSS))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIInstanceHallWindow", GameConst.SYS_OPEN_TRIAL_BOSS);
            return true;
        }

        public bool GotoRank(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_RANK, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_RANK))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIRankListWindow", args);
            return true;
        }

        public bool GotoTreasure(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_TREASURE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_TREASURE))
            {
                return false;
            }

            UIManager.GetInstance().CloseWindow("UIOpenBossTipsWindow");
            UIManager.GetInstance().ShowSysWindow("UITreasureWindow");

            return true;
        }

        public bool GotoCorsair(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_CORSAIR, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_CORSAIR))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIInstanceHallWindow", GameConst.SYS_OPEN_CORSAIR);
            return true;
        }

        public bool GotoFairyValley(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_FAIRY_VALLEY, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_FAIRY_VALLEY))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIInstanceHallWindow", GameConst.SYS_OPEN_FAIRY_VALLEY);
            return true;
        }

        public bool GotoWorshipMeeting(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_WORSHIP_MEETING, true))
            {
                return false;
            }
            if (!ActivityHelper.IsActivityOpen(GameConst.SYS_OPEN_WORSHIP_MEETING, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_WORSHIP_MEETING))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIWorshipMeetingEnterWindow");
            return true;
        }

//         public bool GotoStigma(params object[] args)
//         {
//             if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_STIGMA, true))
//             {
//                 return false;
//             }
//             if (!CheckSysDownloaded(GameConst.SYS_OPEN_STIGMA))
//             {
//                 return false;
//             }
//             UIManager.GetInstance().ShowSysWindow("UIPlayerPropertyWindow", "StigmataTab");
//             return true;
//         }

        public bool GotoForgottenTomb(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_FORGOTTEN_TOMB, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_FORGOTTEN_TOMB))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIInstanceHallWindow", GameConst.SYS_OPEN_FORGOTTEN_TOMB);
            return true;
        }

        public bool GotoTransfer(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_TRANSFER, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_TRANSFER))
            {
                return false;
            }
            if (args.Length == 1 && args[0].ToString() == "2801")   //使用龙珠
            {
                List<string> levels = DBManager.Instance.QuerySqliteField<string>(GlobalConfig.DBFile, "data_transfer", "id", "4", "open_lv");
                if (TransferHelper.GetTransferLevel() < 3 || LocalPlayerManager.Instance.LocalActorAttribute.Level < int.Parse(levels[0]))
                {
                    UINotice.Instance.ShowMessage(xc.DBConstText.GetText("TRANSFER_USE_GOODS_LIMIT"));
                    return false;
                }
            }
            UIManager.GetInstance().ShowSysWindow("UITransferWindow");
            return true;
        }

        public bool GotoOpenDragonForest(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_DRAGON_FOREST, true))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIDragonForestEnterWindow");
            return true;
        }

        public bool GotoGuildBoss(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_GUILD_BOSS, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_GUILD_BOSS))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIGuildWindow", "GUILD_BOSS");
            return true;
        }

//         public bool GotoWorldBoss(params object[] args)
//         {
//             if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_WORLD_BOSS, true))
//             {
//                 return false;
//             }
//             if (!CheckSysDownloaded(GameConst.SYS_OPEN_WORLD_BOSS))
//             {
//                 return false;
//             }
//             UIManager.GetInstance().ShowSysWindow("UITreasureWindow", "UIWorldBossWindow");
//             return true;
//         }

        public bool GoToEquipStrength(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_STRENGTH, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_STRENGTH))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIEquipmentWindow", "Strength");
            return true;
        }

        public bool GoToEquipBaptize(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_BAPTIZE, true)|| !SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_STRENGTH, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_BAPTIZE) || !CheckSysDownloaded(GameConst.SYS_OPEN_STRENGTH))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIEquipmentWindow", "Wash");
            return true;
        }


        public bool GoToEquipGem(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_GEM, true) || !SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_STRENGTH, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_GEM) || !CheckSysDownloaded(GameConst.SYS_OPEN_STRENGTH))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIEquipmentWindow", "Gem");
            return true;
        }


        public bool GoToEquipSuit(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SUIT, true) || !SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_STRENGTH, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SUIT) || !CheckSysDownloaded(GameConst.SYS_OPEN_STRENGTH))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIEquipmentWindow", "SetEquip");
            return true;
        }

        public bool GoToEquipSuitRefine(params object[] args)
        {
            //if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SUIT_REFINE, true) 
            //    || !SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SUIT, true))
            //{
            //    return false;
            //}

            //if (!CheckSysDownloaded(GameConst.SYS_OPEN_SUIT) || !CheckSysDownloaded(GameConst.SYS_OPEN_SUIT_REFINE))
            //{
            //    return false;
            //}

            //UIManager.GetInstance().ShowSysWindow("UIEquipmentWindow", "SuitRefine");

            return true;
        }

        public bool GotoDeadSpace(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_DEAD_SPACE, true))
            {
                return false;
            }
            if (!ActivityHelper.IsActivityOpen(GameConst.SYS_OPEN_DEAD_SPACE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_DEAD_SPACE))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIDeadSpaceEnterWindow");
            return true;
        }

//         public bool GotoOpenRide(params object[] args)
//         {
//             if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_RIDE, true))
//             {
//                 return false;
//             }
//             if (!CheckSysDownloaded(GameConst.SYS_OPEN_RIDE))
//             {
//                 return false;
//             }
// 
//             if (LuaScriptMgr.Instance != null)
//             {
//                 XLua.LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction(LuaScriptMgr.Instance.Lua.Global, "GotoSysRouter");
//                 if (func != null)
//                 {
//                     func.Action(GameConst.SYS_OPEN_RIDE);
//                 }
//                 return true;
//             }
//             return false;
//         }

        public bool GotoBountyTask(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_REC_SG, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_REC_SG))
            {
                return false;
            }

            if (args.Length == 1 && (bool)args[0] == true)
            {
                UIManager.Instance.ShowSysWindow("UITaskWindow", GameConst.QUEST_SG, null);
                return true;
            }

            // 记录当弹出退出提示的时候是否要继续自动战斗
            if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
            {
                SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
            }

            //UIManager.GetInstance().ShowSysWindow("UITaskWindow", xc.GameConst.QUEST_SG, null);
            BountyTaskInfo bountyTaskInfo = TaskManager.Instance.BountyTaskInfo;
            List<Task> tasks = TaskManager.Instance.VisibleBountyTasks;
            bool isGoto = false;
            if (bountyTaskInfo == null)
            {
                isGoto = false;
            }
            else
            {
                if (tasks.Count > 0)
                {
                    isGoto = true;
                }
                else
                {
                    isGoto = false;
                }
            }
            if (isGoto == true)
            {
                TaskHelper.TaskGuide(tasks[0]);
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.TASK_CHANGED, null);
            }
            else
            {
                if (bountyTaskInfo == null)
                {
                    TaskHelper.AcceptBountyTaskGuide();
                }
                else
                {
                    uint maxTimes = TaskHelper.GetBountyTaskMaxTimes();
                    if (bountyTaskInfo.num >= maxTimes)
                    {
                        UIManager.Instance.ShowSysWindow("UITaskWindow", GameConst.QUEST_SG, null);
                    }
                    else
                    {
                        TaskHelper.AcceptBountyTaskGuide();
                    }
                }
            }
            UIManager.Instance.CloseSysWindow("UITowerClimbWindow");

            return true;
        }

        public bool GotoGuildTask(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_QUEST_GUILD, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_QUEST_GUILD))
            {
                return false;
            }

            // 记录当弹出退出提示的时候是否要继续自动战斗
            if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
            {
                SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
            }

            GuildTaskInfo guildTaskInfo = TaskManager.Instance.GuildTaskInfo;
            List<Task> tasks = TaskManager.Instance.VisibleGuildTasks;
            bool isGoto = false;
            if (guildTaskInfo == null)
            {
                isGoto = false;
            }
            else
            {
                if (tasks.Count > 0)
                {
                    isGoto = true;
                }
                else
                {
                    isGoto = false;
                }
            }
            if (isGoto == true)
            {
                TaskHelper.TaskGuide(tasks[0]);
            }
            else
            {
                if (guildTaskInfo != null && guildTaskInfo.reward_state == 1)
                {
                    xc.ui.ugui.UIManager.Instance.ShowSysWindow("UITaskWindow", xc.GameConst.QUEST_GUILD, null);
                }
                else
                {
                    TaskHelper.AcceptGuildTaskGuide();
                }
            }
            UIManager.Instance.CloseSysWindow("UITowerClimbWindow");

            return true;
        }

        public bool GotoOpenSouthLand(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SOUTH_LAND, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SOUTH_LAND))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UITreasureWindow", "UISouthLandWindow");
            return true;
        }

        public bool GotoOpenTargetSys(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_TARGET, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_TARGET))
            {
                return false;
            }

            UIManager.GetInstance().ShowSysWindow("UITargetWindow");
            return true;
        }

        public bool GotoGuildLeaguePreview(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_LEAGUE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_LEAGUE))
            {
                return false;
            }

            //UIManager.GetInstance().ShowSysWindow("UIGuildWindow", "GUILD_LEAGUE");
            UIManager.GetInstance().ShowWindow("UIGuildWarFunctionNoticeWindow");
            return true;
        }


        public bool GotoGuildLeague(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_LEAGUE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_LEAGUE))
            {
                return false;
            }

            UIManager.GetInstance().ShowSysWindow("UIGuildWindow", "GUILD_LEAGUE");
            return true;
        }

        public bool GotoGuildLeaguePrime(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_LEAGUE_PRIME, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_LEAGUE_PRIME))
            {
                return false;
            }

            UIManager.GetInstance().ShowSysWindow("UIGuildLeaguePrimeGuildWindow");
            return true;
        }

        public bool GotoArena(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_ARENA, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_ARENA))
            {
                return false;
            }
            if (!ActivityHelper.IsActivityOpen(GameConst.SYS_OPEN_ARENA, true))
            {
                return false;
            }

            UIManager.GetInstance().ShowSysWindow("UIArenaMainWindow");
            return true;
        }

        public bool GotoSevenGift(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SEVEN_GIFT, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SEVEN_GIFT))
            {
                return false;
            }

            UIManager.GetInstance().ShowSysWindow("UISevenDayGiftWindow");
            return true;
        }

        public bool GotoSecretDefend(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SECRET_DEFEND, true))
            {
                return false;
            }

            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SECRET_DEFEND))
            {
                return false;
            }

            UIManager.GetInstance().ShowSysWindow("UIInstanceHallWindow", GameConst.SYS_OPEN_SECRET_DEFEND);
            return true;
        }

        public bool GotoGuildFire(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_GUILD_FIRE, true))
            {
                return false;
            }

            if (!ActivityHelper.IsActivityOpen(GameConst.SYS_OPEN_GUILD_FIRE, true))
            {
                return false;
            }

            if (!CheckSysDownloaded(GameConst.SYS_OPEN_GUILD_FIRE))
            {
                return false;
            }

            if (LocalPlayerManager.Instance.GuildID > 0)
            {
                InstanceHelper.EnterGuildManor();
            }
            else
            {
                UIManager.GetInstance().ShowSysWindow("UIGuildWindow");
            }
            return true;
        }


        public bool GotoGuilRainRedPacket(params object[] args)
        {
            //if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_RAIN_RED_PACKET, true))
            //{
            //    return false;
            //}

            //if (!ActivityHelper.IsActivityOpen(GameConst.SYS_OPEN_RAIN_RED_PACKET, true))
            //{
            //    return false;
            //}

            if (!CheckSysDownloaded(GameConst.SYS_OPEN_RAIN_RED_PACKET))
            {
                return false;
            }

            if (LocalPlayerManager.Instance.GuildID > 0)
            {
                //InstanceHelper.EnterGuildManor();
                InstanceHelper.EnterGuildRainRedPacket();
            }
            else
            {
                UIManager.GetInstance().ShowSysWindow("UIGuildWindow");
            }
            return true;
        }

        public bool GotoCloudBuy(params object[] args)
        {
            if (!SysConfigManager.instance.CheckSysHasOpened(GameConst.SYS_OPEN_CHOSEN_BUY, true))
                return false;

            if (!CheckSysDownloaded(GameConst.SYS_OPEN_CHOSEN_BUY))
                return false;

            UIManager.instance.ShowSysWindow("UICloudBuyWindow");

            return true;
        }

        public bool GotoTreasureHome(params object[] args)
        {
            if (!SysConfigManager.instance.CheckSysHasOpened(GameConst.SYS_OPEN_TREASURE_HOME, true))
                return false;

            if (!CheckSysDownloaded(GameConst.SYS_OPEN_TREASURE_HOME))
                return false;

            UIManager.instance.ShowSysWindow("UITreasureHouseWindow");

            return true;
        }

        public bool GotoQuest(params object[] args)
        {
            if (!SysConfigManager.instance.CheckSysHasOpened(GameConst.SYS_OPEN_QUEST, true))
                return false;

            if (!CheckSysDownloaded(GameConst.SYS_OPEN_QUEST))
                return false;

            UIManager.instance.ShowSysWindow("UITaskWindow");

            return true;
        }

        public bool GotoOpenServerAct(params object[] args)
        {
            if (!SysConfigManager.instance.CheckSysHasOpened(GameConst.SYS_OPEN_OPEN_SERVER_ACT, true))
                return false;

            if (!CheckSysDownloaded(GameConst.SYS_OPEN_OPEN_SERVER_ACT))
                return false;

            UIManager.instance.ShowSysWindow("UIOpenServerActWindow", args);

            return true;
        }

        public bool GotoWingInstance(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_WING_INSTANCE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_WING_INSTANCE))
            {
                return false;
            }

            UIManager.Instance.ShowSysWindow("UIInstanceHallWindow", GameConst.SYS_OPEN_WING_INSTANCE);

            return true;
        }
        
        public bool GotoEquipCompose(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_EQUIP_COMPOSE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_EQUIP_COMPOSE))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIGoodsComposeWindow", "equip");
            return true;
        }

        
        public bool GotoGodGoodsCompose(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_GOD_GOODS_COMPOSE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_GOD_GOODS_COMPOSE))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIGoodsComposeWindow", "godGoods");
            return true;
        }

        public bool GotoBattleHall(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_BATTLE_HALL, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_BATTLE_HALL))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIBattleHallWindow");
            return true;
        }

        
        public bool GotoExchangeMall(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_EXCHANGE_MALL, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_EXCHANGE_MALL))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIExchangeMallWindow");
            return true;
        }

        public bool GotoEquipExchange(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_EQUIP_EXCHANGE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_EQUIP_EXCHANGE))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIExchangeMallWindow", GameConst.SYS_OPEN_EQUIP_EXCHANGE);
            return true;
        }

        public bool GotoSoulExchange(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_SOUL_EXCHANGE, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_SOUL_EXCHANGE))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIExchangeMallWindow", GameConst.SYS_OPEN_SOUL_EXCHANGE);
            return true;
        }

        public bool GotoInstanceHall(params object[] args)
        {
            if (!SysConfigManager.GetInstance().CheckSysHasOpened(GameConst.SYS_OPEN_INSTANCE_HALL, true))
            {
                return false;
            }
            if (!CheckSysDownloaded(GameConst.SYS_OPEN_INSTANCE_HALL))
            {
                return false;
            }
            UIManager.GetInstance().ShowSysWindow("UIInstanceHallWindow");
            return true;
        }

        #endregion

        public bool IsRegisterSysId(uint sys_id)
        {
            if (RouterDict.ContainsKey(sys_id))
                return true;
            return false;
        }
    }
}