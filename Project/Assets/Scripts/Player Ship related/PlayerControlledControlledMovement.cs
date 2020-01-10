using UnityEngine;

public class PlayerControlledControlledMovement : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D theObject;
    int dodgeTime;
    public int dodgeSpeed;
    public int dodgeFrames;
    public int rollCooldown;
    public int coinCount;

    private int canRoll;

    Animator anim;

    Vector2 dodgeMemory = new Vector2();

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;



    void AddCoins(int howMany)
    {
        coinCount += howMany;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theObject = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //tick down the roll variable

        if (canRoll > 0)
        {
            canRoll--;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //make sure the player does not move faster in diagonals

        Vector2 movement = new Vector2(x, y);
        movement.Normalize();

        theObject.transform.Translate(new Vector2(x, y) * speed / 10.0f, Space.World);
        theObject.angularVelocity = 0.0f;

        if ((Input.GetMouseButton(1) && movement != Vector2.zero) && dodgeTime == 0 && canRoll <= 0)
        {
            dodgeTime = dodgeFrames;
            dodgeMemory = movement;
            dodgeMemory.Normalize();
            this.GetComponent<CapsuleCollider2D>().enabled = false;

            //rolling animation elements

            if (movement.x < 0)
            {
                anim.SetBool("Rolling Left", true);
            }
            else if (movement.x > 0)
            {
                anim.SetBool("Rolling Right", true);
            }

        }
        //What all this does is set a timer for the dodge and record what direction you're dodging in, if you're moving, trying to dodge, and not standing perfectly still.


        if (dodgeTime != 0)
        {
            dodgeTime -= 1;
            dodgeMemory.Normalize();
            theObject.velocity = dodgeMemory * dodgeSpeed;
            //Debug.Log("rolling");

            if (dodgeTime < 1)
            {
                //stop the rolling animation
                anim.SetBool("Rolling Right", false);
                anim.SetBool("Rolling Left", false);
                Debug.Log("ended rolling");
                this.GetComponent<CapsuleCollider2D>().enabled = true;
                //Debug.Log("stopped rolling");
                //reenable the player collider

                theObject.velocity = Vector2.zero;

                //stop rolling for a while

                canRoll = rollCooldown;
            }
        }
        //If you're still dodging (counter isn't zero yet), move in the dodge direction at the dodge speed.
    }
    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
