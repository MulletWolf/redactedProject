using System.Collections.Generic;
using Narrative;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<InventoryItem> inventory=new List<InventoryItem>();
    public List<UnlockableItem> items = new List<UnlockableItem>();

    //public InventoryItem inventoryItem;
    // public ItemData itemdata;
    // public Unlockable unlockable;
    //public UnlockableItem newItem;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // For Inventory/ProgressManager
    }


    public void AddItem(UnlockableItem newItem)
    {
        //focusing on
        
        //if lsit already ahs an item then add item

        if (!items.Contains(newItem))
        {
            items.Add(newItem);
            Debug.Log(newItem + "Added mto inventory yayy");
           // Debug.Log($"Added {newItem}");
        }
        else
        {
            Debug.Log($"[Inventory] {newItem.itemName} already exists in inventory");
        }

    }

    public void Remove(UnlockableItem newItem)
    {
        if (items.Contains(newItem))
        {
            items.Remove(newItem);
            Debug.Log(newItem + "Removed from inventory");
        }

        


    }
}



   