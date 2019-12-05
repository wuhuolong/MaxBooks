using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using xc.ui.ugui;

namespace xc
{
    namespace ui
    {
        [wxb.Hotfix]
        public class UIWidgetHelp : xc.Singleton<UIWidgetHelp>
        {
            public GameObject mTips;
            public GameObject mLabelTips;
            public delegate void BarCloseBtnFunc();
            //             public float m_normal_damage_num_scale = 1;
            //             public float m_crit_damage_num_scale = 1;

            public enum DragDropGroup
            {
                Player = 1,
                Bag = 2,
                WareHouse = 3,
                TempBag = 4,
            }


            public UIWidgetHelp()
            {

            }

            public void Reset()
            {

            }

            /// <summary>
            /// 创建窗口对应的概率公示按钮
            /// </summary>
            /// <param name="parentGo"></param>
            /// <param name="windName"></param>
            /// <param name="scale"></param>
            /// <param name="param1_str"></param>
            /// <returns></returns>
            public GameObject CreateAndCheckProbabilityBtn(GameObject parentGo, string windName, float scale,
                string param1_str)
            {
                var probabilityRes = ugui.UIManager.Instance.MainCtrl.mProbabilityRes;
                if (parentGo == null || probabilityRes == null || probabilityRes.obj_ == null)
                {
                    return null;
                }
                //获取概率按钮的配置信息
                var db_probability_btn = DBManager.Instance.GetDB<DBProbabilityBtn>();
                if (db_probability_btn == null)
                    return null;

                var info = db_probability_btn.GetSuitableInfo(windName, param1_str);
                if (info == null)
                    return null;

                //实例化新的概率按钮物体
                GameObject gameObject = GameObject.Instantiate(probabilityRes.obj_) as GameObject;
                CommonTool.SetActive(gameObject, true);

                //设置节点的位置信息
                var trans = gameObject.transform;
                var parent_transform = parentGo.transform;

                var panel_node = info.panel_node;
                if (!string.IsNullOrEmpty(panel_node))
                {
                    var node_transform = UIHelper.FindChildInHierarchy(parentGo.transform, panel_node);
                    if (node_transform != null)
                    {
                        parent_transform = node_transform;
                    }
                }

                trans.SetParent(parent_transform);
                trans.localScale = Vector3.one;

                var rect_trans = gameObject.GetComponent<RectTransform>();
                rect_trans.anchorMax = new Vector2(0.5f, 0.5f);
                rect_trans.anchorMin = new Vector2(0.5f, 0.5f);
                rect_trans.pivot = new Vector2(0.5f, 0.5f);
                rect_trans.anchoredPosition = info.panel_pos;

                var pos = rect_trans.localPosition;
                pos.z = 0;
                rect_trans.localPosition = pos;

                var bar_trans = trans.Find("BarPanel");
                if (bar_trans != null)
                    bar_trans.localScale = new Vector3(scale, scale, scale);

                var probabilityBtn = gameObject.AddComponent<ugui.UIProbabilityPublish>();
                //probabilityBtn.SetSysID(info.sys_id);
                probabilityBtn.SetOpenURL(info.url);
                return gameObject;
            }

            /// <summary>
            /// 创建窗口对应的七日退款按钮
            /// </summary>
            /// <param name="parentGo"></param>
            /// <param name="windName"></param>
            /// <param name="scale"></param>
            /// <param name="param1_str"></param>
            /// <returns></returns>
            public GameObject CreateAndCheckRefundBtn(GameObject parentGo, string windName, float scale,
                string param1_str)
            {
                var refundRes = ugui.UIManager.Instance.MainCtrl.mRefundRes;
                if (parentGo == null || refundRes == null || refundRes.obj_ == null)
                {
                    return null;
                }
                //获取七日退款按钮的配置信息
                var db_refund_btn = DBManager.Instance.GetDB<DBRefundBtn>();
                if (db_refund_btn == null)
                    return null;

                var info = db_refund_btn.GetSuitableInfo(windName, param1_str);
                if (info == null)
                    return null;

                //实例化新的七日退款按钮物体
                GameObject gameObject = GameObject.Instantiate(refundRes.obj_) as GameObject;
                CommonTool.SetActive(gameObject, true);

                //设置节点的位置信息
                var trans = gameObject.transform;
                var parent_transform = parentGo.transform;

                var panel_node = info.panel_node;
                if (!string.IsNullOrEmpty(panel_node))
                {
                    var node_transform = UIHelper.FindChildInHierarchy(parentGo.transform, panel_node);
                    if (node_transform != null)
                    {
                        parent_transform = node_transform;
                    }
                }

                trans.SetParent(parent_transform);
                trans.localScale = Vector3.one;

                var rect_trans = gameObject.GetComponent<RectTransform>();
                rect_trans.anchorMax = new Vector2(0.5f, 0.5f);
                rect_trans.anchorMin = new Vector2(0.5f, 0.5f);
                rect_trans.pivot = new Vector2(0.5f, 0.5f);
                rect_trans.anchoredPosition = Vector2.zero;

                var button_transform = UIHelper.FindChildInHierarchy(trans.transform, "Button");
                var button_rect_trans = button_transform.GetComponent<RectTransform>();
                button_rect_trans.anchoredPosition = info.btn_panel_pos;
                var pos = button_rect_trans.localPosition;
                pos.z = 0;
                button_rect_trans.localPosition = pos;

                var button_text_trans = button_transform.Find("Text");
                if (button_text_trans != null)
                {
                    var button_text = button_text_trans.GetComponent<Text>();
                    if (button_text != null)
                    {
                        button_text.text = info.btn_text;
                    }
                }

                var button = button_rect_trans.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(() =>
                    {
                        if(info.open_type == 1) {
                            if (!string.IsNullOrEmpty(info.url)) {
                                Application.OpenURL(info.url);
                            }
                        }
                        else {
                            xc.ui.UIWidgetHelp.GetInstance().ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK_DisableCloseBtn, "", info.message_box_text, null, null);
                        }
                    });
                }

                var return_text_transform = UIHelper.FindChildInHierarchy(trans.transform, "ReturnText");
                var return_text_rect_trans = return_text_transform.GetComponent<RectTransform>();
                return_text_rect_trans.anchoredPosition = info.tips_panel_pos;
                pos = return_text_rect_trans.localPosition;
                pos.z = 0;
                return_text_rect_trans.localPosition = pos;

                var return_text_text_trans = UIHelper.FindChildInHierarchy(return_text_rect_trans, "Text");
                if (return_text_text_trans != null)
                {
                    var return_text_text = return_text_text_trans.GetComponent<Text>();
                    if (return_text_text != null)
                    {
                        return_text_text.text = info.tips_panel_text;
                    }
                }

                var bar_trans = trans.Find("BarPanel");
                if (bar_trans != null)
                    bar_trans.localScale = new Vector3(scale, scale, scale);

                return gameObject;
            }

            /// <summary>
            /// 创建窗口对应的货币栏
            /// </summary>
            /// <param name="parentGo"></param>
            /// <param name="windName"></param>
            /// <param name="scale"></param>
            /// <param name="param1_str"></param>
            /// <returns></returns>
            public GameObject CreateAndCheckMoneyBar(GameObject parentGo, string windName, float scale, string param1_str)
            {
                var currencyRes = ugui.UIManager.Instance.MainCtrl.mCurrencyRes;
                if (parentGo == null || currencyRes == null || currencyRes.obj_ == null)
                {
                    return null;
                }

                // 获取货币栏的配置信息
                var db_currency_panel = DBManager.Instance.GetDB<DBCurrencyPanel>();
                if (db_currency_panel == null)
                    return null;

                var info = db_currency_panel.GetSuitableInfo(windName, param1_str);
                if (info == null)
                    return null;

                var money_list_str = TextHelper.GetTupleFromString(info.money_type_list);

                if (money_list_str.Length <= 0)
                    return null;

                List<int> money_type_list = new List<int>();
                for (int i = 0; i < money_list_str.Length; i++)
                {
                    var item_id = int.Parse(money_list_str[i]);
                    money_type_list.Add(item_id);
                }

                // 实例化新的货币栏物体
                GameObject gameObject = GameObject.Instantiate(currencyRes.obj_) as GameObject;
                CommonTool.SetActive(gameObject, true);

                // 设置节点的位置信息
                var trans = gameObject.transform;
                var parent_transform = parentGo.transform;

                var panel_node = info.panel_node;
                if (!string.IsNullOrEmpty(panel_node))
                {
                    var node_transform = UIHelper.FindChildInHierarchy(parentGo.transform, panel_node);
                    if (node_transform != null)
                    {
                        parent_transform = node_transform;
                    }
                }

                trans.SetParent(parent_transform);
                trans.localScale = Vector3.one;

                var rect_trans = gameObject.GetComponent<RectTransform>();
                rect_trans.anchorMax = new Vector2(0.5f, 0.5f);
                rect_trans.anchorMin = new Vector2(0.5f, 0.5f);
                rect_trans.pivot = new Vector2(0.5f, 0.5f);
                rect_trans.anchoredPosition = info.panel_pos;

                var pos = rect_trans.localPosition;
                pos.z = 0;
                rect_trans.localPosition = pos;

                var bar_trans = trans.Find("BarPanel");
                if (bar_trans != null)
                    bar_trans.localScale = new Vector3(scale, scale, scale);

                var bar = gameObject.AddComponent<ugui.UICurrencyWindow>();
                bar.SetMoneyList(money_type_list);
                return gameObject;
            }

            public GameObject CreateGoodsItem(GameObject template, uint goodsID, ulong num, bool isShowTips = true, bool isScale = false, uint isBind = uint.MaxValue)
            {
                if (template == null)
                {
                    return null;
                }

                var gameObject = UIManager.Instance.UICache.GetItemGameObj(template.transform.parent, true);

                UIItemRef itemRef = template.GetComponent<UIItemRef>();

                UIItemNewSlot newSlot = template.GetComponent<UIItemNewSlot>();

                //gameObject.transform.SetParent(template.transform.parent, false);
                //gameObject.SetActive(true);

                UIItemNewSlot itemSlot;

                if (itemRef)
                {
                    itemSlot = UIItemNewSlot.Bind(gameObject, itemRef.TargetPanel, itemRef.ClipPanel);
                }
                else if (newSlot)
                {
                    itemSlot = UIItemNewSlot.Bind(gameObject, newSlot.TargetPanel, newSlot.ClipPanel);
                }
                else
                {
                    itemSlot = UIItemNewSlot.Bind(gameObject);
                }


                Goods itemInfo = GoodsHelper.CreateGoodsByTypeId(goodsID);

                if (isShowTips == false && isScale == false)
                {
                    var collider = gameObject.GetComponent<Collider>();

                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                }
                if (itemInfo == null)
                {
                    GameDebug.LogError("CreateGoodsItem error, can not find goods " + goodsID);
                    return gameObject;
                }
                itemInfo.num = num;
                if (isBind != uint.MaxValue)
                {
                    itemInfo.bind = isBind;
                }
                UIItemNewSlot.TypeParse typeParse = UIItemNewSlot.CreateUIItemTypeParse();

                if (isShowTips == true)
                    typeParse._mType = 2;
                else
                {
                    typeParse._mType = 0;
                }
                itemSlot.Clear();
                itemSlot.setItemInfo(itemInfo, typeParse, isScale);
                return gameObject;
            }

            /// <summary>
            /// 通过内存池来创建物品图标
            /// </summary>
            /// <param name="template"></param>
            /// <param name="wnd_name"></param>
            /// <param name="goodsID"></param>
            /// <param name="num"></param>
            /// <param name="isShowTips"></param>
            /// <param name="isScale"></param>
            /// <param name="isBind"></param>
            /// <returns></returns>
            public GameObject CreateGoodsItemCache(GameObject template, string wnd_name, Transform parent, uint goodsID, ulong num, bool isShowTips = true, bool isScale = false, uint isBind = uint.MaxValue)
            {
                if (template == null)
                {
                    return null;
                }

                var wnd = UIManager.instance.GetWindow(wnd_name);
                if (wnd == null)
                    return null;

                var gameObject = wnd.GetItemGameObj(parent);

                UIItemRef itemRef = template.GetComponent<UIItemRef>();

                UIItemNewSlot newSlot = template.GetComponent<UIItemNewSlot>();

                gameObject.transform.SetParent(template.transform.parent, false);
                gameObject.SetActive(true);

                UIItemNewSlot itemSlot;

                if (itemRef)
                {
                    itemSlot = UIItemNewSlot.Bind(gameObject, itemRef.TargetPanel, itemRef.ClipPanel);
                }
                else if (newSlot)
                {
                    itemSlot = UIItemNewSlot.Bind(gameObject, newSlot.TargetPanel, newSlot.ClipPanel);
                }
                else
                {
                    itemSlot = UIItemNewSlot.Bind(gameObject);
                }

                Goods itemInfo = GoodsHelper.CreateGoodsByTypeId(goodsID);

                if (isShowTips == false && isScale == false)
                {
                    var collider = gameObject.GetComponent<Collider>();

                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                }

                if (itemInfo == null)
                {
                    GameDebug.LogError("CreateGoodsItem error, can not find goods " + goodsID);
                    return gameObject;
                }
                itemInfo.num = num;
                if (isBind != uint.MaxValue)
                {
                    itemInfo.bind = isBind;
                }

                UIItemNewSlot.TypeParse typeParse = UIItemNewSlot.CreateUIItemTypeParse();

                if (isShowTips == true)
                    typeParse._mType = 2;
                else
                {
                    typeParse._mType = 0;
                }

                itemSlot.setItemInfo(itemInfo, typeParse, isScale);
                return gameObject;
            }

            /// <summary>
            /// 创建一个物品图标
            /// </summary>
            public GameObject CreateGoodsItem(Transform parent, uint goodsID, ulong num, bool isShowTips = true, bool isScale = false, uint isBind = uint.MaxValue, bool newInstace = true)
            {
                GameObject obj = UIManager.Instance.UICache.GetItemGameObj(parent, false);
                Transform trans = obj.transform;
                //trans.SetParent(parent);
                trans.localScale = Vector3.one;
                trans.localRotation = Quaternion.identity;
                trans.localPosition = Vector3.zero;

                return CreateGoodsItem(obj, goodsID, num, isShowTips, isScale, isBind);
            }


            public uint GetGoodsIdByVGoodesId(uint vGoodsId)
            {
                return (uint)(200000 + vGoodsId);
            }

            xc.ui.ugui.UIFightEffectWindow GetFightEffectWindow()
            {
                return (xc.ui.ugui.UIFightEffectWindow)xc.ui.ugui.UIManager.GetInstance().GetWindow("UIFightEffectWindow");
            }

            public void ShowDamageValue_Critic(int damageValue, float displayTimeScale, bool isLocalPlayer, Actor actor, Vector3 attacker_world_pos, FightEffectHelp.FightEffectType type)
            {
                if (damageValue <= 0)
                    return;

                var fightEffectWindow = GetFightEffectWindow();
                if (fightEffectWindow == null)
                {
                    return;
                }

                GameObject damageEffectObject = null;
                damageEffectObject = fightEffectWindow.GetObjectByFightEffectType(type);
                if (damageEffectObject == null)
                {
                    return;
                }

                int level = FightEffectHelp.GetLayoutLevel(type);
                fightEffectWindow.SetGameObjectLayoutLevel(damageEffectObject, level);

                Vector3 worldPosInScene;
                Vector2 screen_abs_offset;
                Vector3 worldPos = xc.ui.ugui.UIFightEffectWindow.GetEffectWorldPosInUIByType(actor, type, out worldPosInScene, out screen_abs_offset);
                damageEffectObject.transform.position = worldPos;
                damageEffectObject.transform.localPosition = new Vector3(damageEffectObject.transform.localPosition.x,
                    damageEffectObject.transform.localPosition.y, 0);

                Text effectValueLabel = damageEffectObject.transform.Find("Value").GetComponent<Text>();
                if (effectValueLabel != null)
                {
                    if (isLocalPlayer)
                        effectValueLabel.text = (-damageValue).ToString();
                    else if (type == FightEffectHelp.FightEffectType.OurDamage && damageValue > 0)
                        effectValueLabel.text = (-damageValue).ToString();
                    else
                        effectValueLabel.text = damageValue.ToString();
                }

                damageEffectObject.SetActive(true);

                float playTimeBySeconds = 2;
                Animation animation = damageEffectObject.GetComponentInChildren<Animation>();
                if (animation != null && animation.clip != null)
                {
                    playTimeBySeconds = animation.clip.length;
                    animation[animation.clip.name].speed = displayTimeScale;
                }

                var delay_enable = damageEffectObject.GetComponent<DelayEnableComponent>();
                delay_enable.DelayTime = playTimeBySeconds;
                delay_enable.SetEnable = false;
                delay_enable.Start();

                if (TryShowDamageWordAnim(type))
                {
                    UIFightDamageWordAnimComponent anim_component = damageEffectObject.GetComponent<UIFightDamageWordAnimComponent>();
                    if (anim_component == null)
                    {
                        anim_component = damageEffectObject.AddComponent<UIFightDamageWordAnimComponent>();
                    }
                    if (actor.transform != null)
                        anim_component.Show(displayTimeScale, worldPosInScene, attacker_world_pos, actor.transform.position, type, screen_abs_offset);
                }
            }

            public bool ShowBuffTip(string tip)
            {
                var fightEffectWindow = GetFightEffectWindow();
                if (fightEffectWindow != null)
                {
                    fightEffectWindow.ShowFightingTip(tip);
                    return true;
                }
                else
                    return false;
            }

            public void ShowDamageEffect(FightEffectHelp.FightEffectType type, long value, float displayTimeScale, Actor actor, bool show_percent, string push_str)
            {
                if (GlobalConst.IsBanshuVersion)
                {
                    if (type == FightEffectHelp.FightEffectType.AddExp)
                        return;
                }
                var fightEffectWindow = GetFightEffectWindow();
                if (fightEffectWindow == null)
                    return;
                GameObject damageEffectObject = null;
                damageEffectObject = fightEffectWindow.GetObjectByFightEffectType(type);
                if (damageEffectObject == null)
                {
                    return;
                }
                int level = FightEffectHelp.GetLayoutLevel(type);
                fightEffectWindow.SetGameObjectLayoutLevel(damageEffectObject, level);

                Vector3 worldPosInScene;
                Vector2 screen_abs_offset;
                Vector3 worldPos = xc.ui.ugui.UIFightEffectWindow.GetEffectWorldPosInUIByType(actor, type, out worldPosInScene, out screen_abs_offset);
                damageEffectObject.transform.position = worldPos;
                damageEffectObject.transform.localPosition = new Vector3(damageEffectObject.transform.localPosition.x,
                    damageEffectObject.transform.localPosition.y, 0);

                Text effectValueLabel = damageEffectObject.transform.Find("Value").GetComponent<Text>();

                if (type == FightEffectHelp.FightEffectType.OurDamage && value > 0)
                    value = -value;

                FightEffectHelp.SetEffectValue(type, effectValueLabel, value, show_percent, push_str);

                float playTimeBySeconds = 2;
                Animation animation = damageEffectObject.GetComponentInChildren<Animation>();
                if (animation != null && animation.clip != null)
                {
                    playTimeBySeconds = animation.clip.length;
                    animation[animation.clip.name].speed = displayTimeScale;
                }
                damageEffectObject.SetActive(true);

                var delay_enable = damageEffectObject.GetComponent<DelayEnableComponent>();
                delay_enable.DelayTime = playTimeBySeconds;
                delay_enable.SetEnable = false;
                delay_enable.Start();
            }

            public void ShowBubbleDlg(Transform target, string content)
            {
                return;// 闲话框已经由UI3DDialogBubble来进行处理
            }

            const float DamageDelayTime = 1.0f;
            static Vector3 DamageScale = new Vector3(10.0f, 10.0f, 1.0f);

            /// <summary>
            /// 显示伤害数字
            /// </summary>
            public void ShowDamageValue(/*Vector3 headPos, */int damageValue, float displayTimeScale, EUnitType unitType, bool isLocalPlayer, Actor actor, Vector3 attacker_world_pos, FightEffectHelp.FightEffectType type)
            {
                if (damageValue <= 0)
                    return;

                var fightEffectWindow = GetFightEffectWindow();
                if (fightEffectWindow == null)
                    return;
                GameObject damageEffectObject = null;
                damageEffectObject = fightEffectWindow.GetObjectByFightEffectType(type);
                if (damageEffectObject == null)
                    return;

                //damageEffectObject.transform.localScale = Vector3.one * m_normal_damage_num_scale;

                int level = FightEffectHelp.GetLayoutLevel(type);
                fightEffectWindow.SetGameObjectLayoutLevel(damageEffectObject, level);

                Vector3 worldPosInScene;
                Vector2 screen_abs_offset;
                Vector3 worldPos = xc.ui.ugui.UIFightEffectWindow.GetEffectWorldPosInUIByType(actor, type, out worldPosInScene, out screen_abs_offset);
                damageEffectObject.transform.position = worldPos;
                damageEffectObject.transform.localPosition = new Vector3(damageEffectObject.transform.localPosition.x,
                    damageEffectObject.transform.localPosition.y, 0);

                if (type == FightEffectHelp.FightEffectType.OneHitKill)
                {

                }
                else
                {
                    Text effectValueLabel = damageEffectObject.transform.Find("Value").GetComponent<Text>();


                    if (effectValueLabel != null)
                    {
                        if (isLocalPlayer)
                            effectValueLabel.text = (-damageValue).ToString();
                        else if (type == FightEffectHelp.FightEffectType.OurDamage && damageValue > 0)
                            effectValueLabel.text = (-damageValue).ToString();
                        else
                            effectValueLabel.text = damageValue.ToString();
                    }
                }
                damageEffectObject.SetActive(true);

                float playTimeBySeconds = 2;
                Animation animation = damageEffectObject.GetComponentInChildren<Animation>();
                if (animation != null && animation.clip != null)
                {
                    playTimeBySeconds = animation.clip.length;
                    animation[animation.clip.name].speed = displayTimeScale;
                }

                var delay_enable = damageEffectObject.GetComponent<DelayEnableComponent>();
                delay_enable.DelayTime = 2 * displayTimeScale;
                delay_enable.SetEnable = false;
                delay_enable.Start();

                if (TryShowDamageWordAnim(type))
                {
                    UIFightDamageWordAnimComponent anim_component = damageEffectObject.GetComponent<UIFightDamageWordAnimComponent>();
                    if (anim_component == null)
                    {
                        anim_component = damageEffectObject.AddComponent<UIFightDamageWordAnimComponent>();
                    }
                    anim_component.Show(displayTimeScale, worldPosInScene, attacker_world_pos, actor.transform.position, type, screen_abs_offset);
                }

            }

            public bool TryShowDamageWordAnim(FightEffectHelp.FightEffectType effect_type)
            {
                if (effect_type == FightEffectHelp.FightEffectType.EnemyDamage ||
                    effect_type == FightEffectHelp.FightEffectType.Attendant_damage ||
                    effect_type == FightEffectHelp.FightEffectType.CriticEnemyDamage ||
                    effect_type == FightEffectHelp.FightEffectType.CriticAttendantDamage)
                    return true;
                return false;
            }

            public static bool mHasBlock = false;
            public static bool BlockOtherNoticeDlg  // = false;// 不允许再弹出其他对话框
            {
                get
                {
                    return mHasBlock;
                }

                set
                {
                    mHasBlock = value;
                }
            }

            public void SetBlockNoticeDlg(bool block)
            {
                mHasBlock = block;
            }

            /// <summary>
            /// 通用提示框自动取消，如果是0则不自动取消
            /// </summary>
            public static int NoticeDlgAutoCancelTime = 0;

            /// <summary>
            /// 通用提示框自动确定，如果是0则不自动确定
            /// </summary>
            public static int NoticeDlgAutoOKTime = 0;

            /// <summary>
            /// 通用提示框的文本对其方式
            /// </summary>
            public static TextAnchor NoticeDlgAlignment = TextAnchor.MiddleLeft;

            public static bool ToggleValue = false;


            void ShowNoticeDlgImpl(UINoticeWindow.EWindowType window_type, string title, string content,
                                      xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback, System.Object ok_callback_param,
                                      xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback, System.Object cancel_callback_param,
                                      string ok_btn_text, string cancel_btn_text, string toggle_text, bool toggle_isOn, xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate ok_with_toggle_callback, string wnd_name,
                                      UINoticeWindow.OnClickToggleDelegate on_click_toggle_delegate)
            {
                xc.ui.ugui.UIManager.GetInstance().ShowWindow(wnd_name, new object[] {
                    window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param, ok_btn_text, cancel_btn_text, toggle_text, toggle_isOn, ok_with_toggle_callback, on_click_toggle_delegate
                });
            }

            public bool ShowNoticeDlg(
                UINoticeWindow.EWindowType window_type = UINoticeWindow.EWindowType.WT_OK,
                string title = "",
                string content = "",
                xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = null,
                System.Object ok_callback_param = null,
                xc.ui.ugui.UINoticeWindow.CancelBtnClickedDelegate cancel_callback = null,
                System.Object cancel_callback_param = null,
                string ok_btn_text = "",
                string cancel_btn_text = "",
                string toggle_text = "",
                bool toggle_isOn = false,
                xc.ui.ugui.UINoticeWindow.OkBtnWithToggleClickedDelegate ok_with_toggle_callback = null,
                string wnd_name = "UINoticeWindow",
                xc.ui.ugui.UINoticeWindow.OnClickToggleDelegate on_click_toggle_delegate = null
                )
            {
                if (BlockOtherNoticeDlg)
                    return false;
                if (string.IsNullOrEmpty(ok_btn_text))
                    ok_btn_text = xc.TextHelper.BtnConfirm;
                if (string.IsNullOrEmpty(cancel_btn_text))
                    cancel_btn_text = xc.TextHelper.BtnCancel;
                ShowNoticeDlgImpl(window_type, title, content, ok_callback, ok_callback_param, cancel_callback, cancel_callback_param,
                    ok_btn_text, cancel_btn_text, toggle_text, toggle_isOn, ok_with_toggle_callback, wnd_name, on_click_toggle_delegate);

                return true;
            }

            public bool ShowNoticeDlg(UINoticeWindow.EWindowType window_type, string text, xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback, System.Object ok_callback_param)
            {
                return ShowNoticeDlg(window_type, "", text, ok_callback, ok_callback_param);
            }

            public bool ShowNoticeDlg(UINoticeWindow.EWindowType window_type, string text, xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback, System.Object ok_callback_param, string wnd_name)
            {
                return ShowNoticeDlg(window_type, "", text, ok_callback, ok_callback_param, null, null, xc.TextHelper.BtnConfirm, xc.TextHelper.BtnCancel, "", false, null, wnd_name, null);
            }

            public void ShowNoticeDlg(string text, xc.ui.ugui.UINoticeWindow.OkBtnClickedDelegate ok_callback = null, System.Object ok_callback_param = null)
            {
                ShowNoticeDlg(xc.ui.ugui.UINoticeWindow.EWindowType.WT_OK, "", text, ok_callback, ok_callback_param);
            }

            /// <summary>
            /// 隐藏提示窗口
            /// </summary>
            /// <param name="wnd_name"></param>
            public void HideNoticeDlg(string wnd_name = "UINoticeWindow")
            {
                xc.ui.ugui.UIManager.GetInstance().CloseWindow(wnd_name);
            }

            public static string GetMoneySpriteName(uint moneyType)
            {

                return LocalPlayerManager.GetMoneySpriteName((int)moneyType);
            }

            public static uint GiveTypeStringToUint(string type)
            {
                if (type == "GIVE_TYPE_EXP")
                {
                    return GameConst.GIVE_TYPE_EXP;
                }

                if (type == "GIVE_TYPE_GOODS")
                {
                    return GameConst.GIVE_TYPE_GOODS;
                }

                if (type == "GIVE_TYPE_EQUIP")
                {
                    return GameConst.GIVE_TYPE_EQUIP;
                }

                if (type == "GIVE_TYPE_MONEY")
                {
                    return GameConst.GIVE_TYPE_MONEY;
                }

                return 0;
            }

            public static uint GetSpecialGIdByType(uint type, uint defaultGId)
            {
                switch (type)
                {
                    case GameConst.GIVE_TYPE_MONEY:
                        {
                            switch (defaultGId)
                            {
                                case GameConst.MONEY_COIN:
                                    {
                                        return 10001;
                                    }
                                //case GameConst.MONEY_XRMB:
                                //    {
                                //        return 10002;
                                //    }
                                case GameConst.MONEY_DIAMOND:
                                    {
                                        return 10003;
                                    }
                                //case GameConst.MONEY_HONOR:
                                //    {
                                //        return 10004;
                                //    }
                                //case GameConst.MONEY_RACE_SCORE:
                                //    {
                                //        return 10006;
                                //    }
                                default:
                                    {
                                        return defaultGId;
                                    }
                            }
                        }
                    case GameConst.GIVE_TYPE_EXP:
                        {
                            return 10005;
                        }
                    default:
                        {
                            return defaultGId;
                        }
                }
            }

            public static uint GetSpecialGIdByType(string type, uint defaultGId)
            {
                return GetSpecialGIdByType(GiveTypeStringToUint(type), defaultGId);
            }

            /// <summary>
            /// 优化大额数值的显示
            /// 数量超过一万时，则显示为万，保留一位小数点，若小数位根据四舍五入取整后为0，则不显示小数位，  例如31000=3.1万；30100=3万
            /// 超过一亿时，则显示为亿，保留一位小数点，若小数位根据四舍五入取整后为0，则不显示小数位
            /// </summary>
            /// <param name="number"></param>
            /// <param name="decimalPlaces">小数的位数</param>
            /// <returns></returns>
            public static string GetLargeNumberString(ulong number, uint decimalPlaces = 1)
            {
                string str = string.Empty;
                string unit = "";

                System.Text.StringBuilder formatStr = new System.Text.StringBuilder();
                formatStr.Append("0.");
                for (uint i = 0; i < decimalPlaces; ++i)
                {
                    formatStr.Append("#");
                }

                if (number < 10000)
                {
                    str = number.ToString();
                }
                else if (number < 100000000)
                {
                    str = Convert.ToDouble((double)number / 10000.0).ToString(formatStr.ToString());
                    unit = DBConstText.GetText("TEN_THOUSAND");
                }
                else
                {
                    str = Convert.ToDouble((double)number / 100000000.0).ToString(formatStr.ToString());
                    unit = DBConstText.GetText("HUNDRED_MILLION");
                }

                str = str + unit;

                return str;
            }

            /// <summary>
            /// 优化大额数值的显示，基本同GetLargeNumberString
            /// 数值小于等于99999，以实际数值显示
            /// 数值大于99999且小于等于999999999，以“xx.xx”+“万”字来显示，需保留2位小数。
            /// 数值大于999999999,以“xx.xx”+“亿”字来显示，需保留2位小数
            /// </summary>
            /// <param name="number"></param>
            /// <param name="decimalPlaces">小数的位数</param>
            /// <returns></returns>
            public static string GetLargeNumberString2(ulong number, uint decimalPlaces = 1)
            {
                string str = string.Empty;
                string unit = "";

                System.Text.StringBuilder formatStr = new System.Text.StringBuilder();
                formatStr.Append("0.");
                for (uint i = 0; i < decimalPlaces; ++i)
                {
                    formatStr.Append("0");
                }

                if (number <= 99999)
                {
                    str = number.ToString();
                }
                else if (number < 999999999)
                {
                    str = Convert.ToDouble((double)number / 10000.0).ToString(formatStr.ToString());
                    unit = DBConstText.GetText("TEN_THOUSAND");
                }
                else
                {
                    str = Convert.ToDouble((double)number / 100000000.0).ToString(formatStr.ToString());
                    unit = DBConstText.GetText("HUNDRED_MILLION");
                }

                str = str + unit;

                return str;
            }

            /// <summary>
            /// 优化大额数值的显示 基本同GetLargeNumberString
            /// 数量超过10万时，则显示为万，保留一位小数点，若小数位根据四舍五入取整后为0，则不显示小数位，  例如310000=30.1万；300100=30万
            /// 超过一亿时，则显示为亿，保留一位小数点，若小数位根据四舍五入取整后为0，则不显示小数位
            /// </summary>
            /// <param name="number"></param>
            /// <param name="decimalPlaces">小数的位数</param>
            /// <returns></returns>
            public static string GetLargeNumberString3(ulong number, uint decimalPlaces = 1)
            {
                string str = string.Empty;
                string unit = "";

                System.Text.StringBuilder formatStr = new System.Text.StringBuilder();
                formatStr.Append("0.");
                for (uint i = 0; i < decimalPlaces; ++i)
                {
                    formatStr.Append("#");
                }

                if (number < 100000)
                {
                    str = number.ToString();
                }
                else if (number < 100000000)
                {
                    str = Convert.ToDouble((double)number / 10000.0).ToString(formatStr.ToString());
                    unit = DBConstText.GetText("TEN_THOUSAND");
                }
                else
                {
                    str = Convert.ToDouble((double)number / 100000000.0).ToString(formatStr.ToString());
                    unit = DBConstText.GetText("HUNDRED_MILLION");
                }

                str = str + unit;

                return str;
            }

            /// <summary>
            /// 优化大额数值的显示 基本同GetLargeNumberString
            /// 不四舍五入，直接舍弃多余位
            /// </summary>
            /// <param name="number"></param>
            /// <param name="decimalPlaces">小数的位数</param>
            /// <returns></returns>
            public static string GetLargeNumberString4(ulong number, uint decimalPlaces = 1)
            {
                string str = string.Empty;
                string unit = "";

                System.Text.StringBuilder formatStr = new System.Text.StringBuilder();
                formatStr.Append("0.");
                for (uint i = 0; i < decimalPlaces; ++i)
                {
                    formatStr.Append("0");
                }

                if (number <= 99999)
                {
                    str = number.ToString();
                }
                else if (number < 999999999)
                {
                    double result = Convert.ToDouble((double)number / 10000.0);
                    str = result.ToString();
                    str = ConvertToDecimal(str, decimalPlaces);
                    unit = DBConstText.GetText("TEN_THOUSAND");
                }
                else
                {
                    double result = number / 100000000.0;
                    str = result.ToString();
                    str = ConvertToDecimal(str, decimalPlaces);
                    unit = DBConstText.GetText("HUNDRED_MILLION");
                }

                str = str + unit;

                return str;
            }

            public static string ConvertToDecimal(string str, uint decimalPlaces = 1)
            {
                string result;
                int pointIndex = str.IndexOf('.');
                if (pointIndex == -1 )
                {
                    result = str + ".";
                    for (int i = 1; i <= decimalPlaces; i++)
                    {
                        result += "0";
                    }
                }
                else
                {
                    int decimalLenth = str.Substring(pointIndex).Length - 1;
                    if (decimalLenth < decimalPlaces)
                    {
                        result = str;
                        for (int i = 1; i <= decimalPlaces - decimalLenth; i ++)
                        {
                            result += "0";
                        }
                    }
                    else
                    {
                        result = str.Substring(0, pointIndex + (int)decimalPlaces + 1);
                    }
                }
                return result;
            }
        }
    }
}

