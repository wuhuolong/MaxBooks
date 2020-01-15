//-----------------------------------------------
// SkillActionEndingStage.cs
// 技能的收招阶段
// @raorui
// 2017.5.26
//-----------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    class SkillActionEndingStage : SkillActionBaseStage
    {
        bool m_is_should = false;
        /// <summary>
        /// 开始
        /// </summary>
        public override bool Begin(SkillAction action)
        {
            base.Begin(action);

            mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(mSkillAction.SkillParent.SpeedScale);
            m_is_should = false;
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (mSkillAction.SkillParent.SrcActor.AttackCtrl.UpdateRigidity())
            {
                m_is_should = true;
                return;
            }

//             if (mSkillAction.SkillParent != null && mSkillAction.SkillParent.SrcActor != null &&
//                mSkillAction.SkillParent.SrcActor.ActorAttribute != null &&
//                mSkillAction.SkillParent.SrcActor.ActorAttribute.State == GameConst.PLAYER_STATE_HANG)
//             {
//                 mSkillAction.SkillParent.End();
//                 return;
//             }

            if (m_is_should == false && mSkillAction != null && mSkillAction.ActionData != null && mStageTime >= mSkillAction.ActionData.EndStageTime)
            {
                if(mSkillAction.SkillParent != null)
                    mSkillAction.SkillParent.End();
            }
        }

        public override void End()
        {
            if (mSkillAction != null)
                mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(1.0f);

            base.End();
        }
    }
}
