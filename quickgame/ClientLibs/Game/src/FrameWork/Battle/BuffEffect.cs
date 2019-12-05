using UnityEngine;
using System.Collections.Generic;

namespace xc
{
    /// <summary>
    /// 状态标记的判断
    /// </summary>
    public class FlagOperate
    {
        /// <summary>
        /// kSrcState具备kTargetState中的标记
        /// </summary>
        public static bool HasFlag(int kSrcState, int kTargetState)
        {
            return (kSrcState & kTargetState) != 0;
        }
        
        public static bool HasFlag(uint kSrcState, uint kTargetState)
        {
            return (kSrcState & kTargetState) != 0;
        }

        // <summary>
        /// 将kTargetState标记增加到kSrcState中
        /// </summary>
        public static int AddFlag(int kSrcState, int kAddFlag)
        {
            kSrcState |= kAddFlag;           
            return kSrcState;
        }

        // <summary>
        /// 将kRemoveFlag标记从kSrcState中移除
        /// </summary>
        public static int RemoveFlag(int kSrcState, int kRemoveFlag)
        {
            kSrcState &= (~kRemoveFlag);
            return kSrcState;
        }
    }

    [wxb.Hotfix]
    public class BuffEffect
    {
        /// <summary>
        /// buff开始时增加战斗状态
        /// </summary>
        public static void BattleStateChangeBegin(Buff buff, Buff.BuffInfo buff_info)
        {
            if (buff == null || buff_info == null)
                return;

            Actor actor = buff.Target_P;
            if (actor != null)
                actor.GetBehavior<BattleStateBehavior>().AddBattleState(buff_info.battle_effect_type);
        }

        /// <summary>
        /// buff结束后移除战斗状态
        /// </summary>
        public static void BattleStateChangeEnd(Buff buff, Buff.BuffInfo buff_info)
        {
            if (buff == null || buff_info == null)
                return;

            Actor actor = buff.Target_P;
            if (actor != null)
                actor.GetBehavior<BattleStateBehavior>().RemoveBattleState(buff_info.battle_effect_type);
        }

        /// <summary>
        /// buff开始时进行变身
        /// </summary>
        /// <param name="buff"></param>
        /// <param name="type_id"></param>
        public static void ShapeShiftBegin(Buff buff, Buff.BuffInfo buff_info)
        {
            if (buff == null || buff_info == null)
                return;

            if (buff.ShiftExcept)
                return;

            Actor actor = buff.Target_P;
            if (actor != null)
                actor.mAvatarCtrl.ShapeShift(true, buff_info.shape_shift, buff_info.shift_state);
        }

        /// <summary>
        /// buff结束后取消变身
        /// </summary>
        public static void ShapeShiftEnd(Buff buff, Buff.BuffInfo buff_info)
        {
            if (buff == null || buff_info == null)
                return;

            if (buff.ShiftExcept)
                return;

            Actor actor = buff.Target_P;
            if (actor != null)
                actor.mAvatarCtrl.ShapeShift(false, buff_info.shape_shift, buff_info.shift_state);
        }
    }
}