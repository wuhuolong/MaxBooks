using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarTest : MonoBehaviour
{
    public Text monthText;
    public Text yearText;
    public RectTransform generalDayPanelRectTrans;
    public Transform dayPanelTrans;
    public GridLayoutGroup dayPanelGridLayoutGroup;


    // private List<DayTest> dayList = new List<DayTest>();


    public void InitCalendar(int month, int year)
    {
        // dayList = new List<DayTest>();
        //设置月和年的显示
        monthText.text = month.ToString();
        yearText.text = year.ToString();

        DateTime[] dateTimeArr = new DateTime[42];

        DateTime firstDayOfTheMonth = new DateTime(year, month, 1);

        DayOfWeek firstDayWeek = firstDayOfTheMonth.DayOfWeek;
        int firstDayWeekInt = (int)firstDayWeek;

        int lastDayOfTheMonthInt = firstDayOfTheMonth.AddMonths(1).AddDays(-1).Day;
        // for (int i = 0; i < firstDayWeekInt; ++i)
        // {
        //     dayArr[i] = 0;
        // }
        int d = 1;
        int lastDayCount = lastDayOfTheMonthInt + firstDayWeekInt;
        Debug.Log("lastDayCount" + lastDayCount);
        for (int i = firstDayWeekInt; i < lastDayCount; i++)
        {
            dateTimeArr[i] = new DateTime(year, month, d);
            d++;
        }

        // Debug.Log(MatrixUtil.PrintIntArray(dayArr));

        for (int i = 0; i < 42; ++i)
        {
            Transform dayTrans = dayPanelTrans.GetChild(i);

            DayTest day = dayTrans.GetComponent<DayTest>();
            // dayList.Add(day);

            if (dateTimeArr[i] == DateTime.MinValue)
            {
                day.InitInvisible();
            }
            else
            {
                day.InitDay(dateTimeArr[i]);
            }
        }

        int row = lastDayCount / 7;
        if (lastDayCount % 7 != 0)
        {
            row++;
        }


        float cellWidth = generalDayPanelRectTrans.rect.width / 7;
        float cellHeight = generalDayPanelRectTrans.rect.height / row;

        dayPanelGridLayoutGroup.cellSize = new Vector2(cellWidth - 15, cellHeight - 15);
    }

}
