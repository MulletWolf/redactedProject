using UnityEngine;

public class CircularPan : MonoBehaviour
{
    public Transform[] layers; // Assign your layered PNGs in inspector
    public float[] layerSpeeds; // Speed multipliers for parallax effect
    public float panSpeed = 5f;
    
    private float totalWidth; // Width of your room panorama

    void Start()
    {
        // Calculate total width based on your background image
        totalWidth = 96;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        
        if (moveInput != 0)
        {
            for (int i = 0; i < layers.Length; i++)
            {
                // Move each layer at different speeds for parallax
                float moveAmount = moveInput * panSpeed * layerSpeeds[i] * Time.deltaTime;
                Vector3 newPos = layers[i].localPosition + Vector3.right * moveAmount;
                
                // Wrap around if beyond boundaries
                if (newPos.x > totalWidth/2) newPos.x -= totalWidth;
                else if (newPos.x < -totalWidth/2) newPos.x += totalWidth;
                
                layers[i].localPosition = newPos;
            }
        }
    }
}