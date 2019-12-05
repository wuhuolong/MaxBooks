using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 是否第一次通过寻路来跳场景
    /// 相关需求：https://www.tapd.cn/20249401/prong/stories/view/1120249401001002752
    /// </summary>
    [Serializable]
    public class IsFirstNavigatingJumpToSceneCondition : ICondition
    {
        protected override bool Check()
        {
            return xc.TargetPathManager.Instance.IsFirstNavigatingJumpToScene;
        }
    }
}
