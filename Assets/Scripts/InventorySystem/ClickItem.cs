using System;

using InventorySystem;

using UnityEngine;
//using UnityEngine.Rendering;

using InventorySystem;
using Narrative;
using Scenes;
using UnityEditor;

[Serializable]
public class ClickItem : MonoBehaviour
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
 // [SerializeField] private ProgressBar progressBar;
 public ProgressBar2 progressBar;
  [SerializeField] private Unlockable unlockable;

  [SerializeField] private ProgressManager progressManager;
  [SerializeField] private UnlockManager unlockManager;
  [SerializeField] private LevelManager levelManager;
  public static ClickItem instance;

 // private bool hasbeenClicked = false;




 void Start()
 {



   if (inventory != null)
   {
     inventory = inventory.GetComponent<Inventory>();
     if (inventory == null)
     {
       inventory = GameObject.FindWithTag("Inventory")?.GetComponent<Inventory>();

       Debug.LogError("Inventory found ,but theres no inventory script attached");
     }

   }
   else
   {
     Debug.Log("Inventory not found");
   }

   if (progressBar == null)
   {
     progressBar = FindAnyObjectByType<ProgressBar2>(FindObjectsInactive.Include);
     if (progressBar == null)
     {
       Debug.LogError("ProgressBar object not found in the scene!");
     }
   }


 }

 void Awake()
 {
//   DontDestroyOnLoad(instance);
 }



  // private void OnTriggerEnter2D(Collider2D other)
  //   {
  //       if (other.CompareTag("Player")) 
  //       {

  //           Destroy(gameObject); 
  //          
  //       }

  /*public string Mainroom(string itemName)
  {
      if (itemName.Contains("cherry"))//replace with taskname
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
          if (!unlockable.IsUnlocked("Painting1_1"))
          {
            Debug.Log($"wowwww Painting1_1 is unlockingggg");
             unlockManager.UnlockItem("Painting1_1");
          }


        }

        if (gameObject.name == "RightBed" || gameObject.name == "LeftBed")
        {
          Debug.Log("Dialogue bed");
        }

        if (gameObject.name == "Mirror")
        {
          Debug.Log("Dialogue mirror");
        }

        return null;

  }
*/


  public string OnItemClick(string itemName)
  {
     bool itemlocked = unlockManager.CheckUnlockStatus(itemName);
    if (gameObject.name == "RightDoor")
    {
      Debug.Log("Dialogue door");
    }

    if (gameObject.name == "LeftDoor")
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[6]);
      if (!unlockable.IsUnlocked("Painting1_1"))
      {
        Debug.Log($"wowwww Painting1_1 is unlockingggg");
        unlockManager.UnlockItem("Painting1_1");
      }


    }

    if (gameObject.name == "RightBed" || gameObject.name == "LeftBed")
    {
      Debug.Log("Dialogue bed");
    }

    if (gameObject.name == "Mirror")
    {
      Debug.Log("Dialogue mirror");
    }

    if (itemName == "Painting1_1")
    {
      //UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
      // progressManager.UnlockSceneInGallery(itemName);
      if (unlockable.IsUnlocked(itemName))
      {
        Debug.Log($" {itemName} is unlocked =true");
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
      }


      return itemName;
    }



    if (itemName.Contains("cherry") ) //replace with taskname
    {
      //int curr = progressBar.CurrentProgress;
      string progress = $"{progressBar.currentProgress}/{progressBar.maxProgress}";
 Debug.Log($" {itemName} is clicked {progress}");
      progressBar.AddProgress();
     
      //Destroy(gameObject.name);
      // gameObject.SetActive(false);
      Destroy(gameObject);
      return itemName;

    }


   

      foreach (var item in unlockable.items)
      {
        if (item.itemName == itemName)
        {
          /*  if (item.itemName=="Painting1_1")
           {
             //UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
             // progressManager.UnlockSceneInGallery(itemName);
             if ( unlockable.IsUnlocked(item.itemName))
             {
               Debug.Log($" {itemName} is unlocked =true");
               UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
             }


             return itemName;
           }
  */


         

          //progressManager.CheckProgressAndUnlock("Cipher1"); progressManager.HandleUnlockablesProgress("Cipher1", "Painting1");#
          if (item.itemName.Contains("Cipher"))
          {
            string progress = $"progress {progressBar.currentProgress}/{progressBar.maxProgress}";
            //UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
            // progressManager.UnlockSceneInGallery(itemName);
            // if (progressManager.isProgressFull) return null;

            if (progressBar.currentProgress < progressBar.maxProgress) return null;


            if (progressBar.currentProgress >= progressBar.maxProgress)
            {
              //
              //  bool unlocked = progressManager.CheckProgressAndUnlock(item.itemName);
              if (itemlocked)
              {
                
                Debug.Log($"{itemName} is locked nooooooooooooooo");
              }





              //unlockManager.UnlockItem(item.itemName);



              Debug.Log($" {itemName} is locked =false");
              if (!unlockManager.CheckUnlockStatus(item.itemName))
              {
                Debug.Log($"{itemName}Hasnt been unlocked yet");
                unlockManager.UnlockItem(item.itemName);
              }
              else
              {
                Debug.Log($"{itemName}Has beeeeeeen unlocked yet");
              }


              Debug.Log($" {itemName} is unlocked ==true");
              // progressManager.HandleUnlockablesProgress(itemName, null);
              inventory.AddItem(item);
              Debug.Log($" {itemName} is added to inv=true");
              Destroy(gameObject);





            }

            else
            {
              Debug.Log($" ProgressBar not full{progress}");
            }
          }



          if (item.itemName.Contains("Painting"))
          {
            // string paintingName = itemName;
            progressManager.HandleUnlockablesProgress(null, itemName);
            // unlockManager.UnlockItem("Painting1_1");


            return itemName;


          }



       }
      }



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
    /* if (unlockable == null) unlockable =  FindFirstObjectByType<Unlockable>();
     if (progressManager == null) progressManager =  FindFirstObjectByType<ProgressManager>();
     if (levelManager == null) levelManager = FindFirstObjectByType<LevelManager>();*/
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
