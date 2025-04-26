using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BanquetDialogueManager : MonoBehaviour
{
    public static BanquetDialogueManager Instance;

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
        StartCoroutine(StartBanquetDialogue());
    }

    public IEnumerator StartBanquetDialogue()
    {
        dialoguePanel.SetActive(true);

        yield return DialogueLine("Narrator", "You are uncharacteristically silent, Prisoner. What is going through your head?");
        yield return DialogueLine("Player", "It’s… bright. Loud.");
        yield return DialogueLine("Narrator", "What brilliant observational skills you have there, Prisoner.");
        yield return DialogueLine("Player", "Would you stop calling me Prisoner? I have a name you know.");
        yield return DialogueLine("Narrator", "I know more about your own name than you do, Prisoner. But no, you have lost the privilege of a name.");
        yield return DialogueLine("Player", "So we knew each other before? How? Were we acquaintances? Friends?");
        yield return DialogueLine("Narrator", "That information is [Redacted].");
        yield return DialogueLine("Player", "I have a feeling you are going to be saying that a lot.");
        yield return DialogueLine("Narrator", "You catch on quick.");
        yield return DialogueLine("Player", "Very well then. What are my first orders, Commander?");

        yield return DialogueObjective("Fix chandelier");
        yield return DialogueObjective("Explore surroundings");

        yield return DialogueLine("Player", "Fix the chandelier? What chandelier?");
        yield return DialogueLine("Narrator", "I suggest looking up, Prisoner.");

        // ✨ Mini-game trigger: Chandelier
        // → Activate sparkles and click button to launch chandelier puzzle
        // → Mini-game happens with no dialogue during

        yield return new WaitUntil(() => /* condition: chandelier mini-game is completed */ false); // Replace 'false' with your actual flag
        yield return DialogueLine("Narrator", "Well done.");
        yield return DialogueLine("Player", "Thank the seven flames. What now?");

        yield return DialogueObjective("Bring back the maid");

        yield return DialogueLine("Player", "Bring back? Bring back what?");

        // ✨ Trigger: Sparkles/Arrows guide player to blacked-out maid
        // → Start paint-in mini-game
        // → On completion: replace sprite with colored version

        yield return new WaitUntil(() => /* condition: maid mini-game is completed */ false); // Replace 'false' with your actual flag

        yield return DialogueLine("Maid", "Good, there you are. I’ve been looking for you. Come here, I need you to do something for me.");
        yield return DialogueLine("Player", "Me?");
        yield return DialogueLine("Maid", "Yes, of course you.");
        yield return DialogueLine("Player", "I didn’t realise you could see me.");
        yield return DialogueLine("Maid", "I’m sorry?");
        yield return DialogueLine("Player", "Nothing, never mind.");

        yield return DialogueLine("Narrator", "Okay, okay, that’s enough chatting now. You’ve done what you needed to do, it’s time to leave. We’re running out of time here already.");
        yield return DialogueLine("Player", "What do you mean, 'we’re running out of time'?!");

        // 🎬 Trigger transition to second gallery scene
        // SceneManager.LoadScene("SecondGalleryScene"); // Uncomment if needed

        yield break;
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
