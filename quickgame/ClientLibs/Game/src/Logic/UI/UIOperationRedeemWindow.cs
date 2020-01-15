using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using xc.ui;

namespace xc
{
    namespace ui
    {
        [wxb.Hotfix]
        public class UIOperationRedeemWindow : UIBaseWindow
        {
            private OperationRedeemManager.ShopType mCurrentShopType = OperationRedeemManager.ShopType.STUFF;
            private OperationRedeemCommodity mCurrentCommodity = null;

            private UIButton mCloseButton;
            private UIButton mReduceButton;
            private UIButton mMaxButton;
            private UIButton mAddButton;
            private UIToggle mStuffToggle;
            private UIToggle mFashionToggle;
            private UILabel mCommodityNameLabel;
            private UILabel mCommodityDescriptLabel;
            private UIButton mBuyButton;
            private UIInput mBuyNumberInput;
            private UILabel mCostMoneyLabel;
            private UILabel mStuffRedeemVoucherNumLabel;
            private UILabel mFashionRedeemVoucherNumLabel;
            private UIScrollView mCommodityScrollView;
            private UISprite mCostMoneyTypeSprite;
            private Transform mCommodityContent;
            private GameObject mCommoditySampleItem;

            public UIOperationRedeemWindow()
            {
                mPrefabName = "UIOperationRedeemWindow";
            }

            protected override void InitUI()
            {
                mCloseButton = FindChild<UIButton>("CloseButton");
                mReduceButton = FindChild<UIButton>("ReduceButton");
                mMaxButton = FindChild<UIButton>("MaxButton");
                mAddButton = FindChild<UIButton>("AddButton");
                mStuffToggle = FindChild<UIToggle>("StuffToggle");
                mFashionToggle = FindChild<UIToggle>("FashionToggle");
                mCommodityNameLabel = FindChild<UILabel>("CommodityNameLabel");
                mCommodityDescriptLabel = FindChild<UILabel>("CommodityDescriptLabel");
                mBuyButton = FindChild<UIButton>("BuyButton");
                mBuyNumberInput = FindChild<UIInput>("BuyNumberInput");
                mCostMoneyLabel = FindChild<UILabel>("CostMoneyLabel");
                mStuffRedeemVoucherNumLabel = FindChild<UILabel>("StuffRedeemVoucherNumLabel");
                mFashionRedeemVoucherNumLabel = FindChild<UILabel>("FashionRedeemVoucherNumLabel");
                mCostMoneyTypeSprite = FindChild<UISprite>("CostMoneyTypeSprite");
                mCommodityScrollView = FindChild<UIScrollView>("CommodityScrollView");
                mCommodityContent = FindChild<Transform>("CommodityContent");
                mCommoditySampleItem = FindChild("CommodityItem");
                mCommoditySampleItem.transform.parent = null;

                mUIObject.AddComponent<AutoSize>();
            }

            protected override void InitEvent()
            {
                base.InitEvent();

                EventDelegate.Add(mCloseButton.onClick, OnCloseButtonClicked);
                EventDelegate.Add(mMaxButton.onClick, OnMaxButtonClicked);
                EventDelegate.Add(mAddButton.onClick, OnAddButtonClicked);
                EventDelegate.Add(mBuyButton.onClick, OnBuyButtonClicked);
                EventDelegate.Add(mReduceButton.onClick, OnReduceButtonClicked);
                EventDelegate.Add(mStuffToggle.onChange, OnStuffToggleClicked);
                EventDelegate.Add(mFashionToggle.onChange, OnFashionToggleClicked);
                EventDelegate.Add(mBuyNumberInput.onChange, OnBuyNumberInputChanged);

                ClientEventMgr.GetInstance().SubscribeClientEvent((int)ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
                Utils.ClientEventManager<ClientEvent>.Instance.SubscribeClientEvent(ClientEvent.COMMODITIES_RECEIVED, OnCommoditiesInfosReceived);
            }

            protected override void UnInitEvent()
            {
                base.UnInitEvent();

                ClientEventMgr.GetInstance().UnsubscribeClientEvent((int)ClientEvent.CE_MONEY_UPDATE, OnMoneyUpdate);
                Utils.ClientEventManager<ClientEvent>.Instance.UnsubscribeClientEvent(ClientEvent.COMMODITIES_RECEIVED, OnCommoditiesInfosReceived);
            }

            protected override void UnInitUI()
            {
                base.UnInitUI();

                if (mCommoditySampleItem != null)
                {
                    mCommoditySampleItem.transform.parent = null;
                    GameObject.Destroy(mCommoditySampleItem);
                    mCommoditySampleItem = null;
                }
            }

            public override void Show()
            {
                OperationRedeemNet.Instance.GetCommodities();

                base.Show();
            }

            public void ShowTab(OperationRedeemManager.ShopType type)
            {
                Show();

                mFashionToggle.value = false;
                mStuffToggle.value = true;
                mCurrentShopType = type;

                UpdateContent();
            }

            private void UpdateMoneyLabel()
            {
//                mStuffRedeemVoucherNumLabel.text = LocalPlayerManager.Instance.StuffRedeemVoucher.ToString();
//                mFashionRedeemVoucherNumLabel.text = LocalPlayerManager.Instance.FashionRedeemVoucher.ToString();
            }

            private void UpdateContent()
            {
                UpdateMoneyLabel();

                ModelHelper.ClearChildren(mCommodityContent);

                const int ITEM_WIDTH = 168;
                const int ITEM_HEIGHT = 192;

                List<OperationRedeemCommodity> commodites = OperationRedeemManager.Instance.FashionCommodities;

                if(mCurrentShopType == OperationRedeemManager.ShopType.STUFF)
                {
                    commodites = OperationRedeemManager.Instance.StuffCommodities;
                }

                int index = 0;
                foreach (var item in commodites)
                {
                    GameObject itemObject = GameObject.Instantiate(mCommoditySampleItem) as GameObject;
                    itemObject.transform.parent = mCommodityContent;
                    itemObject.transform.localScale = Vector3.one;
                    itemObject.transform.localPosition = new Vector3((index % 3) * ITEM_WIDTH, -(index / 3) * ITEM_HEIGHT, 0);

                    UILabel nameLabel = ModelHelper.FindChildComponentInHierarchy<UILabel>(itemObject.transform, "NameLabel");
                    UILabel priceLabel = ModelHelper.FindChildComponentInHierarchy<UILabel>(itemObject.transform, "PriceLabel");
                    UIToggle itemToggle = itemObject.GetComponent<UIToggle>();
                    UISprite moneyTypeSprite = ModelHelper.FindChildComponentInHierarchy<UISprite>(itemObject.transform, "MoneyTypeSprite");
                    GameObject limitTimeContainer = ModelHelper.FindChildInHierarchy(itemObject.transform, "LimitTimeContainer").gameObject;

                    Transform iconGoodsRoot = ModelHelper.FindChildComponentInHierarchy<Transform>(itemObject.transform, "IconGoodsRoot");

                    priceLabel.text = item.Price.ToString();
                    moneyTypeSprite.spriteName = UIWidgetHelp.GetMoneySpriteName(item.PriceType);

                    if(item.EndTime > 0)
                    {
                        limitTimeContainer.SetActive(true);
                    }
                    else
                    {
                        limitTimeContainer.SetActive(false);
                    }

                    GameObject iconGoods = UIWidgetHelp.Instance.CreateGoodsItem(item.IconGoodsId, 0, false, false);
                    iconGoods.transform.parent = iconGoodsRoot;
                    iconGoods.transform.localPosition = new Vector3(0, 39, 0);
                    iconGoods.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

                    Collider iconCollider = iconGoods.GetComponent<Collider>();
                    if(iconCollider != null)
                    {
                        GameObject.Destroy(iconCollider);
                        iconCollider = null;
                    }

                    nameLabel.text = GoodsHelper.GetGoodsOriginalNameByTypeId(item.IconGoodsId);
                    itemToggle.Param = item;

                    EventDelegate.Add(itemToggle.onChange, OnItemToggleClicked);

                    if(index == 0)
                    {
                        itemToggle.value = true;
                    }

                    ++index;
                }

                mCommodityScrollView.ResetPosition();

                mReduceButton.gameObject.SetActive(true);
                mAddButton.gameObject.SetActive(true);
                mMaxButton.gameObject.SetActive(true);
            }

            private uint GetCurrentBuyNumber()
            {
                uint result = 0;

                uint.TryParse(mBuyNumberInput.value, out result);

                if(result > GameConstHelper.GetUint("meConst.GAME_SHOP_MAX_BUY_NUMBER"))
                {
                    result = GameConstHelper.GetUint("GAME_SHOP_MAX_BUY_NUMBER");
                    mBuyNumberInput.value = result.ToString();
                }

                return result;
            }

            private void OnItemToggleClicked()
            {
                UIToggle toggle = UIToggle.current;

                if(toggle.value == false)
                {
                    return;
                }

                OperationRedeemCommodity commodity = (OperationRedeemCommodity)toggle.Param;
                mCurrentCommodity = commodity;

                if (commodity == null)
                {
                    return;
                }

                mCommodityNameLabel.text = GoodsHelper.GetGoodsOriginalNameByTypeId(commodity.IconGoodsId);
                mCommodityDescriptLabel.text = GoodsHelper.GetGoodsDescriptionByTypeId(commodity.IconGoodsId);
                mCostMoneyTypeSprite.spriteName = UIWidgetHelp.GetMoneySpriteName(commodity.PriceType);
                mBuyNumberInput.value = "1";

                UpdateCostMoneyLabel();
            }

            private void OnBuyButtonClicked()
            {
                
                if(mCurrentCommodity == null)
                {
                    return;
                }

                uint num = GetCurrentBuyNumber();

                if(num <= 0)
                {
                    return;
                }

                uint money = LocalPlayerManager.Instance.GetMoneyByConst((ushort)mCurrentCommodity.PriceType);

                if (money < mCurrentCommodity.Price)
                {
                    if (mCurrentCommodity.PriceType == GameConst.MONEY_DIAMOND)
                    {
                        AssistantData.EResType[] list = new AssistantData.EResType[] { AssistantData.EResType.Diamond };
                        AssistantManager.Instance.ShowResGainWnd(OnCloseButtonClicked, list);
                    }

                    UINotice.Instance.ShowMessage(string.Format(TextHelper.GetConstText("GOODS_NOT_ENOUGH"), LocalPlayerManager.GetMoneyNameByConst((ushort)mCurrentCommodity.PriceType)));

                    return;
                }

                OperationRedeemNet.Instance.Buy(mCurrentCommodity.Id, num);
            }

            private void OnStuffToggleClicked()
            {
                if(mStuffToggle.value == false)
                {
                    return;
                }

                mCurrentShopType = OperationRedeemManager.ShopType.STUFF;
                UpdateContent();
            }

            private void OnFashionToggleClicked()
            {
                if(mFashionToggle.value == false)
                {
                    return;
                }

                mCurrentShopType = OperationRedeemManager.ShopType.FASHION;
                UpdateContent();
            }

            private void OnCloseButtonClicked()
            {
                UIManager.GetInstance().DestroyWindow(mPrefabName);
            }

            private void OnReduceButtonClicked()
            {
                uint num = GetCurrentBuyNumber();

                if(num < 1)
                {
                    return;
                }

                mBuyNumberInput.value = (num - 1).ToString();
            }

            private void OnAddButtonClicked()
            {
                uint num = GetCurrentBuyNumber();

                mBuyNumberInput.value = (num + 1).ToString();
            }

            private void OnMaxButtonClicked()
            {
                if(mCurrentCommodity == null)
                {
                    return;
                }

                uint money = LocalPlayerManager.Instance.GetMoneyByConst((ushort)mCurrentCommodity.PriceType);
                uint num = money / mCurrentCommodity.Price;

                if(num < 1)
                {
                    num = 1;
                }

                if(num > GameConstHelper.GetUint("GAME_SHOP_MAX_BUY_NUMBER"))
                {
                    num = GameConstHelper.GetUint("GAME_SHOP_MAX_BUY_NUMBER");
                }

                mBuyNumberInput.value = num.ToString();
            }

            private void UpdateCostMoneyLabel()
            {
                if (mCurrentCommodity == null)
                {
                    return;
                }

                uint num = GetCurrentBuyNumber();

                mCostMoneyLabel.text = (num * mCurrentCommodity.Price).ToString();
            }

            private void OnBuyNumberInputChanged()
            {
                UpdateCostMoneyLabel();
            }

            private void OnMoneyUpdate(CEventBaseArgs evt)
            {
                if (this.IsShow == false)
                {
                    return;
                }

                UpdateMoneyLabel();
            }

            private void OnCommoditiesInfosReceived(Utils.ClientEventBaseArgs args)
            {
                UpdateContent();
            }
        }
    }
}