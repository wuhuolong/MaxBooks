//-----------------------------------------------
// SkillActionBaseStage.cs
// 技能的某一阶段
// @raorui
// 2017.5.26
//-----------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

using xc;
using xc.protocol;
using Net;

namespace xc
{
    class SkillActionBaseStage
    {
        protected SkillAction mSkillAction;
        public float mStageTime;

        /// <summary>
        /// 开始
        /// </summary>
        public virtual bool Begin(SkillAction action)
        {
            mSkillAction = action;
            mStageTime = 0;
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public virtual void Update()
        {
            if (!mSkillAction.SkillParent.IsFreeze)
            {
                float deltaTime = (Time.deltaTime * mSkillAction.SkillParent.SpeedScale);
                mStageTime += deltaTime;
            }
        }

        /// <summary>
        /// 结束
        /// </summary>
        public virtual void End()
        {
            mStageTime = 0;
            mSkillAction = null;
        }
    }
}
