using UnityEngine;
using UnityEngine.UI;

public class PrgressManager : MonoBehaviour
{
    public Image progressFill;

    [Range(0, 3)]
    public int completedTasks = 0;

    private int totalTasks = 3;
    //public int totalTasks { get; private set; } = 3;
    public int TotalTasks 
    {
        get => totalTasks;
        private set => totalTasks = value; // 'value' is the new value being set
    }

    void Awake()
    {
        //completedTasks = 0;
    }

    public bool isProgressFull()
    {
       // string progress=$"{completedTasks}/{totalTasks}";
       // Debug.Log($"Progress is full{progress}");
        return completedTasks>=totalTasks;
    }
    
    

    public void AddProgress()
    {
        if (completedTasks<totalTasks) 
        {
            Debug.Log($"current progress increasing from : {completedTasks}/{totalTasks}");
            completedTasks = Mathf.Clamp(completedTasks + 1, 0, totalTasks);
            Debug.Log($" To: Adding progress increasing: {completedTasks}/{totalTasks}");
        }
       
      //  UpdateProgressBar();

        if (completedTasks == totalTasks)
        {
            Debug.Log($"progress full bitchess kawaiiii: {completedTasks}/{totalTasks}");
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
