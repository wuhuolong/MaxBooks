//-----------------------------------------------
// SkillActionCastingReady.cs
// 技能吟唱阶段
// @raorui
// 2017.5.26
//-----------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace xc
{
    class SkillActionCastingReady : SkillActionBaseStage
    {
        public bool m_is_finish = false;
        /// <summary>
        /// 开始
        /// </summary>
        public override bool Begin(SkillAction action)
        {
            base.Begin(action);

            // 判定是否要进入吟唱阶段
            if (action.ActionData.CastingReadyStageTime <= 0)
            {
                m_is_finish = true;
                return false;
            }
            m_is_finish = false;
            if (mSkillAction.SkillParent.SrcActor != null && mSkillAction.SkillParent.SrcActor.IsLocalPlayer)
                InstanceManager.Instance.SetInCastingReadyStage(true, action.ActionData.CastingReadyStageTime);
            if(mSkillAction.ActionData.CastingReadyAnimation != string.Empty)
            {
                mSkillAction.SkillParent.SrcActor.Play(mSkillAction.ActionData.CastingReadyAnimation);
            }

            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            base.Update();

            if(InstanceManager.Instance.IsInCastingReadyStage == false)
            {
                m_is_finish = true;
            }
            if (m_is_finish || mSkillAction.SkillParent.IsPress == false || mStageTime >= mSkillAction.ActionData.CastingReadyStageTime)
            {

                if (mSkillAction != null)// mSkillAction在Begin时才赋值
                {
                    if (mSkillAction != null && mSkillAction.SkillParent != null)
                    {
                        if (mSkillAction.SkillParent.SrcActor != null && mSkillAction.SkillParent.SrcActor.IsLocalPlayer)
                        {
                            var pack = new Net.C2SNwarSkillSing();
                            Net.NetClient.GetCrossClient().SendData<Net.C2SNwarSkillSing>(protocol.NetMsg.MSG_NWAR_SKILL_SING, pack);
                            
                        }
                    }
                }
                mSkillAction.NextStage();
                //UINotice.Instance.ShowMessage("End SkillActionCastingReady");
            }
            else
            {

            }
        }

        public override void End()
        {
            if (mSkillAction != null)// mSkillAction在Begin时才赋值
            {
                if (mSkillAction != null && mSkillAction.SkillParent != null)
                {
                    if (mSkillAction.SkillParent.SrcActor != null && mSkillAction.SkillParent.SrcActor.IsLocalPlayer)
                    {
                        InstanceManager.Instance.SetInCastingReadyStage(false, 0);
                    }
                }
            }
            base.End();
        }
    }
}