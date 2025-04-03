using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
   // [CreateAssetMenu(fileName = "NewUnlockable", menuName = "Unlockable/Create New Unlockable")]

   public class Unlockable:MonoBehaviour

   {
   // public UnlockableItem unlockableItem;

   public List<UnlockableItem> items;
  // public List<ItemData> ciphers;
   private Dictionary<string, UnlockableItem> itemDictionary;


   // public List<UnlockableItem> itemList=new List<UnlockableItemItem>();

   private void OnEnable() //each item is added into inventory
   {
       if (items == null || items.Count == 0)
       {
           // Debug.Log("Unlockable items not found");
           //add each item ton
       }

       itemDictionary = new Dictionary<string, UnlockableItem>();

       foreach (var item in items)
       {

           itemDictionary[item.itemName] = item;
       }


   }

   public bool UnlockItem(string itemName) //unlockingitem when ....
   {
       if (itemDictionary.TryGetValue(itemName, out var item) && !item.isUnlocked)
       {
         return  item.isUnlocked = true;
           //  Debug.Log($"{itemName} has been unlocked!");
       }

       return false;
   }

   public bool IsUnlocked(string itemName) //if isUnlocked==true then 
   {
       return itemDictionary.TryGetValue(itemName, out var item) && item.isUnlocked;
   }
   }
}