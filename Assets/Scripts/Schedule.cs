using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Schedule : MonoBehaviour
{
    

    public void GoToClass()
    {
        if (SceneManager.GetActiveScene().name.Equals("Classroom") 
            && gameObject.name != "Rin" 
            && gameObject.name != "Orochi" 
            && gameObject.name != "Kyoko"
            && gameObject.name != "Miyu")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
