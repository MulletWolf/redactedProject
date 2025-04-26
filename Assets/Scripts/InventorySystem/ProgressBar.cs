using System;
using System.Collections.Generic;
using System.Net.Mime;
using InventorySystem;
using Narrative;
using NUnit.Framework;
using Scenes;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    
    public Image progressFill;

    [UnityEngine.Range(0, 3)]
    public int completedTasks = 0;

    private int totalTasks = 3;
    //public int totalTasks { get; private set; } = 3;
    public int TotalTasks 
    {
        get => totalTasks;
        private set => totalTasks = value; // 'value' is the new value being set
    }
    
    

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
