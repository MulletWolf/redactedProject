using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{
    public class ClickItemUI:MonoBehaviour,IPointerEnterHandler
    {
        public PrgressManager progressBar;
       // public GameObject gameObject;

        public Image blackImage;

      //  public Image colouredImage;

        public Sprite colouredSprite;
       /* public void OnPointerClick(PointerEventData eventData)
        {
            ItemClicked(gameObject.name);
         
        }*/

        public void   OnPointerEnter(PointerEventData eventData)
        {
            ItemClicked(gameObject.name);
        }

        public void ItemClicked(string itemName)
        {
            if (itemName=="maid_blackedout")
            {
                Debug.Log("maid_blackedout clicked");
               // blackImage = colouredImage;
                if (blackImage.sprite!=colouredSprite)
                {
                    Debug.Log("Doenst have cooured sprite");
                    blackImage.sprite = colouredSprite;
                    progressBar.AddProgress();
                    

                }
               
               // itemName=gameObject.name;
             
                
            }
        }
    }
}