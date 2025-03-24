using System.Collections.Generic;
using System.Net.Mime;
using Narrative;
using NUnit.Framework;
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
   
    public Inventory inventory;
    

  
    public ItemData itemData;
    public int maxProgress;
    public int currentProgress;
    public float fillAmount;
    public Image fillmask;
    //public UnlockPainting unlocked;
  //  public List<int> puzzleProgress = new List<int>();
   // public int puzzleIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
       


        //current progress--is the count
        //each puuzzleIndex is the index inside puzzleProgress list
        //every time a gem is clicked the puzzelprogres sincreases


    }

   public void AddProgress()
   {
      // SetProgress();
        //each index is a puzzle
        //puzzleProgress[0] first puzzle
        //puzzleProgress[1]-- 2nd puzzle ecetra
        //do i need to say puzzleIndex when , its my chouice to say i orpuzzleIndex
        maxProgress = 7;

        currentProgress++;

        if (currentProgress>=maxProgress)
        {
            //every time the progressbar is fulll user can enter painting
            //so put the progressbar.Add() at the end of each puzzle 
            //set sizefor max progress
            inventory.AddItem(itemData);
            currentProgress -= maxProgress;//restart progress to 0
            UpdateProgress();
            //unlocked.Unlock();
           // unlockableItem.UnlockItem("Painting");//unlock painting
            
            Debug.Log("Item added to inventory"+itemData.name);
            
        }
    }

 

    // public void SetProgress()
    // {
    //           // currentProgress = puzzleProgress[puzzleIndex];
    //             maxProgress = puzzleProgress.Count - 1;
    // }
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
    
}
