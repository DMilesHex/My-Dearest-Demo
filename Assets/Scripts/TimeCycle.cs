using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeCycle : MonoBehaviour
{
    private float timePassed;
    public int weeks, days, hours, minutes;
    public List<UnityEvent> m_event;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if (hours >= 8 && hours < 13)
        {
            m_event[0].Invoke();
        }
    }


}
