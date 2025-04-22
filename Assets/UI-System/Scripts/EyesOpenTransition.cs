using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class EyesOpenTransition : MonoBehaviour
{
    public Image eyesImage;
    public float fadeDuration = 1f;
    public float displayTime = 5f;

    void Start()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        // Wait for display time
        yield return new WaitForSeconds(displayTime);
        
        // Fade out
        float elapsed = 0;
        Color color = eyesImage.color;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, elapsed / fadeDuration);
            eyesImage.color = color;
            yield return null;
        }
        
        // Load next scene
        SceneManager.LoadScene("MainRoomScene");
    }
}