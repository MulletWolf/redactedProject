using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScroll : MonoBehaviour
{
    public float panSpeed = 10f;
    public float minX = -30f;  // Try these
    public float maxX = 30f;

    void Update()
    {
        // Add to your main camera if using world-space clicks:
       
        float move = Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(move, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
    }

  
    void Start()
    {
        // Add this once (not in Update!)
        if (Camera.main.GetComponent<Physics2DRaycaster>() == null)
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        
    }
}
