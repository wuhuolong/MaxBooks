using System;
using UnityEngine;

namespace Utils
{
	public class Timer
	{
		public delegate void DetalCallback(float remainTime);

		public delegate void DetalCallbackEx(float remainTime, Timer timer);

		public delegate void DetalCallbackEx2(float remainTime, float trueDeltaTime);

		private object mUserData;

		private static uint msIdCount = 0u;

		private uint mId;

		private float mTime;

		private float mLastCallbackTime;

		private float mTimeRemain;

		private bool mLoop;

		private bool mDead;

		private bool mPause = false;

		private float mDetalTime;

		private Timer.DetalCallback mDetalCallback;

		private Timer.DetalCallbackEx mDetalCallbackEx;

		private Timer.DetalCallbackEx2 mDetalCallbackEx2;

		public uint ID
		{
			get
			{
				return this.mId;
			}
		}

		public float Remain
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

		public Timer.DetalCallback CallBackFunc
		{
			get
			{
				return this.mDetalCallback;
			}
		}

		public Timer.DetalCallbackEx CallBackFuncEx
		{
			get
			{
				return this.mDetalCallbackEx;
			}
		}

		public Timer.DetalCallbackEx2 CallBackFuncEx2
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

		public Timer(float time, bool loop)
		{
			this.mDead = false;
			uint num = Timer.msIdCount;
			Timer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = 0f;
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = 0f;
			this.mDetalCallback = null;
			this.mDetalCallbackEx = null;
			TimerManager.GetInstance().RegisterTimer(this);
		}

		public Timer(float time, bool loop, float detalTime, Timer.DetalCallback callback)
		{
			this.mDead = false;
			uint num = Timer.msIdCount;
			Timer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = 0f;
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = detalTime;
			this.mDetalCallback = callback;
			this.mDetalCallbackEx = null;
			this.mUserData = null;
			TimerManager.GetInstance().RegisterTimer(this);
		}

		public Timer(float time, bool loop, float detalTime, Timer.DetalCallbackEx2 callback)
		{
			this.mDead = false;
			uint num = Timer.msIdCount;
			Timer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = 0f;
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = detalTime;
			this.mDetalCallback = null;
			this.mDetalCallbackEx = null;
			this.mDetalCallbackEx2 = callback;
			this.mUserData = null;
			TimerManager.GetInstance().RegisterTimer(this);
		}

		public Timer(float time, bool loop, float detalTime, Timer.DetalCallbackEx callback, object userData)
		{
			this.mDead = false;
			uint num = Timer.msIdCount;
			Timer.msIdCount = num + 1u;
			this.mId = num;
			this.mTime = time;
			this.mLastCallbackTime = 0f;
			this.mTimeRemain = time;
			this.mLoop = loop;
			this.mDetalTime = detalTime;
			this.mDetalCallback = null;
			this.mDetalCallbackEx = callback;
			this.mUserData = userData;
			TimerManager.GetInstance().RegisterTimer(this);
		}

		public void Reset(float time)
		{
			this.mPause = false;
			this.mTime = time;
			this.mLastCallbackTime = 0f;
			this.mTimeRemain = time;
		}

		public void Destroy()
		{
			this.mDead = true;
			this.mDetalCallback = null;
			this.mDetalCallbackEx = null;
		}

		~Timer()
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
				this.mTimeRemain -= deltaTime * 1000f;
				bool flag2 = this.mTimeRemain < 0f;
				if (flag2)
				{
					this.mTimeRemain = 0f;
				}
				bool flag3 = Mathf.Abs(this.mTimeRemain - this.mLastCallbackTime) > this.mDetalTime;
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
						float trueDeltaTime = this.mLastCallbackTime - this.mTimeRemain;
						bool flag7 = this.mLastCallbackTime == 0f;
						if (flag7)
						{
							trueDeltaTime = this.mTime - this.mTimeRemain;
						}
						this.mDetalCallbackEx2(this.mTimeRemain, trueDeltaTime);
					}
					this.mLastCallbackTime = this.mTimeRemain;
				}
				bool flag8 = this.mTimeRemain <= 0f;
				if (flag8)
				{
					bool flag9 = !this.mLoop;
					if (flag9)
					{
						this.mDead = true;
						this.mTimeRemain = 0f;
						this.mLastCallbackTime = 0f;
					}
					else
					{
						this.mTimeRemain = Mathf.Max(0f, this.mTime + this.mTimeRemain);
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

		public static string GetFMTTime2(float fTime)
		{
			int num = (int)(fTime / 1000f);
			int num2 = num % 60;
			int num3 = num % 3600 / 60;
			int num4 = num / 3600;
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

		public static string GetFMTTime(float fTime)
		{
			int num = (int)(fTime / 1000f);
			int num2 = num % 60;
			int num3 = num % 3600 / 60;
			int num4 = num / 3600;
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
				result = string.Format("{0}时{1}分{2}秒", text3, text2, text);
			}
			else
			{
				result = string.Format("{0}分{1}秒", text2, text);
			}
			return result;
		}

		public string GetFMTRemainTime()
		{
			return Timer.GetFMTTime(this.mTimeRemain);
		}

		public string GetFMTRemainTime2()
		{
			return Timer.GetFMTTime2(this.mTimeRemain);
		}
	}
}
