using UnityEngine;
using System.Collections.Generic;
using SGameEngine;

namespace Utils
{
	public class Timer
	{
		public uint ID
		{ get { return mId; } }
		
		public float Remain
		{ get { return mTimeRemain; } }
		
		public bool IsDead
		{ get { return mDead; } }
		
		public bool Pause {
			get { return mPause; }
			set { mPause = value; }
		}
		
		public DetalCallback CallBackFunc
		{
			get { return mDetalCallback; }
		}
		
		public DetalCallbackEx CallBackFuncEx
		{
			get { return mDetalCallbackEx; }
		}

        public DetalCallbackEx2 CallBackFuncEx2
        {
            get
            {
                return mDetalCallbackEx2;
            }
        }
		
		public System.Object UserData
		{
			get { return mUserData; }
			set { mUserData = value; }
		}
		System.Object mUserData;
		
		static uint msIdCount = 0;
		uint mId;
        float mTime;
		float mLastCallbackTime;
		float mTimeRemain;
		bool mLoop;
		bool mDead;
		bool mPause = false;
		float mDetalTime;
		DetalCallback mDetalCallback;
		DetalCallbackEx mDetalCallbackEx;
        DetalCallbackEx2 mDetalCallbackEx2;
		
		public delegate void DetalCallback(float remainTime);
		public delegate void DetalCallbackEx(float remainTime, Timer timer);
        public delegate void DetalCallbackEx2(float remainTime, float trueDeltaTime);
			
		public Timer (float time, bool loop)
		{
			mDead = false;
			mId = msIdCount++;
			mTime = time;
			mLastCallbackTime = 0;
			mTimeRemain = time;
			mLoop = loop;
			mDetalTime = 0;
			mDetalCallback = null;
			mDetalCallbackEx = null;
			
			TimerManager.GetInstance ().RegisterTimer (this);
		}
		
		public Timer (float time, bool loop, float detalTime, DetalCallback callback)
		{
			mDead = false;
			mId = msIdCount++;
			mTime = time;
			mLastCallbackTime = 0;
			mTimeRemain = time;
			mLoop = loop;
			mDetalTime = detalTime;
			mDetalCallback = callback;
			mDetalCallbackEx = null;
			mUserData = null;
			
			TimerManager.GetInstance ().RegisterTimer (this);
		}

        public Timer(float time, bool loop, float detalTime, DetalCallbackEx2 callback)
        {
            mDead = false;
            mId = msIdCount++;
            mTime = time;
            mLastCallbackTime = 0;
            mTimeRemain = time;
            mLoop = loop;
            mDetalTime = detalTime;
            mDetalCallback = null;
            mDetalCallbackEx = null;
            mDetalCallbackEx2 = callback;
            mUserData = null;

            TimerManager.GetInstance().RegisterTimer(this);
        }
		
		public Timer (float time, bool loop, float detalTime, DetalCallbackEx callback, System.Object userData)
		{
			mDead = false;
			mId = msIdCount++;
			mTime = time;
			mLastCallbackTime = 0;
			mTimeRemain = time;
			mLoop = loop;
			mDetalTime = detalTime;
			mDetalCallback = null;
			mDetalCallbackEx = callback;
			mUserData = userData;
			
			TimerManager.GetInstance ().RegisterTimer (this);
		}
		
		public void Reset (float time)
		{
			mPause = false;
			mTime = time;
			mLastCallbackTime = 0;
			mTimeRemain = time;
		}
		
		public void Destroy ()
		{
			mDead = true;	
			mDetalCallback = null;
			mDetalCallbackEx = null;
		}
		
		~Timer ()
		{
			//Debug.Log ("Timer destroyed. id:" + mId);
		}
		
        public bool Update (float deltaTime)
		{
			if (mPause || mDead)
				return false;

			// 计算剩余时间
            mTimeRemain = mTimeRemain - deltaTime*1000.0f;
            if (mTimeRemain < 0f)
                mTimeRemain = 0f;

			if(Mathf.Abs(mTimeRemain - mLastCallbackTime) > mDetalTime)
			{				
				if(mDetalCallback!=null)
					mDetalCallback(mTimeRemain);
				if (mDetalCallbackEx != null)
					mDetalCallbackEx(mTimeRemain, this);

                if(mDetalCallbackEx2 != null)
                {
                    float trueDeltaTime = mLastCallbackTime - mTimeRemain;

                    if(mLastCallbackTime == 0.0f)
                    {
                        trueDeltaTime = mTime - mTimeRemain;
                    }

                    mDetalCallbackEx2(mTimeRemain, trueDeltaTime);
                }

                mLastCallbackTime = mTimeRemain;
			}
			
			if (mTimeRemain <= 0) {
				if (!mLoop) {
					mDead = true;
					mTimeRemain = 0;
					mLastCallbackTime = 0;
				} else {
					mTimeRemain = Mathf.Max(0, mTime + mTimeRemain);
					mLastCallbackTime = mTime;
				}
				
				return true;
			}
			
			return false;
		}
		
		public static string GetFMTTime2(float fTime)
		{
			int mTimeRemainSec = (int)(fTime/1000.0f);
			int sec = mTimeRemainSec % 60;
			int min = (mTimeRemainSec % 3600) / 60;
			int hour = mTimeRemainSec / 3600;
			
			string sec_str;
			if (sec >= 10)
				sec_str = sec.ToString ();
			else
				sec_str = "0" + sec.ToString ();
			
			string min_str;
			if (min >= 10)
				min_str = min.ToString ();
			else
				min_str = "0" + min.ToString ();
			
			string hour_str;
			if (hour >= 10)
				hour_str = hour.ToString ();
			else
				hour_str = "0" + hour.ToString ();
				
			if (hour > 0)
				return string.Format ("{0}:{1}:{2}", hour_str, min_str, sec_str);
			else
				return string.Format ("{0}:{1}", min_str, sec_str);
		}
		
		public static string GetFMTTime(float fTime)
		{
			int mTimeRemainSec = (int)(fTime/1000.0f);
			int sec = mTimeRemainSec % 60;
			int min = (mTimeRemainSec % 3600) / 60;
			int hour = mTimeRemainSec / 3600;
			
			string sec_str;
			if (sec >= 10)
				sec_str = sec.ToString ();
			else
				sec_str = "0" + sec.ToString ();
			
			string min_str;
			if (min >= 10)
				min_str = min.ToString ();
			else
				min_str = "0" + min.ToString ();
			
			string hour_str;
			if (hour >= 10)
				hour_str = hour.ToString ();
			else
				hour_str = "0" + hour.ToString ();
				
			if (hour > 0)
				return string.Format ("{0}时{1}分{2}秒", hour_str, min_str, sec_str);
			else
				return string.Format ("{0}分{1}秒", min_str, sec_str);
		}
		
		public string GetFMTRemainTime ()
		{
			return GetFMTTime(mTimeRemain);
		}
		
		public string GetFMTRemainTime2 ()
		{
			return GetFMTTime2(mTimeRemain);
		}
	}
	
	public class SingleTimer
	{
		float mfRemainTime;
		public float RemainTime
		{
			get
			{
				return mfRemainTime;
			}
		}
		
		bool mbIsDead = true;
		public bool IsDead
		{
			get
			{
				return mbIsDead;
			}
		}
		
		public delegate void Callback(SingleTimer kArgs);
		Callback mkTimerCallback = null;
		System.Object mkArgs;
		
		public SingleTimer(Callback kTimerCallback, System.Object kArgs)
		{
			mkTimerCallback = kTimerCallback;
			mkArgs = kArgs;
		}
		
		public virtual void Reset(float fTimeInSceond)
		{
			mfRemainTime = fTimeInSceond;			
			mbIsDead = false;
		}		
		
		public void Update(float fDeltaTime)
		{
			if (mbIsDead)
				return;			
			
			DoUpdate(fDeltaTime);
		}
		
		public void Kill()
		{
			mbIsDead = true;
			mfRemainTime = 0.0f;
		}
		
		public void KillForNotify()
		{
			Kill();
			if (mkTimerCallback != null)
				mkTimerCallback(this);
		}
		
		protected virtual void DoUpdate(float fDeltaTime)
		{
			if (mfRemainTime <= 0.0f)
			{
				KillForNotify();
			}
			else
			{
				mfRemainTime -= fDeltaTime;
			}
		}
	}
	
	public class CycleCallBackTimer : SingleTimer
	{
		public float mfCycle = 0.01f;
		Callback mkCycleTimerCallback = null;
		System.Object mkCycleArgs;
		float mfLastRemainTime = 0.0f;
		
		public CycleCallBackTimer(Callback kTimerCallback, System.Object kArgs,
			Callback kCycleTimerCallback, System.Object kCycleArgs) : base(kTimerCallback, kArgs)
		{
			mkCycleTimerCallback = kCycleTimerCallback;
			mkCycleArgs = kCycleArgs;
		}
		
		public override void Reset (float fTimeInSceond)
		{
			base.Reset (fTimeInSceond);
			mfLastRemainTime = fTimeInSceond;
		}
		
		protected override void DoUpdate (float fDeltaTime)
		{
			if (mfLastRemainTime - RemainTime >= mfCycle)
			{
				mfLastRemainTime = RemainTime;
				if (mkCycleTimerCallback != null)
					mkCycleTimerCallback(this);
			}
			
			base.DoUpdate (fDeltaTime);
		}
	}
	
	public class TimerManager
	{
		static public TimerManager GetInstance ()
		{
			if (msInstance == null)
				msInstance = new TimerManager ();
			return msInstance;
		}

		static TimerManager msInstance = null;
		List<uint> mRemoveIds = new List<uint> ();
		List<uint> mTimeupIds = new List<uint> ();
		Dictionary<uint, Timer> mTimers = new Dictionary<uint, Timer> ();
        float mLastFrameTime;
		
		TimerManager ()
		{
		}
		
		public void RegisterTimer (Timer timer)
		{
			mTimers.Add (timer.ID, timer);
		}
		
		public void Reset()
		{
			mTimers.Clear();
			mTimeupIds.Clear();
			mRemoveIds.Clear();
            mLastFrameTime = 0f;
		}
		
		public void Update ()
		{
            float curTime = Time.realtimeSinceStartup;

            // 在Timeer的Update函数中，调用Timer注册的回调函数，如果在函数中创建新的Timer，则迭代器会报错

            var keyList = Pool<uint>.List.New();

            foreach (var key in mTimers.Keys)
            {
                keyList.Add(key);
            }

			//var keyList = new List<uint>(mTimers.Keys);

			for(int i = 0; i< keyList.Count; ++i)
			{
				uint timeId = keyList[i];
				Timer kTime = mTimers[timeId];

				if (kTime.Update (curTime - mLastFrameTime))
					mTimeupIds.Add (timeId);
				
				if (kTime.IsDead)
					mRemoveIds.Add (timeId);
			}

            Pool<uint>.List.Free(keyList);

            // 时间已结束的Timer
            if (mTimeupIds.Count > 0)
			{
				for (int i = 0; i < mTimeupIds.Count; ++i) 
				{
					uint id = mTimeupIds[i];
                    if (mTimers.ContainsKey(id) == true)
                    {
                        // 时间结束的回调
                        if (mTimers[id].CallBackFunc != null)
                            mTimers[id].CallBackFunc(0);
                        if (mTimers[id].CallBackFuncEx != null)
                            mTimers[id].CallBackFuncEx(0, mTimers[id]);
                    }
                    else
                    {
                        Debug.LogError("Error!!!Can not find timer by id: " + id);
                    }
                }
				
				mTimeupIds.Clear ();
			}

			// 移除被销毁的Timer
			if (mRemoveIds.Count > 0) 
			{
				for (int i = 0; i < mRemoveIds.Count; ++i) 
				{
					uint id = mRemoveIds[i];
					mTimers.Remove (id);
				}
				
				mRemoveIds.Clear ();
			}

            mLastFrameTime = curTime;
		}
	}
}

