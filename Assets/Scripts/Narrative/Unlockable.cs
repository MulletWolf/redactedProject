using System;
using System.Collections.Generic;
using System.Text;
using InventorySystem;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Narrative
{
   

    public class Unlockable : MonoBehaviour

    {
        // public UnlockableItem unlockableItem;

        public List<UnlockableItem> items;
        //public List<GameObject> items;

        // public List<ItemData> ciphers;
       /* public  Dictionary<string, UnlockableItem> itemDictionary;*/
       
      //  public UnlockableItem item;
       // private bool isInitialized = false;
        public static Unlockable instance;
        public PrgressManager progressBar;
        public LevelManager levelManager;

       
   void Start()
        {
           // LockAllItems();
           DebugPrintAllItems();

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
            //  LoadItemsFromUnlocakbleList();
                       InititializeItems();
                        ClearNull();
                        //LockItem("Cipher1");
                         LockAllItems();
        }
        /*void LoadItemsFromUnlocakbleList()//automatic laoding
        { 
        //   items = new List<UnlockableItem>(Resources.LoadAll<UnlockableItem>("ScriptableObjects"));
           Debug.Log($"Loaded {items.Count} unlockable items");
           foreach (var item in items)
           {
               Debug.Log($"Loaded item: {item.name}");
           }
        }
*/


        public void InititializeItems()
        {
            //  itemDictionary = new Dictionary<string, UnlockableItem>();

            if (items == null )
            {
                // Debug.Log("Unlockable items not found");
                //add each item ton
                
                items = new List<UnlockableItem>();
                Debug.Log("Created new list of items");
               // return;
            }

            if (items.Count==0)
            {
               // LoadItemsFromUnlocakbleList();
            }

            
        }



        public bool SetUnlockItem(string itemName) //unlockingitem when ....
        {
           
            foreach (var unlockeditem in items)
            {
                if (unlockeditem.name == itemName)
                {
                    if (!unlockeditem.isUnlocked) //if false make it true
                    {
                        unlockeditem.isUnlocked = true;
                        return true;
                    }
                }
            }
            
        return false;

    }
        public void ClearNull()
        {
            items.RemoveAll(item => item == null);
        }
        void DebugPrintAllItems()
        {
            StringBuilder sb = new StringBuilder("ALL ITEMS:\n");
            foreach (var item in items)
            {
                sb.AppendLine($"- '{item?.name ?? "NULL"}' (Type: {item?.GetType().Name})");
            }
            Debug.Log(sb.ToString());
        }
        public bool IsUnlocked(string itemName) //if isUnlocked==true then //checker not unlocker
        {
           
            if (progressBar==null||levelManager==null||items==null)
            {
                Debug.LogError("Error refernces is empty");
                return false;

            }
            Debug.Log($"Searching for item {itemName} (among {items.Count} items)" );
            bool itemExists = false;
          
                foreach (var item in items)
                {
                       //itemExists = false;
                    if (item == null) continue;
          

                       if (item.itemName == itemName)
                       {
                           itemExists = true;
                            Debug.Log($"item {itemName}, current unlock status:{item.isUnlocked}");
                            return item.isUnlocked;

                        

                        }
                       //  Debug.Log($"item {itemName} not found");
                           // return false;
                    

                
                }

                if (!itemExists)
                {
                    Debug.Log($"item {itemName} not found");
                    return false;
                }
               
            
        



           

                    //  return true;
               /* }

            return false;*/
               return false;
        }

        public void LockItem(string itemName)
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

           /* if (!isInitialized)
          {
              InititializeItems();
          }
*/
           
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