using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    public float panSpeed = 2f; // Speed of camera movement
    public float roomWidth = 960f; // Width of the room in Unity units
    public float cameraWidth = 480f; // Width of the camera view

    private float halfCameraWidth;

    void Start()
    {
        halfCameraWidth = cameraWidth / 2f;
    }

    void Update()
    {
        float moveX = 0;

        // Capture input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveX = -1;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveX = 1;

        // Apply movement
        if (moveX != 0)
        {
            transform.position += new Vector3(moveX * panSpeed * Time.deltaTime, 0, 0);

            // Wrap around logic
            if (transform.position.x - cameraWidth > roomWidth / 2)
            {
                transform.position -= new Vector3(roomWidth, 0, 0);
            }
            else if (transform.position.x + cameraWidth < -roomWidth / 2)
            {
                transform.position += new Vector3(roomWidth, 0, 0);
            }
        }
    }
}
