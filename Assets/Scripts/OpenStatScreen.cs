using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class OpenStatScreen : MonoBehaviour
{
    public GameObject statDist;
    public TMP_Text studyPointsLeft;
    public player pl;
    public UnityEvent classTime;

    private void Update()
    {
        studyPointsLeft.text = "Study Points " + pl.studyPoints;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                classTime.Invoke();
                statDist.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                statDist.SetActive(false);
            }
        }
    }
}
