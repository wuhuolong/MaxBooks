using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace xc
{
    public class DebugProfile
    {
        static long s1;
        static System.Diagnostics.Stopwatch mTimeStopWatch;

        public static void BeginMono()
        {
            s1 = Profiler.GetMonoUsedSizeLong();
        }

        public static long EndMono()
        {
            long s2 = Profiler.GetMonoUsedSizeLong();
            long detla = s2 - s1;

            return detla;
        }

        public static void BeginTime()
        {
            if (mTimeStopWatch == null)
                mTimeStopWatch = new System.Diagnostics.Stopwatch();
            else
                mTimeStopWatch.Reset();

            mTimeStopWatch.Start();

        }

        public static long EndTime()
        {
            if (mTimeStopWatch == null)
                return 0;
            mTimeStopWatch.Stop();
            return mTimeStopWatch.ElapsedMilliseconds;
        }
    }
}
