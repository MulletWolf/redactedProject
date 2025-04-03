using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using Microsoft.Unity.VisualStudio.Editor;
using Narrative;
using UnityEngine.Rendering.Universal;
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
  public Inventory inventory;
  SpriteRenderer myRenderer;
  Color origcolour;
  public ProgressBar progressBar;
  public Unlockable unlockable;
  

  //private bool clickedbefore;
  public bool wasClicked;
  /*ClickBehaviour clickBehaviour = ClickBehaviour.None;*/
  
  void Start(){
 ;
    myRenderer=GetComponent<SpriteRenderer>();
    origcolour=myRenderer.material.color;
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



    if (Input.GetMouseButtonDown(0))
    {
      
      // OnItemClick();
      //Raycasting();
       Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.up*0.01f);

      if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
          Debug.Log($"{gameObject.name} was clicked!");
          wasClicked = true;
          //OnItemClick(hit.collider.gameObject.name);
          OnItemClick("");
        }
      }

    

  }


  // private void OnTriggerEnter2D(Collider2D other)
  //   {
  //       if (other.CompareTag("Player")) 
  //       {

  //           Destroy(gameObject); 
  //          
  //       }


  public bool OnItemClick(string itemName)
  {
    bool isPainting = false;
    bool isCipher = false;

    if (unlockable == null)
    {
      Debug.Log("Unlockable null");
      return false;
    }

    foreach (var item in unlockable.items)
    {
      Debug.Log($"Comparing {item.itemName} with {gameObject.name}");
      if (item.itemName == itemName)
      {
        
        Debug.Log($"Item {gameObject.name} clicked, it matches {item.itemName}");
        if (inventory != null)
        {
          inventory.AddItem(itemData);
          Debug.Log($"Clicked and added  {gameObject.name}, to inventory" + itemData.name);
        }

        if (progressBar != null)
        {
          progressBar.AddProgress();
          Debug.Log($"Progress Bar increased  {progressBar.currentProgress}, ");

        }

        myRenderer.material.color = Color.green;
        // Debug.Log($"GameObject destroyed  {gameObject.name}, " + itemData.name);
        // Destroy(gameObject, 0.5f);

        if (item.itemName.Contains("Painting"))
        {
          isPainting = true;
          Debug.Log($"Item {gameObject.name} contains the unlockable item {item.itemName}");
        }

        if (item.itemName.Contains("Cipher"))
        {
          isCipher = true;
          Debug.Log($"Item {gameObject.name} contains  the unlockable item  {item.itemName}");
        }

    
        //   }
        Debug.Log($"GameObject destroyed  {gameObject.name}, " + itemData.name);
        Destroy(gameObject, 0.5f);

       return isPainting || isCipher; //returns ispainting or iscipher

      }
    }
    Debug.Log("No match found");

    return false;
  }

  
  //ignore the raycasting
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
                inventory.AddItem(itemData);

                Debug.Log($"Item : {itemData.itemName}, added to inv");
                // Destroy(gameObject);
                // Debug.Log($"GameObject : {gameObject.name}, destroyed");
              }


              if (progressBar != null)
              {
                progressBar.AddProgress();
                Debug.Log($"Progress Bar increased  {progressBar.currentProgress}, ");

              }


              myRenderer.material.color = Color.green;
              Destroy(gameObject);
              Debug.Log($"GameObject : {gameObject.name}, destroyed");
              if (item.itemName.Contains("Painting"))
              {
                // isPainting=true;
                Debug.Log($"Item {gameObject.name} contains {item.itemName}");
              }

              if (item.itemName.Contains("Cipher"))
              {
                //  isCipher=true;
                Debug.Log($"Item {gameObject.name} contains {item.itemName}");
              }

              //
              // // myRenderer.material.color=Color.red;
              //   OnGemCollected?.Invoke(gemData);//allows other place sto use gemDatat




              // Debug.Log($"ProgressBar : {itemData.itemName}, added to inv");
              //   Destroy(gameObject);
            }

            //Debug.Log("no itemmmmm hittt");
          }

         
      }
 else{
         Debug.Log("No item hit");
        }
      }
     
               
    

    public void OnMouseEnter(){//when u click mouse what happens
      myRenderer.color=Color.red;

    }
    public void OnMouseExit(){ //remove mouse what happens
      myRenderer.color=origcolour;

    }
    
 
 
   
}
