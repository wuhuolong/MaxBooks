//---------------------------------------
// File:    GuideHelper.cs
// Desc:    新手引导帮助类
// Author:  lijiayong
// Date:    2018.7.27
//---------------------------------------
using System;
using System.Collections.Generic;
using xc;

namespace xc
{
    [wxb.Hotfix]
    public class GuideHelper
    {
        /// <summary>
        /// 指定的引导结束且返回主界面后是否执行主线任务
        /// </summary>
        /// <param name="guideId"></param>
        /// <returns></returns>
        public static bool GetIsGuideMainTaskWhenFinishAndReturnMainWnd(uint guideId)
        {
            var dbGuide = DBManager.GetInstance().GetDB<DBGuide>();
            var guide = dbGuide.GetGuideById(guideId);
            if (guide != null)
            {
                return guide.GuideMainTaskWhenFinishAndReturnMainWnd;
            }

            return false;
        }
    }
}
