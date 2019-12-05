using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIUnderAttackWindow : UIBaseWindow
    {
        GameObject mRootObj;
        Image mIcon;
        Image mHonorIcon;
        Text mLevelText;
        Button mSelectBtn;
        Image mHpFill;
        Text mNameText;

        UnitID mSelectActorUID;
        protected override void InitUI()
        {
            mRootObj = this.FindChild("UnderAttack");

            mIcon = FindChild("Icon").GetComponent<Image>(); //头像

            mHonorIcon = FindChild("Honour").GetComponent<Image>(); // 头衔

            mNameText = FindChild("Name").GetComponent<Text>();  // 名字

            mLevelText = FindChild("LevelText").GetComponent<Text>();    //等级

            mSelectBtn = FindChild("UnderAttack").GetComponent<Button>();     //按钮

            mSelectBtn.onClick.AddListener(OnClickSelectButton);

            mHpFill = FindChild("HpFill").GetComponent<Image>();

            //ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_CHANGE, OnSelectActorChange);
            //ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_SELECTACTOR_WHEN_CAST_SKILL, OnSelectActorChange);
            uint cur_idx = xc.instance_behaviour.HostileAttackBehaviour.GetHostileAttackActorObjIdx_static();
            OnShowWin(cur_idx);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.EC_ACTOR_UNDER_ATTACK_CHANGE, OnSelectActor);
            xc.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
            //ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LOCAL_PLAYER_ADD_ENEMY, AddOneEnemy);
            //ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_LEAVEAOI, OnLeaveAOI);
            base.InitUI();
        }
        protected override void ResetUI()
        {
            base.ResetUI();
        }
        public override void Show()
        {
            base.Show();
        }

        public override void Destroy()
        {
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.EC_ACTOR_UNDER_ATTACK_CHANGE, OnSelectActor);
            xc.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.EC_ACTOR_HP_CHANGE, OnActorHpChange);
            base.Destroy();
        }

        void OnClickSelectButton()
        {
            if (mSelectActorUID == null)
                return;
            Actor actor = ActorManager.Instance.GetActor(mSelectActorUID);
            if (actor == null || actor.IsDestroy || actor.collider == null)
                return;
            GameObject click_obj = actor.collider.gameObject;
            ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CLICKPLAYER, new CEventBaseArgs(click_obj));
            if (actor != null &&
                actor.IsDestroy == false && actor.GetModel() != null)
                ClientEventMgr.Instance.FireEvent((int)ClientEvent.CE_CLICKPLAYER_INFO, new CEventBaseArgs(actor.GetModel()));
        }
        void OnHideWin()
        {
            mRootObj.SetActive(false);
        }
        void OnShowWin(uint select_obj_idx)
        {
            Actor actor = ActorManager.Instance.GetActor(select_obj_idx);
            if (actor == null)
            {
                OnHideWin();
                return;
            }
            mSelectActorUID = actor.UID;
            mRootObj.SetActive(true);
            uint vocation_id = xc.ActorHelper.TypeIdToRoleId(actor.ActorId);
            string iconName = xc.RoleHelp.GetPlayerIconName(vocation_id, 0, false);
            mLevelText.text = actor.Level.ToString();
            mNameText.text = actor.UserName;
            string icon = xc.DBManager.Instance.GetDB<DBHonor>().GetHonorIcon(actor.Honor);
            if (icon == null || icon == "")
                mHonorIcon.gameObject.SetActive(false);
            else
            {
                mHonorIcon.sprite = this.LoadSprite(icon);
                mHonorIcon.gameObject.SetActive(true);
            }

            mIcon.sprite = this.LoadSprite(iconName);
            RefreshHpPanel();
        }

        void RefreshHpPanel()
        {
            if (mSelectActorUID == null)
                return;

            Actor actor = ActorManager.Instance.GetActor(mSelectActorUID);

            if(actor == null)
            {
                OnHideWin();
                return;
            }

            mHpFill.fillAmount = actor.HpPercent;
        }

        void OnSelectActor(CEventBaseArgs msg)
        {
            if (mUIObject == null)
            {
                return;
            }

            if (msg == null || msg.arg == null)
            {//取消选中目标
                OnHideWin();
                return;
            }

            uint select_obj_idx = (uint)msg.arg;
            if (select_obj_idx == 0)
            {
                OnHideWin();
                return;
            }
            OnShowWin(select_obj_idx);
        }

        void OnActorHpChange(xc.ClientEventBaseArgs msg)
        {
            if (mUIObject == null)
            {
                return;
            }

            if (mSelectActorUID == null)
            {
                return;
            }

            var actor = (Actor)msg.GetArg();
            if (actor == null)
            {
                GameDebug.LogError("actor == null");
                return;
            }
            if (mSelectActorUID == actor.UID)
            {
                RefreshHpPanel();
            }
        }
    }
}
