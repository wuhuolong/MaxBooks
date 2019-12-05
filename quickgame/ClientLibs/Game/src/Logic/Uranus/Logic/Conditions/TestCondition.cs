using System;

namespace Uranus.Runtime
{
    /// <summary>
    /// 测试Condition
    /// </summary>
    [Serializable]
    public class TestCondition : ICondition
    {
        public uint HP;

        public bool IsNew;

        protected override bool Check()
        {
            if (HP > 0)
            {
                HP--;
            }
            else
            {
                HP = 60;
            }
            return HP > 30;
        }
    }
}
