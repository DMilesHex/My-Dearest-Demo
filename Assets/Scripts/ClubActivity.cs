using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClubActivity : MonoBehaviour
{
    public RectTransform canvas, buttonPrompt;
    private GameObject promptPrefab;
    public Weapon activity;
    public UnityEvent remove;

    public List<Club> clublist;
    public Club addclub;

    public void ClubStart(string name)
    {
        JoinClub(name);
        addclub = new Club();
        addclub.clubname = name;
        addclub.bclubjoined = true;
        clublist.Add(addclub);
    } 
    public bool JoinClub(string name)
    {
        

        foreach (Club club in clublist)
        {
            if (name == addclub.clubname)
            {
                return true;
            }
            
        }
        return false;
    }






    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (JoinClub(gameObject.name))
        {
            promptPrefab = Instantiate(buttonPrompt.gameObject, canvas);

            Text[] texts = promptPrefab.GetComponentsInChildren<Text>();
            texts[0].text = "F";
            texts[1].text = "Submit";
            promptPrefab.transform.position = gameObject.transform.position + new Vector3(0, 1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.name == "Player")
        {

            if (Input.GetKeyDown(KeyCode.F) && activity.equipped && JoinClub(gameObject.name))
            {
                remove.Invoke();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(promptPrefab);
    }
}



