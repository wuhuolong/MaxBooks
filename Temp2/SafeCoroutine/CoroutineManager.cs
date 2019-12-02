using System;
using System.Collections;
using System.Collections.Generic;

namespace SafeCoroutine
{
	public class CoroutineManager
	{
		private static List<Coroutine> mCoroutines = new List<Coroutine>();

		private static List<Coroutine> mSalvageCoroutines = new List<Coroutine>();

		private static bool mIsUpdating = false;

		public static void Update(float delta_time)
		{
			WaitForHeavyCall.ResetHeavyCall();
			CoroutineManager.mIsUpdating = true;
			int num;
			for (int i = CoroutineManager.mCoroutines.get_Count() - 1; i >= 0; i = num)
			{
				bool flag = CoroutineManager.mCoroutines.get_Item(i).Update(delta_time);
				if (flag)
				{
					CoroutineManager.mCoroutines.RemoveAt(i);
				}
				num = i - 1;
			}
			CoroutineManager.mIsUpdating = false;
			bool flag2 = CoroutineManager.mSalvageCoroutines.get_Count() > 0;
			if (flag2)
			{
				CoroutineManager.mCoroutines.AddRange(CoroutineManager.mSalvageCoroutines);
				CoroutineManager.mSalvageCoroutines.Clear();
			}
		}

		public static Coroutine StartCoroutine(IEnumerator iterator)
		{
			bool flag = iterator == null;
			Coroutine result;
			if (flag)
			{
				result = null;
			}
			else
			{
				Coroutine coroutine = new Coroutine(iterator);
				bool flag2 = CoroutineManager.mIsUpdating;
				if (flag2)
				{
					CoroutineManager.mSalvageCoroutines.Add(coroutine);
				}
				else
				{
					CoroutineManager.mCoroutines.Add(coroutine);
				}
				result = coroutine;
			}
			return result;
		}
	}
}
