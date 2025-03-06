using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventory=new List<InventoryItem>();
    public InventoryItem inventoryItem;
    public ItemData itemData;
    
    

        
    
    //public Dictionary<ItemData,InventoryItem> itemDictionary=new Dictionary<ItemData,InventoryItem>();

   /* private void OnEnable(){
        Gem.OnGemCollected+=Add;
    }
     private void OnDisable(){
        Gem.OnGemCollected-=Add;
    }*/

    public void AddItem(ItemData itemdata){//focusing on
        bool itemisFound=false;
       // InventoryItem newItem= new InventoryItem(itemData);
       // InventoryItem newItem= new InventoryItem(itemData);
        
        foreach(var item in inventory){
            //if item existed increase quantity
            if(item.itemData==itemData){
                itemisFound=true;
                item.IncreaseQuantity();//same thing increase quantity
                //continue;
            // itemisFound=true;
            Debug.Log( itemdata.itemName + "increased to: " + item.quantity);

                break;

            }
        }
        if(!itemisFound){//if it doesnt create new inventory object  and add it to it
         InventoryItem newItem= new InventoryItem(itemData);
       //sse from constructor
        inventory.Add(newItem);
        Debug.Log("Added " + itemdata.itemName + " to inventory.");


        }

       // int numberOfItemsCarried = inventory.Count; // number of items we have picked up
 //   InventoryItem currentItem = inventory[2];//index 2 of inventoru
//this is for showing 1 item at a time using a 1 box 
//press left or right to go up/dowm
    }
     public void Remove(ItemData itemdata){

        foreach(var item in inventory){
          
            if(item.itemData==itemdata){//item=i  =itemdata[i]
                item.DecreaseQuantity();//same thing remove quantity
                //continue;
            
             Debug.Log(itemData+"removed from iventory at "+item.itemData);
              
             if(item.quantity==0)
             {
                 inventory.Remove(item);
                 Debug.Log("Removed " + itemdata.itemName + " from inventory. Total: " + item.quantity);

             }
             else
             {
                 Debug.Log(itemdata.itemName+"decreased to "+item.quantity);
             }

        }
    
       

        }

    }



    /*   public void Add(ItemData itemData){
     if(itemDictionary.TryGetValue(itemData,out  InventoryItem item)){
            item.toAdd();
            Debug.Log(item.itemData.itemName+"stack is "+item);

        }else{
            InventoryItem newItem=new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData,newItem);
              Debug.Log("Added "+ itemData.itemName+" to inventory for first time");


          

        }

    }*/
   /* public void Remove(ItemData itemData){
        if(itemDictionary.TryGetValue(itemData,out  InventoryItem item)){
            item.toRemove();
            if(item.quantity==0){
                inventory.Remove(item);
                itemDictionary.Remove(itemData);

            }

        }

    }*/
}
