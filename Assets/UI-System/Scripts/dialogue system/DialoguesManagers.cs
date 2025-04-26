using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialoguesManagers : MonoBehaviour
{
    public static DialoguesManagers Instance;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject choicePanel;
    public Button choiceButtonPrefab;
    public GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;
    public GameObject InstantDeathPanel;

    private bool choiceMade = false;
    private int selectedChoiceIndex = -1;

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

        yield return ShowLine("Player", "Urghhh.");
        yield return ShowLine("Player", "Where… Where..  Where Am I?");
        yield return ShowObjective("Explore surroundings?");

        yield return ShowLine("Player", "What is this place?");
        yield return ShowLine("Narrator", "A prison, I would expect.");
        yield return ShowLine("Narrator", "Take a look around, you're going to be here awhile.");
        yield return new WaitForSeconds(5f);

        // You can insert item clicking text like this:
        yield return ShowLine("Narrator", "How about you start with the desk?");
        yield return new WaitForSeconds(1.5f);
        yield return ShowLine("Player", "A journal? It’s empty. Is it for me then?");
        yield return ShowLine("Player", "...");
        yield return ShowLine("Player", "Well then, I might as well put my name in– my name– my name– … what is my name?");
        

        yield return ShowLine("Narrator", "How cute. It thinks it has a name.");
        yield return ShowLine("Player", "Are my inside thoughts supposed to be this loud? And condescending?");

        yield return ShowLine("Narrator", "How about trying the doors?");
        yield return new WaitForSeconds(5f);
        yield return ShowLine("", "You cannot enter the gallery at this time.");
        yield return ShowLine("", "Locked. You cannot leave.");
        yield return ShowLine("Player", "Maybe I can kick it? Who Am I kidding?");
        yield return ShowLine("Player", "Maybe there’s a key somewhere?");

        yield return ShowLine("Narrator", "ooh. There's a mirror too.");
        yield return ShowLine("", "Maybe I’ll be able to see what I look like– no, It’s broken. Of course.");

        yield return ShowObjective("Find a way out?");
        yield return new WaitForSeconds(1.5f);
        yield return ShowLine("Narrator", "Don’t be an idiot, prisoner. There is no way out.");
        objectivePanel.SetActive(false);

        yield return ShowLine("Player", "Woah- who said that?");
        yield return ShowLine("Narrator", "...");
        yield return ShowLine("Player", "I thought I was hearing something the first time, but you definitely said something...");

        yield return ShowLine("Narrator", "You’re quite pathetic, you know that?");
        yield return ShowLine("Player", "I knew you weren’t a hallucination!");

        yield return ShowLine("Narrator", "I wouldn’t be too sure on that, prisoner...");
        yield return ShowLine("Player", "Let me out of here!");
        yield return ShowLine("Narrator", "You’re Inconsolable.");
        yield return ShowLine("Player", "I try my best...");

        yield return ShowLine("Narrator", "You have two choices. Either do as you're told, or face death.");
        yield return ShowLine("Player", "What a selection.");
        yield return ShowLine("Narrator", "You are a prisoner, prisoner...");
        yield return ShowLine("Narrator", "So, what do you choose?");
        yield return ShowLine("Player", "Death");
        
        yield return ShowLine("Narrator", "All right then.");
        InstantDeathPanel.SetActive(true);
        yield return ShowLine("Player", "Wait, what?");
        yield return ShowLine("Player", "Voice? I was joking!");
        yield return ShowLine("Narrator", "You wish to recount on your previous decision?");
        yield return ShowLine("Player", "Yes! Yes I do!");
        yield return ShowLine("Narrator", "Excellent. Let's try this again shall we?");
        InstantDeathPanel.SetActive(false);
        

        yield return ShowLine("Narrator", "Excellent choice...");
        yield return ShowLine("Player", "And how exactly am I meant to do that?");
        yield return ShowLine("Narrator", "Through the paintings of course.");
        yield return ShowLine("Player", "Through the what?");
        yield return ShowObjective("Enter the Gallery by clicking the green door");

        yield return new WaitForSeconds(1f);
        
    }

    private IEnumerator ShowLine(string speaker, string line)
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



    private IEnumerator ShowObjective(string text)
    {
        objectivePanel.SetActive(true);
        objectiveText.text = "New Objective: " + text;
        yield return new WaitForSeconds(3f);
        objectivePanel.SetActive(false);
    }
}
