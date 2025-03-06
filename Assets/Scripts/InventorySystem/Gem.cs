using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.Rendering.Universal;
[Serializable]
public class Gem : MonoBehaviour
{
 /*public static event HandleGemCollected OnGemCollected;
 
 
 
 public delegate void HandleGemCollected(ItemData itemData);*/
  public ItemData itemData;
  public Inventory inventory;
  SpriteRenderer myRenderer;
  Color origcolour;
  public ProgressBar2 progressBar;
  
  void Start(){
  GameObject inventoryObj = GameObject.FindWithTag("Inventory");
  if(inventoryObj!=null){
    inventory = inventoryObj.GetComponent<Inventory>();
    if (inventory==null)
    {
      Debug.LogError("Inventory found ,but theres no inventory script attached");
    }

  }
  else{
    Debug.Log("Inventory found");

  }
    myRenderer=GetComponent<SpriteRenderer>();
    origcolour=myRenderer.material.color;

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
    public void Raycasting()
    {
        
        
        Vector2 mousePos;
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        RaycastHit2D hit=Physics2D.Raycast(mousePos,Vector2.zero);

        if(hit.collider!=null){
            Debug.Log(hit.collider.gameObject.name +"was hit!");

            if( hit.transform.gameObject == gameObject )
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
             /// inventory.Add(itemData);
             
             progressBar.AddProgress();
               Destroy(gameObject);
            }
        }
        else{
             Debug.Log("No item hit");
        }


    }
    public void OnMouseEnter(){
      myRenderer.material.color=Color.red;

    }
    public void OnMouseExit(){
      myRenderer.material.color=origcolour;

    }
 
 
   
}
