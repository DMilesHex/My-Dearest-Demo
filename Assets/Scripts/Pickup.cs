using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private InventoryScript inventory;
    public GameObject itemButton;
    public Weapon associatedWeapon;

    public List<DialogueObject> shopDialogue;
    public Text dialogueText;
    public Text nameText;

    public player pl;

    public Animator animator;

    public Button buy;

    private void Start()
    {
        
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();

    }

    public void DisableButton()
    {
        itemButton.SetActive(false);
        
    }
    public void EnableButton()
    {
        itemButton.SetActive(true);
    }
    public void Buy()
    {
        buy.gameObject.SetActive(false);
        if (pl.money >= 10.0f)
        {
            animator.SetBool("IsOpen", false);
            EnableButton();
            inventory.AddWeapon(associatedWeapon);
        }
        else

        {
            Shop(1);
            animator.SetBool("IsOpen", false);
        }
    }
    public void AddUI()
    {
        if (SceneManager.GetActiveScene().name.Equals("Rin's Shop"))
        {
            buy.gameObject.SetActive(true);
            Shop(0);

            
        }
        else
        {
            EnableButton();
            inventory.AddWeapon(associatedWeapon);
        }
        
        
    }

    void Shop(int progression)
    {

            animator.SetBool("IsOpen", true);
        for (int h = 0; h < shopDialogue[0].DialogueLines.Count; h++)
        {

            Debug.Log(shopDialogue[progression].DialogueLines[h]);
            dialogueText.text = shopDialogue[progression].DialogueLines[h].LineText;
            nameText.text = shopDialogue[progression].DialogueLines[h]._npcName.ToString();

            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            AddUI();

        }
    }


    
}
