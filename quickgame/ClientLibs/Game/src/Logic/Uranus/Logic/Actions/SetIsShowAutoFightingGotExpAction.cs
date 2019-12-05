

using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 是否显示经验效率
    /// </summary>
    [Serializable]
    public class SetIsShowAutoFightingGotExpAction : IAction
    {
        public bool IsShow;

        public override NodeStatus Execute()
        {
            xc.InstanceManager.Instance.IsShowAutoFightingGotExp = IsShow;
            return NodeStatus.SUCCESS;
        }
    }
}