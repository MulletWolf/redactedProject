using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class TypewriterEffect : MonoBehaviour {
    public bool IsFinished { get; private set; }

    [SerializeField] private float typingSpeed = 0.05f; // Delay between characters
    private TMP_Text prologueText;
    private string fullText;

    void Start() {
        prologueText = GetComponent<TMP_Text>();
        fullText = prologueText.text; // Store the complete text
        prologueText.text = ""; // Clear the text initially
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText() {
        foreach (char c in fullText) {
            prologueText.text += c; // Add one character at a time
            yield return new WaitForSeconds(typingSpeed); // Pause between characters
        }
        
        // After typing finishes, wait 2 seconds, then fade out
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() {
        CanvasGroup canvasGroup = GetComponentInParent<CanvasGroup>();
        if (canvasGroup == null) {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        float fadeDuration = 1.5f; // Duration of fade-out
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration) {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;
        
        // Load the title screen after fade-out
        SceneManager.LoadScene("TitleScreen"); // Replace with your scene name
    }
}
