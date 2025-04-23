using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainRoomDialogue : MonoBehaviour
{
    public DialogueSystems dialogueSystem;
    
    private List<DialogueLine> sceneDialogue = new List<DialogueLine>();
    private int deathChoiceIndex = -1;
    private bool hasDiedOnce = false;

    void Start()
    {
        InitializeDialogue();
        dialogueSystem.StartDialogue(sceneDialogue);
    }

    void InitializeDialogue()
    {
        // Opening sequence
        AddLine("Player", "*Waking up sounds*");
        AddLine("Player", "Urghhh.");
        AddLine("Player", "Where… Where.. Where Am I?");
        AddLine("System", "New Objective: Explore surroundings?");
        AddLine("Player", "What is this place?");
        AddLine("Narrator", "a prison, I would expect.");
        AddLine("System", "*begin clicking stuff*");
        
        // Object examination lines would be triggered by clicking objects in the room
        // We'll implement those separately
    }

    // Call this when player examines the desk
    public void ExamineDesk()
    {
        List<DialogueLine> deskLines = new List<DialogueLine>();
        deskLines.Add(new DialogueLine() {
            speakerName = "Desk",
            text = "The one thing in the room that seemed to call your name the most. The quill is familiar in your hand. The smell of parchment is welcome. This room is not yours and neither was this desk, but in absence of a past, this is the closest thing to a home you have."
        });
        deskLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "A journal? It's empty. Is it for me then?"
        });
        deskLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "..."
        });
        deskLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "well then, I might as well put my name in- my name- my name- ... what is my name?"
        });
        deskLines.Add(new DialogueLine() {
            speakerName = "Narrator",
            text = "how cute."
        });
        deskLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "Are my inside thoughts supposed to be this loud? And condescending?"
        });
        
        dialogueSystem.StartDialogue(deskLines);
    }

    // Call this when player examines the green door
    public void ExamineGreenDoor()
    {
        List<DialogueLine> doorLines = new List<DialogueLine>();
        doorLines.Add(new DialogueLine() {
            speakerName = "Gallery Door",
            text = "You may not enter the Gallery at this time."
        });
        doorLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "Maybe it's for the best, it looks pretty scratched up. I don't want to know what they're keeping behind there."
        });
        doorLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "Chipped as it may be, that is a very nice shade of green."
        });
        
        dialogueSystem.StartDialogue(doorLines);
    }

    // Call this when player examines the mirror (last object)
    public void ExamineMirror()
    {
        List<DialogueLine> mirrorLines = new List<DialogueLine>();
        mirrorLines.Add(new DialogueLine() {
            speakerName = "Mirror",
            text = "Maybe I'll be able to see what I look like- no, It's broken. Of course. A broken mirror. Great."
        });
        mirrorLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "The shards are still there, maybe I could use them to key a lock or something?"
        });
        mirrorLines.Add(new DialogueLine() {
            speakerName = "System",
            text = "New Objective: Find a way out?"
        });
        mirrorLines.Add(new DialogueLine() {
            speakerName = "Narrator",
            text = "Don't be an idiot, prisoner. There is no way out."
        });
        mirrorLines.Add(new DialogueLine() {
            speakerName = "System",
            text = "(Objective disappears)"
        });
        mirrorLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "Woah- who said that?"
        });
        mirrorLines.Add(new DialogueLine() {
            speakerName = "Narrator",
            text = "..."
        });
        mirrorLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "I thought I was hearing something the first time, but you definitely said something just there. I know it."
        });
        
        // First dialogue choice
        DialogueLine choiceLine = new DialogueLine() {
            speakerName = "Player",
            text = "",
            isChoice = true,
            choices = new List<string>() {
                "Don't be shy, fleshless voice within the walls, you have nothing to fear from me",
                "Pspspspspspspsps…",
                "Please?"
            }
        };
        
        dialogueSystem.StartDialogue(mirrorLines);
        dialogueSystem.ShowChoices(choiceLine.choices);
    }


    // Call this when a choice is selected
    public void OnChoiceSelected(int choiceIndex)
    {
        if (deathChoiceIndex != -1 && choiceIndex == deathChoiceIndex)
        {
            List<DialogueLine> deathLines = new List<DialogueLine>();
            deathLines.Add(new DialogueLine() {
                speakerName = "Narrator",
                text = "All right then."
            });
            deathLines.Add(new DialogueLine() {
                speakerName = "System",
                text = "*instant death scene*"
            });
            deathLines.Add(new DialogueLine() {
                speakerName = "Player",
                text = "Wait, what?"
            });
            deathLines.Add(new DialogueLine() {
                speakerName = "Player",
                text = "What in the seven flames- Voice? Voice, I was joking, I was Joking! I was just making a funny joke, hahaha-- so funny, please, please, don't let me die like this I want to go back-- let me go back"
            });
            deathLines.Add(new DialogueLine() {
                speakerName = "Narrator",
                text = "You wish to recount on your previous decision?"
            });
            deathLines.Add(new DialogueLine() {
                speakerName = "Player",
                text = "Yes! Yes! I do- just please let me-"
            });
            deathLines.Add(new DialogueLine() {
                speakerName = "Narrator",
                text = "Excellent. Let's try this again shall we?",
                nextScene = "MainRoom"
            });
            
            dialogueSystem.StartDialogue(deathLines);
            hasDiedOnce = true;
        }
        else
        {
            ContinueAfterChoice(choiceIndex);
        }
    }
    void ContinueAfterChoice(int choiceIndex)
    {
        List<DialogueLine> responseLines = new List<DialogueLine>();
        
        responseLines.Add(new DialogueLine() {
            speakerName = "Narrator",
            text = "You're quite pathetic, you know that?"
        });
        responseLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "I knew you weren't a hallucination!"
        });
        responseLines.Add(new DialogueLine() {
            speakerName = "Narrator",
            text = "I wouldn't be too sure on that prisoner, after all, there is no one else here to confirm."
        });
        responseLines.Add(new DialogueLine() {
            speakerName = "Player",
            text = "Nor anyone else to deny, so if you don't mind, I think I'll choose to believe that I am perfectly sane, and you are a very real, albeit non-diegetic, helping hand in my current struggles."
        });
        responseLines.Add(new DialogueLine() {
            speakerName = "Narrator",
            text = "Who said I was here to help you? I could be your tormentor, your torturer, met out all of your pain and suffering within these walls."
        });
        
        // Second dialogue choice
        DialogueLine secondChoice = new DialogueLine() {
            speakerName = "Player",
            text = "",
            isChoice = true,
            choices = new List<string>() {
                "Did you do the decor?",
                "You could be both"
            }
        };
        
        if (hasDiedOnce)
        {
            // Remove "I choose death" option if we've died once
            secondChoice.choices.Add("What do I need to do?");
        }
        else
        {
            secondChoice.choices.Add("I choose death");
            deathChoiceIndex = secondChoice.choices.Count - 1;
        }
        
        dialogueSystem.StartDialogue(responseLines);
        dialogueSystem.ShowChoices(secondChoice.choices);
    }

    void AddLine(string speakerName, string text)
    {
        sceneDialogue.Add(new DialogueLine() {
            speakerName = speakerName,
            text = text
        });
    }
}