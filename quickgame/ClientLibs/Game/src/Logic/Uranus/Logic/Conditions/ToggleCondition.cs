using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// Toggle Condition
    /// </summary>
    [Serializable]
    public class ToggleCondition : ICondition
    {
        public bool Toggle;

        public string Name;

        protected override bool Check()
        {
            return Toggle;
        }
    }
}
