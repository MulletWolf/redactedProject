using UnityEngine;

public class PulsatingGlow : MonoBehaviour
{
    public float pulseSpeed = 1.5f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;

    private CanvasGroup cg;

    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        if (cg == null) cg = gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        float alpha = minAlpha + Mathf.PingPong(Time.time * pulseSpeed, maxAlpha - minAlpha);
        cg.alpha = alpha;
    }
}
