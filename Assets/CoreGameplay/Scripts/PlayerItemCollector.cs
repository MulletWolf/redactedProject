// add this method to your inventory system script for it to work!!!!!


// PlayerItemCollector Script
using System.Collections;
using System.Collections.Generic;
using CoreGameplay.Scripts;
using Narrative;
using UnityEditor;
using UnityEngine;

/*public class PlayerItemCollector : MonoBehaviour
{
   // private InventoryController inventoryController;
    public Inventory inventoryController;
    public UnlockableItem itemData;

    // Start is called before the first frame update
    void Start()
    {
       // inventoryController = FindObjectOfType<Inventory>();
        inventoryController = FindFirstObjectByType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Progress.Item item = collision.GetComponent<Progress.Item>();
            if (item != null)
            {
              
               inventoryController.AddItem(itemData);
                Destroy(collision.gameObject);
                
            }
        }
    }
}
*/
  // Add item to inventory
               // bool itemAdded = inventoryController.AddItem(collision.gameObject);
               //inventoryController.AddItem(collision.gameObject);