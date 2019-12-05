//------------------------------------------------------------------------------
// Desc: 包含角色状态信息的组件
// Date: 2016.7.4
// Author: raorui
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    [wxb.Hotfix]
    public class BattleStateBehavior : IActorBehavior
    {
        // ------------------------------------------------
        // 接口的实现
        // ------------------------------------------------
        public override void InitBehaviors()
        {
            
        }
        
        public override void Update()
        {
            
        }

        
        public override void LateUpdate()
        {
            
        }
        

       
        // leaf
        public override void EnableBehaviors(bool enable)
        {
            
        }
        
        // ------------------------------------------------
        // 组件的类型定义
        // ------------------------------------------------
        
        
        // ------------------------------------------------
        // 组件的变量定义
        // ------------------------------------------------
        bool mbIsInFreeze;
        SafeInteger mLastBattleState = 0;
        SafeInteger mCurBattleState = 0;

        /// <summary>
        /// 用来保存设置战斗状态的引用次数，当引用计数为0时，才可移除战斗状态
        /// </summary>
        byte[] mBattleStateRefNum = new byte[Buff.BattleStateCount];
        
        // ------------------------------------------------
        // 组件的内部方法
        // ------------------------------------------------
        // 进入透明状态
        private void EnterTransparenceState()
        {
            if (!FlagOperate.HasFlag(mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_STransparenceEffects))
            {
                mOwner.Alpha = 0.4f;
            }
        }
        
        // 退出透明状态
        private void ExitTranparenceState()
        {
            if (FlagOperate.HasFlag(mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_STransparenceEffects) &&
                !FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_STransparenceEffects))
            {
                mOwner.Alpha = 1.0f;
            }       
        }

        // ------------------------------------------------
        // 组件的外部接口
        // ------------------------------------------------
        public BattleStateBehavior(Actor act)
        {
            mOwner = act;
        }

        /// <summary>
        /// 是否处于隐身状态
        /// </summary>
        public bool IsActorInvisiable
        {
            get
            {
                return FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_INVISIBLE);
            }
        }

        /// <summary>
        /// 是否处于不可选中和受击状态
        /// </summary>
        public bool IsNoStrike
        {
            get
            {
                return FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_NOSTRIKE);
            }
        }

        public bool IsActorBeattackDisable
        {
            get
            {
                return FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_SBeattackDisable);
            }
        }

        /// <summary>
        /// 是否处于冰冻状态
        /// </summary>
        public bool IsFreezeState
        {
            get
            {
                return FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_FREEZE);
            }
        }

        /// <summary>
        /// 是否处于不可移动状态
        /// </summary>
        public bool IsMoveDisable
        {
            get
            {
                return FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_SMoveDisable) && IsMonster == false;
            }
        }

        /// <summary>
        /// 是否处于不可攻击状态
        /// </summary>
        public bool IsAttackDisable(uint skillId)
        {
            if (IsMonster == true)
            {
                return false;
            }
            if (FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_SAttakcDisableBase))
            {
                return true;
            }
            DBSkillSev.SkillInfoSev infoSev = DBManager.Instance.GetDB<DBSkillSev>().GetSkillInfo(skillId);
            if (infoSev != null)
            {
                if (infoSev.IsPg)
                {
                    return FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_BLIND);
                }
                else
                {
                    if (FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_BLIND))
                    {
                        return true;
                    }
                    else if (FlagOperate.HasFlag(mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_BLIND2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 是否具备某种战斗状态
        /// </summary>
        public bool HasBattleState(BattleStatusType type)
        {
            return FlagOperate.HasFlag(mCurBattleState, (int)type);
        }

        /// <summary>
        /// 根据当前角色状态标志做对应的状态处理
        /// </summary>
        public void UpdateBattleState()
        {
            if (mOwner.GetModel() == null)
                return;
            
            if (mLastBattleState != mCurBattleState)
            {
                // 眩晕
                if (FlagOperate.HasFlag((int)mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_DIZZY))
                {
                    if (!FlagOperate.HasFlag((int)mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_DIZZY))
                        mOwner.EnterDizzyState();
                }
                else
                {
                    if (FlagOperate.HasFlag((int)mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_DIZZY))
                        mOwner.ExitDizzyState();
                }

                // 混乱
                if (FlagOperate.HasFlag((int)mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_CHAOS))
                {
                    if (!FlagOperate.HasFlag((int)mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_CHAOS))
                        mOwner.EnterChaosState();
                }
                else
                {
                    if (FlagOperate.HasFlag((int)mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_CHAOS))
                        mOwner.ExitChaosState();
                }

                // 隐身
                if (IsActorInvisiable)
                {
                    if (!mOwner.IsLocalPlayer)
                    {
                        if (!FlagOperate.HasFlag(mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_INVISIBLE))
                        {
                            mOwner.mVisibleCtrl.SetActorVisible(false, VisiblePriority.BUFF_STATE);
                        }
                    }
                    else
                    {
                        EnterTransparenceState();
                    }
                }
                //else
                {
                    if (!mOwner.IsLocalPlayer)
                    {
                        if (FlagOperate.HasFlag(mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_INVISIBLE))
                        {
                            mOwner.mVisibleCtrl.SetActorVisible(true, VisiblePriority.BUFF_STATE);
                        }
                    }
                    else
                    {
                        ExitTranparenceState();             
                    }
                }


                // 无敌
                if (FlagOperate.HasFlag((int)mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_SUPER))
                {
                    if (!FlagOperate.HasFlag((int)mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_SUPER))
                        mOwner.EnterSuperState();
                }
                else
                {
                    if (FlagOperate.HasFlag((int)mLastBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_SUPER))
                        mOwner.ExitSuperState();
                }
                mLastBattleState = mCurBattleState;
            }

            // 角色在地面上才能进入冰冻状态
            if (mOwner.IsGrounded())
            {
                // 冰冻
                if (FlagOperate.HasFlag((int)mCurBattleState, (int)BattleStatusType.BATTLE_STATUS_TYPE_FREEZE))
                {
                    if (!mbIsInFreeze)
                    {
                        mbIsInFreeze = true;
                        mOwner.EnterFreezeState();
                    }
                }
                else
                {
                    if (mbIsInFreeze)
                    {
                        mbIsInFreeze = false;
                        mOwner.ExitFreezeState();
                    }
                }
            }
        }

        /// <summary>
        /// 是否是怪物
        /// </summary>
        bool IsMonster
        {
            get
            {
                // 对于怪物, 添加的限制移动类的战斗状态不起作用（因为怪物由服务端控制）
                Monster monster = mOwner as Monster;
                if (monster != null && monster.BeSummonedType != Monster.BeSummonType.BE_SUMMON_BY_PLAYER)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 增加战斗状态的标志
        /// </summary>
        public void AddBattleState(BattleStatusType eType)
        {
            if (mOwner == null)
                return;

            // 获取状态对应的引用计数
            int tmpType = (int)eType;
            int i = 0;
            for(; i < mBattleStateRefNum.GetLength(0); ++i)
            {
                tmpType = tmpType >> 1;
                if(tmpType == 0)
                    break;
            }
            
            if(i < mBattleStateRefNum.GetLength(0))
            {
                // 增加角色状态的flag
                if(mBattleStateRefNum[i] < 255)
                    mBattleStateRefNum[i] += 1;
                
                mCurBattleState = FlagOperate.AddFlag(mCurBattleState, (int)eType);
            }
            else
                Debug.LogError("角色状态数值溢出 : " + eType);
        }

        /// <summary>
        /// 移除战斗状态的标志
        /// </summary>
        public void RemoveBattleState(BattleStatusType eType)
        {       
            // 获取状态对应的引用计数
            int tmpType = (int)eType;
            int i = 0;
            for(; i < mBattleStateRefNum.GetLength(0); ++i)
            {
                tmpType = tmpType >> 1;
                if(tmpType == 0)
                    break;
            }
            
            if(i < mBattleStateRefNum.GetLength(0))
            {
                // 增加角色状态的flag
                if(mBattleStateRefNum[i] > 0)
                    mBattleStateRefNum[i] -= 1;
                
                if(mBattleStateRefNum[i] <= 0)
                {
                    mCurBattleState = FlagOperate.RemoveFlag(mCurBattleState, (int)eType);
                    mBattleStateRefNum[i] = 0;
                }
            }
            else
                Debug.LogError("角色状态数值溢出 : " + eType);
        }

        /// <summary>
        /// 重设战斗状态的标志
        /// </summary>
        public void ResetBattleState(BattleStatusType eType)
        {       
            // 获取状态对应的引用计数
            int tmpType = (int)eType;
            int i = 0;
            for(; i < mBattleStateRefNum.GetLength(0); ++i)
            {
                tmpType = tmpType >> 1;
                if(tmpType == 0)
                    break;
            }
            
            if(i < mBattleStateRefNum.GetLength(0))
            {
                mCurBattleState = FlagOperate.RemoveFlag(mCurBattleState, (int)eType);
                //kActor.BattleStateRefNum[i] = 0;
            }
            else
                Debug.LogError("角色状态数值溢出 : " + eType);
        }

        /// <summary>
        /// 重设当前战斗状态
        /// </summary>
        public void Reset()
        {
            mCurBattleState = 0;
            for(int i =0;i < mBattleStateRefNum.GetLength(0); ++i)
            {
                mBattleStateRefNum[i] = 0;
            }

            UpdateBattleState();
        }
    }
}

