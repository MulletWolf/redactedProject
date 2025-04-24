using System.Collections;
using UnityEngine;

public class EndCreditsManager : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public CanvasGroup panel1Group;
    public CanvasGroup panel2Group;

    public float fadeDuration = 1f;
    public float delayBeforeNext = 3f;

    private void Start()
    {
        // Ensure both start in the right state
        panel1Group.alpha = 1f;
        panel1.SetActive(true);

        panel2Group.alpha = 0f;
        panel2.SetActive(false);

        StartCoroutine(PlayCredits());
    }

    IEnumerator PlayCredits()
    {
        // Show panel 1
        yield return new WaitForSeconds(delayBeforeNext);

        // Fade out panel 1
        yield return StartCoroutine(FadeCanvasGroup(panel1Group, 1, 0));
        panel1.SetActive(false);

        // Fade in panel 2
        panel2.SetActive(true);
        yield return StartCoroutine(FadeCanvasGroup(panel2Group, 0, 1));

        // Wait for full typewriter to finish (e.g., 10s — adjust as needed)
        yield return new WaitForSeconds(10f);

        // Optional: go to title screen
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreenScene");
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            cg.alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cg.alpha = end;
    }
}
