using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScrewFailHandler : MonoBehaviour
{
    public float failTime = 2.5f;
    private bool isCountingDown = false;

    public void StartFailCountdown()
    {
        if (!isCountingDown)
            StartCoroutine(FailRoutine());
    }

    private System.Collections.IEnumerator FailRoutine()
    {
        isCountingDown = true;
        yield return new WaitForSeconds(failTime);

        // Kick out of painting
        Debug.Log("Fail: Kicking player out...");
        SceneManager.LoadScene("GalleryScene"); // change to your gallery scene name
    }
}
