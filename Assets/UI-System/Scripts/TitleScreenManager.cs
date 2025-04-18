using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class TitleScreenManager : MonoBehaviour {
    public TMP_Text startButton;
    public TMP_Text galleryButton;
    public float buttonDelay = 2f; // Seconds to wait before showing buttons

    void Start() {
        // Hide buttons initially
        startButton.gameObject.SetActive(false);
        galleryButton.gameObject.SetActive(false);

        // Show buttons after delay
        Invoke("ShowButtons", buttonDelay);
    }

    void ShowButtons() {
        StartCoroutine(FadeInButton(startButton));
        StartCoroutine(FadeInButton(galleryButton));
    }

    IEnumerator FadeInButton(TMP_Text button) {
        button.gameObject.SetActive(true);
        CanvasGroup cg = button.GetComponent<CanvasGroup>();
        if (cg == null) cg = button.gameObject.AddComponent<CanvasGroup>();

        float duration = 1f;
        float elapsed = 0f;
        cg.alpha = 0f;

        while (elapsed < duration) {
            cg.alpha = Mathf.Lerp(0f, 1f, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cg.alpha = 1f;
    }

    // Button click functions
    public void OnStartClicked() {
        SceneManager.LoadScene("TowerZoomIn"); 
    }

    public void OnGalleryClicked() {
        SceneManager.LoadScene("GalleryScreen"); 
    }
}