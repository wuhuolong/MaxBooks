//---------------------------------------
// File:    GuideConditon.cs
// Desc:    引导触发条件的基类
// Author:  Raorui
// Date:    2017.9.20
//---------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using xc;
using xc.ui;

namespace Guide
{
    public enum ECondtionType
    {
        WIDGET_IS_SHOW = 1, //组件可见
        SYSBTN_IS_SHOW = 2,//系统按钮可见
    }

    /// <summary>
    /// 触发条件的基类
    /// </summary>
    public abstract class ICondition
    {
        public ECondtionType ConditionType { get; private set; }

        public ICondition(ECondtionType type, string param)
        {
            ConditionType = type;
            Init(param);
        }

        /// <summary>
        /// 通过触发的参数来进行初始化
        /// </summary>
        /// <param name="param"></param>
        public abstract void Init(string param);

        /// <summary>
        /// 触发的条件是否达到
        /// </summary>
        /// <returns></returns>
        public abstract bool IsAchieve(Guide.Step step);
    }

    namespace Condition
    {
        public class Factory
        {
            /// <summary>
            /// 根据类型来创建不同的触发条件
            /// </summary>
            /// <param name="type"></param>
            /// <param name="param"></param>
            /// <returns></returns>
            public static ICondition CreateCondition(ECondtionType type, string param)
            {
                switch (type)
                { 
                    case ECondtionType.WIDGET_IS_SHOW:
                        return new WidgetIsShow(type, param);
                    case ECondtionType.SYSBTN_IS_SHOW:
                        return new GuideConditionSysBtnIsShow(type, param);
                    default:
                        return null;
                }
            }
        }
    }
}
