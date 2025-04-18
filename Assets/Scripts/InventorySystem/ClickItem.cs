using System;

using InventorySystem;

using UnityEngine;
//using UnityEngine.Rendering;

using Narrative;
using Scenes;
using UnityEditor;

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
 //public UnlockableItem itemData;
 
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
  [SerializeField] private UnlockManager unlockManager;
  [SerializeField] private LevelManager levelManager;
  

  

  //l clickedbefore;
  //public bool wasClicked;
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
  
  Debug.Log($"Unlockable exists: {unlockable != null}");
  Debug.Log($"ProgressManager exists: {progressManager != null}");
  Debug.Log($"LevelManager exists: {levelManager != null}");
  
}
  void Awake() {
    if (unlockable == null) unlockable =  FindFirstObjectByType<Unlockable>();
    if (progressManager == null) progressManager = FindFirstObjectByType<ProgressManager>();
    if (levelManager == null) levelManager =  FindFirstObjectByType<LevelManager>();
  }

  public void Update()
  {
   // if (wasClicked) return;



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
    // if (unlockable == null) Debug.LogError("Unlockable not set!");
    // if (progressBar == null) Debug.LogError("ProgressBar not set!");
    // if (progressManager == null) Debug.LogError("ProgressManager not set!");
    // if (levelManager == null) Debug.LogError("LevelManager not set!");
    // if (levelManager != null && levelManager.scenes == null) Debug.LogError("LevelManager.scenes not set!");
    //
    // // Exit early if any are null
    // if (unlockable == null || progressBar == null || progressManager == null || levelManager == null || levelManager.scenes == null)
    // {
    //   return null;
    // }



    if (itemName.Contains("cherry"))
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
    if (gameObject.name == "RightDoor")
    {
      Debug.Log("Dialogue door");
    }

    if (gameObject.name == "LeftDoor")
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[6]);

    }

    if (gameObject.name == "RightBed" || gameObject.name == "LeftBed")
    {
      Debug.Log("Dialogue bed");
    }

    if (gameObject.name == "Mirror")
    {
      Debug.Log("Dialogue mirror");
    }
 if (gameObject.name=="Painting1_1")
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
      //return itemName;
    }
        
    foreach(var item in unlockable.items)
    {
      if(itemName==item.name)



      if (!progressManager.isProgressFull) return null;
        
          //progressManager.CheckProgressAndUnlock("Cipher1"); progressManager.HandleUnlockablesProgress("Cipher1", "Painting1");#
          if (item.itemName.Contains("Cipher"))
          {
            progressManager.HandleUnlockablesProgress(itemName,null);
            return itemName;
          }
           if (item.itemName.Contains("Painting"))
          {
           // string paintingName = itemName;
            progressManager.HandleUnlockablesProgress(null, itemName);
           // unlockManager.UnlockItem("Painting1_1");
           

            return itemName;
           
            
          } 
          
    }

   
        
      

    
      //return null;





    

    return itemName;
  }
  // Debug.Log("No match found");

    // return null;
  

  
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
     if (unlockable == null) unlockable =  FindFirstObjectByType<Unlockable>();
     if (progressManager == null) progressManager =  FindFirstObjectByType<ProgressManager>();
     if (levelManager == null) levelManager = FindFirstObjectByType<LevelManager>();
     //string itemName = OnItemClick(unlockable.name);
    

    
     // progressManager.HandleUnlockablesProgress("Cipher1", "Painting1");

    
     OnItemClick(gameObject.name);

    }

    /*
    public void OnMouseExit(){ //remove mouse what happens
      myRenderer.color=origcolour;

    }
    
 */
    private void ShowLockedVisual()
    {
      // Example: Change color to red
      if (TryGetComponent<Renderer>(out var renderer))
      {
        renderer.material.color = Color.red;
      }
    }

    private void ShowUnlockedVisual()
    {
      // Example: Change color to green
      if (TryGetComponent<Renderer>(out var renderer))
      {
        renderer.material.color = Color.green;
      }
    }
}
