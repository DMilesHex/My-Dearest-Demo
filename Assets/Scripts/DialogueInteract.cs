using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DialogueInteract : MonoBehaviour
{ 



    public Image dialogueImage;
    public Text dialogueText;
    public DialogueObject dialogueObject;

    public RepMeter rm;


    public DialogueObject intro;
    public List<DialogueObject> nice;
    public List<DialogueObject> mean;
    public List<DialogueObject> awkward;
    public DialogueObject gift;
    public Text nameText;
    public Button option1, option2, option3;
    public Button meanOption1, meanOption2, meanOption3;
    public Button awkOption1, awkOption2, awkOption3;

    public Animator animator;
    int match, match2;
    string charName;
    int j;
    public player pl;

    List<GameObject> collisions;

    int progression;
    int rep;


    bool choices;
    bool choices2;
    bool choices3;
    bool displayed;
    bool giftGiving;

    public bool removeGift;

    

    private void Start()

    {
        collisions = new List<GameObject>();
        DisplayDialogue(0, 3);



    }
    public void Update()
    {
        rm.ChangeRep(rep);
        
        if (choices)
        {
            option1.gameObject.SetActive(true);
            option2.gameObject.SetActive(true);
            option3.gameObject.SetActive(true);
        }
        else
        {
            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
            option3.gameObject.SetActive(false);
        }

        if (choices2)
        {
            meanOption1.gameObject.SetActive(true);
            meanOption2.gameObject.SetActive(true);
            meanOption3.gameObject.SetActive(true);
        }
        else
        {
            meanOption1.gameObject.SetActive(false);
            meanOption2.gameObject.SetActive(false);
            meanOption3.gameObject.SetActive(false);
        }

        if (choices3)
        {
            awkOption1.gameObject.SetActive(true);
            awkOption2.gameObject.SetActive(true);
            awkOption3.gameObject.SetActive(true);
        }
        else
        {
            awkOption1.gameObject.SetActive(false);
            awkOption2.gameObject.SetActive(false);
            awkOption3.gameObject.SetActive(false);
        }

    }
    public void NiceDialogue()
    {
        
        if (progression < nice.Count)
        {
            rep++;
            
            StartCoroutine(DisplayDialogue(progression, 0));
            
            choices = true;

        }
        else
        {
            Debug.Log(progression);
            //animator.SetBool("IsOpen", false);
            choices = false;
        }
    }

    public void MeanDialogue()
    {
        if (progression < mean.Count)
        {

            if (EventSystem.current.currentSelectedGameObject.name == "Apologize")
            {
                progression = 2;

            }
            else if (EventSystem.current.currentSelectedGameObject.name == "Insult")
            {
                rep -= 1;
                
                progression = 3;
            }
            else if (EventSystem.current.currentSelectedGameObject.name == "Leave")
            {
                progression = 4;
            }

            if (progression < 1)
            {
                choices = true;
            }
            else
            {
                choices2 = true;
                choices = false;
            }
            StartCoroutine(DisplayDialogue(progression, 1));
            progression++;



        }
        else
        {
            animator.SetBool("IsOpen", false);
        }
    }

    public void AwkwardDialogue()
    {
        if (progression < awkward.Count)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "Apologize")
            {
                
                progression = 2;

            }
            else if (EventSystem.current.currentSelectedGameObject.name == "Insult")
            {
                progression = 3;
            }
            else if (EventSystem.current.currentSelectedGameObject.name == "Leave")
            {
                progression = 4;
            }

            if (progression < 1)
            {
                choices = true;
            }
            else
            {
                choices3 = true;
                choices = false;
            }
            StartCoroutine(DisplayDialogue(progression, 2));
            progression++;



        }
        else
        {
            animator.SetBool("IsOpen", false);
        }
    }

    IEnumerator DisplayDialogue(int element, int type)
    {

        animator.SetBool("IsOpen", true);


        

            if (type == 0)
            {

                for (int j = 0; j < nice[element].DialogueLines.Count; j++)
                {

                    Debug.Log(nice[element].DialogueLines[j]);
                    dialogueText.text = nice[element].DialogueLines[j].LineText;
                    nameText.text = nice[element].DialogueLines[j]._npcName.ToString();
                    
                    yield return new WaitForSeconds(5f);
                progression++;

            }


            }

            if (type == 1)
            {

                for (j = 0; j < mean[element].DialogueLines.Count; j++)
                {

                    Debug.Log(mean[element].DialogueLines[j].LineText);
                    dialogueText.text = mean[element].DialogueLines[j].LineText;
                    nameText.text = mean[element].DialogueLines[j]._npcName.ToString();
                    CheckValue();
                    yield return new WaitForSeconds(5f);



                }
            }

            if (type == 2)
            {

                for (int j = 0; j < awkward[element].DialogueLines.Count; j++)
                {

                    Debug.Log(awkward[element].DialogueLines[j]);
                    dialogueText.text = awkward[element].DialogueLines[j].LineText;
                    nameText.text = awkward[element].DialogueLines[j]._npcName.ToString();
                    CheckValue();
                    yield return new WaitForSeconds(5f);


                }
            }
            if (type == 3)
            {
                for (int h = 0; h < intro.DialogueLines.Count; h++)
                {
                animator.SetBool("IsOpen", true);
                Debug.Log(intro.DialogueLines[h]);
                    dialogueText.text = intro.DialogueLines[h].LineText;
                    nameText.text = intro.DialogueLines[h]._npcName.ToString();
                    choices = true;


            }

  
                

            }

        if (type == 4)
        {
            animator.SetBool("IsOpen", true);
            for (int h = 0; h < gift.DialogueLines.Count; h++)
            {

                Debug.Log(gift.DialogueLines[h]);
                dialogueText.text = gift.DialogueLines[h].LineText;
                nameText.text = gift.DialogueLines[h]._npcName.ToString();
                
                yield return new WaitForSeconds(5f);
                
            }
        }

    }
    
        void CheckValue()
        {


            if (progression >= 3 && j > mean[progression].DialogueLines.Count)
            {
                animator.SetBool("IsOpen", false);
                choices2 = false;


            }

            if (progression >= 3 && j > awkward[progression].DialogueLines.Count)
            {
                animator.SetBool("IsOpen", false);
                choices3 = false;


            }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (!collisions.Contains(collision.gameObject))
            collisions.Add(collision.gameObject);
        if (collision.CompareTag("gift"))
        {
            Debug.Log("test");
            giftGiving = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.name == "Player" && Input.GetAxis("Jump") > 0)
            {
                Debug.Log("Interact");
                if (choices)
                {
                    option1.gameObject.SetActive(true);
                    option2.gameObject.SetActive(true);
                    option3.gameObject.SetActive(true);
                }
                else
                {
                Debug.Log(progression);
                    StartCoroutine(DisplayDialogue(0, 3));
                }

            }

            if(collisions.Count >= 2  && !giftGiving && collision.name == "Knife" && Input.GetAxis("Fire1") > 0)
            {
            Debug.Log("dead");
            pl.sanity -= 10;
            Destroy(gameObject);
            }
        if (giftGiving && Input.GetAxis("Fire1") > 0)
        {
            
            removeGift = true;
            rep += 5;
            rm.ChangeRep(rep);
            StartCoroutine(DisplayDialogue(0, 4));


        }

    }

        void OnTriggerExit2D(Collider2D collision)
        {
            option1.gameObject.SetActive(false);
            option2.gameObject.SetActive(false);
            option3.gameObject.SetActive(false);
            animator.SetBool("IsOpen", false);
            
    }

}

