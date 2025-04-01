using InventorySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Narrative
{
    public class UnlockManager:MonoBehaviour
    {
        public Unlockable unlockableData; 
     //   public ProgressBar progressBar;
        public ProgressManager progressManager;
        public UnlockManager instance;
       

        
            void Start()
            {
                if (progressManager == null || progressManager.progressBar == null)///if reference is empty
                {
                   /// Debug.LogError("ProgressManager or ProgressBar is not assigned in UnlockManager!");
                    return; // Exit if there's an issue with the progress manager.
                }

                
            

           // UnlockItem(itemName:unlockableData.name);
            LoadUnlockData();
            
            
        }
        public void UnlockItem(string itemName)
        {
            if (unlockableData == null)
            {
                Debug.LogError("Unlockable Data is NOT assigned in UnlockManager!");
                return; // Prevent further execution if `unlockableData` is missing.
            }

          //  int currentProgress = 0;
            if (progressManager.progressBar.currentProgress>=progressManager.progressBar.maxProgress&&!unlockableData.IsUnlocked(itemName))///and not already unlocked then
            {
                unlockableData.UnlockItem(itemName);//make itemname unlocked
                
                SaveUnlockData();
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