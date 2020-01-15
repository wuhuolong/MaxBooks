//-------------------------------------------
// File: UIJoystick.cs
// Desc: 虚拟摇杆的逻辑
// Author: raorui
// Date: 2017.9.15
//-------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace xc
{
    namespace ui
    {
        public class UIJoystick : MonoBehaviour
        {
            public Vector2 position { get { return m_Position; } }

            /// <summary>
            /// UI相机
            /// </summary>
            Camera m_UICamera = null;

            /// <summary>
            /// 虚拟摇杆的背景图
            /// </summary>
            protected Image m_BackImage = null;

            /// <summary>
            /// 虚拟摇杆的小按钮
            /// </summary>
            protected Image m_Thumb = null;

            /// <summary>
            /// 背景图的大小（圆形）
            /// </summary>
            float m_BackImageSize = 0.0f;

            /// <summary>
            /// 背景图的大小的倒数（圆形）
            /// </summary>
            float m_BackImageSizeInv = 0.0f;

            /// <summary>
            ///  Thumb按住时候的alpha数值
            /// </summary>
            protected float TouchFingerAlhpa = 1.0f;

            /// <summary>
            /// Thumb释放时候的alpha数值
            /// </summary>
            protected float TouchReleaseAlhpa = 0.6f;

            /// <summary>
            /// 虚拟摇杆的坐标
            /// </summary>
            protected Vector2 m_Position = Vector2.zero;

            /// <summary>
            /// 摇杆的可响应区域范围
            /// </summary>
			Rect mJoystickRect = Rect.MinMaxRect(0f, 0f, 0f, 0f);

            /// <summary>
            /// 组件的Transform
            /// </summary>
            Transform m_CacheTrans;

            /// <summary>
            /// 摇杆按钮的Transform
            /// </summary>
            protected Transform m_ThumbTrans;

            /// <summary>
            /// 虚拟摇杆初始的位置
            /// </summary>
            Vector3 m_InitLocalPos;

            protected int m_LastFingerId = -1;// 上一次控制虚拟摇杆的TouchID
            protected float m_LastFingerTime = 0; // 上一次控制虚拟摇杆的时间

            protected bool mJoystickIsShow = false;

            protected bool mIsForceToShow = false;


            void Awake()
            {
                m_CacheTrans = transform;
            }

            void Start()
            {
                mJoystickRect = Rect.MinMaxRect(1280 * 0.06f, 720 * 0.1f, 1280 * 0.25f, 720 * 0.3f);

                var local_pos = m_CacheTrans.localPosition;
                var joystick_info = GetComponent<JoystickInfo>();
                if (joystick_info != null)
                    local_pos = joystick_info.m_InitPos;
                local_pos.x = Mathf.Clamp(local_pos.x, mJoystickRect.xMin, mJoystickRect.xMax);
                local_pos.y = Mathf.Clamp(local_pos.y, mJoystickRect.yMin, mJoystickRect.yMax);
                local_pos.z = 0.0f;

                m_CacheTrans.localPosition = local_pos;
                m_InitLocalPos = local_pos;

                m_ThumbTrans = m_CacheTrans.Find("Thumb");
                if (m_ThumbTrans != null)
                {
                    m_Thumb = m_ThumbTrans.GetComponent<Image>();
                }

                if (m_Thumb == null)
                {
                    Debug.LogError("[UIJoystick]m_Thumb is null");
                    return;
                }

                Transform background_trans = m_CacheTrans.Find("Background");
                if (background_trans != null)
                    m_BackImage = background_trans.GetComponent<Image>();

                if (m_BackImage == null)
                {
                    Debug.LogError("[UIJoystick]m_BackImage is null");
                    return;
                }

                var rect_trans = m_BackImage.GetComponent<RectTransform>();
                // 获取背景的大小
                if(rect_trans.sizeDelta.x != rect_trans.sizeDelta.y)
                {
                    Debug.LogError("[UIJoytick]BackImage size is not square");
                }
                m_BackImageSize = rect_trans.sizeDelta.x;
                m_BackImageSizeInv = 2.0f / m_BackImageSize;
            }

            public virtual void ResetJoystick()
            {
                m_CacheTrans.localPosition = m_InitLocalPos;// 重置虚拟摇杆的初始位置

                m_Position = Vector2.zero;
                m_LastFingerId = -1;
                m_LastFingerTime = 0;

                if (m_Thumb != null)
                {
                    m_ThumbTrans.localPosition = Vector3.zero;
                    m_Thumb.color = new Color(m_Thumb.color.r, m_Thumb.color.g, m_Thumb.color.b, TouchReleaseAlhpa);
                }

                Color release_color = Color.white;
                release_color.a = TouchReleaseAlhpa;
                m_BackImage.color = release_color;

                mJoystickIsShow = false;
            }

            /// <summary>
            /// 是否有InputTouch(非摇杆TouchID)
            /// </summary>
            public bool IsFingerDown
            {
                get
                {
                    if(m_LastFingerId == -1)
                    {
                        return Input.touchCount > 0;
                    }
                    else
                    {
                        for(int i = 0; i < Input.touchCount; ++i)
                        {
                            var touch = Input.GetTouch(i);
                            if (touch.fingerId != m_LastFingerId)
                                return true;
                        }

                        return false;
                    }
                }
            }

            void Update()
            {
                if (m_UICamera == null)
                {
                    m_UICamera = xc.ui.ugui.UIMainCtrl.MainCam;
                    return;
                }

                Vector3 thumb_localpos = Vector3.zero;
                Vector2 touch_pos = Vector3.zero;

                int count = Input.touchCount;

                if (count == 0)
                {
                    ResetJoystick();
                    return;
                }

                for (int i = 0; i < count; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    
                    // 已经有摇杆对应的Touch
                    if (m_LastFingerId != -1 && m_LastFingerId != touch.fingerId)
                        continue;

                    touch_pos = touch.position;
                    if (touch.phase == TouchPhase.Began)// 开始点击
                    {
                        bool touch_ui = UIInputEvent.TouchedUI(touch.fingerId);

                        // 触碰到ui或者在可触摸范围外
                        if ((touch_ui || InTouchRange(touch_pos) == false))
                            continue;

                        // 记录fingerId和触摸的时间
                        m_LastFingerId = touch.fingerId;
                        m_LastFingerTime = Time.time;

                        // 显示虚拟摇杆
                        ShowJoystick(touch_pos);

                        // 发送事件
                        Actor actor = Game.Instance.GetLocalPlayer(); 
                        if (actor != null)
                        {
                            ClientEventMgr.GetInstance().FireEvent((int)ClientEvent.CE_PLAYERCONTROLED, null);
                        }
                        break;
                    }
                    else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) // 在移动过程中
                    {
                        // 没有已经开始的Touch
                        if (m_LastFingerId == -1)
                            continue;

                        // 按下一段时间才可设置摇杆Thumb的位置
                        if (Time.time - m_LastFingerTime >= 0.1f)
                            thumb_localpos = ShowThumb(touch_pos);

                        break;
                    }
                    else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) // 移动结束
                    {
                        // 没有已经开始的Touch
                        if (m_LastFingerId == -1) 
                            continue;

                        ResetJoystick();
                        break;
                    }
                }

                // 根据虚拟摇杆的按钮的位置来计算[-1,1]的坐标
                m_Position.x = thumb_localpos.x * m_BackImageSizeInv;
                m_Position.y = thumb_localpos.y * m_BackImageSizeInv;
            }

            /// <summary>
            /// 是否在触摸范围内
            /// </summary>
            /// <returns></returns>
            bool InTouchRange(Vector3 touch_pos)
            {
                // 设置Joystick的位置为屏幕上点击到的位置
                Vector3 world_pos = m_UICamera.ScreenToWorldPoint(new Vector3(touch_pos.x, touch_pos.y, m_UICamera.nearClipPlane)); // 屏幕坐标转为世界坐标
                Vector3 local_pos = m_CacheTrans.parent.InverseTransformPoint(world_pos);// 将世界坐标转为本地坐标
                if (local_pos.x > 1280*0.5)
                    return false;

                if (local_pos.y > 720*0.5)
                    return false;

                return true;
            }

            /// <summary>
            /// 设置Joystick的位置和透明度
            /// </summary>
			protected virtual void ShowJoystick(Vector3 touch_pos)
            {
                if (!mJoystickIsShow)
                {
                    mJoystickIsShow = true;

                    Color touch_color = Color.white;
                    touch_color.a = TouchFingerAlhpa;
                    m_BackImage.color = touch_color;
                    m_Thumb.color = new Color(m_Thumb.color.r, m_Thumb.color.g, m_Thumb.color.b, TouchFingerAlhpa);

                    // 设置Joystick的位置为屏幕上点击到的位置
                    Vector3 world_pos = m_UICamera.ScreenToWorldPoint(new Vector3(touch_pos.x, touch_pos.y, m_UICamera.nearClipPlane)); // 屏幕坐标转为世界坐标
                    Vector3 local_pos = m_CacheTrans.parent.InverseTransformPoint(world_pos);// 将世界坐标转为本地坐标
                    local_pos.x = Mathf.Clamp(local_pos.x, mJoystickRect.xMin, mJoystickRect.xMax);
                    local_pos.y = Mathf.Clamp(local_pos.y, mJoystickRect.yMin, mJoystickRect.yMax);
                    local_pos.z = 0.0f;

                    m_CacheTrans.localPosition = local_pos;
                }
            }

            Vector3 ShowThumb(Vector3 touch_pos)
            {
                Vector3 world_pos = m_UICamera.ScreenToWorldPoint(new Vector3(touch_pos.x, touch_pos.y, m_UICamera.nearClipPlane));
                Vector3 local_pos = m_CacheTrans.InverseTransformPoint(world_pos);
                local_pos.z = 0;
                if(local_pos.magnitude > m_BackImageSize * 0.5f)
                {
                    local_pos = local_pos.normalized * m_BackImageSize * 0.5f;
                }

                m_ThumbTrans.localPosition = local_pos;
                return local_pos;
            }
        }
    } // ui
} // xc