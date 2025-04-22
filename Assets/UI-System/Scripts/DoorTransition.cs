using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DoorTransition : MonoBehaviour
{
    public Image fadeOverlay;
    public float fadeDuration = 1f;
    public string gallerySceneName = "GalleryScene";

    public void OnDoorClicked()
    {
        StartCoroutine(TransitionToGallery());
    }

    IEnumerator TransitionToGallery()
    {
        // Fade to black
        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            fadeOverlay.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, elapsed/fadeDuration));
            yield return null;
        }
        
        SceneManager.LoadScene(gallerySceneName);
    }
}