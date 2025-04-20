using UnityEngine;

public class SparkleTrigger : MonoBehaviour
{
    public GameObject sparkleEffect;
    public float delayInSeconds = 5f;

    void Start()
    {
        // Delay to simulate the narrator guiding the player
        Invoke("ShowSparkles", delayInSeconds);
    }

    void ShowSparkles()
    {
        if (sparkleEffect != null)
        {
            sparkleEffect.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Sparkle effect not assigned!");
        }
    }
}
