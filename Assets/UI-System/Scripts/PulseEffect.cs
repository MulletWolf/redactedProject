using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    public float speed = 2f;
    public float scaleAmount = 1.05f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = Mathf.PingPong(Time.time * speed, scaleAmount - 1f) + 1f;
        transform.localScale = originalScale * scale;
    }
}
