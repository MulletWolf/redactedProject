using System;

using InventorySystem;

using UnityEngine;
//using UnityEngine.Rendering;

using Narrative;

[Serializable]
public class ClickItem: MonoBehaviour
{
 /*public static event HandleGemCollected OnGemCollected; 
 public delegate void HandleGemCollected(ItemData itemData);*/
 
/* enum ClickBehaviour
 {
   None,
   OpenScene,
   ShowPicture
 } 
 */
 public UnlockableItem itemData;
 
 /* SpriteRenderer myRenderer;
  Color origcolour;*/
  
 //  public GameObject Cipher1;
   // public GameObject Cipher2;
   // public GameObject Cipher3;
//  public GameObject GetCipher1() => Cipher1; 
  
  [SerializeField] private Inventory inventory;
  [SerializeField] private ProgressBar progressBar;
  [SerializeField] private Unlockable unlockable;
  [SerializeField] private ProgressManager progressManager;

  

  //l clickedbefore;
  public bool wasClicked;
  /*ClickBehaviour clickBehaviour = ClickBehaviour.None;*/
  
  void Start(){

   /* if (Cipher1!=null)
    {
       myRenderer = Cipher1.GetComponent<SpriteRenderer>();
       // myRenderer = Cipher2.GetComponent<SpriteRenderer>();
       // myRenderer = Cipher3.GetComponent<SpriteRenderer>();
    }
*/
   //origcolour=myRenderer.color;
  if(inventory!=null){
    inventory = inventory.GetComponent<Inventory>();
    if (inventory==null)
    {
      inventory= GameObject.FindWithTag("Inventory")?.GetComponent<Inventory>();

      Debug.LogError("Inventory found ,but theres no inventory script attached");
    }

  }
  else{
    Debug.Log("Inventory not found");
  }
  

  if (progressBar == null)
  {
    progressBar = FindFirstObjectByType<ProgressBar>();
    Debug.LogError("ProgressBar object not found in the scene!");
  } 
  

}

  public void Update()
  {
    if (wasClicked) return;



   /* if (Input.GetMouseButtonDown(0))
    {

      // OnItemClick();
      //Raycasting();

      Debug.Log($"{gameObject.name} was clicked!");
      wasClicked = true;
      //OnItemClick(hit.collider.gameObject.name);
      OnItemClick(gameObject.name);


//
    }*/
   //OnItemClick(gameObject.name);

  }

  // private void OnTriggerEnter2D(Collider2D other)
  //   {
  //       if (other.CompareTag("Player")) 
  //       {

  //           Destroy(gameObject); 
  //          
  //       }


  public string OnItemClick(string itemName)
  {
   

    if (unlockable == null)
    {
      Debug.Log("Unlockable null");
     // return false;
     return null;
    }

   

      if (gameObject.name.Contains("cherry"))
      {
        Debug.Log($"Progress Bar currentprogress :  {progressBar.currentProgress}, ");
        Debug.Log($"{itemName} is {gameObject.name}");
        progressBar.AddProgress();
        Debug.Log($"Progress Bar increased cherry {progressBar.currentProgress}, ");
        Destroy(gameObject);
        //return false;
        return "cherry";

      }
      //wait time here
    
    foreach (var item in unlockable.items)
    {
      //Debug.Log($"Comparing {item.itemName} with {gameObject.name}");
      if (item.itemName == itemName)
      {
        
        //Debug.Log($"Item {gameObject.name} clicked, it matches {item.itemName}");
      
       
          if (item.itemName.Contains("Cipher"))
          {
              // ProgressManager.CheckProgressAndUnlock(item.itemName);
              // progressManager.HandleUnlockablesProgress(item.itemName, item.itemName);
             progressManager.CheckProgressAndUnlock(item.itemName);
             inventory.AddItem(itemData);
              Debug.Log($"Item {gameObject.name}is added to the inventory ");
               //isCipher = true;
               //  Debug.Log($"Item {gameObject.name} contains  the unlockable item  {item.itemName}");
             return item.itemName;
         }
          /*
            if (item.itemName.Contains("Painting"))
                  {
                   // ProgressManager.UnlockScene();
                    progressManager.CheckProgressAndUnlock(itemName);
                   // isPainting = true;
                    Debug.Log($"Item {gameObject.name} contains the unlockable item {item.itemName}");
                    return item.itemName; 
                  }
*/
    
        //   }
       // Debug.Log($"GameObject destroyed  {gameObject.name}, " + itemData.name);
        //   Destroy(gameObject, 0.5f);

         // return isPainting || isCipher; //returns ispainting or iscipher

      }
    }
   // Debug.Log("No match found");

    return null;
  }

  
  //ignore the raycasting
  
  /*
  
  public void Raycasting()
    {


      Vector2 mousePos;
      mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

      if (hit.collider != null)
      {
        //  Debug.Log(hit.collider.gameObject.name +" was hit! " + gameObject.name + " is me...");


        foreach (var item in unlockable.items)
        {
        //  {
            Debug.Log($"Item {gameObject.name} clicked, it matches {item.itemName}");

            if (hit.transform.gameObject == gameObject)
            {
              Debug.Log("Handling " + gameObject.name + " was hit! " + gameObject.name + " is me...");

              if (inventory != null)
              {
             
              }


              


             
              Destroy(gameObject);
              Debug.Log($"GameObject : {gameObject.name}, destroyed");
              if (item.itemName.Contains("Painting"))
              {
                // isPainting=true;
                Debug.Log($"Item {gameObject.name} contains {item.itemName}");
              }

              if (item.itemName.Contains("Cipher"))
              {
               
                Debug.Log($"Item {gameObject.name} contains {item.itemName}");
              }

         
            }

            //Debug.Log("no itemmmmm hittt");
        }
      }
      else{
            Debug.Log("No item hit"); 
      }
   }
     
               
  */  
  
    public void OnMouseDown(){//when u click mouse what happens
     // myRenderer.color=Color.red;
     OnItemClick(gameObject.name);

    }
    /*
    public void OnMouseExit(){ //remove mouse what happens
      myRenderer.color=origcolour;

    }
    
 */
 
   
}
