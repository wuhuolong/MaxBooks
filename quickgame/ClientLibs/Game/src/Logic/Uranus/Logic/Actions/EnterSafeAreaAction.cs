

using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 进入安全区域
    /// </summary>
    [Serializable]
    public class EnterSafeAreaAction : IAction
    {
        public override NodeStatus Execute()
        {
            xc.PKModeManagerEx.Instance.IsInSafeArea = true;
            return NodeStatus.SUCCESS;
        }
    }
}