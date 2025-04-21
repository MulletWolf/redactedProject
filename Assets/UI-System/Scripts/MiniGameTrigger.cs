using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject miniGameOverlay; // drag your overlay panel here in the inspector
    
    void Start()
    {
        // Ensure mini-game panel is hidden initially
        if (miniGameOverlay != null)
            miniGameOverlay.SetActive(false);
    }

    public void OnClickChandelier()
    {
        if (miniGameOverlay != null)
            miniGameOverlay.SetActive(true);
    }

    public void CloseMiniGame()
    {
        if (miniGameOverlay != null)
            miniGameOverlay.SetActive(false);
    }
}
