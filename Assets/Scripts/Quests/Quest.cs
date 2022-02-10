using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Quests
{
    Habiki, Kazou, Rin, Minori
}

public class Quest : MonoBehaviour
{
    [Header("Select a quest")]
    [SerializeField] private Quests quests;
    [SerializeField] float points; //I forgot what should be given after the task is done. Just change it to the name that is better for you.

    [Header("Info about the quest")]
    [SerializeField] private string questInfo;
    [SerializeField] private TextMeshProUGUI questUIText;


    public static bool OnQuest;
    public static bool HabikiOnQuest = false;
    public static bool KazouOnQuest = false;
    public static bool RinOnQuest = false;
    public static bool MinoriOnQuest = false;
    private void Awake()
    {
        questUIText.text = questInfo;

        if (!OnQuest)
            QuestStarted();
        else
            Debug.Log("You have already selected a quest");
    }


    private void QuestStarted()
    {
        OnQuest = true;

        switch (quests)
        {
            case Quests.Habiki:
                HabikiOnQuest = true;
                break;
            case Quests.Kazou:
                KazouOnQuest = true;
                break;
            case Quests.Rin:
                RinOnQuest = true;
                break;
            case Quests.Minori:
                MinoriOnQuest = true;
                break;
            default:
                HabikiOnQuest = false;
                KazouOnQuest = false;
                RinOnQuest = false;
                MinoriOnQuest = false;
                break;
        }
    }
}
