//------------------------------------------------------------------------------
// Desc   :  结婚帮助类
// Author :  ljy
// Date   :  2018.11.8
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;
using Net;

namespace xc
{
    [wxb.Hotfix]
    public class MarryHelper
    {
        /// <summary>
        /// 前往结婚npc
        /// </summary>
        public static void GotoMarryNpcGuide()
        {
            // 记录当弹出退出提示的时候是否要继续自动战斗
            if (SceneHelp.Instance.IsInInstance == true || SceneHelp.Instance.IsCanExitBtnInWild == true)
            {
                SceneHelp.Instance.IsAutoFightingWhenShowExitTips = InstanceManager.Instance.IsAutoFighting || SceneHelp.Instance.IsAutoFightingWhenShowExitTips;
            }

            InstanceManager.Instance.IsAutoFighting = false;

            TaskManager.Instance.NavigatingTask = null;

            List<uint> npcParams = xc.GameConstHelper.GetUintList("GAME_MARRY_NPC");
            if (npcParams.Count > 1)
            {
                TargetPathManager.Instance.GoToNpcPos(npcParams[0], npcParams[1], null);
            }
            else
            {
                ui.ugui.UIManager.Instance.ShowSysWindow("UIMarryNPCWindow");
            }
        }

        /// <summary>
        /// 能否进入结婚场景
        /// </summary>
        public static bool CanJumpToMarryScene(bool needTips)
        {
            List<uint> npcParams = xc.GameConstHelper.GetUintList("GAME_MARRY_NPC");
            uint id = npcParams[0];
            var attr = LocalPlayerManager.Instance.LocalActorAttribute;
            var needLv = InstanceHelper.GetInstanceNeedRoleLevel(id);
            if (attr != null && attr.Level < needLv)
            {
                if(needTips)
                {
                    UINotice.Instance.ShowMessage(string.Format(DBConstText.GetText("MARRIAGE_LEVEL_NOT_ENOUGH"), needLv));
                    //UINotice.Instance.ShowMessage(string.Format("情缘岛地图{0}级开放，等级不足无法进入", needLv));
                }
                return false;
            }
            return true;
        }


        /// <summary>
        /// 执行触碰结婚npc，是结婚npc则返回true
        /// </summary>
        public static bool ProcessTouchMarryNpc(NpcPlayer npcPlayer)
        {
            if (NpcHelper.NpcCanOpenMarryWin((uint)npcPlayer.NpcData.Id) == true)
            {
                ui.ugui.UIManager.Instance.ShowSysWindow("UIMarryNPCWindow");
                return true;
            }

            return false;
        }

        public static void GetWeddingCoupleJobs(out uint job1, out uint job2)
        {
            job1 = 0;
            job2 = 0;

            object[] param = { };
            System.Type[] return_type = { typeof(uint), typeof(uint) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "WeddingMgr_GetCoupleJobs", param, return_type);
            if (objs != null && objs.Length > 1)
            {
                if (objs[0] != null)
                {
                    job1 = (uint)objs[0];
                }
                if (objs[1] != null)
                {
                    job2 = (uint)objs[1];
                }
            }
        }
    }
}
