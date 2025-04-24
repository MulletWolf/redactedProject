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
  [SerializeField] private PrgressManager progressBar;
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
      progressBar = FindAnyObjectByType<PrgressManager>(FindObjectsInactive.Include);
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



  


  private bool isPrgressComplete()
  {
    return progressBar != null && progressBar.completedTasks >= progressBar.TotalTasks;
  }


  public void OnItemClick(string itemName)
  {
   
  }

  public string HandlePaintingInSceneClick(string itemName)
  {
    
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
              SceneManager.LoadScene(levelManager.scenes[8]);
              return itemName;
            }
          }
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

          if (cipherunlocked)
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

          if (cipherunlocked)
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


          if (cipherUnlocked && paintingUnlocked && !levelManager.scenes.Equals("GalleryScene"))
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
      //BanquetScene(gameObject.name);

    
     OnItemClick(gameObject.name);
     HandlePaintingInSceneClick(gameObject.name);

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
