using System;
using System.Text;
using UnityEngine;
using xc;

public class DateHelper
{
    static uint ONE_MINUTE_TIME = 60;
    static uint ONE_HOUR_TIME = 3600;
    static uint ONE_DAY_TIME = 86400;
    public static int GetCurrentMonth()
    {
        DateTime dateTime = xc.Game.GetInstance().GetServerDateTime();

        return dateTime.Month;
    }

    public static int GetCurrentDay()
    {
        DateTime dateTime = xc.Game.GetInstance().GetServerDateTime();

        return dateTime.Day;
    }

    public static int GetCurrentYear()
    {
        DateTime dateTime = xc.Game.GetInstance().GetServerDateTime();

        return dateTime.Year;
    }

    public static int GetCurrentDayOfWeek()
    {
        DateTime dateTime = xc.Game.GetInstance().GetServerDateTime();
        return (int)dateTime.DayOfWeek;
    }

    public static string GetCurrentWeekString()
    {
        DateTime dateTime = xc.Game.GetInstance().GetServerDateTime();

        return dateTime.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
    }

    public static int GetCurrentMonth(int now)
    {
        DateTime dateTime = GetDateTime(now);

        return dateTime.Month;
    }

    public static int GetCurrentMonthDaysNum()
    {
        DateTime dateTime = xc.Game.GetInstance().GetServerDateTime();

        return System.DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
    }
    public static int GetCurrentMonthDaysNum(int now)
    {
        DateTime dateTime = GetDateTime(now);

        return System.DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
    }

    public static DateTime GetServerDateTime()
    {
        return xc.Game.GetInstance().GetServerDateTime();
    }

    static StringBuilder TimeBuilder = new StringBuilder("00:00");

    public static string GetServerMMSS()
    {
        var time_span = GetServerDateTime();
        var i = time_span.Hour;
        var j = time_span.Minute;
        if (i < 10)
        {
            TimeBuilder[0] = '0';
            TimeBuilder[1] = (char)(i + 48);
        }
        else
        {
            TimeBuilder[0] = (char)((i / 10) + 48);
            TimeBuilder[1] = (char)((i % 10) + 48);
        }

        if (j < 10)
        {
            TimeBuilder[3] = '0';
            TimeBuilder[4] = (char)(j + 48);
        }
        else
        {
            TimeBuilder[3] = (char)((j / 10) + 48);
            TimeBuilder[4] = (char)((j % 10) + 48);
        }

        return TimeBuilder.ToString();
    }

    public static DateTime GetDateTime(int now)
    {
        System.DateTime converted = xc.Game.GetInstance().Converted;
        System.DateTime newDate = converted.AddSeconds(now);

        return newDate;
    }

    /// <summary>
    /// 根据DateTime获取时间戳
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static long GetTimestamp(DateTime dateTime)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));

        return (long)(dateTime - startTime).TotalSeconds;
    }

    /// <summary>
    /// 获取当前日期是今年第几周
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static int GetWeekOfYear(DateTime dateTime)
    {
        //一.找到第一周的最后一天（先获取1月1日是星期几，从而得知第一周周末是几）
        // 星期一才是一周的第一天，这里要做一个转换
        int dayOfWeek = Convert.ToInt32(DateTime.Parse(dateTime.Year + "-1-1").DayOfWeek);
        if (dayOfWeek == 0)
        {
            dayOfWeek = 6;
        }
        else
        {
            dayOfWeek = dayOfWeek - 1;
        }
        int firstWeekend = 7 - dayOfWeek;

        //二.获取今天是一年当中的第几天
        int currentDay = dateTime.DayOfYear;

        //三.（今天 减去 第一周周一）/7 等于 距第一周有多少周 再加上第一周的1 就是今天是今年的第几周了
        //    刚好考虑了惟一的特殊情况就是，今天刚好在第一周内，那么距第一周就是0 再加上第一周的1 最后还是1
        return Convert.ToInt32(Math.Ceiling((currentDay - firstWeekend) / 7.0)) + 1;
    }

    /// <summary>
    /// 时间相减，为了解决Lua调用的时候IOS下面报错的问题
    /// </summary>
    /// <param name="left1"></param>
    /// <param name="left2"></param>
    /// <returns></returns>
    public static TimeSpan Subtract(DateTime left1, DateTime left2)
    {
        return left1 - left2;
    }

    public static string GetMMSS(uint endTimeStamp)
    {
        string str = string.Empty;
        int sec = (int)endTimeStamp % (int)ONE_MINUTE_TIME;
        int min = ((int)endTimeStamp % (int)ONE_HOUR_TIME) / (int)ONE_MINUTE_TIME;
        var hour = Mathf.FloorToInt(endTimeStamp % ONE_DAY_TIME) / ONE_HOUR_TIME;
        string sec_str;
        if (sec >= 10)
            sec_str = sec.ToString();
        else
            sec_str = "0" + sec.ToString();

        string min_str;
        if (min >= 10)
            min_str = min.ToString();
        else
            min_str = "0" + min.ToString();

        string hour_str;
        if (hour >= 10)
            hour_str = hour.ToString();
        else
            hour_str = "0" + hour.ToString();
        if (hour > 0)
        {
            str = string.Format("{0}:{1}", hour.ToString(), min.ToString());
        }
        else
        {
            str = string.Format("{0}:{1}", min.ToString(), sec.ToString());
        }
        return str;
    }
}