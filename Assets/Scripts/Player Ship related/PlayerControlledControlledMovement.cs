using UnityEngine;

public class PlayerControlledControlledMovement : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D theObject;
    int dodgeTime;
    public int dodgeSpeed;
    public int dodgeFrames;

    Vector2 dodgeMemory = new Vector2();
   
    void Start()
    {
        theObject = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //make sure the player does not move faster in diagonals

        Vector2 movement = new Vector2(x,y);
        movement.Normalize();

        theObject.transform.Translate(new Vector2(x, y) * speed / 10.0f, Space.World);
        theObject.angularVelocity = 0.0f;

        if ((Input.GetButtonDown("Fire1") && movement != Vector2.zero) && dodgeTime == 0) 
        {
            dodgeTime = dodgeFrames;
            dodgeMemory = movement;
            dodgeMemory.Normalize();
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            //Debug.Log("started rolling");
        }
        //What all this does is set a timer for the dodge and record what direction you're dodging in, if you're moving, trying to dodge, and not standing perfectly still.


        if (dodgeTime != 0)
        {
            dodgeTime -= 1;
            dodgeMemory.Normalize();
            theObject.velocity = dodgeMemory * dodgeSpeed;
            //Debug.Log("rolling");

            if(dodgeTime<1)
            {
                this.GetComponent<CapsuleCollider2D>().enabled = true;
                //Debug.Log("stopped rolling");
                //reenable the player collider

                theObject.velocity = Vector2.zero;
            }
        }
        //If you're still dodging (counter isn't zero yet), move in the dodge direction at the dodge speed.
    }
}
