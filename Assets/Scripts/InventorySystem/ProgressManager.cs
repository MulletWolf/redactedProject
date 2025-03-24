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
        public LevelLoader levelLoader;
        public UnlockableItem unlockableData;
        public TaskTracker taskTracker;
        
        // TaskTracker task = new TaskTracker(); 
        // int completedTasks = task.getTasks();
        
        



        void Start()
        {
            string paintingname = "";
            CheckProgressAndUnlock( paintingname);

           
        }

        void Update()
        {
            int sceneIndex = 0;
            CheckAndUnlockScene(sceneIndex);
        }

        public bool CheckProgressAndUnlock(string paintingname)
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
                if(!unlockManager.CheckUnlockStatus(paintingname)){//prevents same thing being unlocked
                unlockManager.UnlockItem(paintingname);
                Debug.Log(paintingname +"has been unlocked");
                return true;
                }
            }

            if (taskTracker!=null&&taskTracker.completedTasks>=taskTracker.tasks.Count)
            {
                
            }

            

            return false;
        }

        public void CheckAndUnlockScene(int sceneIndex)
        {
            switch (sceneIndex)
            {
                case 4:
                    if (unlockManager.CheckUnlockStatus("Painting 1"))
                    {
                        CheckProgressAndUnlock("Door 1");
                    }
                    break;
                case 5:
                    if (unlockManager.CheckUnlockStatus("Painting 1"))
                    {
                        CheckProgressAndUnlock("Painting 1");
                    }
                    break;
                case 6:
                    if (unlockManager.CheckUnlockStatus("Painting 2"))
                    {
                        CheckProgressAndUnlock("Painting 2");
                    }
                    break;
                
            }
        }
    }
}