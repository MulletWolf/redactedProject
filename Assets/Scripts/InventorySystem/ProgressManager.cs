using Narrative;
using UnityEngine;

namespace InventorySystem
{
    public class ProgressManager: MonoBehaviour
    {
        //use to check the progress onceconditiosn are met
        public ProgressBar progressBar;
        //public UnlockableItem unlockableIData;
        public UnlockManager unlockManager;
        public LevelManager levelManager;
        public UnlockableItem itemData;
        public TaskTracker taskTracker;
        public ClickPainting clickItem;
        public Inventory inventory;
        
        
        // TaskTracker task = new TaskTracker(); 
        // int completedTasks = task.getTasks();
        
        



        void Start()
        {
           // string paintingname = "";
          //  CheckProgressAndUnlock( );

           
        }

        void Update()
        {
           // int sceneIndex = 0;
           // CheckAndUnlockScene(sceneIndex);
           // unlockManager.UnlockItem("Painting1");
            UnlockScene();
            
        }
        

        public bool CheckProgressAndUnlock(string itemName)
        {
            if( progressBar==null)
            {
                Debug.LogError("ProgressBar not assigned to progressManager");
            }

            if (unlockManager==null)
            {
                Debug.LogError("UnlockManager not assigned to progressManagerr u talking about ");
            }
            if (progressBar.currentProgress>=progressBar.maxProgress )
            {
                if(!unlockManager.CheckUnlockStatus(itemName)){//prevents same thing being unlocked
                unlockManager.UnlockItem(itemName);
                Debug.Log(itemName+"has been unlocked");
                return true;
                }
            }

            /*if (taskTracker!=null&&taskTracker.completedTasks>=taskTracker.tasks.Count)
            {
                
            }*/

            

            return false;
        }

        public void UnlockScene()
        
        {//if progressbar is full and ur ina  specific index then cipher1 is unlocked if its unlcojed then painting1 is unlokded
            //if painting 1 is unlcoked its clickable and u are trasnferred to gallery
            //string sceneName="";
      // Only check if progress is complete
                if (progressBar.currentProgress >= progressBar.maxProgress)
                {
                    // Check for unlockables for each scene
                    if (levelManager.currentSceneIndex == 7)
                    {
                        HandleUnlockables("Cipher1", "Painting1", 7);
                    }
                    else if (levelManager.currentSceneIndex == 8)
                    {
                        HandleUnlockables("Cipher2", "Painting2", 8);
                    }
                    else if (levelManager.currentSceneIndex == 9)
                    {
                        HandleUnlockables("Cipher3", "Painting3", 9);
                    }
                }
            
        }

        public void HandleUnlockables(string cipherName, string paintingName, int currentSceneIndex)
        {
            CheckProgressAndUnlock(cipherName);
            CheckProgressAndUnlock(paintingName);

            if (clickItem.ClickP(paintingName))//if painting is clicked then go to gallery which is scene 6
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[6]);
                
            }else if (clickItem.ClickP(cipherName))//if cipher is clicked then additem to inventory
            {
                inventory.AddItem(itemData);
            }
            



        }



        /* public void CheckAndUnlockScene(int sceneIndex)
         {
             int currentSceneIndex = 0;
             if (levelmanager.currentSceneIndex==sceneIndex)
             {
             }

             switch (sceneIndex)
             {

                 case 5:
                     if (unlockManager.CheckUnlockStatus("Door1"))
                     {
                         CheckProgressAndUnlock("Door1");
                     }

                     break;
                 case 7:
                     if (unlockManager.CheckUnlockStatus("Painting1"))
                     {

                         CheckProgressAndUnlock("Painting1");
                     }

                     break;
                 case 8:
                     if (unlockManager.CheckUnlockStatus("Painting 2"))
                     {
                         CheckProgressAndUnlock("Painting 2");
                     }
                 case 9:
                     if (unlockManager.CheckUnlockStatus("Painting3"))
                     {
                         CheckProgressAndUnlock("Painting3");
                     }

                     break;

             }*/
        

    
        
        
        
    }
}