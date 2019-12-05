//---------------------------------------
// File:    GuideStep.cs
// Desc:    引导的单个步骤
// Author:  Raorui
// Date:    2017.9.20
//---------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using xc;
using xc.ui;
using Guide.Trigger;
using xc.protocol;
using Net;

namespace Guide
{
    /// <summary>
    /// 引导图标（箭头）的指向
    /// </summary>
    public enum EGuideIconDir
    {
        Top = 1, //指上
        Right = 2, //指右
        Bottom = 3,//指下
        Left = 4,//指左
    }

    /// <summary>
    /// 引导显示的类型
    /// </summary>
    public enum EDisplayType
    {
        Arrow = 1, // 手指指引
        Picture, // 显示全屏图片
        Model, // 显示角色模型
        Text, // 居中显示模型和文本
        Region // 显示一块区域
    }

    /// <summary>
    /// 单个引导的步骤
    /// </summary>
    public class Step : IComparable
    {
        /// <summary>
        /// 引导序列ID
        /// </summary>
        public uint GuideId { get; set; }

        /// <summary>
        /// 引导步骤ID
        /// </summary>
        public uint StepId { get; set; }

        /// <summary>
        /// 发送事件的类型
        /// 1: 发送点击事件
        /// 2: 发送按下事件
        /// </summary>
        public byte EventType { get; set; }

        /// <summary>
        /// 引导箭头的方向
        /// </summary>
        public EGuideIconDir IconDir { get; set; }

        /// <summary>
        /// 图标的文字描述
        /// </summary>
        public string IconDesc { get; set; }

        /// <summary>
        /// 图片显示的名字
        /// </summary>
        public string PicName { get; set; }

        /// <summary>
        /// 显示模型是否播放的动作
        /// </summary>
        public string AnimationName { get; set; }

        /// <summary>
        /// 模型引导在X方向的偏移位置
        /// </summary>
        public float Offset_X { get; set; }

        /// <summary>
        /// 是否是强制指引
        /// </summary>
        public bool IsForcible { get; set; }

        /// <summary>
        /// 是否响应点击屏幕任意区域(非强制引导使用)
        /// </summary>
        public bool ClickAny { get; set; }

        /// <summary>
        /// 是否暂停副本中的逻辑
        /// </summary>
        public bool IsPause { get; set; }

        /// <summary>
        /// 执行到此步骤就可以标记为结束
        /// </summary>
        public bool IsCanFinish { get; set; }

        /// <summary>
        /// 是否可以通过跳过按钮跳过该引导步骤和后续的引导步骤
        /// </summary>
        public bool IsCanSkip { get; set; }

        /// <summary>
        /// 在引导的时候，需要将某些特殊的控件隐藏
        /// </summary>
        public string HideWidget { get; set; }

        /// <summary>
        /// 指引的时候显示的类型
        /// </summary>
        public EDisplayType DisplayType { get; set; }

        /// <summary>
        /// 引导触发的条件
        /// </summary>
        public List<ICondition> GuideTriggerList { get; set; }

        /// <summary>
        /// 语音资源id
        /// </summary>
        public uint VoiceId { get; set; }

        public ITrigger TargetTrigger { get; set; }

        bool m_IsFinished = false;
        public bool IsFinished
        {
            get
            {
                return m_IsFinished;
            }
            set
            {
                m_IsFinished = value;
                if(m_IsFinished && IsPause)// 当前步骤完成后，重新开启ai
                {
                    C2SDungeonStartAi start_ai = new C2SDungeonStartAi();
                    NetClient.GetBaseClient().SendData<C2SDungeonStartAi>(NetMsg.MSG_DUNGEON_START_AI, start_ai);

                    InstanceHelper.ResumeInstance();
                }
            }
        }

        public void Reset()
        {
            IsFinished = false;

            if (TargetTrigger != null)
                TargetTrigger.Reset();
        }

        public Step(uint guide_id, uint step_id, bool is_forcible)
        {
            GuideId = guide_id;
            StepId = step_id;
            IsForcible = is_forcible;

            GuideTriggerList = new List<ICondition>();
        }

        /// <summary>
        /// 检查引导的触发条件是否都满足了
        /// </summary>
        /// <returns></returns>
        public bool CheckGuideCondition()
        {
            foreach (var trigger in GuideTriggerList)
            {
                if (!trigger.IsAchieve(this))
                {
                    return false;
                }
            }

            return true;
        }

        public bool TryToStartup()
        {
            return TargetTrigger.TryToStartUp();
        }

        private void WaitToFinish(float dt)
        {
            // 不能用协程，因为协程依赖于monoBehaviour，所以当Time.timeScale变为0时，协程也动不了了
            new Utils.Timer((int)(dt * 1000), false, dt * 1000f,
                (t) =>
                {
                    GuideManager.Instance.TryToFinishGuideStep(this);
                });
        }

        public int CompareTo(object obj)
        {
            var guideStep = obj as Step;
            if (guideStep == null)
            {
                return -1;
            }
            if (GuideId < guideStep.GuideId)
            {
                return -1;
            }
            else if (GuideId > guideStep.GuideId)
            {
                return 1;
            }
            return StepId.CompareTo(guideStep.StepId);
        }

        // Utils
        public void GuideClick(GameObject target)
        {
            if(target == null)
            {
                return;
            }

            var guidewnd = xc.ui.ugui.UIManager.Instance.GetWindow("UIGuideWindow");
            var guide_wnd = (xc.ui.ugui.UIGuideWindow)guidewnd;
            //FIXME 直接判断为空可能有其他问题
            if (guide_wnd == null)
            {
                GameDebug.LogError("Guide.GuideStep.GuideClick Can not get UIGuideWindow");
                //xc.ClientEventManager<ClientEvent>.Instance.FireEvent(ClientEvent.WINDOW_SHOW, new xc.ClientEventParamArgs("UIGuideWindow"));
                return;
            }

            guide_wnd.GuideClick(this, target);

            if (!guide_wnd.IsShow)
                guide_wnd.Show();
        }

        public void GuideClickMask(GameObject target)
        {
            var guidewnd = xc.ui.ugui.UIManager.Instance.GetWindow("UIGuideWindow");
            var guide_wnd = (xc.ui.ugui.UIGuideWindow)guidewnd;
            //FIXME 直接判断为空可能有其他问题
            if (guide_wnd == null)
            {
                GameDebug.LogError("Guide.GuideStep.GuideClickMask Can not get UIGuideWindow");
                return;
            }

            guide_wnd.GuideClickMask(this, target);

            if (!guide_wnd.IsShow)
                guide_wnd.Show();
        }

        /// <summary>
        /// 加载指引需要的角色模型
        /// </summary>
        public void PrepareModel()
        {
            if (this.DisplayType == EDisplayType.Model || this.DisplayType == EDisplayType.Text || this.DisplayType == EDisplayType.Region)
            {
                var guidewnd = xc.ui.ugui.UIManager.Instance.GetWindow("UIGuideWindow");
                var guide_wnd = (xc.ui.ugui.UIGuideWindow)guidewnd;
                if (guide_wnd == null)
                {
                    GameDebug.LogError("Guide.GuideStep.GuideClickMask Can not get UIGuideWindow");
                    return;
                }

                guide_wnd.PrepareModel(this.AnimationName);
            }
        }
    }
}
