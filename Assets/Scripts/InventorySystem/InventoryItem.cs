using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
//using Microsoft.Unity.VisualStudio.Editor;
[Serializable]
public class InventoryItem 
{
   [Header ("UI")]
   public ItemData itemData;
   public Image image;
   public int quantity;

   public InventoryItem(ItemData item){
    this.itemData=item;
    IncreaseQuantity();
    //inventory inventory =ne inventory(); it takes in itemdata 

   }
   public void showitem(ItemData newItem){
    
   }
   public void IncreaseQuantity(){
   
    if(quantity==0){
      quantity=1; //used to set quantity to 0 first then wehne used becomes 1

    }
    else{
      quantity++;

    }

   }
    public void DecreaseQuantity(){
        if(quantity>0){
         quantity--;
         if(quantity==0){
            Debug.Log("Item removed from inventory");

         }

        }
    
   }
}
