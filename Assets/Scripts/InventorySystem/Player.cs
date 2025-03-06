using UnityEngine;

public class player : MonoBehaviour
{
   
    Rigidbody2D rb;
    Vector2 move;
    public float speed=10f;
 
    void Start()//called once
    {
        rb=GetComponent<Rigidbody2D>();
        gameObject.name="Diva";
       // transform.position=new Vector2(transform.position.x,-3.155135f);
       
        
    }

    // Update is called once per frame //called continously
    void FixedUpdate()

    { 
         move=new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        //Debug.Log("movement:"+move);
          rb.linearVelocity=speed*move;
        
    }
    void Update(){
         transform.rotation = Quaternion.identity;

     
         

    }
}
