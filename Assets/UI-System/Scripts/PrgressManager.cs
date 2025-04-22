using UnityEngine;
using UnityEngine.UI;

public class PrgressManager : MonoBehaviour
{
    public Image progressFill;

    [Range(0, 3)]
    public int completedTasks = 0;

    private int totalTasks = 3;

    public void AddProgress()
    {
        completedTasks = Mathf.Clamp(completedTasks + 1, 0, totalTasks);
        UpdateProgressBar();

        if (completedTasks == totalTasks)
        {
            TriggerFinalDialogue();
        }
    }

    void UpdateProgressBar()
    {
        float fillPercent = Mathf.Clamp01((float)completedTasks / totalTasks);
        progressFill.fillAmount = fillPercent;
    }

    void TriggerFinalDialogue()
    {
        Debug.Log("All tasks complete! Time to start the cipher.");
        // You can plug your dialogue trigger here or call another script.
    }
}
