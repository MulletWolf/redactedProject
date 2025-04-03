using UnityEngine;
using UnityEngine.SceneManagement;

public class FailSystem : MonoBehaviour
{
    public int totalTasks = 3;
    private int completedTasks = 0;
    public int maxFails = 3;
    private int failCount = 0;

    public GameObject paintingPromptUI;

    void Start()
    {
        paintingPromptUI.SetActive(false);
    }

    public void CompleteTask()
    {
        completedTasks++;
        if (completedTasks >= totalTasks)
        {
            paintingPromptUI.SetActive(true);
        }
    }

    public void FailTask()
    {
        failCount++;
        if (failCount >= maxFails)
        {
            GoToDeathScene();
        }
    }

    public void InteractWithPainting(bool enter)
    {
        if (enter)
        {
            LoadNextLevel();
        }
        else
        {
            GoToDeathScene();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("NextLevelScene");
    }

    void GoToDeathScene()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
