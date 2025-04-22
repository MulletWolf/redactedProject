using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GallerySceneController : MonoBehaviour
{
    [Header("Curtain States")]
    public GameObject closedCurtainsPanel;
    public GameObject openingAnimationPanel;
    public GameObject openedCurtainsPanel;
    public GameObject frontViewPanel;
    
    [Header("Media")]
    public VideoPlayer curtainOpeningVideo;
    public Image fadeOverlay;
    public float fadeDuration = 1f;

    void Start()
    {
        // Start with only closed curtains visible
        closedCurtainsPanel.SetActive(true);
        openingAnimationPanel.SetActive(false);
        openedCurtainsPanel.SetActive(false);
        frontViewPanel.SetActive(false);
        
        // Set up video completion callback
        curtainOpeningVideo.loopPointReached += OnVideoFinished;
    }

    // Called when clicking the closed curtains
    public void OnClosedCurtainsClicked()
    {
        closedCurtainsPanel.SetActive(false);
        openingAnimationPanel.SetActive(true);
        curtainOpeningVideo.Play();
    }

    // Called when video finishes playing
    void OnVideoFinished(VideoPlayer vp)
    {
        StartCoroutine(TransitionToOpenedCurtains());
    }

    IEnumerator TransitionToOpenedCurtains()
    {
        openingAnimationPanel.SetActive(false);
        openedCurtainsPanel.SetActive(true);
        
        // Fade in effect
        CanvasGroup cg = openedCurtainsPanel.GetComponent<CanvasGroup>();
        if (cg == null) cg = openedCurtainsPanel.AddComponent<CanvasGroup>();
        
        cg.alpha = 0;
        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0, 1, elapsed/fadeDuration);
            yield return null;
        }
    }

    // Called when clicking the opened curtains
    public void OnOpenedCurtainsClicked()
    {
        StartCoroutine(TransitionToFrontView());
    }

    IEnumerator TransitionToFrontView()
    {
        // Fade out opened curtains
        CanvasGroup cg = openedCurtainsPanel.GetComponent<CanvasGroup>();
        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1, 0, elapsed/fadeDuration);
            yield return null;
        }
        
        openedCurtainsPanel.SetActive(false);
        frontViewPanel.SetActive(true);
        
        // Fade in front view
        cg = frontViewPanel.GetComponent<CanvasGroup>();
        if (cg == null) cg = frontViewPanel.AddComponent<CanvasGroup>();
        
        cg.alpha = 0;
        elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0, 1, elapsed/fadeDuration);
            yield return null;
        }
    }

    // Called when clicking the miniature painting
    public void OnMiniaturePaintingClicked()
    {
        StartCoroutine(TransitionToBanquet());
    }

    IEnumerator TransitionToBanquet()
    {
        // Fade to black
        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeOverlay.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, elapsed/fadeDuration));
            yield return null;
        }
        
        SceneManager.LoadScene("TheBanquet");
    }
}