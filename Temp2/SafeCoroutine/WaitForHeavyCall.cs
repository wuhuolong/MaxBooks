using System;

namespace SafeCoroutine
{
	public class WaitForHeavyCall : IYieldInstruction
	{
		private static bool mIsHeavyCallThisFrame = false;

		public static WaitForHeavyCall Default = new WaitForHeavyCall();

		public static void HeavyCall()
		{
			WaitForHeavyCall.mIsHeavyCallThisFrame = true;
		}

		public static void ResetHeavyCall()
		{
			WaitForHeavyCall.mIsHeavyCallThisFrame = false;
		}

		public bool Update(float delta_time)
		{
			bool flag = !WaitForHeavyCall.mIsHeavyCallThisFrame;
			bool result;
			if (flag)
			{
				WaitForHeavyCall.HeavyCall();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
