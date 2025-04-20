using System.Collections.Generic;
using Narrative;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<InventoryItem> inventory=new List<InventoryItem>();
    public List<string> invitems = new List<string>();
    public static Inventory instance;
    public Unlockable unlockable;

    //public InventoryItem inventoryItem;
    // public ItemData itemdata;
    // public Unlockable unlockable;
    //public UnlockableItem newItem;

       void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
             DontDestroyOnLoad(gameObject); // For Inventory/ProgressManager
        }
        Destroy(gameObject);
        */
        
        if (instance != null )
        {
            Destroy(gameObject);
            return;
        }
   
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        
       
    }
       


    public void AddItem(UnlockableItem newItem)
    {
        //focusing on
        
        //if lsit already ahs an item then add item

        foreach (var item in unlockable.items)
        {
            if (item == newItem)
            {

                if (!invitems.Contains(item.itemName))
                {
                    invitems.Add(item.itemName);
                    Debug.Log(item.itemName + "Added mto inventory yayy");
                    // Debug.Log($"Added {newItem}");
                }
                else
                {
                    Debug.Log($"[Inventory] {item.itemName} already exists in inventory");
                }
            }
        }

    }

    public void Remove(string newItem)
    {
        if (invitems.Contains(newItem))
        {
            invitems.Remove(newItem);
            Debug.Log(newItem + "Removed from inventory");
        }

        


    }
}



   