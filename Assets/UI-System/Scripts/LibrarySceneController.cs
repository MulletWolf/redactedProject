using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LibrarySceneController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject[] dialogueButtons;
    public GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;

    private int dialogueIndex = 0;

    private string[] dialogueLines = new string[]
    {
        "Narrator: There is a low hum of chatter throughout the common area of The Archives. Barely contained whispers. This is the main hub of activity within the sizable Library, and there is an edge of anxiety permeating through the air. The Head Scribe will be making an appearance.",
        "???: Novice, a word? I have some tasks that need to be carried out before the arrival of the Head Scribe.",
        "Player: Straight into it I see",
        "Narrator: It’s a fast paced environment.",
        "Library Attendant: Novice-",
        "Player: Hello sir",
        "Library Attendant: yes hello- seven flames this desk is a mess, he will not approve- I have a few tasks I need taken care of, the fourth year’s qualifying exams are tomorrow and it is utter bedlam.",
        "Player: Oh- Oh yeah I… remember the pain well?",
        "Library Attendant: As do I, even if it was decades ago on my part... quite uncouth.",
        "Player: Uncouth as the Seven Flames.",
        "Library Attendant: Indeed. Anyways, enough babbling...", 
        "Library Attendant: There is a stack of books that need to be logged and checked in to your left, see to it that it is done...",
        "Player: I understand sir. I will find them.",
        "Narrator: New Objective: check in books\nNew Objective: Organise Bookshelf\nNew Objective: find 0/3 Tomes.",
        "Player: guess I better get started!",
        "Library Attendant nods stiffly and leaves.",
        "Player: I think I prefer the banquet painting",
        "Narrator: Do not speak so loud Prisoner, someone will hear you.",
        "Player: Fine. Best finish these tasks then."
    };

    void Start()
    {
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        if (dialogueIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[dialogueIndex];
            dialogueIndex++;

            // Example branching logic:
            if (dialogueText.text.Contains("Objective: check in books"))
            {
                objectivePanel.SetActive(true);
                objectiveText.text = "✔ Check in books\n✔ Organise bookshelf\n✔ Find 0/3 Tomes";
                EnableButton(0); // Show button to start book check-in mini-game
            }
            else if (dialogueText.text.Contains("Best finish these tasks then."))
            {
                EnableButton(1); // Organise bookshelf button
            }
            else
            {
                DisableAllButtons();
            }
        }
    }

    public void EnableButton(int index)
    {
        for (int i = 0; i < dialogueButtons.Length; i++)
        {
            dialogueButtons[i].SetActive(i == index);
        }
    }

    public void DisableAllButtons()
    {
        foreach (GameObject button in dialogueButtons)
        {
            button.SetActive(false);
        }
    }

    public void OnBookCheckInPressed()
    {
        dialogueText.text = "Player: One Tome down, two to go! I think I’m getting the hang of this shtick!";
        // You can also add game logic for mini-games here
    }

    public void OnOrganiseBooksPressed()
    {
        dialogueText.text = "Player: I think when I get out of here, I’m going to try to become a Scribe. Or professional Bookshelf Organiser. Whichever is easier.";
    }

    public void OnEnterOfficePressed()
    {
        dialogueText.text = "Narrator: Do not look in there Prisoner, the Tome will not be in there\nPlayer: Why are you being so cagey?";
    }

    public void OnPickUpTomePressed()
    {
        dialogueText.text = "You pick up the Tome, finally completing your tasks, but before you can register anything else, you see a scrap of warm-toned paper.";
        objectiveText.text = "✔ Explore the office?";
    }
}
