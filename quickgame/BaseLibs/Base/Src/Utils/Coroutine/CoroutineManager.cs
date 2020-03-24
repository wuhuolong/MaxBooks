using System.Collections;
using System.Collections.Generic;

namespace SafeCoroutine
{
	/// <summary>
	/// Coroutine manager.
	/// </summary>
    public class CoroutineManager
    {
		/// <summary>
		/// 协程列表
		/// </summary>
        private static List<Coroutine> mCoroutines = new List<Coroutine>();
        
		/// <summary>
		/// 协程更新时新加的协程
		/// </summary>
		private static List<Coroutine> mSalvageCoroutines = new List<Coroutine>();

		/// <summary>
		/// 当前是否在更新协程中
		/// </summary>
        private static bool mIsUpdating = false;

		/// <summary>
		/// 更新所有的协程
		/// </summary>
		/// <param name="delta_time">Delta time</param>
        public static void Update(float delta_time)
        {
            WaitForHeavyCall.ResetHeavyCall();

            mIsUpdating = true;
            for (int i = mCoroutines.Count - 1; i >= 0; --i)
            {
                if (mCoroutines[i].Update(delta_time))
                    mCoroutines.RemoveAt(i);
            }
            mIsUpdating = false;

			// 更新完后把新加的协程加进协程列表，下一次才更新（为了防止死循环）
            if (mSalvageCoroutines.Count > 0)
            {
                mCoroutines.AddRange(mSalvageCoroutines);
                mSalvageCoroutines.Clear();
            }
        }

		/// <summary>
		/// 开启一个协程
		/// </summary>
		/// <returns></returns>
		/// <param name="iterator">Iterator.</param>
        public static Coroutine StartCoroutine(IEnumerator iterator)
        {
            if (iterator == null)
                return null;

            var c = new Coroutine(iterator);

            if (mIsUpdating)
				// 更新过程中，把协程放入新加协程列表，防止更新循环错误
                mSalvageCoroutines.Add(c);
            else
                mCoroutines.Add(c);

            return c;
        }
    }
}
