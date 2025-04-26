using UnityEngine;

public class QuitGame : MonoBehaviour {
    public void Quit() {
    Application.Quit();
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; // For testing in Editor
    #endif
}
}

