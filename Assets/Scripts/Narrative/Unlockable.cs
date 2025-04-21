using System;
using System.Collections.Generic;
using InventorySystem;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace Narrative
{
    // [CreateAssetMenu(fileName = "NewUnlockable", menuName = "Unlockable/Create New Unlockable")]

    public class Unlockable : MonoBehaviour

    {
        // public UnlockableItem unlockableItem;

        public List<UnlockableItem> items;

        // public List<ItemData> ciphers;
       /* public  Dictionary<string, UnlockableItem> itemDictionary;*/
       
      //  public UnlockableItem item;
        private bool isInitialized = false;
        public static Unlockable instance;
        public ProgressBar2 progressBar;
        public LevelManager levelManager;

       
   void Start()
        {
         
         
        }
   
        void Awake()
        {
             LockAllItems();
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


        public void InititializeItems()
        {
            //  itemDictionary = new Dictionary<string, UnlockableItem>();

            if (items == null || items.Count == 0)
            {
                // Debug.Log("Unlockable items not found");
                //add each item ton
                items = new List<UnlockableItem>();
                Debug.Log("Created new list of items");
                return;
            }

            
        }



        public bool SetUnlockItem(string itemName) //unlockingitem when ....
        {
            /*if (itemDictionary.TryGetValue(itemName, out var item) && !item.isUnlocked)
            {
                item.isUnlocked = true;

                // Debug.Log($"{itemName} unlocked!");
                return true;

            }
*/
            foreach (var unlockeditem in items)
            {
            

            if (!unlockeditem.isUnlocked)
            {
                // =true;

                // Debug.Log($"{itemName} unlocked!");
                return unlockeditem.isUnlocked;
            }
        }
        // else{
        //     Debug.Log($"{itemName} is already unlocked/doesnt exist!");
        //     return false;
        //     }

        return false;

    }

        public bool IsUnlocked(string itemName) //if isUnlocked==true then 
        {
            // return itemDictionary.TryGetValue(itemName, out UnlockableItem item) && item.isUnlocked;
          


                foreach (var item in items)
                {
                    if (item.name == itemName)
                    {
                        item.isUnlocked = true;
                        return true;
                    }
                }

                return false;

            
           
        }

        public void LockItem(string itemName)
        {
            if (progressBar.currentProgress<progressBar.maxProgress)
            {
                foreach (var item in items)
                {

                    if (item == null) continue;
                    if (item.itemName == itemName)
                    {
                        item.isUnlocked = false;
                        // break;
                        Debug.Log(item.itemName + "is locked");
                    }
                }
            }

            if (!isInitialized)
          {
              InititializeItems();
          }
         /* if (itemDictionary == null)
          {
              Debug.Log("Item dictionary is null");
          }
            if(itemDictionary.TryGetValue(itemName, out var unlockeditem))
            {
                unlockeditem.isUnlocked = false;
                Debug.Log("Locked item: " + unlockeditem.itemName);
            }
            else
            {
                Debug.Log($"item {itemName} not founf in item dictionary " );
            }*/
           
           
        }


        public void LockAllItems()
        {
            foreach (var lockitem in items)
            {
                if (lockitem!=null)
                {
                    lockitem.isUnlocked = false;
                    
                }

            }
            Debug.Log("All Items locked");
        }
    }
}