using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TowerZoom : MonoBehaviour {
    [Header("Settings")]
    public float zoomDuration = 12f;
    public float fadeOutStart = 8f;
    
    [Header("References")]
    public Image fadePanel;
    public Image towerImage;
    
    private float timer = 0f;
    private Vector3 initialScale;

    void Start() {
        // Error checking
        if (!fadePanel) Debug.LogError("Assign fadePanel in Inspector!");
        if (!towerImage) Debug.LogError("Assign towerImage in Inspector!");
        
        initialScale = towerImage.transform.localScale;
        if (fadePanel) fadePanel.color = Color.clear;
    }

    void Update() {
        timer += Time.deltaTime;

        // Zoom effect
        float zoomProgress = Mathf.Clamp01(timer / zoomDuration);
        towerImage.transform.localScale = initialScale * (1 + zoomProgress * 0.5f);

        // Fade effect
        if (timer >= fadeOutStart && fadePanel) {
            float fadeProgress = (timer - fadeOutStart) / (zoomDuration - fadeOutStart);
            fadePanel.color = new Color(0, 0, 0, fadeProgress);
        }

        // Scene transition
        if (timer >= zoomDuration) {
                SceneManager.LoadScene("DoorShutScene");
        }
    }
}