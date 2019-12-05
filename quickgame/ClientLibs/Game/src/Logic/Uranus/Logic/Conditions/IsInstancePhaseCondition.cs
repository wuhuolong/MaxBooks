using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 在指定的副本阶段内
    /// </summary>
    [Serializable]
    public class IsInstancePhaseCondition : ICondition
    {
        public uint Phase;

        protected override bool Check()
        {
            return xc.InstanceManager.Instance.InstancePhase == Phase;
        }
    }
}
