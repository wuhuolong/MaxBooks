//-----------------------------------------------
// SkillActionBaseStage.cs
// 技能的施法阶段
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
    class SkillActionCastingStage : SkillActionBaseStage
    {
        float m_DynamicStageTime = 0.0f;
        Vector3 m_RealTargetPos = Vector3.zero;

        /// <summary>
        /// 开始
        /// </summary>
        public override bool Begin(SkillAction action)
        {
            base.Begin(action);

            m_DynamicStageTime = mSkillAction.ActionData.CastingStageTime;
            m_RealTargetPos = Vector3.zero;

            // 判定是否要进入持续施法阶段
            if (mSkillAction.ActionData.SkillInfo.CastingTime <= 0.0f)
                return false;

            Actor src_actor = mSkillAction.SkillParent.SrcActor;

            // 技能的隐身
            if (mSkillAction.ActionData.SkillInfo.Invisible)
            {
                if (src_actor.mVisibleCtrl.VisibleMode == EVisibleMode.Visible)
                {
                    mSkillAction.HideActor = true;
                    src_actor.mVisibleCtrl.SetActorVisible(false, true, false, VisiblePriority.SKILL);
                }
            }

            // 播放动画
            string casting_ani = mSkillAction.ActionData.CastingAnimation;
            if (casting_ani != string.Empty && casting_ani != mSkillAction.ActionData.SkillAnimation)
            {
                src_actor.Play(mSkillAction.ActionData.CastingAnimation);
            }
            src_actor.SetAnimationSpeed(mSkillAction.SkillParent.SpeedScale);

            // 施法阶段的位移
            MoveCtrl move_ctrl = src_actor.MoveCtrl;
            mSkillAction.SkillParent.MovingSpeed = mSkillAction.ActionData.SkillInfo.CastingSpeed;
            src_actor.MoveSpeed = mSkillAction.ActionData.SkillInfo.CastingSpeed;
            mSkillAction.BeginMove();

            uint target_id = mSkillAction.SkillParent.TargetID;// 目标玩家的id
            if (target_id == 0)// 无目标玩家
            {
                move_ctrl.MoveDirInAttacking(src_actor.ForwardDir);// 沿当前方向移动
                Vector3 src_pos = src_actor.Trans.position;
                m_RealTargetPos = src_pos + mSkillAction.SkillParent.AttackDir * mSkillAction.ActionData.SkillInfo.CastingSpeed * mSkillAction.ActionData.CastingStageTime;
                XNavMeshHit hit;
                if (XNavMesh.Raycast(src_pos, m_RealTargetPos, out hit, xc.Dungeon.LevelManager.GetInstance().AreaExclude))
                {
                    m_RealTargetPos = PhysicsHelp.BoundaryHitPos(src_pos, hit.position);
                }
            }
            else// 有目标玩家
            {
                Vector3 src_pos = src_actor.Trans.position;
                Actor target_actor = ActorManager.Instance.GetPlayer(target_id);// 获取目标玩家

                Vector3 target_pos = Vector3.zero;
                if(target_actor != null)
                {
                    target_pos = target_actor.Trans.position;
                    Vector3 vec = target_pos - src_pos;
                    float len = vec.magnitude;

                    if (len > mSkillAction.RushTargetRange)
                    {
                        float real_len = len - mSkillAction.RushTargetRange;
                        target_pos = src_pos + vec * real_len / len;
                        XNavMeshHit hit;
                        if (XNavMesh.Raycast(src_pos, target_pos, out hit, xc.Dungeon.LevelManager.GetInstance().AreaExclude))
                        {
                            target_pos = PhysicsHelp.BoundaryHitPos(src_pos, hit.position);
                        }

                        if (mSkillAction.ActionData.SkillInfo.CastingSpeed != 0)
                        {
                            m_RealTargetPos = target_pos;
                            float calc_castingTime = real_len / mSkillAction.ActionData.SkillInfo.CastingSpeed;// 根据距离和速度计算施法阶段的时间
                            float fix_castingTime = mSkillAction.ActionData.CastingStageTime;
                            if (calc_castingTime < fix_castingTime)
                                m_DynamicStageTime = calc_castingTime;
                        }
                    }
                    else
                    {
                        target_pos = src_pos;
                        m_DynamicStageTime = 0;
                    }

                    move_ctrl.MoveDirInAttacking(vec);// 冲到目标点的方向
                }
                else
                {
                    target_pos = src_pos + mSkillAction.SkillParent.AttackDir * mSkillAction.ActionData.SkillInfo.CastingSpeed * mSkillAction.ActionData.CastingStageTime;
                    XNavMeshHit hit;
                    if (XNavMesh.Raycast(src_pos, target_pos, out hit, xc.Dungeon.LevelManager.GetInstance().AreaExclude))
                    {
                        target_pos = PhysicsHelp.BoundaryHitPos(src_pos, hit.position);
                        m_RealTargetPos = target_pos;
                    }
                }

                if (src_actor.AttackCtrl.mIsSendMsg)
                {
                    C2SNwarChargeStop charge_stop = new C2SNwarChargeStop();
                    charge_stop.skill_id = mSkillAction.ActionData.SkillInfo.Id;
                    PkgNwarMove move = new PkgNwarMove();
                    move.id = src_actor.UID.obj_idx;
                    PkgNwarPos pos = new PkgNwarPos();
                    pos.px = (int)(target_pos.x * 100);
                    pos.py = (int)(target_pos.z * 100);
                    move.pos = pos;
                    move.speed = 0;
                    move.time = 0;
                    charge_stop.move = move;

                    NetClient.GetCrossClient().SendData<C2SNwarChargeStop>(NetMsg.MSG_NWAR_CHARGE_STOP, charge_stop);
                }
            }
            

            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (mStageTime >= m_DynamicStageTime)
            {
                if (m_RealTargetPos != Vector3.zero)
                    mSkillAction.SkillParent.SrcActor.SetPosition(m_RealTargetPos);

                    // 进入下一阶段
                mSkillAction.NextStage();
            }
        }

        public override void End()
        {
            if (mSkillAction != null)// mSkillAction在Begin时才赋值
            {
                mSkillAction.SkillParent.SrcActor.SetAnimationSpeed(1.0f);
                // 如果技能是传送隐身类型，结束时显示角色
                if (mSkillAction.ActionData.SkillInfo.Invisible && mSkillAction.HideActor)
                {
                    mSkillAction.HideActor = false;
                    mSkillAction.SkillParent.SrcActor.mVisibleCtrl.SetActorVisible(true, true, false, VisiblePriority.SKILL);
                }

                // 取消位移
                mSkillAction.CancleMove();
            }

            base.End();
        }
    }
}
