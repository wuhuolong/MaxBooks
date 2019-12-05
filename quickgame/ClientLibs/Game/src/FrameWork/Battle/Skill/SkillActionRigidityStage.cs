//-----------------------------------------------
// SkillActionRigidityStage.cs
// 技能的硬直阶段
// @raorui
// 2017.5.26
//-----------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    class SkillActionRigidityStage : SkillActionBaseStage
    {
        /// <summary>
        /// 开始
        /// </summary>
        public override bool Begin(SkillAction action)
        {
            base.Begin(action);

            // 播放持续施法结束的动画
            if (mSkillAction.ActionData.CastingEndAnimation != string.Empty)
            {
                mSkillAction.SkillParent.SrcActor.Play(mSkillAction.ActionData.CastingEndAnimation);
            }
            // 还原技能动画
            else if (mSkillAction.ActionData.CastingAnimation != string.Empty && mSkillAction.ActionData.CastingAnimation != mSkillAction.ActionData.SkillAnimation)
            {
                mSkillAction.SkillParent.SrcActor.Play(mSkillAction.ActionData.SkillAnimation);
            }

            mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(mSkillAction.SkillParent.SpeedScale);

            //mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(mSkillAction.SkillParent.SpeedScale);

            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (mStageTime >= mSkillAction.ActionData.RigidityStageTime)
            {
                if (!mSkillAction.SkillParent.SrcActor.AttackCtrl.UpdateRigidity())
                {
                    if (mSkillAction != null)
                        mSkillAction.NextStage();
                    //else
                    //    GameDebug.LogError("SkillAction is null");
                }
            }
        }

        public override void End()
        {
            if(mSkillAction != null)
                mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(1.0f);
            base.End();
        }
    }
}
