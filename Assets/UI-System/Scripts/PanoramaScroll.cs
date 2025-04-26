using UnityEngine;

public class PanoramaScroll : MonoBehaviour {
    public float scrollSpeed = 1f; 
    public float imageWidth = 9.6f; // Must match your PNG width in Unity units

    void Update() {
        // Mouse control (hold right-click)
        float mouseX = Input.GetAxis("Mouse X");
        transform.position += Vector3.right * mouseX * scrollSpeed * Time.deltaTime;

        // Arrow key alternative
        float arrowX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * arrowX * scrollSpeed * Time.deltaTime;

        // Loop the camera
        if (transform.position.x > imageWidth / 2) {
            transform.position -= Vector3.right * imageWidth;
        }
        else if (transform.position.x < -imageWidth / 2) {
            transform.position += Vector3.right * imageWidth;
        }
    }
}
