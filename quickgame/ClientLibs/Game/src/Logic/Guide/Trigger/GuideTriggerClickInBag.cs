//---------------------------------------
// File:    GuideTriggerClickInBag.cs
// Desc:    点击背包中的某个物品才完成指引
// Author:  Raorui
// Date:    2017.9.20
//---------------------------------------
using UnityEngine;
using System.Collections.Generic;
using xc;
using xc.ui;

namespace Guide.Trigger
{
    [wxb.Hotfix]
    public class GuideTriggerClickInBag : ITrigger
    {
        // 参数格式： 1001101|1001201|1001301|1001401,UIBagMainWindow:Panel/frame/Container/ScrollView/Content/1

        /// <summary>
        /// 物品ItemSlot所在的层级
        /// </summary>
        string m_GoodsParentPath;

        /// <summary>
        /// 需要点击的物品列表
        /// </summary>
        public List<uint> GoodsId = new List<uint>();

        public GuideTriggerClickInBag(ETriggerType type, string param)
            : base(type, param)
        { }

        public override void Init(string param)
        {
            var path_list = param.Split(',');
            if (path_list.Length > 0)
            {
                var id_list = path_list[0].Split('|');

                // 获取物品ID
                foreach (var item in id_list)
                {
                    GoodsId.Add(uint.Parse(item));
                }
            } 

            if (path_list.Length > 1)
            {
                m_GoodsParentPath = path_list[1];
            } 
            else
            {
                m_GoodsParentPath = string.Empty;
            }
        }

        public override void NotifyClick()
        {
            Finish();
            HideGuideWindow();
        }

        public override bool TryToStartUp()
        {
            if (!IsMainUIReady())
                return false;

            var parentTarget = GuideManager.Instance.GetWidgetByPath(m_GoodsParentPath);

            if (!GuideManager.Instance.IsWidgetVisible(parentTarget))
            {
                return false;
            }

            if (GetTargetGoodsId() <= 0)
            {
                return false;
            }

            // 找出那个物品
            var slots = parentTarget.GetComponentsInChildren<UIItemNewSlot>(true);

            if (slots == null)
            {
                return false;
            }

            GameObject targetObject = null;

            foreach (var item in slots)
            {
                if (item == null)
                {
                    continue;
                }

                if (item.ItemInfo == null)
                {
                    continue;
                }

                if (item.ItemInfo.type_idx == GetTargetGoodsId())
                {
                    targetObject = item.gameObject;
                    break;
                }
            }

            if (targetObject == null)
            {
                return false;
            }

            if (GuideManager.Instance.IsWidgetVisible(targetObject))
            {
                Parent.PrepareModel();
                if (TriggerType == ETriggerType.CLICK_MASK)
                    Parent.GuideClickMask(targetObject);
                else
                    Parent.GuideClick(targetObject);

                return true;
            }

            return false;
        }

        /// <summary>
        /// 通过角色职业来获取需要点击的物品ID
        /// </summary>
        /// <returns></returns>
        uint GetTargetGoodsId()
        {
            uint vocation = LocalPlayerManager.Instance.LocalActorAttribute.Vocation - 1;

            if(GoodsId.Count <= 0)
            {
                return 0;
            }

            if(vocation >= GoodsId.Count)
            {
                return GoodsId[0];
            }

            return GoodsId[(int)vocation];
        }

    }
}
