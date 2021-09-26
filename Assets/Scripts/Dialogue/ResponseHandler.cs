using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform  responseButtonTemplate, responseContainer;
    private GameObject buttonText;
    private DialogueUI dialogueUI;
    List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }

    public void ShowResponses(Response[] responses)
    {
        
        foreach (Response response in responses)
        {
            
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponentInChildren<Text>().text = response.ResponseText;
            
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));

            tempResponseButtons.Add(responseButton);
            
        }

        
    }

    private void OnPickedResponse(Response response)
    {
        responseContainer.gameObject.SetActive(false);
        dialogueUI.ShowDialogue(response.DialogueObject);

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();

    }
}
