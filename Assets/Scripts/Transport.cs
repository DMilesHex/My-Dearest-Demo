
using UnityEngine;


public class Transport : MonoBehaviour
{
    public int indexToLoad;

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && Input.GetKeyDown(KeyCode.E))
        {

            PlayerTransporter.LoadMap(indexToLoad);
            
        }
    }



}
