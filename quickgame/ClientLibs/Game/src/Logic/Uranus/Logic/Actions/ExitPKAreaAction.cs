
using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 退出PK区域
    /// </summary>
    [Serializable]
    public class ExitPKAreaAction : IAction
    {
        public override NodeStatus Execute()
        {
            xc.PKModeManagerEx.Instance.IsInPKArea = false;
            return NodeStatus.SUCCESS;
        }
    }
}