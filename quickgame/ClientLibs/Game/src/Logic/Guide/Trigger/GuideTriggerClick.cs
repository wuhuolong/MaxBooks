using xc;
using xc.ui;
using UnityEngine;

namespace Guide.Trigger
{
    /// <summary>
    /// 点击指定控件完成触发
    /// </summary>
    [wxb.Hotfix]
    public class GuideTriggerClick : ITrigger
    {
        public string WidgetPath { get; private set; }

        public GuideTriggerClick(ETriggerType type, string param)
            : base(type, param)
        { }

        public override void Init(string param)
        {
            WidgetPath = param;
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

            UnityEngine.GameObject target = null;
            if(string.IsNullOrEmpty(WidgetPath) == false)
                target = GuideManager.Instance.GetWidgetByPath(WidgetPath);

            if (string.IsNullOrEmpty(WidgetPath) || IsVisible(target))// 填写控件路径，则必须可见
            {
                Parent.PrepareModel();
                if (TriggerType == ETriggerType.CLICK_MASK)
                    Parent.GuideClickMask(target);
                else
                    Parent.GuideClick(target);

                return true;
            }

            return false;
        }

        bool IsVisible(GameObject target)
        {
            if (target == null)
                return false;

            if (target.tag.CompareTo("GuideRegion") == 0)
                return target.activeInHierarchy;
            else
                return GuideManager.Instance.IsWidgetVisible(target);
        }
    }
}
