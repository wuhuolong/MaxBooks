using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 是否有指定id的指定状态的任务
    /// </summary>
    [Serializable]
    public class TaskIsInStateCondition : ICondition
    {
        public uint TaskId;

        public uint State;

        protected override bool Check()
        {
            xc.Task task = xc.TaskManager.Instance.GetTask(TaskId);
            if (task != null && task.State == State)
            {
                return true;
            }
            return false;
        }
    }
}
