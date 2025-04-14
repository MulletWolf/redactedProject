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
        public Dictionary<string, UnlockableItem> itemDictionary;

       
        public UnlockableItem item;


        // public List<UnlockableItem> itemList=new List<UnlockableItemItem>();

        public void Awake()
        {
            InititializeItems();
        }

         void Start()
        {
         // LockAllItems();
         
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
                    continue;
                }

                if (!itemDictionary.ContainsKey(item.itemName))
                {
                  //  continue;
                      itemDictionary.Add(item.itemName, item);//assigns a key to the identifier 
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

        public void LockItem(string itemName)
        {
          /*  foreach (var item in items)
            {
                if (item == null) continue;
                if (item.itemName==itemName)
                {
                    item.isUnlocked = false;
                    break;
                    Debug.Log( item.itemName+"is locked");
                }
            }*/
            if(itemDictionary.TryGetValue(itemName, out var item) && item.isUnlocked)
            {
                item.isUnlocked = false;
            }
        }


        public void LockAllItems()
        {
            foreach (var item in items)
            {
                if (item!=null)
                {
                    item.isUnlocked = false;
                    
                }

            }
            Debug.Log("All Items locked");
        }
    }
}