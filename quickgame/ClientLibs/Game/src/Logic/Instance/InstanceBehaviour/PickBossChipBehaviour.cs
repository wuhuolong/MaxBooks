
//------------------------------------------------------------------------------
// Desc   :  逻辑
// Author :  
// Date   :  
//------------------------------------------------------------------------------
using Net;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using xc.protocol;

namespace xc.instance_behaviour
{
    [wxb.Hotfix]
    public class PickBossChipBehaviour : Behaviour
    {
        //         protected Vector3 mDropPosition;
        //protected List<Utils.Timer> mTimerList;
        Utils.Timer mTimer;
        PkgDropGive mDropInfo;
        uint mDropType;
        float mStartPickTime = 0;
        float mPickTotalTime = 5;

        uint m_pick_boss_sound_id = 0;  //拾取音效的唯一ID
        public static float mSendPickPackageTime = 0;   //发送拾取协议的时间
        public static bool mHasSendPickPackage = false; //是否发送过拾取碎片协议
        public override void Enter(params object[] param)
        {
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_PICK_BOSS_CHIP_START, HandleServerData);  //开始拾取
            Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_NWAR_PICK_BOSS_CHIP_STOP, HandleServerData);   //终止或者正常结束拾取

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PICK_DROP_START_PICK_UP_LOCALPLAYER, OnStartPickUpLocalPlayer);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)(xc.ClientEvent.CE_PICK_DROP_BREAK_PICK_UP), OnBreakPickBossChip);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_PICK_DROP_DISAPPEAR_BOSS_CHIP, OnDisappearBossChip);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)(xc.ClientEvent.CE_LOCAL_PLAYER_EXIT_INTERACTION), OnLocalPlayerExitInteraction);
            ClientEventMgr.GetInstance().SubscribeClientEvent((int)(xc.ClientEvent.CE_TIMELINE_FINISH), OnTimeLineFinish);

            StopAnim(true, true);
        }

        public override void Exit()
        {

            //             ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_MONSTERDEAD, OnMonsterDead);
            //             ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PICK_DROP, OnPickDrop);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_PICK_BOSS_CHIP_START, HandleServerData);
            Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_NWAR_PICK_BOSS_CHIP_STOP, HandleServerData);

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PICK_DROP_START_PICK_UP_LOCALPLAYER, OnStartPickUpLocalPlayer);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)(xc.ClientEvent.CE_PICK_DROP_BREAK_PICK_UP), OnBreakPickBossChip);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_PICK_DROP_DISAPPEAR_BOSS_CHIP, OnDisappearBossChip);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)(xc.ClientEvent.CE_LOCAL_PLAYER_EXIT_INTERACTION), OnLocalPlayerExitInteraction);
            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)(xc.ClientEvent.CE_TIMELINE_FINISH), OnTimeLineFinish);

            StopAnim(true, true);
        }


        protected virtual void HandleServerData(ushort protocol, byte[] data)
        {
            switch (protocol)
            {
                case NetMsg.MSG_NWAR_PICK_BOSS_CHIP_START:
                    {//开始拾取
                        //GameDebug.LogError("recv MSG_NWAR_PICK_BOSS_CHIP_START");
                        var pack = S2CPackBase.DeserializePack<S2CNwarPickBossChipStart>(data);
                        if (pack.action.uuid == Game.Instance.LocalPlayerTypeID)
                            return;
                        if (SceneHelp.Instance.IsInWorldBossExperienceInstance)
                            return;//世界BOSS体验副本，不显示其他人的拾取操作
                        Actor actor = ActorManager.Instance.GetPlayer(pack.action.uuid);
                        if (actor == null || actor.IsPlayer() == false)
                            return;
                        Player player = actor as Player;
                        UnityEngine.Vector3 kPos = UnityEngine.Vector3.zero;
                        kPos = PhysicsHelp.GetPosition(pack.action.pos.px / 100.0f, pack.action.pos.py / 100.0f);
                        DropComponent drop_com = InstanceDropManager.Instance.GetDrop(pack.action.oid);
                        if (drop_com != null && drop_com.transform.parent != null)
                        {
                            kPos = drop_com.transform.position;
                        }
                        player.StartPickUpBossChipEffect(kPos);
                    }
                    return;
                case NetMsg.MSG_NWAR_PICK_BOSS_CHIP_STOP:
                    {
                        var pack = S2CPackBase.DeserializePack<S2CNwarPickBossChipStop>(data);
                        
                        Actor actor = ActorManager.Instance.GetPlayer(pack.uuid);
                        if (actor == null || actor.IsPlayer() == false)
                            return;
                        if (SceneHelp.Instance.IsInWorldBossExperienceInstance && actor.IsLocalPlayer == false)
                            return;//世界BOSS体验副本，不显示其他人的拾取操作
                        Player player = actor as Player;
                        player.FinishPickUpEffect();
                        if(pack.type == 0 && player.IsLocalPlayer)
                        {//如果是主角完成，需要发送拾取协议给后端 2017/12/28
                            FinishPickImmediately();
                            //if ((mDropInfo.type == GameConst.GIVE_TYPE_GOODS || mDropInfo.type == GameConst.GIVE_TYPE_EQUIP) && ItemManager.Instance.BagIsFull(1) == true)
                            //{
                            //    UINotice.Instance.ShowMessage(DBConstText.GetText("BAG_IS_FULL"));
                            //    return;
                            //}
                            //C2SNwarPick msg = new C2SNwarPick();
                            //msg.oid = mDropInfo.oid;
                            //msg.drop_type = mDropType;
                            //NetClient.GetBaseClient().SendData<C2SNwarPick>(NetMsg.MSG_NWAR_PICK, msg);
                            //mHasSendPickPackage = true;
                            //mSendPickPackageTime = Time.realtimeSinceStartup;
                            //xc.ui.ugui.UIManager.Instance.ShowWindow("UIBossFragmentsWindow", mDropInfo.gid, mDropInfo.num);
                        }
                    }
                    return;
                default:
                    break;
            }
        }

        void FinishPickImmediately()
        {
            if (mDropInfo == null)
                return;

            if ((mDropInfo.type == GameConst.GIVE_TYPE_GOODS || mDropInfo.type == GameConst.GIVE_TYPE_EQUIP) && ItemManager.Instance.BagIsFull(1) == true)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("BAG_IS_FULL"));
                return;
            }
            C2SNwarPick msg = new C2SNwarPick();
            msg.oid = mDropInfo.oid;
            msg.drop_type = mDropType;
            NetClient.GetBaseClient().SendData<C2SNwarPick>(NetMsg.MSG_NWAR_PICK, msg);
            mHasSendPickPackage = true;
            mSendPickPackageTime = Time.realtimeSinceStartup;
        }

        void OnStartPickUpLocalPlayer(CEventBaseArgs data_param)
        {
            if (data_param == null)
                return;
            if ((data_param is CEventEventParamArgs) == false)
                return;
            CEventEventParamArgs data = data_param as CEventEventParamArgs;
            if (data.mMoreParam == null)
                return;
            if (data.mMoreParam.Length <= 1)
                return;
            PkgDropGive drop_info = data.mMoreParam[0] as PkgDropGive;
            uint drop_type = 0;
            drop_type = uint.Parse(data.mMoreParam[1] as string);
            if (drop_info == null)
                return;

            if (mTimer != null)
                return;
            xc.InstanceManager.Instance.IsAutoFighting = false;//停止自动挂机
            
            mTimer = new Utils.Timer(100, true, 200, UpdatePick);
            mDropInfo = drop_info;
            mDropType = drop_type;
            mStartPickTime = Time.realtimeSinceStartup;
            Actor local_player = xc.Game.Instance.GetLocalPlayer();
            Vector3 drop_com_pos = local_player.transform.position;
            DropComponent drop_com = InstanceDropManager.Instance.GetDrop(drop_info.oid);
            if(local_player != null && drop_com != null)
            {
                drop_com_pos = drop_com.transform.position;
                (local_player as Player).StartPickUpBossChipEffect(drop_com.transform.position);
            }
            C2SNwarPickBossChipStart reply = new C2SNwarPickBossChipStart();
            reply.action = new PkgNwarPickBossChip();
            reply.action.uuid = local_player.UID.obj_idx;
            reply.action.oid = mDropInfo.oid;
            reply.action.pos = new PkgNwarPos();
            reply.action.pos.px = (int)(drop_com_pos.x * 100);
            reply.action.pos.py = (int)(drop_com_pos.y * 100);
            NetClient.GetCrossClient().SendData<C2SNwarPickBossChipStart>(NetMsg.MSG_NWAR_PICK_BOSS_CHIP_START, reply);

            string sound_path = "Assets/" + ResPath.Sound_ui_xihun;
            m_pick_boss_sound_id = xc.AudioManager.Instance.PlayAudio_dynamic_out(sound_path, false, 1);
        }

        void OnBreakPickBossChip(CEventBaseArgs data)
        {
            if (data == null || data.arg == null)
                return;
            StopAnim(false);
        }

        void UpdatePick(float remainTime)
        {
            if (remainTime > 0)
                return;
            if (TimelineManager.Instance.IsPlayableDirectorPlaying())
            {
                //有剧情打断，通过剧情最后去发起拾取
                StopAnim(true);
                return;
            }

            Actor local_player = xc.Game.Instance.GetLocalPlayer();
            if (local_player != null)
            {//脱离
                bool is_need_stop_anim = false;
                if (local_player.ActorMachine.IsInInteraction == false)
                {
                    if (local_player.mRideCtrl == null || local_player.mRideCtrl.IsRideTobeLoaded() == false )
                    {//坐骑会延迟进入互动状态的时刻
                        is_need_stop_anim = true;
                        //GameDebug.LogError("local_player.ActorMachine.IsInInteraction == false");
                    }   
                }
                if (local_player.IsShapeShift)
                {
                    //GameDebug.LogError("local_player.IsShapeShift == true");
                    is_need_stop_anim = true;
                }
                if (local_player.HasBattleState(BattleStatusType.BATTLE_STATUS_TYPE_DIZZY))
                {
                    is_need_stop_anim = true;
                    //GameDebug.LogError("HasBattleState(BattleStatusType.BATTLE_STATUS_TYPE_DIZZY)");
                }
                if (is_need_stop_anim)
                {
                    StopAnim(true);
                    return;
                }
            }
            float now_time = Time.realtimeSinceStartup;
            float pass_time = now_time - mStartPickTime;
            float percent = pass_time / mPickTotalTime;
            if (percent >= 1)
            {
                StopAnim(false);
            }
            else
            {
                ClientEventMgr.Instance.FireEvent((int)(ClientEvent.CE_PICK_DROP_CONTROL_SLIDER), new CEventObjectArgs(true, percent));
            }
        }

        /// <summary>
        /// 停止拾取动画
        /// </summary>
        /// <param name="is_break">是否是中断（若为false，则是正常结束动画）</param>
        /// <param name="exec_finish_action">是否停止拾取动作</param>
        public void StopAnim(bool is_break, bool exec_finish_action = false)
        {
            if (mTimer == null)
                return;
            
            //GameDebug.LogRed("StopAnim = " + is_break.ToString());
            C2SNwarPickBossChipStop reply = new C2SNwarPickBossChipStop();
            AudioManager.Instance.StopAudio_dynamic(m_pick_boss_sound_id);
            if (is_break)
            {
                UINotice.Instance.ShowMessage(DBConstText.GetText("WORLD_BOSS_PICK_STOP_TIPS"));
                reply.type = 1;
            }
            else
            {
                reply.type = 0;
            }
          
            NetClient.GetCrossClient().SendData<C2SNwarPickBossChipStop>(NetMsg.MSG_NWAR_PICK_BOSS_CHIP_STOP, reply);
            mTimer.Destroy();
            mTimer = null;

            m_pick_boss_sound_id = 0;
            ClientEventMgr.Instance.FireEvent((int)(ClientEvent.CE_PICK_DROP_CONTROL_SLIDER), new CEventObjectArgs(false, 0));

            if(exec_finish_action)
            {
                Actor actor = Game.Instance.GetLocalPlayer();
                if (actor != null)
                {
                    Player player = actor as Player;
                    player.FinishPickUpEffect();
                }
            }
            
        }

        /// <summary>
        /// 拾取的碎片消失
        /// </summary>
        /// <param name="data"></param>
        void OnDisappearBossChip(CEventBaseArgs data)
        {
            if (data == null || data.arg == null)
                return;
            if (mTimer == null)
                return;
            PkgDropGive param_PkgDropGive = data.arg as PkgDropGive;
            if (mDropInfo != param_PkgDropGive)
                return;
            //GameDebug.LogError("OnDisappearBossChip");
            StopAnim(true);
            Actor local_player = Game.Instance.GetLocalPlayer();
            if(local_player != null)
                local_player.Stand();
        }

        void OnLocalPlayerExitInteraction(CEventBaseArgs data)
        {
            StopAnim(true);
        }

        void OnTimeLineFinish(CEventBaseArgs data)
        {
            uint timelineId = (uint)data.arg;
            List<uint> ids = GameConstHelper.GetUintList("GAME_PICK_BOSS_CLIP_TIMELINE_ID");
            if(ids.Contains(timelineId))
            {
                FinishPickImmediately();
            }
        }
    }
}
