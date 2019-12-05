#define USE_LUA_PROFILER
#if USE_LUA_PROFILER

namespace MikuLuaProfiler
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using UnityEngine;
#if UNITY_5_6_OR_NEWER
    using UnityEngine.Profiling;
#endif

    [wxb.Hotfix]
    public static class NativeHelper
    {
#if UNITY_IPHONE
        const string NATIVE_DLL = "__Internal";
#else
        const string NATIVE_DLL = "native";//名字没定下来
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        static AndroidJavaClass m_debugClass;
        static IntPtr m_debugClassPtr;
        static IntPtr m_getPassPtr;
        static IntPtr m_getBatteryLevel;
        static jvalue[] m_jv = new jvalue[0] { };
#endif

        [Conditional("UNITY_ANDROID")]
        public static void RunAyncPass()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            object[] jv = new object[0] { };
            m_debugClassPtr = AndroidJNI.FindClass("com.miku.profiler.Profiler");
            m_getPassPtr = AndroidJNIHelper.GetMethodID<int>(m_debugClassPtr, "GetPassValue", jv, true);
            m_getBatteryLevel = AndroidJNIHelper.GetMethodID<float>(m_debugClassPtr,"GetBattleryLevel", jv, true);
            m_debugClass = new AndroidJavaClass("com.miku.profiler.Profiler");
            m_debugClass.CallStatic("run");
#endif
        }

        public static int GetPass()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            return AndroidJNI.CallStaticIntMethod(m_debugClassPtr, m_getPassPtr, m_jv) * 1024;
#else
            return 0; //(int)Profiler.GetTotalAllocatedMemoryLong();
#endif
        }

        public static float GetBatteryLevel()
        {
            float result = 100;
#if UNITY_ANDROID && !UNITY_EDITOR
            result = AndroidJNI.CallStaticFloatMethod(m_debugClassPtr, m_getBatteryLevel, m_jv);
#elif UNITY_IPHONE && !UNITY_EDITOR
            //result = GetIOSBatteryLevel();
#endif
            return result;
        }

#if UNITY_IPHONE && !UNITY_EDITOR
        //[DllImport(NATIVE_DLL)]
        //private static extern float GetIOSBatteryLevel();
#endif
    }
}
#endif