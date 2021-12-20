using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text nameText;

    private TypewriterEffect typewriterEffect;
    private ResponseHandler responseHandler;

    public List<DialogueActivator> dialogueActivator;

    [SerializeField] private RepMeter rm;
    public player pl;
    public Image portrait;
    public GameObject portraitContainer;
    

    public bool isOpen { get; private set; }

    private void Start()
    {
        
        

        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        
        
    }

    public void ShowDialogue(DialogueObject dialogueObject, int index)
    {
        
        isOpen = true;
        dialogueBox.SetActive(true);
        ClubRep(index);
        StartCoroutine(StepThroughDialogue(dialogueObject, index));
    }

    
    public void ClubRep(int index)
    {
        dialogueActivator[index].rep += 5;


    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject, int index)
    {
        if (pl.canGainRep && dialogueObject.RepFactor != 0)
        {
            dialogueActivator[index].rep += dialogueObject.RepFactor + pl.repIncrease;
            rm.ChangeRep(dialogueActivator[index].rep);
        }
        if (dialogueObject.Target != null)
            dialogueObject.Target.pop += dialogueObject.StudentPop;

        for (int i = 0; i < dialogueObject.DialogueLines.Count; i++)
        {
            
            DialogueLine dialogue = dialogueObject.DialogueLines[i];
            nameText.text = dialogue._npcName.ToString();
            if (dialogue.portrait != null)
            {
                portraitContainer.SetActive(true);
                portrait.sprite = dialogue.portrait;
            }
            else
            {
                
                portraitContainer.SetActive(false);
            }
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.DialogueLines.Count - 1 && dialogueObject.HasResponses) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            
        }
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses, index);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    public void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
