using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void xEvent(params object[] values);

public static class UIEvent
{

    private static Dictionary<int, xEvent> m_EventDic = new Dictionary<int, xEvent>();

    public static void Broadcast(int eventid ,params object[] argv)
    {
        xEvent de = null;
        m_EventDic.TryGetValue(eventid,out de);
        if(de != null){
            de(argv);
        }
    }
    
    public static void RegEvent(int id, xEvent ac1)
    {
        if (m_EventDic.ContainsKey(id))
        {
            m_EventDic[id] += ac1;
        }
        else
        {
            m_EventDic[id] = ac1;
        }
    }
    public static void UnRegEvent(int id, xEvent ac1)
    {
        if (m_EventDic.ContainsKey(id))
        {
            m_EventDic[id] -= ac1;
            if (m_EventDic[id] == null)
            {
                m_EventDic.Remove(id);
            }
        }
    }
    public static void PrintState()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (var item in m_EventDic)
        {
            sb.Append("key==>"+item.Key + ",value==>" + item.Value.Method.ToString()+"\n");
        }
        Debug.Log(sb.ToString());
    }
    //Event id
    public static int UI_MONEY_CHANGE = 1;
    public static int UI_TEST1 = 2;
    public static int UI_TEST2 = 3;
    public static int UI_LEVELSTART = 4;

    public static int UI_GM_SELECTED = 5;//gm面板被点击
    public static int UI_LEVEL_USEREC = 6;

}