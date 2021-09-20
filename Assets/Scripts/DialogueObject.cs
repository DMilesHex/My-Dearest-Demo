using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RenameMe", menuName = "DialogueTest/DialogueLine"), Serializable]
public class DialogueObject : ScriptableObject
{
    [SerializeField] private List<DialogueLine> _dialogueLine;
    public List<DialogueLine> DialogueLines
    {
        get => _dialogueLine;
        set => _dialogueLine = value;
    }
}
