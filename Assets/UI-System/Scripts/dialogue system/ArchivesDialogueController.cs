using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArchivesDialogueController : MonoBehaviour
{
    public static ArchivesDialogueController Instance;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;
    public GameObject librarian;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    private void Start()
    {
        StartCoroutine(StartIntroDialogue());
    }

    public IEnumerator StartIntroDialogue()
    {
        dialoguePanel.SetActive(true);

        // 🎯 Objective: Explore Vice-Scribe's office?
        yield return DialogueObjective("Explore Vice-Scribe's office");
        yield return new WaitForSeconds(1.5f);
        yield return DialogueLine("Narrator", "The room is locked, Prisoner, I do not see how you could get in there-");
        yield return DialogueLine("Player", "...");
        // 📌 Trigger: Button - "Enter Office?"
        yield return DialogueLine("Narrator", "Do not look in there Prisoner, there is nothing of importance in there.");
        yield return DialogueLine("Player", "Why are you being so cagey?");
        yield return DialogueLine("Narrator", "You know nothing about where you are. I am your guide, so you shall listen to me.");
        yield return new WaitForSeconds(1.5f);

        

        // 🎯 Objective: Explore the office?
        yield return DialogueObjective("Explore the office?");

        // 🎬 Trigger: Go to black screen / enter inventory
        // (No line, just comment for implementation)

        // 🖼️ Clickables: Use as hover or pre-interaction text
        // Optional ambient dialogue for exploring
        librarian.SetActive(true);
        yield return DialogueLine("Librarian", "The Office of the Head Scribe's second is not open to visitors at this time, only Scribes may enter");
        yield return DialogueLine("Librarian", "Who are you anyways? How did you get in here");
        yield return DialogueLine("Player", "Oh! The voice brought me here");
        yield return DialogueLine("Librarian", "What voice? What are you talking about?");
        // 🎬 Ending Dialogue
        yield return DialogueLine("Narrator", "No. That's enough.");
        yield return DialogueLine("Player", "What?");
        yield return DialogueLine("Narrator", "I said that's enough for now!");
        
    }

    private IEnumerator DialogueLine(string speaker, string line)
    {
        nameText.text = speaker;
        dialogueText.text = "";
        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(.5f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }



    private IEnumerator DialogueObjective(string text)
    {
        objectivePanel.SetActive(true);
        objectiveText.text = "New Objective: " + text;
        yield return new WaitForSeconds(5f);
        objectivePanel.SetActive(false);
    }
}
