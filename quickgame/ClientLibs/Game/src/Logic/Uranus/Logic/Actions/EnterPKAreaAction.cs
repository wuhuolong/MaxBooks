

using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 进入PK区域
    /// </summary>
    [Serializable]
    public class EnterPKAreaAction : IAction
    {
        public override NodeStatus Execute()
        {
            xc.PKModeManagerEx.Instance.IsInPKArea = true;
            return NodeStatus.SUCCESS;
        }
    }
}
