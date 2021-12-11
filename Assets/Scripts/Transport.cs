
using UnityEngine;
using UnityEngine.UI;


public class Transport : MonoBehaviour
{
    public string indexToLoad;

    public TimeCycle tc;
    public int startTime, endTime;


    public RectTransform canvas, buttonPrompt;
    private GameObject promptPrefab;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        promptPrefab = Instantiate(buttonPrompt.gameObject, canvas);

        Text[] texts = promptPrefab.GetComponentsInChildren<Text>();
        texts[0].text = "E";
        texts[1].text = indexToLoad;
        promptPrefab.transform.position = gameObject.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.name == "Player") 
        {
            if (Input.GetKeyDown(KeyCode.E)
            && tc.hours >= startTime && tc.hours < endTime)
            {
                PlayerTransporter.LoadMap(indexToLoad);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(promptPrefab);
    }



}
