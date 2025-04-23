using System.Collections.Generic;
using UnityEngine;

public class DialoguesManager : MonoBehaviour
{
    public DialogueSystems dialogueSystem;
    public List<DialogueLine> openingDialogue;

    void Start()
    {
        if (dialogueSystem != null && openingDialogue != null)
        {
            dialogueSystem.StartDialogue(openingDialogue);
        }
    }


    public void HandleObjectInteraction(string objectName)
    {
        switch(objectName)
        {
            case "Desk":
                ExamineDesk();
                break;
            // Add other cases as needed
        }
    }

    void ExamineDesk()
    {
        List<DialogueLine> deskDialogue = new List<DialogueLine>
        {
            new DialogueLine {
                speakerName = "Desk",
                text = "The one thing in the room that seemed to call your name..."
            },
            // Add more lines as needed
        };
        
        dialogueSystem.StartDialogue(deskDialogue);
    }
}