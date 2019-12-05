//-----------------------------------
// File: TransferHelper.cs
// Desc: 转职的辅助类，用于从lua中获取数据
// Author: XiongWei
// Date: 2018.7.7
//-----------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xc
{
    [wxb.Hotfix]
    public class TransferHelper
    {
        /// <summary>
        /// 转职成功界面展示完成
        /// </summary>
        public static bool HasFinishShowTransferSuc(uint transferLevel)
        {
            object[] param = { transferLevel };
            System.Type[] returnType = { typeof(bool) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TransferMgr_HasFinishShowTransferSuc", param, returnType);
            if (objs != null && objs.Length > 0 && objs[0] != null)
            {
                return (bool)objs[0];
            }
            return false;
        }

        /// <summary>
        /// 获取转职等级
        /// </summary>
        public static int GetTransferLevel()
        {
            object[] param = { };
            System.Type[] returnType = { typeof(int) };
            object[] objs = LuaScriptMgr.Instance.CallLuaFunction_return(LuaScriptMgr.Instance.Lua.Global, "TransferMgr_GetTransferLevel", param, returnType);
            if (objs != null && objs.Length > 0)
            {
                if (objs[0] != null)
                {
                    return (int)objs[0];
                }
            }
            return 0;
        }

        /// <summary>
        /// return  是否巅峰
        /// currentLevel    当前等级
        /// transferLevel   当前转职等级
        /// </summary>
        public static bool IsPeak(uint currentLevel, uint transferLevel = 999)
        {
            bool isAwaken = transferLevel == 999 || transferLevel >= GameConstHelper.GetUint("GAME_TRANSFER_PEAK_TRANS_LV_BASE");
            return isAwaken && currentLevel > GameConstHelper.GetUint("GAME_TRANSFER_PEAK_LV_BASE");
        }

        /// <summary>
        /// return 是否巅峰
        /// currentLevel    当前等级
        /// transferLevel   当前转职等级
        /// peakLevel会被赋值为巅峰等级,如果不是巅峰，peakLevel是当前等级
        /// </summary>
        public static bool IsPeak(uint currentLevel, out uint peakLevel, uint transferLevel = 999)
        {
            bool isAwaken = transferLevel == 999 || transferLevel >= GameConstHelper.GetUint("GAME_TRANSFER_PEAK_TRANS_LV_BASE");
            bool isPeak = isAwaken && currentLevel > GameConstHelper.GetUint("GAME_TRANSFER_PEAK_LV_BASE");
            if (isPeak)
            {
                peakLevel = currentLevel - GameConstHelper.GetUint("GAME_TRANSFER_PEAK_LV_BASE");
            }
            else
            {
                peakLevel = currentLevel;
            }
            return isPeak;
        }

        /// <summary>
        /// 自己是否巅峰
        /// </summary>
        public static bool IsSelfPeak()
        {
            bool isAwaken = GetTransferLevel() >= GameConstHelper.GetUint("GAME_TRANSFER_PEAK_TRANS_LV_BASE");
            return isAwaken && LocalPlayerManager.Instance.Level > GameConstHelper.GetUint("GAME_TRANSFER_PEAK_LV_BASE");
        }

        /// <summary>
        /// 自己是否巅峰
        /// peakLevel会被赋值为巅峰等级,如果不是巅峰，peakLevel是当前等级
        /// </summary>
        public static bool IsSelfPeak(out uint peakLevel)
        {
            bool isAwaken = GetTransferLevel() >= GameConstHelper.GetUint("GAME_TRANSFER_PEAK_TRANS_LV_BASE");
            uint currentLevel = LocalPlayerManager.Instance.Level;
            bool isPeak = isAwaken && currentLevel > GameConstHelper.GetUint("GAME_TRANSFER_PEAK_LV_BASE");
            if (isPeak)
            {
                peakLevel = currentLevel - GameConstHelper.GetUint("GAME_TRANSFER_PEAK_LV_BASE");
            }
            else
            {
                peakLevel = currentLevel;
            }
            return isPeak;
        }
    }
}
