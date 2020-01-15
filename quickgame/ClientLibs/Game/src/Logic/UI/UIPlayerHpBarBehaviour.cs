
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using xc;
using xc.ui.ugui;
using System;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIPlayerHpBarBehaviour : IUIBehaviour
    {
        GameObject mUIObject;

        Text mNameText;
        Image mHonorIcon;
        Image mPlayerIconImage;
        Image mLvBgImage;
        Image mPeakLvBgImage;
        UIPhotoFrameWidget mPlayerPhotoFrame;
        Text mLvText;
        Slider mScoreSlider;
        Text mHpText;
        ActorMono mTargetMono;

        bool m_is_active;

        ActorMono mLastEnemyActorMono;
        Button mPlayerIconImageBtn;
        public override void InitBehaviour()
        {
            InitUI();
            InitEvent();
            base.InitBehaviour();
        }

        public override void UpdateBehaviour()
        {
            base.UpdateBehaviour();
        }

        public override void DestroyBehaviour()
        {
            UninitEvent();
            mUIObject = null;
            mTargetMono = null;
            base.DestroyBehaviour();
        }

        public override void EnableBehaviour(bool isEnable)
        {
            base.EnableBehaviour(isEnable);
            SetActive_check(m_is_active);
            if (IsEnable == false)
                mTargetMono = null;
            //GameDebug.LogError("start EnableBehaviour = " + isEnable.ToString());
            TryRefreshSelectPlayer();
            //GameDebug.LogError("end EnableBehaviour = " + isEnable.ToString());
        }

        void InitUI()
        {
            
            mUIObject = UIHelper.FindChild(Window.mUIObject, "PlayerHpBar");
            mUIObject.SetActive(false);
            
            //GameDebug.LogError("start InitUI = " + m_is_active.ToString());
            SetActive_check(false);
            m_is_active = false;

            mHonorIcon = UIHelper.FindChild(mUIObject, "HonorIcon").GetComponent<Image>();
            mNameText = UIHelper.FindChild(mUIObject, "NameText").GetComponent<Text>();
            GameObject playerIcon = UIHelper.FindChild(mUIObject, "PlayerIconImage");
            mPlayerIconImage = playerIcon.GetComponent<Image>();
            mPlayerPhotoFrame = playerIcon.GetComponent<UIPhotoFrameWidget>();
            mLvBgImage = UIHelper.FindChild(mUIObject, "LvBgImage").GetComponent<Image>();
            mPeakLvBgImage = UIHelper.FindChild(mUIObject, "PeakLvBgImage").GetComponent<Image>();
            mLvText = UIHelper.FindChild(mUIObject, "LvText").GetComponent<Text>();
            mScoreSlider = UIHelper.FindChild(mUIObject, "ScoreSlider").GetComponent<Slider>();
            mPlayerIconImageBtn = UIHelper.FindChild(mUIObject, "PlayerIconImageTouch").GetComponent<Button>();
            mPlayerIconImageBtn.onClick.AddListener(OnClickPlayerBtn);
            mHpText = UIHelper.FindChild(mUIObject, "HpText").GetComponent<Text>();
        }

        void InitEvent()
        {
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE, OnExchangePVPState);
            //ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_BATTLESTATUS_CHANGE, OnBattleStatusChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL, OnSelectActorChange);
            xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_ADD_ENEMY, AddOneEnemy);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LEAVEAOI, OnLeaveAOI);
        }

        void UninitEvent()
        {
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_EXCHANGE_PVP_STATE, OnExchangePVPState);
            //ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_BATTLESTATUS_CHANGE, OnBattleStatusChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL, OnSelectActorChange);
            xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_ADD_ENEMY, AddOneEnemy);
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_LEAVEAOI, OnLeaveAOI);
        }

        void OnExchangePVPState(CEventBaseArgs msg)
        {
            TryRefreshSelectPlayer();
        }

        /// <summary>
        /// 点击玩家头像按钮
        /// </summary>
        void OnClickPlayerBtn()
        {
            if (mTargetMono != null && mTargetMono.BindActor != null && 
                mTargetMono.BindActor.IsDestroy == false && mTargetMono.BindActor.GetModel() != null)
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CLICKPLAYER_INFO, new CEventBaseArgs(mTargetMono.BindActor.GetModel()));
        }
        void OnSelectActorChange(CEventBaseArgs msg)
        {
            if (mUIObject == null)
            {
                return;
            }

            if (msg == null || msg.arg == null)
            {//取消选中目标
                if(mTargetMono != null)
                    TryRefreshSelectPlayer();
                return;
            }

            var monoActor = msg.arg as ActorMono;
            if (monoActor == null || monoActor.BindActor == null)
            {
                if(mTargetMono != null)
                    TryRefreshSelectPlayer();
                return;
            }

            if (mTargetMono != null && monoActor.BindActor.UID == mTargetMono.BindActor.UID)
            {
                return;
            }

            TryRefreshSelectPlayer();
        }

        public void SetInfoPanel()
        {
            if(mTargetMono == null)
            {
                SetHpBarPanelVisible(false);
                return;
            }
            var actor = mTargetMono.BindActor;
            if(actor == null)
            {
                SetHpBarPanelVisible(false);
                return;
            }
            uint vocation_id = ActorHelper.TypeIdToRoleId(actor.ActorId);
            string iconName = RoleHelp.GetPlayerIconName(vocation_id, actor.TransferLv, false);

            uint peakLevel = 0;
            bool isPeak = TransferHelper.IsPeak((uint)actor.Level, out peakLevel, actor.TransferLv);
            if (isPeak == true)
            {
                mLvBgImage.gameObject.SetActive(false);
                mPeakLvBgImage.gameObject.SetActive(true);
            }
            else
            {
                mLvBgImage.gameObject.SetActive(true);
                mPeakLvBgImage.gameObject.SetActive(false);
            }
            mLvText.text = string.Format("{0}", peakLevel.ToString());

            string replaceName = DBInstanceTypeControl.Instance.GetReplaceOtherPlayerName(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType);
            if(replaceName == null || replaceName == "")
            {
                mNameText.text = actor.UserName;
            }
            else
            {
                mNameText.text = replaceName;
            }

            
            var icon = xc.DBManager.Instance.GetDB<xc.DBHonor>().GetHonorIcon(actor.Honor);
            if(icon == null || icon == "")
                mHonorIcon.gameObject.SetActive(false);
            else
            {
                mHonorIcon.sprite = Window.LoadSprite(icon);
                mHonorIcon.gameObject.SetActive(true);
            }
            
            mPlayerIconImage.sprite = Window.LoadSprite(iconName);
            SetHpBarPanel();

            AvatarProperty ap = actor.mAvatarCtrl.GetLatestAvatartProperty();
            if(ap == null)
            {
                mPlayerPhotoFrame.Clean();
            }
            else
            {
                mPlayerPhotoFrame.SetModelId(ap.FashionPhotoFrameId);
            }
        }


        void TryRefreshSelectPlayer()
        {
            if (DBInstanceTypeControl.Instance.HidePvpHpBar(InstanceManager.Instance.InstanceType, InstanceManager.Instance.InstanceSubType))
            {
                SetHpBarPanelVisible(false);
                return;
            }

            ActorMono perfect_player = GetPerfectPlayer();
            if (perfect_player != null && perfect_player == mTargetMono)
                return;
            mTargetMono = perfect_player;
            if (mTargetMono == null)
            {
                SetHpBarPanelVisible(false);
            }
            else
            {
                SetHpBarPanelVisible(true);
                SetInfoPanel();
            }
        }

        ActorMono GetPerfectPlayer()
        {
            
            var local_player = Game.Instance.GetLocalPlayer();
            if (local_player == null || local_player.IsDestroy)
                return null;
            if (local_player.AttackCtrl != null
                && local_player.AttackCtrl.CurSelectActor != null)
            {
                ActorMono localPlayerSelectActor = local_player.AttackCtrl.CurSelectActor;
                if(localPlayerSelectActor.BindActor != null && localPlayerSelectActor.BindActor.IsDestroy == false)
                {
                    if(localPlayerSelectActor.BindActor.IsPlayer() && localPlayerSelectActor.BindActor.IsLocalPlayer == false)
                        return localPlayerSelectActor;
//                     bool show_tips = false;
//                     if(PKModeManagerEx.Instance.IsLocalPlayerCanAttackActor(localPlayerSelectActor.BindActor, ref show_tips))
//                     {
//                         return localPlayerSelectActor;
//                     }
                }
            }

            if (PKModeManagerEx.Instance.IsPVPBattleState == false)
                return null;
            if (mLastEnemyActorMono != null && mLastEnemyActorMono.BindActor != null &&
                mLastEnemyActorMono.BindActor.IsDestroy == false)
            {
                if(local_player.AttackCtrl != null && local_player.transform != null &&
                    mLastEnemyActorMono.BindActor.transform != null)
                {
                    float max_range = local_player.AttackCtrl.LeaveRange;
                    if((local_player.transform.position - mLastEnemyActorMono.BindActor.transform.position).sqrMagnitude < max_range * max_range)
                        return mLastEnemyActorMono;
                }
                
            }
            return null;
        }


        void OnActorHpChange(xc.ClientEventBaseArgs msg)
        {
            if (mUIObject == null)
            {
                return;
            }

            if (mTargetMono == null || mTargetMono.BindActor == null)
            {
                return;
            }

            var actor = (Actor)msg.GetArg();
            if (actor == null)
            {
                GameDebug.LogError("actor == null");
                return;
            }

            var targetActor = (Actor)mTargetMono.BindActor;
            if (targetActor.UID == actor.UID)
            {
                SetHpBarPanel();
            }
        }

        void SetHpBarPanel()
        {//刷新血量
            if (mTargetMono == null)
            {
                SetHpBarPanelVisible(false);
                return;
            }
            var actor = mTargetMono.BindActor;
            if (actor == null)
            {
                SetHpBarPanelVisible(false);
                return;
            }

            mScoreSlider.value = actor.HpPercent;
            mHpText.text = string.Format("{0}/{1}", actor.CurLife, actor.FullLife);
        }

        void AddOneEnemy(CEventBaseArgs data)
        {
            if (data == null || data.arg == null)
                return;

            UnitID uid = data.arg as UnitID;

            if (uid == null)
                return;
            Actor enemy_actor = ActorManager.Instance.GetActor(uid);
            if (enemy_actor != null && enemy_actor.IsPlayer() && enemy_actor.IsLocalPlayer == false)
            {
                mLastEnemyActorMono = enemy_actor.GetActorMono();
                TryRefreshSelectPlayer();
            }
        }

        void OnLeaveAOI(CEventBaseArgs data)
        {
            if (data == null || data.arg == null)
                return;
            uint leave_uuid = (uint)data.arg;
            if(mLastEnemyActorMono != null && mLastEnemyActorMono.BindActor != null && leave_uuid == mLastEnemyActorMono.BindActor.UID.obj_idx)
            {
                mLastEnemyActorMono = null;
                TryRefreshSelectPlayer();
            }
        }

        void SetHpBarPanelVisible(bool isVisible)
        {
            if (mUIObject != null && m_is_active != isVisible)
            {
                SetActive_check(isVisible);
            }
            if (mUIObject)
            {
                mUIObject.SetActive(isVisible);
            }
        }
        void SetActive_check(bool var_is_active)
        {
            //GameDebug.LogError("var_is_active = " + var_is_active.ToString());
            m_is_active = var_is_active;
            if (mUIObject != null && var_is_active)
            {
                mUIObject.SetActive(var_is_active);
            }
            UIBossHpBarBehaviour.SetShowPlayerHp(var_is_active);
            //             string state = var_is_active == true ? "Battle" : "Normal";
            //             ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_MAINMAP_STATE_CHANGED, new CEventBaseArgs(state));
        }
    }
}