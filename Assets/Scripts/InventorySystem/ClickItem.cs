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
 
 enum ClickBehaviour
 {
   None,
   OpenScene,
   ShowPicture
 } 
 
  public UnlockableItem itemData;
  public Inventory inventory;
  SpriteRenderer myRenderer;
  Color origcolour;
  public ProgressBar progressBar;
  
  ClickBehaviour clickBehaviour = ClickBehaviour.None;
  
  void Start(){
  GameObject inventoryObj = GameObject.FindWithTag("Inventory");
    myRenderer=GetComponent<SpriteRenderer>();
    origcolour=myRenderer.material.color;
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
  

}
  public void Update(){
    if(Input.GetMouseButtonDown(0)){
      Raycasting();

    }
  }

  
  // private void OnTriggerEnter2D(Collider2D other)
  //   {
  //       if (other.CompareTag("Player")) 
  //       {

  //           Destroy(gameObject); 
  //          
  //       }
  //   }
    public void Raycasting()//use all this for when clicking objects  and what happens when u do
    {
        
        
        Vector2 mousePos;
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        RaycastHit2D hit=Physics2D.Raycast(mousePos,Vector2.zero);

        if(hit.collider!=null){
            Debug.Log(hit.collider.gameObject.name +"was hit!");

            if( hit.transform.gameObject == gameObject )//and this what happens when u clcik an object
            {
              //
              // if (progressBar != null)
              // {
              //   progressBar.AddProgress();
              //    Destroy(gameObject);
              // }
              // else
              // {
              //   Debug.Log("ProgressbBar doenst exist");
              // }
              //
            // // myRenderer.material.color=Color.red;
         //   OnGemCollected?.Invoke(gemData);//allows other place sto use gemDatat
              inventory.AddItem(itemData);
              Debug.Log("inventory added to inventory"+itemData.name);
              ;
             
             progressBar.AddProgress();//use this for each tasks
             Debug.Log("added to inventory"+itemData.name);
              Destroy(gameObject);
              Debug.Log("Gameobject destroyed"+itemData.name);
              // return true;
            }
        }
        else{
             Debug.Log("No item hit");
             
        }
//return false;

    }
    public void OnMouseEnter(){//when u click mouse what happens
      myRenderer.material.color=Color.red;

    }
    public void OnMouseExit(){ //remove mouse what happens
      myRenderer.material.color=origcolour;

    }
 
 
   
}
