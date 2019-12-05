//----------------------------------------
// File: UGUIMath.cs
// Desc: UIGUI控件计算的辅助类
// Author: Raorui
// Date: 2017.9.21
//----------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using xc.ui;
using xc.ui.ugui;
using SGameEngine;

namespace xc
{
    class UGUIMath
    {
        /// <summary>
        /// 获取rect_trans的size,来设置target_trans对应控件的大小
        /// </summary>
        /// <param name="target_trans"></param>
        /// <param name="rect_trans"></param>
        public static void SetWidgetSize(RectTransform target_trans, RectTransform rect_trans)
        {
            if (target_trans == null)
                return;

            target_trans.anchorMax = new Vector2(0.5f, 0.5f);
            target_trans.anchorMin = new Vector2(0.5f, 0.5f);
            target_trans.offsetMin = Vector2.zero;
            target_trans.offsetMax = Vector2.zero;

            Vector2 size = Vector2.zero;
            size.x = rect_trans.rect.width;
            size.y = rect_trans.rect.height;
            target_trans.sizeDelta = size;
        }

        /// <summary>
        /// 计算rect_trans在世界坐标系下的Bounds
        /// </summary>
        /// <param name="rect_trans"></param>
        /// <returns></returns>
        public static Bounds CalculateAbsoluteBounds(RectTransform rect_trans)
        {
            if(rect_trans == null || rect_trans.parent == null)
            {
                Debug.LogError("[CalculateAbsoluteBounds]rect_trans is null");
                return new Bounds(Vector3.zero, Vector3.zero);
            }

            //bottom left->top left->top right->bottom right
            Vector3[] v = new Vector3[4];
            rect_trans.GetWorldCorners(v);

            Bounds bound = new Bounds();
            bound.SetMinMax(v[0], v[2]);
            return bound;

            // invalid
            //Vector3 max = rect_trans.parent.TransformPoint(rect_trans.rect.width, rect_trans.rect.height, 0);// 计算min位置
            // Vector3 min = rect_trans.parent.TransformPoint(Vector3.zero);// 计算min位置
        }

        /// <summary>
        /// 触摸点的二维坐标
        /// </summary>
        static Vector2 m_EventPos = new Vector2();

        /// <summary>
        /// 获取屏幕位置处碰撞到的UI物体
        /// </summary>
        /// <param name="inPos"></param>
        /// <returns></returns>
        static public GameObject GetRaycastObj(Vector3 inPos, PointerEventData eventDataCurrentPosition, List<GameObject> excludeGameObjects = null, bool excludeChildren = false)
        {
            Camera curCam = UIMainCtrl.MainCam;
            if (!curCam.enabled)
                return null;

            // 检查屏幕坐标合法性
            Vector3 pos = curCam.ScreenToViewportPoint(inPos);
            if (float.IsNaN(pos.x) || float.IsNaN(pos.y))
                return null;

            if (pos.x < 0f || pos.x > 1f || pos.y < 0f || pos.y > 1f)
                return null;

            if (EventSystem.current == null)
                return null;

            //将点击位置的屏幕坐标赋值给点击事件
            //PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

            m_EventPos.x = inPos.x;
            m_EventPos.y = inPos.y;
            eventDataCurrentPosition.position = m_EventPos;
            

            //向点击处发射射线
            //List<RaycastResult> results = new List<RaycastResult>();

            var results = Pool<RaycastResult>.List.New();
            results.Clear();

            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            GameObject gameobj = null;
            if (results.Count > 0)
            {
                if (excludeGameObjects != null && excludeGameObjects.Count > 0)
                {
                    foreach (GameObject excludeGameObject in excludeGameObjects)
                    {
                        for (int i = results.Count - 1; i >= 0; i--)
                        {
                            RaycastResult retult = results[i];
                            if (excludeChildren)
                            {
                                if (ContainWidget(excludeGameObject, retult.gameObject))
                                {
                                    results.Remove(retult);
                                }
                            }
                            else
                            {
                                if (excludeGameObject == retult.gameObject)
                                {
                                    results.Remove(retult);
                                }
                            }
                        }
                    }
                }
                if (results.Count > 0)
                {
                    gameobj = results[0].gameObject;
                }
            }

            Pool<RaycastResult>.List.Free(results);


            return gameobj;
        }

        /// <summary>
        /// parent 是否包含widget
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="widget"></param>
        /// <returns></returns>
        static public bool ContainWidget(GameObject parent, GameObject widget)
        {
            //var elements = parent.GetComponentsInChildren<Transform>(true);
            //foreach(var e in elements)
            //{
            //    if (e.gameObject == widget)
            //        return true;
            //}

            if (parent == null || widget == null)
            {
                return false;
            }

            Transform parentTrans = widget.transform;
            while (parentTrans != null)
            {
                if (parentTrans == parent.transform)
                {
                    return true;
                }
                parentTrans = parentTrans.parent;
            }

            return false;
        }
    }
}
