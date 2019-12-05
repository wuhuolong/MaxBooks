using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Uranus.Runtime
{
    /// <summary>
    /// 设置是否第一次通过寻路来跳场景
    /// </summary>
    [Serializable]
    public class SetIsFirstNavigatingJumpToSceneAction : IAction
    {
        public bool isFirst = true;

        public override NodeStatus Execute()
        {
            xc.TargetPathManager.Instance.SetIsFirstNavigatingJumpToScene(isFirst);
            return NodeStatus.SUCCESS;
        }
    }
}
