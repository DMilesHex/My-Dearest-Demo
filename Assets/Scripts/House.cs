using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class House : MonoBehaviour
{
    public List<DialogueObject> dialogue;
    public TMP_Text infoText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(int index)
    {
        for(int i = 0; i < dialogue[index].DialogueLines.Count; i++)
        infoText.text = dialogue[index].DialogueLines[i].LineText; 
    }
    public void HideText()
    {
        infoText.text = string.Empty;
    }
}
