using InventorySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Narrative
{
    public class UnlockManager : MonoBehaviour
    {
        public Unlockable unlockableData;
        private ProgressBar progressBar;
        public ProgressManager progressManager;
        //a  public UnlockManager instance;




        void Start()
        {
            if (progressManager == null || progressManager.progressBar == null) ///if reference is empty
            {
                /// Debug.LogError("ProgressManager or ProgressBar is not assigned in UnlockManager!");
                return; // Exit if there's an issue with the progress manager.
            }

           unlockableData.LockItem("Cipher1");
            unlockableData.LockItem("Painting1");




            // UnlockItem(itemName:unlockableData.name);
            // LoadUnlockData();


        }


        public void UnlockItem(string itemName)
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
      
    
