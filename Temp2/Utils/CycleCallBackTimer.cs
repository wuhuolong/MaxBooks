using System;

namespace Utils
{
	public class CycleCallBackTimer : SingleTimer
	{
		public float mfCycle = 0.01f;

		private SingleTimer.Callback mkCycleTimerCallback = null;

		private object mkCycleArgs;

		private float mfLastRemainTime = 0f;

		public CycleCallBackTimer(SingleTimer.Callback kTimerCallback, object kArgs, SingleTimer.Callback kCycleTimerCallback, object kCycleArgs) : base(kTimerCallback, kArgs)
		{
			this.mkCycleTimerCallback = kCycleTimerCallback;
			this.mkCycleArgs = kCycleArgs;
		}

		public override void Reset(float fTimeInSceond)
		{
			base.Reset(fTimeInSceond);
			this.mfLastRemainTime = fTimeInSceond;
		}

		protected override void DoUpdate(float fDeltaTime)
		{
			bool flag = this.mfLastRemainTime - base.RemainTime >= this.mfCycle;
			if (flag)
			{
				this.mfLastRemainTime = base.RemainTime;
				bool flag2 = this.mkCycleTimerCallback != null;
				if (flag2)
				{
					this.mkCycleTimerCallback(this);
				}
			}
			base.DoUpdate(fDeltaTime);
		}
	}
}
