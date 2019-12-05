//---------------------------------------
// File:    WidgetIsShow.cs
// Desc:    指定的控件是否已经显示
// Author:  Raorui
// Date:    2017.9.20
//---------------------------------------
using xc;
using xc.ui.ugui;

namespace Guide.Condition
{
    [wxb.Hotfix]
    public class WidgetIsShow : ICondition
    {
        /// <summary>
        /// 控件所在的路径
        /// </summary>
        public string WidgetPath { get; private set; }

        public WidgetIsShow(ECondtionType type, string param)
            : base(type, param)
        { }

        public override void Init(string param)
        {
            WidgetPath = param;
        }

        bool m_LastVisiable = false;

        public override bool IsAchieve(Guide.Step step)
        {
            var target = GuideManager.Instance.GetWidgetByPath(WidgetPath);

            bool nowState = false;
            if (step.DisplayType == EDisplayType.Region) // 区域显示类型的，先判断节点已经Active，再做射线检测
            {
                if (target == null || !target.activeInHierarchy)
                {
                    nowState = false;
                }
                else
                {
                    NoDrawingRayCast noDrawingRayCast = target.GetComponent<NoDrawingRayCast>();
                    if (noDrawingRayCast == null)
                    {
                        noDrawingRayCast = target.AddComponent<NoDrawingRayCast>();
                    }
                    if (noDrawingRayCast != null)
                    {
                        noDrawingRayCast.raycastTarget = true;
                    }
                    nowState = GuideManager.Instance.IsWidgetVisible(target);
                    if (noDrawingRayCast != null)
                    {
                        noDrawingRayCast.raycastTarget = false;
                    }
                }
            }
            else
            {
                nowState = GuideManager.Instance.IsWidgetVisible(target);
            }

            nowState = nowState && GuideManager.Instance.MatchComponent(target, WidgetPath);

            if (nowState && m_LastVisiable)
            {
                if (target != null)
                {
                    UIFinishGuideBtn finishGuideBtn = target.GetComponent<UIFinishGuideBtn>();
                    if (finishGuideBtn == null)
                    {
                        finishGuideBtn = target.AddComponent<UIFinishGuideBtn>();
                        finishGuideBtn.GuideId = step.GuideId;
                        finishGuideBtn.StepId = step.StepId;
                    }
                }

                return true;
            }

            // 延迟一帧
            m_LastVisiable = nowState;
            return false;
        }
    }
}
