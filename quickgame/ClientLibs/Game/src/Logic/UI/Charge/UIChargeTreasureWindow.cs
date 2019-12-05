//---------------------------------------------
// File : UIChargeTreasureWindow.cs
// Desc:  充值限购商品的展示界面
// Authro: raorui
// Date: 2018.3.20
//---------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using xc.ui;

namespace xc.ui.ugui
{
    /// <summary>
    /// 充值界面
    /// </summary>
    [wxb.Hotfix]
    public class UIChargeTreasureWindow : UIBaseWindow
    {
        private List<UIItemNewSlot> mItemSlots = new List<UIItemNewSlot>();
        private GameObject mTemplateObj = null;
        private Button mCloseButton;
        private Button mBuyButton;
        private Text mBuyText;
        private DBPay.PayItemInfo mPayItemInfo;

        public UIChargeTreasureWindow()
        {
            mWndName = "UIChargeTreasureWindow";
        }

        protected override void InitUI()
        {
            base.InitUI();

            mTemplateObj = FindChild("UIGoodsItem");
            mCloseButton = FindChild<Button>("CloseButton");
            mBuyButton = FindChild<Button>("BuyButton");
            mBuyText = FindChild<Text>("BuyText");

            if (mCloseButton != null)
                mCloseButton.onClick.AddListener(delegate () { UIManager.Instance.CloseWindow("UIChargeTreasureWindow"); });

            if (mBuyButton != null)
                mBuyButton.onClick.AddListener(OnClickBuyButton);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CHARGEINFO_UPDATE, OnChargeInfoUpdate);
        }

        protected override void UnInitUI()
        {
            base.UnInitUI();

            ClearReward();
            mItemSlots.Clear();
            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CHARGEINFO_UPDATE, OnChargeInfoUpdate);

        }

        protected override void ResetUI()
        {
            base.ResetUI();

            if (ShowParam == null || ShowParam.Length <= 0)
                return;

            var item_info = (DBPay.PayItemInfo)ShowParam[0];
            mPayItemInfo = item_info;
            uint limit_times = ChargeManager.Instance.GetLimitTimes(item_info.Id);

            if(item_info.TreasureGID != null)
            {
                int i = 0;
                foreach(var gid in item_info.TreasureGID.Keys)
                {
                    var num = item_info.TreasureGID[gid];
                    SetReward(i, gid, num);
                    i++;
                }
            }

            if (limit_times >= mPayItemInfo.LimitTimes)
            {
                mBuyButton.interactable = false;
                mBuyText.text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_96");
            }
            else
            {
                mBuyButton.interactable = true;
                mBuyText.text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_97");
            }
        }

        protected override void HideUI()
        {
            base.HideUI();

            ClearReward();
        }

        /// <summary>
        /// 设置奖励信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="gid"></param>
        /// <param name="bind"></param>
        /// <param name="num"></param>
        void SetReward(int index, uint gid, uint num)
        {
            UIItemNewSlot item_slot = null;
            if (index >= mItemSlots.Count)
            {
                item_slot = UIItemNewSlot.Bind(mTemplateObj).ReplaceItemPrefab();
                mItemSlots.Add(item_slot);
            }
            else
                item_slot = mItemSlots[index];

            var goods = GoodsHelper.CreateGoodsByTypeId(gid);
            goods.num = (ulong)num;

            var type_parse = UIItemNewSlot.CreateUIItemTypeParse(2);
            item_slot.setItemInfo(goods, type_parse);
        }

        void ClearReward()
        {
            foreach(var item in mItemSlots)
            {
                if (item == null)
                    continue;

                item.Clear();
            } 
        }

        void OnClickBuyButton()
        {
            Close();
            UIManager.Instance.ShowWaitScreen(true, 2.0f);
            ChargeManager.Instance.Pay(mPayItemInfo);
        }

        #region 客户端事件
        /// <summary>
        /// 响应支付信息改变的事件
        /// </summary>
        /// <param name="data"></param>
        void OnChargeInfoUpdate(CEventBaseArgs data)
        {
            if (IsShow == false)
                return;

            if (mPayItemInfo == null)
                return;

            // 需要更新购买按钮的状态
            uint limit_times = ChargeManager.Instance.GetLimitTimes(mPayItemInfo.Id);

            if (limit_times >= mPayItemInfo.LimitTimes)
            {
                mBuyButton.interactable = false;
                mBuyText.text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_96");
            }
            else
            {
                mBuyButton.interactable = true;
                mBuyText.text = xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_97");
            }
        }
        #endregion
    }
}
