using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalleryDialogueManager : MonoBehaviour
{
    public static GalleryDialogueManager Instance;

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
        StartCoroutine(StartIntroDialogue());
    }

    public IEnumerator StartIntroDialogue()
    {
        dialoguePanel.SetActive(true);

        yield return DialogueLine("Player", "Oh, this is actually quite nice. Dark, but nice. I don't see any paintings though.");
        yield return DialogueLine("Narrator", "They're behind curtains to protect from sunlight.");
        yield return DialogueLine("Player", "I didn't know the sun was bad for paintings.");
        yield return DialogueLine("Narrator", "The sun is bad for most things if you give it the time. It will eventually eat away and depreciate everything. There is no escaping it.");
        yield return DialogueLine("Player", "How kind of you then to keep me so far from it. You must care for me deeply.");
        yield return DialogueLine("Narrator", "….");
        // 🎯 New Objective
        yield return DialogueObjective("Inspect first Painting");
        yield return DialogueLine("Narrator", "Open the curtain.");
        yield return new WaitForSeconds(1.5f);
        yield return DialogueLine("Player", "It looks like a… a banquet?");
        yield return DialogueLine("Narrator", "Correct.");
        yield return DialogueLine("Player", "… And what do I do with this painting of a banquet? I'll admit It's a very nice painting, do you want me to just marvel at it? Clean it? Tell it my secrets?");
        yield return DialogueLine("Narrator", "What secrets? You have no memory to impart them onto me, or am I wrong?");
        yield return DialogueLine("Player", "Salt in the wound Omnipotent voice, salt in the wound.");
        yield return DialogueLine("Narrator", "Just– be quiet and put your hand to the painting.");
        yield return DialogueLine("Player", "I thought you're not supposed to touch artwork–");
        yield return DialogueLine("Narrator", "Do it, Prisoner, lest I believe that you are rethinking your decision.");
        yield return DialogueLine("Player", "I wouldn't dream of it.");
        yield return new WaitForSeconds(1.5f);
        

        
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
