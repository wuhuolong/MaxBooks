//---------------------------------------
// File:    GuideTrigger.cs
// Desc:    引导触发完成条件判断的基类
// Author:  Raorui
// Date:    2017.9.20
//---------------------------------------
using System;
using UnityEngine;
using xc;
using xc.ui;

namespace Guide
{
    /// <summary>
    /// 完成指引的条件类型
    /// </summary>
    public enum ETriggerType
    {
        CLICK_WIDGET = 101, //完成点击操作
        CLICK_MASK = 102, //点击屏幕任意位置
        CLICK_IN_BAG = 103,//点击背包某个物品
        CLICK_SYS_BTN = 104,//点击系统按钮
        USE_JOYSTICK = 105, //完成摇杆操作 
    }

    namespace Trigger
    {
        public class ITrigger
        {
            /// <summary>
            /// 完成条件类型
            /// </summary>
            public ETriggerType TriggerType { get; set; }

            /// <summary>
            /// 对应的引导步骤
            /// </summary>
            public Step Parent { get; set; }

            /// <summary>
            /// 是否强制指引
            /// </summary>
            public bool IsForcible { get { return Parent.IsForcible; } }

            /// <summary>
            /// 引导是否完成
            /// </summary>
            public bool Finished { get; protected set; }

            /// <summary>
            /// 通过触发条件和参数进行初始化
            /// </summary>
            /// <param name="type"></param>
            /// <param name="param"></param>
            public ITrigger(ETriggerType type, string param)
            {
                TriggerType = type;
                Finished = false;
                Init(param);
            }

            /// <summary>
            /// 重置指引
            /// </summary>
            public virtual void Reset()
            {
                Finished = false;
            }

            /// <summary>
            /// 通过参数初始化
            /// </summary>
            /// <param name="param"></param>
            public virtual void Init(string param)
            { }

            /// <summary>
            /// 引导是否完成
            /// </summary>
            /// <returns></returns>
            public virtual bool IsAchieve()
            {
                return Finished;
            }

            /// <summary>
            /// 开始监听当前引导的步骤是否完成
            /// </summary>
            /// <returns></returns>
            public virtual bool TryToStartUp()
            {
                return true;
            }

            /// <summary>
            /// 通知点击事件
            /// </summary>
            public virtual void NotifyClick()
            {
                Finish();
                HideGuideWindow();
            }

            /// <summary>
            /// 引导完成后的处理
            /// </summary>
            public virtual void Finish()
            {
                Finished = true;
            }

            protected void WaitToFinish(float dt)
            {
                // 不能用协程，因为协程依赖于monoBehaviour，所以当Time.timeScale变为0时，协程也动不了了
                new Utils.Timer((int)(dt * 1000), false, dt * 1000f,
                    (t) =>
                    {
                        Finish();
                    });
            }

            protected void WaitToFinish()
            {
                WaitToFinish(0f);
            }

            /// <summary>
            /// 检查引导需要的UI是否都已经加载完毕
            /// </summary>
            /// <returns></returns>
            protected bool IsMainUIReady()
            {
                var mainmap_window = xc.ui.ugui.UIManager.Instance.GetWindow("UIMainmapWindow");
                if (mainmap_window == null || !mainmap_window.IsShow)
                {
                    return false;
                }

                var guide_wnd = xc.ui.ugui.UIManager.Instance.GetWindow("UIGuideWindow");
                if (guide_wnd == null)
                    return false;

                return true;
            }

            protected void HideGuideWindow()
            {
                xc.ui.ugui.UIManager.Instance.CloseWindow("UIGuideWindow");
            }
        }

        [wxb.Hotfix]
        public class Factory
        {
            public static ITrigger CreateTrigger(ETriggerType type, string param)
            {
                switch (type)
                {
                    case ETriggerType.CLICK_WIDGET:
                    case ETriggerType.CLICK_MASK:
                        return new GuideTriggerClick(type, param);
                    case ETriggerType.CLICK_SYS_BTN:
                        return new ClickSysBtn(type, param);
                    case ETriggerType.CLICK_IN_BAG:
                        return new GuideTriggerClickInBag(type, param);
                    default:
                        return null;
                }
            }
        }
    }
}
