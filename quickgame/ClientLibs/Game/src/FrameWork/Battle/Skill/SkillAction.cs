using System;
using System.Collections.Generic;
using UnityEngine;

using xc;
using xc.protocol;
using Net;

namespace xc
{
    /// <summary>
    /// 技能可以由多个Action组成，前一个Action的硬直时间到后就执行下一个
    /// </summary>
    public class SkillAction
    {
        // actiont流程 : 
        //      |
        //      |                       |----持续施法---|       
        //      |---->    前摇(cast)---->            ---> 后摇------> 硬直 -> 硬直检测（是否施放下一技能） -> 结束
        //      |                       |----施法------|
        //      |                                   
        //      |                                   
        //      |
        //      |---->    缓存技能检测

        /// <summary>
        /// SkillAciton对应的Skill
        /// </summary>
        private Skill mSkillParent;
        public Skill SkillParent
        {
            get { return mSkillParent; }
            set { mSkillParent = value; }
        }

        DBSkill.SkillActionData mActionData;

        /// <summary>
        /// 技能表中的数据
        /// </summary>
        public DBSkill.SkillActionData ActionData
        {
            get
            {
                return mActionData;
            }
        }

        /// <summary>
        /// 技能的各个阶段
        /// </summary>
        List<SkillActionBaseStage> mAllStages;

        /// <summary>
        /// 传送隐身类技能，是否已经隐藏了角色
        /// </summary>
        bool mHideActor = false;
        public bool HideActor
        {
            get{return mHideActor;}
            set { mHideActor = value; }
        }

        public SkillAction(DBSkill.SkillActionData kActionData)
        {
            LoadFromData(kActionData);
            mSkillParent = null;
            mAllStages = new List<SkillActionBaseStage>();
        }

        /// <summary>
        /// 根据技能表中数据来设置需要发射子弹的数据
        /// </summary>
        public void LoadFromData(DBSkill.SkillActionData kActionData)
        {
            mActionData = kActionData;
        }

        /// <summary>
        /// 当前处于的技能阶段
        /// </summary>
        SkillActionBaseStage mCurrentStage;

        /// <summary>
        /// 开始技能的Stage
        /// </summary>
        public void StartStage()
        {
            mAllStages.Add(new SkillActionCastStage());
            mAllStages.Add(new SkillActionCastingReady());
            mAllStages.Add(new SkillActionCastingStage());
            mAllStages.Add(new SkillActionRigidityStage());
            mAllStages.Add(new SkillActionEndingStage());

            SkillActionBaseStage first_stage = mAllStages[0];

            if (first_stage.Begin(this))
            {
                mCurrentStage = first_stage;
                SkillParent.SetUpdateFuncRun(first_stage.Update);
            }
            else
                NextStage();
        }

        /// <summary>
        /// 进入下一个技能Stage
        /// </summary>
        public void NextStage()
        {
            if (mAllStages.Count > 0)
            {
                // end current
                SkillActionBaseStage stage = mAllStages[0];
                SkillParent.RemoveUpdateFunc(stage.Update);
                stage.End();
                mAllStages.RemoveAt(0);

                // start next
                if (mAllStages.Count > 0)
                {
                    SkillActionBaseStage next_stage = mAllStages[0];

                    if (next_stage.Begin(this))
                    {
                        mCurrentStage = next_stage;
                        SkillParent.SetUpdateFuncRun(next_stage.Update);
                    }
                    else
                        NextStage();
                }
            }
        }

        /// <summary>
        /// 中断技能的Stage
        /// </summary>
        public void FinishStage()
        {
            mCurrentStage = null;
            if (mAllStages.Count > 0)
            {
                // end current
                SkillActionBaseStage stage = mAllStages[0];
                SkillParent.RemoveUpdateFunc(stage.Update);
                stage.End();
                mAllStages.RemoveAt(0);
            }

            // clear all 
            foreach (SkillActionBaseStage stage in mAllStages)
            {
                stage.End();
            }
            mAllStages.Clear();
        }

        /// <summary>
        /// 是否可以缓存下一个技能
        /// </summary>
        /// <returns></returns>
        public bool CanCacheNext()
        {
            return  mCurrentStage is SkillActionCastStage || mCurrentStage is SkillActionCastingReady || mCurrentStage is SkillActionCastingStage || mCurrentStage is SkillActionRigidityStage || mCurrentStage is SkillActionEndingStage;
        }

        /// <summary>
        /// 判断是否处于后摇阶段
        /// </summary>
        /// <returns></returns>
        public bool IsInSkillActionEndingStage()
        {
            return mCurrentStage is SkillActionEndingStage;
        }

        public bool IsInBeforeSkillActionEndingStage()
        {
            return mCurrentStage is SkillActionCastStage || mCurrentStage is SkillActionCastingReady || mCurrentStage is SkillActionCastingStage || mCurrentStage is SkillActionRigidityStage;
        }
        /// <summary>
        /// 技能结束时间点初始数值为-1，需要重新计算
        /// </summary>
        public void UpdateSkillEndPoint()
        {
            if (mActionData.EndStageTime < 0.0f && mSkillParent != null && mSkillParent.SrcActor != null && mSkillParent.SrcActor.IsResLoaded)
            {
                Actor anim_actor = mSkillParent.SrcActor;
                if (mSkillParent.SrcActor.mRideCtrl != null && mSkillParent.SrcActor.mRideCtrl.Rider != null)
                {
                    anim_actor = mSkillParent.SrcActor.mRideCtrl.Rider;
                    if (anim_actor.IsResLoaded == false)
                        return;
                }
                    
                mActionData.UpdateEndPoint(anim_actor.GetAnimationLength(mActionData.SkillAnimation));
            }
        }

        /// <summary>
        /// SkillAction是否在cd中
        /// </summary>
        /// <returns></returns>
        public bool IsInCD()
        {
            uint cd_idx = mActionData.SkillInfo.Id;
            return cd_idx != 0 && mSkillParent.SrcActor.CDCtrl.IsInCD(cd_idx);
        }

        public CooldownCtrl.CDInstance GetCDInstance()
        {
            uint uiCDTypeID = mActionData.SkillInfo.Id;

            return uiCDTypeID != 0 ? mSkillParent.SrcActor.CDCtrl.GetCDInstance(uiCDTypeID) : null;
        }

        /// <summary>
        /// 开始执行SkillAction
        /// </summary>
        public void Begin()
        {
            UpdateSkillEndPoint();

            // 播放技能动作
            if (!string.IsNullOrEmpty(mActionData.SkillAnimation))
                mSkillParent.SrcActor.Play(mActionData.SkillAnimation);

            // 播放技能对应的音效
            if (mSkillParent.SrcActor != null && string.IsNullOrEmpty(mActionData.SkillInfo.Sound) == false)
            {
                mSkillParent.SrcActor.PlaySkillSound(GlobalConst.ResPath + mActionData.SkillInfo.Sound);
            }

            // 初始化移动攻击的方式
            mSkillParent.SrcActor.MoveCtrl.MoveDirInAttacking(Vector3.zero);

#if SKILLINFO_DEBUG
                GameDebug.LogError(string.Format("使用技能skill[{0}] spell[{1}]", mActionData.mkSkillInfo.muiID, mActionData.mkSkillInfo.mkSpellInfo.muiID));
#endif

            StartStage();
        }

        /// <summary>
        /// 冲锋技能冲到角色身边的距离
        /// </summary>
        float mRushTargetRange = 0.0f;
        public float RushTargetRange
        {
            get
            {
                if (mRushTargetRange == 0.0)
                {
                    mRushTargetRange = GameConstHelper.GetFloat("GAME_RUSH_TARGET_RANGE") * GlobalConst.UnitScale;
                    if (mRushTargetRange == 0.0)
                        mRushTargetRange = 3.0f;
                }

                return mRushTargetRange;
            }
        }

        void OnMoveDirChange()
        {
            // 先获取移动方向
            Vector3 attackDir = mSkillParent.SrcActor.MoveDir;
            // 如果没有移动方向，则使用角色的当前朝向
            if (attackDir == Vector3.zero)
                attackDir = mSkillParent.SrcActor.ForwardDir;

            mSkillParent.AttackDir = attackDir.normalized;

            mSkillParent.SrcActor.TurnDir(mSkillParent.AttackDir);
        }

        void OnMoveEnd()
        {
            mSkillParent.MovingSpeed = 0.0f;
        }

        // 开始位移
        public void BeginMove()
        {
            MoveCtrl move_ctrl = mSkillParent.SrcActor.MoveCtrl;
            move_ctrl.OnMoveDirChange = OnMoveDirChange;
            move_ctrl.OnMoveEnd = OnMoveEnd;
        }

        // 取消位移
        public void CancleMove()
        {
            // 施法阶段位移
            if (mSkillParent.MovingSpeed != 0.0f)
            {
                MoveCtrl move_ctrl = mSkillParent.SrcActor.MoveCtrl;

                // 先取消位移
                move_ctrl.MoveDirInAttacking(Vector3.zero);

                // 还原数据
                mSkillParent.SrcActor.MoveSpeed = mSkillParent.MovingSpeed;
                move_ctrl.OnMoveDirChange = null;
                move_ctrl.OnMoveEnd = null;
            }
        }

        public Vector2 GetAttackRange()
        {
            Vector2 kResult = Vector2.zero;
            if (mActionData != null && mActionData.SkillInfo != null)
            {
                kResult.y = mActionData.SkillInfo.Range;
            }
            else
            {
                kResult = new Vector2(0.0f, Mathf.Infinity);
            }

            return kResult;
        }

        public SkillAction Clone(Skill kSkill)
        {
            SkillAction kNewAction = MemberwiseClone() as SkillAction;
            kNewAction.mSkillParent = kSkill;

            return kNewAction;
        }

        /// <summary>
        /// SkillAction结束，在技能正常结束或者被打断的时候调用
        /// </summary>
        public void Stop()
        {
            FinishStage();

            mSkillParent.SrcActor.MoveCtrl.OnMoveDirChange = null;
            mSkillParent.SrcActor.MoveCtrl.OnMoveEnd = null;

            if (mSkillParent.MovingSpeed != 0.0f)
            {
                mSkillParent.MovingSpeed = 0.0f;
            }

            mSkillParent.SrcActor.SetAnimationSpeed(1.0f); //技能阶段结束时，恢复动画的播放速度
        }

        public void FinishCastingReadyStage()
        {
            for(int index = 0; index < mAllStages.Count; ++index)
            {
                if( mAllStages[index] is SkillActionCastingReady)
                {
                    (mAllStages[index] as SkillActionCastingReady).m_is_finish = true;
                }
            }
        }
    }
}

