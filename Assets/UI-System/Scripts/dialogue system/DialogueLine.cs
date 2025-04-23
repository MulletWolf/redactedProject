using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class DialogueLine
{
    public string speakerName; // "Player", "Narrator", or object name
    public string text;
    public bool isChoice = false;
    public List<string> choices; // Only used if isChoice is true
    public string nextScene; // Scene to load after this line (optional)
}

