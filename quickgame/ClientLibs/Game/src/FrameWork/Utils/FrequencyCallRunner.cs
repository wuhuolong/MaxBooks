using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 用于优化处理频繁调用的函数
/// </summary>
/// <typeparam name="T"></typeparam>
public class FrequencyCallRunner<T> where T : class
{
    /// <summary>
    /// 上次调用的时间
    /// </summary>
    private float mLastCallTime = 0f;

    /// <summary>
    /// 上次返回的结果
    /// </summary>
    private T mLastCallObject = null;

    /// <summary>
    /// 调用的函数
    /// </summary>
    public delegate T Func();
    private Func mFunc;

    /// <summary>
    /// 有参数的调用的函数
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public delegate T ParametersFunc(List<System.Object> parameters);
    private ParametersFunc mParametersFunc;

    private List<System.Object> mRunParameters;

    /// <summary>
    /// 调用频率
    /// </summary>
    private float mCallDelay = 1f;

    public FrequencyCallRunner(float delay, Func func)
    {
        mCallDelay = delay;
        mFunc = func;
    }

    public FrequencyCallRunner(float delay, ParametersFunc func, List<System.Object> parameters)
    {
        mCallDelay = delay;
        mParametersFunc = func;
        mRunParameters = parameters;
    }

    public T Call()
    {
        var now_time = Time.realtimeSinceStartup;
        if (now_time - mLastCallTime < mCallDelay)
        {
            return mLastCallObject;
        }

        mLastCallTime = now_time;

        if(mFunc != null)
        {
            mLastCallObject = mFunc();
        }
        else if(mParametersFunc != null)
        {
            mLastCallObject = mParametersFunc(mRunParameters);
        }

        return mLastCallObject;
    }
}