using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ClickItemUI:MonoBehaviour,IPointerClickHandler
    {
        public PrgressManager progressBar;

        public Inventory inventory;
       // public GameObject gameObject;

        public Image blackImage;
      //  public Image colouredImage;
        public Sprite colouredSprite;

        public GameObject cipherGameObject;
       /* public void OnPointerClick(PointerEventData eventData)
        {
            ItemClicked(gameObject.name);
         
        }*/

        public void   OnPointerClick(PointerEventData eventData)
        {
            HandleMaidClick(gameObject.name);
            HandleBanquetClick(gameObject.name);
           
        }

        public void HandleMaidClick(string itemName)
        {
            if ( colouredSprite == null  && itemName == "")
            {
                Debug.LogWarning("Reference missing in cclickItemUI script");
                return;
            }

            if (itemName == "maid_blackedout")
            {

                Debug.Log("maid_blackedout clicked");
                // blackImage = colouredImage;
                if (blackImage.sprite != colouredSprite)
                {
                    Debug.Log("Doenst have cooured sprite");
                    blackImage.sprite = colouredSprite;
                    progressBar.AddProgress();


                }
            }
        }

        public void HandleBanquetClick(string itemName)
        {
           

            if (itemName == "banquet_brunette_aritocrat")
            {
                if (!progressBar.isProgressFull())
                {
                    string progress=$"{progressBar.completedTasks}/{progressBar.TotalTasks}";
                    Debug.Log($"ProgressBar not full: {progress}");
                    return;
                }
                if (cipherGameObject!=null&&cipherGameObject.name.Contains("Cipher"))
                {
                    inventory.AddItem(cipherGameObject);
                }
                else
                {
                    Debug.Log($" No valid Cipher.name as a gameobject");
                }
                
            }
            Debug.Log($"Clicked item {itemName} but progressBar isnt full");
        }
    }
}