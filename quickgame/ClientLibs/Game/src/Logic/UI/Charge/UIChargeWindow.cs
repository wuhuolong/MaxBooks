//---------------------------------------------
// File : UIChargeWindow.cs
// Desc:  充值界面
// Authro: raorui
// Date: 2018.3.20
//---------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

using Net;
using xc.protocol;

namespace xc.ui.ugui
{
    /// <summary>
    /// 充值界面
    /// </summary>
    [wxb.Hotfix]
    public class UIChargeWindow : UIBaseWindow
    {
        #region 变量定义
        /// <summary>
        ///  充值列表中的一项
        /// </summary>
        GameObject mPayItemTemplate;

        /// <summary>
        /// 物品中间的间隔线
        /// </summary>
        GameObject mLineTemplate;

        /// <summary>
        /// 所有的列表元素
        /// </summary>
        Dictionary<uint, GameObject> mPayItems = new Dictionary<uint, GameObject>();

        /// <summary>
        /// 所有的充值信息
        /// </summary>
        List<DBPay.PayItemInfo> mPayItemInfos = new List<DBPay.PayItemInfo>();

        RectTransform mPayContentRectTrans;
        RectTransform mPayListRectTrans;
        RectTransform mRightPanelRectTrans;
        #endregion

        public UIChargeWindow()
        {
            // 送审后不还原
            mPrefabName = SDKHelper.GetPrefabName("UIChargeWindow", false);
        }

        #region 虚函数
        protected override void InitUI()
        {
            base.InitUI();
           
            mPayItemTemplate = FindChild("PayItemTemplate");
            mLineTemplate = FindChild("LineTemplate");
            mPayContentRectTrans = FindChild<RectTransform>("PayContent");
            mPayListRectTrans = FindChild<RectTransform>("PayList");
            mRightPanelRectTrans = FindChild<RectTransform>("RightPanel");

            // 韩国商城改版，UI需要挪右边位置
            if (xc.Const.Region == xc.RegionType.KOREA) {
                mRightPanelRectTrans.localPosition = new Vector2(83, -51);
            }
            else {
                mRightPanelRectTrans.localPosition = new Vector2(-110, -51);
            }

           // 读取表格数据来生成充值列表
           var db_pay = DBManager.Instance.GetDB<DBPay>();
            if (db_pay == null)
                return;

            mPayItems.Clear();
            mPayItemInfos.Clear();
            mPayItemTemplate.SetActive(false);
            var pay_item_template_trans = mPayItemTemplate.transform;
            foreach (var item_info in db_pay.PayItemList)
            {
                if (item_info == null)
                    continue;

                var db_pay_product = DBManager.Instance.GetDB<DBPayProduct>();
                DBPayProduct.PayDroductInfo product_info = db_pay_product.getProductInfo(item_info.RmbLow);
                if (product_info == null)
                    continue;

                var pay_item = GameObject.Instantiate(mPayItemTemplate) as GameObject;
                if (pay_item == null)
                    continue;

                // 设置item对应的GameObject
                var pay_trans = pay_item.transform;
                pay_trans.parent = pay_item_template_trans.parent;
                pay_item.SetActive(true);
                pay_trans.localPosition = Vector3.zero;
                pay_trans.localRotation = Quaternion.identity;
                pay_trans.localScale = Vector3.one;
                mPayItems[item_info.Id] = pay_item;
                mPayItemInfos.Add(item_info);

                // 设置item信息
                uint bought_times = ChargeManager.Instance.GetBoughtTimes(item_info.Id);
                uint limit_times = ChargeManager.Instance.GetLimitTimes(item_info.Id);
                SetPayItemInfo(pay_trans, item_info, bought_times, limit_times);
            }

            // 界面中的横线需要根据列表的数量生成(一行最多4个元素)
            int line_c = db_pay.PayItemList.Count % 4;
            int line_d = db_pay.PayItemList.Count / 4;
            int line_count = line_c == 0 ? line_d : line_d + 1;
            mLineTemplate.SetActive(false);
            var line_template_trans = mLineTemplate.transform;
            for (int i = 0; i < line_count; ++i)
            {
                var line_object = GameObject.Instantiate(mLineTemplate) as GameObject;
                if (line_object == null)
                    continue;

                line_object.SetActive(true);
                var line_trans = line_object.transform;
                line_trans.parent = line_template_trans.parent;
                line_trans.localPosition = Vector3.zero;
                line_trans.localRotation = Quaternion.identity;
                line_trans.localScale = Vector3.one;

                line_object.GetComponent<RectTransform>().SetAsFirstSibling();
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(mPayContentRectTrans);

            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_CHARGEINFO_UPDATE, OnChargeInfoUpdate);
        }

        protected override void UnInitUI()
        {
            base.UnInitUI();

            foreach(var pay_item in mPayItems.Values)
            {
                if (pay_item == null)
                    continue;

                var button = pay_item.GetComponent<Button>();
                if(button != null)
                    button.onClick.RemoveAllListeners();
            }
            mPayItems.Clear();
            mPayItemInfos.Clear();

            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_CHARGEINFO_UPDATE, OnChargeInfoUpdate);
        }

        protected override void ResetUI()
        {
            base.ResetUI();
            ChargeManager.Instance.SetOpenState();
            OnChargeInfoUpdate(null);
            UpdateTime();
            LayoutRebuilder.ForceRebuildLayoutImmediate(mPayContentRectTrans);
        }

        protected override void HideUI()
        {
            ClearTime();
            base.HideUI();
        }
        #endregion 

        #region 控件消息

        /// <summary>
        /// 点击充值按钮
        /// </summary>
        void OnClickPayButton(DBPay.PayItemInfo pay_info)
        {
            if (pay_info.LimitGID != 0)
            {
                //UIManager.Instance.ShowWindow("UIChargeTreasureWindow", pay_info);
                uint state = ChargeManager.Instance.GetLimitState();
                if (state == 0)
                {
                    //可购买0
                    UIManager.Instance.ShowWaitScreen(true, 2.0f);
                    ChargeManager.Instance.Pay(pay_info);
                }
            }
            else
            {
                UIManager.Instance.ShowWaitScreen(true, 2.0f);
                ChargeManager.Instance.Pay(pay_info);
            }
                
        }
        #endregion

        Utils.Timer WaitTimer;
        private void UpdateTime()
        {
            ClearTime();
            float time = ChargeManager.Instance.GetTodayFreshTime() * 1000;
            WaitTimer = new Utils.Timer(time, false, time,
                   (dt) =>
                   {
                       OnChargeInfoUpdate(null);
                   });
        }
        private void ClearTime()
        {
            if (WaitTimer != null)
            {
                WaitTimer.Destroy();
                WaitTimer = null;
            }
        }




        #region 内部调用
        /// <summary>
        /// 根据当前档位充值次数来设置ui的显示
        /// </summary>
        /// <param name="pay_item_trans"></param>
        /// <param name="pay_info"></param>
        /// <param name="bought_times"></param>
        /// <param name="limit_times"></param>
        void SetPayItemInfo(Transform pay_item_trans, DBPay.PayItemInfo pay_info, uint bought_times, uint limit_times)
        {
            if (pay_item_trans == null || pay_info == null)
                return;

            // 元宝数量
            var gold_num_text = GetChildComponent<Text>(pay_item_trans, "GoldTag/GoldNum");
            if(gold_num_text != null)
                gold_num_text.text  = string.Format("{0}", pay_info.Diamond);

            // 购买价格
            var price_num_text = GetChildComponent<Text>(pay_item_trans, "PriceNum");
            if (price_num_text != null) {
                var price_str = CommonTool.ParsePrice(pay_info.RmbLow);
                price_num_text.text = string.Format(xc.TextHelper.GetConstText("CODE_TEXT_LOCALIZATION_98"), price_str);
            }

            // 充值图标
            var icon_image = GetChildComponent<Image>(pay_item_trans, "Treasure");
            if (icon_image != null && !string.IsNullOrEmpty(pay_info.Icon))
            {
                var ori_sprite = icon_image.sprite;
                var new_sprite = LoadSprite(pay_info.Icon);
                if(ori_sprite != new_sprite)
                {
                    icon_image.sprite = new_sprite;
                    icon_image.SetNativeSize();
                }
            }

            // 按钮事件
            var button = pay_item_trans.GetComponent<Button>();
            if(button != null)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => { OnClickPayButton(pay_info); });
            }

            var limit_trans = pay_item_trans.Find("LimitTag");
            var present_tag_trans = pay_item_trans.Find("PresentTag");
            var gold_tag_trans = pay_item_trans.Find("GoldTag");

            // 限购物品类型
            if (pay_info.LimitGID != 0)
            {
                if(present_tag_trans != null)
                    present_tag_trans.gameObject.SetActive(false);

                if (gold_tag_trans != null)
                    gold_tag_trans.gameObject.SetActive(false);

                if (limit_trans == null)
                    return;

                limit_trans.gameObject.SetActive(true);



                uint state = ChargeManager.GetInstance().GetLimitState();
                //可购买0，可领取1，已领取2


                var limit_name_text = GetChildComponent<Text>(limit_trans, "LimitName");
                if (limit_name_text != null)
                {
                    limit_name_text.gameObject.SetActive(state == 0);
                    limit_name_text.text = GoodsHelper.GetGoodsOriginalNameByTypeId(pay_info.LimitGID);
                }

                var get_btn = GetChildComponent<Button>(limit_trans, "GetButton");
                if (get_btn != null)
                {
                    get_btn.gameObject.SetActive(state == 1);
                    get_btn.onClick.RemoveAllListeners();
                    get_btn.onClick.AddListener(() =>
                    {
                        C2SBindGoldBoxGet data = new C2SBindGoldBoxGet();
                        NetClient.GetBaseClient().SendData<C2SBindGoldBoxGet>(NetMsg.MSG_BIND_GOLD_BOX_GET, data);
                    });
                }

                var received = GetChildComponent<Transform>(limit_trans, "Received");
                if (received != null)
                    received.gameObject.SetActive(state == 2);

                var redPoint = GetChildComponent<Transform>(limit_trans, "RedPoint");
                if (redPoint != null)
                    redPoint.gameObject.SetActive(ChargeManager.Instance.GetRedPointState());

                
              
                if (state == 0)
                {
                    //可购买0
                    var limit_title = GetChildComponent<Text>(limit_trans, "LimitTitle");
                    if (limit_title != null)
                        limit_title.text = string.Format(DBConstText.GetText("CHARGE_BOX_LAST_TEXT"), GameConstHelper.GetUint("GAME_BIND_GOLD_BOX_GOLD_NUM"), GameConstHelper.GetUint("GAME_BIND_GOLD_BOX_DAYS"));
                }
                else
                {
                    //可领取1 已领取2
                    var limit_title = GetChildComponent<Text>(limit_trans, "LimitTitle");
                    if (limit_title != null)
                        limit_title.text = string.Format(DBConstText.GetText("CHARGE_BOX_LEAVE_TEXT"), GameConstHelper.GetUint("GAME_BIND_GOLD_BOX_GOLD_NUM"), ChargeManager.GetInstance().GetLimitedLeftTime());
                }


            }
            // 充值赠送元宝类型
            else
            {
                if (limit_trans != null)
                    limit_trans.gameObject.SetActive(false);

                if (gold_tag_trans != null)
                    gold_tag_trans.gameObject.SetActive(true);

                if (present_tag_trans == null)
                    return;

                if (pay_info.BonusFirst != 0 || pay_info.BonusOther != 0)
                {
                    var present_object = GetChildComponent<Transform>(present_tag_trans, "Present");
                    var present2_object = GetChildComponent<Transform>(present_tag_trans, "Present2");
                    var gold_icon = GetChildComponent<Image>(present_tag_trans, "GoldIcon");
                    var present_text = GetChildComponent<Text>(present_tag_trans, "PresentNum");

                    // 首次充值
                    if (bought_times == 0)
                    {
                        if (gold_icon != null)
                        {
                            var ori_sprite = gold_icon.sprite;
                            var new_sprite = LoadSprite(LocalPlayerManager.GetMoneySpriteName((int)pay_info.BonusFirstType));
                            if(ori_sprite != new_sprite)
                            {
                                gold_icon.sprite = new_sprite;
                            }
                        }

                        if (pay_info.BonusFirst != 0) // 首充赠送金额
                        {
                            if (present_text != null)
                                present_text.text = pay_info.BonusFirst.ToString();

                            if (present_object != null)
                                present_object.gameObject.SetActive(true);

                            if (present2_object != null)
                                present2_object.gameObject.SetActive(false);

                            present_tag_trans.gameObject.SetActive(true);
                        }
                        else
                        {
                            present_tag_trans.gameObject.SetActive(false);
                        }
                    }
                    // 多次充值
                    else
                    {
                        if (gold_icon != null)
                        {
                            var ori_sprite = gold_icon.sprite;
                            var new_sprite = LoadSprite(LocalPlayerManager.GetMoneySpriteName((int)pay_info.BonusOtherType));
                            if (ori_sprite != new_sprite)
                            {
                                gold_icon.sprite = new_sprite;
                            }
                        }

                        if (pay_info.BonusOther != 0)// 普通赠送金额
                        {
                            if (present_text != null)
                                present_text.text = pay_info.BonusOther.ToString();

                            if (present_object != null)
                                present_object.gameObject.SetActive(false);

                            if (present2_object != null)
                                present2_object.gameObject.SetActive(true);

                            present_tag_trans.gameObject.SetActive(true);
                        }
                        else
                        {
                            present_tag_trans.gameObject.SetActive(false);
                        }

                    }
                }
                else
                    present_tag_trans.gameObject.SetActive(false);
            }

            // ios审核包隐藏首冲赠送的控件
            /*if(GlobalConfig.Instance.IosPackageInfo.Open)
            {
                if (present_tag_trans != null)
                    present_tag_trans.gameObject.SetActive(false);
            }*/
            if (SysConfigManager.Instance.CheckSysHasOpened(GameConst.SYS_OPEN_BONUS_PAY) == false)
            {
                if (present_tag_trans != null)
                    present_tag_trans.gameObject.SetActive(false);
            }





            //iphone
            if (AuditManager.Instance.AuditAndIOS())
            {
                LoadMaJiaImage majiaImage = pay_item_trans.gameObject.GetComponent<LoadMaJiaImage>();
                if (majiaImage == null)
                {
                    majiaImage = pay_item_trans.gameObject.AddComponent<LoadMaJiaImage>();
                    majiaImage.mPath = string.Format("ChargeItem_{0}.png", pay_info.Diamond);
                    majiaImage.SetCallBack(() =>
                    {
                        RawImage rawImage = majiaImage.GetRawImage();
                        if (rawImage != null)
                        {
                            if (icon_image != null)
                                icon_image.gameObject.SetActive(false);
                            rawImage.rectTransform.SetAsFirstSibling();
                        }
                    });
                }
            }




        }

        /// <summary>
        /// 获取子节点上的组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent_trans"></param>
        /// <param name="child_name"></param>
        /// <returns></returns>
        T GetChildComponent<T>(Transform parent_trans, string child_name)
        {
            if (parent_trans == null)
                return default(T);

            var child_trans = parent_trans.Find(child_name);
            if (child_trans != null)
            {
                var child_component = child_trans.GetComponent<T>();
                if (child_component != null)
                    return child_component;
            }

            return default(T);
        }
        #endregion

        #region 客户端事件
        void OnChargeInfoUpdate(CEventBaseArgs data)
        {
            if (IsShow == false)
                return;

            foreach(var item_info in mPayItemInfos)
            {
                GameObject pay_item = null;
                if (mPayItems.TryGetValue(item_info.Id, out pay_item))
                {
                    if (pay_item == null)
                        continue;

                    // 设置item信息
                    uint bought_times = ChargeManager.Instance.GetBoughtTimes(item_info.Id);
                    uint limit_times = ChargeManager.Instance.GetLimitTimes(item_info.Id);
                    SetPayItemInfo(pay_item.transform, item_info, bought_times, limit_times);
                }
            }
        }
        #endregion
    }
}
