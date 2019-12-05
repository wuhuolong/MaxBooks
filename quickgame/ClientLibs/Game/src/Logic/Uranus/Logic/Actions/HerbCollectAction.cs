using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using xc;
using Net;
using xc.protocol;

namespace Uranus.Runtime
{
    /// <summary>
    /// 采药Action
    /// </summary>
    [Serializable]
    public class HerbCollectAction : IAction
    {
        public override NodeStatus Execute()
        {
            xc.ui.ugui.UIManager.Instance.ShowWindow("UIHerbCollectWindow", 1);
            return NodeStatus.SUCCESS;
        }
    }
}
