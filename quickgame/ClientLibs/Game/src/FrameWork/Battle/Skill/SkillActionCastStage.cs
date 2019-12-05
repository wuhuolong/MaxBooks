//-----------------------------------------------
// SkillActionCastStage.cs
// 技能的前摇阶段
// @raorui
// 2017.5.26
//-----------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    class SkillActionCastStage : SkillActionBaseStage
    {
        public override bool Begin(SkillAction action)
        {
            base.Begin(action);

            if (mSkillAction.ActionData.CastStageTime != 0.0f)
            {
                if (mSkillAction.ActionData.SkillInfo.ForwardSpeed != 0.0f)
                {
                    // 将位移回调设置给MoveCtrl，并设置移动速度和方向
                    MoveCtrl kMoveCtrl = mSkillAction.SkillParent.SrcActor.MoveCtrl;
                    float moveSpeed = mSkillAction.ActionData.SkillInfo.ForwardSpeed * mSkillAction.SkillParent.SpeedScale;// 攻速影响前摇移动速度
                    mSkillAction.SkillParent.MovingSpeed = moveSpeed;
                    mSkillAction.SkillParent.SrcActor.MoveSpeed = moveSpeed;

                    mSkillAction.BeginMove();
                    kMoveCtrl.MoveDirInAttacking(mSkillAction.SkillParent.SrcActor.ForwardDir);
                }

                mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(mSkillAction.SkillParent.SpeedScale);

                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Update()
        {
            base.Update();

            if (mStageTime >= mSkillAction.ActionData.CastStageTime)
            {
                mSkillAction.NextStage();
            }
        }

        public override void End()
        {
            if (mSkillAction != null)
            {
                mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(1.0f);
                mSkillAction.CancleMove();
             }

            base.End();
        }
    }
}
