using UnityEngine;

public class CameraPan : MonoBehaviour {
    [Header("Movement")]
    public float panSpeed = 5f;
    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    [Header("Bounds")]
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update() {
        // Get raw input for snappier movement
        Vector3 input = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );

        if (input != Vector3.zero) { // Only move if there's input
            Vector3 targetPos = transform.position + input.normalized * panSpeed;
            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
            
            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPos,
                ref velocity,
                smoothTime
            );
            Debug.Log($"Moving! Input: {input} | Position: {transform.position}");
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(
            new Vector3((minX + maxX)/2, (minY + maxY)/2, 0),
            new Vector3(maxX-minX, maxY-minY, 1)
        );
    }
}