using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public int sanity;
    public int sanityMax = 100;
    [SerializeField]
    public Weapon[] weapons;
    public GameObject weaponheld;
    public InventoryScript inventory;
    public Animator an;
    public bool chopped;

    public Text moneyText;

    public float money;
    public UnityEvent Sanity;
    public InsanityEffects ie;
    public int studyPoints;

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public int repIncrease;
    public Button button;

    public GameObject responseContainer, secondResponseContainer;

    public bool canGainRep = true;

    public I_Interactable interactable { get; set; }

    public AddPoints add;
    public int psych, bio;

    // Start is called before the first frame update

    public void Awake()
    {
        sanity = sanityMax;

    }

    public void Equip(int equipnumber)
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<InventoryScript>();
        Weapon weapontoequip = inventory.inventoryList[equipnumber];

        weaponheld = weapontoequip.weaponprefab;
    }

 
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        
        weapons = Resources.FindObjectsOfTypeAll<Weapon>();

        

    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        //image.gameObject.SetActive(false);
        moneyText.text = "$" + money;

        if (!SceneManager.GetActiveScene().name.Equals("House"))
        {
            ie.ChangeSanity(sanity);

        }
        else
        {
            button.interactable = studyPoints > 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
                interactable?.Interact(this);
            
        }

        
        
    }

     void FixedUpdate()
    {
        moveCharacter(movement);  
    }
    void moveCharacter(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree")) 

        {
            chopped = true;
            an.SetBool("isChopped", true);
            
            
        }
    }

    public void AddStudyPoints(int amount)
    {
        studyPoints += amount; 
    }

    public void ExtraRepPoints()
    {
        repIncrease = 5;
    }

    public void SanityRestore()
    {
        sanity = sanityMax;
    }

    public void MakeMoney()
    {
        responseContainer.SetActive(false);
        secondResponseContainer.SetActive(true);
    }

    public void Tutor()
    {
        money += 100;
    }

    public void Job()
    {
        money += 30;
    }

    public void Shady()
    {
        float troubleChance = Random.value;
        if (troubleChance > 0.3)
        {
            money += 50;
        }
        else if (troubleChance < 0.05)
        {
            Debug.Log("You were arrested. Game over");
        }
        else
        {
            canGainRep = false;
        }
    }

    public void StatDist(int index)
    {

        if (studyPoints > 0)
        {
            studyPoints--;
            switch (index)
            {
                case 0:
                    psych++;
                    break;
                case 1:
                    bio++;
                    break;
            }
            add.Add(index);
        }
    }


}
