using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class TimeCycle : MonoBehaviour, ISaveable
{
    private float timePassed;
    public int weeks, days, hours, minutes;
    public List<UnityEvent> m_event;

    public TMP_Text dayText;
    public TMP_Text weekText;

    private void Awake()
    {
        weekText.text = "Week " + weeks;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        timePassed += 1f;

        if (timePassed == 300)
        {
            timePassed = 0;
            minutes += 10;
        }
        if (minutes == 60)
        {
            minutes = 0;
            hours += 1;
        }
        if (hours == 24)
        {
            hours = 0;
            days += 1;
        }
        if (days == 8)
        {
            days = 0;
            weeks += 1;
        }

        if (hours >= 8 && hours < 13 || hours >= 14 && hours < 16)
        {
            m_event[0].Invoke();
        }

        switch (days)
        {
            case 0:
                dayText.text = "Monday";
                break;
            case 1:
                dayText.text = "Tuesday";
                break;
            case 2:
                dayText.text = "Wednesday";
                break;
            case 3:
                dayText.text = "Thursday";
                break;
            case 4:
                dayText.text = "Friday";
                break;
            case 5:
                dayText.text = "Saturday";
                break;
            case 6:
                dayText.text = "Sunday";
                break;
        }

        weekText.text = "Week " + weeks;
    }

    public void ClassTime()
    {
        if (hours <= 8)
        {
            hours = 13;
            minutes = 0;
            timePassed = 0;
        }
        else if (hours > 13 && hours < 16)
        {
            hours = 16;
            minutes = 0;
            timePassed = 0;
        }
    }

    public object CaptureState()
    {
        return new SaveData
        {
            weeks = weeks,
            days = days,
            hours = hours,
            minutes = minutes
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        weeks = saveData.weeks;
        days = saveData.days;
        hours = saveData.hours;
        minutes = saveData.minutes;
    }

    private struct SaveData
    {
        public int weeks, days, hours, minutes;
    }
}
