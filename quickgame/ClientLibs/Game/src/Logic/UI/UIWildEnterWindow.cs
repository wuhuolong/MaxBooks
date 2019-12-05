using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xc.protocol;

namespace xc.ui
{
    public class UIWildEnterWindow : UIBaseWindow
    {
        private UIButton mCloseBtn;
        private UIButton mEnterBtn;
        private UIButton mTmpBagBtn;
        private UILabel mSinLabel;
        private UILabel mHelpLabel;
        //private UIButton mHelpBtn;

        public UIWildEnterWindow()
        {
            mPrefabName = "UIWildEnterWindow";
        }

        protected override void InitUI()
        {
            base.InitUI();

            mCloseBtn = FindChild<UIButton>("CloseBtn");
            mEnterBtn = FindChild<UIButton>("EnterBtn");
            //mHelpBtn = FindChild<UIButton>("HelpBtn");
            mSinLabel = FindChild<UILabel>("SinLabel");
            mTmpBagBtn = FindChild<UIButton>("TempBagBtn");
            mHelpLabel = FindChild<UILabel>("HelpLabel");

            mHelpLabel.gameObject.SetActive(false);
            mUIObject.AddComponent<AutoSize>();
            mHelpLabel.gameObject.SetActive(true);
        }

        protected override void InitEvent()
        {
            base.InitEvent();

            EventDelegate.Add(mCloseBtn.onClick, OnCloseBtnClick);
            EventDelegate.Add(mEnterBtn.onClick, OnEnterBtnClick);
            //EventDelegate.Add(mHelpBtn.onClick, OnHelpBtnClick);
            EventDelegate.Add(mTmpBagBtn.onClick, OnTmpBagBtnClick);

            ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_TMP_BAG_HAVE_GOODS, OnTmpBagChanged);
        }

        protected override void UnInitEvent()
        {
            base.UnInitEvent();

            EventDelegate.Remove(mCloseBtn.onClick, OnCloseBtnClick);
            EventDelegate.Remove(mEnterBtn.onClick, OnEnterBtnClick);
            //EventDelegate.Remove(mHelpBtn.onClick, OnHelpBtnClick);
            EventDelegate.Remove(mTmpBagBtn.onClick, OnTmpBagBtnClick);

            ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_TMP_BAG_HAVE_GOODS, OnTmpBagChanged);
        }

        protected override void ResetUI()
        {
            base.ResetUI();

            var local_player = Game.GetInstance().GetLocalPlayer();
            if (local_player != null)
            {
                var sin_value = local_player.ActorAttribute.Sin;
                mSinLabel.text = string.Format("[FF0000]{0}", sin_value);
            }
            else
            {
#if UNITY_EDITOR
                GameDebug.LogWarning("UIWildEnterWindow LocalPlayer is null");
#endif
                mSinLabel.text = string.Format("[FF0000]{0}",
                    LocalPlayerManager.Instance.LocalActorAttribute.Sin.ToString());
            }

            UpdateTmpBagNotEmpty();
        }

        private void UpdateTmpBagNotEmpty()
        {
            var tmp_bag_empty = ItemManager.GetInstance().TmpBagGoodsOids.Count <= 0;
            FindChild(mTmpBagBtn.gameObject, "TipsSprite").SetActive(!tmp_bag_empty);
        }

        private void OnTmpBagChanged(CEventBaseArgs evt)
        {
            if (!IsShow)
                return;

            UpdateTmpBagNotEmpty();
        }

        private void OnCloseBtnClick()
        {
            Hide();
        }
        
        private void OnEnterBtnClick()
        {
            //var now = Game.GetInstance().ServerTime;
            //var enter_time = WildManager.Instance.LastLeaveTime + GameConst.GAME_MWAR_WILD_ENTER_CD;
            //if (now < enter_time)
            //{
            //    var sec = enter_time - now;
            //    UINotice.Instance.ShowMessage(string.Format("{0}秒后才能进入野外地图。", sec));
            //    return;
            //}

            // 重置自动战斗状态
            //InstanceManager.GetInstance().IsAutoFighting = false;
            InstanceManager.GetInstance().SetIsAutoFightingOutsideInstance(false);

            //var pack = new C2SMwarWideStart();
            //uint dungeonId = DBTextResource.ParseArrayUint(GameConstHelper.GetString("GAME_WIDE_DUNGEON_IDS"), ",")[0];
            //uint minNum = uint.MaxValue;
            //foreach (var item in WildManager.Instance.mLineAmout)
            //{
            //    if(item.Value < minNum)
            //    {
            //        minNum = item.Value;
            //        dungeonId = item.Key;
            //    }
            //}
            //pack.dungeon_id = dungeonId;
            //NetClient.GetBaseClient().SendData<C2SMwarWideStart>(NetMsg.MSG_MWAR_WIDE_START, pack);
        }
        
        private void OnHelpBtnClick()
        {
            UIManager.Instance.ShowWindow("UIWildHelpWindow");
        }

        private void OnTmpBagBtnClick()
        {
            MainGame.HeartBehavior.StartCoroutine(UIManager.Instance.ShowWindow("UITmpBagWindow"));
        }
        
    }
}
