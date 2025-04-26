using System.Collections;
using TMPro;
using UnityEngine;
//using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject dialogueBox; // Scroll-like UI container
    public TextMeshProUGUI dialogueText;
    public float textSpeed = 0.05f;
    public bool isGlitchEnabled = false;

    private string currentDialogue;
    //private bool isTyping = false;

    void Start()
    {
        dialogueBox.SetActive(false); // Hide on start
    }

    public void ShowDialogue(string text)
    {
        currentDialogue = text;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeText());
    }

    public void HideDialogue()
    {
        StopAllCoroutines();
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }

    IEnumerator TypeText()
    {
        //isTyping = true;
        dialogueText.text = "";

        foreach (char letter in currentDialogue)
        {
            if (isGlitchEnabled && Random.value > 0.8f) // Random chance to glitch
            {
                dialogueText.text += "#"; 
                yield return new WaitForSeconds(textSpeed / 2);
                dialogueText.text = dialogueText.text.Remove(dialogueText.text.Length - 1); // Remove glitch
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
     //   isTyping = false;
    }

    public void EnableGlitchEffect(bool enable)
    {
        isGlitchEnabled = enable;
    }
}
