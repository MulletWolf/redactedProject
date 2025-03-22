using UnityEngine;
using UnityEngine.Video;

public class CurtainClick : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the video player
    public string sceneToLoad; // Name of the scene to load after the video

    private bool isPlaying = false;

    void OnMouseDown() 
    {
        if (!isPlaying) 
        {
            Debug.Log("Curtain Clicked!");
            isPlaying = true;
            videoPlayer.Play();
            videoPlayer.loopPointReached += OnVideoEnd; // Call when video ends
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video Finished. Loading Scene: " + sceneToLoad);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
