using System;

namespace Utils
{
	public class DecimalTimer
	{
		public delegate void DetalCallback(decimal remainTime);

		public delegate void DetalCallbackEx(decimal remainTime, DecimalTimer timer);

		public delegate void DetalCallbackEx2(decimal remainTime, decimal trueDeltaTime);

		private object mUserData;

		private static uint msIdCount = 0u;

		private uint mId;

		private decimal mTime;

		private decimal mLastCallbackTime;

		private decimal mTimeRemain;

		private bool mLoop;

		private bool mDead;

		private bool mPause = false;

		private decimal mDetalTime;

		private DecimalTimer.DetalCallback mDetalCallback;

		private DecimalTimer.DetalCallbackEx mDetalCallbackEx;

		private DecimalTimer.DetalCallbackEx2 mDetalCallbackEx2;

		public uint ID
		{
			get
			{
				return this.mId;
			}
		}

		public decimal Remain
		{
			get
			{
				return this.mTimeRemain;
			}
		}

		public bool IsDead
		{
			get
			{
				return this.mDead;
			}
		}

		public bool Pause
		{
			get
			{
				return this.mPause;
			}
			set
			{
				this.mPause = value;
			}
		}

		public DecimalTimer.DetalCallback CallBackFunc
		{
			get
			{
				return this.mDetalCallback;
			}
		}

		public DecimalTimer.DetalCallbackEx CallBackFuncEx
		{
			get
			{
				return this.mDetalCallbackEx;
			}
		}

		public DecimalTimer.DetalCallbackEx2 CallBackFuncEx2
		{
			get
			{
				return this.mDetalCallbackEx2;
			}
		}

		public object UserData
		{
			get
			{
				return this.mUserData;
			}
			set
			{
				this.mUserData = value;
			}
		}

		public DecimalTimer(decimal time, bool loop)
		{
			this.mDead = false;
			uint num = DecimalTimer.msIdCount;
			DecimalTimer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = default(decimal);
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = default(decimal);
			this.mDetalCallback = null;
			this.mDetalCallbackEx = null;
			DecimalTimerManager.GetInstance().RegisterTimer(this);
		}

		public DecimalTimer(decimal time, bool loop, decimal detalTime, DecimalTimer.DetalCallback callback)
		{
			this.mDead = false;
			uint num = DecimalTimer.msIdCount;
			DecimalTimer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = default(decimal);
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = detalTime;
			this.mDetalCallback = callback;
			this.mDetalCallbackEx = null;
			this.mUserData = null;
			DecimalTimerManager.GetInstance().RegisterTimer(this);
		}

		public DecimalTimer(decimal time, bool loop, decimal detalTime, DecimalTimer.DetalCallbackEx2 callback)
		{
			this.mDead = false;
			uint num = DecimalTimer.msIdCount;
			DecimalTimer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = default(decimal);
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = detalTime;
			this.mDetalCallback = null;
			this.mDetalCallbackEx = null;
			this.mDetalCallbackEx2 = callback;
			this.mUserData = null;
			DecimalTimerManager.GetInstance().RegisterTimer(this);
		}

		public DecimalTimer(decimal time, bool loop, decimal detalTime, DecimalTimer.DetalCallbackEx callback, object userData)
		{
			this.mDead = false;
			uint num = DecimalTimer.msIdCount;
			DecimalTimer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = default(decimal);
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = detalTime;
			this.mDetalCallback = null;
			this.mDetalCallbackEx = callback;
			this.mUserData = userData;
			DecimalTimerManager.GetInstance().RegisterTimer(this);
		}

		public void Reset(decimal time)
		{
			this.mPause = false;
			this.mTime = time;
			this.mLastCallbackTime = default(decimal);
			this.mTimeRemain = time;
		}

		public void Destroy()
		{
			this.mDead = true;
			this.mDetalCallback = null;
			this.mDetalCallbackEx = null;
		}

		~DecimalTimer()
		{
		}

		public bool Update(float deltaTime)
		{
			bool flag = this.mPause || this.mDead;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.mTimeRemain -= (decimal)deltaTime * 1000m;
				bool flag2 = this.mTimeRemain < decimal.Zero;
				if (flag2)
				{
					this.mTimeRemain = default(decimal);
				}
				bool flag3 = Math.Abs(this.mTimeRemain - this.mLastCallbackTime) > this.mDetalTime;
				if (flag3)
				{
					bool flag4 = this.mDetalCallback != null;
					if (flag4)
					{
						this.mDetalCallback(this.mTimeRemain);
					}
					bool flag5 = this.mDetalCallbackEx != null;
					if (flag5)
					{
						this.mDetalCallbackEx(this.mTimeRemain, this);
					}
					bool flag6 = this.mDetalCallbackEx2 != null;
					if (flag6)
					{
						decimal trueDeltaTime = this.mLastCallbackTime - this.mTimeRemain;
						bool flag7 = this.mLastCallbackTime == decimal.Zero;
						if (flag7)
						{
							trueDeltaTime = this.mTime - this.mTimeRemain;
						}
						this.mDetalCallbackEx2(this.mTimeRemain, trueDeltaTime);
					}
					this.mLastCallbackTime = this.mTimeRemain;
				}
				bool flag8 = this.mTimeRemain <= decimal.Zero;
				if (flag8)
				{
					bool flag9 = !this.mLoop;
					if (flag9)
					{
						this.mDead = true;
						this.mTimeRemain = default(decimal);
						this.mLastCallbackTime = default(decimal);
					}
					else
					{
						this.mTimeRemain = Math.Max(decimal.Zero, this.mTime + this.mTimeRemain);
						this.mLastCallbackTime = this.mTime;
					}
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public static string GetFMTTime2(decimal fTime)
		{
			decimal num = fTime / 1000m;
			int num2 = (int)(num % 60m);
			int num3 = (int)(num % 3600m / 60m);
			int num4 = (int)(num / 3600m);
			bool flag = num2 >= 10;
			string text;
			if (flag)
			{
				text = num2.ToString();
			}
			else
			{
				text = "0" + num2.ToString();
			}
			bool flag2 = num3 >= 10;
			string text2;
			if (flag2)
			{
				text2 = num3.ToString();
			}
			else
			{
				text2 = "0" + num3.ToString();
			}
			bool flag3 = num4 >= 10;
			string text3;
			if (flag3)
			{
				text3 = num4.ToString();
			}
			else
			{
				text3 = "0" + num4.ToString();
			}
			bool flag4 = num4 > 0;
			string result;
			if (flag4)
			{
				result = string.Format("{0}:{1}:{2}", text3, text2, text);
			}
			else
			{
				result = string.Format("{0}:{1}", text2, text);
			}
			return result;
		}

		public static string GetFMTTime(decimal fTime)
		{
			decimal num = fTime / 1000m;
			int num2 = (int)(num % 60m);
			int num3 = (int)(num % 3600m / 60m);
			int num4 = (int)(num / 3600m);
			bool flag = num2 >= 10;
			string text;
			if (flag)
			{
				text = num2.ToString();
			}
			else
			{
				text = "0" + num2.ToString();
			}
			bool flag2 = num3 >= 10;
			string text2;
			if (flag2)
			{
				text2 = num3.ToString();
			}
			else
			{
				text2 = "0" + num3.ToString();
			}
			bool flag3 = num4 >= 10;
			string text3;
			if (flag3)
			{
				text3 = num4.ToString();
			}
			else
			{
				text3 = "0" + num4.ToString();
			}
			bool flag4 = num4 > 0;
			string result;
			if (flag4)
			{
				result = string.Format("{0}小时{1}分{2}秒", text3, text2, text);
			}
			else
			{
				result = string.Format("{0}分{1}秒", text2, text);
			}
			return result;
		}

		public string GetFMTRemainTime()
		{
			return DecimalTimer.GetFMTTime(this.mTimeRemain);
		}

		public string GetFMTRemainTime2()
		{
			return DecimalTimer.GetFMTTime2(this.mTimeRemain);
		}
	}
}
