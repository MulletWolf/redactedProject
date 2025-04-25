using System.Collections.Generic;
using Narrative;
using Scenes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//using UnityEngine.SceneManagement;

namespace InventorySystem
{
   
    public class ProgressManager : MonoBehaviour
    {
        //public static ProgressManager instance;
        //use to check the progress onceconditiosn are met
        public PrgressManager progressBar;

        //public UnlockableItem unlockableIData;
        public UnlockManager unlockManager;
        public LevelManager levelManager;
       
      //  public ClickItem clickItem;
        public Inventory inventory;

        public Unlockable unlockable;
       // public FailSystem failSystem;

        // TaskTracker task = new TaskTracker(); 
        // int completedTasks = task.getTasks();
        public static ProgressManager instance;





        void Start()
        {
            // string paintingname = "";
            //  CheckProgressAndUnlock( );
            if (progressBar == null)
            {
                Debug.LogError("ProgressBar not assigned to progressManager");
            }

            if (unlockManager == null)
            {
                Debug.LogError("UnlockManager not assigned to progressManagerr u talking about ");
            }





        }
        void Awake()
        {
             if (instance != null )
            {
                 Destroy(gameObject);
                 return;
            }
           
                instance = this;
                 DontDestroyOnLoad(gameObject); // Make this object persistent
             
        }


        void Update()
        {
            // int sceneIndex = 0;
            // CheckAndUnlockScene(sceneIndex);
            // unlockManager.UnlockItem("Painting1");
            //UnlockSceneInGallery();

        }
        /*   void Awake()
           {
               DontDestroyOnLoad(gameObject); // For Inventory/ProgressManager
           }

   */

        public bool isProgressFull()
        {
            return progressBar.completedTasks >= progressBar.TotalTasks; 
        }

        public bool CheckProgressAndUnlock(string itemName)
        {
            Debug.Log($"Attempting to check progress and unlock {itemName}");
            // unlockable.SetUnlockItem("Painting1") ;//automatically makes Painting1 unlocked
            string progress = $"{progressBar.completedTasks}/{progressBar.TotalTasks}";
           // unlockManager.UnlockItem("Painting1_1"); 

        
         if (progressBar.completedTasks <progressBar.TotalTasks) return false;
         if (progressBar.completedTasks >= progressBar.TotalTasks)
            
         
         {
              Debug.Log($"Progress (progressbar full)requirement met - checking unlock status{progress}");
              
              
              bool unlocked = unlockable.IsUnlocked(itemName);
             
             if (!unlocked) //if item hasnt been unlocked by unlockkmanager then
             {
              
                 unlockManager.UnlockItem(itemName); //unlock item

                 return true;


             }
             Debug.Log($"{itemName } was already unlcoked ");

             return false;


         }
      
         Debug.Log($"ProgressBr not full - checking unlock status{progress}");
         return false;
         



        }
    

    /*if (taskTracker!=null&&taskTracker.completedTasks>=taskTracker.tasks.Count)
    {

    }*/

   





        public void UnlockSceneInGallery(string painting)

        {
            //if progressbar is full and ur ina  specific index then cipher1 is unlocked if its unlcojed then painting1 is unlokded
            //if painting 1 is unlcoked its clickable and u are trasnferred to gallery
            //string sceneName="";
            // Only check if progress is complete
           // var clickedItem = clickItem.OnItemClick("Painting1");
           
           //painting1_1 is automatically unlocked 
           //painting2_1 is unlocked once painting1 is
           //painting3_1 is unlocked once painting2 is unlcoked
           bool paintingUnlock = CheckProgressAndUnlock(painting);
           if (!paintingUnlock) return;


           if (!levelManager.Scenes.Equals("GalleryScene")) return;
           
           
            if (paintingUnlock&&painting=="Painting2_1")
           {
              SceneManager.LoadScene("Library");
           }
           
        
            
  

          
        }




       /* public void UnlocksForCurrentScene()
        {
            switch (levelManager.currentSceneIndex)
            {


                // Check for unlockables for each scene
                case 7: // Lab → Unlock Cipher1 → Painting2
                    HandleUnlockablesProgress("Cipher1", "Painting1");
                    break;
                case 8: // Library → Unlock Cipher2 → Painting3
                    HandleUnlockablesProgress("Cipher2", "Painting3");
                    break;
                case 9: // Vault → Unlock Cipher3 → Painting4
                    HandleUnlockablesProgress("Cipher3", "Painting4");
                    break;


            }
        }
*/
        public void HandleUnlockablesProgress( string paintingName)
        {
            //i wnat it to handle the scenes that have teh cipgher and painting, anythings thats not the gallery
            //string clickedItemName = clickItem.OnItemClick(cipherName);
            //   paintingName = "Painting";
            //  cipherName = "Cipher";




            if (progressBar.completedTasks<progressBar.TotalTasks) return;

           

            

            /*        bool cipherUnlocked = CheckProgressAndUnlock(cipherName);
            if (!string.IsNullOrEmpty(cipherName)&&cipherUnlocked)
            {

                foreach (var item in unlockable.items)
                {
                    if (item.itemName==cipherName)
                    {

                        inventory.AddItem(game);
                        Debug.Log($"{cipherName} is unlocked and added to inventory.");
                        break;

                    }
                    Debug.Log($"{cipherName} is not equal to {item.itemName}");
                }
                */


            
                bool paintingUnlocked = CheckProgressAndUnlock(paintingName);
            if (!string.IsNullOrEmpty(paintingName))
            {
            
             if (paintingUnlocked&&paintingName=="Painting1") //if painting is clicked then go to gallery which is scene 6
            {
                foreach (var item in unlockable.items)
                {
                   /* if (item.itemName == cipherName)
                    {*/

                        //here is the options dialogue enter scene yes or no
                        Debug.Log($"{paintingName} is clicked goes to gallery.");

                        if (levelManager != null)
                        {
                            SceneManager.LoadScene("GalleryScene");
                            SceneManager.LoadScene("TheBanquet");
                        }
                        
                   // }
                }



            }



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
