using System;
using UnityEngine;

[Serializable]
public class DialogueLine
{
    public enum NpcName
    {
        Manami, Habiki, Ryo, Narration, Rin //...
    }
    public NpcName _npcName;
    [TextArea(3, 10)]
    [SerializeField] private string _lineText;
    public string LineText
    {
        get => _lineText;
        set => _lineText = value;
    }
}
