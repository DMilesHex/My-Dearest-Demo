using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Build;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private float sov = 5f;
    [SerializeField] private Transform sight;
    [SerializeField] private player playerScript;
    [SerializeField] private int sanityLevel = 60;

    void Update()
    {
        RaycastHit2D sightInfo = Physics2D.Raycast(sight.position, sight.right, sov);
        
        if (sightInfo.collider == true)
        {
            if (gameObject.tag == "Teacher")
            {
                if (sightInfo.collider.gameObject.CompareTag("Player") == true)
                {
                    //Player can be seen
                    Debug.Log("Always watching Mike Wazowski");
                    if (weapon.activeSelf == true)
                    {
                        //Player is carrying a weopon
                        Debug.Log("Weapon game over");
                    }

                    if (playerScript.Sanity <= sanityLevel)
                    {
                        Debug.Log("Sanity game over");
                    }
                }
            }
            else
            {
                if (sightInfo.collider.gameObject.CompareTag("Player") == true)
                {
                    //Player can be seen
                    Debug.Log("Player Captured");
                    if (weapon.activeSelf == true)
                    {
                        //Player is carrying a weopon
                        Debug.Log("She had a weopon OMG!!!");
                    }

                    if (playerScript.Sanity <= sanityLevel)
                    {
                        Debug.Log("She's dropping blood");
                    }
                }
            }
        }
    }
}
