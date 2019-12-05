using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using xc.ui;
using Net;
using xc.protocol;

namespace xc
{
    namespace ui
    {
        [wxb.Hotfix]
        public class UIPayWindow : UIBaseWindow
        {
            //--------------------------------------------------------
            //  变量定义
            //--------------------------------------------------------
            UIButton mCloseButton;

            UIScrollView mItemListScrollView;
            GameObject mItemGameObject;
            UIGrid mItemListGrid;
            
            //--------------------------------------------------------
            //  构造函数
            //--------------------------------------------------------
            public UIPayWindow()
            {
                mPrefabName = "UIPayWindow";
            }
                    
            //--------------------------------------------------------
            //  虚函数
            //--------------------------------------------------------
            protected override void InitUI()
            {
                base.InitUI();
                
                GameObject childObj;
                childObj = FindChild("CloseButton");
                mCloseButton = childObj.GetComponent<UIButton>();

                childObj = FindChild("ItemListPanel");
                mItemListScrollView = childObj.GetComponent<UIScrollView>();
                
                childObj = FindChild("ItemListGrid");
                mItemListGrid = childObj.GetComponent<UIGrid>();
                
                mItemGameObject = FindChild("ItemButton");
                mItemGameObject.SetActive(false);

                mUIObject.AddComponent<AutoSize>();
                mHideSceneFlag = (byte)EHideRender.F_HideAll;
            }
            
            protected override void UnInitUI()
            {
                base.UnInitUI();
            }
            
            protected override void InitEvent()
            {
                base.InitEvent();
                
                // 注册控件消息
                EventDelegate.Add(mCloseButton.onClick, OnClickCloseButton);
                
                // 注册网络消息
                Game.GetInstance().SubscribeNetNotify(NetMsg.MSG_DEPOSIT_ACT_LIST, HandleServerData);
                
                // 注册客户端消息
            }
            
            protected override void UnInitEvent()
            {
                base.UnInitEvent();
                
                // 取消注册客户端消息
                
                // 取消注册网络消息
                Game.GetInstance().UnsubscribeNetNotify(NetMsg.MSG_DEPOSIT_ACT_LIST, HandleServerData);
                
                // 取消注册控件消息
                EventDelegate.Remove(mCloseButton.onClick, OnClickCloseButton);
            }
            
            protected override void ResetUI()
            {
                base.ResetUI();

                RemoveAllGridItem(mItemListGrid, "ItemToggle");

                C2SDepositActList msg = new C2SDepositActList();
                NetClient.GetBaseClient().SendData<C2SDepositActList>(NetMsg.MSG_DEPOSIT_ACT_LIST, msg);
            }
            
            protected override void ResetVar()
            {
                base.ResetVar();
            }
            
            protected override void HideUI()
            {
                base.HideUI();
            }
            
            //--------------------------------------------------------
            //  内部调用
            //--------------------------------------------------------
            void InsertOneItem(UIGrid grid, GameObject itemGameObject, uint rmb, uint diamond, string iconName, PkgDepositAct payActivity)
            {
                Transform rootTrans = itemGameObject.transform.parent;
                GameObject item = UIMain.InstUIObject(itemGameObject);
                Transform itemTrans = item.transform;
                itemTrans.localScale = Vector3.one;

                // 图标
                UISprite iconSprite = itemTrans.FindChild("IconSprite").GetComponent<UISprite>();
                iconSprite.spriteName = iconName;
                iconSprite.MakePixelPerfect();

                // 钻石
                itemTrans.FindChild("DiamondLabel").GetComponent<UILabel>().text = "[b]" + diamond.ToString()/* + DBConstText.GetText("MONEY_DIAMOND_NAME")*/;

                // 人民币
                itemTrans.FindChild("RMBLabel").GetComponent<UILabel>().text = "[b]" + rmb.ToString();

                // 充值活动
                GameObject activityGameObject = itemTrans.FindChild("ActivityBgSprite").gameObject;
                GameObject firstDoubleGameObject = activityGameObject.transform.FindChild("FirstDoubleSprite").gameObject;
                firstDoubleGameObject.SetActive(false);
                GameObject giveExtraGameObject = activityGameObject.transform.FindChild("GiveExtraSprite").gameObject;
                giveExtraGameObject.SetActive(false);
                bool hasActivity = false;
                if (payActivity != null)
                {
                    if (payActivity.type == (uint)PayManager.EPayActivity.None)
                    {
                    }
                    else if (payActivity.type == (uint)PayManager.EPayActivity.FirstDouble)
                    {
                        hasActivity = true;
                        firstDoubleGameObject.SetActive(true);
                    }
                    else if (payActivity.type == (uint)PayManager.EPayActivity.GetFirstDouble)
                    {
                    }
                    else if (payActivity.type == (uint)PayManager.EPayActivity.GiveExtra)
                    {
                        hasActivity = true;
                        giveExtraGameObject.SetActive(true);
                        UILabel giveExtraLabel = giveExtraGameObject.transform.FindChild("GiveExtraLabel").GetComponent<UILabel>();
                        giveExtraLabel.text = "[b]" + payActivity.rate.ToString();
                    }
                }
                if (hasActivity == false)
                {
                    activityGameObject.SetActive(false);
                }
                else
                {
                    activityGameObject.SetActive(true);
                }

                UIButton button = itemTrans.GetComponent<UIButton>();
                button.Param = rmb;
                EventDelegate.Add(button.onClick, OnClickPayButton);

                item.name = rmb.ToString();
                item.SetActive(true);
                grid.AddChild(item.transform);
            }

            void RemoveAllGridItem(UIGrid grid, string defaultItemName)
            {
                List<Transform> children = grid.GetChildList();
                foreach (Transform child in children)
                {
                    if (child.gameObject.name != defaultItemName)
                    {
                        grid.RemoveChild(child);
                        NGUITools.DestroyImmediate(child.gameObject);
                    }
                }
            }
            
            //--------------------------------------------------------
            //  外部调用
            //--------------------------------------------------------
            
            
            //--------------------------------------------------------
            //  控件消息
            //--------------------------------------------------------
            void OnClickCloseButton()
            {
                Hide();
            }

            void OnClickPayButton()
            {
                UIButton button = UIButton.current;
                if (button.Param != null)
                {
                    PayManager.Instance.GotoPay((uint)button.Param);
                }
            }
            
            //--------------------------------------------------------
            //  客户端消息
            //--------------------------------------------------------  
            
            //--------------------------------------------------------
            //  网络消息
            //--------------------------------------------------------  
            void HandleServerData(ushort protocol, byte[] data)
            {
                switch (protocol)
                {
                    case NetMsg.MSG_DEPOSIT_ACT_LIST:
                    {
                        S2CPackBase s2cPackBase = new S2CPackBase();
                        S2CDepositActList msg = s2cPackBase.DeserializePack<S2CDepositActList>(data);

                        PayManager.Instance.UpdatePayActivitys(msg.list);

                        DBPay dbPay = DBManager.GetInstance().GetDB<DBPay>();
                        foreach (DBPay.PayItemInfo payItem in dbPay.PayItemList)
                        {
                            InsertOneItem(mItemListGrid, mItemGameObject, payItem.mRmbLow, payItem.mDiamond, payItem.mIcon, PayManager.Instance.GetPayActivity(payItem.mId));
                        }
                        mItemListScrollView.ResetPosition();
                        mItemListGrid.repositionNow = true;
                        
                        break;
                    }
                    default:
                        break;
                }
            }
            
        }
        
    }
}
