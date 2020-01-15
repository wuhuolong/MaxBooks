//------------------------------------------------------------------------------
// Desc   :  恶意攻击
// Author :  xusong
// Date   :  2018/4/4
//------------------------------------------------------------------------------
using Net;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using xc.protocol;

namespace xc.instance_behaviour
{
    [wxb.Hotfix]
    public class HostileAttackBehaviour : Behaviour
    {

        Utils.Timer mTimer;
        public class HostileAttackData
        {
            public uint obj_idx;
            public float last_attack_time;
            //public bool is_destroy;
        }
        List<HostileAttackData> mDataArray = new List<HostileAttackData>();
        uint mCurShowObjIdx = 0;    //正在显示的目标ID
        float mLastResetTime = 0;   //上次重置时间
        static HostileAttackBehaviour inst = null;
        private float mNoAttackInterval = 10;   //不攻击的时长（秒）
        private float mResetInterval = 5;       //自动重置列表目标的时长（秒）
        public override void Enter(params object[] param)
        {
            inst = this;
            mCurShowObjIdx = 0;
            mDataArray.Clear();
            mNoAttackInterval = GameConstHelper.GetFloat("GAME_BATTLE_HOSTILE_NO_ATTACK_TIME");
            mResetInterval = GameConstHelper.GetFloat("GAME_BATTLE_HOSTILE_RESET_TIME");
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.EC_ACTOR_ADD_UNDER_ATTACK, OnAddUnderAttackActor);

            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }
        }

        public override void Exit()
        {
            inst = null;
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.EC_ACTOR_ADD_UNDER_ATTACK, OnAddUnderAttackActor);
            if (mTimer != null)
            {
                mTimer.Destroy();
                mTimer = null;
            }
        }

        public void OnAddUnderAttackActor(CEventBaseArgs msg)
        {
            if (msg == null || msg.arg == null)
            {//取消选中目标
                return;
            }
            uint obj_idx = (uint)msg.arg;
            bool need_reset_list = false;
            if (mDataArray.Count == 0)
                need_reset_list = true;

            HostileAttackData find_data = mDataArray.Find((a) => { return a.obj_idx == obj_idx; });
            if (find_data == null)
            {
                HostileAttackData new_data = new HostileAttackData();
                new_data.obj_idx = obj_idx;
                new_data.last_attack_time = Time.realtimeSinceStartup;
                mDataArray.Add(new_data);
            }
            else
            {
                find_data.last_attack_time = Time.realtimeSinceStartup;
            }
            if (need_reset_list)
            {
                ResetList();
            }
        }

        public static uint GetHostileAttackActorObjIdx_static()
        {
            if (inst == null)
                return 0;
            return inst.GetHostileAttackActorObjIdx();
        }

        public uint GetHostileAttackActorObjIdx()
        {
            return mCurShowObjIdx;
        }

        void ResetList()
        {
            mLastResetTime = Time.realtimeSinceStartup;
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer == null || localPlayer.transform == null || localPlayer.AttackCtrl == null)
            {
                mCurShowObjIdx = 0;
                return;
            }
            float max_target_range = AttackCtrl.MaxTargetRange;
            uint perfect_actor_id = 0;
            //HostileAttackData perfect_data = null;
            if (mDataArray.Count > 0)
            {
                if (mCurShowObjIdx == mDataArray[0].obj_idx)
                {
                    HostileAttackData tmp_data = mDataArray[0];
                    mDataArray.RemoveAt(0);
                    mDataArray.Add(tmp_data);
                }
                float now_time = Time.realtimeSinceStartup;
                for (int index = mDataArray.Count - 1; index >= 0; --index)
                {
                    HostileAttackData tmp_data = mDataArray[index];
                    Actor actor = ActorManager.Instance.GetActor(mDataArray[index].obj_idx);
                    if (actor != null)
                    {
                        float dist = (actor.transform.position - localPlayer.transform.position).magnitude;
                        if (dist > max_target_range)
                        {
                            mDataArray.RemoveAt(index);
                            continue;
                        }
                        float pass_time = now_time - tmp_data.last_attack_time;
                        if (pass_time > mNoAttackInterval)
                        {
                            mDataArray.RemoveAt(index);
                            continue;
                        }

                        perfect_actor_id = actor.UID.obj_idx;
                        //perfect_data = mDataArray[index];
                    }
                    else
                    {
                        mDataArray.RemoveAt(index);
                    }
                }
            }
            mCurShowObjIdx = perfect_actor_id;
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.EC_ACTOR_UNDER_ATTACK_CHANGE, new CEventBaseArgs(mCurShowObjIdx));
        }

        public override void Update()
        {
            base.Update();
            if (mCurShowObjIdx == 0)
                return;
            if (mDataArray.Count == 0)
                return;
            if (Time.realtimeSinceStartup - mLastResetTime >= mResetInterval)
            {//每过一段时间，重置一次列表
                ResetList();
                return;
            }
            CheckActorPosAndNoAttack();
        }

        void CheckActorPosAndNoAttack()
        {
            Actor localPlayer = Game.GetInstance().GetLocalPlayer();
            if (localPlayer == null || localPlayer.transform == null || localPlayer.AttackCtrl == null)
            {
                return;
            }
            float max_target_range = AttackCtrl.MaxTargetRange;
            if (mDataArray.Count > 0)
            {
                float now_time = Time.realtimeSinceStartup;
                for (int index = mDataArray.Count - 1; index >= 0; --index)
                {
                    HostileAttackData tmp_data = mDataArray[index];
                    Actor actor = ActorManager.Instance.GetActor(mDataArray[index].obj_idx);
                    if (actor != null)
                    {
                        float dist = (actor.transform.position - localPlayer.transform.position).magnitude;
                        if (dist > max_target_range)
                        {
                            mDataArray.RemoveAt(index);
                            continue;
                        }
                        float pass_time = now_time - tmp_data.last_attack_time;
                        if (pass_time > mNoAttackInterval)
                        {
                            mDataArray.RemoveAt(index);
                            continue;
                        }
                    }
                    else
                    {
                        mDataArray.RemoveAt(index);
                    }
                }
            }
            if (mDataArray.Count == 0 || mCurShowObjIdx != mDataArray[0].obj_idx)
            {//最优的目标被删除了，应该重置列表
                ResetList();
            }
        }
    }
}

