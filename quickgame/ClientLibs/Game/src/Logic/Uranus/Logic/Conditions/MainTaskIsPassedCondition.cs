using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 该主线任务是否已经通过
    /// </summary>
    [Serializable]
    public class MainTaskIsPassedCondition : ICondition
    {
        public uint TaskId;

        protected override bool Check()
        {
            return xc.TaskHelper.MainTaskIsPassed(TaskId);
        }
    }
}
