using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialoguesManager : MonoBehaviour {
    public TMP_Text characterNameTMP;
    public TMP_Text dialogueTextTMP;
    public CanvasGroup dialoguePanel;
    public GameObject choicePanel; // holds buttons
    public float fadeDuration = 0.3f;
    public float typingSpeed = 0.03f;
    public string speaker;
    public string line;
    private Coroutine typingCoroutine;
    public string choiceText;
    public int nextLineIndex;
    void Awake()
    {
        HideDialogueUIInstant(); // Hide at start of ANY scene
    }

    public void HideDialogueUIInstant()
    {
        StopAllCoroutines(); // cancel fades/typing
        dialoguePanel.alpha = 0;
        dialoguePanel.gameObject.SetActive(false);
        choicePanel.SetActive(false);
    }

    public void ShowDialogueUIInstant()
    {
        dialoguePanel.alpha = 1;
        dialoguePanel.gameObject.SetActive(true);
    }

    public IEnumerator StartDialogueDelayed(DialogueLine line, float delay = 2f)
    {
        HideDialogueUIInstant();
        yield return new WaitForSeconds(delay);
        StartDialogue(line); // will fade in automatically
    }

    public void StartDialogue(DialogueLine line) {
        StopAllCoroutines();
        StartCoroutine(FadeInPanel());
        UpdateSpeaker(line.speakerName);
        typingCoroutine = StartCoroutine(TypeText(line.dialogueText));
    }

    IEnumerator FadeInPanel() {
        dialoguePanel.alpha = 0;
        dialoguePanel.gameObject.SetActive(true);
        while (dialoguePanel.alpha < 1) {
            dialoguePanel.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }

    IEnumerator FadeOutPanel() {
        while (dialoguePanel.alpha > 0) {
            dialoguePanel.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }
        dialoguePanel.gameObject.SetActive(false);
    }

    void UpdateSpeaker(string newName) {
        if (characterNameTMP.text != newName) {
            StartCoroutine(FadeSpeakerName(newName));
        }
    }

    IEnumerator FadeSpeakerName(string newName) {
        float t = 0;
        while (t < fadeDuration) {
            characterNameTMP.alpha = 1 - (t / fadeDuration);
            t += Time.deltaTime;
            yield return null;
        }
        characterNameTMP.text = newName;
        t = 0;
        while (t < fadeDuration) {
            characterNameTMP.alpha = t / fadeDuration;
            t += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator TypeText(string text) {
        dialogueTextTMP.text = "";
        foreach (char c in text) {
            dialogueTextTMP.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        // Optional: wait for input or auto continue
    }

    public void ShowChoices(List<DialogueChoice> choices) {
        choicePanel.SetActive(true);
        // populate buttons
    }

    public void EndDialogue() {
        StartCoroutine(FadeOutPanel());
    }


}
