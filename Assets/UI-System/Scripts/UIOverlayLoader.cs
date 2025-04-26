using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOverlayLoader : MonoBehaviour
{
    private static bool overlayLoaded = false;

    void Awake()
    {
        if (!overlayLoaded)
        {
            SceneManager.LoadScene("UI_Overlay", LoadSceneMode.Additive);
            overlayLoaded = true;
        }
    }
}
