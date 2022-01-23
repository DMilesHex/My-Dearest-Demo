using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Pickup : MonoBehaviour
{
    #region Events
    public delegate void OnItemBought();
    /// <summary> Item has been bought. </summary>
    public static event OnItemBought ItemBought;
    /// <summary> Disable the canva, so the dialogue can be shown. </summary>
    public static event OnItemBought DisableCanva;
    /// <summary> Ënablle the disabled canva. </summary>
    public static event OnItemBought EnableCanva;

    public delegate void OnItemBoughtPrice(float price);
    /// <summary> Item was bought, decreased the money. </summary>
    public static event OnItemBoughtPrice ItemPrice;
    #endregion

    #region Variables
    private InventoryScript inventory;
    [SerializeField] private GameObject itemButton;
    [SerializeField] private Weapon associatedWeapon;
    [SerializeField] private Money money;
    [Header("Dialogues")]
    [SerializeField] private List<DialogueObject> shopDialogue;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject textBox;
    [Header("Buttons")]
    [SerializeField] private Button buyButton;
    #endregion

    private void Start() => inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();

    private void OnEnable() => RandomItem.ButtonPressed += GoBack;

    private void OnDisable() => RandomItem.ButtonPressed -= GoBack;

    public void DisableButton() => itemButton.SetActive(false);  
    public void EnableButton() => itemButton.SetActive(true);

    public void Buy()
    {
        buyButton.gameObject.SetActive(false);      

        if (money.MoneyAmount >= associatedWeapon.price)
        {
            HandleTextBox(false);
            ItemPrice(associatedWeapon.price);
            EnableButton();
            
            ItemBought();
            EnableCanva();
            inventory.AddWeapon(associatedWeapon);
        }

        Shop(1);
         HandleTextBox(false);  
    }

    public void ShowUI()
    {
        if (SceneManager.GetActiveScene().name.Equals("Rin's Shop"))
        {
            DisableCanva();
            buyButton.gameObject.SetActive(true);
            Shop(0);            
        }

        EnableButton();
        inventory.AddWeapon(associatedWeapon);         
    }

    private void Shop(int progression)
    {
        HandleTextBox(true);

        for (int h = 0; h < shopDialogue[0].DialogueLines.Count; h++)
        {
            Debug.Log(shopDialogue[progression].DialogueLines[h]);
            dialogueText.text = shopDialogue[progression].DialogueLines[h].LineText;
            nameText.text = shopDialogue[progression].DialogueLines[h].NpcName.ToString();         
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            ShowUI();
        }
    }

    private void GoBack()
    {
        buyButton.gameObject.SetActive(false);
        HandleTextBox(false);
    }

    #region Stuff to make the life easier
    /// <summary> Enable or disable the textboxt. </summary>
    /// <param name="value">True or false</param>
    private void HandleTextBox(bool value)
    {
        textBox.SetActive(value);
    }
    #endregion
}
