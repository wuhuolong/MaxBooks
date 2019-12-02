using System;

namespace SafeCoroutine
{
	public class SafeWaitForSeconds : IYieldInstruction
	{
		private float mTimeDelay;

		public SafeWaitForSeconds(float delay)
		{
			this.mTimeDelay = delay;
		}

		public bool Update(float delta_time)
		{
			bool flag = this.mTimeDelay < 0f;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.mTimeDelay -= delta_time;
				result = false;
			}
			return result;
		}
	}
}
