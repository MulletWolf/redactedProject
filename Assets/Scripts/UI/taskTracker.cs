using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskTracker : MonoBehaviour
{
    [System.Serializable]
    public class Task
    {
        public string taskName;
        public bool isCompleted;
    }

    public List<Task> tasks = new List<Task>();
    public Slider progressBar;
    public Text taskListText;

    private int completedTasks = 0;

    void Start()
    {
        UpdateUI();
    }

    public void CompleteTask(int index)
    {
        if (index >= 0 && index < tasks.Count && !tasks[index].isCompleted)
        {
            tasks[index].isCompleted = true;
            completedTasks++;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Update progress bar (red color)
        float progress = (float)completedTasks / tasks.Count;
        progressBar.value = progress;
        progressBar.fillRect.GetComponent<Image>().color = Color.red;

        // Update task list text
        taskListText.text = "";
        foreach (Task task in tasks)
        {
            taskListText.text += task.isCompleted ? "<color=green>✓</color> " : "<color=red>✗</color> ";
            taskListText.text += task.taskName + "\n";
        }
    }
}
