
namespace SafeCoroutine
{
    public class WaitForCondition : IYieldInstruction
    {
        public delegate bool ConditionFunc();
        private ConditionFunc mConditionFunc;

        public WaitForCondition(ConditionFunc conditionFunc)
        {
            mConditionFunc = conditionFunc;
        }

        public bool Update(float delta_time)
        {
            if (mConditionFunc != null)
            {
                return mConditionFunc();
            }

            return false;
        }
    }
}
