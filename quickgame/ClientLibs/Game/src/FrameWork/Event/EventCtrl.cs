using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SGameEngine;

public class EventCtrl
{
    public delegate void EventProcessFunc(CEventBaseArgs kArgs);
    Dictionary<int, List<EventProcessFunc>> mEventMap;

    public EventCtrl()
    {
        mEventMap = new Dictionary<int, List<EventProcessFunc>>();
    }

    public void SubscribeEvent(int uiEvent, ref EventProcessFunc processFunc)
    {
        List<EventProcessFunc> funcList;
        if(!mEventMap.TryGetValue(uiEvent, out funcList))
        {
            funcList = new List<EventProcessFunc>();
            mEventMap.Add(uiEvent, funcList);
        }

        if (!funcList.Contains(processFunc))
            funcList.Add(processFunc);
    }

    public void UnSubscribeEvent(int uiEvent, ref EventProcessFunc processFunc)
    {
        List<EventProcessFunc> funcList;
        if (mEventMap.TryGetValue(uiEvent, out funcList))
        {
            funcList.Remove(processFunc);
        }
    }

    public void UnSubscribeAllEvent(int uiEvent)
    {
        mEventMap.Remove(uiEvent);
    }

    public void FireEvent(int uiEvent, CEventBaseArgs args)
    {
        List<EventProcessFunc> funcList;
        if (mEventMap.TryGetValue(uiEvent, out funcList))
        {
            var tmpfuncList = Pool<EventProcessFunc>.List.New(funcList.Count);
            foreach (var func in funcList)
            {
                tmpfuncList.Add(func);
            }

            using (var iter = tmpfuncList.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var func = iter.Current;
                    if (func != null)
                        func(args);
                }
            }

            Pool<EventProcessFunc>.List.Free(tmpfuncList);
        }
    }

    /// <summary>
    /// 沒用的函數
    /// </summary>
    public static bool ContainProcess(ref EventProcessFunc funcList, ref EventProcessFunc processFunc)
    {
        foreach (EventProcessFunc func in funcList.GetInvocationList())
        {
            if (func == processFunc)
                return true;
        }

        return false;
    }

    /// <summary>
    /// 沒用的函數
    /// </summary>
    public bool ContainEvent(int eventId, ref EventProcessFunc fun)
    {
        return false;
    }

    /// <summary>
    /// 清除掉所有的事件
    /// </summary>
    public void Destory()
    {
        mEventMap.Clear();
    }
}
