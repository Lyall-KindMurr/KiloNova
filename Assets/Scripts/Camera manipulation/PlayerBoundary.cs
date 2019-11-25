using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    Rigidbody2D theObject;
    public float limitX = 8, limitminuX = -8, limitminusY =-5;
    public float pushingForce;

    //variables are sepparate, to allow a non-symetrical environment during gameplay

    void Start()
    {
        theObject = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //theObject.transform.position = new Vector2(Mathf.Clamp(transform.position.x, limitminuX, limitX),
         //   transform.position.y);

        
        if(theObject.transform.position.x > limitX)
        {
            theObject.transform.position = new Vector2(limitX, theObject.transform.position.y);
            
            Debug.Log("Hit right wall");

            theObject.AddForce(new Vector2(-pushingForce * theObject.velocity.x, 0), ForceMode2D.Impulse);


            //sets the item position to the edge, and gives them slight velocity towards the center
        }

        //the object goes offscreen to the left

        else if(theObject.transform.position.x < limitminuX)
        {
            theObject.transform.position = new Vector2(limitminuX, theObject.transform.position.y);
            theObject.velocity = Vector2.zero;
            Debug.Log("Hit left wall");
            theObject.velocity = new Vector2(pushingForce *theObject.velocity.x, 0);
        }
        
        if(theObject.transform.position.y < limitminusY)
        {
            theObject.transform.position = new Vector2(theObject.transform.position.x, limitminusY);
            theObject.velocity = Vector2.zero;
            Debug.Log("Hit lower wall");
            theObject.velocity = new Vector2(0, pushingForce * theObject.velocity.x);
        }



    }
}
