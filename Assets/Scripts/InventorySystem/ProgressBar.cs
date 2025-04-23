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
    
    //used to control the progress
    //item is added to inventory when 
    //painting unlocked once tasks are completed
    //i use trask tracker now not gem data
    //scratch this use task tracker
    
    //ONLY FOR UPDATING PROGRESSBAR NOTHING ELSE 
   
   

  
   // public ItemData itemData;
   [Header("Progress Settings")]
    [SerializeField] private int maxProgress=3;
    [SerializeField] private  int currentProgress=0;
    public float fillAmount;
    public Image fillmask;
    //public UnlockPainting unlocked;
  //  public List<int> puzzleProgress = new List<int>();
   // public int puzzleIndex = 0;
 //  public UnlockableItem itemData;
  // public InventoryItem newItem;
  public ProgressManager progressManager;
  private bool isComplete;
  public ClickItem clickItem;
  public ProgressBar instance;
 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int CurrentProgress
    {
        get
        {
            return currentProgress;
        }
        set
        {
            currentProgress = value;
        }
    }
    public int MaxProgress
    {
        get { return maxProgress; }
        set { maxProgress = value; }
    }

    /*public void IncrementProgress()
    {
        currentProgress += 1;
    }
    */
    void Start()
    {
        if (progressManager == null)
        {
            Debug.Log($"ProgressManager is null");
        }
        if(isComplete)  ResetProgress();
      
       
    //   currentProgress = 0;
        
        
    //  maxProgress = 3;
    }

    // Update is called once per frame
    void Update()
    {
       


        //current progress--is the count
        //each puuzzleIndex is the index inside puzzleProgress 
        //every time a gem is clicked the puzzelprogres sincreases


    }
    // void OnEnable() => Debug.Log("ProgressBar enabled");
    // void OnDisable() => Debug.Log("ProgressBar disabled");
    // void OnDestroy() => Debug.Log("ProgressBar destroyed");

    /*void Awake()
    {
     

        if (instance != this&&instance!=null)
        {
          
            Destroy(gameObject);
            return;
        }
       
            instance = this;
            DontDestroyOnLoad(gameObject);
        
        
          if (maxProgress == 0)
               { Debug.Log($"ProgressBar max: {maxProgress}"); 
                   maxProgress = 3;
                      ResetProgress();
               }
      
    }
*/
    private void ResetProgress()
    {
        if (maxProgress == 0)
        {
            maxProgress = 3;
            currentProgress = 0;
            isComplete = false;
            //  Debug.Log($"ResetProgress");
            Debug.Log($"Progress reset to {currentProgress}/{maxProgress}");
        }
    }
    #if UNITY_EDITOR
    private void OnValidate()
    {

        if (maxProgress <= 0) maxProgress = 3;
    }
    #endif

    public void AddProgress()
   {
      // if (currentProgress > maxProgress) return;
     
      //currentProgress = Mathf.Min(currentProgress, maxProgress); // Prevent overflow
      //UpdateProgressBar();
    //  if (currentProgress >= maxProgress) return;
   /* if (maxProgress == 0) maxProgress = 3;
   
   
    
    maxProgress = 3;
   // currentProgress = Mathf.Clamp( currentProgress + 1, 0, maxProgress);
      currentProgress++;
      string progress = $"{currentProgress}/{maxProgress}";
      Debug.Log($" AddedProgress: {progress}");

      if (maxProgress == 0)
      {
          maxProgress = 3;
          
          */
   currentProgress++;
  

  

   if (currentProgress >= maxProgress)
          {
             // maxProgress = 3;
              //  Debug.Log($"Progress: {progress}");
            //isComplete = true;


              Debug.Log("Progress complete, all cherries collectd!");
              // Add your custom logic here (e.g., unlock a painting)
          }
      //}
/*
        currentProgress++;
        if (currentProgress<maxProgress)
        {

            Debug.Log($"Progress: {currentProgress}/{maxProgress}");
        }

        if (currentProgress>=maxProgress)
        {

            Debug.Log("ProgressBar full");


        }*/
    }

 

  
    public void UpdateProgress(){//to show ithe ui of it being filled
        if (fillmask!=null)
        { 
            fillAmount = (float)currentProgress / (float)maxProgress;
            fillmask.fillAmount = fillAmount;//fillmask is the actual block thats getting increased 
                 //whatever amount of progress is filled by fillmask image
            
        }
        else
        {
            Debug.Log("Fillmask doesnt exist");
        }
       

    }
    /*public int CurrentProgress => currentProgress; // Expression-bodied property (C# 6+)
*/}
