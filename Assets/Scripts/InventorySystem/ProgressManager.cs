using System.Collections.Generic;
using Narrative;
using Scenes;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.SceneManagement;

namespace InventorySystem
{
   
    public class ProgressManager : MonoBehaviour
    {
        //public static ProgressManager instance;
        //use to check the progress onceconditiosn are met
        public ProgressBar2 progressBar;

        //public UnlockableItem unlockableIData;
        public UnlockManager unlockManager;
        public LevelManager levelManager;
        public UnlockableItem itemData;
        public TaskTracker taskTracker;
      //  public ClickItem clickItem;
        public Inventory inventory;

        public Unlockable unlockable;
        public FailSystem failSystem;

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
            // if (instance != null && instance != this)
            // {
            //     Destroy(gameObject);
            // }
            // else
            // {
            //     instance = this;
            //     DontDestroyOnLoad(gameObject); // Make this object persistent
            // }
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
            return progressBar.currentProgress >= progressBar.maxProgress; 
        }

        public bool CheckProgressAndUnlock(string itemName)
        {
            Debug.Log($"Attempting to check progress and unlock {itemName}");
            // unlockable.SetUnlockItem("Painting1") ;//automatically makes Painting1 unlocked
            string progress = $"{progressBar.currentProgress}/{progressBar.maxProgress}";
           // unlockManager.UnlockItem("Painting1_1"); 

           if (string.IsNullOrEmpty(itemName))
           {
               Debug.LogError($"{itemData} is not a valid item name");
               return false;
           }

           if (unlockManager == null)
           {
               Debug.LogError($"{unlockManager} is not assigned to progressManager");
               return false;
           }
            
            if (!unlockManager.CheckUnlockStatus(itemName)) //if item hasnt been unlocked by unlockkmanager then
            {
                // Debug.Log($"[Progress] {itemName} -has already been unlocked{progress}");
                // return false;
                Debug.Log("Unlocking " + itemName);
                unlockManager.UnlockItem(itemName); //unlock item

                return true;


            }
                
            return false;
        


           /* try
            {
                if (!unlockManager.CheckUnlockStatus(itemName)) //if item hasnt been unlocked by unlockkmanager then
                {
                    // Debug.Log($"[Progress] {itemName} -has already been unlocked{progress}");
                    // return false;
                    Debug.Log("Unlocking " + itemName);
                    unlockManager.UnlockItem(itemName); //unlock item

                    return true;


                }
                
                return false;
            }
            catch (System.Exception e)
            {
                Debug.Log($"Error checking {itemName}: {e.Message}");

                return false;
            }
*/
           


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


           if (levelManager.currentSceneIndex != 6) return;
           
           if (painting=="Painting1_1"&&CheckProgressAndUnlock("Painting1_1"))
           {
               UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
           }
           else if (paintingUnlock.Equals("Painting2_1")&&painting=="Painting2_1")
           {
               UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[8]);
           }
           
          /* Dictionary<string, int> NextPaintingScene = new Dictionary<string, int>//this basically laods scene once the painting is clicked 
           {
               { "Painting1_1", Scenes.Painting1 }, //string and its key
               { "Painting2_1", Scenes.Painting2 },
               { "Painting3_1", Scenes.Painting3 }


           };
           if (levelManager.currentSceneIndex != Scenes.Gallery) return; //checs if teh paints r unlocked inside the gallery
           if (NextPaintingScene.TryGetValue(painting, out int sceneIndex))
           {
               UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
           }
           
*/
            
  

          
        }




        public void UnlocksForCurrentScene()
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

        public void HandleUnlockablesProgress(string cipherName, string paintingName)
        {
            //i wnat it to handle the scenes that have teh cipgher and painting, anythings thats not the gallery
            //string clickedItemName = clickItem.OnItemClick(cipherName);
            //   paintingName = "Painting";
            //  cipherName = "Cipher";




            if (!isProgressFull()) return;

            bool cipherUnlocked = CheckProgressAndUnlock(cipherName);

            bool paintingUnlocked = CheckProgressAndUnlock(paintingName);


            if (!string.IsNullOrEmpty(cipherName)&&cipherUnlocked)
            {

                foreach (var item in unlockable.items)
                {
                    if (item.itemName.Equals(cipherName))
                    {

                        inventory.AddItem(item);
                        Debug.Log($"{cipherName} is unlocked and added to inventory.");
                        break;

                    }
                }


            }

            if (!string.IsNullOrEmpty(paintingName))
            {
            
             if (paintingUnlocked&&paintingName=="Painting1") //if painting is clicked then go to gallery which is scene 6
            {

                //here is the options dialogue enter scene yes or no

                UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[6]);
                Debug.Log($"{paintingName} is clicked goes to gallery.");
                
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
