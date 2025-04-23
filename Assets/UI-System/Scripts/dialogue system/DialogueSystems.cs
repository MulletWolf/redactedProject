using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueSystems : MonoBehaviour
{
    public static DialogueSystems Instance { get; private set; }

    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI characterText;
    public GameObject objectivesPanel;
    public GameObject choicesPanel;
    public GameObject choiceButtonPrefab;
    
    [Header("Settings")]
    public float typewriterSpeed = 0.05f;
    public int maxCharsBeforeFade = 100;
    public float fadeDuration = 0.5f;

    private Coroutine typingCoroutine;
    private List<DialogueLine> currentDialogueLines;
    private int currentLineIndex;
    private bool isTyping = false;

    void Start()
    {
        // Initialize with empty text
        dialogueText.text = "";
        characterText.text = "";
        
        // Hide choices panel by default
        if (choicesPanel != null) choicesPanel.SetActive(false);
    }

    public void StartDialogue(List<DialogueLine> dialogueLines)
    {
        currentDialogueLines = dialogueLines;
        currentLineIndex = 0;
        characterText.text = "";
        dialogueText.text = "";
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = currentDialogueLines[currentLineIndex].text;
            isTyping = false;
            return;
        }

        if (currentLineIndex < currentDialogueLines.Count)
        {
            DialogueLine currentLine = currentDialogueLines[currentLineIndex];
            characterText.text = currentLine.speakerName;
            
            if (currentLine.isChoice)
            {
                ShowChoices(currentLine.choices);
            }
            else
            {
                typingCoroutine = StartCoroutine(TypeText(currentLine.text));
                currentLineIndex++;
            }
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        int charCount = 0;
        
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            charCount++;
            
            if (charCount >= maxCharsBeforeFade)
            {
                yield return StartCoroutine(FadeText());
                dialogueText.text = "";
                charCount = 0;
            }
            
            yield return new WaitForSeconds(typewriterSpeed);
        }
        
        isTyping = false;
    }

    IEnumerator FadeText()
    {
        float elapsedTime = 0f;
        Color originalColor = dialogueText.color;
        
        // Fade out
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            dialogueText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Fade in
        elapsedTime = 0f;
        dialogueText.text = "";
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            dialogueText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueText.text = "";
        characterText.text = "";
        // Add any cleanup or next steps here
    }

    public void ShowChoices(List<DialogueChoice> choices)
    {
        if (choicesPanel == null) return;
        
        // Clear existing choices
        foreach (Transform child in choicesPanel.transform)
        {
            Destroy(child.gameObject);
        }
        
        // Create new choice buttons
        foreach (DialogueChoice choice in choices)
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choicesPanel.transform);
            buttonObj.SetActive(true);
            
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.choiceText;
            
            Button btnComponent = buttonObj.GetComponent<Button>();
            btnComponent.onClick.AddListener(() => OnChoiceSelected(choice));
        }
        
        choicesPanel.SetActive(true);
    }

    private void OnChoiceSelected(DialogueChoice choice)
    {
        Debug.Log("Choice selected: " + choice);
        choicesPanel.SetActive(false);
        StartDialogue(choice.resultingDialogue);
        // Handle choice selection here
    }

    // Add these to the DialogueSystem class
    public void HandleObjectClick(string objectName)
    {
        switch(objectName)
        {
            case "Desk":
                FindAnyObjectByType<MainRoomDialogue>().ExamineDesk();
                break;
            case "GreenDoor":
                FindAnyObjectByType<MainRoomDialogue>().ExamineGreenDoor();
                break;
            case "Mirror":
                FindAnyObjectByType<MainRoomDialogue>().ExamineMirror();
                break;
            // Add other objects as needed
        }
    }

public void LoadScene(string sceneName)
{
    if (!string.IsNullOrEmpty(sceneName))
    {
        SceneManager.LoadScene(sceneName);
    }
}
}


