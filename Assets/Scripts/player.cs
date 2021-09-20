using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

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
        
        ie.ChangeSanity(sanity);
        
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


}
