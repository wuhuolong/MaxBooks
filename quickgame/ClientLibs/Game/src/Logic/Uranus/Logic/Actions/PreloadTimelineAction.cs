

using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 预加载Timeline剧情动画
    /// </summary>
    [Serializable]
    public class PreloadTimelineAction : IAction
    {
        /// <summary>
        /// 剧情id
        /// </summary>
        public uint TimelineId;

        public override NodeStatus Execute()
        {
            xc.TimelineManager.Instance.Preload(TimelineId);
            return NodeStatus.SUCCESS;
        }
    }
}
