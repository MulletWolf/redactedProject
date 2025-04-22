using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueLine", menuName = "Dialogue/Dialogue Line")]
public class DialogueLine : ScriptableObject
{
    [TextArea(2, 5)]
    public string dialogueText;

    public float textSpeed = 0.05f;

    public AudioClip voiceClip;

    // Optional: speaker name, portrait, etc.
    public string speakerName;
    public Sprite speakerPortrait;
    public DialogueLine nextLine;
    public DialogueChoice nextChoice;

    public void ContinueDialogue(DialogueLine nextLine)
{
    if (nextLine != null)
    {
        StartDialogue(nextLine);
    }
    else
    {
        EndDialogue();
    }
}

}
