using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    Vector2 move;
    [Header("Camera settings")]
    public float camspeed=7f;
    // Start is called before the first frame update
    void Start()

    {

        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement(camspeed,move);

    }
       
    public void CameraMovement(float camspeed,Vector2 move){
         move=new Vector2(0,0);
       // moveX=0;
      //  moveY=0;
        
        if(Input.GetKey(KeyCode.LeftArrow)){
            move=move+new Vector2(-camspeed,0);
           
           // moveX=-1f;
           // transform.Translate(Vector2.left*camspeed*Time.deltaTime);

        }
        if(Input.GetKey(KeyCode.RightArrow)){
             move=move+new Vector2(camspeed,0);
             
            // moveX=1f;
           // transform.Translate(Vector2.right*camspeed*Time.deltaTime);


        }
         if(Input.GetKey(KeyCode.UpArrow)){
            move=move+new Vector2(0,camspeed);
            
          //  transform.Translate(Vector2.up*camspeed*Time.deltaTime);

        }
        if(Input.GetKey(KeyCode.DownArrow)){
             move=move+new Vector2(0,-camspeed);
            
           // transform.Translate(Vector2.down*camspeed*Time.deltaTime);


        }
        transform.Translate(move*Time.deltaTime);
    }
    public void Raycasting(){
        

    }



    }


