using UnityEngine;
using TMPro;

public class DialogueOverlay : MonoBehaviour
{
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;

    public void DisplayDialogue(DialogueLine line)
    {
        speakerText.text = line.speakerName;
        dialogueText.text = line.text;
    }
}