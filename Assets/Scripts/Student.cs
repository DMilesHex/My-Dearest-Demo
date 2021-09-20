using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Student : MonoBehaviour
{
    public Dialogue dialogue;
    public Button casual;
    public Button compliment;
    public Button manipulate;
    // Start is called before the first frame update
    void Start()
    {
        
        casual.gameObject.SetActive(false);
        compliment.gameObject.SetActive(false);
        manipulate.gameObject.SetActive(false);
    }

    public void TriggerDialogue()
    {
        casual.gameObject.SetActive(false);
        compliment.gameObject.SetActive(false);
        manipulate.gameObject.SetActive(false);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            casual.gameObject.SetActive(true);
            compliment.gameObject.SetActive(true);
            manipulate.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            casual.gameObject.SetActive(false);
            compliment.gameObject.SetActive(false);
            manipulate.gameObject.SetActive(false);
            
        }
    }
    // Update is called once per frame
    public void OnClick()
    {
        
    }
}
