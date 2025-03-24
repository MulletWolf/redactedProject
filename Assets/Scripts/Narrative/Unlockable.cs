using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "NewUnlockable", menuName = "Unlockable/Create New Unlockable")]
    public class Unlockable : ScriptableObject
    {

        public UnlockableItem[] items;
        private Dictionary<string, UnlockableItem> itemDictionary;

        private void OnEnable()
        {
            itemDictionary = new Dictionary<string, UnlockableItem>();
            foreach (var item in items)
            {
                itemDictionary[item.itemName] = item;
            }
        }

        public void UnlockItem(string itemName)
        {
            if (itemDictionary.TryGetValue(itemName, out var item) && !item.isUnlocked)
            {
                item.isUnlocked = true;
              //  Debug.Log($"{itemName} has been unlocked!");
            }
        }

        public bool IsUnlocked(string itemName)
        {
            return itemDictionary.TryGetValue(itemName, out var item) && item.isUnlocked;
        }
    }
}