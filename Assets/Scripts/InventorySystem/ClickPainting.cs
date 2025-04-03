using Narrative;
using Unity.VisualScripting;
using UnityEngine;

namespace InventorySystem
{
  public class ClickPainting : MonoBehaviour
  {
    public UnlockableItem itemData;
    public Inventory inventory;
    SpriteRenderer myRenderer;
    public Unlockable unlockable;
    Color origcolour;
    //public ProgressBar progressBar;
    private bool debug = true;

    void Start()
    {
      myRenderer = GetComponent<SpriteRenderer>();
      origcolour = myRenderer.color;


    }

    public void Update()
    {
      if (debug)
      {
        Debug.Log("Debugging");
       // return;
      }
      else
      {
      

      if (Input.GetMouseButtonDown(0))
      {
        ClickP("");

      }
    }
  }
    
    public bool ClickP(string itemName) //use all this for when clicking objects  and what happens when u do
    {
      Vector2 mousePos;
      mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

      if (hit.collider != null)
      {
        Debug.Log(hit.collider.gameObject.name + "was hit!");

        foreach (var item in unlockable.items) {//tracks unlockable items in unlockable

          if (hit.collider.gameObject.name == item.itemName)
          {

            if (item.itemName.Contains("Painting")) //and this what happens when u clcik an object
            {
            //  PaintingClick(item);
            Debug.Log("Painting"+item.itemName);
              return itemName.Contains("Painting");
              //Debug.Log("Painting");
              

            }
             if (item.itemName.Contains("Cipher"))
            {
              
              inventory.AddItem(itemData);
              Debug.Log("Cipher"+item.itemName+"added to inventory");
              return true;

            }
          }

          
//return false;

        }
      }

      Debug.Log("No item hit");
      return false;
    }

  

  public void CipherClick(Unlockable item)
  {
    
  }

  public void PaintingClick(Unlockable item)
  {
    
    
  }

  public void OnMouseEnter(){//when u click mouse what happens
      myRenderer.material.color=Color.red;

    }
    public void OnMouseExit(){ //remove mouse what happens
      myRenderer.material.color=origcolour;

    }
 
 
   
    }
}