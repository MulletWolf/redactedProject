using UnityEngine;

/*namespace CoreGameplay.Scripts
{
    public class Inventory2
    {
        public bool AddItem(GameObject itemPrefab)
        {
            // Look for empty slot
            foreach(Transform slotTransform in inventoryPanel.transform)
            {
                Slot slot = slotTransform.GetComponent<Slot>();
                if (slot != null && slot.currentItem == null)
                {
                    GameObject newItem = Instantiate(itemPrefab, slotTransform);
                    newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentItem = newItem;
                    return true;
                }
            }

            Debug.Log("Inventory is full!");
            return false;
        }

    }
}*/