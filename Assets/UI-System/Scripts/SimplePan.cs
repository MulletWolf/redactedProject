using UnityEngine;

public class SimplePan : MonoBehaviour {
    [Header("Pan Settings")]
    public float panSpeed = 100f;
    //public Vector2 panLimits = new Vector2(480, 202.5f); // Half your image size

    private Vector3 startPos;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        // Get arrow key input
        float moveX = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;

        // Calculate new position
        Vector3 newPos = transform.position + new Vector3(moveX, moveY, 0);
        
        // Apply bounds (so you don't pan outside the image)
        //newPos.x = Mathf.Clamp(newPos.x, startPos.x - panLimits.x, startPos.x + panLimits.x);
        //newPos.y = Mathf.Clamp(newPos.y, startPos.y - panLimits.y, startPos.y + panLimits.y);
        
        //transform.position = newPos;
    }
}