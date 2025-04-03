/*
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
namespace InventorySystem
{
  
}
[Serializable]
public class DoorRaycast: MonoBehaviour
{
 public static event HandleGemCollected OnGemCollected; 
 public delegate void HandleGemCollected(ItemData itemData);
 
enum ClickBehaviour
 {
   None,
   OpenScene,
   ShowPicture
 } 
 
  public UnlockableItem itemData;
  public Inventory inventory;
  SpriteRenderer myRenderer;

  public ProgressBar progressBar;

  private bool clickedbefore;
 
  
  void Start(){
  GameObject inventoryObj = GameObject.FindWithTag("Inventory");
    myRenderer=GetComponent<SpriteRenderer>();
    
  if(inventoryObj!=null){
    inventory = inventoryObj.GetComponent<Inventory>();
    if (inventory==null)
    {
      Debug.LogError("Inventory found ,but theres no inventory script attached");
    }

  }
  else{
    Debug.Log("Inventory not found");
  }
  

  if (progressBar != null)
  {
    
    progressBar = FindFirstObjectByType<ProgressBar>();
  }
  else
  {
    Debug.LogError("Progress Bar object not found in the scene!");
  }
  

}
  public void Update(){
    if(Input.GetMouseButtonDown(0))
    {
      Raycasting();

    }
  }

  
 
    public void Raycasting()
    {
    
     if (clickedbefore) return;
     clickedbefore = true; 
        
        
        Vector2 mousePos;
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
       
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.up,0.1f);

     

        if(hit.collider!=null){
            Debug.Log(hit.transform.gameObject.name +"was hit!");

            if( hit.collider.gameObject == gameObject )
            {
              
              if (inventory!=null)
              {
                inventory.AddItem(itemData);
                Debug.Log($"Added {itemData.name} to inventory");
              }
              else
              {
                Debug.Log($"Inventory is empty");
              }
             
              if (progressBar != null)
              {
                progressBar.AddProgress();
                 Debug.Log($"GameObject  {itemData.name}, detsroyed");
                 Destroy(gameObject);
                 
                
              }
              else
              {
                Debug.Log("ProgressbBar doenst exist");
              }
              
           
            }
        }
        else{
             Debug.Log("No item hit");
             
        }


    }
    public void OnMouseEnter(){//when u click mouse what happens

      if (myRenderer!=null)
      {
        myRenderer.color=Color.blue;
      }
      else
      {
        Debug.Log("renderer is missing");
      }
     

    }
    public void OnMouseExit(){ 
    
      if (myRenderer != null)
      {
        myRenderer.color = Color.magenta;
      }
      else
      {
        Debug.LogError("SpriteRenderer is missing on this GameObject!");
      }

    }
 
 
   
}
*/