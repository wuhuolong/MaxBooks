using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class TimeUtil
{
    static DateTime startDateTime = new DateTime(1899, 12, 30);
    public static DateTime getDateTimeByInt(int timeInt)
    {
        DateTime retDateTime = startDateTime.AddDays(timeInt);
        return retDateTime;
    }

    public static int getIntByDateTime(DateTime dateTime)
    {
        TimeSpan timeSpan = dateTime - startDateTime;
        int ret = timeSpan.Days;
        return ret;
    }

    public static int getIntByDateTime(int y, int m, int d)
    {
        DateTime dateTime = new DateTime(y, m, d);
        return getIntByDateTime(dateTime);
    }

    public static bool isNetworkOn()
    {
        return (Application.internetReachability != NetworkReachability.NotReachable);
    }
}