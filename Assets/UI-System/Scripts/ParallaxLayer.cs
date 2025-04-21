using UnityEngine;

public class ParallaxLayer : MonoBehaviour {
    [Header("Settings")]
    public float parallaxSpeed = 0.5f;
    public bool invertMovement = false;

    private Vector3 startPos;
    private Transform cam;

    void Start() {
        cam = Camera.main.transform;
        startPos = transform.position;
    }

    void Update() {
        float parallaxFactor = invertMovement ? -parallaxSpeed : parallaxSpeed;
        Vector3 camOffset = cam.position - Camera.main.transform.position;
        transform.position = startPos + new Vector3(
            camOffset.x * parallaxFactor,
            camOffset.y * parallaxFactor * 0.5f, // Optional vertical parallax
            0
        );
    }
}