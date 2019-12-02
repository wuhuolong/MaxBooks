using System;

namespace Utils
{
	public class SingleTimer
	{
		public delegate void Callback(SingleTimer kArgs);

		private float mfRemainTime;

		private bool mbIsDead = true;

		private SingleTimer.Callback mkTimerCallback = null;

		private object mkArgs;

		public float RemainTime
		{
			get
			{
				return this.mfRemainTime;
			}
		}

		public bool IsDead
		{
			get
			{
				return this.mbIsDead;
			}
		}

		public SingleTimer(SingleTimer.Callback kTimerCallback, object kArgs)
		{
			this.mkTimerCallback = kTimerCallback;
			this.mkArgs = kArgs;
		}

		public virtual void Reset(float fTimeInSceond)
		{
			this.mfRemainTime = fTimeInSceond;
			this.mbIsDead = false;
		}

		public void Update(float fDeltaTime)
		{
			bool flag = this.mbIsDead;
			if (!flag)
			{
				this.DoUpdate(fDeltaTime);
			}
		}

		public void Kill()
		{
			this.mbIsDead = true;
			this.mfRemainTime = 0f;
		}

		public void KillForNotify()
		{
			this.Kill();
			bool flag = this.mkTimerCallback != null;
			if (flag)
			{
				this.mkTimerCallback(this);
			}
		}

		protected virtual void DoUpdate(float fDeltaTime)
		{
			bool flag = this.mfRemainTime <= 0f;
			if (flag)
			{
				this.KillForNotify();
			}
			else
			{
				this.mfRemainTime -= fDeltaTime;
			}
		}
	}
}
