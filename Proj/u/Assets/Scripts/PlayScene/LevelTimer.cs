using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    int time = 0;
    public int Time
    {
        get { return time; }
        set { time = value; }
    }
    public Text timeText;

    private bool gameOn = true;

    public IEnumerator RestartTimer()
    {
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(Timer());
        StartCoroutine(Timer());
    }
    private static string timeformat = "{0}s";
    public void SetTime(int time)
    {
        this.time = time;
        timeText.text = string.Format(timeformat, time);
    }

    public IEnumerator Timer()
    {
        while (gameOn)
        {
            yield return new WaitForSeconds(1.0f);
            time++;
            SetTime(time);
        }

    }

}
