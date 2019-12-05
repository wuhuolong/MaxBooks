//---------------------------------------
// File:    UIGuideWindow.cs
// Desc:    引导界面
// Author:  Raorui
// Date:    2017.9.19
//---------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace xc.ui.ugui
{
    [wxb.Hotfix]
    public class UIGuideWindow : UIBaseWindow
    {
        /// <summary>
        /// 当前的指引物体
        /// </summary>
        public GuideObject CurrentGuideObject
        {
            get{return m_GuideObject;}
        }
        GuideObject m_GuideObject;

        /// <summary>
        /// 当前的引导步骤
        /// </summary>
        Guide.Step m_GuideStep;

        /// <summary>
        /// 强制指引的Mask，防止点击穿透
        /// </summary>
        public GameObject EventMask
        {
            get { return m_EventMask; }
        }

        GameObject m_Mask;

        UIPreviewTexture m_PreviewTexture;

        /// <summary>
        /// 用来接收任意区域点击事件的物体
        /// </summary>
        GameObject m_EventMask;

        /// <summary>
        /// 引导的箭头
        /// </summary>
        GameObject m_GuideArrow;

        /// <summary>
        /// 引导的模型
        /// </summary>
        RawImage m_GuideModel;

        GameObject m_PreviewCamera;

        /// <summary>
        /// 模型引导时显示的文本
        /// </summary>
        Text m_GuideModelDesc;

        /// <summary>
        /// 跳过按钮
        /// </summary>
        Button m_SkipButton;

        // 标记引导目标的范围（调试用）
        GameObject m_RectMin;
        GameObject m_RectMax;

        RectTransform m_RectMinTrans;
        RectTransform m_RectMaxTrans;

        /// <summary>
        ///  引导箭头在世界坐标的宽度
        /// </summary>
        float m_ArrowWorldWidth = -1;

        /// <summary>
        ///  引导箭头在世界坐标的高度
        /// </summary>
        float m_ArrowWorldHeight = -1;

        /// <summary>
        /// 显示指引文字的背景图
        /// </summary>
        GameObject m_GuideDescObject;

        /// <summary>
        /// 显示在指引箭头旁边的文本
        /// </summary>
        Text m_GuideDesc;

        /// <summary>
        /// 将指引控件复制到TargetTmpRoot上
        /// </summary>
        public Transform TargetTmpRoot
        {
            get { return m_TargetTmpRoot; }
        }
        Transform m_TargetTmpRoot;

        /// <summary>
        /// 新手引导显示的图片
        /// </summary>
        GameObject m_GuidePicture;

        /// <summary>
        /// 窗口的Canvas
        /// </summary>
        Canvas m_Canvas;

        /// <summary>
        /// 显示一块区域
        /// </summary>
        GameObject mHollowRegion;

        /// <summary>
        /// 显示区域的最小点
        /// </summary>
        Transform mHollowRectMin;

        /// <summary>
        /// 显示区域的最大点
        /// </summary>
        Transform mHollowRectMax;

        /// <summary>
        /// 用于引导描述文字一段时候后显示的Timer
        /// </summary>
        Utils.Timer m_GuideDescTimer;

        /// <summary>
        /// 窗口更新的Timer
        /// </summary>
        Utils.Timer m_UpdateTimer;

        /// <summary>
        /// 非强制指引时候的时间委托
        /// </summary>
        List<Button.ButtonClickedEvent> m_TargetObjClickDelegate = new List<Button.ButtonClickedEvent>();

        /// <summary>
        /// 非强制指引时候的时间委托
        /// </summary>
        List<Toggle.ToggleEvent> m_TargetObjToggleDelegate = new List<Toggle.ToggleEvent>();

        private delegate void OnClickDel(GameObject click_obj);
        private OnClickDel OnClickListener;

        private Transform mHideWidgetTransform = null;

        Dictionary<uint, uint> mPlayingVoice = new Dictionary<uint, uint>();

        public UIGuideWindow()
        {
        }

        protected override void InitUI()
        {
            base.InitUI();

            m_Mask = FindChild("Mask");
            m_EventMask = FindChild("EventMask");

            m_SkipButton = FindChild<Button>("SkipButton");
            m_GuideArrow = FindChild("GuideArrow");
            m_PreviewCamera = FindChild("PreviewCamera");
            m_PreviewTexture = m_PreviewCamera.GetComponent<UIPreviewTexture>();
            m_GuideModel = FindChild<RawImage>("GuideModel");
            m_GuideModelDesc = m_GuideModel.transform.Find("ModelDesc").GetComponent<Text>();

            m_RectMin = FindChild("RectMin");
            m_RectMinTrans = m_RectMin.GetComponent<RectTransform>();
            m_RectMax = FindChild("RectMax");
            m_RectMaxTrans = m_RectMax.GetComponent<RectTransform>();

            mHollowRegion = FindChild("HollowRegion");
            mHollowRectMin = mHollowRegion.transform.Find("HollowRectMin");
            mHollowRectMax = mHollowRegion.transform.Find("HollowRectMax");

            m_GuideDescObject = FindChild("GuideDescImage");

            m_GuideDesc = FindChild<Text>("GuideDesc");
            m_GuidePicture = FindChild("Picture");

            m_TargetTmpRoot = FindChild("TargetTmpRoot").transform;

            m_Canvas = mUIObject.GetComponent<Canvas>();

            InitEvent();
        }

        void InitEvent()
        {
            m_SkipButton.onClick.AddListener(OnClickSkipButton);
            ClientEventMgr.Instance.SubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }

        protected override void UnInitUI()
        {
            GameDebug.LogWarning("UIGuideWindow.UnInitUI, this window should not be deleted");

            base.UnInitUI();

            CleanupUpdateTimer();

            if (m_GuideDescTimer != null)
            {
                m_GuideDescTimer.Destroy();
                m_GuideDescTimer = null;
            }

            UnInitEvent();
        }

        void UnInitEvent()
        {
            if (m_SkipButton != null)
                m_SkipButton.onClick.RemoveListener(OnClickSkipButton);

            ClientEventMgr.Instance.UnsubscribeClientEvent((int)ClientEvent.CE_START_SWITCHSCENE, OnStartSwitchScene);
        }

        void OnStartSwitchScene(CEventBaseArgs data)
        {
            mPlayingVoice.Clear();
        }

        protected override void ResetUI()
        {
            base.ResetUI();
        }

        /// <summary>
        /// 点击跳过按钮
        /// </summary>
        void OnClickSkipButton()
        {
            GuideManager.Instance.SkipCurrentGuide();
            m_SkipButton.gameObject.SetActive(false);
        }

        /// <summary>
        /// 设置ui的通用事件监听器
        /// </summary>
        private void SetupGenericEventListener(GameObject target_object, OnClickDel click_handle)
        {
            if(mUIObject == null)
            {
                return;
            }

            // 如果没有目标物体的监听事件，则使用GuideWindow来进行监听
            if(target_object != null)
            {
                var event_listen = EventTriggerListener.GetListener(target_object);
                event_listen.onPointerClick += OnClick;
            }
            else
            {
                var event_listen = EventTriggerListener.GetListener(m_EventMask);
                event_listen.onPointerClick += OnClick;
            }

            OnClickListener = click_handle;
        }

        /// <summary>
        /// 设置mask层
        /// </summary>
        void SetupMask(bool is_force = false)
        {
            if (m_GuideStep == null)
            {
                m_Mask.SetActive(false);
                m_EventMask.SetActive(false);
                return;
            }

            bool active_mask = m_GuideStep.IsForcible || is_force;
            m_EventMask.SetActive(active_mask);

            // 区域类型的指引本身有蒙板，不需要显示黑色背景
            if (m_GuideStep.DisplayType == Guide.EDisplayType.Region)
                m_Mask.SetActive(false);
            else
                m_Mask.SetActive(active_mask);
        }

        /// <summary>
        /// 播放语音
        /// </summary>
        void TryPlayVoice()
        {
            //Debug.Log("TryPlayVoice   start  " + Time.time);
            if (m_GuideStep == null)
                return;
            if(m_GuideStep.VoiceId != 0 )
            {
                uint clipId = 0;
                if(mPlayingVoice.TryGetValue(m_GuideStep.VoiceId,out clipId))
                {
                    //已播
                    if(AudioManager.Instance.CheckSFXValid(clipId))
                    {
                        //但未失效
                        return;
                    }
                }

                var db = DBManager.Instance.GetDB<DBVoice>();
                string voicePath = db.GetVoicePath(m_GuideStep.VoiceId);
                if (voicePath != "")
                {
                    //Debug.Log("TryPlayVoice     " + GlobalConst.ResPath + voicePath + "  "+ Time.time);
                    clipId = AudioManager.Instance.PlayBattleSFX(GlobalConst.ResPath + voicePath, SoundType.Voice);
                    mPlayingVoice[m_GuideStep.VoiceId] = clipId;
                }
            }
        }   


        float ImageWidth(GameObject image_object)
        {
            var rect_trans = image_object.GetComponent<RectTransform>();
            if (rect_trans != null)
                return rect_trans.sizeDelta.x;
            else
                return 0;
        }

        float ImageHeight(Image image)
        {
            RectTransform rect_trans = image.rectTransform;
            return rect_trans.sizeDelta.y;
        }

        #region 箭头引导
        private void ClearArrowTips()
        {
            if(m_GuideArrow == null)
            {
                return;
            }

            m_GuideArrow.SetActive(false);
            m_GuideModel.gameObject.SetActive(false);
            m_PreviewCamera.SetActive(false);
            m_RectMin.SetActive(false);
            m_RectMax.SetActive(false);
            m_GuideDesc.text = string.Empty;
            m_GuideDesc.gameObject.SetActive(false);
            m_GuideDescObject.gameObject.SetActive(false);
            m_GuidePicture.SetActive(false);
            m_SkipButton.gameObject.SetActive(false);
            mHollowRegion.SetActive(false);
        }

        public void ResetArrowTips()
        {
            if (m_GuideStep == null)
                return;

            ShowSkipButton(m_GuideStep.IsCanSkip);

            if (m_GuideStep.DisplayType == Guide.EDisplayType.Arrow || m_GuideStep.DisplayType == Guide.EDisplayType.Model)// 箭头引导类型/模型引导类型
            {
                if (m_GuideArrow == null)
                {
                    GameDebug.LogError("UIGuideWindow:ResetArrowTips m_GuideArrow is null");
                    return;
                }

                if (m_GuideObject != null)
                {
                    // 计算目标物体的Bounds
                    var guide_gameobject = m_GuideObject as GuideGameObject;
                    m_GuideObject.Bounds = UGUIMath.CalculateAbsoluteBounds(guide_gameobject.TargetObject.GetComponent<RectTransform>());
                    var bounds = m_GuideObject.Bounds;

                    // 设置debug min max点的位置
                    m_RectMin.SetActive(true);
                    m_RectMax.SetActive(true);
                    m_RectMin.transform.position = bounds.min;
                    Vector3 local_pos = m_RectMin.transform.localPosition;
                    m_RectMin.transform.localPosition = new Vector3(local_pos.x, local_pos.y, 0);
                    m_RectMax.transform.position = bounds.max;
                    local_pos = m_RectMax.transform.localPosition;
                    m_RectMax.transform.localPosition = new Vector3(local_pos.x, local_pos.y, 0);

                    // 显示箭头
                    m_GuideArrow.SetActive(true);
                    m_GuideArrow.transform.localRotation = Quaternion.identity;

                    // 获取箭头在世界坐标下的Bounds
                    if (m_ArrowWorldWidth < 0)
                    {
                        Bounds arrow_bound = UGUIMath.CalculateAbsoluteBounds(m_GuideArrow.GetComponent<RectTransform>());
                        m_ArrowWorldWidth = arrow_bound.size.x;
                        m_ArrowWorldHeight = arrow_bound.size.y;
                    }

                    float neighbour_width = 0;
                    float neighbour_height = 0;
                    float model_x_offset = m_GuideStep.Offset_X; // 模型预览组件在x方向的偏移

                    // 引导箭头的控件
                    if (m_GuideStep.DisplayType == Guide.EDisplayType.Arrow)
                    {
                        m_GuideDesc.gameObject.SetActive(true);
                        m_GuideDescObject.gameObject.SetActive(true);

                        // 设置引导文本的显示
                        m_GuideDesc.text = m_GuideStep.IconDesc;
                        neighbour_width = m_GuideDesc.rectTransform.sizeDelta.x;
                        neighbour_height = m_GuideDesc.preferredHeight;
                    }
                    else// 引导模型的控件
                    {
                        m_PreviewCamera.SetActive(true);
                        m_GuideModel.gameObject.SetActive(true);
                        m_GuideModelDesc.text = m_GuideStep.IconDesc;
                        neighbour_width = m_GuideModel.rectTransform.sizeDelta.x;
                        neighbour_height = m_GuideModel.rectTransform.sizeDelta.y;
                    }

                    Vector3 center_local_pos = (m_RectMaxTrans.localPosition + m_RectMinTrans.localPosition) * 0.5f;
                    Vector3 neighbour_pos = Vector3.zero;
                    Vector3 arrow_rot = Vector3.zero;
                    switch (m_GuideStep.IconDir)
                    {
                        case Guide.EGuideIconDir.Bottom:
                            {
                                m_GuideArrow.transform.position = new Vector3(bounds.min.x + bounds.size.x * 0.5f, bounds.max.y + m_ArrowWorldWidth * 0.5f, bounds.center.z);
                                neighbour_pos = m_GuideArrow.transform.TransformPoint(0, ImageWidth(m_GuideArrow) * 0.5f + neighbour_height, 0f);
                                model_x_offset += m_GuideModel.rectTransform.sizeDelta.x * 0.5f;
                                if (center_local_pos.x > 0)// 如果指引中心点在右边，则模型显示在左边
                                    model_x_offset = -model_x_offset;

                                arrow_rot = new Vector3(0f, 0f, 90f);
                                break;
                            }
                        case Guide.EGuideIconDir.Top:
                            {
                                m_GuideArrow.transform.position = new Vector3(bounds.min.x + bounds.size.x * 0.5f, bounds.min.y - m_ArrowWorldWidth * 0.5f, bounds.center.z);
                                neighbour_pos = m_GuideArrow.transform.TransformPoint(0, -ImageWidth(m_GuideArrow) * 0.5f - neighbour_height, 0f);
                                model_x_offset += m_GuideModel.rectTransform.sizeDelta.x * 0.5f;
                                if (center_local_pos.x > 0)// 如果指引中心点在右边，则模型显示在左边
                                    model_x_offset = -model_x_offset;

                                arrow_rot = new Vector3(0f, 0f, -90f);
                                break;
                            }
                        case Guide.EGuideIconDir.Left:
                            {
                                m_GuideArrow.transform.position = new Vector3(bounds.max.x + m_ArrowWorldWidth * 0.5f, bounds.min.y + bounds.size.y * 0.5f, bounds.center.z);
                                neighbour_pos = m_GuideArrow.transform.TransformPoint(ImageWidth(m_GuideArrow) * 0.5f + neighbour_width * 0.5f, 0f, 0f);

                                arrow_rot = Vector3.zero;
                                break;
                            }
                        case Guide.EGuideIconDir.Right:
                            {
                                m_GuideArrow.transform.position = new Vector3(bounds.min.x - m_ArrowWorldWidth * 0.5f, bounds.min.y + bounds.size.y * 0.5f, bounds.center.z);
                                neighbour_pos = m_GuideArrow.transform.TransformPoint(-ImageWidth(m_GuideArrow) * 0.5f - neighbour_width * 0.5f, 0f, 0f);

                                arrow_rot = new Vector3(0f, 0f, 180f);
                                break;
                            }
                    }

                    if (m_GuideStep.DisplayType == Guide.EDisplayType.Arrow)
                    {
                        m_GuideDesc.transform.position = neighbour_pos;
                        local_pos = m_GuideDesc.transform.localPosition;
                        m_GuideDesc.transform.localPosition = new Vector3(local_pos.x, local_pos.y, 0);
                    }
                    else
                    {
                        m_GuideModel.transform.position = neighbour_pos;
                        local_pos = m_GuideModel.transform.localPosition;
                        m_GuideModel.transform.localPosition = new Vector3(local_pos.x + model_x_offset, m_GuideModel.rectTransform.sizeDelta.y * 0.5f, 0);
                    }

                    m_GuideArrow.transform.Rotate(arrow_rot, Space.Self);
                    local_pos = m_GuideArrow.transform.localPosition;
                    m_GuideArrow.transform.localPosition = new Vector3(local_pos.x, local_pos.y, 0f);

                }
            }
            else if (m_GuideStep.DisplayType == Guide.EDisplayType.Picture)
            {
                m_GuidePicture.SetActive(true);

                // 暂时屏蔽，引导图片改成RawImage了
                //m_GuidePicture.GetComponent<Image>().sprite = LoadSprite(m_GuideStep.PicName);
            }
            else if (m_GuideStep.DisplayType == Guide.EDisplayType.Text)// 居中显示模型和文本
            {
                m_PreviewCamera.SetActive(true);
                m_GuideModelDesc.text = m_GuideStep.IconDesc;
                m_GuideModel.transform.localPosition = new Vector3(m_GuideStep.Offset_X, m_GuideModel.rectTransform.sizeDelta.y * 0.5f, 0);
                m_GuideModel.gameObject.SetActive(true);
            }
            else if (m_GuideStep.DisplayType == Guide.EDisplayType.Region)// 高亮一块区域并居中显示模型和文本
            {
                // 显示模型
                m_PreviewCamera.SetActive(true);
                m_GuideModelDesc.text = m_GuideStep.IconDesc;
                m_GuideModel.transform.localPosition = new Vector3(m_GuideStep.Offset_X, m_GuideModel.rectTransform.sizeDelta.y * 0.5f, 0);
                m_GuideModel.gameObject.SetActive(true);


                if (m_GuideObject != null)
                {
                    // 计算目标物体的Bounds
                    var guide_gameobject = m_GuideObject as GuideGameObject;
                    m_GuideObject.Bounds = UGUIMath.CalculateAbsoluteBounds(guide_gameobject.TargetObject.GetComponent<RectTransform>());

                    // 显示高亮区域
                    mHollowRegion.SetActive(true);

                    var bounds = m_GuideObject.Bounds;

                    // 设置 min max点的位置
                    mHollowRectMin.position = bounds.min;
                    Vector3 local_pos = mHollowRectMin.localPosition;
                    mHollowRectMin.localPosition = new Vector3(local_pos.x, local_pos.y, 0);

                    mHollowRectMax.position = bounds.max;
                    local_pos = mHollowRectMax.localPosition;
                    mHollowRectMax.localPosition = new Vector3(local_pos.x, local_pos.y, 0);
                }
            }
        }

        /// <summary>
        /// 更新指示箭头和对应的提示文本
        /// </summary>
        private void UpdateArrowTips()
        {
            ClearArrowTips();

            ResetArrowTips();
        }
        #endregion

        /// <summary>
        /// 更新检测
        /// </summary>
        /// <param name="deltaTime"></param>
        private void UpdateGuideObject(float deltaTime)
        {
            if (m_GuideObject != null)
                m_GuideObject.Update();
        }

        /// <summary>
        /// 暂停引导
        /// </summary>
        private void StopGuideStep()
        {
            GuideManager.GetInstance().TryToStopGuideStep(m_GuideStep);
        }

        /// <summary>
        /// 重置引导
        /// </summary>
        public void ResetGuideStep()
        {
            GuideManager.GetInstance().TryToResetGuideStep(m_GuideStep);
        }

        public override void Close()
        {
            ClearTargetObjEvent();

            if (m_GuideObject != null)
            {
                m_GuideObject.Cleanup();
                m_GuideObject = null;
            }

            m_GuideStep = null;
            ClearArrowTips();
            m_Mask.SetActive(false);
            m_EventMask.SetActive(false);

            CleanupUpdateTimer();

            DestroyPreviewModel();

            if (mHideWidgetTransform != null)
            {
                HideWidget(mHideWidgetTransform.gameObject, false);
            }
        }

        void HideWidget(GameObject widget, bool hide)
        {
            Graphic[] graphics = widget.GetComponentsInChildren<Graphic>(true);
            foreach (Graphic graphic in graphics)
            {
                Color color = graphic.color;
                color.a = hide ? 0 : 1;
                graphic.color = color;
            }
        }

        public void OnClick(GameObject obj)
        {
            if (m_GuideStep == null)
            {
                return;
            }

            if (OnClickListener != null)
            {
                OnClickListener(obj);
            }
        }

        #region Util
        /// <summary>
        /// 清理上一次引导的内容
        /// </summary>
        private void CleanupLastGuide()
        {
            OnClickListener = null;
            ClearTargetObjEvent();

            if (m_GuideObject != null)
            {
                m_GuideObject.Cleanup();
                m_GuideObject = null;
            }
        }

        /// <summary>
        /// 清理更新timer
        /// </summary>
        private void CleanupUpdateTimer()
        {
            if (m_UpdateTimer != null)
            {
                m_UpdateTimer.Destroy();
                m_UpdateTimer = null;
            }
        }

        /// <summary>
        /// 开启更新
        /// </summary>
        private void StartUpdateTimer()
        {
            CleanupUpdateTimer();

            UpdateGuideObject(0);
            m_UpdateTimer = new Utils.Timer(1000, true, 10, UpdateGuideObject);
        }

        #endregion

        #region 点击引导
        /// <summary>
        /// 清空引导时绑在对象身上的事件
        /// </summary>
        private void ClearTargetObjEvent()
        {
            foreach(var button_click in m_TargetObjClickDelegate)
            {
                if(button_click != null)
                    button_click.RemoveListener(OnClickTarget);
            }
            m_TargetObjClickDelegate.Clear();

            foreach (var toggle_click in m_TargetObjToggleDelegate)
            {
                if (toggle_click != null)
                    toggle_click.RemoveListener(OnToggleTarget);
            }
            m_TargetObjToggleDelegate.Clear();

            GuideManager.Instance.OnTouched -= OnTouched;
        }

        /// <summary>
        /// 设置引导对象的点击处理
        /// 只在非强制时使用
        /// </summary>
        /// <param name="click_handle"></param>
        void SetupTargetClickEventListener(GameObject target, bool click_any, UnityEngine.Events.UnityAction click_handle)
        {
            if(click_any) // 点击任意区域
            {
                GuideManager.Instance.OnTouched += OnTouched;
            }
            else // 点击按钮
            {
                var btn = target.GetComponent<Button>();
                if (btn != null)
                {
                    m_TargetObjClickDelegate.Add(btn.onClick);
                    btn.onClick.AddListener(OnClickTarget);
                }
                else
                {
                    var toggle = target.GetComponent<Toggle>();
                    if (toggle != null)
                    {
                        m_TargetObjToggleDelegate.Add(toggle.onValueChanged);
                        toggle.onValueChanged.AddListener(OnToggleTarget);
                    }
                }
            }
        }

        /// <summary>
        /// 点击到引导按钮
        /// </summary>
        void OnClickTarget()
        {
            if (m_GuideStep == null || mUIObject == null)
            {
                return;
            }

            // 反注册点击事件
            GuideGameObject guide_object = m_GuideObject as GuideGameObject;
            if (guide_object != null && guide_object.TargetObject != null)
            {
                var btn = guide_object.TargetObject.GetComponent<Button>();
                if (btn != null)
                {
                    btn.onClick.RemoveListener(OnClickTarget);
                }
            }

            // 进行下个步骤
            if (m_GuideStep != null && m_GuideStep.TargetTrigger != null)
                m_GuideStep.TargetTrigger.NotifyClick();
            else
                Close();
        }

        /// <summary>
        /// 点击到引导Toggle
        /// </summary>
        /// <param name="is_on"></param>
        void OnToggleTarget(bool is_on)
        {
            if (is_on == false)
                return;

            if (m_GuideStep == null || mUIObject == null)
            {
                return;
            }

            // 反注册点击事件
            GuideGameObject guide_object = m_GuideObject as GuideGameObject;
            if (guide_object != null && guide_object.TargetObject != null)
            {
                var toggle = guide_object.TargetObject.GetComponent<Toggle>();
                if (toggle != null)
                {
                    toggle.onValueChanged.RemoveListener(OnToggleTarget);
                }
            }

            // 进行下个步骤
            if (m_GuideStep != null && m_GuideStep.TargetTrigger != null)
                m_GuideStep.TargetTrigger.NotifyClick();
            else
                Close();
        }

        /// <summary>
        /// 点击到屏幕任意区域
        /// </summary>
        void OnTouched()
        {
            // 反注册点击事件
            GuideManager.Instance.OnTouched -= OnTouched;

            if (m_GuideObject != null && m_GuideStep != null)
            {
                var guide_gameobject = (GuideGameObject)m_GuideObject;
                var guide_target = guide_gameobject.TargetObject;
                if (guide_target != null)
                {
                    // 如果触摸到了目标物体
                    if(GuideManager.Instance.IsWidgetTouched(guide_target))
                    {
                        // 执行guide_obj.TargetObject的点击事件
                        /*if (m_GuideStep.EventType == 1)
                            ExecuteEvents.Execute<IPointerClickHandler>(guide_target, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                        else
                        {
                            ExecuteEvents.Execute<IPointerDownHandler>(guide_target, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                            ExecuteEvents.Execute<IPointerUpHandler>(guide_target, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
                        }*/

                        if (m_GuideStep.TargetTrigger != null)
                            m_GuideStep.TargetTrigger.NotifyClick();
                        else
                            Close();

                        return;
                    }
                }
            }

            // 没有触摸到目标物体
            GuideManager.Instance.SkipCurrentGuide();
        }

        /// <summary>
        /// 点击引导对象
        /// </summary>
        /// <param name="guide_step"></param>
        /// <param name="target">要引导的对象</param>
        public void GuideClick(Guide.Step guide_step, GameObject target)
        {
            CleanupLastGuide();

            if (target == null)
                return;

            if(guide_step == null)
            {
                return;
            }

            m_GuideStep = guide_step;

            if(m_GuideObject != null)
            {
                m_GuideObject.Cleanup();
                m_GuideObject = null;
            }

            var guide_obj = new GuideGameObject(this, target);

            m_GuideObject = guide_obj;

            if (!m_GuideStep.IsForcible)
            {
                // 非强制时监听其点击事件
                SetupTargetClickEventListener(guide_obj.TargetObject, m_GuideStep.ClickAny, OnClickTarget);
            }
            else
            {
                guide_obj.CopyTargetObj();
                if (target != null)
                {
                    string hide_widget = m_GuideStep.HideWidget;
                    if (string.IsNullOrEmpty(hide_widget) == false)
                    {
                        if (target.name == hide_widget)
                        {
                            mHideWidgetTransform = target.transform;
                        }
                        else
                        {
                            mHideWidgetTransform = UIHelper.FindChildInHierarchy(target.transform, hide_widget);
                        }
                        if (mHideWidgetTransform != null)
                        {
                            HideWidget(mHideWidgetTransform.gameObject, true);
                        }   
                    }
                }

                GameObject listen_object = guide_obj.CopyObj != null ? guide_obj.CopyObj : guide_obj.TargetObject;
                SetupGenericEventListener(listen_object, (click_obj) =>
                {
                    if (m_GuideStep == null || mUIObject == null)
                    {
                        return;
                    }

                    if ((guide_obj.CopyObj != null && click_obj == guide_obj.CopyObj) ||
                        (guide_obj.CopyObj == null && click_obj == guide_obj.TargetObject))
                    {
                        if (guide_obj.TargetObject == null)
                        {
                            Close();
                            return;
                        }

                        // 执行guide_obj.TargetObject的点击事件
                        if (guide_step.EventType == 1)
                            ExecuteEvents.Execute<IPointerClickHandler>(guide_obj.TargetObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                        else
                        {
                            ExecuteEvents.Execute<IPointerDownHandler>(guide_obj.TargetObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                            ExecuteEvents.Execute<IPointerUpHandler>(guide_obj.TargetObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
                        }

                        if (mHideWidgetTransform != null)
                        {
                            HideWidget(mHideWidgetTransform.gameObject, false);
                        }

                        if (click_obj != null)
                        {
                            var event_listen = EventTriggerListener.GetListener(click_obj);
                            event_listen.onPointerClick -= OnClick;
                        }

                        if (m_GuideStep != null && m_GuideStep.TargetTrigger != null)
                            m_GuideStep.TargetTrigger.NotifyClick();
                        else
                            Close();
                    }
                });
            }
            //Debug.Log("GuideClick" + guide_step.GuideId + "   " + guide_step.StepId);

            SetupMask();
            UpdateArrowTips();
            StartUpdateTimer();
            TryPlayVoice();

        }

        /// <summary>
        /// 点击目标物体的回调
        /// </summary>
        /// <param name="click_obj"></param>
        /// <param name="guide_obj"></param>
        /// <param name="guide_step"></param>
        void OnClickTarget(GameObject click_obj, GuideGameObject guide_obj, Guide.Step guide_step)
        {
            if (m_GuideStep == null || mUIObject == null)
            {
                return;
            }

            if ((guide_obj.CopyObj != null && click_obj == guide_obj.CopyObj) ||
                (guide_obj.CopyObj == null && click_obj == guide_obj.TargetObject))
            {
                if (guide_obj.TargetObject == null)
                {
                    Close();
                    return;
                }

                // 执行guide_obj.TargetObject的点击事件
                if (guide_step.EventType == 1)
                    ExecuteEvents.Execute<IPointerClickHandler>(guide_obj.TargetObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                else
                {
                    ExecuteEvents.Execute<IPointerDownHandler>(guide_obj.TargetObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                    ExecuteEvents.Execute<IPointerUpHandler>(guide_obj.TargetObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
                }

                if (click_obj != null)
                {
                    var event_listen = EventTriggerListener.GetListener(click_obj);
                    event_listen.onPointerClick -= OnClick;
                }

                if (m_GuideStep != null && m_GuideStep.TargetTrigger != null)
                    m_GuideStep.TargetTrigger.NotifyClick();
                else
                    Close();
            }
        }

        /// <summary>
        /// 引导对象，但点击任意地方继续（支持没有目标物体，比如显示图片）
        /// </summary>
        /// <param name="guide_step"></param>
        /// <param name="target"></param>
        public void GuideClickMask(Guide.Step guide_step, GameObject target)
        {
            CleanupLastGuide();

            m_GuideStep = guide_step;

            GuideGameObject guide_obj = null;
            if (target != null)
            {
                guide_obj = new GuideGameObject(this, target);
                m_GuideObject = guide_obj;
            }
            else
            {
                m_GuideObject = null;
            }

            SetupGenericEventListener(null, (click_obj) => 
            {
                if (m_GuideStep != null && m_GuideStep.TargetTrigger != null)
                    m_GuideStep.TargetTrigger.NotifyClick();
                else
                    Close();
            });

            if (guide_obj != null)
                guide_obj.CopyTargetObj();

            // 显示区域类型的控件不可点击`
            if (guide_step.DisplayType == Guide.EDisplayType.Region)
            {
                if (guide_obj != null)
                    guide_obj.TargetCanbeHit = false;
                else
                    GameDebug.LogError(string.Format("GuideClickMask: guide_step {0} cannot find guide object", guide_step.StepId));
            }

            //Debug.Log("GuideClickMask" + guide_step.GuideId + "   " + guide_step.StepId);


            // 一定要加mask
            SetupMask(true);
            UpdateArrowTips();
            StartUpdateTimer();
            TryPlayVoice();

        }
        #endregion

        /// <summary>
        /// 是否显示跳过按钮
        /// </summary>
        /// <param name="is_show"></param>
        public void ShowSkipButton(bool is_show)
        {
            if (m_SkipButton != null)
                m_SkipButton.gameObject.SetActive(is_show);
        }

        /// <summary>
        /// 加载角色的id
        /// </summary>
        UnitID m_ModelId;

        /// <summary>
        /// 加载后播放的动作名字
        /// </summary>
        string m_AnimationName;

        /// <summary>
        /// 加载指引需要的角色模型
        /// </summary>
        public void PrepareModel(string ani_name)
        {
            m_AnimationName = ani_name;
            if (m_ModelId != null)
            {
                var actor = ActorManager.Instance.GetActor(m_ModelId);
                if(actor != null && string.IsNullOrEmpty(ani_name) == false)
                {
                    actor.CrossFade(ani_name);
                    float delay_time = actor.GetAnimationLength(m_AnimationName);
                    MainGame.HeartBehavior.StartCoroutine(PlayIdle(actor, delay_time, "idle"));
                }
            }
            else
                m_ModelId = ClientModel.CreateClientModelByActorIdForLua(GameConstHelper.GetUint("GAME_GUIDE_MODEL"), OnModelLoaded);
        }

        /// <summary>
        /// 模型加载完毕后的回调
        /// </summary>
        /// <param name="actor"></param>
        void OnModelLoaded(Actor actor)
        {
            if (actor == null)
                return;

            if(this.IsShow == false)
            {
                DestroyPreviewModel();
                return;
            }

            if(string.IsNullOrEmpty(m_AnimationName) == false)
            {
                actor.CrossFade(m_AnimationName);
                float delay_time = actor.GetAnimationLength(m_AnimationName);
                MainGame.HeartBehavior.StartCoroutine(PlayIdle(actor, delay_time, "idle"));
            }
            
            var go = actor.GetModelParent();
            m_PreviewTexture.SetGameObject(go);
            m_PreviewTexture.EnableRotate(false);
            //go.transform.localEulerAngles = new Vector3(0, -50, 0);
        }

        /// <summary>
        /// 销毁加载的角色
        /// </summary>
        void DestroyPreviewModel()
        {
            if (m_ModelId != null)
            {
                xc.ActorManager.Instance.DestroyActor(m_ModelId, 0);
                m_ModelId = null;
            }

            if (m_PreviewTexture != null)
            {
                m_PreviewTexture.Destroy();
            }
        }

        /// <summary>
        /// 延迟一段时间后播放待机动画
        /// </summary>
        /// <returns></returns>
        IEnumerator PlayIdle(Actor actor, float second_time, string animation_name)
        {
            yield return new WaitForSeconds(second_time);

            if(actor != null && string.IsNullOrEmpty(animation_name) == false)
            {
                if(m_ModelId != null && actor.IsDestroy == false)
                    actor.CrossFade(animation_name);
            }
        }
    }
}