

using System.Diagnostics;
using System.Reflection;

public static class DebugerExtension
{

    public static void LogLoop(this object obj, string message = "")
    {
        if (!Debuger.EnableLogLoop)
        {
            return;
        }

        Debuger.LogLoop(GetLogTag(obj), GetLogCallerMethod(), (string)message);
    }

    public static void LogLoop(this object obj, string format, params object[] args)
    {
        if (!Debuger.EnableLogLoop)
        {
            return;
        }

        Debuger.LogLoop(GetLogTag(obj), GetLogCallerMethod(), string.Format(format, args));
    }


    //----------------------------------------------------------------------

    public static void Log(this object obj, string message = "")
    {
        if (!Debuger.EnableLog)
        {
            return;
        }

        Debuger.Log(GetLogTag(obj), GetLogCallerMethod(), (string)message);
    }

    public static void Log(this object obj, string format, params object[] args)
    {
        if (!Debuger.EnableLog)
        {
            return;
        }

        Debuger.Log(GetLogTag(obj), GetLogCallerMethod(), string.Format(format, args));
    }


    //----------------------------------------------------------------------


    public static void LogError(this object obj, string message)
    {
        Debuger.LogError(GetLogTag(obj), GetLogCallerMethod(), (string)message);
    }

    public static void LogError(this object obj, string format, params object[] args)
    {
        Debuger.LogError(GetLogTag(obj), GetLogCallerMethod(), string.Format(format, args));
    }



    //----------------------------------------------------------------------

    public static void LogWarning(this object obj, string message)
    {
        Debuger.LogWarning(GetLogTag(obj), GetLogCallerMethod(), (string)message);
    }


    public static void LogWarning(this object obj, string format, params object[] args)
    {
        Debuger.LogWarning(GetLogTag(obj), GetLogCallerMethod(), string.Format(format, args));
    }

    //----------------------------------------------------------------------



    //----------------------------------------------------------------------
    private static string GetLogTag(object obj)
    {
        FieldInfo fi = obj.GetType().GetField("LOG_TAG");
        if (fi != null)
        {
            return (string)fi.GetValue(obj);
        }

        return obj.GetType().Name;
    }

    private static Assembly ms_Assembly;
    private static string GetLogCallerMethod()
    {
        StackTrace st = new StackTrace(2, false);
        if (st != null)
        {
            if (null == ms_Assembly)
            {
                ms_Assembly = typeof(Debuger).Assembly;
            }

            int currStackFrameIndex = 0;
            while (currStackFrameIndex < st.FrameCount)
            {
                StackFrame oneSf = st.GetFrame(currStackFrameIndex);
                MethodBase oneMethod = oneSf.GetMethod();

                if (oneMethod.Module.Assembly != ms_Assembly)
                {
                    return oneMethod.Name;
                }

                currStackFrameIndex++;
            }

        }

        return "";
    }
}

