//---------------------------------------
// File:GuideGameObject.cs
// Desc:GameObject类型的引导，当指定的控件有引导的时候，将控件对应的GameObject复制一份出来
// Author: raorui
// Date:2017.9.19
//---------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace xc.ui.ugui
{
    public class GuideGameObject : GuideObject
    {
        private const float MIN_DIFF = 0.01f;

        public GameObject CopyObj { get; set; }
        private Transform CopyTrans { get; set; }
        public GameObject TargetObject { get; set; }
        public Transform TargetTrans { get; set; }
        private float TargetObjOldPosX { get; set; }
        private float TargetObjOldPosY { get; set; }
        private float TargetObjOldScaleX { get; set; }
        private float TargetObjOldScaleY { get; set; }
        public bool TargetCanbeHit = true;

        private PointerEventData pointerData;

        public GuideGameObject(UIGuideWindow wnd, GameObject target)
            : base(wnd)
        {
            Init(target);
        }

        void Init(GameObject target)
        {
            TargetObject = target;
            TargetTrans = target.transform;
            var pos = TargetTrans.position;
            TargetObjOldPosX = pos.x;
            TargetObjOldPosY = pos.y;
            var scale = TargetTrans.localScale;
            TargetObjOldScaleX = scale.x;
            TargetObjOldScaleY = scale.y;

            Bounds = UGUIMath.CalculateAbsoluteBounds(TargetTrans.GetComponent<RectTransform>());
        }

        public override void Cleanup()
        {
            if (CopyObj != null)
            {
                UnityEngine.Object.DestroyImmediate(CopyObj);
                CopyObj = null;
            }

            CopyTrans = null;
        }

        public override void Update()
        {
            if (!Wnd.IsShow)
            {
                return;
            }

            if (TargetObject == null)
            {
                Wnd.ResetGuideStep();
                Wnd.Close();
                return;
            }

            CheckTargetObjPosChange();
            UpdateGuideObjPos();
            CheckTargetObjVisibility();
        }

        /// <summary>
        /// Target的位置发生变化时，更新引导的箭头
        /// </summary>
        private void CheckTargetObjPosChange()
        {
            var new_pos = TargetTrans.position;
            var new_scale = TargetTrans.localScale;

            if (Mathf.Abs(new_pos.x - TargetObjOldPosX) < MIN_DIFF && Mathf.Abs(new_pos.y - TargetObjOldPosY) <= MIN_DIFF
                && Mathf.Abs(new_scale.x - TargetObjOldScaleX) < MIN_DIFF && Mathf.Abs(new_scale.y - TargetObjOldScaleY) <= MIN_DIFF)
                return;

            Bounds = UGUIMath.CalculateAbsoluteBounds(TargetTrans.GetComponent<RectTransform>());
            TargetObjOldPosX = new_pos.x;
            TargetObjOldPosY = new_pos.y;

            TargetObjOldScaleX = new_scale.x;
            TargetObjOldScaleY = new_scale.y;

            if(CopyObj != null)
            {
                // 可能traget_trans的父亲节点有缩放
                var rect_corner = new Vector3[4];
                CopyTrans.GetComponent<RectTransform>().GetWorldCorners(rect_corner);
                float copy_rect_size_x = rect_corner[2].x - rect_corner[0].x;

                TargetTrans.GetComponent<RectTransform>().GetWorldCorners(rect_corner);
                float target_size_x = rect_corner[2].x - rect_corner[0].x;

                float scale = 1;
                if (copy_rect_size_x != 0) scale = target_size_x / copy_rect_size_x;
                Vector3 ori_scale = CopyTrans.localScale;
                CopyTrans.localScale = new Vector3(ori_scale.x * scale, ori_scale.y * scale, ori_scale.z * scale);
            }

            Wnd.ResetArrowTips();
        }

        private void UpdateGuideObjPos()
        {
            if (TargetTrans == null || Wnd == null)
            {
                return;
            }

            if (CopyTrans != null)
            {
                CopyTrans.position = TargetTrans.position;
                var local_pos = CopyTrans.localPosition;
                local_pos.z = 0;
                CopyTrans.localPosition = local_pos;
            }
        }

        /// <summary>
        /// 开启控件不可见时候的计时
        /// </summary>
        bool m_StartInvisible = false;

        /// <summary>
        /// 开始不可见时候的Time
        /// </summary>
        float m_InvisibleTime = 0;

        /// <summary>
        /// 不可见x秒后再关闭引导
        /// </summary>
        float m_CloseDelayTime = 5.0f;

        private void CheckTargetObjVisibility()
        {
            var visible = true;

            if (TargetCanbeHit)
            {
                var current_camera = UIMainCtrl.MainCam;
                if (current_camera == null)
                {
                    visible = false;
                }

                var screen_pos = current_camera.WorldToScreenPoint(Bounds.center);

                if (pointerData == null)
                {
                    pointerData = new PointerEventData(EventSystem.current);
                }

                var hit_obj = UGUIMath.GetRaycastObj(screen_pos, pointerData);
                if (hit_obj == Wnd.EventMask)
                {
                    visible = false;
                }
                else if (hit_obj == null)
                {
                    visible = false;
                }
                else
                {
                    if (CopyObj != null)
                    {
                        if (!UGUIMath.ContainWidget(CopyObj, hit_obj))
                            visible = false;
                    }
                    else if(TargetObject != null)
                    {
                        if (!UGUIMath.ContainWidget(TargetObject, hit_obj))
                            visible = false;
                    }
                }
            }
            else
            {
                visible = TargetObject.activeInHierarchy;
            }

            if (!visible)// 因为UGUI的Layout有可能并不是在当前帧完成排版，因此对于强制指引，不可见时需要等待一会儿再重置
            {
                if(m_StartInvisible == false)
                {
                    m_InvisibleTime = Time.time;
                    m_StartInvisible = true;
                }

                if(CopyObj == null || Time.time - m_InvisibleTime > m_CloseDelayTime)
                {
                    Wnd.ResetGuideStep();
                    Wnd.Close();
                }
            }
        }

        /// <summary>
        /// 拷贝指引的目标控件
        /// </summary>
        public void CopyTargetObj()
        {
            if (TargetObject == null)
                return;

            CopyObj = UnityEngine.GameObject.Instantiate(TargetObject) as GameObject;


            var toggle = CopyObj.GetComponent<Toggle>();
            if (toggle != null)
            {
                toggle.group = null; 
            }

            CopyTrans = CopyObj.transform;

            // 需要特殊处理的MonoBehaviour
            var spec_list = SGameEngine.Pool<MonoBehaviour>.List.New();

            // 把非UI控件的MonoBehaviour销毁掉
            var remove_list = SGameEngine.Pool<MonoBehaviour>.List.New();
            var db_guide_copy_behavior = DBManager.Instance.GetDB<DBGuideCopyBehavior>();
            foreach (var com in CopyObj.GetComponentsInChildren<MonoBehaviour>(true))
            {
                // 处理特殊的组件
                TargetModelInfo target_model_info = com as TargetModelInfo;
                if (target_model_info != null)
                {
                    spec_list.Add(target_model_info);
                    continue;
                }

                // 因为UIItemNewSlot采用了延迟加载图标，直接拷贝会图标丢失，需要把UIItemNewSlot也拷贝进来并进行加载工作
                UIItemNewSlot slot = com as UIItemNewSlot;
                if (slot != null)
                {
                    UIItemNewSlot source_slot = TargetObject.GetComponentInChildren<UIItemNewSlot>();

                    if (source_slot != null)
                    {
                        slot.ItemInfo = source_slot.ItemInfo;
                        slot.SetUI();
                        if (slot.ItemInfo != null && GoodsHelper.GetGoodsType(slot.ItemInfo.type_idx) == GameConst.GIVE_TYPE_SOUL)
                        {
                            slot.CanShowCircleBkg = true;
                            slot.SetColor(false);
                            slot.SetBgImageVisiable(false);
                            slot.SetEffectRootVisiable(false);
                        }
                    }

                    continue;
                }

                // ui控件的基类
                if (com == null || com is ICanvasElement || com is Selectable)
                    continue;

                // 其他需要添加的组件
                string class_name = com.GetType().Name;
                if (db_guide_copy_behavior.ContainType(class_name))
                    continue;

                //有Alpha渐变时直接设为不透明
                TweenAlpha tween = com as TweenAlpha;
                if (tween != null)
                {
                    tween.value = 1;
                }

                // 剩余的组件添加到remove_list
                remove_list.Add(com);
            }

            for (int i = remove_list.Count - 1; i >= 0; i--)
            {
                //包含序列帧特效的GameObject直接删掉，因为有特效重叠不同步的问题，物品除外
                if (remove_list[i] is UGUIFrameAnimation)
                {
                    if (remove_list[i].transform.parent != null && remove_list[i].transform.parent.parent != null)
                    {
                        if (remove_list[i].transform.parent.parent.GetComponent<UIItemNewSlot>() == null)
                        {
                            UnityEngine.Object.DestroyImmediate(remove_list[i].gameObject);
                        }
                    }
                }
                else
                {
                    UnityEngine.Object.DestroyImmediate(remove_list[i]);
                }
            }
            SGameEngine.Pool<MonoBehaviour>.List.Free(remove_list);

            var canvas = CopyObj.GetComponent<Canvas>();
            if (canvas != null)
            {
                UnityEngine.Object.DestroyImmediate(canvas);
            }

            CopyObj.SetActive(false);
            CopyTrans.SetParent(Wnd.TargetTmpRoot);

            var local_pos = CopyTrans.localPosition;
            local_pos.z = 0f;
            CopyTrans.localPosition = local_pos;
            RectTransform copy_trans = CopyTrans.GetComponent<RectTransform>();
            RectTransform traget_trans = TargetObject.GetComponent<RectTransform>();
            UGUIMath.SetWidgetSize(copy_trans, traget_trans);
            CopyObj.SetActive(true);

            // 可能traget_trans的父亲节点有缩放
            var rect_corner = new Vector3[4];
            copy_trans.GetWorldCorners(rect_corner);
            float copy_rect_size_x = rect_corner[2].x - rect_corner[0].x;

            traget_trans.GetWorldCorners(rect_corner);
            float target_size_x = rect_corner[2].x - rect_corner[0].x;

            float scale = 1;
            if(copy_rect_size_x != 0) scale = target_size_x / copy_rect_size_x;
            Vector3 ori_scale = CopyTrans.localScale;
            CopyTrans.localScale = new Vector3(ori_scale.x* scale, ori_scale.y * scale, ori_scale.z *scale);

            for (int i = spec_list.Count - 1; i >= 0; i--)
            {
                var com = spec_list[i];

                //StartLoadModel 函数中播放模型动作在object隐藏时会不生效，需延后调用
                TargetModelInfo target_model_info = com as TargetModelInfo;
                if (target_model_info != null)
                {
                    target_model_info.StartLoadModel();
                }
            }

            SGameEngine.Pool<MonoBehaviour>.List.Free(spec_list);
        }
    }
}
