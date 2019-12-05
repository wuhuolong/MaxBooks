
using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 退出安全区域
    /// </summary>
    [Serializable]
    public class ExitSafeAreaAction : IAction
    {
        public override NodeStatus Execute()
        {
            xc.PKModeManagerEx.Instance.IsInSafeArea = false;
            return NodeStatus.SUCCESS;
        }
    }
}