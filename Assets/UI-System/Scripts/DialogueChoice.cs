using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueChoice
{
    public string choiceText;
    public List<DialogueLine> resultingDialogue;
}