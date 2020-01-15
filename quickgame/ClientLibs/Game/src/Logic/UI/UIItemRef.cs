using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc.ui.ugui;

namespace xc
{
    namespace ui
    {
        [DisallowMultipleComponent]
        public class UIItemRef : MonoBehaviour
        {

            [Header("面板canvas")]
            public Canvas TargetPanel;
            [Header("裁剪区域：（只有ScrollView 滑动区域需要裁剪）")]
            public RectTransform ClipPanel;

            public void OnDestroy()
            {
                this.TargetPanel = null;
                this.ClipPanel = null;
            }


            /// <summary>
            /// 替换prefab,返回一个新的对象,并设置当前gameobject为false,设置为同一层级中
            /// </summary>
            public UIItemNewSlot ReplaceItemPrefab(bool newInstance = true)
            {
                var slot = UIItemNewSlot.Bind(this.gameObject, this.TargetPanel, this.ClipPanel);
                return slot.ReplaceItemPrefab(newInstance);
            }

            public static UIItemNewSlot Bind(GameObject itemObj)
            {
                return UIItemNewSlot.Bind(itemObj);
            }



            /// <summary>
            /// 获取UIItemNewSlot对象
            /// </summary>
            /// <returns></returns>
            public UIItemNewSlot Bind()
            {
                return UIItemNewSlot.Bind(this.gameObject, this.TargetPanel, this.ClipPanel);
            }
        }
    }
}