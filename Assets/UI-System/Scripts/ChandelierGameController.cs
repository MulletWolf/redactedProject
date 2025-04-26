using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class ChandelierGameController : MonoBehaviour
{
    public GameObject chandelierGamePanel;
    public ParticleSystem chandelierSparkles;
    public GameObject maidWithSparkles;
    public PrgressManager progressManager; // link your PrgressManager object here
    public GameObject maidSparkleFX;
    private int screwsPlaced = 0;
    public int totalScrewsRequired = 4;

    public void RegisterScrewPlacement()
    {
        screwsPlaced++;

        if (screwsPlaced >= totalScrewsRequired)
        {
            FinishChandelierGame(); // triggers everything: progress, fade, sparkles
        }
    }

    public void FinishChandelierGame()
    {
        // 1. Update progress
        progressManager.AddProgress();

        // 2. Fade out chandelier game 
        StartCoroutine(FadeOutChandelierPanel());

        // 3. Stop sparkles 2 seconds after fade
        Invoke(nameof(StopChandelierSparkles), 2f);

        // 4. Start maid sparkles
        maidWithSparkles.SetActive(true);
    }

    IEnumerator FadeOutChandelierPanel()
    {
        CanvasGroup cg = chandelierGamePanel.GetComponent<CanvasGroup>();
        if (cg != null)
        {
            float duration = 1f;
            float t = 0;
            while (t < duration)
            {
                t += Time.deltaTime;
                cg.alpha = 1 - t / duration;
                yield return null;
            }
            chandelierGamePanel.SetActive(false);
        }
        else
        {
            chandelierGamePanel.SetActive(false); // fallback
        }
    }

    public void OnCloseChandelier()
    {
        chandelierGamePanel.SetActive(false);
        maidSparkleFX.SetActive(true);
    }
    void StopChandelierSparkles()
    {
        if (chandelierSparkles != null)
        {
            chandelierSparkles.Stop();
        }
    }
}
