using InventorySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Narrative
{
    public class UnlockManager : MonoBehaviour
    {
        public Unlockable unlockableData;
       
        public ProgressManager progressManager;
        public ProgressBar2 progressBar;
        public LevelManager levelManager;

        public static  UnlockManager instance;
        //a  public UnlockManager instance;




        void Start()
        {
            if (progressManager == null || progressManager.progressBar == null) ///if reference is empty
            {
                /// Debug.LogError("ProgressManager or ProgressBar is not assigned in UnlockManager!");
                return; // Exit if there's an issue with the progress manager.
            }

        




            // UnlockItem(itemName:unlockableData.name);
            // LoadUnlockData();


        }
        void Awake()
        {
               unlockableData.LockItem("Cipher1");
               unlockableData.LockItem("Cipher2");
               unlockableData.LockItem("Painting1_1");
               unlockableData.LockItem("Painting1");
               unlockableData.LockItem("Painting2");
            
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject); // Make this object persistent
            }
        }



        public void UnlockItem(string itemName)
        {
            if (progressBar.currentProgress>=progressBar.maxProgress||levelManager.currentSceneIndex!=8||levelManager.currentSceneIndex!=9)
            {

                if (unlockableData.IsUnlocked(itemName))
                {
                    Debug.Log(itemName + " is already unlocked");
                    return;
                }

                unlockableData.SetUnlockItem(itemName);
                Debug.Log(itemName + " is unlocked");





                //string progress = $"{progressManager.progressBar.currentProgress}/{progressManager.progressBar.maxProgress}";
                /* if (isUnlock==false)
                 {
                     if (!progressManager.isProgressFull)
                     {
                         Debug.Log($"[Unlock] {itemName} is locked (Progress: {progress})");
                     }
                 }

                 if (progressManager.isProgressFull&&!isUnlock)///and not already unlocked then
                   {

                       unlockableData.SetUnlockItem(itemName);//make itemname unlocked
                      // Debug.Log("Unlocked item: " + itemName);
                       Debug.Log($"[Unlock] {itemName} unlocked (Progress:  {progress})");

                       SaveUnlockData();
                   }


                 */

            }
        }

        public bool CheckUnlockStatus(string itemName) => unlockableData.IsUnlocked(itemName);

          void SaveUnlockData()
          {
              foreach (var item in unlockableData.items)
                  PlayerPrefs.SetInt(item.itemName, item.isUnlocked ? 1 : 0);// Save unlock status (1 = unlocked, 0 = locked)

              PlayerPrefs.Save();// Ensure all data is saved to PlayerPrefs
              //Good for saving player progress like unlocked levels or collected items.
          }

          void LoadUnlockData()
          {
              foreach (var item in unlockableData.items)
                  item.isUnlocked = PlayerPrefs.GetInt(item.itemName, 0) == 1;
          }
          }
      }
      
    
