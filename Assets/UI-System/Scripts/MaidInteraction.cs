using UnityEngine;

public class MaidInteraction : MonoBehaviour
{
    public GameObject maidMiniGamePanel;
    public GameObject thisMaidWithSparkles;

    public void OnMaidClicked()
    {
        if (maidMiniGamePanel != null)
            maidMiniGamePanel.SetActive(true);

        if (thisMaidWithSparkles != null)
            thisMaidWithSparkles.SetActive(false);
    }
}
