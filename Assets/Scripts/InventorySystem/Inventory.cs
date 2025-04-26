using System.Collections.Generic;
using Narrative;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<InventoryItem> inventory=new List<InventoryItem>();
    public List<Sprite> inventorySprites = new List<Sprite>();
    public static Inventory instance;

       void Awake()
    {
        
        
        
        if (instance != null )
        {
            Destroy(gameObject);
            return;
        }
   
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
            //clear before game starts
            inventorySprites.Clear();
            Debug.Log($"Inventory s: {inventorySprites.Count} has been cleared");
        
       
    }



    public void AddItem(GameObject newItem)
    {
        //focusing on

        //if lsit already ahs an item then add item
        Sprite itemSprite = newItem.GetComponent<SpriteRenderer>().sprite;
        if (itemSprite == null)
        {
            Debug.Log($"Item sprite is null");
        }


        if (newItem.name.Contains("Cipher"))
        {
            inventorySprites.Add(itemSprite);
            Debug.Log($"Item sprite of: {newItem.name} added to inventory");
        }
        else
        {
            Debug.Log($"{newItem.name} doesn't contain Cipher");

        }
    }

    public void Remove(GameObject newItem)
    {
        Sprite itemSprite = newItem.GetComponent<SpriteRenderer>().sprite;
        if (inventorySprites.Contains(itemSprite))
        {
            inventorySprites.Remove(itemSprite);
            Debug.Log($"{newItem.name} has been removed from inventory");
        }

        


    }
}



   