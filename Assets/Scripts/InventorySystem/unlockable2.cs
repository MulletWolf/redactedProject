/*namespace InventorySystem
{
    public class unlockable2
    {
        using System;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    // [CreateAssetMenu(fileName = "NewUnlockable", menuName = "Unlockable/Create New Unlockable")]

    public class Unlockable : MonoBehaviour

    {
        // public UnlockableItem unlockableItem;

        public List<UnlockableItem> items;

        // public List<ItemData> ciphers;
        private Dictionary<string, UnlockableItem> itemDictionary;


        // public List<UnlockableItem> itemList=new List<UnlockableItemItem>();

        public void Awake()
        {
            InititializeItems();
        }

         void Start()
        {
           LockItems();
        }

        public void InititializeItems()
        {
            if (items == null || items.Count == 0)
            {
                // Debug.Log("Unlockable items not found");
                //add each item ton
                items = new List<UnlockableItem>();
                Debug.Log("Created new list of items");
                return;
            }

            itemDictionary = new Dictionary<string, UnlockableItem>();

            foreach (var item in items)
            {
                if (item == null) continue;
                // item.isUnlocked = false;
               // item.isUnlocked = false;

                if (!string.IsNullOrEmpty(item.itemName))
                {
                    itemDictionary[item.itemName] = item;
                }
                else
                {
                    Debug.Log("UnlockableItem is null");
                }


            }

        }

        public bool SetUnlockItem(string itemName) //unlockingitem when ....
        {
            if (itemDictionary.TryGetValue(itemName, out var item) && !item.isUnlocked)
            {
                item.isUnlocked = true;
                
               // Debug.Log($"{itemName} unlocked!");
                return true;

            }
            // else{
            //     Debug.Log($"{itemName} is already unlocked/doesnt exist!");
            //     return false;
            //     }

            return false;

        }

        public bool IsUnlocked(string itemName) //if isUnlocked==true then 
        {
            return itemDictionary.TryGetValue(itemName, out UnlockableItem item) && item.isUnlocked;
            
        }


        public void LockItems()
        {
            foreach (var item in items)
            {
                if (item!=null)
                {
                    item.isUnlocked = false;
                }

            }
        }
    }
}
    }
}
*/