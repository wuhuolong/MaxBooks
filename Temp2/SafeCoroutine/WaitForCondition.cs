using System;

namespace SafeCoroutine
{
	public class WaitForCondition : IYieldInstruction
	{
		public delegate bool ConditionFunc();

		private WaitForCondition.ConditionFunc mConditionFunc;

		public WaitForCondition(WaitForCondition.ConditionFunc conditionFunc)
		{
			this.mConditionFunc = conditionFunc;
		}

		public bool Update(float delta_time)
		{
			bool flag = this.mConditionFunc != null;
			return flag && this.mConditionFunc();
		}
	}
}
