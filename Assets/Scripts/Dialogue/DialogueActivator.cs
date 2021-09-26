using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueActivator : MonoBehaviour, I_Interactable
{
    [SerializeField] private DialogueObject dialogueObject;
    public int rep;

    public void Interact(player pl)
    {

        
        pl.DialogueUI.ShowDialogue(dialogueObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            player pl = collision.GetComponent<player>();
            pl.interactable = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player pl = collision.GetComponent<player>();
            if (pl.interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                pl.interactable = null;
            }
        }
    }
}
