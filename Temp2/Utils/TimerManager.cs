using SGameEngine;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public class TimerManager
	{
		private static TimerManager msInstance = null;

		private List<uint> mRemoveIds = new List<uint>();

		private List<uint> mTimeupIds = new List<uint>();

		private Dictionary<uint, Timer> mTimers = new Dictionary<uint, Timer>();

		private float mLastFrameTime;

		public static TimerManager GetInstance()
		{
			bool flag = TimerManager.msInstance == null;
			if (flag)
			{
				TimerManager.msInstance = new TimerManager();
			}
			return TimerManager.msInstance;
		}

		private TimerManager()
		{
		}

		public void RegisterTimer(Timer timer)
		{
			this.mTimers.Add(timer.ID, timer);
		}

		public void Reset()
		{
			this.mTimers.Clear();
			this.mTimeupIds.Clear();
			this.mRemoveIds.Clear();
			this.mLastFrameTime = 0f;
		}

		public void Update()
		{
			float realtimeSinceStartup = Time.get_realtimeSinceStartup();
			List<uint> list = Pool<uint>.List.New();
			using (Dictionary<uint, Timer>.KeyCollection.Enumerator enumerator = this.mTimers.get_Keys().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					uint current = enumerator.get_Current();
					list.Add(current);
				}
			}
			int num2;
			for (int i = 0; i < list.get_Count(); i = num2)
			{
				uint num = list.get_Item(i);
				Timer timer = this.mTimers.get_Item(num);
				bool flag = timer.Update(realtimeSinceStartup - this.mLastFrameTime);
				if (flag)
				{
					this.mTimeupIds.Add(num);
				}
				bool isDead = timer.IsDead;
				if (isDead)
				{
					this.mRemoveIds.Add(num);
				}
				num2 = i + 1;
			}
			Pool<uint>.List.Free(list);
			bool flag2 = this.mTimeupIds.get_Count() > 0;
			if (flag2)
			{
				for (int j = 0; j < this.mTimeupIds.get_Count(); j = num2)
				{
					uint num3 = this.mTimeupIds.get_Item(j);
					bool flag3 = this.mTimers.ContainsKey(num3);
					if (flag3)
					{
						bool flag4 = this.mTimers.get_Item(num3).CallBackFunc != null;
						if (flag4)
						{
							this.mTimers.get_Item(num3).CallBackFunc(0f);
						}
						bool flag5 = this.mTimers.get_Item(num3).CallBackFuncEx != null;
						if (flag5)
						{
							this.mTimers.get_Item(num3).CallBackFuncEx(0f, this.mTimers.get_Item(num3));
						}
					}
					else
					{
						Debug.LogError("Error!!!Can not find timer by id: " + num3);
					}
					num2 = j + 1;
				}
				this.mTimeupIds.Clear();
			}
			bool flag6 = this.mRemoveIds.get_Count() > 0;
			if (flag6)
			{
				for (int k = 0; k < this.mRemoveIds.get_Count(); k = num2)
				{
					uint num4 = this.mRemoveIds.get_Item(k);
					this.mTimers.Remove(num4);
					num2 = k + 1;
				}
				this.mRemoveIds.Clear();
			}
			this.mLastFrameTime = realtimeSinceStartup;
		}
	}
}
