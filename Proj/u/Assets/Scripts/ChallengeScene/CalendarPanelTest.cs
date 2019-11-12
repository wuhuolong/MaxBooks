using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarPanelTest : MonoBehaviour
{
    public Button lastButton;
    public Button nextButton;

    public RectTransform UIChallengeRectTrans;

    public RectTransform switchBarRectTrans;
    private RectTransform rectTrans;
    float panelWidth = 0;
    // string day = "";
    DateTime currentCalendarDateTime = new DateTime();

    List<CalendarTest> calendarList;


    // void Start()
    // {
    //     // InitPanelSize();
    //     // InitAllCalendars();
    // }

    public void InitPanelSize()
    {
        rectTrans = this.GetComponent<RectTransform>();
        Rect rect = rectTrans.rect;
        Vector2 v2 = rectTrans.sizeDelta;
        panelWidth = rect.width;
        // float height = rect.height;
        float height = UIChallengeRectTrans.rect.height * transform.parent.GetComponent<RectTransform>().anchorMax.y;


        int childCount = rectTrans.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            Transform childTrans = rectTrans.GetChild(i);
            RectTransform childRectTrans = childTrans.GetComponent<RectTransform>();
            Rect childRect = childRectTrans.rect;
            Vector2 childSize = childRect.size;
            childRectTrans.sizeDelta = new Vector2(panelWidth, height);
        }
        //rectTrans.sizeDelta = new Vector2(panelWidth*4, height);
        rectTrans.sizeDelta = new Vector2(childCount * panelWidth - panelWidth, height);
        switchBarRectTrans.sizeDelta = new Vector2(0, height);
    }

    public void InitAllCalendars()
    {
        calendarList = new List<CalendarTest>();

        int selectedDateTimeInt = XPlayerPrefs.GetInt(ChallengeController.selectedDateTimeStr);
        Debug.Log("selectedDay:" + selectedDateTimeInt);

        if (selectedDateTimeInt != 0)
        {
            currentCalendarDateTime = TimeUtil.getDateTimeByInt(selectedDateTimeInt);
        }
        else
        {
            currentCalendarDateTime = DateTime.Today;

            X.Res.SignInConfig todaySignInConfig = SignInMgr.GetInstance().GetConfigByID((uint)TimeUtil.getIntByDateTime(currentCalendarDateTime));
            if (todaySignInConfig != null && LevelMgr.GetInstance().GetLevelConfig(todaySignInConfig.LevelId).Config != null)
            {
                XPlayerPrefs.SetInt(ChallengeController.selectedDateTimeStr, TimeUtil.getIntByDateTime(currentCalendarDateTime));
            }
            else
            {
                XPlayerPrefs.SetInt(ChallengeController.selectedDateTimeStr, (int)SignInMgr.GetInstance().MaxValidDay);
            }
        }

        selectedDateTimeInt = XPlayerPrefs.GetInt(ChallengeController.selectedDateTimeStr);
        Debug.Log("selectedDay:" + selectedDateTimeInt);



        int calendarCount = transform.childCount;
        int centerCalendar = calendarCount / 2;
        int offsetMonth = 0;


        for (int i = centerCalendar; i >= 0; i--)
        {
            Transform calendarTrans = transform.GetChild(i);
            CalendarTest calendar = calendarTrans.GetComponent<CalendarTest>();

            calendarList.Add(calendar);

            DateTime calendarDateTime = currentCalendarDateTime.AddMonths(offsetMonth);
            calendar.InitCalendar(calendarDateTime.Month, calendarDateTime.Year);
            offsetMonth--;
        }

        offsetMonth = 1;
        for (int i = centerCalendar + 1; i < calendarCount; i++)
        {
            Transform calendarTrans = transform.GetChild(i);
            CalendarTest calendar = calendarTrans.GetComponent<CalendarTest>();

            calendarList.Add(calendar);

            DateTime calendarDateTime = currentCalendarDateTime.AddMonths(offsetMonth);
            calendar.InitCalendar(calendarDateTime.Month, calendarDateTime.Year);
            offsetMonth++;
        }

        currentCalendarDateTime = new DateTime(currentCalendarDateTime.Year, currentCalendarDateTime.Month, 1);
        Debug.Log(currentCalendarDateTime.Year + " " + currentCalendarDateTime.Month + " " + currentCalendarDateTime.Day);


    }

    public void ShowBesideMonthCalendar(bool nextOrLast)
    {
        if (nextOrLast)
        {
            //跳至下一个月
            DateTime nextCalendarDateTime = currentCalendarDateTime.AddMonths(1);
            DateTime firstDateOfNext = new DateTime(nextCalendarDateTime.Year, nextCalendarDateTime.Month, 1);

            if (firstDateOfNext > TimeUtil.getDateTimeByInt((int)(SignInMgr.GetInstance().MaxDay)))
            {
                //如果下一個月的第一天沒有配置
                return;
            }

            //设置currentCalendarDateTime
            currentCalendarDateTime = currentCalendarDateTime.AddMonths(1);
            Debug.Log(currentCalendarDateTime.Year + " " + currentCalendarDateTime.Month + " " + currentCalendarDateTime.Day);
            nextCalendarDateTime = currentCalendarDateTime.AddMonths(1);


            //TODO:加入动画而非直接变换位置
            StartCoroutine(moveRectTrans(rectTrans, rectTrans.anchoredPosition + Vector2.left * panelWidth, 0.2f, () =>
            {
                // rectTrans.anchoredPosition = rectTrans.anchoredPosition + Vector2.left * panelWidth;

                //TODO:动画播完后，改变子节点的排序，即多个日历的排序，由于horizontalLayout的作用会改变每个日历的位置，将第一个日历放到最后时，当前展示的日历会往左移动，因此整个panel需要再往右移动

                //TODO:原本的第一个子节点，即第一个日历放到最后之后，将第一个日历变为当前查看的日历的下一月份的日历
                Transform firstCalendarTrans = rectTrans.GetChild(0);
                firstCalendarTrans.SetAsLastSibling();

                CalendarTest firstCalendar = firstCalendarTrans.GetComponent<CalendarTest>();

                firstCalendar.InitCalendar(nextCalendarDateTime.Month, nextCalendarDateTime.Year);

                Debug.Log("move back");
                rectTrans.anchoredPosition = rectTrans.anchoredPosition + Vector2.right * panelWidth;
            }));


        }
        else
        {
            //跳至上一个月
            DateTime lastCalendarDateTime = currentCalendarDateTime.AddMonths(-1);
            DateTime lastDateOfLast = new DateTime(currentCalendarDateTime.Year, currentCalendarDateTime.Month, 1).AddDays(-1);
            if (lastDateOfLast < TimeUtil.getDateTimeByInt((int)(SignInMgr.GetInstance().MinDay)))
            {
                //如果上一個月的最後一天也沒有配置
                return;
            }

            //设置currentCalendarDateTime
            currentCalendarDateTime = currentCalendarDateTime.AddMonths(-1);
            Debug.Log(currentCalendarDateTime.Year + " " + currentCalendarDateTime.Month + " " + currentCalendarDateTime.Day);
            lastCalendarDateTime = currentCalendarDateTime.AddMonths(-1);

            //TODO:加入动画而非直接变换位置
            StartCoroutine(moveRectTrans(rectTrans, rectTrans.anchoredPosition + Vector2.right * panelWidth, 0.2f, () =>
            {
                //TODO:动画播完后，改变子节点的排序，即多个日历的排序，由于horizontalLayout的作用会改变每个日历的位置，将最后一个日历放到开头时，当前展示的日历会往右移动，因此整个panel需要再往左移动

                //TODO:原本的最后一个子节点，即最后一个日历放到开头之后，将最后一个日历变为当前查看的日历的前一月份的日历
                Transform lastCalendarTrans = rectTrans.GetChild(rectTrans.childCount - 1);
                lastCalendarTrans.SetAsFirstSibling();

                CalendarTest lastCalendar = lastCalendarTrans.GetComponent<CalendarTest>();
                lastCalendar.InitCalendar(lastCalendarDateTime.Month, lastCalendarDateTime.Year);

                rectTrans.anchoredPosition = rectTrans.anchoredPosition + Vector2.left * panelWidth;
            }));
            // rectTrans.anchoredPosition = rectTrans.anchoredPosition + Vector2.right * panelWidth;


        }
    }

    IEnumerator moveRectTrans(RectTransform rectTrans, Vector2 destPos, float time, Action afterMove)
    {
        lastButton.interactable = false;
        nextButton.interactable = false;
        Vector2 startPos = rectTrans.anchoredPosition;
        Vector2 direction = Vector3.Normalize(destPos - startPos);
        float distance = Vector3.Magnitude(destPos - startPos);
        float speed = distance / time;
        while (time > 0)
        {
            time -= Time.deltaTime;
            rectTrans.anchoredPosition += speed * Time.deltaTime * direction;
            yield return null;
        }
        rectTrans.anchoredPosition = destPos;
        lastButton.interactable = true;
        nextButton.interactable = true;
        afterMove();
    }

    // public DayTest GetDayByDateTime(int dateTimeInt)
    // {
    //     int childCount = rectTrans.childCount;
    //     foreach(CalendarTest calendar in calendarList)
    //     {

    //     }
    //     return null;
    // }


}
