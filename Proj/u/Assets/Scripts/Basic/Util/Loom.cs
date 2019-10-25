using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
/// <summary>
/// 用于多线程异步操作
/// </summary>
public class Loom : MonoSingleton<Loom>
{
    public static int maxThreads = 8;
    static int numThreads;

    private static Loom _current;
    private int _count;
    public static Loom Current
    {
        get
        {
            if (_current == null)
            {
                _current = GetInstance();
            }
            //Initialize();
            return _current;
        }
    }


    static bool initialized;
    static void Initialize()
    {
        if (!initialized)
        {
            if (!Application.isPlaying)
                return;
            initialized = true;
        }
    }

    private List<Action> _actions = new List<Action>();
    public struct DelayedQueueItem
    {
        public float DTime;
        public Action DAction;
    }
    private List<DelayedQueueItem> _delayed = new List<DelayedQueueItem>();
    private List<DelayedQueueItem> _currentDelayed = new List<DelayedQueueItem>();
    public static void QueueOnMainThread(Action action)
    {
        QueueOnMainThread(action, 0f);
    }
    public static void QueueOnMainThread(Action action,float time)
    {
        if (time!= 0)
        {
            lock (Current._delayed)
            {
                Current._delayed.Add(new DelayedQueueItem { DTime = time, DAction = action });
            }
        }
        else
        {
            lock (Current._actions)
            {
                Current._actions.Add(action);
            }
        }
    }

    public static Thread RunAsync(Action a)
    {
        Initialize();
        while (numThreads>=maxThreads)
        {
            Thread.Sleep(1);
        }
        Interlocked.Increment(ref numThreads);
        ThreadPool.QueueUserWorkItem(RunAction,a);
        return null;
    }

    private static void RunAction(object action)
    {
        try
        {
            ((Action)action)();
        }
        catch (Exception e)
        {
            Debuger.Log("Loom", "RunAction", e.Message + "==>" + e.StackTrace);
        }
        finally
        {
            Interlocked.Decrement(ref numThreads);
        }
    }

    private void OnDisable()
    {
        if (_current == this)
        {
            _current = null;
        }
    }
    List<Action> _currentActions = new List<Action>();

    private void Update()
    {
        lock (_actions)
        {
            _currentActions.Clear();
            _currentActions.AddRange(_actions);
            _actions.Clear();
        }
        for (int i = 0; i < _currentActions.Count; i++)
        {
            _currentActions[i]();
        }
        lock (_delayed)
        {
            _currentDelayed.Clear();
            for (int i = 0; i < _delayed.Count; i++)
            {
                if (_delayed[i].DTime<=Time.time)
                {
                    _currentDelayed.Add(_delayed[i]);
                }
            }
            for (int i = 0; i < _currentDelayed.Count; i++)
            {
                _delayed.Remove(_currentDelayed[i]);
            }
        }
        for (int i = 0; i < _currentDelayed.Count; i++)
        {
            _currentDelayed[i].DAction();
        }
    }
}
