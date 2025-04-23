using System;

using InventorySystem;

using UnityEngine;
//using UnityEngine.Rendering;

using InventorySystem;
using Narrative;
using Scenes;
using UnityEditor;
using UnityEngine.SceneManagement;

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
 [SerializeField] private  ProgressBar2 progressBar;
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
 private void OnEnable()
 {
   SceneManager.sceneLoaded += OnSceneLoaded;
 }
 private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
 {
 /*  if (scene.name == "Banquet")
   {
     Debug.Log("Entered Banquet scene!");
     // Call your Banquet-specific logic here.
     InitializeBanquet();
   }*/
 }

 private void InitializeBanquet()
 {
   // Your one-time setup code for Banquet.
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

  public void BanquetScene(string itemName)
  {
    if (itemName=="maid_blackedout")
    {
      Debug.Log("maid_blackedout clicked");
    }
  }
  private bool isPrgressComplete()
  {
    return progressBar!=null&&progressBar.completedTasks >= progressBar.TotalTasks;
  }


  public string OnItemClick(string itemName)
  {
    bool itemlocked = unlockManager.CheckUnlockStatus(itemName);
    if (gameObject.name == "RightDoor")
    {
      Debug.Log("Dialogue door");
    }

    if (gameObject.name == "LeftDoor")
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene("Gallery");
      // if (!unlockable.IsUnlocked("Painting1_1"))
      // {
      //   Debug.Log($"wowwww Painting1_1 is unlockingggg");
      //   //unlockManager.UnlockItem("Painting1_1");
      // unlockManager.UnlockItem("Painting1_1");
      // }

     


    }

    if (gameObject.name == "RightBed" || gameObject.name == "LeftBed")
    {
      Debug.Log("Dialogue bed");
    }

    if (gameObject.name == "Mirror")
    {
      Debug.Log("Dialogue mirror");
    }

    /*if (itemName == "Painting1_1")
    {
      //UnityEngine.SceneManagement.SceneManager.LoadScene(levelManager.scenes[7]);
      // progressManager.UnlockSceneInGallery(itemName);
      if (unlockable.IsUnlocked(itemName))
      {
        Debug.Log($" {itemName} is unlocked =true");
        SceneManager.LoadScene(levelManager.scenes[7]);
      }


      return itemName;
    }
*/
   /* if (itemName == "Painting2_1")
    {
      bool ciphherunlocked = unlockable.IsUnlocked("Cipher1");
      bool paintingunlocked = unlockable.IsUnlocked("Painting1");
      bool painting2unlocked = unlockable.IsUnlocked("Painting2_1");


      if (ciphherunlocked && paintingunlocked && levelManager.currentSceneIndex == 6)
      {
        if (!painting2unlocked)
        {
          unlockable.IsUnlocked("Painting2_1");
          SceneManager.LoadScene(levelManager.scenes[8]);
        }
        else
        {
          SceneManager.LoadScene(levelManager.scenes[8]);
        }

      }

      return itemName;
    }

*/

    /*if (itemName.Contains("cherry")) //replace with taskname
    {
      //int curr = progressBar.CurrentProgress;
      string progress = $"{progressBar.completedTasks}/{progressBar.TotalTasks}";
      Debug.Log($" {itemName} is clicked {progress}");
      progressBar.AddProgress();

      //Destroy(gameObject.name);
      // gameObject.SetActive(false);
      Destroy(gameObject);
      return itemName;

    }

    */
   


    foreach (var item in unlockable.items)
    {
      if (item.itemName == itemName)
      {
        if (item.itemName.ToLower() == itemName.ToLower()) // Make case-insensitive comparison
        {
          if (item.itemName == "Painting1_1")
          {
            bool setUnlock = unlockable.IsUnlocked(itemName);

            if (setUnlock == false)
            {
              Debug.Log($" {itemName} hasn't been unlocked yet: status {item.isUnlocked}");
              unlockManager.UnlockItem(itemName);
              Debug.Log($" {itemName} is unlocked : status {item.isUnlocked}");
              SceneManager.LoadScene("TheBanquet");
              return itemName;
            }
          }
        }

      



        //progressManager.CheckProgressAndUnlock("Cipher1"); progressManager.HandleUnlockablesProgress("Cipher1", "Painting1");#
        if (item.itemName.Contains("Cipher"))
        {
         
          Debug.Log($" {itemName} is unlocked status: {item.isUnlocked}  (click item)");
          string progress = $"progress {progressBar.completedTasks}/{progressBar.TotalTasks}";
         

          if (!isPrgressComplete())
          {
          
            Debug.Log("progressbar not full retrn null");
            return null;
          }


          Debug.Log($"Progress (progressbar full)requirement met - checking unlock status{progress}");
          bool cipher=progressManager.CheckProgressAndUnlock(itemName);

          if (cipher)
          {
            
            
           // progressManager.HandleUnlockablesProgress(itemName,null);
            inventory.AddItem(item);
            Debug.Log($" {itemName}/  {item.itemName }added to inventory in clickitem");
            Destroy(gameObject);
            return itemName;
            // Debug.Log($" {itemName}/  {item.itemName }added to inventory in clickitem");

          }

          return null;

          // return itemName;
        }
        if (item.itemName == "Painting2")
        {
          // bool cipherunlocked = progressManager.CheckProgressAndUnlock("Cipher1");
          bool cipherunlocked = unlockable.IsUnlocked("Cipher2");
          // bool paintingunlocked = progressManager.CheckProgressAndUnlock("Painting1");
          Debug.Log($" {itemName}is  unlocked : status  {item.isUnlocked}");
          if (!isPrgressComplete())
          {
            Debug.Log("progressbar not full retrn null");
            return null;
          }
          if (cipherunlocked )
          {
            progressManager.CheckProgressAndUnlock(itemName);
            Debug.Log($" {itemName}is  unlocked : status  {item.isUnlocked}");
            Debug.Log($"Succesfully unlocked cipher1 for {item.itemName} ");
            progressManager.UnlockSceneInGallery(itemName);

            // progressManager.HandleUnlockablesProgress(null,itemName);
          
            SceneManager.LoadScene("GalleryScene");
            return itemName;

          }
          Debug.LogWarning($"Failed to unlock cipher for {item.itemName} despite meeting requirements");

          return null;

        }





        if (item.itemName == "Painting1")
        {
        // bool cipherunlocked = progressManager.CheckProgressAndUnlock("Cipher1");
         bool cipherunlocked = unlockable.IsUnlocked("Cipher1");
        // bool paintingunlocked = progressManager.CheckProgressAndUnlock("Painting1");
         Debug.Log($" {itemName}is  unlocked : status  {item.isUnlocked}");
          if (!isPrgressComplete())
          {
            Debug.Log("progressbar not full retrn null");
            return null;
          }
          if (cipherunlocked )
          {
            progressManager.CheckProgressAndUnlock(itemName);
            Debug.Log($" {itemName}is  unlocked : status  {item.isUnlocked}");
            Debug.Log($"Succesfully unlocked cipher1 for {item.itemName} ");
            progressManager.UnlockSceneInGallery(itemName);

           // progressManager.HandleUnlockablesProgress(null,itemName);
          
            SceneManager.LoadScene("GalleryScene");
            return itemName;

          }
          Debug.LogWarning($"Failed to unlock cipher for {item.itemName} despite meeting requirements");

          return null;

        }

        if (item.itemName == "Painting2_1")
    {
      Debug.Log($" {itemName}is  unlocked : status  {item.isUnlocked}");
      bool cipherUnlocked = unlockable.IsUnlocked("Cipher1");
      bool paintingUnlocked = unlockable.IsUnlocked("Painting1");
      bool painting2Unlocked = unlockable.IsUnlocked("Painting2_1");


      if (cipherUnlocked && paintingUnlocked &&  !levelManager.scenes.Equals("GalleryScene"))
      {
        if (!painting2Unlocked)
        {
          Debug.Log("Unlocking Painting2_1...");
          unlockManager.UnlockItem("Painting2_1");
          
          bool verifyUnlock = unlockable.IsUnlocked("Painting2_1");
          Debug.Log($"Verification - Painting2_1 is now: {verifyUnlock}");
          
          Debug.Log($" {itemName}is  unlocked : status  {item.isUnlocked}");
          Debug.Log($" Going to library");
           SceneManager.LoadScene("LibrarysSene");
         
        }
        else
        {
          Debug.Log($" {itemName} already  been unlocked ");
          Debug.Log($" Going to library");
          SceneManager.LoadScene("LibraryScene");
        }
      
         
         

      }
     
        else
        {
          Debug.Log("Unlock conditions not met. Requires:");
          Debug.Log($"- Cipher1 unlocked: {cipherUnlocked},{unlockable.IsUnlocked("Cipher1")}");
          Debug.Log($"- Painting1 unlocked: {paintingUnlocked},{unlockable.IsUnlocked("Painting1")}");
          Debug.Log($"- Current scene index 6: {levelManager.currentSceneIndex == 7}");
        }
      

     return itemName;
    }

    
        
      }
      else
      {
        Debug.LogWarning($"Item {itemName} not found in the unlockable list.");
      }
      //return itemName;
    }

    return null;
  }

  // Debug.Log("No match found");

    // return null;
  

  
  //ignore the raycasting
  
  
  

  
    public void OnMouseDown(){
      BanquetScene(gameObject.name);

    
     OnItemClick(gameObject.name);

    }

 
    
 
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
