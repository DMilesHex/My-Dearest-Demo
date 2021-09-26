using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RivalIntro : MonoBehaviour
{
    public List<DialogueObject> nice, mean, awkward, followup;
    public DialogueObject intro;
    public GameObject buttons1, buttons2, buttons3, textBox;
    int progression;
    int niceCounter, meanCounter, awkCounter;

    public Text dialogueText;
    public Text nameText;

    

    bool started;
    private void Update()
    {
          
    }

    public void Nice()
    {

            Debug.Log("valid");
            if (progression < nice.Count)
            {
                
                if (buttons1 != null)
                {
                    buttons1.SetActive(true);
                }
                textBox.SetActive(true);
                if (gameObject.activeSelf)
                {
                    StartCoroutine(DisplayNice());
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
            else
            {
                textBox.SetActive(false);
                buttons1.SetActive(false);
            }
        
    }

    public void Mean()
    {
        if (progression < mean.Count)
        {
            
            while (meanCounter < mean[progression].DialogueLines.Count)
            {
                dialogueText.text = mean[progression].DialogueLines[meanCounter].LineText;
                nameText.text = mean[progression].DialogueLines[meanCounter]._npcName.ToString();
                if (Input.GetKey(KeyCode.E))
                {
                    if (meanCounter < mean[progression].DialogueLines.Count)
                        meanCounter++;
                    else
                    {
                        progression++;
                        break;
                    }//if meancounter
                }//if input
            }//while



        }
        else
        {
            
        }//else
    }//void mean

    public void Awkward()
    {
        if (progression < awkward.Count)
        {
            while (awkCounter < awkward[progression].DialogueLines.Count)
            {
                dialogueText.text = awkward[progression].DialogueLines[awkCounter].LineText;
                nameText.text = awkward[progression].DialogueLines[awkCounter]._npcName.ToString();
                if (Input.GetKey(KeyCode.E))
                {
                    if (awkCounter < awkward[progression].DialogueLines.Count)
                        awkCounter++;
                    else
                    {
                        progression++;
                        break;
                    } //if awkCounter
                }//if Input
            }//while
        }//if progression
        else
        {
            
        }//else
    }//void awkward

    IEnumerator DisplayNice()
    {
        dialogueText.text = nice[progression].DialogueLines[niceCounter].LineText;
        nameText.text = nice[progression].DialogueLines[niceCounter]._npcName.ToString();
        if (Input.GetKey(KeyCode.Space))
        {
            if (niceCounter < nice[progression].DialogueLines.Count)
                niceCounter++;
            else
            {
                progression++;
                
            }
        }
        yield return null;
    }
    private void OnEnable()
    {
        Debug.Log("enabled");
        started = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (started && collision.name == "Player" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("stuff");
            
            buttons1.SetActive(true);
            
            for (int i = 0; i < intro.DialogueLines.Count; i++)
            {
                
                dialogueText.text = intro.DialogueLines[i].LineText;
                nameText.text = intro.DialogueLines[i]._npcName.ToString();
            }
        }
    }
}//rivalintro
