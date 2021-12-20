using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    Weapon axe;
    public TimeCycle tc;
    public UnityEvent tutor;
    public GameObject tutorButtons;
    public bool litter;
    
   

    public Text moneyText;

    public float money;
    public UnityEvent loadBar;
    public InsanityEffects ie;
    public int studyPoints;

    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public int repIncrease;
    public Button button, button2;
    public DialogueActivator da;

    public GameObject responseContainer, secondResponseContainer;

    public bool canGainRep = true;

    public I_Interactable interactable { get; set; }

    public AddPoints add;
    public int psych, bio;

    public Image panelColour;
    public GameObject canvas;

    public RectTransform buttonCanvas, buttonPrompt;
    private GameObject promptPrefab;

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

        if (SceneManager.GetActiveScene().name == "Outside")
        {
            weapons = Resources.FindObjectsOfTypeAll<Weapon>();

            promptPrefab = Instantiate(buttonPrompt.gameObject, buttonCanvas);

            Text[] texts = promptPrefab.GetComponentsInChildren<Text>();
            texts[0].text = "E";
            texts[1].text = "Tutor";
            promptPrefab.transform.position = gameObject.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            movement = new Vector2(Input.GetAxis("Horizontal"), 0);
        }
        //image.gameObject.SetActive(false);
        moneyText.text = "$" + money;

        if (!SceneManager.GetActiveScene().name.Equals("House"))
        {
            ie.ChangeSanity(sanity);

        }
        else
        {
            button.interactable = studyPoints > 0;
            button2.interactable = da.rep > 20;
        }

        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale > 0)
        {
                interactable?.Interact(this);
            
        }

        if (SceneManager.GetActiveScene().name == "Outside")
        {

            if (Input.GetKeyDown(KeyCode.E) && tc.hours > 16)
            {
                tutorButtons.SetActive(true);
                tc.hours += 1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                litter = true;
            }
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
        foreach (Weapon weapon in weapons)
        {
            if (weapon.weaponType == Weapon.WeaponType.Axe)
            {
                axe = weapon;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Tree") && axe.equipped && Input.GetKeyDown(KeyCode.F))

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
        EndDay();
    }

    public void Job()
    {
        money += 30;
        EndDay();
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
        EndDay();
    }

    public void Invite()
    {
        Debug.Log("Habiki greatly appreciates all you have done for her. She will stay away from Ryo.");
        EndDay();
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

    void EndDay()
    {
        canvas.SetActive(false);
        Color32 tempColour = panelColour.color;
        Color32 endColour = panelColour.color;
        endColour.a = 255;


        tempColour = Color32.Lerp(panelColour.color,
            endColour, Time.time);
        




        panelColour.color = tempColour;
        Color32 fadein = panelColour.color;
        fadein.a = 0;
        tempColour = Color32.Lerp(panelColour.color,
            fadein, Time.time);
        panelColour.color = tempColour;
        loadBar.Invoke();
    }

}
