using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SecondGalleryDialogueManager : MonoBehaviour
{
    public static SecondGalleryDialogueManager Instance;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;

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
        StartCoroutine(StartSecondGalleryDialogue());
    }

    public IEnumerator StartSecondGalleryDialogue()
    {
        dialoguePanel.SetActive(true);

        yield return DialogueLine("Player", "Wait, did I do something wrong? What did I do?");
        yield return DialogueLine("Narrator", "No, Prisoner. You successfully managed to retrieve all relevant information.");
        yield return DialogueLine("Player", "What information though?");
        yield return DialogueLine("Narrator", "I cannot tell you what information was gleaned, as it would be–");
        yield return DialogueLine("Player", "[Redacted], yes, I know. You keep saying that. …");
        yield return DialogueLine("Player", "Please?");
        yield return DialogueLine("Narrator", "Please what, Prisoner?");
        yield return DialogueLine("Player", "Please, just tell me something, anything. I feel like I’m going insane here!");

        yield return new WaitForSeconds(1.5f);

        yield return DialogueLine("Narrator", "You talked to the maid, yes?");
        yield return DialogueLine("Player", "A little bit, yes.");

        yield return new WaitForSeconds(1.2f);

        yield return DialogueLine("Narrator", "I shouldn't be saying this, but... she was not a good person, Prisoner. Her and a few others, they were conspiring to… to do some very bad things.");
        yield return DialogueLine("Player", "Like what?");
        yield return DialogueLine("Narrator", "You know I cannot say.");

        // 🎯 New Objective
        yield return DialogueObjective("Enter second painting");

        yield return DialogueLine("Player", "We’re coming back to this conversation.");
        yield return DialogueLine("Narrator", "You can try.");
    }

    private IEnumerator DialogueLine(string speaker, string line)
    {
        nameText.text = speaker;
        dialogueText.text = "";
        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.015f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }

    private IEnumerator DialogueObjective(string text)
    {
        objectivePanel.SetActive(true);
        objectiveText.text = "New Objective: " + text;
        yield return new WaitForSeconds(3f);
        objectivePanel.SetActive(false);
    }
}
