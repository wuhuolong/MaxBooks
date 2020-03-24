using UnityEngine;
using System.Collections.Generic;
using SGameEngine;

namespace Utils
{
	public class DecimalTimer
    {
		public uint ID
		{ get { return mId; } }
		
		public decimal Remain
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
        decimal mTime;
        decimal mLastCallbackTime;
        decimal mTimeRemain;
		bool mLoop;
		bool mDead;
		bool mPause = false;
        decimal mDetalTime;
		DetalCallback mDetalCallback;
		DetalCallbackEx mDetalCallbackEx;
        DetalCallbackEx2 mDetalCallbackEx2;
		
		public delegate void DetalCallback(decimal remainTime);
		public delegate void DetalCallbackEx(decimal remainTime, DecimalTimer timer);
        public delegate void DetalCallbackEx2(decimal remainTime, decimal trueDeltaTime);
			
		public DecimalTimer(decimal time, bool loop)
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

            DecimalTimerManager.GetInstance ().RegisterTimer (this);
		}
		
		public DecimalTimer(decimal time, bool loop, decimal detalTime, DetalCallback callback)
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

            DecimalTimerManager.GetInstance ().RegisterTimer (this);
		}

        public DecimalTimer(decimal time, bool loop, decimal detalTime, DetalCallbackEx2 callback)
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

            DecimalTimerManager.GetInstance().RegisterTimer(this);
        }
		
		public DecimalTimer(decimal time, bool loop, decimal detalTime, DetalCallbackEx callback, System.Object userData)
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

            DecimalTimerManager.GetInstance ().RegisterTimer (this);
		}
		
		public void Reset (decimal time)
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
		
		~DecimalTimer()
		{
			//Debug.Log ("Timer destroyed. id:" + mId);
		}
		
        public bool Update (float deltaTime)
		{
			if (mPause || mDead)
				return false;

			// 计算剩余时间
            mTimeRemain = mTimeRemain - (decimal)deltaTime*1000;
            if (mTimeRemain < 0)
                mTimeRemain = 0;

			if(System.Math.Abs(mTimeRemain - mLastCallbackTime) > mDetalTime)
			{				
				if(mDetalCallback!=null)
					mDetalCallback(mTimeRemain);
				if (mDetalCallbackEx != null)
					mDetalCallbackEx(mTimeRemain, this);

                if(mDetalCallbackEx2 != null)
                {
                    decimal trueDeltaTime = mLastCallbackTime - mTimeRemain;

                    if(mLastCallbackTime == 0)
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
					mTimeRemain = System.Math.Max(0, mTime + mTimeRemain);
					mLastCallbackTime = mTime;
				}
				
				return true;
			}
			
			return false;
		}
		
		public static string GetFMTTime2(decimal fTime)
		{
            decimal mTimeRemainSec = fTime/1000;
			int sec = (int)(mTimeRemainSec % 60);
			int min = (int)((mTimeRemainSec % 3600) / 60);
			int hour = (int)(mTimeRemainSec / 3600);
			
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
		
		public static string GetFMTTime(decimal fTime)
		{
			decimal mTimeRemainSec = fTime/1000;
			int sec = (int)(mTimeRemainSec % 60);
			int min = (int)((mTimeRemainSec % 3600) / 60);
			int hour = (int)(mTimeRemainSec / 3600);
			
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
				return string.Format ("{0}小时{1}分{2}秒", hour_str, min_str, sec_str);
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
	
	public class DecimalTimerManager
    {
		static public DecimalTimerManager GetInstance ()
		{
			if (msInstance == null)
				msInstance = new DecimalTimerManager();
			return msInstance;
		}

		static DecimalTimerManager msInstance = null;
		List<uint> mRemoveIds = new List<uint> ();
		List<uint> mTimeupIds = new List<uint> ();
		Dictionary<uint, DecimalTimer> mTimers = new Dictionary<uint, DecimalTimer> ();
        float mLastFrameTime;

        DecimalTimerManager()
		{
		}
		
		public void RegisterTimer (DecimalTimer timer)
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
                DecimalTimer kTime = mTimers[timeId];

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

