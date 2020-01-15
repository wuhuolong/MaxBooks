using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uranus.Runtime
{
    [Serializable]
    public class OpenWorldMapWindowAction : IAction
    {
        public uint SceneId;

        public override NodeStatus Execute()
        {
            xc.ui.ugui.UIManager.Instance.ShowSysWindow("UIWorldMapWindow", SceneId);
            return NodeStatus.SUCCESS;
        }
    }
}
