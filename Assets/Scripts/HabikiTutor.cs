using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabikiTutor : MonoBehaviour
{
    public DialogueUI ui;
    public bool tutorQuestDone;
    public DialogueActivator da;
    public GameObject tutorButtons;

    public void RightAnswers()
    {
        tutorQuestDone = true;
        tutorButtons.SetActive(false);
    }

    public void WrongAnswers()
    {
        tutorQuestDone = true;
        da.pop -= 5;
        tutorButtons.SetActive(false);
    }
}
