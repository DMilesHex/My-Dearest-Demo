using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text nameText;

    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;

    public DialogueActivator dialogueActivator;

    [SerializeField] private RepMeter rm;

    public bool isOpen { get; private set; }

    private void Start()
    {
        
        

        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        
        
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        dialogueActivator.rep += dialogueObject.RepFactor;
        rm.ChangeRep(dialogueActivator.rep);

        for (int i = 0; i < dialogueObject.DialogueLines.Count; i++)
        {
            
            DialogueLine dialogue = dialogueObject.DialogueLines[i];
            nameText.text = dialogue._npcName.ToString();
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.DialogueLines.Count - 1 && dialogueObject.HasResponses) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            
        }
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    private void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
