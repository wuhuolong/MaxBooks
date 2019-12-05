//---------------------------------------
// File:GuideObject.cs
// Desc:引导的基类
// Author: raorui
// Date:2017.9.19
//---------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

namespace xc.ui.ugui
{
    /// <summary>
    /// GuideObject,保存当前的引导界面和范围
    /// </summary>
    public class GuideObject
    {
        public UIGuideWindow Wnd { get; set; }
        public Bounds Bounds { get; set; }

        public GuideObject(UIGuideWindow wnd)
        {
            Wnd = wnd;
        }

        public virtual void Cleanup() { }
        public virtual void Update() { }
    }
}
